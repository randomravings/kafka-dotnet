using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class SnapshotFooterRecordSerde
    {
        private static readonly Func<Stream, SnapshotFooterRecord>[] READ_VERSIONS = {
            b => ReadV00(b),
        };
        private static readonly Action<Stream, SnapshotFooterRecord>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static SnapshotFooterRecord Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, SnapshotFooterRecord message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static SnapshotFooterRecord ReadV00(Stream buffer)
        {
            var versionField = Decoder.ReadInt16(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                versionField
            );
        }
        private static void WriteV00(Stream buffer, SnapshotFooterRecord message)
        {
            Encoder.WriteInt16(buffer, message.VersionField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
    }
}