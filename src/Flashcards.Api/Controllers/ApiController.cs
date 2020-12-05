using System;
using Flashcards.Core;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    public class ApiController : Controller
    {
        private readonly IMediator _mediator;

        public ApiController(IMediator mediator)
        {
            _mediator = mediator;
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
        
        protected IActionResult Dispatch<TCommand, TEvent>(TCommand command, Func<Result, TEvent> publishEventOnSuccess) 
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
            _mediator.Publish(@event);

            return Accepted();
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
