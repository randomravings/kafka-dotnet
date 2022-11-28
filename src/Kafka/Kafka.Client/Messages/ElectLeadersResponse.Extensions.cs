using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using ReplicaElectionResult = Kafka.Client.Messages.ElectLeadersResponse.ReplicaElectionResult;
using PartitionResult = Kafka.Client.Messages.ElectLeadersResponse.ReplicaElectionResult.PartitionResult;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ElectLeadersResponseSerde
    {
        private static readonly DecodeDelegate<ElectLeadersResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
        };
        private static readonly EncodeDelegate<ElectLeadersResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
        };
        public static ElectLeadersResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, ElectLeadersResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static ElectLeadersResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = default(short);
            var replicaElectionResultsField = Decoder.ReadArray<ReplicaElectionResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => ReplicaElectionResultSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'ReplicaElectionResults'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                replicaElectionResultsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, ElectLeadersResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<ReplicaElectionResult>(buffer, message.ReplicaElectionResultsField, (b, i) => ReplicaElectionResultSerde.WriteV00(b, i));
            return buffer;
        }
        private static ElectLeadersResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var replicaElectionResultsField = Decoder.ReadArray<ReplicaElectionResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => ReplicaElectionResultSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'ReplicaElectionResults'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                replicaElectionResultsField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, ElectLeadersResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteArray<ReplicaElectionResult>(buffer, message.ReplicaElectionResultsField, (b, i) => ReplicaElectionResultSerde.WriteV01(b, i));
            return buffer;
        }
        private static ElectLeadersResponse ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var replicaElectionResultsField = Decoder.ReadCompactArray<ReplicaElectionResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => ReplicaElectionResultSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'ReplicaElectionResults'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                replicaElectionResultsField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, ElectLeadersResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteCompactArray<ReplicaElectionResult>(buffer, message.ReplicaElectionResultsField, (b, i) => ReplicaElectionResultSerde.WriteV02(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class ReplicaElectionResultSerde
        {
            public static ReplicaElectionResult ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadString(ref buffer);
                var partitionResultField = Decoder.ReadArray<PartitionResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionResultSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionResult'");
                return new(
                    topicField,
                    partitionResultField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, ReplicaElectionResult message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicField);
                buffer = Encoder.WriteArray<PartitionResult>(buffer, message.PartitionResultField, (b, i) => PartitionResultSerde.WriteV00(b, i));
                return buffer;
            }
            public static ReplicaElectionResult ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadString(ref buffer);
                var partitionResultField = Decoder.ReadArray<PartitionResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionResultSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionResult'");
                return new(
                    topicField,
                    partitionResultField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, ReplicaElectionResult message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicField);
                buffer = Encoder.WriteArray<PartitionResult>(buffer, message.PartitionResultField, (b, i) => PartitionResultSerde.WriteV01(b, i));
                return buffer;
            }
            public static ReplicaElectionResult ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadCompactString(ref buffer);
                var partitionResultField = Decoder.ReadCompactArray<PartitionResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionResultSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionResult'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    topicField,
                    partitionResultField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, ReplicaElectionResult message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.TopicField);
                buffer = Encoder.WriteCompactArray<PartitionResult>(buffer, message.PartitionResultField, (b, i) => PartitionResultSerde.WriteV02(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class PartitionResultSerde
            {
                public static PartitionResult ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIdField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var errorMessageField = Decoder.ReadNullableString(ref buffer);
                    return new(
                        partitionIdField,
                        errorCodeField,
                        errorMessageField
                    );
                }
                public static Memory<byte> WriteV00(Memory<byte> buffer, PartitionResult message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIdField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteNullableString(buffer, message.ErrorMessageField);
                    return buffer;
                }
                public static PartitionResult ReadV01(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIdField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var errorMessageField = Decoder.ReadNullableString(ref buffer);
                    return new(
                        partitionIdField,
                        errorCodeField,
                        errorMessageField
                    );
                }
                public static Memory<byte> WriteV01(Memory<byte> buffer, PartitionResult message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIdField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteNullableString(buffer, message.ErrorMessageField);
                    return buffer;
                }
                public static PartitionResult ReadV02(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIdField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var errorMessageField = Decoder.ReadCompactNullableString(ref buffer);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        partitionIdField,
                        errorCodeField,
                        errorMessageField
                    );
                }
                public static Memory<byte> WriteV02(Memory<byte> buffer, PartitionResult message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIdField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
            }
        }
    }
}