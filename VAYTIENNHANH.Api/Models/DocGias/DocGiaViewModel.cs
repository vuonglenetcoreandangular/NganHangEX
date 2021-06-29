namespace VAYTIENNHANH.Api.Models.DocGias
{
    public class DocGiaViewModel : BaseViewModel
    {
        public long FacebookId { get; set; }
        public long GoogleId { get; set; }
        public long ZaloId { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string TenDocGia { get; set; }
        public string Avatar { get; set; }
        public int LuotXemWeb { get; set; }
    }
}