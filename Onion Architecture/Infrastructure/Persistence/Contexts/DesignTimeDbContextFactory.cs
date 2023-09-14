
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<OnionArchitecture_DbContext>
    {
        public OnionArchitecture_DbContext CreateDbContext(string[] args)
        {


            DbContextOptionsBuilder<OnionArchitecture_DbContext> optionsBuilder = new DbContextOptionsBuilder<OnionArchitecture_DbContext>();

            optionsBuilder.UseSqlServer(ConfigurationSQL.ConnectionString);

            return new OnionArchitecture_DbContext(optionsBuilder.Options);
        }
    }
}
