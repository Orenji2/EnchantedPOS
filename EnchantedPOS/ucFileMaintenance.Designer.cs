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
            panelUserWorkspace = new Panel();
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
            panelUserBottomBar = new Panel();
            btnCancel = new Button();
            btnDelete = new Button();
            btnSave = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            panel6 = new Panel();
            dgvUsers = new DataGridView();
            tabSupplier = new TabPage();
            panelSupWorkspace = new Panel();
            label2 = new Label();
            groupInfo = new GroupBox();
            label1 = new Label();
            txtContactPerson = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBox1 = new TextBox();
            txtContactNo = new TextBox();
            txtSuppName = new TextBox();
            txtSuppID = new TextBox();
            panelSupBottom = new Panel();
            btnSuppCancel = new Button();
            btnSuppDelete = new Button();
            btnSuppSave = new Button();
            btnSuppEdit = new Button();
            btnSuppAdd = new Button();
            panelSupGrid = new Panel();
            dgvSuppliers = new DataGridView();
            tabCustomer = new TabPage();
            panelWorkspace = new Panel();
            label6 = new Label();
            groupCustInfo = new GroupBox();
            lblCurrBalance = new Label();
            label11 = new Label();
            txtCreditLimit = new TextBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            txtCustAddress = new TextBox();
            txtCustContactNo = new TextBox();
            txtCustName = new TextBox();
            textBox6 = new TextBox();
            panelBottomBar = new Panel();
            btnCustCancel = new Button();
            btnCustDelete = new Button();
            btnCustSave = new Button();
            btnCustEdit = new Button();
            btnCustAdd = new Button();
            panelTable = new Panel();
            dgvCustomers = new DataGridView();
            tabFileMaster.SuspendLayout();
            tabCashier.SuspendLayout();
            panelUserWorkspace.SuspendLayout();
            groupPersoInfo.SuspendLayout();
            panelUserBottomBar.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            tabSupplier.SuspendLayout();
            panelSupWorkspace.SuspendLayout();
            groupInfo.SuspendLayout();
            panelSupBottom.SuspendLayout();
            panelSupGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSuppliers).BeginInit();
            tabCustomer.SuspendLayout();
            panelWorkspace.SuspendLayout();
            groupCustInfo.SuspendLayout();
            panelBottomBar.SuspendLayout();
            panelTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
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
            tabCashier.Controls.Add(panelUserWorkspace);
            tabCashier.Controls.Add(panelUserBottomBar);
            tabCashier.Controls.Add(panel6);
            tabCashier.Location = new Point(4, 29);
            tabCashier.Name = "tabCashier";
            tabCashier.Padding = new Padding(3);
            tabCashier.Size = new Size(918, 591);
            tabCashier.TabIndex = 0;
            tabCashier.Text = "Cashiers";
            tabCashier.UseVisualStyleBackColor = true;
            // 
            // panelUserWorkspace
            // 
            panelUserWorkspace.Controls.Add(labelPass);
            panelUserWorkspace.Controls.Add(labelUserID);
            panelUserWorkspace.Controls.Add(checkIsCashier);
            panelUserWorkspace.Controls.Add(checkIsAdmin);
            panelUserWorkspace.Controls.Add(groupPersoInfo);
            panelUserWorkspace.Controls.Add(txtPassword);
            panelUserWorkspace.Controls.Add(txtUserID);
            panelUserWorkspace.Dock = DockStyle.Fill;
            panelUserWorkspace.Location = new Point(3, 252);
            panelUserWorkspace.Name = "panelUserWorkspace";
            panelUserWorkspace.Size = new Size(912, 276);
            panelUserWorkspace.TabIndex = 5;
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
            // panelUserBottomBar
            // 
            panelUserBottomBar.Controls.Add(btnCancel);
            panelUserBottomBar.Controls.Add(btnDelete);
            panelUserBottomBar.Controls.Add(btnSave);
            panelUserBottomBar.Controls.Add(btnEdit);
            panelUserBottomBar.Controls.Add(btnAdd);
            panelUserBottomBar.Dock = DockStyle.Bottom;
            panelUserBottomBar.Location = new Point(3, 528);
            panelUserBottomBar.Name = "panelUserBottomBar";
            panelUserBottomBar.Size = new Size(912, 60);
            panelUserBottomBar.TabIndex = 4;
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
            dgvUsers.CellContentClick += dgvUsers_CellContentClick;
            // 
            // tabSupplier
            // 
            tabSupplier.Controls.Add(panelSupWorkspace);
            tabSupplier.Controls.Add(panelSupBottom);
            tabSupplier.Controls.Add(panelSupGrid);
            tabSupplier.Location = new Point(4, 29);
            tabSupplier.Name = "tabSupplier";
            tabSupplier.Padding = new Padding(3);
            tabSupplier.Size = new Size(918, 591);
            tabSupplier.TabIndex = 1;
            tabSupplier.Text = "Suppliers";
            tabSupplier.UseVisualStyleBackColor = true;
            // 
            // panelSupWorkspace
            // 
            panelSupWorkspace.Controls.Add(label2);
            panelSupWorkspace.Controls.Add(groupInfo);
            panelSupWorkspace.Controls.Add(txtSuppID);
            panelSupWorkspace.Dock = DockStyle.Fill;
            panelSupWorkspace.Location = new Point(3, 252);
            panelSupWorkspace.Name = "panelSupWorkspace";
            panelSupWorkspace.Size = new Size(912, 276);
            panelSupWorkspace.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(172, 52);
            label2.Name = "label2";
            label2.Size = new Size(83, 20);
            label2.TabIndex = 18;
            label2.Text = "Supplier ID";
            // 
            // groupInfo
            // 
            groupInfo.Controls.Add(label1);
            groupInfo.Controls.Add(txtContactPerson);
            groupInfo.Controls.Add(label3);
            groupInfo.Controls.Add(label4);
            groupInfo.Controls.Add(label5);
            groupInfo.Controls.Add(textBox1);
            groupInfo.Controls.Add(txtContactNo);
            groupInfo.Controls.Add(txtSuppName);
            groupInfo.Location = new Point(261, 26);
            groupInfo.Name = "groupInfo";
            groupInfo.Size = new Size(464, 204);
            groupInfo.TabIndex = 15;
            groupInfo.TabStop = false;
            groupInfo.Text = "Supplier Info";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 80);
            label1.Name = "label1";
            label1.Size = new Size(107, 20);
            label1.TabIndex = 13;
            label1.Text = "Contact Person";
            // 
            // txtContactPerson
            // 
            txtContactPerson.Location = new Point(23, 103);
            txtContactPerson.Name = "txtContactPerson";
            txtContactPerson.Size = new Size(200, 27);
            txtContactPerson.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 133);
            label3.Name = "label3";
            label3.Size = new Size(62, 20);
            label3.TabIndex = 11;
            label3.Text = "Address";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(242, 80);
            label4.Name = "label4";
            label4.Size = new Size(84, 20);
            label4.TabIndex = 10;
            label4.Text = "Contact No";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(23, 27);
            label5.Name = "label5";
            label5.Size = new Size(108, 20);
            label5.TabIndex = 9;
            label5.Text = "Supplier Name";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(23, 156);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(406, 27);
            textBox1.TabIndex = 3;
            // 
            // txtContactNo
            // 
            txtContactNo.Location = new Point(242, 103);
            txtContactNo.Name = "txtContactNo";
            txtContactNo.Size = new Size(187, 27);
            txtContactNo.TabIndex = 2;
            // 
            // txtSuppName
            // 
            txtSuppName.Location = new Point(23, 50);
            txtSuppName.Name = "txtSuppName";
            txtSuppName.Size = new Size(406, 27);
            txtSuppName.TabIndex = 1;
            // 
            // txtSuppID
            // 
            txtSuppID.Location = new Point(187, 75);
            txtSuppID.Name = "txtSuppID";
            txtSuppID.Size = new Size(46, 27);
            txtSuppID.TabIndex = 13;
            // 
            // panelSupBottom
            // 
            panelSupBottom.Controls.Add(btnSuppCancel);
            panelSupBottom.Controls.Add(btnSuppDelete);
            panelSupBottom.Controls.Add(btnSuppSave);
            panelSupBottom.Controls.Add(btnSuppEdit);
            panelSupBottom.Controls.Add(btnSuppAdd);
            panelSupBottom.Dock = DockStyle.Bottom;
            panelSupBottom.Location = new Point(3, 528);
            panelSupBottom.Name = "panelSupBottom";
            panelSupBottom.Size = new Size(912, 60);
            panelSupBottom.TabIndex = 4;
            // 
            // btnSuppCancel
            // 
            btnSuppCancel.Location = new Point(740, 4);
            btnSuppCancel.Name = "btnSuppCancel";
            btnSuppCancel.Size = new Size(132, 51);
            btnSuppCancel.TabIndex = 9;
            btnSuppCancel.Text = "Cancel";
            btnSuppCancel.UseVisualStyleBackColor = true;
            btnSuppCancel.Click += btnSuppCancel_Click;
            // 
            // btnSuppDelete
            // 
            btnSuppDelete.Location = new Point(569, 4);
            btnSuppDelete.Name = "btnSuppDelete";
            btnSuppDelete.Size = new Size(132, 51);
            btnSuppDelete.TabIndex = 8;
            btnSuppDelete.Text = "Delete";
            btnSuppDelete.UseVisualStyleBackColor = true;
            btnSuppDelete.Click += btnSuppDelete_Click;
            // 
            // btnSuppSave
            // 
            btnSuppSave.Location = new Point(387, 4);
            btnSuppSave.Name = "btnSuppSave";
            btnSuppSave.Size = new Size(132, 51);
            btnSuppSave.TabIndex = 7;
            btnSuppSave.Text = "Save";
            btnSuppSave.UseVisualStyleBackColor = true;
            btnSuppSave.Click += btnSuppSave_Click;
            // 
            // btnSuppEdit
            // 
            btnSuppEdit.Location = new Point(212, 6);
            btnSuppEdit.Name = "btnSuppEdit";
            btnSuppEdit.Size = new Size(132, 51);
            btnSuppEdit.TabIndex = 6;
            btnSuppEdit.Text = "Edit";
            btnSuppEdit.UseVisualStyleBackColor = true;
            btnSuppEdit.Click += btnSuppEdit_Click;
            // 
            // btnSuppAdd
            // 
            btnSuppAdd.Location = new Point(40, 4);
            btnSuppAdd.Name = "btnSuppAdd";
            btnSuppAdd.Size = new Size(132, 51);
            btnSuppAdd.TabIndex = 5;
            btnSuppAdd.Text = "Add";
            btnSuppAdd.UseVisualStyleBackColor = true;
            btnSuppAdd.Click += btnSuppAdd_Click;
            // 
            // panelSupGrid
            // 
            panelSupGrid.Controls.Add(dgvSuppliers);
            panelSupGrid.Dock = DockStyle.Top;
            panelSupGrid.Location = new Point(3, 3);
            panelSupGrid.Name = "panelSupGrid";
            panelSupGrid.Size = new Size(912, 249);
            panelSupGrid.TabIndex = 3;
            // 
            // dgvSuppliers
            // 
            dgvSuppliers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSuppliers.Dock = DockStyle.Fill;
            dgvSuppliers.Location = new Point(0, 0);
            dgvSuppliers.Name = "dgvSuppliers";
            dgvSuppliers.RowHeadersWidth = 51;
            dgvSuppliers.Size = new Size(912, 249);
            dgvSuppliers.TabIndex = 0;
            dgvSuppliers.CellClick += dgvSuppliers_CellClick;
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
            panelWorkspace.Controls.Add(label6);
            panelWorkspace.Controls.Add(groupCustInfo);
            panelWorkspace.Controls.Add(textBox6);
            panelWorkspace.Dock = DockStyle.Fill;
            panelWorkspace.Location = new Point(3, 252);
            panelWorkspace.Name = "panelWorkspace";
            panelWorkspace.Size = new Size(912, 276);
            panelWorkspace.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(111, 65);
            label6.Name = "label6";
            label6.Size = new Size(91, 20);
            label6.TabIndex = 21;
            label6.Text = "Customer ID";
            // 
            // groupCustInfo
            // 
            groupCustInfo.Controls.Add(lblCurrBalance);
            groupCustInfo.Controls.Add(label11);
            groupCustInfo.Controls.Add(txtCreditLimit);
            groupCustInfo.Controls.Add(label7);
            groupCustInfo.Controls.Add(label8);
            groupCustInfo.Controls.Add(label9);
            groupCustInfo.Controls.Add(label10);
            groupCustInfo.Controls.Add(txtCustAddress);
            groupCustInfo.Controls.Add(txtCustContactNo);
            groupCustInfo.Controls.Add(txtCustName);
            groupCustInfo.Location = new Point(224, 20);
            groupCustInfo.Name = "groupCustInfo";
            groupCustInfo.Size = new Size(525, 240);
            groupCustInfo.TabIndex = 20;
            groupCustInfo.TabStop = false;
            groupCustInfo.Text = "Customer Info";
            // 
            // lblCurrBalance
            // 
            lblCurrBalance.AutoSize = true;
            lblCurrBalance.Location = new Point(346, 160);
            lblCurrBalance.Name = "lblCurrBalance";
            lblCurrBalance.Size = new Size(86, 20);
            lblCurrBalance.TabIndex = 15;
            lblCurrBalance.Text = "currBalance";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(219, 160);
            label11.Name = "label11";
            label11.Size = new Size(116, 20);
            label11.TabIndex = 14;
            label11.Text = "Current Balance:";
            // 
            // txtCreditLimit
            // 
            txtCreditLimit.Location = new Point(23, 157);
            txtCreditLimit.Name = "txtCreditLimit";
            txtCreditLimit.Size = new Size(141, 27);
            txtCreditLimit.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(23, 134);
            label7.Name = "label7";
            label7.Size = new Size(86, 20);
            label7.TabIndex = 12;
            label7.Text = "Credit Limit";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(23, 80);
            label8.Name = "label8";
            label8.Size = new Size(62, 20);
            label8.TabIndex = 11;
            label8.Text = "Address";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(378, 81);
            label9.Name = "label9";
            label9.Size = new Size(84, 20);
            label9.TabIndex = 10;
            label9.Text = "Contact No";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(23, 27);
            label10.Name = "label10";
            label10.Size = new Size(116, 20);
            label10.TabIndex = 9;
            label10.Text = "Customer Name";
            // 
            // txtCustAddress
            // 
            txtCustAddress.Location = new Point(23, 104);
            txtCustAddress.Name = "txtCustAddress";
            txtCustAddress.Size = new Size(349, 27);
            txtCustAddress.TabIndex = 3;
            // 
            // txtCustContactNo
            // 
            txtCustContactNo.Location = new Point(378, 104);
            txtCustContactNo.Name = "txtCustContactNo";
            txtCustContactNo.Size = new Size(141, 27);
            txtCustContactNo.TabIndex = 2;
            // 
            // txtCustName
            // 
            txtCustName.Location = new Point(23, 50);
            txtCustName.Name = "txtCustName";
            txtCustName.Size = new Size(496, 27);
            txtCustName.TabIndex = 1;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(128, 88);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(46, 27);
            textBox6.TabIndex = 19;
            // 
            // panelBottomBar
            // 
            panelBottomBar.Controls.Add(btnCustCancel);
            panelBottomBar.Controls.Add(btnCustDelete);
            panelBottomBar.Controls.Add(btnCustSave);
            panelBottomBar.Controls.Add(btnCustEdit);
            panelBottomBar.Controls.Add(btnCustAdd);
            panelBottomBar.Dock = DockStyle.Bottom;
            panelBottomBar.Location = new Point(3, 528);
            panelBottomBar.Name = "panelBottomBar";
            panelBottomBar.Size = new Size(912, 60);
            panelBottomBar.TabIndex = 1;
            // 
            // btnCustCancel
            // 
            btnCustCancel.Location = new Point(740, 4);
            btnCustCancel.Name = "btnCustCancel";
            btnCustCancel.Size = new Size(132, 51);
            btnCustCancel.TabIndex = 14;
            btnCustCancel.Text = "Cancel";
            btnCustCancel.UseVisualStyleBackColor = true;
            btnCustCancel.Click += btnCustCancel_Click;
            // 
            // btnCustDelete
            // 
            btnCustDelete.Location = new Point(569, 4);
            btnCustDelete.Name = "btnCustDelete";
            btnCustDelete.Size = new Size(132, 51);
            btnCustDelete.TabIndex = 13;
            btnCustDelete.Text = "Delete";
            btnCustDelete.UseVisualStyleBackColor = true;
            btnCustDelete.Click += btnCustDelete_Click;
            // 
            // btnCustSave
            // 
            btnCustSave.Location = new Point(387, 4);
            btnCustSave.Name = "btnCustSave";
            btnCustSave.Size = new Size(132, 51);
            btnCustSave.TabIndex = 12;
            btnCustSave.Text = "Save";
            btnCustSave.UseVisualStyleBackColor = true;
            btnCustSave.Click += btnCustSave_Click;
            // 
            // btnCustEdit
            // 
            btnCustEdit.Location = new Point(212, 5);
            btnCustEdit.Name = "btnCustEdit";
            btnCustEdit.Size = new Size(132, 51);
            btnCustEdit.TabIndex = 11;
            btnCustEdit.Text = "Edit";
            btnCustEdit.UseVisualStyleBackColor = true;
            btnCustEdit.Click += btnCustEdit_Click;
            // 
            // btnCustAdd
            // 
            btnCustAdd.Location = new Point(40, 4);
            btnCustAdd.Name = "btnCustAdd";
            btnCustAdd.Size = new Size(132, 51);
            btnCustAdd.TabIndex = 10;
            btnCustAdd.Text = "Add";
            btnCustAdd.UseVisualStyleBackColor = true;
            btnCustAdd.Click += btnCustAdd_Click;
            // 
            // panelTable
            // 
            panelTable.Controls.Add(dgvCustomers);
            panelTable.Dock = DockStyle.Top;
            panelTable.Location = new Point(3, 3);
            panelTable.Name = "panelTable";
            panelTable.Size = new Size(912, 249);
            panelTable.TabIndex = 0;
            // 
            // dgvCustomers
            // 
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.Dock = DockStyle.Fill;
            dgvCustomers.Location = new Point(0, 0);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.RowHeadersWidth = 51;
            dgvCustomers.Size = new Size(912, 249);
            dgvCustomers.TabIndex = 0;
            dgvCustomers.CellClick += dgvCustomers_CellClick;
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
            panelUserWorkspace.ResumeLayout(false);
            panelUserWorkspace.PerformLayout();
            groupPersoInfo.ResumeLayout(false);
            groupPersoInfo.PerformLayout();
            panelUserBottomBar.ResumeLayout(false);
            panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            tabSupplier.ResumeLayout(false);
            panelSupWorkspace.ResumeLayout(false);
            panelSupWorkspace.PerformLayout();
            groupInfo.ResumeLayout(false);
            groupInfo.PerformLayout();
            panelSupBottom.ResumeLayout(false);
            panelSupGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSuppliers).EndInit();
            tabCustomer.ResumeLayout(false);
            panelWorkspace.ResumeLayout(false);
            panelWorkspace.PerformLayout();
            groupCustInfo.ResumeLayout(false);
            groupCustInfo.PerformLayout();
            panelBottomBar.ResumeLayout(false);
            panelTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabFileMaster;
        private TabPage tabCashier;
        private TabPage tabSupplier;
        private TabPage tabCustomer;
        private Panel panelTable;
        private Panel panelUserWorkspace;
        private Panel panelUserBottomBar;
        private Panel panel6;
        private Panel panelSupWorkspace;
        private Panel panelSupBottom;
        private Panel panelSupGrid;
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
        private DataGridView dgvSuppliers;
        private Label label2;
        private GroupBox groupInfo;
        private Label label1;
        private TextBox txtContactPerson;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBox1;
        private TextBox txtContactNo;
        private TextBox txtSuppName;
        private TextBox txtSuppID;
        private Button btnSuppCancel;
        private Button btnSuppDelete;
        private Button btnSuppSave;
        private Button btnSuppEdit;
        private Button btnSuppAdd;
        private DataGridView dgvCustomers;
        private Label label6;
        private GroupBox groupCustInfo;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private TextBox txtCustAddress;
        private TextBox txtCustContactNo;
        private TextBox txtCustName;
        private TextBox textBox6;
        private Label lblCurrBalance;
        private Label label11;
        private TextBox txtCreditLimit;
        private Button btnCustCancel;
        private Button btnCustDelete;
        private Button btnCustSave;
        private Button btnCustEdit;
        private Button btnCustAdd;
    }
}
