using Courses.Infrastructure.DTO.UserDTOs.Basic;

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
        Task AddProductAsync(Guid courseId, string name,double price, Guid cartId);
        Task DeleteProductAsync(Guid cartId, Guid courseId);
    }
}
