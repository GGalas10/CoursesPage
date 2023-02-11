using Courses.Core.Value_Object;

namespace Courses.Infrastructure.Comands.User
{

    public class Login
    {
        public Name Name { get; set; }
        public Name Password { get; set; }
    }
}
