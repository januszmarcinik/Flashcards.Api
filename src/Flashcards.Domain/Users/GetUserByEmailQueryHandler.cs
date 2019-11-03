using Flashcards.Core;

namespace Flashcards.Domain.Users
{
    internal class GetUserByEmailQueryHandler : QueryHandlerBase<GetUserByEmailQuery, UserDto>
    {
        private readonly IUsersRepository _usersRepository;

        public GetUserByEmailQueryHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public override Result<UserDto> Handle(GetUserByEmailQuery query)
        {
            var user = _usersRepository.GetByEmail(query.Email);
            if (user == null)
            {
                return Fail("User with given email does not exist.");
            }

            return Ok(user.ToDto());
        }
    }
}
