using Courses.Core.Models;

namespace Courses.Core.Repositories
{
    public interface IPasswordRepository
    {
        public Task<Password> GetByIdAsync(Guid id);
        public Task CreateAsync(Password password);
        public Task UpdateAsync(Password password);

    }
}
