using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EnchantedPOS
{
    public partial class formItemHistory : Form
    {
        private string itemBarcode;
        public formItemHistory(string barcode, string prodName)
        {
            InitializeComponent();
            itemBarcode = barcode;

            this.Text = $"Purchase History: {prodName} ({barcode})";

            string query = @"
                SELECT 
                    dh.DELIVERY_DATE AS 'Date Received',
                    s.SUPP_NAME AS 'Supplier',
                    dh.SUPP_INVOICE AS 'Invoice No.',
                    di.QTY AS 'Quantity',
                    di.UNIT_COST AS 'Unit Cost',
                    di.TOTAL_COST AS 'Total Cost'
                FROM DELIVERY_ITEMS di
                JOIN DELIVERY_HEADER dh ON di.DELIVERY_ID = dh.DELIVERY_ID
                LEFT JOIN SUPPLIER_MAST s ON dh.SUPP_ID = s.SUPP_ID
                WHERE di.BARCODE = @barcode
                ORDER BY dh.DELIVERY_DATE DESC";

            using (MySqlConnection con = DatabaseConfig.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@barcode", itemBarcode);

                    try
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            dgvHistory.DataSource = dt;
                            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            dgvHistory.ClearSelection();

                            if (dt.Rows.Count == 0)
                            {
                                MessageBox.Show("No purchase history found for this item.", "No Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading item history: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
