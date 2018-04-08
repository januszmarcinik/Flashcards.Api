using System;
using System.Threading.Tasks;
using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Users;
using Flashcards.Infrastructure.Services.Abstract.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    [Authorize]
    [Route("api/users")]
    public class UsersController : ApiController
    {
        private readonly IUsersQueryService _usersQueryService;

        public UsersController(IUsersQueryService usersQueryService, ICommandDispatcher commandDispatcher)
            : base(commandDispatcher)
        {
            _usersQueryService = usersQueryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await _usersQueryService.GetListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Ok(await _usersQueryService.GetByIdAsync(id));

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
