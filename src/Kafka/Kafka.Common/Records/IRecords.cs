using Kafka.Common.Model;

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
    public interface IRecords :
        IReadOnlyList<IRecord>
    {
        long BaseOffset { get; }

        int BatchLength { get; }

        int PartitionLeaderEpoch { get; }

        sbyte Magic { get; }

        int Crc { get; }

        Attributes Attributes { get; }

        int LastOffsetDelta { get; }

        long BaseTimestamp { get; }

        long MaxTimestamp { get; }

        long ProducerId { get; }

        short ProducerEpoch { get; }

        int BaseSequence { get; }
    }
}
