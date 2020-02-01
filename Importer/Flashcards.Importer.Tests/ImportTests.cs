using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Flashcards.Importer.Tests
{
    public class ImportTests
    {
        [Fact]
        public void Read_ShouldReturnAppropriateDecksWithCards()
        {
            var import = new Import("ImportData.txt");
            var expected = new List<Deck>()
            {
                new Deck("Animals", "Zwierzęta"),
                new Deck("Buildings", "Budynki"),
                new Deck("Clothes-and-accessories", "Ubrania i akcesoria")
            };
            expected[0].AddCard(new Card("bird", "ptak"));
            expected[0].AddCard(new Card("bull", "byk"));
            expected[1].AddCard(new Card("bookshop", "księgarnia"));
            expected[1].AddCard(new Card("cathedral", "katedra"));
            expected[2].AddCard(new Card("blouse", "bluzka damska"));
            expected[2].AddCard(new Card("button", "guzik"));
            
            var decks = import.Read();

            expected.Should().BeEquivalentTo(decks, options => options.Excluding(x => x.Id));
        }
    }
}
