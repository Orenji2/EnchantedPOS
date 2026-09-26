namespace EnchantedPOS
{
    partial class formProductType
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
            panel1 = new Panel();
            btnExit = new Button();
            panel2 = new Panel();
            dgvProductType = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductType).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnExit);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 341);
            panel1.Name = "panel1";
            panel1.Size = new Size(391, 75);
            panel1.TabIndex = 0;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(267, 9);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(112, 55);
            btnExit.TabIndex = 0;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvProductType);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(391, 341);
            panel2.TabIndex = 1;
            // 
            // dgvProductType
            // 
            dgvProductType.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductType.Dock = DockStyle.Fill;
            dgvProductType.Location = new Point(0, 0);
            dgvProductType.Name = "dgvProductType";
            dgvProductType.RowHeadersWidth = 51;
            dgvProductType.Size = new Size(391, 341);
            dgvProductType.TabIndex = 0;
            // 
            // formProductType
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(391, 416);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "formProductType";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Product Type";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProductType).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnExit;
        private Panel panel2;
        private DataGridView dgvProductType;
    }
}