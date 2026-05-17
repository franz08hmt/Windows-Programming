using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsDemo
{
    public partial class frmProperties : Form
    {
        public frmProperties()
        {
            InitializeComponent();
        }

        private void btnNewForm_Click(object sender, EventArgs e)
        {
            Form frm = new Form();
            frm.Text = "New Form";
            frm.Name = "frmNewForm";
            frm.Show();
        }

        private void btnOpacity_Click(object sender, EventArgs e)
        {
            Form frm = new frmOpacity();
            frm.Show();
        }

        private void btnIcon_Click(object sender, EventArgs e)
        {

        }

        private void btnBackColor_Click(object sender, EventArgs e)
        {
            Form frm = new Form();
            frm.Text = "BackColor Demo";
            frm.Load += (s, ev) => ((Form)s).BackColor = System.Drawing.Color.Azure;
            frm.Show();
        }

        private void btnForeColor_Click(object sender, EventArgs e)
        {
            Form frm = new Form();
            frm.Text = "ForeColor Demo";
            frm.Load += (s, ev) => ((Form)s).ForeColor = System.Drawing.Color.Brown;
            frm.Show();
        }

        private void btnChildForm_Click(object sender, EventArgs e)
        {
            Form mdiParent = new Form();
            mdiParent.Text = "MDI Form";
            mdiParent.IsMdiContainer = true;
            mdiParent.Load += (s, ev) =>
            {
                Form child = new Form();
                child.Text = "Child Form";
                child.MdiParent = mdiParent;
                child.WindowState = FormWindowState.Maximized;
                child.Show();
            };
            mdiParent.ShowDialog();
        }
    }
}
