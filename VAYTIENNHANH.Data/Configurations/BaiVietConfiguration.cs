using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VAYTIENNHANH.Model.Entities;

namespace VAYTIENNHANH.Data.Configurations
{
    public class BaiVietConfiguration : IEntityTypeConfiguration<BaiViet>
    {
        public void Configure(EntityTypeBuilder<BaiViet> builder)
        {
            builder.ToTable("BaiViet");
            builder.HasKey(x => x.Id);

            builder.HasOne(rf => rf.DanhMucBaiViet)
                .WithMany(r => r.BaiViets)
                .HasForeignKey(rf => rf.DanhMucId);

            builder.HasMany(rf => rf.CauHinhHienThiBaiViets)
                .WithOne(r => r.BaiViet)
                .HasForeignKey(rf => rf.BaiVietId);
            builder.HasMany(rf => rf.BaiVietHinhAnhs)
                .WithOne(r => r.BaiViet)
                .HasForeignKey(rf => rf.BaiVietId);
        }
    }
}