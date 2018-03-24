using System;

namespace Flashcards.Domain.Exceptions
{
    public class FlashcardsException : Exception
    {
        public ErrorCode ErrorCode { get; }

        public FlashcardsException(ErrorCode errorCode)
            : this(errorCode, string.Empty)
        {
        }

        public FlashcardsException(ErrorCode errorCode, string message)
            : this(errorCode, message, null)
        {
        }

        public FlashcardsException(ErrorCode errorCode, string message, Exception innerException)
            : base(message, innerException)
        {
            ErrorCode = errorCode;
        }
    }
}
