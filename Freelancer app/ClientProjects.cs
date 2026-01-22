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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Freelancer_app
{
    public partial class ClientProjects : Form
    {
        private int _userId;
        private string _email;
        string conString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=SkillHive Database.accdb;Persist Security Info=False;";

        public ClientProjects(int userId, string email)
        {
            InitializeComponent();
            _userId = userId;
            _email = email;
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            string title = txtProjectTitle.Text.Trim();
            string description = txtDescription.Text.Trim();
            string budgetText = txtBudget.Text.Trim();
            DateTime deadline = dateDeadline.Value;

            // ✅ Validation
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description) || string.IsNullOrEmpty(budgetText))
            {
                MessageBox.Show("All fields are required!", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(budgetText, out decimal budget) || budget <= 0)
            {
                MessageBox.Show("Budget must be a positive number!", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (deadline <= DateTime.Now)
            {
                MessageBox.Show("Deadline must be a future date!", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (OleDbConnection conn = new OleDbConnection(conString))
                {
                    conn.Open();

                    string query = @"INSERT INTO ClientProjects 
                                     (UserID, EmailID, ProjectTitle, Description, Budget, Deadline) 
                                     VALUES (@UserID, @Email, @ProjectTitle, @Description, @Budget, @Deadline)";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", _userId);
                        cmd.Parameters.AddWithValue("@Email", _email);
                        cmd.Parameters.AddWithValue("@ProjectTitle", title);
                        cmd.Parameters.AddWithValue("@Description", description);
                        cmd.Parameters.AddWithValue("@Budget", budget);
                        cmd.Parameters.AddWithValue("@Deadline", deadline);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Project posted successfully!", "Success",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Clear fields
                            txtProjectTitle.Clear();
                            txtDescription.Clear();
                            txtBudget.Clear();
                            dateDeadline.Value = DateTime.Now.AddDays(1); // reset deadline
                        }
                        else
                        {
                            MessageBox.Show("Failed to post project. Please try again.", "Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while posting project:\n" + ex.Message,
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClientProjects_Load(object sender, EventArgs e)
        {

        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            ClientDashboard clientDashboard = new ClientDashboard(_userId, _email);
            clientDashboard.Show();
            this.Hide();
        }

        private void txtProjectTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            ClientCompletedProject clientCompletedProject = new ClientCompletedProject(_email, _userId);
            clientCompletedProject.Show();
            this.Hide();
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

        private void BtnProjects_Click(object sender, EventArgs e)
        {
            ClientProjects clientProjects = new ClientProjects(_userId, _email);
            clientProjects.Show();
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
