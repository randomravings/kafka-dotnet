using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using WritableTxnMarkerResult = Kafka.Client.Messages.WriteTxnMarkersResponse.WritableTxnMarkerResult;
using WritableTxnMarkerTopicResult = Kafka.Client.Messages.WriteTxnMarkersResponse.WritableTxnMarkerResult.WritableTxnMarkerTopicResult;
using WritableTxnMarkerPartitionResult = Kafka.Client.Messages.WriteTxnMarkersResponse.WritableTxnMarkerResult.WritableTxnMarkerTopicResult.WritableTxnMarkerPartitionResult;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class WriteTxnMarkersResponseSerde
    {
        private static readonly Func<Stream, WriteTxnMarkersResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
        };
        private static readonly Action<Stream, WriteTxnMarkersResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
        };
        public static WriteTxnMarkersResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, WriteTxnMarkersResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static WriteTxnMarkersResponse ReadV00(Stream buffer)
        {
            var markersField = Decoder.ReadArray<WritableTxnMarkerResult>(buffer, b => WritableTxnMarkerResultSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Markers'");
            return new(
                markersField
            );
        }
        private static void WriteV00(Stream buffer, WriteTxnMarkersResponse message)
        {
            Encoder.WriteArray<WritableTxnMarkerResult>(buffer, message.MarkersField, (b, i) => WritableTxnMarkerResultSerde.WriteV00(b, i));
        }
        private static WriteTxnMarkersResponse ReadV01(Stream buffer)
        {
            var markersField = Decoder.ReadCompactArray<WritableTxnMarkerResult>(buffer, b => WritableTxnMarkerResultSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Markers'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                markersField
            );
        }
        private static void WriteV01(Stream buffer, WriteTxnMarkersResponse message)
        {
            Encoder.WriteCompactArray<WritableTxnMarkerResult>(buffer, message.MarkersField, (b, i) => WritableTxnMarkerResultSerde.WriteV01(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class WritableTxnMarkerResultSerde
        {
            public static WritableTxnMarkerResult ReadV00(Stream buffer)
            {
                var producerIdField = Decoder.ReadInt64(buffer);
                var topicsField = Decoder.ReadArray<WritableTxnMarkerTopicResult>(buffer, b => WritableTxnMarkerTopicResultSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
                return new(
                    producerIdField,
                    topicsField
                );
            }
            public static void WriteV00(Stream buffer, WritableTxnMarkerResult message)
            {
                Encoder.WriteInt64(buffer, message.ProducerIdField);
                Encoder.WriteArray<WritableTxnMarkerTopicResult>(buffer, message.TopicsField, (b, i) => WritableTxnMarkerTopicResultSerde.WriteV00(b, i));
            }
            public static WritableTxnMarkerResult ReadV01(Stream buffer)
            {
                var producerIdField = Decoder.ReadInt64(buffer);
                var topicsField = Decoder.ReadCompactArray<WritableTxnMarkerTopicResult>(buffer, b => WritableTxnMarkerTopicResultSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    producerIdField,
                    topicsField
                );
            }
            public static void WriteV01(Stream buffer, WritableTxnMarkerResult message)
            {
                Encoder.WriteInt64(buffer, message.ProducerIdField);
                Encoder.WriteCompactArray<WritableTxnMarkerTopicResult>(buffer, message.TopicsField, (b, i) => WritableTxnMarkerTopicResultSerde.WriteV01(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class WritableTxnMarkerTopicResultSerde
            {
                public static WritableTxnMarkerTopicResult ReadV00(Stream buffer)
                {
                    var nameField = Decoder.ReadString(buffer);
                    var partitionsField = Decoder.ReadArray<WritableTxnMarkerPartitionResult>(buffer, b => WritableTxnMarkerPartitionResultSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                    return new(
                        nameField,
                        partitionsField
                    );
                }
                public static void WriteV00(Stream buffer, WritableTxnMarkerTopicResult message)
                {
                    Encoder.WriteString(buffer, message.NameField);
                    Encoder.WriteArray<WritableTxnMarkerPartitionResult>(buffer, message.PartitionsField, (b, i) => WritableTxnMarkerPartitionResultSerde.WriteV00(b, i));
                }
                public static WritableTxnMarkerTopicResult ReadV01(Stream buffer)
                {
                    var nameField = Decoder.ReadCompactString(buffer);
                    var partitionsField = Decoder.ReadCompactArray<WritableTxnMarkerPartitionResult>(buffer, b => WritableTxnMarkerPartitionResultSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        nameField,
                        partitionsField
                    );
                }
                public static void WriteV01(Stream buffer, WritableTxnMarkerTopicResult message)
                {
                    Encoder.WriteCompactString(buffer, message.NameField);
                    Encoder.WriteCompactArray<WritableTxnMarkerPartitionResult>(buffer, message.PartitionsField, (b, i) => WritableTxnMarkerPartitionResultSerde.WriteV01(b, i));
                    Encoder.WriteVarUInt32(buffer, 0);
                }
                private static class WritableTxnMarkerPartitionResultSerde
                {
                    public static WritableTxnMarkerPartitionResult ReadV00(Stream buffer)
                    {
                        var partitionIndexField = Decoder.ReadInt32(buffer);
                        var errorCodeField = Decoder.ReadInt16(buffer);
                        return new(
                            partitionIndexField,
                            errorCodeField
                        );
                    }
                    public static void WriteV00(Stream buffer, WritableTxnMarkerPartitionResult message)
                    {
                        Encoder.WriteInt32(buffer, message.PartitionIndexField);
                        Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    }
                    public static WritableTxnMarkerPartitionResult ReadV01(Stream buffer)
                    {
                        var partitionIndexField = Decoder.ReadInt32(buffer);
                        var errorCodeField = Decoder.ReadInt16(buffer);
                        _ = Decoder.ReadVarUInt32(buffer);
                        return new(
                            partitionIndexField,
                            errorCodeField
                        );
                    }
                    public static void WriteV01(Stream buffer, WritableTxnMarkerPartitionResult message)
                    {
                        Encoder.WriteInt32(buffer, message.PartitionIndexField);
                        Encoder.WriteInt16(buffer, message.ErrorCodeField);
                        Encoder.WriteVarUInt32(buffer, 0);
                    }
                }
            }
        }
    }
}