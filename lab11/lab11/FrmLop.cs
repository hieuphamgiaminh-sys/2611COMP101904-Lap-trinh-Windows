using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace lab11
{
    public partial class FrmLop : Form
    {
        private readonly string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EduManagerDB;Integrated Security=True;TrustServerCertificate=True";

        public FrmLop()
        {
            InitializeComponent();
        }
        private void FrmLop_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                string sql = @"SELECT l.MaLop, l.TenLop, COUNT(sv.MaSV) AS SoSinhVien 
                               FROM LOP l 
                               LEFT JOIN SINHVIEN sv ON l.MaLop = sv.MaLop 
                               GROUP BY l.MaLop, l.TenLop 
                               ORDER BY l.MaLop";
                using SqlConnection conn = new SqlConnection(connectionString);
                using SqlCommand cmd = new SqlCommand(sql, conn);
                using SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvLop.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
            }
        }
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaLop.Text))
            {
                MessageBox.Show("Vui lòng nhập mã lớp");
                txtMaLop.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTenLop.Text))
            {
                MessageBox.Show("Vui lòng nhập tên lớp");
                txtTenLop.Focus();
                return false;
            }
            return true;
        }
        private bool IsMaLopExists(string maLop)
        {
            string sql = "SELECT COUNT(*) FROM LOP WHERE MaLop = @ma";
            using SqlConnection conn = new SqlConnection(connectionString);
            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ma", maLop);
            conn.Open();
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count > 0;
        }
        private int CountSinhVienByLop(string maLop)
        {
            string sql = "SELECT COUNT(*) FROM SINHVIEN WHERE MaLop = @ma";
            using SqlConnection conn = new SqlConnection(connectionString);
            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ma", maLop);
            conn.Open();
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            string ma = txtMaLop.Text.Trim();
            string ten = txtTenLop.Text.Trim();
            try
            {
                if (IsMaLopExists(ma))
                {
                    MessageBox.Show("Mã lớp đã tồn tại");
                    return;
                }
                string sql = "INSERT INTO LOP(MaLop, TenLop) VALUES(@ma, @ten)";
                using SqlConnection conn = new SqlConnection(connectionString);
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", ma);
                cmd.Parameters.AddWithValue("@ten", ten);
                conn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Thêm lớp thành công");
                    LoadData();
                    ClearInput();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm lớp: " + ex.Message);
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            string ma = txtMaLop.Text.Trim();
            string ten = txtTenLop.Text.Trim();
            try
            {
                string sql = "UPDATE LOP SET TenLop = @ten WHERE MaLop = @ma";
                using SqlConnection conn = new SqlConnection(connectionString);
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", ma);
                cmd.Parameters.AddWithValue("@ten", ten);
                conn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Cập nhật lớp thành công");
                    LoadData();
                    ClearInput();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy lớp cần sửa");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message);
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtMaLop.Text.Trim();
            if (string.IsNullOrWhiteSpace(ma))
            {
                MessageBox.Show("Vui lòng chọn lớp cần xóa");
                return;
            }
            try
            {
                if (CountSinhVienByLop(ma) > 0)
                {
                    MessageBox.Show("Không thể xóa lớp đang có sinh viên");
                    return;
                }

                if (MessageBox.Show("Bạn có chắc muốn xóa lớp này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

                string sql = "DELETE FROM LOP WHERE MaLop = @ma";
                using SqlConnection conn = new SqlConnection(connectionString);
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", ma);
                conn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Xóa lớp thành công");
                    LoadData();
                    ClearInput();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa lớp: " + ex.Message);
            }
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTimKiem.Text.Trim();
                string sql = @"SELECT l.MaLop, l.TenLop, COUNT(sv.MaSV) AS SoSinhVien 
                               FROM LOP l 
                               LEFT JOIN SINHVIEN sv ON l.MaLop = sv.MaLop 
                               WHERE l.MaLop LIKE @kw OR l.TenLop LIKE @kw 
                               GROUP BY l.MaLop, l.TenLop 
                               ORDER BY l.MaLop";
                using SqlConnection conn = new SqlConnection(connectionString);
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                using SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvLop.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInput();
            LoadData();
        }
        private void dgvLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvLop.Rows[e.RowIndex];
            txtMaLop.Text = row.Cells["MaLop"].Value != null ? row.Cells["MaLop"].Value.ToString() : string.Empty;
            txtTenLop.Text = row.Cells["TenLop"].Value != null ? row.Cells["TenLop"].Value.ToString() : string.Empty;
        }
        private void ClearInput()
        {
            txtMaLop.Clear();
            txtTenLop.Clear();
            txtTimKiem.Clear();
            txtMaLop.Focus();
        }
    }
}