using Kafka.Client.Model;
using Kafka.Common.Model;
using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;

namespace Kafka.Client.IO.Read
{
    internal class AssignedReader<TKey, TValue> :
        Reader<TKey, TValue>,
        IAssignedReader<TKey, TValue>
    {
        private readonly IDeserializer<TKey> _keyDeserializer;
        private readonly IDeserializer<TValue> _valueDeserializer;

        internal AssignedReader(
            IAssignedReadStream stream,
            IReadOnlyList<TopicPartition> topicPartitions,
            IDeserializer<TKey> keyDeserializer,
            IDeserializer<TValue> valueDeserializer,
            ILogger logger
        ) : base(stream, keyDeserializer, valueDeserializer, logger)
        {
            _keyDeserializer = keyDeserializer;
            _valueDeserializer = valueDeserializer;
        }

        ValueTask IAssignedReader<TKey, TValue>.Assign(TopicPartition topicPartition)
        {
            throw new NotImplementedException();
        }

        ValueTask IAssignedReader<TKey, TValue>.Assign(IReadOnlyList<TopicPartition> topicPartitions)
        {
            throw new NotImplementedException();
        }

        ValueTask IAssignedReader<TKey, TValue>.Assign(TopicPartitionOffset topicPartitionOffset)
        {
            throw new NotImplementedException();
        }

        ValueTask IAssignedReader<TKey, TValue>.Assign(IReadOnlyList<TopicPartitionOffset> topicPartitionOffsets)
        {
            throw new NotImplementedException();
        }

        ValueTask IAssignedReader<TKey, TValue>.Seek(TopicPartitionOffset topicPartitionOffset)
        {
            throw new NotImplementedException();
        }

        ValueTask IAssignedReader<TKey, TValue>.Seek(IReadOnlyList<TopicPartitionOffset> topicPartitionOffsets)
        {
            throw new NotImplementedException();
        }

        ValueTask IAssignedReader<TKey, TValue>.Seek(TopicPartition topicPartition)
        {
            throw new NotImplementedException();
        }

        ValueTask IAssignedReader<TKey, TValue>.Seek(IReadOnlyList<TopicPartition> topicPartitions, Timestamp timestamp)
        {
            throw new NotImplementedException();
        }

        ValueTask IAssignedReader<TKey, TValue>.SeekBeginning()
        {
            throw new NotImplementedException();
        }

        ValueTask IAssignedReader<TKey, TValue>.SeekBeginning(TopicPartition topicPartition)
        {
            throw new NotImplementedException();
        }

        ValueTask IAssignedReader<TKey, TValue>.SeekBeginning(IReadOnlyList<TopicPartition> topicPartitions)
        {
            throw new NotImplementedException();
        }

        ValueTask IAssignedReader<TKey, TValue>.SeekEnd()
        {
            throw new NotImplementedException();
        }

        ValueTask IAssignedReader<TKey, TValue>.SeekEnd(TopicPartition topicPartition)
        {
            throw new NotImplementedException();
        }

        ValueTask IAssignedReader<TKey, TValue>.SeekEnd(IReadOnlyList<TopicPartition> topicPartitions)
        {
            throw new NotImplementedException();
        }

        ValueTask IAssignedReader<TKey, TValue>.Unassign(TopicPartition topicPartitionOffset)
        {
            throw new NotImplementedException();
        }

        ValueTask IAssignedReader<TKey, TValue>.Unassign(IReadOnlyList<TopicPartition> topicPartitions)
        {
            throw new NotImplementedException();
        }

        protected override ValueTask Initialize(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task IReader<TKey, TValue>.Close(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
