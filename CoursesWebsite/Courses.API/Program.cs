using Courses.API.HostedService;
using Courses.API.Middlewares;
using Courses.Core.Repositories;
using Courses.Infrastructure.Database;
using Courses.Infrastructure.Mappers;
using Courses.Infrastructure.Repositories;
using Courses.Infrastructure.Services;
using Courses.Infrastructure.Services.Interfaces;
using Courses.Infrastructure.Services.Services;
using Courses.Infrastructure.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddRazorPages();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMvc();

builder.Services.AddSingleton(AutoMapperConfig.Initialize());

builder.Services.AddDbContext<CoursesDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
        ,x=>x.MigrationsAssembly("Courses.API"));
});

#region Services
builder.Services.AddSingleton<IJwtHandler, JwtHandler>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<ICourseService, CoursesService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository,RoleRepository>();
builder.Services.AddScoped<ICoursesRepository,CoursesRepository>();
builder.Services.AddScoped<IPasswordRepository, PasswordRepository>();
builder.Services.AddScoped<ICartRepository, CartRepostiory>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IUserConfigRepository, UserConfigRepository>();
builder.Services.AddScoped<IUserConfigService, UserConfigService>();

#endregion

builder.Services.AddHostedService<CartHostedService>();

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddCookie().AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateAudience = false
    };
    o.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            context.Token = context.Request.Cookies["Bearer"];
            return Task.CompletedTask;
        }
    };
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseStatusCodePages(async context =>
{
    var response = context.HttpContext.Response;

    if (response.StatusCode == (int)HttpStatusCode.Unauthorized ||
            response.StatusCode == (int)HttpStatusCode.Forbidden)
        response.Redirect("/Home/Unauthorized");
});
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
var _cartSerivce = app.Services.CreateScope();
app.UseMiddleware<CheckCartMiddleware>(_cartSerivce.ServiceProvider.GetService<ICartService>());
app.UseMiddleware<ErrorHandlerMiddleware>();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
