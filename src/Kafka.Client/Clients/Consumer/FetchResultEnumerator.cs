using Kafka.Client.Clients.Consumer.Models;
using Kafka.Common.Model;
using Kafka.Common.Serialization;
using System.Collections.Immutable;

namespace Kafka.Client.Clients.Consumer
{
    internal sealed class FetchResultEnumerator
    {
        public static FetchResultEnumerator Empty { get; } = new();

        private readonly Action<RawConsumerRecord> _onRead;
        private readonly ImmutableArray<RawConsumerRecord> _fetchRecords;
        private readonly TaskCompletionSource _taskCompletionSource;
        private readonly int _eod;

        private int _index;
        private FetchEnumeratorState _state;

        private FetchResultEnumerator()
        {
            _fetchRecords = ImmutableArray<RawConsumerRecord>.Empty;
            _onRead = r => { };
            _taskCompletionSource = new TaskCompletionSource();
            _taskCompletionSource.SetException(new InvalidOperationException());
            _state = FetchEnumeratorState.Closed;
        }

        public FetchResultEnumerator(
            ImmutableArray<RawConsumerRecord> fetchRecords,
            Action<RawConsumerRecord> onRead,
            TaskCompletionSource taskCompletionSource
        )
        {
            _fetchRecords = fetchRecords;
            _onRead = onRead;
            _taskCompletionSource = taskCompletionSource;
            _index = -1;
            _state = FetchEnumeratorState.Active;
            if (fetchRecords.Length == 0)
                _state = FetchEnumeratorState.End;
            else
                _state = FetchEnumeratorState.Active;
            _eod = _fetchRecords.Length - 1;
        }

        public FetchEnumeratorState MoveNext()
        {
            switch (_state)
            {
                case FetchEnumeratorState.Active:
                    _index++;
                    if (_index == _eod)
                        _state = FetchEnumeratorState.End;
                    break;
                case FetchEnumeratorState.End:
                case FetchEnumeratorState.Closed:
                    break;
            }
            return _state;
        }

        public ConsumerRecord<TKey, TValue> ReadRecord<TKey, TValue>(
            IDeserializer<TKey> keyDeserializer,
            IDeserializer<TValue> valueDeserializer
        )
        {
            var record = _fetchRecords[_index];
            var key = keyDeserializer.Read(record.Key);
            var value = valueDeserializer.Read(record.Value);
            _onRead(record);
            return new ConsumerRecord<TKey, TValue>(
                TopicPartition: record.TopicPartition,
                Offset: record.Offset,
                Timestamp: record.Timestamp,
                Key: key,
                Value: value,
                Headers: record.Headers
            );
        }

        public void Close()
        {
            if (_state == FetchEnumeratorState.Closed)
                return;
            _taskCompletionSource.SetResult();
            _state = FetchEnumeratorState.Closed;
        }
    }
}
