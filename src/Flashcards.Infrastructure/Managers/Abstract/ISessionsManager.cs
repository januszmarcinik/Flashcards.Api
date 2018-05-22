using System;
using System.Threading.Tasks;
using Flashcards.Domain.Enums;
using Flashcards.Infrastructure.Dto.Sessions;

namespace Flashcards.Infrastructure.Managers.Abstract
{
    public interface ISessionsManager
    {
        Task<SessionStateDto> GetSessionAsync(Guid userId, string deck);
        Task ApplySessionCardAsync(Guid userId, string deck, Guid cardId, SessionCardStatus status);
    }
}
