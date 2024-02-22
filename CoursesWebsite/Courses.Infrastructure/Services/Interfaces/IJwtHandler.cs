using Courses.Infrastructure.DTO;

namespace Courses.Infrastructure.Services.Interfaces
{
    public interface IJwtHandler
    {
        JWTDTO CreateToken(Guid userId, string role);

        LoginModel LoginWithRefreshToken(RefreshTokenDTO refreshToken);
    }
}
