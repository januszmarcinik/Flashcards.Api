using System;
using System.Threading.Tasks;
using Flashcards.Core.Extensions;
using Flashcards.Domain.Enums;
using Flashcards.Domain.Repositories;
using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Cards;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    [Authorize]
    [Route("api/topics/{topic}/categories/{category}/decks/{deck}/cards")]
    public class CardsController : ApiController
    {
        private readonly ICardsRepository _cardsRepository;

        public CardsController(ICommandDispatcher commandDispatcher, ICardsRepository cardsRepository) 
            : base(commandDispatcher)
        {
            _cardsRepository = cardsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string topic, string category, string deck)
            => Ok(await _cardsRepository.GetListAsync(deck));

        [HttpGet("{card}")]
        public async Task<IActionResult> Get(string topic, string category, string deck, Guid card)
            => Ok(await _cardsRepository.GetAsync(card));

        [HttpPost]
        public async Task<IActionResult> Post(string topic, string category, string deck, [FromBody] AddCardCommandModel command)
            => await DispatchAsync(command.SetFromRoute(topic.ToEnum<Topic>(), category, deck));

        [HttpPut]
        public async Task<IActionResult> Put(string topic, string category, string deck, [FromBody] EditCardCommandModel command)
            => await DispatchAsync(command.SetFromRoute(topic.ToEnum<Topic>(), category, deck, Guid.Parse(User.Identity.Name)));

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] ConfirmCardCommandModel command)
            => await DispatchAsync(command);

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] RemoveCardCommandModel command)
            => await DispatchAsync(command);
    }
}
