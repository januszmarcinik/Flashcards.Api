namespace Flashcards.Importer
{
    public class Card
    {
        public Card(string question, string answer)
        {
            Question = question;
            Answer = answer;
        }

        public string Question { get; }
        public string Answer { get; }
    }
}