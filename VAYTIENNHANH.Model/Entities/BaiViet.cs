using System.Collections.Generic;

namespace VAYTIENNHANH.Model.Entities
{
    public class BaiViet : BaseEntity
    {
        public string Ten { get; set; }
        public string Alias { get; set; }
        public string HinhAnh { get; set; }
        public string NoiDungNgan { get; set; }
        public string NoiDung { get; set; }
        public int? LuotXemAo { get; set; }
        public int? LuotXem { get; set; }
        public bool? HienThi { get; set; }
        public bool? HienThiAnh { get; set; }
        public int ThuTuHienThi { get; set; }
        public long DanhMucId { get; set; }
        public long? NhanVatId { get; set; }
        public bool? Deleted { get; set; }
        public virtual DanhMucBaiViet DanhMucBaiViet { get; set; }
      
        private ICollection<CauHinhHienThiBaiViet> _cauHinhHienThiBaiViets;
        public virtual ICollection<CauHinhHienThiBaiViet> CauHinhHienThiBaiViets
        {
            get => _cauHinhHienThiBaiViets ??
                   (_cauHinhHienThiBaiViets = new List<CauHinhHienThiBaiViet>());
            protected set => _cauHinhHienThiBaiViets = value;
        }

        private ICollection<BaiVietHinhAnh> _baiVietHinhAnh;
        public virtual ICollection<BaiVietHinhAnh> BaiVietHinhAnhs
        {
            get => _baiVietHinhAnh ??
                   (_baiVietHinhAnh = new List<BaiVietHinhAnh>());
            protected set => _baiVietHinhAnh = value;
        }

        public virtual NhanVat NhanVat { get; set; }
    }
}