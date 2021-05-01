using System.Collections.Generic;
using System.Linq;
using Flashcards.Application.Cards;
using Flashcards.Application.Users;
using Flashcards.Core;

namespace Flashcards.Application.Comments
{
    internal class GetCommentsByCardQueryHandler : QueryHandlerBase<GetCommentsByCardQuery, IEnumerable<CommentDto>>
    {
        private readonly ISqlCommentsRepository _commentsRepository;
        private readonly ISqlCardsRepository _cardsRepository;
        private readonly IUsersRepository _usersRepository;

        public GetCommentsByCardQueryHandler(ISqlCommentsRepository commentsRepository, ISqlCardsRepository cardsRepository, IUsersRepository usersRepository)
        {
            _commentsRepository = commentsRepository;
            _cardsRepository = cardsRepository;
            _usersRepository = usersRepository;
        }

        public override Result<IEnumerable<CommentDto>> Handle(GetCommentsByCardQuery query)
        {
            var card = _cardsRepository.GetById(query.CardId);
            if (card == null)
            {
                return Fail("Card with given id does not exist.");
            }

            var comments = _commentsRepository
                .GetByCard(query.CardId)
                .ToList();

            var userIds = comments.Select(x => x.UserId).ToList();
            var users = _usersRepository.GetByIds(userIds).ToList();

            var result = comments
                .Select(comment =>
                {
                    var user = users.SingleOrDefault(x => x.Id == comment.UserId);
                    return comment.ToDto(user?.Email);
                });

            return Ok(result);
        }
    }
}
