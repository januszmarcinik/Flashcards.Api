using System;

namespace Flashcards.Domain.Users
{
    public class UserDto
    {
        public UserDto(Guid id, string email, Role role)
        {
            Id = id;
            Email = email;
            Role = role;
        }

        public Guid Id { get; }
        public string Email { get; }
        public Role Role { get; }
    }
}
