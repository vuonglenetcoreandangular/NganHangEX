using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VAYTIENNHANH.Model.Entities;

namespace VAYTIENNHANH.Data.Configurations
{
    public class DanhMucBaiVietConfiguration : IEntityTypeConfiguration<DanhMucBaiViet>
    {
        public void Configure(EntityTypeBuilder<DanhMucBaiViet> builder)
        {
            builder.ToTable("DanhMucBaiViet");
            builder.HasKey(x => x.Id);
            builder.HasMany(rf => rf.BaiViets)
                .WithOne(r => r.DanhMucBaiViet)
                .HasForeignKey(rf => rf.DanhMucId);

            builder.HasMany(rf => rf.CauHinhHienThiBaiViets)
                .WithOne(r => r.DanhMucBaiViet)
                .HasForeignKey(rf => rf.DanhMucId);
        }
    }
}