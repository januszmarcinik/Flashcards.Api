using System;
using Flashcards.Domain.Services;
using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Sessions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    [Authorize]
    [Route("api/topics/{topic}/categories/{category}/decks/{deck}/sessions")]
    public class SessionsController : ApiController
    {
        private readonly ISessionsService _sessionsService;

        public SessionsController(ISessionsService sessionsService, ICommandDispatcher commandDispatcher)
            : base(commandDispatcher)
        {
            _sessionsService = sessionsService;
        }

        [HttpGet]
        public IActionResult Get(string deck)
            => Ok(_sessionsService.GetSession(Guid.Parse(User.Identity.Name), deck));

        [HttpPost]
        public IActionResult Post([FromBody] ApplySessionCardCommandModel command, string deck)
        {
            var userId = Guid.Parse(User.Identity.Name);
            Dispatch(command.SetFromRoute(userId, deck));
            return Ok(_sessionsService.GetSession(userId, deck));
        }
    }
}
