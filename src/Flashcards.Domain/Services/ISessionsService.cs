using System;
using Flashcards.Domain.Dto;

namespace Flashcards.Domain.Services
{
    public interface ISessionsService
    {
        SessionStateDto GetSession(Guid userId, string deck);
        void ApplySessionCard(Guid userId, string deck, Guid cardId, SessionCardStatus status);
    }
}
