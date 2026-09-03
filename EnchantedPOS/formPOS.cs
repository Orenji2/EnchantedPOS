using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace EnchantedPOS
{
    public partial class formPOS : Form
    {

        private bool isRecalculating = false;

        // private string currentDiscountType = "Regular";
        public enum DiscountType
        {
            Regular,
            Wholesale,
            VIP,
            Royal
        }
        private DiscountType currentDiscountType = DiscountType.Regular;
        private int currentCashierId;
        private string currentCashier;
        private int currentShift;
        private decimal currentChangeFunds;
        private DateTime currentTransDate;
        private int currentStation;
        private int currentInvoiceNumber = 0;
        private string headerBusinessName = "BUSINESS";
        private string headerAddress = "ADDRESS";
        private string headerTIN = "000-000-000-000";

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
        private void SaveToTempRegister(string barcode, string engName, string korName, decimal qty, decimal uPrice, decimal totalAmnt, bool isNonVat)
        {
            string query = @"INSERT INTO TEMP_REGISTER
            (INVOICE, CASHIER_ID, SHIFT_NUM, TRANS_DATE, CHANGE_FUNDS, BAR_CODE, ENG_NAME, KOR_NAME, QTY, U_PRICE, TOTAL_AMNT, CHANGE_AMNT, STATION_NUM, NON_VAT)
            VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

            using (OleDbConnection con = new OleDbConnection(DatabaseConfig.GetConnectionString()))
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
                    cmd.Parameters.AddWithValue("?", korName);
                    cmd.Parameters.AddWithValue("?", qty);
                    cmd.Parameters.AddWithValue("?", uPrice);
                    cmd.Parameters.AddWithValue("?", totalAmnt);
                    cmd.Parameters.AddWithValue("?", 0m);
                    cmd.Parameters.AddWithValue("?", currentStation);
                    cmd.Parameters.AddWithValue("?", isNonVat);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void LoadInvoiceHeader()
        {
            string query = "SELECT BUSINESS_NAME, ADDRESS, TIN FROM INVOICE_HEADER WHERE ID = 1";

            using (OleDbConnection con = new OleDbConnection(DatabaseConfig.GetConnectionString()))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    try
                    {
                        con.Open();
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                headerBusinessName = reader["BUSINESS_NAME"].ToString();
                                headerAddress = reader["ADDRESS"].ToString();
                                headerTIN = reader["TIN"].ToString();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading invoice header: " + ex.Message, "Database Error");
                    }
                }
            }
        }





        

        private void DeductInventory()
        {
            string query = "UPDATE PRODMAST SET STOCK = STOCK - ? WHERE BARCODE = ?";

            using (OleDbConnection con = new OleDbConnection(DatabaseConfig.GetConnectionString()))
            {
                try
                {
                    con.Open();

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells[0].Value != null)
                        {
                            string barcode = row.Cells[0].Value.ToString();

                            // Grab the QTY
                            if (decimal.TryParse(row.Cells[2].Value.ToString(), out decimal qty))
                            {
                                using (OleDbCommand cmd = new OleDbCommand(query, con))
                                {
                                    cmd.Parameters.AddWithValue("?", qty);
                                    cmd.Parameters.AddWithValue("?", barcode);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to deduct inventory: " + ex.Message, "Inventory Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private DiscountType? SelectDiscountType()
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
            if (result == DialogResult.Yes) return DiscountType.Regular;
            if (result == DialogResult.No) return DiscountType.Wholesale;
            if (result == DialogResult.OK) return DiscountType.VIP;
            if (result == DialogResult.Ignore) return DiscountType.Royal;

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
            LoadInvoiceHeader();

            this.ActiveControl = txtBarcode;

            this.dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
        }

        private void ClearTempRegister()
        {
            string query = "DELETE FROM TEMP_REGISTER WHERE STATION_NUM = ?";
            
            using (OleDbConnection con = new OleDbConnection(DatabaseConfig.GetConnectionString()))
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
            // dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

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

                DiscountType? selectedType = SelectDiscountType();

                // If selected a discount 

                if(selectedType != null)
                {
                    currentDiscountType = selectedType.Value;
                    // MessageBox.Show($"Price Mode changed to: {currentDiscountType}.\nAll newly scanned items will use this price tier.", "Mode Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (currentDiscountType == DiscountType.Regular)
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

            if (e.KeyCode == Keys.Delete)
            {
                if (dataGridView1.ReadOnly == false && dataGridView1.CurrentRow != null)
                {
                    string selectedBarcode = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    string selectedName = dataGridView1.CurrentRow.Cells[1].Value.ToString();

                    DialogResult confirmDelete = MessageBox.Show(
                        $"Are you sure you want to remove '{selectedName}'?",
                        "Remove Item",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (confirmDelete == DialogResult.Yes)
                    {
                        // Remove only the specific highlighted row from the items
                        dataGridView1.Rows.Remove(dataGridView1.CurrentRow);

                        // Wipe all the entries of the BARCODE from the database
                        string query = "DELETE FROM TEMP_REGISTER WHERE STATION_NUM = ? AND INVOICE = ? AND BAR_CODE = ?";

                        using (OleDbConnection con = new OleDbConnection(DatabaseConfig.GetConnectionString()))
                        {
                            using (OleDbCommand cmd = new OleDbCommand(query, con))
                            {
                                cmd.Parameters.AddWithValue("?", currentStation);
                                cmd.Parameters.AddWithValue("?", currentInvoiceNumber);
                                cmd.Parameters.AddWithValue("?", selectedBarcode);

                                try
                                {
                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                }
                                catch(Exception ex)
                                {
                                    MessageBox.Show("Error Removing from Database: " + ex.Message);
                                    return;
                                }
                            }
                        }
                        // Look at the grid if there are duplicates left, re-save them to the database
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            //If we found another item in the another row with the same barcode
                            if (row.Cells[0].Value != null && row.Cells[0].Value.ToString()  == selectedBarcode)
                            {
                                decimal qty = Convert.ToDecimal(row.Cells[2].Value); 
                                
                                // Clean the comas out and grab the numbers
                                string rawUPrice = row.Cells[3].Value.ToString().Replace(",", "");
                                decimal.TryParse(rawUPrice, out decimal uPrice);

                                string rawAmount = row.Cells[4].Value.ToString().Replace(",", "");
                                decimal.TryParse(rawUPrice,out decimal amount);

                                // Split the combined names back into two strings
                                string[] names = row.Cells[1].Value.ToString().Split(new string[] { " / " }, StringSplitOptions.None);
                                string engName = names[0].Trim();
                                string korName = names.Length > 1 ? names[1].Trim() : "";

                                bool isNonVat = false;
                                if (row.Cells[7].Value != null)
                                {
                                    bool.TryParse(row.Cells[7].Value.ToString(), out isNonVat);
                                }

                                // Save to the temp register
                                SaveToTempRegister(selectedBarcode, engName, korName, qty, uPrice, amount, isNonVat);
                            }
                        }
                        UpdateTotalAmount();
                        txtBarcode.Focus();
                    }
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
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

            // Payment
            if (e.KeyCode == Keys.F2)
            {
               if (string.IsNullOrWhiteSpace(txtTotalAmnt.Text) || txtTotalAmnt.Text == "0.00")
               {
                    MessageBox.Show("There are no items to pay for.", "Empty Transaction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
               }

               string rawTotal = txtTotalAmnt.Text.Replace(",", "");
               
                if(decimal.TryParse(rawTotal, out decimal currentTotal))
                {
                    using (formSaveTransaction payForm = new formSaveTransaction(currentTotal))
                    {
                        if(payForm.ShowDialog() == DialogResult.OK)
                        {
                            decimal change = payForm.FinalChangeAmount;
                            decimal receivedAmount = payForm.FinalReceivedAmount;

                            txtPrice.Text = change.ToString("N2");
                            
                            // MessageBox.Show($"Payment Succesful!\n Change: {change.ToString("N2")}", "Transaction Complete");

                            FinalizeTransaction(currentTotal,receivedAmount, change);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Error reading total amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private void AddItemToCart(ProductRecord product, decimal quantityOrWeight, string customDisplayName = null)
        {
            decimal uPrice = 0m;
            switch (currentDiscountType)
            {
                case DiscountType.Regular: uPrice = product.RegPrice; break;
                case DiscountType.Wholesale: uPrice = product.WholesalePrice; break;
                case DiscountType.VIP: uPrice = product.VipPrice; break;
                case DiscountType.Royal: uPrice = product.RoyalPrice; break;
            }

            decimal discountPercent = 0m;
            decimal effectiveSrp = uPrice - (uPrice * (discountPercent / 100));
            decimal amount = Math.Round(quantityOrWeight * effectiveSrp, MidpointRounding.AwayFromZero);

            string displayName = customDisplayName ?? (string.IsNullOrWhiteSpace(product.KorName) ? product.EngName : $"{product.EngName} / {product.KorName}");

            dataGridView1.Rows.Add(
                product.Barcode,
                displayName,
                quantityOrWeight.ToString("0.###"),
                effectiveSrp.ToString("F2"),
                amount.ToString("F2"),
                discountPercent.ToString() + "%",
                uPrice.ToString("F2"),
                product.IsNonVat
                );

            txtProdName.Text = product.EngName;
            txtUnitPrice.Text = effectiveSrp.ToString("F2");
            txtPrice.Text = amount.ToString("F2");
            SaveToTempRegister(product.Barcode, product.EngName, product.KorName, quantityOrWeight, effectiveSrp, amount, product.IsNonVat);
            UpdateTotalAmount();
        }

        private void processItem(string Barcode)
        {
            if(!decimal.TryParse(txtQty.Text, out decimal qtyToAdd) || qtyToAdd <= 0)
            {
                qtyToAdd = 1;
            }

            ProductRecord product = FetchProductFromDatabase(Barcode);

            if (product == null)
            {
                MessageBox.Show("Item not found.", "Unknown Barcode", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AddItemToCart(product, qtyToAdd);
        }

        private void processWeightedItem(string scaleBarcode)
        {
            string actualBarcode = "";
            decimal weightInKg = 0m;

            try
            {
                if (scaleBarcode.Length == 14)
                {
                    actualBarcode = scaleBarcode.Substring(3, 4);
                    decimal.TryParse(scaleBarcode.Substring(8, 5), out decimal weightGrams);
                    weightInKg = weightGrams / 1000m;
                }
                else if (scaleBarcode.Length == 13)
                {
                    actualBarcode = scaleBarcode.Substring(3, 4);
                    decimal.TryParse(scaleBarcode.Substring(7, 5), out decimal weightGrams);
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
                MessageBox.Show("Failed to parse weight from Barcode: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ProductRecord product = FetchProductFromDatabase(actualBarcode);

            if (product == null)
            {
                MessageBox.Show("Weighed item not found in the database.", "Unknown Barcode", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Format the special weight string
            string baseDisplayName = string.IsNullOrWhiteSpace(product.KorName) ? product.EngName : $"{product.EngName} / {product.KorName}";
            string displayWithWeight = $"{baseDisplayName} ({weightInKg.ToString("F3")} kg)";

            // Call the new helper, passing in the custom display name!
            AddItemToCart(product, weightInKg, displayWithWeight);
        }

        private void LoadRecoveredTransactions()
        {
            string query = @"SELECT INVOICE, BAR_CODE, ENG_NAME, KOR_NAME, QTY, U_PRICE, TOTAL_AMNT
                            FROM TEMP_REGISTER
                            WHERE STATION_NUM = ?";

            using (OleDbConnection con = new OleDbConnection(DatabaseConfig.GetConnectionString()))
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
                                string engName = reader["ENG_NAME"].ToString();
                                string korName = reader["KOR_NAME"].ToString();
                                decimal qty = Convert.ToDecimal(reader["QTY"]);
                                decimal uPrice = Convert.ToDecimal(reader["U_PRICE"]);
                                decimal amount = Convert.ToDecimal(reader["TOTAL_AMNT"]);

                                string displayName = string.IsNullOrWhiteSpace(korName)
                                    ? engName
                                    : $"{engName} / {korName}";

                                bool isNonVat = reader["NON_VAT"] != DBNull.Value && Convert.ToBoolean(reader["NON_VAT"]);

                                dataGridView1.Rows.Add(
                                    barcode,
                                    displayName,
                                    qty,
                                    uPrice.ToString("F2"),
                                    amount.ToString("F2"),
                                    "0%", // Default discount
                                    uPrice.ToString("F2"), // Defaulting regprice
                                    isNonVat
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

            using (OleDbConnection con = new OleDbConnection(DatabaseConfig.GetConnectionString()))
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

        private void FinalizeTransaction(decimal grandTotal, decimal amountReceived, decimal changeAmount)
        {

            
            

            string insertQuery = @"INSERT INTO REGISTER
                                   (INVOICE, CASHIER_ID, SHIFT_NUM, TRANS_DATE, CHANGE_FUNDS, BAR_CODE, ENG_NAME, KOR_NAME, QTY, U_PRICE, TOTAL_AMNT, STATION_NUM, NON_VAT)
                                    SELECT INVOICE, CASHIER_ID, SHIFT_NUM, TRANS_DATE, CHANGE_FUNDS, BAR_CODE, ENG_NAME, KOR_NAME, QTY, U_PRICE, TOTAL_AMNT, STATION_NUM, NON_VAT
                                       FROM TEMP_REGISTER
                                        WHERE STATION_NUM = ? AND INVOICE = ?";

            string updateQuery = @"UPDATE REGISTER
                                    SET TRANS_TIME = ?, GRAND_TOTAL = ?, AMOUNT_RECEIVED = ?, CHANGE_AMNT = ?
                                    WHERE STATION_NUM = ? AND INVOICE = ?";
            
            using (OleDbConnection con = new OleDbConnection(DatabaseConfig.GetConnectionString()))
            {
                try
                {
                    con.Open();

                    // Insert Query 
                    using (OleDbCommand cmdInsert = new OleDbCommand(insertQuery, con))
                    {
                        cmdInsert.Parameters.AddWithValue("?", currentStation);
                        cmdInsert.Parameters.AddWithValue("?", currentInvoiceNumber);
                        cmdInsert.ExecuteNonQuery();
                    }

                    // Update totals
                    using (OleDbCommand cmdUpdate = new OleDbCommand(updateQuery, con))
                    {
                        cmdUpdate.Parameters.AddWithValue("?", DateTime.Now.ToString("hh:mm:ss tt"));
                        cmdUpdate.Parameters.AddWithValue("?", grandTotal);
                        cmdUpdate.Parameters.AddWithValue("?", amountReceived);
                        cmdUpdate.Parameters.AddWithValue("?", changeAmount);

                        // Parameters for the WHERE clause
                        cmdUpdate.Parameters.AddWithValue("?", currentStation);
                        cmdUpdate.Parameters.AddWithValue("?", currentInvoiceNumber);

                        cmdUpdate.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to Save to Register Databae! Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            DeductInventory();

            //PRINT THE RECEIPT!
            PrintReceipt(grandTotal, amountReceived, changeAmount);

            ClearTempRegister();
            dataGridView1.Rows.Clear();
            currentInvoiceNumber++;
            UpdateTotalAmount();
            txtBarcode.Focus();
        }

        private void PrintReceipt(decimal grandTotal, decimal amountReceived, decimal changeAmount)
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += (sender, e) => PrintReceiptPage(sender, e, grandTotal, amountReceived, changeAmount);

            try
            {
                // printDoc.Print();
                PrintPreviewDialog previewDialog = new PrintPreviewDialog();
                previewDialog.Document = printDoc;

                previewDialog.Width = 400;
                previewDialog.Height = 600;

                bool wasTopMost = this.TopMost;
                this.TopMost = false;

                // Show the receipt on the screen!
                previewDialog.ShowDialog(this);

                this.TopMost = wasTopMost;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Printer error:" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void PrintReceiptPage(object sender, PrintPageEventArgs e, decimal grandTotal, decimal amountReceived, decimal changeAmount)
        {
            Graphics g = e.Graphics;

            Font fontRegular = new Font("Courier New", 8);
            Font fontBold = new Font("Courier New", 10, FontStyle.Bold);
            Font fontHeader = new Font("Courier New", 14, FontStyle.Bold);
            Brush brush = Brushes.Black;

            float yPos = 10;
            float leftMargin = 5;
            float centerMargin = 140;
            float rightMargin = 280;

            StringFormat centerAlign = new StringFormat() { Alignment = StringAlignment.Center };
            StringFormat rightAlign = new StringFormat() { Alignment = StringAlignment.Far };

            // --HEADER ---
            g.DrawString(headerBusinessName, fontHeader, brush, centerMargin, yPos, centerAlign);
            yPos += 25;
            g.DrawString(headerAddress, fontRegular, brush, centerMargin, yPos, centerAlign);
            yPos += 15;
            g.DrawString($"VAT REG TIN: {headerTIN}", fontRegular, brush, centerMargin, yPos, centerAlign);
            yPos += 15;
            g.DrawString(new string('-', 38), fontRegular, brush, leftMargin, yPos);
            yPos += 20;

            // --- TRANSACTION DETAILS ---
            g.DrawString($"Invoice: {currentInvoiceNumber}", fontRegular, brush, leftMargin, yPos);
            yPos += 15;
            g.DrawString($"Date:    {DateTime.Now.ToString("MM/dd/yyyy hh:mm tt")}", fontRegular, brush, leftMargin, yPos);
            yPos += 15;
            g.DrawString($"Cashier: {currentCashier}", fontRegular, brush, leftMargin, yPos);
            yPos += 20;
            g.DrawString(new string('-', 38), fontRegular, brush, leftMargin, yPos);
            yPos += 20;

            // --- COLUMN HEADERS ---
            g.DrawString("ITEM", fontBold, brush, leftMargin, yPos);
            g.DrawString("TOTAL", fontBold, brush, rightMargin, yPos, rightAlign);
            yPos += 20;

            // --- LOOP THROUGH ITEMS IN THE DATAGRID ---
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    // 1. Grab your known columns
                    string engName = row.Cells[1].Value.ToString();
                    string qty = row.Cells[2].Value.ToString();
                    string totalAmount = row.Cells[4].Value.ToString();

                    // 2. Grab your Unit Price 
                    // -> CHANGE THIS INDEX TO MATCH YOUR DATAGRID! <-
                    string uPrice = row.Cells[3].Value.ToString();

                    // 3. Print the English Name (It now has the full paper width!)
                    g.DrawString(engName, fontRegular, brush, leftMargin, yPos);
                    yPos += 15; // Move down a line

                    // 4. Print the Math (e.g., "  4 x 100.00") on the left, and Total on the right
                    string mathLine = $"  {qty} x {uPrice}";
                    g.DrawString(mathLine, fontRegular, brush, leftMargin, yPos);
                    g.DrawString(totalAmount, fontRegular, brush, rightMargin, yPos, rightAlign);

                    yPos += 22; // Extra spacing before the next product begins
                }
            }

            yPos += 5;
            g.DrawString(new string('-', 38), fontRegular, brush, leftMargin, yPos);
            yPos += 20;

            // --- TOTALS ---
            decimal totalItems = 0m;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    decimal.TryParse(row.Cells[2].Value.ToString(), out decimal qty);
                    totalItems += qty;
                }
            }

            decimal totalAmnt = grandTotal;
            decimal totalRegularAmnt = grandTotal; // Temporary while the Senior Discount is still not implemented yet
            decimal discountAmount = 0m; // Temporary


            // PRINT TOTALS
            g.DrawString("Total Amnt:", fontRegular, brush, leftMargin, yPos);
            g.DrawString(totalAmnt.ToString("N2"), fontRegular, brush, rightMargin, yPos, rightAlign);
            yPos += 15;

            g.DrawString("Total Regular Amnt:", fontRegular, brush, leftMargin, yPos);
            g.DrawString(totalRegularAmnt.ToString("N2"), fontRegular, brush, rightMargin, yPos, rightAlign);
            yPos += 15;

            g.DrawString("(Senior/PWD Discount):", fontRegular, brush, leftMargin, yPos);
            g.DrawString(discountAmount.ToString("N2"), fontRegular, brush, rightMargin, yPos, rightAlign);
            yPos += 15;

            g.DrawString("Amount to Pay:", fontBold, brush, leftMargin, yPos);
            g.DrawString(grandTotal.ToString("N2"), fontBold, brush, rightMargin, yPos, rightAlign);
            yPos += 15;

            g.DrawString("Amt. Received:", fontRegular, brush, leftMargin, yPos);
            g.DrawString(amountReceived.ToString("N2"), fontRegular, brush, rightMargin, yPos, rightAlign);
            yPos += 15;

            g.DrawString("Change Amount:", fontBold, brush, leftMargin, yPos);
            g.DrawString(changeAmount.ToString("N2"), fontBold, brush, rightMargin, yPos, rightAlign);
            yPos += 15;

            g.DrawString("Total Item:", fontRegular, brush, leftMargin, yPos);
            // Using "0" instead of "N2" so quantities like 5 print as "5" instead of "5.00" (Unless you sell by weight!)
            g.DrawString(totalItems.ToString("0.###"), fontRegular, brush, rightMargin, yPos, rightAlign);
            yPos += 25; // Space before the VAT computation block

            g.DrawString(new string('-', 15), fontRegular, brush, centerMargin, yPos, centerAlign);
            yPos += 5;
            g.DrawString("Customer Signature:", fontRegular, brush, centerMargin, yPos, centerAlign);
            yPos += 15;

            // --- VAT COMPUTATION ---
            CalculateVATBreakdown(out decimal vatableSales, out decimal vatAmount, out decimal vatExempt, out decimal zeroRated);

            // Draw VAT
            g.DrawString("VATable Sales: ", fontRegular, brush, leftMargin, yPos);
            g.DrawString(vatableSales.ToString("N2"), fontRegular, brush, rightMargin, yPos, rightAlign);
            yPos += 15;

            g.DrawString("VAT (12%):", fontRegular, brush, leftMargin, yPos);
            g.DrawString(vatAmount.ToString("N2"), fontRegular, brush, rightMargin, yPos, rightAlign);
            yPos += 15;

            g.DrawString("VAT Exempt Sales:", fontRegular, brush, leftMargin, yPos);
            g.DrawString(vatExempt.ToString("N2"), fontRegular, brush, rightMargin, yPos, rightAlign);
            yPos += 15;

            g.DrawString("Zero Rated Sales:", fontRegular, brush, leftMargin, yPos);
            g.DrawString(zeroRated.ToString("N2"), fontRegular, brush, rightMargin, yPos, rightAlign);
            yPos += 30;

            // -- FOOTER
            g.DrawString("This serves as \n your official receipt.", fontBold, brush, centerMargin, yPos, centerAlign);
            yPos += 30;

            g.DrawString("Please Come Again", fontRegular, brush, centerMargin, yPos, centerAlign);
            yPos += 25;

            g.DrawString("Please present this receipt in case \n of exchange of merchandise within 7 days.", fontRegular, brush, centerMargin, yPos, centerAlign);
            yPos += 25;

            g.DrawString("This invoice shall be valid \n for five(5) days from the date \n of the permit to use.", fontRegular, brush, centerMargin, yPos, centerAlign);
        }

        private void CalculateVATBreakdown(out decimal vatableSales, out decimal vatAmount, out decimal vatExempt, out decimal zeroRated)
        {

            vatableSales = 0m;
            vatAmount = 0m;
            vatExempt = 0m;
            zeroRated = 0m;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    string rawAmount = row.Cells[4].Value.ToString().Replace(",", "");
                    decimal.TryParse(rawAmount, out decimal rowTotal);

                    bool isNonVat = false;
                    if (row.Cells[7].Value.ToString() != null)
                    {
                        bool.TryParse(row.Cells[7].Value.ToString(), out isNonVat);
                    }

                    if(isNonVat)
                    {
                        vatExempt += rowTotal;
                    }
                    else
                    {
                        decimal netVat = Math.Round(rowTotal / 1.12m, 2, MidpointRounding.AwayFromZero);
                        vatableSales += netVat;
                        vatAmount += (rowTotal - netVat);
                    }
                }
            }

        }
        
        private ProductRecord FetchProductFromDatabase (string barcode)
        {
            string query = "SELECT ENG_NAME, KOR_NAME, R_PRICE, D_PRICE_A, D_PRICE_B, D_PRICE_C, NON_VAT FROM PRODMAST WHERE BARCODE = ?";

            using (OleDbConnection con = new OleDbConnection(DatabaseConfig.GetConnectionString()))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("?", barcode);

                    try
                    {
                        con.Open();
                        using(OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new ProductRecord
                                {
                                    Barcode = barcode,
                                    EngName = reader["ENG_NAME"].ToString(),
                                    KorName = reader["KOR_NAME"].ToString(),
                                    RegPrice = Convert.ToDecimal(reader["R_PRICE"]),
                                    WholesalePrice = Convert.ToDecimal(reader["D_PRICE_A"]),
                                    VipPrice = Convert.ToDecimal(reader["D_PRICE_B"]),
                                    RoyalPrice = Convert.ToDecimal(reader["D_PRICE_C"]),
                                    IsNonVat = reader["NON_VAT"] != DBNull.Value && Convert.ToBoolean(reader["NON_VAT"])
                                };
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Database Error: " + ex.Message, "Error");
                    }
                }
            }
            return null;
        }
    }
}
