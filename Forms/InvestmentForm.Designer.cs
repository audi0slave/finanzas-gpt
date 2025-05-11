using System.Windows.Forms;

namespace FinanceApp.Forms
{
    partial class InvestmentForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvInvestments;
        private Button btnAddInvestment;
        private Button btnSaveInvestment;
        private Button btnDeleteInvestment;
        private Panel panelButtons;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvInvestments = new DataGridView();
            this.panelButtons = new Panel();
            this.btnAddInvestment = new Button();
            this.btnSaveInvestment = new Button();
            this.btnDeleteInvestment = new Button();

            // dgvInvestments
            this.dgvInvestments.Dock = DockStyle.Top;
            this.dgvInvestments.Height = 300;
            this.dgvInvestments.AllowUserToAddRows = false;
            this.dgvInvestments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // panelButtons
            this.panelButtons.Dock = DockStyle.Bottom;
            this.panelButtons.Height = 40;
            this.panelButtons.Controls.AddRange(new Control[] { btnDeleteInvestment, btnSaveInvestment, btnAddInvestment });

            // btnAddInvestment
            this.btnAddInvestment.Text = "Agregar";
            this.btnAddInvestment.Dock = DockStyle.Left;

            // btnSaveInvestment
            this.btnSaveInvestment.Text = "Guardar";
            this.btnSaveInvestment.Dock = DockStyle.Left;

            // btnDeleteInvestment
            this.btnDeleteInvestment.Text = "Eliminar";
            this.btnDeleteInvestment.Dock = DockStyle.Left;

            // InvestmentForm
            this.ClientSize = new System.Drawing.Size(600, 350);
            this.Controls.Add(this.dgvInvestments);
            this.Controls.Add(this.panelButtons);
            this.Text = "Inversiones";
        }
    }
}
