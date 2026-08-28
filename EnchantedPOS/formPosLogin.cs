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
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void formPosLogin_Load(object sender, EventArgs e)
        {
            Form1 f = new Form1();

            f.disablelogIn();
            labelWelcome.Text = $"Hello, {cashierName}";

        }
    }
}
