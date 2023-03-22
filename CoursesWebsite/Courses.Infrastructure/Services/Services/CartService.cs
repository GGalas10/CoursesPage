﻿using AutoMapper;
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
        public async Task AddProductAsync(Guid CartId,Guid id)
        {
            var cart = new CoursesCart(CartId, id);
            await _cartRepository.AddToCartAsync(cart);
        }
        public async Task DeleteProductAsync(Guid CartId,Guid id)
        {
            var cart = new CoursesCart(CartId,id);
            await _cartRepository.RemoveFromCartAsync(cart);
        }       
    }
}
