using Flashcards.Infrastructure.Commands.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Flashcards.Api.Controllers
{
    [Route("api/[controller]")]
    public class ApiController : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public ApiController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        protected async Task<IActionResult> DispatchAsync<T>(T command) where T : ICommandModel
        {
            await _commandDispatcher.DispatchAsync(command);
            return Accepted();
        }
    }
}
