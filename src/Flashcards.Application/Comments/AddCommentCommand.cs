using System;
using System.ComponentModel.DataAnnotations;
using Flashcards.Core;

namespace Flashcards.Application.Comments
{
    public class AddCommentCommand : ICommand
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(512)]
        public string Text { get; set; }

        public Guid CardId { get; set; }
        public Guid UserId { get; set; }

        public AddCommentCommand SetCard(Guid cardId)
        {
            CardId = cardId;
            return this;
        }

        public AddCommentCommand SetUser(Guid userId)
        {
            UserId = userId;
            return this;
        }
    }
}
