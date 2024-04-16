namespace Courses.Infrastructure.DTO
{
    public class LoginModel
    {
        public JWTDTO tokenJWT { get; set; }
        public string refreshToken { get; set; }
    }
}
