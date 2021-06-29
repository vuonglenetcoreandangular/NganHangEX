using System;
using VAYTIENNHANH.Model.Helpers;

namespace VAYTIENNHANH.Model.DataModels.BaiViets
{
    public class BaiVietGridPortal
    {
        public long Id { get; set; }
        public string TenBaiViet { get; set; }
        public string Alias { get; set; }
        public DateTime NgayTao { get; set; }
        public string NgayTaoDisplay => NgayTao.ConvestDateVN();
        public string NoiDungNgan { get; set; }
        public string NoiDung { get; set; }
        public int? LuotXem { get; set; }
        public string HinhAnhUrl { get; set; }
    }
}