using System;

namespace Flashcards.Application.Metrics
{
    public interface IMetricsService
    {
        Guid StartRequest(int stagesCount);
        void SaveCheckpoint(Guid correlationId, string message);
        void SaveTime(Guid correlationId, string message, Action action);
        MetricsRecord EndRequest(Guid correlationId);
    }
}