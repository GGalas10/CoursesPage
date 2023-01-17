using System;

namespace APICore.Models
{
    public class UserRole
    {
        public UserRole(Guid userId, Guid roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }

        public Guid UserId { get; protected set;}
        public Guid RoleId { get; protected set;}
    }
}
