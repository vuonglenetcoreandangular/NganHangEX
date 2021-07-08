namespace VAYTIENNHANH.Model.Entities
{
    public class DanhGiaNhanVat : BaseEntity
    {
        public long NhanVatId { get; set; }
        public long DocGiaId { get; set; }
        public int Like { get; set; }
        public int Gian { get; set; }
        public int Cuoi { get; set; }
        public int Ghet { get; set; }
    }
}