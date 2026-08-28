using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace EnchantedPOS
{
    public partial class formPOS : Form
    {


        public formPOS()
        {
            InitializeComponent();



            this.KeyPreview = true;
        }

        private bool isRecalculating = false;



        private string GetConnectionString()
        {
            // Reference to the directory of the exe file
            string exeFolder = AppDomain.CurrentDomain.BaseDirectory;

            // Reference to the Path of the Database
            string dbPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(exeFolder, @"..\..\..\dbEn.accdb"));

            // Access uses an OLEDB provider pointing directly to your local file
            return $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbPath};";
        }



        private void formPOS_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void btnReprint_Click(object sender, EventArgs e)
        {

        }

        private void formPOS_Load(object sender, EventArgs e)
        {
            // this.Focus();
            txtBarcode.Focus();
            this.dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
        }

        private void setupDataGridView()
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void formPOS_KeyDown(object sender, KeyEventArgs e)
        {

            // Press "/" for Quantity
            if (e.KeyCode == Keys.Divide)
            {
                txtQty.Enabled = true;
                txtQty.Focus();
                txtQty.SelectAll();


                e.Handled = true;
                e.SuppressKeyPress = true;
            }

            // Press F2 to Edit or Void
            if (e.KeyCode == Keys.F2)
            {
                DialogResult result = MessageBox.Show(
                    "Press 'Yes' to EDIT the transaction (Discount/Price).\nPress 'No' to VOID (Clear all items).\nPress 'Cancel' to return.",
            "Edit or Void",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No) //void 
                {
                    dataGridView1.Rows.Clear();
                    UpdateTotalAmount();
                    txtBarcode.Focus();
                }
                else if (result == DialogResult.Yes)  //Edit
                {
                    //Turn off the datagrid read only mode
                    dataGridView1.ReadOnly = false;

                    // Only disc and price will be editable by loop
                    foreach (DataGridViewColumn col in dataGridView1.Columns)
                    {
                        if (col.Name == "disc" || col.Name == "srp")
                        {
                            col.ReadOnly = false;
                            col.DefaultCellStyle.BackColor = Color.LightYellow; // Highlight editable cells
                        }
                        else
                        {
                            col.ReadOnly = true;
                        }
                    }
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.F1)
            {
                // Lock the DataGrid 
                dataGridView1.ReadOnly = true;

                //Reset the Background
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    col.ReadOnly = true;
                    col.DefaultCellStyle.BackColor = Color.White; // Changes the color back to white
                }

                //Return the focus to the Barcode
                txtBarcode.Focus();

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            
        }

        private void UpdateTotalAmount()
        {
            decimal totalAmount = 0m;

            //Loop through every row in the DataGridView
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                // Make sure the cell isn't empty before trying to add it
                if (row.Cells["amnt"].Value != null)
                {
                    string rawAmount = row.Cells["amnt"].Value.ToString().Replace("%", "").Replace(",", "").Trim();

                    if (decimal.TryParse(rawAmount, out decimal amount))
                    {
                        totalAmount += amount;
                    }

                }

            }

            //Display it in the TextBox
            txtTotalAmnt.Text = totalAmount.ToString("F2");
        }

        private void processItem(string Barcode)
        {
            // Get the QTY (safely parse it, default to 1 if invalid)
            if (!decimal.TryParse(txtQty.Text, out decimal qtyToAdd) || qtyToAdd <= 0)
            {
                qtyToAdd = 1;
            }

            //Add the item item in the DataGrid, query the database

            string query = "SELECT ENG_NAME, R_PRICE FROM PRODMAST WHERE BARCODE = ?";

            using (OleDbConnection con = new OleDbConnection(GetConnectionString()))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("?", txtBarcode.Text);

                    try
                    {
                        con.Open();
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                string prod_name = reader["ENG_NAME"].ToString();
                                decimal uPrice = Convert.ToDecimal(reader["R_PRICE"]);

                                //Discount logic
                                decimal discountPercent = 0m;

                                decimal effectiveSrp = uPrice - (uPrice * (discountPercent / 100));
                                // decimal amount = qtyToAdd * effectiveSrp;
                                decimal amount = Math.Round(qtyToAdd * effectiveSrp, MidpointRounding.AwayFromZero);

                                //Add the Item to the Data Grid
                                dataGridView1.Rows.Add(
                                    txtBarcode.Text,
                                    prod_name,
                                    qtyToAdd,
                                    effectiveSrp.ToString("F2"),
                                    amount.ToString("F2"),
                                    discountPercent.ToString() + "%",
                                    uPrice.ToString("F2")

                                    );

                                txtProdName.Text = prod_name;
                                txtUnitPrice.Text = effectiveSrp.ToString("F2");
                                txtPrice.Text = amount.ToString("F2");

                                UpdateTotalAmount();
                            }
                            else
                            {
                                MessageBox.Show("Item not found.", "Unknown Barcode", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Database Error: " + ex.Message, "Error");
                    }
                }
            }
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string scannedBarcode = txtBarcode.Text.Trim();

                if (!string.IsNullOrEmpty(scannedBarcode))
                {
                    processItem(scannedBarcode);
                }
                else
                {
                    MessageBox.Show("Opening Product Master");
                }

                //Resets the field after scanning
                txtBarcode.Text = "";
                txtQty.Text = "1";
                txtQty.Enabled = false;
                txtBarcode.Focus();

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBarcode.Focus();
                txtQty.Enabled = false;
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //Ignore if the row is invalid, or if the code is currently doing math
            if (e.RowIndex < 0 || isRecalculating) return;

            isRecalculating = true; // Lock the grid momentarily

            try
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string colName = dataGridView1.Columns[e.ColumnIndex].Name;

                // If the user edited the Discount OR the SRP
                if (colName == "disc" || colName == "srp")
                {
                    // Safetly grab the QTY and the Regular SRP 
                    int qty = Convert.ToInt32(row.Cells["quantity"].Value);

                    string rawRegSrp = row.Cells["regprice"].Value?.ToString().Replace(",", "").Trim() ?? "0";
                    decimal.TryParse(rawRegSrp, out decimal regSrp);

                    decimal currentSrp = 0m;

                    // Is the discount changed
                    if (colName == "disc")
                    {
                        string rawDisc = row.Cells["disc"].Value?.ToString().Replace("%", "").Trim() ?? "0";
                        decimal.TryParse(rawDisc, out decimal discPercent);

                        //Calculate the new SRP based on the discount
                        currentSrp = regSrp - (regSrp * (discPercent / 100m));

                        row.Cells["price"].Value = currentSrp.ToString("F2");
                        row.Cells["disc"].Value = discPercent.ToString("F0") + "%"; // Re-add the percentage
                    }
                    // Or the srp
                    else if (colName == "price")
                    {
                        string rawSrp = row.Cells["price"].Value?.ToString().Replace(",", "").Trim() ?? "0";
                        decimal.TryParse(rawSrp, out currentSrp);

                        row.Cells["price"].Value = currentSrp.ToString("F2"); //Format to 2 decimals
                    }

                    // Update the Amount for this row
                    // decimal newAmount = qty * currentSrp;
                    decimal newAmount = Math.Round(qty * currentSrp, MidpointRounding.AwayFromZero);
                    row.Cells["amnt"].Value = newAmount.ToString("F2");

                    // Update the Total Amount
                    UpdateTotalAmount();
                }
            }
            finally
            {
                isRecalculating = false; // Unlock the grid
            }
        }
    }
}
