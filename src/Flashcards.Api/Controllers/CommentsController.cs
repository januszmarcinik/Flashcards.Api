using System;
using Flashcards.Application.Comments;
using Flashcards.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    [Authorize]
    [Route("api/decks/{deck}/cards/{card}/comments")]
    public class CommentsController : ApiController
    {
        public CommentsController(IMediator mediator, IEventBus eventBus)
            : base(mediator, eventBus)
        {
        }

        [HttpGet]
        public IActionResult Get(Guid card)
            => Dispatch(new GetCommentsByCardQuery(card));

        [HttpPost]
        public IActionResult Post(Guid card, [FromBody] AddCommentCommand command)
            => Dispatch(command.SetCard(card).SetUser(Guid.Parse(User.Identity.Name)));
    }
}
