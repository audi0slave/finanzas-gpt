namespace FinanceApp.Forms
{
    partial class TransactionForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.ComboBox cbAccount;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.ComboBox cbSubCategory;
        private System.Windows.Forms.ComboBox cbCreditCard;
        private System.Windows.Forms.ComboBox cbLoan;
        private System.Windows.Forms.NumericUpDown nudTotal;
        private System.Windows.Forms.NumericUpDown nudPaid;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblPaid;
        private System.Windows.Forms.Label lblRate;
        private System.Windows.Forms.DateTimePicker dtpRateDate;
        private System.Windows.Forms.Button btnAddTransaction;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Button btnDeleteTransaction;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgv = new System.Windows.Forms.DataGridView();
            dtpDate = new System.Windows.Forms.DateTimePicker();
            txtDescription = new System.Windows.Forms.TextBox();
            txtAmount = new System.Windows.Forms.TextBox();
            cbType = new System.Windows.Forms.ComboBox();
            cbAccount = new System.Windows.Forms.ComboBox();
            cbCategory = new System.Windows.Forms.ComboBox();
            cbSubCategory = new System.Windows.Forms.ComboBox();
            cbCreditCard = new System.Windows.Forms.ComboBox();
            cbLoan = new System.Windows.Forms.ComboBox();
            nudTotal = new System.Windows.Forms.NumericUpDown();
            nudPaid = new System.Windows.Forms.NumericUpDown();
            lblTotal = new System.Windows.Forms.Label();
            lblPaid = new System.Windows.Forms.Label();
            lblRate = new System.Windows.Forms.Label();
            dtpRateDate = new System.Windows.Forms.DateTimePicker();
            btnAddTransaction = new System.Windows.Forms.Button();
            btnSaveChanges = new System.Windows.Forms.Button();
            btnDeleteTransaction = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudTotal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPaid).BeginInit();
            SuspendLayout();
            // 
            // dgv
            // 
            dgv.Dock = System.Windows.Forms.DockStyle.Top;
            dgv.Location = new System.Drawing.Point(0, 0);
            dgv.Name = "dgv";
            dgv.Size = new System.Drawing.Size(800, 250);
            dgv.TabIndex = 18;
            // 
            // dtpDate
            // 
            dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpDate.Location = new System.Drawing.Point(0, 275);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new System.Drawing.Size(800, 23);
            dtpDate.TabIndex = 17;
            // 
            // txtDescription
            // 
            txtDescription.Location = new System.Drawing.Point(0, 304);
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "Descripción...";
            txtDescription.Size = new System.Drawing.Size(800, 23);
            txtDescription.TabIndex = 16;
            // 
            // txtAmount
            // 
            txtAmount.Location = new System.Drawing.Point(0, 333);
            txtAmount.Name = "txtAmount";
            txtAmount.PlaceholderText = "Monto";
            txtAmount.Size = new System.Drawing.Size(800, 23);
            txtAmount.TabIndex = 15;
            // 
            // cbType
            // 
            cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbType.Location = new System.Drawing.Point(36, 366);
            cbType.Name = "cbType";
            cbType.Size = new System.Drawing.Size(122, 23);
            cbType.TabIndex = 14;
            // 
            // cbAccount
            // 
            cbAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbAccount.Location = new System.Drawing.Point(215, 366);
            cbAccount.Name = "cbAccount";
            cbAccount.Size = new System.Drawing.Size(122, 23);
            cbAccount.TabIndex = 13;
            // 
            // cbCategory
            // 
            cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbCategory.Location = new System.Drawing.Point(407, 366);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new System.Drawing.Size(122, 23);
            cbCategory.TabIndex = 12;
            // 
            // cbSubCategory
            // 
            cbSubCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbSubCategory.Location = new System.Drawing.Point(624, 366);
            cbSubCategory.Name = "cbSubCategory";
            cbSubCategory.Size = new System.Drawing.Size(164, 23);
            cbSubCategory.TabIndex = 11;
            // 
            // cbCreditCard
            // 
            cbCreditCard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbCreditCard.Location = new System.Drawing.Point(0, 430);
            cbCreditCard.Name = "cbCreditCard";
            cbCreditCard.Size = new System.Drawing.Size(800, 23);
            cbCreditCard.TabIndex = 10;
            // 
            // cbLoan
            // 
            cbLoan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbLoan.Location = new System.Drawing.Point(0, 474);
            cbLoan.Name = "cbLoan";
            cbLoan.Size = new System.Drawing.Size(800, 23);
            cbLoan.TabIndex = 9;
            // 
            // nudTotal
            // 
            nudTotal.Location = new System.Drawing.Point(0, 523);
            nudTotal.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudTotal.Name = "nudTotal";
            nudTotal.Size = new System.Drawing.Size(800, 23);
            nudTotal.TabIndex = 7;
            nudTotal.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // nudPaid
            // 
            nudPaid.Location = new System.Drawing.Point(0, 569);
            nudPaid.Name = "nudPaid";
            nudPaid.Size = new System.Drawing.Size(800, 23);
            nudPaid.TabIndex = 5;
            // 
            // lblTotal
            // 
            lblTotal.Location = new System.Drawing.Point(0, 500);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new System.Drawing.Size(800, 23);
            lblTotal.TabIndex = 8;
            lblTotal.Text = "Total cuotas";
            // 
            // lblPaid
            // 
            lblPaid.Location = new System.Drawing.Point(0, 546);
            lblPaid.Name = "lblPaid";
            lblPaid.Size = new System.Drawing.Size(800, 23);
            lblPaid.TabIndex = 6;
            lblPaid.Text = "Cuotas pagadas";
            // 
            // lblRate
            // 
            lblRate.Location = new System.Drawing.Point(0, 592);
            lblRate.Name = "lblRate";
            lblRate.Size = new System.Drawing.Size(800, 23);
            lblRate.TabIndex = 4;
            lblRate.Text = "Fecha cotización";
            // 
            // dtpRateDate
            // 
            dtpRateDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpRateDate.Location = new System.Drawing.Point(0, 615);
            dtpRateDate.Name = "dtpRateDate";
            dtpRateDate.Size = new System.Drawing.Size(800, 23);
            dtpRateDate.TabIndex = 3;
            // 
            // btnAddTransaction
            // 
            btnAddTransaction.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnAddTransaction.Location = new System.Drawing.Point(0, 651);
            btnAddTransaction.Name = "btnAddTransaction";
            btnAddTransaction.Size = new System.Drawing.Size(95, 46);
            btnAddTransaction.TabIndex = 2;
            btnAddTransaction.Text = "Agregar transacción";
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnSaveChanges.Location = new System.Drawing.Point(101, 651);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new System.Drawing.Size(87, 46);
            btnSaveChanges.TabIndex = 1;
            btnSaveChanges.Text = "Guardar cambios";
            // 
            // btnDeleteTransaction
            // 
            btnDeleteTransaction.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnDeleteTransaction.Location = new System.Drawing.Point(194, 651);
            btnDeleteTransaction.Name = "btnDeleteTransaction";
            btnDeleteTransaction.Size = new System.Drawing.Size(99, 46);
            btnDeleteTransaction.TabIndex = 0;
            btnDeleteTransaction.Text = "Eliminar transacción";
            // 
            // label1
            // 
            label1.Location = new System.Drawing.Point(0, 253);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(800, 19);
            label1.TabIndex = 19;
            label1.Text = "Fecha";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(0, 369);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(30, 15);
            label2.TabIndex = 20;
            label2.Text = "Tipo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(164, 369);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(45, 15);
            label3.TabIndex = 21;
            label3.Text = "Cuenta";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(343, 369);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(58, 15);
            label4.TabIndex = 22;
            label4.Text = "Categoria";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(535, 369);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(83, 15);
            label5.TabIndex = 23;
            label5.Text = "Sub-Categoria";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(0, 412);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(97, 15);
            label6.TabIndex = 24;
            label6.Text = "Tarjeta de credito";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(0, 456);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(57, 15);
            label7.TabIndex = 25;
            label7.Text = "Préstamo";
            // 
            // TransactionForm
            // 
            ClientSize = new System.Drawing.Size(800, 700);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnDeleteTransaction);
            Controls.Add(btnSaveChanges);
            Controls.Add(btnAddTransaction);
            Controls.Add(dtpRateDate);
            Controls.Add(lblRate);
            Controls.Add(nudPaid);
            Controls.Add(lblPaid);
            Controls.Add(nudTotal);
            Controls.Add(lblTotal);
            Controls.Add(cbLoan);
            Controls.Add(cbCreditCard);
            Controls.Add(cbSubCategory);
            Controls.Add(cbCategory);
            Controls.Add(cbAccount);
            Controls.Add(cbType);
            Controls.Add(txtAmount);
            Controls.Add(txtDescription);
            Controls.Add(dtpDate);
            Controls.Add(dgv);
            Name = "TransactionForm";
            Text = "Transacciones";
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudTotal).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPaid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}
