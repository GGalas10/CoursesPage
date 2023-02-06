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
        public DateTime CreateAt { get; protected set; }
        public State state { get; protected set; }
        public IEnumerable<Guid> PurchasedCourses => _purchasedCourses;
        #endregion
        #region Constructors
        public User(string userName, Email email, string password):base()
        {
            _purchasedCourses = new HashSet<Guid>();
            SetUserName(userName);
            SetEmail(email);
            SetPassword(password);
            SetLogin(email);
            state = State.Active;
            CreateAt= DateTime.UtcNow;
        }
        public User(string userName, Email email, string password, string login) : base()
        {
            _purchasedCourses = new HashSet<Guid>();
            SetUserName(userName);
            SetEmail(email);
            SetPassword(password);
            SetLogin(login);
            state = State.Active;
            CreateAt = DateTime.UtcNow;
        }
        #endregion
        #region Methods
        public void SetEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new Exception("Email cannot be empty");
            this.Email= email.Trim();
        }
        public void SetPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new Exception("Password cannot be empty");
            this.Password= password.Trim();
        }
        public void SetLogin(string login)
        {
            if (string.IsNullOrEmpty(login))
                throw new Exception("Login cannot be empty");
            this.Login= login.Trim();
        }
        public void SetUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                throw new Exception("User Name cannot be empty");
            this.UserName= userName.Trim();
        }
        public void CoursesBuy(Guid id)
        => _purchasedCourses.Add(id);
        public void DeleteCourses(Guid id)
            => _purchasedCourses.Remove(id);
        public void SetState(State newstate)
            => state = newstate;
        #endregion
    }
}