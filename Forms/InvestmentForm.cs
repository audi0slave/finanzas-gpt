using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using FinanceApp.Data;
using FinanceApp.Data.Models;

namespace FinanceApp.Forms
{
    public partial class InvestmentForm : Form
    {
        private readonly FinanceContext _ctx;
        private readonly BindingSource _bsInvestments;

        public InvestmentForm()
        {
            InitializeComponent();

            // Inicializar contexto y cargar datos
            _ctx = new FinanceContext();
            _ctx.Investments.Load();

            // Configurar BindingSource
            _bsInvestments = new BindingSource { DataSource = _ctx.Investments.Local.ToBindingList() };

            // Configurar DataGridView
            dgvInvestments.AutoGenerateColumns = false;
            dgvInvestments.Columns.Clear();

            // Columna Id oculta
            dgvInvestments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                DataPropertyName = "Id",
                Visible = false
            });
            // Tipo de inversión
            dgvInvestments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Type",
                DataPropertyName = "Type",
                HeaderText = "Tipo",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            // Fecha inicio
            dgvInvestments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StartDate",
                DataPropertyName = "StartDate",
                HeaderText = "Fecha Inicio",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });
            // Monto inicial
            dgvInvestments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Amount",
                DataPropertyName = "Amount",
                HeaderText = "Monto Inicial",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });
            // Valor actual
            dgvInvestments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CurrentValue",
                DataPropertyName = "CurrentValue",
                HeaderText = "Valor Actual",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            dgvInvestments.DataSource = _bsInvestments;

            // Botones
            btnAddInvestment.Click += BtnAddInvestment_Click;
            btnSaveInvestment.Click += BtnSaveInvestment_Click;
            btnDeleteInvestment.Click += BtnDeleteInvestment_Click;
        }

        private void BtnAddInvestment_Click(object sender, EventArgs e)
        {
            var inv = new Investment { Type = string.Empty, StartDate = DateTime.Today, Amount = 0m, CurrentValue = 0m };
            _ctx.Investments.Add(inv);
            _bsInvestments.ResetBindings(false);
            dgvInvestments.CurrentCell = dgvInvestments.Rows[dgvInvestments.Rows.Count - 1].Cells[1];
            dgvInvestments.BeginEdit(true);
        }

        private void BtnSaveInvestment_Click(object sender, EventArgs e)
        {
            try
            {
                _ctx.SaveChanges();
                _bsInvestments.ResetBindings(false);
                MessageBox.Show("Inversiones guardadas.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDeleteInvestment_Click(object sender, EventArgs e)
        {
            if (dgvInvestments.CurrentRow == null) return;
            var inv = (Investment)dgvInvestments.CurrentRow.DataBoundItem;
            if (MessageBox.Show($"Eliminar inversión '{inv.Type}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _ctx.Investments.Remove(inv);
                _ctx.SaveChanges();
                _bsInvestments.ResetBindings(false);
            }
        }
    }
}