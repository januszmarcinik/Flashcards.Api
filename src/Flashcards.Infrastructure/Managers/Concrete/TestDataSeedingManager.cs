using Flashcards.Domain.Entities;
using Flashcards.Domain.Enums;
using Flashcards.Infrastructure.Managers.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flashcards.Domain.Data.Abstract;

namespace Flashcards.Infrastructure.Managers.Concrete
{
    internal class TestDataSeedingManager : ITestDataSeedingManager
    {
        private readonly IEncryptionManager _encryptionManager;
        private readonly IDbContext _dbContext;

        public TestDataSeedingManager(IEncryptionManager encryptionManager, IDbContext dbContext)
        {
            _encryptionManager = encryptionManager;
            _dbContext = dbContext;
        }

        public void Seed()
        {
            var categories = new List<Category>();
            var users = new List<User>();

            var azure = new Category(Topic.It, "Azure");
            azure.AddDeck(new Deck("70-532"));
            azure.AddDeck(new Deck("70-533"));
            azure.AddDeck(new Deck("70-535"));
            categories.Add(azure);

            var dotnet = new Category(Topic.It, ".NET");
            dotnet.AddDeck(new Deck("Console Applications"));
            dotnet.AddDeck(new Deck("Web API Applications"));
            dotnet.AddDeck(new Deck("MVC 5 Applications"));
            categories.Add(dotnet);

            var b1 = new Category(Topic.EnPl, "B1");
            b1.AddDeck(new Deck("Vocabulary"));
            b1.AddDeck(new Deck("Test exam"));
            categories.Add(b1);

            var b2 = new Category(Topic.EnPl, "B2");
            b2.AddDeck(new Deck("Vocabulary"));
            b2.AddDeck(new Deck("Test exam"));
            categories.Add(b2);

            foreach (var category in categories)
            {
                var index = 1;
                foreach (var deck in category.Decks)
                {
                    index++;
                    deck.AddCard(new Card($"Title {index}", $"Question {index}", $"Answer {index}"));
                }
                index = 1;
            }


            for (int i = 1; i <= 10; i++)
            {
                var password = $"password{i}";
                var salt = _encryptionManager.GetSalt(password);
                var hash = _encryptionManager.GetHash(password, salt);
                users.Add(new User($"user{i}@januszmarcinik.pl", Role.Admin, hash, salt));
            }

            Task.WaitAll(
                Task.WhenAll(
                    _dbContext.Categories.AddRangeAsync(categories),
                    _dbContext.Users.AddRangeAsync(users)),
                _dbContext.SaveChangesAsync());
        }
    }
}
