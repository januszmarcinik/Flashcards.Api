using Flashcards.Domain.Exceptions;
using Flashcards.Infrastructure.Managers.Abstract;
using System;
using System.Security.Cryptography;

namespace Flashcards.Infrastructure.Managers.Concrete
{
    internal class EncryptionManager : IEncryptionManager
    {
        private const int _deriveBytesIterationsCount = 10000;
        private const int _saltSize = 40;

        public string GetSalt(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new FlashcardsException(ErrorCode.EmptyPasswordForGenerateSalt);
            }

            var saltBytes = new byte[_saltSize];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(saltBytes);

            return Convert.ToBase64String(saltBytes);
        }

        public string GetHash(string value, string salt)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new FlashcardsException(ErrorCode.EmptyPasswordForGenerateHash);
            }
            if (string.IsNullOrWhiteSpace(salt))
            {
                throw new FlashcardsException(ErrorCode.EmptySaltForGenerateHash);
            }

            var pbkdf2 = new Rfc2898DeriveBytes(value, GetBytes(salt), _deriveBytesIterationsCount);

            return Convert.ToBase64String(pbkdf2.GetBytes(_saltSize));
        }

        private byte[] GetBytes(string value)
        {
            var bytes = new byte[value.Length * sizeof(char)];

            Buffer.BlockCopy(value.ToCharArray(), 0, bytes, 0, bytes.Length);
            Buffer.BlockCopy(value.ToCharArray(), 0, bytes, 0, bytes.Length);

            return bytes;
        }
    }
}
