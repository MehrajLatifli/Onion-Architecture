using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<APIDbContext>
    {
        public APIDbContext CreateDbContext(string[] args)
        {


            DbContextOptionsBuilder<APIDbContext> optionsBuilder = new DbContextOptionsBuilder<APIDbContext>();

            optionsBuilder.UseNpgsql(Configuration.PostgreSQLConnectionString);

            return new APIDbContext(optionsBuilder.Options);
        }
    }
}
