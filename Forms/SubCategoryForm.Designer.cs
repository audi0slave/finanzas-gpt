using System.Windows.Forms;

namespace FinanceApp.Forms
{
    partial class SubCategoryForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvSub;
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
            this.dgvSub = new DataGridView();
            this.panelButtons = new Panel();
            this.btnAdd = new Button();
            this.btnSave = new Button();
            this.btnDelete = new Button();

            // dgvSub
            this.dgvSub.Dock = DockStyle.Top;
            this.dgvSub.Height = 300;
            this.dgvSub.AllowUserToAddRows = false;
            this.dgvSub.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

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

            // SubCategoryForm
            this.ClientSize = new System.Drawing.Size(500, 350);
            this.Controls.Add(this.dgvSub);
            this.Controls.Add(this.panelButtons);
            this.Text = "Subcategorías";
        }
    }
}
