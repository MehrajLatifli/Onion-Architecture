using Domain.Entities;
using Domain.Entities.Models;

namespace Application.Repositories.Custom
{
    public interface IProductWriteRepository : IWriteRepository<Product>
    {
    }
}
