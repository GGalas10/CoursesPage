using Courses.Core.Repositories;
using Courses.Infrastructure.Repositories;
using Courses.Infrastructure.Services;
using Courses.Infrastructure.Services.Interfaces;
using Courses.Infrastructure.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Courses.Infrastructure
{
    public static class InfrastructureDeependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IJwtHandler, JwtHandler>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ICourseService, CoursesService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ICoursesRepository, CoursesRepository>();
            services.AddScoped<IPasswordRepository, PasswordRepository>();
            services.AddScoped<ICartRepository, CartRepostiory>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUserConfigRepository, UserConfigRepository>();
            services.AddScoped<IUserConfigService, UserConfigService>();
            services.AddScoped<IAdminPanelRepository, AdminPanelRepository>();
            services.AddScoped<IAdminUserService, AdminUserService>();
            return services;
        }
    }
}
