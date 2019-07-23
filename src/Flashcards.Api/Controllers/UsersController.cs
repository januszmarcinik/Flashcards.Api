using Flashcards.Domain.Repositories;
using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    [Authorize]
    [Route("api/users")]
    public class UsersController : ApiController
    {
        private readonly IUsersRepository _usersRepository;

        public UsersController(IUsersRepository usersRepository, ICommandDispatcher commandDispatcher)
            : base(commandDispatcher)
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
        public IActionResult Post([FromBody] RegisterUserCommandModel command)
            => Dispatch(command);

        [HttpPut]
        public IActionResult Put([FromBody] EditUserCommandModel command)
            => Dispatch(command);

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] RemoveUserCommandModel command)
            => Dispatch(command);
    }
}
