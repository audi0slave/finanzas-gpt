namespace FinanceApp.Forms
{
    partial class AccountForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel panelButtons;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgv = new System.Windows.Forms.DataGridView();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();

            // 
            // dgv
            // 
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersVisible = false;
            this.dgv.Size = new System.Drawing.Size(400, 300);

            // 
            // panelButtons
            // 
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Height = 40;
            this.panelButtons.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.btnDelete,
                this.btnSave,
                this.btnAdd
            });

            // 
            // btnAdd
            // 
            this.btnAdd.Text = "Agregar";
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Left;

            // 
            // btnSave
            // 
            this.btnSave.Text = "Guardar cambios";
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Left;

            // 
            // btnDelete
            // 
            this.btnDelete.Text = "Eliminar";
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Left;

            // 
            // AccountForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 340);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.panelButtons);
            this.Name = "AccountForm";
            this.Text = "Cuentas";
        }
    }
}
