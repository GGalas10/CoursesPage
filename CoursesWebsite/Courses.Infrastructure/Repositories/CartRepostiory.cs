using Courses.Core.Models.Cart;
using Courses.Core.Repositories;
using Courses.Infrastructure.Database;
using Courses.Infrastructure.DTO;
using Microsoft.EntityFrameworkCore;

namespace Courses.Infrastructure.Repositories
{
    public class CartRepostiory : ICartRepository
    {
        private readonly CoursesDbContext _context;
        public CartRepostiory(CoursesDbContext context)
        {
            _context = context;
        }
        public async Task<Cart> GetCartByIdAsync(Guid cartId)
        => await Task.FromResult(_context.Carts.FirstOrDefault(c => c.Id == cartId));
        public async Task<Cart> GetUserCartAsync(Guid userId)
        => await Task.FromResult(_context.Carts.FirstOrDefault(c=>c.UserId == userId));
        public async Task<List<Guid>> GetProductsInCartByIdAsync(Guid cartId)
        {
            var productsGuids = await Task.FromResult(_context.coursesCarts.Where(c=>c.Id == cartId).Select(c=>c.CourseId));
            return productsGuids.ToList();
        }
        public async Task AddToCartAsync(CoursesCart course)
        {
            await Task.FromResult(_context.coursesCarts.Add(course));
            await UpdateCartAsync();
        }
        public async Task RemoveFromCartAsync(CoursesCart course) 
        {
            await Task.FromResult(_context.coursesCarts.Remove(course));
            await UpdateCartAsync();
        }
        public async Task CreateCartAsync(Cart cart)
        {
            await Task.FromResult(_context.Carts.Add(cart));
            await UpdateCartAsync();
        }

        public async Task DeleteCartAsync(Guid cartId)
        {
            var cart = _context.Carts.FirstOrDefault(c=>c.Id== cartId);
            await Task.FromResult(_context.Remove(cart));
            await UpdateCartAsync();
        }
        public async Task Sale(Cart cart)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateCartAsync()
        {
            if (await _context.SaveChangesAsync() > 0)
                await Task.CompletedTask;
            else
                throw new Exception("Database cannot save data");
        }
        public async Task ClearCartFromDatabase()
        {
            var allCart = await _context.Carts.ToListAsync();
            foreach(var cart in allCart)
            {
                if (cart.UpdatedAt.AddDays(30) <= DateTime.UtcNow)
                    await this.DeleteCartAsync(cart.Id);
            }
        }
    }
}
