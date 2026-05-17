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
    public partial class frmLoad : Form
    {
        public frmLoad()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frmLoad_Load(object sender, EventArgs e)
        {
            txtComputerName.Text = SystemInformation.ComputerName;
            txtUserName.Text = SystemInformation.UserName;
            txtDomainName.Text = SystemInformation.UserDomainName;
        }
    }
}
