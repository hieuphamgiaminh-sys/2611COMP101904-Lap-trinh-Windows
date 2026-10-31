namespace lab05
{
    public class KhoaHoc
    {
        public string TenKhoaHoc { get; set; }
        public decimal HocPhi { get; set; }
        public KhoaHoc(string tenKhoaHoc, decimal hocPhi)
        {
            TenKhoaHoc = tenKhoaHoc;
            HocPhi = hocPhi;
        }
        public override string ToString()
        {
            return TenKhoaHoc;
        }
    }
}