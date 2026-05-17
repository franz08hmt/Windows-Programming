// Login_Form.cs  —  Account Login Form
// Subject: Windows Programming  |  Topic: WinForms + ADO.NET + SQL Parameters
// Student: Huynh Minh Tai  |  MSSV: 22110068

using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentMIS
{
    public partial class Login_Form : Form
    {
        private MY_DB db = new MY_DB();

        public Login_Form()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter your username.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter your password.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            try
            {
                db.openConnection();

                string query = "SELECT COUNT(*) FROM log_in " +
                               "WHERE username = @User AND password = @Pass";

                SqlCommand cmd = new SqlCommand(query, db.getConnection);
                cmd.Parameters.Add("@User", SqlDbType.VarChar).Value = username;
                cmd.Parameters.Add("@Pass", SqlDbType.VarChar).Value = password;

                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Ok, next time will be go to Main Menu of App",
                        "Login Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Invalid Username Or Password",
                        "Login Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtUsername.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.closeConnection();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {

        }
    }
}