using Flashcards.WindowsUI.Controls;
using Flashcards.WindowsUI.Extensions;
using Flashcards.WindowsUI.Infrastructure;
using Flashcards.WindowsUI.Models;

namespace Flashcards.WindowsUI.Services
{
    class UsersService
    {
        public bool Auth(string email, string password)
        {
            if (email.IsEmpty())
            {
                FlashcardsMessageBox.Error("Email can't be empty.");
                return false;
            }
            else if (password.IsEmpty())
            {
                FlashcardsMessageBox.Error("Password can't be empty.");
                return false;
            }

            using (var client = new FlashcardsHttpClient())
            {
                var body = new {Email = email, Password = password};
                var authResponse = client.Post<JwtToken>(@"/auth", body);
                if (authResponse.IsSuccess)
                {
                    Session.Jwt = authResponse.Result;

                    client.LoadToken();
                    var userResponse = client.Get<User>($@"/users/{email}");
                    if (userResponse.IsSuccess)
                    {
                        Session.User = userResponse.Result;
                        Session.User.Password = password;
                    }

                    return true;
                }
                else
                {
                    FlashcardsMessageBox.Error(authResponse.ErrorMessage);
                    return false;
                }
            }
        }
    }
}
