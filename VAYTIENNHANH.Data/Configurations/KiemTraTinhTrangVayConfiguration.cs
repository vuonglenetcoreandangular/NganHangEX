using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VAYTIENNHANH.Model.Entities;

namespace VAYTIENNHANH.Data.Configurations
{
    public class KiemTraTinhTrangVayConfiguration : IEntityTypeConfiguration<KiemTraTinhTrangVay>
    {
        public void Configure(EntityTypeBuilder<KiemTraTinhTrangVay> builder)
        {
            builder.ToTable("KiemTraTinhTrangVay");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TenKhachHang).IsRequired();
        }
    }
}