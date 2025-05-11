using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using FinanceApp.Data;
using FinanceApp.Forms;
using ScottPlot.WinForms;
using ScottPlot.Plottables;
using ScottPlot;

namespace FinanceApp
{
    public partial class MainForm : Form
    {
        private readonly FinanceContext _context;

        public MainForm()
        {
            InitializeComponent();
            _context = new FinanceContext();

            // Navegación
            btnAccount.Click += (_, __) => new AccountForm().ShowDialog();
            btnCategory.Click += (_, __) => new CategoryForm().ShowDialog();
            btnSubCategory.Click += (_, __) => new SubCategoryForm().ShowDialog();
            btnCreditCard.Click += (_, __) => new CreditCardForm().ShowDialog();
            btnRate.Click += (_, __) => new RateForm().ShowDialog();
            btnLoan.Click += (_, __) => new LoanForm().ShowDialog();
            btnInvestment.Click += (_, __) => new InvestmentForm().ShowDialog();
            btnNewTransaction.Click += (_, __) => { new TransactionForm().ShowDialog(); LoadData(); };

            // Filtro de mes/año
            dtpFilter.ValueChanged += (_, __) => LoadData();

            Load += (_, __) => LoadData();
        }

        private void LoadData()
        {
            // 1) Fecha de filtro
            int month = dtpFilter.Value.Month;
            int year = dtpFilter.Value.Year;

            // 2) Cotización más reciente
            decimal latestRate = _context.CurrencyRates
                .OrderByDescending(r => r.Date)
                .Select(r => r.UsdToArs)
                .FirstOrDefault();

            // 3) Datos de cuentas y saldo total
            var accounts = _context.Accounts
                .Include(a => a.Transactions)
                .AsEnumerable();

            decimal totalArs = accounts
                .Where(a => a.Currency == "ARS")
                .Sum(a => a.Transactions.Sum(t => t.Amount));

            decimal totalUsd = accounts
                .Where(a => a.Currency == "USD")
                .Sum(a => a.Transactions.Sum(t => t.Amount));

            decimal totalUsdEq = totalUsd + (totalArs / (latestRate == 0 ? 1 : latestRate));

            lblTotalBalance.Text =
                $"Saldo total: {totalArs:C2} ARS / {totalUsdEq:C2} USD";

            dgvAccounts.DataSource = accounts
                .Select(a => new {
                    a.Name,
                    a.Currency,
                    Balance = Math.Round(
                        a.Transactions.Sum(t =>
                            a.Currency == "ARS"
                                ? t.Amount / (latestRate == 0 ? 1 : latestRate)
                                : t.Amount
                        ), 2)
                })
                .ToList();

            // 4) Métricas del mes
            var txsMes = _context.Transactions
                .Where(t => t.Date.Year == year && t.Date.Month == month);

            decimal totalIncome = txsMes.Where(t => t.Type == "Income").Sum(t => t.Amount);
            decimal totalDebit = -txsMes.Where(t => t.Type == "Debit").Sum(t => t.Amount);
            decimal totalCredit = -txsMes.Where(t => t.Type == "Credit").Sum(t => t.Amount);
            decimal totalInstallments = -txsMes.Where(t => t.Type == "Installment").Sum(t => t.Amount);
            decimal totalInvestments = _context.Investments.Sum(i => i.CurrentValue);

            lblTotalIncome.Text = $"Ingresos: {totalIncome:C2}";
            lblTotalDebit.Text = $"Gastos débito: {totalDebit:C2}";
            lblTotalCredit.Text = $"Gastos crédito: {totalCredit:C2}";
            lblInstallmentExpenses.Text = $"Gastos en cuotas: {totalInstallments:C2}";
            lblInvestments.Text = $"Valor inversiones: {totalInvestments:C2}";

            // 5) Gráfico de torta por categoría
            var pieData = txsMes
                .Where(t => t.Type == "Debit" || t.Type == "Credit")
                .GroupBy(t => t.Category.Name)
                .Select(g => new { Cat = g.Key, Val = Math.Round(-g.Sum(t => t.Amount), 2) })
                .ToList();

            pltExpenses.Plot.Clear();
            if (pieData.Count > 0)
            {
                var slices = pieData
                    .Select(x => new PieSlice
                    {
                        Value = (double)x.Val,
                        Label = x.Cat
                    })
                    .ToList();

                var pie = pltExpenses.Plot.Add.Pie(slices);
                //pie.ShowSliceLabels = true;
                pie.SliceLabelDistance = 1.2;
            }
            pltExpenses.Refresh();

            // 6) Resumen de pago mensual de préstamos activos
            //var totalLoanPerMonth = _context.Loans
            //    .Where(l => l.PaidInstallments < l.TotalInstallments)
            //    .Sum(l => l.MonthlyPayment);

            //lblLoanSummary.Text =
            //    $"Pago mensual de préstamos: {totalLoanPerMonth:C2}";
        }
    }
}
