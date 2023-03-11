namespace Courses.Infrastructure.Services.Interfaces
{
    public interface ICartService
    {
        Task<Guid> CreateCartAsync(Guid userId);
        Task DeleteCartAsync(Guid CartId);
        Task SaleAsync(Guid CartId);
        Task AddProductAsync(Guid CartId,Guid id);
        Task DeleteProductAsync(Guid CartId, Guid id);
    }
}
