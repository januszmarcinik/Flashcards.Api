using System;
using System.Threading.Tasks;
using Flashcards.Core;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    public class ApiController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IEventBus _eventBus;

        public ApiController(IMediator mediator, IEventBus eventBus)
        {
            _mediator = mediator;
            _eventBus = eventBus;
        }
        
        protected IActionResult Dispatch<TCommand>(TCommand command, Func<object> getValueOnSuccess = null) where TCommand : ICommand
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _mediator.Command(command);
            if (result.IsSuccess == false)
            {
                return BadRequest(result.Message);
            }

            return getValueOnSuccess != null 
                ? Accepted(getValueOnSuccess()) 
                : Accepted();
        }
        
        protected async Task<IActionResult> Dispatch<TCommand, TEvent>(TCommand command, Func<Result, TEvent> publishEventOnSuccess) 
            where TCommand : ICommand
            where TEvent : IEvent
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _mediator.Command(command);
            if (result.IsSuccess == false)
            {
                return BadRequest(result.Message);
            }

            var @event = publishEventOnSuccess(result);
            await _eventBus.PublishAsync(@event);

            return Accepted(result.Message);
        }
        
        protected IActionResult Dispatch<T>(IQuery<T> query)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _mediator.Query(query);
            if (result.IsSuccess == false)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Value);
        }
    }
}
