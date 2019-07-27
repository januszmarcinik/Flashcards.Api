using System;
using Flashcards.Core;
using Flashcards.Domain.Comments;
using Flashcards.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    [Authorize]
    [Route("api/topics/{topic}/categories/{category}/decks/{deck}/cards/{card}/comments")]
    public class CommentsController : ApiController
    {
        private readonly ICommentsRepository _commentsRepository;

        public CommentsController(IMediator mediator, ICommentsRepository commentsRepository)
            : base(mediator)
        {
            _commentsRepository = commentsRepository;
        }

        [HttpGet]
        public IActionResult Get(Guid card)
            => Ok(_commentsRepository.GetByCard(card));

        [HttpGet("id")]
        public IActionResult Get(Guid card, Guid id)
            => Ok(_commentsRepository.GetById(id));

        [HttpPost]
        public IActionResult Post(Guid card, [FromBody] AddCommentCommand command)
            => Dispatch(command.SetCard(card).SetUser(Guid.Parse(User.Identity.Name)));
    }
}
