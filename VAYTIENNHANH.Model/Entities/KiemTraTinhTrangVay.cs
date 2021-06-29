namespace VAYTIENNHANH.Model.Entities
{
    public class KiemTraTinhTrangVay : BaseEntity
    {
        public string TenKhachHang { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public decimal TongNoDangVayHangThang { get; set; }
        public string TenCongTy { get; set; }
        public string CongViec { get; set; }
        public decimal ThuNhap { get; set; }
    }
}