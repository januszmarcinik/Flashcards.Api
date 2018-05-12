using System;

namespace Flashcards.WindowsUI.Models
{
    class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }

    enum Role
    {
        Admin = 1,
        Moderator = 2,
        User = 3
    }
}
