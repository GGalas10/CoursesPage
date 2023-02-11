using Courses.Core.Value_Object;

namespace Courses.Infrastructure.Comands.User
{
    public class Register
    {
        public Name UserName { get; set; }
        public Email UserEmail { get; set; }
        public Name? Login { get; set; }
        public Password Password { get; set; }

    }
}
