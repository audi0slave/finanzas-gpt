using System.Windows.Forms;
using ScottPlot.WinForms;

namespace FinanceApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private DateTimePicker dtpFilter;
        private FlowLayoutPanel flpMetrics;
        private Label lblTotalBalance;
        private Label lblTotalIncome;
        private Label lblTotalDebit;
        private Label lblTotalCredit;
        private Label lblInstallmentExpenses;
        private Label lblInvestments;
        private DataGridView dgvAccounts;
        private FormsPlot pltExpenses;
        private Label lblLoanSummary;
        private Panel panelButtons;
        private Button btnAccount, btnCategory, btnSubCategory;
        private Button btnCreditCard, btnRate, btnLoan, btnInvestment, btnNewTransaction;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dtpFilter = new DateTimePicker();
            this.flpMetrics = new FlowLayoutPanel();
            this.lblTotalBalance = new Label();
            this.lblTotalIncome = new Label();
            this.lblTotalDebit = new Label();
            this.lblTotalCredit = new Label();
            this.lblInstallmentExpenses = new Label();
            this.lblInvestments = new Label();
            this.dgvAccounts = new DataGridView();
            this.pltExpenses = new FormsPlot();
            this.lblLoanSummary = new Label();
            this.panelButtons = new Panel();
            this.btnNewTransaction = new Button();
            this.btnAccount = new Button();
            this.btnCategory = new Button();
            this.btnSubCategory = new Button();
            this.btnCreditCard = new Button();
            this.btnRate = new Button();
            this.btnLoan = new Button();
            this.btnInvestment = new Button();

            // dtpFilter
            this.dtpFilter.Dock = DockStyle.Top;
            this.dtpFilter.Format = DateTimePickerFormat.Custom;
            this.dtpFilter.CustomFormat = "MMMM yyyy";
            this.dtpFilter.ShowUpDown = true;

            // flpMetrics
            this.flpMetrics.Dock = DockStyle.Top;
            this.flpMetrics.Height = 70;
            this.flpMetrics.AutoScroll = true;
            this.flpMetrics.Controls.AddRange(new Control[] {
                this.lblTotalBalance,
                this.lblTotalIncome,
                this.lblTotalDebit,
                this.lblTotalCredit,
                this.lblInstallmentExpenses,
                this.lblInvestments
            });
            foreach (Control c in flpMetrics.Controls)
                ((Label)c).AutoSize = true;

            // dgvAccounts
            this.dgvAccounts.Dock = DockStyle.Top;
            this.dgvAccounts.Height = 200;
            this.dgvAccounts.ReadOnly = true;
            this.dgvAccounts.AutoGenerateColumns = true;

            // pltExpenses
            this.pltExpenses.Dock = DockStyle.Fill;

            // lblLoanSummary
            this.lblLoanSummary.Dock = DockStyle.Bottom;
            this.lblLoanSummary.Height = 30;
            this.lblLoanSummary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // panelButtons
            this.panelButtons.Dock = DockStyle.Bottom;
            this.panelButtons.Height = 40;
            this.panelButtons.Controls.AddRange(new Control[] {
                btnNewTransaction, btnAccount, btnCategory, btnSubCategory,
                btnCreditCard, btnRate, btnLoan, btnInvestment
            });

            // Buttons
            this.btnNewTransaction.Text = "Nueva Transacción"; this.btnNewTransaction.Dock = DockStyle.Left;
            this.btnAccount.Text = "Cuentas"; this.btnAccount.Dock = DockStyle.Left;
            this.btnCategory.Text = "Categorías"; this.btnCategory.Dock = DockStyle.Left;
            this.btnSubCategory.Text = "Subcategorías"; this.btnSubCategory.Dock = DockStyle.Left;
            this.btnCreditCard.Text = "Tarjetas"; this.btnCreditCard.Dock = DockStyle.Left;
            this.btnRate.Text = "Cotizaciones"; this.btnRate.Dock = DockStyle.Left;
            this.btnLoan.Text = "Préstamos"; this.btnLoan.Dock = DockStyle.Left;
            this.btnInvestment.Text = "Inversiones"; this.btnInvestment.Dock = DockStyle.Left;

            // MainForm
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.AddRange(new Control[] {
                this.panelButtons,
                this.lblLoanSummary,
                this.pltExpenses,
                this.dgvAccounts,
                this.flpMetrics,
                this.dtpFilter
            });
            this.Text = "Mis Finanzas";
        }
    }
}
