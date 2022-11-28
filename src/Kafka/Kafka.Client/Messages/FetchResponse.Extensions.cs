using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using Kafka.Common.Records;
using FetchableTopicResponse = Kafka.Client.Messages.FetchResponse.FetchableTopicResponse;
using SnapshotId = Kafka.Client.Messages.FetchResponse.FetchableTopicResponse.PartitionData.SnapshotId;
using EpochEndOffset = Kafka.Client.Messages.FetchResponse.FetchableTopicResponse.PartitionData.EpochEndOffset;
using LeaderIdAndEpoch = Kafka.Client.Messages.FetchResponse.FetchableTopicResponse.PartitionData.LeaderIdAndEpoch;
using AbortedTransaction = Kafka.Client.Messages.FetchResponse.FetchableTopicResponse.PartitionData.AbortedTransaction;
using PartitionData = Kafka.Client.Messages.FetchResponse.FetchableTopicResponse.PartitionData;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class FetchResponseSerde
    {
        private static readonly DecodeDelegate<FetchResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV04(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV05(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV06(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV07(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV08(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV09(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV10(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV11(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV12(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV13(ref b),
        };
        private static readonly EncodeDelegate<FetchResponse>[] WRITE_VERSIONS = {
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
        public static FetchResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, FetchResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static FetchResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = Decoder.ReadArray<FetchableTopicResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => FetchableTopicResponseSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, FetchResponse message)
        {
            buffer = Encoder.WriteArray<FetchableTopicResponse>(buffer, message.ResponsesField, (b, i) => FetchableTopicResponseSerde.WriteV00(b, i));
            return buffer;
        }
        private static FetchResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = Decoder.ReadArray<FetchableTopicResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => FetchableTopicResponseSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, FetchResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<FetchableTopicResponse>(buffer, message.ResponsesField, (b, i) => FetchableTopicResponseSerde.WriteV01(b, i));
            return buffer;
        }
        private static FetchResponse ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = Decoder.ReadArray<FetchableTopicResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => FetchableTopicResponseSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, FetchResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<FetchableTopicResponse>(buffer, message.ResponsesField, (b, i) => FetchableTopicResponseSerde.WriteV02(b, i));
            return buffer;
        }
        private static FetchResponse ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = Decoder.ReadArray<FetchableTopicResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => FetchableTopicResponseSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, FetchResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<FetchableTopicResponse>(buffer, message.ResponsesField, (b, i) => FetchableTopicResponseSerde.WriteV03(b, i));
            return buffer;
        }
        private static FetchResponse ReadV04(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = Decoder.ReadArray<FetchableTopicResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => FetchableTopicResponseSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField
            );
        }
        private static Memory<byte> WriteV04(Memory<byte> buffer, FetchResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<FetchableTopicResponse>(buffer, message.ResponsesField, (b, i) => FetchableTopicResponseSerde.WriteV04(b, i));
            return buffer;
        }
        private static FetchResponse ReadV05(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = Decoder.ReadArray<FetchableTopicResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => FetchableTopicResponseSerde.ReadV05(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField
            );
        }
        private static Memory<byte> WriteV05(Memory<byte> buffer, FetchResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<FetchableTopicResponse>(buffer, message.ResponsesField, (b, i) => FetchableTopicResponseSerde.WriteV05(b, i));
            return buffer;
        }
        private static FetchResponse ReadV06(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = Decoder.ReadArray<FetchableTopicResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => FetchableTopicResponseSerde.ReadV06(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField
            );
        }
        private static Memory<byte> WriteV06(Memory<byte> buffer, FetchResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<FetchableTopicResponse>(buffer, message.ResponsesField, (b, i) => FetchableTopicResponseSerde.WriteV06(b, i));
            return buffer;
        }
        private static FetchResponse ReadV07(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var sessionIdField = Decoder.ReadInt32(ref buffer);
            var responsesField = Decoder.ReadArray<FetchableTopicResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => FetchableTopicResponseSerde.ReadV07(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField
            );
        }
        private static Memory<byte> WriteV07(Memory<byte> buffer, FetchResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteInt32(buffer, message.SessionIdField);
            buffer = Encoder.WriteArray<FetchableTopicResponse>(buffer, message.ResponsesField, (b, i) => FetchableTopicResponseSerde.WriteV07(b, i));
            return buffer;
        }
        private static FetchResponse ReadV08(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var sessionIdField = Decoder.ReadInt32(ref buffer);
            var responsesField = Decoder.ReadArray<FetchableTopicResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => FetchableTopicResponseSerde.ReadV08(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField
            );
        }
        private static Memory<byte> WriteV08(Memory<byte> buffer, FetchResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteInt32(buffer, message.SessionIdField);
            buffer = Encoder.WriteArray<FetchableTopicResponse>(buffer, message.ResponsesField, (b, i) => FetchableTopicResponseSerde.WriteV08(b, i));
            return buffer;
        }
        private static FetchResponse ReadV09(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var sessionIdField = Decoder.ReadInt32(ref buffer);
            var responsesField = Decoder.ReadArray<FetchableTopicResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => FetchableTopicResponseSerde.ReadV09(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField
            );
        }
        private static Memory<byte> WriteV09(Memory<byte> buffer, FetchResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteInt32(buffer, message.SessionIdField);
            buffer = Encoder.WriteArray<FetchableTopicResponse>(buffer, message.ResponsesField, (b, i) => FetchableTopicResponseSerde.WriteV09(b, i));
            return buffer;
        }
        private static FetchResponse ReadV10(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var sessionIdField = Decoder.ReadInt32(ref buffer);
            var responsesField = Decoder.ReadArray<FetchableTopicResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => FetchableTopicResponseSerde.ReadV10(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField
            );
        }
        private static Memory<byte> WriteV10(Memory<byte> buffer, FetchResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteInt32(buffer, message.SessionIdField);
            buffer = Encoder.WriteArray<FetchableTopicResponse>(buffer, message.ResponsesField, (b, i) => FetchableTopicResponseSerde.WriteV10(b, i));
            return buffer;
        }
        private static FetchResponse ReadV11(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var sessionIdField = Decoder.ReadInt32(ref buffer);
            var responsesField = Decoder.ReadArray<FetchableTopicResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => FetchableTopicResponseSerde.ReadV11(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField
            );
        }
        private static Memory<byte> WriteV11(Memory<byte> buffer, FetchResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteInt32(buffer, message.SessionIdField);
            buffer = Encoder.WriteArray<FetchableTopicResponse>(buffer, message.ResponsesField, (b, i) => FetchableTopicResponseSerde.WriteV11(b, i));
            return buffer;
        }
        private static FetchResponse ReadV12(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var sessionIdField = Decoder.ReadInt32(ref buffer);
            var responsesField = Decoder.ReadCompactArray<FetchableTopicResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => FetchableTopicResponseSerde.ReadV12(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField
            );
        }
        private static Memory<byte> WriteV12(Memory<byte> buffer, FetchResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteInt32(buffer, message.SessionIdField);
            buffer = Encoder.WriteCompactArray<FetchableTopicResponse>(buffer, message.ResponsesField, (b, i) => FetchableTopicResponseSerde.WriteV12(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static FetchResponse ReadV13(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var sessionIdField = Decoder.ReadInt32(ref buffer);
            var responsesField = Decoder.ReadCompactArray<FetchableTopicResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => FetchableTopicResponseSerde.ReadV13(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField
            );
        }
        private static Memory<byte> WriteV13(Memory<byte> buffer, FetchResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteInt32(buffer, message.SessionIdField);
            buffer = Encoder.WriteCompactArray<FetchableTopicResponse>(buffer, message.ResponsesField, (b, i) => FetchableTopicResponseSerde.WriteV13(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class FetchableTopicResponseSerde
        {
            public static FetchableTopicResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<PartitionData>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionDataSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, FetchableTopicResponse message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicField);
                buffer = Encoder.WriteArray<PartitionData>(buffer, message.PartitionsField, (b, i) => PartitionDataSerde.WriteV00(b, i));
                return buffer;
            }
            public static FetchableTopicResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<PartitionData>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionDataSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, FetchableTopicResponse message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicField);
                buffer = Encoder.WriteArray<PartitionData>(buffer, message.PartitionsField, (b, i) => PartitionDataSerde.WriteV01(b, i));
                return buffer;
            }
            public static FetchableTopicResponse ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<PartitionData>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionDataSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, FetchableTopicResponse message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicField);
                buffer = Encoder.WriteArray<PartitionData>(buffer, message.PartitionsField, (b, i) => PartitionDataSerde.WriteV02(b, i));
                return buffer;
            }
            public static FetchableTopicResponse ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<PartitionData>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionDataSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, FetchableTopicResponse message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicField);
                buffer = Encoder.WriteArray<PartitionData>(buffer, message.PartitionsField, (b, i) => PartitionDataSerde.WriteV03(b, i));
                return buffer;
            }
            public static FetchableTopicResponse ReadV04(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<PartitionData>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionDataSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV04(Memory<byte> buffer, FetchableTopicResponse message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicField);
                buffer = Encoder.WriteArray<PartitionData>(buffer, message.PartitionsField, (b, i) => PartitionDataSerde.WriteV04(b, i));
                return buffer;
            }
            public static FetchableTopicResponse ReadV05(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<PartitionData>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionDataSerde.ReadV05(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV05(Memory<byte> buffer, FetchableTopicResponse message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicField);
                buffer = Encoder.WriteArray<PartitionData>(buffer, message.PartitionsField, (b, i) => PartitionDataSerde.WriteV05(b, i));
                return buffer;
            }
            public static FetchableTopicResponse ReadV06(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<PartitionData>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionDataSerde.ReadV06(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV06(Memory<byte> buffer, FetchableTopicResponse message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicField);
                buffer = Encoder.WriteArray<PartitionData>(buffer, message.PartitionsField, (b, i) => PartitionDataSerde.WriteV06(b, i));
                return buffer;
            }
            public static FetchableTopicResponse ReadV07(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<PartitionData>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionDataSerde.ReadV07(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV07(Memory<byte> buffer, FetchableTopicResponse message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicField);
                buffer = Encoder.WriteArray<PartitionData>(buffer, message.PartitionsField, (b, i) => PartitionDataSerde.WriteV07(b, i));
                return buffer;
            }
            public static FetchableTopicResponse ReadV08(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<PartitionData>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionDataSerde.ReadV08(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV08(Memory<byte> buffer, FetchableTopicResponse message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicField);
                buffer = Encoder.WriteArray<PartitionData>(buffer, message.PartitionsField, (b, i) => PartitionDataSerde.WriteV08(b, i));
                return buffer;
            }
            public static FetchableTopicResponse ReadV09(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<PartitionData>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionDataSerde.ReadV09(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV09(Memory<byte> buffer, FetchableTopicResponse message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicField);
                buffer = Encoder.WriteArray<PartitionData>(buffer, message.PartitionsField, (b, i) => PartitionDataSerde.WriteV09(b, i));
                return buffer;
            }
            public static FetchableTopicResponse ReadV10(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<PartitionData>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionDataSerde.ReadV10(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV10(Memory<byte> buffer, FetchableTopicResponse message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicField);
                buffer = Encoder.WriteArray<PartitionData>(buffer, message.PartitionsField, (b, i) => PartitionDataSerde.WriteV10(b, i));
                return buffer;
            }
            public static FetchableTopicResponse ReadV11(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<PartitionData>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionDataSerde.ReadV11(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV11(Memory<byte> buffer, FetchableTopicResponse message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicField);
                buffer = Encoder.WriteArray<PartitionData>(buffer, message.PartitionsField, (b, i) => PartitionDataSerde.WriteV11(b, i));
                return buffer;
            }
            public static FetchableTopicResponse ReadV12(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadCompactString(ref buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadCompactArray<PartitionData>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionDataSerde.ReadV12(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV12(Memory<byte> buffer, FetchableTopicResponse message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.TopicField);
                buffer = Encoder.WriteCompactArray<PartitionData>(buffer, message.PartitionsField, (b, i) => PartitionDataSerde.WriteV12(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static FetchableTopicResponse ReadV13(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = "";
                var topicIdField = Decoder.ReadUuid(ref buffer);
                var partitionsField = Decoder.ReadCompactArray<PartitionData>(ref buffer, (ref ReadOnlyMemory<byte> b) => PartitionDataSerde.ReadV13(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV13(Memory<byte> buffer, FetchableTopicResponse message)
            {
                buffer = Encoder.WriteUuid(buffer, message.TopicIdField);
                buffer = Encoder.WriteCompactArray<PartitionData>(buffer, message.PartitionsField, (b, i) => PartitionDataSerde.WriteV13(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class PartitionDataSerde
            {
                public static PartitionData ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var highWatermarkField = Decoder.ReadInt64(ref buffer);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = ImmutableArray<AbortedTransaction>.Empty;
                    var preferredReadReplicaField = default(int);
                    var recordsField = Decoder.ReadRecords(ref buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
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
                public static Memory<byte> WriteV00(Memory<byte> buffer, PartitionData message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt64(buffer, message.HighWatermarkField);
                    buffer = Encoder.WriteRecords(buffer, message.RecordsField);
                    return buffer;
                }
                public static PartitionData ReadV01(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var highWatermarkField = Decoder.ReadInt64(ref buffer);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = ImmutableArray<AbortedTransaction>.Empty;
                    var preferredReadReplicaField = default(int);
                    var recordsField = Decoder.ReadRecords(ref buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
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
                public static Memory<byte> WriteV01(Memory<byte> buffer, PartitionData message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt64(buffer, message.HighWatermarkField);
                    buffer = Encoder.WriteRecords(buffer, message.RecordsField);
                    return buffer;
                }
                public static PartitionData ReadV02(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var highWatermarkField = Decoder.ReadInt64(ref buffer);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = ImmutableArray<AbortedTransaction>.Empty;
                    var preferredReadReplicaField = default(int);
                    var recordsField = Decoder.ReadRecords(ref buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
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
                public static Memory<byte> WriteV02(Memory<byte> buffer, PartitionData message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt64(buffer, message.HighWatermarkField);
                    buffer = Encoder.WriteRecords(buffer, message.RecordsField);
                    return buffer;
                }
                public static PartitionData ReadV03(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var highWatermarkField = Decoder.ReadInt64(ref buffer);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = ImmutableArray<AbortedTransaction>.Empty;
                    var preferredReadReplicaField = default(int);
                    var recordsField = Decoder.ReadRecords(ref buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
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
                public static Memory<byte> WriteV03(Memory<byte> buffer, PartitionData message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt64(buffer, message.HighWatermarkField);
                    buffer = Encoder.WriteRecords(buffer, message.RecordsField);
                    return buffer;
                }
                public static PartitionData ReadV04(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var highWatermarkField = Decoder.ReadInt64(ref buffer);
                    var lastStableOffsetField = Decoder.ReadInt64(ref buffer);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = Decoder.ReadArray<AbortedTransaction>(ref buffer, (ref ReadOnlyMemory<byte> b) => AbortedTransactionSerde.ReadV04(ref b));
                    var preferredReadReplicaField = default(int);
                    var recordsField = Decoder.ReadRecords(ref buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
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
                public static Memory<byte> WriteV04(Memory<byte> buffer, PartitionData message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt64(buffer, message.HighWatermarkField);
                    buffer = Encoder.WriteInt64(buffer, message.LastStableOffsetField);
                    buffer = Encoder.WriteArray<AbortedTransaction>(buffer, message.AbortedTransactionsField, (b, i) => AbortedTransactionSerde.WriteV04(b, i));
                    buffer = Encoder.WriteRecords(buffer, message.RecordsField);
                    return buffer;
                }
                public static PartitionData ReadV05(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var highWatermarkField = Decoder.ReadInt64(ref buffer);
                    var lastStableOffsetField = Decoder.ReadInt64(ref buffer);
                    var logStartOffsetField = Decoder.ReadInt64(ref buffer);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = Decoder.ReadArray<AbortedTransaction>(ref buffer, (ref ReadOnlyMemory<byte> b) => AbortedTransactionSerde.ReadV05(ref b));
                    var preferredReadReplicaField = default(int);
                    var recordsField = Decoder.ReadRecords(ref buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
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
                public static Memory<byte> WriteV05(Memory<byte> buffer, PartitionData message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt64(buffer, message.HighWatermarkField);
                    buffer = Encoder.WriteInt64(buffer, message.LastStableOffsetField);
                    buffer = Encoder.WriteInt64(buffer, message.LogStartOffsetField);
                    buffer = Encoder.WriteArray<AbortedTransaction>(buffer, message.AbortedTransactionsField, (b, i) => AbortedTransactionSerde.WriteV05(b, i));
                    buffer = Encoder.WriteRecords(buffer, message.RecordsField);
                    return buffer;
                }
                public static PartitionData ReadV06(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var highWatermarkField = Decoder.ReadInt64(ref buffer);
                    var lastStableOffsetField = Decoder.ReadInt64(ref buffer);
                    var logStartOffsetField = Decoder.ReadInt64(ref buffer);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = Decoder.ReadArray<AbortedTransaction>(ref buffer, (ref ReadOnlyMemory<byte> b) => AbortedTransactionSerde.ReadV06(ref b));
                    var preferredReadReplicaField = default(int);
                    var recordsField = Decoder.ReadRecords(ref buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
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
                public static Memory<byte> WriteV06(Memory<byte> buffer, PartitionData message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt64(buffer, message.HighWatermarkField);
                    buffer = Encoder.WriteInt64(buffer, message.LastStableOffsetField);
                    buffer = Encoder.WriteInt64(buffer, message.LogStartOffsetField);
                    buffer = Encoder.WriteArray<AbortedTransaction>(buffer, message.AbortedTransactionsField, (b, i) => AbortedTransactionSerde.WriteV06(b, i));
                    buffer = Encoder.WriteRecords(buffer, message.RecordsField);
                    return buffer;
                }
                public static PartitionData ReadV07(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var highWatermarkField = Decoder.ReadInt64(ref buffer);
                    var lastStableOffsetField = Decoder.ReadInt64(ref buffer);
                    var logStartOffsetField = Decoder.ReadInt64(ref buffer);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = Decoder.ReadArray<AbortedTransaction>(ref buffer, (ref ReadOnlyMemory<byte> b) => AbortedTransactionSerde.ReadV07(ref b));
                    var preferredReadReplicaField = default(int);
                    var recordsField = Decoder.ReadRecords(ref buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
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
                public static Memory<byte> WriteV07(Memory<byte> buffer, PartitionData message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt64(buffer, message.HighWatermarkField);
                    buffer = Encoder.WriteInt64(buffer, message.LastStableOffsetField);
                    buffer = Encoder.WriteInt64(buffer, message.LogStartOffsetField);
                    buffer = Encoder.WriteArray<AbortedTransaction>(buffer, message.AbortedTransactionsField, (b, i) => AbortedTransactionSerde.WriteV07(b, i));
                    buffer = Encoder.WriteRecords(buffer, message.RecordsField);
                    return buffer;
                }
                public static PartitionData ReadV08(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var highWatermarkField = Decoder.ReadInt64(ref buffer);
                    var lastStableOffsetField = Decoder.ReadInt64(ref buffer);
                    var logStartOffsetField = Decoder.ReadInt64(ref buffer);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = Decoder.ReadArray<AbortedTransaction>(ref buffer, (ref ReadOnlyMemory<byte> b) => AbortedTransactionSerde.ReadV08(ref b));
                    var preferredReadReplicaField = default(int);
                    var recordsField = Decoder.ReadRecords(ref buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
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
                public static Memory<byte> WriteV08(Memory<byte> buffer, PartitionData message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt64(buffer, message.HighWatermarkField);
                    buffer = Encoder.WriteInt64(buffer, message.LastStableOffsetField);
                    buffer = Encoder.WriteInt64(buffer, message.LogStartOffsetField);
                    buffer = Encoder.WriteArray<AbortedTransaction>(buffer, message.AbortedTransactionsField, (b, i) => AbortedTransactionSerde.WriteV08(b, i));
                    buffer = Encoder.WriteRecords(buffer, message.RecordsField);
                    return buffer;
                }
                public static PartitionData ReadV09(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var highWatermarkField = Decoder.ReadInt64(ref buffer);
                    var lastStableOffsetField = Decoder.ReadInt64(ref buffer);
                    var logStartOffsetField = Decoder.ReadInt64(ref buffer);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = Decoder.ReadArray<AbortedTransaction>(ref buffer, (ref ReadOnlyMemory<byte> b) => AbortedTransactionSerde.ReadV09(ref b));
                    var preferredReadReplicaField = default(int);
                    var recordsField = Decoder.ReadRecords(ref buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
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
                public static Memory<byte> WriteV09(Memory<byte> buffer, PartitionData message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt64(buffer, message.HighWatermarkField);
                    buffer = Encoder.WriteInt64(buffer, message.LastStableOffsetField);
                    buffer = Encoder.WriteInt64(buffer, message.LogStartOffsetField);
                    buffer = Encoder.WriteArray<AbortedTransaction>(buffer, message.AbortedTransactionsField, (b, i) => AbortedTransactionSerde.WriteV09(b, i));
                    buffer = Encoder.WriteRecords(buffer, message.RecordsField);
                    return buffer;
                }
                public static PartitionData ReadV10(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var highWatermarkField = Decoder.ReadInt64(ref buffer);
                    var lastStableOffsetField = Decoder.ReadInt64(ref buffer);
                    var logStartOffsetField = Decoder.ReadInt64(ref buffer);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = Decoder.ReadArray<AbortedTransaction>(ref buffer, (ref ReadOnlyMemory<byte> b) => AbortedTransactionSerde.ReadV10(ref b));
                    var preferredReadReplicaField = default(int);
                    var recordsField = Decoder.ReadRecords(ref buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
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
                public static Memory<byte> WriteV10(Memory<byte> buffer, PartitionData message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt64(buffer, message.HighWatermarkField);
                    buffer = Encoder.WriteInt64(buffer, message.LastStableOffsetField);
                    buffer = Encoder.WriteInt64(buffer, message.LogStartOffsetField);
                    buffer = Encoder.WriteArray<AbortedTransaction>(buffer, message.AbortedTransactionsField, (b, i) => AbortedTransactionSerde.WriteV10(b, i));
                    buffer = Encoder.WriteRecords(buffer, message.RecordsField);
                    return buffer;
                }
                public static PartitionData ReadV11(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var highWatermarkField = Decoder.ReadInt64(ref buffer);
                    var lastStableOffsetField = Decoder.ReadInt64(ref buffer);
                    var logStartOffsetField = Decoder.ReadInt64(ref buffer);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = Decoder.ReadArray<AbortedTransaction>(ref buffer, (ref ReadOnlyMemory<byte> b) => AbortedTransactionSerde.ReadV11(ref b));
                    var preferredReadReplicaField = Decoder.ReadInt32(ref buffer);
                    var recordsField = Decoder.ReadRecords(ref buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
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
                public static Memory<byte> WriteV11(Memory<byte> buffer, PartitionData message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt64(buffer, message.HighWatermarkField);
                    buffer = Encoder.WriteInt64(buffer, message.LastStableOffsetField);
                    buffer = Encoder.WriteInt64(buffer, message.LogStartOffsetField);
                    buffer = Encoder.WriteArray<AbortedTransaction>(buffer, message.AbortedTransactionsField, (b, i) => AbortedTransactionSerde.WriteV11(b, i));
                    buffer = Encoder.WriteInt32(buffer, message.PreferredReadReplicaField);
                    buffer = Encoder.WriteRecords(buffer, message.RecordsField);
                    return buffer;
                }
                public static PartitionData ReadV12(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var highWatermarkField = Decoder.ReadInt64(ref buffer);
                    var lastStableOffsetField = Decoder.ReadInt64(ref buffer);
                    var logStartOffsetField = Decoder.ReadInt64(ref buffer);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = Decoder.ReadCompactArray<AbortedTransaction>(ref buffer, (ref ReadOnlyMemory<byte> b) => AbortedTransactionSerde.ReadV12(ref b));
                    var preferredReadReplicaField = Decoder.ReadInt32(ref buffer);
                    var recordsField = Decoder.ReadRecords(ref buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
                    _ = Decoder.ReadVarUInt32(ref buffer);
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
                public static Memory<byte> WriteV12(Memory<byte> buffer, PartitionData message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt64(buffer, message.HighWatermarkField);
                    buffer = Encoder.WriteInt64(buffer, message.LastStableOffsetField);
                    buffer = Encoder.WriteInt64(buffer, message.LogStartOffsetField);
                    buffer = EpochEndOffsetSerde.WriteV12(buffer, message.DivergingEpochField);
                    buffer = LeaderIdAndEpochSerde.WriteV12(buffer, message.CurrentLeaderField);
                    buffer = SnapshotIdSerde.WriteV12(buffer, message.SnapshotIdField);
                    buffer = Encoder.WriteCompactArray<AbortedTransaction>(buffer, message.AbortedTransactionsField, (b, i) => AbortedTransactionSerde.WriteV12(b, i));
                    buffer = Encoder.WriteInt32(buffer, message.PreferredReadReplicaField);
                    buffer = Encoder.WriteCompactRecords(buffer, message.RecordsField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
                public static PartitionData ReadV13(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionIndexField = Decoder.ReadInt32(ref buffer);
                    var errorCodeField = Decoder.ReadInt16(ref buffer);
                    var highWatermarkField = Decoder.ReadInt64(ref buffer);
                    var lastStableOffsetField = Decoder.ReadInt64(ref buffer);
                    var logStartOffsetField = Decoder.ReadInt64(ref buffer);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = Decoder.ReadCompactArray<AbortedTransaction>(ref buffer, (ref ReadOnlyMemory<byte> b) => AbortedTransactionSerde.ReadV13(ref b));
                    var preferredReadReplicaField = Decoder.ReadInt32(ref buffer);
                    var recordsField = Decoder.ReadRecords(ref buffer) ?? throw new NullReferenceException("Null not allowed for 'Records'");
                    _ = Decoder.ReadVarUInt32(ref buffer);
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
                public static Memory<byte> WriteV13(Memory<byte> buffer, PartitionData message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionIndexField);
                    buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                    buffer = Encoder.WriteInt64(buffer, message.HighWatermarkField);
                    buffer = Encoder.WriteInt64(buffer, message.LastStableOffsetField);
                    buffer = Encoder.WriteInt64(buffer, message.LogStartOffsetField);
                    buffer = EpochEndOffsetSerde.WriteV13(buffer, message.DivergingEpochField);
                    buffer = LeaderIdAndEpochSerde.WriteV13(buffer, message.CurrentLeaderField);
                    buffer = SnapshotIdSerde.WriteV13(buffer, message.SnapshotIdField);
                    buffer = Encoder.WriteCompactArray<AbortedTransaction>(buffer, message.AbortedTransactionsField, (b, i) => AbortedTransactionSerde.WriteV13(b, i));
                    buffer = Encoder.WriteInt32(buffer, message.PreferredReadReplicaField);
                    buffer = Encoder.WriteCompactRecords(buffer, message.RecordsField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
                private static class SnapshotIdSerde
                {
                    public static SnapshotId ReadV12(ref ReadOnlyMemory<byte> buffer)
                    {
                        var endOffsetField = Decoder.ReadInt64(ref buffer);
                        var epochField = Decoder.ReadInt32(ref buffer);
                        _ = Decoder.ReadVarUInt32(ref buffer);
                        return new(
                            endOffsetField,
                            epochField
                        );
                    }
                    public static Memory<byte> WriteV12(Memory<byte> buffer, SnapshotId message)
                    {
                        buffer = Encoder.WriteInt64(buffer, message.EndOffsetField);
                        buffer = Encoder.WriteInt32(buffer, message.EpochField);
                        buffer = Encoder.WriteVarUInt32(buffer, 0);
                        return buffer;
                    }
                    public static SnapshotId ReadV13(ref ReadOnlyMemory<byte> buffer)
                    {
                        var endOffsetField = Decoder.ReadInt64(ref buffer);
                        var epochField = Decoder.ReadInt32(ref buffer);
                        _ = Decoder.ReadVarUInt32(ref buffer);
                        return new(
                            endOffsetField,
                            epochField
                        );
                    }
                    public static Memory<byte> WriteV13(Memory<byte> buffer, SnapshotId message)
                    {
                        buffer = Encoder.WriteInt64(buffer, message.EndOffsetField);
                        buffer = Encoder.WriteInt32(buffer, message.EpochField);
                        buffer = Encoder.WriteVarUInt32(buffer, 0);
                        return buffer;
                    }
                }
                private static class EpochEndOffsetSerde
                {
                    public static EpochEndOffset ReadV12(ref ReadOnlyMemory<byte> buffer)
                    {
                        var epochField = Decoder.ReadInt32(ref buffer);
                        var endOffsetField = Decoder.ReadInt64(ref buffer);
                        _ = Decoder.ReadVarUInt32(ref buffer);
                        return new(
                            epochField,
                            endOffsetField
                        );
                    }
                    public static Memory<byte> WriteV12(Memory<byte> buffer, EpochEndOffset message)
                    {
                        buffer = Encoder.WriteInt32(buffer, message.EpochField);
                        buffer = Encoder.WriteInt64(buffer, message.EndOffsetField);
                        buffer = Encoder.WriteVarUInt32(buffer, 0);
                        return buffer;
                    }
                    public static EpochEndOffset ReadV13(ref ReadOnlyMemory<byte> buffer)
                    {
                        var epochField = Decoder.ReadInt32(ref buffer);
                        var endOffsetField = Decoder.ReadInt64(ref buffer);
                        _ = Decoder.ReadVarUInt32(ref buffer);
                        return new(
                            epochField,
                            endOffsetField
                        );
                    }
                    public static Memory<byte> WriteV13(Memory<byte> buffer, EpochEndOffset message)
                    {
                        buffer = Encoder.WriteInt32(buffer, message.EpochField);
                        buffer = Encoder.WriteInt64(buffer, message.EndOffsetField);
                        buffer = Encoder.WriteVarUInt32(buffer, 0);
                        return buffer;
                    }
                }
                private static class LeaderIdAndEpochSerde
                {
                    public static LeaderIdAndEpoch ReadV12(ref ReadOnlyMemory<byte> buffer)
                    {
                        var leaderIdField = Decoder.ReadInt32(ref buffer);
                        var leaderEpochField = Decoder.ReadInt32(ref buffer);
                        _ = Decoder.ReadVarUInt32(ref buffer);
                        return new(
                            leaderIdField,
                            leaderEpochField
                        );
                    }
                    public static Memory<byte> WriteV12(Memory<byte> buffer, LeaderIdAndEpoch message)
                    {
                        buffer = Encoder.WriteInt32(buffer, message.LeaderIdField);
                        buffer = Encoder.WriteInt32(buffer, message.LeaderEpochField);
                        buffer = Encoder.WriteVarUInt32(buffer, 0);
                        return buffer;
                    }
                    public static LeaderIdAndEpoch ReadV13(ref ReadOnlyMemory<byte> buffer)
                    {
                        var leaderIdField = Decoder.ReadInt32(ref buffer);
                        var leaderEpochField = Decoder.ReadInt32(ref buffer);
                        _ = Decoder.ReadVarUInt32(ref buffer);
                        return new(
                            leaderIdField,
                            leaderEpochField
                        );
                    }
                    public static Memory<byte> WriteV13(Memory<byte> buffer, LeaderIdAndEpoch message)
                    {
                        buffer = Encoder.WriteInt32(buffer, message.LeaderIdField);
                        buffer = Encoder.WriteInt32(buffer, message.LeaderEpochField);
                        buffer = Encoder.WriteVarUInt32(buffer, 0);
                        return buffer;
                    }
                }
                private static class AbortedTransactionSerde
                {
                    public static AbortedTransaction ReadV04(ref ReadOnlyMemory<byte> buffer)
                    {
                        var producerIdField = Decoder.ReadInt64(ref buffer);
                        var firstOffsetField = Decoder.ReadInt64(ref buffer);
                        return new(
                            producerIdField,
                            firstOffsetField
                        );
                    }
                    public static Memory<byte> WriteV04(Memory<byte> buffer, AbortedTransaction message)
                    {
                        buffer = Encoder.WriteInt64(buffer, message.ProducerIdField);
                        buffer = Encoder.WriteInt64(buffer, message.FirstOffsetField);
                        return buffer;
                    }
                    public static AbortedTransaction ReadV05(ref ReadOnlyMemory<byte> buffer)
                    {
                        var producerIdField = Decoder.ReadInt64(ref buffer);
                        var firstOffsetField = Decoder.ReadInt64(ref buffer);
                        return new(
                            producerIdField,
                            firstOffsetField
                        );
                    }
                    public static Memory<byte> WriteV05(Memory<byte> buffer, AbortedTransaction message)
                    {
                        buffer = Encoder.WriteInt64(buffer, message.ProducerIdField);
                        buffer = Encoder.WriteInt64(buffer, message.FirstOffsetField);
                        return buffer;
                    }
                    public static AbortedTransaction ReadV06(ref ReadOnlyMemory<byte> buffer)
                    {
                        var producerIdField = Decoder.ReadInt64(ref buffer);
                        var firstOffsetField = Decoder.ReadInt64(ref buffer);
                        return new(
                            producerIdField,
                            firstOffsetField
                        );
                    }
                    public static Memory<byte> WriteV06(Memory<byte> buffer, AbortedTransaction message)
                    {
                        buffer = Encoder.WriteInt64(buffer, message.ProducerIdField);
                        buffer = Encoder.WriteInt64(buffer, message.FirstOffsetField);
                        return buffer;
                    }
                    public static AbortedTransaction ReadV07(ref ReadOnlyMemory<byte> buffer)
                    {
                        var producerIdField = Decoder.ReadInt64(ref buffer);
                        var firstOffsetField = Decoder.ReadInt64(ref buffer);
                        return new(
                            producerIdField,
                            firstOffsetField
                        );
                    }
                    public static Memory<byte> WriteV07(Memory<byte> buffer, AbortedTransaction message)
                    {
                        buffer = Encoder.WriteInt64(buffer, message.ProducerIdField);
                        buffer = Encoder.WriteInt64(buffer, message.FirstOffsetField);
                        return buffer;
                    }
                    public static AbortedTransaction ReadV08(ref ReadOnlyMemory<byte> buffer)
                    {
                        var producerIdField = Decoder.ReadInt64(ref buffer);
                        var firstOffsetField = Decoder.ReadInt64(ref buffer);
                        return new(
                            producerIdField,
                            firstOffsetField
                        );
                    }
                    public static Memory<byte> WriteV08(Memory<byte> buffer, AbortedTransaction message)
                    {
                        buffer = Encoder.WriteInt64(buffer, message.ProducerIdField);
                        buffer = Encoder.WriteInt64(buffer, message.FirstOffsetField);
                        return buffer;
                    }
                    public static AbortedTransaction ReadV09(ref ReadOnlyMemory<byte> buffer)
                    {
                        var producerIdField = Decoder.ReadInt64(ref buffer);
                        var firstOffsetField = Decoder.ReadInt64(ref buffer);
                        return new(
                            producerIdField,
                            firstOffsetField
                        );
                    }
                    public static Memory<byte> WriteV09(Memory<byte> buffer, AbortedTransaction message)
                    {
                        buffer = Encoder.WriteInt64(buffer, message.ProducerIdField);
                        buffer = Encoder.WriteInt64(buffer, message.FirstOffsetField);
                        return buffer;
                    }
                    public static AbortedTransaction ReadV10(ref ReadOnlyMemory<byte> buffer)
                    {
                        var producerIdField = Decoder.ReadInt64(ref buffer);
                        var firstOffsetField = Decoder.ReadInt64(ref buffer);
                        return new(
                            producerIdField,
                            firstOffsetField
                        );
                    }
                    public static Memory<byte> WriteV10(Memory<byte> buffer, AbortedTransaction message)
                    {
                        buffer = Encoder.WriteInt64(buffer, message.ProducerIdField);
                        buffer = Encoder.WriteInt64(buffer, message.FirstOffsetField);
                        return buffer;
                    }
                    public static AbortedTransaction ReadV11(ref ReadOnlyMemory<byte> buffer)
                    {
                        var producerIdField = Decoder.ReadInt64(ref buffer);
                        var firstOffsetField = Decoder.ReadInt64(ref buffer);
                        return new(
                            producerIdField,
                            firstOffsetField
                        );
                    }
                    public static Memory<byte> WriteV11(Memory<byte> buffer, AbortedTransaction message)
                    {
                        buffer = Encoder.WriteInt64(buffer, message.ProducerIdField);
                        buffer = Encoder.WriteInt64(buffer, message.FirstOffsetField);
                        return buffer;
                    }
                    public static AbortedTransaction ReadV12(ref ReadOnlyMemory<byte> buffer)
                    {
                        var producerIdField = Decoder.ReadInt64(ref buffer);
                        var firstOffsetField = Decoder.ReadInt64(ref buffer);
                        _ = Decoder.ReadVarUInt32(ref buffer);
                        return new(
                            producerIdField,
                            firstOffsetField
                        );
                    }
                    public static Memory<byte> WriteV12(Memory<byte> buffer, AbortedTransaction message)
                    {
                        buffer = Encoder.WriteInt64(buffer, message.ProducerIdField);
                        buffer = Encoder.WriteInt64(buffer, message.FirstOffsetField);
                        buffer = Encoder.WriteVarUInt32(buffer, 0);
                        return buffer;
                    }
                    public static AbortedTransaction ReadV13(ref ReadOnlyMemory<byte> buffer)
                    {
                        var producerIdField = Decoder.ReadInt64(ref buffer);
                        var firstOffsetField = Decoder.ReadInt64(ref buffer);
                        _ = Decoder.ReadVarUInt32(ref buffer);
                        return new(
                            producerIdField,
                            firstOffsetField
                        );
                    }
                    public static Memory<byte> WriteV13(Memory<byte> buffer, AbortedTransaction message)
                    {
                        buffer = Encoder.WriteInt64(buffer, message.ProducerIdField);
                        buffer = Encoder.WriteInt64(buffer, message.FirstOffsetField);
                        buffer = Encoder.WriteVarUInt32(buffer, 0);
                        return buffer;
                    }
                }
            }
        }
    }
}