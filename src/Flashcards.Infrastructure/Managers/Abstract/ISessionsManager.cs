using System;
using System.Threading.Tasks;
using Flashcards.Domain.Dto;
using Flashcards.Domain.Enums;

namespace Flashcards.Infrastructure.Managers.Abstract
{
    public interface ISessionsManager
    {
        Task<SessionStateDto> GetSessionAsync(Guid userId, string deck);
        Task ApplySessionCardAsync(Guid userId, string deck, Guid cardId, SessionCardStatus status);
    }
}
