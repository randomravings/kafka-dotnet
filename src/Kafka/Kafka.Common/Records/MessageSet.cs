using System.Collections;
using System.Collections.Immutable;

namespace Kafka.Common.Records
{
    public sealed record MessageSet(
        IImmutableList<IRecord> Records
    ) : IRecords
    {
        long IRecords.Offset => Records.Any() ? Records[0].Offset : -1;

        int IRecords.Size => Records.Sum(r => r.SizeInBytes);

        int IRecords.PartitionLeaderEpoch => 0;

        sbyte IRecords.Magic => -1;

        int IRecords.Crc => -1;

        Attributes IRecords.Attributes => Attributes.None;

        int IRecords.LastOffsetDelta => 0;

        long IRecords.BaseTimestamp => 0;

        long IRecords.MaxTimestamp => 0;

        long IRecords.ProducerId => 0;

        short IRecords.ProducerEpoch => 0;

        int IRecords.BaseSequence => 0;

        CompressionType IRecords.CompressionType => CompressionType.None;

        TimestampType IRecords.TimestampType => TimestampType.None;

        bool IRecords.IsTransactional => false;

        bool IRecords.IsControlBatch => false;

        bool IRecords.HasDeleteHorizonMs => false;

        ControlRecord IRecords.ControlRecord => ControlRecord.Empty;

        IRecord IReadOnlyList<IRecord>.this[int index] => Records[index];

        int IReadOnlyCollection<IRecord>.Count => Records.Count;

        IEnumerator<IRecord> IEnumerable<IRecord>.GetEnumerator() => Records.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Records.GetEnumerator();

        void IRecords.EnsureValid()
        {
            foreach(var record in Records)
                record.EnsureValid();
        }
    }
}
