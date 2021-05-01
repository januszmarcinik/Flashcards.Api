using System.Collections.Generic;
using System.Linq;
using Flashcards.Core;

namespace Flashcards.Application.Users
{
    internal class GetAllUsersQueryHandler : QueryHandlerBase<GetAllUsersQuery, IEnumerable<UserDto>>
    {
        private readonly IUsersRepository _usersRepository;

        public GetAllUsersQueryHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public override Result<IEnumerable<UserDto>> Handle(GetAllUsersQuery query)
        {
            var result = _usersRepository
                .GetAll()
                .Select(x => x.ToDto())
                .ToList();

            return Ok(result);
        }
    }
}
