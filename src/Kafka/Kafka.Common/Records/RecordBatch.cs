using Kafka.Common.Attributes;
using System.Collections;
using System.Collections.Immutable;

namespace Kafka.Common.Records
{
    public sealed record RecordBatch(
        [property: Serialization(SerializationType.Int64, 0)] long BaseOffset,
        [property: Serialization(SerializationType.Int32, 1)] int BatchLength,
        [property: Serialization(SerializationType.Int32, 2)] int PartitionLeaderEpoch,
        [property: Serialization(SerializationType.Int8, 3)] sbyte Magic,
        [property: Serialization(SerializationType.Int32, 4)] int Crc,
        [property: Serialization(SerializationType.Int16, 5)] Attributes Attributes,
        [property: Serialization(SerializationType.Int32, 6)] int LastOffsetDelta,
        [property: Serialization(SerializationType.Int64, 7)] long BaseTimestamp,
        [property: Serialization(SerializationType.Int64, 8)] long MaxTimestamp,
        [property: Serialization(SerializationType.Int64, 9)] long ProducerId,
        [property: Serialization(SerializationType.Int16, 10)] short ProducerEpoch,
        [property: Serialization(SerializationType.Int32, 11)] int BaseSequence,
        [property: SerializationSequence(12)] IImmutableList<IRecord> Records
    ) : IRecords
    {
        public static RecordBatch Empty { get; } = new(
            long.MinValue,
            int.MinValue,
            int.MinValue,
            sbyte.MinValue,
            0,
            Attributes.None,
            int.MinValue,
            long.MinValue,
            long.MinValue,
            long.MinValue,
            short.MinValue,
            int.MinValue,
            ImmutableArray<IRecord>.Empty
        );
        long IRecords.Offset => BaseOffset;

        int IRecords.Size => BatchLength;

        int IRecords.PartitionLeaderEpoch => PartitionLeaderEpoch;

        int IRecords.Crc => Crc;

        Attributes IRecords.Attributes => Attributes;

        int IRecords.LastOffsetDelta => LastOffsetDelta;

        long IRecords.BaseTimestamp => BaseTimestamp;

        long IRecords.MaxTimestamp => MaxTimestamp;

        long IRecords.ProducerId => ProducerId;

        short IRecords.ProducerEpoch => ProducerEpoch;

        int IRecords.BaseSequence => BaseSequence;

        CompressionType IRecords.CompressionType => (CompressionType)(Attributes & Attributes.CompressionType);

        TimestampType IRecords.TimestampType => (TimestampType)(Attributes & Attributes.TimestampType);

        bool IRecords.IsTransactional => (Attributes & Attributes.IsTransactional) == Attributes.IsTransactional;

        bool IRecords.IsControlBatch => (Attributes & Attributes.IsControlBatch) == Attributes.IsControlBatch;

        bool IRecords.HasDeleteHorizonMs => (Attributes & Attributes.HasDeleteHorizonMs) == Attributes.HasDeleteHorizonMs;

        ControlRecord IRecords.ControlRecord => (ControlRecord)Records[0];

        IRecord IReadOnlyList<IRecord>.this[int index] => Records[index];

        int IReadOnlyCollection<IRecord>.Count => Records.Count;

        IEnumerator<IRecord> IEnumerable<IRecord>.GetEnumerator() => Records.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Records.GetEnumerator();

        void IRecords.EnsureValid()
        {
            throw new NotImplementedException();
        }
    }
}
