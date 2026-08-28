using EnchantedPOS;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System.Data.OleDb;
using System.Diagnostics.Eventing.Reader;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EnchantedPOS
{
    public partial class Form1 : Form
    {
        public string currentFirstName = "";
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
                string query = "SELECT F_NAME, IS_ADMIN, IS_CASHIER FROM LOGIN WHERE U_PASS = ?";

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
                                string fName = reader["F_NAME"].ToString();

                                bool isAdmin = Convert.ToBoolean(reader["IS_ADMIN"]);
                                bool isCashier = Convert.ToBoolean(reader["IS_CASHIER"]);

                                RouteCashier(fName, isAdmin, isCashier);
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

        private void RouteCashier(string fName, bool isAdmin, bool isCashier)
        {
            formPOS pos = new formPOS();


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
                        formPOS pos = new formPOS();
                        pos.Show();
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        // They clicked Cancel! Log them out on THIS exact form.
                        logOut();

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
                        formPOS pos = new formPOS();
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


        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            openPosForm(currentFirstName, currentIsAdmin);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            logOut();
        }
    }
}
