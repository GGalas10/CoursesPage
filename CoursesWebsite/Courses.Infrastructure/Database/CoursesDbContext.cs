using Courses.Core.Models.Carts;
using Courses.Core.Models.Categories;
using Courses.Core.Models.Commons;
using Courses.Core.Models.Courses;
using Courses.Core.Models.Invoicing;
using Courses.Core.Models.Invoicing.Settings;
using Courses.Core.Models.Orders;
using Courses.Core.Models.Users;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CoursesCart> coursesCarts { get; set; }
        public DbSet<CoursesCategory> coursesCategories { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceSettings> invoiceSettings { get; set; }
        public DbSet<InvoicingCourses> invoicingCourses { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Recipient> Recipients { get; set; }
        public DbSet<UserConfiguration> UserConfigurations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderCourses> OrderCourses { get; set; }

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
                entity.OwnsOne(p => p.NormalizedPassword, a => { a.Property(p => p.Value).HasColumnName("NormalizedPassword"); });
                entity.OwnsOne(s => s.Salt, a => { a.Property(p => p.Value).HasColumnName("Salt"); });
                entity.HasOne(u => u.User).WithOne(up => up.UserPassword).HasForeignKey<UserPassword>(fk => fk.UserId);
            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.HasOne(p => p.UserPassword).WithOne(up => up.User);
                entity.OwnsOne(n => n.UserName, a => { a.Property(p => p.Value).HasColumnName("UserName"); });
                entity.OwnsOne(n => n.Login, a => { a.Property(p => p.Value).HasColumnName("Login"); });
            });
            modelBuilder.Entity<Course>(entity =>
            {
                entity.OwnsOne(n => n.Name, a => { a.Property(p => p.Value).HasColumnName("Name"); });
                entity.OwnsOne(d => d.Description, a => { a.Property(p => p.Value).HasColumnName("Description"); });
                entity.OwnsOne(a => a.Author, a => { a.Property(p => p.Value).HasColumnName("Author"); });
                entity.OwnsOne(p => p.Picutre, a => { a.Property(p => p.Value).HasColumnName("Picture"); });
                entity.HasMany(t => t.Topics).WithOne(t => t.Course);
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
                entity.OwnsOne(n => n.Name, a => { a.Property(p => p.Value).HasColumnName("Name"); });
            });
            modelBuilder.Entity<UserRole>()
                .HasKey(pk => pk.UserId);

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.HasMany(mC => mC._coursesCart).WithOne(oC => oC.Cart);
            });


            modelBuilder.Entity<CoursesCart>(entity =>
            {
                entity.HasKey(pk => pk.Id);
                entity.HasOne(fk => fk.Cart).WithMany(fk => fk._coursesCart);
            });
                

            modelBuilder.Entity<CoursesCategory>()
                .HasKey(pk => pk.Id);
            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(pk => pk.Id);
                entity.HasMany(fk => fk.Courses).WithOne(fk => fk.Invoice);
            });
                
            modelBuilder.Entity<InvoiceSettings>()
                .HasNoKey();
            modelBuilder.Entity<InvoicingCourses>(entity =>
            {
                entity.HasKey(pk => pk.CourseId);
                entity.HasOne(fk => fk.Invoice);
            });
            modelBuilder.Entity<Buyer>()
                .HasKey(pk => pk.Id);
            modelBuilder.Entity<Recipient>()
                .HasKey(pk => pk.Id);
                
        }
    }
}
