using System;
using System.Threading.Tasks;
using Flashcards.Domain.Repositories;
using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Comments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    [Authorize]
    [Route("api/topics/{topic}/categories/{category}/decks/{deck}/cards/{card}/comments")]
    public class CommentsController : ApiController
    {
        private readonly ICommentsRepository _commentsRepository;

        public CommentsController(ICommandDispatcher commandDispatcher, ICommentsRepository commentsRepository)
            : base(commandDispatcher)
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
        public IActionResult Post(Guid card, [FromBody] AddCommentCommandModel command)
            => Dispatch(command.SetCard(card).SetUser(Guid.Parse(User.Identity.Name)));
    }
}
