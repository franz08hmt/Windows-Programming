using System.Windows.Forms;

namespace QuanLySinhVien
{
    public class BaseForm : Form
    {
        public BaseForm()
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
        }
    }
}