using Kafka.Client.Clients.Producer.Model;
using Kafka.Common.Model;

namespace Kafka.Client.Clients.Producer
{
    internal sealed class ProduceBatchV2
    {
        private readonly int _maxSize;
        private readonly int _partitionLeaderEpoch;
        private readonly Attributes _attributes;
        private readonly long _producerId;
        private readonly short _producerEpoch;
        private readonly int _baseSequence;
        private readonly Dictionary<TopicPartition, ProduceRecords> _topics = new();

        private int _batchSize;

        public ProduceBatchV2(
            int maxSize,
            int partitionLeaderEpoch,
            Attributes attributes,
            long producerId,
            short producerEpoch,
            int baseSequence
        )
        {
            _maxSize = maxSize;
            _partitionLeaderEpoch = partitionLeaderEpoch;
            _attributes = attributes;
            _producerId = producerId;
            _producerEpoch = producerEpoch;
            _baseSequence = baseSequence;
        }

        public int BatchSize => _batchSize;
        public int MaxSize => _maxSize;

        /// <summary>
        /// Returns false if max size is exceeded (always adds one).
        /// </summary>
        /// <param name="timestamp"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public AddRecordResult Add(
            SendCommand sendCommand
        )
        {
            if (_topics.TryGetValue(sendCommand.TopicPartition, out var produceRecords))
                return TryAddExistingPartition(sendCommand, produceRecords);
            else
                return TryAddNewPartition(sendCommand);
        }

        private AddRecordResult TryAddNewPartition(
            SendCommand sendCommand
        )
        {
            var produceRecords = new ProduceRecords(
                _partitionLeaderEpoch,
                _attributes,
                sendCommand.Timestamp.TimestampMs,
                _producerId,
                _producerEpoch,
                _baseSequence
            );
            (var added, var recordSize) = produceRecords.TryAdd(
                sendCommand,
                _maxSize - (_batchSize + ProduceRecords.BATCH_HEADER_SIZE)
            );
            if (added)
            {
                _batchSize += produceRecords.BatchSize;
                _topics.Add(
                    sendCommand.TopicPartition,
                    produceRecords
                );
            }
            return (added, recordSize + ProduceRecords.BATCH_HEADER_SIZE);
        }

        private AddRecordResult TryAddExistingPartition(
            SendCommand sendCommand,
            ProduceRecords produceRecords
        )
        {
            (var added, var recordSize) = produceRecords.TryAdd(
                sendCommand,
                _maxSize - _batchSize
            );
            if(added)
                _batchSize += recordSize;
            return (added, recordSize);
        }
    }
}
