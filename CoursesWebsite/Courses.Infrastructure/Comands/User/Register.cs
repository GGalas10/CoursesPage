using Courses.Core.Value_Object;

namespace Courses.Infrastructure.Comands.User
{
    public class Register
    {
        public string UserName { get; set; }
        public Email UserEmail { get; set; }
        public string? Login { get; set; }
        public Password Password { get; set; }

    }
}
