using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EnchantedPOS
{
    public partial class formAdminDashboard : Form
    {
        public formAdminDashboard()
        {
            InitializeComponent();
        }

        private void formAdminDashboard_Load(object sender, EventArgs e)
        {
            btnDashboard.PerformClick();
        }

        private void LoadScreen(UserControl uc)
        {
            // 1. Clear out whatever screen is currently showing
            panelWorkspace.Controls.Clear();

            // 2. Make the new screen stretch to fill the whole panel
            uc.Dock = DockStyle.Fill;

            // 3. Add the new screen to the panel
            panelWorkspace.Controls.Add(uc);
            uc.BringToFront();
        }

        private void LoadModule(UserControl selectedControl)
        {
            panelWorkspace.Controls.Clear();
            selectedControl.Dock = DockStyle.Fill;
            panelWorkspace.Controls.Add(selectedControl);
            selectedControl.BringToFront();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ucDashboard dashboard = new ucDashboard();
            LoadModule(dashboard);
        }

        private void btnProductMasterFile_Click(object sender, EventArgs e)
        {
            ucProductMaster productMasterScreen = new ucProductMaster();
            LoadModule(productMasterScreen);
        }
    }
}
