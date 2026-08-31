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
            lblBrowseProd.AutoSize = true;
            lblBrowseProd.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBrowseProd.Location = new Point(277, 9);
            lblBrowseProd.Name = "lblBrowseProd";
            lblBrowseProd.Size = new Size(154, 25);
            lblBrowseProd.TabIndex = 0;
            lblBrowseProd.Text = "Browse Product";
            // 
            // groupSearchCriteria
            // 
            groupSearchCriteria.Controls.Add(radioKorProdName);
            groupSearchCriteria.Controls.Add(radioEngProdName);
            groupSearchCriteria.Controls.Add(radioBarcode);
            groupSearchCriteria.Location = new Point(19, 37);
            groupSearchCriteria.Name = "groupSearchCriteria";
            groupSearchCriteria.Size = new Size(569, 48);
            groupSearchCriteria.TabIndex = 1;
            groupSearchCriteria.TabStop = false;
            groupSearchCriteria.Text = "Search Criteria";
            // 
            // radioKorProdName
            // 
            radioKorProdName.AutoSize = true;
            radioKorProdName.Location = new Point(297, 22);
            radioKorProdName.Name = "radioKorProdName";
            radioKorProdName.Size = new Size(142, 19);
            radioKorProdName.TabIndex = 2;
            radioKorProdName.TabStop = true;
            radioKorProdName.Text = "Product Name Korean";
            radioKorProdName.UseVisualStyleBackColor = true;
            // 
            // radioEngProdName
            // 
            radioEngProdName.AutoSize = true;
            radioEngProdName.Location = new Point(129, 22);
            radioEngProdName.Name = "radioEngProdName";
            radioEngProdName.Size = new Size(143, 19);
            radioEngProdName.TabIndex = 1;
            radioEngProdName.TabStop = true;
            radioEngProdName.Text = "Product Name English";
            radioEngProdName.UseVisualStyleBackColor = true;
            // 
            // radioBarcode
            // 
            radioBarcode.AutoSize = true;
            radioBarcode.Location = new Point(15, 22);
            radioBarcode.Name = "radioBarcode";
            radioBarcode.Size = new Size(73, 19);
            radioBarcode.TabIndex = 0;
            radioBarcode.TabStop = true;
            radioBarcode.Text = "Bar Code";
            radioBarcode.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(594, 46);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(94, 39);
            btnOk.TabIndex = 2;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(694, 46);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 39);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // labelSearch
            // 
            labelSearch.AutoSize = true;
            labelSearch.Location = new Point(26, 103);
            labelSearch.Name = "labelSearch";
            labelSearch.Size = new Size(69, 15);
            labelSearch.TabIndex = 4;
            labelSearch.Text = "Search Item";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(23, 121);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(565, 23);
            txtSearch.TabIndex = 5;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // dgvProdList
            // 
            dgvProdList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProdList.Columns.AddRange(new DataGridViewColumn[] { colProdDesc, colPrice, colPriceBox, colBarcode });
            dgvProdList.Location = new Point(26, 157);
            dgvProdList.Name = "dgvProdList";
            dgvProdList.ReadOnly = true;
            dgvProdList.Size = new Size(763, 440);
            dgvProdList.TabIndex = 6;
            dgvProdList.CellDoubleClick += dgvProdList_CellDoubleClick;
            dgvProdList.KeyDown += dgvProdList_KeyDown;
            // 
            // colProdDesc
            // 
            colProdDesc.HeaderText = "Product Description";
            colProdDesc.Name = "colProdDesc";
            colProdDesc.ReadOnly = true;
            colProdDesc.Width = 320;
            // 
            // colPrice
            // 
            colPrice.HeaderText = "Price per PCS";
            colPrice.Name = "colPrice";
            colPrice.ReadOnly = true;
            // 
            // colPriceBox
            // 
            colPriceBox.HeaderText = "Price Per Box";
            colPriceBox.Name = "colPriceBox";
            colPriceBox.ReadOnly = true;
            // 
            // colBarcode
            // 
            colBarcode.HeaderText = "Barcode";
            colBarcode.Name = "colBarcode";
            colBarcode.ReadOnly = true;
            colBarcode.Width = 200;
            // 
            // formProdBrowse
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(801, 608);
            Controls.Add(dgvProdList);
            Controls.Add(txtSearch);
            Controls.Add(labelSearch);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(groupSearchCriteria);
            Controls.Add(lblBrowseProd);
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