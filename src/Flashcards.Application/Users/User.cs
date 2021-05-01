using System;

namespace Flashcards.Application.Users
{
    public class User : IEntity
    {
        public Guid Id { get; protected set; }
        public string Email { get; protected set; }
        public Role Role { get; set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }

        protected User() { }

        public User(string email, Role role, string password, string salt)
        {
            Id = Guid.NewGuid();
            Email = email;
            Role = role;
            Password = password;
            Salt = salt;
        }

        public UserDto ToDto()
            => new UserDto(Id, Email, Role);
    }
}
