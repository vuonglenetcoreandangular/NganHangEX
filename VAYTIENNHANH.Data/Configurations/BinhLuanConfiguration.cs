using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VAYTIENNHANH.Model.Entities;

namespace VAYTIENNHANH.Data.Configurations
{
    public class BinhLuanConfiguration : IEntityTypeConfiguration<BinhLuan>
    {
        public void Configure(EntityTypeBuilder<BinhLuan> builder)
        {
            builder.ToTable("BinhLuan");
            builder.HasKey(x => x.Id);
        }
    }
}