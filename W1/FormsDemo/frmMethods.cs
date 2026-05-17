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
    public partial class frmMethods : Form
    {
        public frmMethods()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            Form frm = new frmActivate();
            frm.ShowDialog();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            Form frm = new frmActivate();
            frm.Show();
            MessageBox.Show("Show() does NOT block — this message appears immediately.", "Show vs ShowDialog");
        }

        private void btnShowDialog_Click(object sender, EventArgs e)
        {
            Form frm = new frmActivate();
            frm.ShowDialog();
            MessageBox.Show("ShowDialog() BLOCKED — this message appears after child closes.", "Show vs ShowDialog");
        }
    }
}
