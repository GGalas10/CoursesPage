﻿using AutoMapper;
using Courses.Core.Models.Carts;
using Courses.Core.Repositories;
using Courses.Infrastructure.DTO.UserDTOs.Basic;
using Courses.Infrastructure.Services.Interfaces;

namespace Courses.Infrastructure.Services.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public CartService(ICartRepository cartRepository,IUserRepository userRepository,IMapper mapper)
        {
            _cartRepository = cartRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<Guid> CreateCartAsync(Guid userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            var cart = new Cart(user);
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
            if (userId == Guid.Empty)
                throw new Exception("User id cannot be null or empty");
            var user = await _userRepository.GetByIdAsync(userId);
            cart.SetUser(user);
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
        public async Task AddProductAsync(Guid courseId, string name,double price,Guid cartId)
        {
            var cart = await _cartRepository.GetCartByIdAsync(cartId);
            var courseCart = new CoursesCart(courseId, name, price, cart);
            cart.AddToCart(courseCart);
            await _cartRepository.AddToCartAsync(courseCart);
        }
        public async Task DeleteProductAsync(Guid cartId, Guid courseId)
        {
            try
            {
                var cart = await _cartRepository.GetCartByIdAsync(cartId);
                var courseInCart = cart._coursesCart.FirstOrDefault(e => e.CourseId == courseId);
                if (courseInCart == null)
                    throw new Exception("Course doesn't exist in cart");
                await _cartRepository.RemoveFromCartAsync(courseInCart);
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }       
    }
}
