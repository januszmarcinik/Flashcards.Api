using Flashcards.Core.Exceptions;
using Flashcards.Core.Extensions;
using Flashcards.Domain.Data.Abstract;
using Flashcards.Domain.Enums;
using System;

namespace Flashcards.Domain.Entities
{
    public class User : Entity
    {
        public string Email { get; protected set; }
        public Role Role { get; set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }

        protected User() { }

        public User(string email, Role role, string password, string salt)
            : this(Guid.NewGuid(), email, role, password, salt) { }

        public User(Guid id, string email, Role role, string password, string salt)
        {
            SetId(id);
            SetRole(role);
            SetEmail(email);
            SetPassword(password, salt);
        }

        public void SetId(Guid id)
        {
            if (id.IsEmpty())
            {
                throw new FlashcardsException(ErrorCode.InvalidUserId);
            }

            Id = id;
        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new FlashcardsException(ErrorCode.InvalidUserEmail);
            }

            Email = email;
        }

        public void SetRole(Role role)
        {
            if (role == Role.Empty)
            {
                throw new FlashcardsException(ErrorCode.InvalidUserRole);
            }

            Role = role;
        }

        public void SetPassword(string password, string salt)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new FlashcardsException(ErrorCode.InvalidUserPassword);
            }
            if (string.IsNullOrEmpty(salt))
            {
                throw new FlashcardsException(ErrorCode.InvalidUserPasswordSalt);
            }

            Password = password;
            Salt = salt;
        }
    }
}
