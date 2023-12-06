using Kafka.Client.Model.Internal;
using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Records;
using System.Collections;

namespace Kafka.Client.IO.Write
{
    internal sealed class WriteRecords :
        IRecords,
        IEnumerable<ProduceCommand>
    {
        private readonly int _partitionLeaderEpoch;
        private readonly Attributes _attributes;
        private readonly long _baseTimestamp;
        private readonly long _producerId;
        private readonly short _producerEpoch;
        private readonly List<IRecord> _packedRecords = new();

        private int _baseSequence;
        private int _batchSize;
        private long _maxTimestamp;

        private sealed record PackedRecord(
            int Length,
            long TimestampDelta,
            int OffsetDelta,
            ProduceCommand ProduceCommand
        ) : IRecord
        {
            int IRecord.Length => Length;

            Attributes IRecord.Attributes => Attributes.None;

            long IRecord.TimestampDelta => TimestampDelta;

            int IRecord.OffsetDelta => OffsetDelta;

            ReadOnlyMemory<byte>? IRecord.Key => ProduceCommand.Record.Key;

            ReadOnlyMemory<byte>? IRecord.Value => ProduceCommand.Record.Value;

            IReadOnlyList<RecordHeader> IRecord.Headers => ProduceCommand.Record.Headers;
        }

        public WriteRecords(
            int partitionLeaderEpoch,
            Attributes attributes,
            long baseTimestamp,
            long producerId,
            short producerEpoch
        )
        {
            _partitionLeaderEpoch = partitionLeaderEpoch;
            _attributes = attributes;
            _baseTimestamp = baseTimestamp;
            _producerId = producerId;
            _producerEpoch = producerEpoch;
        }

        public int BatchSize => _batchSize;

        public long BaseOffset => 0;

        public int BatchLength => _batchSize;

        public int PartitionLeaderEpoch => _partitionLeaderEpoch;

        public sbyte Magic => 2;

        public int Crc => 0;

        public Attributes Attributes => _attributes;

        public int LastOffsetDelta => _packedRecords.Count - 1;

        public long BaseTimestamp => _baseTimestamp;

        public long MaxTimestamp => _maxTimestamp;

        public long ProducerId => _producerId;

        public short ProducerEpoch => _producerEpoch;

        public int BaseSequence => _baseSequence;

        public IReadOnlyList<IRecord> Records => _packedRecords;

        /// <summary>
        /// Tries to add a record to the collection.
        /// Will always add at least one record and subsequent additions are subject to the max size limit provided.
        /// </summary>
        /// <param name="sendCommand">The send command to add.</param>
        /// <param name="maxSize">The size limit to add.</param>
        /// <returns>A tuple containing: A boolean indicating if the record was added and, The total number of bytes required.</returns>
        public AddRecordResult TryAdd(
            in ProduceCommand produceCommand,
            in int maxSize
        )
        {
            var (record, _) = produceCommand;
            var timestampDelta = produceCommand.Record.Timestamp.Millisconds - _baseTimestamp;
            var offsetDelta = _packedRecords.Count;
            var recordSize = BinaryEncoder.ComputeRecordSize(
                timestampDelta,
                offsetDelta,
                record.Key,
                record.Value,
                record.Headers
            );
            var bufferSize = BinaryEncoder.SizeOfVarInt32(recordSize) + recordSize;
            if (_packedRecords.Count > 0 && bufferSize > maxSize)
                return (false, bufferSize);
            var packedRecord = new PackedRecord(
                recordSize,
                timestampDelta,
                offsetDelta,
                produceCommand
            );
            _packedRecords.Add(packedRecord);
            _maxTimestamp = Math.Max(_maxTimestamp, record.Timestamp.Millisconds);
            _batchSize += bufferSize;
            return (true, bufferSize);
        }

        public void SetBaseSequence(int baseSequence) =>
            _baseSequence = baseSequence
        ;

        public IEnumerator<ProduceCommand> GetEnumerator()
        {
            for (int i = 0; i < _packedRecords.Count; i++)
                yield return ((PackedRecord)_packedRecords[i]).ProduceCommand;
        }

        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator()
        ;
    }
}
