namespace Kafka.Common.Encoding
{
    public static class RecordsConstants
    {
        public const int RecordsBatchOffsetIx = 0;
        public const int RecordsBatchLengthIx = 8;
        public const int RecordsPartitionLeaderEpochIx = 12;
        public const int RecordsMagicByteIx = 16;
        public const int RecordsCrcIx = 17;
        public const int RecordsAttributesIx = 21;
        public const int RecordsLastOffsetDeltaIx = 23;
        public const int RecordsBaseTimestampIx = 27;
        public const int RecordsMaxTimestampIx = 35;
        public const int RecordsProducerIdIx = 43;
        public const int RecordsProducerEpochIx = 51;
        public const int RecordsBaseSequenceIx = 53;
        public const int RecordsCountIx = 57;

        public const sbyte RecordsMagicByte = 2;
        public const int RecordsMaxBatchSize = int.MaxValue - RecordsHeaderSize;

        public const int RecordsHeaderSize = 61;
        public const int RecordsLogOverhead = 12;
        public const int RecordsSizePadding = RecordsHeaderSize - RecordsLogOverhead;
    }
}
