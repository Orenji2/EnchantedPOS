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
            txtC_Pass = new TextBox();
            lblCashierPass = new Label();
            btnLogIn = new Button();
            pictureBox1 = new PictureBox();
            lblDate = new Label();
            dateTimePicker = new DateTimePicker();
            lblShift = new Label();
            textBox1 = new TextBox();
            lblChange = new Label();
            txtChange = new TextBox();
            gbPOSLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI Black", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.Location = new Point(34, 334);
            lblName.Name = "lblName";
            lblName.Size = new Size(256, 37);
            lblName.TabIndex = 0;
            lblName.Text = "<Business Name>";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(45, 380);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(71, 15);
            lblAddress.TabIndex = 1;
            lblAddress.Text = "< Address >";
            // 
            // gbPOSLogin
            // 
            gbPOSLogin.Controls.Add(txtChange);
            gbPOSLogin.Controls.Add(lblChange);
            gbPOSLogin.Controls.Add(textBox1);
            gbPOSLogin.Controls.Add(lblShift);
            gbPOSLogin.Controls.Add(dateTimePicker);
            gbPOSLogin.Controls.Add(lblDate);
            gbPOSLogin.Controls.Add(txtC_Pass);
            gbPOSLogin.Controls.Add(lblCashierPass);
            gbPOSLogin.Controls.Add(btnLogIn);
            gbPOSLogin.Controls.Add(pictureBox1);
            gbPOSLogin.Location = new Point(389, 15);
            gbPOSLogin.Name = "gbPOSLogin";
            gbPOSLogin.Size = new Size(385, 254);
            gbPOSLogin.TabIndex = 2;
            gbPOSLogin.TabStop = false;
            gbPOSLogin.Text = "Point-of-Sales Log-In";
            // 
            // txtC_Pass
            // 
            txtC_Pass.Location = new Point(152, 40);
            txtC_Pass.Name = "txtC_Pass";
            txtC_Pass.Size = new Size(219, 23);
            txtC_Pass.TabIndex = 3;
            // 
            // lblCashierPass
            // 
            lblCashierPass.AutoSize = true;
            lblCashierPass.Location = new Point(152, 22);
            lblCashierPass.Name = "lblCashierPass";
            lblCashierPass.Size = new Size(110, 15);
            lblCashierPass.TabIndex = 2;
            lblCashierPass.Text = "Cashier's Password:";
            // 
            // btnLogIn
            // 
            btnLogIn.Location = new Point(270, 172);
            btnLogIn.Name = "btnLogIn";
            btnLogIn.Size = new Size(101, 58);
            btnLogIn.TabIndex = 1;
            btnLogIn.Text = "LOG IN";
            btnLogIn.UseVisualStyleBackColor = true;
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
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(152, 66);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(34, 15);
            lblDate.TabIndex = 4;
            lblDate.Text = "Date:";
            // 
            // dateTimePicker
            // 
            dateTimePicker.Format = DateTimePickerFormat.Short;
            dateTimePicker.Location = new Point(152, 84);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(110, 23);
            dateTimePicker.TabIndex = 5;
            // 
            // lblShift
            // 
            lblShift.AutoSize = true;
            lblShift.Location = new Point(278, 66);
            lblShift.Name = "lblShift";
            lblShift.Size = new Size(81, 15);
            lblShift.TabIndex = 6;
            lblShift.Text = "Shift Number:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(327, 84);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(44, 23);
            textBox1.TabIndex = 7;
            textBox1.Text = "1";
            // 
            // lblChange
            // 
            lblChange.AutoSize = true;
            lblChange.Location = new Point(152, 110);
            lblChange.Name = "lblChange";
            lblChange.Size = new Size(81, 15);
            lblChange.TabIndex = 8;
            lblChange.Text = "Change Fund:";
            // 
            // txtChange
            // 
            txtChange.Location = new Point(152, 128);
            txtChange.Name = "txtChange";
            txtChange.Size = new Size(219, 23);
            txtChange.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(800, 450);
            Controls.Add(gbPOSLogin);
            Controls.Add(lblAddress);
            Controls.Add(lblName);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Enchanted POS";
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
        private Label lblChange;
        private TextBox textBox1;
        private Label lblShift;
        private DateTimePicker dateTimePicker;
        private Label lblDate;
        private TextBox txtChange;
    }
}
