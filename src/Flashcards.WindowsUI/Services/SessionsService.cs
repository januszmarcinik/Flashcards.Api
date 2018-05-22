using Flashcards.WindowsUI.Infrastructure;
using Flashcards.WindowsUI.Models;
using Flashcards.WindowsUI.Models.Sessions;

namespace Flashcards.WindowsUI.Services
{
    class SessionsService : ServiceBase
    {
        public SessionState GetSessionState(Topic topic, string category, string deck)
            => Handle<SessionState>($"/topics/{topic}/categories/{category}/decks/{deck}/sessions");

        public ApiResponse<SessionState> ApplySessionCard(Topic topic, string category, string deck, ApplySessionCardCommand command)
        {
            using (var client = new FlashcardsHttpClient())
            {
                var url = $"/topics/{topic}/categories/{category}/decks/{deck}/sessions";
                return client.Post<SessionState>(url, command);
            }
        }
    }
}
