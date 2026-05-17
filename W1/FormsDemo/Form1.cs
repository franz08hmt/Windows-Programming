using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnForm2_Click(object sender, EventArgs e)
        {
            Form frm = new Form2();
            frm.IsMdiContainer = true;
            frm.Show();
        }

        private void btnForm3_Click(object sender, EventArgs e)
        {
            Form frm = new Form3();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnForm4_Click(object sender, EventArgs e)
        {
            Form frm = new Form4();
            frm.Show();
        }

        private void btnForm5_Click(object sender, EventArgs e)
        {
            Form frm = new Form5();
            frm.ShowDialog();
        }

        private void btnNewForm_Click(object sender, EventArgs e)
        {
            Form frm = new Form();
            frm.Text = "New Form";
            frm.Name = "frmNewForm";
            frm.Click += delegate (object sender1, EventArgs e1)
            {
                MessageBox.Show("Click on the new Form!", "Vi du Form");
            };
            frm.Show();
        }

        private void btnInheritForm_Click(object sender, EventArgs e)
        {
            Form frm = new frmInherit();
            frm.ShowDialog();
        }

        private void btnUseInherit_Click(object sender, EventArgs e)
        {
            Form frm = new Form6();
            frm.ShowDialog();
        }

        private void btnOtherMDI_Click(object sender, EventArgs e)
        {
            Form frm = new Form5();
            frm.MdiParent = Form2.ActiveForm;
            frm.Show();
        }

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
}
