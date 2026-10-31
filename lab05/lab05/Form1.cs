using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace lab05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            numSoThang.Minimum = 1;
            numSoThang.Maximum = 12;
            numSoThang.Value = 1;

            List<KhoaHoc> danhSachKhoaHoc = new List<KhoaHoc>()
            {
                new KhoaHoc("C# WinForms cơ bản", 800000),
                new KhoaHoc("SQL Server cơ bản", 700000),
                new KhoaHoc("Web Frontend cơ bản", 750000),
                new KhoaHoc("Lập trình Python cơ bản", 650000)
            };

            cboKhoaHoc.DataSource = danhSachKhoaHoc;
            cboKhoaHoc.SelectedIndex = 0;
            radOnline.Checked = true;
            CapNhatTongTien();
        }
        private void CapNhatTongTien()
        {
            if (cboKhoaHoc.SelectedItem != null)
            {
                KhoaHoc kh = (KhoaHoc)cboKhoaHoc.SelectedItem;
                decimal tongTien = kh.HocPhi * numSoThang.Value;
                lblTongTien.Text = string.Format("{0:N0} VNĐ", tongTien);
            }
        }
        private void cboKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatTongTien();
        }

        private void numSoThang_ValueChanged(object sender, EventArgs e)
        {
            CapNhatTongTien();
        }
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSoDienThoai.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return;
            }

            if (cboKhoaHoc.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn khóa học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboKhoaHoc.Focus();
                return;
            }
            KhoaHoc kh = (KhoaHoc)cboKhoaHoc.SelectedItem;
            string hinhThuc = radOnline.Checked ? "Online" : "Trực tiếp (Offline)";
            string nhanEmail = chkNhanEmail.Checked ? "Có" : "Không";
            decimal tongTien = kh.HocPhi * numSoThang.Value;

            string ketQua = "THÔNG TIN ĐĂNG KÝ KHÓA HỌC\n" +
                            "---------------------------\n" +
                            $"- Họ tên: {txtHoTen.Text.Trim()}\n" +
                            $"- Số điện thoại: {txtSoDienThoai.Text.Trim()}\n" +
                            $"- Ngày sinh: {dtpNgaySinh.Value:dd/MM/yyyy}\n" +
                            $"- Khóa học: {kh.TenKhoaHoc}\n" +
                            $"- Hình thức học: {hinhThuc}\n" +
                            $"- Số tháng: {numSoThang.Value}\n" +
                            $"- Nhận email thông báo: {nhanEmail}\n" +
                            "---------------------------\n" +
                            $"=> TỔNG TIỀN: {tongTien:N0} VNĐ";

            MessageBox.Show(ketQua, "Phiếu Đăng Ký", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtHoTen.Clear();
            txtSoDienThoai.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            chkNhanEmail.Checked = false;

            if (cboKhoaHoc.Items.Count > 0)
                cboKhoaHoc.SelectedIndex = 0;

            radOnline.Checked = true;
            numSoThang.Value = 1;

            txtHoTen.Focus();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?",
                                                  "Xác nhận thoát",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?",
                                                      "Xác nhận thoát",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}