using Courses.Core.Models.Common;
using Courses.Core.Value_Object;

namespace Courses.Core.Models.User
{
    public class User : Entity
    {
        #region Properties
        public Name UserName { get; protected set; }
        public Email Email { get; protected set; }
        public Name Login { get; protected set; }
        public DateTime CreateAt { get; protected set; }
        public UserPassword UserPassword { get; set; }
        #endregion
        #region Constructors
        private User() { }
        public User(string userName, Email email, string? login) : base()
        {
            SetUserName(userName);
            SetEmail(email);
            if (login != null)
                SetLogin(login);
            else
                SetLogin(email);
            CreateAt = DateTime.UtcNow;
        }
        #endregion
        #region Methods
        public void SetEmail(string email)
        {
            Email = email.Trim();
        }
        public void SetLogin(string login)
        {
            Login = login.Trim();
        }
        public void SetUserName(string userName)
        {
            UserName = userName.Trim();
        }
        #endregion
    }
}