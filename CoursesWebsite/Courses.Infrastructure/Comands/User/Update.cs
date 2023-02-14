using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Infrastructure.Comands.User
{
    public record Update
    {
        string email { get; set; }
        string login {get;set;}
        string password { get; set; }
    }
}
