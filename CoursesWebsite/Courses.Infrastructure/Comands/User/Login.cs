using Courses.Core.Value_Object;
using System.ComponentModel.DataAnnotations;

namespace Courses.Infrastructure.Comands.User
{

    public class Login
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
