namespace EnchantedPOS
{
    partial class formProdBrowse
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
            lblBrowseProd = new Label();
            groupSearchCriteria = new GroupBox();
            radioKorProdName = new RadioButton();
            radioEngProdName = new RadioButton();
            radioBarcode = new RadioButton();
            btnOk = new Button();
            btnCancel = new Button();
            labelSearch = new Label();
            txtSearch = new TextBox();
            dgvProdList = new DataGridView();
            colProdDesc = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            colPriceBox = new DataGridViewTextBoxColumn();
            colBarcode = new DataGridViewTextBoxColumn();
            groupSearchCriteria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProdList).BeginInit();
            SuspendLayout();
            // 
            // lblBrowseProd
            // 
            lblBrowseProd.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblBrowseProd.AutoSize = true;
            lblBrowseProd.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBrowseProd.Location = new Point(317, 12);
            lblBrowseProd.Name = "lblBrowseProd";
            lblBrowseProd.Size = new Size(195, 32);
            lblBrowseProd.TabIndex = 0;
            lblBrowseProd.Text = "Browse Product";
            // 
            // groupSearchCriteria
            // 
            groupSearchCriteria.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupSearchCriteria.Controls.Add(radioKorProdName);
            groupSearchCriteria.Controls.Add(radioEngProdName);
            groupSearchCriteria.Controls.Add(radioBarcode);
            groupSearchCriteria.Location = new Point(22, 49);
            groupSearchCriteria.Margin = new Padding(3, 4, 3, 4);
            groupSearchCriteria.Name = "groupSearchCriteria";
            groupSearchCriteria.Padding = new Padding(3, 4, 3, 4);
            groupSearchCriteria.Size = new Size(650, 64);
            groupSearchCriteria.TabIndex = 1;
            groupSearchCriteria.TabStop = false;
            groupSearchCriteria.Text = "Search Criteria";
            // 
            // radioKorProdName
            // 
            radioKorProdName.AutoSize = true;
            radioKorProdName.Location = new Point(339, 29);
            radioKorProdName.Margin = new Padding(3, 4, 3, 4);
            radioKorProdName.Name = "radioKorProdName";
            radioKorProdName.Size = new Size(176, 24);
            radioKorProdName.TabIndex = 2;
            radioKorProdName.TabStop = true;
            radioKorProdName.Text = "Product Name Korean";
            radioKorProdName.UseVisualStyleBackColor = true;
            // 
            // radioEngProdName
            // 
            radioEngProdName.AutoSize = true;
            radioEngProdName.Location = new Point(147, 29);
            radioEngProdName.Margin = new Padding(3, 4, 3, 4);
            radioEngProdName.Name = "radioEngProdName";
            radioEngProdName.Size = new Size(176, 24);
            radioEngProdName.TabIndex = 1;
            radioEngProdName.TabStop = true;
            radioEngProdName.Text = "Product Name English";
            radioEngProdName.UseVisualStyleBackColor = true;
            // 
            // radioBarcode
            // 
            radioBarcode.AutoSize = true;
            radioBarcode.Location = new Point(17, 29);
            radioBarcode.Margin = new Padding(3, 4, 3, 4);
            radioBarcode.Name = "radioBarcode";
            radioBarcode.Size = new Size(91, 24);
            radioBarcode.TabIndex = 0;
            radioBarcode.TabStop = true;
            radioBarcode.Text = "Bar Code";
            radioBarcode.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            btnOk.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOk.Location = new Point(679, 61);
            btnOk.Margin = new Padding(3, 4, 3, 4);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(107, 52);
            btnOk.TabIndex = 2;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancel.Location = new Point(793, 61);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(107, 52);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // labelSearch
            // 
            labelSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelSearch.AutoSize = true;
            labelSearch.Location = new Point(30, 137);
            labelSearch.Name = "labelSearch";
            labelSearch.Size = new Size(87, 20);
            labelSearch.TabIndex = 4;
            labelSearch.Text = "Search Item";
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Location = new Point(26, 161);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(645, 27);
            txtSearch.TabIndex = 5;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // dgvProdList
            // 
            dgvProdList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProdList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProdList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProdList.Columns.AddRange(new DataGridViewColumn[] { colProdDesc, colPrice, colPriceBox, colBarcode });
            dgvProdList.Location = new Point(30, 209);
            dgvProdList.Margin = new Padding(3, 4, 3, 4);
            dgvProdList.Name = "dgvProdList";
            dgvProdList.ReadOnly = true;
            dgvProdList.RowHeadersWidth = 51;
            dgvProdList.Size = new Size(872, 587);
            dgvProdList.TabIndex = 6;
            dgvProdList.CellDoubleClick += dgvProdList_CellDoubleClick;
            dgvProdList.KeyDown += dgvProdList_KeyDown;
            // 
            // colProdDesc
            // 
            colProdDesc.HeaderText = "Product Description";
            colProdDesc.MinimumWidth = 6;
            colProdDesc.Name = "colProdDesc";
            colProdDesc.ReadOnly = true;
            // 
            // colPrice
            // 
            colPrice.HeaderText = "Price per PCS";
            colPrice.MinimumWidth = 6;
            colPrice.Name = "colPrice";
            colPrice.ReadOnly = true;
            // 
            // colPriceBox
            // 
            colPriceBox.HeaderText = "Price Per Box";
            colPriceBox.MinimumWidth = 6;
            colPriceBox.Name = "colPriceBox";
            colPriceBox.ReadOnly = true;
            // 
            // colBarcode
            // 
            colBarcode.HeaderText = "Barcode";
            colBarcode.MinimumWidth = 6;
            colBarcode.Name = "colBarcode";
            colBarcode.ReadOnly = true;
            // 
            // formProdBrowse
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(915, 811);
            Controls.Add(dgvProdList);
            Controls.Add(txtSearch);
            Controls.Add(labelSearch);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(groupSearchCriteria);
            Controls.Add(lblBrowseProd);
            Margin = new Padding(3, 4, 3, 4);
            Name = "formProdBrowse";
            Text = "Browse Product";
            Load += formProdBrowse_Load;
            groupSearchCriteria.ResumeLayout(false);
            groupSearchCriteria.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProdList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBrowseProd;
        private GroupBox groupSearchCriteria;
        private RadioButton radioKorProdName;
        private RadioButton radioEngProdName;
        private RadioButton radioBarcode;
        private Button btnOk;
        private Button btnCancel;
        private Label labelSearch;
        private TextBox txtSearch;
        private DataGridView dgvProdList;
        private DataGridViewTextBoxColumn colProdDesc;
        private DataGridViewTextBoxColumn colPrice;
        private DataGridViewTextBoxColumn colPriceBox;
        private DataGridViewTextBoxColumn colBarcode;
    }
}