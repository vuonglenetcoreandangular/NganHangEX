using System.Collections.Generic;

namespace VAYTIENNHANH.Model.Entities
{
    public class HinhAnh : BaseEntity
    {
        public string TenHinhAnh { get; set; }
        public string HinhAnhUrl { get; set; }

        private ICollection<BaiVietHinhAnh> _baiVietHinhAnh;

        public virtual ICollection<BaiVietHinhAnh> BaiVietHinhAnhs
        {
            get => _baiVietHinhAnh ??
                   (_baiVietHinhAnh = new List<BaiVietHinhAnh>());
            protected set => _baiVietHinhAnh = value;
        }
    }
}