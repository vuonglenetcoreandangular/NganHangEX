using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VAYTIENNHANH.Service.Services.DanhMucBaiViets;

namespace VAYTIENNHANH.Api.Areas.Portal.Controllers
{
    public class DanhMucController : PortalBaseController
    {
        private readonly IDanhMucBaiVietService _service;
        public DanhMucController(IDanhMucBaiVietService service)
        {
            _service = service;
        }
        [HttpGet("GetDanhMucHienThiMenu")]
        public async Task<ActionResult> GetDanhMucHienThiMenu()
        {
            var data = await _service.GetDanhMucHienThiMenu();
            return Ok(data);
        }
    }
}
