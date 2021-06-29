namespace VAYTIENNHANH.Api.Models
{
    public class DanhMucBaiVietViewModel : BaseViewModel
    {
        public long DanhMucChaId { get; set; }
        public string TenDanhMucCha { get; set; }
        public string Ten { get; set; }
        public string Alias { get; set; }
        public bool HienThiMenu { get; set; }
        public int ThuTuHienThi { get; set; }
        public string Logo { get; set; }
    }
}