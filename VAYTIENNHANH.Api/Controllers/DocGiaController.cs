using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VAYTIENNHANH.Api.Models.DocGias;
using VAYTIENNHANH.Model.Entities;
using VAYTIENNHANH.Service.Services.Users;

namespace VAYTIENNHANH.Api.Controllers
{
    public class DocGiaController : VayTienNhanhControllerBase
    {
        private readonly IUserService _service;

        public DocGiaController(IUserService service)
        {
            _service = service;
        }

        [HttpGet("GetTest")]
        //[Authorize]
        public async Task<ActionResult> Get()
        {
            return Ok("ggg");
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginViewModel model)
        {
            if (model == null)
            {
                return BadRequest("Invalid client request");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name , model.Username),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim("vuongtest", "lưu cái gì Hôm nay hai vợ chồng mình cùng cha lên rừng đước tìm dộp rừng cùng đốt lửa cắm trại ăn uống nghĩ mệt cùng nhau trãi qua những giay phút thoải mái nơi rừng sâu")

            };

            if (model.Username == "vuong" && model.Password == "123")
            {
                var secrecKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signingCredentials = new SigningCredentials(secrecKey, SecurityAlgorithms.HmacSha256);

                var tockenOptions = new JwtSecurityToken(
                    issuer: "https://localhost:5100",
                    audience: "https://localhost:5100",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials : signingCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tockenOptions);
                return Ok(new { tokenString = tokenString });
            }

            //return Unauthorized();
            return BadRequest();
        }


        [HttpPost]
        public async Task<ActionResult> Add([FromForm] DocGiaViewModel model)
        {
            var data = new DocGia
            {
                FacebookId = model.FacebookId,
                GoogleId = model.GoogleId,
                ZaloId = model.ZaloId,
                Avatar = model.Avatar,
                TenDocGia = model.TenDocGia,
                CreatedOn = DateTime.Now,
                LuotXemWeb = 1
            };
            _service.Create(data);
            return Ok();
        }
    }
}