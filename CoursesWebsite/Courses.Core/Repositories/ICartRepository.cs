using Courses.Core.Models;

namespace Courses.Core.Repositories
{
    public interface ICartRepository
    {
        Task<Cart> GetCartByIdAsync(Guid cartId);
        Task<Cart> GetUserCartAsync(Guid userId);
        Task AddToCartAsync(CoursesCart course);
        Task RemoveFromCartAsync(CoursesCart course);
        Task CreateCartAsync(Cart cart);
        Task UpdateCartAsync();
        Task DeleteCartAsync(Guid cartId);
        Task Sale(Cart cart);
    }
}
