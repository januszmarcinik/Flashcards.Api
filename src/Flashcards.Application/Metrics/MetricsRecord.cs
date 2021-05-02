using System;
using System.Collections.Generic;

namespace Flashcards.Application.Metrics
{
    public class MetricsRecord
    {
        public MetricsRecord(Guid correlationId, int stagesCount)
        {
            CorrelationId = correlationId;
            StagesCount = stagesCount;
            Stages = new List<MetricStage>();
        }

        public Guid CorrelationId { get; }
        public int StagesCount { get; }
        public IList<MetricStage> Stages { get; }

        public class MetricStage
        {
            public MetricStage(int number, string message, long timeStamp, long elapsedMilliseconds)
            {
                Number = number;
                Message = message;
                TimeStamp = timeStamp;
                ElapsedMilliseconds = elapsedMilliseconds;
            }

            public int Number { get; }
            public string Message { get; }
            public long TimeStamp { get; }
            public long ElapsedMilliseconds { get; }
        }
    }
}