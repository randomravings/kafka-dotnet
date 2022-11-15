using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using DeletableGroupResult = Kafka.Client.Messages.DeleteGroupsResponse.DeletableGroupResult;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DeleteGroupsResponseSerde
    {
        private static readonly Func<Stream, DeleteGroupsResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
        };
        private static readonly Action<Stream, DeleteGroupsResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
        };
        public static DeleteGroupsResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, DeleteGroupsResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static DeleteGroupsResponse ReadV00(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var resultsField = Decoder.ReadArray<DeletableGroupResult>(buffer, b => DeletableGroupResultSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static void WriteV00(Stream buffer, DeleteGroupsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<DeletableGroupResult>(buffer, message.ResultsField, (b, i) => DeletableGroupResultSerde.WriteV00(b, i));
        }
        private static DeleteGroupsResponse ReadV01(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var resultsField = Decoder.ReadArray<DeletableGroupResult>(buffer, b => DeletableGroupResultSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static void WriteV01(Stream buffer, DeleteGroupsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<DeletableGroupResult>(buffer, message.ResultsField, (b, i) => DeletableGroupResultSerde.WriteV01(b, i));
        }
        private static DeleteGroupsResponse ReadV02(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var resultsField = Decoder.ReadCompactArray<DeletableGroupResult>(buffer, b => DeletableGroupResultSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static void WriteV02(Stream buffer, DeleteGroupsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteCompactArray<DeletableGroupResult>(buffer, message.ResultsField, (b, i) => DeletableGroupResultSerde.WriteV02(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class DeletableGroupResultSerde
        {
            public static DeletableGroupResult ReadV00(Stream buffer)
            {
                var groupIdField = Decoder.ReadString(buffer);
                var errorCodeField = Decoder.ReadInt16(buffer);
                return new(
                    groupIdField,
                    errorCodeField
                );
            }
            public static void WriteV00(Stream buffer, DeletableGroupResult message)
            {
                Encoder.WriteString(buffer, message.GroupIdField);
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
            }
            public static DeletableGroupResult ReadV01(Stream buffer)
            {
                var groupIdField = Decoder.ReadString(buffer);
                var errorCodeField = Decoder.ReadInt16(buffer);
                return new(
                    groupIdField,
                    errorCodeField
                );
            }
            public static void WriteV01(Stream buffer, DeletableGroupResult message)
            {
                Encoder.WriteString(buffer, message.GroupIdField);
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
            }
            public static DeletableGroupResult ReadV02(Stream buffer)
            {
                var groupIdField = Decoder.ReadCompactString(buffer);
                var errorCodeField = Decoder.ReadInt16(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    groupIdField,
                    errorCodeField
                );
            }
            public static void WriteV02(Stream buffer, DeletableGroupResult message)
            {
                Encoder.WriteCompactString(buffer, message.GroupIdField);
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
    }
}