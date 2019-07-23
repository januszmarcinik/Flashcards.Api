using System;
using Flashcards.Domain.Dto;

namespace Flashcards.Infrastructure.Managers.Abstract
{
    public interface ISessionsManager
    {
        SessionStateDto GetSession(Guid userId, string deck);
        void ApplySessionCard(Guid userId, string deck, Guid cardId, SessionCardStatus status);
    }
}
