using System.Linq;
using Flashcards.Infrastructure.Commands.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Flashcards.Core.Exceptions;

namespace Flashcards.Api.Controllers
{
    public class ApiController : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public ApiController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        protected async Task<IActionResult> DispatchAsync<T>(T command) where T : ICommandModel
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join(", ", ModelState.SelectMany(x => x.Value.Errors).Select(x => x.ErrorMessage));
                throw new FlashcardsException(ErrorCode.InvalidCommand, errors);
            }

            await _commandDispatcher.DispatchAsync(command);
            return Accepted();
        }
    }
}
