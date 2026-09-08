namespace EnchantedPOS
{
    partial class ucDashboard
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
            lblTotalCost = new Label();
            lblTotalRetail = new Label();
            lblLowStock = new Label();
            lblTotalProducts = new Label();
            lblTxtTotalItems = new Label();
            lblTextLowStocks = new Label();
            lblTextTotalRetail = new Label();
            lblTextTotalCost = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblTotalCost
            // 
            lblTotalCost.AutoSize = true;
            lblTotalCost.Location = new Point(279, 125);
            lblTotalCost.Name = "lblTotalCost";
            lblTotalCost.Size = new Size(50, 20);
            lblTotalCost.TabIndex = 0;
            lblTotalCost.Text = "label1";
            // 
            // lblTotalRetail
            // 
            lblTotalRetail.AutoSize = true;
            lblTotalRetail.Location = new Point(279, 183);
            lblTotalRetail.Name = "lblTotalRetail";
            lblTotalRetail.Size = new Size(50, 20);
            lblTotalRetail.TabIndex = 1;
            lblTotalRetail.Text = "label2";
            // 
            // lblLowStock
            // 
            lblLowStock.AutoSize = true;
            lblLowStock.Location = new Point(279, 231);
            lblLowStock.Name = "lblLowStock";
            lblLowStock.Size = new Size(50, 20);
            lblLowStock.TabIndex = 2;
            lblLowStock.Text = "label3";
            // 
            // lblTotalProducts
            // 
            lblTotalProducts.AutoSize = true;
            lblTotalProducts.Location = new Point(279, 277);
            lblTotalProducts.Name = "lblTotalProducts";
            lblTotalProducts.Size = new Size(50, 20);
            lblTotalProducts.TabIndex = 3;
            lblTotalProducts.Text = "label3";
            // 
            // lblTxtTotalItems
            // 
            lblTxtTotalItems.AutoSize = true;
            lblTxtTotalItems.Location = new Point(91, 277);
            lblTxtTotalItems.Name = "lblTxtTotalItems";
            lblTxtTotalItems.Size = new Size(85, 20);
            lblTxtTotalItems.TabIndex = 7;
            lblTxtTotalItems.Text = "Total Items:";
            // 
            // lblTextLowStocks
            // 
            lblTextLowStocks.AutoSize = true;
            lblTextLowStocks.Location = new Point(91, 231);
            lblTextLowStocks.Name = "lblTextLowStocks";
            lblTextLowStocks.Size = new Size(85, 20);
            lblTextLowStocks.TabIndex = 6;
            lblTextLowStocks.Text = "Low Stocks:";
            // 
            // lblTextTotalRetail
            // 
            lblTextTotalRetail.AutoSize = true;
            lblTextTotalRetail.Location = new Point(93, 183);
            lblTextTotalRetail.Name = "lblTextTotalRetail";
            lblTextTotalRetail.Size = new Size(127, 20);
            lblTextTotalRetail.TabIndex = 5;
            lblTextTotalRetail.Text = "Total Stock Retail:";
            // 
            // lblTextTotalCost
            // 
            lblTextTotalCost.AutoSize = true;
            lblTextTotalCost.Location = new Point(91, 125);
            lblTextTotalCost.Name = "lblTextTotalCost";
            lblTextTotalCost.Size = new Size(118, 20);
            lblTextTotalCost.TabIndex = 4;
            lblTextTotalCost.Text = "Total Stock Cost:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(93, 66);
            label1.Name = "label1";
            label1.Size = new Size(180, 28);
            label1.TabIndex = 8;
            label1.Text = "Inventory Report:";
            // 
            // ucDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(lblTxtTotalItems);
            Controls.Add(lblTextLowStocks);
            Controls.Add(lblTextTotalRetail);
            Controls.Add(lblTextTotalCost);
            Controls.Add(lblTotalProducts);
            Controls.Add(lblLowStock);
            Controls.Add(lblTotalRetail);
            Controls.Add(lblTotalCost);
            Name = "ucDashboard";
            Size = new Size(604, 461);
            Load += ucDashboard_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTotalCost;
        private Label lblTotalRetail;
        private Label lblLowStock;
        private Label lblTotalProducts;
        private Label lblTxtTotalItems;
        private Label lblTextLowStocks;
        private Label lblTextTotalRetail;
        private Label lblTextTotalCost;
        private Label label1;
    }
}
