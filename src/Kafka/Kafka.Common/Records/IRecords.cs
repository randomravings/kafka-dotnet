namespace Kafka.Common.Records
{
    public interface IRecords :
        IReadOnlyList<IRecord>
    {
        long Offset { get; }

        int Size { get; }

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

        CompressionType CompressionType { get; }

        TimestampType TimestampType { get; }

        bool IsTransactional { get; }

        bool IsControlBatch { get; }

        bool HasDeleteHorizonMs { get; }

        ControlRecord ControlRecord { get; }

        void EnsureValid();
    }
}
