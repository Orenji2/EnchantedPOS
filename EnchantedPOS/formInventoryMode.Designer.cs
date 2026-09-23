namespace EnchantedPOS
{
    partial class formInventoryMode
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
            panelInfo = new Panel();
            label2 = new Label();
            txtAltProdName = new TextBox();
            txtProdName = new TextBox();
            label1 = new Label();
            txtProdCode = new TextBox();
            panelBottomBar = new Panel();
            button5 = new Button();
            button4 = new Button();
            btnSave = new Button();
            btnEdit = new Button();
            button1 = new Button();
            txtBarcode = new TextBox();
            panel1 = new Panel();
            groupBox1 = new GroupBox();
            txtTotalStock = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            txtWHStock = new TextBox();
            txtStoreStock = new TextBox();
            groupAdjustment = new GroupBox();
            btnCancel = new Button();
            btnEnter = new Button();
            txtInventoryCount = new TextBox();
            label5 = new Label();
            groupBarcode = new GroupBox();
            label4 = new Label();
            cmbUM = new ComboBox();
            label3 = new Label();
            panelInfo.SuspendLayout();
            panelBottomBar.SuspendLayout();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupAdjustment.SuspendLayout();
            groupBarcode.SuspendLayout();
            SuspendLayout();
            // 
            // panelInfo
            // 
            panelInfo.Controls.Add(label2);
            panelInfo.Controls.Add(txtAltProdName);
            panelInfo.Controls.Add(txtProdName);
            panelInfo.Controls.Add(label1);
            panelInfo.Controls.Add(txtProdCode);
            panelInfo.Dock = DockStyle.Top;
            panelInfo.Location = new Point(0, 0);
            panelInfo.Name = "panelInfo";
            panelInfo.Size = new Size(897, 112);
            panelInfo.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(195, 11);
            label2.Name = "label2";
            label2.Size = new Size(107, 20);
            label2.TabIndex = 4;
            label2.Text = "Product Name:";
            // 
            // txtAltProdName
            // 
            txtAltProdName.Location = new Point(195, 67);
            txtAltProdName.Name = "txtAltProdName";
            txtAltProdName.ReadOnly = true;
            txtAltProdName.Size = new Size(623, 27);
            txtAltProdName.TabIndex = 3;
            // 
            // txtProdName
            // 
            txtProdName.Location = new Point(195, 34);
            txtProdName.Name = "txtProdName";
            txtProdName.ReadOnly = true;
            txtProdName.Size = new Size(623, 27);
            txtProdName.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 11);
            label1.Name = "label1";
            label1.Size = new Size(102, 20);
            label1.TabIndex = 1;
            label1.Text = "Product Code:";
            // 
            // txtProdCode
            // 
            txtProdCode.Location = new Point(12, 34);
            txtProdCode.Name = "txtProdCode";
            txtProdCode.ReadOnly = true;
            txtProdCode.Size = new Size(164, 27);
            txtProdCode.TabIndex = 5;
            // 
            // panelBottomBar
            // 
            panelBottomBar.Controls.Add(button5);
            panelBottomBar.Controls.Add(button4);
            panelBottomBar.Controls.Add(btnSave);
            panelBottomBar.Controls.Add(btnEdit);
            panelBottomBar.Controls.Add(button1);
            panelBottomBar.Dock = DockStyle.Bottom;
            panelBottomBar.Location = new Point(0, 213);
            panelBottomBar.Name = "panelBottomBar";
            panelBottomBar.Size = new Size(897, 62);
            panelBottomBar.TabIndex = 1;
            // 
            // button5
            // 
            button5.Location = new Point(697, 3);
            button5.Name = "button5";
            button5.Size = new Size(159, 56);
            button5.TabIndex = 4;
            button5.Text = "Exit";
            button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(532, 3);
            button4.Name = "button4";
            button4.Size = new Size(159, 56);
            button4.TabIndex = 3;
            button4.Text = "Cancel";
            button4.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(367, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(159, 56);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += button3_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(205, 3);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(159, 56);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // button1
            // 
            button1.Location = new Point(40, 3);
            button1.Name = "button1";
            button1.Size = new Size(159, 56);
            button1.TabIndex = 0;
            button1.Text = "Browse";
            button1.UseVisualStyleBackColor = true;
            // 
            // txtBarcode
            // 
            txtBarcode.Location = new Point(15, 41);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Size = new Size(164, 27);
            txtBarcode.TabIndex = 0;
            txtBarcode.KeyDown += txtBarcode_KeyDown;
            // 
            // panel1
            // 
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(groupAdjustment);
            panel1.Controls.Add(groupBarcode);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 112);
            panel1.Name = "panel1";
            panel1.Size = new Size(897, 101);
            panel1.TabIndex = 6;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtTotalStock);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtWHStock);
            groupBox1.Controls.Add(txtStoreStock);
            groupBox1.Location = new Point(721, 9);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(168, 84);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Stocks";
            // 
            // txtTotalStock
            // 
            txtTotalStock.Location = new Point(113, 48);
            txtTotalStock.Name = "txtTotalStock";
            txtTotalStock.ReadOnly = true;
            txtTotalStock.Size = new Size(44, 27);
            txtTotalStock.TabIndex = 11;
            txtTotalStock.Text = "0";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(114, 25);
            label8.Name = "label8";
            label8.Size = new Size(42, 20);
            label8.TabIndex = 10;
            label8.Text = "Total";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(63, 25);
            label7.Name = "label7";
            label7.Size = new Size(34, 20);
            label7.TabIndex = 9;
            label7.Text = "WH";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 25);
            label6.Name = "label6";
            label6.Size = new Size(44, 20);
            label6.TabIndex = 8;
            label6.Text = "Store";
            // 
            // txtWHStock
            // 
            txtWHStock.Location = new Point(63, 48);
            txtWHStock.Name = "txtWHStock";
            txtWHStock.ReadOnly = true;
            txtWHStock.Size = new Size(44, 27);
            txtWHStock.TabIndex = 1;
            txtWHStock.Text = "0";
            // 
            // txtStoreStock
            // 
            txtStoreStock.Location = new Point(6, 48);
            txtStoreStock.Name = "txtStoreStock";
            txtStoreStock.ReadOnly = true;
            txtStoreStock.Size = new Size(44, 27);
            txtStoreStock.TabIndex = 0;
            txtStoreStock.Text = "0";
            // 
            // groupAdjustment
            // 
            groupAdjustment.Controls.Add(btnCancel);
            groupAdjustment.Controls.Add(btnEnter);
            groupAdjustment.Controls.Add(txtInventoryCount);
            groupAdjustment.Controls.Add(label5);
            groupAdjustment.Location = new Point(318, 21);
            groupAdjustment.Name = "groupAdjustment";
            groupAdjustment.Size = new Size(397, 72);
            groupAdjustment.TabIndex = 7;
            groupAdjustment.TabStop = false;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(299, 19);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(89, 47);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnEnter
            // 
            btnEnter.Location = new Point(204, 19);
            btnEnter.Name = "btnEnter";
            btnEnter.Size = new Size(89, 47);
            btnEnter.TabIndex = 5;
            btnEnter.Text = "Enter";
            btnEnter.UseVisualStyleBackColor = true;
            btnEnter.Click += btnEnter_Click;
            // 
            // txtInventoryCount
            // 
            txtInventoryCount.Location = new Point(99, 29);
            txtInventoryCount.Name = "txtInventoryCount";
            txtInventoryCount.Size = new Size(99, 27);
            txtInventoryCount.TabIndex = 8;
            txtInventoryCount.Text = "0";
            txtInventoryCount.KeyDown += txtInventoryCount_KeyDown;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 23);
            label5.Name = "label5";
            label5.Size = new Size(87, 40);
            label5.TabIndex = 8;
            label5.Text = "INVENTORY\r\nCOUNT";
            // 
            // groupBarcode
            // 
            groupBarcode.Controls.Add(label4);
            groupBarcode.Controls.Add(cmbUM);
            groupBarcode.Controls.Add(label3);
            groupBarcode.Controls.Add(txtBarcode);
            groupBarcode.Location = new Point(9, 9);
            groupBarcode.Name = "groupBarcode";
            groupBarcode.Size = new Size(301, 88);
            groupBarcode.TabIndex = 6;
            groupBarcode.TabStop = false;
            groupBarcode.Text = "Barcode";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(196, 18);
            label4.Name = "label4";
            label4.Size = new Size(38, 20);
            label4.TabIndex = 7;
            label4.Text = "U/M";
            // 
            // cmbUM
            // 
            cmbUM.FormattingEnabled = true;
            cmbUM.Location = new Point(196, 41);
            cmbUM.Name = "cmbUM";
            cmbUM.Size = new Size(97, 28);
            cmbUM.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 18);
            label3.Name = "label3";
            label3.Size = new Size(67, 20);
            label3.TabIndex = 5;
            label3.Text = "Barcode:";
            // 
            // formInventoryMode
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(897, 275);
            Controls.Add(panel1);
            Controls.Add(panelBottomBar);
            Controls.Add(panelInfo);
            Name = "formInventoryMode";
            Text = "Adjust Inventory";
            Load += formInventoryMode_Load;
            panelInfo.ResumeLayout(false);
            panelInfo.PerformLayout();
            panelBottomBar.ResumeLayout(false);
            panel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupAdjustment.ResumeLayout(false);
            groupAdjustment.PerformLayout();
            groupBarcode.ResumeLayout(false);
            groupBarcode.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelInfo;
        private Label label2;
        private TextBox txtAltProdName;
        private TextBox txtProdName;
        private Label label1;
        private TextBox txtProdCode;
        private Panel panelBottomBar;
        private Button btnSave;
        private Button btnEdit;
        private Button button1;
        private Button button5;
        private Button button4;
        private TextBox txtBarcode;
        private Panel panel1;
        private GroupBox groupBox1;
        private TextBox txtStoreStock;
        private GroupBox groupAdjustment;
        private Button btnCancel;
        private Button btnEnter;
        private TextBox txtInventoryCount;
        private Label label5;
        private GroupBox groupBarcode;
        private Label label4;
        private ComboBox cmbUM;
        private Label label3;
        private Label label7;
        private Label label6;
        private TextBox txtWHStock;
        private TextBox txtTotalStock;
        private Label label8;
    }
}