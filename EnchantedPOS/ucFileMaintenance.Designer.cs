namespace EnchantedPOS
{
    partial class ucFileMaintenance
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabFileMaster = new TabControl();
            tabCashier = new TabPage();
            panel4 = new Panel();
            labelPass = new Label();
            labelUserID = new Label();
            checkIsCashier = new CheckBox();
            checkIsAdmin = new CheckBox();
            groupPersoInfo = new GroupBox();
            labelAddress = new Label();
            labelLn = new Label();
            labelFn = new Label();
            txtAddress = new TextBox();
            txtLastName = new TextBox();
            txtFirstName = new TextBox();
            txtPassword = new TextBox();
            txtUserID = new TextBox();
            panel5 = new Panel();
            btnCancel = new Button();
            btnDelete = new Button();
            btnSave = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            panel6 = new Panel();
            dgvUsers = new DataGridView();
            tabSupplier = new TabPage();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            tabCustomer = new TabPage();
            panelWorkspace = new Panel();
            panelBottomBar = new Panel();
            panelTable = new Panel();
            tabFileMaster.SuspendLayout();
            tabCashier.SuspendLayout();
            panel4.SuspendLayout();
            groupPersoInfo.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            tabSupplier.SuspendLayout();
            tabCustomer.SuspendLayout();
            SuspendLayout();
            // 
            // tabFileMaster
            // 
            tabFileMaster.Controls.Add(tabCashier);
            tabFileMaster.Controls.Add(tabSupplier);
            tabFileMaster.Controls.Add(tabCustomer);
            tabFileMaster.Dock = DockStyle.Fill;
            tabFileMaster.Location = new Point(0, 0);
            tabFileMaster.Name = "tabFileMaster";
            tabFileMaster.SelectedIndex = 0;
            tabFileMaster.Size = new Size(926, 624);
            tabFileMaster.TabIndex = 0;
            // 
            // tabCashier
            // 
            tabCashier.Controls.Add(panel4);
            tabCashier.Controls.Add(panel5);
            tabCashier.Controls.Add(panel6);
            tabCashier.Location = new Point(4, 29);
            tabCashier.Name = "tabCashier";
            tabCashier.Padding = new Padding(3);
            tabCashier.Size = new Size(918, 591);
            tabCashier.TabIndex = 0;
            tabCashier.Text = "Cashiers";
            tabCashier.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            panel4.Controls.Add(labelPass);
            panel4.Controls.Add(labelUserID);
            panel4.Controls.Add(checkIsCashier);
            panel4.Controls.Add(checkIsAdmin);
            panel4.Controls.Add(groupPersoInfo);
            panel4.Controls.Add(txtPassword);
            panel4.Controls.Add(txtUserID);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(3, 252);
            panel4.Name = "panel4";
            panel4.Size = new Size(912, 276);
            panel4.TabIndex = 5;
            // 
            // labelPass
            // 
            labelPass.AutoSize = true;
            labelPass.Location = new Point(206, 180);
            labelPass.Name = "labelPass";
            labelPass.Size = new Size(95, 20);
            labelPass.TabIndex = 12;
            labelPass.Text = "Access Code:";
            // 
            // labelUserID
            // 
            labelUserID.AutoSize = true;
            labelUserID.Location = new Point(132, 30);
            labelUserID.Name = "labelUserID";
            labelUserID.Size = new Size(57, 20);
            labelUserID.TabIndex = 8;
            labelUserID.Text = "User ID";
            // 
            // checkIsCashier
            // 
            checkIsCashier.AutoSize = true;
            checkIsCashier.Location = new Point(575, 203);
            checkIsCashier.Name = "checkIsCashier";
            checkIsCashier.Size = new Size(79, 24);
            checkIsCashier.TabIndex = 7;
            checkIsCashier.Text = "Cashier";
            checkIsCashier.UseVisualStyleBackColor = true;
            // 
            // checkIsAdmin
            // 
            checkIsAdmin.AutoSize = true;
            checkIsAdmin.Location = new Point(440, 204);
            checkIsAdmin.Name = "checkIsAdmin";
            checkIsAdmin.Size = new Size(75, 24);
            checkIsAdmin.TabIndex = 6;
            checkIsAdmin.Text = "Admin";
            checkIsAdmin.UseVisualStyleBackColor = true;
            // 
            // groupPersoInfo
            // 
            groupPersoInfo.Controls.Add(labelAddress);
            groupPersoInfo.Controls.Add(labelLn);
            groupPersoInfo.Controls.Add(labelFn);
            groupPersoInfo.Controls.Add(txtAddress);
            groupPersoInfo.Controls.Add(txtLastName);
            groupPersoInfo.Controls.Add(txtFirstName);
            groupPersoInfo.Location = new Point(206, 6);
            groupPersoInfo.Name = "groupPersoInfo";
            groupPersoInfo.Size = new Size(464, 173);
            groupPersoInfo.TabIndex = 5;
            groupPersoInfo.TabStop = false;
            groupPersoInfo.Text = "Personal Info";
            // 
            // labelAddress
            // 
            labelAddress.AutoSize = true;
            labelAddress.Location = new Point(23, 82);
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(62, 20);
            labelAddress.TabIndex = 11;
            labelAddress.Text = "Address";
            // 
            // labelLn
            // 
            labelLn.AutoSize = true;
            labelLn.Location = new Point(242, 27);
            labelLn.Name = "labelLn";
            labelLn.Size = new Size(79, 20);
            labelLn.TabIndex = 10;
            labelLn.Text = "Last Name";
            // 
            // labelFn
            // 
            labelFn.AutoSize = true;
            labelFn.Location = new Point(23, 27);
            labelFn.Name = "labelFn";
            labelFn.Size = new Size(80, 20);
            labelFn.TabIndex = 9;
            labelFn.Text = "First Name";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(23, 105);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(406, 27);
            txtAddress.TabIndex = 3;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(242, 50);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(187, 27);
            txtLastName.TabIndex = 2;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(23, 50);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(187, 27);
            txtFirstName.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(206, 203);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(201, 27);
            txtPassword.TabIndex = 4;
            // 
            // txtUserID
            // 
            txtUserID.Location = new Point(132, 55);
            txtUserID.Name = "txtUserID";
            txtUserID.Size = new Size(46, 27);
            txtUserID.TabIndex = 0;
            // 
            // panel5
            // 
            panel5.Controls.Add(btnCancel);
            panel5.Controls.Add(btnDelete);
            panel5.Controls.Add(btnSave);
            panel5.Controls.Add(btnEdit);
            panel5.Controls.Add(btnAdd);
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(3, 528);
            panel5.Name = "panel5";
            panel5.Size = new Size(912, 60);
            panel5.TabIndex = 4;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(746, 6);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(132, 51);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(575, 6);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(132, 51);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(393, 6);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(132, 51);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(218, 8);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(132, 51);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(46, 6);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(132, 51);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // panel6
            // 
            panel6.Controls.Add(dgvUsers);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(3, 3);
            panel6.Name = "panel6";
            panel6.Size = new Size(912, 249);
            panel6.TabIndex = 3;
            // 
            // dgvUsers
            // 
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Dock = DockStyle.Fill;
            dgvUsers.Location = new Point(0, 0);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.Size = new Size(912, 249);
            dgvUsers.TabIndex = 0;
            dgvUsers.CellClick += dgvUsers_CellClick;
            // 
            // tabSupplier
            // 
            tabSupplier.Controls.Add(panel1);
            tabSupplier.Controls.Add(panel2);
            tabSupplier.Controls.Add(panel3);
            tabSupplier.Location = new Point(4, 29);
            tabSupplier.Name = "tabSupplier";
            tabSupplier.Padding = new Padding(3);
            tabSupplier.Size = new Size(918, 591);
            tabSupplier.TabIndex = 1;
            tabSupplier.Text = "Suppliers";
            tabSupplier.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 252);
            panel1.Name = "panel1";
            panel1.Size = new Size(912, 276);
            panel1.TabIndex = 5;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(3, 528);
            panel2.Name = "panel2";
            panel2.Size = new Size(912, 60);
            panel2.TabIndex = 4;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(912, 249);
            panel3.TabIndex = 3;
            // 
            // tabCustomer
            // 
            tabCustomer.Controls.Add(panelWorkspace);
            tabCustomer.Controls.Add(panelBottomBar);
            tabCustomer.Controls.Add(panelTable);
            tabCustomer.Location = new Point(4, 29);
            tabCustomer.Name = "tabCustomer";
            tabCustomer.Padding = new Padding(3);
            tabCustomer.Size = new Size(918, 591);
            tabCustomer.TabIndex = 2;
            tabCustomer.Text = "Customers";
            tabCustomer.UseVisualStyleBackColor = true;
            // 
            // panelWorkspace
            // 
            panelWorkspace.Dock = DockStyle.Fill;
            panelWorkspace.Location = new Point(3, 252);
            panelWorkspace.Name = "panelWorkspace";
            panelWorkspace.Size = new Size(912, 276);
            panelWorkspace.TabIndex = 2;
            // 
            // panelBottomBar
            // 
            panelBottomBar.Dock = DockStyle.Bottom;
            panelBottomBar.Location = new Point(3, 528);
            panelBottomBar.Name = "panelBottomBar";
            panelBottomBar.Size = new Size(912, 60);
            panelBottomBar.TabIndex = 1;
            // 
            // panelTable
            // 
            panelTable.Dock = DockStyle.Top;
            panelTable.Location = new Point(3, 3);
            panelTable.Name = "panelTable";
            panelTable.Size = new Size(912, 249);
            panelTable.TabIndex = 0;
            // 
            // ucFileMaintenance
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabFileMaster);
            Name = "ucFileMaintenance";
            Size = new Size(926, 624);
            tabFileMaster.ResumeLayout(false);
            tabCashier.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            groupPersoInfo.ResumeLayout(false);
            groupPersoInfo.PerformLayout();
            panel5.ResumeLayout(false);
            panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            tabSupplier.ResumeLayout(false);
            tabCustomer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabFileMaster;
        private TabPage tabCashier;
        private TabPage tabSupplier;
        private TabPage tabCustomer;
        private Panel panelTable;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panelWorkspace;
        private Panel panelBottomBar;
        private TextBox txtPassword;
        private TextBox txtAddress;
        private TextBox txtLastName;
        private TextBox txtFirstName;
        private TextBox txtUserID;
        private DataGridView dgvUsers;
        private Button btnCancel;
        private Button btnDelete;
        private Button btnSave;
        private Button btnEdit;
        private Button btnAdd;
        private GroupBox groupPersoInfo;
        private Label labelPass;
        private Label labelUserID;
        private CheckBox checkIsCashier;
        private CheckBox checkIsAdmin;
        private Label labelAddress;
        private Label labelLn;
        private Label labelFn;
    }
}
