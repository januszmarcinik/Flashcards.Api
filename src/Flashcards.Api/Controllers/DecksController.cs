using System.Threading.Tasks;
using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Decks;
using Flashcards.Infrastructure.Services.Abstract.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    [Authorize]
    [Route("api/topics/{topic}/categories/{category}/decks")]
    public class DecksController : ApiController
    {
        private readonly IDeckQueryService _deckQueryService;

        public DecksController(ICommandDispatcher commandDispatcher, IDeckQueryService deckQueryService) 
            : base(commandDispatcher)
        {
            _deckQueryService = deckQueryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string category)
            => Ok(await _deckQueryService.GetListAsync(category));

        [HttpGet("{deck}")]
        public async Task<IActionResult> Get(string topic, string category, string deck)
            => Ok(await _deckQueryService.GetAsync(deck));

        [HttpPost]
        public async Task<IActionResult> Post(string category, [FromBody] AddDeckCommandModel command)
            => await DispatchAsync(command.SetCategory(category));
    }
}
