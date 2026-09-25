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
    public partial class ucFileMaintenance : UserControl
    {

        private bool isAdding = false;
        private bool isSuppAdding = false;
        private bool isCustAdding = false;
        public ucFileMaintenance()
        {
            InitializeComponent();
            LoadUsers();
            ToggleEditMode(false);
            LoadSuppliers();
            ToggleSuppEditMode(false);
            ToggleCustEditMode(false);
            LoadCustomers();
        }

        private void ToggleEditMode(bool isEditing)
        {
            // Lock/Unlock Inputs
            txtFirstName.Enabled = isEditing;
            txtLastName.Enabled = isEditing;
            txtPassword.Enabled = isEditing;
            txtAddress.Enabled = isEditing;
            checkIsCashier.Enabled = isEditing;
            checkIsAdmin.Enabled = isEditing;

            // Toggle Action Buttons
            btnSave.Enabled = isEditing;
            btnCancel.Enabled = isEditing;

            // Toggle Entry Buttons
            btnAdd.Enabled = !isEditing;
            btnEdit.Enabled = !isEditing;
            btnDelete.Enabled = !isEditing; // Only allow delete when an item is selected, not while editing
        }

        private void ToggleSuppEditMode(bool isEditing)
        {
            txtSuppName.Enabled = isEditing;
            txtContactPerson.Enabled = isEditing;
            txtContactNo.Enabled = isEditing;

            btnSave.Enabled = isEditing;
            btnSuppCancel.Enabled = isEditing;

            btnSuppAdd.Enabled = !isEditing;
            btnSuppEdit.Enabled = !isEditing;
            btnSuppDelete.Enabled = !isEditing;
        }

        private void ToggleCustEditMode(bool isEditing)
        {
            txtCustName.Enabled = isEditing;
            txtCustContactNo.Enabled = isEditing;
            txtCustAddress.Enabled = isEditing;
            txtCreditLimit.Enabled = isEditing;

            btnCustSave.Enabled = isEditing;
            btnCustCancel.Enabled = isEditing;

            btnCustAdd.Enabled = !isEditing;
            btnCustEdit.Enabled = !isEditing;
            btnCustDelete.Enabled = !isEditing;
        }

        private void ClearTextBoxes()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtPassword.Clear();
            txtAddress.Clear();

            checkIsCashier.Checked = false;
            checkIsAdmin.Checked = false;

            txtFirstName.Tag = null; // Clear the hidden ID so we don't accidentally update an old record!
        }

        private void ClearSuppTextBoxes()
        {
            txtSuppName.Clear();
            txtContactPerson.Clear();
            txtContactNo.Clear();
            txtAddress.Clear();

            txtSuppName.Tag = null;
        }

        private void ClearCustTextBoxes()
        {
            txtCustName.Clear();
            txtCustContactNo.Clear();
            txtCustAddress.Clear();
            txtCreditLimit.Text = "0.00";
            lblCurrBalance.Text = "0.00";

            txtCustName.Tag = null;
        }

        private void LoadUsers()
        {
            string query = "SELECT USER_ID, U_PASS, F_NAME, L_NAME, `ADD`, IS_CASHIER, IS_ADMIN FROM LOGIN";

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
                            dgvUsers.DataSource = dt;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading users: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LoadSuppliers()
        {
            string query = "SELECT SUPP_ID, SUPP_NAME, CONTACT_PERSON, CONTACT_NO, ADDRESS FROM SUPPLIER_MAST";
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
                            dgvSuppliers.DataSource = dt;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading suppliers: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LoadCustomers()
        {
            string query = "SELECT CUST_ID, CUST_NAME, CONTACT_NO, ADDRESS, CREDIT_LIMIT, CURR_BALANCE FROM CUSTOMER_MAST";
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
                            dgvCustomers.DataSource = dt;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading customers: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }



        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsers.Rows[e.RowIndex];

                txtFirstName.Text = row.Cells["F_NAME"].Value?.ToString();
                txtLastName.Text = row.Cells["L_NAME"].Value?.ToString();
                txtPassword.Text = row.Cells["U_PASS"].Value?.ToString();
                txtAddress.Text = row.Cells["ADD"].Value?.ToString();
                txtUserID.Text = row.Cells["USER_ID"].Value?.ToString();

                // Handle the booleans safely
                checkIsCashier.Checked = row.Cells["IS_CASHIER"].Value != DBNull.Value && Convert.ToBoolean(row.Cells["IS_CASHIER"].Value);
                checkIsAdmin.Checked = row.Cells["IS_ADMIN"].Value != DBNull.Value && Convert.ToBoolean(row.Cells["IS_ADMIN"].Value);

                // Store the ID for Updates/Deletes
                txtFirstName.Tag = row.Cells["USER_ID"].Value?.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("First Name and Password are required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection con = DatabaseConfig.GetConnection())
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;

                // 2. Assign Parameters
                cmd.Parameters.AddWithValue("@pass", txtPassword.Text.Trim());
                cmd.Parameters.AddWithValue("@fname", txtFirstName.Text.Trim());
                cmd.Parameters.AddWithValue("@lname", txtLastName.Text.Trim());
                cmd.Parameters.AddWithValue("@add", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@isCashier", checkIsCashier.Checked);
                cmd.Parameters.AddWithValue("@isAdmin", checkIsAdmin.Checked);

                try
                {
                    if (isAdding)
                    {
                        // INSERT NEW USER
                        // Notice the backticks around `ADD` to bypass the reserved keyword rule!
                        cmd.CommandText = @"INSERT INTO LOGIN 
                                    (U_PASS, F_NAME, L_NAME, `ADD`, IS_CASHIER, IS_ADMIN) 
                                    VALUES (@pass, @fname, @lname, @add, @isCashier, @isAdmin)";
                    }
                    else
                    {
                        // UPDATE EXISTING USER
                        cmd.CommandText = @"UPDATE LOGIN SET 
                                    U_PASS = @pass, F_NAME = @fname, L_NAME = @lname, 
                                    `ADD` = @add, IS_CASHIER = @isCashier, IS_ADMIN = @isAdmin 
                                    WHERE USER_ID = @id";

                        cmd.Parameters.AddWithValue("@id", txtFirstName.Tag);
                    }

                    // 3. Execute
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 4. Reset UI
                    isAdding = false;
                    // ToggleEditMode(false); // Uncomment once you copy over your Toggle method
                    LoadUsers(); // Refresh the grid!
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving user: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAdding = true;
            ClearTextBoxes();
            ToggleEditMode(true);
            txtFirstName.Focus(); // Put the cursor in the first box automatically
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Prevent editing if they haven't clicked a user in the grid yet
            if (txtFirstName.Tag == null)
            {
                MessageBox.Show("Please select a user from the list first.", "No User Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            isAdding = false;
            ToggleEditMode(true);
            txtFirstName.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            isAdding = false;
            ClearTextBoxes();
            ToggleEditMode(false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Tag == null || string.IsNullOrWhiteSpace(txtFirstName.Tag.ToString()))
            {
                MessageBox.Show("Please select a user from the list to delete.", "No User Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtFirstName.Tag.ToString() == "1")
            {
                MessageBox.Show("You cannot delete the primary administrator account!", "Action Denied", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to PERMANENTLY delete {txtFirstName.Text} {txtLastName.Text}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Error);

            if (result == DialogResult.Yes)
            {
                using (MySqlConnection con = DatabaseConfig.GetConnection())
                {
                    string query = "DELETE FROM LOGIN WHERE USER_ID = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", txtFirstName.Tag.ToString());

                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Customer deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ClearTextBoxes();
                            ToggleCustEditMode(false);
                            LoadUsers(); // Refresh the grid to remove the deleted user
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error deleting user: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvSuppliers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSuppliers.Rows[e.RowIndex];

                txtSuppName.Text = row.Cells["SUPP_NAME"].Value?.ToString();
                txtContactPerson.Text = row.Cells["CONTACT_PERSON"].Value?.ToString();
                txtContactNo.Text = row.Cells["CONTACT_NO"].Value?.ToString();
                txtAddress.Text = row.Cells["ADDRESS"].Value?.ToString();
                txtSuppID.Text = row.Cells["SUPP_ID"].Value?.ToString();

                txtSuppName.Tag = row.Cells["SUPP_ID"].Value?.ToString();
            }
        }

        private void btnSuppSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSuppName.Text))
            {
                MessageBox.Show("Supplier Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection con = DatabaseConfig.GetConnection())
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;

                cmd.Parameters.AddWithValue("@name", txtSuppName.Text.Trim());
                cmd.Parameters.AddWithValue("@person", txtContactPerson.Text.Trim());
                cmd.Parameters.AddWithValue("@no", txtContactNo.Text.Trim());
                cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());

                try
                {
                    if (isSuppAdding)
                    {
                        cmd.CommandText = @"INSERT INTO SUPPLIER_MAST (SUPP_NAME, CONTACT_PERSON, CONTACT_NO, ADDRESS) VALUES (@name, @person, @no, @address)";
                    }
                    else
                    {
                        cmd.CommandText = @"UPDATE SUPPLIER_MAST SET 
                                    SUPP_NAME = @name, CONTACT_PERSON = @person, 
                                    CONTACT_NO = @no, ADDRESS = @address 
                                    WHERE SUPP_ID = @id";
                        cmd.Parameters.AddWithValue("@id", txtSuppName.Tag);
                    }

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Supplier saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    isSuppAdding = false;
                    ToggleSuppEditMode(false);
                    LoadSuppliers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving supplier: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSuppAdd_Click(object sender, EventArgs e)
        {
            isSuppAdding = true;
            ClearSuppTextBoxes();
            ToggleSuppEditMode(true);
            txtSuppName.Focus(); // Put the cursor in the first box automatically
        }

        private void btnSuppEdit_Click(object sender, EventArgs e)
        {
            // Prevent editing if they haven't clicked a user in the grid yet
            if (txtSuppName.Tag == null)
            {
                MessageBox.Show("Please select a supplier from the list first.", "No Supplier Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            isSuppAdding = false;
            ToggleSuppEditMode(true);
            txtSuppName.Focus();
        }

        private void btnSuppDelete_Click(object sender, EventArgs e)
        {
            if (txtSuppName.Tag == null || string.IsNullOrWhiteSpace(txtSuppName.Tag.ToString()))
            {
                MessageBox.Show("Please select a user from the list to delete.", "No User Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to PERMANENTLY delete {txtSuppName.Text} ?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Error);

            if (result == DialogResult.Yes)
            {
                using (MySqlConnection con = DatabaseConfig.GetConnection())
                {
                    string query = "DELETE FROM SUPPLIER_MAST WHERE SUPP_ID = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", txtSuppName.Tag.ToString());

                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Supplier deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ClearSuppTextBoxes();
                            ToggleEditMode(false);
                            LoadSuppliers(); // Refresh the grid to remove the deleted supplier
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error deleting user: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnSuppCancel_Click(object sender, EventArgs e)
        {
            isSuppAdding = false;
            ClearSuppTextBoxes();
            ToggleSuppEditMode(false);
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];

                txtCustName.Text = row.Cells["CUST_NAME"].Value?.ToString();
                txtCustContactNo.Text = row.Cells["CONTACT_NO"].Value?.ToString();
                txtCustAddress.Text = row.Cells["ADDRESS"].Value?.ToString();
                txtCreditLimit.Text = row.Cells["CREDIT_LIMIT"].Value?.ToString();
                lblCurrBalance.Text = row.Cells["CURR_BALANCE"].Value?.ToString();

                txtCustName.Tag = row.Cells["CUST_ID"].Value?.ToString();
            }
        }

        private void btnCustSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustName.Text))
            {
                MessageBox.Show("Customer Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection con = DatabaseConfig.GetConnection())
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;

                decimal.TryParse(txtCreditLimit.Text, out decimal creditLimit);

                cmd.Parameters.AddWithValue("@name", txtCustName.Text.Trim());
                cmd.Parameters.AddWithValue("@no", txtCustContactNo.Text.Trim());
                cmd.Parameters.AddWithValue("@address", txtCustAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@limit", creditLimit);

                try
                {
                    if (isCustAdding)
                    {
                        cmd.CommandText = @"INSERT INTO CUSTOMER_MAST 
                                    (CUST_NAME, CONTACT_NO, ADDRESS, CREDIT_LIMIT) 
                                    VALUES (@name, @no, @address, @limit)";
                    }
                    else
                    {
                        cmd.CommandText = @"UPDATE CUSTOMER_MAST SET 
                                    CUST_NAME = @name, CONTACT_NO = @no, 
                                    ADDRESS = @address, CREDIT_LIMIT = @limit 
                                    WHERE CUST_ID = @id";
                        cmd.Parameters.AddWithValue("@id", txtCustName.Tag);
                    }

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    isCustAdding = false;
                    ToggleCustEditMode(false);
                    LoadCustomers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving customer: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCustAdd_Click(object sender, EventArgs e)
        {
            isCustAdding = true;
            ClearTextBoxes();
            ToggleCustEditMode(true);
            txtCustName.Focus(); // Put the cursor in the first box automatically
        }

        private void btnCustEdit_Click(object sender, EventArgs e)
        {
            // Prevent editing if they haven't clicked a user in the grid yet
            if (txtCustName.Tag == null)
            {
                MessageBox.Show("Please select a Customer from the list first.", "No Customer Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            isCustAdding = false;
            ToggleCustEditMode(true);
            txtCustName.Focus();
        }

        private void btnCustDelete_Click(object sender, EventArgs e)
        {
            if (txtCustName.Tag == null || string.IsNullOrWhiteSpace(txtCustName.Tag.ToString()))
            {
                MessageBox.Show("Please select a user from the list to delete.", "No User Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to PERMANENTLY delete {txtCustName.Text} ?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Error);

            if (result == DialogResult.Yes)
            {
                using (MySqlConnection con = DatabaseConfig.GetConnection())
                {
                    string query = "DELETE FROM CUSTOMER_MAST WHERE CUST_ID = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", txtCustName.Tag.ToString());

                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Supplier deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ClearCustTextBoxes();
                            ToggleEditMode(false);
                            LoadSuppliers(); // Refresh the grid to remove the deleted supplier
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error deleting user: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnCustCancel_Click(object sender, EventArgs e)
        {
            isCustAdding = false;
            ClearCustTextBoxes();
            ToggleCustEditMode(false);
        }
    }
}
