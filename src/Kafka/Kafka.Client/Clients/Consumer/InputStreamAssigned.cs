using Kafka.Client.Clients.Consumer.Models;
using Kafka.Common.Serialization;
using Kafka.Common.Types;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Consumer
{
    internal sealed class InputStreamAssigned<TKey, TValue> :
        InputStream<TKey, TValue>,
        IInputStreamSeekable<TKey, TValue>
    {
        public InputStreamAssigned(
            ImmutableArray<NodeAssignment> nodeAssignments,
            SortedList<TopicPartition, Offset> topicPartitionOffsets,
            IDeserializer<TKey> keyDeserializer,
            IDeserializer<TValue> valueDeserializer,
            ConsumerConfig config,
            ILogger<IConsumer<TKey, TValue>> logger
        ) : base(
            nodeAssignments,
            topicPartitionOffsets,
            keyDeserializer,
            valueDeserializer,
            config,
            logger
        )
        { }

        async ValueTask<ImmutableArray<TopicPartitionOffset>> IInputStreamSeekable<TKey, TValue>.Seek(
            ImmutableArray<TopicPartitionOffset> topicPartitionOffsets,
            CancellationToken cancellationToken
        )
        {
            await _semaphore.WaitAsync(cancellationToken);
            try
            {
                foreach (var topicPartitionOffset in topicPartitionOffsets)
                    _topicPartitionOffsets[topicPartitionOffset.TopicPartition] = topicPartitionOffset.Offset;
                return _topicPartitionOffsets
                    .Select(r => new TopicPartitionOffset(r.Key, r.Value))
                    .ToImmutableArray()
                ;
            }
            finally
            {
                _semaphore.Release();
            }
        }

        async ValueTask<ImmutableArray<TopicPartitionOffset>> IInputStreamSeekable<TKey, TValue>.Seek(
            ImmutableArray<TopicPartition> topicPartitionOffsets,
            DateTimeOffset timestamp,
            CancellationToken cancellationToken
        ) =>
            await Seek(timestamp, cancellationToken)
        ;

        async ValueTask<ImmutableArray<TopicPartitionOffset>> IInputStreamSeekable<TKey, TValue>.SeekToBeginning(
            CancellationToken cancellationToken
        ) =>
            await Seek(DateTimeOffset.FromUnixTimeMilliseconds(Offset.Beginning.Value), cancellationToken)
        ;

        async ValueTask<ImmutableArray<TopicPartitionOffset>> IInputStreamSeekable<TKey, TValue>.SeekToEnd(
            CancellationToken cancellationToken
        ) =>
            await Seek(DateTimeOffset.FromUnixTimeMilliseconds(Offset.End.Value), cancellationToken)
        ;

        private async ValueTask<ImmutableArray<TopicPartitionOffset>> Seek(
            DateTimeOffset timestamp,
            CancellationToken cancellationToken
        )
        {
            await _semaphore.WaitAsync(cancellationToken);
            try
            {
                var listOffsetsResponses = await ConsumerProtocol.RequestListOffsets(
                    _nodeAssignment,
                    _topicPartitionOffsets.Keys.ToImmutableSortedSet(),
                    _config.IsolationLevel,
                    timestamp,
                    cancellationToken
                );
                foreach (var listOffsetsResponse in listOffsetsResponses)
                    foreach (var topic in listOffsetsResponse.TopicsField)
                        foreach (var partition in topic.PartitionsField)
                            _topicPartitionOffsets[new(topic.NameField, partition.PartitionIndexField)] = partition.OffsetField;
                return _topicPartitionOffsets
                    .Select(r => new TopicPartitionOffset(r.Key, r.Value))
                    .ToImmutableArray()
                ;
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}
