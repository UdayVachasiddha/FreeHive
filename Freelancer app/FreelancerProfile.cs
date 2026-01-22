using System;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Freelancer_app
{
    public partial class FreelancerProfile : Form
    {
        private readonly int _userId;
        private readonly string _email;
        private int _freelancerId; // To store the freelancer's ID
        string conString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=SkillHive Database.accdb;Persist Security Info=False;";


        public FreelancerProfile(int userId, string email)
        {
            InitializeComponent();
            _userId = userId;
            _email = email;

            // Ensure the Load event is wired
            this.Load += FreelancerProfile_Load;

            // Wire LinkClicked event for portfolio link
            linkPortfolio.LinkClicked += linkPortfolio_LinkClicked;
        }

        private void FreelancerProfile_Load(object sender, EventArgs e)
        {
            txtEmail.Text = _email;   // show login email
            txtEmail.ReadOnly = true; // keep it read-only
            LoadFreelancerProfile();
        }

        private void LoadFreelancerProfile()
        {
            try
            {
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    con.Open();

                    // ✅ Step 1: Assign _freelancerId
                    string idQuery = "SELECT FreelancerID FROM FreelancerProfile WHERE EmailID = ?";
                    using (OleDbCommand idCmd = new OleDbCommand(idQuery, con))
                    {
                        idCmd.Parameters.AddWithValue("?", _email);
                        object result = idCmd.ExecuteScalar();
                        if (result != null)
                            _freelancerId = Convert.ToInt32(result);
                    }

                    // ✅ Step 2: Load profile data — use a fresh command object
                    string profileQuery = @"SELECT [Name], [ContactNo], [EmailID], [AboutMe], 
                                    [Qualification], [PreferredLanguage], 
                                    [Portfolio], [Tagline], [Location], 
                                    [ProfilePicture], [Skills], [PastWork]
                                    FROM FreelancerProfile
                                    WHERE [EmailID] = ?";
                    using (OleDbCommand cmd = new OleDbCommand(profileQuery, con))
                    {
                        cmd.Parameters.AddWithValue("?", _email);
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader != null && reader.Read())
                            {
                                // Fill textboxes here
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

                                // Portfolio as clickable link
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

                                // Profile picture
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
                                MessageBox.Show("No freelancer profile found for this email.",
                                                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }

                        // ✅ Step 3: Display rating
                        float avgRating = GetAverageRating(_freelancerId);
                        DisplayRating(avgRating);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading freelancer profile:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🔹 When user clicks Portfolio link
        private void linkPortfolio_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        // 🔹 Edit Profile Button click event

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard(_userId, _email);
            dashboard.Show();
            this.Hide();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBoxProfile_Click(object sender, EventArgs e)
        {

        }

        private void txtTagline_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSET_Click(object sender, EventArgs e)
        {
            EditFreelancerProfile editForm = new EditFreelancerProfile(_userId, _email);
            this.Hide();
            editForm.Show();
        }

        private void FreelancerProfile_Load_1(object sender, EventArgs e)
        {
            //float avgRating = GetAverageRating(_freelancerId);
            //DisplayRating(avgRating);
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
            int fullStars = (int)Math.Floor(averageRating);
            bool halfStar = averageRating - fullStars >= 0.5;

            string stars = new string('★', fullStars);
            if (halfStar) stars += "☆"; // Optional half star
            stars = stars.PadRight(5, '☆'); // Fill up to 5 stars

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
                Location = new Point(217, 82),
                AutoSize = true
            };

            panel2.Controls.Add(lblStars);
            panel2.Controls.Add(lblRating);
        }
    }
}
