using Courses.Core.Models;
using Courses.Infrastructure.Services;

namespace Courses.Infrastructure.Database
{
    public static class DbInitialize
    {
        public async static void Initialize(CoursesDbContext context, IUserService userService,IRoleService roleService) 
        { 
            if(!context.Roles.Any())
            {
                await roleService.CreateRoleAsync("Admin");
                await roleService.CreateRoleAsync("User");
            }
            if (!context.Users.Any())
            {
                await userService.RegisterAsync("root@root.com", "Root$123", "Admin", "Admin"); 
            }
        }
    }
}
