using Application.Repositories.Custom;
using Domain.Entities;
using Domain.Entities.Models;
using Persistence.Contexts;

namespace Persistence.Repositories.Custom
{
    public class OrderReadRepository : ReadRepository<Order>, IOrderReadRepository
    {
        public OrderReadRepository(OnionArchitecture_DbContext context) : base(context)
        {
        }
    }
}
