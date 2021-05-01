using System;
using Flashcards.Application.Cards;
using Flashcards.Application.Users;
using Flashcards.Core;
using Flashcards.Core.Extensions;

namespace Flashcards.Application.Comments
{
    internal class AddCommentCommandHandler : CommandHandlerBase<AddCommentCommand>
    {
        private readonly ISqlCommentsRepository _commentsRepository;
        private readonly ISqlCardsRepository _cardsRepository;
        private readonly IUsersRepository _usersRepository;

        public AddCommentCommandHandler(ISqlCommentsRepository commentsRepository, ISqlCardsRepository cardsRepository, IUsersRepository usersRepository)
        {
            _commentsRepository = commentsRepository;
            _cardsRepository = cardsRepository;
            _usersRepository = usersRepository;
        }

        public override Result Handle(AddCommentCommand command)
        {
            if (command.Id.IsEmpty())
            {
                command.Id = Guid.NewGuid();
            }

            var user = _usersRepository.GetById(command.UserId);
            if (user == null)
            {
                return Fail("User with given id does not exist.");
            }

            var card = _cardsRepository.GetById(command.CardId);
            if (card == null)
            {
                return Fail("Card wih given id does not exist.");
            }

            var comment = new Comment(card.Id, user.Id, command.Text);
            _commentsRepository.Add(comment);

            return Result.Ok();
        }
    }
}
