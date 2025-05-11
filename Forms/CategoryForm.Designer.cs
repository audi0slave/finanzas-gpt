// CategoryForm.Designer.cs
using System.Windows.Forms;

namespace FinanceApp.Forms
{
    partial class CategoryForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvCategories;
        private Button btnAdd;
        private Button btnSave;
        private Button btnDelete;
        private Panel panelButtons;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvCategories = new DataGridView();
            this.panelButtons = new Panel();
            this.btnAdd = new Button();
            this.btnSave = new Button();
            this.btnDelete = new Button();

            // dgvCategories
            this.dgvCategories.Dock = DockStyle.Top;
            this.dgvCategories.Height = 300;
            this.dgvCategories.AllowUserToAddRows = false;
            this.dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // panelButtons
            this.panelButtons.Dock = DockStyle.Bottom;
            this.panelButtons.Height = 40;
            this.panelButtons.Controls.AddRange(new Control[] { btnDelete, btnSave, btnAdd });

            // btnAdd
            this.btnAdd.Text = "Agregar";
            this.btnAdd.Dock = DockStyle.Left;

            // btnSave
            this.btnSave.Text = "Guardar";
            this.btnSave.Dock = DockStyle.Left;

            // btnDelete
            this.btnDelete.Text = "Eliminar";
            this.btnDelete.Dock = DockStyle.Left;

            // CategoryForm
            this.ClientSize = new System.Drawing.Size(400, 350);
            this.Controls.Add(this.dgvCategories);
            this.Controls.Add(this.panelButtons);
            this.Text = "Categorías";
        }
    }
}