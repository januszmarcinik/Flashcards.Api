using Flashcards.Core;

namespace Flashcards.Application.Users
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
