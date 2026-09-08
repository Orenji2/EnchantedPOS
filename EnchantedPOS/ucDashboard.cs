using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EnchantedPOS
{
    public partial class ucDashboard : UserControl
    {
        public ucDashboard()
        {
            InitializeComponent();
        }

        private void LoadDashboardStats()
        {
            string queryCost = "SELECT SUM(STOCK * COST) FROM PRODMAST WHERE STOCK > 0";
            string queryRetail = "SELECT SUM(STOCK * R_PRICE) FROM PRODMAST WHERE STOCK > 0";
            string queryLowStock = "SELECT COUNT(*) FROM PRODMAST WHERE STOCK > 0 AND STOCK <= 10";
            string queryTotalItems = "SELECT COUNT(*) FROM PRODMAST";


            using (MySqlConnection con = DatabaseConfig.GetConnection())
            {
                try
                {

                    // Execute Total Cost
                    using (MySqlCommand cmd = new MySqlCommand(queryCost, con))
                    {
                        object result = cmd.ExecuteScalar();
                        decimal totalCost = (result != DBNull.Value && result != null) ? Convert.ToDecimal(result) : 0m;
                        lblTotalCost.Text = "₱ " + totalCost.ToString("N2");
                    }

                    // Execute Total Retail Value
                    using (MySqlCommand cmd = new MySqlCommand(queryRetail, con))
                    {
                        object result = cmd.ExecuteScalar();
                        decimal totalRetail = (result != DBNull.Value && result != null) ? Convert.ToDecimal(result) : 0m;
                        lblTotalRetail.Text = "₱ " + totalRetail.ToString("N2");
                    }

                    // Execute Low Stock Count
                    using (MySqlCommand cmd = new MySqlCommand(queryLowStock, con))
                    {
                        object result = cmd.ExecuteScalar();
                        lblLowStock.Text = (result != DBNull.Value && result != null) ? result.ToString() + " Items" : "0 Items";
                    }

                    // Execute Total Product Count
                    using (MySqlCommand cmd = new MySqlCommand(queryTotalItems, con))
                    {
                        object result = cmd.ExecuteScalar();
                        lblTotalProducts.Text = (result != DBNull.Value && result != null) ? result.ToString() + " Unique SKUs" : "0 Unique SKUs";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load dashboard statistics: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ucDashboard_Load(object sender, EventArgs e)
        {
            LoadDashboardStats();
        }
    }

}
