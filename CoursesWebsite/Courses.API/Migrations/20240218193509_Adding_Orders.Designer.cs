﻿// <auto-generated />
using System;
using Courses.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Courses.API.Migrations
{
    [DbContext(typeof(CoursesDbContext))]
    [Migration("20240218193509_Adding_Orders")]
    partial class Adding_Orders
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
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

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("Courses.Core.Models.Cart.CoursesCart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CartIdForCourses")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("CartIdForCourses");

                    b.ToTable("coursesCarts");
                });

            modelBuilder.Entity("Courses.Core.Models.Categories.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Courses.Core.Models.Categories.CoursesCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("coursesCategories");
                });

            modelBuilder.Entity("Courses.Core.Models.Commons.Address", b =>
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

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Courses.Core.Models.Courses.Course", b =>
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

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Courses.Core.Models.Courses.Lesson", b =>
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

            modelBuilder.Entity("Courses.Core.Models.Courses.Topic", b =>
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

                    b.ToTable("Buyers");
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

                    b.ToTable("Invoices");
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

                    b.ToTable("invoicingCourses");
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

                    b.ToTable("Recipients");
                });

            modelBuilder.Entity("Courses.Core.Models.Invoicing.Settings.InvoiceSettings", b =>
                {
                    b.Property<string>("InvoiceEnd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InvoicingNumber")
                        .HasColumnType("int");

                    b.ToTable("invoiceSettings");
                });

            modelBuilder.Entity("Courses.Core.Models.Orders.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Courses.Core.Models.Orders.OrderCourses", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderCourses");
                });

            modelBuilder.Entity("Courses.Core.Models.Users.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Courses.Core.Models.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Courses.Core.Models.Users.UserConfiguration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Theme")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserConfigurations");
                });

            modelBuilder.Entity("Courses.Core.Models.Users.UserPassword", b =>
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

            modelBuilder.Entity("Courses.Core.Models.Users.UserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId");

                    b.ToTable("UsersRoles");
                });

            modelBuilder.Entity("Courses.Core.Models.Cart.CoursesCart", b =>
                {
                    b.HasOne("Courses.Core.Models.Cart.Cart", null)
                        .WithMany("CoursesCart")
                        .HasForeignKey("CartId");

                    b.HasOne("Courses.Core.Models.Cart.Cart", "Cart")
                        .WithMany("_coursesCart")
                        .HasForeignKey("CartIdForCourses")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Courses.Core.Value_Object.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("CoursesCartId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("CoursesCartId");

                            b1.ToTable("coursesCarts");

                            b1.WithOwner()
                                .HasForeignKey("CoursesCartId");
                        });

                    b.Navigation("Cart");

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("Courses.Core.Models.Categories.Category", b =>
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

            modelBuilder.Entity("Courses.Core.Models.Courses.Course", b =>
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

            modelBuilder.Entity("Courses.Core.Models.Courses.Lesson", b =>
                {
                    b.HasOne("Courses.Core.Models.Courses.Topic", "Topic")
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

            modelBuilder.Entity("Courses.Core.Models.Courses.Topic", b =>
                {
                    b.HasOne("Courses.Core.Models.Courses.Course", "Course")
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

            modelBuilder.Entity("Courses.Core.Models.Invoicing.Buyer", b =>
                {
                    b.HasOne("Courses.Core.Models.Commons.Address", "Adress")
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

                    b.OwnsOne("Courses.Core.Value_Object.Name", "CourseName", b1 =>
                        {
                            b1.Property<Guid>("InvoicingCoursesCourseId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("InvoicingCoursesCourseId");

                            b1.ToTable("invoicingCourses");

                            b1.WithOwner()
                                .HasForeignKey("InvoicingCoursesCourseId");
                        });

                    b.Navigation("CourseName")
                        .IsRequired();

                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("Courses.Core.Models.Invoicing.Recipient", b =>
                {
                    b.HasOne("Courses.Core.Models.Commons.Address", "DeliveryAdress")
                        .WithMany()
                        .HasForeignKey("DeliveryAdressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeliveryAdress");
                });

            modelBuilder.Entity("Courses.Core.Models.Orders.OrderCourses", b =>
                {
                    b.HasOne("Courses.Core.Models.Orders.Order", null)
                        .WithMany("OrderCourses")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Courses.Core.Value_Object.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("OrderCoursesId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("OrderCoursesId");

                            b1.ToTable("OrderCourses");

                            b1.WithOwner()
                                .HasForeignKey("OrderCoursesId");
                        });

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("Courses.Core.Models.Users.Role", b =>
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

            modelBuilder.Entity("Courses.Core.Models.Users.User", b =>
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

                    b.Navigation("Login")
                        .IsRequired();

                    b.Navigation("UserName")
                        .IsRequired();
                });

            modelBuilder.Entity("Courses.Core.Models.Users.UserConfiguration", b =>
                {
                    b.HasOne("Courses.Core.Models.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Courses.Core.Models.Users.UserPassword", b =>
                {
                    b.HasOne("Courses.Core.Models.Users.User", "User")
                        .WithOne("UserPassword")
                        .HasForeignKey("Courses.Core.Models.Users.UserPassword", "UserId")
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

            modelBuilder.Entity("Courses.Core.Models.Cart.Cart", b =>
                {
                    b.Navigation("CoursesCart");

                    b.Navigation("_coursesCart");
                });

            modelBuilder.Entity("Courses.Core.Models.Courses.Course", b =>
                {
                    b.Navigation("Topics");
                });

            modelBuilder.Entity("Courses.Core.Models.Courses.Topic", b =>
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

            modelBuilder.Entity("Courses.Core.Models.Orders.Order", b =>
                {
                    b.Navigation("OrderCourses");
                });

            modelBuilder.Entity("Courses.Core.Models.Users.User", b =>
                {
                    b.Navigation("UserPassword")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
