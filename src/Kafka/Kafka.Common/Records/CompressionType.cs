namespace Kafka.Common.Records
{
    public enum CompressionType : short
    {
        None = 0,
        Gzip = 1,
        Snappy = 2,
        LZ4 = 3,
        ZSTD = 4
    }
}
