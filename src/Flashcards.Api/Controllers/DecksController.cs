using Flashcards.Core;
using Flashcards.Domain.Decks;
using Flashcards.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    [Authorize]
    [Route("api/topics/{topic}/categories/{category}/decks")]
    public class DecksController : ApiController
    {
        private readonly IDecksRepository _decksRepository;

        public DecksController(IMediator mediator, IDecksRepository decksRepository) 
            : base(mediator)
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
        public IActionResult Post(string category, [FromBody] AddDeckCommand command)
            => Dispatch(command.SetCategory(category));

        [HttpPut]
        public IActionResult Put([FromBody] EditDeckCommand command)
            => Dispatch(command);

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] RemoveDeckCommand command)
            => Dispatch(command);  
    }
}
