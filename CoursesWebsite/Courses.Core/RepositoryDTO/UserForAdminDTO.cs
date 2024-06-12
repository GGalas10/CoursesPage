using Courses.Core.Models.Users;

namespace Courses.Core.RepositoryDTO
{
    public class UserForAdminDTO
    {
        public UserForAdminDTO() { }
        public UserForAdminDTO(User user) 
        {
            UserName = user.UserName;
        }
        public string UserName { get; set; }
        
    }
}
