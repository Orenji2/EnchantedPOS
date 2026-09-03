namespace EnchantedPOS
{
    partial class formPOS
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
            panelBarcode = new Panel();
            btnRecall = new Button();
            pnlBottom = new Panel();
            btnSuspend = new Button();
            groupBox1 = new GroupBox();
            labelBarcode = new Label();
            txtProdName = new TextBox();
            txtQty = new TextBox();
            txtUnitPrice = new TextBox();
            txtBarcode = new TextBox();
            btnReprint = new Button();
            txtPrice = new TextBox();
            txtTotalAmnt = new TextBox();
            panelSales = new Panel();
            dataGridView1 = new DataGridView();
            barcode = new DataGridViewTextBoxColumn();
            prod_name = new DataGridViewTextBoxColumn();
            quantity = new DataGridViewTextBoxColumn();
            price = new DataGridViewTextBoxColumn();
            amnt = new DataGridViewTextBoxColumn();
            disc = new DataGridViewTextBoxColumn();
            regprice = new DataGridViewTextBoxColumn();
            colNonVat = new DataGridViewTextBoxColumn();
            labelSales = new Label();
            panelTotal = new Panel();
            panelBarcode.SuspendLayout();
            groupBox1.SuspendLayout();
            panelSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panelTotal.SuspendLayout();
            SuspendLayout();
            // 
            // panelBarcode
            // 
            panelBarcode.BackColor = Color.FromArgb(64, 64, 64);
            panelBarcode.Controls.Add(btnRecall);
            panelBarcode.Controls.Add(pnlBottom);
            panelBarcode.Controls.Add(btnSuspend);
            panelBarcode.Controls.Add(groupBox1);
            panelBarcode.Controls.Add(btnReprint);
            panelBarcode.Controls.Add(txtPrice);
            panelBarcode.Dock = DockStyle.Right;
            panelBarcode.Location = new Point(933, 0);
            panelBarcode.Margin = new Padding(3, 4, 3, 4);
            panelBarcode.Name = "panelBarcode";
            panelBarcode.Size = new Size(352, 861);
            panelBarcode.TabIndex = 0;
            // 
            // btnRecall
            // 
            btnRecall.BackColor = Color.Teal;
            btnRecall.FlatStyle = FlatStyle.Flat;
            btnRecall.ForeColor = SystemColors.ControlLightLight;
            btnRecall.Location = new Point(233, 337);
            btnRecall.Margin = new Padding(3, 4, 3, 4);
            btnRecall.Name = "btnRecall";
            btnRecall.Size = new Size(87, 93);
            btnRecall.TabIndex = 6;
            btnRecall.Text = "RECALL";
            btnRecall.UseVisualStyleBackColor = false;
            // 
            // pnlBottom
            // 
            pnlBottom.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlBottom.BackColor = Color.Teal;
            pnlBottom.Location = new Point(3, 452);
            pnlBottom.Margin = new Padding(3, 4, 3, 4);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Size = new Size(354, 409);
            pnlBottom.TabIndex = 5;
            // 
            // btnSuspend
            // 
            btnSuspend.BackColor = Color.Teal;
            btnSuspend.FlatStyle = FlatStyle.Flat;
            btnSuspend.ForeColor = SystemColors.ControlLightLight;
            btnSuspend.Location = new Point(128, 337);
            btnSuspend.Margin = new Padding(3, 4, 3, 4);
            btnSuspend.Name = "btnSuspend";
            btnSuspend.Size = new Size(98, 93);
            btnSuspend.TabIndex = 5;
            btnSuspend.Text = "SUSPEND";
            btnSuspend.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(64, 64, 64);
            groupBox1.Controls.Add(labelBarcode);
            groupBox1.Controls.Add(txtProdName);
            groupBox1.Controls.Add(txtQty);
            groupBox1.Controls.Add(txtUnitPrice);
            groupBox1.Controls.Add(txtBarcode);
            groupBox1.Location = new Point(3, 81);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(397, 204);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            // 
            // labelBarcode
            // 
            labelBarcode.AutoSize = true;
            labelBarcode.ForeColor = SystemColors.ControlLight;
            labelBarcode.Location = new Point(7, 20);
            labelBarcode.Name = "labelBarcode";
            labelBarcode.Size = new Size(64, 20);
            labelBarcode.TabIndex = 4;
            labelBarcode.Text = "Barcode";
            // 
            // txtProdName
            // 
            txtProdName.Enabled = false;
            txtProdName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtProdName.Location = new Point(7, 132);
            txtProdName.Margin = new Padding(3, 4, 3, 4);
            txtProdName.Multiline = true;
            txtProdName.Name = "txtProdName";
            txtProdName.ReadOnly = true;
            txtProdName.Size = new Size(322, 71);
            txtProdName.TabIndex = 3;
            // 
            // txtQty
            // 
            txtQty.BorderStyle = BorderStyle.None;
            txtQty.Enabled = false;
            txtQty.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtQty.Location = new Point(273, 59);
            txtQty.Margin = new Padding(3, 4, 3, 4);
            txtQty.Name = "txtQty";
            txtQty.Size = new Size(49, 32);
            txtQty.TabIndex = 2;
            txtQty.Text = "1";
            txtQty.KeyDown += txtQty_KeyDown;
            // 
            // txtUnitPrice
            // 
            txtUnitPrice.BorderStyle = BorderStyle.None;
            txtUnitPrice.Enabled = false;
            txtUnitPrice.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUnitPrice.Location = new Point(191, 59);
            txtUnitPrice.Margin = new Padding(3, 4, 3, 4);
            txtUnitPrice.Name = "txtUnitPrice";
            txtUnitPrice.ReadOnly = true;
            txtUnitPrice.Size = new Size(75, 32);
            txtUnitPrice.TabIndex = 1;
            // 
            // txtBarcode
            // 
            txtBarcode.BorderStyle = BorderStyle.None;
            txtBarcode.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBarcode.Location = new Point(7, 59);
            txtBarcode.Margin = new Padding(3, 4, 3, 4);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Size = new Size(177, 32);
            txtBarcode.TabIndex = 0;
            txtBarcode.KeyDown += txtBarcode_KeyDown;
            // 
            // btnReprint
            // 
            btnReprint.BackColor = Color.Teal;
            btnReprint.FlatStyle = FlatStyle.Flat;
            btnReprint.ForeColor = SystemColors.ControlLightLight;
            btnReprint.Location = new Point(23, 337);
            btnReprint.Margin = new Padding(3, 4, 3, 4);
            btnReprint.Name = "btnReprint";
            btnReprint.Size = new Size(98, 93);
            btnReprint.TabIndex = 1;
            btnReprint.Text = "REPRINT";
            btnReprint.UseVisualStyleBackColor = false;
            btnReprint.Click += btnReprint_Click;
            // 
            // txtPrice
            // 
            txtPrice.Enabled = false;
            txtPrice.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtPrice.Location = new Point(10, 17);
            txtPrice.Margin = new Padding(3, 4, 3, 4);
            txtPrice.Name = "txtPrice";
            txtPrice.ReadOnly = true;
            txtPrice.Size = new Size(322, 56);
            txtPrice.TabIndex = 0;
            // 
            // txtTotalAmnt
            // 
            txtTotalAmnt.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTotalAmnt.BackColor = Color.FromArgb(0, 64, 64);
            txtTotalAmnt.BorderStyle = BorderStyle.FixedSingle;
            txtTotalAmnt.Font = new Font("Segoe UI", 60F, FontStyle.Bold);
            txtTotalAmnt.ForeColor = SystemColors.Window;
            txtTotalAmnt.Location = new Point(-3, 0);
            txtTotalAmnt.Margin = new Padding(3, 4, 3, 4);
            txtTotalAmnt.Name = "txtTotalAmnt";
            txtTotalAmnt.ReadOnly = true;
            txtTotalAmnt.Size = new Size(940, 141);
            txtTotalAmnt.TabIndex = 6;
            txtTotalAmnt.Text = "0.00";
            // 
            // panelSales
            // 
            panelSales.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelSales.BackColor = Color.Teal;
            panelSales.Controls.Add(dataGridView1);
            panelSales.Location = new Point(0, 189);
            panelSales.Margin = new Padding(3, 4, 3, 4);
            panelSales.Name = "panelSales";
            panelSales.Size = new Size(933, 672);
            panelSales.TabIndex = 7;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.BackgroundColor = Color.FromArgb(224, 224, 224);
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { barcode, prod_name, quantity, price, amnt, disc, regprice, colNonVat });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.GridColor = SystemColors.Menu;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(933, 672);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            // 
            // barcode
            // 
            barcode.HeaderText = "Barcode";
            barcode.MinimumWidth = 6;
            barcode.Name = "barcode";
            barcode.ReadOnly = true;
            barcode.Width = 150;
            // 
            // prod_name
            // 
            prod_name.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            prod_name.HeaderText = "Item Description";
            prod_name.MinimumWidth = 6;
            prod_name.Name = "prod_name";
            prod_name.ReadOnly = true;
            prod_name.Resizable = DataGridViewTriState.False;
            // 
            // quantity
            // 
            quantity.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            quantity.HeaderText = "QTY";
            quantity.MinimumWidth = 6;
            quantity.Name = "quantity";
            quantity.ReadOnly = true;
            quantity.Width = 64;
            // 
            // price
            // 
            price.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            price.HeaderText = "SRP";
            price.MinimumWidth = 6;
            price.Name = "price";
            price.ReadOnly = true;
            price.Width = 63;
            // 
            // amnt
            // 
            amnt.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            amnt.HeaderText = "Amount";
            amnt.MinimumWidth = 6;
            amnt.Name = "amnt";
            amnt.ReadOnly = true;
            amnt.Width = 91;
            // 
            // disc
            // 
            disc.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            disc.HeaderText = "Disc %";
            disc.MinimumWidth = 6;
            disc.Name = "disc";
            disc.ReadOnly = true;
            disc.Width = 82;
            // 
            // regprice
            // 
            regprice.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            regprice.HeaderText = "Reg. SRP";
            regprice.MinimumWidth = 6;
            regprice.Name = "regprice";
            regprice.ReadOnly = true;
            regprice.Width = 96;
            // 
            // colNonVat
            // 
            colNonVat.HeaderText = "nonVat";
            colNonVat.MinimumWidth = 6;
            colNonVat.Name = "colNonVat";
            colNonVat.ReadOnly = true;
            colNonVat.Visible = false;
            colNonVat.Width = 125;
            // 
            // labelSales
            // 
            labelSales.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelSales.AutoSize = true;
            labelSales.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelSales.ForeColor = SystemColors.ControlLight;
            labelSales.Location = new Point(444, 145);
            labelSales.Name = "labelSales";
            labelSales.Size = new Size(117, 28);
            labelSales.TabIndex = 1;
            labelSales.Text = "Sales Entry";
            // 
            // panelTotal
            // 
            panelTotal.BackColor = Color.Teal;
            panelTotal.Controls.Add(txtTotalAmnt);
            panelTotal.Controls.Add(labelSales);
            panelTotal.Dock = DockStyle.Top;
            panelTotal.Location = new Point(0, 0);
            panelTotal.Name = "panelTotal";
            panelTotal.Size = new Size(933, 187);
            panelTotal.TabIndex = 7;
            // 
            // formPOS
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1285, 861);
            Controls.Add(panelTotal);
            Controls.Add(panelSales);
            Controls.Add(panelBarcode);
            Margin = new Padding(3, 4, 3, 4);
            Name = "formPOS";
            Text = "Keys: F1 - Barcode, F2 - Save, F3-Edit,F6-Cash Drawer, F9-Reprint, F10-Suspend,F11-Recall,F12-SDisc.<ENTER>-Browse, /-Quantity";
            FormClosed += formPOS_FormClosed;
            Load += formPOS_Load;
            KeyDown += formPOS_KeyDown;
            panelBarcode.ResumeLayout(false);
            panelBarcode.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panelSales.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panelTotal.ResumeLayout(false);
            panelTotal.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelBarcode;
        private TextBox txtPrice;
        private GroupBox groupBox1;
        private TextBox txtBarcode;
        private Button btnReprint;
        private TextBox txtProdName;
        private TextBox txtQty;
        private TextBox txtUnitPrice;
        private Panel pnlBottom;
        private TextBox txtTotalAmnt;
        private Panel panelSales;
        private Label labelSales;
        private DataGridView dataGridView1;
        private Label labelBarcode;
        private Button btnRecall;
        private Button btnSuspend;
        private Panel panelTotal;
        private DataGridViewTextBoxColumn barcode;
        private DataGridViewTextBoxColumn prod_name;
        private DataGridViewTextBoxColumn quantity;
        private DataGridViewTextBoxColumn price;
        private DataGridViewTextBoxColumn amnt;
        private DataGridViewTextBoxColumn disc;
        private DataGridViewTextBoxColumn regprice;
        private DataGridViewTextBoxColumn colNonVat;
    }
}