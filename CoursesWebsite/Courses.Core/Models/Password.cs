using value = Courses.Core.Value_Object;

namespace Courses.Core.Models
{
    public class Password
    {
        public Guid Id { get; protected set; }
        public value.Password NormalizedPassword { get; protected set; }
        public value.Name Salt { get; protected set; }
        private Password() { }
        public Password(value.Password normalizedPassword, value.Name salt)
        {
            Id = Guid.NewGuid();
            SetPassword(normalizedPassword);
            SetSalt(salt);
        }
        public void SetPassword(value.Password password)
        {
            NormalizedPassword = password;
        }
        public void SetSalt(string salt)
        {
            Salt = salt;
        }
    }
}
