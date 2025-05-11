using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using FinanceApp.Data;
using FinanceApp.Data.Models;

namespace FinanceApp.Forms
{
    public partial class CreditCardForm : Form
    {
        private readonly FinanceContext _ctx;
        private readonly BindingSource _bsCards;

        public CreditCardForm()
        {
            InitializeComponent();
            _ctx = new FinanceContext();
            _ctx.CreditCards.Load();
            _bsCards = new BindingSource { DataSource = _ctx.CreditCards.Local.ToBindingList() };
            dgvCards.AutoGenerateColumns = false;
            dgvCards.Columns.Clear();
            dgvCards.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgvCards.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name", DataPropertyName = "Name", HeaderText = "Nombre Tarjeta", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCards.Columns.Add(new DataGridViewTextBoxColumn { Name = "Bank", DataPropertyName = "Bank", HeaderText = "Banco", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvCards.Columns.Add(new DataGridViewTextBoxColumn { Name = "ClosingDate", DataPropertyName = "ClosingDate", HeaderText = "Cierre Tarjeta", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvCards.DataSource = _bsCards;
            btnAddCard.Click += BtnAddCard_Click;
            btnSaveCard.Click += BtnSaveCard_Click;
            btnDeleteCard.Click += BtnDeleteCard_Click;
        }

        private void BtnAddCard_Click(object sender, EventArgs e)
        {
            var card = new CreditCard { Name = string.Empty, Bank = string.Empty, ClosingDate = DateTime.Today };
            _ctx.CreditCards.Add(card); _bsCards.ResetBindings(false);
            dgvCards.CurrentCell = dgvCards.Rows[^1].Cells[1]; dgvCards.BeginEdit(true);
        }

        private void BtnSaveCard_Click(object sender, EventArgs e)
        {
            try { _ctx.SaveChanges(); _bsCards.ResetBindings(false); MessageBox.Show("Tarjetas guardadas."); }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void BtnDeleteCard_Click(object sender, EventArgs e)
        {
            if (dgvCards.CurrentRow == null) return;
            var card = (CreditCard)dgvCards.CurrentRow.DataBoundItem;
            if (MessageBox.Show($"Eliminar tarjeta '{card.Name}'?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            { _ctx.CreditCards.Remove(card); _ctx.SaveChanges(); _bsCards.ResetBindings(false); }
        }
    }
}