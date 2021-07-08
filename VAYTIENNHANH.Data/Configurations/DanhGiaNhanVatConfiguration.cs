using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VAYTIENNHANH.Model.Entities;

namespace VAYTIENNHANH.Data.Configurations
{
    public class DanhGiaNhanVatConfiguration : IEntityTypeConfiguration<DanhGiaNhanVat>
    {
        public void Configure(EntityTypeBuilder<DanhGiaNhanVat> builder)
        {
            builder.ToTable("DanhGiaNhanVat");
            builder.HasKey(x => x.Id);
        }
    }
}