using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Sessions;
using Flashcards.Infrastructure.Managers.Abstract;

namespace Flashcards.Infrastructure.Commands.Handlers.Sessions
{
    internal class ApplySessionCardCommandHandler : ICommandHandler<ApplySessionCardCommandModel>
    {
        private readonly ISessionsManager _sessionsManager;

        public ApplySessionCardCommandHandler(ISessionsManager sessionsManager)
        {
            _sessionsManager = sessionsManager;
        }

        public void Handle(ApplySessionCardCommandModel command) 
            => _sessionsManager.ApplySessionCard(command.UserId, command.Deck, command.CardId, command.Status);
    }
}
