using Courses.Core.Value_Object;

namespace Courses.Core.Models.User
{
    public class UserPassword
    {
        public Guid Id { get; set; }
        public Password NormalizedPassword { get; protected set; }
        public Name Salt { get; protected set; }
        public Guid UserId { get; set; }
        public User User { get; protected set; }
        private UserPassword() { }
        public UserPassword(Password normalizedPassword, Name salt, User user)
        {
            Id = Guid.NewGuid();
            SetPassword(normalizedPassword);
            SetSalt(salt);
            User = user;
        }
        public void SetPassword(Password password)
        {
            NormalizedPassword = password;
        }
        public void SetSalt(string salt)
        {
            Salt = salt;
        }
    }
}
