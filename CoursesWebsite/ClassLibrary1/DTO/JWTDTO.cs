using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Infrastructure.DTO
{
    public class JWTDTO
    {
        public string Token { get; set; }
        public long Expires { get; set; }
    }
}
