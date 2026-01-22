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

namespace Freelancer_app
{
    public partial class Freelancer : Form
    {
        private int _userId;
        private string _email;
        string conString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=SkillHive Database.accdb;Persist Security Info=False;";


        public Freelancer(int userId, string email)
        {
            InitializeComponent();
            _userId = userId;
            _email = email;

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Freelancer_Load(object sender, EventArgs e)
        {
            LoadFreelancers();
        }

        private void LoadFreelancers()
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(conString))
                {
                    conn.Open();
                    string query = "SELECT FreelancerId, Name, Tagline FROM FreelancerProfile";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    OleDbDataReader reader = cmd.ExecuteReader();

                    flowLayoutPanelFreelancers.Controls.Clear();

                    while (reader.Read())
                    {
                        int freelancerId = Convert.ToInt32(reader["FreelancerId"]);
                        string name = reader["Name"].ToString();
                        string tagline = reader["Tagline"].ToString();

                        // create card (Guna2Panel instead of normal panel)
                        var card = new Guna.UI2.WinForms.Guna2Panel();
                        card.Width = flowLayoutPanelFreelancers.Width - 35; // fit nicely
                        card.Height = 100;
                        card.BorderRadius = 12;  // rounded corners
                        card.FillColor = Color.White;
                        card.ShadowDecoration.Enabled = true;
                        card.ShadowDecoration.Depth = 5;
                        card.Margin = new Padding(10, 10, 10, 0);

                        // name label
                        Label lblName = new Label();
                        lblName.Text = name;
                        lblName.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                        lblName.Location = new Point(20, 20);
                        lblName.AutoSize = true;

                        // tagline label
                        Label lblTagline = new Label();
                        lblTagline.Text = "Tagline: " + tagline;
                        lblTagline.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                        lblTagline.Location = new Point(20, 55);
                        lblTagline.AutoSize = true;

                        // view profile button (Guna2Button)
                        var btnProfile = new Guna.UI2.WinForms.Guna2Button();
                        btnProfile.Text = "View Profile";
                        btnProfile.BorderRadius = 8;
                        btnProfile.FillColor = Color.RoyalBlue;
                        btnProfile.ForeColor = Color.White;
                        btnProfile.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                        btnProfile.Size = new Size(110, 35);
                        btnProfile.Location = new Point(card.Width - 140, 30);
                        btnProfile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                        btnProfile.Cursor = Cursors.Hand;

                        btnProfile.Click += (s, e) =>
                        {
                            //MessageBox.Show($"Opening profile of {name}");
                            ViewProfile vp = new ViewProfile(freelancerId);
                            vp.ShowDialog();
                        };

                        // add to card
                        card.Controls.Add(lblName);
                        card.Controls.Add(lblTagline);
                        card.Controls.Add(btnProfile);

                        // add card to flow panel
                        flowLayoutPanelFreelancers.Controls.Add(card);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading freelancers: " + ex.Message);
            }
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

        private void BtnMessages_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            ClientCompletedProject clientCompletedProject = new ClientCompletedProject(_email, _userId);
            clientCompletedProject.Show();
            this.Hide();
        }

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            LoginRegisterr loginForm = new LoginRegisterr();
            loginForm.Show();
            this.Hide();
        }

        private void BtnProfile_Click(object sender, EventArgs e)
        {
            ClientProfile clientProfile = new ClientProfile(_userId, _email);
            clientProfile.Show();
            this.Hide();
        }
    }
}
