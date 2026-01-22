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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Freelancer_app
{
    public partial class ClientBiddings : Form
    {
        private string _email;
        private int _userId;
        public int _freelancerId;
        string conString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=SkillHive Database.accdb;Persist Security Info=False;";

        public ClientBiddings(string email, int userId)
        {
            InitializeComponent();
            _email = email;
            _userId = userId;
        }

        private void ClientBiddings_Load(object sender, EventArgs e)
        {
            LoadBidsForClient();
        }

        private void LoadBidsForClient()
        {
            flowLayoutPanelProposals.Controls.Clear();

           
            using (OleDbConnection con = new OleDbConnection(conString))
            {
                try
                {
                    con.Open();
                    string query = @"
                SELECT 
                    B.BidID,
                    B.ProjectTitle,
                    B.BidAmount,
                    B.BidMessage,
                    B.BidDate,
                    F.[Name] AS FreelancerName,
                    P.Deadline,
                    B.Status
                FROM 
                    (Biddings AS B 
                    LEFT JOIN FreelancerProfile AS F ON B.FreelancerID = F.FreelancerID)
                    INNER JOIN ClientProjects AS P ON B.ProjectID = P.ProjectID
                WHERE 
                    P.EmailID = ?
                ORDER BY 
                    B.BidDate DESC;";

                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("?", _email); // logged-in client email

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            int bidCount = 0;
                            while (reader.Read())
                            {
                                bidCount++;

                                string freelancerName = reader["FreelancerName"] != DBNull.Value
                                    ? reader["FreelancerName"].ToString()
                                    : "Unknown Freelancer";

                                string projectTitle = reader["ProjectTitle"]?.ToString() ?? "Untitled Project";
                                string bidAmount = reader["BidAmount"]?.ToString() ?? "0";
                                string deadline = reader["Deadline"]?.ToString() ?? "No deadline";
                                string bidMessage = reader["BidMessage"]?.ToString() ?? "No message provided";

                                Console.WriteLine($"BidID: {reader["BidID"]}, Project: {projectTitle}, Freelancer: {freelancerName}, Amount: {bidAmount}");

                                AddBidCard(freelancerName, projectTitle, bidAmount, deadline, bidMessage);
                            }

                            if (bidCount == 0)
                            {
                                MessageBox.Show("No bids found for your projects.", "Info",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading bids: " + ex.Message, "Database Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddBidCard(string freelancerName, string projectTitle, string bidAmount, string deadline, string bidMessage)
        {
            // 🔹 Main Card Panel - Increased height for better message display
            Guna2Panel bidPanel = new Guna2Panel
            {
                Size = new Size(flowLayoutPanelProposals.Width - 40, 220), // Increased height for better layout
                BorderRadius = 12,
                BorderThickness = 1,
                BorderColor = Color.LightGray,
                FillColor = Color.White,
                Margin = new Padding(15, 10, 15, 10),
                ShadowDecoration = { Enabled = true, Shadow = new Padding(0, 3, 5, 5) }
            };

            // 🔹 Project Title (Top section - like your screenshot)
            Guna2HtmlLabel lblProjectTitle = new Guna2HtmlLabel
            {
                Text = projectTitle,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(64, 64, 64),
                Location = new Point(15, 15),
                AutoSize = true
            };

            // 🔹 Freelancer Name (Posted by section)
            Guna2HtmlLabel lblPostedBy = new Guna2HtmlLabel
            {
                Text = $"Posted by: {freelancerName}",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = Color.Gray,
                Location = new Point(15, 45),
                AutoSize = true
            };

            // 🔹 Separator line
            Guna2Separator separator = new Guna2Separator
            {
                Location = new Point(15, 70),
                Size = new Size(bidPanel.Width - 30, 1),
                FillColor = Color.LightGray
            };

            // 🔹 Bid Message (Styled like project description from your screenshot)
            Guna2HtmlLabel lblBidMessage = new Guna2HtmlLabel
            {
                Text = bidMessage,
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = Color.FromArgb(64, 64, 64),
                Location = new Point(15, 80),
                AutoSize = false,
                Size = new Size(bidPanel.Width - 30, 50), // Fixed size with word wrap
                IsContextMenuEnabled = false
            };

            // 🔹 Separator line 2
            Guna2Separator separator2 = new Guna2Separator
            {
                Location = new Point(15, 140),
                Size = new Size(bidPanel.Width - 30, 1),
                FillColor = Color.LightGray
            };

            // 🔹 Budget/Bid Amount
            Guna2HtmlLabel lblBid = new Guna2HtmlLabel
            {
                Text = $"Budget: ₹{bidAmount}",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = Color.DimGray,
                Location = new Point(15, 150),
                AutoSize = true
            };

            // 🔹 Deadline
            Guna2HtmlLabel lblDeadline = new Guna2HtmlLabel
            {
                Text = $"Deadline: {deadline}",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = Color.DimGray,
                Location = new Point(15, 170),
                AutoSize = true
            };

            // 🔹 Accept Button
            Guna2Button btnAccept = new Guna2Button
            {
                Text = "Accept",
                Size = new Size(100, 35),
                Location = new Point(bidPanel.Width - 240, 160),
                BorderRadius = 8,
                FillColor = Color.SeaGreen,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Cursor = Cursors.Hand
            };

            // 🔹 Reject Button
            Guna2Button btnReject = new Guna2Button
            {
                Text = "Reject",
                Size = new Size(100, 35),
                Location = new Point(bidPanel.Width - 120, 160),
                BorderRadius = 8,
                FillColor = Color.IndianRed,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Cursor = Cursors.Hand
            };

            // 🔹 Button Events
            btnAccept.Click += (s, e) =>
            {
                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to accept {freelancerName}'s bid for '{projectTitle}'?",
                    "Confirm Acceptance",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int projectId = GetProjectIdByTitle(projectTitle);
                        int freelancerId = GetFreelancerIdByName(freelancerName);
                        decimal amount = decimal.TryParse(bidAmount, out decimal val) ? val : 0;

                        if (projectId == -1 || freelancerId == -1)
                        {
                            MessageBox.Show("Could not resolve project or freelancer ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        bool saved = SaveContract(projectId, freelancerId, projectTitle, amount, "Accepted");

                        if (saved)
                        {
                            MessageBox.Show($"✅ Contract created with {freelancerName} for project '{projectTitle}'", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            flowLayoutPanelProposals.Controls.Remove(bidPanel); // 🔥 Remove the card
                        }
                        else
                        {
                            MessageBox.Show("❌ Failed to create contract.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Unexpected error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            };

            btnReject.Click += (s, e) =>
            {
                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to reject {freelancerName}'s bid for '{projectTitle}'?",
                    "Confirm Rejection",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int projectId = GetProjectIdByTitle(projectTitle);
                        int freelancerId = GetFreelancerIdByName(freelancerName);
                        decimal amount = decimal.TryParse(bidAmount, out decimal val) ? val : 0;

                        if (projectId == -1 || freelancerId == -1)
                        {
                            MessageBox.Show("Could not resolve project or freelancer ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        bool saved = SaveContract(projectId, freelancerId, projectTitle, amount, "Rejected");

                        if (saved)
                        {
                            MessageBox.Show($"❌ You rejected {freelancerName}'s bid for '{projectTitle}'. Status logged.", "Bid Rejected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            flowLayoutPanelProposals.Controls.Remove(bidPanel); // 🔥 Remove the card
                        }
                        else
                        {
                            MessageBox.Show("⚠️ Failed to log rejection. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Unexpected error while rejecting bid: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            };

            // Add controls to Panel
            bidPanel.Controls.Add(lblProjectTitle);
            bidPanel.Controls.Add(lblPostedBy);
            bidPanel.Controls.Add(separator);
            bidPanel.Controls.Add(lblBidMessage);
            bidPanel.Controls.Add(separator2);
            bidPanel.Controls.Add(lblBid);
            bidPanel.Controls.Add(lblDeadline);
            bidPanel.Controls.Add(btnAccept);
            bidPanel.Controls.Add(btnReject);

            // Add Panel to FlowLayout
            flowLayoutPanelProposals.Controls.Add(bidPanel);
        }
        private bool SaveContract(int projectId, int freelancerId, string projectTitle, decimal contractAmount, string status)
        {
            using (OleDbConnection con = new OleDbConnection(conString))
            {
                try
                {
                    con.Open();

                    // 🔹 Step 1: Insert into Contracts
                    string insertQuery = @"INSERT INTO Contracts 
                (ProjectID, FreelancerID, ClientID, ContractAmount, ProjectTitle, ContractDate, Status) 
                VALUES (?, ?, ?, ?, ?, ?, ?)";

                    using (OleDbCommand cmd = new OleDbCommand(insertQuery, con))
                    {
                        cmd.Parameters.Add("?", OleDbType.Integer).Value = projectId;
                        cmd.Parameters.Add("?", OleDbType.Integer).Value = freelancerId;
                        cmd.Parameters.Add("?", OleDbType.Integer).Value = _userId; // ClientID
                        cmd.Parameters.Add("?", OleDbType.Currency).Value = contractAmount;
                        cmd.Parameters.Add("?", OleDbType.VarChar).Value = projectTitle;
                        cmd.Parameters.Add("?", OleDbType.Date).Value = DateTime.Now;
                        cmd.Parameters.Add("?", OleDbType.VarChar).Value = status;

                        int rows = cmd.ExecuteNonQuery();

                        // 🔹 Step 2: Update Biddings table with new status
                        string updateBidStatusQuery = @"UPDATE Biddings SET Status = ? WHERE ProjectID = ? AND FreelancerID = ?";
                        using (OleDbCommand updateCmd = new OleDbCommand(updateBidStatusQuery, con))
                        {
                            updateCmd.Parameters.Add("?", OleDbType.VarChar).Value = status;
                            updateCmd.Parameters.Add("?", OleDbType.Integer).Value = projectId;
                            updateCmd.Parameters.Add("?", OleDbType.Integer).Value = freelancerId;
                            updateCmd.ExecuteNonQuery();
                        }

                        // 🔹 Step 3: Notify freelancer if accepted
                        if (rows > 0 && status == "Accepted")
                        {
                            SendNotification(freelancerId, $"🎉 Your bid for '{projectTitle}' has been accepted!");
                        }

                        else
                        { 
                            SendNotification(freelancerId, $"❌ Your bid for '{projectTitle}' has been rejected!");
                        }

                            return rows > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving contract: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        private void SendNotification(int freelancerId, string message)
        {
            using (OleDbConnection con = new OleDbConnection(conString))
            {
                try
                {
                    con.Open();
                    string query = @"INSERT INTO Notifications ([FreelancerID], [Message], [Timestamp]) VALUES (?, ?, ?)";

                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        cmd.Parameters.Add("?", OleDbType.Integer).Value = freelancerId;
                        cmd.Parameters.Add("?", OleDbType.LongVarChar).Value = message;
                        cmd.Parameters.Add("?", OleDbType.Date).Value = DateTime.Now;

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to send notification: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private int GetProjectIdByTitle(string title)
        {
            using (OleDbConnection con = new OleDbConnection(conString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT ProjectID FROM ClientProjects WHERE ProjectTitle = ?";
                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("?", title);
                        object result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : -1;
                    }
                }
                catch
                {
                    return -1;
                }
            }
        }

        private int GetFreelancerIdByName(string name)
        {
            using (OleDbConnection con = new OleDbConnection(conString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT FreelancerID FROM FreelancerProfile WHERE Name = ?";
                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("?", name);
                        object result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : -1;
                    }
                }
                catch
                {
                    return -1;
                }
            }
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            new ClientDashboard(_userId, _email).Show();
            this.Hide();
        }

        private void flowLayoutPanelProposals_Paint(object sender, PaintEventArgs e)
        {
            // No implementation needed
        }

        private void abcL17_Click(object sender, EventArgs e)
        {
            // No implementation needed
        }

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            LoginRegisterr loginForm = new LoginRegisterr();
            loginForm.Show();
            this.Hide();
        }

        private void BtnProjects_Click(object sender, EventArgs e)
        {
            ClientProjects clientProjects = new ClientProjects(_userId, _email);
            clientProjects.Show();
            this.Hide();
        }

        private void BtnProfile_Click(object sender, EventArgs e)
        {
            ClientProfile clientProfile = new ClientProfile(_userId, _email);
            clientProfile.Show();
            this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Freelancer freelancerForm = new Freelancer(_userId, _email);
            freelancerForm.Show();
            this.Hide();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            ClientCompletedProject clientCompletedProject = new ClientCompletedProject(_email, _userId);
            clientCompletedProject.Show();
            this.Hide();
        }
    }
}