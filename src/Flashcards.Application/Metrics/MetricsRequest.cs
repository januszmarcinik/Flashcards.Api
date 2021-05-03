using System;
using System.Collections.Generic;
using System.Linq;

namespace Flashcards.Application.Metrics
{
    public class MetricsRequest
    {
        private readonly List<MetricsStage> _stages;
        
        private MetricsRequest(
            Guid correlationId,
            DateTime startTime,
            DateTime? endTime,
            DateTime? checkpointTime,
            long elapsedMilliseconds,
            IEnumerable<MetricsStage> stages)
        {
            CorrelationId = correlationId;
            StartTime = startTime;
            EndTime = endTime;
            CheckpointTime = checkpointTime;
            ElapsedMilliseconds = elapsedMilliseconds;
            _stages = stages.ToList();
        }

        public Guid CorrelationId { get; }
        public DateTime StartTime { get; }
        public DateTime? EndTime { get; private set; }
        public long ElapsedMilliseconds { get; private set; }
        public DateTime? CheckpointTime { get; private set; }
        public IEnumerable<MetricsStage> Stages => _stages;

        public static MetricsRequest Start(Guid correlationId)
        {
            return new(correlationId, DateTime.Now, null, null, 0, new List<MetricsStage>());
        }

        public void SetCheckpoint()
        {
            if (CheckpointTime.HasValue)
            {
                throw new InvalidOperationException("Checkpoint time has been already set.");
            }
            
            CheckpointTime = DateTime.Now;
        }

        public MetricsStage EndCheckpoint(string name)
        {
            if (CheckpointTime.HasValue == false)
            {
                throw new InvalidOperationException("Cannot end checkpoint because checkpoint has not been set.");
            }

            var now = DateTime.Now;
            var elapsedMilliseconds = (now - CheckpointTime.Value).TotalMilliseconds;
            CheckpointTime = null;
            
            return AddStage(name, (long) elapsedMilliseconds);
        }

        public MetricsStage AddStage(string name, long elapsedMilliseconds)
        {
            if (CheckpointTime.HasValue)
            {
                throw new InvalidOperationException("Cannot add stage because checkpoint time has been set.");
            }

            var stage = new MetricsStage(name, elapsedMilliseconds);
            _stages.Add(stage);

            return stage;
        }

        public MetricsStage End(string name)
        {
            if (CheckpointTime.HasValue)
            {
                throw new InvalidOperationException("Cannot end request because checkpoint time has been set.");
            }
            
            EndTime = DateTime.Now;
            ElapsedMilliseconds = (long) (EndTime.Value - StartTime).TotalMilliseconds;
            var stagesElapsedMilliseconds = _stages.Sum(x => x.ElapsedMilliseconds);
            var millisecondsLoss = ElapsedMilliseconds - stagesElapsedMilliseconds;

            var lastStage = new MetricsStage(name, millisecondsLoss);
            _stages.Add(lastStage);

            return lastStage;
        }
    }
}