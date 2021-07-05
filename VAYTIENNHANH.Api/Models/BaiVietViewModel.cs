namespace VAYTIENNHANH.Api.Models
{
    public class BaiVietViewModel : BaseViewModel
    {
        public string Ten { get; set; }
        public string Alias { get; set; }
        public string HinhAnhBase64 { get; set; }
        public string NoiDungNgan { get; set; }
        public string NoiDung { get; set; }
        public int LuotXemAo { get; set; }
        public int LuotXem { get; set; }
        public bool HienThi { get; set; }
        public int ThuTuHienThi { get; set; }
        public long DanhMucId { get; set; }
        public string TenDanhMuc { get; set; }
    }
}