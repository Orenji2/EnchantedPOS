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
    public partial class ucSuppplierInvoice : UserControl
    {

        private bool isGridCalculating = false;

        public ucSuppplierInvoice()
        {
            InitializeComponent();

            dgvInvoice.EditMode = DataGridViewEditMode.EditOnEnter;
            ToggleUI(false);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && dgvInvoice.ContainsFocus)
            {
                if (dgvInvoice.CurrentCell != null)
                {
                    dgvInvoice.EndEdit();

                    int currentRow = dgvInvoice.CurrentCell.RowIndex;
                    string currentCol = dgvInvoice.Columns[dgvInvoice.CurrentCell.ColumnIndex].Name;

                    if (currentCol == "colBarcode")
                    {
                        dgvInvoice.CurrentCell = dgvInvoice.Rows[currentRow].Cells["colQty"];
                    }
                    else if (currentCol == "colQty")
                    {
                        dgvInvoice.CurrentCell = dgvInvoice.Rows[currentRow].Cells["colCost"];
                    }
                    else if (currentCol == "colCost")
                    {
                        if (currentRow + 1 < dgvInvoice.Rows.Count)
                        {
                            dgvInvoice.CurrentCell = dgvInvoice.Rows[currentRow + 1].Cells["colBarcode"];
                        }
                    }

                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txtSupplierCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string suppCode = txtSupplierCode.Text.Trim();
                if (string.IsNullOrWhiteSpace(suppCode)) return;

                string query = "SELECT SUPP_NAME, ADDRESS FROM SUPPLIER_MAST WHERE SUPP_ID = @id";

                using (MySqlConnection con = DatabaseConfig.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", suppCode);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtSupplierName.Text = reader["SUPP_NAME"].ToString();
                                txtSupplierAddress.Text = reader["ADDRESS"].ToString();
                                txtInvoiceNumber.Focus();
                            }
                            else
                            {
                                MessageBox.Show("Supplier Code not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtSupplierName.Clear();
                                txtSupplierAddress.Clear();
                            }
                        }
                    }
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void dgvInvoice_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || isGridCalculating) return;

            DataGridViewRow row = dgvInvoice.Rows[e.RowIndex];
            string colName = dgvInvoice.Columns[e.ColumnIndex].Name;

            isGridCalculating = true;

            try
            {
                if (colName == "colBarcode")
                {
                    string barcode = row.Cells["colBarcode"].Value?.ToString().Trim();

                    if (string.IsNullOrWhiteSpace(barcode)) return;

                    foreach (DataGridViewRow r in dgvInvoice.Rows)
                    {
                        if (r.Index != e.RowIndex && !r.IsNewRow && r.Cells["colBarcode"].Value?.ToString() == barcode)
                        {
                            MessageBox.Show("This item is already in the invoice. Please update the quantity of the existing line instead.", "Duplicate Item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            row.Cells["colBarcode"].Value = "";
                            return;
                        }
                    }

                    string query = "SELECT PROD_NAME, R_PRICE, COST FROM PRODMAST WHERE BARCODE = @barcode";
                    using (MySqlConnection con = DatabaseConfig.GetConnection())
                    {
                        using (MySqlCommand cmd = new MySqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@barcode", barcode);
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    row.Cells["colItemName"].Value = reader["PROD_NAME"].ToString();
                                    row.Cells["colUM"].Value = reader["R_PRICE"].ToString();
                                    row.Cells["colBaseCost"].Value = Convert.ToDecimal(reader["COST"]).ToString("F2");

                                    row.Cells["colQty"].Value = "1";
                                    row.Cells["colCost"].Value = row.Cells["ColBaseCost"].Value;
                                }
                                else
                                {
                                    MessageBox.Show($"Barcode '{barcode}' not found in the Product Master.", "Item Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    row.Cells["colBarcode"].Value = "";
                                }
                            }
                        }
                    }
                }

                if (colName == "colQty" || colName == "colCost" || colName == "colBarcode")
                {
                    if (row.Cells["colItemName"].Value != null && !string.IsNullOrWhiteSpace(row.Cells["colItemName"].Value.ToString()))
                    {
                        decimal.TryParse(row.Cells["colQty"].Value?.ToString(), out decimal qty);
                        decimal.TryParse(row.Cells["colCost"].Value?.ToString(), out decimal cost);

                        decimal amount = Math.Round(qty * cost, 2, MidpointRounding.AwayFromZero);
                        row.Cells["colAmount"].Value = amount > 0 ? amount.ToString("F2") : "";

                        UpdateGrandTotal();
                    }
                }
            }
            finally
            {
                isGridCalculating = false;
            }
        }

        private void ToggleUI(bool isAdding)
        {
            txtSupplierCode.Enabled = isAdding;
            txtInvoiceNumber.Enabled = isAdding;
            txtPONumber.Enabled = isAdding;
            dtpDate.Enabled = isAdding;
            dgvInvoice.Enabled = isAdding;
            btnSave.Enabled = isAdding;
            btnCancel.Enabled = isAdding;
            btnAdd.Enabled = !isAdding;
            btnExit.Enabled = !isAdding;
        }

        private void ClearFields()
        {
            txtSupplierCode.Clear();
            txtSupplierName.Clear();
            txtSupplierAddress.Clear();
            txtInvoiceNumber.Clear();
            txtPONumber.Clear();
            dtpDate.Value = DateTime.Now;

            dgvInvoice.Rows.Clear();
            if (txtGrandTotal != null) txtGrandTotal.Text = "0.00";
        }

        private void UpdateGrandTotal()
        {
            decimal grandTotal = 0m;

            foreach (DataGridViewRow row in dgvInvoice.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells["colAmount"].Value != null)
                {
                    string rawAmount = row.Cells["colAmount"].Value.ToString().Replace(",", "").Trim();

                    if (decimal.TryParse(rawAmount, out decimal amount))
                    {
                        grandTotal += amount;
                    }
                }
            }
            labellll.Text = grandTotal.ToString("N2");
        }

        private void dgvInvoice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtpDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPONumber.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtPONumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrWhiteSpace(txtPONumber.Text))
                {
                    txtPONumber.Text = "0";
                }

                dgvInvoice.Focus();

                if (dgvInvoice.Rows.Count > 0)
                {
                    dgvInvoice.CurrentCell = dgvInvoice.Rows[0].Cells["colBarcode"];
                }

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtInvoiceNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrWhiteSpace(txtInvoiceNumber.Text))
                {
                    MessageBox.Show("Please enter an Invoice Number before proceeding.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Stops the code here, keeping the cursor in this textbox
                }

                dtpDate.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearFields();
            ToggleUI(true);
            txtSupplierCode.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Are you sure you want to cancel this entry? All unsaved data will be lost.", "Cancel Entry", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                ClearFields();
                ToggleUI(false);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSupplierCode.Text) || string.IsNullOrWhiteSpace(txtSupplierName.Text))
            {
                MessageBox.Show("Please enter a valid Supplier Code.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSupplierCode.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtInvoiceNumber.Text))
            {
                MessageBox.Show("Please enter an Invoice Number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInvoiceNumber.Focus();
                return;
            }

            if (dgvInvoice.Rows.Count == 0 || (dgvInvoice.Rows.Count == 1 && dgvInvoice.Rows[0].IsNewRow))
            {
                MessageBox.Show("Please add at least one item to the invoice.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgvInvoice.Focus();
                return;
            }

            using (MySqlConnection con = DatabaseConfig.GetConnection())
            {
                using (MySqlTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        long newDeliveryId = 0;
                        string headerQuery = @"INSERT INTO DELIVERY_HEADER
                                                (SUPP_INVOICE, PO_NUMBER, SUPP_ID, DELIVERY_DATE, TOTAL_AMOUNT, RECEIVED_BY)
                                                VALUES (@invoice, @po, @suppId, @date, @total, @receivedBy);
                                                SELECT LAST_INSERT_ID();";

                        using (MySqlCommand headerCmd = new MySqlCommand(headerQuery, con, transaction))
                        {
                            headerCmd.Parameters.AddWithValue("@invoice", txtInvoiceNumber.Text.Trim());
                            headerCmd.Parameters.AddWithValue("@po", txtPONumber.Text.Trim());
                            headerCmd.Parameters.AddWithValue("@suppId", txtSupplierCode.Text.Trim());
                            headerCmd.Parameters.AddWithValue("@date", dtpDate.Value);

                            decimal.TryParse(txtGrandTotal.Text.Replace(",", ""), out decimal grandTotal);
                            headerCmd.Parameters.AddWithValue("@total", grandTotal);
                            headerCmd.Parameters.AddWithValue("@receivedBy", "Admin"); // Replace with actual login variable

                            newDeliveryId = Convert.ToInt64(headerCmd.ExecuteScalar());
                        }
                        string itemQuery = @"INSERT INTO DELIVERY_ITEMS 
                                     (DELIVERY_ID, BARCODE, PROD_NAME, QTY, UNIT_COST, TOTAL_COST) 
                                     VALUES (@delId, @barcode, @name, @qty, @cost, @total)";

                        string updateStockQuery = "UPDATE PRODMAST SET STOCK = STOCK + @qty WHERE BARCODE = @barcode";
                        using (MySqlCommand itemCmd = new MySqlCommand(itemQuery, con, transaction))
                        using (MySqlCommand stockCmd = new MySqlCommand(updateStockQuery, con, transaction))
                        {
                            foreach (DataGridViewRow row in dgvInvoice.Rows)
                            {
                                if (row.IsNewRow) continue;

                                string barcode = row.Cells["colBarcode"].Value?.ToString();
                                if (string.IsNullOrWhiteSpace(barcode)) continue;

                                decimal.TryParse(row.Cells["colQty"].Value?.ToString(), out decimal qty);
                                decimal.TryParse(row.Cells["colCost"].Value?.ToString(), out decimal cost);
                                decimal.TryParse(row.Cells["colAmount"].Value?.ToString(), out decimal total);

                                itemCmd.Parameters.Clear();
                                itemCmd.Parameters.AddWithValue("@delId", newDeliveryId);
                                itemCmd.Parameters.AddWithValue("@barcode", barcode);
                                itemCmd.Parameters.AddWithValue("@name", row.Cells["colItemName"].Value?.ToString());
                                itemCmd.Parameters.AddWithValue("@qty", qty);
                                itemCmd.Parameters.AddWithValue("@cost", cost);
                                itemCmd.Parameters.AddWithValue("@total", total);
                                itemCmd.ExecuteNonQuery();

                                stockCmd.Parameters.Clear();
                                stockCmd.Parameters.AddWithValue("@qty", qty);
                                stockCmd.Parameters.AddWithValue("@barcode", barcode);
                                stockCmd.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();

                        MessageBox.Show("Delivery posted and stock updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ClearFields();
                        ToggleUI(false);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Failed to post delivery. No stock was updated. Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
