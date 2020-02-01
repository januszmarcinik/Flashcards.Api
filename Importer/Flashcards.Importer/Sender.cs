using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Flashcards.Domain.Cards;
using Flashcards.Domain.Decks;
using Flashcards.Domain.Users;
using Newtonsoft.Json;

namespace Flashcards.Importer
{
    public class Sender
    {
        private readonly string _apiUrl;
        private readonly string _email;
        private readonly string _password;
        private readonly HttpClient _httpClient;

        public Sender(string apiUrl, string email, string password)
        {
            _apiUrl = apiUrl;
            _email = email;
            _password = password;
            _httpClient = new HttpClient();
        }

        public void Send(IEnumerable<Deck> decks)
        {
            Auth();

            foreach (var deck in decks)
            {
                SendDeck(deck);

                foreach (var card in deck.Cards)
                {
                    SendCard(deck.Name, card);
                }
            }
        }

        private void SendDeck(Deck deck)
        {
            var command = new AddDeckCommand
            {
                Id = deck.Id,
                Name = deck.Name,
                Description = deck.Description
            };

            var body = JsonConvert.SerializeObject(command);
            var content = new StringContent(body, Encoding.UTF8, "application/json");
                
            var result = _httpClient.PostAsync($"{_apiUrl}/decks", content)
                .GetAwaiter()
                .GetResult();

            result.EnsureSuccessStatusCode();
        }
        
        private void SendCard(string deckName, Card card)
        {
            var command = new AddCardCommand
            {
                Deck = deckName,
                Question = card.Question,
                Answer = card.Answer
            };

            var body = JsonConvert.SerializeObject(command);
            var content = new StringContent(body, Encoding.UTF8, "application/json");
                
            var result = _httpClient.PostAsync($"{_apiUrl}/decks/{deckName}/cards", content)
                .GetAwaiter()
                .GetResult();

            result.EnsureSuccessStatusCode();
        }

        private void Auth()
        {
            var authCommand = new
            {
                Email = _email,
                Password = _password
            };

            var body = JsonConvert.SerializeObject(authCommand);
            var content = new StringContent(body, Encoding.UTF8, "application/json");

            var result = _httpClient.PostAsync($"{_apiUrl}/auth", content)
                .GetAwaiter()
                .GetResult();

            result.EnsureSuccessStatusCode();

            var stringContent = result.Content.ReadAsStringAsync()
                .GetAwaiter()
                .GetResult();

            var token = JsonConvert.DeserializeObject<JwtDto>(stringContent);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);
        }
    }
}