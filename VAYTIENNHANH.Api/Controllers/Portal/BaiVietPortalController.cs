using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VAYTIENNHANH.Service.Services.BaiViets;

namespace VAYTIENNHANH.Api.Controllers.Portal
{
    public class BaiVietPortalController : VayTienNhanhControllerBase
    {
        private readonly IBaiVietService _service;

        public BaiVietPortalController(IBaiVietService service)
        {
            _service = service;
        }

        [HttpGet("GetBaiVietDetail/{baiVietId}")]
        public async Task<ActionResult> GetBaiVietDetail(long baiVietId)
        {
            var data = await _service.GetBaiVietDetail(baiVietId);
            return Ok(data);
        }
    }
}
