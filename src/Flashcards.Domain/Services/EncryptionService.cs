﻿using System;
using System.Security.Cryptography;
using Flashcards.Core.Exceptions;

namespace Flashcards.Domain.Services
{
    public class EncryptionService
    {
        private const int DeriveBytesIterationsCount = 10000;
        private const int SaltSize = 40;

        public string GetSalt(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new FlashcardsException(ErrorCode.EmptyPasswordForGenerateSalt);
            }

            var saltBytes = new byte[SaltSize];
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

            var pbkdf2 = new Rfc2898DeriveBytes(value, GetBytes(salt), DeriveBytesIterationsCount);

            return Convert.ToBase64String(pbkdf2.GetBytes(SaltSize));
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