using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VAYTIENNHANH.Api.Models.DocGias
{
    public class RegisterViewModel
    {
        public int LoaiTaiKhoan { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public  string PassWord { get; set; }
    }
}
