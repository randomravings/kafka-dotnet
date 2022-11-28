using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class SnapshotHeaderRecordSerde
    {
        private static readonly DecodeDelegate<SnapshotHeaderRecord>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
        };
        private static readonly EncodeDelegate<SnapshotHeaderRecord>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static SnapshotHeaderRecord Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, SnapshotHeaderRecord message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static SnapshotHeaderRecord ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var versionField = Decoder.ReadInt16(ref buffer);
            var lastContainedLogTimestampField = Decoder.ReadInt64(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                versionField,
                lastContainedLogTimestampField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, SnapshotHeaderRecord message)
        {
            buffer = Encoder.WriteInt16(buffer, message.VersionField);
            buffer = Encoder.WriteInt64(buffer, message.LastContainedLogTimestampField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
    }
}