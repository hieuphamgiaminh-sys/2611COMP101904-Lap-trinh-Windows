using System;
using System.Collections.Generic;
using System.Text;

namespace Lab03_QuanLySinhVienOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            QuanLySinhVien qlsv = new QuanLySinhVien();
            int luaChon;

            do
            {
                HienThiMenu();
                luaChon = NhapSoNguyen("Chọn chức năng: ");
                Console.WriteLine();

                switch (luaChon)
                {
                    case 1:
                        ThemSinhVien(qlsv);
                        break;
                    case 2:
                        InDanhSach(qlsv.LayDanhSach(), "DANH SÁCH TẤT CẢ SINH VIÊN");
                        break;
                    case 3:
                        TimSinhVienTheoMa(qlsv);
                        break;
                    case 4:
                        TimSinhVienTheoTen(qlsv);
                        break;
                    case 5:
                        SuaDiemSinhVien(qlsv);
                        break;
                    case 6:
                        XoaSinhVien(qlsv);
                        break;
                    case 7:
                        InDanhSach(qlsv.SapXepTheoDiemGiamDan(), "DANH SÁCH SẮP XẾP ĐIỂM GIẢM DẦN");
                        break;
                    case 8:
                        InDanhSach(qlsv.LocSinhVienDat(), "DANH SÁCH SINH VIÊN ĐẠT (ĐIỂM >= 5)");
                        break;
                    case 0:
                        Console.WriteLine("Đang thoát chương trình. Tạm biệt!");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng nhập lại!");
                        break;
                }
                Console.WriteLine("\n----------------------------------------------------");
            } while (luaChon != 0);
        }

        static void HienThiMenu()
        {
            Console.WriteLine("===== QUAN LY SINH VIEN =====");
            Console.WriteLine("1. Thêm sinh viên");
            Console.WriteLine("2. Xuất danh sách");
            Console.WriteLine("3. Tìm sinh viên theo mã");
            Console.WriteLine("4. Tìm sinh viên theo tên");
            Console.WriteLine("5. Sửa điểm trung bình");
            Console.WriteLine("6. Xóa sinh viên");
            Console.WriteLine("7. Sắp xếp theo điểm giảm dần");
            Console.WriteLine("8. Lọc sinh viên đạt");
            Console.WriteLine("0. Thoát");
        }

        // --- CÁC HÀM XỬ LÝ GỌI TỪ MENU ---
        static void ThemSinhVien(QuanLySinhVien qlsv)
        {
            Console.Write("Nhập mã sinh viên: ");
            string ma = Console.ReadLine().Trim();
            Console.Write("Nhập họ tên: ");
            string ten = Console.ReadLine().Trim();

            DateTime ngaySinh = NhapNgaySinh("Nhập ngày sinh (dd/MM/yyyy): ");

            Console.Write("Nhập mã lớp: ");
            string lop = Console.ReadLine().Trim();

            double diem = NhapDiem("Nhập điểm trung bình (0-10): ");

            try
            {
                SinhVien sv = new SinhVien(ma, ten, ngaySinh, lop, diem);
                if (qlsv.Them(sv))
                    Console.WriteLine("=> Thêm sinh viên thành công!");
                else
                    Console.WriteLine("=> Lỗi: Mã sinh viên đã tồn tại!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"=> Lỗi tạo sinh viên: {ex.Message}");
            }
        }

        static void InDanhSach(List<SinhVien> danhSach, string thongDiep)
        {
            Console.WriteLine($"--- {thongDiep} ---");
            if (danhSach.Count == 0)
            {
                Console.WriteLine("Danh sách trống!");
                return;
            }
            foreach (var sv in danhSach)
            {
                sv.LayThongTin();
            }
        }

        static void TimSinhVienTheoMa(QuanLySinhVien qlsv)
        {
            Console.Write("Nhập mã sinh viên cần tìm: ");
            string ma = Console.ReadLine().Trim();
            var sv = qlsv.TimTheoMa(ma);
            if (sv != null)
            {
                Console.WriteLine("=> Đã tìm thấy:");
                sv.LayThongTin();
            }
            else
            {
                Console.WriteLine("=> Không tìm thấy sinh viên có mã này.");
            }
        }

        static void TimSinhVienTheoTen(QuanLySinhVien qlsv)
        {
            Console.Write("Nhập từ khóa tên cần tìm: ");
            string tuKhoa = Console.ReadLine().Trim();
            var kq = qlsv.TimTheoTen(tuKhoa);
            InDanhSach(kq, $"KẾT QUẢ TÌM KIẾM THEO TỪ KHÓA '{tuKhoa}'");
        }

        static void SuaDiemSinhVien(QuanLySinhVien qlsv)
        {
            Console.Write("Nhập mã sinh viên cần sửa điểm: ");
            string ma = Console.ReadLine().Trim();
            double diemMoi = NhapDiem("Nhập điểm trung bình mới (0-10): ");

            if (qlsv.SuaDiem(ma, diemMoi))
                Console.WriteLine("=> Cập nhật điểm thành công!");
            else
                Console.WriteLine("=> Không tìm thấy sinh viên có mã này.");
        }

        static void XoaSinhVien(QuanLySinhVien qlsv)
        {
            Console.Write("Nhập mã sinh viên cần xóa: ");
            string ma = Console.ReadLine().Trim();
            if (qlsv.Xoa(ma))
                Console.WriteLine("=> Đã xóa sinh viên thành công!");
            else
                Console.WriteLine("=> Không tìm thấy sinh viên có mã này để xóa.");
        }

        static int NhapSoNguyen(string thongDiep)
        {
            int ketQua;
            while (true)
            {
                Console.Write(thongDiep);
                if (int.TryParse(Console.ReadLine(), out ketQua)) return ketQua;
                Console.WriteLine("Lỗi: Vui lòng nhập số nguyên hợp lệ!");
            }
        }

        static double NhapDiem(string thongDiep)
        {
            double diem;
            while (true)
            {
                Console.Write(thongDiep);
                if (double.TryParse(Console.ReadLine(), out diem) && diem >= 0 && diem <= 10) return diem;
                Console.WriteLine("Lỗi: Điểm phải là số thực từ 0 đến 10!");
            }
        }

        static DateTime NhapNgaySinh(string thongDiep)
        {
            DateTime ngay;
            while (true)
            {
                Console.Write(thongDiep);
                if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out ngay))
                {
                    return ngay;
                }
                Console.WriteLine("Lỗi: Nhập sai định dạng. Vui lòng nhập theo định dạng dd/MM/yyyy (VD: 03/09/2007)!");
            }
        }
    }
}