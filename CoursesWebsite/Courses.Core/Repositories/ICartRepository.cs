using Courses.Core.Models.Cart;

namespace Courses.Core.Repositories
{
    public interface ICartRepository
    {
        Task<Cart> GetCartByIdAsync(Guid cartId);
        Task<Cart> GetUserCartAsync(Guid userId);
        Task<List<Guid>> GetProductsInCartByIdAsync(Guid cartId);
        Task AddToCartAsync(CoursesCart course);
        Task RemoveFromCartAsync(CoursesCart course);
        Task CreateCartAsync(Cart cart);
        Task UpdateCartAsync();
        Task DeleteCartAsync(Guid cartId);
        Task Sale(Cart cart);
        Task ClearCartFromDatabase();
    }
}
