using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Freelancer_app
{
    public partial class EditClientProfile : Form
    {
        private int _userId;
        private string _email;
        string conString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=SkillHive Database.accdb;Persist Security Info=False;";

        public EditClientProfile(int userId, string email, string username)
        {
            InitializeComponent();
            _userId = userId;
            _email = email;
        }

        private void EditClientProfile_Load(object sender, EventArgs e)
        {
            // Show email and try to load existing profile if present
            txtEmail1.Text = _email;
            txtEmail1.ReadOnly = true;
            LoadExistingClientProfile();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            // designer hook - no code required
        }

        private void BtnSET1_Click(object sender, EventArgs e)
        {
            if (!ValidateClientForm(out var errors))
            {
                MessageBox.Show(string.Join("\n", errors), "Please fix the following issues", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SaveOrUpdateClientProfile();

                // Navigate to client dashboard after saving
                ClientDashboard dashboard = new ClientDashboard(_userId, _email);
                dashboard.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving profile: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateClientForm(out List<string> errors)
        {
            errors = new List<string>();

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
                errors.Add("Client name is required.");
            if (string.IsNullOrWhiteSpace(txtMobile1.Text))
                errors.Add("Contact number is required.");
            if (string.IsNullOrWhiteSpace(txtEmail1.Text))
                errors.Add("Email ID is required.");
            if (string.IsNullOrWhiteSpace(txtAboutUs.Text))
                errors.Add("About Us section cannot be empty.");
            if (string.IsNullOrWhiteSpace(txtCompanyName.Text))
                errors.Add("Company name is required.");
            if (string.IsNullOrWhiteSpace(txtCompanyType.Text))
                errors.Add("Company type is required.");
            if (string.IsNullOrWhiteSpace(txtLanguages1.Text))
                errors.Add("Preferred languages are required.");
            if (string.IsNullOrWhiteSpace(txtURL.Text))
                errors.Add("Business website is required.");
            if (string.IsNullOrWhiteSpace(txtDomain.Text))
                errors.Add("Industry/Domain is required.");
            if (comboBox2.SelectedItem == null)
                errors.Add("Location must be selected.");
            if (string.IsNullOrWhiteSpace(txtProject.Text))
                errors.Add("Preferred project categories are required.");

            // Phone validation (10 digits)
            if (!string.IsNullOrWhiteSpace(txtMobile1.Text) &&
                !Regex.IsMatch(txtMobile1.Text.Trim(), @"^\d{10}$"))
            {
                errors.Add("Contact number must be exactly 10 digits.");
            }

            // Email validation
            string email = txtEmail1.Text.Trim();
            if (!string.IsNullOrWhiteSpace(email) &&
                !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                errors.Add("Email format is invalid. Use format like abc@xyz.com");
            }

            // URL validation
            if (!string.IsNullOrWhiteSpace(txtURL.Text) &&
               !Uri.IsWellFormedUriString(txtURL.Text, UriKind.Absolute))
            {
                errors.Add("Business website must be a valid URL (e.g. https://example.com)");
            }

            if (pictureBox2.Image == null)
                errors.Add("Profile photo is required. Please upload an image.");

            return errors.Count == 0;
        }

        private void SaveOrUpdateClientProfile()
        {
            using (OleDbConnection con = new OleDbConnection(conString))
            {
                con.Open();

                // Check existing profile by EmailID
                string checkQuery = "SELECT COUNT(*) FROM ClientProfile WHERE EmailID = ?";
                using (OleDbCommand checkCmd = new OleDbCommand(checkQuery, con))
                {
                    checkCmd.Parameters.AddWithValue("?", _email);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    string sql;
                    if (count > 0)
                    {
                        // Update existing client profile - note order of parameters below must match AddWithValue order
                        sql = @"
                            UPDATE ClientProfile
                            SET Name = ?, ContactNo = ?, CompanyName = ?, CompanyType = ?, Location = ?, ProfilePicture = ?, 
                                AboutUs = ?, PreferredLanguages = ?, BusinessWebsite = ?, IndustryDomain = ?,   
                                PreferredCategories = ?
                            WHERE EmailID = ?";
                    }
                    else
                    {
                        // Insert new client profile
                        sql = @"
                            INSERT INTO ClientProfile
                              (Name, ContactNo, CompanyName, CompanyType, Location, ProfilePicture, AboutUs, PreferredLanguages, 
                               BusinessWebsite, IndustryDomain, PreferredCategories, EmailID)
                            VALUES
                              (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
                    }

                    using (OleDbCommand cmd = new OleDbCommand(sql, con))
                    {
                        // Add parameters in the exact order used in the SQL
                        cmd.Parameters.AddWithValue("?", txtUsername.Text.Trim());            // Name
                        cmd.Parameters.AddWithValue("?", txtMobile1.Text.Trim());             // ContactNo
                        cmd.Parameters.AddWithValue("?", txtCompanyName.Text.Trim());         // CompanyName
                        cmd.Parameters.AddWithValue("?", txtCompanyType.Text.Trim());         // CompanyType
                        cmd.Parameters.AddWithValue("?", comboBox2.SelectedItem?.ToString() ?? ""); // Location

                        // Profile picture -> compress/resize then add bytes
                        if (pictureBox2.Image != null)
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                pictureBox2.Image.Save(ms, ImageFormat.Jpeg); // ✅ safer than RawFormat
                                cmd.Parameters.AddWithValue("@ProfilePicture", ms.ToArray());
                            }
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@ProfilePicture", DBNull.Value);
                        }

                        cmd.Parameters.AddWithValue("?", txtAboutUs.Text.Trim());            // AboutUs
                        cmd.Parameters.AddWithValue("?", txtLanguages1.Text.Trim());        // PreferredLanguages
                        cmd.Parameters.AddWithValue("?", txtURL.Text.Trim());               // BusinessWebsite
                        cmd.Parameters.AddWithValue("?", txtDomain.Text.Trim());            // IndustryDomain
                        cmd.Parameters.AddWithValue("?", txtProject.Text.Trim());           // PreferredCategories

                        // EmailID last (for both insert/update)
                        cmd.Parameters.AddWithValue("?", txtEmail1.Text.Trim());            // EmailID

                        cmd.ExecuteNonQuery();
                    }
                }
            }

            MessageBox.Show("Client profile saved successfully!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // select image and load from memory to avoid locking the original file
            using (var dlg = new OpenFileDialog())
            {
                dlg.Title = "Select Profile Picture";
                dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                dlg.Multiselect = false;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    // dispose previous image properly
                    if (pictureBox2.Image != null)
                    {
                        pictureBox2.Image.Dispose();
                        pictureBox2.Image = null;
                    }

                    // Load bytes then create image from stream (prevents file lock)
                    var bytes = File.ReadAllBytes(dlg.FileName);
                    using (var ms = new MemoryStream(bytes))
                    {
                        using (var tempImage = Image.FromStream(ms))
                        {
                            pictureBox2.Image = new Bitmap(tempImage); // ✅ clone to detach from stream
                        }
                    }
                    pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile(_userId, _email);
            profile.Show();
            this.Hide();
        }

        private void LoadExistingClientProfile()
        {
            using (OleDbConnection con = new OleDbConnection(conString))
            {
                con.Open();

                string select = @"SELECT Name, ContactNo, CompanyName, CompanyType, Location, ProfilePicture, 
                                  AboutUs, PreferredLanguages, BusinessWebsite, IndustryDomain, PreferredCategories
                                  FROM ClientProfile
                                  WHERE EmailID = ?";

                using (OleDbCommand cmd = new OleDbCommand(select, con))
                {
                    cmd.Parameters.AddWithValue("?", _email);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtUsername.Text = reader["Name"]?.ToString() ?? "";
                            txtMobile1.Text = reader["ContactNo"]?.ToString() ?? "";
                            txtCompanyName.Text = reader["CompanyName"]?.ToString() ?? "";
                            txtCompanyType.Text = reader["CompanyType"]?.ToString() ?? "";
                            var loc = reader["Location"]?.ToString();
                            if (!string.IsNullOrEmpty(loc))
                                comboBox2.SelectedItem = loc;
                            txtAboutUs.Text = reader["AboutUs"]?.ToString() ?? "";
                            txtLanguages1.Text = reader["PreferredLanguages"]?.ToString() ?? "";
                            txtURL.Text = reader["BusinessWebsite"]?.ToString() ?? "";
                            txtDomain.Text = reader["IndustryDomain"]?.ToString() ?? "";
                            txtProject.Text = reader["PreferredCategories"]?.ToString() ?? "";

                            // Load image bytes (if present)
                            if (!(reader["ProfilePicture"] is DBNull))
                            {
                                var imgBytes = (byte[])reader["ProfilePicture"];
                                using (var ms = new MemoryStream(imgBytes))
                                {
                                    pictureBox2.Image = Image.FromStream(ms);
                                    pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                                }
                            }
                        }
                    }
                }
            }
        }

        // Helper: convert image to compressed JPEG bytes, resizing if necessary
        private byte[] ImageToJpegBytes(Image image, int maxWidth = 800, long quality = 75L)
        {
            if (image == null) return null;

            Image toSave = image;
            Bitmap resized = null;

            try
            {
                if (image.Width > maxWidth)
                {
                    float ratio = (float)maxWidth / image.Width;
                    int newW = maxWidth;
                    int newH = (int)(image.Height * ratio);

                    resized = new Bitmap(newW, newH);
                    using (Graphics g = Graphics.FromImage(resized))
                    {
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        g.DrawImage(image, 0, 0, newW, newH);
                    }
                    toSave = resized;
                }

                using (var ms = new MemoryStream())
                {
                    ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                    if (jpgEncoder == null)
                    {
                        // fallback
                        toSave.Save(ms, ImageFormat.Jpeg);
                        return ms.ToArray();
                    }

                    var encoder = System.Drawing.Imaging.Encoder.Quality;
                    var encParams = new EncoderParameters(1);
                    encParams.Param[0] = new EncoderParameter(encoder, quality);
                    toSave.Save(ms, jpgEncoder, encParams);
                    return ms.ToArray();
                }
            }
            finally
            {
                if (resized != null) resized.Dispose();
            }
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (var c in codecs)
            {
                if (c.FormatID == format.Guid) return c;
            }
            return null;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
