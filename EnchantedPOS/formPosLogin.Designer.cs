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
            dateTrans = new DateTimePicker();
            txtShiftNumber = new TextBox();
            txtChangeFunds = new TextBox();
            btnLogin2 = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // labelChangeFunds
            // 
            labelChangeFunds.AutoSize = true;
            labelChangeFunds.Location = new Point(8, 160);
            labelChangeFunds.Name = "labelChangeFunds";
            labelChangeFunds.Size = new Size(104, 20);
            labelChangeFunds.TabIndex = 0;
            labelChangeFunds.Text = "Change Funds:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(67, 84);
            label1.Name = "label1";
            label1.Size = new Size(44, 20);
            label1.TabIndex = 1;
            label1.Text = "Date:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 125);
            label2.Name = "label2";
            label2.Size = new Size(100, 20);
            label2.TabIndex = 2;
            label2.Text = "Shift Number:";
            // 
            // labelWelcome
            // 
            labelWelcome.AutoSize = true;
            labelWelcome.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelWelcome.Location = new Point(8, 12);
            labelWelcome.Name = "labelWelcome";
            labelWelcome.Size = new Size(224, 50);
            labelWelcome.TabIndex = 3;
            labelWelcome.Text = "<Welcome>";
            // 
            // dateTrans
            // 
            dateTrans.Format = DateTimePickerFormat.Short;
            dateTrans.ImeMode = ImeMode.NoControl;
            dateTrans.Location = new Point(135, 76);
            dateTrans.Margin = new Padding(3, 4, 3, 4);
            dateTrans.Name = "dateTrans";
            dateTrans.Size = new Size(198, 27);
            dateTrans.TabIndex = 0;
            dateTrans.ValueChanged += dateTimePicker_ValueChanged;
            dateTrans.KeyDown += dateTrans_KeyDown;
            // 
            // txtShiftNumber
            // 
            txtShiftNumber.AcceptsReturn = true;
            txtShiftNumber.Location = new Point(135, 115);
            txtShiftNumber.Margin = new Padding(3, 4, 3, 4);
            txtShiftNumber.Name = "txtShiftNumber";
            txtShiftNumber.Size = new Size(83, 27);
            txtShiftNumber.TabIndex = 1;
            txtShiftNumber.Text = "1";
            txtShiftNumber.TextChanged += textBox1_TextChanged;
            txtShiftNumber.KeyDown += txtShiftNumber_KeyDown;
            // 
            // txtChangeFunds
            // 
            txtChangeFunds.AcceptsReturn = true;
            txtChangeFunds.Location = new Point(135, 153);
            txtChangeFunds.Margin = new Padding(3, 4, 3, 4);
            txtChangeFunds.Name = "txtChangeFunds";
            txtChangeFunds.Size = new Size(161, 27);
            txtChangeFunds.TabIndex = 2;
            txtChangeFunds.Text = "0";
            txtChangeFunds.KeyDown += txtChangeFunds_KeyDown;
            // 
            // btnLogin2
            // 
            btnLogin2.Location = new Point(195, 200);
            btnLogin2.Margin = new Padding(3, 4, 3, 4);
            btnLogin2.Name = "btnLogin2";
            btnLogin2.Size = new Size(135, 69);
            btnLogin2.TabIndex = 3;
            btnLogin2.Text = "LOG-IN";
            btnLogin2.UseVisualStyleBackColor = true;
            btnLogin2.Click += btnLogin2_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(54, 200);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(135, 69);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "CANCEL";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // formPosLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(342, 285);
            ControlBox = false;
            Controls.Add(btnCancel);
            Controls.Add(btnLogin2);
            Controls.Add(txtChangeFunds);
            Controls.Add(txtShiftNumber);
            Controls.Add(dateTrans);
            Controls.Add(labelWelcome);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(labelChangeFunds);
            Margin = new Padding(3, 4, 3, 4);
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
        private DateTimePicker dateTrans;
        private TextBox txtShiftNumber;
        private TextBox txtChangeFunds;
        private Button btnLogin2;
        private Button btnCancel;
    }
}