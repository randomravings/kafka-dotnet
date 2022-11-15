using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using RemainingPartition = Kafka.Client.Messages.ControlledShutdownResponse.RemainingPartition;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ControlledShutdownResponseSerde
    {
        private static readonly Func<Stream, ControlledShutdownResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
        };
        private static readonly Action<Stream, ControlledShutdownResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
        };
        public static ControlledShutdownResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, ControlledShutdownResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static ControlledShutdownResponse ReadV00(Stream buffer)
        {
            var errorCodeField = Decoder.ReadInt16(buffer);
            var remainingPartitionsField = Decoder.ReadArray<RemainingPartition>(buffer, b => RemainingPartitionSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'RemainingPartitions'");
            return new(
                errorCodeField,
                remainingPartitionsField
            );
        }
        private static void WriteV00(Stream buffer, ControlledShutdownResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteArray<RemainingPartition>(buffer, message.RemainingPartitionsField, (b, i) => RemainingPartitionSerde.WriteV00(b, i));
        }
        private static ControlledShutdownResponse ReadV01(Stream buffer)
        {
            var errorCodeField = Decoder.ReadInt16(buffer);
            var remainingPartitionsField = Decoder.ReadArray<RemainingPartition>(buffer, b => RemainingPartitionSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'RemainingPartitions'");
            return new(
                errorCodeField,
                remainingPartitionsField
            );
        }
        private static void WriteV01(Stream buffer, ControlledShutdownResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteArray<RemainingPartition>(buffer, message.RemainingPartitionsField, (b, i) => RemainingPartitionSerde.WriteV01(b, i));
        }
        private static ControlledShutdownResponse ReadV02(Stream buffer)
        {
            var errorCodeField = Decoder.ReadInt16(buffer);
            var remainingPartitionsField = Decoder.ReadArray<RemainingPartition>(buffer, b => RemainingPartitionSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'RemainingPartitions'");
            return new(
                errorCodeField,
                remainingPartitionsField
            );
        }
        private static void WriteV02(Stream buffer, ControlledShutdownResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteArray<RemainingPartition>(buffer, message.RemainingPartitionsField, (b, i) => RemainingPartitionSerde.WriteV02(b, i));
        }
        private static ControlledShutdownResponse ReadV03(Stream buffer)
        {
            var errorCodeField = Decoder.ReadInt16(buffer);
            var remainingPartitionsField = Decoder.ReadCompactArray<RemainingPartition>(buffer, b => RemainingPartitionSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'RemainingPartitions'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                errorCodeField,
                remainingPartitionsField
            );
        }
        private static void WriteV03(Stream buffer, ControlledShutdownResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteCompactArray<RemainingPartition>(buffer, message.RemainingPartitionsField, (b, i) => RemainingPartitionSerde.WriteV03(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class RemainingPartitionSerde
        {
            public static RemainingPartition ReadV00(Stream buffer)
            {
                var topicNameField = Decoder.ReadString(buffer);
                var partitionIndexField = Decoder.ReadInt32(buffer);
                return new(
                    topicNameField,
                    partitionIndexField
                );
            }
            public static void WriteV00(Stream buffer, RemainingPartition message)
            {
                Encoder.WriteString(buffer, message.TopicNameField);
                Encoder.WriteInt32(buffer, message.PartitionIndexField);
            }
            public static RemainingPartition ReadV01(Stream buffer)
            {
                var topicNameField = Decoder.ReadString(buffer);
                var partitionIndexField = Decoder.ReadInt32(buffer);
                return new(
                    topicNameField,
                    partitionIndexField
                );
            }
            public static void WriteV01(Stream buffer, RemainingPartition message)
            {
                Encoder.WriteString(buffer, message.TopicNameField);
                Encoder.WriteInt32(buffer, message.PartitionIndexField);
            }
            public static RemainingPartition ReadV02(Stream buffer)
            {
                var topicNameField = Decoder.ReadString(buffer);
                var partitionIndexField = Decoder.ReadInt32(buffer);
                return new(
                    topicNameField,
                    partitionIndexField
                );
            }
            public static void WriteV02(Stream buffer, RemainingPartition message)
            {
                Encoder.WriteString(buffer, message.TopicNameField);
                Encoder.WriteInt32(buffer, message.PartitionIndexField);
            }
            public static RemainingPartition ReadV03(Stream buffer)
            {
                var topicNameField = Decoder.ReadCompactString(buffer);
                var partitionIndexField = Decoder.ReadInt32(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    topicNameField,
                    partitionIndexField
                );
            }
            public static void WriteV03(Stream buffer, RemainingPartition message)
            {
                Encoder.WriteCompactString(buffer, message.TopicNameField);
                Encoder.WriteInt32(buffer, message.PartitionIndexField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
    }
}