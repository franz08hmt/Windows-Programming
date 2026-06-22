using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using SysColor = System.Drawing.Color;

namespace QuanLySinhVien
{
    public partial class f_Contact : UserControl
    {
        private My_DB db = new My_DB();
        private DataView contactView;
        private byte[] contactImage = null;
        private static readonly HttpClient httpClient = new HttpClient();

        private string currentUserId => Globals.GlobalUserId ?? "0";

        // xóa trước khi push GitHub:
        private const string GEMINI_KEY_CONTACT = "";

        // Chuỗi placeholder cố định để so sánh logic
        private const string PLACEHOLDER_TEXT = "Tìm kiếm theo tên hoặc số điện thoại";

        public f_Contact()
        {
            InitializeComponent();
            ApplyContactModernTheme();
            BuildImportAIButtons();
            SetupEventHandlers();
        }

        private void f_Contact_Load(object sender, EventArgs e)
        {
            EnsureContactSchemaAndDemoData();
            LoadGroupsToComboBoxAndGrid();
            LoadContactList();
            cboGroup_SelectedIndexChanged_1(null, null); // Áp dụng bộ lọc theo nhóm đang chọn
            SetupSuggestList();
            SetupPlaceholderSearch();
            dgvContacts.CellClick += new DataGridViewCellEventHandler(dgvContacts_CellClick);
        }

        private void EnsureContactSchemaAndDemoData()
        {
            try
            {
                db.openConnection();

                new SqlCommand(@"
IF OBJECT_ID('dbo.Groups','U') IS NULL
    CREATE TABLE dbo.Groups (
        ID INT IDENTITY(1,1) PRIMARY KEY,
        Name NVARCHAR(100) NOT NULL,
        UserID NVARCHAR(20) NOT NULL);", db.conn).ExecuteNonQuery();

                new SqlCommand(@"
IF OBJECT_ID('dbo.Contact','U') IS NULL
    CREATE TABLE dbo.Contact (
        ID INT IDENTITY(1,1) PRIMARY KEY,
        Fname NVARCHAR(50) NOT NULL, Lname NVARCHAR(50) NOT NULL,
        Dob DATETIME NULL, Gender NVARCHAR(10) NULL, Group_ID INT NULL,
        Phone NVARCHAR(20) NULL, Address NVARCHAR(250) NULL,
        Email NVARCHAR(100) NULL, Pic IMAGE NULL,
        UserID NVARCHAR(20) NOT NULL);", db.conn).ExecuteNonQuery();

                // Xóa bản ghi bị lỗi từ seed cũ (Fname = số nguyên)
                var cleanCmd = new SqlCommand(
                    "DELETE FROM dbo.Contact WHERE ISNUMERIC(Fname) = 1 AND UserID = @uid", db.conn);
                cleanCmd.Parameters.AddWithValue("@uid", currentUserId);
                cleanCmd.ExecuteNonQuery();

                // Nếu dữ liệu hiện tại không phù hợp với vai trò → xóa và seed lại đúng vai trò
                int position = Globals.GlobalPosition;
                if (IsWrongRoleSeed(position))
                    DeleteAllUserContactsAndGroups();

                // Seed danh bạ theo vai trò tài khoản
                if (position == 0)       SeedAdminContacts();     // Admin: liên hệ quản trị trường
                else if (position == 2)  SeedHRContacts();        // Giảng viên: đồng nghiệp, sinh viên
                else                     SeedStudentContacts();   // Sinh viên: gia đình, bạn học
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khởi tạo dữ liệu danh bạ: " + ex.Message);
            }
            finally { db.closeConnection(); }
        }

        // Trả về true nếu nhóm "chỉ điểm" của vai trò khác xuất hiện → dữ liệu seed sai vai trò
        private bool IsWrongRoleSeed(int position)
        {
            string markerGroup = "";
            if (position == 0 || position == 2)
                markerGroup = "Bạn cùng lớp";   // Admin/GV không nên có nhóm kiểu sinh viên
            else
                markerGroup = "Ban giám hiệu";  // Sinh viên không nên có nhóm kiểu admin

            var cmd = new SqlCommand(
                "SELECT COUNT(*) FROM dbo.Groups WHERE Name=@n AND UserID=@uid", db.conn);
            cmd.Parameters.AddWithValue("@n", markerGroup);
            cmd.Parameters.AddWithValue("@uid", currentUserId);
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        private void DeleteAllUserContactsAndGroups()
        {
            var c1 = new SqlCommand("DELETE FROM dbo.Contact WHERE UserID=@uid", db.conn);
            c1.Parameters.AddWithValue("@uid", currentUserId);
            c1.ExecuteNonQuery();

            var c2 = new SqlCommand("DELETE FROM dbo.Groups WHERE UserID=@uid", db.conn);
            c2.Parameters.AddWithValue("@uid", currentUserId);
            c2.ExecuteNonQuery();
        }

        // ── Admin: Ban giám hiệu / Phòng ban / Giảng viên / Đối tác trường (16 liên hệ) ──
        private void SeedAdminContacts()
        {
            int g1 = EnsureGroupExists("Ban giám hiệu");
            int g2 = EnsureGroupExists("Phòng ban");
            int g3 = EnsureGroupExists("Giảng viên");
            int g4 = EnsureGroupExists("Đối tác trường");

            var cnt = new SqlCommand("SELECT COUNT(*) FROM dbo.Contact WHERE UserID=@uid", db.conn);
            cnt.Parameters.AddWithValue("@uid", currentUserId);
            if (Convert.ToInt32(cnt.ExecuteScalar()) >= 16) return;

            // Ban giám hiệu — 3
            InsertContact("Nguyễn", "Văn Khải",   new DateTime(1968,  3, 15), "Nam", g1, "0919001001", "HCMUTE, Thủ Đức, TP.HCM",     "hieupho.khai@hcmute.edu.vn");
            InsertContact("Trần",   "Thị Mai",     new DateTime(1972,  7, 22), "Nữ",  g1, "0919001002", "HCMUTE, Thủ Đức, TP.HCM",     "pho.mai@hcmute.edu.vn");
            InsertContact("Lê",     "Quốc Bảo",   new DateTime(1970, 11,  5), "Nam", g1, "0919001003", "HCMUTE, Thủ Đức, TP.HCM",     "pho.bao@hcmute.edu.vn");

            // Phòng ban — 4
            InsertContact("Phạm",   "Hồng Hà",    new DateTime(1980,  4, 12), "Nữ",  g2, "0919002001", "Phòng Đào tạo, HCMUTE",        "daotao@hcmute.edu.vn");
            InsertContact("Vũ",     "Thanh Long",  new DateTime(1982,  8, 20), "Nam", g2, "0919002002", "Phòng CTSV, HCMUTE",           "ctsv@hcmute.edu.vn");
            InsertContact("Đặng",   "Thùy An",    new DateTime(1985,  2, 14), "Nữ",  g2, "0919002003", "Phòng Tài chính, HCMUTE",      "taichinh@hcmute.edu.vn");
            InsertContact("Bùi",    "Minh Tuấn",  new DateTime(1979,  9, 30), "Nam", g2, "0919002004", "Phòng CNTT, HCMUTE",           "cntt@hcmute.edu.vn");

            // Giảng viên đầu ngành — 5
            InsertContact("Ngô",    "Minh Phúc",  new DateTime(1975,  6, 18), "Nam", g3, "0919003001", "Khoa CNTT, HCMUTE",            "truongkhoa.cntt@hcmute.edu.vn");
            InsertContact("Đinh",   "Văn Khoa",   new DateTime(1973,  1, 25), "Nam", g3, "0919003002", "Khoa Điện tử, HCMUTE",         "truongkhoa.dt@hcmute.edu.vn");
            InsertContact("Lý",     "Quốc Hùng",  new DateTime(1969,  5, 10), "Nam", g3, "0919003003", "Khoa Cơ khí, HCMUTE",          "truongkhoa.ck@hcmute.edu.vn");
            InsertContact("Hoàng",  "Thị Xuân",   new DateTime(1977, 12,  8), "Nữ",  g3, "0919003004", "Khoa Hóa học, HCMUTE",         "truongkhoa.hh@hcmute.edu.vn");
            InsertContact("Nguyễn", "Bảo Quốc",   new DateTime(1974,  3, 28), "Nam", g3, "0919003005", "Khoa Kinh tế, HCMUTE",         "truongkhoa.kt@hcmute.edu.vn");

            // Đối tác trường — 4
            InsertContact("Trần",   "Thanh Minh", new DateTime(1983,  7, 15), "Nam", g4, "0919004001", "Tầng 5, FPT Software, Thủ Đức", "partnership@fpt.edu.vn");
            InsertContact("Lê",     "Thị Hương",  new DateTime(1986, 10, 20), "Nữ",  g4, "0919004002", "Tòa nhà Viettel, Q.10, TP.HCM", "education@viettel.com.vn");
            InsertContact("Phan",   "Văn Đức",    new DateTime(1984,  4,  5), "Nam", g4, "0919004003", "Grab Vietnam, Quận 1, TP.HCM", "talent@grab.com");
            InsertContact("Võ",     "Thị Lan",    new DateTime(1988,  1, 18), "Nữ",  g4, "0919004004", "VNPT Technology, TP.HCM",      "recruit@vnpt-technology.vn");
        }

        // ── Giảng viên/HR: Đồng nghiệp / Sinh viên tiêu biểu / Ban giám hiệu / Đối tác học thuật (16 liên hệ) ──
        private void SeedHRContacts()
        {
            int g1 = EnsureGroupExists("Đồng nghiệp");
            int g2 = EnsureGroupExists("Sinh viên tiêu biểu");
            int g3 = EnsureGroupExists("Ban giám hiệu");
            int g4 = EnsureGroupExists("Đối tác học thuật");

            var cnt = new SqlCommand("SELECT COUNT(*) FROM dbo.Contact WHERE UserID=@uid", db.conn);
            cnt.Parameters.AddWithValue("@uid", currentUserId);
            if (Convert.ToInt32(cnt.ExecuteScalar()) >= 16) return;

            // Đồng nghiệp — 5
            InsertContact("Nguyễn", "Thành Trung", new DateTime(1982,  4, 10), "Nam", g1, "0918001001", "Khoa CNTT, HCMUTE",            "ttrung@hcmute.edu.vn");
            InsertContact("Trần",   "Thị Bích",    new DateTime(1985,  8, 25), "Nữ",  g1, "0918001002", "Khoa CNTT, HCMUTE",            "tbich@hcmute.edu.vn");
            InsertContact("Lê",     "Hữu Phước",   new DateTime(1979, 12,  3), "Nam", g1, "0918001003", "Khoa CNTT, HCMUTE",            "hphuoc@hcmute.edu.vn");
            InsertContact("Phạm",   "Ngọc Lan",    new DateTime(1983,  6, 17), "Nữ",  g1, "0918001004", "Khoa CNTT, HCMUTE",            "ngoclan@hcmute.edu.vn");
            InsertContact("Vũ",     "Quang Hải",   new DateTime(1980,  2, 28), "Nam", g1, "0918001005", "Khoa CNTT, HCMUTE",            "qhai@hcmute.edu.vn");

            // Sinh viên tiêu biểu — 4
            InsertContact("Đặng",   "Minh Khoa",   new DateTime(2003,  5, 14), "Nam", g2, "0918002001", "KTX Đại học Quốc gia, Thủ Đức", "minhkhoa.sv@hcmute.edu.vn");
            InsertContact("Bùi",    "Thị Thu",     new DateTime(2003,  9, 20), "Nữ",  g2, "0918002002", "Quận 9, TP.HCM",               "thithu.sv@hcmute.edu.vn");
            InsertContact("Hoàng",  "Văn Toàn",   new DateTime(2004,  1,  7), "Nam", g2, "0918002003", "Thủ Đức, TP.HCM",              "vantoan.sv@hcmute.edu.vn");
            InsertContact("Ngô",    "Thị Cẩm",    new DateTime(2004,  3, 22), "Nữ",  g2, "0918002004", "Bình Dương",                   "thicam.sv@hcmute.edu.vn");

            // Ban giám hiệu — 3
            InsertContact("Đinh",   "Văn Toàn",   new DateTime(1965,  7, 12), "Nam", g3, "0918003001", "HCMUTE, Thủ Đức",              "hieupho1@hcmute.edu.vn");
            InsertContact("Lý",     "Thị Hoa",    new DateTime(1970,  3, 18), "Nữ",  g3, "0918003002", "HCMUTE, Thủ Đức",              "truongkhoa@hcmute.edu.vn");
            InsertContact("Phan",   "Quang Minh", new DateTime(1968, 11,  5), "Nam", g3, "0918003003", "HCMUTE, Thủ Đức",              "phocntt@hcmute.edu.vn");

            // Đối tác học thuật — 4
            InsertContact("Võ",     "Thanh Hùng",  new DateTime(1975,  8, 30), "Nam", g4, "0918004001", "Đại học Bách khoa, TP.HCM",    "thunghv@hcmut.edu.vn");
            InsertContact("Nguyễn", "Thị Yến",    new DateTime(1978,  4, 15), "Nữ",  g4, "0918004002", "Viện CNTT, TP.HCM",            "thiyennv@itep.edu.vn");
            InsertContact("Trần",   "Công Danh",  new DateTime(1980, 12, 20), "Nam", g4, "0918004003", "Đại học KHTN, TP.HCM",         "congdanh@hcmus.edu.vn");
            InsertContact("Lê",     "Thị Bình",   new DateTime(1982,  6, 10), "Nữ",  g4, "0918004004", "Đại học UEH, TP.HCM",          "thibinh@ueh.edu.vn");
        }

        // ── Sinh viên: Gia đình / Bạn cùng lớp / Giảng viên / Đối tác học tập (16 liên hệ) ──
        private void SeedStudentContacts()
        {
            int g1 = EnsureGroupExists("Gia đình");
            int g2 = EnsureGroupExists("Bạn cùng lớp");
            int g3 = EnsureGroupExists("Giảng viên");
            int g4 = EnsureGroupExists("Đối tác học tập");

            var cnt = new SqlCommand("SELECT COUNT(*) FROM dbo.Contact WHERE UserID=@uid", db.conn);
            cnt.Parameters.AddWithValue("@uid", currentUserId);
            if (Convert.ToInt32(cnt.ExecuteScalar()) >= 16) return;

            // Gia đình — 4
            InsertContact("Nguyễn", "Minh Anh",   new DateTime(2004,  3, 12), "Nữ",  g1, "0901234567", "Quận 1, TP HCM",        "minhanh@example.com");
            InsertContact("Nguyễn", "Văn An",     new DateTime(1975,  6,  8), "Nam", g1, "0902345678", "Bình Dương",              "nvan@example.com");
            InsertContact("Nguyễn", "Thị Bình",   new DateTime(1978,  9, 20), "Nữ",  g1, "0903456789", "Quận 1, TP HCM",        "ntbinh@example.com");
            InsertContact("Trần",   "Gia Huy",    new DateTime(2006,  1, 15), "Nam", g1, "0904567890", "Thủ Đức, TP HCM",       "giahuy@example.com");

            // Bạn cùng lớp — 5
            InsertContact("Trần",   "Quốc Bảo",   new DateTime(2003,  7, 24), "Nam", g2, "0912345678", "Thủ Đức, TP HCM",       "quocbao@example.com");
            InsertContact("Hoàng",  "Thị Lan",    new DateTime(2004,  2, 14), "Nữ",  g2, "0913456789", "Gò Vấp, TP HCM",        "thilan@example.com");
            InsertContact("Vũ",     "Minh Đức",   new DateTime(2003, 11,  3), "Nam", g2, "0914567890", "Quận 12, TP HCM",       "minhduc@example.com");
            InsertContact("Đặng",   "Thùy Linh",  new DateTime(2004,  5, 30), "Nữ",  g2, "0915678901", "Bình Thạnh, TP HCM",    "thuylinh@example.com");
            InsertContact("Bùi",    "Văn Tuấn",   new DateTime(2003,  8, 22), "Nam", g2, "0916789012", "Tân Bình, TP HCM",      "vantuan@example.com");

            // Giảng viên — 3
            InsertContact("Lê",     "Hoàng Nam",  new DateTime(1985, 11,  4), "Nam", g3, "0987654321", "HCMUTE, Thủ Đức",       "hoangnam@hcmute.edu.vn");
            InsertContact("Phạm",   "Văn Hùng",   new DateTime(1980,  3, 17), "Nam", g3, "0988765432", "HCMUTE, Thủ Đức",       "vanhung@hcmute.edu.vn");
            InsertContact("Trần",   "Thị Hoa",    new DateTime(1988,  7,  9), "Nữ",  g3, "0989876543", "HCMUTE, Thủ Đức",       "thihoa@hcmute.edu.vn");

            // Đối tác học tập — 4
            InsertContact("Phạm",   "Thanh Trúc", new DateTime(2004, 10, 18), "Nữ",  g4, "0933456789", "Bình Thạnh, TP HCM",    "thanhtruc@example.com");
            InsertContact("Ngô",    "Minh Quân",  new DateTime(2003,  4, 25), "Nam", g4, "0934567890", "Quận 3, TP HCM",        "minhquan@example.com");
            InsertContact("Lý",     "Thị Ngọc",   new DateTime(2004,  8, 11), "Nữ",  g4, "0935678901", "Quận 7, TP HCM",        "thingoc@example.com");
            InsertContact("Đinh",   "Văn Tùng",   new DateTime(2003, 12,  5), "Nam", g4, "0936789012", "Nhà Bè, TP HCM",        "vantung@example.com");
        }

        private int EnsureGroupExists(string name)
        {
            SqlCommand chk = new SqlCommand(
                "SELECT TOP 1 ID FROM dbo.Groups WHERE Name=@n AND UserID=@uid", db.conn);
            chk.Parameters.AddWithValue("@n",   name);
            chk.Parameters.AddWithValue("@uid", currentUserId);
            object existing = chk.ExecuteScalar();
            return (existing != null) ? Convert.ToInt32(existing) : InsertContactGroup(name);
        }

        private int InsertContactGroup(string name)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Groups (Name, UserID) VALUES (@name, @uid); SELECT CAST(SCOPE_IDENTITY() AS INT);", db.conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@uid", currentUserId);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        // Trả về true nếu đã tồn tại liên hệ trùng (Phone hoặc Fname+Lname) của user này
        private bool IsDuplicateContact(string phone, string fname, string lname)
        {
            SqlCommand cmd;
            if (!string.IsNullOrWhiteSpace(phone))
            {
                cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM dbo.Contact WHERE LTRIM(RTRIM(Phone))=@ph AND UserID=@uid",
                    db.conn);
                cmd.Parameters.AddWithValue("@ph", phone.Trim());
                cmd.Parameters.AddWithValue("@uid", currentUserId);
            }
            else
            {
                cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM dbo.Contact WHERE Fname=@fn AND Lname=@ln AND UserID=@uid",
                    db.conn);
                cmd.Parameters.AddWithValue("@fn", fname ?? "");
                cmd.Parameters.AddWithValue("@ln", lname ?? "");
                cmd.Parameters.AddWithValue("@uid", currentUserId);
            }
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        // Xóa các bản ghi trùng lặp (Fname+Lname+Phone+UserID), giữ ID nhỏ nhất mỗi nhóm
        private int CleanDuplicateContacts()
        {
            try
            {
                db.openConnection();
                var cmd = new SqlCommand(@"
                    DELETE FROM dbo.Contact
                    WHERE ID NOT IN (
                        SELECT MIN(ID)
                        FROM dbo.Contact
                        GROUP BY Fname, Lname, COALESCE(Phone,''), UserID
                    )
                    AND UserID = @uid", db.conn);
                cmd.Parameters.AddWithValue("@uid", currentUserId);
                return cmd.ExecuteNonQuery();
            }
            catch { return 0; }
            finally { db.closeConnection(); }
        }

        // Trả về true nếu insert thành công, false nếu trùng lặp (bỏ qua)
        private bool InsertContact(string fname, string lname, DateTime dob, string gender, int groupId, string phone, string address, string email)
        {
            if (IsDuplicateContact(phone, fname, lname)) return false;

            SqlCommand cmd = new SqlCommand(
                "INSERT INTO dbo.Contact (Fname, Lname, Dob, Gender, Group_ID, Phone, Address, Email, Pic, UserID) " +
                "VALUES (@fn, @ln, @dob, @gender, @gid, @phone, @address, @email, NULL, @uid)", db.conn);
            cmd.Parameters.AddWithValue("@fn", fname);
            cmd.Parameters.AddWithValue("@ln", lname);
            cmd.Parameters.AddWithValue("@dob", dob);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@gid", groupId);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@uid", currentUserId);
            cmd.ExecuteNonQuery();
            return true;
        }

        private void ApplyContactModernTheme()
        {
            Color page = Color.FromArgb(242, 246, 252);
            Color primary = Color.FromArgb(0, 61, 149);
            Color text = Color.FromArgb(18, 31, 53);

            tcbContact.Appearance = TabAppearance.FlatButtons;
            tcbContact.ItemSize = new Size(170, 34);
            tcbContact.SizeMode = TabSizeMode.Fixed;
            tabPage1.BackColor = page;
            tabPage2.BackColor = page;


            StyleContactGrid(dgvGroup);
            StyleContactGrid(dgvContacts);



            picContact.BackColor = Color.FromArgb(235, 242, 252);
            picContact.SizeMode = PictureBoxSizeMode.Zoom;

            // Fix ngày sinh hiển thị dạng "dd/MM/yyyy" thay vì dạng dài đầy đủ
            dtpDob.Format = DateTimePickerFormat.Custom;
            dtpDob.CustomFormat = "dd/MM/yyyy";

            // Căn đều 4 nút hành động trong panel3 (panel3 width = 811)
            // 4 × 180 + 3 × 12 + 2 × 27 = 720 + 36 + 54 = 810
            int bw = 180, bh = 52, bY = 714, gap = 12, startX = 27;
            btnAddContact.SetBounds(startX,                  bY, bw, bh);
            btnFixContact.SetBounds(startX +   (bw + gap),   bY, bw, bh);
            btnRefreshContact.SetBounds(startX + 2*(bw + gap), bY, bw, bh);
            btnDeleteContact.SetBounds(startX + 3*(bw + gap), bY, bw, bh);

            // Căn đều 2 nút quản lý nhóm trong panel1 (panel1 width = 523)
            // 2 × 200 + 1 × 20 + 2 × 51 = 400 + 20 + 102 = 522
            btnAddGroup.SetBounds(51, 233, 200, 55);
            btnDeleteGroup.SetBounds(271, 233, 200, 55);
        }

        private void BuildImportAIButtons()
        {
            // Designer.cs đã wire btnImportCSV_Click và btnAISuggestGroup_Click,
            // hai stub đó gọi async version — không đăng ký thêm ở đây.
        }

        private IEnumerable<Control> GetAllControls(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                yield return control;
                foreach (Control child in GetAllControls(control))
                    yield return child;
            }
        }

        private void StyleContactGrid(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 61, 149);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 38;
            dgv.RowHeadersVisible = false;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10f);
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgv.GridColor = Color.FromArgb(226, 232, 240);
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void StyleActionButton(Button button, Color backColor, Color foreColor)
        {
            button.BackColor = backColor;
            button.ForeColor = foreColor;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            button.Cursor = Cursors.Hand;
        }

        private void CardPanel_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);
            using (GraphicsPath path = RoundedRect(rect, 12))
            using (Pen pen = new Pen(Color.FromArgb(222, 231, 242), 1))
            {
                panel.Region = new Region(path);
                e.Graphics.DrawPath(pen, path);
            }
        }

        private GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void SetupEventHandlers()
        {
            // Chỉ đăng ký những sự kiện KHÔNG có trong Designer.cs
            // (Load, btnAddGroup, btnDeleteGroup, btnChooseImage, bntSearchContact,
            //  txtSearchContact.TextChanged, dgvGroup.CellClick, dgvContacts.CellClick,
            //  txtAddress.TextChanged, lstSuggest.Click, btnFixContact, btnRefreshContact
            //  đều đã được Designer.cs đăng ký → không đăng ký lại)

            txtSearchContact.Enter += new EventHandler(txtSearchContact_Enter);
            txtSearchContact.Leave += new EventHandler(txtSearchContact_Leave);
            txtSearchContact.KeyDown += new KeyEventHandler(txtSearchContact_KeyDown);
            bntSearchContact.Click += new EventHandler(bntSearchContact_Click);

            btnAddContact.Click += (s, e) => AddContact();
            btnDeleteContact.Click += (s, e) => DeleteContact();

            RegisterContactRealTimeValidation();
        }

        private bool ValidateContactInput()
        {
            // 🛠️ ĐÃ SỬA: Loại bỏ dòng kiểm tra Component lỗi, clear trực tiếp biến cục bộ
            erpContact.Clear();
            bool isValid = true;

            if (string.IsNullOrEmpty(txtFname.Text.Trim()))
            { erpContact.SetError(txtFname, "Vui lòng nhập Họ!"); isValid = false; }
            else if (Regex.IsMatch(txtFname.Text.Trim(), @"\d"))
            { erpContact.SetError(txtFname, "Họ không được chứa chữ số!"); isValid = false; }

            if (string.IsNullOrEmpty(txtLname.Text.Trim()))
            { erpContact.SetError(txtLname, "Vui lòng nhập Tên!"); isValid = false; }
            else if (Regex.IsMatch(txtLname.Text.Trim(), @"\d"))
            { erpContact.SetError(txtLname, "Tên không được chứa chữ số!"); isValid = false; }

            if (cboGender.SelectedIndex == -1 || string.IsNullOrEmpty(cboGender.Text))
            { erpContact.SetError(cboGender, "Vui lòng chọn Giới tính!"); isValid = false; }

            if (cboGroup2.SelectedValue == null)
            { erpContact.SetError(cboGroup2, "Vui lòng chọn phân loại Nhóm!"); isValid = false; }

            if (string.IsNullOrEmpty(txtPhone.Text.Trim()))
            { erpContact.SetError(txtPhone, "Số điện thoại không được để trống!"); isValid = false; }
            else if (!long.TryParse(txtPhone.Text.Trim(), out _))
            { erpContact.SetError(txtPhone, "Số điện thoại không hợp lệ! Chỉ được chứa chữ số."); isValid = false; }

            if (!string.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                if (!Regex.IsMatch(txtEmail.Text.Trim(), @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                { erpContact.SetError(txtEmail, "Định dạng Email không đúng quy định!"); isValid = false; }
            }

            return isValid;
        }

        private void RegisterContactRealTimeValidation()
        {
            txtFname.TextChanged += (s, e) => {
                if (string.IsNullOrEmpty(txtFname.Text.Trim())) erpContact.SetError(txtFname, "Vui lòng nhập Họ!");
                else if (Regex.IsMatch(txtFname.Text.Trim(), @"\d")) erpContact.SetError(txtFname, "Họ không được chứa chữ số!");
                else erpContact.SetError(txtFname, "");
            };

            txtLname.TextChanged += (s, e) => {
                if (string.IsNullOrEmpty(txtLname.Text.Trim())) erpContact.SetError(txtLname, "Vui lòng nhập Tên!");
                else if (Regex.IsMatch(txtLname.Text.Trim(), @"\d")) erpContact.SetError(txtLname, "Tên không được chứa chữ số!");
                else erpContact.SetError(txtLname, "");
            };

            txtPhone.TextChanged += (s, e) => {
                if (string.IsNullOrEmpty(txtPhone.Text.Trim())) erpContact.SetError(txtPhone, "Số điện thoại không được để trống!");
                else if (!long.TryParse(txtPhone.Text.Trim(), out _)) erpContact.SetError(txtPhone, "Số điện thoại chỉ được chứa chữ số!");
                else erpContact.SetError(txtPhone, "");
            };

            txtEmail.TextChanged += (s, e) => {
                string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                if (!Regex.IsMatch(txtEmail.Text.Trim(), pattern) && txtEmail.Text.Length > 0)
                    erpContact.SetError(txtEmail, "Định dạng Email không đúng!");
                else erpContact.SetError(txtEmail, "");
            };

            cboGender.SelectedIndexChanged += (s, e) => erpContact.SetError(cboGender, "");
            cboGroup2.SelectedIndexChanged += (s, e) => erpContact.SetError(cboGroup2, "");
        }

        // 🌟 LOGIC TRỰC XUẤT 1: Thiết lập chữ mờ gợi ý ban đầu
        private void SetupPlaceholderSearch()
        {
            txtSearchContact.Text = PLACEHOLDER_TEXT;
            txtSearchContact.ForeColor = Color.Gray; // Chữ màu xám mờ ảo diện mạo chuyên nghiệp
        }

        // 🌟 LOGIC TRỰC XUẤT 2: Khi nhấp chuột vào -> Xóa chữ gợi ý để người dùng nhập
        private void txtSearchContact_Enter(object sender, EventArgs e)
        {
            if (txtSearchContact.Text == PLACEHOLDER_TEXT)
            {
                txtSearchContact.Text = "";
                txtSearchContact.ForeColor = Color.Black; // Đổi lại chữ đen bình thường để gõ
            }
        }

        // 🌟 LOGIC TRỰC XUẤT 3: Khi nhấp ra ngoài -> Nếu trống thì hiện lại chữ gợi ý
        private void txtSearchContact_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchContact.Text))
            {
                SetupPlaceholderSearch();
            }
        }

        // 🌟 LOGIC TRỰC XUẤT 4: Nhấn nút Enter trên bàn phím để kích hoạt tìm kiếm luôn
        private void txtSearchContact_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ThucHienTimKiemDanhBa();
                e.Handled = true; // Ngăn tiếng "ting" hệ thống của Windows khi nhấn Enter
                e.SuppressKeyPress = true; // Không truyền phím Enter xuống dưới tránh xuống dòng vô nghĩa
            }
        }

        // 🌟 LOGIC TRỰC XUẤT 5: Bắt sự kiện Click của nút btnSearchContact
        private void bntSearchContact_Click(object sender, EventArgs e)
        {
            ThucHienTimKiemDanhBa();
        }


        // 🚀 HÀM CORE: Xử lý bộ lọc tìm kiếm danh bạ an toàn, bọc thép bẫy ký tự đặc biệt
        private void ThucHienTimKiemDanhBa()
        {
            if (contactView == null) return;

            string keyword = txtSearchContact.Text.Trim();

            // Nếu ô tìm kiếm đang rỗng hoặc đang hiển thị chữ placeholder mặc định -> Hủy lọc, hiện full bảng
            if (string.IsNullOrEmpty(keyword) || txtSearchContact.Text == PLACEHOLDER_TEXT)
            {
                contactView.RowFilter = "";
            }
            else
            {
                // Né lỗi SQL injection phá chuỗi phá dòng bằng cách replace dấu nháy đơn
                string safeKeyword = keyword.Replace("'", "''");
                contactView.RowFilter = $"Fname LIKE '%{safeKeyword}%' OR Lname LIKE '%{safeKeyword}%' OR Phone LIKE '%{safeKeyword}%'";
            }

            UpdateTotalCount(); // Cập nhật lại số lượng liên lạc hiển thị trên nhãn bộ đếm
        }

        private void LoadGroupsToComboBoxAndGrid()
        {
            string query = "SELECT ID, Name FROM Groups WHERE UserID = @uid ORDER BY Name";
            try
            {
                SqlCommand cmd = new SqlCommand(query, db.getConnection);
                cmd.Parameters.AddWithValue("@uid", currentUserId);
                DataTable dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);

                // dgvGroup: chỉ hiển thị các nhóm thực (không có "Tất cả")
                dgvGroup.DataSource = dt;
                dgvGroup.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvGroup.Columns["ID"].HeaderText = "Mã nhóm";
                dgvGroup.Columns["Name"].HeaderText = "Tên nhóm danh bạ";

                // cboGroup (tab Quản lý nhóm): thêm "Tất cả nhóm" (ID=0) lên đầu để lọc danh bạ
                DataTable dtCbo = dt.Copy();
                DataRow allRow = dtCbo.NewRow();
                allRow["ID"] = 0;
                allRow["Name"] = "— Tất cả nhóm —";
                dtCbo.Rows.InsertAt(allRow, 0);
                cboGroup.DataSource = dtCbo;
                cboGroup.DisplayMember = "Name";
                cboGroup.ValueMember = "ID";

                // cboGroup2 (tab Quản lý danh bạ): chỉ các nhóm thực
                cboGroup2.DataSource = dt.Copy();
                cboGroup2.DisplayMember = "Name";
                cboGroup2.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi nạp nhóm: " + ex.Message);
            }
        }

        private void btnAddGroup_Click_1(object sender, EventArgs e)
        {
            string groupName = txtGroupName.Text.Trim();
            if (string.IsNullOrEmpty(groupName))
            {
                MessageBox.Show("Ní vui lòng nhập tên nhóm mới trước khi bấm Thêm nhé!", "Thiếu thông tin");
                return;
            }

            string query = "INSERT INTO Groups (Name, UserID) VALUES (@name, @uid)";
            try
            {
                db.openConnection();
                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@name", groupName);
                cmd.Parameters.AddWithValue("@uid", currentUserId);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Đã thêm nhóm danh bạ mới thành công tốt đẹp!", "Thành công");
                    txtGroupName.Clear();
                    LoadGroupsToComboBoxAndGrid();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi thực thi thêm nhóm: " + ex.Message); }
            finally { db.closeConnection(); }
        }

        private void btnDeleteGroup_Click_1(object sender, EventArgs e)
        {
            if (cboGroup.SelectedValue == null) return;
            int groupId = (int)cboGroup.SelectedValue;

            DialogResult confirm = MessageBox.Show($"Xóa nhóm này sẽ tự động gỡ liên kết toàn bộ danh bạ thuộc nhóm! Ní có chắc không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                db.openConnection();
                string updateContact = "UPDATE Contact SET Group_ID = NULL WHERE Group_ID = @gid AND UserID = @uid";
                SqlCommand cmdUpdate = new SqlCommand(updateContact, db.conn);
                cmdUpdate.Parameters.AddWithValue("@gid", groupId);
                cmdUpdate.Parameters.AddWithValue("@uid", currentUserId);
                cmdUpdate.ExecuteNonQuery();

                string deleteGroup = "DELETE FROM Groups WHERE ID = @gid AND UserID = @uid";
                SqlCommand cmdDel = new SqlCommand(deleteGroup, db.conn);
                cmdDel.Parameters.AddWithValue("@gid", groupId);
                cmdDel.Parameters.AddWithValue("@uid", currentUserId);

                if (cmdDel.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Đã xóa nhóm liên hệ ra khỏi hệ thống!", "Thông báo");
                    LoadGroupsToComboBoxAndGrid();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi xóa nhóm: " + ex.Message); }
            finally { db.closeConnection(); }
        }

        private void dgvGroup_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            cboGroup.SelectedValue = Convert.ToInt32(dgvGroup.Rows[e.RowIndex].Cells["ID"].Value);
        }

        private void LoadContactList()
        {
            string query = "SELECT c.ID, c.Fname, c.Lname, c.Dob, c.Gender, g.Name AS 'TenNhom', c.Phone, c.Email, c.Address, c.Pic, c.Group_ID " +
                           "FROM Contact c LEFT JOIN Groups g ON c.Group_ID = g.ID " +
                           "WHERE c.UserID = @uid";
            try
            {
                SqlCommand cmd = new SqlCommand(query, db.getConnection);
                cmd.Parameters.AddWithValue("@uid", currentUserId);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                contactView = new DataView(dt);
                dgvContacts.DataSource = contactView;

                dgvContacts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvContacts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvContacts.RowTemplate.Height = 50;

                dgvContacts.Columns["ID"].HeaderText = "Mã";
                dgvContacts.Columns["Fname"].HeaderText = "Họ";
                dgvContacts.Columns["Lname"].HeaderText = "Tên";
                dgvContacts.Columns["Dob"].HeaderText = "Ngày sinh";
                dgvContacts.Columns["Dob"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvContacts.Columns["Gender"].HeaderText = "Giới tính";
                dgvContacts.Columns["TenNhom"].HeaderText = "Nhóm";
                dgvContacts.Columns["Phone"].HeaderText = "Số điện thoại";
                dgvContacts.Columns["Email"].HeaderText = "Email";
                dgvContacts.Columns["Address"].HeaderText = "Địa chỉ";

                if (dgvContacts.Columns["Pic"] != null)
                {
                    dgvContacts.Columns["Pic"].HeaderText = "Ảnh";
                    ((DataGridViewImageColumn)dgvContacts.Columns["Pic"]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                }
                if (dgvContacts.Columns["Group_ID"] != null) dgvContacts.Columns["Group_ID"].Visible = false;

                UpdateTotalCount();
            }
            catch (Exception ex) { Console.WriteLine("Lỗi nạp danh bạ: " + ex.Message); }
        }

        private void UpdateTotalCount()
        {
            if (dgvContacts.DataSource == null) return;
            int total = dgvContacts.AllowUserToAddRows ? dgvContacts.Rows.Count - 1 : dgvContacts.Rows.Count;
            if (total < 0) total = 0;
            txtTotalContact.Text = "Tổng số liên lạc: " + total;
        }

        private void AddContact()
        {
            if (!ValidateContactInput())
            {
                MessageBox.Show("Vui lòng kiểm tra và chỉnh sửa lại các thông tin lỗi (Xem ký hiệu đỏ) trước khi thêm!", "Thao tác bị chặn", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (string.IsNullOrEmpty(txtFname.Text.Trim()) || string.IsNullOrEmpty(txtLname.Text.Trim()))
            {
                MessageBox.Show("Ní vui lòng điền đầy đủ Họ và Tên liên hệ nhé!", "Thiếu thông tin");
                return;
            }
            if (cboGroup2.SelectedValue == null)
            {
                MessageBox.Show("Ní vui lòng tạo nhóm bên Tab Quản lý nhóm và chọn phân loại nhóm trước khi thêm nhé!", "Thiếu phân loại");
                return;
            }

            string query = "INSERT INTO Contact (Fname, Lname, Dob, Gender, Group_ID, Phone, Address, Email, Pic, UserID) " +
                           "VALUES (@fn, @ln, @dob, @gder, @gid, @phone, @addr, @email, @pic, @uid)";
            try
            {
                db.openConnection();

                if (IsDuplicateContact(txtPhone.Text.Trim(), txtFname.Text.Trim(), txtLname.Text.Trim()))
                {
                    MessageBox.Show("Liên hệ này đã tồn tại trong danh bạ!", "Trùng lặp",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@fn", txtFname.Text.Trim());
                cmd.Parameters.AddWithValue("@ln", txtLname.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", dtpDob.Value);
                cmd.Parameters.AddWithValue("@gder", cboGender.Text);
                cmd.Parameters.AddWithValue("@gid", cboGroup2.SelectedValue);
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                cmd.Parameters.AddWithValue("@addr", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                cmd.Parameters.Add(new SqlParameter("@pic", SqlDbType.Image) { Value = (object)contactImage ?? DBNull.Value });
                cmd.Parameters.AddWithValue("@uid", currentUserId);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Đã thêm liên hệ mới vào danh bạ thành công tốt đẹp!", "Thành công");
                    LoadContactList();
                    RefreshContactForm();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi lưu danh bạ: " + ex.Message); }
            finally { db.closeConnection(); }
        }

        private void EditContact()
        {
            if (dgvContacts.CurrentRow == null)
            {
                MessageBox.Show("Ní vui lòng chọn một liên hệ dưới bảng danh bạ để chỉnh sửa nhé!", "Thông báo");
                return;
            }

            if (!ValidateContactInput())
            {
                MessageBox.Show("Không thể cập nhật! Thông tin sửa đổi đang bị sai định dạng.", "Thao tác bị chặn", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            int contactId = Convert.ToInt32(dgvContacts.CurrentRow.Cells["ID"].Value);

            string query = "UPDATE Contact SET Fname=@fn, Lname=@ln, Dob=@dob, Gender=@gder, Group_ID=@gid, Phone=@phone, Address=@addr, Email=@email, Pic=@pic " +
                           "WHERE ID=@id AND UserID=@uid";
            try
            {
                db.openConnection();
                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@id", contactId);
                cmd.Parameters.AddWithValue("@fn", txtFname.Text.Trim());
                cmd.Parameters.AddWithValue("@ln", txtLname.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", dtpDob.Value);
                cmd.Parameters.AddWithValue("@gder", cboGender.Text);
                cmd.Parameters.AddWithValue("@gid", cboGroup2.SelectedValue ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                cmd.Parameters.AddWithValue("@addr", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                cmd.Parameters.Add(new SqlParameter("@pic", SqlDbType.Image) { Value = (object)contactImage ?? DBNull.Value });
                cmd.Parameters.AddWithValue("@uid", currentUserId);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Cập nhật thông tin danh bạ thành công tốt đẹp!", "Thông báo");
                    LoadContactList();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi cập nhật danh bạ: " + ex.Message); }
            finally { db.closeConnection(); }
        }

        private void DeleteContact()
        {
            if (dgvContacts.CurrentRow == null)
            {
                MessageBox.Show("Ní vui lòng chọn số liên lạc trên bảng để xóa nhé!", "Thông báo");
                return;
            }
            int contactId = Convert.ToInt32(dgvContacts.CurrentRow.Cells["ID"].Value);

            DialogResult confirm = MessageBox.Show("Ní có thực sự chắc chắn muốn xóa liên hệ này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            string query = "DELETE FROM Contact WHERE ID = @id AND UserID = @uid";
            try
            {
                db.openConnection();
                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@id", contactId);
                cmd.Parameters.AddWithValue("@uid", currentUserId);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Đã xóa liên hệ ra khỏi danh bạ hệ thống!", "Thông báo");
                    LoadContactList();
                    RefreshContactForm();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi thực thi lệnh xóa: " + ex.Message); }
            finally { db.closeConnection(); }
        }

        private void dgvContacts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvContacts.Rows[e.RowIndex];

            txtFname.Text = row.Cells["Fname"].Value?.ToString() ?? "";
            txtLname.Text = row.Cells["Lname"].Value?.ToString() ?? "";
            txtPhone.Text = row.Cells["Phone"].Value?.ToString() ?? "";
            txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
            txtAddress.Text = row.Cells["Address"].Value?.ToString() ?? "";
            cboGender.Text = row.Cells["Gender"].Value?.ToString().Trim() ?? "";

            if (row.Cells["Dob"].Value != DBNull.Value && row.Cells["Dob"].Value != null)
                dtpDob.Value = Convert.ToDateTime(row.Cells["Dob"].Value);

            if (row.Cells["Group_ID"].Value != DBNull.Value && row.Cells["Group_ID"].Value != null)
                cboGroup2.SelectedValue = Convert.ToInt32(row.Cells["Group_ID"].Value);

            if (row.Cells["Pic"].Value != DBNull.Value && row.Cells["Pic"].Value != null)
            {
                contactImage = (byte[])row.Cells["Pic"].Value;
                using (MemoryStream ms = new MemoryStream(contactImage))
                    picContact.Image = Image.FromStream(ms);
            }
            else
            {
                picContact.Image = null;
                contactImage = null;
            }
        }

        private void RefreshContactForm()
        {
            txtFname.Clear(); txtLname.Clear(); txtPhone.Clear();
            txtEmail.Clear(); txtAddress.Clear();
            cboGender.SelectedIndex = -1; cboGroup2.SelectedIndex = -1;
            dtpDob.Value = DateTime.Now;
            picContact.Image = null;
            contactImage = null;
            lstSuggest.Visible = false;

            erpContact.Clear();
        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog { Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (Image img = Image.FromFile(ofd.FileName))
                {
                    picContact.Image = new Bitmap(img, new Size(150, 150));
                    MemoryStream ms = new MemoryStream();
                    picContact.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    contactImage = ms.ToArray();
                }
            }
        }

        // Vô hiệu hóa tính năng lọc real-time tự động nếu ní muốn chuyển sang gõ Enter và bấm nút chủ động
        private void txtSearchContact_TextChanged(object sender, EventArgs e)
        {
            // Nếu ní muốn vừa gõ vừa tự lọc, hãy giữ code cũ. 
            // Nếu muốn đúng chuẩn bấm nút / ấn Enter mới lọc thì để trống hàm này như hiện tại nhé ní.
            if (txtSearchContact.Text == PLACEHOLDER_TEXT) return;
        }

        private void SetupSuggestList()
        {
            lstSuggest.Visible = false;
            lstSuggest.BringToFront();
        }

        private async void txtAddress_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtAddress.Text.Trim();
            if (keyword.Length < 3) { lstSuggest.Visible = false; return; }

            try
            {
                string url = $"https://nominatim.openstreetmap.org/search?q={Uri.EscapeDataString(keyword)}&format=json&limit=5&countrycodes=vn";
                httpClient.DefaultRequestHeaders.UserAgent.Clear();
                httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("QuanLySinhVien/1.0");
                string json = await httpClient.GetStringAsync(url);
                JArray results = JArray.Parse(json);

                lstSuggest.Items.Clear();
                foreach (var item in results)
                    lstSuggest.Items.Add(item["display_name"].ToString());

                lstSuggest.Visible = lstSuggest.Items.Count > 0;
            }
            catch { lstSuggest.Visible = false; }
        }

        private void lstSuggest_Click(object sender, EventArgs e)
        {
            if (lstSuggest.SelectedItem != null)
            {
                txtAddress.Text = lstSuggest.SelectedItem.ToString();
                lstSuggest.Visible = false;
            }
        }

        private void btnExportCSV_Click_1(object sender, EventArgs e)
        {
            if (contactView == null || contactView.Count == 0)
            {
                MessageBox.Show("Danh bạ trống rỗng, không có dữ liệu để xuất file ní ơi!", "Thông báo");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                FileName = $"DanhBaCaNhan_{DateTime.Now:yyyyMMdd_HHmm}.xlsx"
            };

            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                string[] headers  = { "Mã liên hệ", "Họ", "Tên", "Ngày sinh", "Giới tính", "Phân nhóm", "Số điện thoại", "Email", "Địa chỉ" };
                string[] colNames = { "ID", "Fname", "Lname", "Dob", "Gender", "TenNhom", "Phone", "Email", "Address" };
                int      colCount = headers.Length;

                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                using (ExcelPackage pkg = new ExcelPackage())
                {
                    ExcelWorksheet ws = pkg.Workbook.Worksheets.Add("Danh bạ cá nhân");

                    // ── Tiêu đề trường ──
                    ws.Cells[1, 1].Value = "TRƯỜNG ĐẠI HỌC CÔNG NGHỆ KỸ THUẬT TP.HCM";
                    ws.Cells[1, 1, 1, colCount].Merge = true;
                    ws.Cells[1, 1].Style.Font.Bold = true;
                    ws.Cells[1, 1].Style.Font.Size = 13;
                    ws.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[1, 1].Style.Font.Color.SetColor(SysColor.FromArgb(0, 61, 149));

                    // ── Tiêu đề báo cáo ──
                    ws.Cells[2, 1].Value = "DANH BẠ CÁ NHÂN";
                    ws.Cells[2, 1, 2, colCount].Merge = true;
                    ws.Cells[2, 1].Style.Font.Bold = true;
                    ws.Cells[2, 1].Style.Font.Size = 14;
                    ws.Cells[2, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    // ── Ngày xuất ──
                    ws.Cells[3, 1].Value = $"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm}";
                    ws.Cells[3, 1, 3, colCount].Merge = true;
                    ws.Cells[3, 1].Style.Font.Italic = true;
                    ws.Cells[3, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                    // ── Header row (row 5) ──
                    for (int i = 0; i < colCount; i++)
                    {
                        var cell = ws.Cells[5, i + 1];
                        cell.Value = headers[i];
                        cell.Style.Font.Bold = true;
                        cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        cell.Style.Fill.BackgroundColor.SetColor(SysColor.FromArgb(0, 61, 149));
                        cell.Style.Font.Color.SetColor(SysColor.White);
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    }

                    // ── Data rows ──
                    int rowIdx = 6;
                    foreach (DataRowView row in contactView)
                    {
                        for (int c = 0; c < colCount; c++)
                        {
                            var val = row[colNames[c]];
                            if (colNames[c] == "Dob")
                                ws.Cells[rowIdx, c + 1].Value = (val != DBNull.Value)
                                    ? Convert.ToDateTime(val).ToString("dd/MM/yyyy") : "";
                            else if (colNames[c] == "Phone")
                            {
                                // Lưu số điện thoại dạng text để tránh scientific notation
                                ws.Cells[rowIdx, c + 1].Value = val?.ToString() ?? "";
                                ws.Cells[rowIdx, c + 1].Style.Numberformat.Format = "@";
                            }
                            else
                                ws.Cells[rowIdx, c + 1].Value = val?.ToString() ?? "";
                        }
                        if (rowIdx % 2 == 0)
                        {
                            ws.Cells[rowIdx, 1, rowIdx, colCount].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            ws.Cells[rowIdx, 1, rowIdx, colCount].Style.Fill.BackgroundColor.SetColor(SysColor.FromArgb(240, 244, 255));
                        }
                        rowIdx++;
                    }

                    // ── Footer ──
                    ws.Cells[rowIdx + 1, 1].Value = $"Tổng số bản ghi: {contactView.Count}   |   Xuất bởi: {Globals.GlobalUserName}   |   Hệ thống QuanLySinhVien";
                    ws.Cells[rowIdx + 1, 1, rowIdx + 1, colCount].Merge = true;
                    ws.Cells[rowIdx + 1, 1].Style.Font.Italic = true;
                    ws.Cells[rowIdx + 1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                    ws.Cells.AutoFitColumns();
                    pkg.SaveAs(new FileInfo(sfd.FileName));
                }

                DialogResult dr = MessageBox.Show("Xuất Excel thành công!\nBạn có muốn mở file vừa xuất không?",
                    "Thành công", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                    System.Diagnostics.Process.Start(sfd.FileName);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi xuất CSV: " + ex.Message); }
        }

        private void btnRefreshContact_Click(object sender, EventArgs e)
        {
            RefreshContactForm();
        }

        private void btnFixContact_Click(object sender, EventArgs e)
        {
            EditContact();
        }

        // ── Import CSV / vCard ────────────────────────────────────────────
        private async Task btnImportCSV_ClickAsync()
        {
            using (var ofd = new OpenFileDialog
            {
                Title = "Chọn file danh bạ",
                Filter = "CSV / vCard|*.csv;*.vcf|CSV|*.csv|vCard|*.vcf"
            })
            {
                if (ofd.ShowDialog() != DialogResult.OK) return;

                string path = ofd.FileName;
                bool isVcf = path.EndsWith(".vcf", StringComparison.OrdinalIgnoreCase);

                int imported = 0, skipped = 0, duplicates = 0;
                List<string> errors = new List<string>();

                // Xóa trùng lặp đang có trước khi nhập mới
                int cleaned = CleanDuplicateContacts();

                try
                {
                    db.openConnection();
                    var groupMap = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
                    using (var cmd = new SqlCommand("SELECT ID, Name FROM Groups WHERE UserID=@uid", db.conn))
                    {
                        cmd.Parameters.AddWithValue("@uid", currentUserId);
                        using (var reader = cmd.ExecuteReader())
                            while (reader.Read())
                                groupMap[reader.GetString(1)] = reader.GetInt32(0);
                    }

                    if (isVcf)
                        ImportVCard(path, groupMap, ref imported, ref skipped, ref duplicates, errors);
                    else
                        ImportCsv(path, groupMap, ref imported, ref skipped, ref duplicates, errors);

                    LoadContactList();
                    string msg = $"Nhập thành công {imported} liên hệ mới.";
                    if (duplicates > 0) msg += $"\nBỏ qua {duplicates} liên hệ trùng lặp.";
                    if (cleaned > 0)    msg += $"\nĐã xóa {cleaned} bản ghi trùng lặp cũ.";
                    if (skipped > 0)    msg += $"\nBỏ qua {skipped} dòng lỗi định dạng.";
                    if (errors.Count > 0) msg += "\n" + string.Join("\n", errors.Take(3));
                    MessageBox.Show(msg, "Kết quả nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi nhập file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally { db.closeConnection(); }
            }
            await Task.CompletedTask;
        }

        private void ImportCsv(string path, Dictionary<string, int> groupMap,
            ref int imported, ref int skipped, ref int duplicates, List<string> errors)
        {
            var lines = File.ReadAllLines(path, Encoding.UTF8);
            // Detect separator: first line may use ; or ,
            char sep = lines.Length > 0 && lines[0].Contains(';') ? ';' : ',';

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i].Trim();
                if (string.IsNullOrEmpty(line)) continue;
                // Simple CSV split (no quoted-field multiline, but handle quoted fields on same line)
                var cols = SplitCsvLine(line, sep);
                if (cols.Length < 3) { skipped++; continue; }

                try
                {
                    string fname   = GetCol(cols, 0);
                    string lname   = GetCol(cols, 1);
                    string dobStr  = GetCol(cols, 2);
                    string gender  = GetCol(cols, 3, "Nam");
                    string phone   = GetCol(cols, 4);
                    string email   = GetCol(cols, 5);
                    string address = GetCol(cols, 6);
                    string groupName = GetCol(cols, 7);

                    if (string.IsNullOrWhiteSpace(fname) && string.IsNullOrWhiteSpace(lname))
                    { skipped++; continue; }

                    DateTime dob = DateTime.TryParse(dobStr, out var d) ? d : new DateTime(2000, 1, 1);
                    int groupId = ResolveOrCreateGroup(groupName, groupMap);

                    if (InsertContact(fname, lname, dob, gender, groupId, phone, address, email))
                        imported++;
                    else
                        duplicates++;
                }
                catch (Exception ex) { skipped++; errors.Add($"Dòng {i + 1}: {ex.Message}"); }
            }
        }

        private void ImportVCard(string path, Dictionary<string, int> groupMap,
            ref int imported, ref int skipped, ref int duplicates, List<string> errors)
        {
            var lines = File.ReadAllLines(path, Encoding.UTF8);
            string fname = "", lname = "", phone = "", email = "", address = "", dobStr = "", gender = "Nam";
            bool inCard = false;

            foreach (string raw in lines)
            {
                string line = raw.Trim();
                if (line.Equals("BEGIN:VCARD", StringComparison.OrdinalIgnoreCase))
                {
                    fname = lname = phone = email = address = dobStr = "";
                    gender = "Nam"; inCard = true; continue;
                }
                if (line.Equals("END:VCARD", StringComparison.OrdinalIgnoreCase))
                {
                    if (inCard && (!string.IsNullOrEmpty(fname) || !string.IsNullOrEmpty(lname)))
                    {
                        try
                        {
                            DateTime dob = DateTime.TryParse(dobStr, out var d) ? d : new DateTime(2000, 1, 1);
                            int gid = ResolveOrCreateGroup("", groupMap);
                            if (InsertContact(fname, lname, dob, gender, gid, phone, address, email))
                                imported++;
                            else
                                duplicates++;
                        }
                        catch (Exception ex) { skipped++; errors.Add(ex.Message); }
                    }
                    inCard = false; continue;
                }
                if (!inCard) continue;

                if (line.StartsWith("N:", StringComparison.OrdinalIgnoreCase))
                {
                    // N:Last;First;...
                    var parts = line.Substring(2).Split(';');
                    lname = parts.Length > 0 ? parts[0] : "";
                    fname = parts.Length > 1 ? parts[1] : "";
                }
                else if (line.StartsWith("FN:", StringComparison.OrdinalIgnoreCase) && string.IsNullOrEmpty(fname))
                {
                    var full = line.Substring(3).Trim().Split(' ');
                    fname = full.Length > 0 ? full[0] : "";
                    lname = full.Length > 1 ? string.Join(" ", full, 1, full.Length - 1) : "";
                }
                else if (line.StartsWith("TEL", StringComparison.OrdinalIgnoreCase))
                    phone = line.Substring(line.IndexOf(':') + 1).Trim();
                else if (line.StartsWith("EMAIL", StringComparison.OrdinalIgnoreCase))
                    email = line.Substring(line.IndexOf(':') + 1).Trim();
                else if (line.StartsWith("ADR", StringComparison.OrdinalIgnoreCase))
                    address = line.Substring(line.IndexOf(':') + 1).Replace(";", ", ").Trim().TrimStart(',').Trim();
                else if (line.StartsWith("BDAY:", StringComparison.OrdinalIgnoreCase))
                    dobStr = line.Substring(5).Trim();
            }
        }

        private int ResolveOrCreateGroup(string groupName, Dictionary<string, int> groupMap)
        {
            if (!string.IsNullOrWhiteSpace(groupName) && groupMap.TryGetValue(groupName, out int existing))
                return existing;
            // Default group: pick first available or create "Đã nhập"
            if (groupMap.Count > 0)
                return groupMap.Values.First();
            using (var cmd = new SqlCommand(
                "INSERT INTO dbo.Groups (Name, UserID) VALUES (@n, @uid); SELECT CAST(SCOPE_IDENTITY() AS INT)", db.conn))
            {
                cmd.Parameters.AddWithValue("@n", string.IsNullOrWhiteSpace(groupName) ? "Đã nhập" : groupName);
                cmd.Parameters.AddWithValue("@uid", currentUserId);
                int newId = Convert.ToInt32(cmd.ExecuteScalar());
                groupMap[groupName ?? "Đã nhập"] = newId;
                return newId;
            }
        }

        private static string[] SplitCsvLine(string line, char sep)
        {
            var result = new List<string>();
            bool inQuotes = false;
            var sb = new StringBuilder();
            foreach (char c in line)
            {
                if (c == '"') { inQuotes = !inQuotes; continue; }
                if (c == sep && !inQuotes) { result.Add(sb.ToString()); sb.Clear(); continue; }
                sb.Append(c);
            }
            result.Add(sb.ToString());
            return result.ToArray();
        }

        private static string GetCol(string[] cols, int idx, string defaultVal = "")
            => idx < cols.Length ? cols[idx].Trim() : defaultVal;

        // ── AI gợi ý nhóm ─────────────────────────────────────────────────
        private async Task btnAISuggestGroup_ClickAsync()
        {
            if (dgvContacts.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một liên hệ trong danh sách để AI gợi ý nhóm.", "Chưa chọn liên hệ");
                return;
            }

            var row = dgvContacts.CurrentRow;
            string fname  = row.Cells["Fname"]?.Value?.ToString()   ?? "";
            string lname  = row.Cells["Lname"]?.Value?.ToString()   ?? "";
            string email  = row.Cells["Email"]?.Value?.ToString()   ?? "";
            string phone  = row.Cells["Phone"]?.Value?.ToString()   ?? "";
            string gender = row.Cells["Gender"]?.Value?.ToString()  ?? "";

            btnAISuggestGroup.Enabled = false;
            btnAISuggestGroup.Text = "⏳ Đang hỏi AI...";
            try
            {
                string groups = string.Join(", ", GetUserGroups());
                string prompt =
                    $"Bạn là trợ lý phân loại danh bạ. Dựa vào thông tin: " +
                    $"Tên: {fname} {lname}, Email: {email}, SĐT: {phone}, Giới tính: {gender}. " +
                    $"Các nhóm hiện có: {groups}. " +
                    $"Hãy gợi ý nhóm phù hợp nhất và giải thích ngắn gọn lý do (1-2 câu). " +
                    $"Trả lời bằng tiếng Việt.";

                string reply = await CallGeminiAsync(prompt);
                MessageBox.Show(reply, $"AI gợi ý nhóm cho {fname} {lname}",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối AI: " + ex.Message, "Lỗi AI");
            }
            finally
            {
                btnAISuggestGroup.Enabled = true;
                btnAISuggestGroup.Text = "🤖 AI gợi ý nhóm";
            }
        }

        private List<string> GetUserGroups()
        {
            var list = new List<string>();
            try
            {
                db.openConnection();
                using (var cmd = new SqlCommand("SELECT Name FROM Groups WHERE UserID=@uid", db.conn))
                {
                    cmd.Parameters.AddWithValue("@uid", currentUserId);
                    using (var r = cmd.ExecuteReader())
                        while (r.Read()) list.Add(r.GetString(0));
                }
            }
            catch { }
            finally { db.closeConnection(); }
            return list.Count > 0 ? list : new List<string> { "Gia đình", "Bạn cùng lớp", "Giảng viên", "Đối tác học tập" };
        }

        private async Task<string> CallGeminiAsync(string prompt)
        {
            string url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent?key={GEMINI_KEY_CONTACT}";
            var body = new JObject(
                new JProperty("contents", new JArray(
                    new JObject(new JProperty("parts", new JArray(
                        new JObject(new JProperty("text", prompt))))))));

            var content = new StringContent(body.ToString(), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, content);
            string json = await response.Content.ReadAsStringAsync();
            var obj = JObject.Parse(json);
            return obj["candidates"]?[0]?["content"]?["parts"]?[0]?["text"]?.ToString()
                   ?? "AI không trả lời được.";
        }

        private void cboGroup_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Kiểm tra an toàn xem ComboBox đã nạp dữ liệu xong chưa
            if (cboGroup.SelectedValue == null || contactView == null) return;

            try
            {
                // 1. Trích xuất mã ID nhóm từ SelectedValue của ComboBox
                string selectedGroupId = cboGroup.SelectedValue.ToString();

                // 2. Thực thi chuỗi truy vấn có điều kiện lọc theo phân quyền tài khoản cá nhân
                // (Mã nguồn SQL này chính là nội dung cốt lõi ní cần bôi đen để chụp hình 15)
                

                // 3. Sử dụng kịch bản lọc an toàn DataView RowFilter để tránh nghẽn mạch kết nối Database
                if (selectedGroupId == "0" || string.IsNullOrEmpty(selectedGroupId))
                {
                    contactView.RowFilter = ""; // Nếu chọn tất cả thì hiện full lưới danh bạ
                }
                else
                {
                    contactView.RowFilter = $"Group_ID = {selectedGroupId}"; // Lọc chính xác danh bạ thuộc nhóm
                }

                UpdateTotalCount(); // Cập nhật lại số lượng liên lạc hiển thị dưới nhãn bộ đếm
            }
            catch (Exception ex)
            {
                // Khối bảo vệ ngăn chặn ứng dụng bị đứng hình hoặc văng lỗi ra ngoài khi mất kết nối đột ngột
                MessageBox.Show("Hệ thống nghẽn mạch lọc danh mục: " + ex.Message, "Lỗi phân hệ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bntSearchContact_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnImportCSV_Click(object sender, EventArgs e)
        {
            _ = btnImportCSV_ClickAsync();
        }

        private void btnAISuggestGroup_Click(object sender, EventArgs e)
        {
            _ = btnAISuggestGroup_ClickAsync();
        }

    }
}
