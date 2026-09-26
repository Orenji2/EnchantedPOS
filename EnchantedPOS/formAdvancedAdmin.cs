using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EnchantedPOS
{
    public partial class formAdvancedAdmin : Form
    {
        public formAdvancedAdmin()
        {
            InitializeComponent();
        }

        private void customerMasterFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void productMasterFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form wrapperForm = new Form
            {
                Text = "Product Master File",
                Width = 1050,
                Height = 750,
                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.Sizable
            };

            ucProductMaster ucProductMaster = new ucProductMaster
            {
                Dock = DockStyle.Fill
            };

            wrapperForm.Controls.Add(ucProductMaster);
            wrapperForm.ShowDialog(this);
        }

        private void productTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (formProductType prodTypeForm = new formProductType())
            {
                prodTypeForm.ShowDialog(this);
            }
        }


    }
}
