using AutoMapper;
using Courses.Core.Models.Cart;
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
        {
            var userCart = await _cartRepository.GetUserCartAsync(userid);
            var cartDto = new UserCartDTO();
            cartDto.ProductGuid = await _cartRepository.GetProductsInCartByIdAsync(userCart.Id);
            return cartDto;
        }
        public async Task<UserCartDTO> GetCartById(Guid cartId)
        {
            var cartDto = new UserCartDTO();
            cartDto.ProductGuid = await _cartRepository.GetProductsInCartByIdAsync(cartId);
            return cartDto;
        }
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
        public async Task AddProductAsync(Guid cartId, string name,double price)
        {
            var cart = new CoursesCart(cartId,name,price);
            await _cartRepository.AddToCartAsync(cart);
        }
        public async Task DeleteProductAsync(Guid cartId, Guid courseId)
        {
           
            //await _cartRepository.RemoveFromCartAsync(cart);
        }       
    }
}
