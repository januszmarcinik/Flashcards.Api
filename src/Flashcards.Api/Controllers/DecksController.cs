using System;
using System.Threading.Tasks;
using Flashcards.Application.Decks;
using Flashcards.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    [Authorize]
    [Route("api/decks")]
    public class DecksController : ApiController
    {
        private readonly INoSqlDecksRepository _decksRepository;

        public DecksController(IMediator mediator, IEventBus eventBus, INoSqlDecksRepository decksRepository) 
            : base(mediator, eventBus)
        {
            _decksRepository = decksRepository;
        }

        [HttpGet]
        public IActionResult Get()
            => Ok(_decksRepository.GetAll());

        [HttpGet("{deck}")]
        public IActionResult Get(string deck)
        {
            var result = _decksRepository.GetByName(deck);
            if (result == null)
            {
                return NotFound("Deck with given name does not exist.");
            }
            
            return Ok(result);
        }

        [HttpGet("{deck}/cards")]
        public IActionResult Cards(string deck) => 
            Ok(_decksRepository.GetByName(deck).Cards);

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddDeckCommand command)
            => await Dispatch(command,result => new DeckAddedEvent(Guid.Parse(result.Message)));

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] EditDeckCommand command)
            => await Dispatch(command, _ => new DeckEditedEvent(command.Id));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] RemoveDeckCommand command)
            => await Dispatch(command,_ => new DeckRemovedEvent(command.Id));  
    }
}
