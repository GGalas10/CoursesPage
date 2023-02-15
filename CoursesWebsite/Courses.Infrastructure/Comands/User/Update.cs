using Courses.Core.Value_Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Infrastructure.Comands.User
{
    public record Update
    {
        public Email Email { get; set; }
        public string Login {get;set;}
        public string Password { get; set; }
    }
}
