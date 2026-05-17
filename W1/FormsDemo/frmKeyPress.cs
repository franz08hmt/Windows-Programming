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
    public partial class frmKeyPress : Form
    {
        public frmKeyPress()
        {
            InitializeComponent();
        }

        private void frmKeyPress_KeyPress(object sender, KeyPressEventArgs e)
        {
            label1.Text = "Pressed key: " + e.KeyChar.ToString();
        }
    }
}
