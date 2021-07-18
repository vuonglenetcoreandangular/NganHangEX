using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VAYTIENNHANH.Service.Services.BaiViets;
using VAYTIENNHANH.Service.Services.DanhMucBaiViets;

namespace VAYTIENNHANH.Api.Controllers.Portal
{
    public class DanhMucPortalController : VayTienNhanhControllerBase
    {
        private readonly IDanhMucBaiVietService _service;
        private readonly IBaiVietService _baiVietService;

        public DanhMucPortalController(IDanhMucBaiVietService service, IBaiVietService baiVietService)
        {
            _service = service;
            _baiVietService = baiVietService;
        }

        [HttpGet("GetDanhMucHienThiMenu")]
        public async Task<ActionResult> GetDanhMucHienThiMenu()
        {
            var data = await _service.GetDanhMucHienThiMenu();
            return Ok(data);
        }

        [HttpGet("GetBaiVIetKV1/{danhMucId}")]
        public async Task<ActionResult> GetBaiVIetKV1(long? danhMucId)
        {
            if (danhMucId == null)
            {
                danhMucId = 0;
            }
            var data = await _baiVietService.getBaiVietKV1(danhMucId);
            return Ok(data);
        }

        [HttpGet("GetBaiVIetKV2/{danhMucId}")]
        public async Task<ActionResult> GetBaiVIetKV2(long? danhMucId)
        {
            var data = await _baiVietService.getBaiVietKV2(danhMucId);
            return Ok(data);
        }

        [HttpGet("GetBaiVIetKV3/{danhMucId}")]
        public async Task<ActionResult> GetBaiVIetKV3(long? danhMucId)
        {
            var data = await _baiVietService.getBaiVietKV3(danhMucId);
            return Ok(data);
        }
        
        [HttpGet("GetBaiListBaiViet/{danhMucId}")]
        public async Task<ActionResult> GetBaiListBaiViet(long? danhMucId)
        {
            var data = await _baiVietService.GetBaiListBaiViet(danhMucId);
            return Ok(data);
        }
    }
}