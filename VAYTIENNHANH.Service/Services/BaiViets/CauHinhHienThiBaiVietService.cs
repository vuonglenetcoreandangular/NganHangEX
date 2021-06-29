using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VAYTIENNHANH.Data.Repository;
using VAYTIENNHANH.Model.Entities;

namespace VAYTIENNHANH.Service.Services.BaiViets
{
    public class CauHinhHienThiBaiVietService : MasterBaseService<CauHinhHienThiBaiViet>, ICauHinhHienThiBaiVietService
    {
        private readonly IRepository<CauHinhHienThiBaiViet> _repository;
        public CauHinhHienThiBaiVietService(IRepository<CauHinhHienThiBaiViet> repository) : base(repository)
        {
            _repository = repository;
        }

        public bool CheckDuSoLuongBaiViet(long? danhMucId, int ViTriId)
        {
            var listBaiViet = _repository.TableNoTracking.Where(x => x.DanhMucId == danhMucId && x.ViTriHienThi == ViTriId);
            int i = listBaiViet.Count();
            switch (ViTriId)
            {
                case 1:
                    if (i >= 1) { return true; } else { return false; };
                case 2:
                    if (i >= 2) { return true; } else { return false; };
                case 3:
                    if (i >= 2) { return true; } else { return false; };
                case 4:
                    if (i >= 4) { return true; } else { return false; };
                default: return false;
            }
        }
    }
}
