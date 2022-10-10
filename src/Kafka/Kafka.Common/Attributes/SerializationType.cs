namespace Kafka.Common.Attributes
{
    public enum SerializationType : int
    {
        Ignore,
        Int8,
        Int16,
        Int32,
        Int64,
        UInt32,
        VarInt32,
        VarInt64,
        Uuid,
        Float64,
        String,
        CompactString,
        NullableString,
        CompactNullableString,
        Bytes,
        CompactBytes,
        NullableBytes,
        CompactNullableBytes,
        Records,
        Array,
        CompactArray
    }
}
