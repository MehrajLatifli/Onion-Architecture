
using Application.Repositories.Custom;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services) {

            //services.AddDbContext<APIDbContext>(options => options.UseNpgsql(Configuration.PostgreSQLConnectionString), ServiceLifetime.Singleton);

            //services.AddSingleton<ICustomerWriteRepository, CustomerWriteRepository>();
            //services.AddSingleton<ICustomerReadRepository, CustomerReadRepository>();

            //services.AddSingleton<IOrderWriteRepository, OrderWriteRepository>();
            //services.AddSingleton<IOrderReadRepository, OrderReadRepository>();

            //services.AddSingleton<IProductWriteRepository, ProductWriteRepository>();
            //services.AddSingleton<IProductReadRepository, ProductReadRepository>();

            services.AddDbContext<APIDbContext>(options => options.UseNpgsql(Configuration.PostgreSQLConnectionString));

            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();

            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IOrderReadRepository,  OrderReadRepository>();

            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IProductReadRepository,  ProductReadRepository>();
        }
    }
}
