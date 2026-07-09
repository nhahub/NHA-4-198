using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Center_Education_Management.EFcore
{
    public class CenterDBContextFactory : IDesignTimeDbContextFactory<CenterDBContext>
    {
        public CenterDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CenterDBContext>();

            optionsBuilder
                .UseSqlServer("DefaultConnection")
                .UseLazyLoadingProxies();

            return new CenterDBContext(optionsBuilder.Options);
        }
    }
}