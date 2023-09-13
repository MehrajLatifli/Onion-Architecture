using Application.Repositories.Custom;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.Custom
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(APIDbContext context) : base(context)
        {
        }
    }
}
