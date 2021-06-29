namespace VAYTIENNHANH.Model.Entities
{
    public class BaiVietHinhAnh : BaseEntity
    {
        public long BaiVietId { get; set; }
        public long HinhAnhId { get; set; }

        public virtual BaiViet BaiViet { get; set; }
        public virtual HinhAnh HinhAnh { get; set; }
    }
}