namespace EnchantedPOS
{
    partial class formSaveTransaction
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
            panelTransactions = new Panel();
            panelPoints = new Panel();
            btnTotalPoints = new Button();
            txtTotalPoints = new TextBox();
            labelTotalPoints = new Label();
            btnAddTotalPoints = new Button();
            panelPayment = new Panel();
            groupPayment = new GroupBox();
            btnPaymentOK = new Button();
            btnDiscount = new Button();
            btnReceivePayment = new Button();
            labelChange = new Label();
            labelReceived = new Label();
            labelDiscPercent = new Label();
            txtTotalDisc = new TextBox();
            labelNet = new Label();
            labelDiscount = new Label();
            txtChange = new TextBox();
            txtReceivedAmount = new TextBox();
            txtNetAmount = new TextBox();
            txtDiscount = new TextBox();
            txtSales = new TextBox();
            labelAmount = new Label();
            panelCheck = new Panel();
            groupChecks = new GroupBox();
            labelGiftCertAmnt = new Label();
            labelCheckAmnt = new Label();
            txtGiftCert = new TextBox();
            txtCheck = new TextBox();
            panelPaymentMethods = new Panel();
            btnCancel = new Button();
            btnSoA = new Button();
            btnGC = new Button();
            btnCash = new Button();
            btnCheck = new Button();
            btnCC = new Button();
            panelTransactions.SuspendLayout();
            panelPoints.SuspendLayout();
            panelPayment.SuspendLayout();
            groupPayment.SuspendLayout();
            panelCheck.SuspendLayout();
            groupChecks.SuspendLayout();
            panelPaymentMethods.SuspendLayout();
            SuspendLayout();
            // 
            // panelTransactions
            // 
            panelTransactions.Controls.Add(panelPoints);
            panelTransactions.Controls.Add(panelPayment);
            panelTransactions.Controls.Add(panelPaymentMethods);
            panelTransactions.Dock = DockStyle.Fill;
            panelTransactions.Location = new Point(0, 0);
            panelTransactions.Name = "panelTransactions";
            panelTransactions.Size = new Size(998, 556);
            panelTransactions.TabIndex = 0;
            // 
            // panelPoints
            // 
            panelPoints.Controls.Add(btnTotalPoints);
            panelPoints.Controls.Add(txtTotalPoints);
            panelPoints.Controls.Add(labelTotalPoints);
            panelPoints.Controls.Add(btnAddTotalPoints);
            panelPoints.Dock = DockStyle.Right;
            panelPoints.Location = new Point(820, 0);
            panelPoints.Name = "panelPoints";
            panelPoints.Size = new Size(178, 556);
            panelPoints.TabIndex = 5;
            // 
            // btnTotalPoints
            // 
            btnTotalPoints.Location = new Point(13, 198);
            btnTotalPoints.Name = "btnTotalPoints";
            btnTotalPoints.Size = new Size(156, 91);
            btnTotalPoints.TabIndex = 16;
            btnTotalPoints.Text = "Verify Member's\r\nRemaining Points";
            btnTotalPoints.UseVisualStyleBackColor = true;
            // 
            // txtTotalPoints
            // 
            txtTotalPoints.Enabled = false;
            txtTotalPoints.Font = new Font("Segoe UI", 14F);
            txtTotalPoints.Location = new Point(28, 146);
            txtTotalPoints.Name = "txtTotalPoints";
            txtTotalPoints.Size = new Size(138, 39);
            txtTotalPoints.TabIndex = 15;
            // 
            // labelTotalPoints
            // 
            labelTotalPoints.AutoSize = true;
            labelTotalPoints.Location = new Point(52, 123);
            labelTotalPoints.Name = "labelTotalPoints";
            labelTotalPoints.Size = new Size(85, 20);
            labelTotalPoints.TabIndex = 4;
            labelTotalPoints.Text = "Total Points";
            // 
            // btnAddTotalPoints
            // 
            btnAddTotalPoints.Location = new Point(13, 16);
            btnAddTotalPoints.Name = "btnAddTotalPoints";
            btnAddTotalPoints.Size = new Size(156, 91);
            btnAddTotalPoints.TabIndex = 0;
            btnAddTotalPoints.Text = "Add Total Points to\r\nInvoice Discount";
            btnAddTotalPoints.UseVisualStyleBackColor = true;
            // 
            // panelPayment
            // 
            panelPayment.Controls.Add(groupPayment);
            panelPayment.Location = new Point(191, 12);
            panelPayment.Name = "panelPayment";
            panelPayment.Size = new Size(619, 529);
            panelPayment.TabIndex = 4;
            panelPayment.Visible = false;
            // 
            // groupPayment
            // 
            groupPayment.Controls.Add(btnPaymentOK);
            groupPayment.Controls.Add(btnDiscount);
            groupPayment.Controls.Add(btnReceivePayment);
            groupPayment.Controls.Add(labelChange);
            groupPayment.Controls.Add(labelReceived);
            groupPayment.Controls.Add(labelDiscPercent);
            groupPayment.Controls.Add(txtTotalDisc);
            groupPayment.Controls.Add(labelNet);
            groupPayment.Controls.Add(labelDiscount);
            groupPayment.Controls.Add(txtChange);
            groupPayment.Controls.Add(txtReceivedAmount);
            groupPayment.Controls.Add(txtNetAmount);
            groupPayment.Controls.Add(txtDiscount);
            groupPayment.Controls.Add(txtSales);
            groupPayment.Controls.Add(labelAmount);
            groupPayment.Controls.Add(panelCheck);
            groupPayment.Location = new Point(11, 3);
            groupPayment.Name = "groupPayment";
            groupPayment.Size = new Size(608, 506);
            groupPayment.TabIndex = 1;
            groupPayment.TabStop = false;
            groupPayment.Text = "Cash Payment";
            // 
            // btnPaymentOK
            // 
            btnPaymentOK.Location = new Point(469, 293);
            btnPaymentOK.Name = "btnPaymentOK";
            btnPaymentOK.Size = new Size(122, 42);
            btnPaymentOK.TabIndex = 14;
            btnPaymentOK.Text = "OK";
            btnPaymentOK.UseVisualStyleBackColor = true;
            btnPaymentOK.Click += btnPaymentOK_Click;
            // 
            // btnDiscount
            // 
            btnDiscount.Location = new Point(469, 201);
            btnDiscount.Name = "btnDiscount";
            btnDiscount.Size = new Size(122, 58);
            btnDiscount.TabIndex = 13;
            btnDiscount.Text = "Invoice\r\nDiscount";
            btnDiscount.UseVisualStyleBackColor = true;
            // 
            // btnReceivePayment
            // 
            btnReceivePayment.Location = new Point(469, 143);
            btnReceivePayment.Name = "btnReceivePayment";
            btnReceivePayment.Size = new Size(122, 50);
            btnReceivePayment.TabIndex = 6;
            btnReceivePayment.Text = "Receive\r\nPayment";
            btnReceivePayment.UseVisualStyleBackColor = true;
            btnReceivePayment.Click += btnReceivePayment_Click;
            // 
            // labelChange
            // 
            labelChange.AutoSize = true;
            labelChange.Font = new Font("Segoe UI", 11F);
            labelChange.Location = new Point(24, 348);
            labelChange.Name = "labelChange";
            labelChange.Size = new Size(149, 25);
            labelChange.TabIndex = 12;
            labelChange.Text = "Change Amount";
            // 
            // labelReceived
            // 
            labelReceived.AutoSize = true;
            labelReceived.Font = new Font("Segoe UI", 11F);
            labelReceived.Location = new Point(15, 303);
            labelReceived.Name = "labelReceived";
            labelReceived.Size = new Size(158, 25);
            labelReceived.TabIndex = 11;
            labelReceived.Text = "Received Amount";
            // 
            // labelDiscPercent
            // 
            labelDiscPercent.AutoSize = true;
            labelDiscPercent.Font = new Font("Segoe UI", 14F);
            labelDiscPercent.Location = new Point(227, 211);
            labelDiscPercent.Name = "labelDiscPercent";
            labelDiscPercent.Size = new Size(34, 32);
            labelDiscPercent.TabIndex = 10;
            labelDiscPercent.Text = "%";
            // 
            // txtTotalDisc
            // 
            txtTotalDisc.Enabled = false;
            txtTotalDisc.Font = new Font("Segoe UI", 14F);
            txtTotalDisc.Location = new Point(267, 208);
            txtTotalDisc.Name = "txtTotalDisc";
            txtTotalDisc.Size = new Size(196, 39);
            txtTotalDisc.TabIndex = 9;
            // 
            // labelNet
            // 
            labelNet.AutoSize = true;
            labelNet.Font = new Font("Segoe UI", 11F);
            labelNet.Location = new Point(59, 258);
            labelNet.Name = "labelNet";
            labelNet.Size = new Size(114, 25);
            labelNet.TabIndex = 8;
            labelNet.Text = "Net Amount";
            // 
            // labelDiscount
            // 
            labelDiscount.AutoSize = true;
            labelDiscount.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelDiscount.Location = new Point(40, 201);
            labelDiscount.Name = "labelDiscount";
            labelDiscount.Size = new Size(127, 50);
            labelDiscount.TabIndex = 7;
            labelDiscount.Text = "Senior/\r\nPWD Discount";
            // 
            // txtChange
            // 
            txtChange.Enabled = false;
            txtChange.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtChange.Location = new Point(179, 340);
            txtChange.Name = "txtChange";
            txtChange.Size = new Size(284, 38);
            txtChange.TabIndex = 6;
            // 
            // txtReceivedAmount
            // 
            txtReceivedAmount.Font = new Font("Segoe UI", 14F);
            txtReceivedAmount.Location = new Point(179, 295);
            txtReceivedAmount.Name = "txtReceivedAmount";
            txtReceivedAmount.Size = new Size(284, 39);
            txtReceivedAmount.TabIndex = 5;
            txtReceivedAmount.KeyDown += txtReceived_KeyDown;
            // 
            // txtNetAmount
            // 
            txtNetAmount.Enabled = false;
            txtNetAmount.Font = new Font("Segoe UI", 14F);
            txtNetAmount.Location = new Point(179, 250);
            txtNetAmount.Name = "txtNetAmount";
            txtNetAmount.Size = new Size(284, 39);
            txtNetAmount.TabIndex = 4;
            // 
            // txtDiscount
            // 
            txtDiscount.Font = new Font("Segoe UI", 14F);
            txtDiscount.Location = new Point(179, 208);
            txtDiscount.Name = "txtDiscount";
            txtDiscount.Size = new Size(42, 39);
            txtDiscount.TabIndex = 3;
            // 
            // txtSales
            // 
            txtSales.Enabled = false;
            txtSales.Font = new Font("Segoe UI", 14F);
            txtSales.Location = new Point(179, 151);
            txtSales.Name = "txtSales";
            txtSales.Size = new Size(284, 39);
            txtSales.TabIndex = 2;
            // 
            // labelAmount
            // 
            labelAmount.AutoSize = true;
            labelAmount.Font = new Font("Segoe UI", 11F);
            labelAmount.Location = new Point(46, 159);
            labelAmount.Name = "labelAmount";
            labelAmount.Size = new Size(127, 25);
            labelAmount.TabIndex = 1;
            labelAmount.Text = "Sales Amount";
            // 
            // panelCheck
            // 
            panelCheck.Controls.Add(groupChecks);
            panelCheck.Location = new Point(6, 26);
            panelCheck.Name = "panelCheck";
            panelCheck.Size = new Size(573, 108);
            panelCheck.TabIndex = 0;
            // 
            // groupChecks
            // 
            groupChecks.Controls.Add(labelGiftCertAmnt);
            groupChecks.Controls.Add(labelCheckAmnt);
            groupChecks.Controls.Add(txtGiftCert);
            groupChecks.Controls.Add(txtCheck);
            groupChecks.Location = new Point(7, 8);
            groupChecks.Name = "groupChecks";
            groupChecks.Size = new Size(558, 94);
            groupChecks.TabIndex = 0;
            groupChecks.TabStop = false;
            groupChecks.Text = "Total Amount of Checks and Gift Certs.";
            // 
            // labelGiftCertAmnt
            // 
            labelGiftCertAmnt.AutoSize = true;
            labelGiftCertAmnt.Location = new Point(45, 63);
            labelGiftCertAmnt.Name = "labelGiftCertAmnt";
            labelGiftCertAmnt.Size = new Size(124, 20);
            labelGiftCertAmnt.TabIndex = 3;
            labelGiftCertAmnt.Text = "Gift Cert. Amount";
            // 
            // labelCheckAmnt
            // 
            labelCheckAmnt.AutoSize = true;
            labelCheckAmnt.Location = new Point(55, 30);
            labelCheckAmnt.Name = "labelCheckAmnt";
            labelCheckAmnt.Size = new Size(105, 20);
            labelCheckAmnt.TabIndex = 2;
            labelCheckAmnt.Text = "Check Amount";
            // 
            // txtGiftCert
            // 
            txtGiftCert.Location = new Point(175, 60);
            txtGiftCert.Name = "txtGiftCert";
            txtGiftCert.Size = new Size(275, 27);
            txtGiftCert.TabIndex = 1;
            // 
            // txtCheck
            // 
            txtCheck.Location = new Point(175, 27);
            txtCheck.Name = "txtCheck";
            txtCheck.Size = new Size(275, 27);
            txtCheck.TabIndex = 0;
            // 
            // panelPaymentMethods
            // 
            panelPaymentMethods.Controls.Add(btnCancel);
            panelPaymentMethods.Controls.Add(btnSoA);
            panelPaymentMethods.Controls.Add(btnGC);
            panelPaymentMethods.Controls.Add(btnCash);
            panelPaymentMethods.Controls.Add(btnCheck);
            panelPaymentMethods.Controls.Add(btnCC);
            panelPaymentMethods.Dock = DockStyle.Left;
            panelPaymentMethods.Location = new Point(0, 0);
            panelPaymentMethods.Name = "panelPaymentMethods";
            panelPaymentMethods.Size = new Size(185, 556);
            panelPaymentMethods.TabIndex = 3;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(3, 368);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(177, 67);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel Payment";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSoA
            // 
            btnSoA.Location = new Point(3, 295);
            btnSoA.Name = "btnSoA";
            btnSoA.Size = new Size(177, 67);
            btnSoA.TabIndex = 4;
            btnSoA.Text = "Sales on Account";
            btnSoA.UseVisualStyleBackColor = true;
            // 
            // btnGC
            // 
            btnGC.Location = new Point(3, 222);
            btnGC.Name = "btnGC";
            btnGC.Size = new Size(177, 67);
            btnGC.TabIndex = 3;
            btnGC.Text = "Gift Certificate";
            btnGC.UseVisualStyleBackColor = true;
            // 
            // btnCash
            // 
            btnCash.Location = new Point(3, 3);
            btnCash.Name = "btnCash";
            btnCash.Size = new Size(177, 67);
            btnCash.TabIndex = 0;
            btnCash.Text = "Cash";
            btnCash.UseVisualStyleBackColor = true;
            btnCash.Click += btnCash_Click;
            // 
            // btnCheck
            // 
            btnCheck.Location = new Point(3, 149);
            btnCheck.Name = "btnCheck";
            btnCheck.Size = new Size(177, 67);
            btnCheck.TabIndex = 2;
            btnCheck.Text = "Check";
            btnCheck.UseVisualStyleBackColor = true;
            // 
            // btnCC
            // 
            btnCC.Location = new Point(3, 76);
            btnCC.Name = "btnCC";
            btnCC.Size = new Size(177, 67);
            btnCC.TabIndex = 1;
            btnCC.Text = "Credit Card";
            btnCC.UseVisualStyleBackColor = true;
            // 
            // formSaveTransaction
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(998, 556);
            Controls.Add(panelTransactions);
            Name = "formSaveTransaction";
            Text = "Payment";
            Load += formSaveTransaction_Load;
            panelTransactions.ResumeLayout(false);
            panelPoints.ResumeLayout(false);
            panelPoints.PerformLayout();
            panelPayment.ResumeLayout(false);
            groupPayment.ResumeLayout(false);
            groupPayment.PerformLayout();
            panelCheck.ResumeLayout(false);
            groupChecks.ResumeLayout(false);
            groupChecks.PerformLayout();
            panelPaymentMethods.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTransactions;
        private Panel panelPaymentMethods;
        private Button btnCancel;
        private Button btnSoA;
        private Button btnGC;
        private Button btnCash;
        private Button btnCheck;
        private Button btnCC;
        private Panel panelPoints;
        private Panel panelPayment;
        private GroupBox groupPayment;
        private Panel panelCheck;
        private TextBox txtChange;
        private TextBox txtReceivedAmount;
        private TextBox txtNetAmount;
        private TextBox txtDiscount;
        private TextBox txtSales;
        private Label labelAmount;
        private GroupBox groupChecks;
        private Label labelDiscPercent;
        private TextBox txtTotalDisc;
        private Label labelNet;
        private Label labelDiscount;
        private Button btnPaymentOK;
        private Button btnDiscount;
        private Button btnReceivePayment;
        private Label labelChange;
        private Label labelReceived;
        private Button btnAddTotalPoints;
        private TextBox txtGiftCert;
        private TextBox txtCheck;
        private Button btnTotalPoints;
        private TextBox txtTotalPoints;
        private Label labelTotalPoints;
        private Label labelGiftCertAmnt;
        private Label labelCheckAmnt;
    }
}