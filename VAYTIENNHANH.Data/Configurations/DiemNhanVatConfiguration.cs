using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VAYTIENNHANH.Model.Entities;

namespace VAYTIENNHANH.Data.Configurations
{
    public class DiemNhanVatConfiguration : IEntityTypeConfiguration<DiemNhanVat>
    {
        public void Configure(EntityTypeBuilder<DiemNhanVat> builder)
        {
            builder.ToTable("DiemNhanVat");
            builder.HasKey(x => x.Id);
        }
    }
}