using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Mail;
using System.Net;
using System.Data.OleDb;

namespace Freelancer_app
{
    public partial class ForgotPasswordForm : Form
    {
        string conString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=SkillHive Database.accdb;Persist Security Info=False;";

        public ForgotPasswordForm()
        {
            InitializeComponent();
        }

        private void ForgotPasswordForm_Load(object sender, EventArgs e)
        {
        }

        private void btnSendOtp_Click(object sender, EventArgs e)
        {
        }

        private void txtMobile_TextChanged(object sender, EventArgs e)
        {
        }

        private void ForgotPasswordForm_Load_1(object sender, EventArgs e)
        {
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {
        }

        private async void btnSendOtp1_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim(); // Use TextBox for email input

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please enter your registered email address.");
                return;
            }

            // Check if email exists in database
            if (!IsEmailRegistered(email))
            {
                MessageBox.Show("Email not found. Please register or use a valid email.");
                return;
            }

            Random rnd = new Random();
            int generatedOtp = rnd.Next(1000, 9999);

            try
            {
                // Set up the email message
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("freehive787@gmail.com"); 
                mail.To.Add(email);
                mail.Subject = "OTP for Password Reset";
                mail.Body = $"Dear User,\n\nYour one-time password (OTP) for resetting your password is: {generatedOtp}.\n\nThis OTP is valid for 10 minutes. Do not share it with anyone.\n\nBest regards,\nYour FreeHive App Team";
                mail.IsBodyHtml = false;

                // Set up SMTP client
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new System.Net.NetworkCredential("freehive787@gmail.com", "sqvz jzkn klbm atov"); // Use App Password
                smtp.EnableSsl = true;

                // Send the email
                smtp.Send(mail);

                MessageBox.Show("OTP sent to your email. Please check your inbox (and spam folder).");

                // Navigate to OTP Verification Form
                OtpVerificationForm otpForm = new OtpVerificationForm(generatedOtp.ToString(), email);
                otpForm.Show();
                this.Hide();
            }
            catch (SmtpException ex)
            {
                MessageBox.Show("SMTP error: " + ex.Message + "\nCheck your Gmail settings or App Password.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending OTP: " + ex.Message);
            }
        }

        private bool IsEmailRegistered(string email)
        {
            using (OleDbConnection conn = new OleDbConnection(conString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Users WHERE Email = ?";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("?", email);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
                catch (Exception)
                {
                    return false; // Assume not registered on error
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            LoginRegisterr LoginForm = new LoginRegisterr();
            LoginForm.Show();
            this.Close();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
