namespace VAYTIENNHANH.Api.Models
{
    public class BaiVietViewModel : BaseViewModel
    {
        public string Ten { get; set; }
        public string Alias { get; set; }
        public string HinhAnhBase64 { get; set; }
        public string NoiDungNgan { get; set; }
        public string NoiDung { get; set; }
        public int? LuotXemAo { get; set; }
        public int? LuotXem { get; set; }
        public bool? HienThi { get; set; }
        public bool? HienThiAnh { get; set; }
        public int ThuTuHienThi { get; set; }
        public long DanhMucId { get; set; }
        public string TenDanhMuc { get; set; }

        public string TenNV { get; set; }
        public string HinhAnhBase64NV { get; set; }
        public string NoiDungNV { get; set; }
        public string NoiTaoDanhNV { get; set; }
        public int? DiemTanBao { get; set; }
        public int? DiemNguyHiem { get; set; }
        public int? DiemBeNgoai { get; set; }
    }
}