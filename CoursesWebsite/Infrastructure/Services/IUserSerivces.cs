using APICore.Models;
using System;
using System.Threading.Tasks;


namespace Infrastructure.Services
{
    public interface IUserSerivces
    {
        Task<User> GetAsyncLogin(string login,string password);
        Task<User> GetAsyncEmail(string email, string password);
        Task CreateUserAsync(User user);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(User user);

    }
}
