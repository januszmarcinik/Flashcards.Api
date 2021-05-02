using System;
using System.Diagnostics;
using Flashcards.Application.Cache;
using Flashcards.Core.Extensions;
using Microsoft.Extensions.Logging;

namespace Flashcards.Application.Metrics
{
    public class MetricsService : IMetricsService
    {
        private readonly ILogger<MetricsService> _logger;
        private readonly ICacheService _cache;

        public MetricsService(ILogger<MetricsService> logger, ICacheService cache)
        {
            _logger = logger;
            _cache = cache;
        }

        public Guid StartRequest(int stagesCount)
        {
            var correlationId = Guid.NewGuid();
            var record = new MetricsRecord(correlationId, stagesCount);
            SaveRecord(record);

            return correlationId;
        }

        public void SaveCheckpoint(Guid correlationId, string message)
        {
            AddStage(correlationId, message, 0);
        }

        public void SaveTime(Guid correlationId, string message, Action action)
        {
            var watch = new Stopwatch();
            watch.Start();
            
            action();
            
            watch.Stop();
            var elapsedMilliseconds = watch.ElapsedMilliseconds;

            AddStage(correlationId, message, elapsedMilliseconds);
        }

        public MetricsRecord EndRequest(Guid correlationId) => GetRecord(correlationId);

        private void SaveRecord(MetricsRecord record) => 
            _cache.Set($"metrics-{record.CorrelationId}", record, TimeSpan.FromMinutes(5));

        private MetricsRecord GetRecord(Guid correlationId) =>
            _cache.Get<MetricsRecord>($"metrics-{correlationId}");

        private void AddStage(Guid correlationId, string message, long elapsedMilliseconds)
        {
            var timeStamp = DateTime.Now.GetTimeStamp();
            var now = DateTime.Now;
            var record = GetRecord(correlationId);
            var stageNumber = record.Stages.Count + 1;
            var stage = new MetricsRecord.MetricStage(stageNumber, message, timeStamp, elapsedMilliseconds);
            record.Stages.Add(stage);
            SaveRecord(record);
            
            _logger.LogInformation(
                "{LogType}: {CorrelationId} ({StageNumber}/{StagesCount}) {Message} - {TimeStamp} / {ElapsedMilliseconds}ms",
                "Metrics",
                record.CorrelationId,
                stageNumber,
                record.StagesCount,
                message,
                timeStamp,
                elapsedMilliseconds);
        }
    }
}