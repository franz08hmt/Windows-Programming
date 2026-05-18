using System;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new f_Login());
        }
    }
}