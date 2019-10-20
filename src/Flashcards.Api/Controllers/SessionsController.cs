using System;
using Flashcards.Core;
using Flashcards.Domain.Sessions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    [Authorize]
    [Route("api/decks/{deck}/sessions")]
    public class SessionsController : ApiController
    {
        public SessionsController(IMediator mediator)
            : base(mediator)
        {
        }

        [HttpGet]
        public IActionResult GetActive(string deck)
            => Dispatch(new GetSessionQuery(Guid.Parse(User.Identity.Name), deck));

        [HttpGet("history")]
        public IActionResult GetHistory(string deck)
            => Dispatch(new GetSessionsQuery(Guid.Parse(User.Identity.Name), deck));

        [HttpPost]
        public IActionResult Post([FromBody] ApplySessionCardCommand command, string deck)
        {
            var userId = Guid.Parse(User.Identity.Name);
            Dispatch(command.SetFromRoute(userId, deck));
            return Dispatch(new GetSessionQuery(userId, deck));
        }
    }
}
