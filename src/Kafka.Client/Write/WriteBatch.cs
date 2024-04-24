using Kafka.Client.Model.Internal;
using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Comparison;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Kafka.Client.Write
{
    internal sealed class WriteBatch(
        int maxSize,
        int partitionLeaderEpoch,
        Attributes attributes,
        long producerId,
        short producerEpoch
    ) :
        IReadOnlyDictionary<TopicPartition, WriteRecords>,
        IEnumerable<KeyValuePair<TopicPartition, WriteRecords>>
    {
        private readonly int _maxSize = maxSize;
        private readonly int _partitionLeaderEpoch = partitionLeaderEpoch;
        private readonly Attributes _attributes = attributes;
        private readonly long _producerId = producerId;
        private readonly short _producerEpoch = producerEpoch;
        private readonly Dictionary<TopicPartition, WriteRecords> _topics = new(TopicPartitionCompare.Equality);

        private int _count;
        private int _batchSize;

        public int BatchSize => _batchSize;
        public int MaxSize => _maxSize;
        public int Count => _count;

        public IEnumerable<TopicPartition> Keys => _topics.Keys;

        public IEnumerable<WriteRecords> Values => _topics.Values;

        public WriteRecords this[TopicPartition topicPartition] => _topics[topicPartition];

        /// <summary>
        /// Returns false if max size is exceeded (always adds one).
        /// </summary>
        /// <param name="timestamp"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public AddRecordResult Add(
            WriteCommand writeCommand
        )
        {
            if (_topics.TryGetValue(writeCommand.Record.TopicPartition, out var writeRecords))
                return TryAddExistingPartition(writeCommand, writeRecords);
            else
                return TryAddNewPartition(writeCommand);
        }

        private AddRecordResult TryAddNewPartition(
            WriteCommand writeCommand
        )
        {
            var writeRecords = new WriteRecords(
                _partitionLeaderEpoch,
                _attributes,
                writeCommand.Record.Timestamp.Millisconds,
                _producerId,
                _producerEpoch
            );
            (var added, var recordSize) = writeRecords.TryAdd(
                writeCommand,
                _maxSize - RecordsConstants.RecordsHeaderSize - _batchSize
            );
            if (added)
            {
                _count++;
                _batchSize += RecordsConstants.RecordsHeaderSize;
                _batchSize += writeRecords.BatchSize;
                _topics.Add(
                    writeCommand.Record.TopicPartition,
                    writeRecords
                );
            }
            return (added, recordSize);
        }

        private AddRecordResult TryAddExistingPartition(
            WriteCommand writeCommand,
            WriteRecords writeRecords
        )
        {
            (var added, var recordSize) = writeRecords.TryAdd(
                writeCommand,
                _maxSize - _batchSize
            );
            if (added)
            {
                _count++;
                _batchSize += recordSize;
            }
            return (added, recordSize);
        }

        public IEnumerator<KeyValuePair<TopicPartition, WriteRecords>> GetEnumerator() =>
            _topics.GetEnumerator()
        ;

        IEnumerator IEnumerable.GetEnumerator() =>
            _topics.GetEnumerator()
        ;

        public bool ContainsKey(TopicPartition key) =>
            _topics.ContainsKey(key)
        ;

        public bool TryGetValue(TopicPartition key, [MaybeNullWhen(false)] out WriteRecords value) =>
            _topics.TryGetValue(key, out value)
        ;
    }
}
