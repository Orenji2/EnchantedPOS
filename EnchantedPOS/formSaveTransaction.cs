using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EnchantedPOS
{
    public partial class formSaveTransaction : Form
    {

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

        

        private void LoadPaymentMethods()
        {
            string query = "SELECT [PAYMENT_METHODS], ENABLED FROM PAYMENT_METHODS";

            using (OleDbConnection con = new OleDbConnection(DatabaseConfig.GetConnectionString()))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    try
                    {
                        con.Open();
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                string method = reader["PAYMENT_METHODS"].ToString().ToUpper().Trim();
                                bool isEnabled = Convert.ToBoolean(reader["ENABLED"]);

                                switch(method)
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
        }

        private void btnReceivePayment_Click(object sender, EventArgs e)
        {
            txtReceivedAmount.Focus();
        }

        private void txtReceived_KeyDown(object sender, KeyEventArgs e)
        {

            if(e.KeyCode == Keys.Enter)
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
    }
}
