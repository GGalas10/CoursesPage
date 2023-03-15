using AutoMapper;
using Courses.Core.Models;
using Courses.Core.Repositories;
using Courses.Infrastructure.DTO;
using Courses.Infrastructure.Services.Interfaces;

namespace Courses.Infrastructure.Services.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;
        public CartService(ICartRepository cartRepository,IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }
        public async Task<Guid> CreateCartAsync(Guid userId)
        {
            var cart = new Cart(userId);
            await _cartRepository.CreateCartAsync(cart);
            return cart.Id;
        }
        public async Task<UserCartDTO> GetUserCart(Guid userid)
        => _mapper.Map<UserCartDTO>(await _cartRepository.GetUserCartAsync(userid));
        public async Task<UserCartDTO> GetCartById(Guid cartId)
        => _mapper.Map<UserCartDTO>(await _cartRepository.GetCartByIdAsync(cartId));
        public async Task UpdateUserIdAsync(Guid userId, Guid cartId)
        {
            var cart = await _cartRepository.GetCartByIdAsync(userId);
            cart.SetUserGuid(userId);
            await _cartRepository.UpdateCartAsync();
        }
        public async Task DeleteCartAsync(Guid CartId)
        {
            await _cartRepository.DeleteCartAsync(CartId);

        }
        public Task SaleAsync(Guid CartId)
        {
            throw new NotImplementedException();
        }
        public async Task AddProductAsync(Guid CartId,Guid id)
        {
            var cart = await _cartRepository.GetUserCartAsync(CartId);
            cart.AddCourse(id);
            await _cartRepository.UpdateCartAsync();
        }
        public async Task DeleteProductAsync(Guid CartId,Guid id)
        {
            var cart = await _cartRepository.GetUserCartAsync(CartId);
            cart.RemoveCourse(id);
            await _cartRepository.UpdateCartAsync();
        }       
    }
}
