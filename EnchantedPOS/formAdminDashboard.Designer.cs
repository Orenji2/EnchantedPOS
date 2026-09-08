namespace EnchantedPOS
{
    partial class formAdminDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelSidebar = new Panel();
            button1 = new Button();
            button3 = new Button();
            btnProductMasterFile = new Button();
            btnFileMaintenance = new Button();
            btnDashboard = new Button();
            panelWorkspace = new Panel();
            panelSidebar.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.DimGray;
            panelSidebar.Controls.Add(button1);
            panelSidebar.Controls.Add(button3);
            panelSidebar.Controls.Add(btnProductMasterFile);
            panelSidebar.Controls.Add(btnFileMaintenance);
            panelSidebar.Controls.Add(btnDashboard);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(250, 753);
            panelSidebar.TabIndex = 0;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Top;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.White;
            button1.Location = new Point(0, 200);
            button1.Name = "button1";
            button1.Size = new Size(250, 50);
            button1.TabIndex = 4;
            button1.Text = "REPORTS";
            button1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Dock = DockStyle.Top;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = Color.White;
            button3.Location = new Point(0, 150);
            button3.Name = "button3";
            button3.Size = new Size(250, 50);
            button3.TabIndex = 3;
            button3.Text = "TRANSACTIONS";
            button3.UseVisualStyleBackColor = true;
            // 
            // btnProductMasterFile
            // 
            btnProductMasterFile.Dock = DockStyle.Top;
            btnProductMasterFile.FlatAppearance.BorderSize = 0;
            btnProductMasterFile.FlatStyle = FlatStyle.Flat;
            btnProductMasterFile.ForeColor = Color.White;
            btnProductMasterFile.Location = new Point(0, 100);
            btnProductMasterFile.Name = "btnProductMasterFile";
            btnProductMasterFile.Size = new Size(250, 50);
            btnProductMasterFile.TabIndex = 2;
            btnProductMasterFile.Text = "PRODUCT MASTER FILE";
            btnProductMasterFile.UseVisualStyleBackColor = true;
            btnProductMasterFile.Click += btnProductMasterFile_Click;
            // 
            // btnFileMaintenance
            // 
            btnFileMaintenance.Dock = DockStyle.Top;
            btnFileMaintenance.FlatAppearance.BorderSize = 0;
            btnFileMaintenance.FlatStyle = FlatStyle.Flat;
            btnFileMaintenance.ForeColor = Color.White;
            btnFileMaintenance.Location = new Point(0, 50);
            btnFileMaintenance.Name = "btnFileMaintenance";
            btnFileMaintenance.Size = new Size(250, 50);
            btnFileMaintenance.TabIndex = 1;
            btnFileMaintenance.Text = "FILE MAINTENANCE";
            btnFileMaintenance.UseVisualStyleBackColor = true;
            // 
            // btnDashboard
            // 
            btnDashboard.Dock = DockStyle.Top;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Location = new Point(0, 0);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(250, 50);
            btnDashboard.TabIndex = 0;
            btnDashboard.Text = "DASHBOARD";
            btnDashboard.UseVisualStyleBackColor = true;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // panelWorkspace
            // 
            panelWorkspace.Dock = DockStyle.Fill;
            panelWorkspace.Location = new Point(250, 0);
            panelWorkspace.Name = "panelWorkspace";
            panelWorkspace.Size = new Size(932, 753);
            panelWorkspace.TabIndex = 1;
            // 
            // formAdminDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 753);
            Controls.Add(panelWorkspace);
            Controls.Add(panelSidebar);
            Name = "formAdminDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin Dashboard";
            Load += formAdminDashboard_Load;
            panelSidebar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSidebar;
        private Button button3;
        private Button btnProductMasterFile;
        private Button btnFileMaintenance;
        private Button btnDashboard;
        private Panel panelWorkspace;
        private Button button1;
    }
}