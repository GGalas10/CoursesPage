﻿// <auto-generated />
using System;
using Courses.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Courses.API.Migrations
{
    [DbContext(typeof(CoursesDbContext))]
    partial class CoursesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CategoryCourse", b =>
                {
                    b.Property<Guid>("CategoriesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CategoriesId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("CategoryCourse");
                });

            modelBuilder.Entity("Courses.Core.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Courses.Core.Models.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Courses.Core.Models.Lesson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<Guid>("TopicId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TopicId");

                    b.ToTable("lessons");
                });

            modelBuilder.Entity("Courses.Core.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Courses.Core.Models.Topic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("topics");
                });

            modelBuilder.Entity("Courses.Core.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Courses.Core.Models.UserPassword", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Password");
                });

            modelBuilder.Entity("Courses.Core.Models.UserRole", b =>
                {
                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.ToTable("UsersRoles");
                });

            modelBuilder.Entity("CategoryCourse", b =>
                {
                    b.HasOne("Courses.Core.Models.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Courses.Core.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Courses.Core.Models.Category", b =>
                {
                    b.OwnsOne("Courses.Core.Value_Object.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("CategoryId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Name");

                            b1.HasKey("CategoryId");

                            b1.ToTable("Categories");

                            b1.WithOwner()
                                .HasForeignKey("CategoryId");
                        });

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("Courses.Core.Models.Course", b =>
                {
                    b.OwnsOne("Courses.Core.Value_Object.Name", "Author", b1 =>
                        {
                            b1.Property<Guid>("CourseId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Author");

                            b1.HasKey("CourseId");

                            b1.ToTable("Courses");

                            b1.WithOwner()
                                .HasForeignKey("CourseId");
                        });

                    b.OwnsOne("Courses.Core.Value_Object.Name", "Description", b1 =>
                        {
                            b1.Property<Guid>("CourseId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Description");

                            b1.HasKey("CourseId");

                            b1.ToTable("Courses");

                            b1.WithOwner()
                                .HasForeignKey("CourseId");
                        });

                    b.OwnsOne("Courses.Core.Value_Object.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("CourseId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Name");

                            b1.HasKey("CourseId");

                            b1.ToTable("Courses");

                            b1.WithOwner()
                                .HasForeignKey("CourseId");
                        });

                    b.OwnsOne("Courses.Core.Value_Object.DigitalItem", "Picutre", b1 =>
                        {
                            b1.Property<Guid>("CourseId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<byte[]>("Value")
                                .IsRequired()
                                .HasColumnType("varbinary(max)")
                                .HasColumnName("Picture");

                            b1.HasKey("CourseId");

                            b1.ToTable("Courses");

                            b1.WithOwner()
                                .HasForeignKey("CourseId");
                        });

                    b.Navigation("Author")
                        .IsRequired();

                    b.Navigation("Description")
                        .IsRequired();

                    b.Navigation("Name")
                        .IsRequired();

                    b.Navigation("Picutre")
                        .IsRequired();
                });

            modelBuilder.Entity("Courses.Core.Models.Lesson", b =>
                {
                    b.HasOne("Courses.Core.Models.Topic", "Topic")
                        .WithMany("Lessons")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Courses.Core.Value_Object.Name", "LessonDescription", b1 =>
                        {
                            b1.Property<Guid>("LessonId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("LessonDescription");

                            b1.HasKey("LessonId");

                            b1.ToTable("lessons");

                            b1.WithOwner()
                                .HasForeignKey("LessonId");
                        });

                    b.OwnsOne("Courses.Core.Value_Object.Name", "LessonName", b1 =>
                        {
                            b1.Property<Guid>("LessonId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("LessonName");

                            b1.HasKey("LessonId");

                            b1.ToTable("lessons");

                            b1.WithOwner()
                                .HasForeignKey("LessonId");
                        });

                    b.OwnsOne("Courses.Core.Value_Object.DigitalItem", "Video", b1 =>
                        {
                            b1.Property<Guid>("LessonId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<byte[]>("Value")
                                .IsRequired()
                                .HasColumnType("varbinary(max)")
                                .HasColumnName("Video");

                            b1.HasKey("LessonId");

                            b1.ToTable("lessons");

                            b1.WithOwner()
                                .HasForeignKey("LessonId");
                        });

                    b.OwnsOne("Courses.Core.Value_Object.Number", "LessonNumber", b1 =>
                        {
                            b1.Property<Guid>("LessonId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Value")
                                .HasColumnType("int")
                                .HasColumnName("LessonNumber");

                            b1.HasKey("LessonId");

                            b1.ToTable("lessons");

                            b1.WithOwner()
                                .HasForeignKey("LessonId");
                        });

                    b.Navigation("LessonDescription")
                        .IsRequired();

                    b.Navigation("LessonName")
                        .IsRequired();

                    b.Navigation("LessonNumber")
                        .IsRequired();

                    b.Navigation("Topic");

                    b.Navigation("Video")
                        .IsRequired();
                });

            modelBuilder.Entity("Courses.Core.Models.Role", b =>
                {
                    b.OwnsOne("Courses.Core.Value_Object.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("RoleId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Name");

                            b1.HasKey("RoleId");

                            b1.ToTable("Roles");

                            b1.WithOwner()
                                .HasForeignKey("RoleId");
                        });

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("Courses.Core.Models.Topic", b =>
                {
                    b.HasOne("Courses.Core.Models.Course", "Course")
                        .WithMany("Topics")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Courses.Core.Value_Object.Name", "Description", b1 =>
                        {
                            b1.Property<Guid>("TopicId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Description");

                            b1.HasKey("TopicId");

                            b1.ToTable("topics");

                            b1.WithOwner()
                                .HasForeignKey("TopicId");
                        });

                    b.OwnsOne("Courses.Core.Value_Object.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("TopicId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Name");

                            b1.HasKey("TopicId");

                            b1.ToTable("topics");

                            b1.WithOwner()
                                .HasForeignKey("TopicId");
                        });

                    b.Navigation("Course");

                    b.Navigation("Description")
                        .IsRequired();

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("Courses.Core.Models.User", b =>
                {
                    b.OwnsOne("Courses.Core.Value_Object.Name", "Login", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Login");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Courses.Core.Value_Object.Name", "UserName", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("UserName");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Courses.Core.Value_Object.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Email");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Login")
                        .IsRequired();

                    b.Navigation("UserName")
                        .IsRequired();
                });

            modelBuilder.Entity("Courses.Core.Models.UserPassword", b =>
                {
                    b.HasOne("Courses.Core.Models.User", "User")
                        .WithOne("UserPassword")
                        .HasForeignKey("Courses.Core.Models.UserPassword", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Courses.Core.Value_Object.Name", "Salt", b1 =>
                        {
                            b1.Property<Guid>("UserPasswordId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Salt");

                            b1.HasKey("UserPasswordId");

                            b1.ToTable("Password");

                            b1.WithOwner()
                                .HasForeignKey("UserPasswordId");
                        });

                    b.OwnsOne("Courses.Core.Value_Object.Password", "NormalizedPassword", b1 =>
                        {
                            b1.Property<Guid>("UserPasswordId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("NormalizedPassword");

                            b1.HasKey("UserPasswordId");

                            b1.ToTable("Password");

                            b1.WithOwner()
                                .HasForeignKey("UserPasswordId");
                        });

                    b.Navigation("NormalizedPassword")
                        .IsRequired();

                    b.Navigation("Salt")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Courses.Core.Models.Course", b =>
                {
                    b.Navigation("Topics");
                });

            modelBuilder.Entity("Courses.Core.Models.Topic", b =>
                {
                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("Courses.Core.Models.User", b =>
                {
                    b.Navigation("UserPassword")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}