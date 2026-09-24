using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EnchantedPOS
{
    public partial class formReports : Form
    {
        public formReports()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCashierSales_Click(object sender, EventArgs e)
        {
            using (formCashierSalesReport cashierRep = new formCashierSalesReport())
            {
                cashierRep.ShowDialog(this);
            }
        }

        private void btnProfitabilityReport_Click(object sender, EventArgs e)
        {
            using (formProfitabilityReport profitReport = new formProfitabilityReport())
            {
                profitReport.ShowDialog(this);
            }
        }
    }
}
