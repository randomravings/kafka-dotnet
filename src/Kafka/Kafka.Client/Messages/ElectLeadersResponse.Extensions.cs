using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using ReplicaElectionResult = Kafka.Client.Messages.ElectLeadersResponse.ReplicaElectionResult;
using PartitionResult = Kafka.Client.Messages.ElectLeadersResponse.ReplicaElectionResult.PartitionResult;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ElectLeadersResponseSerde
    {
        private static readonly DecodeDelegate<ElectLeadersResponse>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
        };
        private static readonly EncodeDelegate<ElectLeadersResponse>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
        };
        public static ElectLeadersResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, ElectLeadersResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static ElectLeadersResponse ReadV00(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = default(short);
            var replicaElectionResultsField = Decoder.ReadArray<ReplicaElectionResult>(buffer, ref index, ReplicaElectionResultSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'ReplicaElectionResults'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                replicaElectionResultsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, ElectLeadersResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<ReplicaElectionResult>(buffer, index, message.ReplicaElectionResultsField, ReplicaElectionResultSerde.WriteV00);
            return index;
        }
        private static ElectLeadersResponse ReadV01(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var replicaElectionResultsField = Decoder.ReadArray<ReplicaElectionResult>(buffer, ref index, ReplicaElectionResultSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'ReplicaElectionResults'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                replicaElectionResultsField
            );
        }
        private static int WriteV01(byte[] buffer, int index, ElectLeadersResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteArray<ReplicaElectionResult>(buffer, index, message.ReplicaElectionResultsField, ReplicaElectionResultSerde.WriteV01);
            return index;
        }
        private static ElectLeadersResponse ReadV02(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var replicaElectionResultsField = Decoder.ReadCompactArray<ReplicaElectionResult>(buffer, ref index, ReplicaElectionResultSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'ReplicaElectionResults'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                errorCodeField,
                replicaElectionResultsField
            );
        }
        private static int WriteV02(byte[] buffer, int index, ElectLeadersResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteCompactArray<ReplicaElectionResult>(buffer, index, message.ReplicaElectionResultsField, ReplicaElectionResultSerde.WriteV02);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class ReplicaElectionResultSerde
        {
            public static ReplicaElectionResult ReadV00(byte[] buffer, ref int index)
            {
                var topicField = Decoder.ReadString(buffer, ref index);
                var partitionResultField = Decoder.ReadArray<PartitionResult>(buffer, ref index, PartitionResultSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'PartitionResult'");
                return new(
                    topicField,
                    partitionResultField
                );
            }
            public static int WriteV00(byte[] buffer, int index, ReplicaElectionResult message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicField);
                index = Encoder.WriteArray<PartitionResult>(buffer, index, message.PartitionResultField, PartitionResultSerde.WriteV00);
                return index;
            }
            public static ReplicaElectionResult ReadV01(byte[] buffer, ref int index)
            {
                var topicField = Decoder.ReadString(buffer, ref index);
                var partitionResultField = Decoder.ReadArray<PartitionResult>(buffer, ref index, PartitionResultSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'PartitionResult'");
                return new(
                    topicField,
                    partitionResultField
                );
            }
            public static int WriteV01(byte[] buffer, int index, ReplicaElectionResult message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicField);
                index = Encoder.WriteArray<PartitionResult>(buffer, index, message.PartitionResultField, PartitionResultSerde.WriteV01);
                return index;
            }
            public static ReplicaElectionResult ReadV02(byte[] buffer, ref int index)
            {
                var topicField = Decoder.ReadCompactString(buffer, ref index);
                var partitionResultField = Decoder.ReadCompactArray<PartitionResult>(buffer, ref index, PartitionResultSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'PartitionResult'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    topicField,
                    partitionResultField
                );
            }
            public static int WriteV02(byte[] buffer, int index, ReplicaElectionResult message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.TopicField);
                index = Encoder.WriteCompactArray<PartitionResult>(buffer, index, message.PartitionResultField, PartitionResultSerde.WriteV02);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class PartitionResultSerde
            {
                public static PartitionResult ReadV00(byte[] buffer, ref int index)
                {
                    var partitionIdField = Decoder.ReadInt32(buffer, ref index);
                    var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var errorMessageField = Decoder.ReadNullableString(buffer, ref index);
                    return new(
                        partitionIdField,
                        errorCodeField,
                        errorMessageField
                    );
                }
                public static int WriteV00(byte[] buffer, int index, PartitionResult message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIdField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
                    return index;
                }
                public static PartitionResult ReadV01(byte[] buffer, ref int index)
                {
                    var partitionIdField = Decoder.ReadInt32(buffer, ref index);
                    var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var errorMessageField = Decoder.ReadNullableString(buffer, ref index);
                    return new(
                        partitionIdField,
                        errorCodeField,
                        errorMessageField
                    );
                }
                public static int WriteV01(byte[] buffer, int index, PartitionResult message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIdField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
                    return index;
                }
                public static PartitionResult ReadV02(byte[] buffer, ref int index)
                {
                    var partitionIdField = Decoder.ReadInt32(buffer, ref index);
                    var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var errorMessageField = Decoder.ReadCompactNullableString(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        partitionIdField,
                        errorCodeField,
                        errorMessageField
                    );
                }
                public static int WriteV02(byte[] buffer, int index, PartitionResult message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIdField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
            }
        }
    }
}