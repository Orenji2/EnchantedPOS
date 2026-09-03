namespace EnchantedPOS
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblName = new Label();
            lblAddress = new Label();
            gbPOSLogin = new GroupBox();
            btnLogOut = new Button();
            txtC_Pass = new TextBox();
            lblCashierPass = new Label();
            btnLogIn = new Button();
            pictureBox1 = new PictureBox();
            btnAdmin = new Button();
            btnReports = new Button();
            btnPOS = new Button();
            panelPOSLogin = new Panel();
            gbPOSLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelPOSLogin.SuspendLayout();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.BackColor = Color.Transparent;
            lblName.Font = new Font("Segoe UI Black", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.ForeColor = SystemColors.ControlLightLight;
            lblName.Location = new Point(31, 123);
            lblName.Name = "lblName";
            lblName.Size = new Size(317, 46);
            lblName.TabIndex = 0;
            lblName.Text = "<Business Name>";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.BackColor = Color.Transparent;
            lblAddress.ForeColor = SystemColors.ControlLightLight;
            lblAddress.Location = new Point(47, 169);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(90, 20);
            lblAddress.TabIndex = 1;
            lblAddress.Text = "< Address >";
            // 
            // gbPOSLogin
            // 
            gbPOSLogin.BackColor = Color.Transparent;
            gbPOSLogin.Controls.Add(btnLogOut);
            gbPOSLogin.Controls.Add(txtC_Pass);
            gbPOSLogin.Controls.Add(lblCashierPass);
            gbPOSLogin.Controls.Add(btnLogIn);
            gbPOSLogin.Controls.Add(pictureBox1);
            gbPOSLogin.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbPOSLogin.ForeColor = SystemColors.ControlLightLight;
            gbPOSLogin.Location = new Point(59, 15);
            gbPOSLogin.Margin = new Padding(3, 4, 3, 4);
            gbPOSLogin.Name = "gbPOSLogin";
            gbPOSLogin.Padding = new Padding(3, 4, 3, 4);
            gbPOSLogin.Size = new Size(440, 339);
            gbPOSLogin.TabIndex = 2;
            gbPOSLogin.TabStop = false;
            gbPOSLogin.Text = "Log-In";
            // 
            // btnLogOut
            // 
            btnLogOut.Enabled = false;
            btnLogOut.ForeColor = SystemColors.ActiveCaptionText;
            btnLogOut.Location = new Point(320, 221);
            btnLogOut.Margin = new Padding(3, 4, 3, 4);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(104, 77);
            btnLogOut.TabIndex = 4;
            btnLogOut.Text = "LOG OUT";
            btnLogOut.UseVisualStyleBackColor = true;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // txtC_Pass
            // 
            txtC_Pass.Location = new Point(174, 85);
            txtC_Pass.Margin = new Padding(3, 4, 3, 4);
            txtC_Pass.Name = "txtC_Pass";
            txtC_Pass.Size = new Size(250, 29);
            txtC_Pass.TabIndex = 3;
            txtC_Pass.UseSystemPasswordChar = true;
            txtC_Pass.KeyDown += txtC_Pass_KeyDown;
            // 
            // lblCashierPass
            // 
            lblCashierPass.AutoSize = true;
            lblCashierPass.ForeColor = SystemColors.ControlLightLight;
            lblCashierPass.Location = new Point(174, 49);
            lblCashierPass.Name = "lblCashierPass";
            lblCashierPass.Size = new Size(154, 23);
            lblCashierPass.TabIndex = 2;
            lblCashierPass.Text = "Enter Access Code";
            // 
            // btnLogIn
            // 
            btnLogIn.BackColor = Color.ForestGreen;
            btnLogIn.FlatStyle = FlatStyle.Flat;
            btnLogIn.ForeColor = SystemColors.ControlLightLight;
            btnLogIn.Location = new Point(174, 136);
            btnLogIn.Margin = new Padding(3, 4, 3, 4);
            btnLogIn.Name = "btnLogIn";
            btnLogIn.Size = new Size(250, 77);
            btnLogIn.TabIndex = 4;
            btnLogIn.Text = "LOG IN";
            btnLogIn.UseVisualStyleBackColor = false;
            btnLogIn.Click += btnLogIn_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(7, 29);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(160, 184);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnAdmin
            // 
            btnAdmin.Location = new Point(959, 549);
            btnAdmin.Margin = new Padding(3, 4, 3, 4);
            btnAdmin.Name = "btnAdmin";
            btnAdmin.Size = new Size(196, 217);
            btnAdmin.TabIndex = 2;
            btnAdmin.Text = "Admin Menu";
            btnAdmin.TextAlign = ContentAlignment.BottomCenter;
            btnAdmin.UseVisualStyleBackColor = true;
            btnAdmin.Click += btnAdmin_Click;
            // 
            // btnReports
            // 
            btnReports.Location = new Point(959, 294);
            btnReports.Margin = new Padding(3, 4, 3, 4);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(196, 224);
            btnReports.TabIndex = 1;
            btnReports.Text = "Reports";
            btnReports.TextAlign = ContentAlignment.BottomCenter;
            btnReports.UseVisualStyleBackColor = true;
            btnReports.Click += btnReports_Click;
            // 
            // btnPOS
            // 
            btnPOS.BackColor = Color.Transparent;
            btnPOS.BackgroundImage = Properties.Resources.cashier__3_;
            btnPOS.BackgroundImageLayout = ImageLayout.Zoom;
            btnPOS.Location = new Point(959, 48);
            btnPOS.Margin = new Padding(3, 4, 3, 4);
            btnPOS.Name = "btnPOS";
            btnPOS.Size = new Size(196, 221);
            btnPOS.TabIndex = 0;
            btnPOS.Text = "Point-of-Sales";
            btnPOS.TextAlign = ContentAlignment.BottomCenter;
            btnPOS.UseVisualStyleBackColor = false;
            btnPOS.Click += btnPOS_Click;
            // 
            // panelPOSLogin
            // 
            panelPOSLogin.BackColor = Color.Transparent;
            panelPOSLogin.Controls.Add(gbPOSLogin);
            panelPOSLogin.Location = new Point(346, 203);
            panelPOSLogin.Name = "panelPOSLogin";
            panelPOSLogin.Size = new Size(591, 389);
            panelPOSLogin.TabIndex = 6;
            panelPOSLogin.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImage = Properties.Resources._2788686;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1264, 848);
            Controls.Add(panelPOSLogin);
            Controls.Add(btnPOS);
            Controls.Add(btnReports);
            Controls.Add(btnAdmin);
            Controls.Add(lblAddress);
            Controls.Add(lblName);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EnchantedPOS";
            gbPOSLogin.ResumeLayout(false);
            gbPOSLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelPOSLogin.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private Label lblAddress;
        private GroupBox gbPOSLogin;
        private Label lblCashierPass;
        private Button btnLogIn;
        private PictureBox pictureBox1;
        private TextBox txtC_Pass;
        private Button btnAdmin;
        private Button btnReports;
        private Button btnPOS;
        private Button btnLogOut;
        private Panel panelPOSLogin;
    }
}
