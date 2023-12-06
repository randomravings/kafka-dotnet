using Kafka.Client.Model;
using Kafka.Common.Model;
using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;

namespace Kafka.Client.IO.Read
{
    internal class ManualReader :
        Reader,
        IManualReader,
        IDisposable
    {
        private protected readonly IManualReadStream _manualStream;
        private protected readonly IReadOnlyList<TopicPartition> _topicPartitions;

        internal ManualReader(
            IManualReadStream stream,
            IReadOnlyList<TopicPartition> topicPartitions,
            ILogger logger
        ) : base(stream, logger)
        {
            _manualStream = stream;
            _topicPartitions = topicPartitions;
        }

        ValueTask IManualReader.Assign(TopicPartition topicPartition)
        {
            throw new NotImplementedException();
        }

        ValueTask IManualReader.Assign(IReadOnlyList<TopicPartition> topicPartitions)
        {
            throw new NotImplementedException();
        }

        ValueTask IManualReader.Assign(TopicPartitionOffset topicPartitionOffset)
        {
            throw new NotImplementedException();
        }

        ValueTask IManualReader.Assign(IReadOnlyList<TopicPartitionOffset> topicPartitionOffsets)
        {
            throw new NotImplementedException();
        }

        ValueTask IManualReader.Seek(TopicPartitionOffset topicPartitionOffset)
        {
            throw new NotImplementedException();
        }

        ValueTask IManualReader.Seek(IReadOnlyList<TopicPartitionOffset> topicPartitionOffsets)
        {
            throw new NotImplementedException();
        }

        ValueTask IManualReader.Seek(TopicPartition topicPartition)
        {
            throw new NotImplementedException();
        }

        ValueTask IManualReader.Seek(IReadOnlyList<TopicPartition> topicPartitions, Timestamp timestamp)
        {
            throw new NotImplementedException();
        }

        ValueTask IManualReader.SeekBeginning()
        {
            throw new NotImplementedException();
        }

        ValueTask IManualReader.SeekBeginning(TopicPartition topicPartition)
        {
            throw new NotImplementedException();
        }

        ValueTask IManualReader.SeekBeginning(IReadOnlyList<TopicPartition> topicPartitions)
        {
            throw new NotImplementedException();
        }

        ValueTask IManualReader.SeekEnd()
        {
            throw new NotImplementedException();
        }

        ValueTask IManualReader.SeekEnd(TopicPartition topicPartition)
        {
            throw new NotImplementedException();
        }

        ValueTask IManualReader.SeekEnd(IReadOnlyList<TopicPartition> topicPartitions)
        {
            throw new NotImplementedException();
        }

        ValueTask IManualReader.Unassign(TopicPartition topicPartitionOffset)
        {
            throw new NotImplementedException();
        }

        ValueTask IManualReader.Unassign(IReadOnlyList<TopicPartition> topicPartitions)
        {
            throw new NotImplementedException();
        }

        protected override ValueTask Initialize(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }



    internal class ManualReader<TKey, TValue> :
        ManualReader,
        IManualReader<TKey, TValue>
    {
        private readonly IDeserializer<TKey> _keyDeserializer;
        private readonly IDeserializer<TValue> _valueDeserializer;

        internal ManualReader(
            IManualReadStream stream,
            IReadOnlyList<TopicPartition> topicPartitions,
            IDeserializer<TKey> keyDeserializer,
            IDeserializer<TValue> valueDeserializer,
            ILogger logger
        ) : base(stream, topicPartitions, logger)
        {
            _keyDeserializer = keyDeserializer;
            _valueDeserializer = valueDeserializer;
        }

        async ValueTask<ReadRecord<TKey, TValue>> IReader<TKey, TValue>.Read(
            CancellationToken cancellationToken
        ) =>
            await Read(_keyDeserializer, _valueDeserializer, cancellationToken)
                .ConfigureAwait(false)
        ;

        async ValueTask<ReadRecord<TKey, TValue>> IReader<TKey, TValue>.Read(
            TimeSpan timeout,
            CancellationToken cancellationToken
        )
        {
            using var cts = CancellationTokenSource.CreateLinkedTokenSource(
                cancellationToken
            );
            cts.CancelAfter(timeout);
            return await Read(_keyDeserializer, _valueDeserializer, cts.Token)
                .ConfigureAwait(false)
            ;
        }

        Task IReader<TKey, TValue>.Close(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
