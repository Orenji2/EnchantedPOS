using EnchantedPOS;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data.OleDb;

namespace EnchantedPOS
{
    public partial class Form1 : Form
    {

        public Form1()
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

            if(string.IsNullOrEmpty(txtChange.Text))
            {
                MessageBox.Show("Please Enter Cashier's Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // MessageBox.Show("This Button is working");

            // Reference to the directory of the exe file
            string exeFolder = AppDomain.CurrentDomain.BaseDirectory;

            // Reference to the Path of the Database
            string dbPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(exeFolder, @"..\..\..\dbEn.accdb"));

            // Access uses an OLEDB provider pointing directly to your local file
            string connString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbPath};";


            string qLogin = "SELECT * FROM LOGIN WHERE ID=@ID";

            using (OleDbConnection con = new OleDbConnection(connString))
            {
                using (OleDbCommand cmd = new OleDbCommand(qLogin, con))
                {
                    cmd.Parameters.AddWithValue("?", txtC_Pass.Text.Trim());

                    try
                    {
                        con.Open();

                        int userCount = (int)cmd.ExecuteScalar();

                        if (userCount > 0)
                        {
                            
                        }

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            bool isCashier = reader.Read();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Database Error: " + ex.Message);
                    }
                }
            }
           
        }
    }
}
