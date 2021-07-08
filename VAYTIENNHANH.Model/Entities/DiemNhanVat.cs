namespace VAYTIENNHANH.Model.Entities
{
    public class DiemNhanVat : BaseEntity
    {
        public long NhanVatId { get; set; }
        public long DocGiaId { get; set; }
        public int DiemTanBao { get; set; }
        public long DiemNguyHiem { get; set; }
        public long DiemBeNgoai { get; set; }
        public virtual NhanVat NhanVat { get; set; }
    }
}