using Kafka.Common.Model;
using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Consumer
{
    internal sealed class StreamStreamAssigned<TKey, TValue> :
        StreamReader<TKey, TValue>,
        IStreamReaderAssigned<TKey, TValue>
    {
        public StreamStreamAssigned(
            IDeserializer<TKey> keyDeserializer,
            IDeserializer<TValue> valueDeserializer,
            ConsumerConfig config,
            ILogger<IConsumer<TKey, TValue>> logger
        ) : base(keyDeserializer, valueDeserializer, config, logger)
        {
        }

        ValueTask<ImmutableArray<TopicPartitionOffset>> IStreamReaderAssigned<TKey, TValue>.Seek(
            IReadOnlyDictionary<TopicPartition, Offset> topicPartitionOffsets,
            CancellationToken cancellationToken
        )
        {
            throw new NotImplementedException();
        }

        ValueTask<ImmutableArray<TopicPartitionOffset>> IStreamReaderAssigned<TKey, TValue>.Seek(
            IReadOnlyDictionary<TopicPartition, Timestamp> topicPartitionOffsets,
            CancellationToken cancellationToken
        )
        {
            throw new NotImplementedException();
        }

        ValueTask<ImmutableArray<TopicPartitionOffset>> IStreamReaderAssigned<TKey, TValue>.SeekToBeginning(
            CancellationToken cancellationToken
        )
        {
            throw new NotImplementedException();
        }

        ValueTask<ImmutableArray<TopicPartitionOffset>> IStreamReaderAssigned<TKey, TValue>.SeekToEnd(
            CancellationToken cancellationToken
        )
        {
            throw new NotImplementedException();
        }

        protected override ValueTask Closing(
            CancellationToken cancellationToken
        )
        {
            throw new NotImplementedException();
        }

        protected override ValueTask PrepareFetch(
            CancellationToken cancellationToken
        )
        {
            throw new NotImplementedException();
        }
    }
}
