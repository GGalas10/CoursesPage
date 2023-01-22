using APICore.Models;
using Courses.Infrastructure.DTO;

namespace Courses.Infrastructure.Services
{
    public interface IJwtHandler
    {
        JWTDTO CreateToken(Guid userId, Role role);
    }
}
