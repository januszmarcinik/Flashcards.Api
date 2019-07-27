using Flashcards.Core;
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

        public AuthController(IMediator mediator, IMemoryCache cache) 
            : base(mediator)
        {
            _cache = cache;
        }

        [HttpPost]
        public IActionResult Post([FromBody] LoginUserCommand command)
        {
            Dispatch(command);
            return Ok(_cache.GetJwt(command.TokenId));
        }
    }
}
