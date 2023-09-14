using Application.Repositories.Custom;
using Domain.Entities;
using Domain.Entities.Models;
using Persistence.Contexts;

namespace Persistence.Repositories.Custom
{
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(OnionArchitecture_DbContext context) : base(context)
        {
        }
    }
}
