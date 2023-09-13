using Application.Repositories.Custom;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.Custom
{
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(APIDbContext context) : base(context)
        {
        }
    }
}
