using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyNhanVien
{

    public class NhanVien
    {
        public string MaNV { get; set; }
        public string HoTen { get; set; }

        private double luongCoBan;
        public double LuongCoBan
        {
            get { return luongCoBan; }
            set
            {
                if (value >= 0) luongCoBan = value;
                else throw new ArgumentException("Lương cơ bản phải >= 0");
            }
        }

        public NhanVien(string maNV, string hoTen, double luongCoBan)
        {
            MaNV = maNV;
            HoTen = hoTen;
            LuongCoBan = luongCoBan;
        }

        public virtual double TinhLuong()
        {
            return LuongCoBan;
        }

        public virtual void HienThiThongTin()
        {
            Console.Write($"Mã NV: {MaNV,-6} | Họ tên: {HoTen,-18} | Lương CB: {LuongCoBan,-10:N0}");
        }
    }

    public class NhanVienVanPhong : NhanVien
    {
        private int soNgayLamViec;
        public int SoNgayLamViec
        {
            get { return soNgayLamViec; }
            set
            {
                if (value >= 0 && value <= 31) soNgayLamViec = value;
                else throw new ArgumentException("Số ngày làm việc phải từ 0 đến 31");
            }
        }

        public NhanVienVanPhong(string maNV, string hoTen, double luongCoBan, int soNgayLamViec)
            : base(maNV, hoTen, luongCoBan)
        {
            SoNgayLamViec = soNgayLamViec;
        }

        public override double TinhLuong()
        {
            return base.LuongCoBan + (SoNgayLamViec * 200000);
        }

        public override void HienThiThongTin()
        {
            base.HienThiThongTin();
            Console.WriteLine($" | Ngày làm: {SoNgayLamViec,-2} | TỔNG LƯƠNG: {TinhLuong():N0}");
        }
    }

    public class NhanVienKinhDoanh : NhanVien
    {
        private double doanhSo;
        public double DoanhSo
        {
            get { return doanhSo; }
            set
            {
                if (value >= 0) doanhSo = value;
                else throw new ArgumentException("Doanh số phải >= 0");
            }
        }

        public NhanVienKinhDoanh(string maNV, string hoTen, double luongCoBan, double doanhSo)
            : base(maNV, hoTen, luongCoBan)
        {
            DoanhSo = doanhSo;
        }

        public override double TinhLuong()
        {
            return base.LuongCoBan + (0.05 * DoanhSo);
        }

        public override void HienThiThongTin()
        {
            base.HienThiThongTin();
            Console.WriteLine($" | Doanh số: {DoanhSo,-10:N0} | TỔNG LƯƠNG: {TinhLuong():N0}");
        }
    }

    public class NhanVienThoiVu : NhanVien
    {
        public double SoGioLam { get; set; }
        public double LuongTheoGio { get; set; }

        public NhanVienThoiVu(string maNV, string hoTen, double soGioLam, double luongTheoGio)
            : base(maNV, hoTen, 0) // Nhân viên thời vụ không có lương cơ bản
        {
            SoGioLam = soGioLam;
            LuongTheoGio = luongTheoGio;
        }

        public override double TinhLuong()
        {
            return SoGioLam * LuongTheoGio;
        }

        public override void HienThiThongTin()
        {
            base.HienThiThongTin();
            Console.WriteLine($" | Giờ làm: {SoGioLam,-3} | Lương/giờ: {LuongTheoGio,-7:N0} | TỔNG LƯƠNG: {TinhLuong():N0}");
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            List<NhanVien> danhSach = new List<NhanVien>();

            danhSach.Add(new NhanVienVanPhong("VP01", "Nguyễn Văn A", 5000000, 24));
            danhSach.Add(new NhanVienVanPhong("VP02", "Trần Thị B", 6000000, 26));
            danhSach.Add(new NhanVienKinhDoanh("KD01", "Lê Văn C", 4500000, 150000000));
            danhSach.Add(new NhanVienKinhDoanh("KD02", "Phạm Thị D", 4000000, 200000000));
            danhSach.Add(new NhanVienThoiVu("TV01", "Hoàng Văn E", 120, 25000)); // Bonus

            int luaChon;
            do
            {
                Console.WriteLine("\n========== MENU ==========");
                Console.WriteLine("1. Xuất danh sách nhân viên");
                Console.WriteLine("2. Tìm nhân viên theo mã");
                Console.WriteLine("3. Tìm nhân viên có lương cao nhất");
                Console.WriteLine("4. Tính tổng lương công ty phải trả");
                Console.WriteLine("5. Nhập thêm nhân viên (Mở rộng)");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng: ");

                if (!int.TryParse(Console.ReadLine(), out luaChon)) continue;
                Console.WriteLine("--------------------------------------------------------------------------------------------------");

                switch (luaChon)
                {
                    case 1:
                        if (danhSach.Count == 0) Console.WriteLine("Danh sách trống!");
                        // TUYỆT ĐỐI KHÔNG DÙNG IF/SWITCH Ở ĐÂY - ĐÂY LÀ ĐA HÌNH
                        foreach (var nv in danhSach)
                        {
                            nv.HienThiThongTin();
                        }
                        break;

                    case 2:
                        Console.Write("Nhập mã nhân viên cần tìm: ");
                        string maTim = Console.ReadLine().Trim();
                        var nvTimDuoc = danhSach.FirstOrDefault(n => n.MaNV.Equals(maTim, StringComparison.OrdinalIgnoreCase));
                        if (nvTimDuoc != null) nvTimDuoc.HienThiThongTin();
                        else Console.WriteLine("Không tìm thấy nhân viên!");
                        break;

                    case 3:
                        if (danhSach.Count > 0)
                        {
                            // Thuật toán không thay đổi dù thêm NhanVienThoiVu
                            double maxLuong = danhSach.Max(n => n.TinhLuong());
                            var dsMax = danhSach.Where(n => n.TinhLuong() == maxLuong);
                            Console.WriteLine("Nhân viên có lương cao nhất:");
                            foreach (var nv in dsMax) nv.HienThiThongTin();
                        }
                        break;

                    case 4:
                        // Thuật toán tính tổng lương hoàn toàn độc lập với Class con
                        double tongLuong = danhSach.Sum(n => n.TinhLuong());
                        Console.WriteLine($"Tổng lương công ty phải trả: {tongLuong:N0} VNĐ");
                        break;

                    case 5:
                        NhapNhanVien(danhSach);
                        break;

                    case 0:
                        Console.WriteLine("Đang thoát chương trình...");
                        break;

                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;
                }
            } while (luaChon != 0);
        }

        static void NhapNhanVien(List<NhanVien> danhSach)
        {
            try
            {
                Console.WriteLine("1. NV Văn Phòng | 2. NV Kinh Doanh | 3. NV Thời Vụ");
                Console.Write("Chọn loại nhân viên muốn nhập: ");
                int loai = int.Parse(Console.ReadLine());

                Console.Write("Nhập mã NV: "); string ma = Console.ReadLine();
                Console.Write("Nhập họ tên: "); string ten = Console.ReadLine();

                if (loai == 1)
                {
                    Console.Write("Lương cơ bản: "); double lcb = double.Parse(Console.ReadLine());
                    Console.Write("Số ngày làm việc: "); int sn = int.Parse(Console.ReadLine());
                    danhSach.Add(new NhanVienVanPhong(ma, ten, lcb, sn));
                }
                else if (loai == 2)
                {
                    Console.Write("Lương cơ bản: "); double lcb = double.Parse(Console.ReadLine());
                    Console.Write("Doanh số: "); double ds = double.Parse(Console.ReadLine());
                    danhSach.Add(new NhanVienKinhDoanh(ma, ten, lcb, ds));
                }
                else if (loai == 3)
                {
                    Console.Write("Số giờ làm: "); double sg = double.Parse(Console.ReadLine());
                    Console.Write("Lương/giờ: "); double lg = double.Parse(Console.ReadLine());
                    danhSach.Add(new NhanVienThoiVu(ma, ten, sg, lg));
                }
                Console.WriteLine("=> Thêm thành công!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi nhập liệu: {ex.Message}");
            }
        }
    }
}