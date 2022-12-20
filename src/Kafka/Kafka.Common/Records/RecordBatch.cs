using System.Collections;
using System.Collections.Immutable;

namespace Kafka.Common.Records
{
    public sealed record RecordBatch(
        long BaseOffset,
        int BatchLength,
        int PartitionLeaderEpoch,
        sbyte Magic,
        int Crc,
        Attributes Attributes,
        int LastOffsetDelta,
        long BaseTimestamp,
        long MaxTimestamp,
        long ProducerId,
        short ProducerEpoch,
        int BaseSequence,
        ImmutableArray<IRecord> Records
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

        int IReadOnlyCollection<IRecord>.Count => Records.Length;

        IEnumerator<IRecord> IEnumerable<IRecord>.GetEnumerator()
        {
            foreach (var record in Records)
                yield return record;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var record in Records)
                yield return record;
        }

        void IRecords.EnsureValid()
        {
            throw new NotImplementedException();
        }
    }
}
