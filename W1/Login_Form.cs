// Login_Form.cs  —  Account Login Form
// Subject: Windows Programming  |  Topic: WinForms + ADO.NET + SQL Parameters
// Student: Huynh Minh Tai  |  MSSV: 22110068

using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentMIS
{
    /// <summary>
    /// Login form that authenticates against the log_in table in viduDB.
    /// Uses SqlParameter to prevent SQL Injection (see SQLPara_huongdan).
    ///
    /// Controls needed:
    ///   - pictureBox1       : displays user avatar (images/user.png)
    ///   - lblTitle          : Label "Account Login"
    ///   - txtUsername       : TextBox for username
    ///   - txtPassword       : TextBox for password (PasswordChar = '*')
    ///   - btnLogin          : Button "Login"
    ///   - btnCancel         : Button "Cancel"
    ///
    /// Design properties (set in Designer):
    ///   - Form BackColor    : #1E2A38 (dark navy)
    ///   - Button Login      : BackColor = #28A745 (green)
    ///   - Button Cancel     : BackColor = #DC3545 (red)
    /// </summary>
    public partial class Login_Form : Form
    {
        // Database manager instance
        private MY_DB db = new MY_DB();

        public Login_Form()
        {
            InitializeComponent();
        }

        // Load: set avatar image from local images folder
        private void Login_Form_Load(object sender, EventArgs e)
        {
            try
            {
                // Path relative to executable: ../../images/user.png
                pictureBox1.Image = System.Drawing.Image.FromFile("../../images/user.png");
            }
            catch
            {
                // If image not found, continue without avatar
            }
        }

        // Login button: authenticate via SQL Parameter query
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

                // Safe parameterized query — prevents SQL Injection
                string query = "SELECT COUNT(*) FROM log_in WHERE username = @User AND password = @Pass";
                SqlCommand command = new SqlCommand(query, db.getConnection);

                // Bind parameters (SqlParameter — see SQLPara_huongdan.docx)
                command.Parameters.Add("@User", SqlDbType.VarChar).Value = username;
                command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = password;

                int count = (int)command.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Ok, next time will be go to Main Menu of App",
                                    "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // TODO: Open MainForm and close login
                    // MainForm main = new MainForm();
                    // main.Show();
                    // this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Username Or Password",
                                    "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtUsername.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.closeConnection();
            }
        }

        // Cancel button: exit application
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
