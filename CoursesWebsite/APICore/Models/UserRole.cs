using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICore.Models
{
    internal class UserRole
    {
        public Guid UserId { get; protected set; }
        public Guid RoleId { get; protected set;}
    }
}
