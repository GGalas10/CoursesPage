using System.Security.Cryptography;
using System.Text;

namespace Courses.Infrastructure.Sercurity
{
    internal static class SecurityClass
    {
        public static string CreateSalt(Guid id)
        {
            byte[] salt = Encoding.Default.GetBytes(Convert.ToString(id));
            RandomNumberGenerator.Create().GetNonZeroBytes(salt);
            return Convert.ToBase64String(salt);
        }
        public static string HashPassword(string password,string salt)
        {
            byte[] saltedpassword = Encoding.Default.GetBytes(String.Concat(salt, password));
            var hash = SHA512.Create().ComputeHash(saltedpassword);
            return Convert.ToBase64String(hash);
        }
        public static bool ComparePassword(string Dbpassword,string password,string salt)
        {
            var hasedpassword = HashPassword(password,salt);
            return hasedpassword == Dbpassword;
        }
    }
}
