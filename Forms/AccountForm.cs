using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using FinanceApp.Data;
using FinanceApp.Data.Models;

namespace FinanceApp.Forms
{
    public partial class AccountForm : Form
    {
        private readonly FinanceContext _ctx;
        private readonly BindingSource _bsAccounts;

        public AccountForm()
        {
            InitializeComponent();

            // 1) Inicializa contexto y carga entidades en memoria
            _ctx = new FinanceContext();
            _ctx.Accounts.Load(); // requiere using Microsoft.EntityFrameworkCore

            // 2) Crea el BindingSource sobre el Local de EntityFramework
            _bsAccounts = new BindingSource
            {
                DataSource = _ctx.Accounts.Local.ToBindingList()
            };

            // 3) Asigna el DataSource al grid
            dgv.DataSource = _bsAccounts;

            // 4) Configura columnas: ocultamos Id y ponemos ComboBox para Currency
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();

            // Columna Id (oculta)
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                DataPropertyName = "Id",
                Visible = false
            });

            // Columna Name
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Name",
                DataPropertyName = "Name",
                HeaderText = "Nombre",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // Columna Currency (ComboBox)
            dgv.Columns.Add(new DataGridViewComboBoxColumn
            {
                Name = "Currency",
                DataPropertyName = "Currency",
                HeaderText = "Moneda",
                DataSource = new[] { "ARS", "USD" },
                ValueType = typeof(string),
                FlatStyle = FlatStyle.Flat,
                Width = 80
            });

            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AllowUserToAddRows = false; // agregamos sólo con el botón

            // 5) Wiring de botones
            btnAdd.Click += BtnAdd_Click;
            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            // Crea una nueva entidad, la agrega al Local y mueve el Binding
            var acc = new Account { Name = "", Currency = "ARS" };
            _ctx.Accounts.Add(acc);
            _bsAccounts.MoveLast();
            dgv.CurrentCell = dgv.Rows[_bsAccounts.Position].Cells["Name"];
            dgv.BeginEdit(true);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Guarda todas las modificaciones hechas en el grid
                _ctx.SaveChanges();
                MessageBox.Show("Cambios guardados correctamente.", "OK",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null) return;
            var acc = (Account)dgv.CurrentRow.DataBoundItem;
            if (MessageBox.Show($"Eliminar cuenta '{acc.Name}'?",
                                "Confirmar eliminación",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning)
                                == DialogResult.Yes)
            {
                _ctx.Accounts.Remove(acc);
                _ctx.SaveChanges();
                _bsAccounts.Remove(acc);
            }
        }
    }
}
