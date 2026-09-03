using EnchantedPOS;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System.Data.OleDb;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EnchantedPOS
{
    public partial class Form1 : Form
    {
        public string currentFirstName = "";
        public int currentCashierId;
        public bool currentIsAdmin;

        public static bool boolLoginStatus;


        public Form1(bool boolLogin = false)
        {
            InitializeComponent();

            // Reference to the directory of the exe file
            string exeFolder = AppDomain.CurrentDomain.BaseDirectory;

            // Reference to the Path of the Database
            string dbPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(exeFolder, @"..\..\..\dbEn.accdb"));

            // Access uses an OLEDB provider pointing directly to your local file
            string connString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbPath};";
            string qHeader = "SELECT * FROM businessInfo WHERE ID = @ID";

            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                using (OleDbCommand cmd = new OleDbCommand(qHeader, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", 2);

                    try
                    {
                        conn.Open(); // Open the connection stream
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string bName = reader["bName"].ToString();
                                string bAddress = reader["bAddress"].ToString();

                                lblName.Text = bName;
                                lblAddress.Text = bAddress;
                            }
                            else
                            {
                                lblName.Text = "Database Error: No String found";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Database Error: " + ex.Message);
                    }
                }
            }
        }
        private void btnLogIn_Click(object sender, EventArgs e)
        {

            string entC_Pass = txtC_Pass.Text.Trim();

            if (string.IsNullOrEmpty(txtC_Pass.Text))
            {
                MessageBox.Show("Please Enter Cashier's Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // MessageBox.Show("This Button is working");

            CheckCashierLogin(entC_Pass);
        }

        private void CheckCashierLogin(string CashierPass)
        {
            // Reference to the directory of the exe file
            string exeFolder = AppDomain.CurrentDomain.BaseDirectory;

            // Reference to the Path of the Database
            string dbPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(exeFolder, @"..\..\..\dbEn.accdb"));

            // Access uses an OLEDB provider pointing directly to your local file
            string connString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbPath};";

            using (OleDbConnection con = new OleDbConnection(connString))
            {
                string query = "SELECT USER_ID, F_NAME, IS_ADMIN, IS_CASHIER FROM LOGIN WHERE U_PASS = ?";

                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("?", CashierPass);

                    try
                    {
                        con.Open();
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // User exists
                                int id = Convert.ToInt32(reader["USER_ID"]);
                                string fName = reader["F_NAME"].ToString();

                                bool isAdmin = Convert.ToBoolean(reader["IS_ADMIN"]);
                                bool isCashier = Convert.ToBoolean(reader["IS_CASHIER"]);

                                RouteCashier(id, fName, isAdmin, isCashier);
                            }
                            else
                            {
                                MessageBox.Show("Cashier not found");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Database Error: " + ex.Message);
                    }
                }
            }
        }

        private void RouteCashier(int id, string fName, bool isAdmin, bool isCashier)
        {
            //Global values
            currentCashierId = id;
            currentFirstName = fName;
            currentIsAdmin = isAdmin;

            if (isAdmin && isCashier)
            {
                txtC_Pass.Text = "";
                MessageBox.Show($"Welcome Ma'am {fName}! You have full Authority in POS and Admin Menu");
                enableManagementButtons();

            }
            else if (isAdmin)
            {
                txtC_Pass.Text = "";
                MessageBox.Show($"Welcome {fName}! Opening Admin Dashboard");
            }
            else if (isCashier)
            {
                txtC_Pass.Text = "";
                // Open POS Form
                openPosForm(fName, isAdmin);
            }
            else if (isCashier || (isAdmin && isCashier))
            {
                txtC_Pass.Text = "";
                panelPOSLogin.Visible = false;


                formPosLogin loginForm = new formPosLogin(fName, isAdmin, boolLoginStatus);

                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    formPOS pos = new formPOS(
                    id,
                    fName,
                    loginForm.ShiftNumber,
                    loginForm.ChangeFunds,
                    loginForm.TransDate,
                    loginForm.StationNumber
        );
                    pos.Show();
                }
                
                btnPOS.Visible = true;
                btnReports.Visible = true;
                btnAdmin.Visible = true;
            }
            else
            {
                txtC_Pass.Text = "";
                MessageBox.Show("This account has no active roles assinged");
            }
        }

        private void enableManagementButtons()
        {
            boolLoginStatus = btnLogIn.Enabled;

            btnReports.Enabled = true;
            btnPOS.Enabled = true;
            btnAdmin.Enabled = true;
            btnLogOut.Enabled = true;

            txtC_Pass.Enabled = false;
            btnLogIn.Enabled = false;
        }

        public void disablelogIn()
        {
            txtC_Pass.Enabled = false;
        }

        public void logOut()
        {
            btnReports.Enabled = false;
            btnPOS.Enabled = false;
            btnAdmin.Enabled = false;

            btnLogIn.Enabled = true;
            btnLogOut.Enabled = false;
        }



        public void openPosForm(string firstName, bool isAdmin)
        {
            formPOS existingPos = Application.OpenForms.OfType<formPOS>().FirstOrDefault();

            if (!isAdmin)
            {
                if (existingPos != null)
                {
                    if (existingPos.WindowState == FormWindowState.Minimized)
                    {
                        existingPos.WindowState = FormWindowState.Normal;
                    }
                    existingPos.BringToFront();
                    existingPos.Activate();


                    MessageBox.Show("POS window is already open");
                }
                else
                {
                    MessageBox.Show($"Welcome {firstName}! Opening POS System.");
                    formPosLogin login = new formPosLogin(firstName, isAdmin, boolLoginStatus);
                    DialogResult result = login.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        // They clicked Login2! Open the POS form.
                        formPOS pos = new formPOS(
                            currentCashierId,
                            firstName,
                            login.ShiftNumber,
                            login.ChangeFunds,
                            login.TransDate,
                            login.StationNumber
                            );
                        pos.Show();
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        // They clicked Cancel! Log them out on THIS exact form.
                        btnPOS.Visible = true;
                        btnPOS.Enabled = true;

                        btnReports.Visible = true;
                        btnReports.Enabled = true;

                        btnAdmin.Visible = true;
                        btnAdmin.Enabled = true;

                        // Hide the login panel if it was showing
                        // panelLogin.Visible = false;

                        // Optionally, re-enable the login button if they cancelled
                        // btnLogIn.Enabled = true; 
                    }
                }
            }
           
            else
            {
                if (existingPos != null)
                {
                    if (existingPos.WindowState == FormWindowState.Minimized)
                    {
                        existingPos.WindowState = FormWindowState.Normal;
                    }

                    existingPos.BringToFront();
                    existingPos.Activate();

                    MessageBox.Show("Log the current cashier out first");

                    return;
                }
                else
                {

                    MessageBox.Show($"Welcome Ma'am {firstName}! Opening POS System.");

                    disablelogIn();

                    formPosLogin login = new formPosLogin(firstName, isAdmin, boolLoginStatus);
                    DialogResult result = login.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        // They clicked Login2! Open the POS form.
                        formPOS pos = new formPOS(
                            currentCashierId,
                            firstName,
                            login.ShiftNumber,
                            login.ChangeFunds,
                            login.TransDate,
                            login.StationNumber
                            );
                        pos.Show();
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        // They clicked Cancel! Log them out on THIS exact form.
                        logOut();

                        // Optionally, re-enable the login button if they cancelled
                        // btnLogIn.Enabled = true; 
                    }

                    // this.Hide();
                }
            }
            panelPOSLogin.Visible = false;
            btnPOS.Visible = true;
            btnReports.Visible = true;
            btnAdmin.Visible = true;


        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            // openPosForm(currentFirstName, currentIsAdmin);
            formPOS existingPos = Application.OpenForms.OfType<formPOS>().FirstOrDefault();
            if (existingPos != null)
            {
                if (existingPos.WindowState == FormWindowState.Minimized)
                {
                    existingPos.WindowState = FormWindowState.Normal;
                }
                existingPos.BringToFront();
                existingPos.Activate();
                MessageBox.Show("POS Window is already open.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            panelPOSLogin.Visible = true;

            btnPOS.Visible = false;
            btnReports.Visible = false;
            btnAdmin.Visible = false;

            txtC_Pass.Clear();
            txtC_Pass.Enabled = true;
            txtC_Pass.Focus();
            txtC_Pass.Select();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            panelPOSLogin.Visible = false;
            btnPOS.Visible = true;
            btnReports.Visible = true;
            btnAdmin.Visible = true;
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            if (CheckAdminPassword())
            {
                MessageBox.Show("Access Granted to Admin Menu.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // TODO: Open your Admin Form
            }
            else
            {
                MessageBox.Show("Incorrect Password.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool CheckAdminPassword()
        {
            string globalPassword = "admin"; //Global Password

            Form prompt = new Form()
            {
                Width = 300,
                Height = 160,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Admin Password",
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

        private void btnReports_Click(object sender, EventArgs e)
        {
            // Prompt for admin password or check if current user is admin
            if (CheckAdminPassword()) // Reusing your existing manager override method!
            {
                MessageBox.Show("Access Granted to Reports.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // TODO: Open your Reports Form
            }
            else
            {
                MessageBox.Show("Incorrect Password.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtC_Pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogIn.Focus();
            }
        }
    }
}
