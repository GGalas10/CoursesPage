using APICore.Models;
using System;
using System.Threading.Tasks;


namespace Infrastructure.Services
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid id);
        Task<User> GetByLoginAsync(string login);
        Task<User> GetByEmailAsync(string email);
        Task RegisterAsync(User user);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(User user);
    }
}
