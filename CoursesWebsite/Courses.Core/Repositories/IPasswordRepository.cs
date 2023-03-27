using Courses.Core.Models.User;

namespace Courses.Core.Repositories
{
    public interface IPasswordRepository
    {
        public Task<UserPassword> GetByIdAsync(Guid id);
        public Task CreateAsync(UserPassword password);
        public Task UpdateAsync();

    }
}
