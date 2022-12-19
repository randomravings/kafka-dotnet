using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class SnapshotHeaderRecordSerde
    {
        private static readonly DecodeDelegate<SnapshotHeaderRecord>[] READ_VERSIONS = {
            ReadV00,
        };
        private static readonly EncodeDelegate<SnapshotHeaderRecord>[] WRITE_VERSIONS = {
            WriteV00,
        };
        public static SnapshotHeaderRecord Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, SnapshotHeaderRecord message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static SnapshotHeaderRecord ReadV00(byte[] buffer, ref int index)
        {
            var versionField = Decoder.ReadInt16(buffer, ref index);
            var lastContainedLogTimestampField = Decoder.ReadInt64(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                versionField,
                lastContainedLogTimestampField
            );
        }
        private static int WriteV00(byte[] buffer, int index, SnapshotHeaderRecord message)
        {
            index = Encoder.WriteInt16(buffer, index, message.VersionField);
            index = Encoder.WriteInt64(buffer, index, message.LastContainedLogTimestampField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
    }
}