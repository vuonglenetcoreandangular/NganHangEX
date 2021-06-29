using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VAYTIENNHANH.Api.Areas.Portal.Controllers
{

    [Route("apiPortal/[controller]")]
    [ApiController]
    [Area("Portal")]
    public class PortalBaseController : ControllerBase
    {
    }
}
