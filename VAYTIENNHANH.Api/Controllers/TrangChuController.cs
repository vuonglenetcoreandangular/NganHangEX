using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VAYTIENNHANH.Service.Services.BaiViets;

namespace VAYTIENNHANH.Api.Controllers
{
    public class TrangChuController : VayTienNhanhControllerBase
    {
        private readonly IBaiVietService _baiVietService;
        public TrangChuController(IBaiVietService baiVietService)
        {
            _baiVietService = baiVietService;
        }

        [HttpGet("GetTongSoBaiVIet")]
        public async Task<ActionResult> GetTongSoBaiVIet()
        {
            int soBaiViet = await _baiVietService.countTongSoBaiViet();
            return Ok(soBaiViet);
        }
    }
}
