using Flashcards.Domain.Enums;
using Flashcards.Infrastructure.Dto.Tokens;
using System;

namespace Flashcards.Infrastructure.Managers.Abstract
{
    public interface IJwtManager
    {
        JwtDto CreateToken(Guid id, string email, Role role);
    }
}
