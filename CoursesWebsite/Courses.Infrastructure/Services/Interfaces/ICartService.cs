namespace Courses.Infrastructure.Services.Interfaces
{
    public interface ICartService
    {
        Task CreateCartAsync(Guid userId);
        Task DeleteCartAsync();
        Task SaleAsync();
        Task AddProductAsync(Guid id);
        Task DeleteProductAsync(Guid id);
    }
}
