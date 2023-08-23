using Courses.Core.Models;
using Courses.Core.Models.User;
using Courses.Core.Repositories;
using Courses.Infrastructure.Services.Interfaces;

namespace Courses.Infrastructure.Database
{
    public static class DbInitialize
    {
        public async static void Initialize(CoursesDbContext context, IUserService userService,IRoleService roleService,IUserRepository userRepository,IRoleRepository roleRepository,ICartRepository cartRepostiory, IUserConfigService userConfigService) 
        {          
            if (!context.Roles.Any())
            {
                await roleService.CreateRoleAsync("Admin");
                await roleService.CreateRoleAsync("User");
            }
            User user;
            if (!context.Users.Any())
            {
                await userService.Initialize("root@root.com", "Root$123", "Admin", "Admin");
                user = await userRepository.GetByEmailAsync("root@root.com");
                var role = await roleRepository.GetRoleAsync("Admin");
                await roleService.AsignRoleAsync(user.Id, role.Id);
                
            }
        }
    }
}
