using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;
using System.Net.Mail;
using System.Net;

namespace Freelancer_app
{

    public partial class OtpVerificationForm : Form
    {
        private string generatedOtp;
        private string email;
        public OtpVerificationForm(string otp, string userEmail)
        {
            InitializeComponent();
            generatedOtp = otp;
            email = userEmail;
        }

        private void OtpVerificationForm_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = 600000; // 10 minutes in milliseconds
            timer.Tick += (s, args) =>
            {
                generatedOtp = null;
                timer.Stop();
                MessageBox.Show("OTP has expired. Please request a new one.");
            };
            timer.Start();
        }

        private void btnSendOtp_Click(object sender, EventArgs e)
        {
            
        }

        private async void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Random rnd = new Random();
            int newOtp = rnd.Next(1000, 9999);
            generatedOtp = newOtp.ToString();

            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("freehive787@gmail.com");
                mail.To.Add(email);
                mail.Subject = "New OTP for Password Reset";
                mail.Body = $"Your new OTP is: {newOtp}. Valid for 10 minutes.";
                mail.IsBodyHtml = false;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("freehive787@gmail.com", "sqvz jzkn klbm atov");
                smtp.EnableSsl = true;
                smtp.Send(mail);

                MessageBox.Show("New OTP sent to your email.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error resending OTP: " + ex.Message);
            }
        }

        private void txtMobile1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void btnVerifyOtp_Click(object sender, EventArgs e)
        {
            if (txtOtp.Text == generatedOtp)
            {
                MessageBox.Show("OTP Verified! You can now reset your password.");
                txtNewPassword resetForm = new txtNewPassword(email); // Pass email for DB update
                resetForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid OTP. Please try again.");
                txtOtp.Clear();
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Open Gmail in the default browser
            System.Diagnostics.Process.Start("https://mail.google.com/");
        }
    }
}
