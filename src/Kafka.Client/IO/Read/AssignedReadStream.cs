using Kafka.Client.Config;
using Kafka.Client.Net;
using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using Kafka.Common.Net;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Collections.Immutable;

namespace Kafka.Client.IO.Read
{
    internal class AssignedReadStream(
        ICluster<INodeLink> connectionManager,
        ReadStreamConfig config,
        ILogger logger
    ) :
        ReadStream(connectionManager, config, logger),
        IAssignedReadStream
    {
        private readonly SemaphoreSlim _reconfigureSemaphore = new(1, 1);

        IAssignedReaderBuilder IAssignedReadStream.CreateReader() =>
            new AssignedReaderBuilder(
                this,
                _logger
            )
        ;

        async ValueTask IAssignedReadStream.Assign(
            IReadOnlyList<TopicPartitionOffset> topicPartitionOffsets,
            CancellationToken cancellationToken
        )
        {
            await _reconfigureSemaphore.WaitAsync(
                cancellationToken
            ).ConfigureAwait(false);
            try
            {
                var topicPartitionOffsetsToAddBuilder = ImmutableArray.CreateBuilder<TopicPartitionOffset>();
                foreach (var topicPartitionOffset in topicPartitionOffsets)
                {
                    if (_trackedOffsets.ContainsKey(topicPartitionOffset.TopicPartition))
                        continue;
                    topicPartitionOffsetsToAddBuilder.Add(topicPartitionOffset);
                }
                var topicPartitionOffsetsToAdd = topicPartitionOffsetsToAddBuilder.ToImmutable();
                if (topicPartitionOffsetsToAdd.Length == 0)
                    return;

                var invalidTopicPartitionOffsets = await CheckTopicPartitionOffsetList(
                    topicPartitionOffsetsToAdd,
                    cancellationToken
                ).ConfigureAwait(false);
                if (invalidTopicPartitionOffsets.Length > 0)
                    throw new ArgumentException($"Cluster returned missing topic partitions invalid offsets: '{string.Join(',', invalidTopicPartitionOffsets)}'");
                foreach (var (topicPartition, offset) in topicPartitionOffsets)
                    _trackedOffsets.TryAdd(topicPartition, offset);
                SignalStateAltered();
            }
            finally
            {
                _reconfigureSemaphore.Release();
            }
        }

        async ValueTask IAssignedReadStream.Unassign(
            IReadOnlyList<TopicPartition> topicPartitions,
            CancellationToken cancellationToken
        )
        {
            await _reconfigureSemaphore.WaitAsync(
                cancellationToken
            ).ConfigureAwait(false);
            try
            {
                var topicPartitionsToRemove = new List<TopicPartition>();
                foreach (var topicPartition in topicPartitions)
                    if (_trackedOffsets.ContainsKey(topicPartition))
                        topicPartitionsToRemove.Add(topicPartition);
            }
            finally
            {
                _reconfigureSemaphore.Release();
            }
        }

        async ValueTask IAssignedReadStream.Seek(
            IReadOnlyList<TopicPartitionOffset> topicPartitionOffsets,
            CancellationToken cancellationToken
        )
        {
            await _reconfigureSemaphore.WaitAsync(
                cancellationToken
            ).ConfigureAwait(false);
            try
            {
                var topicPartitionOffsetsToSeekBuilder = ImmutableArray.CreateBuilder<TopicPartitionOffset>();
                foreach (var topicPartitionOffset in topicPartitionOffsets)
                {
                    if (!_trackedOffsets.ContainsKey(topicPartitionOffset.TopicPartition))
                        continue;
                    topicPartitionOffsetsToSeekBuilder.Add(topicPartitionOffset);
                }
                var topicPartitionOffsetsToSeek = topicPartitionOffsetsToSeekBuilder.ToImmutable();
                if (topicPartitionOffsetsToSeek.Length == 0)
                    return;

                var invalidTopicPartitionOffsets = await CheckTopicPartitionOffsetList(
                    topicPartitionOffsetsToSeek,
                    cancellationToken
                ).ConfigureAwait(false);
                if (invalidTopicPartitionOffsets.Length > 0)
                    throw new ArgumentException($"Cluster returned missing topic partitions invalid offsets: '{string.Join(',', invalidTopicPartitionOffsets)}'");
                foreach (var (topicPartition, offset) in topicPartitionOffsets)
                    _trackedOffsets[topicPartition] = offset;
                SignalStateAltered();
            }
            finally
            {
                _reconfigureSemaphore.Release();
            }
        }

        protected override ValueTask Closing(
            CancellationToken cancellationToken
        )
        {
            return ValueTask.CompletedTask;
        }

        protected override async ValueTask UpdateTrackedOffsets(
            ConcurrentDictionary<TopicPartition, Offset> trackedOffsets,
            CancellationToken cancellationToken
        )
        {
            var topics = trackedOffsets
                .Keys
                .Select(r => r.Topic)
                .ToImmutableSortedSet(TopicCompare.Instance)
            ;
            var stored = trackedOffsets
                .ToImmutableSortedDictionary(
                    k => k.Key,
                    v => v.Value,
                    TopicPartitionCompare.Instance
                )
            ;
            var coordinator = await GetCoordinator(cancellationToken).ConfigureAwait(false);
            var topicPartitions = await GetTopicPartitions(
                coordinator,
                topics,
                cancellationToken
            ).ConfigureAwait(false);
            trackedOffsets.Clear();
            foreach (var topicPartition in topicPartitions)
                trackedOffsets.TryAdd(topicPartition, stored[topicPartition]);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                _reconfigureSemaphore.Dispose();
            }
        }
    }
}
