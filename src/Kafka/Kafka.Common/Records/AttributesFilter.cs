namespace Kafka.Common.Records
{
    public static class AttributesFilter
    {
        private static readonly Attributes V0_MASK = 
            Attributes.Gzip |
            Attributes.Snappy
        ;
        private static readonly Attributes V1_MASK =
            V0_MASK |
            Attributes.LZ4 |
            Attributes.TimestampType
        ;
        private static readonly Attributes V2_MASK =
            V1_MASK |
            Attributes.IsTransactional |
            Attributes.IsControlBatch |
            Attributes.HasDeleteHorizonMs
        ;
        public static Attributes TrimV0(Attributes attributes) =>
            attributes & V0_MASK
        ;
        public static Attributes TrimV1(Attributes attributes) =>
            attributes & V1_MASK
        ;
        public static Attributes TrimV2(Attributes attributes) =>
            attributes & V2_MASK
        ;
    }
}
