using System.Net;

namespace Flashcards.Core.Exceptions
{
    public class ErrorCode
    {
        public string Code { get; protected set; }
        public string Message { get; }
        public HttpStatusCode HttpStatusCode { get; }

        public ErrorCode(string message, HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest)
        {
            Message = message;
            HttpStatusCode = httpStatusCode;
        }

        public static ErrorCode EmptyCommand => new ErrorCode(nameof(EmptyCommand));
        public static ErrorCode InvalidCommand => new ErrorCode(nameof(InvalidCommand));

        public static ErrorCode EmptyPasswordForGenerateSalt => new ErrorCode(nameof(EmptyPasswordForGenerateSalt));
        public static ErrorCode EmptyPasswordForGenerateHash => new ErrorCode(nameof(EmptyPasswordForGenerateHash));
        public static ErrorCode EmptySaltForGenerateHash => new ErrorCode(nameof(EmptySaltForGenerateHash));

        public static ErrorCode InvalidUserId => new ErrorCode(nameof(InvalidUserId));
        public static ErrorCode InvalidUserEmail => new ErrorCode(nameof(InvalidUserEmail));
        public static ErrorCode InvalidUserRole => new ErrorCode(nameof(InvalidUserRole));
        public static ErrorCode InvalidUserPassword => new ErrorCode(nameof(InvalidUserPassword));
        public static ErrorCode InvalidUserPasswordSalt => new ErrorCode(nameof(InvalidUserPasswordSalt));

        public static ErrorCode InvalidCategoryId => new ErrorCode(nameof(InvalidCategoryId));
        public static ErrorCode InvalidCategoryTopic => new ErrorCode(nameof(InvalidCategoryTopic));
        public static ErrorCode InvalidCategoryName => new ErrorCode(nameof(InvalidCategoryName));
        public static ErrorCode CategoryWithGivenNameDoesNotExist => new ErrorCode(nameof(CategoryWithGivenNameDoesNotExist), HttpStatusCode.NotFound);
        public static ErrorCode CategoryDoesNotExist => new ErrorCode(nameof(CategoryDoesNotExist), HttpStatusCode.NotFound);
        public static ErrorCode CategoryWithGivenNameAlreadyExist => new ErrorCode(nameof(CategoryWithGivenNameAlreadyExist));
        public static ErrorCode CategoryCannotBeDeletedBecouseHasRelatedDecks => new ErrorCode(nameof(CategoryCannotBeDeletedBecouseHasRelatedDecks));

        public static ErrorCode InvalidCredentials => new ErrorCode(nameof(InvalidCredentials), HttpStatusCode.Unauthorized);
                      
        public static ErrorCode UserDoesNotExist => new ErrorCode(nameof(UserDoesNotExist), HttpStatusCode.NotFound);
        public static ErrorCode UserWithGivenEmailDoesNotExist => new ErrorCode(nameof(UserWithGivenEmailDoesNotExist), HttpStatusCode.NotFound);
        public static ErrorCode UserWithGivenEmailAlreadyExist => new ErrorCode(nameof(UserWithGivenEmailAlreadyExist));

        public static ErrorCode InvalidDeckId => new ErrorCode(nameof(InvalidDeckId));
        public static ErrorCode InvalidDeckName => new ErrorCode(nameof(InvalidDeckName));
        public static ErrorCode DeckWithGivenNameDoesNotExist => new ErrorCode(nameof(DeckWithGivenNameDoesNotExist), HttpStatusCode.NotFound);
        public static ErrorCode DeckDoesNotExist => new ErrorCode(nameof(DeckDoesNotExist), HttpStatusCode.NotFound);
        public static ErrorCode DeckWithGivenNameAlreadyExist => new ErrorCode(nameof(DeckWithGivenNameAlreadyExist));
        public static ErrorCode DeckAlreadyExist => new ErrorCode(nameof(DeckAlreadyExist));

        public static ErrorCode InvalidCardId => new ErrorCode(nameof(InvalidCardId));
        public static ErrorCode InvalidCardTitle => new ErrorCode(nameof(InvalidCardTitle));
        public static ErrorCode InvalidCardQuestion => new ErrorCode(nameof(InvalidCardQuestion));
        public static ErrorCode InvalidCardAnswer => new ErrorCode(nameof(InvalidCardAnswer));
        public static ErrorCode CardDoesNotExist => new ErrorCode(nameof(CardDoesNotExist), HttpStatusCode.NotFound);

        public static ErrorCode InvalidCommentText => new ErrorCode(nameof(InvalidCommentText));
        public static ErrorCode CommentDoesNotExist => new ErrorCode(nameof(CommentDoesNotExist), HttpStatusCode.NotFound);
    }
}
