using System;
using System.Collections.Generic;
using System.Text;
using VAYTIENNHANH.Model.Helpers;

namespace VAYTIENNHANH.Model.DataModels.BaiViets
{
    public class BaiVietDetailPortal
    {
        public long Id { get; set; }
        public string TenBaiViet { get; set; }
        public DateTime NgayTao { get; set; }
        public string NgayTaoDisplay => NgayTao.ConvestDateVN();
        public string NoiDung { get; set; }
        public bool HienThiAnh { get; set; }
        public int? LuotXem { get; set; }
        public string HinhAnhUrl { get; set; }
        //Nhân vật
        public long? NhanVatId { get; set; }
        public string TenNhanVat { get; set; }
        public string HinhAnhUrlNV { get; set; }
        public double DiemTanBao { get; set; }
        public double DiemNguyHiem { get; set; }
        public double DiemBeNgoai { get; set; }
    }
}
