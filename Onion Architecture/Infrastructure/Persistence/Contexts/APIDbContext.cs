using Domain.Entities;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product>  Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
          var datas  = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                var result = data.State switch
                { 
                    EntityState.Added => data.Entity.CreateDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdateDate = DateTime.UtcNow,
                    EntityState.Deleted => data.Entity.DeleteDate = DateTime.UtcNow,

                };

            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
