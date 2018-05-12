using System;
using Flashcards.WindowsUI.Extensions;
using Flashcards.WindowsUI.Infrastructure;
using Flashcards.WindowsUI.Models;

namespace Flashcards.WindowsUI.Services
{
    class UsersService
    {
        public void Auth(string email, string password)
        {
            if (email.IsEmpty())
            {
                throw new Exception("Email can't be empty.");
            }
            else if (password.IsEmpty())
            {
                 throw new Exception("Password can't be empty.");
            }

            using (var client = new FlashcardsHttpClient())
            {
                var body = new {Email = email, Password = password};
                var authResponse = client.Post<JwtToken>(@"/auth", body);
                if (authResponse.IsSuccess)
                {
                    Session.Jwt = authResponse.Result;

                    var userResponse = client.Get<User>($@"/users/{email}");
                    if (userResponse.IsSuccess)
                    {
                        Session.User = userResponse.Result;
                        Session.User.Password = password;
                    }
                }
                else
                {
                    throw new Exception(authResponse.Message);
                }
            }
        }
    }
}
