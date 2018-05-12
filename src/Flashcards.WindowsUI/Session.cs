using Flashcards.WindowsUI.Extensions;
using Flashcards.WindowsUI.Models;

namespace Flashcards.WindowsUI
{
    class Session
    {
        public static bool UserIsLoggedIn 
            => User != null && Jwt != null && Jwt.Token.IsNotEmpty();

        public static User User { get; set; }
        public static JwtToken Jwt { get; set; }
    }
}
