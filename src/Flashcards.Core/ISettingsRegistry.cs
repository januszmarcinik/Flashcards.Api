namespace Flashcards.Core
{
    public interface ISettingsRegistry
    {
        T GetSettings<T>() where T : ISettings, new();

        void AddSettings<T>() where T : class, ISettings;
    }
}