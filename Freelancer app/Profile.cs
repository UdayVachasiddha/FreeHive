using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Freelancer_app
{
    public partial class Profile : Form
    {
        private int _userId;
        private string _email;
        string conString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=SkillHive Database.accdb;Persist Security Info=False;";


        private bool isFreelancer = false;
        private bool isClient = false;

        public Profile(int userId, string email)
        {
            InitializeComponent();
            _userId = userId;
            _email = email;

            CheckUserRoles();
        }

        public Profile(string email, int userId)  // For new users (no UserID yet)
        {
            InitializeComponent();
            _userId = userId;
            _email = email;

            CheckUserRoles();
        }

        private void Profile_Load(object sender, EventArgs e)
        {

        }

        private void CheckUserRoles()
        {
            using (OleDbConnection conn = new OleDbConnection(conString))
            {
                conn.Open();

                // ✅ Check FreelancerProfile
                OleDbCommand freelancerCmd = new OleDbCommand("SELECT COUNT(*) FROM FreelancerProfile WHERE EmailID = ?", conn);
                freelancerCmd.Parameters.AddWithValue("?", _email);
                int freelancerExists = (int)freelancerCmd.ExecuteScalar();
                if (freelancerExists > 0) isFreelancer = true;

                // ✅ Check ClientProfile
                OleDbCommand clientCmd = new OleDbCommand("SELECT COUNT(*) FROM ClientProfile WHERE EmailID = ?", conn);
                clientCmd.Parameters.AddWithValue("?", _email);
                int clientExists = (int)clientCmd.ExecuteScalar();
                if (clientExists > 0) isClient = true;
            }
        }

        // Freelancer button
        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            if (isFreelancer)
            {
                // ✅ Open Freelancer Dashboard
                Dashboard freelancerDashboard = new Dashboard(_userId, _email);
                freelancerDashboard.Show();
                this.Hide();
            }
            else
            {
                // ✅ Redirect to EditFreelancerProfile (new freelancer user)
                EditFreelancerProfile editFreelancerProfile = new EditFreelancerProfile(_userId, _email);
                editFreelancerProfile.Show();
                this.Hide();
            }
        }

        // Client button
        private void btnClient_Click(object sender, EventArgs e)
        {
            if (isClient)
            {
                // ✅ Open Client Dashboard
                ClientDashboard clientDashboard = new ClientDashboard(_userId, _email);
                clientDashboard.Show();
                this.Hide();
            }
            else
            {
                // ✅ Redirect to EditClientProfile (new client user)
                EditClientProfile editClientProfile = new EditClientProfile(_userId, _email, "");
                editClientProfile.Show();
                this.Hide();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
