using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab03_QuanLySinhVienOOP
{
    public class QuanLySinhVien
    {
        private List<SinhVien> danhSach;

        public QuanLySinhVien()
        {
            danhSach = new List<SinhVien>();
        }

        public bool Them(SinhVien sv)
        {
            if (danhSach.Any(s => s.MaSinhVien.Equals(sv.MaSinhVien, StringComparison.OrdinalIgnoreCase)))
            {
                return false; // Trùng mã
            }
            danhSach.Add(sv);
            return true;
        }

        public List<SinhVien> LayDanhSach()
        {
            return danhSach;
        }

        // 3. Tìm sinh viên theo mã (Dùng LINQ)
        public SinhVien TimTheoMa(string maSV)
        {
            return danhSach.FirstOrDefault(s => s.MaSinhVien.Equals(maSV, StringComparison.OrdinalIgnoreCase));
        }

        public List<SinhVien> TimTheoTen(string tuKhoa)
        {
            return danhSach.Where(s => s.HoTen.ToLower().Contains(tuKhoa.ToLower())).ToList();
        }

        public bool SuaDiem(string maSV, double diemMoi)
        {
            var sv = TimTheoMa(maSV);
            if (sv != null)
            {
                sv.DiemTrungBinh = diemMoi;
                return true;
            }
            return false;
        }

        public bool Xoa(string maSV)
        {
            var sv = TimTheoMa(maSV);
            if (sv != null)
            {
                danhSach.Remove(sv);
                return true;
            }
            return false;
        }

        public List<SinhVien> SapXepTheoDiemGiamDan()
        {
            return danhSach.OrderByDescending(s => s.DiemTrungBinh).ToList();
        }

        // 8. Lọc sinh viên Đạt (Dùng LINQ)
        public List<SinhVien> LocSinhVienDat()
        {
            return danhSach.Where(s => s.DiemTrungBinh >= 5.0).ToList();
        }
    }
}