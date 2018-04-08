using Flashcards.Domain.Enums;
using Flashcards.Infrastructure.Dto.Tokens;

namespace Flashcards.Infrastructure.Managers.Abstract
{
    public interface IJwtManager
    {
        JwtDto CreateToken(string email, Role role);
    }
}
