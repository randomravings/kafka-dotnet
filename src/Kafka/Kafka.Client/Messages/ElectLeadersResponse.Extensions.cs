using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using PartitionResult = Kafka.Client.Messages.ElectLeadersResponse.ReplicaElectionResult.PartitionResult;
using ReplicaElectionResult = Kafka.Client.Messages.ElectLeadersResponse.ReplicaElectionResult;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ElectLeadersResponseSerde
    {
        private static readonly Func<Stream, ElectLeadersResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
        };
        private static readonly Action<Stream, ElectLeadersResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
        };
        public static ElectLeadersResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, ElectLeadersResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static ElectLeadersResponse ReadV00(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = default(short);
            var replicaElectionResultsField = Decoder.ReadArray<ReplicaElectionResult>(buffer, b => ReplicaElectionResultSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'ReplicaElectionResults'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                replicaElectionResultsField
            );
        }
        private static void WriteV00(Stream buffer, ElectLeadersResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<ReplicaElectionResult>(buffer, message.ReplicaElectionResultsField, (b, i) => ReplicaElectionResultSerde.WriteV00(b, i));
        }
        private static ElectLeadersResponse ReadV01(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var replicaElectionResultsField = Decoder.ReadArray<ReplicaElectionResult>(buffer, b => ReplicaElectionResultSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'ReplicaElectionResults'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                replicaElectionResultsField
            );
        }
        private static void WriteV01(Stream buffer, ElectLeadersResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteArray<ReplicaElectionResult>(buffer, message.ReplicaElectionResultsField, (b, i) => ReplicaElectionResultSerde.WriteV01(b, i));
        }
        private static ElectLeadersResponse ReadV02(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var replicaElectionResultsField = Decoder.ReadCompactArray<ReplicaElectionResult>(buffer, b => ReplicaElectionResultSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'ReplicaElectionResults'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                replicaElectionResultsField
            );
        }
        private static void WriteV02(Stream buffer, ElectLeadersResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteCompactArray<ReplicaElectionResult>(buffer, message.ReplicaElectionResultsField, (b, i) => ReplicaElectionResultSerde.WriteV02(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class ReplicaElectionResultSerde
        {
            public static ReplicaElectionResult ReadV00(Stream buffer)
            {
                var topicField = Decoder.ReadString(buffer);
                var partitionResultField = Decoder.ReadArray<PartitionResult>(buffer, b => PartitionResultSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionResult'");
                return new(
                    topicField,
                    partitionResultField
                );
            }
            public static void WriteV00(Stream buffer, ReplicaElectionResult message)
            {
                Encoder.WriteString(buffer, message.TopicField);
                Encoder.WriteArray<PartitionResult>(buffer, message.PartitionResultField, (b, i) => PartitionResultSerde.WriteV00(b, i));
            }
            public static ReplicaElectionResult ReadV01(Stream buffer)
            {
                var topicField = Decoder.ReadString(buffer);
                var partitionResultField = Decoder.ReadArray<PartitionResult>(buffer, b => PartitionResultSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionResult'");
                return new(
                    topicField,
                    partitionResultField
                );
            }
            public static void WriteV01(Stream buffer, ReplicaElectionResult message)
            {
                Encoder.WriteString(buffer, message.TopicField);
                Encoder.WriteArray<PartitionResult>(buffer, message.PartitionResultField, (b, i) => PartitionResultSerde.WriteV01(b, i));
            }
            public static ReplicaElectionResult ReadV02(Stream buffer)
            {
                var topicField = Decoder.ReadCompactString(buffer);
                var partitionResultField = Decoder.ReadCompactArray<PartitionResult>(buffer, b => PartitionResultSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'PartitionResult'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    topicField,
                    partitionResultField
                );
            }
            public static void WriteV02(Stream buffer, ReplicaElectionResult message)
            {
                Encoder.WriteCompactString(buffer, message.TopicField);
                Encoder.WriteCompactArray<PartitionResult>(buffer, message.PartitionResultField, (b, i) => PartitionResultSerde.WriteV02(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class PartitionResultSerde
            {
                public static PartitionResult ReadV00(Stream buffer)
                {
                    var partitionIdField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var errorMessageField = Decoder.ReadNullableString(buffer);
                    return new(
                        partitionIdField,
                        errorCodeField,
                        errorMessageField
                    );
                }
                public static void WriteV00(Stream buffer, PartitionResult message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIdField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteNullableString(buffer, message.ErrorMessageField);
                }
                public static PartitionResult ReadV01(Stream buffer)
                {
                    var partitionIdField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var errorMessageField = Decoder.ReadNullableString(buffer);
                    return new(
                        partitionIdField,
                        errorCodeField,
                        errorMessageField
                    );
                }
                public static void WriteV01(Stream buffer, PartitionResult message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIdField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteNullableString(buffer, message.ErrorMessageField);
                }
                public static PartitionResult ReadV02(Stream buffer)
                {
                    var partitionIdField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var errorMessageField = Decoder.ReadCompactNullableString(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        partitionIdField,
                        errorCodeField,
                        errorMessageField
                    );
                }
                public static void WriteV02(Stream buffer, PartitionResult message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIdField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
            }
        }
    }
}