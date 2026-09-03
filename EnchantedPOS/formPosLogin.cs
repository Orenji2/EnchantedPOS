using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EnchantedPOS
{
    public partial class formPosLogin : Form
    {

        public int ShiftNumber { get; private set; }
        public decimal ChangeFunds { get; private set; }
        public DateTime TransDate { get; private set; }
        public int StationNumber { get; private set; } = 1;

        private string cashierName = "";

        private bool loginBtn;

        public formPosLogin(string passedName, bool passedIsAdmin, bool passedLogin)
        {
            InitializeComponent();

            cashierName = passedName;
            loginBtn = passedLogin;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

           
        }

        private void btnLogin2_Click(object sender, EventArgs e)
        {
            if(!int.TryParse(txtShiftNumber.Text, out int shiftNum))
            {
                MessageBox.Show("Please enter a valid Shift Number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtShiftNumber.Focus();
                txtShiftNumber.SelectAll();
                return;
            }
            if (!decimal.TryParse(txtChangeFunds.Text, out decimal changeFunds))
            {
                MessageBox.Show("Please enter a valid amount for Change Funds.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtChangeFunds.Focus();
                txtChangeFunds.SelectAll();
                return;
            }

            TransDate = dateTrans.Value.Date;
            ShiftNumber = shiftNum;
            ChangeFunds = changeFunds;

            this.DialogResult = DialogResult.OK;
            this.Close();

            
        }

        private void formPosLogin_Load(object sender, EventArgs e)
        {
            Form1 f = new Form1();

            f.disablelogIn();
            labelWelcome.Text = $"Hello, {cashierName}";
            this.ActiveControl = dateTrans;

        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTrans_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                txtShiftNumber.Focus();
                txtShiftNumber.SelectAll();
            }
        }

        private void txtShiftNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                txtChangeFunds.Focus();
                txtChangeFunds.SelectAll();
            }
        }

        private void txtChangeFunds_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                btnLogin2_Click(sender, e);
            }
        }
    }
}
