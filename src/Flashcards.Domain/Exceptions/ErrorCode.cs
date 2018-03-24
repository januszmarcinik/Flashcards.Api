using System.Net;

namespace Flashcards.Domain.Exceptions
{
    public class ErrorCode
    {
        public string Message { get; }
        public HttpStatusCode HttpStatusCode { get; }

        public ErrorCode(string message, HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest)
        {
            Message = message;
            HttpStatusCode = httpStatusCode;
        }

        public static ErrorCode EmptyCommand 
            => new ErrorCode("Command can not be null.", HttpStatusCode.BadRequest);

        public static ErrorCode EmptyPasswordForGenerateSalt 
            => new ErrorCode("Can not generate salt from an empty password.", HttpStatusCode.BadRequest);
        public static ErrorCode EmptyPasswordForGenerateHash 
            => new ErrorCode("Can not generate hash from an empty password.", HttpStatusCode.BadRequest);
        public static ErrorCode EmptySaltForGenerateHash 
            => new ErrorCode("Can not generate hash from an empty salt.", HttpStatusCode.BadRequest);

        public static ErrorCode InvalidUserId 
            => new ErrorCode("Invalid user ID.", HttpStatusCode.BadRequest);
        public static ErrorCode InvalidUserEmail 
            => new ErrorCode("Invalid user email.", HttpStatusCode.BadRequest);
        public static ErrorCode InvalidUserRole 
            => new ErrorCode("Invalid user role.", HttpStatusCode.BadRequest);
        public static ErrorCode InvalidUserPassword 
            => new ErrorCode("Invalid user password.", HttpStatusCode.BadRequest);
        public static ErrorCode InvalidUserPasswordSalt 
            => new ErrorCode("Invalid user password-salt.", HttpStatusCode.BadRequest);
                      
        public static ErrorCode InvalidCredentials 
            => new ErrorCode("Invalid credentials.", HttpStatusCode.Unauthorized);
                      
        public static ErrorCode UserDoesNotExist 
            => new ErrorCode("User does not exist.", HttpStatusCode.NotFound);
        public static ErrorCode UserWithGivenEmailDoesNotExist 
            => new ErrorCode("User with given email does not exist.", HttpStatusCode.NotFound);
        public static ErrorCode UserWithGivenEmailAlreadyExist 
            => new ErrorCode("User with given email already exist.", HttpStatusCode.BadRequest);
    }
}
