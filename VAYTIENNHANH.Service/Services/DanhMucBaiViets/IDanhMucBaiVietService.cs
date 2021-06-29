using System.Collections.Generic;
using System.Threading.Tasks;
using VAYTIENNHANH.Model.DataModels.DanhMucBaiViets;
using VAYTIENNHANH.Model.Entities;

namespace VAYTIENNHANH.Service.Services.DanhMucBaiViets
{
    public interface IDanhMucBaiVietService : IMasterBaseService<DanhMucBaiViet>
    {
        public List<DanhMucChaLookInfo> getDanhMucCha();
        public List<DanhMucChaLookInfo> geAlltDanhMuc();
        public Task<List<DanhMucBaiVietItem>> GetDanhMucHienThiMenu();
        public Task<List<DanhMucBaiVietItem>> GetDanhMucKhongHienThiMenu();
        
    }
}
