using System;

namespace Flashcards.Application.Users
{
    public interface ITokenService
    {
        JwtDto CreateToken(Guid id, string email, Role role);
    }
}
