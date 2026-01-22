namespace Freelancer_app
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.panelSidebar = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.BtnLogOut = new Guna.UI2.WinForms.Guna2Button();
            this.BtnProfile = new Guna.UI2.WinForms.Guna2Button();
            this.BtnProjects = new Guna.UI2.WinForms.Guna2Button();
            this.BtnHome = new Guna.UI2.WinForms.Guna2Button();
            this.BtnBidding = new Guna.UI2.WinForms.Guna2Button();
            this.panelTop = new Guna.UI2.WinForms.Guna2Panel();
            this.btnClearAll = new Guna.UI2.WinForms.Guna2Button();
            this.lblBadgee = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.BtnBell = new Guna.UI2.WinForms.Guna2CircleButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelContent = new Guna.UI2.WinForms.Guna2Panel();
            this.flowLayoutPanelNotifications = new System.Windows.Forms.FlowLayoutPanel();
            this.flowRecentProjects = new System.Windows.Forms.FlowLayoutPanel();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblEarnings = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCompletedProjects = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblActiveBids = new System.Windows.Forms.Label();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.badgePulseTimer = new System.Windows.Forms.Timer(this.components);
            this.panelSidebar.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.panelSidebar.Controls.Add(this.guna2Button1);
            this.panelSidebar.Controls.Add(this.BtnLogOut);
            this.panelSidebar.Controls.Add(this.BtnProfile);
            this.panelSidebar.Controls.Add(this.BtnProjects);
            this.panelSidebar.Controls.Add(this.BtnHome);
            this.panelSidebar.Controls.Add(this.BtnBidding);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(161, 647);
            this.panelSidebar.TabIndex = 0;
            this.panelSidebar.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSidebar_Paint);
            // 
            // guna2Button1
            // 
            this.guna2Button1.Animated = true;
            this.guna2Button1.AnimatedGIF = true;
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.guna2Button1.BorderRadius = 10;
            this.guna2Button1.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2Button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(60)))), ((int)(((byte)(78)))));
            this.guna2Button1.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.guna2Button1.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button1.Image")));
            this.guna2Button1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button1.ImageSize = new System.Drawing.Size(22, 22);
            this.guna2Button1.Location = new System.Drawing.Point(-3, 321);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(175, 59);
            this.guna2Button1.TabIndex = 7;
            this.guna2Button1.Text = "   Project Submit";
            this.guna2Button1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click_2);
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
            this.BtnLogOut.Location = new System.Drawing.Point(-3, 588);
            this.BtnLogOut.Name = "BtnLogOut";
            this.BtnLogOut.Size = new System.Drawing.Size(164, 56);
            this.BtnLogOut.TabIndex = 5;
            this.BtnLogOut.Text = "   Log Out      ";
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
            this.BtnProfile.Name = "BtnProfile";
            this.BtnProfile.Size = new System.Drawing.Size(164, 56);
            this.BtnProfile.TabIndex = 4;
            this.BtnProfile.Text = "    Profile      ";
            this.BtnProfile.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.BtnProfile.Click += new System.EventHandler(this.BtnProfile_Click);
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
            this.BtnProjects.Location = new System.Drawing.Point(-3, 197);
            this.BtnProjects.Name = "BtnProjects";
            this.BtnProjects.Size = new System.Drawing.Size(164, 56);
            this.BtnProjects.TabIndex = 2;
            this.BtnProjects.Text = "    My Projects";
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
            this.BtnHome.Location = new System.Drawing.Point(-3, 135);
            this.BtnHome.Name = "BtnHome";
            this.BtnHome.Size = new System.Drawing.Size(164, 56);
            this.BtnHome.TabIndex = 0;
            this.BtnHome.Text = "  Home      ";
            this.BtnHome.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.BtnHome.Click += new System.EventHandler(this.guna2Button1_Click);
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
            this.BtnBidding.Location = new System.Drawing.Point(-3, 259);
            this.BtnBidding.Name = "BtnBidding";
            this.BtnBidding.Size = new System.Drawing.Size(164, 56);
            this.BtnBidding.TabIndex = 1;
            this.BtnBidding.Text = "Biddings";
            this.BtnBidding.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.BtnBidding.Click += new System.EventHandler(this.BtnBidding_Click);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.Controls.Add(this.btnClearAll);
            this.panelTop.Controls.Add(this.lblBadgee);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Controls.Add(this.BtnBell);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(161, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.panelTop.Size = new System.Drawing.Size(768, 64);
            this.panelTop.TabIndex = 0;
            this.panelTop.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTop_Paint);
            // 
            // btnClearAll
            // 
            this.btnClearAll.BorderRadius = 5;
            this.btnClearAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearAll.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClearAll.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClearAll.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClearAll.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClearAll.FillColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClearAll.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearAll.ForeColor = System.Drawing.Color.Gray;
            this.btnClearAll.Location = new System.Drawing.Point(678, 44);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(78, 20);
            this.btnClearAll.TabIndex = 4;
            this.btnClearAll.Text = "Clear all";
            this.btnClearAll.Visible = false;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click_1);
            // 
            // lblBadgee
            // 
            this.lblBadgee.AutoSize = true;
            this.lblBadgee.BackColor = System.Drawing.Color.Transparent;
            this.lblBadgee.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBadgee.ForeColor = System.Drawing.Color.Red;
            this.lblBadgee.Location = new System.Drawing.Point(737, 15);
            this.lblBadgee.Name = "lblBadgee";
            this.lblBadgee.Size = new System.Drawing.Size(15, 17);
            this.lblBadgee.TabIndex = 3;
            this.lblBadgee.Text = "0";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 15.5F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(6, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(276, 36);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Freelancer Dashboard";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // BtnBell
            // 
            this.BtnBell.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnBell.Animated = true;
            this.BtnBell.AnimatedGIF = true;
            this.BtnBell.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnBell.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnBell.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnBell.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnBell.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnBell.FillColor = System.Drawing.Color.Transparent;
            this.BtnBell.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnBell.ForeColor = System.Drawing.Color.White;
            this.BtnBell.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image6")));
            this.BtnBell.Image = ((System.Drawing.Image)(resources.GetObject("BtnBell.Image")));
            this.BtnBell.Location = new System.Drawing.Point(720, 15);
            this.BtnBell.Name = "BtnBell";
            this.BtnBell.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.BtnBell.Size = new System.Drawing.Size(36, 36);
            this.BtnBell.TabIndex = 2;
            this.BtnBell.Click += new System.EventHandler(this.guna2CircleButton1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(73, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 28);
            this.label5.TabIndex = 78;
            this.label5.Text = "Active Bids";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(288, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(181, 28);
            this.label4.TabIndex = 79;
            this.label4.Text = "Project Completed";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(551, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 28);
            this.label3.TabIndex = 81;
            this.label3.Text = "Earnings (in ₹)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.flowLayoutPanelNotifications);
            this.panelContent.Controls.Add(this.flowRecentProjects);
            this.panelContent.Controls.Add(this.guna2Panel3);
            this.panelContent.Controls.Add(this.guna2Panel2);
            this.panelContent.Controls.Add(this.guna2Panel1);
            this.panelContent.Controls.Add(this.label3);
            this.panelContent.Controls.Add(this.label4);
            this.panelContent.Controls.Add(this.label5);
            this.panelContent.Controls.Add(this.txtSearch);
            this.panelContent.Controls.Add(this.label7);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.FillColor = System.Drawing.Color.Transparent;
            this.panelContent.Location = new System.Drawing.Point(161, 64);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(16);
            this.panelContent.Size = new System.Drawing.Size(768, 583);
            this.panelContent.TabIndex = 3;
            this.panelContent.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContent_Paint);
            // 
            // flowLayoutPanelNotifications
            // 
            this.flowLayoutPanelNotifications.AutoScroll = true;
            this.flowLayoutPanelNotifications.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanelNotifications.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanelNotifications.Location = new System.Drawing.Point(490, 1);
            this.flowLayoutPanelNotifications.Name = "flowLayoutPanelNotifications";
            this.flowLayoutPanelNotifications.Size = new System.Drawing.Size(266, 201);
            this.flowLayoutPanelNotifications.TabIndex = 3;
            this.flowLayoutPanelNotifications.Visible = false;
            // 
            // flowRecentProjects
            // 
            this.flowRecentProjects.AutoScroll = true;
            this.flowRecentProjects.Location = new System.Drawing.Point(6, 281);
            this.flowRecentProjects.Name = "flowRecentProjects";
            this.flowRecentProjects.Size = new System.Drawing.Size(750, 299);
            this.flowRecentProjects.TabIndex = 114;
            this.flowRecentProjects.WrapContents = false;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.guna2Panel3.BorderRadius = 5;
            this.guna2Panel3.BorderThickness = 2;
            this.guna2Panel3.Controls.Add(this.lblEarnings);
            this.guna2Panel3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            this.guna2Panel3.Location = new System.Drawing.Point(504, 19);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.ShadowDecoration.Enabled = true;
            this.guna2Panel3.Size = new System.Drawing.Size(237, 140);
            this.guna2Panel3.TabIndex = 113;
            // 
            // lblEarnings
            // 
            this.lblEarnings.AutoSize = true;
            this.lblEarnings.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblEarnings.Location = new System.Drawing.Point(62, 52);
            this.lblEarnings.Name = "lblEarnings";
            this.lblEarnings.Size = new System.Drawing.Size(35, 41);
            this.lblEarnings.TabIndex = 0;
            this.lblEarnings.Text = "0";
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.guna2Panel2.BorderRadius = 5;
            this.guna2Panel2.BorderThickness = 2;
            this.guna2Panel2.Controls.Add(this.lblCompletedProjects);
            this.guna2Panel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(169)))), ((int)(((byte)(255)))));
            this.guna2Panel2.Location = new System.Drawing.Point(258, 19);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Enabled = true;
            this.guna2Panel2.Size = new System.Drawing.Size(237, 140);
            this.guna2Panel2.TabIndex = 113;
            this.guna2Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel2_Paint_1);
            // 
            // lblCompletedProjects
            // 
            this.lblCompletedProjects.AutoSize = true;
            this.lblCompletedProjects.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblCompletedProjects.Location = new System.Drawing.Point(100, 52);
            this.lblCompletedProjects.Name = "lblCompletedProjects";
            this.lblCompletedProjects.Size = new System.Drawing.Size(35, 41);
            this.lblCompletedProjects.TabIndex = 0;
            this.lblCompletedProjects.Text = "0";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.guna2Panel1.BorderRadius = 5;
            this.guna2Panel1.BorderThickness = 2;
            this.guna2Panel1.Controls.Add(this.lblActiveBids);
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            this.guna2Panel1.Location = new System.Drawing.Point(12, 19);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Enabled = true;
            this.guna2Panel1.Size = new System.Drawing.Size(237, 140);
            this.guna2Panel1.TabIndex = 112;
            this.guna2Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel1_Paint);
            // 
            // lblActiveBids
            // 
            this.lblActiveBids.AutoSize = true;
            this.lblActiveBids.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblActiveBids.Location = new System.Drawing.Point(100, 52);
            this.lblActiveBids.Name = "lblActiveBids";
            this.lblActiveBids.Size = new System.Drawing.Size(35, 41);
            this.lblActiveBids.TabIndex = 0;
            this.lblActiveBids.Text = "0";
            // 
            // txtSearch
            // 
            this.txtSearch.Animated = true;
            this.txtSearch.BorderRadius = 8;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.Gray;
            this.txtSearch.FocusedState.ForeColor = System.Drawing.Color.Gray;
            this.txtSearch.FocusedState.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.ForeColor = System.Drawing.Color.Black;
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.Gray;
            this.txtSearch.HoverState.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtSearch.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtSearch.IconLeft")));
            this.txtSearch.Location = new System.Drawing.Point(488, 238);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Search";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(250, 36);
            this.txtSearch.TabIndex = 5;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(10, 246);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(219, 28);
            this.label7.TabIndex = 4;
            this.label7.Text = "Recent Projects Posted";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // badgePulseTimer
            // 
            this.badgePulseTimer.Interval = 500;
            this.badgePulseTimer.Tick += new System.EventHandler(this.badgePulseTimer_Tick);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(929, 647);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelSidebar);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.panelSidebar.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel3.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelSidebar;
        private Guna.UI2.WinForms.Guna2Button BtnHome;
        private Guna.UI2.WinForms.Guna2Button BtnProjects;
        private Guna.UI2.WinForms.Guna2Button BtnBidding;
        private Guna.UI2.WinForms.Guna2Button BtnProfile;
        private Guna.UI2.WinForms.Guna2Button BtnLogOut;
        private Guna.UI2.WinForms.Guna2Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2CircleButton BtnBell;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Panel panelContent;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelNotifications;
        private System.Windows.Forms.Label lblBadgee;
        private Guna.UI2.WinForms.Guna2Button btnClearAll;
        private System.Windows.Forms.Timer badgePulseTimer;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.Label lblCompletedProjects;
        private System.Windows.Forms.Label lblActiveBids;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private System.Windows.Forms.Label lblEarnings;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.FlowLayoutPanel flowRecentProjects;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}