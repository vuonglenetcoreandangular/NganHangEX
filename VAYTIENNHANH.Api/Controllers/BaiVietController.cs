using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using VAYTIENNHANH.Api.Models;
using VAYTIENNHANH.Model.Entities;
using VAYTIENNHANH.Service.Helpers;
using VAYTIENNHANH.Service.Services.BaiViets;
using VAYTIENNHANH.Service.Services.HinhAnhs;

namespace VAYTIENNHANH.Api.Controllers
{
    public class BaiVietController : VayTienNhanhControllerBase
    {
        private readonly IBaiVietService _service;
        private readonly IHinhAnhService _hinhAnhService;

        public BaiVietController(IBaiVietService service, IHinhAnhService hinhAnhService)
        {
            _service = service;
            _hinhAnhService = hinhAnhService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var data = await _service.getDanhSachBaiViet();
            return Ok(data);
        }

        [HttpGet("getBaiVietTheoDanhMucId/{danhMucId}")]
        public async Task<ActionResult> getBaiVietTheoDanhMucId(long danhMucId)
        {
            var data = await _service.getDanhSachBaiVietTheoDanhMucId(danhMucId);
            return Ok(data);
        }

        [HttpGet("GetBaiVietHienThi/{danhMucId}/{viTriBaiViet}")]
        public async Task<ActionResult> GetBaiVietHienTHi(long danhMucId, int viTriBaiViet)
        {
            var data = await _service.GetBaiVietHienThi(danhMucId, viTriBaiViet);
            return Ok(data);
        }

        [HttpGet("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions),
                     nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> Get(long id)
        {
            var data = await _service.GetById(id, s => s.Include(a => a.DanhMucBaiViet));
            var result = new BaiVietViewModel
            {
                Id = data.Id,
                Ten = data.Ten,
                Alias = data.Alias,
                DanhMucId = data.DanhMucId,
                NoiDungNgan = data.NoiDungNgan,
                NoiDungTomTat = data.NoiDungTomTat,
                NoiDung = data.NoiDung,
                HinhAnhBase64 = data.HinhAnh,
                HienThi = data.HienThi.GetValueOrDefault(),
                ThuTuHienThi = data.ThuTuHienThi,
                LuotXemAo = data.LuotXemAo.GetValueOrDefault(),
                LuotXem = data.LuotXem.GetValueOrDefault(),
                CreatedOn = data.CreatedOn,
                LastUpdate = data.LastUpdate,
                TenDanhMuc = data.DanhMucBaiViet.Ten
            };
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromForm] BaiVietViewModel model)
        {
            var dateNow = DateTime.Now;
            var lastNameIMG = dateNow.ToString("ddMMyyyy");
            var data = new BaiViet
            {
                Ten = model.Ten,
                Alias = model.Alias,
                DanhMucId = model.DanhMucId,
                NoiDungNgan = model.NoiDungNgan,
                NoiDungTomTat = model.NoiDungTomTat,
                NoiDung = model.NoiDung,
                HinhAnh = $@"{RootImage.RootIMG}baiviet\{model.Alias + lastNameIMG}.jpg",
                HienThi = model.HienThi,
                HienThiAnh = model.HienThiAnh,
                HienThiTrangChu = model.HienThiTrangChu,
                ThuTuHienThi = model.ThuTuHienThi,
                LuotXemAo = 200,
                LuotXem = 0,
                CreatedOn = dateNow
            };
            var baiVietHinhAnh = new BaiVietHinhAnh();
            baiVietHinhAnh.CreatedOn = dateNow;
            var hinhAnh = new HinhAnh();
            hinhAnh.HinhAnhUrl = $@"{RootImage.RootIMG}baiviet\{model.Alias + lastNameIMG}.jpg";
            hinhAnh.TenHinhAnh = model.Alias + lastNameIMG + "png";
            hinhAnh.CreatedOn = dateNow;

            
            baiVietHinhAnh.HinhAnh = hinhAnh;
            data.BaiVietHinhAnhs.Add(baiVietHinhAnh);
            _service.UpImageFromBase64ToJpg(PathFolder.PathImgBaiViet, model.HinhAnhBase64, model.Alias + lastNameIMG);
                     
            _service.Create(data);
            
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromForm] BaiVietViewModel model)
        {
            var dateNow = DateTime.Now;
            var lastNameIMG = dateNow.ToString("ddMMyyyy");
            var data = await _service.GetById(model.Id);

            data.Ten = model.Ten;
            data.Alias = model.Alias;
            data.DanhMucId = model.DanhMucId;
            data.NoiDungNgan = model.NoiDungNgan;
            data.NoiDungTomTat = model.NoiDungTomTat;
            data.NoiDung = model.NoiDung;
            //data.HinhAnh = $"wwwroot\\baiviet\\{model.Alias + lastNameIMG}.png";
            data.HienThi = model.HienThi;
            data.ThuTuHienThi = model.ThuTuHienThi;
            data.LuotXem = model.LuotXem;
            data.LastUpdate = DateTime.Now;
            _service.Update(data);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var data = await _service.GetById(id);
            data.Deleted = true;

            _service.Update(data);

            return Ok();
        }
    }
}