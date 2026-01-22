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
using Guna.UI2.WinForms;
using TheArtOfDevHtmlRenderer.Core;

namespace Freelancer_app
{
    public partial class BiddingStatus : Form
    {
        private int _userId;
        private string _email;
        string conString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=SkillHive Database.accdb;Persist Security Info=False;";
        private int _freelancerId; // Assuming you have a way to get the FreelancerID based on the logged-in user
        private bool hasData;

        public BiddingStatus(int userId, string email)
        {
            InitializeComponent();
            _userId = userId;
            _email = email;
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard(_userId, _email);
            dashboard.Show();
            this.Hide();
        }

        private void BtnProjects_Click(object sender, EventArgs e)
        {
            MyProjects projectsForm = new MyProjects(_userId, _email);
            projectsForm.Show();
            this.Hide();
        }

        private void BtnMessages_Click(object sender, EventArgs e)
        {
            Message messagesForm = new Message(_userId, _email);
            messagesForm.Show();
            this.Hide();
        }

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            LoginRegisterr loginForm = new LoginRegisterr();
            loginForm.Show();
            this.Hide();
        }

        private void BiddingStatus_Load(object sender, EventArgs e)
        {
            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel2.WrapContents = false;

            AssignFreelancerId();
            LoadBiddingCards();
        }

        private void AssignFreelancerId()
        {
            using (OleDbConnection con = new OleDbConnection(conString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT FreelancerID FROM FreelancerProfile WHERE EmailID = ?";
                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("?", _email);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                            _freelancerId = Convert.ToInt32(result);
                        else
                            MessageBox.Show("Freelancer profile not found for this account.", "Profile Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error retrieving FreelancerID: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadBiddingCards()
        {
            flowLayoutPanel2.Controls.Clear();

            using (OleDbConnection con = new OleDbConnection(conString))
            {
                try
                {
                    con.Open();
                    string query = @"
                    SELECT b.BidID, b.BidAmount, b.Status, b.BidDate, p.ProjectTitle
                    FROM Biddings AS b
                    INNER JOIN ClientProjects AS p ON b.ProjectID = p.ProjectID
                    WHERE b.FreelancerID = ?";

                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("?", _freelancerId);

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string title = reader["ProjectTitle"].ToString();       // ✅ Correct field name
                                decimal amount = Convert.ToDecimal(reader["BidAmount"]);
                                string status = reader["Status"].ToString();           // ✅ Correct field name
                                DateTime timestamp = Convert.ToDateTime(reader["BidDate"]); // ✅ Correct field name

                                AddBiddingCard(title, amount, status, timestamp);
                            }
                        }
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error loading bids: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddBiddingCard(string title, decimal amount, string status, DateTime timestamp)
        {
            var card = new Guna2Panel
            {
                Width = 540,
                Height = 180,
                BorderRadius = 12,
                BorderThickness = 1,
                BorderColor = Color.LightGray,
                FillColor = Color.White,
                Margin = new Padding(10),
                ShadowDecoration = { Enabled = true, Shadow = new Padding(5) }
            };

            var lblTitle = new Guna2HtmlLabel
            {
                Text = $"<b>{title}</b>",
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                Location = new Point(20, 15),
                AutoSize = true,
                ForeColor = Color.FromArgb(30, 30, 30)
            };

            var lblAmount = new Guna2HtmlLabel
            {
                Text = $"<b>Bid:</b> ₹{amount:N0}",
                Font = new Font("Segoe UI", 10),
                Location = new Point(20, 45),
                AutoSize = true,
                ForeColor = Color.FromArgb(60, 60, 60)
            };

            var lblStatus = new Guna2HtmlLabel
            {
                Text = $"<b>Status:</b> {status}",
                Font = new Font("Segoe UI", 10, FontStyle.Italic),
                Location = new Point(20, 70),
                AutoSize = true,
                ForeColor = status == "Accepted" ? Color.ForestGreen :
                            status == "Rejected" ? Color.Firebrick : Color.DarkOrange
            };

            var lblTime = new Guna2HtmlLabel
            {
                Text = $"<i>{timestamp:dd MMM yyyy, hh:mm tt}</i>",
                Font = new Font("Segoe UI", 9),
                Location = new Point(20, 95),
                AutoSize = true,
                ForeColor = Color.Gray
            };

            var statusBadge = new Guna2Button
            {
                Text = status.ToUpper(),
                Size = new Size(130, 38),
                Location = new Point(400, 20),
                BorderRadius = 20,
                FillColor = status switch
                {
                    "Accepted" => Color.FromArgb(0, 180, 100),     // Emerald green
                    "Rejected" => Color.FromArgb(220, 53, 69),     // Soft red
                    "Pending" => Color.FromArgb(255, 193, 7),     // Amber
                    _ => Color.SteelBlue                           // Fallback
                },
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Enabled = false,
                Cursor = Cursors.Default,
                TextAlign = HorizontalAlignment.Center,
                ShadowDecoration =
                {
                    Enabled = true,
                    BorderRadius = 20,
                    Shadow = new Padding(3)
                },
                HoverState =
                {
                    FillColor = status switch
                    {
                        "Accepted" => Color.FromArgb(0, 160, 90),
                        "Rejected" => Color.FromArgb(200, 40, 60),
                        "Pending"  => Color.FromArgb(245, 180, 0),
                        _ => Color.DodgerBlue
                    }
                }
            };

            var separator = new Guna2Separator
            {
                Location = new Point(20, 130),
                Width = 480,
                FillThickness = 1,
                FillColor = Color.LightGray
            };

            card.Controls.Add(lblTitle);
            card.Controls.Add(lblAmount);
            card.Controls.Add(lblStatus);
            card.Controls.Add(lblTime);
            card.Controls.Add(statusBadge);
            card.Controls.Add(separator);

            flowLayoutPanel2.Controls.Add(card);
        }

        private void BtnProfile_Click(object sender, EventArgs e)
        {
            FreelancerProfile profileForm = new FreelancerProfile(_userId, _email);
            profileForm.Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            ProjectSubmit projectSubmitForm = new ProjectSubmit(_userId, _email);
            projectSubmitForm.Show();
            this.Hide();
        }
    }
}
