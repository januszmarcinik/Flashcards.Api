using System.Threading.Tasks;
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

        public async Task HandleAsync(ApplySessionCardCommandModel command) 
            => await _sessionsManager.ApplySessionCardAsync(command.UserId, command.Deck, command.CardId, command.Status);
    }
}
