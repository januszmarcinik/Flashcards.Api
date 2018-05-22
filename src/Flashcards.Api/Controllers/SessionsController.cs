using System;
using System.Threading.Tasks;
using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Sessions;
using Flashcards.Infrastructure.Managers.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    [Authorize]
    [Route("api/topics/{topic}/categories/{category}/decks/{deck}/sessions")]
    public class SessionsController : ApiController
    {
        private readonly ISessionsManager _sessionsManager;

        public SessionsController(ISessionsManager sessionsManager, ICommandDispatcher commandDispatcher)
            : base(commandDispatcher)
        {
            _sessionsManager = sessionsManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string deck)
            => Ok(await _sessionsManager.GetSessionAsync(Guid.Parse(User.Identity.Name), deck));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ApplySessionCardCommandModel command, string deck)
        {
            var userId = Guid.Parse(User.Identity.Name);
            await DispatchAsync(command.SetFromRoute(userId, deck));
            return Ok(await _sessionsManager.GetSessionAsync(userId, deck));
        }
    }
}
