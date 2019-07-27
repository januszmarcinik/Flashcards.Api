using System;
using Flashcards.Core;
using Flashcards.Core.Extensions;

namespace Flashcards.Domain.Comments
{
    internal class AddCommentCommandHandler : ICommandHandler<AddCommentCommand>
    {
        private readonly ICommentsRepository _commentsRepository;

        public AddCommentCommandHandler(ICommentsRepository commentsRepository)
        {
            _commentsRepository = commentsRepository;
        }

        public Result Handle(AddCommentCommand command)
        {
            if (command.Id.IsEmpty())
            {
                command.Id = Guid.NewGuid();
            }

            _commentsRepository.Add(command.CardId, command.UserId, command.Text);

            return Result.Ok();
        }
    }
}
