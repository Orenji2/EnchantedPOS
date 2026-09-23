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
    public partial class formInventoryMode : Form
    {


        public formInventoryMode()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string barcode = txtProdCode.Text.Trim();

            if (string.IsNullOrWhiteSpace(barcode))
            {
                // MessageBox.Show("No item loaded to save.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtTotalStock.Text, out decimal newStock))
            {
                // MessageBox.Show("No valid calculated stock to save.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Direct UPDATE overriding the stock with the newly calculated total
            string updateQuery = "UPDATE PRODMAST SET STOCK = @newStock WHERE BARCODE = @barcode";

            using (MySqlConnection con = DatabaseConfig.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@newStock", newStock);
                    cmd.Parameters.AddWithValue("@barcode", barcode);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        // MessageBox.Show("Stock updated silently.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Reload the item to lock in the changes visually
                        LoadItemData(barcode);
                        txtInventoryCount.Clear();
                        txtBarcode.Focus();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating stock: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                txtBarcode.Clear();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Delete))
            {
                DialogResult confirm = MessageBox.Show(
                    "EXTREME DANGER: You are about to hard-reset the stock of EVERY SINGLE ITEM in the store to ZERO. \n\nAre you absolutely sure you want to wipe all inventory counts?",
                    "MASS INVENTORY WIPE",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Stop,
                    MessageBoxDefaultButton.Button2);

                if (confirm == DialogResult.Yes)
                {
                    DialogResult secondConfirm = MessageBox.Show(
                        "Final Confirmation: Clicking OK will ERASE ALL STOCK across the entire system. There is no undo.",
                        "NO UNDO",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Warning);

                    if (secondConfirm == DialogResult.OK)
                    {
                        string zeroAllQuery = "UPDATE PRODMAST SET STOCK = 0";

                        using (MySqlConnection con = DatabaseConfig.GetConnection())
                        {
                            using (MySqlCommand cmd = new MySqlCommand(zeroAllQuery, con))
                            {
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("All store inventory has been wiped to 0.", "Mass Reset Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    if (!string.IsNullOrWhiteSpace(txtBarcode.Text))
                                    {
                                        LoadItemData(txtBarcode.Text.Trim());
                                    }
                                    else
                                    {
                                        txtInventoryCount.Clear();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error wiping stock: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProdCode.Text))
            {
                // MessageBox.Show("Please load an item first.", "Missing Item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInventoryCount.Text = "0";
                
                // return;
            }

            if (!decimal.TryParse(txtInventoryCount.Text, out decimal adjustmentQty))
            {
                // MessageBox.Show("Please enter a valid number (e.g., 5 or -5).", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // return;
                txtInventoryCount.Text = "0";
            }

            decimal.TryParse(txtStoreStock.Text, out decimal currentStock);

            decimal newTotal = currentStock + adjustmentQty;
            txtTotalStock.Text = newTotal.ToString("0.###");

            btnSave.Focus();
        }

        private void LoadItemData(string barcode)
        {
            string query = "SELECT BARCODE, PROD_NAME, ALT_PROD_NAME, STOCK FROM PRODMAST WHERE BARCODE = @barcode";

            using (MySqlConnection con = DatabaseConfig.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@barcode", barcode);

                    try
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtProdCode.Text = reader["BARCODE"].ToString();
                                txtProdName.Text = reader["PROD_NAME"].ToString();
                                txtAltProdName.Text = reader["ALT_PROD_NAME"].ToString();


                                decimal currentStock = Convert.ToDecimal(reader["STOCK"] ?? 0);
                                txtStoreStock.Text = currentStock.ToString("0.###");
                                txtWHStock.Text = "0"; // Defaulting warehouse to 0 for now
                                txtTotalStock.Text = currentStock.ToString("0.###");
                            }
                            else
                            {
                                // Clear the fields if the barcode isn't found
                                txtProdCode.Clear();
                                txtProdName.Clear();
                                txtAltProdName.Clear();
                                txtStoreStock.Clear();
                                txtWHStock.Clear();
                                txtTotalStock.Clear();
                                MessageBox.Show("Item not found in the database.", "Unknown Barcode", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading item data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string barcode = txtBarcode.Text.Trim();
                if (!string.IsNullOrEmpty(barcode))
                {
                    LoadItemData(barcode);
                    txtInventoryCount.Focus();
                }

                btnEdit.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtInventoryCount.Focus();
        }

        private void txtInventoryCount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEnter.Focus();
            }
        }

        private void formInventoryMode_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtBarcode;
        }
    }
}
