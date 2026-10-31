using lab07.Models;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace lab07.Forms
{
    public partial class FrmCustomer : Form
    {
        private BindingList<Customer> customerList = new BindingList<Customer>();
        private TextBox txtId, txtName, txtPhone, txtType;
        private DataGridView dgvCustomers;
        public FrmCustomer()
        {
            this.Text = "Quản lý Khách hàng";
            this.Size = new Size(600, 400);
            this.Controls.Add(new Label { Text = "Mã KH:", Location = new Point(20, 20), AutoSize = true });
            txtId = new TextBox { Location = new Point(80, 17), Width = 100 };
            this.Controls.Add(new Label { Text = "Họ tên:", Location = new Point(200, 20), AutoSize = true });
            txtName = new TextBox { Location = new Point(260, 17), Width = 150 };
            this.Controls.Add(new Label { Text = "Số ĐT:", Location = new Point(20, 60), AutoSize = true });
            txtPhone = new TextBox { Location = new Point(80, 57), Width = 100 };
            this.Controls.Add(new Label { Text = "Loại KH:", Location = new Point(200, 60), AutoSize = true });
            txtType = new TextBox { Location = new Point(260, 57), Width = 150 };
            Button btnAdd = new Button { Text = "Thêm KH", Location = new Point(80, 100), Width = 80 };
            btnAdd.Click += BtnAdd_Click;
            dgvCustomers = new DataGridView
            {
                Location = new Point(20, 140),
                Size = new Size(540, 200),
                DataSource = customerList,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true
            };
            this.Controls.AddRange(new Control[] { txtId, txtName, txtPhone, txtType, btnAdd, dgvCustomers });
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text) || string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Mã và tên không được để trống!"); return;
            }
            if (customerList.Any(c => c.CustomerId == txtId.Text.Trim()))
            {
                MessageBox.Show("Mã khách hàng đã tồn tại!"); return;
            }
            customerList.Add(new Customer
            {
                CustomerId = txtId.Text.Trim(),
                FullName = txtName.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                CustomerType = txtType.Text.Trim()
            });
        }
    }
}