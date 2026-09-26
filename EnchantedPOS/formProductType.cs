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
    public partial class formProductType : Form
    {

        private DataTable dt;
        public formProductType()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                string query = "SELECT TYPE_ID, DESCRIPTION FROM PRODUCT_TYPE";
                using (MySqlConnection con = DatabaseConfig.GetConnection())
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter(query, con))
                    {
                        dt = new DataTable();
                        da.Fill(dt);

                        dgvProductType.DataSource = dt;

                        dgvProductType.Columns["TYPE_ID"].Visible = false;

                        dgvProductType.Columns["DESCRIPTION"].HeaderText = "Description";
                        dgvProductType.Columns["DESCRIPTION"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveData()
        {
            try
            {
                dgvProductType.EndEdit();

                string query = "SELECT TYPE_ID, DESCRIPTION FROM PRODUCT_TYPE";

                using (MySqlConnection con = DatabaseConfig.GetConnection())
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, con))
                    {
                        MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);

                        adapter.Update(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving changes: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            SaveData();
            this.Close();
        }
    }
}
