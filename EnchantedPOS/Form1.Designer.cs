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
            gbPOSLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.BackColor = Color.Transparent;
            lblName.Font = new Font("Segoe UI Black", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.ForeColor = SystemColors.ControlLightLight;
            lblName.Location = new Point(34, 334);
            lblName.Name = "lblName";
            lblName.Size = new Size(256, 37);
            lblName.TabIndex = 0;
            lblName.Text = "<Business Name>";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.BackColor = Color.Transparent;
            lblAddress.ForeColor = SystemColors.ControlLightLight;
            lblAddress.Location = new Point(45, 380);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(71, 15);
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
            gbPOSLogin.Location = new Point(369, 141);
            gbPOSLogin.Name = "gbPOSLogin";
            gbPOSLogin.Size = new Size(385, 254);
            gbPOSLogin.TabIndex = 2;
            gbPOSLogin.TabStop = false;
            gbPOSLogin.Text = "Log-In";
            // 
            // btnLogOut
            // 
            btnLogOut.Enabled = false;
            btnLogOut.ForeColor = SystemColors.ActiveCaptionText;
            btnLogOut.Location = new Point(280, 166);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(91, 58);
            btnLogOut.TabIndex = 4;
            btnLogOut.Text = "LOG OUT";
            btnLogOut.UseVisualStyleBackColor = true;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // txtC_Pass
            // 
            txtC_Pass.Location = new Point(152, 64);
            txtC_Pass.Name = "txtC_Pass";
            txtC_Pass.Size = new Size(219, 25);
            txtC_Pass.TabIndex = 3;
            txtC_Pass.UseSystemPasswordChar = true;
            // 
            // lblCashierPass
            // 
            lblCashierPass.AutoSize = true;
            lblCashierPass.ForeColor = SystemColors.ControlLightLight;
            lblCashierPass.Location = new Point(152, 37);
            lblCashierPass.Name = "lblCashierPass";
            lblCashierPass.Size = new Size(119, 17);
            lblCashierPass.TabIndex = 2;
            lblCashierPass.Text = "Enter Access Code";
            // 
            // btnLogIn
            // 
            btnLogIn.BackColor = Color.ForestGreen;
            btnLogIn.FlatStyle = FlatStyle.Flat;
            btnLogIn.ForeColor = SystemColors.ControlLightLight;
            btnLogIn.Location = new Point(152, 102);
            btnLogIn.Name = "btnLogIn";
            btnLogIn.Size = new Size(219, 58);
            btnLogIn.TabIndex = 1;
            btnLogIn.Text = "LOG IN";
            btnLogIn.UseVisualStyleBackColor = false;
            btnLogIn.Click += btnLogIn_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(6, 22);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(140, 138);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnAdmin
            // 
            btnAdmin.Enabled = false;
            btnAdmin.Location = new Point(632, 485);
            btnAdmin.Name = "btnAdmin";
            btnAdmin.Size = new Size(122, 113);
            btnAdmin.TabIndex = 3;
            btnAdmin.Text = "Admin Menu";
            btnAdmin.TextAlign = ContentAlignment.BottomCenter;
            btnAdmin.UseVisualStyleBackColor = true;
            // 
            // btnReports
            // 
            btnReports.Enabled = false;
            btnReports.Location = new Point(503, 485);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(122, 113);
            btnReports.TabIndex = 4;
            btnReports.Text = "Reports";
            btnReports.TextAlign = ContentAlignment.BottomCenter;
            btnReports.UseVisualStyleBackColor = true;
            // 
            // btnPOS
            // 
            btnPOS.BackColor = Color.Transparent;
            btnPOS.BackgroundImage = Properties.Resources.cashier__3_;
            btnPOS.BackgroundImageLayout = ImageLayout.Zoom;
            btnPOS.Enabled = false;
            btnPOS.Location = new Point(375, 485);
            btnPOS.Name = "btnPOS";
            btnPOS.Size = new Size(122, 113);
            btnPOS.TabIndex = 5;
            btnPOS.Text = "Point-of-Sales";
            btnPOS.TextAlign = ContentAlignment.BottomCenter;
            btnPOS.UseVisualStyleBackColor = false;
            btnPOS.Click += btnPOS_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImage = Properties.Resources._2788686;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1106, 636);
            Controls.Add(btnPOS);
            Controls.Add(btnReports);
            Controls.Add(btnAdmin);
            Controls.Add(gbPOSLogin);
            Controls.Add(lblAddress);
            Controls.Add(lblName);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EnchantedPOS";
            gbPOSLogin.ResumeLayout(false);
            gbPOSLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
    }
}
