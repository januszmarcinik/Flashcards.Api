using Flashcards.Domain.Entities;
using Flashcards.Domain.Enums;
using Flashcards.Infrastructure.Managers.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flashcards.Domain.Data.Abstract;
using System;

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
            var a70_532 = new Deck("70-532");
            azure.AddDeck(a70_532);
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

            for (int i = 1; i <= 10; i++)
            {
                var password = $"password{i}";
                var salt = _encryptionManager.GetSalt(password);
                var hash = _encryptionManager.GetHash(password, salt);
                users.Add(new User($"user{i}@januszmarcinik.pl", Role.User, hash, salt));
            }

            var adminSalt = _encryptionManager.GetSalt("admin123");
            var adminHash = _encryptionManager.GetHash("admin123", adminSalt);
            var admin = new User(Guid.Parse("c5572a1b-5a5c-431c-a473-73f14b9797f0"), "admin@admin.pl", Role.Admin, adminHash, adminSalt);
            users.Add(admin);

            for (int i = 1; i <= 100; i++)
            {
                var title = $"Lorem ipsum dolor sit amet {i}";
                var question = $"Proin porta ante sed facilisis accumsan. Vestibulum rutrum nisl ut ornare finibus. Aliquam at ante id ligula efficitur pretium. Donec bibendum ultrices libero nec interdum. Donec sit amet imperdiet diam. Duis tincidunt leo semper semper feugiat. Mauris vehicula, orci vel ultricies euismod, purus ligula pellentesque massa, quis rhoncus urna leo sit amet purus.";
                var answer = $"Duis et justo congue purus lacinia blandit ac ornare urna. Aenean in lacinia nisl. Morbi pharetra dui at facilisis tempor. Phasellus convallis tempus aliquet. Aliquam quis neque massa. Integer ac cursus erat. Nam nibh lectus, aliquam pellentesque diam id, egestas accumsan quam. Nunc fringilla mauris est, id convallis lacus maximus pulvinar. Duis commodo ligula vitae molestie ornare. Nunc nec pellentesque risus. Vestibulum tristique molestie purus, commodo tincidunt felis volutpat ac. Donec sodales ante in lacus laoreet pellentesque eget in ex. Curabitur lobortis pellentesque viverra. Ut convallis tempus sollicitudin. Nulla porttitor mauris arcu, eget malesuada libero tempor non. Aliquam elit felis, bibendum quis imperdiet sit amet, facilisis vel dolor.";
                var card = new Card(title, question, answer);
                a70_532.AddCard(card);

                for (int j = 1; j <= 10; j++)
                {
                    var comment = new Comment($"{title}. Proin in viverra diam. Interdum et malesuada fames ac ante ipsum primis in faucibus {j}");
                    card.AddComment(comment);
                    admin.AddComment(comment);
                }
            }

            foreach (var category in categories)
            {
                var index = 1;
                foreach (var deck in category.Decks)
                {
                    index++;
                    var card = new Card($"Title {index}", $"Question {index}", $"Answer {index}");
                    var comment = new Comment($"Comment {index}");
                    card.AddComment(comment);
                    admin.AddComment(comment);
                    deck.AddCard(card);
                }
                index = 1;
            }

            Task.WaitAll(
                _dbContext.Users.AddRangeAsync(users),
                _dbContext.SaveChangesAsync(),
                _dbContext.Categories.AddRangeAsync(categories),
                _dbContext.SaveChangesAsync());
        }
    }
}
