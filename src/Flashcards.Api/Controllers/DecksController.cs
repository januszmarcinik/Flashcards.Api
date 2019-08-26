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
        public DecksController(IMediator mediator) 
            : base(mediator)
        {
        }

        [HttpGet]
        public IActionResult Get()
            => Dispatch(new GetAllDecksQuery());

        [HttpGet("{deck}")]
        public IActionResult Get(string deck)
            => Dispatch(new GetDeckByNameQuery(deck));

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
