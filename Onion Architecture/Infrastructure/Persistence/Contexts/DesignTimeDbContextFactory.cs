
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<OnionArchitectureDbContext>
    {
        public OnionArchitectureDbContext CreateDbContext(string[] args)
        {


            DbContextOptionsBuilder<OnionArchitectureDbContext> optionsBuilder = new DbContextOptionsBuilder<OnionArchitectureDbContext>();

            optionsBuilder.UseNpgsql(Configuration.PostgreSQLConnectionString);

            return new OnionArchitectureDbContext(optionsBuilder.Options);
        }
    }
}
