using System;
using System.Collections.Generic;
using System.Text;
using VAYTIENNHANH.Data.Repository;
using VAYTIENNHANH.Model.Entities;

namespace VAYTIENNHANH.Service.Services.HinhAnhs
{
    public class HinhAnhService: MasterBaseService<HinhAnh>, IHinhAnhService
    {
        public HinhAnhService(IRepository<HinhAnh> repository): base(repository)
        {

        }
    }
}
