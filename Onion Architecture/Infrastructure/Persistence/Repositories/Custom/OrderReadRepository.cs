using Application.Repositories.Custom;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.Custom
{
    public class OrderReadRepository : ReadRepository<Order>, IOrderReadRepository
    {
        public OrderReadRepository(APIDbContext context) : base(context)
        {
        }
    }
}
