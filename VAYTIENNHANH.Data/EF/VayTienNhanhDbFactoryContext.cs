using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace VAYTIENNHANH.Data.EF
{
    public class VayTienNhanhDbFactoryContext : IDesignTimeDbContextFactory<VayTienNhanhDbContext>
    {
        public VayTienNhanhDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("vaytiennhanhDB");

            var optionsBuilder = new DbContextOptionsBuilder<VayTienNhanhDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new VayTienNhanhDbContext(optionsBuilder.Options);
        }
    }
}