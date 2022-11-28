using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using RemainingPartition = Kafka.Client.Messages.ControlledShutdownResponse.RemainingPartition;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ControlledShutdownResponseSerde
    {
        private static readonly DecodeDelegate<ControlledShutdownResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
        };
        private static readonly EncodeDelegate<ControlledShutdownResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
        };
        public static ControlledShutdownResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, ControlledShutdownResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static ControlledShutdownResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var remainingPartitionsField = Decoder.ReadArray<RemainingPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => RemainingPartitionSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'RemainingPartitions'");
            return new(
                errorCodeField,
                remainingPartitionsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, ControlledShutdownResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteArray<RemainingPartition>(buffer, message.RemainingPartitionsField, (b, i) => RemainingPartitionSerde.WriteV00(b, i));
            return buffer;
        }
        private static ControlledShutdownResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var remainingPartitionsField = Decoder.ReadArray<RemainingPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => RemainingPartitionSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'RemainingPartitions'");
            return new(
                errorCodeField,
                remainingPartitionsField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, ControlledShutdownResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteArray<RemainingPartition>(buffer, message.RemainingPartitionsField, (b, i) => RemainingPartitionSerde.WriteV01(b, i));
            return buffer;
        }
        private static ControlledShutdownResponse ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var remainingPartitionsField = Decoder.ReadArray<RemainingPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => RemainingPartitionSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'RemainingPartitions'");
            return new(
                errorCodeField,
                remainingPartitionsField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, ControlledShutdownResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteArray<RemainingPartition>(buffer, message.RemainingPartitionsField, (b, i) => RemainingPartitionSerde.WriteV02(b, i));
            return buffer;
        }
        private static ControlledShutdownResponse ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var remainingPartitionsField = Decoder.ReadCompactArray<RemainingPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => RemainingPartitionSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'RemainingPartitions'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                errorCodeField,
                remainingPartitionsField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, ControlledShutdownResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteCompactArray<RemainingPartition>(buffer, message.RemainingPartitionsField, (b, i) => RemainingPartitionSerde.WriteV03(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class RemainingPartitionSerde
        {
            public static RemainingPartition ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = Decoder.ReadString(ref buffer);
                var partitionIndexField = Decoder.ReadInt32(ref buffer);
                return new(
                    topicNameField,
                    partitionIndexField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, RemainingPartition message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicNameField);
                buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                return buffer;
            }
            public static RemainingPartition ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = Decoder.ReadString(ref buffer);
                var partitionIndexField = Decoder.ReadInt32(ref buffer);
                return new(
                    topicNameField,
                    partitionIndexField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, RemainingPartition message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicNameField);
                buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                return buffer;
            }
            public static RemainingPartition ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = Decoder.ReadString(ref buffer);
                var partitionIndexField = Decoder.ReadInt32(ref buffer);
                return new(
                    topicNameField,
                    partitionIndexField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, RemainingPartition message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicNameField);
                buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                return buffer;
            }
            public static RemainingPartition ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var topicNameField = Decoder.ReadCompactString(ref buffer);
                var partitionIndexField = Decoder.ReadInt32(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    topicNameField,
                    partitionIndexField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, RemainingPartition message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.TopicNameField);
                buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
    }
}