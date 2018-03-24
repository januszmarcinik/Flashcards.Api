namespace Flashcards.Infrastructure.Managers.Abstract
{
    public interface IEncryptionManager
    {
        string GetSalt(string value);
        string GetHash(string value, string salt);
    }
}
