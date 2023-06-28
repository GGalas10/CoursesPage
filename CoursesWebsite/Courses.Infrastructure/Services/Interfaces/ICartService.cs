﻿using Courses.Core.Models;
using Courses.Infrastructure.DTO;

namespace Courses.Infrastructure.Services.Interfaces
{
    public interface ICartService
    {
        Task<Guid> CreateCartAsync(Guid userId);
        Task<UserCartDTO> GetUserCart(Guid userId);
        Task<UserCartDTO> GetCartById(Guid cartId);
        Task UpdateUserIdAsync(Guid userId, Guid cartId);
        Task DeleteCartAsync(Guid cartId);
        Task SaleAsync(Guid cartId);
        Task AddProductAsync(Guid cartId,string name,double price);
        Task DeleteProductAsync(Guid cartId, Guid courseId);
    }
}
