using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VAYTIENNHANH.Model.Entities;

namespace VAYTIENNHANH.Data.Configurations
{
    public class NhanVatConfiguration : IEntityTypeConfiguration<NhanVat>
    {
        public void Configure(EntityTypeBuilder<NhanVat> builder)
        {
            builder.ToTable("NhanVat");
            builder.HasKey(x => x.Id);

            builder.HasMany(rf => rf.BaiViets)
               .WithOne(r => r.NhanVat)
               .HasForeignKey(rf => rf.NhanVatId);
        }
    }
}