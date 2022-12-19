using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using AddPartitionsToTxnPartitionResult = Kafka.Client.Messages.AddPartitionsToTxnResponse.AddPartitionsToTxnTopicResult.AddPartitionsToTxnPartitionResult;
using AddPartitionsToTxnTopicResult = Kafka.Client.Messages.AddPartitionsToTxnResponse.AddPartitionsToTxnTopicResult;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AddPartitionsToTxnResponseSerde
    {
        private static readonly DecodeDelegate<AddPartitionsToTxnResponse>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
        };
        private static readonly EncodeDelegate<AddPartitionsToTxnResponse>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
        };
        public static AddPartitionsToTxnResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, AddPartitionsToTxnResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static AddPartitionsToTxnResponse ReadV00(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var resultsField = Decoder.ReadArray<AddPartitionsToTxnTopicResult>(buffer, ref index, AddPartitionsToTxnTopicResultSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, AddPartitionsToTxnResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<AddPartitionsToTxnTopicResult>(buffer, index, message.ResultsField, AddPartitionsToTxnTopicResultSerde.WriteV00);
            return index;
        }
        private static AddPartitionsToTxnResponse ReadV01(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var resultsField = Decoder.ReadArray<AddPartitionsToTxnTopicResult>(buffer, ref index, AddPartitionsToTxnTopicResultSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static int WriteV01(byte[] buffer, int index, AddPartitionsToTxnResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<AddPartitionsToTxnTopicResult>(buffer, index, message.ResultsField, AddPartitionsToTxnTopicResultSerde.WriteV01);
            return index;
        }
        private static AddPartitionsToTxnResponse ReadV02(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var resultsField = Decoder.ReadArray<AddPartitionsToTxnTopicResult>(buffer, ref index, AddPartitionsToTxnTopicResultSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static int WriteV02(byte[] buffer, int index, AddPartitionsToTxnResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<AddPartitionsToTxnTopicResult>(buffer, index, message.ResultsField, AddPartitionsToTxnTopicResultSerde.WriteV02);
            return index;
        }
        private static AddPartitionsToTxnResponse ReadV03(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var resultsField = Decoder.ReadCompactArray<AddPartitionsToTxnTopicResult>(buffer, ref index, AddPartitionsToTxnTopicResultSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static int WriteV03(byte[] buffer, int index, AddPartitionsToTxnResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteCompactArray<AddPartitionsToTxnTopicResult>(buffer, index, message.ResultsField, AddPartitionsToTxnTopicResultSerde.WriteV03);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class AddPartitionsToTxnTopicResultSerde
        {
            public static AddPartitionsToTxnTopicResult ReadV00(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var resultsField = Decoder.ReadArray<AddPartitionsToTxnPartitionResult>(buffer, ref index, AddPartitionsToTxnPartitionResultSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Results'");
                return new(
                    nameField,
                    resultsField
                );
            }
            public static int WriteV00(byte[] buffer, int index, AddPartitionsToTxnTopicResult message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<AddPartitionsToTxnPartitionResult>(buffer, index, message.ResultsField, AddPartitionsToTxnPartitionResultSerde.WriteV00);
                return index;
            }
            public static AddPartitionsToTxnTopicResult ReadV01(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var resultsField = Decoder.ReadArray<AddPartitionsToTxnPartitionResult>(buffer, ref index, AddPartitionsToTxnPartitionResultSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Results'");
                return new(
                    nameField,
                    resultsField
                );
            }
            public static int WriteV01(byte[] buffer, int index, AddPartitionsToTxnTopicResult message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<AddPartitionsToTxnPartitionResult>(buffer, index, message.ResultsField, AddPartitionsToTxnPartitionResultSerde.WriteV01);
                return index;
            }
            public static AddPartitionsToTxnTopicResult ReadV02(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadString(buffer, ref index);
                var resultsField = Decoder.ReadArray<AddPartitionsToTxnPartitionResult>(buffer, ref index, AddPartitionsToTxnPartitionResultSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Results'");
                return new(
                    nameField,
                    resultsField
                );
            }
            public static int WriteV02(byte[] buffer, int index, AddPartitionsToTxnTopicResult message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteArray<AddPartitionsToTxnPartitionResult>(buffer, index, message.ResultsField, AddPartitionsToTxnPartitionResultSerde.WriteV02);
                return index;
            }
            public static AddPartitionsToTxnTopicResult ReadV03(byte[] buffer, ref int index)
            {
                var nameField = Decoder.ReadCompactString(buffer, ref index);
                var resultsField = Decoder.ReadCompactArray<AddPartitionsToTxnPartitionResult>(buffer, ref index, AddPartitionsToTxnPartitionResultSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Results'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    nameField,
                    resultsField
                );
            }
            public static int WriteV03(byte[] buffer, int index, AddPartitionsToTxnTopicResult message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteCompactArray<AddPartitionsToTxnPartitionResult>(buffer, index, message.ResultsField, AddPartitionsToTxnPartitionResultSerde.WriteV03);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class AddPartitionsToTxnPartitionResultSerde
            {
                public static AddPartitionsToTxnPartitionResult ReadV00(byte[] buffer, ref int index)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static int WriteV00(byte[] buffer, int index, AddPartitionsToTxnPartitionResult message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    return index;
                }
                public static AddPartitionsToTxnPartitionResult ReadV01(byte[] buffer, ref int index)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static int WriteV01(byte[] buffer, int index, AddPartitionsToTxnPartitionResult message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    return index;
                }
                public static AddPartitionsToTxnPartitionResult ReadV02(byte[] buffer, ref int index)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static int WriteV02(byte[] buffer, int index, AddPartitionsToTxnPartitionResult message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    return index;
                }
                public static AddPartitionsToTxnPartitionResult ReadV03(byte[] buffer, ref int index)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static int WriteV03(byte[] buffer, int index, AddPartitionsToTxnPartitionResult message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
            }
        }
    }
}