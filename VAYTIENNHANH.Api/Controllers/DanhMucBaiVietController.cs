using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VAYTIENNHANH.Api.Models;
using VAYTIENNHANH.Model.Entities;
using VAYTIENNHANH.Service.Services.DanhMucBaiViets;

namespace VAYTIENNHANH.Api.Controllers
{
    //[EnableCors("TCAPolicy")]
    public class DanhMucBaiVietController : VayTienNhanhControllerBase
    {
        private readonly IDanhMucBaiVietService _service;
        public DanhMucBaiVietController(IDanhMucBaiVietService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var data = await _service.GetAll();
            return Ok(data);
        }
        [HttpGet("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions),
                     nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult> Get(long id)
        {
            
            var data = await _service.GetById(id);
            var result = new DanhMucBaiVietViewModel
            {
                Id = data.Id,
                Ten = data.Ten,
                Alias = data.Alias,
                DanhMucChaId = data.DanhMucChaId,
                TenDanhMucCha = "ss",
                CreatedOn = data.CreatedOn,
                LastUpdate= data.LastUpdate,
                Logo = data.Logo
            };
            return Ok(result);
        }

        [HttpGet("getDanhMucCha")]
        public ActionResult GetDanhMucCha()
        {
            var data =  _service.getDanhMucCha();
            return Ok(data);
        }

        [HttpGet("GetDanhMucHienThiMenu")]
        public async Task<ActionResult> GetDanhMucHienThiMenu()
        {
            var data =  await _service.GetDanhMucHienThiMenu();
            return Ok(data);
        }

        [HttpGet("GetDanhMucKhongHienThiMenu")]
        public async Task<ActionResult> GetDanhMucKhongHienThiMenu()
        {
            var data = await _service.GetDanhMucKhongHienThiMenu();
            return Ok(data);
        }

        [HttpGet("geAlltDanhMuc")]
        public ActionResult geAlltDanhMuc()
        {
            var data = _service.geAlltDanhMuc();
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromForm] DanhMucBaiVietViewModel model)
        {
            var data = new DanhMucBaiViet
            {
                DanhMucChaId = model.DanhMucChaId,
                Ten = model.Ten,
                Alias = model.Alias,
                HienThiMenu = model.HienThiMenu,
                ThuTuHienThi = model.ThuTuHienThi,
                CreatedOn = DateTime.Now
            };

            _service.Create(data);

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromForm] DanhMucBaiVietViewModel model)
        {
            var data = await _service.GetById(model.Id);

            data.Ten = model.Ten;
            data.Alias = model.Alias;
            data.LastUpdate = DateTime.Now;

            _service.Update(data);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var data = await _service.GetById(id);
            _service.Delete(data);

            return Ok();
        }
    }
}
