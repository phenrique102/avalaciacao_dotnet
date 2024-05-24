using Application.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Services
{
    public class CryptService : ICryptService
    {
        public string GenerateSalt()
        {
            var bytes = new byte[128 / 8];
            using var keyGenerator = RandomNumberGenerator.Create();
            keyGenerator.GetBytes(bytes);
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }

        public string Hash(string input, string salt)
        {
            var hashedBytes = SHA256.HashData(Encoding.UTF8.GetBytes(input + salt));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }

        public bool Verify(string entered, string storedHash, string storedSalt)
        {
            var hashOfEnteredPassword = Hash(entered, storedSalt);
            return string.Equals(storedHash, hashOfEnteredPassword);
        }
    }
}
