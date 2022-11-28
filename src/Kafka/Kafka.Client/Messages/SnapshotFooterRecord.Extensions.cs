using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class SnapshotFooterRecordSerde
    {
        private static readonly DecodeDelegate<SnapshotFooterRecord>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
        };
        private static readonly EncodeDelegate<SnapshotFooterRecord>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static SnapshotFooterRecord Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, SnapshotFooterRecord message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static SnapshotFooterRecord ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var versionField = Decoder.ReadInt16(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                versionField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, SnapshotFooterRecord message)
        {
            buffer = Encoder.WriteInt16(buffer, message.VersionField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
    }
}