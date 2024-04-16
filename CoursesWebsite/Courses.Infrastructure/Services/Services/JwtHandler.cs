using Courses.Core.Repositories;
using Courses.Infrastructure.DTO;
using Courses.Infrastructure.Extensions;
using Courses.Infrastructure.Sercurity;
using Courses.Infrastructure.Services.Interfaces;
using Courses.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Courses.Infrastructure.Services.Services
{
    public class JwtHandler : IJwtHandler
    {
        private readonly JwtSettings _jwtsettings;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        public JwtHandler(IOptions<JwtSettings> jwtsettings,IUserRepository userRepository,IRoleRepository roleRepository)
        {
            _jwtsettings = jwtsettings.Value;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }
        public JWTDTO CreateToken(Guid userId, string role)
        {
            var now = DateTime.UtcNow;
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(ClaimTypes.Role, role),
            };
            var expires = now.AddMinutes(_jwtsettings.ExpiryMinutes);
            var singingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtsettings.Key)),
                SecurityAlgorithms.HmacSha256);
            var jwt = new JwtSecurityToken(
                issuer: _jwtsettings.Issuer,
                claims: claims,
                notBefore: now,
                expires: expires,
                signingCredentials: singingCredentials);
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);
            return new JWTDTO
            {
                Token = SecureTokenService.EncryptToken(token),
                Expires = expires.ToTimestamp(),
            };
        }
        public async Task<LoginModel> LoginUserAsync(Guid userId)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(userId);
                var userRole = await _roleRepository.GetUserRole(user.Id);
                var refresh = CreateRefreshToken();
                user.SetRefreshToken(refresh.RefreshToken, refresh.Expires);
                await _userRepository.UpdateAsync();
                return new LoginModel()
                {
                    tokenJWT = CreateToken(user.Id, userRole.Name),
                    refreshToken = refresh.RefreshToken
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<LoginModel> LoginWithRefreshToken(string refreshToken)
        {
            try
            {
                if (refreshToken == null)
                    throw new Exception("Refresh token is empty");
                var user = await _userRepository.GetByRefreshToken(refreshToken);               
                if (user == null)
                    throw new Exception("Cannot find user with refresh token");
                var userRole = await _roleRepository.GetUserRole(user.Id);
                var refresh = CreateRefreshToken();
                user.SetRefreshToken(refresh.RefreshToken, refresh.Expires);
                await _userRepository.UpdateAsync();
                return new LoginModel()
                {
                    tokenJWT = CreateToken(user.Id, userRole.Name),
                    refreshToken = refresh.RefreshToken
                };
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private RefreshTokenDTO CreateRefreshToken()
        {
            var randomNumber = new byte[64];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            var refreshToken = new RefreshTokenDTO();
            
            refreshToken.Expires = DateTime.UtcNow.AddDays(7);
            refreshToken.RefreshToken = Convert.ToBase64String(randomNumber);

            return refreshToken;
        }
    }
}
