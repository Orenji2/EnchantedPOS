using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace EnchantedPOS
{
    public partial class formProfitabilityReport : Form
    {
        private DataTable reportData;
        private decimal grandTotalCost = 0m;
        private decimal grandTotalSales = 0m;
        private decimal grandTotalProfit = 0m;

        // Tracks pagination across multiple A4 pages
        private int currentRowIndex = 0;

        public formProfitabilityReport()
        {
            InitializeComponent();

            // Set defaults: First day of the current month to Today
            dtpFrom.Value = DateTime.Now.Date;
            dtpTo.Value = DateTime.Now.Date;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dtpFrom.Value.Date > dtpTo.Value.Date)
            {
                MessageBox.Show("The 'From' date cannot be later than the 'To' date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Reset totals & pagination before each print
            grandTotalCost = 0m;
            grandTotalSales = 0m;
            grandTotalProfit = 0m;
            currentRowIndex = 0;
            reportData = new DataTable();

            // Joined with LOGIN table to fetch the cashier's name
            string query = @"
                SELECT 
                    IFNULL(l.F_NAME, 'Unknown') AS CashierName,
                    r.INVOICE AS InvoiceNo, 
                    (r.QTY * IFNULL(p.COST, 0)) AS TotalCost,
                    r.TOTAL_AMNT AS TotalSales,
                    (r.TOTAL_AMNT - (r.QTY * IFNULL(p.COST, 0))) AS Profit
                FROM REGISTER r
                LEFT JOIN PRODMAST p ON r.BAR_CODE = p.BARCODE
                LEFT JOIN LOGIN l ON r.CASHIER_ID = l.USER_ID
                WHERE DATE(r.TRANS_DATE) >= @fromDate AND DATE(r.TRANS_DATE) <= @toDate
                ORDER BY r.TRANS_DATE ASC, r.INVOICE ASC";

            using (MySqlConnection con = DatabaseConfig.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@fromDate", dtpFrom.Value.Date);
                    cmd.Parameters.AddWithValue("@toDate", dtpTo.Value.Date);

                    try
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(reportData);
                        }

                        if (reportData.Rows.Count == 0)
                        {
                            MessageBox.Show("No sales found within the selected date range.", "Empty Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        pbProfit.Minimum = 0;
                        pbProfit.Value = 0;
                        pbProfit.Maximum = reportData.Rows.Count;

                        foreach (DataRow row in reportData.Rows)
                        {
                            grandTotalCost += Convert.ToDecimal(row["TotalCost"]);
                            grandTotalSales += Convert.ToDecimal(row["TotalSales"]);
                            grandTotalProfit += Convert.ToDecimal(row["Profit"]);
                        }

                        // Configure for Standard A4 Paper size (827 x 1169 hundredths of an inch)
                        PrintDocument printDoc = new PrintDocument();
                        printDoc.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);
                        printDoc.PrintPage += PrintReportPage;

                        PrintPreviewDialog previewDialog = new PrintPreviewDialog { Document = printDoc, Width = 800, Height = 800 };
                        previewDialog.ShowDialog(this);

                        this.Close();
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
            Font fontRegular = new Font("Courier New", 10);
            Font fontBold = new Font("Courier New", 11, FontStyle.Bold);
            Font fontHeader = new Font("Courier New", 14, FontStyle.Bold);
            Brush brush = Brushes.Black;

            // A4 Document Dimensions
            float yPos = 50;
            float leftMargin = 50;
            float rightMargin = 770;
            float pageBottom = e.PageBounds.Height - 80;

            // Column X-Coordinates for A4
            float colCashier = leftMargin;
            float colInvoice = 250;
            float colCost = 480;
            float colSales = 620;
            float colProfit = 770;

            StringFormat centerAlign = new StringFormat() { Alignment = StringAlignment.Center };
            StringFormat rightAlign = new StringFormat() { Alignment = StringAlignment.Far };

            // Only print the header on the very first page
            if (currentRowIndex == 0)
            {
                g.DrawString("SALES PROFITABILITY REPORT", fontHeader, brush, e.PageBounds.Width / 2, yPos, centerAlign);
                yPos += 25;
                g.DrawString($"From: {dtpFrom.Value.ToString("MM/dd/yyyy")}   To: {dtpTo.Value.ToString("MM/dd/yyyy")}", fontRegular, brush, e.PageBounds.Width / 2, yPos, centerAlign);
                yPos += 35;

                g.DrawString("CASHIER", fontBold, brush, colCashier, yPos);
                g.DrawString("INVOICE", fontBold, brush, colInvoice, yPos);
                g.DrawString("COST", fontBold, brush, colCost, yPos, rightAlign);
                g.DrawString("SALES", fontBold, brush, colSales, yPos, rightAlign);
                g.DrawString("PROFIT", fontBold, brush, colProfit, yPos, rightAlign);
                yPos += 20;

                g.DrawLine(Pens.Black, leftMargin, yPos, rightMargin, yPos);
                yPos += 15;
            }

            // --- ITEM BREAKDOWN (Paginated Loop) ---
            while (currentRowIndex < reportData.Rows.Count)
            {
                DataRow row = reportData.Rows[currentRowIndex];

                string cashier = row["CashierName"].ToString();
                string inv = row["InvoiceNo"].ToString();
                decimal tCost = Convert.ToDecimal(row["TotalCost"]);
                decimal tSales = Convert.ToDecimal(row["TotalSales"]);
                decimal profit = Convert.ToDecimal(row["Profit"]);

                g.DrawString(cashier, fontRegular, brush, colCashier, yPos);
                g.DrawString(inv, fontRegular, brush, colInvoice, yPos);
                g.DrawString(tCost.ToString("N2"), fontRegular, brush, colCost, yPos, rightAlign);
                g.DrawString(tSales.ToString("N2"), fontRegular, brush, colSales, yPos, rightAlign);
                g.DrawString(profit.ToString("N2"), fontRegular, brush, colProfit, yPos, rightAlign);

                yPos += 20;
                currentRowIndex++;

                pbProfit.Value = currentRowIndex;
                Application.DoEvents();

                // Check if we hit the bottom of the A4 page
                if (yPos >= pageBottom)
                {
                    e.HasMorePages = true;
                    return; // Pause the loop and trigger a new page
                }
            }

            // --- GRAND TOTALS (Prints only on the final page) ---
            yPos += 10;
            g.DrawLine(Pens.Black, leftMargin, yPos, rightMargin, yPos);
            yPos += 20;

            g.DrawString("GRAND TOTALS", fontBold, brush, colInvoice, yPos);
            g.DrawString(grandTotalCost.ToString("N2"), fontBold, brush, colCost, yPos, rightAlign);
            g.DrawString(grandTotalSales.ToString("N2"), fontBold, brush, colSales, yPos, rightAlign);
            g.DrawString(grandTotalProfit.ToString("N2"), fontBold, brush, colProfit, yPos, rightAlign);

            yPos += 40;
            g.DrawString("END OF REPORT", fontBold, brush, e.PageBounds.Width / 2, yPos, centerAlign);

            e.HasMorePages = false; // Tells the printer it is officially finished
        }
    }
}