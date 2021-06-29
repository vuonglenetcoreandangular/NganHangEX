using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VAYTIENNHANH.Model.Entities;

namespace VAYTIENNHANH.Data.Configurations
{
    internal class DocGiaConfiguration : IEntityTypeConfiguration<DocGia>
    {
        public void Configure(EntityTypeBuilder<DocGia> builder)
        {
            builder.ToTable("DocGia");
            builder.HasKey(x => x.Id);
        }
    }
}