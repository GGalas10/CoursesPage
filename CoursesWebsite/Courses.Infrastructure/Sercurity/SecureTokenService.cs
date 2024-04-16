using System.Security.Cryptography;
using System.Text;

namespace Courses.Infrastructure.Sercurity
{
    public static class SecureTokenService
    {
        private const string Key = "bX67FIpMh1c8HU657B/oNOKJ8I010CL5QX9mTTCxkhUqg03Dwk4AiRP+q9Z212Wr";
        public static string EncryptToken(string token)
        {
            byte[] hashedKey;
            using (SHA256 sha256 = SHA256.Create())
            {
                hashedKey = sha256.ComputeHash(Encoding.UTF8.GetBytes(Key));
            }
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = hashedKey;
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(token);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }
        public static string DecryptToken(string token)
        {
            byte[] hashedKey;
            using (SHA256 sha256 = SHA256.Create())
            {
                hashedKey = sha256.ComputeHash(Encoding.UTF8.GetBytes(Key));
            }
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(token);

            using (Aes aes = Aes.Create())
            {
                aes.Key = hashedKey;
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
