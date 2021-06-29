using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VAYTIENNHANH.Model.Entities;

namespace VAYTIENNHANH.Data.Configurations
{
    public class DanhGiaToiPhamConfiguration : IEntityTypeConfiguration<DanhGiaToiPham>
    {
        public void Configure(EntityTypeBuilder<DanhGiaToiPham> builder)
        {
            builder.ToTable("DanhGiaToiPham");
            builder.HasKey(x => x.Id);
        }
    }
}