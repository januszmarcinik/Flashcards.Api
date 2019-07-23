using System;
using Flashcards.Domain.Enums;

namespace Flashcards.Domain.Dto
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
    }
}
