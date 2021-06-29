using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VAYTIENNHANH.Model.Entities;

namespace VAYTIENNHANH.Data.Configurations
{
    public class DiemToiPhamConfiguration : IEntityTypeConfiguration<DiemToiPham>
    {
        public void Configure(EntityTypeBuilder<DiemToiPham> builder)
        {
            builder.ToTable("DiemToiPham");
            builder.HasKey(x => x.Id);
        }
    }
}