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
    public partial class frmOvertimes : Form
    {
        public frmOvertimes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
}
