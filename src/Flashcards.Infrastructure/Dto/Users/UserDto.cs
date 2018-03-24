using Flashcards.Domain.Enums;
using System;

namespace Flashcards.Infrastructure.Dto.Users
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
    }
}
