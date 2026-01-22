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

namespace Freelancer_app
{
    public partial class ClientDashboard : Form
    {
        private int _userId;
        private string _email;
        private int _clientId; // Add this line to store ClientID
        string conString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=SkillHive Database.accdb;Persist Security Info=False;";

        public ClientDashboard(int userId, string email)
        {
            InitializeComponent();
            _userId = userId;
            _email = email;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnProfile_Click(object sender, EventArgs e)
        {
            ClientProfile clientProfile = new ClientProfile(_userId, _email);
            clientProfile.Show();
            this.Hide();
        }

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            LoginRegisterr loginForm = new LoginRegisterr();
            loginForm.Show();
            this.Hide();
        }

        private void txtAboutUs_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnProjects_Click(object sender, EventArgs e)
        {
            ClientProjects clientProjects = new ClientProjects(_userId, _email);
            clientProjects.Show();
            this.Hide();
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Freelancer freelancerForm = new Freelancer(_userId, _email);
            freelancerForm.Show();
            this.Hide();
        }

        private void BtnBidding_Click(object sender, EventArgs e)
        {
            ClientBiddings clientBiddings = new ClientBiddings(_email, _userId);
            clientBiddings.Show();
            this.Hide();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            ClientCompletedProject clientCompletedProject = new ClientCompletedProject(_email, _userId);
            clientCompletedProject.Show();
            this.Hide();
        }

        private void ClientDashboard_Load(object sender, EventArgs e)
        {
            LoadClientDashboardStats();
            LoadClientProjects();
        }

        private void LoadClientProjects()
        {
            flowLayoutPanelProjects.Controls.Clear();

            using (OleDbConnection con = new OleDbConnection(conString))
            {
                try
                {
                    con.Open();

                    string query = @"
                SELECT 
                    CP.ProjectID,
                    CP.ProjectTitle,
                    CP.Description,
                    CP.Budget,
                    CP.Deadline,
                    IIF(SP.Reviewed IS NULL, False, SP.Reviewed) AS Reviewed
                FROM 
                    ClientProjects AS CP
                LEFT JOIN 
                    SubmittedProjects AS SP
                ON 
                    CP.ProjectID = SP.ProjectID
                WHERE 
                    CP.EmailID = ?
                ORDER BY 
                    CP.Deadline ASC";

                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("?", _email.Trim());

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            int projectCount = 0;
                            while (reader.Read())
                            {
                                bool reviewed = false;
                                if (reader["Reviewed"] != DBNull.Value)
                                    reviewed = Convert.ToBoolean(reader["Reviewed"]);

                                // ✅ Skip project if it's completed (reviewed = true)
                                if (reviewed)
                                    continue;

                                projectCount++;

                                int projectId = Convert.ToInt32(reader["ProjectID"]);
                                string title = reader["ProjectTitle"]?.ToString() ?? "Untitled Project";
                                string description = reader["Description"]?.ToString() ?? "";
                                decimal budget = reader["Budget"] != DBNull.Value ? Convert.ToDecimal(reader["Budget"]) : 0m;
                                string deadline = reader["Deadline"] != DBNull.Value
                                    ? Convert.ToDateTime(reader["Deadline"]).ToString("dd MMM yyyy")
                                    : "No deadline";

                                AddProjectCard(projectId, title, description, budget, deadline, reviewed);
                            }

                            if (projectCount == 0)
                                ShowNoProjectsMessage();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading projects: " + ex.Message, "Database Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ShowNoProjectsMessage();
                }
            }
        }


        private void ShowNoProjectsMessage()
        {
            var lbl = new Guna2HtmlLabel
            {
                Text = "You haven't posted any projects yet.",
                Font = new Font("Segoe UI", 12, FontStyle.Italic),
                ForeColor = Color.Gray,
                AutoSize = true,
                Margin = new Padding(20)
            };
            flowLayoutPanelProjects.Controls.Add(lbl);
        }

        // This method creates a single project card and adds it to the flowLayoutPanelProjects
        private void AddProjectCard(int projectId, string title, string description, decimal budget, string deadline, bool reviewed)
        {
            // compute width so 3 cards fit across (accounting for margins). falls back to 320 min width.
            int margin = 12; // same margin used for each card
            int cardsPerRow = 3;
            int availableWidth = Math.Max(0, flowLayoutPanelProjects.ClientSize.Width - ((cardsPerRow + 1) * margin));
            int cardWidth = Math.Max(320, availableWidth / cardsPerRow);
            int cardHeight = 260;

            // Parent card
            var card = new Guna2Panel
            {
                Size = new Size(cardWidth, cardHeight),
                BorderRadius = 10,
                BorderThickness = 1,
                BorderColor = Color.FromArgb(220, 220, 220),
                FillColor = reviewed ? Color.FromArgb(245, 250, 245) : Color.FromArgb(250, 250, 250), // slight green tint if reviewed
                Margin = new Padding(margin),
                Padding = new Padding(16)
            };

            // Title
            var lblTitle = new Guna2HtmlLabel
            {
                Text = title,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 30, 30),
                Location = new Point(12, 8),
                AutoSize = true
            };

            // Completed Badge (top-right) — only visible when reviewed==true
            var badge = new Guna2HtmlLabel
            {
                Text = "Completed",
                BackColor = Color.FromArgb(56, 142, 60),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                AutoSize = true,
                Padding = new Padding(8, 4, 8, 4),
                Location = new Point(cardWidth - 130, 10),
                Visible = reviewed,
            };

            // Description box (read-only textbox for scrollable description)
            var txtDesc = new TextBox
            {
                Text = description,
                Multiline = true,
                ReadOnly = true,
                BorderStyle = BorderStyle.None,
                BackColor = card.FillColor,
                Location = new Point(12, 44),
                Size = new Size(cardWidth - 36, 100),
                ScrollBars = ScrollBars.Vertical
            };

            // Budget label
            var lblBudget = new Guna2HtmlLabel
            {
                Text = $"Price: ₹{budget:N0}",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = Color.DarkSlateGray,
                Location = new Point(12, 150),
                AutoSize = true
            };

            // Deadline label
            var lblDeadline = new Guna2HtmlLabel
            {
                Text = $"Deadline: {deadline}",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = Color.DarkSlateGray,
                Location = new Point(12, 176),
                AutoSize = true
            };

            // Right-side buttons container
            var panelButtons = new Panel
            {
                Size = new Size(120, 70),
                Location = new Point(cardWidth - 140, 150),
                BackColor = Color.Transparent
            };

            // If reviewed -> show disabled "Completed" button; else show View Bids / Edit
            if (reviewed)
            {
                var btnCompleted = new Guna2Button
                {
                    Text = "Completed",
                    Size = new Size(110, 36),
                    BorderRadius = 8,
                    FillColor = Color.FromArgb(120, 200, 120),
                    ForeColor = Color.White,
                    Location = new Point(0, 17),
                    Enabled = false
                };
                panelButtons.Controls.Add(btnCompleted);
            }
            else
            {
                // "View Bids" button
                var btnViewBids = new Guna2Button
                {
                    Text = "View Bids",
                    Size = new Size(110, 36),
                    BorderRadius = 8,
                    FillColor = Color.FromArgb(0, 120, 215),
                    ForeColor = Color.White,
                    Location = new Point(0, 0),
                    Tag = projectId,
                    Cursor = Cursors.Hand
                };
                btnViewBids.Click += (s, e) =>
                {
                    int pid = (int)((Guna2Button)s).Tag;
                    // Open the ClientBiddings for this project's client (it will load all bids for client's projects)
                    var clientBids = new ClientBiddings(_email, _userId);
                    clientBids.Show();
                    this.Hide();
                    // Optionally you can open clientBids with the project preselected — implement if needed.
                };

                // "Edit" button (open EditProject form if you have one)
                var btnEdit = new Guna2Button
                {
                    Text = "Edit",
                    Size = new Size(110, 36),
                    BorderRadius = 8,
                    FillColor = Color.FromArgb(98, 169, 255),
                    ForeColor = Color.White,
                    Location = new Point(0, 36),
                    Tag = projectId,
                    Cursor = Cursors.Hand
                };
                btnEdit.Click += (s, e) =>
                {
                    int pid = (int)((Guna2Button)s).Tag;
                    MessageBox.Show("Edit feature not implemented yet (projectId: " + pid + ")", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };

                panelButtons.Controls.Add(btnViewBids);
                panelButtons.Controls.Add(btnEdit);
            }

            // Add controls to card
            card.Controls.Add(lblTitle);
            card.Controls.Add(badge);
            card.Controls.Add(txtDesc);
            card.Controls.Add(lblBudget);
            card.Controls.Add(lblDeadline);
            card.Controls.Add(panelButtons);

            // Recompute sizes so layout looks nice (avoid cutting off text)
            txtDesc.Width = card.Width - 36;
            panelButtons.Location = new Point(card.Width - panelButtons.Width - 16, 150);

            flowLayoutPanelProjects.Controls.Add(card);
        }

        private void LoadClientDashboardStats()
        {
            AssignClientId();
            LoadActiveProjects();
            LoadCompletedProjects();
            LoadSpendings();
        }

        private void LoadActiveProjects()
        {
            int activeProjects = 0;
            using (OleDbConnection con = new OleDbConnection(conString))
            {
                con.Open();

                string query = @"
                SELECT COUNT(*) 
                FROM ClientProjects CP
                WHERE CP.EmailID = ? 
                AND CP.ProjectID NOT IN (
                    SELECT ProjectID FROM SubmittedProjects WHERE Reviewed = True
                )";

                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("?", _email);
                    activeProjects = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            lblActiveProjects.Text = activeProjects.ToString();
        }

        private void LoadCompletedProjects()
        {
            int completedProjects = 0;
            using (OleDbConnection con = new OleDbConnection(conString))
            {
                con.Open();
                string query = @"SELECT COUNT(*) 
                         FROM SubmittedProjects SP
                         INNER JOIN ClientProjects CP ON SP.ProjectID = CP.ProjectID
                         WHERE CP.EmailID = ? AND SP.Reviewed = True";

                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("?", _email);
                    completedProjects = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            lblCompletedProjects.Text = completedProjects.ToString();
        }

        private void AssignClientId()
        {
            using (OleDbConnection con = new OleDbConnection(conString))
            {
                con.Open();
                string query = "SELECT ClientID FROM ClientProfile WHERE EmailID = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("?", _email.Trim());
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                        _clientId = Convert.ToInt32(result);
                }
            }
        }

        private void LoadSpendings()
        {
            decimal spendings = 0;
            using (OleDbConnection con = new OleDbConnection(conString))
            {
                con.Open();

                string query = @"
                SELECT SUM(CT.ContractAmount)
                FROM (ClientProjects CP
                INNER JOIN SubmittedProjects SP ON CP.ProjectID = SP.ProjectID)
                INNER JOIN Contracts CT ON CP.ProjectID = CT.ProjectID
                WHERE CP.EmailID = ? AND SP.Reviewed = True";

                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("?", _email.Trim());
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                        spendings = Convert.ToDecimal(result);
                }
            }

            lblSpendings.Text = $"₹{spendings:N0}";
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
