namespace VAYTIENNHANH.Model.Entities
{
    public class ToiPham : BaseEntity
    {
        public string Ten { get; set; }
        public string ToiDanh { get; set; }
        public string NoiGayAn { get; set; }
        public long BaiVietId { get; set; }
        public string HinhAnh { get; set; }
        public int ThuTuHienThi { get; set; }
    }
}