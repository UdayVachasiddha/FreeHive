using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Freelancer_app
{
    public partial class ViewProfile : Form
    {
        private string _email;
        private int _freelancerId;
        string conString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=SkillHive Database.accdb;Persist Security Info=False;";

        public ViewProfile(int id)
        {
            InitializeComponent();
            _freelancerId = id;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ViewProfile_Load(object sender, EventArgs e)
        {
            LoadFreelancerDetails();
        }

        private void LoadFreelancerDetails()
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(conString))
                {
                    conn.Open();

                    // ✅ Step 1: Load profile data directly using _freelancerId
                    string query = @"SELECT [Name], [ContactNo], [EmailID], [AboutMe], 
                             [Qualification], [PreferredLanguage],
                             [Portfolio], [Tagline], [Location],
                             [ProfilePicture], [Skills], [PastWork]
                             FROM FreelancerProfile
                             WHERE FreelancerID = ?";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", _freelancerId);

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtUsername.Text = reader["Name"]?.ToString();
                                txtMobile.Text = reader["ContactNo"]?.ToString();
                                txtEmail.Text = reader["EmailID"]?.ToString();
                                txtAboutMe.Text = reader["AboutMe"]?.ToString();
                                txtQualification.Text = reader["Qualification"]?.ToString();
                                txtLanguage.Text = reader["PreferredLanguage"]?.ToString();
                                txtTagline.Text = reader["Tagline"]?.ToString();
                                txtLocation.Text = reader["Location"]?.ToString();
                                txtSkills.Text = reader["Skills"]?.ToString();
                                txtPastWork.Text = reader["PastWork"]?.ToString();

                                // ✅ Portfolio
                                string portfolio = reader["Portfolio"]?.ToString();
                                if (!string.IsNullOrWhiteSpace(portfolio))
                                {
                                    linkPortfolio.Text = portfolio;
                                    linkPortfolio.Links.Clear();
                                    linkPortfolio.Links.Add(0, portfolio.Length, portfolio);
                                    linkPortfolio.Visible = true;
                                }
                                else
                                {
                                    linkPortfolio.Text = "";
                                    linkPortfolio.Visible = false;
                                }

                                // ✅ Profile picture
                                if (reader["ProfilePicture"] != DBNull.Value)
                                {
                                    byte[] imgData = (byte[])reader["ProfilePicture"];
                                    using (MemoryStream ms = new MemoryStream(imgData))
                                    {
                                        if (pictureBoxProfile.Image != null)
                                            pictureBoxProfile.Image.Dispose();

                                        pictureBoxProfile.Image = Image.FromStream(ms);
                                        pictureBoxProfile.SizeMode = PictureBoxSizeMode.StretchImage;
                                    }
                                }
                                else
                                {
                                    pictureBoxProfile.Image = null;
                                }
                            }
                            else
                            {
                                MessageBox.Show("No freelancer profile found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }

                // ✅ Step 2: Display rating
                float avgRating = GetAverageRating(_freelancerId);
                DisplayRating(avgRating);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading profile: " + ex.Message);
            }
        }
        private void linkPortfolio_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string url = e.Link.LinkData as string ?? linkPortfolio.Text;
                if (!string.IsNullOrWhiteSpace(url))
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private float GetAverageRating(int freelancerId)
        {
            float average = 0;
            int count = 0;

            using (OleDbConnection con = new OleDbConnection(conString))
            {
                con.Open();
                string query = "SELECT Rating FROM Reviews WHERE FreelancerID = ?";

                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("?", freelancerId);

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        int total = 0;
                        while (reader.Read())
                        {
                            total += Convert.ToInt32(reader["Rating"]);
                            count++;
                        }

                        if (count > 0)
                            average = (float)total / count;
                    }
                }
            }

            return average;
        }

        private void DisplayRating(float averageRating)
        {
            averageRating = Math.Max(0, Math.Min(5, averageRating));
            if (float.IsNaN(averageRating)) averageRating = 0;

            // Clear previous rating labels
            var oldLabels = panel2.Controls.OfType<Label>()
                .Where(lbl => lbl.Text.Contains("★") || lbl.Text.Contains("☆") || lbl.Text.Contains("/ 5"))
                .ToList();

            foreach (var lbl in oldLabels)
                panel2.Controls.Remove(lbl);

            int fullStars = (int)Math.Floor(averageRating);
            bool halfStar = averageRating - fullStars >= 0.5;

            string stars = new string('★', fullStars);
            if (halfStar) stars += "☆";
            stars = stars.PadRight(5, '☆');

            var lblStars = new Label
            {
                Text = stars,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.Goldenrod,
                Location = new Point(115, 75),
                AutoSize = true
            };

            var lblRating = new Label
            {
                Text = $":{averageRating:F1} / 5",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(40, 40, 40),
                Location = new Point(lblStars.Right + 5, lblStars.Top + 7),
                AutoSize = true
            };

            panel2.Controls.Add(lblStars);
            panel2.Controls.Add(lblRating);
        }
    }
}
