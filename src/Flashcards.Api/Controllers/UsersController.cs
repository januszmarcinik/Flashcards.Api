using Flashcards.Application.Users;
using Flashcards.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    [Authorize]
    [Route("api/users")]
    public class UsersController : ApiController
    {
        public UsersController(IMediator mediator, IEventBus eventBus)
            : base(mediator, eventBus)
        {
        }

        [HttpGet]
        public IActionResult Get()
            => Dispatch(new GetAllUsersQuery());

        [HttpGet("{email}")]
        public IActionResult Get(string email)
            => Dispatch(new GetUserByEmailQuery(email));

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] RegisterUserCommand command)
            => Dispatch(command);

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] RemoveUserCommand command)
            => Dispatch(command);
    }
}
