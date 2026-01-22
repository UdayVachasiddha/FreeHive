namespace Freelancer_app
{
    partial class Bidding
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bidding));
            this.panelTop = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelSidebar = new Guna.UI2.WinForms.Guna2Panel();
            this.BtnLogOut = new Guna.UI2.WinForms.Guna2Button();
            this.BtnProfile = new Guna.UI2.WinForms.Guna2Button();
            this.BtnProjects = new Guna.UI2.WinForms.Guna2Button();
            this.BtnHome = new Guna.UI2.WinForms.Guna2Button();
            this.BtnBidding = new Guna.UI2.WinForms.Guna2Button();
            this.panelContent = new Guna.UI2.WinForms.Guna2Panel();
            this.txtBidValue = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProjectTitle = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnPlaceBid = new Guna.UI2.WinForms.Guna2Button();
            this.btnClear = new Guna.UI2.WinForms.Guna2Button();
            this.lblMax = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.trkBid = new Guna.UI2.WinForms.Guna2TrackBar();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblBidAmountTitle = new System.Windows.Forms.Label();
            this.txtProject = new Guna.UI2.WinForms.Guna2TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.panelTop.SuspendLayout();
            this.panelSidebar.SuspendLayout();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(170, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(18, 17, 18, 17);
            this.panelTop.Size = new System.Drawing.Size(759, 92);
            this.panelTop.TabIndex = 7;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 15.5F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(15, 29);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(108, 36);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Bidding";
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.panelSidebar.Controls.Add(this.guna2Button3);
            this.panelSidebar.Controls.Add(this.BtnLogOut);
            this.panelSidebar.Controls.Add(this.BtnProfile);
            this.panelSidebar.Controls.Add(this.BtnProjects);
            this.panelSidebar.Controls.Add(this.BtnHome);
            this.panelSidebar.Controls.Add(this.BtnBidding);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(170, 647);
            this.panelSidebar.TabIndex = 8;
            // 
            // BtnLogOut
            // 
            this.BtnLogOut.Animated = true;
            this.BtnLogOut.AnimatedGIF = true;
            this.BtnLogOut.BackColor = System.Drawing.Color.Transparent;
            this.BtnLogOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnLogOut.BorderRadius = 10;
            this.BtnLogOut.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.BtnLogOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnLogOut.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnLogOut.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnLogOut.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnLogOut.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnLogOut.FillColor = System.Drawing.Color.Transparent;
            this.BtnLogOut.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.BtnLogOut.ForeColor = System.Drawing.Color.White;
            this.BtnLogOut.HoverState.FillColor = System.Drawing.Color.DarkRed;
            this.BtnLogOut.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.BtnLogOut.Image = ((System.Drawing.Image)(resources.GetObject("BtnLogOut.Image")));
            this.BtnLogOut.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnLogOut.ImageSize = new System.Drawing.Size(25, 25);
            this.BtnLogOut.Location = new System.Drawing.Point(0, 591);
            this.BtnLogOut.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnLogOut.Name = "BtnLogOut";
            this.BtnLogOut.Size = new System.Drawing.Size(170, 56);
            this.BtnLogOut.TabIndex = 5;
            this.BtnLogOut.Text = "Log Out      ";
            this.BtnLogOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnLogOut.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.BtnLogOut.Click += new System.EventHandler(this.BtnLogOut_Click);
            // 
            // BtnProfile
            // 
            this.BtnProfile.Animated = true;
            this.BtnProfile.AnimatedGIF = true;
            this.BtnProfile.BackColor = System.Drawing.Color.Transparent;
            this.BtnProfile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnProfile.BorderRadius = 10;
            this.BtnProfile.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.BtnProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnProfile.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnProfile.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnProfile.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnProfile.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnProfile.FillColor = System.Drawing.Color.Transparent;
            this.BtnProfile.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnProfile.ForeColor = System.Drawing.Color.White;
            this.BtnProfile.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(60)))), ((int)(((byte)(78)))));
            this.BtnProfile.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            this.BtnProfile.Image = ((System.Drawing.Image)(resources.GetObject("BtnProfile.Image")));
            this.BtnProfile.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnProfile.ImageSize = new System.Drawing.Size(30, 30);
            this.BtnProfile.Location = new System.Drawing.Point(0, 0);
            this.BtnProfile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnProfile.Name = "BtnProfile";
            this.BtnProfile.Size = new System.Drawing.Size(164, 56);
            this.BtnProfile.TabIndex = 4;
            this.BtnProfile.Text = "Profile  ";
            this.BtnProfile.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnProfile.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // BtnProjects
            // 
            this.BtnProjects.Animated = true;
            this.BtnProjects.AnimatedGIF = true;
            this.BtnProjects.BackColor = System.Drawing.Color.Transparent;
            this.BtnProjects.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnProjects.BorderRadius = 10;
            this.BtnProjects.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.BtnProjects.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnProjects.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnProjects.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnProjects.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnProjects.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnProjects.FillColor = System.Drawing.Color.Transparent;
            this.BtnProjects.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnProjects.ForeColor = System.Drawing.Color.White;
            this.BtnProjects.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(60)))), ((int)(((byte)(78)))));
            this.BtnProjects.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image3")));
            this.BtnProjects.Image = ((System.Drawing.Image)(resources.GetObject("BtnProjects.Image")));
            this.BtnProjects.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnProjects.ImageSize = new System.Drawing.Size(22, 22);
            this.BtnProjects.Location = new System.Drawing.Point(0, 228);
            this.BtnProjects.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnProjects.Name = "BtnProjects";
            this.BtnProjects.Size = new System.Drawing.Size(164, 56);
            this.BtnProjects.TabIndex = 2;
            this.BtnProjects.Text = "My Projects";
            this.BtnProjects.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnProjects.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.BtnProjects.Click += new System.EventHandler(this.BtnProjects_Click);
            // 
            // BtnHome
            // 
            this.BtnHome.Animated = true;
            this.BtnHome.AnimatedGIF = true;
            this.BtnHome.BackColor = System.Drawing.Color.Transparent;
            this.BtnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnHome.BorderRadius = 10;
            this.BtnHome.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.BtnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnHome.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnHome.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnHome.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnHome.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnHome.FillColor = System.Drawing.Color.Transparent;
            this.BtnHome.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnHome.ForeColor = System.Drawing.Color.White;
            this.BtnHome.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(60)))), ((int)(((byte)(78)))));
            this.BtnHome.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image4")));
            this.BtnHome.Image = ((System.Drawing.Image)(resources.GetObject("BtnHome.Image")));
            this.BtnHome.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnHome.ImageSize = new System.Drawing.Size(22, 22);
            this.BtnHome.Location = new System.Drawing.Point(3, 164);
            this.BtnHome.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnHome.Name = "BtnHome";
            this.BtnHome.Size = new System.Drawing.Size(164, 56);
            this.BtnHome.TabIndex = 0;
            this.BtnHome.Text = "Home      ";
            this.BtnHome.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnHome.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.BtnHome.Click += new System.EventHandler(this.BtnHome_Click);
            // 
            // BtnBidding
            // 
            this.BtnBidding.Animated = true;
            this.BtnBidding.AnimatedGIF = true;
            this.BtnBidding.BackColor = System.Drawing.Color.Transparent;
            this.BtnBidding.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnBidding.BorderRadius = 10;
            this.BtnBidding.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.BtnBidding.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnBidding.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnBidding.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnBidding.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnBidding.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnBidding.FillColor = System.Drawing.Color.Transparent;
            this.BtnBidding.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBidding.ForeColor = System.Drawing.Color.White;
            this.BtnBidding.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(60)))), ((int)(((byte)(78)))));
            this.BtnBidding.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image5")));
            this.BtnBidding.Image = ((System.Drawing.Image)(resources.GetObject("BtnBidding.Image")));
            this.BtnBidding.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnBidding.ImageSize = new System.Drawing.Size(22, 22);
            this.BtnBidding.Location = new System.Drawing.Point(0, 292);
            this.BtnBidding.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnBidding.Name = "BtnBidding";
            this.BtnBidding.Size = new System.Drawing.Size(164, 56);
            this.BtnBidding.TabIndex = 1;
            this.BtnBidding.Text = "Biddings";
            this.BtnBidding.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnBidding.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.BtnBidding.Click += new System.EventHandler(this.BtnBidding_Click);
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.txtBidValue);
            this.panelContent.Controls.Add(this.label1);
            this.panelContent.Controls.Add(this.txtProjectTitle);
            this.panelContent.Controls.Add(this.btnPlaceBid);
            this.panelContent.Controls.Add(this.btnClear);
            this.panelContent.Controls.Add(this.lblMax);
            this.panelContent.Controls.Add(this.lblMin);
            this.panelContent.Controls.Add(this.trkBid);
            this.panelContent.Controls.Add(this.guna2HtmlLabel1);
            this.panelContent.Controls.Add(this.lblBidAmountTitle);
            this.panelContent.Controls.Add(this.txtProject);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(170, 92);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(759, 555);
            this.panelContent.TabIndex = 9;
            this.panelContent.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContent_Paint);
            // 
            // txtBidValue
            // 
            this.txtBidValue.AcceptsTab = true;
            this.txtBidValue.Animated = true;
            this.txtBidValue.BorderRadius = 5;
            this.txtBidValue.BorderThickness = 2;
            this.txtBidValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBidValue.DefaultText = "";
            this.txtBidValue.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBidValue.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBidValue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBidValue.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBidValue.FocusedState.BorderColor = System.Drawing.Color.Gray;
            this.txtBidValue.FocusedState.FillColor = System.Drawing.Color.Transparent;
            this.txtBidValue.FocusedState.ForeColor = System.Drawing.Color.Gray;
            this.txtBidValue.FocusedState.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtBidValue.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBidValue.ForeColor = System.Drawing.Color.Black;
            this.txtBidValue.HoverState.BorderColor = System.Drawing.Color.Gray;
            this.txtBidValue.HoverState.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtBidValue.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBidValue.Location = new System.Drawing.Point(327, 430);
            this.txtBidValue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtBidValue.Name = "txtBidValue";
            this.txtBidValue.PlaceholderText = "Enter Bid";
            this.txtBidValue.SelectedText = "";
            this.txtBidValue.Size = new System.Drawing.Size(176, 36);
            this.txtBidValue.TabIndex = 98;
            this.txtBidValue.TextChanged += new System.EventHandler(this.txtBidValue_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(145, 437);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 23);
            this.label1.TabIndex = 97;
            this.label1.Text = "Enter Bid Value (in ₹)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtProjectTitle
            // 
            this.txtProjectTitle.AcceptsTab = true;
            this.txtProjectTitle.Animated = true;
            this.txtProjectTitle.BorderRadius = 5;
            this.txtProjectTitle.BorderThickness = 2;
            this.txtProjectTitle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtProjectTitle.DefaultText = "";
            this.txtProjectTitle.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtProjectTitle.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtProjectTitle.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtProjectTitle.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtProjectTitle.FocusedState.BorderColor = System.Drawing.Color.Gray;
            this.txtProjectTitle.FocusedState.FillColor = System.Drawing.Color.Transparent;
            this.txtProjectTitle.FocusedState.ForeColor = System.Drawing.Color.Gray;
            this.txtProjectTitle.FocusedState.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtProjectTitle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProjectTitle.ForeColor = System.Drawing.Color.Black;
            this.txtProjectTitle.HoverState.BorderColor = System.Drawing.Color.Gray;
            this.txtProjectTitle.HoverState.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtProjectTitle.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtProjectTitle.Location = new System.Drawing.Point(48, 92);
            this.txtProjectTitle.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtProjectTitle.Name = "txtProjectTitle";
            this.txtProjectTitle.PlaceholderText = "Project Title";
            this.txtProjectTitle.SelectedText = "";
            this.txtProjectTitle.Size = new System.Drawing.Size(641, 36);
            this.txtProjectTitle.TabIndex = 96;
            this.txtProjectTitle.TextChanged += new System.EventHandler(this.txtProjectTitle_TextChanged);
            // 
            // btnPlaceBid
            // 
            this.btnPlaceBid.Animated = true;
            this.btnPlaceBid.AnimatedGIF = true;
            this.btnPlaceBid.BackColor = System.Drawing.SystemColors.Window;
            this.btnPlaceBid.BorderColor = System.Drawing.Color.Transparent;
            this.btnPlaceBid.BorderRadius = 10;
            this.btnPlaceBid.BorderThickness = 1;
            this.btnPlaceBid.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlaceBid.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPlaceBid.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPlaceBid.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPlaceBid.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPlaceBid.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(113)))), ((int)(((byte)(220)))));
            this.btnPlaceBid.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlaceBid.ForeColor = System.Drawing.Color.White;
            this.btnPlaceBid.HoverState.BorderColor = System.Drawing.Color.Black;
            this.btnPlaceBid.HoverState.CustomBorderColor = System.Drawing.Color.Black;
            this.btnPlaceBid.HoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlaceBid.Location = new System.Drawing.Point(372, 499);
            this.btnPlaceBid.Name = "btnPlaceBid";
            this.btnPlaceBid.Size = new System.Drawing.Size(142, 42);
            this.btnPlaceBid.TabIndex = 94;
            this.btnPlaceBid.Text = "Place Bid";
            this.btnPlaceBid.Click += new System.EventHandler(this.btnPlaceBid_Click_1);
            // 
            // btnClear
            // 
            this.btnClear.Animated = true;
            this.btnClear.AnimatedGIF = true;
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnClear.BorderRadius = 10;
            this.btnClear.BorderThickness = 1;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClear.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClear.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClear.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClear.FillColor = System.Drawing.Color.White;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.HoverState.BorderColor = System.Drawing.Color.LightGray;
            this.btnClear.HoverState.CustomBorderColor = System.Drawing.Color.LightGray;
            this.btnClear.HoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(201, 499);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(126, 42);
            this.btnClear.TabIndex = 93;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblMax
            // 
            this.lblMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMax.AutoSize = true;
            this.lblMax.BackColor = System.Drawing.Color.Transparent;
            this.lblMax.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblMax.Location = new System.Drawing.Point(574, 392);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(99, 28);
            this.lblMax.TabIndex = 92;
            this.lblMax.Text = "₹5,00,000";
            this.lblMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.BackColor = System.Drawing.Color.Transparent;
            this.lblMin.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMin.Location = new System.Drawing.Point(51, 392);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(34, 28);
            this.lblMin.TabIndex = 91;
            this.lblMin.Text = "₹0";
            this.lblMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMin.Click += new System.EventHandler(this.lblMin_Click);
            // 
            // trkBid
            // 
            this.trkBid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trkBid.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trkBid.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.trkBid.HoverState.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.trkBid.Location = new System.Drawing.Point(117, 392);
            this.trkBid.Maximum = 10000;
            this.trkBid.Name = "trkBid";
            this.trkBid.Size = new System.Drawing.Size(451, 30);
            this.trkBid.TabIndex = 90;
            this.trkBid.ThumbColor = System.Drawing.Color.Gray;
            this.trkBid.Value = 0;
            this.trkBid.Scroll += new System.Windows.Forms.ScrollEventHandler(this.trkBid_Scroll);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.AutoSize = false;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.5F, System.Drawing.FontStyle.Bold);
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(48, 32);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(181, 38);
            this.guna2HtmlLabel1.TabIndex = 89;
            this.guna2HtmlLabel1.Text = "Bid on Project";
            // 
            // lblBidAmountTitle
            // 
            this.lblBidAmountTitle.AutoSize = true;
            this.lblBidAmountTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblBidAmountTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBidAmountTitle.Location = new System.Drawing.Point(77, 352);
            this.lblBidAmountTitle.Name = "lblBidAmountTitle";
            this.lblBidAmountTitle.Size = new System.Drawing.Size(136, 28);
            this.lblBidAmountTitle.TabIndex = 88;
            this.lblBidAmountTitle.Text = "BID AMOUNT";
            this.lblBidAmountTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtProject
            // 
            this.txtProject.AcceptsTab = true;
            this.txtProject.Animated = true;
            this.txtProject.BorderRadius = 5;
            this.txtProject.BorderThickness = 2;
            this.txtProject.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtProject.DefaultText = "";
            this.txtProject.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtProject.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtProject.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtProject.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtProject.FocusedState.BorderColor = System.Drawing.Color.Gray;
            this.txtProject.FocusedState.FillColor = System.Drawing.Color.Transparent;
            this.txtProject.FocusedState.ForeColor = System.Drawing.Color.Gray;
            this.txtProject.FocusedState.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtProject.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProject.ForeColor = System.Drawing.Color.Black;
            this.txtProject.HoverState.BorderColor = System.Drawing.Color.Gray;
            this.txtProject.HoverState.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtProject.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtProject.Location = new System.Drawing.Point(48, 156);
            this.txtProject.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtProject.Multiline = true;
            this.txtProject.Name = "txtProject";
            this.txtProject.PlaceholderText = "Type your message....";
            this.txtProject.SelectedText = "";
            this.txtProject.Size = new System.Drawing.Size(641, 164);
            this.txtProject.TabIndex = 87;
            this.txtProject.TextChanged += new System.EventHandler(this.txtProject_TextChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // guna2Button3
            // 
            this.guna2Button3.Animated = true;
            this.guna2Button3.AnimatedGIF = true;
            this.guna2Button3.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.guna2Button3.BorderRadius = 10;
            this.guna2Button3.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2Button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2Button3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button3.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button3.ForeColor = System.Drawing.Color.White;
            this.guna2Button3.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(60)))), ((int)(((byte)(78)))));
            this.guna2Button3.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.guna2Button3.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button3.Image")));
            this.guna2Button3.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button3.ImageSize = new System.Drawing.Size(22, 22);
            this.guna2Button3.Location = new System.Drawing.Point(0, 355);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.Size = new System.Drawing.Size(175, 59);
            this.guna2Button3.TabIndex = 13;
            this.guna2Button3.Text = "   Project Submit";
            this.guna2Button3.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.guna2Button3.Click += new System.EventHandler(this.guna2Button3_Click);
            // 
            // Bidding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 647);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelSidebar);
            this.Name = "Bidding";
            this.Text = "Bidding";
            this.Load += new System.EventHandler(this.Bidding_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelSidebar.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Panel panelSidebar;
        private Guna.UI2.WinForms.Guna2Button BtnLogOut;
        private Guna.UI2.WinForms.Guna2Button BtnProfile;
        private Guna.UI2.WinForms.Guna2Button BtnProjects;
        private Guna.UI2.WinForms.Guna2Button BtnHome;
        private Guna.UI2.WinForms.Guna2Button BtnBidding;
        private Guna.UI2.WinForms.Guna2Panel panelContent;
        private Guna.UI2.WinForms.Guna2Button btnPlaceBid;
        private Guna.UI2.WinForms.Guna2Button btnClear;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label lblMin;
        private Guna.UI2.WinForms.Guna2TrackBar trkBid;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private System.Windows.Forms.Label lblBidAmountTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtProject;
        private Guna.UI2.WinForms.Guna2TextBox txtProjectTitle;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtBidValue;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
    }
}