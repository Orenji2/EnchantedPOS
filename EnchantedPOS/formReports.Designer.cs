namespace EnchantedPOS
{
    partial class formReports
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
            btnSalesReport = new Button();
            btnSummarySales = new Button();
            btnCashierSales = new Button();
            btnXReading = new Button();
            btnFromToReading = new Button();
            btnZReading = new Button();
            btnQuit = new Button();
            btnProfitabilityReport = new Button();
            SuspendLayout();
            // 
            // btnSalesReport
            // 
            btnSalesReport.BackColor = Color.DarkBlue;
            btnSalesReport.FlatStyle = FlatStyle.Flat;
            btnSalesReport.ForeColor = Color.White;
            btnSalesReport.Location = new Point(12, 24);
            btnSalesReport.Name = "btnSalesReport";
            btnSalesReport.Size = new Size(208, 71);
            btnSalesReport.TabIndex = 0;
            btnSalesReport.Text = "SALES REPORT";
            btnSalesReport.UseVisualStyleBackColor = false;
            // 
            // btnSummarySales
            // 
            btnSummarySales.BackColor = Color.DarkBlue;
            btnSummarySales.FlatStyle = FlatStyle.Flat;
            btnSummarySales.ForeColor = Color.White;
            btnSummarySales.Location = new Point(12, 101);
            btnSummarySales.Name = "btnSummarySales";
            btnSummarySales.Size = new Size(208, 73);
            btnSummarySales.TabIndex = 1;
            btnSummarySales.Text = "SUMMARY OF SALES REPORT";
            btnSummarySales.UseVisualStyleBackColor = false;
            // 
            // btnCashierSales
            // 
            btnCashierSales.BackColor = Color.DarkBlue;
            btnCashierSales.FlatStyle = FlatStyle.Flat;
            btnCashierSales.ForeColor = Color.White;
            btnCashierSales.Location = new Point(12, 180);
            btnCashierSales.Name = "btnCashierSales";
            btnCashierSales.Size = new Size(208, 70);
            btnCashierSales.TabIndex = 2;
            btnCashierSales.Text = "CASHIER'S SALES REPORT";
            btnCashierSales.UseVisualStyleBackColor = false;
            btnCashierSales.Click += btnCashierSales_Click;
            // 
            // btnXReading
            // 
            btnXReading.BackColor = Color.DarkBlue;
            btnXReading.FlatStyle = FlatStyle.Flat;
            btnXReading.ForeColor = Color.White;
            btnXReading.Location = new Point(12, 256);
            btnXReading.Name = "btnXReading";
            btnXReading.Size = new Size(208, 69);
            btnXReading.TabIndex = 3;
            btnXReading.Text = "X-READING";
            btnXReading.UseVisualStyleBackColor = false;
            // 
            // btnFromToReading
            // 
            btnFromToReading.BackColor = Color.DarkBlue;
            btnFromToReading.FlatStyle = FlatStyle.Flat;
            btnFromToReading.ForeColor = Color.White;
            btnFromToReading.Location = new Point(12, 331);
            btnFromToReading.Name = "btnFromToReading";
            btnFromToReading.Size = new Size(208, 67);
            btnFromToReading.TabIndex = 4;
            btnFromToReading.Text = "FROM-TO X/Z READING";
            btnFromToReading.UseVisualStyleBackColor = false;
            // 
            // btnZReading
            // 
            btnZReading.BackColor = Color.DarkBlue;
            btnZReading.FlatStyle = FlatStyle.Flat;
            btnZReading.ForeColor = Color.White;
            btnZReading.Location = new Point(12, 404);
            btnZReading.Name = "btnZReading";
            btnZReading.Size = new Size(208, 69);
            btnZReading.TabIndex = 5;
            btnZReading.Text = "Z-READING";
            btnZReading.UseVisualStyleBackColor = false;
            // 
            // btnQuit
            // 
            btnQuit.BackColor = Color.DarkBlue;
            btnQuit.FlatStyle = FlatStyle.Flat;
            btnQuit.ForeColor = Color.White;
            btnQuit.Location = new Point(12, 558);
            btnQuit.Name = "btnQuit";
            btnQuit.Size = new Size(208, 62);
            btnQuit.TabIndex = 6;
            btnQuit.Text = "QUIT PROGRAM";
            btnQuit.UseVisualStyleBackColor = false;
            btnQuit.Click += btnQuit_Click;
            // 
            // btnProfitabilityReport
            // 
            btnProfitabilityReport.BackColor = Color.DarkBlue;
            btnProfitabilityReport.FlatStyle = FlatStyle.Flat;
            btnProfitabilityReport.ForeColor = Color.White;
            btnProfitabilityReport.Location = new Point(12, 479);
            btnProfitabilityReport.Name = "btnProfitabilityReport";
            btnProfitabilityReport.Size = new Size(208, 69);
            btnProfitabilityReport.TabIndex = 7;
            btnProfitabilityReport.Text = "PROFITABILITY REPORT";
            btnProfitabilityReport.UseVisualStyleBackColor = false;
            btnProfitabilityReport.Click += btnProfitabilityReport_Click;
            // 
            // formReports
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(232, 637);
            Controls.Add(btnProfitabilityReport);
            Controls.Add(btnQuit);
            Controls.Add(btnZReading);
            Controls.Add(btnFromToReading);
            Controls.Add(btnXReading);
            Controls.Add(btnCashierSales);
            Controls.Add(btnSummarySales);
            Controls.Add(btnSalesReport);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "formReports";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "formReports";
            ResumeLayout(false);
        }

        #endregion

        private Button btnSalesReport;
        private Button btnSummarySales;
        private Button btnCashierSales;
        private Button btnXReading;
        private Button btnFromToReading;
        private Button btnZReading;
        private Button btnQuit;
        private Button btnProfitabilityReport;
    }
}