using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VAYTIENNHANH.Model.Entities;

namespace VAYTIENNHANH.Data.Configurations
{
    public class ToiPhamConfiguration : IEntityTypeConfiguration<ToiPham>
    {
        public void Configure(EntityTypeBuilder<ToiPham> builder)
        {
            builder.ToTable("ToiPham");
            builder.HasKey(x => x.Id);
        }
    }
}