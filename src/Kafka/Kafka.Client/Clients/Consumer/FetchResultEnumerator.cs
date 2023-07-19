using Kafka.Client.Clients.Consumer.Models;
using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using Kafka.Common.Serialization;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Consumer
{
    internal sealed class FetchResultEnumerator :
        IDisposable
    {
        public static FetchResultEnumerator Empty { get; } = new();

        private readonly SortedList<TopicPartition, Offset> _readOffsets = new(TopicPartitionCompare.Instance);
        private readonly ImmutableArray<FetchRecords> _fetchRecords;
        private readonly TaskCompletionSource<IReadOnlyDictionary<TopicPartition, Offset>> _taskCompletionSource;

        private int _recordsIndex;
        private int _recordIndex;
        private bool _disposed;

        private FetchResultEnumerator()
        {
            _fetchRecords = ImmutableArray<FetchRecords>.Empty;
            _taskCompletionSource = new TaskCompletionSource<IReadOnlyDictionary<TopicPartition, Offset>>();
            _taskCompletionSource.SetException(new InvalidOperationException());
            _disposed= true;
        }

        public FetchResultEnumerator(
            ImmutableArray<FetchRecords> fetchRecords,
            TaskCompletionSource<IReadOnlyDictionary<TopicPartition, Offset>> taskCompletionSource
        )
        {
            _fetchRecords = fetchRecords;
            _taskCompletionSource = taskCompletionSource;
            _recordIndex= -1;
        }

        public bool MoveNext()
        {
            if (_recordsIndex >= _fetchRecords.Length)
                return false;
            _recordIndex++;
            if (_recordIndex >= _fetchRecords[_recordsIndex].Records.Count)
            {
                _recordsIndex++;
                _recordIndex = -1;
                return MoveNext();
            }
            return true;
        }

        public ConsumerRecord<TKey, TValue> ReadRecord<TKey, TValue>(
            IDeserializer<TKey> keyDeserializer,
            IDeserializer<TValue> valueDeserializer
        )
        {
            (var topicPartition, var records, var errorCode) = _fetchRecords[_recordsIndex];
            var record = records[_recordIndex];
            var offset = records.BaseOffset + _recordIndex;
            var timestamp = records.BaseTimestamp + record.TimestampDelta;
            var key = keyDeserializer.Read(record.Key);
            var value = valueDeserializer.Read(record.Value);
            _readOffsets[topicPartition] = offset;
            return new ConsumerRecord<TKey, TValue>(
                TopicPartition: topicPartition,
                Offset: offset,
                Timestamp: records.Attributes.HasFlag(Attributes.LogAppendTime) ? Timestamp.LogAppend(timestamp) : Timestamp.Created(timestamp),
                Key: key,
                Value: value,
                Headers: record.Headers
            );
        }

        public void Dispose()
        {
            if (_disposed)
                return;
            _taskCompletionSource.SetResult(_readOffsets);
            _disposed = true;
        }
    }
}
