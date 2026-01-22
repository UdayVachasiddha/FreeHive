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
using System.Text.RegularExpressions;

namespace Freelancer_app
{
    public partial class LoginRegisterr : Form
    {
         string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=SkillHive Database.accdb;Persist Security Info=False;";
         //string dbPath = System.IO.Path.Combine(Application.StartupPath, "SkillHiveDatabase.accdb");
        public LoginRegisterr()
        {
            InitializeComponent();
            panelLogin.Visible = true;
            panelRegister.Visible = false;
        }

        private void panelLogin_Paint(object sender, PaintEventArgs e)
        {
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string email = txtLoginEmail.Text.Trim();
            string password = txtLoginPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both Email and Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {

                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("SELECT UserID, [Password] FROM Users WHERE Email=@Email", conn);
                    cmd.Parameters.AddWithValue("@Email", email);

                    OleDbDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // ✅ User exists
                        string storedPassword = reader["Password"].ToString();
                        int userId = Convert.ToInt32(reader["UserID"]);

                        if (storedPassword == password)
                        {
                            // Go to Profile.cs
                            Profile profileForm = new Profile(userId, email);
                            profileForm.Show();
                            this.Hide(); // 🔹 close instead of hide
                        }
                        else
                        {
                            MessageBox.Show("Incorrect Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Email not registered!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Login failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelLogin.Visible = false;
            panelRegister.Visible = true;
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPasswordForm forgotForm = new ForgotPasswordForm();
            forgotForm.Show();
            this.Hide();
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            string email = txtRegisterEmail.Text.Trim();
            string password = txtRegisterPassword.Text.Trim();
            string confirmPassword = txtRegisterConfirm.Text.Trim();

            // 1️⃣ Check if fields are filled
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please fill all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2️⃣ Validate email format
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Invalid Email format! Example: abc@xyz.com", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3️⃣ Check if email already exists
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                OleDbCommand checkCmd = new OleDbCommand("SELECT COUNT(*) FROM Users WHERE Email=@Email", conn);
                checkCmd.Parameters.AddWithValue("@Email", email);

                int exists = (int)checkCmd.ExecuteScalar();
                if (exists > 0)
                {
                    MessageBox.Show("Email already registered!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // 4️⃣ Validate password
            if (!Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z]).{8,12}$"))
            {
                MessageBox.Show("Password must contain 1 uppercase, 1 lowercase and be 8–12 characters long!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 5️⃣ Confirm password match
            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 6️⃣ Save user to DB
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                OleDbCommand insertCmd = new OleDbCommand(
                    "INSERT INTO Users (Email, [Password]) VALUES (@Email, @Password)", conn);

                insertCmd.Parameters.AddWithValue("@Email", email);
                insertCmd.Parameters.AddWithValue("@Password", password);
                insertCmd.ExecuteNonQuery();
            }

            MessageBox.Show("Registration Successful! Please login.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Switch back to login
            panelRegister.Visible = false;
            panelLogin.Visible = true;
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelRegister.Visible = false;
            panelLogin.Visible = true;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void LoginRegisterr_Load(object sender, EventArgs e)
        {

        }
    }
}
