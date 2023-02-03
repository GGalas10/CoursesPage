using System;

namespace Courses.Core.Models
{
    public class UserRole
    {
        public Guid UserId { get; protected set; }
        public Guid RoleId { get; protected set; }
        public UserRole(Guid userId, Guid roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }       
    }
}
