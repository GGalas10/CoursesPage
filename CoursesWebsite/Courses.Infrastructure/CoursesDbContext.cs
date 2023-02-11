using Courses.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Courses.Infrastructure
{
    public class CoursesDbContext:DbContext
    {
        public CoursesDbContext(DbContextOptions<CoursesDbContext> options) : base(options) { }
        public DbSet<Course> Courses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UsersRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Topic> topics { get; set; }
        public DbSet<Lesson> lessons { get; set; }
        public DbSet<Password> Password { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasKey(x => x.Id);
        }
    }
}
