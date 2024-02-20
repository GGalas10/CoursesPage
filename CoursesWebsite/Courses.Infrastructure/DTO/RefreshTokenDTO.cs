namespace Courses.Infrastructure.DTO
{
    public class RefreshTokenDTO
    {
        public string RefreshToken { get; set; }
        public DateTime Expires { get; set; }
    }
}
