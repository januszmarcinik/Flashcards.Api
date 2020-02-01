namespace Flashcards.Importer
{
    class Program
    {
        private const string PathToFile = "ImportData.txt";
        private const string ApiUrl = "http://api.flashcards.januszmarcinik.pl/api";
        
        static void Main(string[] args)
        {
            var import = new Import(PathToFile);
            var decks = import.Read();

            var sender = new Sender(ApiUrl, args[0], args[1]);

            sender.Send(decks);
        }
    }
}