using Application.Repositories.Custom;
using Domain.Entities;
using Domain.Entities.Models;
using Persistence.Contexts;

namespace Persistence.Repositories.Custom
{
    public class OrderWriteRepository : WriteRepository<Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(OnionArchitecture_DbContext context) : base(context)
        {
        }
    }
}
