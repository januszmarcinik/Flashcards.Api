using System;
using Flashcards.Application.Users;

namespace Flashcards.Application.Tokens
{
    public interface ITokenService
    {
        JwtDto CreateToken(Guid id, string email, Role role);
    }
}
