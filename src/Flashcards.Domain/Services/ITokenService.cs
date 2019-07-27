using System;
using Flashcards.Domain.Enums;

namespace Flashcards.Domain.Services
{
    public interface ITokenService
    {
        JwtDto CreateToken(Guid id, string email, Role role);
    }
}
