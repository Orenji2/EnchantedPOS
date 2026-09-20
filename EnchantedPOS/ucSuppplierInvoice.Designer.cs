namespace EnchantedPOS
{
    partial class ucSuppplierInvoice
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
            panelInvoiceInfo = new Panel();
            labellll = new Label();
            txtGrandTotal = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dtpDate = new DateTimePicker();
            txtPONumber = new TextBox();
            txtInvoiceNumber = new TextBox();
            txtSupplierAddress = new TextBox();
            txtSupplierName = new TextBox();
            txtSupplierCode = new TextBox();
            panelBottomBar = new Panel();
            btnRetreive = new Button();
            btnExit = new Button();
            btnPrint = new Button();
            btnAddItems = new Button();
            btnCancel = new Button();
            btnSave = new Button();
            btnAdd = new Button();
            panel1 = new Panel();
            dgvInvoice = new DataGridView();
            colBarcode = new DataGridViewTextBoxColumn();
            colItemName = new DataGridViewTextBoxColumn();
            colQty = new DataGridViewTextBoxColumn();
            colCost = new DataGridViewTextBoxColumn();
            colAmount = new DataGridViewTextBoxColumn();
            colUM = new DataGridViewTextBoxColumn();
            colBaseCost = new DataGridViewTextBoxColumn();
            panelInvoiceInfo.SuspendLayout();
            panelBottomBar.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInvoice).BeginInit();
            SuspendLayout();
            // 
            // panelInvoiceInfo
            // 
            panelInvoiceInfo.Controls.Add(labellll);
            panelInvoiceInfo.Controls.Add(txtGrandTotal);
            panelInvoiceInfo.Controls.Add(label6);
            panelInvoiceInfo.Controls.Add(label5);
            panelInvoiceInfo.Controls.Add(label4);
            panelInvoiceInfo.Controls.Add(label3);
            panelInvoiceInfo.Controls.Add(label2);
            panelInvoiceInfo.Controls.Add(label1);
            panelInvoiceInfo.Controls.Add(dtpDate);
            panelInvoiceInfo.Controls.Add(txtPONumber);
            panelInvoiceInfo.Controls.Add(txtInvoiceNumber);
            panelInvoiceInfo.Controls.Add(txtSupplierAddress);
            panelInvoiceInfo.Controls.Add(txtSupplierName);
            panelInvoiceInfo.Controls.Add(txtSupplierCode);
            panelInvoiceInfo.Dock = DockStyle.Top;
            panelInvoiceInfo.Location = new Point(0, 0);
            panelInvoiceInfo.Name = "panelInvoiceInfo";
            panelInvoiceInfo.Size = new Size(1018, 131);
            panelInvoiceInfo.TabIndex = 0;
            // 
            // labellll
            // 
            labellll.AutoSize = true;
            labellll.Location = new Point(463, 91);
            labellll.Name = "labellll";
            labellll.Size = new Size(102, 20);
            labellll.TabIndex = 13;
            labellll.Text = "Total Amount:";
            // 
            // txtGrandTotal
            // 
            txtGrandTotal.Location = new Point(571, 84);
            txtGrandTotal.Name = "txtGrandTotal";
            txtGrandTotal.ReadOnly = true;
            txtGrandTotal.Size = new Size(157, 27);
            txtGrandTotal.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(734, 87);
            label6.Name = "label6";
            label6.Size = new Size(89, 20);
            label6.TabIndex = 11;
            label6.Text = "PO Number:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(779, 56);
            label5.Name = "label5";
            label5.Size = new Size(44, 20);
            label5.TabIndex = 10;
            label5.Text = "Date:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(706, 21);
            label4.Name = "label4";
            label4.Size = new Size(117, 20);
            label4.TabIndex = 9;
            label4.Text = "Invoice Number:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(46, 87);
            label3.Name = "label3";
            label3.Size = new Size(65, 20);
            label3.TabIndex = 8;
            label3.Text = "Address:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(59, 54);
            label2.Name = "label2";
            label2.Size = new Size(52, 20);
            label2.TabIndex = 7;
            label2.Text = "Name:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 21);
            label1.Name = "label1";
            label1.Size = new Size(106, 20);
            label1.TabIndex = 6;
            label1.Text = "Supplier Code:";
            // 
            // dtpDate
            // 
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(829, 51);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(157, 27);
            dtpDate.TabIndex = 5;
            dtpDate.KeyDown += dtpDate_KeyDown;
            // 
            // txtPONumber
            // 
            txtPONumber.Location = new Point(829, 84);
            txtPONumber.Name = "txtPONumber";
            txtPONumber.Size = new Size(157, 27);
            txtPONumber.TabIndex = 4;
            txtPONumber.KeyDown += txtPONumber_KeyDown;
            // 
            // txtInvoiceNumber
            // 
            txtInvoiceNumber.Location = new Point(829, 18);
            txtInvoiceNumber.Name = "txtInvoiceNumber";
            txtInvoiceNumber.Size = new Size(157, 27);
            txtInvoiceNumber.TabIndex = 3;
            txtInvoiceNumber.KeyDown += txtInvoiceNumber_KeyDown;
            // 
            // txtSupplierAddress
            // 
            txtSupplierAddress.Location = new Point(117, 84);
            txtSupplierAddress.Name = "txtSupplierAddress";
            txtSupplierAddress.ReadOnly = true;
            txtSupplierAddress.Size = new Size(276, 27);
            txtSupplierAddress.TabIndex = 2;
            // 
            // txtSupplierName
            // 
            txtSupplierName.Location = new Point(117, 51);
            txtSupplierName.Name = "txtSupplierName";
            txtSupplierName.ReadOnly = true;
            txtSupplierName.Size = new Size(276, 27);
            txtSupplierName.TabIndex = 1;
            // 
            // txtSupplierCode
            // 
            txtSupplierCode.Location = new Point(117, 18);
            txtSupplierCode.Name = "txtSupplierCode";
            txtSupplierCode.Size = new Size(76, 27);
            txtSupplierCode.TabIndex = 0;
            txtSupplierCode.KeyDown += txtSupplierCode_KeyDown;
            // 
            // panelBottomBar
            // 
            panelBottomBar.Controls.Add(btnRetreive);
            panelBottomBar.Controls.Add(btnExit);
            panelBottomBar.Controls.Add(btnPrint);
            panelBottomBar.Controls.Add(btnAddItems);
            panelBottomBar.Controls.Add(btnCancel);
            panelBottomBar.Controls.Add(btnSave);
            panelBottomBar.Controls.Add(btnAdd);
            panelBottomBar.Dock = DockStyle.Bottom;
            panelBottomBar.Location = new Point(0, 620);
            panelBottomBar.Name = "panelBottomBar";
            panelBottomBar.Size = new Size(1018, 78);
            panelBottomBar.TabIndex = 1;
            // 
            // btnRetreive
            // 
            btnRetreive.Location = new Point(753, 5);
            btnRetreive.Name = "btnRetreive";
            btnRetreive.Size = new Size(126, 69);
            btnRetreive.TabIndex = 6;
            btnRetreive.Text = "Retreive Exported\r\nRecords";
            btnRetreive.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(885, 5);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(126, 69);
            btnExit.TabIndex = 5;
            btnExit.Text = "EXIT";
            btnExit.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            btnPrint.Location = new Point(588, 5);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(126, 69);
            btnPrint.TabIndex = 4;
            btnPrint.Text = "PRINT";
            btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnAddItems
            // 
            btnAddItems.Location = new Point(399, 5);
            btnAddItems.Name = "btnAddItems";
            btnAddItems.Size = new Size(183, 69);
            btnAddItems.TabIndex = 3;
            btnAddItems.Text = "Add New Items\r\nIn this invoice";
            btnAddItems.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(267, 6);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(126, 69);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "CANCEL";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(135, 6);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(126, 69);
            btnSave.TabIndex = 1;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(3, 6);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(126, 69);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "ADD";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvInvoice);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 131);
            panel1.Name = "panel1";
            panel1.Size = new Size(1018, 489);
            panel1.TabIndex = 2;
            // 
            // dgvInvoice
            // 
            dgvInvoice.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInvoice.Columns.AddRange(new DataGridViewColumn[] { colBarcode, colItemName, colQty, colCost, colAmount, colUM, colBaseCost });
            dgvInvoice.Dock = DockStyle.Fill;
            dgvInvoice.Location = new Point(0, 0);
            dgvInvoice.Name = "dgvInvoice";
            dgvInvoice.RowHeadersWidth = 51;
            dgvInvoice.Size = new Size(1018, 489);
            dgvInvoice.TabIndex = 0;
            dgvInvoice.CellContentClick += dgvInvoice_CellContentClick;
            dgvInvoice.CellValueChanged += dgvInvoice_CellValueChanged;
            // 
            // colBarcode
            // 
            colBarcode.HeaderText = "Barcode";
            colBarcode.MinimumWidth = 6;
            colBarcode.Name = "colBarcode";
            colBarcode.Width = 125;
            // 
            // colItemName
            // 
            colItemName.HeaderText = "Item Name";
            colItemName.MinimumWidth = 6;
            colItemName.Name = "colItemName";
            colItemName.ReadOnly = true;
            colItemName.Width = 125;
            // 
            // colQty
            // 
            colQty.HeaderText = "Qty";
            colQty.MinimumWidth = 6;
            colQty.Name = "colQty";
            colQty.Width = 125;
            // 
            // colCost
            // 
            colCost.HeaderText = "Cost";
            colCost.MinimumWidth = 6;
            colCost.Name = "colCost";
            colCost.Width = 125;
            // 
            // colAmount
            // 
            colAmount.HeaderText = "Amount";
            colAmount.MinimumWidth = 6;
            colAmount.Name = "colAmount";
            colAmount.ReadOnly = true;
            colAmount.Width = 125;
            // 
            // colUM
            // 
            colUM.HeaderText = "UM";
            colUM.MinimumWidth = 6;
            colUM.Name = "colUM";
            colUM.Width = 125;
            // 
            // colBaseCost
            // 
            colBaseCost.HeaderText = "Base Cost";
            colBaseCost.MinimumWidth = 6;
            colBaseCost.Name = "colBaseCost";
            colBaseCost.Width = 125;
            // 
            // ucSuppplierInvoice
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(panelBottomBar);
            Controls.Add(panelInvoiceInfo);
            Name = "ucSuppplierInvoice";
            Size = new Size(1018, 698);
            panelInvoiceInfo.ResumeLayout(false);
            panelInvoiceInfo.PerformLayout();
            panelBottomBar.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvInvoice).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelInvoiceInfo;
        private Panel panelBottomBar;
        private DateTimePicker dtpDate;
        private TextBox txtPONumber;
        private TextBox txtInvoiceNumber;
        private TextBox txtSupplierAddress;
        private TextBox txtSupplierName;
        private TextBox txtSupplierCode;
        private Panel panel1;
        private DataGridView dgvInvoice;
        private Button btnRetreive;
        private Button btnExit;
        private Button btnPrint;
        private Button btnAddItems;
        private Button btnCancel;
        private Button btnSave;
        private Button btnAdd;
        private DataGridViewTextBoxColumn colBarcode;
        private DataGridViewTextBoxColumn colItemName;
        private DataGridViewTextBoxColumn colQty;
        private DataGridViewTextBoxColumn colCost;
        private DataGridViewTextBoxColumn colAmount;
        private DataGridViewTextBoxColumn colUM;
        private DataGridViewTextBoxColumn colBaseCost;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label6;
        private Label labellll;
        private TextBox txtGrandTotal;
    }
}
