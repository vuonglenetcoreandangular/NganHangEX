using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAYTIENNHANH.Data.Repository;
using VAYTIENNHANH.Model.DataModels;
using VAYTIENNHANH.Model.DataModels.BaiViets;
using VAYTIENNHANH.Model.Entities;
using VAYTIENNHANH.Service.Helpers;

namespace VAYTIENNHANH.Service.Services.BaiViets
{
    public class BaiVietService : MasterBaseService<BaiViet>, IBaiVietService
    {
        private readonly IRepository<BaiViet> _repository;
        private readonly IRepository<CauHinhHienThiBaiViet> _cauHinhHienThiBaiVietRepository;

        public BaiVietService(IRepository<BaiViet> repository,
             IRepository<CauHinhHienThiBaiViet> cauHinhHienThiBaiVietRepository) : base(repository)
        {
            _repository = repository;
            _cauHinhHienThiBaiVietRepository = cauHinhHienThiBaiVietRepository;
        }

        public async Task<int> countTongSoBaiViet()
        {
            var tongSoBaiViet = _repository.TableNoTracking.Where(x => x.Deleted != true).Select(x => x.Id);
            return await tongSoBaiViet.CountAsync();
        }

        public async Task<BaiVietDetailPortal> GetBaiVietDetail(long baiVietId)
        {
            var data = _repository.TableNoTracking.Include(s => s.NhanVat).ThenInclude(s => s.DiemNhanVats).Select(s => new BaiVietDetailPortal
            {
                Id = s.Id,
                TenBaiViet = s.Ten,
                NoiDung = s.NoiDung,
                HienThiAnh = s.HienThiAnh.GetValueOrDefault(),
                HinhAnhUrl = s.HinhAnh,
                LuotXem = s.LuotXem,
                NgayTao = s.CreatedOn,
                NhanVatId = s.NhanVatId != null ? s.NhanVatId : 0,
                TenNhanVat = s.NhanVatId != null ? s.NhanVat.Ten : "",
                NoiDungNV = s.NhanVatId != null ? s.NhanVat.DanhVong : "",
                DiaDiemNV = s.NhanVatId != null ? s.NhanVat.NoiTaoDanhVong : "",
                HinhAnhUrlNV = s.NhanVatId != null ? s.NhanVat.HinhAnh : "",
                DiemTanBao = s.NhanVatId != null ? s.NhanVat.DiemNhanVats.Average(x => x.DiemNguyHiem) : 0,
                DiemNguyHiem = s.NhanVatId != null ? s.NhanVat.DiemNhanVats.Average(x => x.DiemTanBao) : 0,
                DiemBeNgoai = s.NhanVatId != null ? s.NhanVat.DiemNhanVats.Average(x => x.DiemBeNgoai) : 0
            }).FirstOrDefault(x => x.Id == baiVietId);

            return data;
        }

        public async Task<List<CauHinhHienThiBaiVIetVo>> GetBaiVietHienThi(long danhMucId, int viTriBaiViet)
        {
            int sobanGhi = 0;
            switch (viTriBaiViet)
            {
                case 1:
                    sobanGhi = 1;
                    break;
                case 2:
                    sobanGhi = 2;
                    break;
                case 3:
                    sobanGhi = 2;
                    break;
                case 4:
                    sobanGhi = 4;
                    break;
            }

            if (danhMucId == 0)
            {
                var dataHome = await _cauHinhHienThiBaiVietRepository.TableNoTracking
                .Where(x => x.DanhMucId == null && x.ViTriHienThi == viTriBaiViet)
                .Select(s => new CauHinhHienThiBaiVIetVo
                {
                    Id = s.Id,
                    BaiVIetId = s.BaiVietId,
                    Ten = s.BaiViet.Ten.Length <= 30 ? s.BaiViet.Ten : s.BaiViet.Ten.Substring(0, 27) + "...",
                    CreatedOn = s.BaiViet.CreatedOn,
                    CreatedOnDisplay = s.BaiViet.CreatedOn.ToString("dd-MM/yyyy")
                }).Take(sobanGhi).ToListAsync();

                return dataHome;
            }
            var data = await _cauHinhHienThiBaiVietRepository.TableNoTracking
                .Where(x => x.DanhMucId == danhMucId && x.ViTriHienThi == viTriBaiViet)
                .Select(s => new CauHinhHienThiBaiVIetVo
                {
                    Id = s.Id,
                    BaiVIetId = s.BaiVietId,
                    Ten = s.BaiViet.Ten.Length <= 30 ? s.BaiViet.Ten : s.BaiViet.Ten.Substring(0, 27) + "...",
                    CreatedOn = s.BaiViet.CreatedOn,
                    CreatedOnDisplay = s.BaiViet.CreatedOn.ToString("dd-MM/yyyy")
                }).Take(viTriBaiViet).ToListAsync();

            return data;
        }

        /// <summary>
        /// portal
        /// </summary>
        /// <param name="danhMucId"></param>
        /// <returns></returns>
        public async Task<List<BaiVietGridPortal>> getBaiVietKV1(long? danhMucId)
        {
            var data = _repository.TableNoTracking.Where(x => x.Deleted != true);
            if (danhMucId == 0)
            {
                data = data.Where(x => x.CauHinhHienThiBaiViets.Where(i => i.IsTrangChu == true).Select(n => n.ViTriHienThi).Contains(1));
            }
            else
            {
                data = data.Where(x => x.CauHinhHienThiBaiViets.Select(x => x.DanhMucId).Contains(danhMucId) && x.CauHinhHienThiBaiViets.Select(n => n.ViTriHienThi).Contains(1));
            }
            var query = await data.Select(s => new BaiVietGridPortal
            {
                Id = s.Id,
                TenBaiViet = s.Ten,
                Alias = s.Alias,
                NoiDungNgan = s.NoiDungNgan,
                NoiDung = s.NoiDung,
                HinhAnhUrl = s.HinhAnh,
                LuotXem = s.LuotXemAo + s.LuotXem,
                NgayTao = s.CreatedOn
            }).Take(1).ToListAsync();
            return query;
        }

        public async Task<List<BaiVietGridPortal>> getBaiVietKV2(long? danhMucId)
        {
            var data = _repository.TableNoTracking.Where(x => x.Deleted != true);
            if (danhMucId == 0)
            {
                data = data.Where(x => x.CauHinhHienThiBaiViets.Where(i => i.IsTrangChu == true).Select(n => n.ViTriHienThi).Contains(2));
            }
            else
            {
                data = data.Where(x => x.CauHinhHienThiBaiViets.Select(x => x.DanhMucId).Contains(danhMucId) && x.CauHinhHienThiBaiViets.Select(n => n.ViTriHienThi).Contains(2));
            }
            var query = await data.Select(s => new BaiVietGridPortal
            {
                Id = s.Id,
                TenBaiViet = s.Ten,
                Alias = s.Alias,
                NoiDungNgan = s.NoiDungNgan,
                NoiDung = s.NoiDung,
                HinhAnhUrl = s.HinhAnh,
                LuotXem = s.LuotXemAo + s.LuotXem,
                NgayTao = s.CreatedOn
            }).Take(2).ToListAsync();
            return query;
        }

        public async Task<List<BaiVietGridPortal>> getBaiVietKV3(long? danhMucId)
        {
            var data = _repository.TableNoTracking.Where(x => x.Deleted != true);
            if (danhMucId == 0)
            {
                data = data.Where(x => x.CauHinhHienThiBaiViets.Where(i => i.IsTrangChu == true).Select(n => n.ViTriHienThi).Contains(3));
            }
            else
            {
                data = data.Where(x => x.CauHinhHienThiBaiViets.Select(x => x.DanhMucId).Contains(danhMucId) && x.CauHinhHienThiBaiViets.Select(n => n.ViTriHienThi).Contains(3));
            }
            var query = await data.Select(s => new BaiVietGridPortal
            {
                Id = s.Id,
                TenBaiViet = s.Ten,
                Alias = s.Alias,
                NoiDungNgan = s.NoiDungNgan,
                NoiDung = s.NoiDung,
                HinhAnhUrl = s.HinhAnh,
                LuotXem = s.LuotXemAo + s.LuotXem,
                NgayTao = s.CreatedOn
            }).Take(3).ToListAsync();
            return query;
        }

        public async Task<List<BaiVietGrid>> getDanhSachBaiViet()
        {
            var listBaiViet = await _repository.TableNoTracking.Where(x => x.Deleted != true).Include(x => x.DanhMucBaiViet).Select(s => new BaiVietGrid
            {
                Id = s.Id,
                Ten = s.Ten,
                NoiDung = s.NoiDung,
                HinhAnh = s.HinhAnh,
                HienThi = s.HienThi,
                ThuTuHienThi = s.ThuTuHienThi,
                LuotXemAo = s.LuotXemAo,
                LuotXem = s.LuotXem,
                CreatedOn = s.CreatedOn,
                CreatedOnDisplay = s.CreatedOn.ToString("dd-MM/yyyy"),
                TenDanhMuc = s.DanhMucBaiViet.Ten
            }).ToListAsync();

            return listBaiViet;
        }

        public async Task<List<BaiVietGrid>> getDanhSachBaiVietTheoDanhMucId(long danhMucId)
        {
            var listBaiViet = await _repository.TableNoTracking.Where(x => x.DanhMucId == danhMucId && x.Deleted != true)
                .Include(x => x.DanhMucBaiViet)
                .OrderBy(x => x.ThuTuHienThi).Select(s => new BaiVietGrid
                {
                    Id = s.Id,
                    Ten = s.Ten,
                    NoiDung = s.NoiDung,
                    HinhAnh = s.HinhAnh,
                    HienThi = s.HienThi,
                    ThuTuHienThi = s.ThuTuHienThi,
                    LuotXemAo = s.LuotXemAo,
                    LuotXem = s.LuotXem,
                    CreatedOn = s.CreatedOn,
                    CreatedOnDisplay = s.CreatedOn.ToString("dd-MM/yyyy"),
                    TenDanhMuc = s.DanhMucBaiViet.Ten
                }).ToListAsync();

            return listBaiViet;
        }

        public async Task<List<CauHinhHienThiBaiVIetVo>> GetThemBaiVietChoTrang(long danhMucId, int viTriBaiViet)
        {
            var data = _repository.TableNoTracking;
            if (danhMucId == 0)
            {
                data = data.Where(x => x.Deleted != true);
            }
            else
            {
                data = data.Where(x => x.DanhMucId == danhMucId && x.Deleted != true && !x.CauHinhHienThiBaiViets.Select(i => i.BaiVietId).Contains(x.Id));
            }
            var result = await data.Select(s => new CauHinhHienThiBaiVIetVo
            {
                Id = s.Id,
                BaiVIetId = s.Id,
                Ten = s.Ten,
                CreatedOn = s.CreatedOn
            }).ToListAsync();

            return result;
        }
    }
}
