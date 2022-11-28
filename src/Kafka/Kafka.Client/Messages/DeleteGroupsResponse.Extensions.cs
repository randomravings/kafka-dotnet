using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using DeletableGroupResult = Kafka.Client.Messages.DeleteGroupsResponse.DeletableGroupResult;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DeleteGroupsResponseSerde
    {
        private static readonly DecodeDelegate<DeleteGroupsResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
        };
        private static readonly EncodeDelegate<DeleteGroupsResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
        };
        public static DeleteGroupsResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, DeleteGroupsResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static DeleteGroupsResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var resultsField = Decoder.ReadArray<DeletableGroupResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => DeletableGroupResultSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, DeleteGroupsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<DeletableGroupResult>(buffer, message.ResultsField, (b, i) => DeletableGroupResultSerde.WriteV00(b, i));
            return buffer;
        }
        private static DeleteGroupsResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var resultsField = Decoder.ReadArray<DeletableGroupResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => DeletableGroupResultSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, DeleteGroupsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<DeletableGroupResult>(buffer, message.ResultsField, (b, i) => DeletableGroupResultSerde.WriteV01(b, i));
            return buffer;
        }
        private static DeleteGroupsResponse ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var resultsField = Decoder.ReadCompactArray<DeletableGroupResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => DeletableGroupResultSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, DeleteGroupsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteCompactArray<DeletableGroupResult>(buffer, message.ResultsField, (b, i) => DeletableGroupResultSerde.WriteV02(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class DeletableGroupResultSerde
        {
            public static DeletableGroupResult ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var groupIdField = Decoder.ReadString(ref buffer);
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                return new(
                    groupIdField,
                    errorCodeField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, DeletableGroupResult message)
            {
                buffer = Encoder.WriteString(buffer, message.GroupIdField);
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                return buffer;
            }
            public static DeletableGroupResult ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var groupIdField = Decoder.ReadString(ref buffer);
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                return new(
                    groupIdField,
                    errorCodeField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, DeletableGroupResult message)
            {
                buffer = Encoder.WriteString(buffer, message.GroupIdField);
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                return buffer;
            }
            public static DeletableGroupResult ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var groupIdField = Decoder.ReadCompactString(ref buffer);
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    groupIdField,
                    errorCodeField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, DeletableGroupResult message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.GroupIdField);
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
    }
}