using System;
using System.Collections.Generic;

namespace APICore.Models
{
    public class User :Entity
    {
        #region Properties
        private readonly HashSet<Guid> _purchasedCourses = new HashSet<Guid>();
        public string UserName { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string Login { get; protected set; }
        public DateTime CreateAt { get; protected set; }
        public State state { get; protected set; }
        public IEnumerable<Guid> PurchasedCourses => _purchasedCourses;
        #endregion
        #region Constructors
        public User(string userName, string email, string password):base()
        {
            SetUserName(userName);
            SetEmail(email);
            SetPassword(password);
            SetLogin(email);
            state = State.Active;
            CreateAt= DateTime.UtcNow;
        }
        public User(string userName, string email, string password, string login) : base()
        {
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