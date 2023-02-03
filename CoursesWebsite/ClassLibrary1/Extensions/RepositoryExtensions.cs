using Courses.Core.Models;
using Courses.Core.Repositories;

namespace Courses.Infrastructure.Extensions
{
    public static class RepositoryExtensions
    {
        public static async Task<User> GetOrFailByIdAsync(this IUserRepository repository,Guid id)
        {
            var @user = await repository.GetByIdAsync(id);
            if (@user == null)
                throw new Exception("User doesn't exists");
            return @user;
        }
        public static async Task<User> GetOrFailByLoginAsync(this IUserRepository repository, string login)
        {
            var @user = await repository.GetByLoginAsync(login);
            if (@user == null)
                throw new Exception("User doesn't exists");
            return @user;
        }
        public static async Task<User> GetOrFailByEmailAsync(this IUserRepository repository, string email)
        {
            var @user = await repository.GetByEmailAsync(email);
            if (@user == null)
                throw new Exception("User doesn't exists");
            return @user;
        }
    }
}
