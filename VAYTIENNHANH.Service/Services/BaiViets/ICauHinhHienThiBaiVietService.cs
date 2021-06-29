using System;
using System.Collections.Generic;
using System.Text;
using VAYTIENNHANH.Model.Entities;

namespace VAYTIENNHANH.Service.Services.BaiViets
{
    public interface ICauHinhHienThiBaiVietService : IMasterBaseService<CauHinhHienThiBaiViet>
    {
        bool CheckDuSoLuongBaiViet(long? danhMucId, int ViTriId);
    }
}
