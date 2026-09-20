using System;

namespace Lab03_QuanLySinhVienOOP
{
    public class Nguoi
    {
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }

        public Nguoi(string hoTen, DateTime ngaySinh)
        {
            HoTen = hoTen;
            NgaySinh = ngaySinh;
        }

        public virtual void LayThongTin()
        {
            Console.Write($"Họ tên: {HoTen,-20} | Ngày sinh: {NgaySinh.ToString("dd/MM/yyyy"),-12}");
        }
    }
}