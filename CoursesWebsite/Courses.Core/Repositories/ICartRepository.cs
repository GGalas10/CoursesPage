using Courses.Core.Models;

namespace Courses.Core.Repositories
{
    public interface ICartRepository
    {
        Task<Cart> GetUserCartAsync(Guid userId);
        Task CreateCartAsync(Cart cart);
        Task UpdateCartAsync();
        Task DeleteCartAsync(Guid cartId);
        Task Sale(Cart cart);
    }
}
