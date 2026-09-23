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
    public partial class formSaveTransaction : Form
    {

        public string SelectedPaymentMethod { get; private set; } = "CASH";
        public int? SelectedCustomerID { get; private set; } = null;
        public string SelectedCustomerName { get; private set; } = "";

        public decimal FinalNetAmount { get; private set; }
        public decimal FinalReceivedAmount { get; private set; }
        public decimal FinalChangeAmount { get; private set; }

        public formSaveTransaction(decimal totalAmount)
        {
            InitializeComponent();

            LoadPaymentMethods();

            FinalNetAmount = totalAmount;

            txtReceivedAmount.ReadOnly = false;
            txtReceivedAmount.Enabled = true;
        }

        private void formSaveTransaction_Load(object sender, EventArgs e)
        {
            panelPayment.Visible = false;

            txtSales.Text = FinalNetAmount.ToString("N2");
            txtNetAmount.Text = FinalNetAmount.ToString("N2");
        }

        private bool PromptForCustomer()
        {
            Form prompt = new Form()
            {
                Width = 350,
                Height = 180,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Select Customer Account",
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label lbl = new Label() { Left = 20, Top = 20, Text = "Select Customer:" };
            ComboBox cmbCustomers = new ComboBox() { Left = 20, Top = 45, Width = 290, DropDownStyle = ComboBoxStyle.DropDownList };
            Button btnOK = new Button() { Text = "Charge Account", Left = 160, Width = 150, Top = 90, DialogResult = DialogResult.OK };
            Button btnCancel = new Button() { Text = "Cancel", Left = 20, Width = 100, Top = 90, DialogResult = DialogResult.Cancel };

            prompt.Controls.Add(lbl); prompt.Controls.Add(cmbCustomers);
            prompt.Controls.Add(btnOK); prompt.Controls.Add(btnCancel);
            prompt.AcceptButton = btnOK;

            // Fetch customers from your database
            string query = "SELECT CUST_ID, CUST_NAME FROM CUSTOMER_MAST ORDER BY CUST_NAME ASC";
            using (MySqlConnection con = DatabaseConfig.GetConnection())
            {
                using (MySqlDataAdapter da = new MySqlDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbCustomers.DataSource = dt;
                    cmbCustomers.DisplayMember = "CUST_NAME";
                    cmbCustomers.ValueMember = "CUST_ID";
                    cmbCustomers.SelectedIndex = -1;
                }
            }

            if (prompt.ShowDialog() == DialogResult.OK && cmbCustomers.SelectedValue != null)
            {
                SelectedCustomerID = Convert.ToInt32(cmbCustomers.SelectedValue);
                SelectedCustomerName = cmbCustomers.Text;
                return true;
            }

            return false;
        }

        private void LoadPaymentMethods()
        {
            string query = "SELECT PAYMENT_METHODS, ENABLED FROM PAYMENT_METHODS";

            using (MySqlConnection con = DatabaseConfig.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    try
                    {

                        if (con.State != ConnectionState.Open) con.Open();

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string method = reader["PAYMENT_METHODS"].ToString().ToUpper().Trim();
                                bool isEnabled = Convert.ToBoolean(reader["ENABLED"]);

                                switch (method)
                                {
                                    case "CASH":
                                        btnCash.Enabled = isEnabled;
                                        break;
                                    case "CARD":
                                        btnCC.Enabled = isEnabled;
                                        break;
                                    case "CHECK":
                                        btnCheck.Enabled = isEnabled;
                                        break;
                                    case "GIFT CERT":
                                        btnGC.Enabled = isEnabled;
                                        break;
                                    case "SALES ON ACCOUNT":
                                        btnSoA.Enabled = isEnabled;
                                        break;
                                }
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Could not load payment settings: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            panelPayment.Visible = true;
            btnReceivePayment.Focus();

            SelectedPaymentMethod = "CASH";
            SelectedCustomerID = null;
            SelectedCustomerName = "";

            txtReceivedAmount.ReadOnly = false;
            txtReceivedAmount.Clear();
            txtChange.Text = "0.00";

            panelPayment.Visible = true;
            btnReceivePayment.Focus();

        }

        private void btnReceivePayment_Click(object sender, EventArgs e)
        {
            txtReceivedAmount.Focus();
        }

        private void txtReceived_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                //Try to parse what cashier typed
                if (decimal.TryParse(txtReceivedAmount.Text, out decimal received))
                {
                    // Validation
                    if (received >= FinalNetAmount)
                    {
                        FinalReceivedAmount = received;
                        FinalChangeAmount = FinalReceivedAmount - FinalNetAmount;

                        // Format
                        txtReceivedAmount.Text = FinalReceivedAmount.ToString("N2");
                        txtChange.Text = FinalChangeAmount.ToString("N2");

                        btnPaymentOK.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Received amount cannot be less than the Net Amount.", "Insufficient Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtReceivedAmount.SelectAll();
                    }
                }
                else
                {
                    txtReceivedAmount.SelectAll();
                }
            }


        }

        private void btnPaymentOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnSoA_Click(object sender, EventArgs e)
        {
            if (PromptForCustomer())
            {
                SelectedPaymentMethod = "SALES ON ACCOUNT";

                FinalReceivedAmount = FinalNetAmount;
                FinalChangeAmount = 0;

                txtReceivedAmount.Text = FinalReceivedAmount.ToString("N2");
                txtChange.Text = "0.00";

                txtReceivedAmount.ReadOnly = true;

                panelPayment.Visible = true;

                MessageBox.Show($"Transaction will be charged to: {SelectedCustomerName}", "Account Linked", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnPaymentOK.Focus();
            }
        }
    }
}
