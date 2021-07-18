namespace VAYTIENNHANH.Model.Entities
{
    public class CamXucBaiViet : BaseEntity
    {
        public long DocGiaId { get; set; }
        public long BaiVietId { get; set; }
        public int? Liked { get; set; }
        public int? Cuoi { get; set; }
        public int? Gian { get; set; }
        public int? Buon { get; set; }

        public virtual DocGia DocGia { get; set; }
        public virtual BaiViet BaiViet { get; set; }
    }
}