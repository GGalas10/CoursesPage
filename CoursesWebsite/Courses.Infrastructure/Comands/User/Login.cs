using Courses.Core.Value_Object;
using System.ComponentModel.DataAnnotations;

namespace Courses.Infrastructure.Comands.User
{

    public class Login
    {
        [Required]
        public Name Name { get; set; }
        [Required]
        public Name Password { get; set; }
    }
}
