using Courses.Core.Models.Commons;
using Courses.Core.Value_Object;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Courses.Core.Models.Users
{
    public class User : Entity
    {
        #region Properties
        public Name UserName { get; protected set; }
        [Column("Email")]
        public string Email { get; protected set; }
        public Name Login { get; protected set; }
        public DateTime CreateAt { get; protected set; }
        public UserPassword UserPassword { get; set; }
        #endregion
        #region Constructors
        private User() { }
        public User(string userName, string email, string? login) : base()
        {
            if (string.IsNullOrEmpty(userName))
                userName = login;
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
            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException("User email cannot be empty");
            var isValid = new EmailAddressAttribute().IsValid(email);
            if (!isValid)
                throw new ArgumentException("Email structure is invalid");
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