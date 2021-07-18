using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VAYTIENNHANH.Model.Entities;
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

        [HttpPost("TangLike")]
        public async Task<ActionResult> TangLike([FromBody] long baiVietId)
        {
            var baiViet = await _service.GetById(baiVietId, s => s.Include(s => s.CamXucBaiViets));
            if (baiViet != null)
            {
                var camXuc = new CamXucBaiViet();
                camXuc.Liked = 1;
                camXuc.Gian = 1;
                camXuc.Buon = 1;
                camXuc.Cuoi = 1;
                camXuc.DocGiaId = 2;
                camXuc.BaiVietId = baiVietId;
                camXuc.CreatedOn = DateTime.Now;
                baiViet.CamXucBaiViets.Add(camXuc);
                try
                {
                    _service.Update(baiViet);
                }
                catch (Exception ex)
                {

                }


            }
            return Ok();
        }
    }
}
