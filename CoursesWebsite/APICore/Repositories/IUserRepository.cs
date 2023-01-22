using APICore.Models;
using System;
using System.Threading.Tasks;


namespace Infrastructure.Services
{
    public interface IUserRepository
    {
        Task<User> GetAsync(Guid id);
        Task<User> GetByLoginAsync(string login,string password);
        Task<User> GetByEmailAsync(string email, string password);
        Task RegisterAsync(User user);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(User user);
    }
}
