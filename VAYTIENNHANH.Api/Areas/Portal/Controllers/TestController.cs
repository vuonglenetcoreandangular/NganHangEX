using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VAYTIENNHANH.Api.Areas.Portal.Controllers
{
    public class TestController : PortalBaseController
    {
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var aa = 1;
            return Ok(aa);
        }
    }
}
