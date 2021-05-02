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
            public MetricStage(int number, string message, DateTime timeStamp, long timeInMilliseconds)
            {
                Number = number;
                Message = message;
                TimeStamp = timeStamp;
                TimeInMilliseconds = timeInMilliseconds;
            }

            public int Number { get; }
            public string Message { get; }
            public DateTime TimeStamp { get; }
            public long TimeInMilliseconds { get; }
        }
    }
}