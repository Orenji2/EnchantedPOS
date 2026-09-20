namespace EnchantedPOS
{
    partial class ucInventoryAdjustment
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
            txtBarcode = new TextBox();
            label1 = new Label();
            txtProdName = new TextBox();
            label2 = new Label();
            txtStock = new TextBox();
            label3 = new Label();
            txtAdjQty = new TextBox();
            label4 = new Label();
            txtRemarks = new TextBox();
            label5 = new Label();
            cmbAdjType = new ComboBox();
            label6 = new Label();
            panelTextBoxes = new Panel();
            label7 = new Label();
            panel1 = new Panel();
            btnCancel = new Button();
            btnSave = new Button();
            btnAdd = new Button();
            panelGrid = new Panel();
            dgvRecentAdjustments = new DataGridView();
            panelTextBoxes.SuspendLayout();
            panel1.SuspendLayout();
            panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecentAdjustments).BeginInit();
            SuspendLayout();
            // 
            // txtBarcode
            // 
            txtBarcode.Location = new Point(25, 29);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Size = new Size(358, 27);
            txtBarcode.TabIndex = 0;
            txtBarcode.KeyDown += txtBarcode_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 6);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 1;
            label1.Text = "Barcode:";
            // 
            // txtProdName
            // 
            txtProdName.Location = new Point(404, 29);
            txtProdName.Name = "txtProdName";
            txtProdName.ReadOnly = true;
            txtProdName.Size = new Size(482, 27);
            txtProdName.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(404, 6);
            label2.Name = "label2";
            label2.Size = new Size(107, 20);
            label2.TabIndex = 3;
            label2.Text = "Product Name:";
            // 
            // txtStock
            // 
            txtStock.Location = new Point(25, 92);
            txtStock.Name = "txtStock";
            txtStock.ReadOnly = true;
            txtStock.Size = new Size(139, 27);
            txtStock.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 69);
            label3.Name = "label3";
            label3.Size = new Size(48, 20);
            label3.TabIndex = 5;
            label3.Text = "Stock:";
            // 
            // txtAdjQty
            // 
            txtAdjQty.Location = new Point(179, 92);
            txtAdjQty.Name = "txtAdjQty";
            txtAdjQty.Size = new Size(204, 27);
            txtAdjQty.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(179, 69);
            label4.Name = "label4";
            label4.Size = new Size(132, 20);
            label4.TabIndex = 7;
            label4.Text = "Quantity to Adjust:";
            // 
            // txtRemarks
            // 
            txtRemarks.Location = new Point(25, 153);
            txtRemarks.Name = "txtRemarks";
            txtRemarks.ReadOnly = true;
            txtRemarks.Size = new Size(861, 27);
            txtRemarks.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(25, 130);
            label5.Name = "label5";
            label5.Size = new Size(140, 20);
            label5.TabIndex = 9;
            label5.Text = "Remarks: (Optional)";
            // 
            // cmbAdjType
            // 
            cmbAdjType.FormattingEnabled = true;
            cmbAdjType.Items.AddRange(new object[] { "Damaged", "Expired", "Store Use", "Correction (Add)" });
            cmbAdjType.Location = new Point(404, 92);
            cmbAdjType.Name = "cmbAdjType";
            cmbAdjType.Size = new Size(482, 28);
            cmbAdjType.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(404, 69);
            label6.Name = "label6";
            label6.Size = new Size(163, 20);
            label6.TabIndex = 11;
            label6.Text = "Reason for Adjustment:";
            // 
            // panelTextBoxes
            // 
            panelTextBoxes.Controls.Add(label7);
            panelTextBoxes.Controls.Add(label6);
            panelTextBoxes.Controls.Add(cmbAdjType);
            panelTextBoxes.Controls.Add(label5);
            panelTextBoxes.Controls.Add(txtRemarks);
            panelTextBoxes.Controls.Add(label4);
            panelTextBoxes.Controls.Add(txtAdjQty);
            panelTextBoxes.Controls.Add(label3);
            panelTextBoxes.Controls.Add(txtStock);
            panelTextBoxes.Controls.Add(label2);
            panelTextBoxes.Controls.Add(txtProdName);
            panelTextBoxes.Controls.Add(label1);
            panelTextBoxes.Controls.Add(txtBarcode);
            panelTextBoxes.Dock = DockStyle.Top;
            panelTextBoxes.Location = new Point(0, 0);
            panelTextBoxes.Name = "panelTextBoxes";
            panelTextBoxes.Size = new Size(922, 225);
            panelTextBoxes.TabIndex = 12;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(26, 199);
            label7.Name = "label7";
            label7.Size = new Size(143, 20);
            label7.TabIndex = 12;
            label7.Text = "Recent Adjustments:";
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(btnAdd);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 618);
            panel1.Name = "panel1";
            panel1.Size = new Size(922, 73);
            panel1.TabIndex = 13;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(619, 6);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(280, 64);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "CANCEL";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(322, 6);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(291, 64);
            btnSave.TabIndex = 1;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(17, 6);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(299, 64);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "ADD";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // panelGrid
            // 
            panelGrid.Controls.Add(dgvRecentAdjustments);
            panelGrid.Dock = DockStyle.Fill;
            panelGrid.Location = new Point(0, 225);
            panelGrid.Name = "panelGrid";
            panelGrid.Size = new Size(922, 393);
            panelGrid.TabIndex = 14;
            // 
            // dgvRecentAdjustments
            // 
            dgvRecentAdjustments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRecentAdjustments.Dock = DockStyle.Fill;
            dgvRecentAdjustments.Location = new Point(0, 0);
            dgvRecentAdjustments.Name = "dgvRecentAdjustments";
            dgvRecentAdjustments.RowHeadersWidth = 51;
            dgvRecentAdjustments.Size = new Size(922, 393);
            dgvRecentAdjustments.TabIndex = 0;
            // 
            // ucInventoryAdjustment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelGrid);
            Controls.Add(panel1);
            Controls.Add(panelTextBoxes);
            Name = "ucInventoryAdjustment";
            Size = new Size(922, 691);
            panelTextBoxes.ResumeLayout(false);
            panelTextBoxes.PerformLayout();
            panel1.ResumeLayout(false);
            panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRecentAdjustments).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtBarcode;
        private Label label1;
        private TextBox txtProdName;
        private Label label2;
        private TextBox txtStock;
        private Label label3;
        private TextBox txtAdjQty;
        private Label label4;
        private TextBox txtRemarks;
        private Label label5;
        private ComboBox cmbAdjType;
        private Label label6;
        private Panel panelTextBoxes;
        private Label label7;
        private Panel panel1;
        private Button btnCancel;
        private Button btnSave;
        private Button btnAdd;
        private Panel panelGrid;
        private DataGridView dgvRecentAdjustments;
    }
}
