namespace FinanceApp.Forms
{
    partial class LoanForm
    {
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.DataGridView dgvLoans;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnAddLoan;
        private System.Windows.Forms.Button btnSaveLoan;
        private System.Windows.Forms.Button btnDeleteLoan;

        private void InitializeComponent()
        {
            this.dgvLoans = new System.Windows.Forms.DataGridView();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnAddLoan = new System.Windows.Forms.Button();
            this.btnSaveLoan = new System.Windows.Forms.Button();
            this.btnDeleteLoan = new System.Windows.Forms.Button();

            // dgvLoans
            this.dgvLoans.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvLoans.Height = 300;
            this.dgvLoans.AllowUserToAddRows = false;
            this.dgvLoans.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            // panelButtons
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Height = 40;
            this.panelButtons.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.btnDeleteLoan,
                this.btnSaveLoan,
                this.btnAddLoan
            });

            // btnAddLoan
            this.btnAddLoan.Text = "Agregar";
            this.btnAddLoan.Dock = System.Windows.Forms.DockStyle.Left;

            // btnSaveLoan
            this.btnSaveLoan.Text = "Guardar";
            this.btnSaveLoan.Dock = System.Windows.Forms.DockStyle.Left;

            // btnDeleteLoan
            this.btnDeleteLoan.Text = "Eliminar";
            this.btnDeleteLoan.Dock = System.Windows.Forms.DockStyle.Left;

            // LoanForm
            this.ClientSize = new System.Drawing.Size(600, 350);
            this.Controls.Add(this.dgvLoans);
            this.Controls.Add(this.panelButtons);
            this.Text = "Préstamos";
        }
    }
}
