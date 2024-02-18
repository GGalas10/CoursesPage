using Courses.Core.Models.Carts;
using Courses.Core.Models.Orders;
using Courses.Core.Repositories;
using Courses.Infrastructure.Database;

namespace Courses.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CoursesDbContext _context;
        public OrderRepository(CoursesDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> CreateOrderFromCartAsync(Cart cart)
        {
            try
            {
                if (cart == null)
                    throw new Exception("Cart cannot be empty");
                var newOrder = new Order(cart);
                await _context.Orders.AddAsync(newOrder);
                await UpdateDatabase();
                return newOrder.Id;
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Guid> CreateOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOrderAsync(Guid orderId, Order order)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOrderAsync(Guid orderId)
        {
            throw new NotImplementedException();
        } 

        public Task<Order> GetOrderById(Guid orderId)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetAllUserOrders(Guid userId)
        {
            throw new NotImplementedException();
        }
        private async Task UpdateDatabase()
        {
            if (await _context.SaveChangesAsync() > 0)
                await Task.CompletedTask;
            else
                throw new Exception("Database cannot save changes");
        }
    }
}
