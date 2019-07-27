using System;
using Flashcards.Core;
using Flashcards.Domain.Sessions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    [Authorize]
    [Route("api/topics/{topic}/categories/{category}/decks/{deck}/sessions")]
    public class SessionsController : ApiController
    {
        private readonly ISessionsService _sessionsService;

        public SessionsController(ISessionsService sessionsService, IMediator mediator)
            : base(mediator)
        {
            _sessionsService = sessionsService;
        }

        [HttpGet]
        public IActionResult Get(string deck)
            => Ok(_sessionsService.GetSession(Guid.Parse(User.Identity.Name), deck));

        [HttpPost]
        public IActionResult Post([FromBody] ApplySessionCardCommand command, string deck)
        {
            var userId = Guid.Parse(User.Identity.Name);
            Dispatch(command.SetFromRoute(userId, deck));
            return Ok(_sessionsService.GetSession(userId, deck));
        }
    }
}
