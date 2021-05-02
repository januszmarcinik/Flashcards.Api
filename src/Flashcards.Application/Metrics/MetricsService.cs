using System;
using System.Diagnostics;
using Flashcards.Application.Cache;
using Microsoft.Extensions.Logging;

namespace Flashcards.Application.Metrics
{
    public class MetricsService : IMetricsService
    {
        private readonly ILogger<MetricsService> _logger;
        private readonly ICacheService _cache;
        private Guid _correlationId;

        public MetricsService(ILogger<MetricsService> logger, ICacheService cache)
        {
            _logger = logger;
            _cache = cache;
        }

        public void StartRequest(int stagesCount)
        {
            _correlationId = Guid.NewGuid();
            var record = new MetricsRecord(_correlationId, stagesCount);
            SaveRecord(record);
        }

        public void RestoreCorrelationId(Guid correlationId)
        {
            _correlationId = correlationId;
        }

        public void SaveCheckpoint(string message)
        {
            AddStage(message, 0);
        }

        public void SaveTime(Action action, string message)
        {
            var watch = new Stopwatch();
            watch.Start();
            
            action();
            
            watch.Stop();
            var elapsedMilliseconds = watch.ElapsedMilliseconds;

            AddStage(message, elapsedMilliseconds);
        }

        public MetricsRecord EndRequest()
        {
            _correlationId = Guid.Empty;
            return GetRecord();
        }

        private string Key => $"metrics-{_correlationId}";

        private void SaveRecord(MetricsRecord record) => 
            _cache.Set(Key, record, TimeSpan.FromMinutes(5));

        private MetricsRecord GetRecord() =>
            _cache.Get<MetricsRecord>(Key);

        private void AddStage(string message, long timeInMilliseconds)
        {
            var now = new DateTime();
            var record = GetRecord();
            var stageNumber = record.Stages.Count + 1;
            var stage = new MetricsRecord.MetricStage(stageNumber, message, now, timeInMilliseconds);
            record.Stages.Add(stage);
            SaveRecord(record);
            
            _logger.LogInformation(
                "{LogType}: {CorrelationId} ({StageNumber}/{StagesCount}) {Message}",
                "Request metrics",
                record.CorrelationId,
                stageNumber,
                record.StagesCount,
                message);
        }
    }
}