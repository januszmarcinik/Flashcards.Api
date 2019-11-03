using System.Collections.Generic;
using Flashcards.Core;

namespace Flashcards.Domain.Users
{
    public class GetAllUsersQuery : IQuery<IEnumerable<UserDto>>
    {
    }
}
