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
        public async Task<IActionResult> Get(Guid card)
            => Ok(await _commentsRepository.GetByCardAsync(card));

        [HttpGet("id")]
        public async Task<IActionResult> Get(Guid card, Guid id)
            => Ok(await _commentsRepository.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Post(Guid card, [FromBody] AddCommentCommandModel command)
            => await DispatchAsync(command.SetCard(card).SetUser(Guid.Parse(User.Identity.Name)));
    }
}
