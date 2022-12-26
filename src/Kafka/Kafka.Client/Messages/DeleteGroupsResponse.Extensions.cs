using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using DeletableGroupResult = Kafka.Client.Messages.DeleteGroupsResponse.DeletableGroupResult;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DeleteGroupsResponseSerde
    {
        private static readonly DecodeDelegate<DeleteGroupsResponse>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
        };
        private static readonly EncodeDelegate<DeleteGroupsResponse>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
        };
        public static DeleteGroupsResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, DeleteGroupsResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static DeleteGroupsResponse ReadV00(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var resultsField = Decoder.ReadArray<DeletableGroupResult>(buffer, ref index, DeletableGroupResultSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, DeleteGroupsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<DeletableGroupResult>(buffer, index, message.ResultsField, DeletableGroupResultSerde.WriteV00);
            return index;
        }
        private static DeleteGroupsResponse ReadV01(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var resultsField = Decoder.ReadArray<DeletableGroupResult>(buffer, ref index, DeletableGroupResultSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static int WriteV01(byte[] buffer, int index, DeleteGroupsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<DeletableGroupResult>(buffer, index, message.ResultsField, DeletableGroupResultSerde.WriteV01);
            return index;
        }
        private static DeleteGroupsResponse ReadV02(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var resultsField = Decoder.ReadCompactArray<DeletableGroupResult>(buffer, ref index, DeletableGroupResultSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static int WriteV02(byte[] buffer, int index, DeleteGroupsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteCompactArray<DeletableGroupResult>(buffer, index, message.ResultsField, DeletableGroupResultSerde.WriteV02);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class DeletableGroupResultSerde
        {
            public static DeletableGroupResult ReadV00(byte[] buffer, ref int index)
            {
                var GroupIdField = Decoder.ReadString(buffer, ref index);
                var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                return new(
                    GroupIdField,
                    ErrorCodeField
                );
            }
            public static int WriteV00(byte[] buffer, int index, DeletableGroupResult message)
            {
                index = Encoder.WriteString(buffer, index, message.GroupIdField);
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                return index;
            }
            public static DeletableGroupResult ReadV01(byte[] buffer, ref int index)
            {
                var GroupIdField = Decoder.ReadString(buffer, ref index);
                var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                return new(
                    GroupIdField,
                    ErrorCodeField
                );
            }
            public static int WriteV01(byte[] buffer, int index, DeletableGroupResult message)
            {
                index = Encoder.WriteString(buffer, index, message.GroupIdField);
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                return index;
            }
            public static DeletableGroupResult ReadV02(byte[] buffer, ref int index)
            {
                var GroupIdField = Decoder.ReadCompactString(buffer, ref index);
                var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    GroupIdField,
                    ErrorCodeField
                );
            }
            public static int WriteV02(byte[] buffer, int index, DeletableGroupResult message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.GroupIdField);
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
        }
    }
}