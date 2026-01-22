using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirebaseAdmin.Auth;
using Guna.UI2.WinForms;

namespace Freelancer_app
{
    public partial class ClientCompletedProject : Form
    {
        private string _email;
        private int _userId;               
        private Guna2PictureBox[] stars;
        string conString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Application.StartupPath}\SkillHive Database.accdb;Persist Security Info=False;";
        public ClientCompletedProject(string email, int userId)
        {
            InitializeComponent();
            _email = email;
            _userId = userId;
        }


        private void ClientCompletedProject_Load(object sender, EventArgs e)
        {
            LoadCompletedProjectCards();
        }

        private void LoadCompletedProjectCards()
        {
            flowLayoutPanelCards.Controls.Clear(); // Assuming you're using a FlowLayoutPanel

            using (OleDbConnection con = new OleDbConnection(conString))
            {
                con.Open();

                // ✅ Updated query: no IsRead, and filtering by ProjectID or ClientID if needed
                string query = @"
                SELECT s.[PNotificationID], s.[Title], s.[Description], s.[Timestamp], s.[FreelancerID]
                FROM SubmittedProjects AS s
                INNER JOIN ClientProjects AS c ON s.[ProjectID] = c.[ProjectID]
                WHERE c.[UserID] = ? AND s.[Reviewed] = False";


                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("?", _userId); // ✅ Now correctly filtering by ClientID

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string title = reader["Title"].ToString();
                            string description = reader["Description"].ToString();
                            DateTime timestamp = Convert.ToDateTime(reader["Timestamp"]);
                            int notificationId = Convert.ToInt32(reader["PNotificationID"]);
                            int freelancerId = Convert.ToInt32(reader["FreelancerID"]);
                            string freelancerName = GetFreelancerName(freelancerId);

                            AddReviewCard(title, freelancerName, description, timestamp, notificationId, freelancerId);
                        }
                    }
                }
            }
        }

        private string GetFreelancerName(int freelancerId)
        {
            using (OleDbConnection con = new OleDbConnection(conString))
            {
                con.Open();
                string query = "SELECT Name FROM FreelancerProfile WHERE FreelancerID = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("?", freelancerId);
                    object result = cmd.ExecuteScalar();
                    return result?.ToString() ?? "Freelancer";
                }
            }
        }

        private void AddReviewCard(string title, string freelancerName, string description, DateTime timestamp, int notificationId, int freelancerId)
        {
            var card = new Guna2Panel
            {
                Width = 500,
                Height = 220,
                BorderRadius = 10,
                BorderThickness = 1,
                BorderColor = Color.Gray,
                Padding = new Padding(10),
                Margin = new Padding(10),
                BackColor = Color.White
            };

            var lblTitle = new Label
            {
                Text = $"📌 {title}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true
            };

            var lblFreelancer = new Label
            {
                Text = $"👤 {freelancerName}",
                Font = new Font("Segoe UI", 10),
                Location = new Point(10, 35),
                AutoSize = true
            };

            var gunaRating = new Guna2RatingStar
            {
                Location = new Point(10, 60),
                Size = new Size(120, 30),
                Cursor = Cursors.Hand
            };

            var txtReview = new Guna2TextBox
            {
                PlaceholderText = "Write your review",
                Location = new Point(10, 100),
                Width = 460,
                Height = 40,
                Cursor = Cursors.IBeam
            };

            var btnSubmit = new Guna2Button
            {
                Text = "Submit Review",
                Location = new Point(10, 150),
                Width = 150,
                Height = 30,
                BorderRadius = 5,
                Tag = notificationId,
                Cursor = Cursors.Hand
            };
            btnSubmit.Click += SubmitReview_Click;

            card.Controls.Add(lblTitle);
            card.Controls.Add(lblFreelancer);
            card.Controls.Add(gunaRating);
            card.Controls.Add(txtReview);
            card.Controls.Add(btnSubmit);

            flowLayoutPanelCards.Controls.Add(card);
        }

        private void SubmitReview_Click(object sender, EventArgs e)
        {
            var btn = sender as Guna2Button;
            int notificationId = (int)btn.Tag;

            var card = btn.Parent as Guna2Panel;
            var rating = card.Controls.OfType<Guna2RatingStar>().FirstOrDefault();
            var reviewBox = card.Controls.OfType<Guna2TextBox>().FirstOrDefault();

            int stars = (int)rating.Value;
            string reviewText = reviewBox.Text.Trim();

            if (stars == 0 || string.IsNullOrEmpty(reviewText))
            {
                MessageBox.Show("Please provide a rating and review.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (OleDbConnection con = new OleDbConnection(conString))
            {
                con.Open();

                // 🔍 Retrieve FreelancerID from SubmittedProjects
                int freelancerId;
                using (OleDbCommand getFreelancerCmd = new OleDbCommand("SELECT FreelancerID FROM SubmittedProjects WHERE PNotificationID = ?", con))
                {
                    getFreelancerCmd.Parameters.Add("PNotificationID", OleDbType.Integer).Value = notificationId;
                    var result = getFreelancerCmd.ExecuteScalar();

                    if (result == null || !int.TryParse(result.ToString(), out freelancerId))
                    {
                        MessageBox.Show("Freelancer ID not found for this notification.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // ✅ Insert review
                string insertQuery = "INSERT INTO Reviews ([NotificationID], [Rating], [ReviewText], [Timestamp], [FreelancerID]) VALUES (?, ?, ?, ?, ?)";
                using (OleDbCommand cmd = new OleDbCommand(insertQuery, con))
                {
                    cmd.Parameters.Add("NotificationID", OleDbType.Integer).Value = notificationId;
                    cmd.Parameters.Add("Rating", OleDbType.Integer).Value = stars;
                    cmd.Parameters.Add("ReviewText", OleDbType.LongVarChar).Value = reviewText;
                    cmd.Parameters.Add("Timestamp", OleDbType.Date).Value = DateTime.Now;
                    cmd.Parameters.Add("FreelancerID", OleDbType.Integer).Value = freelancerId;
                    cmd.ExecuteNonQuery();
                }

                // Mark project as reviewed
                string markReadQuery = "UPDATE SubmittedProjects SET [Reviewed] = ? WHERE [PNotificationID] = ?";
                using (OleDbCommand cmd = new OleDbCommand(markReadQuery, con))
                {
                    cmd.Parameters.Add("Reviewed", OleDbType.Boolean).Value = true;
                    cmd.Parameters.Add("PNotificationID", OleDbType.Integer).Value = notificationId;
                    cmd.ExecuteNonQuery();
                }
            }

            ShowToast("✅ Review submitted successfully.");
            card.Dispose(); // Remove card from UI
        }

        private void ShowToast(string message)
        {
            MessageBox.Show(message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Or replace with Guna toast if you're using Guna.UI2.WinForms.Guna2MessageDialog or Guna2Notification
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnProfile_Click(object sender, EventArgs e)
        {
            ClientProfile clientProfile = new ClientProfile(_userId, _email);
            clientProfile.Show();
            this.Hide();
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            ClientDashboard clientDashboard = new ClientDashboard(_userId, _email);
            clientDashboard.Show();
            this.Hide();
        }

        private void BtnProjects_Click(object sender, EventArgs e)
        {
            ClientProjects clientProjects = new ClientProjects(_userId, _email);
            clientProjects.Show();
            this.Hide();
        }

        private void BtnBidding_Click(object sender, EventArgs e)
        {
            ClientBiddings clientBiddings = new ClientBiddings(_email, _userId);
            clientBiddings.Show();
            this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Freelancer freelancerForm = new Freelancer(_userId, _email);
            freelancerForm.Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            LoginRegisterr loginForm = new LoginRegisterr();
            loginForm.Show();
            this.Hide();
        }

        private void panelSidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {

        }
    }
}
