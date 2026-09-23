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
    public partial class ucInventoryAdjustment : UserControl
    {
        public ucInventoryAdjustment()
        {
            InitializeComponent();
            LoadAdjustmentHistory();
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string barcode = txtBarcode.Text.Trim();
                if (string.IsNullOrWhiteSpace(barcode)) return;

                string query = "SELECT PROD_NAME, STOCK FROM PRODMAST WHERE BARCODE = @barcode";

                using (MySqlConnection con = DatabaseConfig.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@barcode", barcode);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtProdName.Text = reader["PROD_NAME"].ToString();
                                txtStock.Text = Convert.ToDecimal(reader["STOCK"]).ToString("0.###");
                                txtAdjQty.Focus();
                            }
                            else
                            {
                                MessageBox.Show("Barcode not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtBarcode.Clear();
                                txtProdName.Clear();
                                txtStock.Clear();
                            }
                        }
                    }
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Validation
            if (string.IsNullOrWhiteSpace(txtProdName.Text))
            {
                MessageBox.Show("Please scan a valid item first.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(cmbAdjType.Text))
            {
                MessageBox.Show("Please select an Adjustment Type.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(txtAdjQty.Text, out decimal inputQty) || inputQty <= 0)
            {
                MessageBox.Show("Please enter a valid quantity greater than zero.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Determine Math (Add or Subtract)
            decimal finalAdjQty = (cmbAdjType.Text == "Correction (Add)") ? inputQty : -inputQty;

            using (MySqlConnection con = DatabaseConfig.GetConnection())
            {
                using (MySqlTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        string logQuery = @"INSERT INTO INVENTORY_ADJUSTMENTS 
                                  (ADJ_DATE, BARCODE, PROD_NAME, ADJ_QTY, ADJ_TYPE, REMARKS, ADJUSTED_BY) 
                                  VALUES (NOW(), @barcode, @name, @qty, @type, @remarks, @admin)";

                        using (MySqlCommand logCmd = new MySqlCommand(logQuery, con, transaction))
                        {
                            logCmd.Parameters.AddWithValue("@barcode", txtBarcode.Text.Trim());
                            logCmd.Parameters.AddWithValue("@name", txtProdName.Text.Trim());
                            logCmd.Parameters.AddWithValue("@qty", finalAdjQty); // Saves as negative if damaged
                            logCmd.Parameters.AddWithValue("@type", cmbAdjType.Text);
                            logCmd.Parameters.AddWithValue("@remarks", txtRemarks.Text.Trim());
                            logCmd.Parameters.AddWithValue("@admin", "Admin"); // Replace with actual login
                            logCmd.ExecuteNonQuery();
                        }

                        string stockQuery = "UPDATE PRODMAST SET STOCK = STOCK + @qty WHERE BARCODE = @barcode";
                        using (MySqlCommand stockCmd = new MySqlCommand(stockQuery, con, transaction))
                        {
                            stockCmd.Parameters.AddWithValue("@qty", finalAdjQty);
                            stockCmd.Parameters.AddWithValue("@barcode", txtBarcode.Text.Trim());
                            stockCmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Inventory successfully adjusted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadAdjustmentHistory();

                        txtBarcode.Clear();
                        txtProdName.Clear();
                        txtStock.Clear();
                        txtAdjQty.Clear();
                        txtRemarks.Clear();
                        cmbAdjType.SelectedIndex = -1;
                        txtBarcode.Focus();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Failed to adjust inventory: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LoadAdjustmentHistory()
        {
            try
            {
                string query = "SELECT ADJ_DATE, BARCODE, PROD_NAME, ADJ_QTY, ADJ_TYPE, REMARKS, ADJUSTED_BY FROM INVENTORY_ADJUSTMENTS ORDER BY ADJ_DATE DESC LIMIT 50";

                using (MySqlConnection con = DatabaseConfig.GetConnection())
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvRecentAdjustments.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading adjustment history: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
