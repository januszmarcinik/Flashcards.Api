using System;
using System.Threading.Tasks;
using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Comments;
using Flashcards.Infrastructure.Services.Abstract.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    [Authorize]
    [Route("api/topics/{topic}/categories/{category}/decks/{deck}/cards/{card}/comments")]
    public class CommentsController : ApiController
    {
        private readonly ICommentsQueryService _commentsQueryService;

        public CommentsController(ICommandDispatcher commandDispatcher, ICommentsQueryService commentsQueryService)
            : base(commandDispatcher)
        {
            _commentsQueryService = commentsQueryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid card)
            => Ok(await _commentsQueryService.GetByCardAsync(card));

        [HttpGet("id")]
        public async Task<IActionResult> Get(Guid card, Guid id)
            => Ok(await _commentsQueryService.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Post(Guid card, [FromBody] AddCommentCommandModel command)
            => await DispatchAsync(command.SetCard(card).SetUser(Guid.Parse(User.Identity.Name)));
    }
}
