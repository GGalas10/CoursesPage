using Courses.Core.Models.Carts;
using Courses.Core.Models.Orders;

namespace Courses.Core.Repositories
{
    public interface IOrderRepository
    {
        public Task<Guid> CreateOrderFromCartAsync(Cart cart);
        public Task<Guid> CreateOrderAsync(Order order);
        public Task UpdateOrderAsync(Guid orderId,Order order);
        public Task DeleteOrderAsync(Guid orderId);
        public Task<Order> GetOrderById(Guid orderId);
        public Task<Order> GetAllUserOrders(Guid userId);
    }
}
