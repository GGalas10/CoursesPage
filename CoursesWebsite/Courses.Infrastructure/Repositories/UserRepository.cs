using Courses.Core.Models.Commons;
using Courses.Core.Models.Users;
using Courses.Core.Repositories;
using Courses.Infrastructure.Database;
using Courses.Infrastructure.Extensions;
using Courses.Infrastructure.Sercurity;
using Microsoft.EntityFrameworkCore;

namespace Courses.Infrastructure.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly CoursesDbContext _context;
        private readonly IPasswordRepository _passwordRepository;
        public UserRepository(CoursesDbContext context, IPasswordRepository passwordRepository)
        {
            _context = context;
            _passwordRepository = passwordRepository;
        }
        public async Task<User> GetByIdAsync(Guid id)
        => await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        public async Task<User> GetByLoginAsync(string login)
        => await _context.Users.Include(u => u.UserPassword).FirstOrDefaultAsync(u=>u.Login.Value == login);
        public async Task<User> GetByEmailAsync(string email)
        {
            var user = await _context.Users.Include(u => u.UserPassword).FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }
        public async Task RegisterAsync(User user,string password)
        {
            await _context.Users.AddAsync(user);
            await UpdateAsync();
            var newUser = await this.GetByEmailAsync(user.Email);
            var salt = SecurityClass.CreateSalt(newUser.Id);
            var pass = SecurityClass.HashPassword(password,salt);
            var newpass = new UserPassword(pass, salt,user);
            _context.Password.Add(newpass);
            if (await UpdateAsync())
                await Task.CompletedTask;
            else
                throw new Exception($"Register can't be done.\nDatabase do not save value");
        }
        public async Task DeleteAsync(Guid id)
        {
            var user = await this.GetOrFailByIdAsync(id);
            user.SetState(State.Deleted);
            if (await UpdateAsync())
                await Task.CompletedTask;
            else
                throw new Exception("Database do not save value");
        } 
        public async Task<bool> UpdateAsync()
        {
            return (_context.SaveChanges() > 0) ? true:false;
        }

    }
}
