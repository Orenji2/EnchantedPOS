namespace EnchantedPOS
{
    partial class formPosLogin
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
            labelChangeFunds = new Label();
            label1 = new Label();
            label2 = new Label();
            labelWelcome = new Label();
            dateTimePicker = new DateTimePicker();
            txtShiftNumber = new TextBox();
            txtChangeFunds = new TextBox();
            btnLogin2 = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // labelChangeFunds
            // 
            labelChangeFunds.AutoSize = true;
            labelChangeFunds.Location = new Point(7, 120);
            labelChangeFunds.Name = "labelChangeFunds";
            labelChangeFunds.Size = new Size(86, 15);
            labelChangeFunds.TabIndex = 0;
            labelChangeFunds.Text = "Change Funds:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(59, 63);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 1;
            label1.Text = "Date:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 94);
            label2.Name = "label2";
            label2.Size = new Size(81, 15);
            label2.TabIndex = 2;
            label2.Text = "Shift Number:";
            // 
            // labelWelcome
            // 
            labelWelcome.AutoSize = true;
            labelWelcome.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelWelcome.Location = new Point(7, 9);
            labelWelcome.Name = "labelWelcome";
            labelWelcome.Size = new Size(175, 40);
            labelWelcome.TabIndex = 3;
            labelWelcome.Text = "<Welcome>";
            // 
            // dateTimePicker
            // 
            dateTimePicker.Format = DateTimePickerFormat.Short;
            dateTimePicker.ImeMode = ImeMode.NoControl;
            dateTimePicker.Location = new Point(118, 57);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(174, 23);
            dateTimePicker.TabIndex = 4;
            // 
            // txtShiftNumber
            // 
            txtShiftNumber.AcceptsReturn = true;
            txtShiftNumber.Location = new Point(118, 86);
            txtShiftNumber.Name = "txtShiftNumber";
            txtShiftNumber.Size = new Size(73, 23);
            txtShiftNumber.TabIndex = 5;
            txtShiftNumber.Text = "1";
            txtShiftNumber.TextChanged += textBox1_TextChanged;
            // 
            // txtChangeFunds
            // 
            txtChangeFunds.AcceptsReturn = true;
            txtChangeFunds.Location = new Point(118, 115);
            txtChangeFunds.Name = "txtChangeFunds";
            txtChangeFunds.Size = new Size(141, 23);
            txtChangeFunds.TabIndex = 6;
            txtChangeFunds.Text = "0";
            // 
            // btnLogin2
            // 
            btnLogin2.Location = new Point(171, 150);
            btnLogin2.Name = "btnLogin2";
            btnLogin2.Size = new Size(118, 52);
            btnLogin2.TabIndex = 7;
            btnLogin2.Text = "LOG-IN";
            btnLogin2.UseVisualStyleBackColor = true;
            btnLogin2.Click += btnLogin2_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(47, 150);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(118, 52);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "CANCEL";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // formPosLogin
            // 
            AcceptButton = btnLogin2;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(299, 214);
            ControlBox = false;
            Controls.Add(btnCancel);
            Controls.Add(btnLogin2);
            Controls.Add(txtChangeFunds);
            Controls.Add(txtShiftNumber);
            Controls.Add(dateTimePicker);
            Controls.Add(labelWelcome);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(labelChangeFunds);
            Name = "formPosLogin";
            Text = "POS Login";
            Load += formPosLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelChangeFunds;
        private Label label1;
        private Label label2;
        private Label labelWelcome;
        private DateTimePicker dateTimePicker;
        private TextBox txtShiftNumber;
        private TextBox txtChangeFunds;
        private Button btnLogin2;
        private Button btnCancel;
    }
}