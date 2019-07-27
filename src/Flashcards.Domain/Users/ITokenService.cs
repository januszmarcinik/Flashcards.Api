using System;

namespace Flashcards.Domain.Users
{
    public interface ITokenService
    {
        JwtDto CreateToken(Guid id, string email, Role role);
    }
}
