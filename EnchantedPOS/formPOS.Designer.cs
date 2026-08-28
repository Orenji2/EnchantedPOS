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
            btnSuspend = new Button();
            groupBox1 = new GroupBox();
            labelBarcode = new Label();
            txtProdName = new TextBox();
            txtQty = new TextBox();
            txtUnitPrice = new TextBox();
            txtBarcode = new TextBox();
            btnReprint = new Button();
            txtPrice = new TextBox();
            pnlBottom = new Panel();
            txtTotalAmnt = new TextBox();
            panel1 = new Panel();
            labelSales = new Label();
            panel2 = new Panel();
            dataGridView1 = new DataGridView();
            barcode = new DataGridViewTextBoxColumn();
            prod_name = new DataGridViewTextBoxColumn();
            quantity = new DataGridViewTextBoxColumn();
            price = new DataGridViewTextBoxColumn();
            amnt = new DataGridViewTextBoxColumn();
            disc = new DataGridViewTextBoxColumn();
            regprice = new DataGridViewTextBoxColumn();
            panelBarcode.SuspendLayout();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panelBarcode
            // 
            panelBarcode.BackColor = SystemColors.ActiveCaption;
            panelBarcode.Controls.Add(btnRecall);
            panelBarcode.Controls.Add(btnSuspend);
            panelBarcode.Controls.Add(groupBox1);
            panelBarcode.Controls.Add(btnReprint);
            panelBarcode.Controls.Add(txtPrice);
            panelBarcode.Location = new Point(819, -1);
            panelBarcode.Name = "panelBarcode";
            panelBarcode.Size = new Size(308, 348);
            panelBarcode.TabIndex = 0;
            // 
            // btnRecall
            // 
            btnRecall.BackColor = Color.Green;
            btnRecall.FlatStyle = FlatStyle.Flat;
            btnRecall.ForeColor = SystemColors.ControlLightLight;
            btnRecall.Location = new Point(204, 253);
            btnRecall.Name = "btnRecall";
            btnRecall.Size = new Size(76, 70);
            btnRecall.TabIndex = 6;
            btnRecall.Text = "RECALL";
            btnRecall.UseVisualStyleBackColor = false;
            // 
            // btnSuspend
            // 
            btnSuspend.BackColor = Color.Green;
            btnSuspend.FlatStyle = FlatStyle.Flat;
            btnSuspend.ForeColor = SystemColors.ControlLightLight;
            btnSuspend.Location = new Point(112, 253);
            btnSuspend.Name = "btnSuspend";
            btnSuspend.Size = new Size(86, 70);
            btnSuspend.TabIndex = 5;
            btnSuspend.Text = "SUSPEND";
            btnSuspend.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ActiveCaption;
            groupBox1.Controls.Add(labelBarcode);
            groupBox1.Controls.Add(txtProdName);
            groupBox1.Controls.Add(txtQty);
            groupBox1.Controls.Add(txtUnitPrice);
            groupBox1.Controls.Add(txtBarcode);
            groupBox1.Location = new Point(3, 61);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(347, 153);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            // 
            // labelBarcode
            // 
            labelBarcode.AutoSize = true;
            labelBarcode.Location = new Point(6, 15);
            labelBarcode.Name = "labelBarcode";
            labelBarcode.Size = new Size(50, 15);
            labelBarcode.TabIndex = 4;
            labelBarcode.Text = "Barcode";
            // 
            // txtProdName
            // 
            txtProdName.Enabled = false;
            txtProdName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtProdName.Location = new Point(6, 99);
            txtProdName.Multiline = true;
            txtProdName.Name = "txtProdName";
            txtProdName.ReadOnly = true;
            txtProdName.Size = new Size(282, 54);
            txtProdName.TabIndex = 3;
            // 
            // txtQty
            // 
            txtQty.BorderStyle = BorderStyle.None;
            txtQty.Enabled = false;
            txtQty.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtQty.Location = new Point(239, 44);
            txtQty.Name = "txtQty";
            txtQty.Size = new Size(43, 26);
            txtQty.TabIndex = 2;
            txtQty.Text = "1";
            txtQty.KeyDown += txtQty_KeyDown;
            // 
            // txtUnitPrice
            // 
            txtUnitPrice.BorderStyle = BorderStyle.None;
            txtUnitPrice.Enabled = false;
            txtUnitPrice.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUnitPrice.Location = new Point(167, 44);
            txtUnitPrice.Name = "txtUnitPrice";
            txtUnitPrice.ReadOnly = true;
            txtUnitPrice.Size = new Size(66, 26);
            txtUnitPrice.TabIndex = 1;
            // 
            // txtBarcode
            // 
            txtBarcode.BorderStyle = BorderStyle.None;
            txtBarcode.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBarcode.Location = new Point(6, 44);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Size = new Size(155, 26);
            txtBarcode.TabIndex = 0;
            txtBarcode.KeyDown += txtBarcode_KeyDown;
            // 
            // btnReprint
            // 
            btnReprint.BackColor = Color.Green;
            btnReprint.FlatStyle = FlatStyle.Flat;
            btnReprint.ForeColor = SystemColors.ControlLightLight;
            btnReprint.Location = new Point(20, 253);
            btnReprint.Name = "btnReprint";
            btnReprint.Size = new Size(86, 70);
            btnReprint.TabIndex = 1;
            btnReprint.Text = "REPRINT";
            btnReprint.UseVisualStyleBackColor = false;
            btnReprint.Click += btnReprint_Click;
            // 
            // txtPrice
            // 
            txtPrice.Enabled = false;
            txtPrice.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtPrice.Location = new Point(9, 13);
            txtPrice.Name = "txtPrice";
            txtPrice.ReadOnly = true;
            txtPrice.Size = new Size(282, 46);
            txtPrice.TabIndex = 0;
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = Color.ForestGreen;
            pnlBottom.Location = new Point(818, 347);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Size = new Size(306, 307);
            pnlBottom.TabIndex = 5;
            // 
            // txtTotalAmnt
            // 
            txtTotalAmnt.BackColor = Color.ForestGreen;
            txtTotalAmnt.BorderStyle = BorderStyle.FixedSingle;
            txtTotalAmnt.Font = new Font("Segoe UI", 60F, FontStyle.Bold);
            txtTotalAmnt.ForeColor = SystemColors.Window;
            txtTotalAmnt.Location = new Point(0, -1);
            txtTotalAmnt.Name = "txtTotalAmnt";
            txtTotalAmnt.ReadOnly = true;
            txtTotalAmnt.Size = new Size(820, 114);
            txtTotalAmnt.TabIndex = 6;
            txtTotalAmnt.Text = "0.00";
            // 
            // panel1
            // 
            panel1.BackColor = Color.OrangeRed;
            panel1.Controls.Add(labelSales);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(-6, 113);
            panel1.Name = "panel1";
            panel1.Size = new Size(825, 532);
            panel1.TabIndex = 7;
            // 
            // labelSales
            // 
            labelSales.AutoSize = true;
            labelSales.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelSales.ForeColor = SystemColors.ControlLight;
            labelSales.Location = new Point(387, 13);
            labelSales.Name = "labelSales";
            labelSales.Size = new Size(94, 21);
            labelSales.TabIndex = 1;
            labelSales.Text = "Sales Entry";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Snow;
            panel2.Controls.Add(dataGridView1);
            panel2.Location = new Point(8, 46);
            panel2.Name = "panel2";
            panel2.Size = new Size(820, 485);
            panel2.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { barcode, prod_name, quantity, price, amnt, disc, regprice });
            dataGridView1.Location = new Point(-2, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(817, 481);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            // 
            // barcode
            // 
            barcode.HeaderText = "Barcode";
            barcode.Name = "barcode";
            barcode.ReadOnly = true;
            barcode.Width = 150;
            // 
            // prod_name
            // 
            prod_name.HeaderText = "Item Description";
            prod_name.Name = "prod_name";
            prod_name.ReadOnly = true;
            prod_name.Resizable = DataGridViewTriState.False;
            prod_name.Width = 350;
            // 
            // quantity
            // 
            quantity.HeaderText = "QTY";
            quantity.Name = "quantity";
            quantity.ReadOnly = true;
            quantity.Width = 50;
            // 
            // price
            // 
            price.HeaderText = "SRP";
            price.Name = "price";
            price.ReadOnly = true;
            price.Width = 50;
            // 
            // amnt
            // 
            amnt.HeaderText = "Amount";
            amnt.Name = "amnt";
            amnt.ReadOnly = true;
            amnt.Width = 50;
            // 
            // disc
            // 
            disc.HeaderText = "Disc %";
            disc.Name = "disc";
            disc.ReadOnly = true;
            disc.Width = 50;
            // 
            // regprice
            // 
            regprice.HeaderText = "Reg. SRP";
            regprice.Name = "regprice";
            regprice.ReadOnly = true;
            regprice.Width = 50;
            // 
            // formPOS
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1124, 646);
            Controls.Add(panel1);
            Controls.Add(txtTotalAmnt);
            Controls.Add(pnlBottom);
            Controls.Add(panelBarcode);
            Name = "formPOS";
            Text = "Keys: F1 - Barcode, F3-Edit,F6-Cash OUT, F7 - Cash IN, F9-Reprint, F10-Suspend, F10-Suspend,F11-Recall,F12-SDisc.<ENTER>-Browse, /-Quantity";
            FormClosed += formPOS_FormClosed;
            Load += formPOS_Load;
            KeyDown += formPOS_KeyDown;
            panelBarcode.ResumeLayout(false);
            panelBarcode.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private Panel panel1;
        private Label labelSales;
        private Panel panel2;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn barcode;
        private DataGridViewTextBoxColumn prod_name;
        private DataGridViewTextBoxColumn quantity;
        private DataGridViewTextBoxColumn price;
        private DataGridViewTextBoxColumn amnt;
        private DataGridViewTextBoxColumn disc;
        private DataGridViewTextBoxColumn regprice;
        private Label labelBarcode;
        private Button btnRecall;
        private Button btnSuspend;
    }
}