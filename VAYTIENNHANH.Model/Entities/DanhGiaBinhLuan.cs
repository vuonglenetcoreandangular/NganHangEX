namespace VAYTIENNHANH.Model.Entities
{
    public class DanhGiaBinhLuan : BaseEntity
    {
        public long DocGiaId { get; set; }
        public long BinhLuanId { get; set; }
        public int Like { get; set; }
        public int Gian { get; set; }
        public int Cuoi { get; set; }
        public int Ghet { get; set; }
    }
}