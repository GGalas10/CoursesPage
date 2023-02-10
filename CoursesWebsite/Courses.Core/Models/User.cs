using APICore.Object_Value;
using Courses.Core.Value_Object;
using System;
using System.Collections.Generic;

namespace Courses.Core.Models
{
    public class User :Entity
    {
        #region Properties
        private readonly HashSet<Guid> _purchasedCourses = new HashSet<Guid>();
        public Name UserName { get; protected set; }
        public Email Email { get; protected set; }
        public Name Password { get; protected set; }
        public Name Login { get; protected set; }
        public string Salt { get; protected set; }
        public DateTime CreateAt { get; protected set; }
        public IEnumerable<Guid> PurchasedCourses => _purchasedCourses;
        #endregion
        #region Constructors
        private User() { }
        public User(string userName, Email email, string password):base()
        {
            _purchasedCourses = new HashSet<Guid>();
            SetUserName(userName);
            SetEmail(email);
            SetPassword(password);
            SetLogin(email);
            CreateAt= DateTime.UtcNow;
        }
        public User(string userName, Email email, string password, string login) : base()
        {
            _purchasedCourses = new HashSet<Guid>();
            SetUserName(userName);
            SetEmail(email);
            SetPassword(password);
            SetLogin(login);
            CreateAt = DateTime.UtcNow;
        }
        #endregion
        #region Methods
        public void SetEmail(string email)
        {
            this.Email= email.Trim();
        }
        public void SetPassword(string password)
        {
            this.Password= password.Trim();
        }
        public void SetLogin(string login)
        {
            this.Login= login.Trim();
        }
        public void SetUserName(string userName)
        {
            this.UserName= userName.Trim();
        }
        public void CoursesBuy(Guid id)
        => _purchasedCourses.Add(id);
        public void DeleteCourses(Guid id)
            => _purchasedCourses.Remove(id);
        public void SetSalt(string salt)
        {
            if (string.IsNullOrEmpty(salt))
                throw new Exception("Salt cannot be empty");
            Salt = salt;
        }
        #endregion
    }
}