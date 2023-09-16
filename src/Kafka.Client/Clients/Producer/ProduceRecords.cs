using Kafka.Client.Clients.Producer.Model;
using Kafka.Common.Encoding;
using Kafka.Common.Hashing;
using Kafka.Common.Model;

namespace Kafka.Client.Clients.Producer
{
    internal sealed class ProduceRecords
    {
        public const int BATCH_OFFSET_IX = 0;
        public const int BATCH_LENGTH_IX = 8;
        public const int PARTITION_LEADER_EPOCH_IX = 12;
        public const int MAGIC_BYTE_IX = 16;
        public const int CRC_IX = 17;
        public const int ATTRIBUTES_IX = 21;
        public const int LAST_OFFSET_DELTA_IX = 23;
        public const int BASE_TIMESTAMP_IX = 27;
        public const int MAX_TIMESTAMP_IX = 35;
        public const int PRODUCER_ID_IX = 43;
        public const int PRODUCER_EPOCH_IX = 51;
        public const int BASE_SEQUENCE_IX = 53;
        public const int RECORDS_COUNT_IX = 57;

        public const sbyte MAGIC_BYTE = 2;
        public const int BATCH_HEADER_SIZE = 61;
        public const int MAX_BATCH_SIZE = int.MaxValue - BATCH_HEADER_SIZE;

        public const int CRC_INDEX = ATTRIBUTES_IX;
        public const int CRC_HEADER_LENGTH = BATCH_HEADER_SIZE - CRC_INDEX;

        private readonly int _partitionLeaderEpoch;
        private readonly Attributes _attributes;
        private readonly long _baseTimestamp;
        private readonly long _producerId;
        private readonly short _producerEpoch;
        private readonly int _baseSequence;
        private readonly byte[] _headerBytes = new byte[BATCH_HEADER_SIZE];
        private readonly List<byte[]> _packedRecords = new();

        private int _batchSize = BATCH_HEADER_SIZE;
        private long _maxTimestamp;

        public ProduceRecords(
            int partitionLeaderEpoch,
            Attributes attributes,
            long baseTimestamp,
            long producerId,
            short producerEpoch,
            int baseSequence
        )
        {
            _partitionLeaderEpoch = partitionLeaderEpoch;
            _attributes = attributes;
            _baseTimestamp = baseTimestamp;
            _producerId = producerId;
            _producerEpoch = producerEpoch;
            _baseSequence = baseSequence;
        }

        public int BatchSize => _batchSize;

        /// <summary>
        /// Tries to add a record to the collection.
        /// Will always add at least one record and subsequent additions are subject to the max size limit provided.
        /// </summary>
        /// <param name="sendCommand">The send command to add.</param>
        /// <param name="maxSize">The size limit to add.</param>
        /// <returns>A tuple containing: A boolean indicating if the record was added and, The total number of bytes required.</returns>
        public AddRecordResult TryAdd(
            SendCommand sendCommand,
            int maxSize
        )
        {
            var timestampDelta = sendCommand.Timestamp.TimestampMs - _baseTimestamp;
            var offsetDelta = _packedRecords.Count;
            var recordSize = BinaryEncoder.ComputeRecordSize(
                timestampDelta,
                offsetDelta,
                sendCommand.Key,
                sendCommand.Value,
                sendCommand.Headers
            );
            var bufferSize = BinaryEncoder.SizeOfVarInt32(recordSize) + recordSize;
            if (_packedRecords.Count > 0 && bufferSize > maxSize)
                return (false, bufferSize);
            var bytes = new byte[bufferSize];
            BinaryEncoder.WriteRecord(
                bytes,
                timestampDelta,
                offsetDelta,
                sendCommand.Key,
                sendCommand.Value,
                sendCommand.Headers
            );
            _packedRecords.Add(bytes);
            _maxTimestamp = Math.Max( _maxTimestamp, sendCommand.Timestamp.TimestampMs);
            _batchSize += bufferSize;
            return (true, bufferSize);
        }

        public void PackHeader()
        {
            BinaryEncoder.WriteInt64(_headerBytes, BATCH_OFFSET_IX, 0);
            BinaryEncoder.WriteInt32(_headerBytes, BATCH_LENGTH_IX, _batchSize);
            BinaryEncoder.WriteInt32(_headerBytes, PARTITION_LEADER_EPOCH_IX, _partitionLeaderEpoch);
            BinaryEncoder.WriteInt8(_headerBytes, MAGIC_BYTE_IX, MAGIC_BYTE);

            BinaryEncoder.WriteInt16(_headerBytes, ATTRIBUTES_IX, (short)_attributes);
            BinaryEncoder.WriteInt32(_headerBytes, LAST_OFFSET_DELTA_IX, _packedRecords.Count - 1);
            BinaryEncoder.WriteInt64(_headerBytes, BASE_TIMESTAMP_IX, _baseTimestamp);
            BinaryEncoder.WriteInt64(_headerBytes, MAX_TIMESTAMP_IX, _maxTimestamp);
            BinaryEncoder.WriteInt64(_headerBytes, PRODUCER_ID_IX, _producerId);
            BinaryEncoder.WriteInt16(_headerBytes, PRODUCER_EPOCH_IX, _producerEpoch);
            BinaryEncoder.WriteInt32(_headerBytes, BASE_SEQUENCE_IX, _baseSequence);
            BinaryEncoder.WriteInt32(_headerBytes, RECORDS_COUNT_IX, _packedRecords.Count);

            var crc = Crc32c.Update(_headerBytes, CRC_INDEX, CRC_HEADER_LENGTH);
            foreach (var record in _packedRecords)
                crc = Crc32c.Update(crc, record);

            BinaryEncoder.WriteInt32(_headerBytes, CRC_INDEX, unchecked((int)crc));
        }

        public byte[] GetHeader() =>
            _headerBytes
        ;

        public IReadOnlyList<byte[]> GetBytes() =>
            _packedRecords
        ;
    }
}
