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
                entity.OwnsOne(o => o.Name, a =>
                {
                    a.Property(p => p.Value).HasColumnName("Name");
                });
                entity.HasKey(k => k.Id);
            });
            modelBuilder.Entity<UserPassword>(entity =>
            {
                entity.HasKey(k => k.Id);
                entity.OwnsOne(p => p.NormalizedPassword, a =>{ a.Property(p => p.Value).HasColumnName("NormalizedPassword"); });
                entity.OwnsOne(s => s.Salt, a => { a.Property(p => p.Value).HasColumnName("Salt"); });
                entity.HasOne(u => u.User).WithOne(up => up.UserPassword).HasForeignKey<UserPassword>(fk => fk.UserId);
            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.HasOne(p => p.UserPassword).WithOne(up => up.User);
                entity.OwnsOne(n => n.UserName, a => { a.Property(p => p.Value).HasColumnName("UserName"); });
                entity.OwnsOne(n => n.Email, a => { a.Property(p => p.Value).HasColumnName("Email"); });
                entity.OwnsOne(n => n.Login, a => { a.Property(p => p.Value).HasColumnName("Login"); });
            });
            modelBuilder.Entity<Course>(entity =>
            {
                entity.OwnsOne(n => n.Name, a =>{ a.Property(p => p.Value).HasColumnName("Name"); });
                entity.OwnsOne(d => d.Description, a =>{ a.Property(p => p.Value).HasColumnName("Description"); });
                entity.OwnsOne(a => a.Author, a =>{ a.Property(p => p.Value).HasColumnName("Author"); });
                entity.OwnsOne(p => p.Picutre, a =>{ a.Property(p => p.Value).HasColumnName("Picture"); });
                entity.HasMany(t => t.Topics).WithOne(t => t.Course);
                entity.HasMany(c => c.Categories).WithMany(c => c.Course);
            });
            modelBuilder.Entity<Topic>(entity =>
            {
                entity.OwnsOne(n => n.Name, a => { a.Property(p => p.Value).HasColumnName("Name"); });
                entity.OwnsOne(d => d.Description, a => { a.Property(p => p.Value).HasColumnName("Description"); });
                entity.HasOne(c => c.Course);
                entity.HasMany(l => l.Lessons).WithOne(l => l.Topic);
            });
            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.OwnsOne(n => n.LessonName, a => { a.Property(p => p.Value).HasColumnName("LessonName"); });
                entity.OwnsOne(d => d.LessonDescription, a => { a.Property(p => p.Value).HasColumnName("LessonDescription"); });
                entity.OwnsOne(n => n.LessonNumber, a => { a.Property(p => p.Value).HasColumnName("LessonNumber"); });
                entity.OwnsOne(d => d.Video, a => { a.Property(p => p.Value).HasColumnName("Video"); });
                entity.HasOne(t => t.Topic);
            });
            modelBuilder.Entity<Category>(entity =>
            {
                entity.OwnsOne(n=>n.Name, a => { a.Property(p => p.Value).HasColumnName("Name"); });
                entity.HasMany(c => c.Course);
            });
            modelBuilder.Entity<UserRole>()
                .HasKey(pk => pk.UserId);
        }
    }
}
