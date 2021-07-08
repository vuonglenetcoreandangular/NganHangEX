using System.Collections.Generic;

namespace VAYTIENNHANH.Model.Entities
{
    public class NhanVat : BaseEntity
    {
        public string Ten { get; set; }
        public string DanhVong { get; set; }
        public string NoiTaoDanhVong { get; set; }
        public string HinhAnh { get; set; }
        public int? ThuTuHienThi { get; set; }

        private ICollection<BaiViet> _baiViets;
        public virtual ICollection<BaiViet> BaiViets
        {
            get => _baiViets ??
                   (_baiViets = new List<BaiViet>());
            protected set => _baiViets = value;
        }

        private ICollection<DiemNhanVat> _diemNhanVats;
        public virtual ICollection<DiemNhanVat> DiemNhanVats
        {
            get => _diemNhanVats ??
                   (_diemNhanVats = new List<DiemNhanVat>());
            protected set => _diemNhanVats = value;
        }
    }
}