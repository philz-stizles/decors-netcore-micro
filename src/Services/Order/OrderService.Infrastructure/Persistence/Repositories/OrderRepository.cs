using OrderService.Application.Contracts.Repositories;
using OrderService.Domain.Entities;
using OrderService.Infrastructure.Persistence.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderService.Infrastructure.Persistence.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(OrderDbContext dbContext) : base(dbContext)
        {
        }

        public Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
        {
            throw new System.NotImplementedException();
        }
    }
}
