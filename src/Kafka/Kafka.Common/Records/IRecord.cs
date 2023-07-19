using Kafka.Common.Model;

namespace Kafka.Common.Records
{
    /// <summary>
    /// length: varint
    /// attributes: int8
    ///     bit 0~7: unused
    /// timestampDelta: varlong
    /// offsetDelta: varint
    /// keyLength: varint
    /// key: byte[]
    /// valueLen: varint
    /// value: byte[]
    /// Headers => [Header]
    /// </summary>
    public interface IRecord
    {        
        /// <summary>
        /// Get the size in bytes of this record.
        /// </summary>
        int Length { get; }

        /// <summary>
        /// For records prior to version 2, it will contain the attributes.
        /// For records version 2, it will return <see cref="Attributes.None"/>.
        /// </summary>
        public Attributes Attributes { get; }

        /// <summary>
        /// 
        /// </summary>
        long TimestampDelta { get; }

        /// <summary>
        /// 
        /// </summary>
        int OffsetDelta { get; }

        /// <summary>
        /// Get the record's key, null if there is none.
        /// </summary>
        ReadOnlyMemory<byte>? Key { get; }

        /// <summary>
        /// Get the record's value, null if there is none.
        /// </summary>
        ReadOnlyMemory<byte>? Value { get; }

        /// <summary>
        /// Get the headers.
        /// <para>For magic versions prior to 2, this always returns an empty array.</para>
        /// </summary>
        IReadOnlyList<RecordHeader> Headers { get; }
    }
}
