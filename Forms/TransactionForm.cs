using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using FinanceApp.Data;
using FinanceApp.Data.Models;

namespace FinanceApp.Forms
{
    public partial class TransactionForm : Form
    {
        private readonly FinanceContext _ctx;
        private readonly BindingSource _bsTransactions;

        public TransactionForm()
        {
            InitializeComponent();

            // 1. Inicializar contexto y precargar datos
            _ctx = new FinanceContext();
            _ctx.Accounts.Load();
            _ctx.Categories.Load();
            _ctx.SubCategories.Load();
            _ctx.CreditCards.Load();
            _ctx.Loans.Load();
            _ctx.CurrencyRates.Load();
            _ctx.Transactions
                .Include(t => t.Account)
                .Include(t => t.Category)
                .Include(t => t.SubCategory)
                .Include(t => t.CreditCard)
                .Include(t => t.Loan)
                .Load();

            // 2. Configurar el DataGridView manualmente
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();

            // Fecha
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Date",
                DataPropertyName = "Date",
                HeaderText = "Fecha",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            // Descripción
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Description",
                DataPropertyName = "Description",
                HeaderText = "Descripción",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // Monto
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Amount",
                DataPropertyName = "Amount",
                HeaderText = "Monto",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            // Tipo
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Type",
                DataPropertyName = "Type",
                HeaderText = "Tipo",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            // Cuenta (Combo)
            dgv.Columns.Add(new DataGridViewComboBoxColumn
            {
                Name = "AccountId",
                DataPropertyName = "AccountId",
                HeaderText = "Cuenta",
                DataSource = _ctx.Accounts.Local.ToBindingList(),
                DisplayMember = "Name",
                ValueMember = "Id",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            // Categoría (Combo)
            dgv.Columns.Add(new DataGridViewComboBoxColumn
            {
                Name = "CategoryId",
                DataPropertyName = "CategoryId",
                HeaderText = "Categoría",
                DataSource = _ctx.Categories.Local.ToBindingList(),
                DisplayMember = "Name",
                ValueMember = "Id",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            // Subcategoría (Combo)
            dgv.Columns.Add(new DataGridViewComboBoxColumn
            {
                Name = "SubCategoryId",
                DataPropertyName = "SubCategoryId",
                HeaderText = "Subcategoría",
                DataSource = _ctx.SubCategories.Local.ToBindingList(),
                DisplayMember = "Name",
                ValueMember = "Id",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            // Tarjeta (Combo)
            dgv.Columns.Add(new DataGridViewComboBoxColumn
            {
                Name = "CreditCardId",
                DataPropertyName = "CreditCardId",
                HeaderText = "Tarjeta",
                DataSource = _ctx.CreditCards.Local.ToBindingList(),
                DisplayMember = "Name",
                ValueMember = "Id",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            // Préstamo (Combo)
            dgv.Columns.Add(new DataGridViewComboBoxColumn
            {
                Name = "LoanId",
                DataPropertyName = "LoanId",
                HeaderText = "Préstamo",
                DataSource = _ctx.Loans.Local.ToBindingList(),
                DisplayMember = "Lender",
                ValueMember = "Id",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            // Cuotas totales
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "InstallmentTotal",
                DataPropertyName = "InstallmentTotal",
                HeaderText = "Total Cuotas",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            // Cuotas pagadas
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "InstallmentPaid",
                DataPropertyName = "InstallmentPaid",
                HeaderText = "Pagas",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            // 3. BindingSource para las transacciones
            _bsTransactions = new BindingSource
            {
                DataSource = _ctx.Transactions.Local.ToBindingList()
            };
            dgv.DataSource = _bsTransactions;

            // 4. Población de dropdowns del formulario inferior
            cbType.Items.AddRange(["Income", "Debit", "Credit", "Installment", "Conversion", "LoanPayment"]);
            cbAccount.DataSource = _ctx.Accounts.Local.ToBindingList();
            cbAccount.DisplayMember = "Name"; cbAccount.ValueMember = "Id";
            cbCategory.DataSource = _ctx.Categories.Local.ToBindingList();
            cbCategory.DisplayMember = "Name"; cbCategory.ValueMember = "Id";
            cbSubCategory.DataSource = _ctx.SubCategories.Local.ToBindingList();
            cbSubCategory.DisplayMember = "Name"; cbSubCategory.ValueMember = "Id";
            cbCreditCard.DataSource = _ctx.CreditCards.Local.ToBindingList();
            cbCreditCard.DisplayMember = "Name"; cbCreditCard.ValueMember = "Id";
            cbLoan.DataSource = _ctx.Loans.Local.ToBindingList();
            cbLoan.DisplayMember = "DisplayName"; cbLoan.ValueMember = "Id";

            // 5. Eventos
            dgv.SelectionChanged += (_, __) => OnRowSelected();
            btnAddTransaction.Click += (_, __) => AddTransaction();
            btnSaveChanges.Click += (_, __) => SaveChanges();
            btnDeleteTransaction.Click += (_, __) => DeleteTransaction();
            cbType.SelectedIndexChanged += (_, __) => UpdateControlsByType();

            // Inicialización UI
            Load += (_, __) =>
            {
                UpdateControlsByType();
                ClearForm();
            };
        }

        private void OnRowSelected()
        {
            if (dgv.CurrentRow == null) return;
            var t = (Transaction)dgv.CurrentRow.DataBoundItem;
            if (t == null) return;

            dtpDate.Value = t.Date;
            txtDescription.Text = t.Description;
            txtAmount.Text = t.Amount.ToString("F2");
            cbType.SelectedItem = t.Type;
            cbAccount.SelectedValue = t.AccountId;

            if (t.CategoryId.HasValue) cbCategory.SelectedValue = t.CategoryId.Value; else cbCategory.SelectedIndex = -1;
            if (t.SubCategoryId.HasValue) cbSubCategory.SelectedValue = t.SubCategoryId.Value; else cbSubCategory.SelectedIndex = -1;
            if (t.CreditCardId.HasValue) cbCreditCard.SelectedValue = t.CreditCardId.Value; else cbCreditCard.SelectedIndex = -1;
            if (t.LoanId.HasValue) cbLoan.SelectedValue = t.LoanId.Value; else cbLoan.SelectedIndex = -1;

            nudTotal.Value = t.InstallmentTotal ?? 1;
            nudPaid.Value = t.InstallmentPaid ?? 0;
            dtpRateDate.Value = t.CurrencyRate != null ? t.CurrencyRate.Date : DateTime.Today;
        }

        private void AddTransaction()
        {
            // Validaciones mínimas
            if (!decimal.TryParse(txtAmount.Text, out var amt))
            {
                MessageBox.Show("Ingresa un monto válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbType.SelectedIndex < 0 || cbAccount.SelectedIndex < 0)
            {
                MessageBox.Show("Selecciona un tipo y una cuenta.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var t = new Transaction
            {
                Date = dtpDate.Value,
                Description = txtDescription.Text.Trim(),
                Amount = amt,
                Type = cbType.SelectedItem.ToString(),
                AccountId = (int)cbAccount.SelectedValue
            };

            // Categoría y subcategoría
            if (t.Type != "Income")
            {
                t.CategoryId = cbCategory.SelectedIndex >= 0 ? (int?)cbCategory.SelectedValue : null;
                t.SubCategoryId = cbSubCategory.SelectedIndex >= 0 ? (int?)cbSubCategory.SelectedValue : null;
            }

            // Tarjeta y préstamo
            t.CreditCardId = t.Type == "Credit" && cbCreditCard.SelectedIndex >= 0 ? (int?)cbCreditCard.SelectedValue : null;
            t.LoanId = t.Type == "LoanPayment" && cbLoan.SelectedIndex >= 0 ? (int?)cbLoan.SelectedValue : null;

            // Cuotas
            if (t.Type == "Installment")
            {
                t.InstallmentTotal = (int)nudTotal.Value;
                t.InstallmentPaid = (int)nudPaid.Value;
            }

            // Conversión de moneda
            if (t.Type == "Conversion")
            {
                var rate = new CurrencyRate { Date = dtpRateDate.Value, UsdToArs = amt };
                _ctx.CurrencyRates.Add(rate);
                _ctx.SaveChanges();
                t.CurrencyRateId = rate.Id;
            }
            else
            {
                var acct = _ctx.Accounts.Find(t.AccountId);
                if (acct.Currency == "ARS")
                    t.CurrencyRateId = _ctx.CurrencyRates.OrderByDescending(r => r.Date).FirstOrDefault()?.Id;
            }

            _ctx.Transactions.Add(t);
            _ctx.SaveChanges();
            _bsTransactions.ResetBindings(false);
            ClearForm();
            MessageBox.Show("Transacción agregada.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SaveChanges()
        {
            try
            {
                _ctx.SaveChanges();
                _bsTransactions.ResetBindings(false);
                MessageBox.Show("Cambios guardados.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteTransaction()
        {
            if (dgv.CurrentRow == null) return;
            var t = (Transaction)dgv.CurrentRow.DataBoundItem;
            if (MessageBox.Show($"Eliminar transacción “{t.Description}”?", "Confirmar eliminación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _ctx.Transactions.Remove(t);
                _ctx.SaveChanges();
                _bsTransactions.ResetBindings(false);
                ClearForm();
            }
        }

        private void UpdateControlsByType()
        {
            var type = cbType.SelectedItem?.ToString();
            bool isCredit = type == "Credit";
            bool isInstallment = type == "Installment";
            bool isConversion = type == "Conversion";
            bool isLoanPay = type == "LoanPayment";

            cbCreditCard.Enabled = isCredit;
            cbLoan.Enabled = isLoanPay;
            nudTotal.Enabled = isInstallment;
            nudPaid.Enabled = isInstallment;
            lblTotal.Visible = isInstallment;
            lblPaid.Visible = isInstallment;
            lblRate.Visible = isConversion;
            dtpRateDate.Visible = isConversion;
        }

        private void ClearForm()
        {
            dtpDate.Value = DateTime.Today;
            txtDescription.Clear();
            txtAmount.Clear();
            cbType.SelectedIndex = -1;
            cbAccount.SelectedIndex = -1;
            cbCategory.SelectedIndex = -1;
            cbSubCategory.SelectedIndex = -1;
            cbCreditCard.SelectedIndex = -1;
            cbLoan.SelectedIndex = -1;
            nudTotal.Value = 1;
            nudPaid.Value = 0;
            dtpRateDate.Value = DateTime.Today;
            dgv.ClearSelection();
        }
    }
}
