using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Freelancer_app
{
    public partial class ProjectSubmit : Form
    {
        private int _userId;
        private string _email;
        private string _selectedFilePath = "";
        private int _freelancerId;
        string conString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=SkillHive Database.accdb;Persist Security Info=False;";


        public ProjectSubmit(int userId, string email)
        {
            InitializeComponent();
            _email = email;
            _userId = userId; 
        }

        private void ProjectSubmit_Load(object sender, EventArgs e)
        {
            AssignFreelancerId();  // ✅ Make sure FreelancerID is linked
            LoadAcceptedProjects();
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
                        {
                            _freelancerId = Convert.ToInt32(result);
                        }
                        else
                        {
                            MessageBox.Show("No freelancer profile found. Please complete your profile first.",
                                "Profile Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching FreelancerID: " + ex.Message,
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadAcceptedProjects()
        {
            comboBoxAcceptedProjects.Items.Clear();

            using (OleDbConnection con = new OleDbConnection(conString))
            {
                con.Open();
                string query = @"
                    SELECT ClientProjects.ProjectID, ClientProjects.ProjectTitle
                    FROM ClientProjects
                    INNER JOIN Biddings ON ClientProjects.ProjectID = Biddings.ProjectID
                    WHERE Biddings.FreelancerID = ? AND Biddings.Status = 'Accepted'";

                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("?", _freelancerId);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBoxAcceptedProjects.Items.Add(new ComboBoxItem
                            {
                                Text = reader["ProjectTitle"].ToString(),
                                Value = reader["ProjectID"].ToString()
                            });
                        }
                    }
                }
            }
        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnUploadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select your project file";
            dialog.Filter = "Supported Files|*.pdf;*.png;*.jpeg;*.jpg;*.csv";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFile = dialog.FileName;

                if (ValidateFile(selectedFile))
                {
                    _selectedFilePath = selectedFile; // ✅ This is critical

                    btnUploadFile.Visible = false;
                    lblUploadInstruction.Visible = false;
                    pictureBoxUploadIcon.Visible = true;

                    panelUploadZone.Visible = true;
                    lblFileNameInsidePanel.Text = $"📁 {Path.GetFileName(selectedFile)}";

                    ShowToast("✅ File selected successfully.");
                }
                else
                {
                    MessageBox.Show("Invalid file type or size. Max allowed: 10 GB", "Upload Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }
        private bool ValidateFile(string path)
        {
            string ext = Path.GetExtension(path).ToLower();
            long size = new FileInfo(path).Length;

            string[] allowed = { ".pdf", ".png", ".jpeg", ".jpg", ".csv" };
            return allowed.Contains(ext) && size <= 10L * 1024 * 1024 * 1024; // 10 GB
        }
        private void ShowToast(string message)
        {
            MessageBox.Show(message, "Upload", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Or use Guna UI toast if available
        }

        private void panelUploadZone_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxAcceptedProjects?.SelectedItem == null ||
                    !(comboBoxAcceptedProjects.SelectedItem is ComboBoxItem selectedItem))
                {
                    MessageBox.Show("Please select a valid project.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string title = txtProjectTitle.Text.Trim();
                string description = txtDescription.Text.Trim();

                if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description))
                {
                    MessageBox.Show("Please enter both title and description.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(_selectedFilePath) || !File.Exists(_selectedFilePath))
                {
                    MessageBox.Show("Please select a valid file before submitting.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SubmitProjectFormData(selectedItem.Value, title, description, _selectedFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while submitting the project.\n\nDetails: " + ex.Message, "Submission Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SubmitProjectFormData(string projectId, string title, string description, string filePath)
        {
            try
            {
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    con.Open();

                    string query = "INSERT INTO SubmittedProjects ([ProjectID], [FreelancerID], [Title], [Description], [FileName], [Timestamp]) VALUES (?, ?, ?, ?, ?, ?)";
                    using (OleDbCommand cmd = new OleDbCommand(query, con))
                    {
                        cmd.Parameters.Add("ProjectID", OleDbType.Integer).Value = Convert.ToInt32(projectId);
                        cmd.Parameters.Add("FreelancerID", OleDbType.Integer).Value = Convert.ToInt32(_freelancerId);
                        cmd.Parameters.Add("Title", OleDbType.VarChar).Value = title;
                        cmd.Parameters.Add("Description", OleDbType.LongVarChar).Value = description;
                        cmd.Parameters.Add("FileName", OleDbType.VarChar).Value = Path.GetFileName(filePath);
                        cmd.Parameters.Add("Timestamp", OleDbType.Date).Value = DateTime.Now;

                        cmd.ExecuteNonQuery();
                    }
                }

                ShowToast("✅ Project submitted successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to store project data.\n\nDetails: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Helper class for ComboBox items
        private class ComboBoxItem
        {
            public string Text { get; set; }
            public string Value { get; set; }
            public override string ToString() => Text;
        }

        private void comboBoxAcceptedProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAcceptedProjects.SelectedItem is ComboBoxItem selectedItem)
            {
                txtProjectTitle.Text = selectedItem.Text;
            }

        }

        private void BtnProfile_Click(object sender, EventArgs e)
        {
            FreelancerProfile profileForm = new FreelancerProfile(_userId, _email);
            profileForm.Show();
            this.Hide();
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            Dashboard dashboardForm = new Dashboard(_userId, _email);
            dashboardForm.Show();
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

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            LoginRegisterr loginForm = new LoginRegisterr();
            loginForm.Show();
            this.Hide();
        }
    }
}
