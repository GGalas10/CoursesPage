using Courses.Core.Models.Users;

namespace Courses.Infrastructure.DTO.UserDTOs
{
    public class UserSettingsDTO
    {
        public string email { get; set; }
        public string name { get; set; }
        public DateTime createAt { get; set; }

        public static UserSettingsDTO GetFromModel(User model)
        {
            return new UserSettingsDTO
            {
                email = model.Email,
                name = model.UserName,
                createAt = model.CreateAt,
            };
        }
    }
}
