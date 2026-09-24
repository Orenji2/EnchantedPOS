namespace EnchantedPOS
{
    partial class formCashierSalesReport
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
            cmbCashier = new ComboBox();
            label1 = new Label();
            dtpDate = new DateTimePicker();
            label2 = new Label();
            label3 = new Label();
            cmbStation = new ComboBox();
            label4 = new Label();
            txtShift = new TextBox();
            btnPrint = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // cmbCashier
            // 
            cmbCashier.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCashier.FormattingEnabled = true;
            cmbCashier.Location = new Point(74, 12);
            cmbCashier.Name = "cmbCashier";
            cmbCashier.Size = new Size(321, 28);
            cmbCashier.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 15);
            label1.Name = "label1";
            label1.Size = new Size(60, 20);
            label1.TabIndex = 1;
            label1.Text = "Cashier:";
            // 
            // dtpDate
            // 
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(74, 51);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(260, 27);
            dtpDate.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 51);
            label2.Name = "label2";
            label2.Size = new Size(44, 20);
            label2.TabIndex = 3;
            label2.Text = "Date:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 93);
            label3.Name = "label3";
            label3.Size = new Size(59, 20);
            label3.TabIndex = 4;
            label3.Text = "Station:";
            // 
            // cmbStation
            // 
            cmbStation.FormattingEnabled = true;
            cmbStation.Items.AddRange(new object[] { "1", "2", "3" });
            cmbStation.Location = new Point(74, 85);
            cmbStation.Name = "cmbStation";
            cmbStation.Size = new Size(111, 28);
            cmbStation.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 129);
            label4.Name = "label4";
            label4.Size = new Size(42, 20);
            label4.TabIndex = 6;
            label4.Text = "Shift:";
            // 
            // txtShift
            // 
            txtShift.Location = new Point(74, 122);
            txtShift.Name = "txtShift";
            txtShift.Size = new Size(78, 27);
            txtShift.TabIndex = 7;
            // 
            // btnPrint
            // 
            btnPrint.BackColor = Color.DarkBlue;
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.ForeColor = Color.White;
            btnPrint.Location = new Point(12, 163);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(187, 46);
            btnPrint.TabIndex = 8;
            btnPrint.Text = "PRINT";
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += btnPrint_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.DarkBlue;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(205, 163);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(199, 46);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "CANCEL";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // formCashierSalesReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(411, 221);
            Controls.Add(btnCancel);
            Controls.Add(btnPrint);
            Controls.Add(txtShift);
            Controls.Add(label4);
            Controls.Add(cmbStation);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dtpDate);
            Controls.Add(label1);
            Controls.Add(cmbCashier);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "formCashierSalesReport";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cashier Sales Report";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbCashier;
        private Label label1;
        private DateTimePicker dtpDate;
        private Label label2;
        private Label label3;
        private ComboBox cmbStation;
        private Label label4;
        private TextBox txtShift;
        private Button btnPrint;
        private Button btnCancel;
    }
}