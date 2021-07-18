using System.Collections.Generic;

namespace VAYTIENNHANH.Model.Entities
{
    public class DocGia : BaseEntity
    {
        public long? FacebookId { get; set; }
        public long? GoogleId { get; set; }
        public long? ZaloId { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string TenDocGia { get; set; }
        public string Avatar { get; set; }
        public int LuotXemWeb { get; set; }

        private ICollection<CamXucBaiViet> _camXucBaiViet;
        public virtual ICollection<CamXucBaiViet> CamXucBaiViets
        {
            get => _camXucBaiViet ??
                   (_camXucBaiViet = new List<CamXucBaiViet>());
            protected set => _camXucBaiViet = value;
        }
    }
}