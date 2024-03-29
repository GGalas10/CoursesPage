﻿using Courses.Core.Value_Object;
using System.ComponentModel.DataAnnotations.Schema;

namespace Courses.Core.Models.Carts
{
    public class CoursesCart
    {
        public Guid Id { get; protected set; }
        public Guid CourseId { get; protected set; }
        public Name Name { get; protected set; }
        public double Price { get; protected set; }
        [ForeignKey("CartIdForCourses")]
        public Cart Cart { get; protected set; }
        private CoursesCart() { }
        public CoursesCart(Guid courseId,string name,double price,Cart cart)
        {
            Id = Guid.NewGuid();
            CourseId = courseId;
            SetName(name);
            SetPrice(price);
            SetCart(cart);
        }
        public void SetCart(Cart cart)
        {
            if (cart == null)
                throw new Exception("Cart cannot be null");
            Cart = cart;
        }
        public void SetName(string name) 
        { 
            Name = name;
        }
        public void SetPrice(double price)
        {
            if (price <= 0)
                throw new Exception("Price cannot be less or equal than zero");
            Price = Math.Round(price,2);
        }
    }
}
