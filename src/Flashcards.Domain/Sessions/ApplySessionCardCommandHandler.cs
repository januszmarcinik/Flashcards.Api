using Flashcards.Core;

namespace Flashcards.Domain.Sessions
{
    internal class ApplySessionCardCommandHandler : ICommandHandler<ApplySessionCardCommand>
    {
        private readonly ISessionsService _sessionsService;

        public ApplySessionCardCommandHandler(ISessionsService sessionsService)
        {
            _sessionsService = sessionsService;
        }

        public Result Handle(ApplySessionCardCommand command)
        {
            _sessionsService.ApplySessionCard(command.UserId, command.Deck, command.CardId, command.Status);
            return Result.Ok();
        }
    }
}
