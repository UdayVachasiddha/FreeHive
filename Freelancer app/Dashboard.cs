using System;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using System.Media;
using FirebaseAdmin.Messaging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Security.Claims;

namespace Freelancer_app
{
    public partial class Dashboard : Form
    {
        private int _userId;
        private string _email;
        private int _previousUnreadCount = 0;
        private int _freelancerId; // For counting active bids
        string conString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=SkillHive Database.accdb;Persist Security Info=False;";

        public Dashboard(int userId, string email)
        {
            InitializeComponent();
            _userId = userId;
            _email = email;

            //AddNotificationBadge();
            this.Load += new System.EventHandler(this.Dashboard_Load);
            badgePulseTimer.Tick -= badgePulseTimer_Tick; // Prevent duplicate wiring
            badgePulseTimer.Tick += badgePulseTimer_Tick;
            lblBadgee.Visible = false; // Hide initially
            btnClearAll.Visible = false; // Hide initially
        }

        private void LoadNotifications()
        {
            flowLayoutPanelNotifications.Controls.Clear();
            int unreadCount = 0;

            using (OleDbConnection con = new OleDbConnection(conString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT NotificationID, Message, [Timestamp] FROM Notifications WHERE FreelancerID = ? ORDER BY [Timestamp] DESC";

                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("?", _freelancerId);

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                unreadCount++;

                                string message = reader["Message"].ToString();
                                string time = Convert.ToDateTime(reader["Timestamp"]).ToString("g");

                                Label lbl = new Label
                                {
                                    Text = $"{message}\n{time}",
                                    AutoSize = false,
                                    Size = new Size(flowLayoutPanelNotifications.Width - 10, 50),
                                    Font = new Font("Segoe UI", 10),
                                    Padding = new Padding(5),
                                    BackColor = Color.WhiteSmoke,
                                    BorderStyle = BorderStyle.FixedSingle
                                };

                                flowLayoutPanelNotifications.Controls.Add(lbl);
                            }
                        }
                    }
                    
                    if (unreadCount == 0)
                    {
                        Label lblEmpty = new Label
                        {
                            Text = "No new notifications",
                            AutoSize = false,
                            Size = new Size(flowLayoutPanelNotifications.Width - 20, 50),
                            Font = new Font("Segoe UI", 10, FontStyle.Italic),
                            ForeColor = Color.Gray,
                            TextAlign = ContentAlignment.MiddleCenter,
                            BackColor = Color.WhiteSmoke
                        };

                        flowLayoutPanelNotifications.Controls.Add(lblEmpty);
                    }

                    // 🔔 Update badge and pulse
                    lblBadgee.Text = unreadCount.ToString();
                    lblBadgee.Visible = unreadCount > 0;

                    // ✅ Play sound only if new notifications arrived
                    if (unreadCount > _previousUnreadCount)
                    {
                        var player = new System.Media.SoundPlayer(@"Resources/notification.wav");
                        player.Play();
                    }

                    _previousUnreadCount = unreadCount; // Update tracker


                    if (unreadCount > 0)
                    {
                        if (!badgePulseTimer.Enabled)
                            badgePulseTimer.Start();
                    }
                    else
                    {
                        badgePulseTimer.Stop();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading notifications: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadRecentProjects()
        {
            flowRecentProjects.Controls.Clear();

            using (OleDbConnection con = new OleDbConnection(conString))
            {
                con.Open();

                // ✅ Replaced Timestamp with Deadline to avoid OleDbException
                string query = @"SELECT TOP 3 P.ProjectTitle, P.Description, P.Budget, P.Deadline, 
                                            P.EmailID, C.Name AS ClientName
                                     FROM ClientProjects P
                                     LEFT JOIN ClientProfile C ON P.EmailID = C.EmailID
                                     WHERE P.Status = 'Pending'
                                     ORDER BY P.Deadline ASC";

                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    try
                    {
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string title = reader["ProjectTitle"]?.ToString() ?? "Untitled Project";
                                string description = reader["Description"]?.ToString() ?? "No description available";
                                string budget = reader["Budget"]?.ToString() ?? "0";
                                string deadline = reader["Deadline"]?.ToString() ?? "No deadline";
                                string clientEmail = reader["EmailID"]?.ToString() ?? "Unknown Client";
                                string clientName = reader["ClientName"]?.ToString() ?? "";

                                AddProjectCard(title, description, budget, deadline, clientEmail, clientName);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading recent projects: " + ex.Message,
                                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void AddProjectCard(string title, string description, string budget, string deadline, string clientEmail, string clientName)
        {
            Guna2Panel card = new Guna2Panel
            {
                Size = new Size(250, 270),
                BorderRadius = 10,
                BorderColor = Color.LightGray,
                BorderThickness = 1,
                FillColor = Color.White,
                Margin = new Padding(10),
                Padding = new Padding(10),
                ShadowDecoration = { Enabled = true, Shadow = new Padding(0, 2, 4, 4) }
            };

            // 🔹 Title
            var lblTitle = new Guna2HtmlLabel
            {
                Text = title,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(10, 8),
                Size = new Size(230, 20),
                TextAlignment = ContentAlignment.MiddleLeft
            };

            // 🔹 Posted by
            var lblClient = new Guna2HtmlLabel
            {
                Text = $"Posted by: {(string.IsNullOrWhiteSpace(clientName) ? clientEmail : clientName)}",
                Font = new Font("Segoe UI", 8, FontStyle.Italic),
                ForeColor = Color.Gray,
                Location = new Point(10, 40),
                Size = new Size(230, 15),
                TextAlignment = ContentAlignment.MiddleLeft
            };

            // 🔹 Description
            var txtDescription = new TextBox
            {
                Text = description,
                Multiline = true,
                ReadOnly = true,
                BorderStyle = BorderStyle.None,
                BackColor = Color.WhiteSmoke,
                Location = new Point(10, 60),
                Size = new Size(230, 80),
                ScrollBars = ScrollBars.Vertical
            };

            // 🔹 Budget
            var lblBudget = new Guna2HtmlLabel
            {
                Text = $"Budget: ₹{budget}",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.DarkGreen,
                Location = new Point(10, 155),
                AutoSize = true
            };

            // 🔹 Deadline
            var lblDeadline = new Guna2HtmlLabel
            {
                Text = $"Deadline: {deadline}",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Black,
                Location = new Point(10, 175),
                AutoSize = true
            };

            // 🔹 Bid Button
            var btnBid = new Guna2Button
            {
                Text = "Bid Now",
                Size = new Size(100, 30),
                Location = new Point((250 - 100) / 2, 225),
                BorderRadius = 6,
                FillColor = Color.FromArgb(0, 120, 215),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Cursor = Cursors.Hand
            };

            btnBid.Click += (s, e) =>
            {
                Bidding biddingForm = new Bidding(_userId, _email, title, budget, deadline, clientEmail, clientName);
                biddingForm.Show();
                this.Hide();
            };

            card.Controls.AddRange(new Control[] { lblTitle, lblClient, txtDescription, lblBudget, lblDeadline, btnBid });
            flowRecentProjects.Controls.Add(card);
        }

        private bool isBadgeeBright = true;

        private void badgePulseTimer_Tick(object sender, EventArgs e)
        {
            lblBadgee.ForeColor = isBadgeeBright ? Color.Red : Color.OrangeRed;
            isBadgeeBright = !isBadgeeBright;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            lblBadgee.BringToFront();
            AssignFreelancerId();         // ✅ Assign ID before loading stats
            LoadNotifications();          // 🔔 Load badge count
            LoadDashboardStats();
            LoadRecentProjects();
        }

        private void AssignFreelancerId()
        { 
            using (OleDbConnection con = new OleDbConnection(conString))
            {
                con.Open();
                string query = "SELECT FreelancerID FROM FreelancerProfile WHERE EmailID = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("?", _email);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                        _freelancerId = Convert.ToInt32(result);
                }
            }
        }

        private void LoadDashboardStats()
        {
            LoadActiveBids();
            LoadCompletedProjects();
            LoadEarnings();
        }

        private void LoadActiveBids()
        {
            int activeBids = 0;
            using (OleDbConnection con = new OleDbConnection(conString))
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM Biddings WHERE FreelancerID = ? AND Status = 'Pending'";
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("?", _freelancerId);
                    activeBids = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            lblActiveBids.Text = activeBids.ToString(); // Make sure this label exists on your form
        }

        private void LoadCompletedProjects()
        {

            int completedProjects = 0;
            using (OleDbConnection con = new OleDbConnection(conString))
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM SubmittedProjects WHERE FreelancerID = ? AND Reviewed = True";
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("?", _freelancerId);
                    completedProjects = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            lblCompletedProjects.Text = completedProjects.ToString();
        }

        private void LoadEarnings()
        {

            decimal earnings = 0;
            using (OleDbConnection con = new OleDbConnection(conString))
            {
                con.Open();
                string query = "SELECT SUM(ContractAmount) FROM Contracts WHERE FreelancerID = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("?", _freelancerId);
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                        earnings = Convert.ToDecimal(result);
                }
            }
            lblEarnings.Text = $"₹{earnings:N0}";
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            flowLayoutPanelNotifications.Visible = !flowLayoutPanelNotifications.Visible;

            if (flowLayoutPanelNotifications.Visible)
            {
                LoadNotifications();

                // Show Clear All only if there are actual notifications
                bool hasNotifications = flowLayoutPanelNotifications.Controls.Count > 0 &&
                                        !(flowLayoutPanelNotifications.Controls[0] is Label lbl && lbl.Text == "No new notifications");

                btnClearAll.Visible = hasNotifications;
            }
            else
            {
                btnClearAll.Visible = false;
            }

            lblBadgee.Visible = false; // Hide badge when panel is opened
        }


        private void Dashboard_Click(object sender, EventArgs e)
        {
           
        }

        
        private void flowLayoutPanelNotifications_Click(object sender, EventArgs e)
        {
            
        }

        // Navigation methods
        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            LoginRegisterr loginForm = new LoginRegisterr();
            loginForm.Show();
            this.Hide();
        }

        private void BtnProfile_Click(object sender, EventArgs e)
        {
            FreelancerProfile profileForm = new FreelancerProfile(_userId, _email);
            profileForm.Show();
            this.Hide();
        }

        private void BtnMessages_Click(object sender, EventArgs e)
        {
            Message messagesForm = new Message(_userId, _email);
            messagesForm.Show();
            this.Hide();
        }

        private void BtnProjects_Click(object sender, EventArgs e)
        {
            MyProjects projectsForm = new MyProjects(_userId, _email);
            projectsForm.Show();
            this.Hide();
        }

        private void BtnBidding_Click(object sender, EventArgs e)
        {
            BiddingStatus biddingForm = new BiddingStatus(_userId, _email);
            biddingForm.Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e) 
        {
            
        }
        
        private void guna2Button7_Click(object sender, EventArgs e) 
        { 
        
        }
        
        private void guna2Button6_Click(object sender, EventArgs e) 
        {
        
        }
        private void guna2Button5_Click(object sender, EventArgs e) { }
        private void guna2Button4_Click(object sender, EventArgs e) { }
        private void guna2Button3_Click(object sender, EventArgs e) { }
        private void guna2Button2_Click(object sender, EventArgs e) { }
        private void panelSidebar_Paint(object sender, PaintEventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
        private void guna2Panel4_Paint(object sender, PaintEventArgs e) { }
        private void lblTitle_Click(object sender, EventArgs e) { }
        private void guna2Panel6_Paint(object sender, PaintEventArgs e) { }
        private void guna2Button3_Click_1(object sender, EventArgs e) { }
        private void label12_Click(object sender, EventArgs e) { }
        private void label13_Click(object sender, EventArgs e) { }
        private void guna2Panel5_Paint(object sender, PaintEventArgs e) { }
        private void guna2Button2_Click_1(object sender, EventArgs e) { }
        private void label10_Click(object sender, EventArgs e) { }
        private void label11_Click(object sender, EventArgs e) { }
        private void panelTop_Paint(object sender, PaintEventArgs e) { }
        private void guna2Button1_Click_1(object sender, EventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }
        private void txtSearch_TextChanged(object sender, EventArgs e) { }
        private void panelContent_Paint(object sender, PaintEventArgs e) { }
        private void guna2Panel3_Paint(object sender, PaintEventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void guna2Panel2_Paint(object sender, PaintEventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void guna2Panel1_Paint(object sender, EventArgs e) { }

        private void btnClearAll_Click_1(object sender, EventArgs e)
        {
            using (OleDbConnection con = new OleDbConnection(conString))
            {
                try
                {
                    con.Open();
                    string query = "DELETE FROM Notifications WHERE FreelancerID = ?";

                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("?", _userId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("All notifications cleared.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadNotifications(); // Refresh panel and badge
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error clearing notifications: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
         
        }

        private void guna2Panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click_2(object sender, EventArgs e)
        {
            ProjectSubmit submittedForm = new ProjectSubmit(_userId, _email);
            submittedForm.Show();
            this.Hide();
        }
    }
}