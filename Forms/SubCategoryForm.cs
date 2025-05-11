using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using FinanceApp.Data;
using FinanceApp.Data.Models;

namespace FinanceApp.Forms
{
    public partial class SubCategoryForm : Form
    {
        private readonly FinanceContext _ctx;
        private readonly BindingSource _bsSub;

        public SubCategoryForm()
        {
            InitializeComponent();

            // Contexto
            _ctx = new FinanceContext();
            _ctx.Categories.Load();
            _ctx.SubCategories.Load();

            // Binding
            _bsSub = new BindingSource { DataSource = _ctx.SubCategories.Local.ToBindingList() };

            // DataGridView
            dgvSub.AutoGenerateColumns = false;
            dgvSub.Columns.Clear();
            // Id oculta
            dgvSub.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                DataPropertyName = "Id",
                Visible = false
            });
            // Name
            dgvSub.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Name",
                DataPropertyName = "Name",
                HeaderText = "Subcategoría",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            // CategoryId as Combo
            dgvSub.Columns.Add(new DataGridViewComboBoxColumn
            {
                Name = "CategoryId",
                DataPropertyName = "CategoryId",
                HeaderText = "Categoría",
                DataSource = _ctx.Categories.Local.ToBindingList(),
                DisplayMember = "Name",
                ValueMember = "Id",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            dgvSub.DataSource = _bsSub;

            // Botones
            btnAdd.Click += BtnAdd_Click;
            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var sc = new SubCategory { Name = string.Empty, CategoryId = _ctx.Categories.First().Id };
            _ctx.SubCategories.Add(sc);
            _bsSub.ResetBindings(false);
            dgvSub.CurrentCell = dgvSub.Rows[dgvSub.Rows.Count - 1].Cells[1];
            dgvSub.BeginEdit(true);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _ctx.SaveChanges();
                _bsSub.ResetBindings(false);
                MessageBox.Show("Subcategorías guardadas.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSub.CurrentRow == null) return;
            var sc = (SubCategory)dgvSub.CurrentRow.DataBoundItem;
            if (MessageBox.Show($"Eliminar subcategoría '{sc.Name}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _ctx.SubCategories.Remove(sc);
                _ctx.SaveChanges();
                _bsSub.ResetBindings(false);
            }
        }
    }
}