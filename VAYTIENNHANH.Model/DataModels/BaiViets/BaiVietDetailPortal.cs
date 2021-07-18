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
        public string NoiDungTomTat { get; set; }
        public string NoiDung { get; set; }
        public bool HienThiAnh { get; set; }
        public int? LuotXem { get; set; }
        public string HinhAnhUrl { get; set; }
    }
}
