using System.Threading.Tasks;
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
        public async Task<IActionResult> Get()
            => Ok(await _usersRepository.GetListAsync());

        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
            => Ok(await _usersRepository.GetByEmailAsync(email));

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] RegisterUserCommandModel command)
            => await DispatchAsync(command);

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] EditUserCommandModel command)
            => await DispatchAsync(command);

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] RemoveUserCommandModel command)
            => await DispatchAsync(command);
    }
}
