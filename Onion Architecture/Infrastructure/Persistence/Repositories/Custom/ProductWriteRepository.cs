using Application.Repositories.Custom;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.Custom
{
    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(APIDbContext context) : base(context)
        {
        }
    }
}
