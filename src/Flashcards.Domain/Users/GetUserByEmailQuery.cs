using Flashcards.Core;

namespace Flashcards.Domain.Users
{
    public class GetUserByEmailQuery : IQuery<UserDto>
    {
        public GetUserByEmailQuery(string email)
        {
            Email = email;
        }

        public string Email { get; }
    }
}
