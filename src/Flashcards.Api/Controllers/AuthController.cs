using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Users;
using Flashcards.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Flashcards.Api.Controllers
{
    [Route("api/auth")]
    public class AuthController : ApiController
    {
        private readonly IMemoryCache _cache;

        public AuthController(ICommandDispatcher commandDispatcher, IMemoryCache cache) 
            : base(commandDispatcher)
        {
            _cache = cache;
        }

        [HttpPost]
        public IActionResult Post([FromBody] LoginUserCommandModel command)
        {
            Dispatch(command);
            return Ok(_cache.GetJwt(command.TokenId));
        }
    }
}
