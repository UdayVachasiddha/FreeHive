using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Freelancer_app
{
    public partial class EditFreelancerProfile : Form
    {
        private int _userId;
        private string _email;
        string conString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=SkillHive Database.accdb;Persist Security Info=False;";


        public EditFreelancerProfile(int userId, string email)
        {
            InitializeComponent();
            _userId = userId;
            _email = email;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            txtEmail.Text = _email;
        }

        private void btnSET_Click(object sender, EventArgs e)
        {
            if (!ValidateFreelancerForm(out var errors))
            {
                MessageBox.Show(
                    string.Join("\n", errors),
                    "Please fix the following issues",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            SaveOrUpdateFreelancerProfile();

            // ✅ After saving, go back to Dashboard first
            Dashboard dashboard = new Dashboard(_userId, _email);
            dashboard.Show();
            this.Hide();
        }

        private bool ValidateFreelancerForm(out List<string> errors)
        {
            errors = new List<string>();

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
                errors.Add("Username is required.");
            if (string.IsNullOrWhiteSpace(txtTagline.Text))
                errors.Add("Tagline is required.");
            if (comboBox1.SelectedItem == null)
                errors.Add("Location must be selected.");
            if (string.IsNullOrWhiteSpace(txtMobile.Text))
                errors.Add("Contact number is required.");
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
                errors.Add("Email ID is required.");
            if (string.IsNullOrWhiteSpace(txtAboutMe.Text))
                errors.Add("About Me section cannot be empty.");
            if (string.IsNullOrWhiteSpace(txtQualification.Text))
                errors.Add("Qualification is required.");
            if (string.IsNullOrWhiteSpace(txtLanguage.Text))
                errors.Add("Preferred language is required.");
            if (string.IsNullOrWhiteSpace(txtPortfolio.Text))
                errors.Add("Portfolio link is required.");
            if (string.IsNullOrWhiteSpace(txtSkills.Text))
                errors.Add("Skill metric is required.");
            if (string.IsNullOrWhiteSpace(txtPastWork.Text))
                errors.Add("Past work details are required.");

            // Phone validation
            if (!string.IsNullOrWhiteSpace(txtMobile.Text) &&
                !Regex.IsMatch(txtMobile.Text.Trim(), @"^\d{10}$"))
            {
                errors.Add("Contact number must be exactly 10 digits.");
            }

            // Email validation
            string email = txtEmail.Text.Trim();
            if (!string.IsNullOrWhiteSpace(email) &&
                !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                errors.Add("Email format is invalid. Use format like abc@xyz.com");
            }

            // Portfolio URL validation (basic check)
            if (!string.IsNullOrWhiteSpace(txtPortfolio.Text) &&
                !Uri.IsWellFormedUriString(txtPortfolio.Text, UriKind.Absolute))
            {
                errors.Add("Portfolio link must be a valid URL (e.g. https://example.com)");
            }

            if (pictureBox3.Image == null)
                errors.Add("Profile photo is required. Please upload an image.");

            return errors.Count == 0;
        }

        private void SaveOrUpdateFreelancerProfile()
        {
            using (OleDbConnection con = new OleDbConnection(conString))
            {
                con.Open();

                string checkQuery = "SELECT COUNT(*) FROM FreelancerProfile WHERE EmailID = ?";
                using (OleDbCommand checkCmd = new OleDbCommand(checkQuery, con))
                {
                    checkCmd.Parameters.AddWithValue("?", _email);
                    int count = (int)checkCmd.ExecuteScalar();

                    string query;
                    if (count > 0)
                    {
                        // ✅ Update existing profile
                        query = @"UPDATE FreelancerProfile 
                                  SET Name=@Name, ContactNo=@ContactNo, AboutMe=@AboutMe, 
                                      Qualification=@Qualification, PreferredLanguage=@PreferredLanguage, 
                                      Portfolio=@Portfolio, Tagline=@Tagline, Location=@Location, 
                                      Skills=@Skills, PastWork=@PastWork, ProfilePicture=@ProfilePicture
                                  WHERE EmailID=@EmailID";
                    }
                    else
                    {
                        // ✅ Insert new profile
                        query = @"INSERT INTO FreelancerProfile 
                                  (Name, ContactNo, AboutMe, Qualification, PreferredLanguage, 
                                   Portfolio, Tagline, Location, Skills, PastWork, ProfilePicture, EmailID) 
                                  VALUES 
                                  (@Name, @ContactNo, @AboutMe, @Qualification, @PreferredLanguage, 
                                   @Portfolio, @Tagline, @Location, @Skills, @PastWork, @ProfilePicture, @EmailID)";
                    }

                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        // Must follow order of fields in query
                        cmd.Parameters.AddWithValue("@Name", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@ContactNo", txtMobile.Text);
                        cmd.Parameters.AddWithValue("@AboutMe", txtAboutMe.Text);
                        cmd.Parameters.AddWithValue("@Qualification", txtQualification.Text);
                        cmd.Parameters.AddWithValue("@PreferredLanguage", txtLanguage.Text);
                        cmd.Parameters.AddWithValue("@Portfolio", txtPortfolio.Text);
                        cmd.Parameters.AddWithValue("@Tagline", txtTagline.Text);
                        cmd.Parameters.AddWithValue("@Location", comboBox1.SelectedItem?.ToString() ?? "");
                        cmd.Parameters.AddWithValue("@Skills", txtSkills.Text);
                        cmd.Parameters.AddWithValue("@PastWork", txtPastWork.Text);

                        // Profile picture
                        if (pictureBox3.Image != null)
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                pictureBox3.Image.Save(ms, pictureBox3.Image.RawFormat);
                                cmd.Parameters.AddWithValue("@ProfilePicture", ms.ToArray());
                            }
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@ProfilePicture", DBNull.Value);
                        }

                        // Email at last
                        cmd.Parameters.AddWithValue("@EmailID", txtEmail.Text);

                        cmd.ExecuteNonQuery();
                    }
                }
            }

            MessageBox.Show("Freelancer profile saved successfully!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var a = new OpenFileDialog())
            {
                a.Title = "Select Profile Picture";
                a.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                a.Multiselect = false;

                if (a.ShowDialog() == DialogResult.OK)
                {
                    if (pictureBox3.Image != null)
                    {
                        pictureBox3.Image.Dispose();
                        pictureBox3.Image = null;
                    }

                    pictureBox3.Image = Image.FromFile(a.FileName);
                    pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile(_userId, _email);
            profile.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
