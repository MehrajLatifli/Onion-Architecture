using Application.Repositories.Custom;
using Domain.Entities;
using Domain.Entities.Models;
using Persistence.Contexts;

namespace Persistence.Repositories.Custom
{
    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(OnionArchitecture_DbContext context) : base(context)
        {
        }
    }
}
