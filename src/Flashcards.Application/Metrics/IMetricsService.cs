using System;

namespace Flashcards.Application.Metrics
{
    public interface IMetricsService
    {
        void StartRequest(Guid correlationId);
        void SetCheckpoint(Guid correlationId);
        void EndCheckpoint(Guid correlationId, string name);
        void SaveTime(Guid correlationId, string name, Action action);
        MetricsRequest EndRequest(Guid correlationId, string lastStageName);
    }
}