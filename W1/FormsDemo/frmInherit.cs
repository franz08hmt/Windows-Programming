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
    public partial class frmInherit : Form
    {
        public frmInherit()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                var dir = new System.IO.DirectoryInfo(txtPath.Text);

                lvData.Columns.Clear();
                lvData.Items.Clear();
                lvData.Columns.Add("Name", 100, 0);
                lvData.Columns.Add("Size", 50, 0);
                lvData.Columns.Add("Date", 70, 0);
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
}
