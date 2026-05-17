// FormsDemo.cs  —  MDI & Form Properties/Methods/Events Demo
// Subject: Windows Programming  |  Topic: Windows Forms – MDI, Shapes, Events
// Student: Huynh Minh Tai  |  MSSV: 22110068

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FormsDemo
{
    // ============================================================
    // SECTION 1 — MDI Parent Form (Form1)
    // IsMdiContainer = true in Designer
    // Buttons: Form2, Form3, Form4, Form5, New Form,
    //          Inherit Form, Use Inherit Form, Other MDI
    // ============================================================
    public partial class Form1 : Form
    {
        public Form1() { InitializeComponent(); }

        // Open Form2 as a new MDI container
        private void btnForm2_Click(object sender, EventArgs e)
        {
            Form frm = new Form2();
            frm.IsMdiContainer = true;
            frm.Show();
        }

        // Open Form3 as MDI child of this form
        private void btnForm3_Click(object sender, EventArgs e)
        {
            Form frm = new Form3();
            frm.MdiParent = this;           // set this form as MDI parent
            frm.Show();
        }

        // Open Form5 as modal dialog
        private void btnForm5_Click(object sender, EventArgs e)
        {
            Form frm = new Form5();
            frm.ShowDialog();
        }

        // Create a brand-new Form at runtime using delegate for Click event
        private void btnNewForm_Click(object sender, EventArgs e)
        {
            Form frm = new Form();
            frm.Text = "New Form";
            frm.Name = "frmNewForm";
            // Attach Click event via anonymous delegate
            frm.Click += delegate (object sender1, EventArgs e1)
            {
                MessageBox.Show("Click on the new Form!", "Vi du Form");
            };
            frm.Show();
        }

        // Open Inherit Form (frmInherit) as modal dialog
        private void btnInheritForm_Click(object sender, EventArgs e)
        {
            Form frm = new frmInherit();
            frm.ShowDialog();
        }

        // Open Form6 (Use Inherit Form — inherits frmInherit) as modal dialog
        private void btnUseInherit_Click(object sender, EventArgs e)
        {
            Form frm = new Form6();
            frm.ShowDialog();
        }

        // Open Other MDI demo
        private void btnOtherMDI_Click(object sender, EventArgs e)
        {
            Form frm = new Form5();
            frm.MdiParent = Form2.ActiveForm;
            frm.Show();
        }
    }

    // ============================================================
    // SECTION 2 — frmInherit : ListView showing directory files
    // Controls: txtPath (TextBox), btnShow (Button), lvData (ListView)
    // ============================================================
    public partial class frmInherit : Form
    {
        public frmInherit() { InitializeComponent(); }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                var dir = new System.IO.DirectoryInfo(txtPath.Text);

                lvData.Columns.Clear();
                lvData.Items.Clear();
                lvData.Columns.Add("Name", 100, 0);
                lvData.Columns.Add("Size",  50, 0);
                lvData.Columns.Add("Date",  70, 0);
                lvData.View = View.Details;

                foreach (System.IO.FileInfo f in dir.GetFiles("*.*"))
                {
                    var item = new ListViewItem(f.Name);
                    item.SubItems.Add(f.Length.ToString());
                    item.SubItems.Add(f.CreationTime.ToLongDateString());
                    lvData.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    // Form6 inherits frmInherit — demonstrates Form Inheritance
    public partial class Form6 : frmInherit
    {
        public Form6() { InitializeComponent(); }
    }

    // ============================================================
    // SECTION 3 — Form Shapes (GraphicsPath)
    // ============================================================

    // frmCircle: ellipse-shaped form
    public partial class frmCircle : Form
    {
        public frmCircle()
        {
            InitializeComponent();
            this.Text = "Circle Form";
        }
        private void btnClose_Click(object sender, EventArgs e) { this.Close(); }
    }

    // frmOthers: custom curved shape form
    public partial class frmOthers : Form
    {
        public frmOthers()
        {
            InitializeComponent();
            this.Text = "Form Tuy Chinh";
        }
    }

    // Form1 button handlers for shape forms
    public partial class Form1
    {
        private void btnTron_Click(object sender, EventArgs e)
        {
            Form frm = new frmCircle();
            GraphicsPath shape = new GraphicsPath();
            shape.AddEllipse(15, 25, this.Width, this.Height);
            frm.Region = new Region(shape);
            frm.Show();
        }

        private void btnKhac_Click(object sender, EventArgs e)
        {
            Form frm = new frmOthers();
            GraphicsPath shape = new GraphicsPath();
            Point[] points = {
                new Point(100,  50), new Point(250, 100),
                new Point(300, 200), new Point(180, 300),
                new Point( 80, 200), new Point( 30, 150)
            };
            shape.AddCurve(points);
            frm.Region = new Region(shape);
            frm.Show();
        }
    }

    // ============================================================
    // SECTION 4 — Form Properties Demo
    // Buttons: New Form, Opacity, Icon, BackColor, ForeColor,
    //          Menu, AcceptButton, Child Form
    // ============================================================
    public partial class frmProperties : Form
    {
        public frmProperties() { InitializeComponent(); }

        // Opacity form (semi-transparent)
        private void btnOpacity_Click(object sender, EventArgs e)
        {
            Form frm = new frmOpacity();
            frm.Show();
        }

        // BackColor form
        private void btnBackColor_Click(object sender, EventArgs e)
        {
            Form frm = new Form();
            frm.Text = "BackColor Demo";
            frm.Load += (s, ev) => ((Form)s).BackColor = Color.Azure;
            frm.Show();
        }

        // ForeColor form
        private void btnForeColor_Click(object sender, EventArgs e)
        {
            Form frm = new Form();
            frm.Text = "ForeColor Demo";
            Label lbl = new Label { Text = "ForeColor = Brown", AutoSize = true, Location = new Point(30, 30) };
            frm.Load += (s, ev) => {
                ((Form)s).ForeColor = Color.Brown;
                ((Form)s).Controls.Add(lbl);
            };
            frm.Show();
        }

        // Child Form inside MDI parent
        private void btnChildForm_Click(object sender, EventArgs e)
        {
            Form mdiParent = new Form();
            mdiParent.Text            = "MDI Form";
            mdiParent.IsMdiContainer  = true;
            mdiParent.Load += (s, ev) =>
            {
                Form child = new Form();
                child.Text            = "Child Form";
                child.MdiParent       = mdiParent;
                child.WindowState     = FormWindowState.Maximized;
                child.Show();
            };
            mdiParent.ShowDialog();
        }
    }

    // frmOpacity — demonstrates Opacity property
    public partial class frmOpacity : Form
    {
        public frmOpacity() { InitializeComponent(); }

        private void frmOpacity_Load(object sender, EventArgs e)
        {
            this.Opacity = 0.5;   // 50% transparent
        }
    }

    // ============================================================
    // SECTION 5 — Form Methods: Close, Hide, Show, ShowDialog, Activate
    // ============================================================
    public partial class frmMethods : Form
    {
        public frmMethods() { InitializeComponent(); }

        private void btnClose_Click(object sender, EventArgs e)   { this.Close(); }
        private void btnHide_Click(object sender, EventArgs e)    { this.Hide(); }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            Form frm = new frmActivate();
            frm.ShowDialog();
        }

        // Show vs ShowDialog demonstration
        private void btnShow_Click(object sender, EventArgs e)
        {
            // Show() is non-blocking — caller continues running
            Form frm = new frmActivate();
            frm.Show();
            MessageBox.Show("Show() does NOT block — this message appears immediately.",
                            "Show vs ShowDialog");
        }

        private void btnShowDialog_Click(object sender, EventArgs e)
        {
            // ShowDialog() is blocking — caller waits until child closes
            Form frm = new frmActivate();
            frm.ShowDialog();
            MessageBox.Show("ShowDialog() BLOCKED — this message appears after child closes.",
                            "Show vs ShowDialog");
        }
    }

    // ============================================================
    // SECTION 6 — Form Events: Closed, Closing, Load, KeyPress, Resize
    // ============================================================

    // FormClosed event demo
    public partial class frmClosed : Form
    {
        public frmClosed() { InitializeComponent(); }

        private void frmClosed_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("FormClosed reason: " + e.CloseReason.ToString(),
                            "Closed Event");
        }
    }

    // FormClosing event demo — can cancel close
    public partial class frmClosing : Form
    {
        public frmClosing() { InitializeComponent(); }

        private void frmClosing_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to close?", "Closing Event",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                e.Cancel = true;    // prevent close
        }
    }

    // Load event demo — reads system info
    public partial class frmLoad : Form
    {
        public frmLoad() { InitializeComponent(); }

        // Controls: txtComputerName, txtUserName, txtDomainName (TextBox)
        private void frmLoad_Load(object sender, EventArgs e)
        {
            txtComputerName.Text = SystemInformation.ComputerName;
            txtUserName.Text     = SystemInformation.UserName;
            txtDomainName.Text   = SystemInformation.UserDomainName;
        }
    }

    // KeyPress event demo
    public partial class frmKeyPress : Form
    {
        public frmKeyPress() { InitializeComponent(); }
        // label1 shows "Ready..." initially

        private void frmKeyPress_KeyPress(object sender, KeyPressEventArgs e)
        {
            label1.Text = "Pressed key: " + e.KeyChar.ToString();
        }
    }

    // Resize event demo — RichTextBox auto-resizes with form
    public partial class frmResize : Form
    {
        public frmResize() { InitializeComponent(); }

        private void frmResize_Resize(object sender, EventArgs e)
        {
            richTextBox1.Width  = this.Width  - 30;
            richTextBox1.Height = this.Height - 50;
        }
    }

    // ============================================================
    // SECTION 7 — Form Lifecycle: MdiChildActivate
    // frmMain → MDI parent with Employees + Overtime child forms
    // ============================================================
    public partial class frmMain : Form
    {
        public frmMain() { InitializeComponent(); }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmEmployees();
            frm.MdiParent = this;
            frm.Show();
        }

        private void overtimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmOvertimes();
            frm.MdiParent = this;
            frm.Show();
        }
    }

    // frmEmployees — tracks how many times it is activated
    public partial class frmEmployees : Form
    {
        int activateCount = 0;
        public frmEmployees() { InitializeComponent(); }

        private void frmEmployees_Activated(object sender, EventArgs e)
        {
            activateCount++;
            label2.Text = "Activated " + activateCount.ToString();
        }
    }

    // frmOvertimes — button activates frmEmployees from sibling child
    public partial class frmOvertimes : Form
    {
        public frmOvertimes() { InitializeComponent(); }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            Form mdi = frmMain.ActiveForm;
            foreach (Form f in mdi.MdiChildren)
            {
                if (f.Name == "frmEmployees")
                {
                    f.Activate();
                    break;
                }
            }
        }
    }

    // frmActivate — used in Activate / MDI child demo
    public partial class frmActivate : Form
    {
        public frmActivate() { InitializeComponent(); }
    }
}
