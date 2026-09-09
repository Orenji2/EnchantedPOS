namespace EnchantedPOS
{
    partial class ucProductMaster
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
            btnAdd = new Button();
            btnEdit = new Button();
            btnSave = new Button();
            btnDelete = new Button();
            btnCancel = new Button();
            dgvProducts = new DataGridView();
            labelProducts = new Label();
            txtBarcode = new TextBox();
            txtProdName = new TextBox();
            txtAltProdName = new TextBox();
            txtItemCost = new TextBox();
            txtItemPrice = new TextBox();
            labelDesc = new Label();
            labelBarcode = new Label();
            labelCost = new Label();
            label1 = new Label();
            groupCostPriice = new GroupBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            txtPriceRoyal = new TextBox();
            txtPriceVip = new TextBox();
            txtPriceWholesale = new TextBox();
            txtStoreStock = new TextBox();
            labelStoreStock = new Label();
            groupStock = new GroupBox();
            label2 = new Label();
            txtWhStock = new TextBox();
            groupCost = new GroupBox();
            txtInvPrice = new TextBox();
            txtInvCost = new TextBox();
            label3 = new Label();
            label4 = new Label();
            groupPricePercentage = new GroupBox();
            txtMarkRoyal = new TextBox();
            txtMarkVip = new TextBox();
            txtMarkWholesale = new TextBox();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            txtMarkPrice = new TextBox();
            cbIsNonVat = new CheckBox();
            btnHistory = new Button();
            panelBottomButtons = new Panel();
            panelProductsList = new Panel();
            panelWorkspace = new Panel();
            textBox1 = new TextBox();
            labelSKU = new Label();
            label13 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            groupCostPriice.SuspendLayout();
            groupStock.SuspendLayout();
            groupCost.SuspendLayout();
            groupPricePercentage.SuspendLayout();
            panelBottomButtons.SuspendLayout();
            panelProductsList.SuspendLayout();
            panelWorkspace.SuspendLayout();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(58, 10);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(120, 68);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(184, 10);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(120, 68);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(310, 10);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 68);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(436, 10);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 68);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(562, 10);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 68);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // dgvProducts
            // 
            dgvProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(13, 30);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.Size = new Size(862, 310);
            dgvProducts.TabIndex = 5;
            dgvProducts.CellClick += dgvProducts_CellClick;
            dgvProducts.CellContentClick += dgvProducts_CellContentClick;
            // 
            // labelProducts
            // 
            labelProducts.AutoSize = true;
            labelProducts.Location = new Point(20, 7);
            labelProducts.Name = "labelProducts";
            labelProducts.Size = new Size(92, 20);
            labelProducts.TabIndex = 6;
            labelProducts.Text = "Products List";
            // 
            // txtBarcode
            // 
            txtBarcode.Location = new Point(12, 28);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Size = new Size(223, 27);
            txtBarcode.TabIndex = 7;
            txtBarcode.Leave += txtBarcode_Leave;
            // 
            // txtProdName
            // 
            txtProdName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtProdName.Location = new Point(262, 28);
            txtProdName.Name = "txtProdName";
            txtProdName.Size = new Size(612, 27);
            txtProdName.TabIndex = 8;
            // 
            // txtAltProdName
            // 
            txtAltProdName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtAltProdName.Location = new Point(262, 77);
            txtAltProdName.Name = "txtAltProdName";
            txtAltProdName.Size = new Size(612, 27);
            txtAltProdName.TabIndex = 9;
            // 
            // txtItemCost
            // 
            txtItemCost.Location = new Point(6, 46);
            txtItemCost.Name = "txtItemCost";
            txtItemCost.Size = new Size(90, 27);
            txtItemCost.TabIndex = 10;
            txtItemCost.TextChanged += txtItemCost_TextChanged;
            // 
            // txtItemPrice
            // 
            txtItemPrice.Location = new Point(102, 46);
            txtItemPrice.Name = "txtItemPrice";
            txtItemPrice.Size = new Size(89, 27);
            txtItemPrice.TabIndex = 11;
            txtItemPrice.TextChanged += txtItemCost_TextChanged;
            // 
            // labelDesc
            // 
            labelDesc.AutoSize = true;
            labelDesc.Location = new Point(262, 5);
            labelDesc.Name = "labelDesc";
            labelDesc.Size = new Size(104, 20);
            labelDesc.TabIndex = 12;
            labelDesc.Text = "Product Name";
            // 
            // labelBarcode
            // 
            labelBarcode.AutoSize = true;
            labelBarcode.Location = new Point(12, 5);
            labelBarcode.Name = "labelBarcode";
            labelBarcode.Size = new Size(64, 20);
            labelBarcode.TabIndex = 13;
            labelBarcode.Text = "Barcode";
            // 
            // labelCost
            // 
            labelCost.AutoSize = true;
            labelCost.Location = new Point(9, 23);
            labelCost.Name = "labelCost";
            labelCost.Size = new Size(72, 20);
            labelCost.TabIndex = 14;
            labelCost.Text = "Item Cost";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(102, 23);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 15;
            label1.Text = "Item Price";
            // 
            // groupCostPriice
            // 
            groupCostPriice.Controls.Add(label7);
            groupCostPriice.Controls.Add(cbIsNonVat);
            groupCostPriice.Controls.Add(label6);
            groupCostPriice.Controls.Add(label5);
            groupCostPriice.Controls.Add(txtPriceRoyal);
            groupCostPriice.Controls.Add(txtPriceVip);
            groupCostPriice.Controls.Add(txtPriceWholesale);
            groupCostPriice.Controls.Add(label1);
            groupCostPriice.Controls.Add(labelCost);
            groupCostPriice.Controls.Add(txtItemPrice);
            groupCostPriice.Controls.Add(txtItemCost);
            groupCostPriice.Location = new Point(17, 138);
            groupCostPriice.Name = "groupCostPriice";
            groupCostPriice.Size = new Size(486, 119);
            groupCostPriice.TabIndex = 16;
            groupCostPriice.TabStop = false;
            groupCostPriice.Text = "Prices";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(387, 23);
            label7.Name = "label7";
            label7.Size = new Size(46, 20);
            label7.TabIndex = 21;
            label7.Text = "Royal";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(292, 23);
            label6.Name = "label6";
            label6.Size = new Size(30, 20);
            label6.TabIndex = 20;
            label6.Text = "VIP";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(197, 23);
            label5.Name = "label5";
            label5.Size = new Size(78, 20);
            label5.TabIndex = 19;
            label5.Text = "Wholesale";
            // 
            // txtPriceRoyal
            // 
            txtPriceRoyal.Location = new Point(387, 46);
            txtPriceRoyal.Name = "txtPriceRoyal";
            txtPriceRoyal.Size = new Size(89, 27);
            txtPriceRoyal.TabIndex = 18;
            txtPriceRoyal.TextChanged += txtItemCost_TextChanged;
            // 
            // txtPriceVip
            // 
            txtPriceVip.Location = new Point(292, 46);
            txtPriceVip.Name = "txtPriceVip";
            txtPriceVip.Size = new Size(89, 27);
            txtPriceVip.TabIndex = 17;
            txtPriceVip.TextChanged += txtItemCost_TextChanged;
            // 
            // txtPriceWholesale
            // 
            txtPriceWholesale.Location = new Point(197, 46);
            txtPriceWholesale.Name = "txtPriceWholesale";
            txtPriceWholesale.Size = new Size(89, 27);
            txtPriceWholesale.TabIndex = 16;
            txtPriceWholesale.TextChanged += txtItemCost_TextChanged;
            // 
            // txtStoreStock
            // 
            txtStoreStock.Enabled = false;
            txtStoreStock.Location = new Point(16, 46);
            txtStoreStock.Name = "txtStoreStock";
            txtStoreStock.Size = new Size(83, 27);
            txtStoreStock.TabIndex = 16;
            // 
            // labelStoreStock
            // 
            labelStoreStock.AutoSize = true;
            labelStoreStock.Location = new Point(37, 23);
            labelStoreStock.Name = "labelStoreStock";
            labelStoreStock.Size = new Size(44, 20);
            labelStoreStock.TabIndex = 16;
            labelStoreStock.Text = "Store";
            // 
            // groupStock
            // 
            groupStock.Controls.Add(label2);
            groupStock.Controls.Add(txtWhStock);
            groupStock.Controls.Add(labelStoreStock);
            groupStock.Controls.Add(txtStoreStock);
            groupStock.Location = new Point(520, 142);
            groupStock.Name = "groupStock";
            groupStock.Size = new Size(214, 98);
            groupStock.TabIndex = 17;
            groupStock.TabStop = false;
            groupStock.Text = "Stock";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(120, 23);
            label2.Name = "label2";
            label2.Size = new Size(34, 20);
            label2.TabIndex = 18;
            label2.Text = "WH";
            // 
            // txtWhStock
            // 
            txtWhStock.Enabled = false;
            txtWhStock.Location = new Point(120, 46);
            txtWhStock.Name = "txtWhStock";
            txtWhStock.Size = new Size(73, 27);
            txtWhStock.TabIndex = 17;
            // 
            // groupCost
            // 
            groupCost.Controls.Add(txtInvPrice);
            groupCost.Controls.Add(txtInvCost);
            groupCost.Controls.Add(label3);
            groupCost.Controls.Add(label4);
            groupCost.Location = new Point(520, 246);
            groupCost.Name = "groupCost";
            groupCost.Size = new Size(218, 98);
            groupCost.TabIndex = 19;
            groupCost.TabStop = false;
            groupCost.Text = "Inventory Cost";
            // 
            // txtInvPrice
            // 
            txtInvPrice.Location = new Point(125, 46);
            txtInvPrice.Name = "txtInvPrice";
            txtInvPrice.Size = new Size(89, 27);
            txtInvPrice.TabIndex = 26;
            // 
            // txtInvCost
            // 
            txtInvCost.Location = new Point(10, 46);
            txtInvCost.Name = "txtInvCost";
            txtInvCost.Size = new Size(89, 27);
            txtInvCost.TabIndex = 25;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(136, 23);
            label3.Name = "label3";
            label3.Size = new Size(78, 20);
            label3.TabIndex = 18;
            label3.Text = "Total Price";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 23);
            label4.Name = "label4";
            label4.Size = new Size(75, 20);
            label4.TabIndex = 16;
            label4.Text = "Total Cost";
            label4.Click += label4_Click;
            // 
            // groupPricePercentage
            // 
            groupPricePercentage.Controls.Add(txtMarkRoyal);
            groupPricePercentage.Controls.Add(txtMarkVip);
            groupPricePercentage.Controls.Add(txtMarkWholesale);
            groupPricePercentage.Controls.Add(label8);
            groupPricePercentage.Controls.Add(label9);
            groupPricePercentage.Controls.Add(label10);
            groupPricePercentage.Controls.Add(label11);
            groupPricePercentage.Controls.Add(txtMarkPrice);
            groupPricePercentage.Location = new Point(17, 263);
            groupPricePercentage.Name = "groupPricePercentage";
            groupPricePercentage.Size = new Size(486, 81);
            groupPricePercentage.TabIndex = 22;
            groupPricePercentage.TabStop = false;
            groupPricePercentage.Text = "Price Mark Ups %";
            // 
            // txtMarkRoyal
            // 
            txtMarkRoyal.Location = new Point(344, 46);
            txtMarkRoyal.Name = "txtMarkRoyal";
            txtMarkRoyal.Size = new Size(89, 27);
            txtMarkRoyal.TabIndex = 24;
            txtMarkRoyal.TextChanged += txtMarkPrice_TextChanged;
            // 
            // txtMarkVip
            // 
            txtMarkVip.Location = new Point(249, 46);
            txtMarkVip.Name = "txtMarkVip";
            txtMarkVip.Size = new Size(89, 27);
            txtMarkVip.TabIndex = 23;
            txtMarkVip.TextChanged += txtMarkPrice_TextChanged;
            // 
            // txtMarkWholesale
            // 
            txtMarkWholesale.Location = new Point(154, 46);
            txtMarkWholesale.Name = "txtMarkWholesale";
            txtMarkWholesale.Size = new Size(89, 27);
            txtMarkWholesale.TabIndex = 22;
            txtMarkWholesale.TextChanged += txtMarkPrice_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(345, 23);
            label8.Name = "label8";
            label8.Size = new Size(46, 20);
            label8.TabIndex = 21;
            label8.Text = "Royal";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(249, 23);
            label9.Name = "label9";
            label9.Size = new Size(30, 20);
            label9.TabIndex = 20;
            label9.Text = "VIP";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(154, 23);
            label10.Name = "label10";
            label10.Size = new Size(78, 20);
            label10.TabIndex = 19;
            label10.Text = "Wholesale";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(59, 23);
            label11.Name = "label11";
            label11.Size = new Size(75, 20);
            label11.TabIndex = 15;
            label11.Text = "Item Price";
            // 
            // txtMarkPrice
            // 
            txtMarkPrice.Location = new Point(59, 46);
            txtMarkPrice.Name = "txtMarkPrice";
            txtMarkPrice.Size = new Size(89, 27);
            txtMarkPrice.TabIndex = 11;
            txtMarkPrice.TextChanged += txtMarkPrice_TextChanged;
            // 
            // cbIsNonVat
            // 
            cbIsNonVat.AutoSize = true;
            cbIsNonVat.Location = new Point(385, 79);
            cbIsNonVat.Name = "cbIsNonVat";
            cbIsNonVat.Size = new Size(95, 24);
            cbIsNonVat.TabIndex = 23;
            cbIsNonVat.Text = "NON-VAT";
            cbIsNonVat.UseVisualStyleBackColor = true;
            // 
            // btnHistory
            // 
            btnHistory.Location = new Point(755, 10);
            btnHistory.Name = "btnHistory";
            btnHistory.Size = new Size(120, 68);
            btnHistory.TabIndex = 24;
            btnHistory.Text = "Purchases\r\nHistory";
            btnHistory.UseVisualStyleBackColor = true;
            // 
            // panelBottomButtons
            // 
            panelBottomButtons.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelBottomButtons.Controls.Add(btnHistory);
            panelBottomButtons.Controls.Add(btnCancel);
            panelBottomButtons.Controls.Add(btnDelete);
            panelBottomButtons.Controls.Add(btnSave);
            panelBottomButtons.Controls.Add(btnEdit);
            panelBottomButtons.Controls.Add(btnAdd);
            panelBottomButtons.Location = new Point(0, 695);
            panelBottomButtons.Name = "panelBottomButtons";
            panelBottomButtons.Size = new Size(891, 85);
            panelBottomButtons.TabIndex = 25;
            // 
            // panelProductsList
            // 
            panelProductsList.Controls.Add(labelProducts);
            panelProductsList.Controls.Add(dgvProducts);
            panelProductsList.Dock = DockStyle.Top;
            panelProductsList.Location = new Point(0, 0);
            panelProductsList.Name = "panelProductsList";
            panelProductsList.Size = new Size(891, 347);
            panelProductsList.TabIndex = 26;
            // 
            // panelWorkspace
            // 
            panelWorkspace.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelWorkspace.Controls.Add(label13);
            panelWorkspace.Controls.Add(labelSKU);
            panelWorkspace.Controls.Add(textBox1);
            panelWorkspace.Controls.Add(groupPricePercentage);
            panelWorkspace.Controls.Add(groupCost);
            panelWorkspace.Controls.Add(groupStock);
            panelWorkspace.Controls.Add(groupCostPriice);
            panelWorkspace.Controls.Add(labelBarcode);
            panelWorkspace.Controls.Add(labelDesc);
            panelWorkspace.Controls.Add(txtAltProdName);
            panelWorkspace.Controls.Add(txtProdName);
            panelWorkspace.Controls.Add(txtBarcode);
            panelWorkspace.Location = new Point(1, 345);
            panelWorkspace.Name = "panelWorkspace";
            panelWorkspace.Size = new Size(889, 349);
            panelWorkspace.TabIndex = 27;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 77);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(223, 27);
            textBox1.TabIndex = 24;
            // 
            // labelSKU
            // 
            labelSKU.AutoSize = true;
            labelSKU.Location = new Point(14, 57);
            labelSKU.Name = "labelSKU";
            labelSKU.Size = new Size(36, 20);
            labelSKU.TabIndex = 25;
            labelSKU.Text = "SKU";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(262, 57);
            label13.Name = "label13";
            label13.Size = new Size(137, 20);
            label13.TabIndex = 26;
            label13.Text = "Product Name (Alt)";
            // 
            // ucProductMaster
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelWorkspace);
            Controls.Add(panelProductsList);
            Controls.Add(panelBottomButtons);
            Name = "ucProductMaster";
            Size = new Size(891, 780);
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            groupCostPriice.ResumeLayout(false);
            groupCostPriice.PerformLayout();
            groupStock.ResumeLayout(false);
            groupStock.PerformLayout();
            groupCost.ResumeLayout(false);
            groupCost.PerformLayout();
            groupPricePercentage.ResumeLayout(false);
            groupPricePercentage.PerformLayout();
            panelBottomButtons.ResumeLayout(false);
            panelProductsList.ResumeLayout(false);
            panelProductsList.PerformLayout();
            panelWorkspace.ResumeLayout(false);
            panelWorkspace.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnAdd;
        private Button btnEdit;
        private Button btnSave;
        private Button btnDelete;
        private Button btnCancel;
        private DataGridView dgvProducts;
        private Label labelProducts;
        private TextBox txtBarcode;
        private TextBox txtProdName;
        private TextBox txtAltProdName;
        private TextBox txtItemCost;
        private TextBox txtItemPrice;
        private Label labelDesc;
        private Label labelBarcode;
        private Label labelCost;
        private Label label1;
        private GroupBox groupCostPriice;
        private TextBox txtStoreStock;
        private Label labelStoreStock;
        private GroupBox groupStock;
        private Label label2;
        private TextBox txtWhStock;
        private GroupBox groupCost;
        private Label label3;
        private TextBox textBox7;
        private Label label4;
        private TextBox textBox8;
        private Label label7;
        private Label label6;
        private Label label5;
        private TextBox txtPriceRoyal;
        private TextBox txtPriceVip;
        private TextBox txtPriceWholesale;
        private GroupBox groupPricePercentage;
        private Label label8;
        private Label label9;
        private Label label10;
        private TextBox textBox12;
        private TextBox textBox13;
        private TextBox textBox14;
        private Label label11;
        private Label label12;
        private TextBox txtMarkPrice;
        private TextBox c;
        private CheckBox cbIsNonVat;
        private Button btnHistory;
        private TextBox txtInvPrice;
        private TextBox txtInvCost;
        private TextBox txtMarkRoyal;
        private TextBox txtMarkVip;
        private TextBox txtMarkWholesale;
        private Panel panelBottomButtons;
        private Panel panelProductsList;
        private Panel panelWorkspace;
        private Label label13;
        private Label labelSKU;
        private TextBox textBox1;
    }
}
