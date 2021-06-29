using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VAYTIENNHANH.Model.Entities;

namespace VAYTIENNHANH.Data.Configurations
{
    public class DanhGiaBinhLuanConfiguration : IEntityTypeConfiguration<DanhGiaBinhLuan>
    {
        public void Configure(EntityTypeBuilder<DanhGiaBinhLuan> builder)
        {
            builder.ToTable("DanhGiaBinhLuan");
            builder.HasKey(x => x.Id);
        }
    }
}