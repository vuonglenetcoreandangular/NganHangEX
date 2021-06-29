using System;
using System.Collections.Generic;
using System.Text;
using VAYTIENNHANH.Model.Entities;

namespace VAYTIENNHANH.Service.Services.Users
{
    public interface IUserService: IMasterBaseService<DocGia>
    {
        public long GetCurentUserId();
    }
}
