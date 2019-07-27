using Flashcards.Core;
using Flashcards.Domain.Extensions;
using Flashcards.Domain.Services;
using Flashcards.Domain.Users;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    [Route("api/auth")]
    public class AuthController : ApiController
    {
        private readonly ICacheService _cache;

        public AuthController(IMediator mediator, ICacheService cache) 
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
