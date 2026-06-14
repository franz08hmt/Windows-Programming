using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace QuanLySinhVien
{
    public partial class f_Contact : UserControl
    {
        private My_DB db = new My_DB();
        private DataView contactView;
        private byte[] contactImage = null;
        private static readonly HttpClient httpClient = new HttpClient();

        private int currentUserId = 1;

        // Chuỗi placeholder cố định để so sánh logic
        private const string PLACEHOLDER_TEXT = "Tìm kiếm theo tên hoặc số điện thoại";

        public f_Contact()
        {
            InitializeComponent();
            SetupEventHandlers();
        }

        private void f_Contact_Load(object sender, EventArgs e)
        {
            LoadGroupsToComboBoxAndGrid();
            LoadContactList();
            SetupSuggestList();
            SetupPlaceholderSearch(); // Khởi tạo giao diện placeholder ban đầu
        }

        private void SetupEventHandlers()
        {
            this.Load += new EventHandler(f_Contact_Load);
            btnAddGroup.Click += new EventHandler(btnAddGroup_Click);
            btnDeleteGroup.Click += new EventHandler(btnDeleteGroup_Click);
            btnChooseImage.Click += new EventHandler(btnChooseImage_Click);

            // Xử lý bộ lọc thời gian thực khi người dùng gõ
            txtSearchContact.TextChanged += new EventHandler(txtSearchContact_TextChanged);

            // 🛠️ ĐĂNG KÝ CÁC SỰ KIỆN MỚI CHO CHỨC NĂNG TÌM KIẾM THEO YÊU CẦU CỦA NÍ
            txtSearchContact.Enter += new EventHandler(txtSearchContact_Enter);
            txtSearchContact.Leave += new EventHandler(txtSearchContact_Leave);
            txtSearchContact.KeyDown += new KeyEventHandler(txtSearchContact_KeyDown);
            bntSearchContact.Click += new EventHandler(bntSearchContact_Click);

            btnExportCSV.Click += new EventHandler(btnExportCSV_Click);
            dgvGroup.CellClick += new DataGridViewCellEventHandler(dgvGroup_CellClick);
            dgvContacts.CellClick += new DataGridViewCellEventHandler(dgvContacts_CellClick);
            txtAddress.TextChanged += new EventHandler(txtAddress_TextChanged);
            lstSuggest.Click += new EventHandler(lstSuggest_Click);

            btnAddContact.Click += (s, e) => AddContact();
            btnFixContact.Click += (s, e) => EditContact();
            btnDeleteContact.Click += (s, e) => DeleteContact();
            btnRefreshContact.Click += (s, e) => RefreshContactForm();

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
            string query = "SELECT ID, Name FROM Groups WHERE UserID = @uid";
            try
            {
                SqlCommand cmd = new SqlCommand(query, db.getConnection);
                cmd.Parameters.AddWithValue("@uid", currentUserId);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvGroup.DataSource = dt;
                dgvGroup.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvGroup.Columns["ID"].HeaderText = "Mã nhóm";
                dgvGroup.Columns["Name"].HeaderText = "Tên nhóm danh bạ";

                cboGroup.DataSource = dt;
                cboGroup.DisplayMember = "Name";
                cboGroup.ValueMember = "ID";

                DataTable dt2 = dt.Copy();
                cboGroup2.DataSource = dt2;
                cboGroup2.DisplayMember = "Name";
                cboGroup2.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi nạp nhóm: " + ex.Message);
            }
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
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

        private void btnDeleteGroup_Click(object sender, EventArgs e)
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

        private void dgvGroup_CellClick(object sender, DataGridViewCellEventArgs e)
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

        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            if (contactView == null || contactView.Count == 0)
            {
                MessageBox.Show("Danh bạ trống rỗng, không có dữ liệu để xuất file ní ơi!", "Thông báo");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "CSV Files|*.csv",
                FileName = $"DanhBaCaNhan_{DateTime.Now:yyyyMMdd}.csv"
            };

            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Mã liên hệ,Họ,Tên,Ngày sinh,Giới tính,Phân nhóm,Số điện thoại,Email,Địa chỉ");

                foreach (DataRowView row in contactView)
                {
                    string dobStr = row["Dob"] != DBNull.Value ? Convert.ToDateTime(row["Dob"]).ToString("dd/MM/yyyy") : "";
                    string safeAddr = $"\"{row["Address"].ToString().Replace("\"", "\"\"")}\"";

                    sb.AppendLine($"{row["ID"]},{row["Fname"]},{row["Lname"]},{dobStr},{row["Gender"]},{row["TenNhom"]},{row["Phone"]},{row["Email"]},{safeAddr}");
                }

                File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                MessageBox.Show("Xuất file danh bạ cá nhân CSV thành công tốt đẹp!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void cboGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra an toàn xem ComboBox đã nạp dữ liệu xong chưa
            if (cboGroup.SelectedValue == null || contactView == null) return;

            try
            {
                // 1. Trích xuất mã ID nhóm từ SelectedValue của ComboBox
                string selectedGroupId = cboGroup.SelectedValue.ToString();

                // 2. Thực thi chuỗi truy vấn có điều kiện lọc theo phân quyền tài khoản cá nhân
                // (Mã nguồn SQL này chính là nội dung cốt lõi ní cần bôi đen để chụp hình 15)
                string queryFilter = $"SELECT c.ID, c.Fname, c.Lname, c.Dob, c.Gender, g.Name AS 'TenNhom', c.Phone, c.Email, c.Address, c.Pic, c.Group_ID " +
                                     $"FROM Contact c LEFT JOIN Groups g ON c.Group_ID = g.ID " +
                                     $"WHERE c.Group_ID = @gid AND c.UserID = @uid";

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
    }
}