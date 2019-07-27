using Flashcards.Domain.Services;
using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Sessions;

namespace Flashcards.Infrastructure.Commands.Handlers.Sessions
{
    internal class ApplySessionCardCommandHandler : ICommandHandler<ApplySessionCardCommandModel>
    {
        private readonly ISessionsService _sessionsService;

        public ApplySessionCardCommandHandler(ISessionsService sessionsService)
        {
            _sessionsService = sessionsService;
        }

        public void Handle(ApplySessionCardCommandModel command) 
            => _sessionsService.ApplySessionCard(command.UserId, command.Deck, command.CardId, command.Status);
    }
}
