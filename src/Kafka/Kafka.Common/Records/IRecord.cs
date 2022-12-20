using System.Collections.Immutable;

namespace Kafka.Common.Records
{
    public interface IRecord
    {        
        /// <summary>
        /// Get the sequence number assigned by the producer.
        /// </summary>
        int Sequence { get; }
        /// <summary>
        /// The offset of this record in the log.
        /// </summary>
        long Offset { get; }

        /// <summary>
        /// Get the size in bytes of this record.
        /// </summary>
        int SizeInBytes { get; }

        /// <summary>
        /// For records prior to version 2, it will contain the magic byte.
        /// For records version 2, it will return -1.
        /// </summary>
        sbyte Magic { get; }

        /// <summary>
        /// For records prior to version 2, it will contain the Crc.
        /// For records version 2, it will return 0.
        /// </summary>
        int Crc { get; }

        /// <summary>
        /// For records prior to version 2, it will contain the attributes.
        /// For records version 2, it will return <see cref="Attributes.None"/>.
        /// </summary>
        public Attributes Attributes { get; }

        /// <summary>
        /// Get the record's timestamp.
        /// </summary>
        long Timestamp { get; }

        /// <summary>
        /// Get the record's key, null if there is none.
        /// </summary>
        ReadOnlyMemory<byte>? Key { get; }

        /// <summary>
        /// Get the record's value, null if there is none.
        /// </summary>
        ReadOnlyMemory<byte>? Value { get; }

        /// <summary>
        /// 
        /// </summary>
        long TimestampDelta { get; }

        /// <summary>
        /// 
        /// </summary>
        int OffsetDelta { get; }

        /// <summary>
        /// Gets the timestamp type used for this record, only applies to version 1.
        /// <para>For magic versions other than 1, this always returns <see cref="TimestampType.None"/>.</para>
        /// </summary>
        TimestampType TimestampType { get; }

        /// <summary>
        /// Gets the compression type that is applied.
        /// Version 0 Set: { GZIP, Snappy }
        /// Version 1 Set: { GZIP, Snappy, LZ4 }
        /// Version 2 Set: { None } (compression is done on the batch level).
        /// </summary>
        CompressionType CompressionType { get; }

        /// <summary>
        /// Get the headers.
        /// <para>For magic versions prior to 2, this always returns an empty array.</para>
        /// </summary>
        ImmutableArray<RecordHeader> Headers { get; }

        /// <summary>
        /// Performs a CRC check on the record data.
        /// </summary>
        /// <exception cref="Exceptions.CorruptRecordException">If the record does not have a valid checksum.</exception>
        void EnsureValid();
    }
}
