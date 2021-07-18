using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VAYTIENNHANH.Model.Entities;

namespace VAYTIENNHANH.Data.Configurations
{
    public class CamXucBaiVietConfiguration : IEntityTypeConfiguration<CamXucBaiViet>
    {
        public void Configure(EntityTypeBuilder<CamXucBaiViet> builder)
        {
            builder.ToTable("CamXucBaiViet");
            builder.HasKey(x => x.Id);

            builder.HasOne(rf => rf.DocGia)
             .WithMany(r => r.CamXucBaiViets)
             .HasForeignKey(rf => rf.DocGiaId);

            builder.HasOne(rf => rf.BaiViet)
            .WithMany(r => r.CamXucBaiViets)
            .HasForeignKey(rf => rf.BaiVietId);
        }
    }
}