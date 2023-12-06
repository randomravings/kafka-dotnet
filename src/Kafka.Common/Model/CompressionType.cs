﻿namespace Kafka.Common.Model
{
    public enum CompressionType : int
    {
        None = 0,
        Gzip = 1,
        Snappy = 2,
        LZ4 = 3,
        ZSTD = 4
    }
}
