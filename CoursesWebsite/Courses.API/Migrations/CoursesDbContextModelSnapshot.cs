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

            modelBuilder.Entity("Courses.Core.Models.Cart.Cart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Carts", (string)null);
                });

            modelBuilder.Entity("Courses.Core.Models.Cart.CoursesCart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CartId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("CartId1");

                    b.ToTable("coursesCarts", (string)null);
                });

            modelBuilder.Entity("Courses.Core.Models.Category.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);
                });

            modelBuilder.Entity("Courses.Core.Models.Category.CoursesCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("coursesCategories", (string)null);
                });

            modelBuilder.Entity("Courses.Core.Models.Common.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HomeNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Address", (string)null);
                });

            modelBuilder.Entity("Courses.Core.Models.Course.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Courses", (string)null);
                });

            modelBuilder.Entity("Courses.Core.Models.Course.Lesson", b =>
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

                    b.ToTable("lessons", (string)null);
                });

            modelBuilder.Entity("Courses.Core.Models.Course.Topic", b =>
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

                    b.ToTable("topics", (string)null);
                });

            modelBuilder.Entity("Courses.Core.Models.Invoicing.Buyer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AdressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NIN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdressId");

                    b.ToTable("Buyers", (string)null);
                });

            modelBuilder.Entity("Courses.Core.Models.Invoicing.Invoice", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("BuyerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("RecipientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BuyerId");

                    b.ToTable("Invoices", (string)null);
                });

            modelBuilder.Entity("Courses.Core.Models.Invoicing.InvoicingCourses", b =>
                {
                    b.Property<Guid>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BillId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("InvoiceId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("CourseId");

                    b.HasIndex("InvoiceId");

                    b.ToTable("invoicingCourses", (string)null);
                });

            modelBuilder.Entity("Courses.Core.Models.Invoicing.Recipient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DeliveryAdressId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryAdressId");

                    b.ToTable("Recipients", (string)null);
                });

            modelBuilder.Entity("Courses.Core.Models.Invoicing.Settings.InvoiceSettings", b =>
                {
                    b.Property<string>("InvoiceEnd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InvoicingNumber")
                        .HasColumnType("int");

                    b.ToTable("invoiceSettings", (string)null);
                });

            modelBuilder.Entity("Courses.Core.Models.User.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("Courses.Core.Models.User.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Courses.Core.Models.User.UserPassword", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Password", (string)null);
                });

            modelBuilder.Entity("Courses.Core.Models.User.UserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId");

                    b.ToTable("UsersRoles", (string)null);
                });

            modelBuilder.Entity("Courses.Core.Models.Cart.CoursesCart", b =>
                {
                    b.HasOne("Courses.Core.Models.Cart.Cart", "Cart")
                        .WithMany("_Carts")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Courses.Core.Models.Cart.Cart", null)
                        .WithMany("Carts")
                        .HasForeignKey("CartId1");

                    b.OwnsOne("Courses.Core.Models.Cart.CoursesCart.Name#Courses.Core.Value_Object.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("CoursesCartId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("CoursesCartId");

                            b1.ToTable("coursesCarts", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("CoursesCartId");
                        });

                    b.Navigation("Cart");

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("Courses.Core.Models.Category.Category", b =>
                {
                    b.OwnsOne("Courses.Core.Models.Category.Category.Name#Courses.Core.Value_Object.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("CategoryId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Name");

                            b1.HasKey("CategoryId");

                            b1.ToTable("Categories", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("CategoryId");
                        });

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("Courses.Core.Models.Course.Course", b =>
                {
                    b.OwnsOne("Courses.Core.Models.Course.Course.Author#Courses.Core.Value_Object.Name", "Author", b1 =>
                        {
                            b1.Property<Guid>("CourseId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Author");

                            b1.HasKey("CourseId");

                            b1.ToTable("Courses", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("CourseId");
                        });

                    b.OwnsOne("Courses.Core.Models.Course.Course.Description#Courses.Core.Value_Object.Name", "Description", b1 =>
                        {
                            b1.Property<Guid>("CourseId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Description");

                            b1.HasKey("CourseId");

                            b1.ToTable("Courses", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("CourseId");
                        });

                    b.OwnsOne("Courses.Core.Models.Course.Course.Name#Courses.Core.Value_Object.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("CourseId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Name");

                            b1.HasKey("CourseId");

                            b1.ToTable("Courses", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("CourseId");
                        });

                    b.OwnsOne("Courses.Core.Models.Course.Course.Picutre#Courses.Core.Value_Object.DigitalItem", "Picutre", b1 =>
                        {
                            b1.Property<Guid>("CourseId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<byte[]>("Value")
                                .IsRequired()
                                .HasColumnType("varbinary(max)")
                                .HasColumnName("Picture");

                            b1.HasKey("CourseId");

                            b1.ToTable("Courses", (string)null);

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

            modelBuilder.Entity("Courses.Core.Models.Course.Lesson", b =>
                {
                    b.HasOne("Courses.Core.Models.Course.Topic", "Topic")
                        .WithMany("Lessons")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Courses.Core.Models.Course.Lesson.LessonDescription#Courses.Core.Value_Object.Name", "LessonDescription", b1 =>
                        {
                            b1.Property<Guid>("LessonId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("LessonDescription");

                            b1.HasKey("LessonId");

                            b1.ToTable("lessons", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("LessonId");
                        });

                    b.OwnsOne("Courses.Core.Models.Course.Lesson.LessonName#Courses.Core.Value_Object.Name", "LessonName", b1 =>
                        {
                            b1.Property<Guid>("LessonId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("LessonName");

                            b1.HasKey("LessonId");

                            b1.ToTable("lessons", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("LessonId");
                        });

                    b.OwnsOne("Courses.Core.Models.Course.Lesson.LessonNumber#Courses.Core.Value_Object.Number", "LessonNumber", b1 =>
                        {
                            b1.Property<Guid>("LessonId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Value")
                                .HasColumnType("int")
                                .HasColumnName("LessonNumber");

                            b1.HasKey("LessonId");

                            b1.ToTable("lessons", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("LessonId");
                        });

                    b.OwnsOne("Courses.Core.Models.Course.Lesson.Video#Courses.Core.Value_Object.DigitalItem", "Video", b1 =>
                        {
                            b1.Property<Guid>("LessonId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<byte[]>("Value")
                                .IsRequired()
                                .HasColumnType("varbinary(max)")
                                .HasColumnName("Video");

                            b1.HasKey("LessonId");

                            b1.ToTable("lessons", (string)null);

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

            modelBuilder.Entity("Courses.Core.Models.Course.Topic", b =>
                {
                    b.HasOne("Courses.Core.Models.Course.Course", "Course")
                        .WithMany("Topics")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Courses.Core.Models.Course.Topic.Description#Courses.Core.Value_Object.Name", "Description", b1 =>
                        {
                            b1.Property<Guid>("TopicId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Description");

                            b1.HasKey("TopicId");

                            b1.ToTable("topics", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("TopicId");
                        });

                    b.OwnsOne("Courses.Core.Models.Course.Topic.Name#Courses.Core.Value_Object.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("TopicId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Name");

                            b1.HasKey("TopicId");

                            b1.ToTable("topics", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("TopicId");
                        });

                    b.Navigation("Course");

                    b.Navigation("Description")
                        .IsRequired();

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("Courses.Core.Models.Invoicing.Buyer", b =>
                {
                    b.HasOne("Courses.Core.Models.Common.Address", "Adress")
                        .WithMany()
                        .HasForeignKey("AdressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adress");
                });

            modelBuilder.Entity("Courses.Core.Models.Invoicing.Invoice", b =>
                {
                    b.HasOne("Courses.Core.Models.Invoicing.Buyer", null)
                        .WithMany("Invoices")
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Courses.Core.Models.Invoicing.InvoicingCourses", b =>
                {
                    b.HasOne("Courses.Core.Models.Invoicing.Invoice", "Invoice")
                        .WithMany("Courses")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Courses.Core.Models.Invoicing.InvoicingCourses.CourseName#Courses.Core.Value_Object.Name", "CourseName", b1 =>
                        {
                            b1.Property<Guid>("InvoicingCoursesCourseId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("InvoicingCoursesCourseId");

                            b1.ToTable("invoicingCourses", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("InvoicingCoursesCourseId");
                        });

                    b.Navigation("CourseName")
                        .IsRequired();

                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("Courses.Core.Models.Invoicing.Recipient", b =>
                {
                    b.HasOne("Courses.Core.Models.Common.Address", "DeliveryAdress")
                        .WithMany()
                        .HasForeignKey("DeliveryAdressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeliveryAdress");
                });

            modelBuilder.Entity("Courses.Core.Models.User.Role", b =>
                {
                    b.OwnsOne("Courses.Core.Models.User.Role.Name#Courses.Core.Value_Object.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("RoleId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Name");

                            b1.HasKey("RoleId");

                            b1.ToTable("Roles", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("RoleId");
                        });

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("Courses.Core.Models.User.User", b =>
                {
                    b.OwnsOne("Courses.Core.Models.User.User.Email#Courses.Core.Value_Object.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Email");

                            b1.HasKey("UserId");

                            b1.ToTable("Users", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Courses.Core.Models.User.User.Login#Courses.Core.Value_Object.Name", "Login", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Login");

                            b1.HasKey("UserId");

                            b1.ToTable("Users", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Courses.Core.Models.User.User.UserName#Courses.Core.Value_Object.Name", "UserName", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("UserName");

                            b1.HasKey("UserId");

                            b1.ToTable("Users", (string)null);

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

            modelBuilder.Entity("Courses.Core.Models.User.UserPassword", b =>
                {
                    b.HasOne("Courses.Core.Models.User.User", "User")
                        .WithOne("UserPassword")
                        .HasForeignKey("Courses.Core.Models.User.UserPassword", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Courses.Core.Models.User.UserPassword.NormalizedPassword#Courses.Core.Value_Object.Password", "NormalizedPassword", b1 =>
                        {
                            b1.Property<Guid>("UserPasswordId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("NormalizedPassword");

                            b1.HasKey("UserPasswordId");

                            b1.ToTable("Password", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("UserPasswordId");
                        });

                    b.OwnsOne("Courses.Core.Models.User.UserPassword.Salt#Courses.Core.Value_Object.Name", "Salt", b1 =>
                        {
                            b1.Property<Guid>("UserPasswordId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Salt");

                            b1.HasKey("UserPasswordId");

                            b1.ToTable("Password", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("UserPasswordId");
                        });

                    b.Navigation("NormalizedPassword")
                        .IsRequired();

                    b.Navigation("Salt")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Courses.Core.Models.Cart.Cart", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("_Carts");
                });

            modelBuilder.Entity("Courses.Core.Models.Course.Course", b =>
                {
                    b.Navigation("Topics");
                });

            modelBuilder.Entity("Courses.Core.Models.Course.Topic", b =>
                {
                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("Courses.Core.Models.Invoicing.Buyer", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("Courses.Core.Models.Invoicing.Invoice", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("Courses.Core.Models.User.User", b =>
                {
                    b.Navigation("UserPassword")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
