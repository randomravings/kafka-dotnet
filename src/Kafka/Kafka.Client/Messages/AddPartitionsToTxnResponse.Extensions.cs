using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using AddPartitionsToTxnTopicResult = Kafka.Client.Messages.AddPartitionsToTxnResponse.AddPartitionsToTxnTopicResult;
using AddPartitionsToTxnPartitionResult = Kafka.Client.Messages.AddPartitionsToTxnResponse.AddPartitionsToTxnTopicResult.AddPartitionsToTxnPartitionResult;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AddPartitionsToTxnResponseSerde
    {
        private static readonly Func<Stream, AddPartitionsToTxnResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
        };
        private static readonly Action<Stream, AddPartitionsToTxnResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
        };
        public static AddPartitionsToTxnResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, AddPartitionsToTxnResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static AddPartitionsToTxnResponse ReadV00(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var resultsField = Decoder.ReadArray<AddPartitionsToTxnTopicResult>(buffer, b => AddPartitionsToTxnTopicResultSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static void WriteV00(Stream buffer, AddPartitionsToTxnResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<AddPartitionsToTxnTopicResult>(buffer, message.ResultsField, (b, i) => AddPartitionsToTxnTopicResultSerde.WriteV00(b, i));
        }
        private static AddPartitionsToTxnResponse ReadV01(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var resultsField = Decoder.ReadArray<AddPartitionsToTxnTopicResult>(buffer, b => AddPartitionsToTxnTopicResultSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static void WriteV01(Stream buffer, AddPartitionsToTxnResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<AddPartitionsToTxnTopicResult>(buffer, message.ResultsField, (b, i) => AddPartitionsToTxnTopicResultSerde.WriteV01(b, i));
        }
        private static AddPartitionsToTxnResponse ReadV02(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var resultsField = Decoder.ReadArray<AddPartitionsToTxnTopicResult>(buffer, b => AddPartitionsToTxnTopicResultSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static void WriteV02(Stream buffer, AddPartitionsToTxnResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<AddPartitionsToTxnTopicResult>(buffer, message.ResultsField, (b, i) => AddPartitionsToTxnTopicResultSerde.WriteV02(b, i));
        }
        private static AddPartitionsToTxnResponse ReadV03(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var resultsField = Decoder.ReadCompactArray<AddPartitionsToTxnTopicResult>(buffer, b => AddPartitionsToTxnTopicResultSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static void WriteV03(Stream buffer, AddPartitionsToTxnResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteCompactArray<AddPartitionsToTxnTopicResult>(buffer, message.ResultsField, (b, i) => AddPartitionsToTxnTopicResultSerde.WriteV03(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class AddPartitionsToTxnTopicResultSerde
        {
            public static AddPartitionsToTxnTopicResult ReadV00(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var resultsField = Decoder.ReadArray<AddPartitionsToTxnPartitionResult>(buffer, b => AddPartitionsToTxnPartitionResultSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
                return new(
                    nameField,
                    resultsField
                );
            }
            public static void WriteV00(Stream buffer, AddPartitionsToTxnTopicResult message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<AddPartitionsToTxnPartitionResult>(buffer, message.ResultsField, (b, i) => AddPartitionsToTxnPartitionResultSerde.WriteV00(b, i));
            }
            public static AddPartitionsToTxnTopicResult ReadV01(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var resultsField = Decoder.ReadArray<AddPartitionsToTxnPartitionResult>(buffer, b => AddPartitionsToTxnPartitionResultSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
                return new(
                    nameField,
                    resultsField
                );
            }
            public static void WriteV01(Stream buffer, AddPartitionsToTxnTopicResult message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<AddPartitionsToTxnPartitionResult>(buffer, message.ResultsField, (b, i) => AddPartitionsToTxnPartitionResultSerde.WriteV01(b, i));
            }
            public static AddPartitionsToTxnTopicResult ReadV02(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var resultsField = Decoder.ReadArray<AddPartitionsToTxnPartitionResult>(buffer, b => AddPartitionsToTxnPartitionResultSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
                return new(
                    nameField,
                    resultsField
                );
            }
            public static void WriteV02(Stream buffer, AddPartitionsToTxnTopicResult message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteArray<AddPartitionsToTxnPartitionResult>(buffer, message.ResultsField, (b, i) => AddPartitionsToTxnPartitionResultSerde.WriteV02(b, i));
            }
            public static AddPartitionsToTxnTopicResult ReadV03(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var resultsField = Decoder.ReadCompactArray<AddPartitionsToTxnPartitionResult>(buffer, b => AddPartitionsToTxnPartitionResultSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    resultsField
                );
            }
            public static void WriteV03(Stream buffer, AddPartitionsToTxnTopicResult message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteCompactArray<AddPartitionsToTxnPartitionResult>(buffer, message.ResultsField, (b, i) => AddPartitionsToTxnPartitionResultSerde.WriteV03(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class AddPartitionsToTxnPartitionResultSerde
            {
                public static AddPartitionsToTxnPartitionResult ReadV00(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static void WriteV00(Stream buffer, AddPartitionsToTxnPartitionResult message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                }
                public static AddPartitionsToTxnPartitionResult ReadV01(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static void WriteV01(Stream buffer, AddPartitionsToTxnPartitionResult message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                }
                public static AddPartitionsToTxnPartitionResult ReadV02(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static void WriteV02(Stream buffer, AddPartitionsToTxnPartitionResult message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                }
                public static AddPartitionsToTxnPartitionResult ReadV03(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static void WriteV03(Stream buffer, AddPartitionsToTxnPartitionResult message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
            }
        }
    }
}