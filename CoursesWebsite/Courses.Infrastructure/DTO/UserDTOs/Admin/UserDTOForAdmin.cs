using Courses.Core.Models.Users;

namespace Courses.Infrastructure.DTO.UserDTOs.Admin
{
    public class UserDTOForAdmin
    {
        public string UserName { get; set; }


        public static UserDTOForAdmin GetDTOFromUser(User user) 
        {
            return new UserDTOForAdmin
            {
                UserName = user.UserName,
            };
        }
    }
}
