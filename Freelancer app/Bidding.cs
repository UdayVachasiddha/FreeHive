using System;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Globalization;

namespace Freelancer_app
{
    public partial class Bidding : Form
    {
        private int _userId;
        private string _email;
        private string _projectTitle;
        private string _budget;
        private string _deadline;
        private string _clientEmail;
        private string _clientName;
        private int _freelancerId;
        string conString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=SkillHive Database.accdb;Persist Security Info=False;";

        public Bidding(int userId, string email, string projectTitle, string budget, string deadline, string clientEmail, string clientName)
        {
            InitializeComponent();
            _userId = userId;
            _email = email ?? throw new ArgumentNullException(nameof(email), "Email cannot be null");
            _projectTitle = projectTitle ?? throw new ArgumentNullException(nameof(projectTitle), "Project title cannot be null");
            _budget = budget ?? "0";
            _deadline = deadline ?? DateTime.Now.ToString("d");
            _clientEmail = clientEmail ?? throw new ArgumentNullException(nameof(clientEmail), "Client email cannot be null");
            _clientName = clientName ?? "Unknown Client";

            this.Load += Bidding_Load;
        }

        private void Bidding_Load(object sender, EventArgs e)
        {
            // Auto-fill project details
            txtProjectTitle.Text = _projectTitle;

            // Initialize slider and labels
            trkBid.Minimum = 100; // Minimum bid amount
            trkBid.Maximum = 500000; // Max bid limit
            trkBid.Value = 100; // Start at minimum bid
            txtBidValue.Text = "₹100";
            lblMin.Text = "₹100";

            // Fetch freelancer ID
            _freelancerId = GetFreelancerIdFromProfile();
            if (_freelancerId == 0)
            {
                MessageBox.Show("⚠️ No freelancer profile found. Please create a profile before bidding.",
                                "Profile Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnPlaceBid.Enabled = false; // Disable bidding if no profile
            }
        }

        private int GetFreelancerIdFromProfile()
        {
            ;
            using (OleDbConnection con = new OleDbConnection(conString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT FreelancerID FROM FreelancerProfile WHERE EmailID = ? OR UserID = ?";
                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@EmailID", _email ?? "");
                        cmd.Parameters.AddWithValue("@UserID", _userId);
                        object result = cmd.ExecuteScalar();
                        return result != null && result != DBNull.Value ? Convert.ToInt32(result) : 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database error fetching freelancer ID: {ex.Message}", "DB Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
            }
        }

        private void trkBid_Scroll(object sender, ScrollEventArgs e)
        {
            txtBidValue.Text = $"₹{trkBid.Value:N0}"; // Format with commas
            lblMin.Text = $"₹{trkBid.Value:N0}";
        }

        private void txtBidValue_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBidValue.Text))
            {
                txtBidValue.Text = $"₹{trkBid.Value:N0}";
                return;
            }

            // Remove currency symbol and any non-numeric characters except digits
            string value = txtBidValue.Text.Replace("₹", "").Replace(",", "").Trim();

            if (int.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out int bidValue))
            {
                if (bidValue >= trkBid.Minimum && bidValue <= trkBid.Maximum)
                {
                    trkBid.Value = bidValue;
                    lblMin.Text = $"₹{bidValue:N0}";
                }
                else
                {
                    MessageBox.Show($"Please enter a value between ₹{trkBid.Minimum:N0} and ₹{trkBid.Maximum:N0}.",
                                    "Invalid Bid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBidValue.Text = $"₹{trkBid.Value:N0}";
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid numeric value.", "Invalid Input",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBidValue.Text = $"₹{trkBid.Value:N0}";
            }
        }

        private void btnPlaceBid_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Validate inputs
                if (string.IsNullOrWhiteSpace(txtProjectTitle.Text))
                {
                    MessageBox.Show("Please enter the project title.", "Missing Info",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (trkBid.Value < 100)
                {
                    MessageBox.Show("Bid amount must be at least ₹100.", "Invalid Bid",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtProject.Text))
                {
                    MessageBox.Show("Please enter a message or proposal.", "Missing Info",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_freelancerId == 0)
                {
                    MessageBox.Show("Cannot place bid without a valid freelancer profile.",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Get project ID
                int projectId = GetProjectIdByTitle(txtProjectTitle.Text);
                if (projectId == -1)
                {
                    MessageBox.Show("Project not found. Please check the title.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Save the bid
                if (SaveBid(projectId, _freelancerId))
                {
                    MessageBox.Show(
                        $"✅ Bid placed successfully!\n\n" +
                        $"Project: {txtProjectTitle.Text}\n" +
                        $"Amount: ₹{trkBid.Value:N0}\n" +
                        $"Message: {txtProject.Text}\n" +
                        $"Time: {DateTime.Now.ToString("hh:mm tt")} IST, {DateTime.Now.ToString("MMMM dd, yyyy")}",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information
                    );
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("❌ Failed to place bid. Please try again.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while placing your bid.\nDetails: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        cmd.Parameters.AddWithValue("@ProjectTitle", title.Trim());
                        object result = cmd.ExecuteScalar();
                        return result != null && result != DBNull.Value ? Convert.ToInt32(result) : -1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database error while getting project ID: {ex.Message}", "DB Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
        }

        private bool SaveBid(int projectId, int freelancerId)
        {
            
            using (OleDbConnection con = new OleDbConnection(conString))
            {
                try
                {
                    con.Open();

                    // Check if table exists and has correct structure
                    string query = @"INSERT INTO Biddings 
                        (ProjectID, ProjectTitle, FreelancerID, BidAmount, BidMessage, BidDate) 
                        VALUES (?, ?, ?, ?, ?, ?)";

                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        // Use proper parameter names and ensure data types match database schema
                        cmd.Parameters.Add("@ProjectID", OleDbType.Integer).Value = projectId;
                        cmd.Parameters.Add("@ProjectTitle", OleDbType.VarChar).Value = txtProjectTitle.Text.Trim();
                        cmd.Parameters.Add("@FreelancerID", OleDbType.Integer).Value = freelancerId;

                        // Use decimal for currency and ensure it matches the database column type
                        decimal bidAmount = Convert.ToDecimal(trkBid.Value);
                        cmd.Parameters.Add("@BidAmount", OleDbType.Decimal).Value = bidAmount;

                        cmd.Parameters.Add("@BidMessage", OleDbType.VarChar).Value = txtProject.Text.Trim();
                        cmd.Parameters.Add("@BidDate", OleDbType.Date).Value = DateTime.Now;

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error submitting bid: {ex.Message}", "DB Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        private void ClearFields()
        {
            try
            {
                txtBidValue.Text = "₹100";
                txtProject.Clear();
                trkBid.Value = 100;
                lblMin.Text = "₹100";
                // Don't clear project title as it's passed from constructor
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not clear fields: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        // Navigation methods
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

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            LoginRegisterr loginForm = new LoginRegisterr();
            loginForm.Show();
            this.Hide();
        }

        private void BtnMessages_Click(object sender, EventArgs e)
        {
            Message messagesForm = new Message(_userId, _email);
            messagesForm.Show();
            this.Hide();
        }

        private void panelContent_Paint(object sender, PaintEventArgs e) { }
        private void txtProject_TextChanged(object sender, EventArgs e) { }
        private void txtProjectTitle_TextChanged(object sender, EventArgs e) { }

        private void label1_Click(object sender, EventArgs e) { }

        private void lblMin_Click(object sender, EventArgs e)
        {

        }

        private void BtnBidding_Click(object sender, EventArgs e)
        {
            BiddingStatus bs = new BiddingStatus(_userId, _email);
            bs.Show();
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