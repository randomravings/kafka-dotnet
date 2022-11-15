using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using Kafka.Common.Records;
using FetchableTopicResponse = Kafka.Client.Messages.FetchResponse.FetchableTopicResponse;
using EpochEndOffset = Kafka.Client.Messages.FetchResponse.FetchableTopicResponse.PartitionData.EpochEndOffset;
using LeaderIdAndEpoch = Kafka.Client.Messages.FetchResponse.FetchableTopicResponse.PartitionData.LeaderIdAndEpoch;
using SnapshotId = Kafka.Client.Messages.FetchResponse.FetchableTopicResponse.PartitionData.SnapshotId;
using AbortedTransaction = Kafka.Client.Messages.FetchResponse.FetchableTopicResponse.PartitionData.AbortedTransaction;
using PartitionData = Kafka.Client.Messages.FetchResponse.FetchableTopicResponse.PartitionData;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class FetchResponseSerde
    {
        private static readonly Func<Stream, FetchResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
            b => ReadV04(b),
            b => ReadV05(b),
            b => ReadV06(b),
            b => ReadV07(b),
            b => ReadV08(b),
            b => ReadV09(b),
            b => ReadV10(b),
            b => ReadV11(b),
            b => ReadV12(b),
            b => ReadV13(b),
        };
        private static readonly Action<Stream, FetchResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
            (b, m) => WriteV05(b, m),
            (b, m) => WriteV06(b, m),
            (b, m) => WriteV07(b, m),
            (b, m) => WriteV08(b, m),
            (b, m) => WriteV09(b, m),
            (b, m) => WriteV10(b, m),
            (b, m) => WriteV11(b, m),
            (b, m) => WriteV12(b, m),
            (b, m) => WriteV13(b, m),
        };
        public static FetchResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, FetchResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static FetchResponse ReadV00(Stream buffer)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = Decoder.ReadArray<FetchableTopicResponse>(buffer, b => FetchableTopicResponseSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField
            );
        }
        private static void WriteV00(Stream buffer, FetchResponse message)
        {
            Encoder.WriteArray<FetchableTopicResponse>(buffer, message.ResponsesField, (b, i) => FetchableTopicResponseSerde.WriteV00(b, i));
        }
        private static FetchResponse ReadV01(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = Decoder.ReadArray<FetchableTopicResponse>(buffer, b => FetchableTopicResponseSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField
            );
        }
        private static void WriteV01(Stream buffer, FetchResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<FetchableTopicResponse>(buffer, message.ResponsesField, (b, i) => FetchableTopicResponseSerde.WriteV01(b, i));
        }
        private static FetchResponse ReadV02(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = Decoder.ReadArray<FetchableTopicResponse>(buffer, b => FetchableTopicResponseSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField
            );
        }
        private static void WriteV02(Stream buffer, FetchResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<FetchableTopicResponse>(buffer, message.ResponsesField, (b, i) => FetchableTopicResponseSerde.WriteV02(b, i));
        }
        private static FetchResponse ReadV03(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = Decoder.ReadArray<FetchableTopicResponse>(buffer, b => FetchableTopicResponseSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField
            );
        }
        private static void WriteV03(Stream buffer, FetchResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<FetchableTopicResponse>(buffer, message.ResponsesField, (b, i) => FetchableTopicResponseSerde.WriteV03(b, i));
        }
        private static FetchResponse ReadV04(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = Decoder.ReadArray<FetchableTopicResponse>(buffer, b => FetchableTopicResponseSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField
            );
        }
        private static void WriteV04(Stream buffer, FetchResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<FetchableTopicResponse>(buffer, message.ResponsesField, (b, i) => FetchableTopicResponseSerde.WriteV04(b, i));
        }
        private static FetchResponse ReadV05(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = Decoder.ReadArray<FetchableTopicResponse>(buffer, b => FetchableTopicResponseSerde.ReadV05(b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField
            );
        }
        private static void WriteV05(Stream buffer, FetchResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<FetchableTopicResponse>(buffer, message.ResponsesField, (b, i) => FetchableTopicResponseSerde.WriteV05(b, i));
        }
        private static FetchResponse ReadV06(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = Decoder.ReadArray<FetchableTopicResponse>(buffer, b => FetchableTopicResponseSerde.ReadV06(b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField
            );
        }
        private static void WriteV06(Stream buffer, FetchResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<FetchableTopicResponse>(buffer, message.ResponsesField, (b, i) => FetchableTopicResponseSerde.WriteV06(b, i));
        }
        private static FetchResponse ReadV07(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var sessionIdField = Decoder.ReadInt32(buffer);
            var responsesField = Decoder.ReadArray<FetchableTopicResponse>(buffer, b => FetchableTopicResponseSerde.ReadV07(b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField
            );
        }
        private static void WriteV07(Stream buffer, FetchResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteInt32(buffer, message.SessionIdField);
            Encoder.WriteArray<FetchableTopicResponse>(buffer, message.ResponsesField, (b, i) => FetchableTopicResponseSerde.WriteV07(b, i));
        }
        private static FetchResponse ReadV08(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var sessionIdField = Decoder.ReadInt32(buffer);
            var responsesField = Decoder.ReadArray<FetchableTopicResponse>(buffer, b => FetchableTopicResponseSerde.ReadV08(b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField
            );
        }
        private static void WriteV08(Stream buffer, FetchResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteInt32(buffer, message.SessionIdField);
            Encoder.WriteArray<FetchableTopicResponse>(buffer, message.ResponsesField, (b, i) => FetchableTopicResponseSerde.WriteV08(b, i));
        }
        private static FetchResponse ReadV09(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var sessionIdField = Decoder.ReadInt32(buffer);
            var responsesField = Decoder.ReadArray<FetchableTopicResponse>(buffer, b => FetchableTopicResponseSerde.ReadV09(b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField
            );
        }
        private static void WriteV09(Stream buffer, FetchResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteInt32(buffer, message.SessionIdField);
            Encoder.WriteArray<FetchableTopicResponse>(buffer, message.ResponsesField, (b, i) => FetchableTopicResponseSerde.WriteV09(b, i));
        }
        private static FetchResponse ReadV10(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var sessionIdField = Decoder.ReadInt32(buffer);
            var responsesField = Decoder.ReadArray<FetchableTopicResponse>(buffer, b => FetchableTopicResponseSerde.ReadV10(b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField
            );
        }
        private static void WriteV10(Stream buffer, FetchResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteInt32(buffer, message.SessionIdField);
            Encoder.WriteArray<FetchableTopicResponse>(buffer, message.ResponsesField, (b, i) => FetchableTopicResponseSerde.WriteV10(b, i));
        }
        private static FetchResponse ReadV11(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var sessionIdField = Decoder.ReadInt32(buffer);
            var responsesField = Decoder.ReadArray<FetchableTopicResponse>(buffer, b => FetchableTopicResponseSerde.ReadV11(b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField
            );
        }
        private static void WriteV11(Stream buffer, FetchResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteInt32(buffer, message.SessionIdField);
            Encoder.WriteArray<FetchableTopicResponse>(buffer, message.ResponsesField, (b, i) => FetchableTopicResponseSerde.WriteV11(b, i));
        }
        private static FetchResponse ReadV12(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var sessionIdField = Decoder.ReadInt32(buffer);
            var responsesField = Decoder.ReadCompactArray<FetchableTopicResponse>(buffer, b => FetchableTopicResponseSerde.ReadV12(b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField
            );
        }
        private static void WriteV12(Stream buffer, FetchResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteInt32(buffer, message.SessionIdField);
            Encoder.WriteCompactArray<FetchableTopicResponse>(buffer, message.ResponsesField, (b, i) => FetchableTopicResponseSerde.WriteV12(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static FetchResponse ReadV13(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var sessionIdField = Decoder.ReadInt32(buffer);
            var responsesField = Decoder.ReadCompactArray<FetchableTopicResponse>(buffer, b => FetchableTopicResponseSerde.ReadV13(b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField
            );
        }
        private static void WriteV13(Stream buffer, FetchResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteInt32(buffer, message.SessionIdField);
            Encoder.WriteCompactArray<FetchableTopicResponse>(buffer, message.ResponsesField, (b, i) => FetchableTopicResponseSerde.WriteV13(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class FetchableTopicResponseSerde
        {
            public static FetchableTopicResponse ReadV00(Stream buffer)
            {
                var topicField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<PartitionData>(buffer, b => PartitionDataSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static void WriteV00(Stream buffer, FetchableTopicResponse message)
            {
                Encoder.WriteString(buffer, message.TopicField);
                Encoder.WriteArray<PartitionData>(buffer, message.PartitionsField, (b, i) => PartitionDataSerde.WriteV00(b, i));
            }
            public static FetchableTopicResponse ReadV01(Stream buffer)
            {
                var topicField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<PartitionData>(buffer, b => PartitionDataSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static void WriteV01(Stream buffer, FetchableTopicResponse message)
            {
                Encoder.WriteString(buffer, message.TopicField);
                Encoder.WriteArray<PartitionData>(buffer, message.PartitionsField, (b, i) => PartitionDataSerde.WriteV01(b, i));
            }
            public static FetchableTopicResponse ReadV02(Stream buffer)
            {
                var topicField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<PartitionData>(buffer, b => PartitionDataSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static void WriteV02(Stream buffer, FetchableTopicResponse message)
            {
                Encoder.WriteString(buffer, message.TopicField);
                Encoder.WriteArray<PartitionData>(buffer, message.PartitionsField, (b, i) => PartitionDataSerde.WriteV02(b, i));
            }
            public static FetchableTopicResponse ReadV03(Stream buffer)
            {
                var topicField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<PartitionData>(buffer, b => PartitionDataSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static void WriteV03(Stream buffer, FetchableTopicResponse message)
            {
                Encoder.WriteString(buffer, message.TopicField);
                Encoder.WriteArray<PartitionData>(buffer, message.PartitionsField, (b, i) => PartitionDataSerde.WriteV03(b, i));
            }
            public static FetchableTopicResponse ReadV04(Stream buffer)
            {
                var topicField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<PartitionData>(buffer, b => PartitionDataSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static void WriteV04(Stream buffer, FetchableTopicResponse message)
            {
                Encoder.WriteString(buffer, message.TopicField);
                Encoder.WriteArray<PartitionData>(buffer, message.PartitionsField, (b, i) => PartitionDataSerde.WriteV04(b, i));
            }
            public static FetchableTopicResponse ReadV05(Stream buffer)
            {
                var topicField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<PartitionData>(buffer, b => PartitionDataSerde.ReadV05(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static void WriteV05(Stream buffer, FetchableTopicResponse message)
            {
                Encoder.WriteString(buffer, message.TopicField);
                Encoder.WriteArray<PartitionData>(buffer, message.PartitionsField, (b, i) => PartitionDataSerde.WriteV05(b, i));
            }
            public static FetchableTopicResponse ReadV06(Stream buffer)
            {
                var topicField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<PartitionData>(buffer, b => PartitionDataSerde.ReadV06(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static void WriteV06(Stream buffer, FetchableTopicResponse message)
            {
                Encoder.WriteString(buffer, message.TopicField);
                Encoder.WriteArray<PartitionData>(buffer, message.PartitionsField, (b, i) => PartitionDataSerde.WriteV06(b, i));
            }
            public static FetchableTopicResponse ReadV07(Stream buffer)
            {
                var topicField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<PartitionData>(buffer, b => PartitionDataSerde.ReadV07(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static void WriteV07(Stream buffer, FetchableTopicResponse message)
            {
                Encoder.WriteString(buffer, message.TopicField);
                Encoder.WriteArray<PartitionData>(buffer, message.PartitionsField, (b, i) => PartitionDataSerde.WriteV07(b, i));
            }
            public static FetchableTopicResponse ReadV08(Stream buffer)
            {
                var topicField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<PartitionData>(buffer, b => PartitionDataSerde.ReadV08(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static void WriteV08(Stream buffer, FetchableTopicResponse message)
            {
                Encoder.WriteString(buffer, message.TopicField);
                Encoder.WriteArray<PartitionData>(buffer, message.PartitionsField, (b, i) => PartitionDataSerde.WriteV08(b, i));
            }
            public static FetchableTopicResponse ReadV09(Stream buffer)
            {
                var topicField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<PartitionData>(buffer, b => PartitionDataSerde.ReadV09(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static void WriteV09(Stream buffer, FetchableTopicResponse message)
            {
                Encoder.WriteString(buffer, message.TopicField);
                Encoder.WriteArray<PartitionData>(buffer, message.PartitionsField, (b, i) => PartitionDataSerde.WriteV09(b, i));
            }
            public static FetchableTopicResponse ReadV10(Stream buffer)
            {
                var topicField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<PartitionData>(buffer, b => PartitionDataSerde.ReadV10(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static void WriteV10(Stream buffer, FetchableTopicResponse message)
            {
                Encoder.WriteString(buffer, message.TopicField);
                Encoder.WriteArray<PartitionData>(buffer, message.PartitionsField, (b, i) => PartitionDataSerde.WriteV10(b, i));
            }
            public static FetchableTopicResponse ReadV11(Stream buffer)
            {
                var topicField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<PartitionData>(buffer, b => PartitionDataSerde.ReadV11(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static void WriteV11(Stream buffer, FetchableTopicResponse message)
            {
                Encoder.WriteString(buffer, message.TopicField);
                Encoder.WriteArray<PartitionData>(buffer, message.PartitionsField, (b, i) => PartitionDataSerde.WriteV11(b, i));
            }
            public static FetchableTopicResponse ReadV12(Stream buffer)
            {
                var topicField = Decoder.ReadCompactString(buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadCompactArray<PartitionData>(buffer, b => PartitionDataSerde.ReadV12(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static void WriteV12(Stream buffer, FetchableTopicResponse message)
            {
                Encoder.WriteCompactString(buffer, message.TopicField);
                Encoder.WriteCompactArray<PartitionData>(buffer, message.PartitionsField, (b, i) => PartitionDataSerde.WriteV12(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static FetchableTopicResponse ReadV13(Stream buffer)
            {
                var topicField = "";
                var topicIdField = Decoder.ReadUuid(buffer);
                var partitionsField = Decoder.ReadCompactArray<PartitionData>(buffer, b => PartitionDataSerde.ReadV13(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static void WriteV13(Stream buffer, FetchableTopicResponse message)
            {
                Encoder.WriteUuid(buffer, message.TopicIdField);
                Encoder.WriteCompactArray<PartitionData>(buffer, message.PartitionsField, (b, i) => PartitionDataSerde.WriteV13(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class PartitionDataSerde
            {
                public static PartitionData ReadV00(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var highWatermarkField = Decoder.ReadInt64(buffer);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = ImmutableArray<AbortedTransaction>.Empty;
                    var preferredReadReplicaField = default(int);
                    var recordsField = Decoder.ReadRecords(buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
                    return new(
                        partitionIndexField,
                        errorCodeField,
                        highWatermarkField,
                        lastStableOffsetField,
                        logStartOffsetField,
                        divergingEpochField,
                        currentLeaderField,
                        snapshotIdField,
                        abortedTransactionsField,
                        preferredReadReplicaField,
                        recordsField
                    );
                }
                public static void WriteV00(Stream buffer, PartitionData message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt64(buffer, message.HighWatermarkField);
                    Encoder.WriteRecords(buffer, message.RecordsField);
                }
                public static PartitionData ReadV01(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var highWatermarkField = Decoder.ReadInt64(buffer);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = ImmutableArray<AbortedTransaction>.Empty;
                    var preferredReadReplicaField = default(int);
                    var recordsField = Decoder.ReadRecords(buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
                    return new(
                        partitionIndexField,
                        errorCodeField,
                        highWatermarkField,
                        lastStableOffsetField,
                        logStartOffsetField,
                        divergingEpochField,
                        currentLeaderField,
                        snapshotIdField,
                        abortedTransactionsField,
                        preferredReadReplicaField,
                        recordsField
                    );
                }
                public static void WriteV01(Stream buffer, PartitionData message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt64(buffer, message.HighWatermarkField);
                    Encoder.WriteRecords(buffer, message.RecordsField);
                }
                public static PartitionData ReadV02(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var highWatermarkField = Decoder.ReadInt64(buffer);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = ImmutableArray<AbortedTransaction>.Empty;
                    var preferredReadReplicaField = default(int);
                    var recordsField = Decoder.ReadRecords(buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
                    return new(
                        partitionIndexField,
                        errorCodeField,
                        highWatermarkField,
                        lastStableOffsetField,
                        logStartOffsetField,
                        divergingEpochField,
                        currentLeaderField,
                        snapshotIdField,
                        abortedTransactionsField,
                        preferredReadReplicaField,
                        recordsField
                    );
                }
                public static void WriteV02(Stream buffer, PartitionData message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt64(buffer, message.HighWatermarkField);
                    Encoder.WriteRecords(buffer, message.RecordsField);
                }
                public static PartitionData ReadV03(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var highWatermarkField = Decoder.ReadInt64(buffer);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = ImmutableArray<AbortedTransaction>.Empty;
                    var preferredReadReplicaField = default(int);
                    var recordsField = Decoder.ReadRecords(buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
                    return new(
                        partitionIndexField,
                        errorCodeField,
                        highWatermarkField,
                        lastStableOffsetField,
                        logStartOffsetField,
                        divergingEpochField,
                        currentLeaderField,
                        snapshotIdField,
                        abortedTransactionsField,
                        preferredReadReplicaField,
                        recordsField
                    );
                }
                public static void WriteV03(Stream buffer, PartitionData message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt64(buffer, message.HighWatermarkField);
                    Encoder.WriteRecords(buffer, message.RecordsField);
                }
                public static PartitionData ReadV04(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var highWatermarkField = Decoder.ReadInt64(buffer);
                    var lastStableOffsetField = Decoder.ReadInt64(buffer);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = Decoder.ReadArray<AbortedTransaction>(buffer, b => AbortedTransactionSerde.ReadV04(b));
                    var preferredReadReplicaField = default(int);
                    var recordsField = Decoder.ReadRecords(buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
                    return new(
                        partitionIndexField,
                        errorCodeField,
                        highWatermarkField,
                        lastStableOffsetField,
                        logStartOffsetField,
                        divergingEpochField,
                        currentLeaderField,
                        snapshotIdField,
                        abortedTransactionsField,
                        preferredReadReplicaField,
                        recordsField
                    );
                }
                public static void WriteV04(Stream buffer, PartitionData message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt64(buffer, message.HighWatermarkField);
                    Encoder.WriteInt64(buffer, message.LastStableOffsetField);
                    Encoder.WriteArray<AbortedTransaction>(buffer, message.AbortedTransactionsField, (b, i) => AbortedTransactionSerde.WriteV04(b, i));
                    Encoder.WriteRecords(buffer, message.RecordsField);
                }
                public static PartitionData ReadV05(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var highWatermarkField = Decoder.ReadInt64(buffer);
                    var lastStableOffsetField = Decoder.ReadInt64(buffer);
                    var logStartOffsetField = Decoder.ReadInt64(buffer);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = Decoder.ReadArray<AbortedTransaction>(buffer, b => AbortedTransactionSerde.ReadV05(b));
                    var preferredReadReplicaField = default(int);
                    var recordsField = Decoder.ReadRecords(buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
                    return new(
                        partitionIndexField,
                        errorCodeField,
                        highWatermarkField,
                        lastStableOffsetField,
                        logStartOffsetField,
                        divergingEpochField,
                        currentLeaderField,
                        snapshotIdField,
                        abortedTransactionsField,
                        preferredReadReplicaField,
                        recordsField
                    );
                }
                public static void WriteV05(Stream buffer, PartitionData message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt64(buffer, message.HighWatermarkField);
                    Encoder.WriteInt64(buffer, message.LastStableOffsetField);
                    Encoder.WriteInt64(buffer, message.LogStartOffsetField);
                    Encoder.WriteArray<AbortedTransaction>(buffer, message.AbortedTransactionsField, (b, i) => AbortedTransactionSerde.WriteV05(b, i));
                    Encoder.WriteRecords(buffer, message.RecordsField);
                }
                public static PartitionData ReadV06(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var highWatermarkField = Decoder.ReadInt64(buffer);
                    var lastStableOffsetField = Decoder.ReadInt64(buffer);
                    var logStartOffsetField = Decoder.ReadInt64(buffer);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = Decoder.ReadArray<AbortedTransaction>(buffer, b => AbortedTransactionSerde.ReadV06(b));
                    var preferredReadReplicaField = default(int);
                    var recordsField = Decoder.ReadRecords(buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
                    return new(
                        partitionIndexField,
                        errorCodeField,
                        highWatermarkField,
                        lastStableOffsetField,
                        logStartOffsetField,
                        divergingEpochField,
                        currentLeaderField,
                        snapshotIdField,
                        abortedTransactionsField,
                        preferredReadReplicaField,
                        recordsField
                    );
                }
                public static void WriteV06(Stream buffer, PartitionData message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt64(buffer, message.HighWatermarkField);
                    Encoder.WriteInt64(buffer, message.LastStableOffsetField);
                    Encoder.WriteInt64(buffer, message.LogStartOffsetField);
                    Encoder.WriteArray<AbortedTransaction>(buffer, message.AbortedTransactionsField, (b, i) => AbortedTransactionSerde.WriteV06(b, i));
                    Encoder.WriteRecords(buffer, message.RecordsField);
                }
                public static PartitionData ReadV07(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var highWatermarkField = Decoder.ReadInt64(buffer);
                    var lastStableOffsetField = Decoder.ReadInt64(buffer);
                    var logStartOffsetField = Decoder.ReadInt64(buffer);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = Decoder.ReadArray<AbortedTransaction>(buffer, b => AbortedTransactionSerde.ReadV07(b));
                    var preferredReadReplicaField = default(int);
                    var recordsField = Decoder.ReadRecords(buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
                    return new(
                        partitionIndexField,
                        errorCodeField,
                        highWatermarkField,
                        lastStableOffsetField,
                        logStartOffsetField,
                        divergingEpochField,
                        currentLeaderField,
                        snapshotIdField,
                        abortedTransactionsField,
                        preferredReadReplicaField,
                        recordsField
                    );
                }
                public static void WriteV07(Stream buffer, PartitionData message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt64(buffer, message.HighWatermarkField);
                    Encoder.WriteInt64(buffer, message.LastStableOffsetField);
                    Encoder.WriteInt64(buffer, message.LogStartOffsetField);
                    Encoder.WriteArray<AbortedTransaction>(buffer, message.AbortedTransactionsField, (b, i) => AbortedTransactionSerde.WriteV07(b, i));
                    Encoder.WriteRecords(buffer, message.RecordsField);
                }
                public static PartitionData ReadV08(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var highWatermarkField = Decoder.ReadInt64(buffer);
                    var lastStableOffsetField = Decoder.ReadInt64(buffer);
                    var logStartOffsetField = Decoder.ReadInt64(buffer);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = Decoder.ReadArray<AbortedTransaction>(buffer, b => AbortedTransactionSerde.ReadV08(b));
                    var preferredReadReplicaField = default(int);
                    var recordsField = Decoder.ReadRecords(buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
                    return new(
                        partitionIndexField,
                        errorCodeField,
                        highWatermarkField,
                        lastStableOffsetField,
                        logStartOffsetField,
                        divergingEpochField,
                        currentLeaderField,
                        snapshotIdField,
                        abortedTransactionsField,
                        preferredReadReplicaField,
                        recordsField
                    );
                }
                public static void WriteV08(Stream buffer, PartitionData message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt64(buffer, message.HighWatermarkField);
                    Encoder.WriteInt64(buffer, message.LastStableOffsetField);
                    Encoder.WriteInt64(buffer, message.LogStartOffsetField);
                    Encoder.WriteArray<AbortedTransaction>(buffer, message.AbortedTransactionsField, (b, i) => AbortedTransactionSerde.WriteV08(b, i));
                    Encoder.WriteRecords(buffer, message.RecordsField);
                }
                public static PartitionData ReadV09(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var highWatermarkField = Decoder.ReadInt64(buffer);
                    var lastStableOffsetField = Decoder.ReadInt64(buffer);
                    var logStartOffsetField = Decoder.ReadInt64(buffer);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = Decoder.ReadArray<AbortedTransaction>(buffer, b => AbortedTransactionSerde.ReadV09(b));
                    var preferredReadReplicaField = default(int);
                    var recordsField = Decoder.ReadRecords(buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
                    return new(
                        partitionIndexField,
                        errorCodeField,
                        highWatermarkField,
                        lastStableOffsetField,
                        logStartOffsetField,
                        divergingEpochField,
                        currentLeaderField,
                        snapshotIdField,
                        abortedTransactionsField,
                        preferredReadReplicaField,
                        recordsField
                    );
                }
                public static void WriteV09(Stream buffer, PartitionData message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt64(buffer, message.HighWatermarkField);
                    Encoder.WriteInt64(buffer, message.LastStableOffsetField);
                    Encoder.WriteInt64(buffer, message.LogStartOffsetField);
                    Encoder.WriteArray<AbortedTransaction>(buffer, message.AbortedTransactionsField, (b, i) => AbortedTransactionSerde.WriteV09(b, i));
                    Encoder.WriteRecords(buffer, message.RecordsField);
                }
                public static PartitionData ReadV10(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var highWatermarkField = Decoder.ReadInt64(buffer);
                    var lastStableOffsetField = Decoder.ReadInt64(buffer);
                    var logStartOffsetField = Decoder.ReadInt64(buffer);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = Decoder.ReadArray<AbortedTransaction>(buffer, b => AbortedTransactionSerde.ReadV10(b));
                    var preferredReadReplicaField = default(int);
                    var recordsField = Decoder.ReadRecords(buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
                    return new(
                        partitionIndexField,
                        errorCodeField,
                        highWatermarkField,
                        lastStableOffsetField,
                        logStartOffsetField,
                        divergingEpochField,
                        currentLeaderField,
                        snapshotIdField,
                        abortedTransactionsField,
                        preferredReadReplicaField,
                        recordsField
                    );
                }
                public static void WriteV10(Stream buffer, PartitionData message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt64(buffer, message.HighWatermarkField);
                    Encoder.WriteInt64(buffer, message.LastStableOffsetField);
                    Encoder.WriteInt64(buffer, message.LogStartOffsetField);
                    Encoder.WriteArray<AbortedTransaction>(buffer, message.AbortedTransactionsField, (b, i) => AbortedTransactionSerde.WriteV10(b, i));
                    Encoder.WriteRecords(buffer, message.RecordsField);
                }
                public static PartitionData ReadV11(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var highWatermarkField = Decoder.ReadInt64(buffer);
                    var lastStableOffsetField = Decoder.ReadInt64(buffer);
                    var logStartOffsetField = Decoder.ReadInt64(buffer);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = Decoder.ReadArray<AbortedTransaction>(buffer, b => AbortedTransactionSerde.ReadV11(b));
                    var preferredReadReplicaField = Decoder.ReadInt32(buffer);
                    var recordsField = Decoder.ReadRecords(buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
                    return new(
                        partitionIndexField,
                        errorCodeField,
                        highWatermarkField,
                        lastStableOffsetField,
                        logStartOffsetField,
                        divergingEpochField,
                        currentLeaderField,
                        snapshotIdField,
                        abortedTransactionsField,
                        preferredReadReplicaField,
                        recordsField
                    );
                }
                public static void WriteV11(Stream buffer, PartitionData message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt64(buffer, message.HighWatermarkField);
                    Encoder.WriteInt64(buffer, message.LastStableOffsetField);
                    Encoder.WriteInt64(buffer, message.LogStartOffsetField);
                    Encoder.WriteArray<AbortedTransaction>(buffer, message.AbortedTransactionsField, (b, i) => AbortedTransactionSerde.WriteV11(b, i));
                    Encoder.WriteInt32(buffer, message.PreferredReadReplicaField);
                    Encoder.WriteRecords(buffer, message.RecordsField);
                }
                public static PartitionData ReadV12(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var highWatermarkField = Decoder.ReadInt64(buffer);
                    var lastStableOffsetField = Decoder.ReadInt64(buffer);
                    var logStartOffsetField = Decoder.ReadInt64(buffer);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = Decoder.ReadCompactArray<AbortedTransaction>(buffer, b => AbortedTransactionSerde.ReadV12(b));
                    var preferredReadReplicaField = Decoder.ReadInt32(buffer);
                    var recordsField = Decoder.ReadRecords(buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField,
                        highWatermarkField,
                        lastStableOffsetField,
                        logStartOffsetField,
                        divergingEpochField,
                        currentLeaderField,
                        snapshotIdField,
                        abortedTransactionsField,
                        preferredReadReplicaField,
                        recordsField
                    );
                }
                public static void WriteV12(Stream buffer, PartitionData message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt64(buffer, message.HighWatermarkField);
                    Encoder.WriteInt64(buffer, message.LastStableOffsetField);
                    Encoder.WriteInt64(buffer, message.LogStartOffsetField);
                    EpochEndOffsetSerde.WriteV12(buffer, message.DivergingEpochField);
                    LeaderIdAndEpochSerde.WriteV12(buffer, message.CurrentLeaderField);
                    SnapshotIdSerde.WriteV12(buffer, message.SnapshotIdField);
                    Encoder.WriteCompactArray<AbortedTransaction>(buffer, message.AbortedTransactionsField, (b, i) => AbortedTransactionSerde.WriteV12(b, i));
                    Encoder.WriteInt32(buffer, message.PreferredReadReplicaField);
                    Encoder.WriteCompactRecords(buffer, message.RecordsField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
                public static PartitionData ReadV13(Stream buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(buffer);
                    var errorCodeField = Decoder.ReadInt16(buffer);
                    var highWatermarkField = Decoder.ReadInt64(buffer);
                    var lastStableOffsetField = Decoder.ReadInt64(buffer);
                    var logStartOffsetField = Decoder.ReadInt64(buffer);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = Decoder.ReadCompactArray<AbortedTransaction>(buffer, b => AbortedTransactionSerde.ReadV13(b));
                    var preferredReadReplicaField = Decoder.ReadInt32(buffer);
                    var recordsField = Decoder.ReadRecords(buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        partitionIndexField,
                        errorCodeField,
                        highWatermarkField,
                        lastStableOffsetField,
                        logStartOffsetField,
                        divergingEpochField,
                        currentLeaderField,
                        snapshotIdField,
                        abortedTransactionsField,
                        preferredReadReplicaField,
                        recordsField
                    );
                }
                public static void WriteV13(Stream buffer, PartitionData message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    Encoder.WriteInt64(buffer, message.HighWatermarkField);
                    Encoder.WriteInt64(buffer, message.LastStableOffsetField);
                    Encoder.WriteInt64(buffer, message.LogStartOffsetField);
                    EpochEndOffsetSerde.WriteV13(buffer, message.DivergingEpochField);
                    LeaderIdAndEpochSerde.WriteV13(buffer, message.CurrentLeaderField);
                    SnapshotIdSerde.WriteV13(buffer, message.SnapshotIdField);
                    Encoder.WriteCompactArray<AbortedTransaction>(buffer, message.AbortedTransactionsField, (b, i) => AbortedTransactionSerde.WriteV13(b, i));
                    Encoder.WriteInt32(buffer, message.PreferredReadReplicaField);
                    Encoder.WriteCompactRecords(buffer, message.RecordsField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
                private static class EpochEndOffsetSerde
                {
                    public static EpochEndOffset ReadV12(Stream buffer)
                    {
                        var epochField = Decoder.ReadInt32(buffer);
                        var endOffsetField = Decoder.ReadInt64(buffer);
                        _ = Decoder.ReadVarUInt32(buffer);
                        return new(
                            epochField,
                            endOffsetField
                        );
                    }
                    public static void WriteV12(Stream buffer, EpochEndOffset message)
                    {
                        Encoder.WriteInt32(buffer, message.EpochField);
                        Encoder.WriteInt64(buffer, message.EndOffsetField);
                        Encoder.WriteVarUInt32(buffer, 0);
                    }
                    public static EpochEndOffset ReadV13(Stream buffer)
                    {
                        var epochField = Decoder.ReadInt32(buffer);
                        var endOffsetField = Decoder.ReadInt64(buffer);
                        _ = Decoder.ReadVarUInt32(buffer);
                        return new(
                            epochField,
                            endOffsetField
                        );
                    }
                    public static void WriteV13(Stream buffer, EpochEndOffset message)
                    {
                        Encoder.WriteInt32(buffer, message.EpochField);
                        Encoder.WriteInt64(buffer, message.EndOffsetField);
                        Encoder.WriteVarUInt32(buffer, 0);
                    }
                }
                private static class LeaderIdAndEpochSerde
                {
                    public static LeaderIdAndEpoch ReadV12(Stream buffer)
                    {
                        var leaderIdField = Decoder.ReadInt32(buffer);
                        var leaderEpochField = Decoder.ReadInt32(buffer);
                        _ = Decoder.ReadVarUInt32(buffer);
                        return new(
                            leaderIdField,
                            leaderEpochField
                        );
                    }
                    public static void WriteV12(Stream buffer, LeaderIdAndEpoch message)
                    {
                        Encoder.WriteInt32(buffer, message.LeaderIdField);
                        Encoder.WriteInt32(buffer, message.LeaderEpochField);
                        Encoder.WriteVarUInt32(buffer, 0);
                    }
                    public static LeaderIdAndEpoch ReadV13(Stream buffer)
                    {
                        var leaderIdField = Decoder.ReadInt32(buffer);
                        var leaderEpochField = Decoder.ReadInt32(buffer);
                        _ = Decoder.ReadVarUInt32(buffer);
                        return new(
                            leaderIdField,
                            leaderEpochField
                        );
                    }
                    public static void WriteV13(Stream buffer, LeaderIdAndEpoch message)
                    {
                        Encoder.WriteInt32(buffer, message.LeaderIdField);
                        Encoder.WriteInt32(buffer, message.LeaderEpochField);
                        Encoder.WriteVarUInt32(buffer, 0);
                    }
                }
                private static class SnapshotIdSerde
                {
                    public static SnapshotId ReadV12(Stream buffer)
                    {
                        var endOffsetField = Decoder.ReadInt64(buffer);
                        var epochField = Decoder.ReadInt32(buffer);
                        _ = Decoder.ReadVarUInt32(buffer);
                        return new(
                            endOffsetField,
                            epochField
                        );
                    }
                    public static void WriteV12(Stream buffer, SnapshotId message)
                    {
                        Encoder.WriteInt64(buffer, message.EndOffsetField);
                        Encoder.WriteInt32(buffer, message.EpochField);
                        Encoder.WriteVarUInt32(buffer, 0);
                    }
                    public static SnapshotId ReadV13(Stream buffer)
                    {
                        var endOffsetField = Decoder.ReadInt64(buffer);
                        var epochField = Decoder.ReadInt32(buffer);
                        _ = Decoder.ReadVarUInt32(buffer);
                        return new(
                            endOffsetField,
                            epochField
                        );
                    }
                    public static void WriteV13(Stream buffer, SnapshotId message)
                    {
                        Encoder.WriteInt64(buffer, message.EndOffsetField);
                        Encoder.WriteInt32(buffer, message.EpochField);
                        Encoder.WriteVarUInt32(buffer, 0);
                    }
                }
                private static class AbortedTransactionSerde
                {
                    public static AbortedTransaction ReadV04(Stream buffer)
                    {
                        var producerIdField = Decoder.ReadInt64(buffer);
                        var firstOffsetField = Decoder.ReadInt64(buffer);
                        return new(
                            producerIdField,
                            firstOffsetField
                        );
                    }
                    public static void WriteV04(Stream buffer, AbortedTransaction message)
                    {
                        Encoder.WriteInt64(buffer, message.ProducerIdField);
                        Encoder.WriteInt64(buffer, message.FirstOffsetField);
                    }
                    public static AbortedTransaction ReadV05(Stream buffer)
                    {
                        var producerIdField = Decoder.ReadInt64(buffer);
                        var firstOffsetField = Decoder.ReadInt64(buffer);
                        return new(
                            producerIdField,
                            firstOffsetField
                        );
                    }
                    public static void WriteV05(Stream buffer, AbortedTransaction message)
                    {
                        Encoder.WriteInt64(buffer, message.ProducerIdField);
                        Encoder.WriteInt64(buffer, message.FirstOffsetField);
                    }
                    public static AbortedTransaction ReadV06(Stream buffer)
                    {
                        var producerIdField = Decoder.ReadInt64(buffer);
                        var firstOffsetField = Decoder.ReadInt64(buffer);
                        return new(
                            producerIdField,
                            firstOffsetField
                        );
                    }
                    public static void WriteV06(Stream buffer, AbortedTransaction message)
                    {
                        Encoder.WriteInt64(buffer, message.ProducerIdField);
                        Encoder.WriteInt64(buffer, message.FirstOffsetField);
                    }
                    public static AbortedTransaction ReadV07(Stream buffer)
                    {
                        var producerIdField = Decoder.ReadInt64(buffer);
                        var firstOffsetField = Decoder.ReadInt64(buffer);
                        return new(
                            producerIdField,
                            firstOffsetField
                        );
                    }
                    public static void WriteV07(Stream buffer, AbortedTransaction message)
                    {
                        Encoder.WriteInt64(buffer, message.ProducerIdField);
                        Encoder.WriteInt64(buffer, message.FirstOffsetField);
                    }
                    public static AbortedTransaction ReadV08(Stream buffer)
                    {
                        var producerIdField = Decoder.ReadInt64(buffer);
                        var firstOffsetField = Decoder.ReadInt64(buffer);
                        return new(
                            producerIdField,
                            firstOffsetField
                        );
                    }
                    public static void WriteV08(Stream buffer, AbortedTransaction message)
                    {
                        Encoder.WriteInt64(buffer, message.ProducerIdField);
                        Encoder.WriteInt64(buffer, message.FirstOffsetField);
                    }
                    public static AbortedTransaction ReadV09(Stream buffer)
                    {
                        var producerIdField = Decoder.ReadInt64(buffer);
                        var firstOffsetField = Decoder.ReadInt64(buffer);
                        return new(
                            producerIdField,
                            firstOffsetField
                        );
                    }
                    public static void WriteV09(Stream buffer, AbortedTransaction message)
                    {
                        Encoder.WriteInt64(buffer, message.ProducerIdField);
                        Encoder.WriteInt64(buffer, message.FirstOffsetField);
                    }
                    public static AbortedTransaction ReadV10(Stream buffer)
                    {
                        var producerIdField = Decoder.ReadInt64(buffer);
                        var firstOffsetField = Decoder.ReadInt64(buffer);
                        return new(
                            producerIdField,
                            firstOffsetField
                        );
                    }
                    public static void WriteV10(Stream buffer, AbortedTransaction message)
                    {
                        Encoder.WriteInt64(buffer, message.ProducerIdField);
                        Encoder.WriteInt64(buffer, message.FirstOffsetField);
                    }
                    public static AbortedTransaction ReadV11(Stream buffer)
                    {
                        var producerIdField = Decoder.ReadInt64(buffer);
                        var firstOffsetField = Decoder.ReadInt64(buffer);
                        return new(
                            producerIdField,
                            firstOffsetField
                        );
                    }
                    public static void WriteV11(Stream buffer, AbortedTransaction message)
                    {
                        Encoder.WriteInt64(buffer, message.ProducerIdField);
                        Encoder.WriteInt64(buffer, message.FirstOffsetField);
                    }
                    public static AbortedTransaction ReadV12(Stream buffer)
                    {
                        var producerIdField = Decoder.ReadInt64(buffer);
                        var firstOffsetField = Decoder.ReadInt64(buffer);
                        _ = Decoder.ReadVarUInt32(buffer);
                        return new(
                            producerIdField,
                            firstOffsetField
                        );
                    }
                    public static void WriteV12(Stream buffer, AbortedTransaction message)
                    {
                        Encoder.WriteInt64(buffer, message.ProducerIdField);
                        Encoder.WriteInt64(buffer, message.FirstOffsetField);
                        Encoder.WriteVarUInt32(buffer, 0);
                    }
                    public static AbortedTransaction ReadV13(Stream buffer)
                    {
                        var producerIdField = Decoder.ReadInt64(buffer);
                        var firstOffsetField = Decoder.ReadInt64(buffer);
                        _ = Decoder.ReadVarUInt32(buffer);
                        return new(
                            producerIdField,
                            firstOffsetField
                        );
                    }
                    public static void WriteV13(Stream buffer, AbortedTransaction message)
                    {
                        Encoder.WriteInt64(buffer, message.ProducerIdField);
                        Encoder.WriteInt64(buffer, message.FirstOffsetField);
                        Encoder.WriteVarUInt32(buffer, 0);
                    }
                }
            }
        }
    }
}