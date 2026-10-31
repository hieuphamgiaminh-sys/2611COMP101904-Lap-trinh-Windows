using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace lab06
{
    public partial class FrmProduct : Form
    {
        private BindingList<Product> products = new BindingList<Product>();
        private BindingSource productSource = new BindingSource();
        private string selectedImagePath = string.Empty;

        public FrmProduct()
        {
            InitializeComponent();
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            cboLoaiSP.Items.AddRange(new object[] { "Điện tử", "Văn phòng", "Gia dụng", "Thời trang" });
            cboLoaiSP.SelectedIndex = 0;

            products.Add(new Product { MaSP = "SP01", TenSP = "Chuột không dây", LoaiSP = "Điện tử", DonGia = 150000, SoLuong = 20, NgayNhap = DateTime.Today, ConKinhDoanh = true });
            products.Add(new Product { MaSP = "SP02", TenSP = "Bút bi", LoaiSP = "Văn phòng", DonGia = 5000, SoLuong = 100, NgayNhap = DateTime.Today, ConKinhDoanh = true });

            productSource.DataSource = products;
            dgvProducts.AutoGenerateColumns = true;
            dgvProducts.DataSource = productSource;
            dgvProducts.Columns["MaSP"].HeaderText = "Mã SP";
            dgvProducts.Columns["TenSP"].HeaderText = "Tên SP";
            dgvProducts.Columns["LoaiSP"].HeaderText = "Loại SP";
            dgvProducts.Columns["DonGia"].HeaderText = "Đơn giá";
            dgvProducts.Columns["SoLuong"].HeaderText = "Số lượng";
            dgvProducts.Columns["NgayNhap"].HeaderText = "Ngày nhập";
            dgvProducts.Columns["ConKinhDoanh"].HeaderText = "Còn kinh doanh";
            dgvProducts.Columns["DuongDanAnh"].HeaderText = "Đường dẫn ảnh";
            dgvProducts.Columns["ThanhTien"].HeaderText = "Thành tiền";
            dgvProducts.ReadOnly = true;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.MultiSelect = false;
            dgvProducts.AllowUserToAddRows = false;
            UpdateStatus("Sẵn sàng");
        }
        private bool ValidateInput(bool isEdit = false)
        {
            errorProvider1.Clear();
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(txtMaSP.Text)) { errorProvider1.SetError(txtMaSP, "Mã SP không được rỗng"); isValid = false; }
            if (string.IsNullOrWhiteSpace(txtTenSP.Text)) { errorProvider1.SetError(txtTenSP, "Tên SP không được rỗng"); isValid = false; }
            if (numDonGia.Value <= 0) { errorProvider1.SetError(numDonGia, "Đơn giá phải > 0"); isValid = false; }
            if (dtpNgayNhap.Value.Date > DateTime.Today) { errorProvider1.SetError(dtpNgayNhap, "Ngày nhập không lớn hơn hôm nay"); isValid = false; }
            string ma = txtMaSP.Text.Trim();
            bool isDuplicate = products.Any(p => p.MaSP.Equals(ma, StringComparison.OrdinalIgnoreCase));
            if (!isEdit && isDuplicate) { errorProvider1.SetError(txtMaSP, "Mã sản phẩm đã tồn tại"); isValid = false; }
            return isValid;
        }
        private Product GetSelectedProduct()
        {
            if (productSource.Current == null)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            return productSource.Current as Product;
        }
        private void ClearInput()
        {
            txtMaSP.Clear(); txtTenSP.Clear(); cboLoaiSP.SelectedIndex = 0;
            numDonGia.Value = 1; numSoLuong.Value = 0; dtpNgayNhap.Value = DateTime.Today;
            chkConKinhDoanh.Checked = true; txtTimKiem.Clear(); picSanPham.Image = null;
            selectedImagePath = string.Empty; errorProvider1.Clear(); txtMaSP.Focus();
        }
        private void UpdateStatus(string message)
        {
            lblStatus.Text = $"{message} | Số sản phẩm: {products.Count}";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            Product p = new Product
            {
                MaSP = txtMaSP.Text.Trim(),
                TenSP = txtTenSP.Text.Trim(),
                LoaiSP = cboLoaiSP.Text,
                DonGia = numDonGia.Value,
                SoLuong = (int)numSoLuong.Value,
                NgayNhap = dtpNgayNhap.Value.Date,
                ConKinhDoanh = chkConKinhDoanh.Checked,
                DuongDanAnh = selectedImagePath
            };
            products.Add(p);
            ClearInput();
            UpdateStatus("Đã thêm sản phẩm mới");
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            Product p = GetSelectedProduct();
            if (p == null || !ValidateInput(isEdit: true)) return;

            p.TenSP = txtTenSP.Text.Trim(); p.LoaiSP = cboLoaiSP.Text; p.DonGia = numDonGia.Value;
            p.SoLuong = (int)numSoLuong.Value; p.NgayNhap = dtpNgayNhap.Value.Date;
            p.ConKinhDoanh = chkConKinhDoanh.Checked; p.DuongDanAnh = selectedImagePath;

            productSource.ResetBindings(false);
            UpdateStatus("Đã cập nhật sản phẩm");
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            Product p = GetSelectedProduct();
            if (p == null) return;

            if (MessageBox.Show($"Bạn có chắc muốn xóa {p.TenSP}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                products.Remove(p);
                ClearInput();
                UpdateStatus("Đã xóa sản phẩm");
            }
        }
        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Product p = productSource.Current as Product;
            if (p == null) return;

            txtMaSP.Text = p.MaSP; txtTenSP.Text = p.TenSP; cboLoaiSP.Text = p.LoaiSP;
            numDonGia.Value = p.DonGia; numSoLuong.Value = p.SoLuong; dtpNgayNhap.Value = p.NgayNhap;
            chkConKinhDoanh.Checked = p.ConKinhDoanh; selectedImagePath = p.DuongDanAnh;

            if (!string.IsNullOrWhiteSpace(p.DuongDanAnh) && File.Exists(p.DuongDanAnh))
                picSanPham.Image = Image.FromFile(p.DuongDanAnh);
            else picSanPham.Image = null;
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();
            var result = products.Where(p => p.MaSP.ToLower().Contains(keyword) || p.TenSP.ToLower().Contains(keyword)).ToList();
            dgvProducts.DataSource = result;
            lblStatus.Text = $"Tìm thấy {result.Count} sản phẩm";
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dgvProducts.DataSource = productSource;
            ClearInput();
            UpdateStatus("Đã làm mới dữ liệu");
        }
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog { Title = "Chọn ảnh", Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = dialog.FileName;
                    picSanPham.Image = Image.FromFile(selectedImagePath);
                    UpdateStatus("Đã chọn ảnh sản phẩm");
                }
            }
        }
        private void mnuFileExit_Click(object sender, EventArgs e) { Close(); }
        private void tsbThem_Click(object sender, EventArgs e) { btnThem.PerformClick(); }
        private void cmsXoa_Click(object sender, EventArgs e) { btnXoa.PerformClick(); }
        private void cmsChiTiet_Click(object sender, EventArgs e)
        {
            Product p = GetSelectedProduct();
            if (p == null) return;
            MessageBox.Show($"Mã: {p.MaSP}\nTên: {p.TenSP}\nLoại: {p.LoaiSP}\nTổng tiền: {p.ThanhTien:N0}", "Chi tiết", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}