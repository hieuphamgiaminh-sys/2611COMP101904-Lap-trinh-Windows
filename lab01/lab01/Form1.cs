using System;
using System.Windows.Forms;

namespace lab01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (cboKhoa.Items.Count == 0)
            {
                cboKhoa.Items.Add("Công nghệ thông tin");
                cboKhoa.Items.Add("Khoa học máy tính");
                cboKhoa.Items.Add("Hệ thống thông tin");
            }
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNamSinh.Text) || !int.TryParse(txtNamSinh.Text, out int namSinh))
            {
                MessageBox.Show("Năm sinh phải là số nguyên và không được rỗng!", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNamSinh.Focus();
                return;
            }

            int namHienTai = DateTime.Now.Year;
            if (namSinh < 1900 || namSinh > namHienTai)
            {
                MessageBox.Show($"Năm sinh phải nằm trong khoảng từ 1900 đến {namHienTai}!", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNamSinh.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập email!", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (!radNam.Checked && !radNu.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính!", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboKhoa.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn khoa hoặc lớp!", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboKhoa.Focus();
                return;
            }

            string hoTen = txtHoTen.Text.Trim();
            int tuoi = namHienTai - namSinh;
            string email = txtEmail.Text.Trim();
            string gioiTinh = radNam.Checked ? "Nam" : "Nữ";
            string khoa = cboKhoa.SelectedItem.ToString();

            txtKetQua.Text = "THÔNG TIN SINH VIÊN\r\n" +
                             "Họ tên: " + hoTen + "\r\n" +
                             "Tuổi: " + tuoi + "\r\n" +
                             "Email: " + email + "\r\n" +
                             "Giới tính: " + gioiTinh + "\r\n" +
                             "Khoa/Lớp: " + khoa;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtHoTen.Clear();
            txtNamSinh.Clear();
            txtEmail.Clear();
            radNam.Checked = false;
            radNu.Checked = false;
            cboKhoa.SelectedIndex = -1; 
            txtKetQua.Clear();
            txtHoTen.Focus(); 
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}