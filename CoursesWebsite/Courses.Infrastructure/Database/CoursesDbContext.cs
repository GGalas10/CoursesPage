using Courses.Core.Models;
using Courses.Core.Value_Object;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Courses.Infrastructure.Database
{
    public class CoursesDbContext : DbContext
    {
        public CoursesDbContext(DbContextOptions<CoursesDbContext> options) : base(options) { }
        public DbSet<Course> Courses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UsersRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Topic> topics { get; set; }
        public DbSet<Lesson> lessons { get; set; }
        public DbSet<UserPassword> Password { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>(entity =>
            {
                entity.OwnsOne(o => o.Name);
                entity.HasKey(k => k.Id);
            });
            modelBuilder.Entity<UserPassword>(entity =>
            {
                entity.HasKey(k => k.Id);
                entity.OwnsOne(p => p.NormalizedPassword);
                entity.OwnsOne(s => s.Salt);
            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.HasOne(p => p.UserPassword).WithOne(up => up.User);
                entity.UsePropertyAccessMode(PropertyAccessMode.PreferFieldDuringConstruction);
            });
            modelBuilder.Entity<Course>(entity =>
            {
                entity.OwnsOne(n => n.Name);
                entity.OwnsOne(d => d.Description);
                entity.OwnsOne(a => a.Author);
                entity.OwnsOne(p => p.Picutre);
                entity.HasMany(t => t.Topics).WithOne(t => t.Course);
                entity.HasMany(c => c.Categories).WithMany(c => c.Course);
            });
            modelBuilder.Entity<Topic>(entity =>
            {
                entity.OwnsOne(n => n.Name);
                entity.OwnsOne(d => d.Description);
                entity.HasOne(c => c.Course);
                entity.HasMany(l => l.Lessons).WithOne(l => l.Topic);
            });
            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.OwnsOne(n => n.LessonName);
                entity.OwnsOne(d => d.LessonDescription);
                entity.OwnsOne(n => n.LessonNumber);
                entity.OwnsOne(d => d.Video);
                entity.HasOne(t => t.Topic);
            });
            modelBuilder.Entity<Category>(entity =>
            {
                entity.OwnsOne(n=>n.Name);
                entity.HasMany(c => c.Course);
            });
            modelBuilder.Entity<UserRole>()
                .HasNoKey();
        }
    }
}
