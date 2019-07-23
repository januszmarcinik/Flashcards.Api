using System.Threading.Tasks;
using Flashcards.Domain.Repositories;
using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Decks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    [Authorize]
    [Route("api/topics/{topic}/categories/{category}/decks")]
    public class DecksController : ApiController
    {
        private readonly IDecksRepository _decksRepository;

        public DecksController(ICommandDispatcher commandDispatcher, IDecksRepository decksRepository) 
            : base(commandDispatcher)
        {
            _decksRepository = decksRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string category)
            => Ok(await _decksRepository.GetListAsync(category));

        [HttpGet("{deck}")]
        public async Task<IActionResult> Get(string topic, string category, string deck)
            => Ok(await _decksRepository.GetAsync(deck));

        [HttpPost]
        public async Task<IActionResult> Post(string category, [FromBody] AddDeckCommandModel command)
            => await DispatchAsync(command.SetCategory(category));

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] EditDeckCommandModel command)
            => await DispatchAsync(command);

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] RemoveDeckCommandModel command)
            => await DispatchAsync(command);  
    }
}
