using APICore.Models;
using Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Infrastructure.Extensions
{
    public static class RepositoryExtensions
    {
        public static async Task<User> GetOrFailASync(this IUserRepository repository,Guid id)
        {
            var @user = await repository.GetAsync(id);
            if (@user == null)
                throw new Exception("User doesn't exists");
            return @user;
        }
    }
}
