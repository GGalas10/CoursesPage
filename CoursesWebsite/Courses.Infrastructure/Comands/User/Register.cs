using Courses.Core.Value_Object;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Courses.Infrastructure.Comands.User
{
    public class Register
    {
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

    }
}
