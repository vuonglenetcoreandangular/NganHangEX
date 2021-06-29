using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VAYTIENNHANH.Api.Areas.Portal.Controllers
{
    public class BaiVietController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
