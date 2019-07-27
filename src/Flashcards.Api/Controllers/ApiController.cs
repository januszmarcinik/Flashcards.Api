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

        protected IActionResult Dispatch<T>(T command) where T : ICommand
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join(", ", ModelState.SelectMany(x => x.Value.Errors).Select(x => x.ErrorMessage));
                throw new FlashcardsException(ErrorCode.InvalidCommand, errors);
            }

            _mediator.Command(command);
            return Accepted();
        }
    }
}
