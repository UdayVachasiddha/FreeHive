namespace Freelancer_app
{
    partial class MyProjects
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyProjects));
            this.panelTop = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelSidebar = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.BtnLogOut = new Guna.UI2.WinForms.Guna2Button();
            this.BtnProfile = new Guna.UI2.WinForms.Guna2Button();
            this.BtnProjects = new Guna.UI2.WinForms.Guna2Button();
            this.BtnHome = new Guna.UI2.WinForms.Guna2Button();
            this.BtnBidding = new Guna.UI2.WinForms.Guna2Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label18 = new System.Windows.Forms.Label();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.panelSidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(161, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(18, 17, 18, 17);
            this.panelTop.Size = new System.Drawing.Size(793, 92);
            this.panelTop.TabIndex = 4;
            this.panelTop.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTop_Paint);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 15.5F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(15, 29);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(153, 36);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "My Projects";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
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
            this.panelSidebar.Size = new System.Drawing.Size(161, 774);
            this.panelSidebar.TabIndex = 5;
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
            this.guna2Button3.Location = new System.Drawing.Point(-3, 410);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.Size = new System.Drawing.Size(175, 59);
            this.guna2Button3.TabIndex = 7;
            this.guna2Button3.Text = "   Project Submit";
            this.guna2Button3.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.guna2Button3.Click += new System.EventHandler(this.guna2Button3_Click);
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
            this.BtnLogOut.Location = new System.Drawing.Point(0, 714);
            this.BtnLogOut.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnLogOut.Name = "BtnLogOut";
            this.BtnLogOut.Size = new System.Drawing.Size(164, 56);
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
            this.BtnProfile.Location = new System.Drawing.Point(-3, 0);
            this.BtnProfile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnProfile.Name = "BtnProfile";
            this.BtnProfile.Size = new System.Drawing.Size(167, 71);
            this.BtnProfile.TabIndex = 4;
            this.BtnProfile.Text = "Profile      ";
            this.BtnProfile.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnProfile.TextFormatNoPrefix = true;
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
            this.BtnProjects.Location = new System.Drawing.Point(-3, 283);
            this.BtnProjects.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnProjects.Name = "BtnProjects";
            this.BtnProjects.Size = new System.Drawing.Size(164, 56);
            this.BtnProjects.TabIndex = 2;
            this.BtnProjects.Text = "My Projects";
            this.BtnProjects.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnProjects.TextFormatNoPrefix = true;
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
            this.BtnHome.Location = new System.Drawing.Point(0, 219);
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
            this.BtnBidding.Location = new System.Drawing.Point(-3, 347);
            this.BtnBidding.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnBidding.Name = "BtnBidding";
            this.BtnBidding.Size = new System.Drawing.Size(161, 56);
            this.BtnBidding.TabIndex = 1;
            this.BtnBidding.Text = "Biddings";
            this.BtnBidding.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnBidding.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.BtnBidding.Click += new System.EventHandler(this.BtnBidding_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(161, 237);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(20);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(793, 537);
            this.flowLayoutPanel1.TabIndex = 6;
            this.flowLayoutPanel1.WrapContents = false;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(181, 98);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(198, 31);
            this.label18.TabIndex = 8;
            this.label18.Text = "Available Projects";
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
            this.txtSearch.Location = new System.Drawing.Point(182, 137);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Search Projects";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(555, 45);
            this.txtSearch.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(177, 206);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 28);
            this.label7.TabIndex = 9;
            this.label7.Text = "Projects Posted";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MyProjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(954, 774);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelSidebar);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MyProjects";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyProjects";
            this.Load += new System.EventHandler(this.MyProjects_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelSidebar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel panelTop;
        private Guna.UI2.WinForms.Guna2Panel panelSidebar;
        private Guna.UI2.WinForms.Guna2Button BtnLogOut;
        private Guna.UI2.WinForms.Guna2Button BtnProfile;
        private Guna.UI2.WinForms.Guna2Button BtnProjects;
        private Guna.UI2.WinForms.Guna2Button BtnHome;
        private Guna.UI2.WinForms.Guna2Button BtnBidding;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label18;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
    }
}