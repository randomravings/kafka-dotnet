using Kafka.Common.Model;
using Kafka.Common.Serialization;
using Microsoft.Extensions.Logging;

namespace Kafka.Client.IO.Read
{
    internal sealed class AssignedReader<TKey, TValue> :
        Reader<TKey, TValue>,
        IAssignedReader<TKey, TValue>
    {
        private readonly IAssignedReadStream _assingedStream;
        private readonly List<TopicPartitionOffset> _assignList = [];
        private readonly List<TopicPartitionOffset> _unassignList = [];

        internal AssignedReader(
            IAssignedReadStream stream,
            IReadOnlyList<TopicPartitionOffset> topicPartitionOffsets,
            IDeserializer<TKey> keyDeserializer,
            IDeserializer<TValue> valueDeserializer,
            ILogger logger
        ) : base(stream, keyDeserializer, valueDeserializer, logger)
        {
            _assingedStream = stream;
            _assignList.AddRange(topicPartitionOffsets);
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

        protected override async ValueTask Initialize(CancellationToken cancellationToken)
        {
            if (_assignList.Count == 0 && _unassignList.Count == 0)
                return;
            await _assingedStream.Assign(
                _assignList,
                cancellationToken
            ).ConfigureAwait(false);
            _assignList.Clear();
            _unassignList.Clear();
            _initialized = true;
        }

        Task IReader<TKey, TValue>.Close(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
