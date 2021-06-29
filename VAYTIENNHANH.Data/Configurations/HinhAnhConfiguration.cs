using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VAYTIENNHANH.Model.Entities;

namespace VAYTIENNHANH.Data.Configurations
{
    public class HinhAnhConfiguration : IEntityTypeConfiguration<HinhAnh>
    {
        public void Configure(EntityTypeBuilder<HinhAnh> builder)
        {
            builder.ToTable("HinhAnh");
            builder.HasKey(x => x.Id);

            builder.HasMany(rf => rf.BaiVietHinhAnhs)
                .WithOne(r => r.HinhAnh)
                .HasForeignKey(rf => rf.HinhAnhId);
        }
    }
}