using Courses.Core.Value_Object;

namespace Courses.Core.Models
{
    public class User :Entity
    {
        #region Properties
        private readonly HashSet<Guid> _purchasedCourses = new HashSet<Guid>();
        public Name UserName { get; protected set; }
        public Email Email { get; protected set; }
        public Name Login { get; protected set; }
        public DateTime CreateAt { get; protected set; }
        public virtual UserPassword UserPassword { get; protected set; }
        public IEnumerable<Guid> PurchasedCourses => _purchasedCourses;
        #endregion
        #region Constructors
        private User() { }
        public User(string userName, Email email, string? login) : base()
        {
            _purchasedCourses = new HashSet<Guid>();
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
            Email= email.Trim();
        }
        public void SetLogin(string login)
        {
            Login= login.Trim();
        }
        public void SetUserName(string userName)
        {
            UserName= userName.Trim();
        }
        public void CoursesBuy(Guid id)
        => _purchasedCourses.Add(id);
        public void DeleteCourses(Guid id)
            => _purchasedCourses.Remove(id);
        public void SetSalt(UserPassword userPassword)
        {
            if (userPassword == null)
                throw new Exception("User password cannot be empty");
            UserPassword= userPassword;
        }
        #endregion
    }
}