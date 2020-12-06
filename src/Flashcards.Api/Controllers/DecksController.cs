using System;
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
        private readonly INoSqlDecksRepository _decksRepository;

        public DecksController(IMediator mediator, INoSqlDecksRepository decksRepository) 
            : base(mediator)
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
        public IActionResult Post([FromBody] AddDeckCommand command)
            => Dispatch(command,result => new DeckAddedEvent(Guid.Parse(result.Message)));

        [HttpPut]
        public IActionResult Put([FromBody] EditDeckCommand command)
            => Dispatch(command, _ => new DeckEditedEvent(command.Id));

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] RemoveDeckCommand command)
            => Dispatch(command,_ => new DeckRemovedEvent(command.Id));  
    }
}
