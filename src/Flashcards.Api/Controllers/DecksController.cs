using Flashcards.Core;
using Flashcards.Domain.Decks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    [Authorize]
    [Route("api/decks")]
    public class DecksController : ApiController
    {
        private readonly IDecksRepository _decksRepository;

        public DecksController(IMediator mediator, IDecksRepository decksRepository) 
            : base(mediator)
        {
            _decksRepository = decksRepository;
        }

        [HttpGet]
        public IActionResult Get()
            => Ok(_decksRepository.GetAll());

        [HttpGet("{deck}")]
        public IActionResult Get(string deck)
            => Ok(_decksRepository.GetByName(deck));

        [HttpPost]
        public IActionResult Post([FromBody] AddDeckCommand command)
            => Dispatch(command);

        [HttpPut]
        public IActionResult Put([FromBody] EditDeckCommand command)
            => Dispatch(command);

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] RemoveDeckCommand command)
            => Dispatch(command);  
    }
}
