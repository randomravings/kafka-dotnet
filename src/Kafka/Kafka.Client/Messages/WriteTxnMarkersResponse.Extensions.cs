using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using WritableTxnMarkerResult = Kafka.Client.Messages.WriteTxnMarkersResponse.WritableTxnMarkerResult;
using WritableTxnMarkerPartitionResult = Kafka.Client.Messages.WriteTxnMarkersResponse.WritableTxnMarkerResult.WritableTxnMarkerTopicResult.WritableTxnMarkerPartitionResult;
using WritableTxnMarkerTopicResult = Kafka.Client.Messages.WriteTxnMarkersResponse.WritableTxnMarkerResult.WritableTxnMarkerTopicResult;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class WriteTxnMarkersResponseSerde
    {
        private static readonly DecodeDelegate<WriteTxnMarkersResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
        };
        private static readonly EncodeDelegate<WriteTxnMarkersResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
        };
        public static WriteTxnMarkersResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, WriteTxnMarkersResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static WriteTxnMarkersResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var markersField = Decoder.ReadArray<WritableTxnMarkerResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => WritableTxnMarkerResultSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Markers'");
            return new(
                markersField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, WriteTxnMarkersResponse message)
        {
            buffer = Encoder.WriteArray<WritableTxnMarkerResult>(buffer, message.MarkersField, (b, i) => WritableTxnMarkerResultSerde.WriteV00(b, i));
            return buffer;
        }
        private static WriteTxnMarkersResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var markersField = Decoder.ReadCompactArray<WritableTxnMarkerResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => WritableTxnMarkerResultSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Markers'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                markersField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, WriteTxnMarkersResponse message)
        {
            buffer = Encoder.WriteCompactArray<WritableTxnMarkerResult>(buffer, message.MarkersField, (b, i) => WritableTxnMarkerResultSerde.WriteV01(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class WritableTxnMarkerResultSerde
        {
            public static WritableTxnMarkerResult ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var producerIdField = Decoder.ReadInt64(ref buffer);
                var topicsField = Decoder.ReadArray<WritableTxnMarkerTopicResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => WritableTxnMarkerTopicResultSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
                return new(
                    producerIdField,
                    topicsField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, WritableTxnMarkerResult message)
            {
                buffer = Encoder.WriteInt64(buffer, message.ProducerIdField);
                buffer = Encoder.WriteArray<WritableTxnMarkerTopicResult>(buffer, message.TopicsField, (b, i) => WritableTxnMarkerTopicResultSerde.WriteV00(b, i));
                return buffer;
            }
            public static WritableTxnMarkerResult ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var producerIdField = Decoder.ReadInt64(ref buffer);
                var topicsField = Decoder.ReadCompactArray<WritableTxnMarkerTopicResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => WritableTxnMarkerTopicResultSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    producerIdField,
                    topicsField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, WritableTxnMarkerResult message)
            {
                buffer = Encoder.WriteInt64(buffer, message.ProducerIdField);
                buffer = Encoder.WriteCompactArray<WritableTxnMarkerTopicResult>(buffer, message.TopicsField, (b, i) => WritableTxnMarkerTopicResultSerde.WriteV01(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class WritableTxnMarkerTopicResultSerde
            {
                public static WritableTxnMarkerTopicResult ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var nameField = Decoder.ReadString(ref buffer);
                    var partitionsField = Decoder.ReadArray<WritableTxnMarkerPartitionResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => WritableTxnMarkerPartitionResultSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                    return new(
                        nameField,
                        partitionsField
                    );
                }
                public static Memory<byte> WriteV00(Memory<byte> buffer, WritableTxnMarkerTopicResult message)
                {
                    buffer = Encoder.WriteString(buffer, message.NameField);
                    buffer = Encoder.WriteArray<WritableTxnMarkerPartitionResult>(buffer, message.PartitionsField, (b, i) => WritableTxnMarkerPartitionResultSerde.WriteV00(b, i));
                    return buffer;
                }
                public static WritableTxnMarkerTopicResult ReadV01(ref ReadOnlyMemory<byte> buffer)
                {
                    var nameField = Decoder.ReadCompactString(ref buffer);
                    var partitionsField = Decoder.ReadCompactArray<WritableTxnMarkerPartitionResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => WritableTxnMarkerPartitionResultSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        nameField,
                        partitionsField
                    );
                }
                public static Memory<byte> WriteV01(Memory<byte> buffer, WritableTxnMarkerTopicResult message)
                {
                    buffer = Encoder.WriteCompactString(buffer, message.NameField);
                    buffer = Encoder.WriteCompactArray<WritableTxnMarkerPartitionResult>(buffer, message.PartitionsField, (b, i) => WritableTxnMarkerPartitionResultSerde.WriteV01(b, i));
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
                private static class WritableTxnMarkerPartitionResultSerde
                {
                    public static WritableTxnMarkerPartitionResult ReadV00(ref ReadOnlyMemory<byte> buffer)
                    {
                        var partitionIndexField = Decoder.ReadInt32(ref buffer);
                        var errorCodeField = Decoder.ReadInt16(ref buffer);
                        return new(
                            partitionIndexField,
                            errorCodeField
                        );
                    }
                    public static Memory<byte> WriteV00(Memory<byte> buffer, WritableTxnMarkerPartitionResult message)
                    {
                        buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                        buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                        return buffer;
                    }
                    public static WritableTxnMarkerPartitionResult ReadV01(ref ReadOnlyMemory<byte> buffer)
                    {
                        var partitionIndexField = Decoder.ReadInt32(ref buffer);
                        var errorCodeField = Decoder.ReadInt16(ref buffer);
                        _ = Decoder.ReadVarUInt32(ref buffer);
                        return new(
                            partitionIndexField,
                            errorCodeField
                        );
                    }
                    public static Memory<byte> WriteV01(Memory<byte> buffer, WritableTxnMarkerPartitionResult message)
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
}