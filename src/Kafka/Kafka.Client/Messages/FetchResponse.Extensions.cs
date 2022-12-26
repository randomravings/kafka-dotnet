using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using Kafka.Common.Records;
using FetchableTopicResponse = Kafka.Client.Messages.FetchResponse.FetchableTopicResponse;
using PartitionData = Kafka.Client.Messages.FetchResponse.FetchableTopicResponse.PartitionData;
using SnapshotId = Kafka.Client.Messages.FetchResponse.FetchableTopicResponse.PartitionData.SnapshotId;
using AbortedTransaction = Kafka.Client.Messages.FetchResponse.FetchableTopicResponse.PartitionData.AbortedTransaction;
using LeaderIdAndEpoch = Kafka.Client.Messages.FetchResponse.FetchableTopicResponse.PartitionData.LeaderIdAndEpoch;
using EpochEndOffset = Kafka.Client.Messages.FetchResponse.FetchableTopicResponse.PartitionData.EpochEndOffset;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class FetchResponseSerde
    {
        private static readonly DecodeDelegate<FetchResponse>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
            ReadV04,
            ReadV05,
            ReadV06,
            ReadV07,
            ReadV08,
            ReadV09,
            ReadV10,
            ReadV11,
            ReadV12,
            ReadV13,
        };
        private static readonly EncodeDelegate<FetchResponse>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
            WriteV04,
            WriteV05,
            WriteV06,
            WriteV07,
            WriteV08,
            WriteV09,
            WriteV10,
            WriteV11,
            WriteV12,
            WriteV13,
        };
        public static FetchResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, FetchResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static FetchResponse ReadV00(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = Decoder.ReadArray<FetchableTopicResponse>(buffer, ref index, FetchableTopicResponseSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField
            );
        }
        private static int WriteV00(byte[] buffer, int index, FetchResponse message)
        {
            index = Encoder.WriteArray<FetchableTopicResponse>(buffer, index, message.ResponsesField, FetchableTopicResponseSerde.WriteV00);
            return index;
        }
        private static FetchResponse ReadV01(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = Decoder.ReadArray<FetchableTopicResponse>(buffer, ref index, FetchableTopicResponseSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField
            );
        }
        private static int WriteV01(byte[] buffer, int index, FetchResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<FetchableTopicResponse>(buffer, index, message.ResponsesField, FetchableTopicResponseSerde.WriteV01);
            return index;
        }
        private static FetchResponse ReadV02(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = Decoder.ReadArray<FetchableTopicResponse>(buffer, ref index, FetchableTopicResponseSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField
            );
        }
        private static int WriteV02(byte[] buffer, int index, FetchResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<FetchableTopicResponse>(buffer, index, message.ResponsesField, FetchableTopicResponseSerde.WriteV02);
            return index;
        }
        private static FetchResponse ReadV03(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = Decoder.ReadArray<FetchableTopicResponse>(buffer, ref index, FetchableTopicResponseSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField
            );
        }
        private static int WriteV03(byte[] buffer, int index, FetchResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<FetchableTopicResponse>(buffer, index, message.ResponsesField, FetchableTopicResponseSerde.WriteV03);
            return index;
        }
        private static FetchResponse ReadV04(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = Decoder.ReadArray<FetchableTopicResponse>(buffer, ref index, FetchableTopicResponseSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField
            );
        }
        private static int WriteV04(byte[] buffer, int index, FetchResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<FetchableTopicResponse>(buffer, index, message.ResponsesField, FetchableTopicResponseSerde.WriteV04);
            return index;
        }
        private static FetchResponse ReadV05(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = Decoder.ReadArray<FetchableTopicResponse>(buffer, ref index, FetchableTopicResponseSerde.ReadV05) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField
            );
        }
        private static int WriteV05(byte[] buffer, int index, FetchResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<FetchableTopicResponse>(buffer, index, message.ResponsesField, FetchableTopicResponseSerde.WriteV05);
            return index;
        }
        private static FetchResponse ReadV06(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = Decoder.ReadArray<FetchableTopicResponse>(buffer, ref index, FetchableTopicResponseSerde.ReadV06) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField
            );
        }
        private static int WriteV06(byte[] buffer, int index, FetchResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<FetchableTopicResponse>(buffer, index, message.ResponsesField, FetchableTopicResponseSerde.WriteV06);
            return index;
        }
        private static FetchResponse ReadV07(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var sessionIdField = Decoder.ReadInt32(buffer, ref index);
            var responsesField = Decoder.ReadArray<FetchableTopicResponse>(buffer, ref index, FetchableTopicResponseSerde.ReadV07) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField
            );
        }
        private static int WriteV07(byte[] buffer, int index, FetchResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteInt32(buffer, index, message.SessionIdField);
            index = Encoder.WriteArray<FetchableTopicResponse>(buffer, index, message.ResponsesField, FetchableTopicResponseSerde.WriteV07);
            return index;
        }
        private static FetchResponse ReadV08(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var sessionIdField = Decoder.ReadInt32(buffer, ref index);
            var responsesField = Decoder.ReadArray<FetchableTopicResponse>(buffer, ref index, FetchableTopicResponseSerde.ReadV08) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField
            );
        }
        private static int WriteV08(byte[] buffer, int index, FetchResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteInt32(buffer, index, message.SessionIdField);
            index = Encoder.WriteArray<FetchableTopicResponse>(buffer, index, message.ResponsesField, FetchableTopicResponseSerde.WriteV08);
            return index;
        }
        private static FetchResponse ReadV09(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var sessionIdField = Decoder.ReadInt32(buffer, ref index);
            var responsesField = Decoder.ReadArray<FetchableTopicResponse>(buffer, ref index, FetchableTopicResponseSerde.ReadV09) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField
            );
        }
        private static int WriteV09(byte[] buffer, int index, FetchResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteInt32(buffer, index, message.SessionIdField);
            index = Encoder.WriteArray<FetchableTopicResponse>(buffer, index, message.ResponsesField, FetchableTopicResponseSerde.WriteV09);
            return index;
        }
        private static FetchResponse ReadV10(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var sessionIdField = Decoder.ReadInt32(buffer, ref index);
            var responsesField = Decoder.ReadArray<FetchableTopicResponse>(buffer, ref index, FetchableTopicResponseSerde.ReadV10) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField
            );
        }
        private static int WriteV10(byte[] buffer, int index, FetchResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteInt32(buffer, index, message.SessionIdField);
            index = Encoder.WriteArray<FetchableTopicResponse>(buffer, index, message.ResponsesField, FetchableTopicResponseSerde.WriteV10);
            return index;
        }
        private static FetchResponse ReadV11(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var sessionIdField = Decoder.ReadInt32(buffer, ref index);
            var responsesField = Decoder.ReadArray<FetchableTopicResponse>(buffer, ref index, FetchableTopicResponseSerde.ReadV11) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField
            );
        }
        private static int WriteV11(byte[] buffer, int index, FetchResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteInt32(buffer, index, message.SessionIdField);
            index = Encoder.WriteArray<FetchableTopicResponse>(buffer, index, message.ResponsesField, FetchableTopicResponseSerde.WriteV11);
            return index;
        }
        private static FetchResponse ReadV12(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var sessionIdField = Decoder.ReadInt32(buffer, ref index);
            var responsesField = Decoder.ReadCompactArray<FetchableTopicResponse>(buffer, ref index, FetchableTopicResponseSerde.ReadV12) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField
            );
        }
        private static int WriteV12(byte[] buffer, int index, FetchResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteInt32(buffer, index, message.SessionIdField);
            index = Encoder.WriteCompactArray<FetchableTopicResponse>(buffer, index, message.ResponsesField, FetchableTopicResponseSerde.WriteV12);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static FetchResponse ReadV13(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var sessionIdField = Decoder.ReadInt32(buffer, ref index);
            var responsesField = Decoder.ReadCompactArray<FetchableTopicResponse>(buffer, ref index, FetchableTopicResponseSerde.ReadV13) ?? throw new NullReferenceException("Null not allowed for 'Responses'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField
            );
        }
        private static int WriteV13(byte[] buffer, int index, FetchResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteInt32(buffer, index, message.SessionIdField);
            index = Encoder.WriteCompactArray<FetchableTopicResponse>(buffer, index, message.ResponsesField, FetchableTopicResponseSerde.WriteV13);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class FetchableTopicResponseSerde
        {
            public static FetchableTopicResponse ReadV00(byte[] buffer, ref int index)
            {
                var TopicField = Decoder.ReadString(buffer, ref index);
                var TopicIdField = default(Guid);
                var PartitionsField = Decoder.ReadArray<PartitionData>(buffer, ref index, PartitionDataSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    TopicField,
                    TopicIdField,
                    PartitionsField
                );
            }
            public static int WriteV00(byte[] buffer, int index, FetchableTopicResponse message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicField);
                index = Encoder.WriteArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV00);
                return index;
            }
            public static FetchableTopicResponse ReadV01(byte[] buffer, ref int index)
            {
                var TopicField = Decoder.ReadString(buffer, ref index);
                var TopicIdField = default(Guid);
                var PartitionsField = Decoder.ReadArray<PartitionData>(buffer, ref index, PartitionDataSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    TopicField,
                    TopicIdField,
                    PartitionsField
                );
            }
            public static int WriteV01(byte[] buffer, int index, FetchableTopicResponse message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicField);
                index = Encoder.WriteArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV01);
                return index;
            }
            public static FetchableTopicResponse ReadV02(byte[] buffer, ref int index)
            {
                var TopicField = Decoder.ReadString(buffer, ref index);
                var TopicIdField = default(Guid);
                var PartitionsField = Decoder.ReadArray<PartitionData>(buffer, ref index, PartitionDataSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    TopicField,
                    TopicIdField,
                    PartitionsField
                );
            }
            public static int WriteV02(byte[] buffer, int index, FetchableTopicResponse message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicField);
                index = Encoder.WriteArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV02);
                return index;
            }
            public static FetchableTopicResponse ReadV03(byte[] buffer, ref int index)
            {
                var TopicField = Decoder.ReadString(buffer, ref index);
                var TopicIdField = default(Guid);
                var PartitionsField = Decoder.ReadArray<PartitionData>(buffer, ref index, PartitionDataSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    TopicField,
                    TopicIdField,
                    PartitionsField
                );
            }
            public static int WriteV03(byte[] buffer, int index, FetchableTopicResponse message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicField);
                index = Encoder.WriteArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV03);
                return index;
            }
            public static FetchableTopicResponse ReadV04(byte[] buffer, ref int index)
            {
                var TopicField = Decoder.ReadString(buffer, ref index);
                var TopicIdField = default(Guid);
                var PartitionsField = Decoder.ReadArray<PartitionData>(buffer, ref index, PartitionDataSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    TopicField,
                    TopicIdField,
                    PartitionsField
                );
            }
            public static int WriteV04(byte[] buffer, int index, FetchableTopicResponse message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicField);
                index = Encoder.WriteArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV04);
                return index;
            }
            public static FetchableTopicResponse ReadV05(byte[] buffer, ref int index)
            {
                var TopicField = Decoder.ReadString(buffer, ref index);
                var TopicIdField = default(Guid);
                var PartitionsField = Decoder.ReadArray<PartitionData>(buffer, ref index, PartitionDataSerde.ReadV05) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    TopicField,
                    TopicIdField,
                    PartitionsField
                );
            }
            public static int WriteV05(byte[] buffer, int index, FetchableTopicResponse message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicField);
                index = Encoder.WriteArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV05);
                return index;
            }
            public static FetchableTopicResponse ReadV06(byte[] buffer, ref int index)
            {
                var TopicField = Decoder.ReadString(buffer, ref index);
                var TopicIdField = default(Guid);
                var PartitionsField = Decoder.ReadArray<PartitionData>(buffer, ref index, PartitionDataSerde.ReadV06) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    TopicField,
                    TopicIdField,
                    PartitionsField
                );
            }
            public static int WriteV06(byte[] buffer, int index, FetchableTopicResponse message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicField);
                index = Encoder.WriteArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV06);
                return index;
            }
            public static FetchableTopicResponse ReadV07(byte[] buffer, ref int index)
            {
                var TopicField = Decoder.ReadString(buffer, ref index);
                var TopicIdField = default(Guid);
                var PartitionsField = Decoder.ReadArray<PartitionData>(buffer, ref index, PartitionDataSerde.ReadV07) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    TopicField,
                    TopicIdField,
                    PartitionsField
                );
            }
            public static int WriteV07(byte[] buffer, int index, FetchableTopicResponse message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicField);
                index = Encoder.WriteArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV07);
                return index;
            }
            public static FetchableTopicResponse ReadV08(byte[] buffer, ref int index)
            {
                var TopicField = Decoder.ReadString(buffer, ref index);
                var TopicIdField = default(Guid);
                var PartitionsField = Decoder.ReadArray<PartitionData>(buffer, ref index, PartitionDataSerde.ReadV08) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    TopicField,
                    TopicIdField,
                    PartitionsField
                );
            }
            public static int WriteV08(byte[] buffer, int index, FetchableTopicResponse message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicField);
                index = Encoder.WriteArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV08);
                return index;
            }
            public static FetchableTopicResponse ReadV09(byte[] buffer, ref int index)
            {
                var TopicField = Decoder.ReadString(buffer, ref index);
                var TopicIdField = default(Guid);
                var PartitionsField = Decoder.ReadArray<PartitionData>(buffer, ref index, PartitionDataSerde.ReadV09) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    TopicField,
                    TopicIdField,
                    PartitionsField
                );
            }
            public static int WriteV09(byte[] buffer, int index, FetchableTopicResponse message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicField);
                index = Encoder.WriteArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV09);
                return index;
            }
            public static FetchableTopicResponse ReadV10(byte[] buffer, ref int index)
            {
                var TopicField = Decoder.ReadString(buffer, ref index);
                var TopicIdField = default(Guid);
                var PartitionsField = Decoder.ReadArray<PartitionData>(buffer, ref index, PartitionDataSerde.ReadV10) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    TopicField,
                    TopicIdField,
                    PartitionsField
                );
            }
            public static int WriteV10(byte[] buffer, int index, FetchableTopicResponse message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicField);
                index = Encoder.WriteArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV10);
                return index;
            }
            public static FetchableTopicResponse ReadV11(byte[] buffer, ref int index)
            {
                var TopicField = Decoder.ReadString(buffer, ref index);
                var TopicIdField = default(Guid);
                var PartitionsField = Decoder.ReadArray<PartitionData>(buffer, ref index, PartitionDataSerde.ReadV11) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    TopicField,
                    TopicIdField,
                    PartitionsField
                );
            }
            public static int WriteV11(byte[] buffer, int index, FetchableTopicResponse message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicField);
                index = Encoder.WriteArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV11);
                return index;
            }
            public static FetchableTopicResponse ReadV12(byte[] buffer, ref int index)
            {
                var TopicField = Decoder.ReadCompactString(buffer, ref index);
                var TopicIdField = default(Guid);
                var PartitionsField = Decoder.ReadCompactArray<PartitionData>(buffer, ref index, PartitionDataSerde.ReadV12) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    TopicField,
                    TopicIdField,
                    PartitionsField
                );
            }
            public static int WriteV12(byte[] buffer, int index, FetchableTopicResponse message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.TopicField);
                index = Encoder.WriteCompactArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV12);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static FetchableTopicResponse ReadV13(byte[] buffer, ref int index)
            {
                var TopicField = "";
                var TopicIdField = Decoder.ReadUuid(buffer, ref index);
                var PartitionsField = Decoder.ReadCompactArray<PartitionData>(buffer, ref index, PartitionDataSerde.ReadV13) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    TopicField,
                    TopicIdField,
                    PartitionsField
                );
            }
            public static int WriteV13(byte[] buffer, int index, FetchableTopicResponse message)
            {
                index = Encoder.WriteUuid(buffer, index, message.TopicIdField);
                index = Encoder.WriteCompactArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV13);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class PartitionDataSerde
            {
                public static PartitionData ReadV00(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var HighWatermarkField = Decoder.ReadInt64(buffer, ref index);
                    var LastStableOffsetField = default(long);
                    var LogStartOffsetField = default(long);
                    var DivergingEpochField = EpochEndOffset.Empty;
                    var CurrentLeaderField = LeaderIdAndEpoch.Empty;
                    var SnapshotIdField = SnapshotId.Empty;
                    var AbortedTransactionsField = ImmutableArray<AbortedTransaction>.Empty;
                    var PreferredReadReplicaField = default(int);
                    var RecordsField = Decoder.ReadRecords(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        ErrorCodeField,
                        HighWatermarkField,
                        LastStableOffsetField,
                        LogStartOffsetField,
                        DivergingEpochField,
                        CurrentLeaderField,
                        SnapshotIdField,
                        AbortedTransactionsField,
                        PreferredReadReplicaField,
                        RecordsField
                    );
                }
                public static int WriteV00(byte[] buffer, int index, PartitionData message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt64(buffer, index, message.HighWatermarkField);
                    index = Encoder.WriteRecords(buffer, index, message.RecordsField);
                    return index;
                }
                public static PartitionData ReadV01(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var HighWatermarkField = Decoder.ReadInt64(buffer, ref index);
                    var LastStableOffsetField = default(long);
                    var LogStartOffsetField = default(long);
                    var DivergingEpochField = EpochEndOffset.Empty;
                    var CurrentLeaderField = LeaderIdAndEpoch.Empty;
                    var SnapshotIdField = SnapshotId.Empty;
                    var AbortedTransactionsField = ImmutableArray<AbortedTransaction>.Empty;
                    var PreferredReadReplicaField = default(int);
                    var RecordsField = Decoder.ReadRecords(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        ErrorCodeField,
                        HighWatermarkField,
                        LastStableOffsetField,
                        LogStartOffsetField,
                        DivergingEpochField,
                        CurrentLeaderField,
                        SnapshotIdField,
                        AbortedTransactionsField,
                        PreferredReadReplicaField,
                        RecordsField
                    );
                }
                public static int WriteV01(byte[] buffer, int index, PartitionData message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt64(buffer, index, message.HighWatermarkField);
                    index = Encoder.WriteRecords(buffer, index, message.RecordsField);
                    return index;
                }
                public static PartitionData ReadV02(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var HighWatermarkField = Decoder.ReadInt64(buffer, ref index);
                    var LastStableOffsetField = default(long);
                    var LogStartOffsetField = default(long);
                    var DivergingEpochField = EpochEndOffset.Empty;
                    var CurrentLeaderField = LeaderIdAndEpoch.Empty;
                    var SnapshotIdField = SnapshotId.Empty;
                    var AbortedTransactionsField = ImmutableArray<AbortedTransaction>.Empty;
                    var PreferredReadReplicaField = default(int);
                    var RecordsField = Decoder.ReadRecords(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        ErrorCodeField,
                        HighWatermarkField,
                        LastStableOffsetField,
                        LogStartOffsetField,
                        DivergingEpochField,
                        CurrentLeaderField,
                        SnapshotIdField,
                        AbortedTransactionsField,
                        PreferredReadReplicaField,
                        RecordsField
                    );
                }
                public static int WriteV02(byte[] buffer, int index, PartitionData message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt64(buffer, index, message.HighWatermarkField);
                    index = Encoder.WriteRecords(buffer, index, message.RecordsField);
                    return index;
                }
                public static PartitionData ReadV03(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var HighWatermarkField = Decoder.ReadInt64(buffer, ref index);
                    var LastStableOffsetField = default(long);
                    var LogStartOffsetField = default(long);
                    var DivergingEpochField = EpochEndOffset.Empty;
                    var CurrentLeaderField = LeaderIdAndEpoch.Empty;
                    var SnapshotIdField = SnapshotId.Empty;
                    var AbortedTransactionsField = ImmutableArray<AbortedTransaction>.Empty;
                    var PreferredReadReplicaField = default(int);
                    var RecordsField = Decoder.ReadRecords(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        ErrorCodeField,
                        HighWatermarkField,
                        LastStableOffsetField,
                        LogStartOffsetField,
                        DivergingEpochField,
                        CurrentLeaderField,
                        SnapshotIdField,
                        AbortedTransactionsField,
                        PreferredReadReplicaField,
                        RecordsField
                    );
                }
                public static int WriteV03(byte[] buffer, int index, PartitionData message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt64(buffer, index, message.HighWatermarkField);
                    index = Encoder.WriteRecords(buffer, index, message.RecordsField);
                    return index;
                }
                public static PartitionData ReadV04(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var HighWatermarkField = Decoder.ReadInt64(buffer, ref index);
                    var LastStableOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var LogStartOffsetField = default(long);
                    var DivergingEpochField = EpochEndOffset.Empty;
                    var CurrentLeaderField = LeaderIdAndEpoch.Empty;
                    var SnapshotIdField = SnapshotId.Empty;
                    var AbortedTransactionsField = Decoder.ReadArray<AbortedTransaction>(buffer, ref index, AbortedTransactionSerde.ReadV04);
                    var PreferredReadReplicaField = default(int);
                    var RecordsField = Decoder.ReadRecords(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        ErrorCodeField,
                        HighWatermarkField,
                        LastStableOffsetField,
                        LogStartOffsetField,
                        DivergingEpochField,
                        CurrentLeaderField,
                        SnapshotIdField,
                        AbortedTransactionsField,
                        PreferredReadReplicaField,
                        RecordsField
                    );
                }
                public static int WriteV04(byte[] buffer, int index, PartitionData message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt64(buffer, index, message.HighWatermarkField);
                    index = Encoder.WriteInt64(buffer, index, message.LastStableOffsetField);
                    index = Encoder.WriteArray<AbortedTransaction>(buffer, index, message.AbortedTransactionsField, AbortedTransactionSerde.WriteV04);
                    index = Encoder.WriteRecords(buffer, index, message.RecordsField);
                    return index;
                }
                public static PartitionData ReadV05(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var HighWatermarkField = Decoder.ReadInt64(buffer, ref index);
                    var LastStableOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var LogStartOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var DivergingEpochField = EpochEndOffset.Empty;
                    var CurrentLeaderField = LeaderIdAndEpoch.Empty;
                    var SnapshotIdField = SnapshotId.Empty;
                    var AbortedTransactionsField = Decoder.ReadArray<AbortedTransaction>(buffer, ref index, AbortedTransactionSerde.ReadV05);
                    var PreferredReadReplicaField = default(int);
                    var RecordsField = Decoder.ReadRecords(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        ErrorCodeField,
                        HighWatermarkField,
                        LastStableOffsetField,
                        LogStartOffsetField,
                        DivergingEpochField,
                        CurrentLeaderField,
                        SnapshotIdField,
                        AbortedTransactionsField,
                        PreferredReadReplicaField,
                        RecordsField
                    );
                }
                public static int WriteV05(byte[] buffer, int index, PartitionData message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt64(buffer, index, message.HighWatermarkField);
                    index = Encoder.WriteInt64(buffer, index, message.LastStableOffsetField);
                    index = Encoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = Encoder.WriteArray<AbortedTransaction>(buffer, index, message.AbortedTransactionsField, AbortedTransactionSerde.WriteV05);
                    index = Encoder.WriteRecords(buffer, index, message.RecordsField);
                    return index;
                }
                public static PartitionData ReadV06(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var HighWatermarkField = Decoder.ReadInt64(buffer, ref index);
                    var LastStableOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var LogStartOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var DivergingEpochField = EpochEndOffset.Empty;
                    var CurrentLeaderField = LeaderIdAndEpoch.Empty;
                    var SnapshotIdField = SnapshotId.Empty;
                    var AbortedTransactionsField = Decoder.ReadArray<AbortedTransaction>(buffer, ref index, AbortedTransactionSerde.ReadV06);
                    var PreferredReadReplicaField = default(int);
                    var RecordsField = Decoder.ReadRecords(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        ErrorCodeField,
                        HighWatermarkField,
                        LastStableOffsetField,
                        LogStartOffsetField,
                        DivergingEpochField,
                        CurrentLeaderField,
                        SnapshotIdField,
                        AbortedTransactionsField,
                        PreferredReadReplicaField,
                        RecordsField
                    );
                }
                public static int WriteV06(byte[] buffer, int index, PartitionData message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt64(buffer, index, message.HighWatermarkField);
                    index = Encoder.WriteInt64(buffer, index, message.LastStableOffsetField);
                    index = Encoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = Encoder.WriteArray<AbortedTransaction>(buffer, index, message.AbortedTransactionsField, AbortedTransactionSerde.WriteV06);
                    index = Encoder.WriteRecords(buffer, index, message.RecordsField);
                    return index;
                }
                public static PartitionData ReadV07(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var HighWatermarkField = Decoder.ReadInt64(buffer, ref index);
                    var LastStableOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var LogStartOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var DivergingEpochField = EpochEndOffset.Empty;
                    var CurrentLeaderField = LeaderIdAndEpoch.Empty;
                    var SnapshotIdField = SnapshotId.Empty;
                    var AbortedTransactionsField = Decoder.ReadArray<AbortedTransaction>(buffer, ref index, AbortedTransactionSerde.ReadV07);
                    var PreferredReadReplicaField = default(int);
                    var RecordsField = Decoder.ReadRecords(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        ErrorCodeField,
                        HighWatermarkField,
                        LastStableOffsetField,
                        LogStartOffsetField,
                        DivergingEpochField,
                        CurrentLeaderField,
                        SnapshotIdField,
                        AbortedTransactionsField,
                        PreferredReadReplicaField,
                        RecordsField
                    );
                }
                public static int WriteV07(byte[] buffer, int index, PartitionData message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt64(buffer, index, message.HighWatermarkField);
                    index = Encoder.WriteInt64(buffer, index, message.LastStableOffsetField);
                    index = Encoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = Encoder.WriteArray<AbortedTransaction>(buffer, index, message.AbortedTransactionsField, AbortedTransactionSerde.WriteV07);
                    index = Encoder.WriteRecords(buffer, index, message.RecordsField);
                    return index;
                }
                public static PartitionData ReadV08(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var HighWatermarkField = Decoder.ReadInt64(buffer, ref index);
                    var LastStableOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var LogStartOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var DivergingEpochField = EpochEndOffset.Empty;
                    var CurrentLeaderField = LeaderIdAndEpoch.Empty;
                    var SnapshotIdField = SnapshotId.Empty;
                    var AbortedTransactionsField = Decoder.ReadArray<AbortedTransaction>(buffer, ref index, AbortedTransactionSerde.ReadV08);
                    var PreferredReadReplicaField = default(int);
                    var RecordsField = Decoder.ReadRecords(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        ErrorCodeField,
                        HighWatermarkField,
                        LastStableOffsetField,
                        LogStartOffsetField,
                        DivergingEpochField,
                        CurrentLeaderField,
                        SnapshotIdField,
                        AbortedTransactionsField,
                        PreferredReadReplicaField,
                        RecordsField
                    );
                }
                public static int WriteV08(byte[] buffer, int index, PartitionData message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt64(buffer, index, message.HighWatermarkField);
                    index = Encoder.WriteInt64(buffer, index, message.LastStableOffsetField);
                    index = Encoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = Encoder.WriteArray<AbortedTransaction>(buffer, index, message.AbortedTransactionsField, AbortedTransactionSerde.WriteV08);
                    index = Encoder.WriteRecords(buffer, index, message.RecordsField);
                    return index;
                }
                public static PartitionData ReadV09(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var HighWatermarkField = Decoder.ReadInt64(buffer, ref index);
                    var LastStableOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var LogStartOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var DivergingEpochField = EpochEndOffset.Empty;
                    var CurrentLeaderField = LeaderIdAndEpoch.Empty;
                    var SnapshotIdField = SnapshotId.Empty;
                    var AbortedTransactionsField = Decoder.ReadArray<AbortedTransaction>(buffer, ref index, AbortedTransactionSerde.ReadV09);
                    var PreferredReadReplicaField = default(int);
                    var RecordsField = Decoder.ReadRecords(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        ErrorCodeField,
                        HighWatermarkField,
                        LastStableOffsetField,
                        LogStartOffsetField,
                        DivergingEpochField,
                        CurrentLeaderField,
                        SnapshotIdField,
                        AbortedTransactionsField,
                        PreferredReadReplicaField,
                        RecordsField
                    );
                }
                public static int WriteV09(byte[] buffer, int index, PartitionData message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt64(buffer, index, message.HighWatermarkField);
                    index = Encoder.WriteInt64(buffer, index, message.LastStableOffsetField);
                    index = Encoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = Encoder.WriteArray<AbortedTransaction>(buffer, index, message.AbortedTransactionsField, AbortedTransactionSerde.WriteV09);
                    index = Encoder.WriteRecords(buffer, index, message.RecordsField);
                    return index;
                }
                public static PartitionData ReadV10(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var HighWatermarkField = Decoder.ReadInt64(buffer, ref index);
                    var LastStableOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var LogStartOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var DivergingEpochField = EpochEndOffset.Empty;
                    var CurrentLeaderField = LeaderIdAndEpoch.Empty;
                    var SnapshotIdField = SnapshotId.Empty;
                    var AbortedTransactionsField = Decoder.ReadArray<AbortedTransaction>(buffer, ref index, AbortedTransactionSerde.ReadV10);
                    var PreferredReadReplicaField = default(int);
                    var RecordsField = Decoder.ReadRecords(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        ErrorCodeField,
                        HighWatermarkField,
                        LastStableOffsetField,
                        LogStartOffsetField,
                        DivergingEpochField,
                        CurrentLeaderField,
                        SnapshotIdField,
                        AbortedTransactionsField,
                        PreferredReadReplicaField,
                        RecordsField
                    );
                }
                public static int WriteV10(byte[] buffer, int index, PartitionData message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt64(buffer, index, message.HighWatermarkField);
                    index = Encoder.WriteInt64(buffer, index, message.LastStableOffsetField);
                    index = Encoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = Encoder.WriteArray<AbortedTransaction>(buffer, index, message.AbortedTransactionsField, AbortedTransactionSerde.WriteV10);
                    index = Encoder.WriteRecords(buffer, index, message.RecordsField);
                    return index;
                }
                public static PartitionData ReadV11(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var HighWatermarkField = Decoder.ReadInt64(buffer, ref index);
                    var LastStableOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var LogStartOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var DivergingEpochField = EpochEndOffset.Empty;
                    var CurrentLeaderField = LeaderIdAndEpoch.Empty;
                    var SnapshotIdField = SnapshotId.Empty;
                    var AbortedTransactionsField = Decoder.ReadArray<AbortedTransaction>(buffer, ref index, AbortedTransactionSerde.ReadV11);
                    var PreferredReadReplicaField = Decoder.ReadInt32(buffer, ref index);
                    var RecordsField = Decoder.ReadRecords(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        ErrorCodeField,
                        HighWatermarkField,
                        LastStableOffsetField,
                        LogStartOffsetField,
                        DivergingEpochField,
                        CurrentLeaderField,
                        SnapshotIdField,
                        AbortedTransactionsField,
                        PreferredReadReplicaField,
                        RecordsField
                    );
                }
                public static int WriteV11(byte[] buffer, int index, PartitionData message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt64(buffer, index, message.HighWatermarkField);
                    index = Encoder.WriteInt64(buffer, index, message.LastStableOffsetField);
                    index = Encoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = Encoder.WriteArray<AbortedTransaction>(buffer, index, message.AbortedTransactionsField, AbortedTransactionSerde.WriteV11);
                    index = Encoder.WriteInt32(buffer, index, message.PreferredReadReplicaField);
                    index = Encoder.WriteRecords(buffer, index, message.RecordsField);
                    return index;
                }
                public static PartitionData ReadV12(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var HighWatermarkField = Decoder.ReadInt64(buffer, ref index);
                    var LastStableOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var LogStartOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var DivergingEpochField = EpochEndOffset.Empty;
                    var CurrentLeaderField = LeaderIdAndEpoch.Empty;
                    var SnapshotIdField = SnapshotId.Empty;
                    var AbortedTransactionsField = Decoder.ReadCompactArray<AbortedTransaction>(buffer, ref index, AbortedTransactionSerde.ReadV12);
                    var PreferredReadReplicaField = Decoder.ReadInt32(buffer, ref index);
                    var RecordsField = Decoder.ReadRecords(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        ErrorCodeField,
                        HighWatermarkField,
                        LastStableOffsetField,
                        LogStartOffsetField,
                        DivergingEpochField,
                        CurrentLeaderField,
                        SnapshotIdField,
                        AbortedTransactionsField,
                        PreferredReadReplicaField,
                        RecordsField
                    );
                }
                public static int WriteV12(byte[] buffer, int index, PartitionData message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt64(buffer, index, message.HighWatermarkField);
                    index = Encoder.WriteInt64(buffer, index, message.LastStableOffsetField);
                    index = Encoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = EpochEndOffsetSerde.WriteV12(buffer, index, message.DivergingEpochField);
                    index = LeaderIdAndEpochSerde.WriteV12(buffer, index, message.CurrentLeaderField);
                    index = SnapshotIdSerde.WriteV12(buffer, index, message.SnapshotIdField);
                    index = Encoder.WriteCompactArray<AbortedTransaction>(buffer, index, message.AbortedTransactionsField, AbortedTransactionSerde.WriteV12);
                    index = Encoder.WriteInt32(buffer, index, message.PreferredReadReplicaField);
                    index = Encoder.WriteCompactRecords(buffer, index, message.RecordsField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
                public static PartitionData ReadV13(byte[] buffer, ref int index)
                {
                    var PartitionIndexField = Decoder.ReadInt32(buffer, ref index);
                    var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                    var HighWatermarkField = Decoder.ReadInt64(buffer, ref index);
                    var LastStableOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var LogStartOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var DivergingEpochField = EpochEndOffset.Empty;
                    var CurrentLeaderField = LeaderIdAndEpoch.Empty;
                    var SnapshotIdField = SnapshotId.Empty;
                    var AbortedTransactionsField = Decoder.ReadCompactArray<AbortedTransaction>(buffer, ref index, AbortedTransactionSerde.ReadV13);
                    var PreferredReadReplicaField = Decoder.ReadInt32(buffer, ref index);
                    var RecordsField = Decoder.ReadRecords(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        PartitionIndexField,
                        ErrorCodeField,
                        HighWatermarkField,
                        LastStableOffsetField,
                        LogStartOffsetField,
                        DivergingEpochField,
                        CurrentLeaderField,
                        SnapshotIdField,
                        AbortedTransactionsField,
                        PreferredReadReplicaField,
                        RecordsField
                    );
                }
                public static int WriteV13(byte[] buffer, int index, PartitionData message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = Encoder.WriteInt64(buffer, index, message.HighWatermarkField);
                    index = Encoder.WriteInt64(buffer, index, message.LastStableOffsetField);
                    index = Encoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = EpochEndOffsetSerde.WriteV13(buffer, index, message.DivergingEpochField);
                    index = LeaderIdAndEpochSerde.WriteV13(buffer, index, message.CurrentLeaderField);
                    index = SnapshotIdSerde.WriteV13(buffer, index, message.SnapshotIdField);
                    index = Encoder.WriteCompactArray<AbortedTransaction>(buffer, index, message.AbortedTransactionsField, AbortedTransactionSerde.WriteV13);
                    index = Encoder.WriteInt32(buffer, index, message.PreferredReadReplicaField);
                    index = Encoder.WriteCompactRecords(buffer, index, message.RecordsField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
                private static class SnapshotIdSerde
                {
                    public static SnapshotId ReadV12(byte[] buffer, ref int index)
                    {
                        var EndOffsetField = Decoder.ReadInt64(buffer, ref index);
                        var EpochField = Decoder.ReadInt32(buffer, ref index);
                        _ = Decoder.ReadVarUInt32(buffer, ref index);
                        return new(
                            EndOffsetField,
                            EpochField
                        );
                    }
                    public static int WriteV12(byte[] buffer, int index, SnapshotId message)
                    {
                        index = Encoder.WriteInt64(buffer, index, message.EndOffsetField);
                        index = Encoder.WriteInt32(buffer, index, message.EpochField);
                        index = Encoder.WriteVarUInt32(buffer, index, 0);
                        return index;
                    }
                    public static SnapshotId ReadV13(byte[] buffer, ref int index)
                    {
                        var EndOffsetField = Decoder.ReadInt64(buffer, ref index);
                        var EpochField = Decoder.ReadInt32(buffer, ref index);
                        _ = Decoder.ReadVarUInt32(buffer, ref index);
                        return new(
                            EndOffsetField,
                            EpochField
                        );
                    }
                    public static int WriteV13(byte[] buffer, int index, SnapshotId message)
                    {
                        index = Encoder.WriteInt64(buffer, index, message.EndOffsetField);
                        index = Encoder.WriteInt32(buffer, index, message.EpochField);
                        index = Encoder.WriteVarUInt32(buffer, index, 0);
                        return index;
                    }
                }
                private static class AbortedTransactionSerde
                {
                    public static AbortedTransaction ReadV04(byte[] buffer, ref int index)
                    {
                        var ProducerIdField = Decoder.ReadInt64(buffer, ref index);
                        var FirstOffsetField = Decoder.ReadInt64(buffer, ref index);
                        return new(
                            ProducerIdField,
                            FirstOffsetField
                        );
                    }
                    public static int WriteV04(byte[] buffer, int index, AbortedTransaction message)
                    {
                        index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
                        index = Encoder.WriteInt64(buffer, index, message.FirstOffsetField);
                        return index;
                    }
                    public static AbortedTransaction ReadV05(byte[] buffer, ref int index)
                    {
                        var ProducerIdField = Decoder.ReadInt64(buffer, ref index);
                        var FirstOffsetField = Decoder.ReadInt64(buffer, ref index);
                        return new(
                            ProducerIdField,
                            FirstOffsetField
                        );
                    }
                    public static int WriteV05(byte[] buffer, int index, AbortedTransaction message)
                    {
                        index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
                        index = Encoder.WriteInt64(buffer, index, message.FirstOffsetField);
                        return index;
                    }
                    public static AbortedTransaction ReadV06(byte[] buffer, ref int index)
                    {
                        var ProducerIdField = Decoder.ReadInt64(buffer, ref index);
                        var FirstOffsetField = Decoder.ReadInt64(buffer, ref index);
                        return new(
                            ProducerIdField,
                            FirstOffsetField
                        );
                    }
                    public static int WriteV06(byte[] buffer, int index, AbortedTransaction message)
                    {
                        index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
                        index = Encoder.WriteInt64(buffer, index, message.FirstOffsetField);
                        return index;
                    }
                    public static AbortedTransaction ReadV07(byte[] buffer, ref int index)
                    {
                        var ProducerIdField = Decoder.ReadInt64(buffer, ref index);
                        var FirstOffsetField = Decoder.ReadInt64(buffer, ref index);
                        return new(
                            ProducerIdField,
                            FirstOffsetField
                        );
                    }
                    public static int WriteV07(byte[] buffer, int index, AbortedTransaction message)
                    {
                        index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
                        index = Encoder.WriteInt64(buffer, index, message.FirstOffsetField);
                        return index;
                    }
                    public static AbortedTransaction ReadV08(byte[] buffer, ref int index)
                    {
                        var ProducerIdField = Decoder.ReadInt64(buffer, ref index);
                        var FirstOffsetField = Decoder.ReadInt64(buffer, ref index);
                        return new(
                            ProducerIdField,
                            FirstOffsetField
                        );
                    }
                    public static int WriteV08(byte[] buffer, int index, AbortedTransaction message)
                    {
                        index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
                        index = Encoder.WriteInt64(buffer, index, message.FirstOffsetField);
                        return index;
                    }
                    public static AbortedTransaction ReadV09(byte[] buffer, ref int index)
                    {
                        var ProducerIdField = Decoder.ReadInt64(buffer, ref index);
                        var FirstOffsetField = Decoder.ReadInt64(buffer, ref index);
                        return new(
                            ProducerIdField,
                            FirstOffsetField
                        );
                    }
                    public static int WriteV09(byte[] buffer, int index, AbortedTransaction message)
                    {
                        index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
                        index = Encoder.WriteInt64(buffer, index, message.FirstOffsetField);
                        return index;
                    }
                    public static AbortedTransaction ReadV10(byte[] buffer, ref int index)
                    {
                        var ProducerIdField = Decoder.ReadInt64(buffer, ref index);
                        var FirstOffsetField = Decoder.ReadInt64(buffer, ref index);
                        return new(
                            ProducerIdField,
                            FirstOffsetField
                        );
                    }
                    public static int WriteV10(byte[] buffer, int index, AbortedTransaction message)
                    {
                        index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
                        index = Encoder.WriteInt64(buffer, index, message.FirstOffsetField);
                        return index;
                    }
                    public static AbortedTransaction ReadV11(byte[] buffer, ref int index)
                    {
                        var ProducerIdField = Decoder.ReadInt64(buffer, ref index);
                        var FirstOffsetField = Decoder.ReadInt64(buffer, ref index);
                        return new(
                            ProducerIdField,
                            FirstOffsetField
                        );
                    }
                    public static int WriteV11(byte[] buffer, int index, AbortedTransaction message)
                    {
                        index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
                        index = Encoder.WriteInt64(buffer, index, message.FirstOffsetField);
                        return index;
                    }
                    public static AbortedTransaction ReadV12(byte[] buffer, ref int index)
                    {
                        var ProducerIdField = Decoder.ReadInt64(buffer, ref index);
                        var FirstOffsetField = Decoder.ReadInt64(buffer, ref index);
                        _ = Decoder.ReadVarUInt32(buffer, ref index);
                        return new(
                            ProducerIdField,
                            FirstOffsetField
                        );
                    }
                    public static int WriteV12(byte[] buffer, int index, AbortedTransaction message)
                    {
                        index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
                        index = Encoder.WriteInt64(buffer, index, message.FirstOffsetField);
                        index = Encoder.WriteVarUInt32(buffer, index, 0);
                        return index;
                    }
                    public static AbortedTransaction ReadV13(byte[] buffer, ref int index)
                    {
                        var ProducerIdField = Decoder.ReadInt64(buffer, ref index);
                        var FirstOffsetField = Decoder.ReadInt64(buffer, ref index);
                        _ = Decoder.ReadVarUInt32(buffer, ref index);
                        return new(
                            ProducerIdField,
                            FirstOffsetField
                        );
                    }
                    public static int WriteV13(byte[] buffer, int index, AbortedTransaction message)
                    {
                        index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
                        index = Encoder.WriteInt64(buffer, index, message.FirstOffsetField);
                        index = Encoder.WriteVarUInt32(buffer, index, 0);
                        return index;
                    }
                }
                private static class LeaderIdAndEpochSerde
                {
                    public static LeaderIdAndEpoch ReadV12(byte[] buffer, ref int index)
                    {
                        var LeaderIdField = Decoder.ReadInt32(buffer, ref index);
                        var LeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                        _ = Decoder.ReadVarUInt32(buffer, ref index);
                        return new(
                            LeaderIdField,
                            LeaderEpochField
                        );
                    }
                    public static int WriteV12(byte[] buffer, int index, LeaderIdAndEpoch message)
                    {
                        index = Encoder.WriteInt32(buffer, index, message.LeaderIdField);
                        index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                        index = Encoder.WriteVarUInt32(buffer, index, 0);
                        return index;
                    }
                    public static LeaderIdAndEpoch ReadV13(byte[] buffer, ref int index)
                    {
                        var LeaderIdField = Decoder.ReadInt32(buffer, ref index);
                        var LeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                        _ = Decoder.ReadVarUInt32(buffer, ref index);
                        return new(
                            LeaderIdField,
                            LeaderEpochField
                        );
                    }
                    public static int WriteV13(byte[] buffer, int index, LeaderIdAndEpoch message)
                    {
                        index = Encoder.WriteInt32(buffer, index, message.LeaderIdField);
                        index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                        index = Encoder.WriteVarUInt32(buffer, index, 0);
                        return index;
                    }
                }
                private static class EpochEndOffsetSerde
                {
                    public static EpochEndOffset ReadV12(byte[] buffer, ref int index)
                    {
                        var EpochField = Decoder.ReadInt32(buffer, ref index);
                        var EndOffsetField = Decoder.ReadInt64(buffer, ref index);
                        _ = Decoder.ReadVarUInt32(buffer, ref index);
                        return new(
                            EpochField,
                            EndOffsetField
                        );
                    }
                    public static int WriteV12(byte[] buffer, int index, EpochEndOffset message)
                    {
                        index = Encoder.WriteInt32(buffer, index, message.EpochField);
                        index = Encoder.WriteInt64(buffer, index, message.EndOffsetField);
                        index = Encoder.WriteVarUInt32(buffer, index, 0);
                        return index;
                    }
                    public static EpochEndOffset ReadV13(byte[] buffer, ref int index)
                    {
                        var EpochField = Decoder.ReadInt32(buffer, ref index);
                        var EndOffsetField = Decoder.ReadInt64(buffer, ref index);
                        _ = Decoder.ReadVarUInt32(buffer, ref index);
                        return new(
                            EpochField,
                            EndOffsetField
                        );
                    }
                    public static int WriteV13(byte[] buffer, int index, EpochEndOffset message)
                    {
                        index = Encoder.WriteInt32(buffer, index, message.EpochField);
                        index = Encoder.WriteInt64(buffer, index, message.EndOffsetField);
                        index = Encoder.WriteVarUInt32(buffer, index, 0);
                        return index;
                    }
                }
            }
        }
    }
}