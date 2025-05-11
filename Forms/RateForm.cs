using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using FinanceApp.Data;
using FinanceApp.Data.Models;

namespace FinanceApp.Forms
{
    public partial class RateForm : Form
    {
        private readonly FinanceContext _ctx;
        private readonly BindingSource _bsRates;

        public RateForm()
        {
            InitializeComponent();
            _ctx = new FinanceContext();
            _ctx.CurrencyRates.Load();
            _bsRates = new BindingSource { DataSource = _ctx.CurrencyRates.Local.ToBindingList() };
            dgvRates.AutoGenerateColumns = false;
            dgvRates.Columns.Clear();
            dgvRates.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgvRates.Columns.Add(new DataGridViewTextBoxColumn { Name = "Date", DataPropertyName = "Date", HeaderText = "Fecha", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvRates.Columns.Add(new DataGridViewTextBoxColumn { Name = "UsdToArs", DataPropertyName = "UsdToArs", HeaderText = "Cotización USD→ARS", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvRates.DataSource = _bsRates;
            btnAddRate.Click += BtnAddRate_Click;
            btnSaveRate.Click += BtnSaveRate_Click;
            btnDeleteRate.Click += BtnDeleteRate_Click;
        }

        private void BtnAddRate_Click(object sender, EventArgs e)
        {
            var rate = new CurrencyRate { Date = DateTime.Today, UsdToArs = 0m };
            _ctx.CurrencyRates.Add(rate); _bsRates.ResetBindings(false);
            dgvRates.CurrentCell = dgvRates.Rows[^1].Cells[1]; dgvRates.BeginEdit(true);
        }

        private void BtnSaveRate_Click(object sender, EventArgs e)
        {
            try { _ctx.SaveChanges(); _bsRates.ResetBindings(false); MessageBox.Show("Cotizaciones guardadas."); }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void BtnDeleteRate_Click(object sender, EventArgs e)
        {
            if (dgvRates.CurrentRow == null) return;
            var rate = (CurrencyRate)dgvRates.CurrentRow.DataBoundItem;
            if (MessageBox.Show($"Eliminar cotización de {rate.Date:d}?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            { _ctx.CurrencyRates.Remove(rate); _ctx.SaveChanges(); _bsRates.ResetBindings(false); }
        }
    }
}