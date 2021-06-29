namespace VAYTIENNHANH.Model.Entities
{
    public class DiemToiPham : BaseEntity
    {
        public long ToiPhamId { get; set; }
        public long DocGiaId { get; set; }
        public int DiemTanBao { get; set; }
        public long DiemNguyHiem { get; set; }
        public long DiemBeNgoai { get; set; }
    }
}