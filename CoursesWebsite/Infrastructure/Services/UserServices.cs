using APICore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserServices : IUserSerivces
    {
        public Task<User> GetAsyncLogin(string login, string password)
        {
            throw new NotImplementedException();
        }
        public Task<User> GetAsyncEmail(string email, string password)
        {
            throw new NotImplementedException();
        }
        public Task CreateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        } 
        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
