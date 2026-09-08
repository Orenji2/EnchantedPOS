using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace EnchantedPOS
{
    public partial class ucProductMaster : UserControl
    {

        private bool isAdding = false;
        private bool isCalculating = false;
        public ucProductMaster()
        {
            InitializeComponent();

            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.ReadOnly = true;

            LoadProducts();
            ToggleEditMode(false);
        }

        private void ToggleEditMode(bool isEditing)
        {
            // Text buttons
            txtBarcode.Enabled = isEditing;
            txtProdName.Enabled = isEditing;
            txtAltProdName.Enabled = isEditing;
            txtItemPrice.Enabled = isEditing;
            txtItemCost.Enabled = isEditing;
            txtMarkPrice.Enabled = isEditing;
            txtMarkWholesale.Enabled = isEditing;
            txtMarkVip.Enabled = isEditing;
            txtMarkRoyal.Enabled = isEditing;

            // Action Buttons
            btnSave.Enabled = isEditing;
            btnDelete.Enabled = isEditing;
            btnCancel.Enabled = isEditing;

            // Entry Buttons
            btnAdd.Enabled = !isEditing;
            btnEdit.Enabled = !isEditing;

            cbIsNonVat.Enabled = isEditing;

            // Discounted Prices
            txtPriceWholesale.Enabled = isEditing;
            txtPriceVip.Enabled = isEditing;
            txtPriceRoyal.Enabled = isEditing;

        }

        private void ClearTextBoxes()
        {
            // Clear Identifiers
            txtBarcode.Clear();
            txtProdName.Clear();
            txtAltProdName.Clear();
            cbIsNonVat.Checked = false;

            // Clear Prices
            txtItemCost.Text = "0.00";
            txtItemPrice.Text = "0.00";
            txtPriceWholesale.Text = "0.00";
            txtPriceVip.Text = "0.00";
            txtPriceRoyal.Text = "0.00";

            //Clear Stock
            txtStoreStock.Text = "0";

            txtBarcode.Tag = null;
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void CalculateMarkups()
        {
            // 1. If the system is currently calculating the reverse math, STOP so we don't loop!
            if (isCalculating) return;

            decimal.TryParse(txtItemCost.Text, out decimal cost);

            if (cost <= 0)
            {
                // Lock the system while we update the textboxes
                isCalculating = true;

                txtMarkPrice.Text = "0.00";
                txtMarkWholesale.Text = "0.00";
                txtMarkVip.Text = "0.00";
                txtMarkRoyal.Text = "0.00";

                isCalculating = false; // Unlock
                return;
            }

            decimal.TryParse(txtItemPrice.Text, out decimal itemPrice);
            decimal.TryParse(txtPriceWholesale.Text, out decimal wholesale);
            decimal.TryParse(txtPriceVip.Text, out decimal vip);
            decimal.TryParse(txtPriceRoyal.Text, out decimal royal);

            decimal markupItem = ((itemPrice - cost) / cost) * 100;
            decimal markupWholesale = ((wholesale - cost) / cost) * 100;
            decimal markupVIP = ((vip - cost) / cost) * 100;
            decimal markupRoyal = ((royal - cost) / cost) * 100;

            // Lock the system while we write the new markups
            isCalculating = true;

            txtMarkPrice.Text = markupItem.ToString("N2");
            txtMarkWholesale.Text = markupWholesale.ToString("N2");
            txtMarkVip.Text = markupVIP.ToString("N2");
            txtMarkRoyal.Text = markupRoyal.ToString("N2");

            isCalculating = false; // Unlock
        }

        private void CalculatePricesFromMarkup()
        {
            // If the system is currently calculating the standard markups, STOP so we don't loop!
            if (isCalculating) return;

            decimal.TryParse(txtItemCost.Text, out decimal cost);
            if (cost <= 0) return; // Can't calculate a price from markup if there is no base cost

            decimal.TryParse(txtMarkPrice.Text, out decimal markItem);
            decimal.TryParse(txtMarkWholesale.Text, out decimal markWholesale);
            decimal.TryParse(txtMarkVip.Text, out decimal markVip);
            decimal.TryParse(txtMarkRoyal.Text, out decimal markRoyal);

            // Lock the system while we write the new prices
            isCalculating = true;

            txtItemPrice.Text = (cost + (cost * (markItem / 100))).ToString("N2");
            txtPriceWholesale.Text = (cost + (cost * (markWholesale / 100))).ToString("N2");
            txtPriceVip.Text = (cost + (cost * (markVip / 100))).ToString("N2");
            txtPriceRoyal.Text = (cost + (cost * (markRoyal / 100))).ToString("N2");

            isCalculating = false; // Unlock
        }


        private void LoadProducts()
        {
            string query = "SELECT PROD_ID, BARCODE, PROD_NAME, ALT_PROD_NAME, COST, R_PRICE, D_PRICE_A, D_PRICE_B, D_PRICE_C, STOCK, NON_VAT FROM PRODMAST";

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
                            dgvProducts.DataSource = dt;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading products: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAdding = true;
            ClearTextBoxes();
            ToggleEditMode(true);
            txtBarcode.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBarcode.Text))
            {
                MessageBox.Show("Please select a product from the list first.", "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            isAdding = false;
            ToggleEditMode(true);
            txtProdName.Focus();
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProducts.Rows[e.RowIndex];

                txtBarcode.Text = row.Cells["BARCODE"].Value?.ToString();
                txtProdName.Text = row.Cells["PROD_NAME"].Value?.ToString();
                txtAltProdName.Text = row.Cells["ALT_PROD_NAME"].Value?.ToString();
                txtItemCost.Text = row.Cells["COST"].Value?.ToString();
                txtItemPrice.Text = row.Cells["R_PRICE"].Value?.ToString();
                txtStoreStock.Text = row.Cells["STOCK"].Value?.ToString();
                txtPriceWholesale.Text = row.Cells["D_PRICE_A"].Value?.ToString();
                txtPriceVip.Text = row.Cells["D_PRICE_B"].Value?.ToString();
                txtPriceRoyal.Text = row.Cells["D_PRICE_C"].Value?.ToString();

                if (row.Cells["NON_VAT"].Value != DBNull.Value)
                {
                    cbIsNonVat.Checked = Convert.ToBoolean(row.Cells["NON_VAT"].Value);
                }

                txtBarcode.Tag = row.Cells["PROD_ID"].Value?.ToString();

                ToggleEditMode(false);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBarcode.Text) || string.IsNullOrWhiteSpace(txtProdName.Text))
            {
                MessageBox.Show("Barcode and Product Name are required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection con = DatabaseConfig.GetConnection())
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;

                decimal.TryParse(txtItemCost.Text, out decimal cost);
                decimal.TryParse(txtItemPrice.Text, out decimal price);
                decimal.TryParse(txtStoreStock.Text, out decimal stock);
                decimal.TryParse(txtPriceWholesale.Text, out decimal wholesale);
                decimal.TryParse(txtPriceVip.Text, out decimal vip);
                decimal.TryParse(txtPriceRoyal.Text, out decimal royal);

                cmd.Parameters.AddWithValue("@barcode", txtBarcode.Text.Trim());
                cmd.Parameters.AddWithValue("@name", txtProdName.Text.Trim());
                cmd.Parameters.AddWithValue("@altName", txtAltProdName.Text.Trim());
                cmd.Parameters.AddWithValue("@cost", cost);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@stock", stock);
                cmd.Parameters.AddWithValue("@nonVat", cbIsNonVat.Checked);
                cmd.Parameters.AddWithValue("@wholesale", wholesale);
                cmd.Parameters.AddWithValue("@vip", vip);
                cmd.Parameters.AddWithValue("@royal", royal);

                try
                {
                    if (isAdding)
                    {
                        // INSERT NEW ITEM
                        cmd.CommandText = @"INSERT INTO PRODMAST 
                                    (BARCODE, PROD_NAME, ALT_PROD_NAME, COST, R_PRICE, D_PRICE_A, D_PRICE_B, D_PRICE_C, STOCK, NON_VAT) 
                                    VALUES (@barcode, @name, @altName, @cost, @price, @wholesale, @vip, @royal, @stock, @nonVat)";
                    }
                    else
                    {
                        // UPDATE EXISTING ITEM
                        // We grab the PROD_ID that we secretly stored in the Tag property during the CellClick event
                        cmd.CommandText = @"UPDATE PRODMAST SET 
                                    BARCODE = @barcode, PROD_NAME = @name, ALT_PROD_NAME = @altName, 
                                    COST = @cost, R_PRICE = @price, D_PRICE_A = @wholesale, D_PRICE_B = @vip, D_PRICE_C = @royal, STOCK = @stock, NON_VAT = @nonVat 
                                    WHERE PROD_ID = @id";

                        cmd.Parameters.AddWithValue("@id", txtBarcode.Tag);
                    }

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    isAdding = false;
                    ToggleEditMode(false);
                    LoadProducts(); // Refresh the grid to show the new data!
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving product: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            isAdding = false;
            ClearTextBoxes();
            ToggleEditMode(false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtBarcode.Tag == null || string.IsNullOrWhiteSpace(txtBarcode.Tag.ToString()))
            {
                MessageBox.Show("Please select a product from the list to delete.", "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
            $"Are you sure you want to PERMANENTLY delete {txtProdName.Text}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Error);

            if (result == DialogResult.Yes)
            {
                using (MySqlConnection con = DatabaseConfig.GetConnection())
                {
                    string query = "DELETE FROM PRODMAST WHERE PROD_ID = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", txtBarcode.Tag.ToString());

                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Product deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Clean up the UI
                            ClearTextBoxes();
                            ToggleEditMode(false);
                            LoadProducts();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error deleting product: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void txtBarcode_Leave(object sender, EventArgs e)
        {
            if (!isAdding || string.IsNullOrWhiteSpace(txtBarcode.Text))
                return;

            string searchBarcode = txtBarcode.Text.Trim();
            string query = "SELECT * FROM PRODMAST WHERE BARCODE = @barcode LIMIT 1";

            using (MySqlConnection con = DatabaseConfig.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@barcode", searchBarcode);

                    try
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                MessageBox.Show("This product already exists!", "Duplicate Found", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                txtBarcode.Tag = reader["PROD_ID"].ToString();
                                txtProdName.Text = reader["PROD_NAME"].ToString();
                                txtAltProdName.Text = reader["ALT_PROD_NAME"].ToString();

                                txtItemCost.Text = reader["COST"].ToString();
                                txtItemPrice.Text = reader["R_PRICE"].ToString();
                                txtPriceWholesale.Text = reader["D_PRICE_A"].ToString();
                                txtPriceVip.Text = reader["D_PRICE_B"].ToString();
                                txtPriceRoyal.Text = reader["D_PRICE_C"].ToString();

                                txtStoreStock.Text = reader["STOCK"].ToString();

                                if (reader["NON_VAT"] != DBNull.Value)
                                    cbIsNonVat.Checked = Convert.ToBoolean(reader["NON_VAT"]);
                                else
                                    cbIsNonVat.Checked = false;

                                isAdding = false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error checking barcode: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtItemCost_TextChanged(object sender, EventArgs e)
        {
            CalculateMarkups();
        }

        private void txtMarkPrice_TextChanged(object sender, EventArgs e)
        {
            CalculatePricesFromMarkup();
        }
    }
}
