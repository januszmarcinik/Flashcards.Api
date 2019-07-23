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
        public IActionResult Get(string category)
            => Ok(_decksRepository.GetByCategoryName(category));

        [HttpGet("{deck}")]
        public IActionResult Get(string topic, string category, string deck)
            => Ok(_decksRepository.GetByName(deck));

        [HttpPost]
        public IActionResult Post(string category, [FromBody] AddDeckCommandModel command)
            => Dispatch(command.SetCategory(category));

        [HttpPut]
        public IActionResult Put([FromBody] EditDeckCommandModel command)
            => Dispatch(command);

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] RemoveDeckCommandModel command)
            => Dispatch(command);  
    }
}
