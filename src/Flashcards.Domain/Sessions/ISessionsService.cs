using System;

namespace Flashcards.Domain.Sessions
{
    public interface ISessionsService
    {
        SessionStateDto GetSession(Guid userId, string deck);
        void ApplySessionCard(Guid userId, string deck, Guid cardId, SessionCardStatus status);
    }
}
