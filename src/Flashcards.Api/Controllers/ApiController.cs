using System;
using System.Linq;
using Flashcards.Core;
using Microsoft.AspNetCore.Mvc;
using Flashcards.Core.Exceptions;

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
                var errors = string.Join(", ", ModelState.SelectMany(x => x.Value.Errors).Select(x => x.ErrorMessage));
                throw new FlashcardsException(ErrorCode.InvalidCommand, errors);
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

        protected IActionResult Dispatch<T>(IQuery<T> query)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join(", ", ModelState.SelectMany(x => x.Value.Errors).Select(x => x.ErrorMessage));
                throw new FlashcardsException(ErrorCode.InvalidCommand, errors);
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
