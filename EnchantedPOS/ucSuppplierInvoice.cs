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
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && dgvInvoice.ContainsFocus)
            {
                SendKeys.Send("{TAB}");
                return true;
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
            if(e.KeyCode == Keys.Enter)
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
    }
}
