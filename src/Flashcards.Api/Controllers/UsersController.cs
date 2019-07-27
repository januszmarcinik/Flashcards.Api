using Flashcards.Core;
using Flashcards.Domain.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    [Authorize]
    [Route("api/users")]
    public class UsersController : ApiController
    {
        private readonly IUsersRepository _usersRepository;

        public UsersController(IUsersRepository usersRepository, IMediator mediator)
            : base(mediator)
        {
            _usersRepository = usersRepository;
        }

        [HttpGet]
        public IActionResult Get()
            => Ok(_usersRepository.GetAll());

        [HttpGet("{email}")]
        public IActionResult Get(string email)
            => Ok(_usersRepository.GetByEmail(email));

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] RegisterUserCommand command)
            => Dispatch(command);

        [HttpPut]
        public IActionResult Put([FromBody] EditUserCommand command)
            => Dispatch(command);

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] RemoveUserCommand command)
            => Dispatch(command);
    }
}
