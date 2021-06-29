using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VAYTIENNHANH.Data.Repository;
using VAYTIENNHANH.Model.DataModels.DanhMucBaiViets;
using VAYTIENNHANH.Model.Entities;

namespace VAYTIENNHANH.Service.Services.DanhMucBaiViets
{
    public class DanhMucBaiVietService : MasterBaseService<DanhMucBaiViet>, IDanhMucBaiVietService
    {
        private readonly IRepository<DanhMucBaiViet> _repository;

        public DanhMucBaiVietService(IRepository<DanhMucBaiViet> repository) : base(repository)
        {
            _repository = repository;
        }

        public List<DanhMucChaLookInfo> getDanhMucCha()
        {
            var data = _repository.TableNoTracking.Where(x => x.Id != 0).Select(s => new DanhMucChaLookInfo
            {
                Id = s.Id,
                Ten = s.Ten
            }).ToList();

            return data;

        }
        public List<DanhMucChaLookInfo> geAlltDanhMuc()
        {
            var data = _repository.TableNoTracking.Select(s => new DanhMucChaLookInfo
            {
                Id = s.Id,
                ViTriHienThi = s.ThuTuHienThi,
                ThuTuSapXep = s.ThuTuHienThi == null ? 99 : s.ThuTuHienThi,
                Ten = s.Ten
            }).OrderBy(x => x.ThuTuSapXep).ToList();

            return data;

        }

        public async Task<List<DanhMucBaiVietItem>> GetDanhMucHienThiMenu()
        {
            var data = await _repository.TableNoTracking.Where(x => x.HienThiMenu == true)
                .OrderBy(x => x.ThuTuHienThi)
                .Select(s => new DanhMucBaiVietItem
                {
                    DanhMucId = s.Id,
                    TenDanhMuc = s.Ten,
                    ThuTuHienThi = s.ThuTuHienThi.GetValueOrDefault(),
                    ThuTuSapXep = s.ThuTuHienThi == null ? 999 : s.ThuTuHienThi
                }).OrderBy(x => x.ThuTuSapXep).ToListAsync();

            return data;
        }

        public async Task<List<DanhMucBaiVietItem>> GetDanhMucKhongHienThiMenu()
        {
            var data = await _repository.TableNoTracking.Where(x => x.HienThiMenu != true)
                .OrderBy(x => x.ThuTuHienThi)
                .Select(s => new DanhMucBaiVietItem
                {
                    DanhMucId = s.Id,
                    TenDanhMuc = s.Ten,
                    ThuTuHienThi = s.ThuTuHienThi.GetValueOrDefault(),
                    ThuTuSapXep = s.ThuTuHienThi == null ? 999 : s.ThuTuHienThi
                }).OrderBy(x => x.ThuTuSapXep).ToListAsync();

            return data;
        }

    }
}