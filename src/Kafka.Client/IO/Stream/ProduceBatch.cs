using Kafka.Client.Model.Internal;
using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Kafka.Client.IO.Stream
{
    internal sealed class ProduceBatch :
        IReadOnlyDictionary<TopicPartition, ProduceRecords>,
        IEnumerable<KeyValuePair<TopicPartition, ProduceRecords>>
    {
        private readonly int _maxSize;
        private readonly int _partitionLeaderEpoch;
        private readonly Attributes _attributes;
        private readonly long _producerId;
        private readonly short _producerEpoch;
        private readonly SortedList<TopicPartition, ProduceRecords> _topics = new(TopicPartitionCompare.Instance);

        private int _count;
        private int _batchSize;

        public ProduceBatch(
            int maxSize,
            int partitionLeaderEpoch,
            Attributes attributes,
            long producerId,
            short producerEpoch
        )
        {
            _maxSize = maxSize;
            _partitionLeaderEpoch = partitionLeaderEpoch;
            _attributes = attributes;
            _producerId = producerId;
            _producerEpoch = producerEpoch;
        }

        public int BatchSize => _batchSize;
        public int MaxSize => _maxSize;
        public int Count => _count;

        public IEnumerable<TopicPartition> Keys => _topics.Keys;

        public IEnumerable<ProduceRecords> Values => _topics.Values;

        public ProduceRecords this[TopicPartition topicPartition] => _topics[topicPartition];

        /// <summary>
        /// Returns false if max size is exceeded (always adds one).
        /// </summary>
        /// <param name="timestamp"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public AddRecordResult Add(
            ProduceCommand produceCommand
        )
        {
            if (_topics.TryGetValue(produceCommand.Record.TopicPartition, out var produceRecords))
                return TryAddExistingPartition(produceCommand, produceRecords);
            else
                return TryAddNewPartition(produceCommand);
        }

        private AddRecordResult TryAddNewPartition(
            ProduceCommand produceCommand
        )
        {
            var produceRecords = new ProduceRecords(
                _partitionLeaderEpoch,
                _attributes,
                produceCommand.Record.Timestamp.TimestampMs,
                _producerId,
                _producerEpoch
            );
            (var added, var recordSize) = produceRecords.TryAdd(
                produceCommand,
                _maxSize - _batchSize
            );
            if (added)
            {
                _count++;
                _batchSize += produceRecords.BatchSize;
                _topics.Add(
                    produceCommand.Record.TopicPartition,
                    produceRecords
                );
            }
            return (added, recordSize);
        }

        private AddRecordResult TryAddExistingPartition(
            ProduceCommand produceCommand,
            ProduceRecords produceRecords
        )
        {
            (var added, var recordSize) = produceRecords.TryAdd(
                produceCommand,
                _maxSize - _batchSize
            );
            if (added)
            {
                _count++;
                _batchSize += recordSize;
            }
            return (added, recordSize);
        }

        public IEnumerator<KeyValuePair<TopicPartition, ProduceRecords>> GetEnumerator() =>
            _topics.GetEnumerator()
        ;

        IEnumerator IEnumerable.GetEnumerator() =>
            _topics.GetEnumerator()
        ;

        public bool ContainsKey(TopicPartition key) =>
            _topics.ContainsKey(key)
        ;

        public bool TryGetValue(TopicPartition key, [MaybeNullWhen(false)] out ProduceRecords value) =>
            _topics.TryGetValue(key, out value)
        ;
    }
}
