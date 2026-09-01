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
        private int currentCashierId;
        private string currentCashier;
        private int currentShift;
        private decimal currentChangeFunds;
        private DateTime currentTransDate;
        private int currentStation;
        private int currentInvoiceNumber = 0;

        public formPOS(int cashierId, string cashier, int shift, decimal funds, DateTime date, int station)
        {
            InitializeComponent();
            this.KeyPreview = true;

            currentCashierId = cashierId;
            currentCashier = cashier;
            currentShift = shift;
            currentChangeFunds = funds;
            currentTransDate = date;
            currentStation = station;

            // Setting the minimum window size
            this.MinimumSize = new Size(1024, 768);

        }

        // Real-time save method
        private void SaveToTempRegister(string barcode, string engName, decimal qty, decimal uPrice, decimal totalAmnt)
        {
            string query = @"INSERT INTO TEMP_REGISTER
            (INVOICE, CASHIER_ID, SHIFT_NUM, TRANS_DATE, CHANGE_FUNDS, BAR_CODE, ENG_NAME, QTY, U_PRICE, TOTAL_AMNT, STATION_NUM)
            VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

            using (OleDbConnection con = new OleDbConnection(GetConnectionString()))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("?", currentInvoiceNumber);
                    cmd.Parameters.AddWithValue("?", currentCashierId);
                    cmd.Parameters.AddWithValue("?", currentShift);
                    cmd.Parameters.AddWithValue("?", currentTransDate.Date);
                    cmd.Parameters.AddWithValue("?", currentChangeFunds);
                    cmd.Parameters.AddWithValue("?", barcode);
                    cmd.Parameters.AddWithValue("?", engName);
                    cmd.Parameters.AddWithValue("?", qty);
                    cmd.Parameters.AddWithValue("?", uPrice);
                    cmd.Parameters.AddWithValue("?", totalAmnt);
                    cmd.Parameters.AddWithValue("?", currentStation);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private bool isRecalculating = false;

        // defaults to regular price
        private string currentDiscountType = "Regular";



        private string GetConnectionString()
        {
            // Reference to the directory of the exe file
            string exeFolder = AppDomain.CurrentDomain.BaseDirectory;

            // Reference to the Path of the Database
            string dbPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(exeFolder, @"..\..\..\dbEn.accdb"));

            // Access uses an OLEDB provider pointing directly to your local file
            return $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbPath};";
        }


        private string SelectDiscountType()
        {
            Form disc = new Form()
            {
                Width = 250,
                Height = 260,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Select Discount Type",
                StartPosition = FormStartPosition.CenterParent,
                MinimizeBox = false,
                MaximizeBox = false
            };

            Button btnReg = new Button() { Text = "Regular Price", Top = 20, Left = 35, Width = 160, DialogResult = DialogResult.Yes };
            Button btnWholesale = new Button() { Text = "Wholesale", Top = 60, Left = 35, Width = 160, DialogResult = DialogResult.No};
            Button btnVIP = new Button() { Text = "VIP (B)", Top = 100, Left = 35, Width = 160, DialogResult = DialogResult.OK };
            Button btnRoyal = new Button() { Text = "Royal (C)", Top = 140, Left = 35, Width = 160, DialogResult = DialogResult.Ignore };
            Button btnCancel = new Button() { Text = "Cancel", Top = 180, Left = 35, Width = 160, DialogResult = DialogResult.Cancel };

            disc.Controls.Add(btnReg);
            disc.Controls.Add(btnWholesale);
            disc.Controls.Add(btnVIP);
            disc.Controls.Add(btnRoyal);
            disc.Controls.Add(btnCancel);

            DialogResult result = disc.ShowDialog();

            // Return the selected type based on which button they clicked
            if (result == DialogResult.Yes) return "Regular";
            if (result == DialogResult.No) return "Wholesale";
            if (result == DialogResult.OK) return "VIP";
            if (result == DialogResult.Ignore) return "Royal";

            return null;
        }

        private bool CheckGlobalPassword()
        {
            string globalPassword = "1"; //Global Password

            Form prompt = new Form()
            {
                Width = 300,
                Height = 160,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Manager Overide",
                StartPosition = FormStartPosition.CenterScreen,
                MinimizeBox = false,
                MaximizeBox = false
            };

            Label txtPassLabel = new Label() { Left = 20, Top = 20, Text = "Enter Password: " };
            TextBox inputBox = new TextBox() { Left = 20, Top = 45, Width = 240, PasswordChar = '*' };
            Button confirmation = new Button() { Text = "OK", Left = 160, Width = 100, Top = 80, DialogResult = DialogResult.OK };
            Button cancel = new Button() { Text = "Cancel", Left = 50, Width = 100, Top = 80, DialogResult = DialogResult.Cancel };

            prompt.Controls.Add(txtPassLabel);
            prompt.Controls.Add(inputBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancel);
            prompt.AcceptButton = confirmation; // Pressing Enter clicks OK

            // Show the prompt. If they click OK, check if the password matches.
            if (prompt.ShowDialog() == DialogResult.OK)
            {
                return inputBox.Text == globalPassword;
            }

            return false; // They clicked Cancel or closed the window
        }



        private void formPOS_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void btnReprint_Click(object sender, EventArgs e)
        {

        }

        private void formPOS_Load(object sender, EventArgs e)
        {
            setupDataGridView();
            LoadRecoveredTransactions();

            this.ActiveControl = txtBarcode;

            this.dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
        }

        private void ClearTempRegister()
        {
            string query = "DELETE FROM TEMP_REGISTER WHERE STATION_NUM = ?";
            
            using (OleDbConnection con = new OleDbConnection(GetConnectionString()))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("?", currentStation);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void setupDataGridView()
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void formPOS_KeyDown(object sender, KeyEventArgs e)
        {

            // Press ESC for Discount
            if (e.KeyCode == Keys.Escape)
            {
                if (!CheckGlobalPassword()) // If the password is incorrect
                {
                    MessageBox.Show("Incorrect Password.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    return;
                }

                string selectedType = SelectDiscountType();

                // If selected a discount 

                if(selectedType != null)
                {
                    currentDiscountType = selectedType;
                    // MessageBox.Show($"Price Mode changed to: {currentDiscountType}.\nAll newly scanned items will use this price tier.", "Mode Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (currentDiscountType == "Regular")
                    {
                        labelSales.Text = "Sales Entry";
                    }
                    else
                    {
                        labelSales.Text = $"Sales Entry ({currentDiscountType})";
                    }
                    txtBarcode.Focus();
                }
            }

            // Press "/" for Quantity
            if (e.KeyCode == Keys.Divide)
            {
                txtQty.Enabled = true;
                txtQty.Focus();
                txtQty.SelectAll();


                e.Handled = true;
                e.SuppressKeyPress = true;
            }

            // Press F3 to Edit or Void
            if (e.KeyCode == Keys.F3)
            {
                //Requires  password first
                if (!CheckGlobalPassword()) // If the password is incorrect
                {
                    MessageBox.Show("Incorrect Password.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    return;
                }
                
                DialogResult result = MessageBox.Show(
                    "Press 'Yes' to EDIT the transaction (Discount/Price).\nPress 'No' to VOID (Clear all items).\nPress 'Cancel' to return.",
            "Edit or Void",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No) //void 
                {

                    DialogResult confirmVoid = MessageBox.Show(
                        "Are you sure you want to VOID this transaction? This action cannot be undone.",
                        "Confirm Void",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (confirmVoid == DialogResult.Yes)
                    {
                        dataGridView1.Rows.Clear();
                        UpdateTotalAmount();
                        ClearTempRegister();
                        txtBarcode.Focus();
                    }
                    else
                    {
                        txtBarcode.Focus();
                    }

                    
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
            txtTotalAmnt.Text = totalAmount.ToString("N2");
        }

        private void processItem(string Barcode)
        {
            // Get the QTY (safely parse it, default to 1 if invalid)
            if (!decimal.TryParse(txtQty.Text, out decimal qtyToAdd) || qtyToAdd <= 0)
            {
                qtyToAdd = 1;
            }

            //Add the item item in the DataGrid, query the database

            string query = "SELECT ENG_NAME, R_PRICE, D_PRICE_A, D_PRICE_B, D_PRICE_C FROM PRODMAST WHERE BARCODE = ?";

            using (OleDbConnection con = new OleDbConnection(GetConnectionString()))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("?", Barcode);

                    try
                    {
                        con.Open();
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                string prod_name = reader["ENG_NAME"].ToString();
                                // decimal uPrice = Convert.ToDecimal(reader["R_PRICE"]);
                                decimal uPrice = 0m;

                                if(currentDiscountType == "Regular")
                                {
                                    uPrice = Convert.ToDecimal(reader["R_PRICE"]);
                                }
                                else if(currentDiscountType == "Wholesale")
                                {
                                    uPrice = Convert.ToDecimal(reader["D_PRICE_A"]);
                                }
                                else if(currentDiscountType == "VIP")
                                {
                                    uPrice = Convert.ToDecimal(reader["D_PRICE_B"]);
                                }
                                else if(currentDiscountType == "Royal")
                                {
                                    uPrice = Convert.ToDecimal(reader["D_PRICE_C"]);
                                }

                                //Discount logic
                                decimal discountPercent = 0m;

                                decimal effectiveSrp = uPrice - (uPrice * (discountPercent / 100));
                                // decimal amount = qtyToAdd * effectiveSrp;
                                decimal amount = Math.Round(qtyToAdd * effectiveSrp, MidpointRounding.AwayFromZero);

                                //Add the Item to the Data Grid
                                dataGridView1.Rows.Add(
                                    Barcode,
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

                                SaveToTempRegister(Barcode, prod_name, qtyToAdd, effectiveSrp, amount);

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

        private void processWeightedItem(string scaleBarcode)
        {
            string actualBarcode = "";
            decimal weightInKg = 0m;

            try
            {
                // 14 digit bacode
                if (scaleBarcode.Length == 14)
                {
                    actualBarcode = scaleBarcode.Substring(3, 4); // Grabs the base barcode
                    string weightGramsStr = scaleBarcode.Substring(8, 5); // Grabs the weight

                    decimal.TryParse(weightGramsStr, out decimal weigthGrams);
                    weightInKg = weigthGrams / 1000m; // Converts the grams to kg
                }
                // For 13 digit barcodes
                else if (scaleBarcode.Length == 13)
                {
                    actualBarcode = scaleBarcode.Substring(2, 4); // Grabs the base barcode
                    string weightGramsStr = scaleBarcode.Substring(7, 5); // Grabs the weight

                    decimal.TryParse(weightGramsStr, out decimal weightGrams); //Convert the String to decimal
                    weightInKg = weightGrams / 1000m; 
                }
                else
                {
                    MessageBox.Show("Unknown Scale Barcode Format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to parse weight from Barcode", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            string query= "SELECT ENG_NAME, R_PRICE, D_PRICE_A, D_PRICE_B, D_PRICE_C FROM PRODMAST WHERE BARCODE = ?";

            using (OleDbConnection con = new OleDbConnection(GetConnectionString()))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("?", actualBarcode);

                    try
                    {
                        con.Open();
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string prod_name = reader["ENG_NAME"].ToString();
                                decimal uPrice = 0m;

                                // Check Tiered pricing
                                if (currentDiscountType == "Regular") { uPrice = Convert.ToDecimal(reader["R_PRICE"]); }
                                else if (currentDiscountType == "Wholesale") { uPrice = Convert.ToDecimal(reader["D_PRICE_A"]); }
                                else if (currentDiscountType == "VIP") { uPrice = Convert.ToDecimal(reader["D_PRICE_B"]); }
                                else if (currentDiscountType == "Royal") { uPrice = Convert.ToDecimal(reader["D_PRICE_C"]); }

                                decimal discountPercent = 0m;
                                decimal effectiveSrp = uPrice - (uPrice * (discountPercent / 100));

                                // MULTIPLY  PRICE PER KG BY THE WEIGHT
                                decimal amount = Math.Round(weightInKg * effectiveSrp, MidpointRounding.AwayFromZero);

                                // ADD TO THE DATAGRID
                                dataGridView1.Rows.Add(
                                    actualBarcode,
                                    prod_name + " (" + weightInKg.ToString("F3") + " kg )",
                                    weightInKg.ToString("F3"),
                                    effectiveSrp.ToString("F2"),
                                    amount.ToString("F2"),
                                    discountPercent.ToString() + "%",
                                    uPrice.ToString("F2")
                                );

                                //Save to temp Register
                                SaveToTempRegister(actualBarcode, prod_name, weightInKg, effectiveSrp, amount);
                                UpdateTotalAmount();
                            }
                            else
                            {
                                MessageBox.Show("Weighed item not found in the database.", "Uknown Barcode", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void LoadRecoveredTransactions()
        {
            string query = @"SELECT INVOICE, BAR_CODE, ENG_NAME, QTY, U_PRICE, TOTAL_AMNT
                            FROM TEMP_REGISTER
                            WHERE STATION_NUM = ?";

            using (OleDbConnection con = new OleDbConnection(GetConnectionString()))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("?", currentStation); // Current Cashier instead of Station?

                    try
                    {
                        con.Open();
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            bool hasRecoveredItems = false;

                            while (reader.Read())
                            {
                                hasRecoveredItems = true;

                                //Grab the Invoice Number
                                currentInvoiceNumber = Convert.ToInt32(reader["INVOICE"]);

                                string barcode = reader["BAR_CODE"].ToString();
                                string name = reader["ENG_NAME"].ToString();
                                decimal qty = Convert.ToDecimal(reader["QTY"]);
                                decimal uPrice = Convert.ToDecimal(reader["U_PRICE"]);
                                decimal amount = Convert.ToDecimal(reader["TOTAL_AMNT"]);

                                dataGridView1.Rows.Add(
                                    barcode,
                                    name,
                                    qty,
                                    uPrice.ToString("F2"),
                                    amount.ToString("F2"),
                                    "0%", // Default discount
                                    uPrice.ToString("F2") // Defaulting regprice
                                    );
                            }

                            if (hasRecoveredItems)
                            {
                                UpdateTotalAmount();
                                MessageBox.Show("An interrupted transaction was recovered succesfully.", "Session restored", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                // If there is nothing to recover, generate a fresh invoice number
                                GenerateNewInvoiceNumber();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error recovering transaction: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string scannedBarcode = txtBarcode.Text.Trim();

                /**
                if (!string.IsNullOrEmpty(scannedBarcode))
                {
                    processItem(scannedBarcode);
                }
                else
                {
                    formProdBrowse f = new formProdBrowse();
                    
                }
                **/

                //If the Barcode is empty and Enter is pressed then the Browse Product Will Open
                if (string.IsNullOrEmpty(scannedBarcode))
                {
                    formProdBrowse browseForm = new formProdBrowse();

                    if (browseForm.ShowDialog() == DialogResult.OK)
                    {
                        scannedBarcode = browseForm.SelectedBarcode;

                        if (!string.IsNullOrEmpty(scannedBarcode)) {

                            processItem(scannedBarcode);

                        }
                    }
                }
                else
                {
                    if (scannedBarcode.StartsWith("20") && scannedBarcode.Length >= 13)
                    {
                        //Weighted Item Scan
                        processWeightedItem(scannedBarcode);
                    }
                    else
                    {
                        //Normal Item Scan
                        processItem(scannedBarcode);
                    }


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

        private void GenerateNewInvoiceNumber()
        {
            string query = "SELECT MAX(INVOICE) FROM REGISTER";

            using (OleDbConnection con = new OleDbConnection(GetConnectionString()))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    try
                    {
                        con.Open();
                        object result = cmd.ExecuteScalar();

                        if (result != DBNull.Value && result != null)
                        {
                            currentInvoiceNumber = Convert.ToInt32(result) + 1;
                        }
                        else
                        {
                            currentInvoiceNumber = 10001;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error generating invoice number: " + ex.Message, "Database Error");
                    }
                }
            }
        }

    }
}
