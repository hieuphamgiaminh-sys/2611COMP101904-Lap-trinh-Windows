using lab07.Models;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace lab07.Forms
{
    public partial class FrmProduct : Form
    {
        private BindingList<Product> productList = new BindingList<Product>();
        private TextBox txtId, txtName, txtCategory, txtPrice, txtQty;
        private DataGridView dgvProducts;
        public FrmProduct()
        {
            this.Text = "Quản lý Sản phẩm";
            this.Size = new Size(650, 450);
            this.Controls.Add(new Label { Text = "Mã SP:", Location = new Point(20, 20), AutoSize = true });
            txtId = new TextBox { Location = new Point(80, 17), Width = 100 };
            this.Controls.Add(new Label { Text = "Tên SP:", Location = new Point(200, 20), AutoSize = true });
            txtName = new TextBox { Location = new Point(260, 17), Width = 150 };
            this.Controls.Add(new Label { Text = "Loại:", Location = new Point(20, 60), AutoSize = true });
            txtCategory = new TextBox { Location = new Point(80, 57), Width = 100 };
            this.Controls.Add(new Label { Text = "Đơn giá:", Location = new Point(200, 60), AutoSize = true });
            txtPrice = new TextBox { Location = new Point(260, 57), Width = 100 };
            this.Controls.Add(new Label { Text = "Số lượng:", Location = new Point(400, 60), AutoSize = true });
            txtQty = new TextBox { Location = new Point(470, 57), Width = 60 };
            Button btnAdd = new Button { Text = "Thêm", Location = new Point(80, 100), Width = 70 };
            Button btnDelete = new Button { Text = "Xóa", Location = new Point(160, 100), Width = 70 };
            Button btnClear = new Button { Text = "Làm mới", Location = new Point(240, 100), Width = 70 };
            btnAdd.Click += BtnAdd_Click;
            btnDelete.Click += BtnDelete_Click;
            btnClear.Click += (s, e) => { txtId.Clear(); txtName.Clear(); txtCategory.Clear(); txtPrice.Clear(); txtQty.Clear(); };
            dgvProducts = new DataGridView
            {
                Location = new Point(20, 150),
                Size = new Size(590, 240),
                DataSource = productList,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true
            };

            this.Controls.AddRange(new Control[] { txtId, txtName, txtCategory, txtPrice, txtQty, btnAdd, btnDelete, btnClear, dgvProducts });
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text) || string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Mã và tên không được để trống!"); return;
            }
            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price < 0)
            {
                MessageBox.Show("Đơn giá phải là số >= 0"); return;
            }
            if (!int.TryParse(txtQty.Text, out int qty) || qty < 0)
            {
                MessageBox.Show("Số lượng phải là số >= 0"); return;
            }
            if (productList.Any(p => p.ProductId == txtId.Text.Trim()))
            {
                MessageBox.Show("Mã sản phẩm đã tồn tại!"); return;
            }
            productList.Add(new Product
            {
                ProductId = txtId.Text.Trim(),
                ProductName = txtName.Text.Trim(),
                Category = txtCategory.Text.Trim(),
                Price = price,
                Quantity = qty
            });
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow != null && MessageBox.Show("Xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                productList.RemoveAt(dgvProducts.CurrentRow.Index);
            }
        }
    }
}