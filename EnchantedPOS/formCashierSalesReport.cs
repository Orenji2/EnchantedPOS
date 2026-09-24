using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace EnchantedPOS
{
    public partial class formCashierSalesReport : Form
    {
        // Variables to hold the fetched data for printing
        private decimal reportTotalSales = 0m;
        private int reportTransactionCount = 0;
        private decimal reportVatableGross = 0m;
        private decimal reportVatExemptGross = 0m;
        private string reportStartInvoice = "N/A";
        private string reportEndInvoice = "N/A";

        public formCashierSalesReport()
        {
            InitializeComponent();
            LoadCashiers();
        }

        private void LoadCashiers()
        {
            string query = "SELECT USER_ID, F_NAME FROM LOGIN WHERE IS_CASHIER = 1";

            using (MySqlConnection con = DatabaseConfig.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    try
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            cmbCashier.DataSource = dt;
                            cmbCashier.DisplayMember = "F_NAME";
                            cmbCashier.ValueMember = "USER_ID";
                            cmbCashier.SelectedIndex = -1;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading cashiers: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // 1. Validation
            if (cmbCashier.SelectedValue == null)
            {
                MessageBox.Show("Please select a Cashier.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(cmbStation.Text))
            {
                MessageBox.Show("Please select a Station Number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtShift.Text, out int shiftNum))
            {
                MessageBox.Show("Please enter a valid Shift Number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Fetch Report Data
            int cashierId = Convert.ToInt32(cmbCashier.SelectedValue);
            DateTime reportDate = dtpDate.Value.Date;
            int stationNum = Convert.ToInt32(cmbStation.Text);

            string query = @"
                SELECT 
                    (SELECT COUNT(DISTINCT INVOICE) FROM REGISTER WHERE CASHIER_ID = @cashier AND SHIFT_NUM = @shift AND TRANS_DATE = @date AND STATION_NUM = @station) AS TotalTransactions,
                    (SELECT SUM(InvoiceTotal) FROM (SELECT MAX(GRAND_TOTAL) AS InvoiceTotal FROM REGISTER WHERE CASHIER_ID = @cashier AND SHIFT_NUM = @shift AND TRANS_DATE = @date AND STATION_NUM = @station GROUP BY INVOICE) AS SubT) AS TotalSales,
                    SUM(CASE WHEN NON_VAT = 0 THEN TOTAL_AMNT ELSE 0 END) AS VatableGross,
                    SUM(CASE WHEN NON_VAT = 1 THEN TOTAL_AMNT ELSE 0 END) AS VatExemptGross,
                    (SELECT MIN(INVOICE) FROM REGISTER WHERE CASHIER_ID = @cashier AND SHIFT_NUM = @shift AND TRANS_DATE = @date AND STATION_NUM = @station) AS StartInvoice,
                    (SELECT MAX(INVOICE) FROM REGISTER WHERE CASHIER_ID = @cashier AND SHIFT_NUM = @shift AND TRANS_DATE = @date AND STATION_NUM = @station) AS EndInvoice
                FROM REGISTER
                WHERE CASHIER_ID = @cashier 
                  AND SHIFT_NUM = @shift 
                  AND TRANS_DATE = @date 
                  AND STATION_NUM = @station";

            using (MySqlConnection con = DatabaseConfig.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@cashier", cashierId);
                    cmd.Parameters.AddWithValue("@shift", shiftNum);
                    cmd.Parameters.AddWithValue("@date", reportDate);
                    cmd.Parameters.AddWithValue("@station", stationNum);

                    try
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                reportTransactionCount = Convert.IsDBNull(reader["TotalTransactions"]) ? 0 : Convert.ToInt32(reader["TotalTransactions"]);
                                reportTotalSales = Convert.IsDBNull(reader["TotalSales"]) ? 0m : Convert.ToDecimal(reader["TotalSales"]);
                                reportVatableGross = Convert.IsDBNull(reader["VatableGross"]) ? 0m : Convert.ToDecimal(reader["VatableGross"]);
                                reportVatExemptGross = Convert.IsDBNull(reader["VatExemptGross"]) ? 0m : Convert.ToDecimal(reader["VatExemptGross"]);
                                reportStartInvoice = Convert.IsDBNull(reader["StartInvoice"]) ? "N/A" : reader["StartInvoice"].ToString();
                                reportEndInvoice = Convert.IsDBNull(reader["EndInvoice"]) ? "N/A" : reader["EndInvoice"].ToString();
                            }
                        }

                        if (reportTransactionCount == 0)
                        {
                            MessageBox.Show("No transactions found for the selected Cashier, Shift, and Station on this date.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        // 3. Trigger Print Preview
                        PrintDocument printDoc = new PrintDocument();
                        printDoc.PrintPage += PrintReportPage;

                        PrintPreviewDialog previewDialog = new PrintPreviewDialog { Document = printDoc, Width = 400, Height = 600 };
                        previewDialog.ShowDialog(this);

                        this.Close(); // Close parameter dialog after printing
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void PrintReportPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font fontRegular = new Font("Courier New", 8);
            Font fontBold = new Font("Courier New", 10, FontStyle.Bold);
            Brush brush = Brushes.Black;

            float yPos = 10;
            float leftMargin = 5;
            float centerMargin = 140;
            float rightMargin = 280;

            StringFormat centerAlign = new StringFormat() { Alignment = StringAlignment.Center };
            StringFormat rightAlign = new StringFormat() { Alignment = StringAlignment.Far };

            decimal vatableSales = Math.Round(reportVatableGross / 1.12m, 2, MidpointRounding.AwayFromZero);
            decimal vatAmount = reportVatableGross - vatableSales;

            g.DrawString("CASHIER'S SALES REPORT", fontBold, brush, centerMargin, yPos, centerAlign);
            yPos += 25;
            g.DrawString($"Date:    {dtpDate.Value.ToString("MM/dd/yyyy")}", fontRegular, brush, leftMargin, yPos);
            yPos += 15;
            g.DrawString($"Cashier: {cmbCashier.Text}", fontRegular, brush, leftMargin, yPos);
            yPos += 15;
            g.DrawString($"Shift:   {txtShift.Text}   Station: {cmbStation.Text}", fontRegular, brush, leftMargin, yPos);
            yPos += 15;
            g.DrawString($"Beg Inv: {reportStartInvoice}  End Inv: {reportEndInvoice}", fontRegular, brush, leftMargin, yPos);
            yPos += 20;
            g.DrawString(new string('-', 38), fontRegular, brush, leftMargin, yPos);
            yPos += 20;

            g.DrawString("Total Transactions:", fontRegular, brush, leftMargin, yPos);
            g.DrawString(reportTransactionCount.ToString(), fontRegular, brush, rightMargin, yPos, rightAlign);
            yPos += 15;

            g.DrawString("Gross Sales:", fontBold, brush, leftMargin, yPos);
            g.DrawString(reportTotalSales.ToString("N2"), fontBold, brush, rightMargin, yPos, rightAlign);
            yPos += 25;

            g.DrawString(new string('-', 15), fontRegular, brush, centerMargin, yPos, centerAlign);
            yPos += 10;
            g.DrawString("VAT BREAKDOWN", fontBold, brush, centerMargin, yPos, centerAlign);
            yPos += 20;

            g.DrawString("VATable Sales:", fontRegular, brush, leftMargin, yPos);
            g.DrawString(vatableSales.ToString("N2"), fontRegular, brush, rightMargin, yPos, rightAlign);
            yPos += 15;

            g.DrawString("VAT (12%):", fontRegular, brush, leftMargin, yPos);
            g.DrawString(vatAmount.ToString("N2"), fontRegular, brush, rightMargin, yPos, rightAlign);
            yPos += 15;

            g.DrawString("VAT Exempt Sales:", fontRegular, brush, leftMargin, yPos);
            g.DrawString(reportVatExemptGross.ToString("N2"), fontRegular, brush, rightMargin, yPos, rightAlign);
            yPos += 25;

            g.DrawString("END OF REPORT", fontBold, brush, centerMargin, yPos, centerAlign);
        }
    }
}