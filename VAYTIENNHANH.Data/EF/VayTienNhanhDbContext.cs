using Microsoft.EntityFrameworkCore;
using VAYTIENNHANH.Data.Configurations;
using VAYTIENNHANH.Model.Entities;

namespace VAYTIENNHANH.Data.EF
{
    public class VayTienNhanhDbContext : DbContext
    {
        public VayTienNhanhDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BaiVietConfiguration());
            modelBuilder.ApplyConfiguration(new BinhLuanConfiguration());
            modelBuilder.ApplyConfiguration(new DanhGiaBinhLuanConfiguration());
            modelBuilder.ApplyConfiguration(new DanhGiaNhanVatConfiguration());
            modelBuilder.ApplyConfiguration(new DanhMucBaiVietConfiguration());
            modelBuilder.ApplyConfiguration(new DiemNhanVatConfiguration());
            modelBuilder.ApplyConfiguration(new DocGiaConfiguration());
            modelBuilder.ApplyConfiguration(new KiemTraTinhTrangVayConfiguration());
            modelBuilder.ApplyConfiguration(new NhanVatConfiguration());
        }

        public DbSet<BaiViet> BaiViets { get; set; }
        public DbSet<BinhLuan> BinhLuans { get; set; }
        public DbSet<DanhGiaBinhLuan> DanhGiaBinhLuans { get; set; }
        public DbSet<DanhGiaNhanVat> DanhGiaNhanVats { get; set; }
        public DbSet<DanhMucBaiViet> DanhMucBaiViets { get; set; }
        public DbSet<DiemNhanVat> DiemNhanVats { get; set; }
        public DbSet<DocGia> DocGias { get; set; }
        public DbSet<KiemTraTinhTrangVay> KiemTraTinhTrangVays { get; set; }
        public DbSet<NhanVat> NhanVats { get; set; }
    }
}