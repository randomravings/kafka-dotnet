using Kafka.Client.Model;
using Kafka.Common.Model;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace Kafka.Client.Read
{
    public sealed class ReadRecordsEnumerator(
        IReadOnlyList<KeyValuePair<TopicPartition, IReadOnlyList<ReadRecord>>> records
    )
    {
        public static ReadRecordsEnumerator Empty { get; } = new(
            ImmutableArray<KeyValuePair<TopicPartition, IReadOnlyList<ReadRecord>>>.Empty
        );
        private readonly IReadOnlyList<KeyValuePair<TopicPartition, IReadOnlyList<ReadRecord>>> _records = records;
        private int _topicPartitionIndex;
        private int _recordsIndex = -1;

        public bool TryGetNext([MaybeNullWhen(false)] out ReadRecord record)
        {
            while (_topicPartitionIndex < _records.Count)
            {
                _recordsIndex++;
                if (_recordsIndex < _records[_topicPartitionIndex].Value.Count)
                {
                    record = _records[_topicPartitionIndex].Value[_recordsIndex];
                    return true;
                }
                else
                {
                    _topicPartitionIndex++;
                    _recordsIndex = -1;
                }
            }
            record = default;
            return false;
        }
    }
}
