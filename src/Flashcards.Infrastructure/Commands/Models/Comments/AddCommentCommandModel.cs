using Flashcards.Infrastructure.Commands.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace Flashcards.Infrastructure.Commands.Models.Comments
{
    public class AddCommentCommandModel : ICommandModel
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(512)]
        public string Text { get; set; }

        public Guid CardId { get; set; }
        public Guid UserId { get; set; }

        public AddCommentCommandModel SetCard(Guid cardId)
        {
            CardId = cardId;
            return this;
        }

        public AddCommentCommandModel SetUser(Guid userId)
        {
            UserId = userId;
            return this;
        }
    }
}
