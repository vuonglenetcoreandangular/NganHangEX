using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VAYTIENNHANH.Model.Entities;

namespace VAYTIENNHANH.Data.Configurations
{
    public class CauHinhHienThiBaiVietConfiguration : IEntityTypeConfiguration<CauHinhHienThiBaiViet>
    {
        public void Configure(EntityTypeBuilder<CauHinhHienThiBaiViet> builder)
        {
            builder.ToTable("CauHinhHienThiBaiViet");
            builder.HasKey(x => x.Id);

            builder.HasOne(rf => rf.BaiViet)
                .WithMany(r => r.CauHinhHienThiBaiViets)
                .HasForeignKey(rf => rf.BaiVietId);

            builder.HasOne(rf => rf.DanhMucBaiViet)
                .WithMany(r => r.CauHinhHienThiBaiViets)
                .HasForeignKey(rf => rf.DanhMucId);
        }
    }
}