namespace EnchantedPOS
{
    partial class formProfitabilityReport
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
            dtpFrom = new DateTimePicker();
            dtpTo = new DateTimePicker();
            pbProfit = new ProgressBar();
            label1 = new Label();
            label2 = new Label();
            btnPrint = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // dtpFrom
            // 
            dtpFrom.Format = DateTimePickerFormat.Short;
            dtpFrom.Location = new Point(118, 22);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(247, 27);
            dtpFrom.TabIndex = 0;
            // 
            // dtpTo
            // 
            dtpTo.Format = DateTimePickerFormat.Short;
            dtpTo.Location = new Point(118, 55);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(247, 27);
            dtpTo.TabIndex = 1;
            // 
            // pbProfit
            // 
            pbProfit.Location = new Point(21, 88);
            pbProfit.Name = "pbProfit";
            pbProfit.Size = new Size(344, 29);
            pbProfit.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(53, 27);
            label1.Name = "label1";
            label1.Size = new Size(52, 20);
            label1.TabIndex = 3;
            label1.Text = "FROM:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(75, 60);
            label2.Name = "label2";
            label2.Size = new Size(30, 20);
            label2.TabIndex = 4;
            label2.Text = "TO:";
            // 
            // btnPrint
            // 
            btnPrint.BackColor = Color.DarkBlue;
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.ForeColor = Color.White;
            btnPrint.Location = new Point(21, 126);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(165, 43);
            btnPrint.TabIndex = 5;
            btnPrint.Text = "PRINT";
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += btnPrint_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.DarkBlue;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(200, 126);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(165, 43);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "CANCEL";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // formProfitabilityReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(381, 174);
            Controls.Add(btnCancel);
            Controls.Add(btnPrint);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pbProfit);
            Controls.Add(dtpTo);
            Controls.Add(dtpFrom);
            Name = "formProfitabilityReport";
            Text = "formProfitabilityReport";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtpFrom;
        private DateTimePicker dtpTo;
        private ProgressBar pbProfit;
        private Label label1;
        private Label label2;
        private Button btnPrint;
        private Button btnCancel;
    }
}