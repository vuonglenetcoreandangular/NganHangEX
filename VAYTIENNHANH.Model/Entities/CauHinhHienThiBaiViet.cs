using System.Collections.Generic;

namespace VAYTIENNHANH.Model.Entities
{
    public class CauHinhHienThiBaiViet : BaseEntity
    {
        public long? DanhMucId { get; set; }
        public long BaiVietId { get; set; }
        public int? ViTriHienThi { get; set; }
        public bool IsTrangChu { get; set; }
        public virtual BaiViet BaiViet { get; set; }
        public virtual DanhMucBaiViet DanhMucBaiViet { get; set; }
    }
}