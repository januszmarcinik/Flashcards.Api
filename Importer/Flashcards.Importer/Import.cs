using System;
using System.Collections.Generic;
using System.IO;

namespace Flashcards.Importer
{
    public class Import
    {
        private readonly string _pathToFile;

        public Import(string pathToFile)
        {
            _pathToFile = pathToFile;
        }

        public IEnumerable<Deck> Read()
        {
            var decks = new List<Deck>();
            Deck current = null;
            
            using var fileStream = new FileStream(_pathToFile, FileMode.Open);
            using var reader = new StreamReader(fileStream);

            while (reader.EndOfStream == false)
            {
                var line = reader.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }

                var indexOfDot = line.IndexOf(".", StringComparison.Ordinal);
                if (indexOfDot >= 0)
                {
                    var deck = GetDeck(line, indexOfDot);
                    decks.Add(deck);
                    current = deck;
                    
                    continue;
                }

                var card = GetCard(line);
                current?.AddCard(card);
            }

            return decks;
        }

        private static Deck GetDeck(string line, int indexOfDot)
        {
            var startBracketIndex = line.IndexOf("(", StringComparison.Ordinal);
            var endBracketIndex = line.IndexOf(")", StringComparison.Ordinal);

            var description = line.Substring(startBracketIndex + 1, endBracketIndex - startBracketIndex - 1);
            description = $"{description[0].ToString().ToUpper()}{description.Substring(1, description.Length - 1)}";

            var title = line
                .Remove(startBracketIndex)
                .Remove(0, indexOfDot)
                .Replace(".", "")
                .Replace("(", "")
                .Replace(")", "")
                .Trim()
                .Replace(" ", "-");
            
            return new Deck(title, description);
        }
        
        private static Card GetCard(string line)
        {
            var parts = line.Split("-");
            var question = parts[0].Trim();
            var answer = parts[1].Trim();
            
            return new Card(question, answer);
        }
    }
}