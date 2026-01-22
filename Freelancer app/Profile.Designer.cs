namespace Freelancer_app
{
    partial class Profile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Profile));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClient = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnFreelancer = new Guna.UI2.WinForms.Guna2ImageButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnClient);
            this.panel1.Controls.Add(this.btnFreelancer);
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(783, 451);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnClient
            // 
            this.btnClient.AnimatedGIF = true;
            this.btnClient.BackColor = System.Drawing.Color.Transparent;
            this.btnClient.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnClient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClient.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.btnClient.HoverState.ImageSize = new System.Drawing.Size(225, 292);
            this.btnClient.Image = ((System.Drawing.Image)(resources.GetObject("btnClient.Image")));
            this.btnClient.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnClient.ImageRotate = 0F;
            this.btnClient.ImageSize = new System.Drawing.Size(218, 288);
            this.btnClient.Location = new System.Drawing.Point(455, 93);
            this.btnClient.Name = "btnClient";
            this.btnClient.PressedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.btnClient.PressedState.ImageSize = new System.Drawing.Size(218, 288);
            this.btnClient.ShadowDecoration.Depth = 35;
            this.btnClient.ShadowDecoration.Enabled = true;
            this.btnClient.Size = new System.Drawing.Size(218, 288);
            this.btnClient.TabIndex = 5;
            this.btnClient.Click += new System.EventHandler(this.btnClient_Click);
            // 
            // btnFreelancer
            // 
            this.btnFreelancer.AnimatedGIF = true;
            this.btnFreelancer.BackColor = System.Drawing.Color.Transparent;
            this.btnFreelancer.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnFreelancer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFreelancer.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            this.btnFreelancer.HoverState.ImageSize = new System.Drawing.Size(225, 292);
            this.btnFreelancer.Image = ((System.Drawing.Image)(resources.GetObject("btnFreelancer.Image")));
            this.btnFreelancer.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnFreelancer.ImageRotate = 0F;
            this.btnFreelancer.ImageSize = new System.Drawing.Size(218, 288);
            this.btnFreelancer.Location = new System.Drawing.Point(173, 93);
            this.btnFreelancer.Name = "btnFreelancer";
            this.btnFreelancer.PressedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image3")));
            this.btnFreelancer.PressedState.ImageSize = new System.Drawing.Size(218, 288);
            this.btnFreelancer.ShadowDecoration.Depth = 35;
            this.btnFreelancer.ShadowDecoration.Enabled = true;
            this.btnFreelancer.Size = new System.Drawing.Size(218, 288);
            this.btnFreelancer.TabIndex = 4;
            this.btnFreelancer.Click += new System.EventHandler(this.guna2ImageButton1_Click);
            // 
            // Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(783, 457);
            this.Controls.Add(this.panel1);
            this.Name = "Profile";
            this.Text = "Profile";
            this.Load += new System.EventHandler(this.Profile_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ImageButton btnFreelancer;
        private Guna.UI2.WinForms.Guna2ImageButton btnClient;
        private System.Windows.Forms.Panel panel1;
    }
}