namespace Courses.Infrastructure.DTO
{
    public class TokenDto
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string Role { get; set; }
        public long Expires { get; set; }
    }
}
