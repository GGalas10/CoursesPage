using Courses.Core.Models;
using Courses.Infrastructure.DTO;

namespace Courses.Infrastructure.Services.Interfaces
{
    public interface ICartService
    {
        Task<Guid> CreateCartAsync(Guid userId);
        Task<UserCartDTO> GetUserCart(Guid userId);
        Task<UserCartDTO> GetCartById(Guid cartId);
        Task UpdateUserIdAsync(Guid userId, Guid cartId);
        Task DeleteCartAsync(Guid CartId);
        Task SaleAsync(Guid CartId);
        Task AddProductAsync(Guid CartId,Guid id);
        Task DeleteProductAsync(Guid CartId, Guid id);
    }
}
