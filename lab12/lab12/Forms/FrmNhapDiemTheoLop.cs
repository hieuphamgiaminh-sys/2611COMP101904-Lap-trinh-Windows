using System;
using System.Data;
using System.Windows.Forms;
using lab12.DAL;

namespace lab12.Forms
{
    public partial class FrmNhapDiemTheoLop : Form
    {
        private readonly KetQuaDAL ketQuaDAL = new KetQuaDAL();
        private readonly BindingSource ketQuaSource = new BindingSource();

        public FrmNhapDiemTheoLop()
        {
            InitializeComponent();
        }

        private void FrmNhapDiemTheoLop_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            dgvKetQua.AutoGenerateColumns = true;
            dgvKetQua.DataSource = ketQuaSource;
        }

        private void LoadComboBox()
        {
            cboLop.DataSource = ketQuaDAL.GetLop();
            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "MaLop";

            cboMonHoc.DataSource = ketQuaDAL.GetMonHoc();
            cboMonHoc.DisplayMember = "TenMon";
            cboMonHoc.ValueMember = "MaMon";
        }

        private void btnTaiDanhSach_Click(object sender, EventArgs e)
        {
            string maLop = cboLop.SelectedValue?.ToString() ?? "";
            string maMon = cboMonHoc.SelectedValue?.ToString() ?? "";

            if (string.IsNullOrEmpty(maLop) || string.IsNullOrEmpty(maMon))
            {
                MessageBox.Show("Vui lòng chọn lớp và môn học.");
                return;
            }

            DataTable table = ketQuaDAL.GetKetQuaByLopMon(maLop, maMon);
            ketQuaSource.DataSource = table;

            if (dgvKetQua.Columns["MaSV"] != null) dgvKetQua.Columns["MaSV"].ReadOnly = true;
            if (dgvKetQua.Columns["HoTen"] != null) dgvKetQua.Columns["HoTen"].ReadOnly = true;
        }

        private void btnLuuTatCa_Click(object sender, EventArgs e)
        {
            try
            {
                ketQuaSource.EndEdit();
                DataTable table = (DataTable)ketQuaSource.DataSource;
                if (table == null || table.Rows.Count == 0) return;

                ValidateData(table);

                string maMon = cboMonHoc.SelectedValue?.ToString() ?? "";
                int count = ketQuaDAL.SaveAll(maMon, table);

                MessageBox.Show($"Đã lưu thành công {count} dòng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể lưu dữ liệu (Toàn bộ đã được Rollback):\n\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidateData(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                string maSV = row["MaSV"].ToString() ?? "";
                string diemText = row["Diem"].ToString() ?? "";

                if (string.IsNullOrWhiteSpace(diemText))
                    throw new Exception($"Điểm của sinh viên {maSV} không được để trống.");

                if (!double.TryParse(diemText, out double diem))
                    throw new Exception($"Điểm của sinh viên {maSV} không hợp lệ (Phải là số).");

                if (diem < 0 || diem > 10)
                    throw new Exception($"Điểm của sinh viên {maSV} phải từ 0 đến 10.");
            }
        }
    }
}