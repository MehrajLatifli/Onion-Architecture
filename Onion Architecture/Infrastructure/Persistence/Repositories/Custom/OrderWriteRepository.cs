using Application.Repositories.Custom;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.Custom
{
    public class OrderWriteRepository : WriteRepository<Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(APIDbContext context) : base(context)
        {
        }
    }
}
