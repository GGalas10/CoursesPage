using Courses.Infrastructure.Services;
using Courses.Infrastructure.Settings;
using Courses.Infrastructure.Mappers;
using Courses.Core.Repositories;
using Courses.Infrastructure.Repositories;
using Courses.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Microsoft.AspNetCore.Authentication.Cookies;

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
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevDb"));
});

builder.Services.AddSingleton<IJwtHandler, JwtHandler>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICourseService, CoursesService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository,RoleRepository>();
builder.Services.AddScoped<ICoursesRepository,CoursesRepository>();
builder.Services.AddScoped<IPasswordRepository, PasswordRepository>();

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddCookie().AddJwtBearer(o =>
{
    o.SaveToken = true;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience= true,
        ValidateIssuer= true,
        IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
    o.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            context.Token = context.Request.Cookies["Bearer"];
            return Task.CompletedTask;
        }
    };
}).AddCookie("AdminCookie", options =>
{
    options.LoginPath = "/API/PAdmin/Login";
    options.LogoutPath = "/API/PAdmin/Login";
}).AddCookie("UserCookie", options =>
{
    options.LoginPath = "/User/Login";
    options.LogoutPath= "/";
});
builder.Services.AddAuthorization();
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
        response.Redirect("/Unauthorized");
});
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
