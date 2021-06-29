using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using VAYTIENNHANH.Data.Repository;
using VAYTIENNHANH.Model.Entities;

namespace VAYTIENNHANH.Service.Services.Users
{
    public class UserService: MasterBaseService<DocGia>, IUserService
    {

        //private readonly ClaimsPrincipal _claimsPrincipal;
        public UserService(IRepository<DocGia> repository) : base(repository)
        {
          //  _claimsPrincipal = principal as ClaimsPrincipal;
        }

        public long GetCurentUserId()
        {
            //var userIdClaim = _claimsPrincipal?.Claims.FirstOrDefault(o => o.Type == "_Id");
            //if (userIdClaim != null)
            //{
            //    return long.Parse(userIdClaim.Value);
            //}
            return 1;
        }
    }
}
