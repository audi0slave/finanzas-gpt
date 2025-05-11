// CategoryForm.cs
using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using FinanceApp.Data;
using FinanceApp.Data.Models;

namespace FinanceApp.Forms
{
    public partial class CategoryForm : Form
    {
        private readonly FinanceContext _ctx;
        private readonly BindingSource _bsCategories;

        public CategoryForm()
        {
            InitializeComponent();

            // 1. Inicializar contexto y cargar categorías
            _ctx = new FinanceContext();
            _ctx.Categories.Load();

            // 2. Configurar BindingSource
            _bsCategories = new BindingSource
            {
                DataSource = _ctx.Categories.Local.ToBindingList()
            };

            // 3. Configurar DataGridView
            dgvCategories.AutoGenerateColumns = false;
            dgvCategories.Columns.Clear();

            // Columna Id oculta
            dgvCategories.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                DataPropertyName = "Id",
                Visible = false
            });
            // Columna Name editable
            dgvCategories.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Name",
                DataPropertyName = "Name",
                HeaderText = "Nombre",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvCategories.DataSource = _bsCategories;

            // 4. Botones
            btnAdd.Click += BtnAdd_Click;
            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            // Crear nueva categoría y mover el Binding
            var cat = new Category { Name = string.Empty };
            _ctx.Categories.Add(cat);
            _bsCategories.ResetBindings(false);
            dgvCategories.CurrentCell = dgvCategories.Rows[dgvCategories.Rows.Count - 1].Cells[1];
            dgvCategories.BeginEdit(true);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _ctx.SaveChanges();
                _bsCategories.ResetBindings(false);
                MessageBox.Show("Categorías guardadas.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentRow == null) return;
            var cat = (Category)dgvCategories.CurrentRow.DataBoundItem;
            if (MessageBox.Show($"Eliminar categoría '{cat.Name}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _ctx.Categories.Remove(cat);
                _ctx.SaveChanges();
                _bsCategories.ResetBindings(false);
            }
        }
    }
}