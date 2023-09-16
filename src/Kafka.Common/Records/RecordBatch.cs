using Kafka.Common.Model;
using System.Collections;

namespace Kafka.Common.Records
{
    /// <summary>
    /// baseOffset: int64
    /// batchLength: int32
    /// partitionLeaderEpoch: int32
    /// magic: int8(current magic value is 2)
    /// crc: int32
    /// attributes: int16
    ///     bit 0~2:
    ///         0: no compression
    ///         1: gzip
    ///         2: snappy
    ///         3: lz4
    ///         4: zstd
    ///     bit 3: timestampType
    ///     bit 4: isTransactional(0 means not transactional)
    ///     bit 5: isControlBatch(0 means not a control batch)
    ///     bit 6: hasDeleteHorizonMs(0 means baseTimestamp is not set as the delete horizon for compaction)
    ///     bit 7~15: unused
    /// lastOffsetDelta: int32
    /// baseTimestamp: int64
    /// maxTimestamp: int64
    /// producerId: int64
    /// producerEpoch: int16
    /// baseSequence: int32
    /// records: [Record]
    /// </summary>
    public record RecordBatch(
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
        IReadOnlyList<IRecord> Records
    ) : IRecords
    {
        IRecord IReadOnlyList<IRecord>.this[int index] => Records[index];
        int IReadOnlyCollection<IRecord>.Count => Records.Count;
        IEnumerator<IRecord> IEnumerable<IRecord>.GetEnumerator() =>
            Records.GetEnumerator()
        ;
        IEnumerator IEnumerable.GetEnumerator() =>
            Records.GetEnumerator()
        ;
    }
}
