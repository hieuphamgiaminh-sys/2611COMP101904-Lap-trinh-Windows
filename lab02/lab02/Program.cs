using System;

namespace Lab02_QuanLyMang
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] a = null; 
            int luachon;

            do
            {
                HienThiMenu();
                luachon = NhapSoNguyen("Chon chuc nang: ");
                Console.WriteLine();
                if (luachon >= 2 && luachon <= 7 && a == null)
                {
                    Console.WriteLine("Ban chua nhap mang! Vui long chon 1 de nhap mang truoc.");
                    Console.WriteLine("-------------------------");
                    continue;
                }

                switch (luachon)
                {
                    case 1:
                        a = NhapMang();
                        Console.WriteLine("Da nhap mang thanh cong!");
                        break;
                    case 2:
                        XuatMang(a);
                        break;
                    case 3:
                        Console.WriteLine($"Tong cac phan tu trong mang = {TinhTong(a)}");
                        break;
                    case 4:
                        Console.WriteLine($"Gia tri Max = {TimMax(a)}");
                        Console.WriteLine($"Gia tri Min = {TimMin(a)}");
                        break;
                    case 5:
                        Console.WriteLine($"So luong phan tu chan = {DemChan(a)}");
                        Console.WriteLine($"So luong phan tu le = {DemLe(a)}");
                        break;
                    case 6:
                        SapXepTangDan(a);
                        Console.WriteLine("Mang sau khi sap xep tang dan:");
                        XuatMang(a);
                        break;
                    case 7:
                        int x = NhapSoNguyen("Nhap gia tri x can tim: ");
                        int viTri = TimKiem(a, x);
                        if (viTri != -1)
                            Console.WriteLine($"Tim thay {x} tai vi tri dau tien la {viTri} (tinh tu 0).");
                        else
                            Console.WriteLine($"Khong tim thay {x} trong mang.");
                        break;
                    case 0:
                        Console.WriteLine("Dang thoat chuong trinh. Tam biet!");
                        break;
                    default:
                        Console.WriteLine("Lựa chon khong hop le. Vui long chon tu 0 den 7.");
                        break;
                }
                Console.WriteLine("-------------------------");

            } while (luachon != 0);
        }

        static void HienThiMenu()
        {
            Console.WriteLine("===== MENU =====");
            Console.WriteLine("1. Nhap mang");
            Console.WriteLine("2. Xuat mang");
            Console.WriteLine("3. Tinh tong");
            Console.WriteLine("4. Tim max/min");
            Console.WriteLine("5. Dem chan/le");
            Console.WriteLine("6. Sap xep tang dan");
            Console.WriteLine("7. Tim kiem");
            Console.WriteLine("0. Thoat");
        }
        static int NhapSoNguyen(string message)
        {
            int result;
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out result))
                {
                    return result;
                }
                Console.WriteLine("Loi: Vui long nhap mot so nguyen hop le!");
            }
        }
        static int NhapSoNguyenDuong(string message)
        {
            int result;
            do
            {
                result = NhapSoNguyen(message);
                if (result <= 0)
                {
                    Console.WriteLine("Loi: So luong n phai la so nguyen duong (> 0). Vui long nhap lai.");
                }
            } while (result <= 0);
            return result;
        }

        static int[] NhapMang()
        {
            int n = NhapSoNguyenDuong("Nhap so luong phan tu n: ");
            int[] mangThongSo = new int[n];
            for (int i = 0; i < n; i++)
            {
                mangThongSo[i] = NhapSoNguyen($"Nhap phan tu thu {i}: ");
            }
            return mangThongSo;
        }

        static void XuatMang(int[] a)
        {
            Console.Write("Cac phan tu cua mang: ");
            foreach (int item in a)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        static int TinhTong(int[] a)
        {
            int sum = 0;
            foreach (int item in a)
            {
                sum += item;
            }
            return sum;
        }

        static int TimMax(int[] a)
        {
            int max = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] > max) max = a[i];
            }
            return max;
        }

        static int TimMin(int[] a)
        {
            int min = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] < min) min = a[i];
            }
            return min;
        }

        static int DemChan(int[] a)
        {
            int count = 0;
            foreach (int item in a)
            {
                if (item % 2 == 0) count++;
            }
            return count;
        }

        static int DemLe(int[] a)
        {
            int count = 0;
            foreach (int item in a)
            {
                if (item % 2 != 0) count++;
            }
            return count;
        }

        static void SapXepTangDan(int[] a)
        {
            Array.Sort(a);
        }

        static int TimKiem(int[] a, int x)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == x) return i;
            }
            return -1;
        }
    }
}