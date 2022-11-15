using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class SnapshotHeaderRecordSerde
    {
        private static readonly Func<Stream, SnapshotHeaderRecord>[] READ_VERSIONS = {
            b => ReadV00(b),
        };
        private static readonly Action<Stream, SnapshotHeaderRecord>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
        };
        public static SnapshotHeaderRecord Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, SnapshotHeaderRecord message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static SnapshotHeaderRecord ReadV00(Stream buffer)
        {
            var versionField = Decoder.ReadInt16(buffer);
            var lastContainedLogTimestampField = Decoder.ReadInt64(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                versionField,
                lastContainedLogTimestampField
            );
        }
        private static void WriteV00(Stream buffer, SnapshotHeaderRecord message)
        {
            Encoder.WriteInt16(buffer, message.VersionField);
            Encoder.WriteInt64(buffer, message.LastContainedLogTimestampField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
    }
}