using System.ComponentModel.DataAnnotations.Schema;

namespace Courses.Core.Models.Users
{
    public class UserConfiguration
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string Theme { get; set; }
        public string Region { get; set; }

        private UserConfiguration() { }
        public UserConfiguration(User user,string theme,string Region) 
        {
            if(user == null) 
                throw new Exception("User cannot be null or empty");
            UserId = user.Id == Guid.Empty ? throw new Exception("User id cannot be null or empty") : user.Id ;
            User = user;
            SetRegion(Region); 
            SetTheme(theme);
        }
        public void SetRegion(string region) 
        {
            if (string.IsNullOrEmpty(region))
                throw new Exception("Region cannot be null or empty");
            Region = region;
        }
        public void SetTheme(string theme) 
        {
            if (string.IsNullOrEmpty(theme))
                throw new Exception("Theme name cannot be null or empty");
            Theme = theme;
        }
        public void UpdateUserConfiguration(string? region,string? theme)
        {
            if(!string.IsNullOrEmpty(region))
                SetRegion(region);
            if(!string.IsNullOrEmpty(theme))
                SetTheme(theme);
                    }
    }
}
