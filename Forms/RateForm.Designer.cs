using System.Windows.Forms;

namespace FinanceApp.Forms
{
    partial class RateForm
    {
        private System.ComponentModel.IContainer components;
        private DataGridView dgvRates; private Panel panelButtons; private Button btnAddRate; private Button btnSaveRate; private Button btnDeleteRate;
        private void InitializeComponent()
        {
            dgvRates = new DataGridView(); panelButtons = new Panel(); btnAddRate = new Button(); btnSaveRate = new Button(); btnDeleteRate = new Button();
            panelButtons.Controls.AddRange(new Control[] { btnDeleteRate, btnSaveRate, btnAddRate });
            dgvRates.Dock = DockStyle.Top; dgvRates.Height = 300; dgvRates.AllowUserToAddRows = false; dgvRates.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            panelButtons.Dock = DockStyle.Bottom; panelButtons.Height = 40;
            btnAddRate.Text = "Agregar"; btnAddRate.Dock = DockStyle.Left;
            btnSaveRate.Text = "Guardar"; btnSaveRate.Dock = DockStyle.Left;
            btnDeleteRate.Text = "Eliminar"; btnDeleteRate.Dock = DockStyle.Left;
            this.ClientSize = new System.Drawing.Size(600, 350);
            this.Controls.Add(dgvRates); this.Controls.Add(panelButtons); this.Text = "Cotizaciones";
        }
    }
}
