using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Center_Education_Management.EFcore
{
    public class CenterDBContextFactory : IDesignTimeDbContextFactory<CenterDBContext>
    {
        public CenterDBContext CreateDbContext(string[] args)
        {
            // conection string
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<CenterDBContext>();

            optionsBuilder
                .UseSqlServer(connectionString)
                .UseLazyLoadingProxies();

            return new CenterDBContext(optionsBuilder.Options);
        }
    }
}