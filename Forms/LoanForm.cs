using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using FinanceApp.Data;
using FinanceApp.Data.Models;

namespace FinanceApp.Forms
{
    public partial class LoanForm : Form
    {
        private readonly FinanceContext _ctx;
        private readonly BindingSource _bsLoans;

        public LoanForm()
        {
            InitializeComponent();

            // Carga EF Core
            _ctx = new FinanceContext();
            _ctx.Loans.Load();

            // BindingSource
            _bsLoans = new BindingSource { DataSource = _ctx.Loans.Local.ToBindingList() };

            // DataGridView manual
            dgvLoans.AllowUserToResizeColumns = true;
            dgvLoans.AutoGenerateColumns = false;
            dgvLoans.Columns.Clear();

            // Id oculto
            dgvLoans.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                DataPropertyName = "Id",
                Visible = false
            });

            // Prestamista
            dgvLoans.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Lender",
                DataPropertyName = "Lender",
                HeaderText = "Prestamista",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // Descripción
            dgvLoans.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Description",
                DataPropertyName = "Description",
                HeaderText = "Descripción",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // Monto total
            dgvLoans.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TotalAmount",
                DataPropertyName = "TotalAmount",
                HeaderText = "Monto Total",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            //// Cuotas totales (si deseas conservar)
            //dgvLoans.Columns.Add(new DataGridViewTextBoxColumn
            //{
            //    Name = "TotalInstallments",
            //    DataPropertyName = "TotalInstallments",
            //    HeaderText = "Cuotas Totales",
            //    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            //});

            //// Cuotas pagadas
            //dgvLoans.Columns.Add(new DataGridViewTextBoxColumn
            //{
            //    Name = "PaidInstallments",
            //    DataPropertyName = "PaidInstallments",
            //    HeaderText = "Cuotas Pagadas",
            //    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            //});

            //// Pago mensual
            //dgvLoans.Columns.Add(new DataGridViewTextBoxColumn
            //{
            //    Name = "MonthlyPayment",
            //    DataPropertyName = "MonthlyPayment",
            //    HeaderText = "Pago Mensual",
            //    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            //});

            dgvLoans.DataSource = _bsLoans;

            // Botones
            btnAddLoan.Click += BtnAddLoan_Click;
            btnSaveLoan.Click += BtnSaveLoan_Click;
            btnDeleteLoan.Click += BtnDeleteLoan_Click;
        }

        private void BtnAddLoan_Click(object sender, EventArgs e)
        {
            var loan = new Loan
            {
                Lender = string.Empty,
                Description = string.Empty,
                TotalAmount = 0m,
            };
            _ctx.Loans.Add(loan);
            _bsLoans.ResetBindings(false);
            dgvLoans.CurrentCell = dgvLoans.Rows[^1].Cells["Lender"];
            dgvLoans.BeginEdit(true);
        }

        private void BtnSaveLoan_Click(object sender, EventArgs e)
        {
            try
            {
                _ctx.SaveChanges();
                _bsLoans.ResetBindings(false);
                MessageBox.Show("Préstamos guardados.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDeleteLoan_Click(object sender, EventArgs e)
        {
            if (dgvLoans.CurrentRow == null) return;
            var loan = (Loan)dgvLoans.CurrentRow.DataBoundItem;
            if (MessageBox.Show($"Eliminar préstamo '{loan.Lender}'?", "Confirmar",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                                == DialogResult.Yes)
            {
                _ctx.Loans.Remove(loan);
                _ctx.SaveChanges();
                _bsLoans.ResetBindings(false);
            }
        }
    }
}