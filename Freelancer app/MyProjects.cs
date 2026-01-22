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
    public partial class MyProjects : Form
    {
        private int _userId;
        private string _email;
        string conString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=SkillHive Database.accdb;Persist Security Info=False;";


        public MyProjects(int userId, string email)
        {
            InitializeComponent();
            _userId = userId;
            _email = email ?? throw new ArgumentNullException(nameof(email), "Email cannot be null");

            this.Load += MyProjects_Load;
        }

        private void MyProjects_Load(object sender, EventArgs e)
        {
            LoadAvailableProjects();
        }

        // 🔹 Load ALL Available Projects (JOIN with ClientProfile for Name)
        private void LoadAvailableProjects()
        {
            flowLayoutPanel1.Controls.Clear();

            using (OleDbConnection con = new OleDbConnection(conString))
            {
                try
                {
                    con.Open();

                    string query = @"SELECT P.ProjectTitle, P.Description, P.Budget, P.Deadline, 
                                            P.EmailID, C.Name AS ClientName
                                     FROM ClientProjects P
                                     LEFT JOIN ClientProfile C ON P.EmailID = C.EmailID
                                     WHERE P.Status = 'Pending'
                                     ORDER BY P.Deadline ASC";

                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        int projectCount = 0;

                        while (reader.Read())
                        {
                            projectCount++;

                            string title = reader["ProjectTitle"]?.ToString() ?? "Untitled Project";
                            string description = reader["Description"]?.ToString() ?? "No description available";
                            string budget = reader["Budget"]?.ToString() ?? "0";
                            string deadline = reader["Deadline"]?.ToString() ?? "No deadline";
                            string clientEmail = reader["EmailID"]?.ToString() ?? "Unknown Client";
                            string clientName = reader["ClientName"]?.ToString() ?? "";

                            AddProjectCard(title, description, budget, deadline, clientEmail, clientName);
                        }

                        if (projectCount == 0)
                            ShowNoProjectsMessage();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading projects: {ex.Message}",
                                    "Database Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                    ShowNoProjectsMessage();
                }
            }
        }

        private void ShowNoProjectsMessage()
        {
            Guna2Panel noProjectsPanel = new Guna2Panel
            {
                Size = new Size(flowLayoutPanel1.Width - 40, 150),
                BorderRadius = 12,
                BorderColor = Color.LightGray,
                BorderThickness = 1,
                FillColor = Color.FromArgb(248, 249, 250),
                Margin = new Padding(20),
                Padding = new Padding(30)
            };

            Guna2HtmlLabel lblMessage = new Guna2HtmlLabel
            {
                Text = "📋 No projects available right now.\nCheck back later!",
                Font = new Font("Segoe UI", 12, FontStyle.Italic),
                ForeColor = Color.Gray,
                Location = new Point(20, 40),
                AutoSize = true
            };

            noProjectsPanel.Controls.Add(lblMessage);
            flowLayoutPanel1.Controls.Add(noProjectsPanel);
        }

        // 🔹 Add one project card
        private void AddProjectCard(string title, string description, string budget, string deadline, string clientEmail, string clientName)
        {
            Guna2Panel projectPanel = new Guna2Panel
            {
                Size = new Size(flowLayoutPanel1.Width - 60, 220), // a bit smaller width
                BorderRadius = 12,
                BorderColor = Color.LightGray,
                BorderThickness = 1,
                Margin = new Padding(10, 5, 0, 10),  // left align: small left margin, no right margin
                Padding = new Padding(15),
                FillColor = Color.White,
                ShadowDecoration = { Enabled = true, Shadow = new Padding(0, 3, 5, 5) }
            };

            // Title
            Guna2HtmlLabel lblTitle = new Guna2HtmlLabel
            {
                Text = title,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(10, 5),
                AutoSize = true
            };

            // Client name or email
            Guna2HtmlLabel lblClient = new Guna2HtmlLabel
            {
                Text = $"Posted by: {(string.IsNullOrWhiteSpace(clientName) ? clientEmail : clientName)}",
                Font = new Font("Segoe UI", 9, FontStyle.Italic),
                ForeColor = Color.DimGray,
                Location = new Point(10, 30),
                AutoSize = true
            };

            // Description box
            TextBox txtDescription = new TextBox
            {
                Text = description,
                Multiline = true,
                ReadOnly = true,
                BorderStyle = BorderStyle.None,
                BackColor = Color.WhiteSmoke,
                Location = new Point(10, 55),
                Size = new Size(projectPanel.Width - 160, 60),
                ScrollBars = ScrollBars.Vertical
            };

            // Budget
            Guna2HtmlLabel lblBudget = new Guna2HtmlLabel
            {
                Text = $"Budget: ₹{budget}",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(10, 125),
                AutoSize = true
            };

            // Deadline
            Guna2HtmlLabel lblDeadline = new Guna2HtmlLabel
            {
                Text = $"Deadline: {deadline}",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Black,
                Location = new Point(10, 150),
                AutoSize = true
            };

            // Bid button (aligned right)
            Guna2Button btnBid = new Guna2Button
            {
                Text = "Bid Now",
                Size = new Size(100, 35),
                Location = new Point(projectPanel.Width - 130, 140),
                BorderRadius = 8,
                FillColor = Color.FromArgb(0, 120, 215),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Cursor = Cursors.Hand
            };

            btnBid.Click += (s, e) =>
            {
                // Navigate directly to Bidding form
                Bidding biddingForm = new Bidding(_userId, _email, title, budget, deadline, clientEmail, clientName);
                biddingForm.Show();
                this.Hide();
            };

            projectPanel.Controls.AddRange(new Control[]
            { lblTitle, lblClient, txtDescription, lblBudget, lblDeadline, btnBid });

            flowLayoutPanel1.Controls.Add(projectPanel);
        }

        // Navigation
        private void BtnHome_Click(object sender, EventArgs e)
        {
            Dashboard d = new Dashboard(_userId, _email);
            d.Show(); 
            this.Hide();
        }
        private void BtnBidding_Click(object sender, EventArgs e)
        {
            BiddingStatus bs = new BiddingStatus(_userId, _email);
            bs.Show(); 
            this.Hide();

        }
        private void BtnMessages_Click(object sender, EventArgs e)
        {
            Message m = new Message(_userId, _email);
            m.Show(); 
            this.Hide();
        }
        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            LoginRegisterr l = new LoginRegisterr();
            l.Show(); 
            this.Hide();
        }

        // Empty event handlers
        private void lblTitle_Click(object sender, EventArgs e) { }
        private void guna2VScrollBar1_Scroll(object sender, ScrollEventArgs e) { }
        private void panelContent_Paint(object sender, PaintEventArgs e) { }
        private void guna2Panel1_Paint(object sender, PaintEventArgs e) { }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void BtnProjects_Click(object sender, EventArgs e) { }

        private void panelTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            ProjectSubmit projectSubmitForm = new ProjectSubmit(_userId, _email);
            projectSubmitForm.Show();
            this.Hide();
        }
    }
}
