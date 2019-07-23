using Flashcards.Domain.Enums;
using System;
using Flashcards.Infrastructure.Managers.Concrete;

namespace Flashcards.Infrastructure.Managers.Abstract
{
    public interface IJwtManager
    {
        JwtDto CreateToken(Guid id, string email, Role role);
    }
}
