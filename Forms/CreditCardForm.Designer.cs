using System.Windows.Forms;

namespace FinanceApp.Forms
{
    partial class CreditCardForm
    {
        private System.ComponentModel.IContainer components;
        private DataGridView dgvCards; private Panel panelButtons; private Button btnAddCard; private Button btnSaveCard; private Button btnDeleteCard;
        private void InitializeComponent()
        {
            dgvCards = new DataGridView(); panelButtons = new Panel(); btnAddCard = new Button(); btnSaveCard = new Button(); btnDeleteCard = new Button();
            panelButtons.Controls.AddRange(new Control[] { btnDeleteCard, btnSaveCard, btnAddCard });
            dgvCards.Dock = DockStyle.Top; dgvCards.Height = 300; dgvCards.AllowUserToAddRows = false; dgvCards.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            panelButtons.Dock = DockStyle.Bottom; panelButtons.Height = 40;
            btnAddCard.Text = "Agregar"; btnAddCard.Dock = DockStyle.Left;
            btnSaveCard.Text = "Guardar"; btnSaveCard.Dock = DockStyle.Left;
            btnDeleteCard.Text = "Eliminar"; btnDeleteCard.Dock = DockStyle.Left;
            this.ClientSize = new System.Drawing.Size(600, 350);
            this.Controls.Add(dgvCards); this.Controls.Add(panelButtons); this.Text = "Tarjetas de Crédito";
        }
    }
}