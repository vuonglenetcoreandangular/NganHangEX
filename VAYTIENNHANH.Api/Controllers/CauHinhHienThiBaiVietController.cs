using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VAYTIENNHANH.Api.Models.BaiViets;
using VAYTIENNHANH.Model.Entities;
using VAYTIENNHANH.Service.Services.BaiViets;

namespace VAYTIENNHANH.Api.Controllers
{
    public class CauHinhHienThiBaiVietController : VayTienNhanhControllerBase
    {
        private readonly IBaiVietService _baiVietService;
        private readonly ICauHinhHienThiBaiVietService _cauHinhHienThiBaiVietService;
        public CauHinhHienThiBaiVietController(IBaiVietService baiVietService, ICauHinhHienThiBaiVietService cauHinhHienThiBaiVietService)
        {
            _baiVietService = baiVietService;
            _cauHinhHienThiBaiVietService = cauHinhHienThiBaiVietService;
        }

        [HttpGet("GetThemBaiVietChoTrang/{danhMucId}/{viTriHienThiId}")]
        public async Task<ActionResult> GetThemBaiVietChoTrang(long danhMucId, int viTriHienThiId)
        {
            var data = await _baiVietService.GetThemBaiVietChoTrang(danhMucId, viTriHienThiId);
            return Ok(data);
        }

        [HttpPost("ThemCauHinhBaiViet")]
        public async Task<ActionResult> Add([FromForm] CauHinhBaiVietViewModel model)
        {
            if (model.DanhMucId == 0)
            {
                model.DanhMucId = null;
            }
            //validate
            var checkDuSoLuong = _cauHinhHienThiBaiVietService.CheckDuSoLuongBaiViet(model.DanhMucId, model.ViTriId);
            if (checkDuSoLuong)
            {
                return NoContent();
            }

            var baiViet = await _baiVietService.GetById(model.BaiVietId);
            var cauHinhBaiViet = new CauHinhHienThiBaiViet();
            cauHinhBaiViet.BaiVietId = model.BaiVietId;
            cauHinhBaiViet.DanhMucId = model.DanhMucId;
            cauHinhBaiViet.CreatedOn = DateTime.Now;
            cauHinhBaiViet.ViTriHienThi = model.ViTriId;
            cauHinhBaiViet.IsTrangChu = model.DanhMucId == null ? true : false;

            baiViet.CauHinhHienThiBaiViets.Add(cauHinhBaiViet);
            _baiVietService.Update(baiViet);

            return NoContent();
        }

        [HttpDelete("Delete/{idHienThi}")]
        public async Task<ActionResult> Delete(long idHienThi)
        {
            _cauHinhHienThiBaiVietService.DeleteById(idHienThi);
            return NoContent();
        }
    }
}
