using System;

namespace Flashcards.Application.Metrics
{
    public interface IMetricsService
    {
        void StartRequest(int stagesCount);
        
        void RestoreCorrelationId(Guid correlationId);

        void SaveCheckpoint(string message);

        void SaveTime(Action action, string message);

        MetricsRecord EndRequest();
    }
}