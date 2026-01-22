using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Freelancer_app
{
    public partial class ClientProfile : Form
    {
        private readonly int _userId;
        private readonly string _email;
        string conString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=SkillHive Database.accdb;Persist Security Info=False;";

        public ClientProfile(int userId, string email)
        {
            InitializeComponent();
            _userId = userId;
            _email = email;

            this.Load += ClientProfile_Load;
            
            linkLabelBusiness.LinkClicked += linkLabelBusiness_LinkClicked;
        }

        private void ClientProfile_Load(object sender, EventArgs e)
        {
            txtEmail1.Text = _email;   // show login email
            txtEmail1.ReadOnly = true; // keep it read-only
            LoadClientProfile();
        }

        private void LoadClientProfile()
        {
            try
            {
                using (OleDbConnection con = new OleDbConnection(conString))
                using (OleDbCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = @"SELECT [Name], [ContactNo], [EmailID], [AboutUs], 
                                       [CompanyName], [Location], 
                                       [ProfilePicture], [CompanyType], [IndustryDomain],
                                       [PreferredCategories], [PreferredLanguages], [BusinessWebsite]
                                FROM ClientProfile
                                WHERE [EmailID] = ?";
                    cmd.Parameters.Add("?", OleDbType.VarWChar).Value = _email;
                    
                    con.Open();
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null && reader.Read())
                        {
                            // Fill in the UI with stored data
                            txtUsername1.Text = reader["Name"]?.ToString();
                            txtMobile1.Text = reader["ContactNo"]?.ToString();
                            txtEmail1.Text = reader["EmailID"]?.ToString();
                            txtAboutUs.Text = reader["AboutUs"]?.ToString();
                            txtCompanyName.Text = reader["CompanyName"]?.ToString();
                            txtlocation1.Text = reader["Location"]?.ToString();
                            txtCompanyType.Text = reader["CompanyType"]?.ToString();
                            txtDomain.Text = reader["IndustryDomain"]?.ToString();
                            txtProject.Text = reader["PreferredCategories"]?.ToString();
                            txtLanguages.Text = reader["PreferredLanguages"]?.ToString();

                            string website = reader["BusinessWebsite"]?.ToString();
                            if (!string.IsNullOrWhiteSpace(website))
                            {
                                linkLabelBusiness.Text = website;
                                linkLabelBusiness.Links.Clear();
                                linkLabelBusiness.Links.Add(0, website.Length, website);
                                linkLabelBusiness.Visible = true;
                            }
                            else
                            {
                                linkLabelBusiness.Text = "No website provided";
                                linkLabelBusiness.Links.Clear();
                            }


                            // Load profile picture if exists
                            if (reader["ProfilePicture"] != DBNull.Value)
                            {
                                byte[] imgData = (byte[])reader["ProfilePicture"];
                                using (MemoryStream ms = new MemoryStream(imgData))
                                {
                                    if (Picturebox1.Image!=null)
                                        Picturebox1.Image.Dispose();

                                    Picturebox1.Image = Image.FromStream(ms);
                                    Picturebox1.SizeMode = PictureBoxSizeMode.StretchImage;
                                }
                            }
                            else
                            {
                                Picturebox1.Image = null; // or set a default image
                            }
                        }
                        else
                        {
                            MessageBox.Show("No Client profile found for this email.",
                                             "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading profile: " + ex.Message);
            }
        }

        private void linkLabelBusiness_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string url = e.Link.LinkData as string ?? linkLabelBusiness.Text;
                if (!string.IsNullOrWhiteSpace(url))
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open website: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void txtAboutUs_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void location1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            EditClientProfile editClientProfile = new EditClientProfile(_userId, _email, "");
            editClientProfile.Show();
            this.Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ClientDashboard clientDashboard = new ClientDashboard(_userId, _email);
            clientDashboard.Show();
            this.Hide();
        }

        private void txtEmail1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLanguages1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
