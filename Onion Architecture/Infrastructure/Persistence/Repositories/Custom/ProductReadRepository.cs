using Application.Repositories.Custom;
using Domain.Entities;
using Domain.Entities.Models;
using Persistence.Contexts;

namespace Persistence.Repositories.Custom
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(OnionArchitecture_DbContext context) : base(context)
        {
        }
    }
}
