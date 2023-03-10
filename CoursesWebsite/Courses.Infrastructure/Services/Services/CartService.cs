using Courses.Core.Models;
using Courses.Core.Repositories;
using Courses.Infrastructure.Services.Interfaces;

namespace Courses.Infrastructure.Services.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public async Task CreateCartAsync(Guid userId)
        {
            var cart = new Cart(userId);
            await _cartRepository.CreateCartAsync(cart);
        }

        public Task DeleteCartAsync()
        {
            throw new NotImplementedException();
        }
        public Task SaleAsync()
        {
            throw new NotImplementedException();
        }
        public Task AddProductAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        public Task DeleteProductAsync(Guid id)
        {
            throw new NotImplementedException();
        }       
    }
}
