﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VAYTIENNHANH.Model.DataModels.BaiViets;
using VAYTIENNHANH.Model.Entities;

namespace VAYTIENNHANH.Service.Services.BaiViets
{
    public interface IBaiVietService : IMasterBaseService<BaiViet>
    {
        Task<int> countTongSoBaiViet();
        Task<List<BaiVietGrid>> getDanhSachBaiViet();
        Task<List<BaiVietGrid>> getDanhSachBaiVietTheoDanhMucId(long danhMucId);
        Task<List<CauHinhHienThiBaiVietVo>> GetBaiVietHienThi(long danhMucId, int viTriBaiViet);
        Task<List<CauHinhHienThiBaiVietVo>> GetThemBaiVietChoTrang(long danhMucId, int viTriBaiViet);

        //## portal
        Task<List<BaiVietGridPortal>> getBaiVietKV1(long? danhMucId);
        Task<List<BaiVietGridPortal>> getBaiVietKV2(long? danhMucId);
        Task<List<BaiVietGridPortal>> getBaiVietKV3(long? danhMucId);
        Task<List<BaiVietGridPortal>> GetBaiListBaiViet(long? danhMucId);

        Task<BaiVietDetailPortal> GetBaiVietDetail(long baiVietId);
    }
}