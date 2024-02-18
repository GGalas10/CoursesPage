using Courses.Core.Models.Carts;
using Courses.Core.Repositories;
using Courses.DataAccess.Context;
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
        => await _context.Carts.FirstOrDefaultAsync(c => c.Id == cartId);
        public async Task<Cart> GetUserCartAsync(Guid userId)
        => await _context.Carts.FirstOrDefaultAsync(c=>c.UserId == userId);
        public async Task<List<Guid>> GetProductsInCartByIdAsync(Guid cartId)
            => await _context.coursesCarts.Where(c=>c.Id == cartId).Select(c=>c.CourseId).ToListAsync();
        public async Task AddToCartAsync(CoursesCart course)
        {
            await _context.coursesCarts.AddAsync(course);
            await UpdateCartAsync();
        }
        public async Task RemoveFromCartAsync(CoursesCart course) 
        {
            _context.coursesCarts.Remove(course);
            await UpdateCartAsync();
        }
        public async Task CreateCartAsync(Cart cart)
        {
            await _context.Carts.AddAsync(cart);
            await UpdateCartAsync();
        }

        public async Task DeleteCartAsync(Guid cartId)
        {
            var cart = await _context.Carts.FirstOrDefaultAsync(c=>c.Id== cartId);
            _context.Remove(cart);
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
