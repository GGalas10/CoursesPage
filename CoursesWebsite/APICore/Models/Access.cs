using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICore.Models
{
    public class Access
    {
        public Guid UserId { get; protected set; }
        public Guid CourseId { get; protected set; }
    }
}
