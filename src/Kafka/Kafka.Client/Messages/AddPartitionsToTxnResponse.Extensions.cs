using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using AddPartitionsToTxnPartitionResult = Kafka.Client.Messages.AddPartitionsToTxnResponse.AddPartitionsToTxnTopicResult.AddPartitionsToTxnPartitionResult;
using AddPartitionsToTxnTopicResult = Kafka.Client.Messages.AddPartitionsToTxnResponse.AddPartitionsToTxnTopicResult;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AddPartitionsToTxnResponseSerde
    {
        private static readonly DecodeDelegate<AddPartitionsToTxnResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
        };
        private static readonly EncodeDelegate<AddPartitionsToTxnResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
        };
        public static AddPartitionsToTxnResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, AddPartitionsToTxnResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static AddPartitionsToTxnResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var resultsField = Decoder.ReadArray<AddPartitionsToTxnTopicResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => AddPartitionsToTxnTopicResultSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, AddPartitionsToTxnResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<AddPartitionsToTxnTopicResult>(buffer, message.ResultsField, (b, i) => AddPartitionsToTxnTopicResultSerde.WriteV00(b, i));
            return buffer;
        }
        private static AddPartitionsToTxnResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var resultsField = Decoder.ReadArray<AddPartitionsToTxnTopicResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => AddPartitionsToTxnTopicResultSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, AddPartitionsToTxnResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<AddPartitionsToTxnTopicResult>(buffer, message.ResultsField, (b, i) => AddPartitionsToTxnTopicResultSerde.WriteV01(b, i));
            return buffer;
        }
        private static AddPartitionsToTxnResponse ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var resultsField = Decoder.ReadArray<AddPartitionsToTxnTopicResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => AddPartitionsToTxnTopicResultSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, AddPartitionsToTxnResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<AddPartitionsToTxnTopicResult>(buffer, message.ResultsField, (b, i) => AddPartitionsToTxnTopicResultSerde.WriteV02(b, i));
            return buffer;
        }
        private static AddPartitionsToTxnResponse ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var resultsField = Decoder.ReadCompactArray<AddPartitionsToTxnTopicResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => AddPartitionsToTxnTopicResultSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, AddPartitionsToTxnResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteCompactArray<AddPartitionsToTxnTopicResult>(buffer, message.ResultsField, (b, i) => AddPartitionsToTxnTopicResultSerde.WriteV03(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class AddPartitionsToTxnTopicResultSerde
        {
            public static AddPartitionsToTxnTopicResult ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var resultsField = Decoder.ReadArray<AddPartitionsToTxnPartitionResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => AddPartitionsToTxnPartitionResultSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
                return new(
                    nameField,
                    resultsField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, AddPartitionsToTxnTopicResult message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<AddPartitionsToTxnPartitionResult>(buffer, message.ResultsField, (b, i) => AddPartitionsToTxnPartitionResultSerde.WriteV00(b, i));
                return buffer;
            }
            public static AddPartitionsToTxnTopicResult ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var resultsField = Decoder.ReadArray<AddPartitionsToTxnPartitionResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => AddPartitionsToTxnPartitionResultSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
                return new(
                    nameField,
                    resultsField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, AddPartitionsToTxnTopicResult message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<AddPartitionsToTxnPartitionResult>(buffer, message.ResultsField, (b, i) => AddPartitionsToTxnPartitionResultSerde.WriteV01(b, i));
                return buffer;
            }
            public static AddPartitionsToTxnTopicResult ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var resultsField = Decoder.ReadArray<AddPartitionsToTxnPartitionResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => AddPartitionsToTxnPartitionResultSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
                return new(
                    nameField,
                    resultsField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, AddPartitionsToTxnTopicResult message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteArray<AddPartitionsToTxnPartitionResult>(buffer, message.ResultsField, (b, i) => AddPartitionsToTxnPartitionResultSerde.WriteV02(b, i));
                return buffer;
            }
            public static AddPartitionsToTxnTopicResult ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactString(ref buffer);
                var resultsField = Decoder.ReadCompactArray<AddPartitionsToTxnPartitionResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => AddPartitionsToTxnPartitionResultSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nameField,
                    resultsField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, AddPartitionsToTxnTopicResult message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteCompactArray<AddPartitionsToTxnPartitionResult>(buffer, message.ResultsField, (b, i) => AddPartitionsToTxnPartitionResultSerde.WriteV03(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class AddPartitionsToTxnPartitionResultSerde
            {
                public static AddPartitionsToTxnPartitionResult ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static Memory<byte> WriteV00(Memory<byte> buffer, AddPartitionsToTxnPartitionResult message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    return buffer;
                }
                public static AddPartitionsToTxnPartitionResult ReadV01(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static Memory<byte> WriteV01(Memory<byte> buffer, AddPartitionsToTxnPartitionResult message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    return buffer;
                }
                public static AddPartitionsToTxnPartitionResult ReadV02(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static Memory<byte> WriteV02(Memory<byte> buffer, AddPartitionsToTxnPartitionResult message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    return buffer;
                }
                public static AddPartitionsToTxnPartitionResult ReadV03(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField
                    );
                }
                public static Memory<byte> WriteV03(Memory<byte> buffer, AddPartitionsToTxnPartitionResult message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
            }
        }
    }
}