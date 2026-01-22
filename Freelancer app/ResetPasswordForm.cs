using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Freelancer_app
{
    public partial class txtNewPassword : Form
    {
        private string email;
        string conString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=SkillHive Database.accdb;Persist Security Info=False;";

        public txtNewPassword(string userEmail)
        {
            InitializeComponent();
            email = userEmail;
        }

        private void ResetPasswordForm_Load(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string newPass = txtNewPasswordBox.Text.Trim();
            string confirmPass = txtConfirmPassword.Text.Trim();

            if (newPass != confirmPass)
            {
                MessageBox.Show("Passwords do not match!");
                return;
            }

            if (newPass.Length < 8 || newPass.Length > 12)
            {
                MessageBox.Show("Password must be between 8 and 12 characters.");
                return;
            }

            // Regex: at least 1 uppercase, 1 lowercase, allowed length 8–12
            Regex regex = new Regex(@"^(?=.*[A-Z])(?=.*[a-z]).{8,12}$");

            if (!regex.IsMatch(newPass))
            {
                MessageBox.Show("Password must contain at least 1 uppercase letter and 1 lowercase letter.");
                return;
            }


            // Update password in MS Access Database
            using (OleDbConnection conn = new OleDbConnection(conString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE Users SET [Password]=? WHERE [Email]=?";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", newPass);
                        cmd.Parameters.AddWithValue("?", email);

                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            MessageBox.Show("Password reset successfully!");
                            LoginRegisterr login = new LoginRegisterr();
                            login.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Error: Email not found!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message);
                }
            }
        }
    }
}
