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
        public ucFileMaintenance()
        {
            InitializeComponent();
            LoadUsers();
            ToggleEditMode(false);
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
                            MessageBox.Show("User deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ClearTextBoxes();
                            ToggleEditMode(false);
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
    }
}
