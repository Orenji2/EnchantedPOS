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
    public partial class formProdBrowse : Form
    {

        // Public Property so the form can read the selected barcode
        public string SelectedBarcode { get; private set; } = "";

        

        public formProdBrowse()
        {
            InitializeComponent();

            // Sets the English Prodname as default option
            radioEngProdName.Checked = true;

            // Enable full row selection
            dgvProdList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProdList.AllowUserToAddRows = false;
            dgvProdList.ReadOnly = true;

        }



        private void formProdBrowse_Load(object sender, EventArgs e)
        {
            SearchDatabase(txtSearch.Text.Trim());

            this.ActiveControl = txtSearch;
        }

        // Run the search every time the user types a new letter
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchDatabase(txtSearch.Text.Trim());
        }

        private void SearchDatabase(string searchTerm)
        {
            dgvProdList.Rows.Clear();

            string searchColumn = "PROD_NAME"; // Default
            if (radioBarcode.Checked) searchColumn = "BARCODE";
            else if (radioKorProdName.Checked) searchColumn = "ALT_PROD_NAME";

            string query = $@"SELECT BARCODE, PROD_NAME, ALT_PROD_NAME, R_PRICE, STOCK 
                      FROM PRODMAST 
                      WHERE {searchColumn} LIKE @search";

            using (MySqlConnection con = DatabaseConfig.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%");

                    try
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string desc = reader["PROD_NAME"].ToString();
                                string pricePcs = Convert.ToDecimal(reader["R_PRICE"]).ToString("N2");
                                string priceBox = "0.00";
                                string barcode = reader["BARCODE"].ToString();


                                decimal stockOnHand = 0m;
                                if (reader["STOCK"] != DBNull.Value)
                                {
                                    stockOnHand = Convert.ToDecimal(reader["STOCK"]);
                                }
                                 dgvProdList.Rows.Add(desc, pricePcs, priceBox, barcode, stockOnHand);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Database Error: " + ex.Message, "Search Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ConfirmSelection()
        {
            if (dgvProdList.SelectedRows.Count > 0)
            {
                // Grab the barcode from the 4th column
                SelectedBarcode = dgvProdList.SelectedRows[0].Cells[3].Value?.ToString().Trim();

                // MessageBox.Show($"Sending Barcode to POS: '{SelectedBarcode}'", "Debug Check");

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select an item from the lists first", "No item selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ConfirmSelection();
        }

        private void dgvProdList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ConfirmSelection();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void dgvProdList_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the pressed key is Enter
            if (e.KeyCode == Keys.Enter)
            {
                // Stop the DataGridView from moving to the next row
                e.Handled = true;
                e.SuppressKeyPress = true;

                // Select
                ConfirmSelection();
            }
        }
    }
}
