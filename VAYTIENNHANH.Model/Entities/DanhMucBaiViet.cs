using System.Collections.Generic;

namespace VAYTIENNHANH.Model.Entities
{
    public class DanhMucBaiViet : BaseEntity
    {
        public long DanhMucChaId { get; set; }
        public string Ten { get; set; }
        public string Alias { get; set; }
        public bool? HienThiMenu { get; set; }
        public int? ThuTuHienThi { get; set; }
        public string Logo { get; set; }

        //public virtual List<BaiViet> BaiViets { get; set; }
        private ICollection<BaiViet> _baiViets;
        public virtual ICollection<BaiViet> BaiViets
        {
            get => _baiViets ??
                   (_baiViets = new List<BaiViet>());
            protected set => _baiViets = value;
        }
        private ICollection<CauHinhHienThiBaiViet> _cauHinhHienThiBaiViets;
        public virtual ICollection<CauHinhHienThiBaiViet> CauHinhHienThiBaiViets
        {
            get => _cauHinhHienThiBaiViets ??
                   (_cauHinhHienThiBaiViets = new List<CauHinhHienThiBaiViet>());
            protected set => _cauHinhHienThiBaiViets = value;
        }
    }
}