using System;
using System.Security.Cryptography;

namespace Flashcards.Domain.Users
{
    public class EncryptionService
    {
        private const int DeriveBytesIterationsCount = 10000;
        private const int SaltSize = 40;

        public string GetSalt(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            var saltBytes = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }

            return Convert.ToBase64String(saltBytes);
        }

        public string GetHash(string value, string salt)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (salt == null) throw new ArgumentNullException(nameof(salt));

            using (var pbkdf2 = new Rfc2898DeriveBytes(value, GetBytes(salt), DeriveBytesIterationsCount))
            {
                return Convert.ToBase64String(pbkdf2.GetBytes(SaltSize));
            }
        }

        private static byte[] GetBytes(string value)
        {
            var bytes = new byte[value.Length * sizeof(char)];

            Buffer.BlockCopy(value.ToCharArray(), 0, bytes, 0, bytes.Length);
            Buffer.BlockCopy(value.ToCharArray(), 0, bytes, 0, bytes.Length);

            return bytes;
        }
    }
}
