using System;

namespace APICore.Models
{
    public class UserRole
    {
        public Guid UserId { get; protected set; }
        public Guid RoleId { get; protected set;}
    }
}
