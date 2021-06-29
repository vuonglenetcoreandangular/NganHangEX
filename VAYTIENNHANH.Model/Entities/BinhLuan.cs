namespace VAYTIENNHANH.Model.Entities
{
    public class BinhLuan : BaseEntity
    {
        public long BinhLuanChaId { get; set; }
        public long BaiVietId { get; set; }
        public string TenNguoiBinhLuanChinh { get; set; }
        public string NoiDungBinhLuan { get; set; }
        public bool HienThi { get; set; }
    }
}