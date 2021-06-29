using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VAYTIENNHANH.Model.Entities;

namespace VAYTIENNHANH.Data.Configurations
{
    public class BaiVietHinhAnhConfiguration : IEntityTypeConfiguration<BaiVietHinhAnh>
    {
        public void Configure(EntityTypeBuilder<BaiVietHinhAnh> builder)
        {
            builder.ToTable("BaiVietHinhAnh");
            builder.HasKey(x => x.Id);

            builder.HasOne(rf => rf.BaiViet)
                .WithMany(r => r.BaiVietHinhAnhs)
                .HasForeignKey(rf => rf.BaiVietId);
            builder.HasOne(rf => rf.HinhAnh)
               .WithMany(r => r.BaiVietHinhAnhs)
               .HasForeignKey(rf => rf.BaiVietId);
        }
    }
}