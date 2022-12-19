using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using FetchPartition = Kafka.Client.Messages.FetchRequest.FetchTopic.FetchPartition;
using FetchTopic = Kafka.Client.Messages.FetchRequest.FetchTopic;
using ForgottenTopic = Kafka.Client.Messages.FetchRequest.ForgottenTopic;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class FetchRequestSerde
    {
        private static readonly DecodeDelegate<FetchRequest>[] READ_VERSIONS = {
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
        private static readonly EncodeDelegate<FetchRequest>[] WRITE_VERSIONS = {
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
        public static FetchRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, FetchRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static FetchRequest ReadV00(byte[] buffer, ref int index)
        {
            var clusterIdField = default(string?);
            var replicaIdField = Decoder.ReadInt32(buffer, ref index);
            var maxWaitMsField = Decoder.ReadInt32(buffer, ref index);
            var minBytesField = Decoder.ReadInt32(buffer, ref index);
            var maxBytesField = default(int);
            var isolationLevelField = default(sbyte);
            var sessionIdField = default(int);
            var sessionEpochField = default(int);
            var topicsField = Decoder.ReadArray<FetchTopic>(buffer, ref index, FetchTopicSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var forgottenTopicsDataField = ImmutableArray<ForgottenTopic>.Empty;
            var rackIdField = "";
            return new(
                clusterIdField,
                replicaIdField,
                maxWaitMsField,
                minBytesField,
                maxBytesField,
                isolationLevelField,
                sessionIdField,
                sessionEpochField,
                topicsField,
                forgottenTopicsDataField,
                rackIdField
            );
        }
        private static int WriteV00(byte[] buffer, int index, FetchRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = Encoder.WriteInt32(buffer, index, message.MaxWaitMsField);
            index = Encoder.WriteInt32(buffer, index, message.MinBytesField);
            index = Encoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicSerde.WriteV00);
            return index;
        }
        private static FetchRequest ReadV01(byte[] buffer, ref int index)
        {
            var clusterIdField = default(string?);
            var replicaIdField = Decoder.ReadInt32(buffer, ref index);
            var maxWaitMsField = Decoder.ReadInt32(buffer, ref index);
            var minBytesField = Decoder.ReadInt32(buffer, ref index);
            var maxBytesField = default(int);
            var isolationLevelField = default(sbyte);
            var sessionIdField = default(int);
            var sessionEpochField = default(int);
            var topicsField = Decoder.ReadArray<FetchTopic>(buffer, ref index, FetchTopicSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var forgottenTopicsDataField = ImmutableArray<ForgottenTopic>.Empty;
            var rackIdField = "";
            return new(
                clusterIdField,
                replicaIdField,
                maxWaitMsField,
                minBytesField,
                maxBytesField,
                isolationLevelField,
                sessionIdField,
                sessionEpochField,
                topicsField,
                forgottenTopicsDataField,
                rackIdField
            );
        }
        private static int WriteV01(byte[] buffer, int index, FetchRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = Encoder.WriteInt32(buffer, index, message.MaxWaitMsField);
            index = Encoder.WriteInt32(buffer, index, message.MinBytesField);
            index = Encoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicSerde.WriteV01);
            return index;
        }
        private static FetchRequest ReadV02(byte[] buffer, ref int index)
        {
            var clusterIdField = default(string?);
            var replicaIdField = Decoder.ReadInt32(buffer, ref index);
            var maxWaitMsField = Decoder.ReadInt32(buffer, ref index);
            var minBytesField = Decoder.ReadInt32(buffer, ref index);
            var maxBytesField = default(int);
            var isolationLevelField = default(sbyte);
            var sessionIdField = default(int);
            var sessionEpochField = default(int);
            var topicsField = Decoder.ReadArray<FetchTopic>(buffer, ref index, FetchTopicSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var forgottenTopicsDataField = ImmutableArray<ForgottenTopic>.Empty;
            var rackIdField = "";
            return new(
                clusterIdField,
                replicaIdField,
                maxWaitMsField,
                minBytesField,
                maxBytesField,
                isolationLevelField,
                sessionIdField,
                sessionEpochField,
                topicsField,
                forgottenTopicsDataField,
                rackIdField
            );
        }
        private static int WriteV02(byte[] buffer, int index, FetchRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = Encoder.WriteInt32(buffer, index, message.MaxWaitMsField);
            index = Encoder.WriteInt32(buffer, index, message.MinBytesField);
            index = Encoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicSerde.WriteV02);
            return index;
        }
        private static FetchRequest ReadV03(byte[] buffer, ref int index)
        {
            var clusterIdField = default(string?);
            var replicaIdField = Decoder.ReadInt32(buffer, ref index);
            var maxWaitMsField = Decoder.ReadInt32(buffer, ref index);
            var minBytesField = Decoder.ReadInt32(buffer, ref index);
            var maxBytesField = Decoder.ReadInt32(buffer, ref index);
            var isolationLevelField = default(sbyte);
            var sessionIdField = default(int);
            var sessionEpochField = default(int);
            var topicsField = Decoder.ReadArray<FetchTopic>(buffer, ref index, FetchTopicSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var forgottenTopicsDataField = ImmutableArray<ForgottenTopic>.Empty;
            var rackIdField = "";
            return new(
                clusterIdField,
                replicaIdField,
                maxWaitMsField,
                minBytesField,
                maxBytesField,
                isolationLevelField,
                sessionIdField,
                sessionEpochField,
                topicsField,
                forgottenTopicsDataField,
                rackIdField
            );
        }
        private static int WriteV03(byte[] buffer, int index, FetchRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = Encoder.WriteInt32(buffer, index, message.MaxWaitMsField);
            index = Encoder.WriteInt32(buffer, index, message.MinBytesField);
            index = Encoder.WriteInt32(buffer, index, message.MaxBytesField);
            index = Encoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicSerde.WriteV03);
            return index;
        }
        private static FetchRequest ReadV04(byte[] buffer, ref int index)
        {
            var clusterIdField = default(string?);
            var replicaIdField = Decoder.ReadInt32(buffer, ref index);
            var maxWaitMsField = Decoder.ReadInt32(buffer, ref index);
            var minBytesField = Decoder.ReadInt32(buffer, ref index);
            var maxBytesField = Decoder.ReadInt32(buffer, ref index);
            var isolationLevelField = Decoder.ReadInt8(buffer, ref index);
            var sessionIdField = default(int);
            var sessionEpochField = default(int);
            var topicsField = Decoder.ReadArray<FetchTopic>(buffer, ref index, FetchTopicSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var forgottenTopicsDataField = ImmutableArray<ForgottenTopic>.Empty;
            var rackIdField = "";
            return new(
                clusterIdField,
                replicaIdField,
                maxWaitMsField,
                minBytesField,
                maxBytesField,
                isolationLevelField,
                sessionIdField,
                sessionEpochField,
                topicsField,
                forgottenTopicsDataField,
                rackIdField
            );
        }
        private static int WriteV04(byte[] buffer, int index, FetchRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = Encoder.WriteInt32(buffer, index, message.MaxWaitMsField);
            index = Encoder.WriteInt32(buffer, index, message.MinBytesField);
            index = Encoder.WriteInt32(buffer, index, message.MaxBytesField);
            index = Encoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = Encoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicSerde.WriteV04);
            return index;
        }
        private static FetchRequest ReadV05(byte[] buffer, ref int index)
        {
            var clusterIdField = default(string?);
            var replicaIdField = Decoder.ReadInt32(buffer, ref index);
            var maxWaitMsField = Decoder.ReadInt32(buffer, ref index);
            var minBytesField = Decoder.ReadInt32(buffer, ref index);
            var maxBytesField = Decoder.ReadInt32(buffer, ref index);
            var isolationLevelField = Decoder.ReadInt8(buffer, ref index);
            var sessionIdField = default(int);
            var sessionEpochField = default(int);
            var topicsField = Decoder.ReadArray<FetchTopic>(buffer, ref index, FetchTopicSerde.ReadV05) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var forgottenTopicsDataField = ImmutableArray<ForgottenTopic>.Empty;
            var rackIdField = "";
            return new(
                clusterIdField,
                replicaIdField,
                maxWaitMsField,
                minBytesField,
                maxBytesField,
                isolationLevelField,
                sessionIdField,
                sessionEpochField,
                topicsField,
                forgottenTopicsDataField,
                rackIdField
            );
        }
        private static int WriteV05(byte[] buffer, int index, FetchRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = Encoder.WriteInt32(buffer, index, message.MaxWaitMsField);
            index = Encoder.WriteInt32(buffer, index, message.MinBytesField);
            index = Encoder.WriteInt32(buffer, index, message.MaxBytesField);
            index = Encoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = Encoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicSerde.WriteV05);
            return index;
        }
        private static FetchRequest ReadV06(byte[] buffer, ref int index)
        {
            var clusterIdField = default(string?);
            var replicaIdField = Decoder.ReadInt32(buffer, ref index);
            var maxWaitMsField = Decoder.ReadInt32(buffer, ref index);
            var minBytesField = Decoder.ReadInt32(buffer, ref index);
            var maxBytesField = Decoder.ReadInt32(buffer, ref index);
            var isolationLevelField = Decoder.ReadInt8(buffer, ref index);
            var sessionIdField = default(int);
            var sessionEpochField = default(int);
            var topicsField = Decoder.ReadArray<FetchTopic>(buffer, ref index, FetchTopicSerde.ReadV06) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var forgottenTopicsDataField = ImmutableArray<ForgottenTopic>.Empty;
            var rackIdField = "";
            return new(
                clusterIdField,
                replicaIdField,
                maxWaitMsField,
                minBytesField,
                maxBytesField,
                isolationLevelField,
                sessionIdField,
                sessionEpochField,
                topicsField,
                forgottenTopicsDataField,
                rackIdField
            );
        }
        private static int WriteV06(byte[] buffer, int index, FetchRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = Encoder.WriteInt32(buffer, index, message.MaxWaitMsField);
            index = Encoder.WriteInt32(buffer, index, message.MinBytesField);
            index = Encoder.WriteInt32(buffer, index, message.MaxBytesField);
            index = Encoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = Encoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicSerde.WriteV06);
            return index;
        }
        private static FetchRequest ReadV07(byte[] buffer, ref int index)
        {
            var clusterIdField = default(string?);
            var replicaIdField = Decoder.ReadInt32(buffer, ref index);
            var maxWaitMsField = Decoder.ReadInt32(buffer, ref index);
            var minBytesField = Decoder.ReadInt32(buffer, ref index);
            var maxBytesField = Decoder.ReadInt32(buffer, ref index);
            var isolationLevelField = Decoder.ReadInt8(buffer, ref index);
            var sessionIdField = Decoder.ReadInt32(buffer, ref index);
            var sessionEpochField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadArray<FetchTopic>(buffer, ref index, FetchTopicSerde.ReadV07) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var forgottenTopicsDataField = Decoder.ReadArray<ForgottenTopic>(buffer, ref index, ForgottenTopicSerde.ReadV07) ?? throw new NullReferenceException("Null not allowed for 'ForgottenTopicsData'");
            var rackIdField = "";
            return new(
                clusterIdField,
                replicaIdField,
                maxWaitMsField,
                minBytesField,
                maxBytesField,
                isolationLevelField,
                sessionIdField,
                sessionEpochField,
                topicsField,
                forgottenTopicsDataField,
                rackIdField
            );
        }
        private static int WriteV07(byte[] buffer, int index, FetchRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = Encoder.WriteInt32(buffer, index, message.MaxWaitMsField);
            index = Encoder.WriteInt32(buffer, index, message.MinBytesField);
            index = Encoder.WriteInt32(buffer, index, message.MaxBytesField);
            index = Encoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = Encoder.WriteInt32(buffer, index, message.SessionIdField);
            index = Encoder.WriteInt32(buffer, index, message.SessionEpochField);
            index = Encoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicSerde.WriteV07);
            index = Encoder.WriteArray<ForgottenTopic>(buffer, index, message.ForgottenTopicsDataField, ForgottenTopicSerde.WriteV07);
            return index;
        }
        private static FetchRequest ReadV08(byte[] buffer, ref int index)
        {
            var clusterIdField = default(string?);
            var replicaIdField = Decoder.ReadInt32(buffer, ref index);
            var maxWaitMsField = Decoder.ReadInt32(buffer, ref index);
            var minBytesField = Decoder.ReadInt32(buffer, ref index);
            var maxBytesField = Decoder.ReadInt32(buffer, ref index);
            var isolationLevelField = Decoder.ReadInt8(buffer, ref index);
            var sessionIdField = Decoder.ReadInt32(buffer, ref index);
            var sessionEpochField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadArray<FetchTopic>(buffer, ref index, FetchTopicSerde.ReadV08) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var forgottenTopicsDataField = Decoder.ReadArray<ForgottenTopic>(buffer, ref index, ForgottenTopicSerde.ReadV08) ?? throw new NullReferenceException("Null not allowed for 'ForgottenTopicsData'");
            var rackIdField = "";
            return new(
                clusterIdField,
                replicaIdField,
                maxWaitMsField,
                minBytesField,
                maxBytesField,
                isolationLevelField,
                sessionIdField,
                sessionEpochField,
                topicsField,
                forgottenTopicsDataField,
                rackIdField
            );
        }
        private static int WriteV08(byte[] buffer, int index, FetchRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = Encoder.WriteInt32(buffer, index, message.MaxWaitMsField);
            index = Encoder.WriteInt32(buffer, index, message.MinBytesField);
            index = Encoder.WriteInt32(buffer, index, message.MaxBytesField);
            index = Encoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = Encoder.WriteInt32(buffer, index, message.SessionIdField);
            index = Encoder.WriteInt32(buffer, index, message.SessionEpochField);
            index = Encoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicSerde.WriteV08);
            index = Encoder.WriteArray<ForgottenTopic>(buffer, index, message.ForgottenTopicsDataField, ForgottenTopicSerde.WriteV08);
            return index;
        }
        private static FetchRequest ReadV09(byte[] buffer, ref int index)
        {
            var clusterIdField = default(string?);
            var replicaIdField = Decoder.ReadInt32(buffer, ref index);
            var maxWaitMsField = Decoder.ReadInt32(buffer, ref index);
            var minBytesField = Decoder.ReadInt32(buffer, ref index);
            var maxBytesField = Decoder.ReadInt32(buffer, ref index);
            var isolationLevelField = Decoder.ReadInt8(buffer, ref index);
            var sessionIdField = Decoder.ReadInt32(buffer, ref index);
            var sessionEpochField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadArray<FetchTopic>(buffer, ref index, FetchTopicSerde.ReadV09) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var forgottenTopicsDataField = Decoder.ReadArray<ForgottenTopic>(buffer, ref index, ForgottenTopicSerde.ReadV09) ?? throw new NullReferenceException("Null not allowed for 'ForgottenTopicsData'");
            var rackIdField = "";
            return new(
                clusterIdField,
                replicaIdField,
                maxWaitMsField,
                minBytesField,
                maxBytesField,
                isolationLevelField,
                sessionIdField,
                sessionEpochField,
                topicsField,
                forgottenTopicsDataField,
                rackIdField
            );
        }
        private static int WriteV09(byte[] buffer, int index, FetchRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = Encoder.WriteInt32(buffer, index, message.MaxWaitMsField);
            index = Encoder.WriteInt32(buffer, index, message.MinBytesField);
            index = Encoder.WriteInt32(buffer, index, message.MaxBytesField);
            index = Encoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = Encoder.WriteInt32(buffer, index, message.SessionIdField);
            index = Encoder.WriteInt32(buffer, index, message.SessionEpochField);
            index = Encoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicSerde.WriteV09);
            index = Encoder.WriteArray<ForgottenTopic>(buffer, index, message.ForgottenTopicsDataField, ForgottenTopicSerde.WriteV09);
            return index;
        }
        private static FetchRequest ReadV10(byte[] buffer, ref int index)
        {
            var clusterIdField = default(string?);
            var replicaIdField = Decoder.ReadInt32(buffer, ref index);
            var maxWaitMsField = Decoder.ReadInt32(buffer, ref index);
            var minBytesField = Decoder.ReadInt32(buffer, ref index);
            var maxBytesField = Decoder.ReadInt32(buffer, ref index);
            var isolationLevelField = Decoder.ReadInt8(buffer, ref index);
            var sessionIdField = Decoder.ReadInt32(buffer, ref index);
            var sessionEpochField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadArray<FetchTopic>(buffer, ref index, FetchTopicSerde.ReadV10) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var forgottenTopicsDataField = Decoder.ReadArray<ForgottenTopic>(buffer, ref index, ForgottenTopicSerde.ReadV10) ?? throw new NullReferenceException("Null not allowed for 'ForgottenTopicsData'");
            var rackIdField = "";
            return new(
                clusterIdField,
                replicaIdField,
                maxWaitMsField,
                minBytesField,
                maxBytesField,
                isolationLevelField,
                sessionIdField,
                sessionEpochField,
                topicsField,
                forgottenTopicsDataField,
                rackIdField
            );
        }
        private static int WriteV10(byte[] buffer, int index, FetchRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = Encoder.WriteInt32(buffer, index, message.MaxWaitMsField);
            index = Encoder.WriteInt32(buffer, index, message.MinBytesField);
            index = Encoder.WriteInt32(buffer, index, message.MaxBytesField);
            index = Encoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = Encoder.WriteInt32(buffer, index, message.SessionIdField);
            index = Encoder.WriteInt32(buffer, index, message.SessionEpochField);
            index = Encoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicSerde.WriteV10);
            index = Encoder.WriteArray<ForgottenTopic>(buffer, index, message.ForgottenTopicsDataField, ForgottenTopicSerde.WriteV10);
            return index;
        }
        private static FetchRequest ReadV11(byte[] buffer, ref int index)
        {
            var clusterIdField = default(string?);
            var replicaIdField = Decoder.ReadInt32(buffer, ref index);
            var maxWaitMsField = Decoder.ReadInt32(buffer, ref index);
            var minBytesField = Decoder.ReadInt32(buffer, ref index);
            var maxBytesField = Decoder.ReadInt32(buffer, ref index);
            var isolationLevelField = Decoder.ReadInt8(buffer, ref index);
            var sessionIdField = Decoder.ReadInt32(buffer, ref index);
            var sessionEpochField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadArray<FetchTopic>(buffer, ref index, FetchTopicSerde.ReadV11) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var forgottenTopicsDataField = Decoder.ReadArray<ForgottenTopic>(buffer, ref index, ForgottenTopicSerde.ReadV11) ?? throw new NullReferenceException("Null not allowed for 'ForgottenTopicsData'");
            var rackIdField = Decoder.ReadString(buffer, ref index);
            return new(
                clusterIdField,
                replicaIdField,
                maxWaitMsField,
                minBytesField,
                maxBytesField,
                isolationLevelField,
                sessionIdField,
                sessionEpochField,
                topicsField,
                forgottenTopicsDataField,
                rackIdField
            );
        }
        private static int WriteV11(byte[] buffer, int index, FetchRequest message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = Encoder.WriteInt32(buffer, index, message.MaxWaitMsField);
            index = Encoder.WriteInt32(buffer, index, message.MinBytesField);
            index = Encoder.WriteInt32(buffer, index, message.MaxBytesField);
            index = Encoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = Encoder.WriteInt32(buffer, index, message.SessionIdField);
            index = Encoder.WriteInt32(buffer, index, message.SessionEpochField);
            index = Encoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicSerde.WriteV11);
            index = Encoder.WriteArray<ForgottenTopic>(buffer, index, message.ForgottenTopicsDataField, ForgottenTopicSerde.WriteV11);
            index = Encoder.WriteString(buffer, index, message.RackIdField);
            return index;
        }
        private static FetchRequest ReadV12(byte[] buffer, ref int index)
        {
            var clusterIdField = default(string?);
            var replicaIdField = Decoder.ReadInt32(buffer, ref index);
            var maxWaitMsField = Decoder.ReadInt32(buffer, ref index);
            var minBytesField = Decoder.ReadInt32(buffer, ref index);
            var maxBytesField = Decoder.ReadInt32(buffer, ref index);
            var isolationLevelField = Decoder.ReadInt8(buffer, ref index);
            var sessionIdField = Decoder.ReadInt32(buffer, ref index);
            var sessionEpochField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadCompactArray<FetchTopic>(buffer, ref index, FetchTopicSerde.ReadV12) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var forgottenTopicsDataField = Decoder.ReadCompactArray<ForgottenTopic>(buffer, ref index, ForgottenTopicSerde.ReadV12) ?? throw new NullReferenceException("Null not allowed for 'ForgottenTopicsData'");
            var rackIdField = Decoder.ReadCompactString(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                clusterIdField,
                replicaIdField,
                maxWaitMsField,
                minBytesField,
                maxBytesField,
                isolationLevelField,
                sessionIdField,
                sessionEpochField,
                topicsField,
                forgottenTopicsDataField,
                rackIdField
            );
        }
        private static int WriteV12(byte[] buffer, int index, FetchRequest message)
        {
            index = Encoder.WriteCompactNullableString(buffer, index, message.ClusterIdField);
            index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = Encoder.WriteInt32(buffer, index, message.MaxWaitMsField);
            index = Encoder.WriteInt32(buffer, index, message.MinBytesField);
            index = Encoder.WriteInt32(buffer, index, message.MaxBytesField);
            index = Encoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = Encoder.WriteInt32(buffer, index, message.SessionIdField);
            index = Encoder.WriteInt32(buffer, index, message.SessionEpochField);
            index = Encoder.WriteCompactArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicSerde.WriteV12);
            index = Encoder.WriteCompactArray<ForgottenTopic>(buffer, index, message.ForgottenTopicsDataField, ForgottenTopicSerde.WriteV12);
            index = Encoder.WriteCompactString(buffer, index, message.RackIdField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static FetchRequest ReadV13(byte[] buffer, ref int index)
        {
            var clusterIdField = default(string?);
            var replicaIdField = Decoder.ReadInt32(buffer, ref index);
            var maxWaitMsField = Decoder.ReadInt32(buffer, ref index);
            var minBytesField = Decoder.ReadInt32(buffer, ref index);
            var maxBytesField = Decoder.ReadInt32(buffer, ref index);
            var isolationLevelField = Decoder.ReadInt8(buffer, ref index);
            var sessionIdField = Decoder.ReadInt32(buffer, ref index);
            var sessionEpochField = Decoder.ReadInt32(buffer, ref index);
            var topicsField = Decoder.ReadCompactArray<FetchTopic>(buffer, ref index, FetchTopicSerde.ReadV13) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var forgottenTopicsDataField = Decoder.ReadCompactArray<ForgottenTopic>(buffer, ref index, ForgottenTopicSerde.ReadV13) ?? throw new NullReferenceException("Null not allowed for 'ForgottenTopicsData'");
            var rackIdField = Decoder.ReadCompactString(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                clusterIdField,
                replicaIdField,
                maxWaitMsField,
                minBytesField,
                maxBytesField,
                isolationLevelField,
                sessionIdField,
                sessionEpochField,
                topicsField,
                forgottenTopicsDataField,
                rackIdField
            );
        }
        private static int WriteV13(byte[] buffer, int index, FetchRequest message)
        {
            index = Encoder.WriteCompactNullableString(buffer, index, message.ClusterIdField);
            index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = Encoder.WriteInt32(buffer, index, message.MaxWaitMsField);
            index = Encoder.WriteInt32(buffer, index, message.MinBytesField);
            index = Encoder.WriteInt32(buffer, index, message.MaxBytesField);
            index = Encoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = Encoder.WriteInt32(buffer, index, message.SessionIdField);
            index = Encoder.WriteInt32(buffer, index, message.SessionEpochField);
            index = Encoder.WriteCompactArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicSerde.WriteV13);
            index = Encoder.WriteCompactArray<ForgottenTopic>(buffer, index, message.ForgottenTopicsDataField, ForgottenTopicSerde.WriteV13);
            index = Encoder.WriteCompactString(buffer, index, message.RackIdField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class FetchTopicSerde
        {
            public static FetchTopic ReadV00(byte[] buffer, ref int index)
            {
                var topicField = Decoder.ReadString(buffer, ref index);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<FetchPartition>(buffer, ref index, FetchPartitionSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static int WriteV00(byte[] buffer, int index, FetchTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicField);
                index = Encoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionSerde.WriteV00);
                return index;
            }
            public static FetchTopic ReadV01(byte[] buffer, ref int index)
            {
                var topicField = Decoder.ReadString(buffer, ref index);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<FetchPartition>(buffer, ref index, FetchPartitionSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static int WriteV01(byte[] buffer, int index, FetchTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicField);
                index = Encoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionSerde.WriteV01);
                return index;
            }
            public static FetchTopic ReadV02(byte[] buffer, ref int index)
            {
                var topicField = Decoder.ReadString(buffer, ref index);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<FetchPartition>(buffer, ref index, FetchPartitionSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static int WriteV02(byte[] buffer, int index, FetchTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicField);
                index = Encoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionSerde.WriteV02);
                return index;
            }
            public static FetchTopic ReadV03(byte[] buffer, ref int index)
            {
                var topicField = Decoder.ReadString(buffer, ref index);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<FetchPartition>(buffer, ref index, FetchPartitionSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static int WriteV03(byte[] buffer, int index, FetchTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicField);
                index = Encoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionSerde.WriteV03);
                return index;
            }
            public static FetchTopic ReadV04(byte[] buffer, ref int index)
            {
                var topicField = Decoder.ReadString(buffer, ref index);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<FetchPartition>(buffer, ref index, FetchPartitionSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static int WriteV04(byte[] buffer, int index, FetchTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicField);
                index = Encoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionSerde.WriteV04);
                return index;
            }
            public static FetchTopic ReadV05(byte[] buffer, ref int index)
            {
                var topicField = Decoder.ReadString(buffer, ref index);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<FetchPartition>(buffer, ref index, FetchPartitionSerde.ReadV05) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static int WriteV05(byte[] buffer, int index, FetchTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicField);
                index = Encoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionSerde.WriteV05);
                return index;
            }
            public static FetchTopic ReadV06(byte[] buffer, ref int index)
            {
                var topicField = Decoder.ReadString(buffer, ref index);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<FetchPartition>(buffer, ref index, FetchPartitionSerde.ReadV06) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static int WriteV06(byte[] buffer, int index, FetchTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicField);
                index = Encoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionSerde.WriteV06);
                return index;
            }
            public static FetchTopic ReadV07(byte[] buffer, ref int index)
            {
                var topicField = Decoder.ReadString(buffer, ref index);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<FetchPartition>(buffer, ref index, FetchPartitionSerde.ReadV07) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static int WriteV07(byte[] buffer, int index, FetchTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicField);
                index = Encoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionSerde.WriteV07);
                return index;
            }
            public static FetchTopic ReadV08(byte[] buffer, ref int index)
            {
                var topicField = Decoder.ReadString(buffer, ref index);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<FetchPartition>(buffer, ref index, FetchPartitionSerde.ReadV08) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static int WriteV08(byte[] buffer, int index, FetchTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicField);
                index = Encoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionSerde.WriteV08);
                return index;
            }
            public static FetchTopic ReadV09(byte[] buffer, ref int index)
            {
                var topicField = Decoder.ReadString(buffer, ref index);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<FetchPartition>(buffer, ref index, FetchPartitionSerde.ReadV09) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static int WriteV09(byte[] buffer, int index, FetchTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicField);
                index = Encoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionSerde.WriteV09);
                return index;
            }
            public static FetchTopic ReadV10(byte[] buffer, ref int index)
            {
                var topicField = Decoder.ReadString(buffer, ref index);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<FetchPartition>(buffer, ref index, FetchPartitionSerde.ReadV10) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static int WriteV10(byte[] buffer, int index, FetchTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicField);
                index = Encoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionSerde.WriteV10);
                return index;
            }
            public static FetchTopic ReadV11(byte[] buffer, ref int index)
            {
                var topicField = Decoder.ReadString(buffer, ref index);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<FetchPartition>(buffer, ref index, FetchPartitionSerde.ReadV11) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static int WriteV11(byte[] buffer, int index, FetchTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicField);
                index = Encoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionSerde.WriteV11);
                return index;
            }
            public static FetchTopic ReadV12(byte[] buffer, ref int index)
            {
                var topicField = Decoder.ReadCompactString(buffer, ref index);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadCompactArray<FetchPartition>(buffer, ref index, FetchPartitionSerde.ReadV12) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static int WriteV12(byte[] buffer, int index, FetchTopic message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.TopicField);
                index = Encoder.WriteCompactArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionSerde.WriteV12);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static FetchTopic ReadV13(byte[] buffer, ref int index)
            {
                var topicField = "";
                var topicIdField = Decoder.ReadUuid(buffer, ref index);
                var partitionsField = Decoder.ReadCompactArray<FetchPartition>(buffer, ref index, FetchPartitionSerde.ReadV13) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static int WriteV13(byte[] buffer, int index, FetchTopic message)
            {
                index = Encoder.WriteUuid(buffer, index, message.TopicIdField);
                index = Encoder.WriteCompactArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionSerde.WriteV13);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class FetchPartitionSerde
            {
                public static FetchPartition ReadV00(byte[] buffer, ref int index)
                {
                    var partitionField = Decoder.ReadInt32(buffer, ref index);
                    var currentLeaderEpochField = default(int);
                    var fetchOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = default(long);
                    var partitionMaxBytesField = Decoder.ReadInt32(buffer, ref index);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField
                    );
                }
                public static int WriteV00(byte[] buffer, int index, FetchPartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                    index = Encoder.WriteInt64(buffer, index, message.FetchOffsetField);
                    index = Encoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                    return index;
                }
                public static FetchPartition ReadV01(byte[] buffer, ref int index)
                {
                    var partitionField = Decoder.ReadInt32(buffer, ref index);
                    var currentLeaderEpochField = default(int);
                    var fetchOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = default(long);
                    var partitionMaxBytesField = Decoder.ReadInt32(buffer, ref index);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField
                    );
                }
                public static int WriteV01(byte[] buffer, int index, FetchPartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                    index = Encoder.WriteInt64(buffer, index, message.FetchOffsetField);
                    index = Encoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                    return index;
                }
                public static FetchPartition ReadV02(byte[] buffer, ref int index)
                {
                    var partitionField = Decoder.ReadInt32(buffer, ref index);
                    var currentLeaderEpochField = default(int);
                    var fetchOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = default(long);
                    var partitionMaxBytesField = Decoder.ReadInt32(buffer, ref index);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField
                    );
                }
                public static int WriteV02(byte[] buffer, int index, FetchPartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                    index = Encoder.WriteInt64(buffer, index, message.FetchOffsetField);
                    index = Encoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                    return index;
                }
                public static FetchPartition ReadV03(byte[] buffer, ref int index)
                {
                    var partitionField = Decoder.ReadInt32(buffer, ref index);
                    var currentLeaderEpochField = default(int);
                    var fetchOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = default(long);
                    var partitionMaxBytesField = Decoder.ReadInt32(buffer, ref index);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField
                    );
                }
                public static int WriteV03(byte[] buffer, int index, FetchPartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                    index = Encoder.WriteInt64(buffer, index, message.FetchOffsetField);
                    index = Encoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                    return index;
                }
                public static FetchPartition ReadV04(byte[] buffer, ref int index)
                {
                    var partitionField = Decoder.ReadInt32(buffer, ref index);
                    var currentLeaderEpochField = default(int);
                    var fetchOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = default(long);
                    var partitionMaxBytesField = Decoder.ReadInt32(buffer, ref index);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField
                    );
                }
                public static int WriteV04(byte[] buffer, int index, FetchPartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                    index = Encoder.WriteInt64(buffer, index, message.FetchOffsetField);
                    index = Encoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                    return index;
                }
                public static FetchPartition ReadV05(byte[] buffer, ref int index)
                {
                    var partitionField = Decoder.ReadInt32(buffer, ref index);
                    var currentLeaderEpochField = default(int);
                    var fetchOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var partitionMaxBytesField = Decoder.ReadInt32(buffer, ref index);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField
                    );
                }
                public static int WriteV05(byte[] buffer, int index, FetchPartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                    index = Encoder.WriteInt64(buffer, index, message.FetchOffsetField);
                    index = Encoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = Encoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                    return index;
                }
                public static FetchPartition ReadV06(byte[] buffer, ref int index)
                {
                    var partitionField = Decoder.ReadInt32(buffer, ref index);
                    var currentLeaderEpochField = default(int);
                    var fetchOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var partitionMaxBytesField = Decoder.ReadInt32(buffer, ref index);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField
                    );
                }
                public static int WriteV06(byte[] buffer, int index, FetchPartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                    index = Encoder.WriteInt64(buffer, index, message.FetchOffsetField);
                    index = Encoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = Encoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                    return index;
                }
                public static FetchPartition ReadV07(byte[] buffer, ref int index)
                {
                    var partitionField = Decoder.ReadInt32(buffer, ref index);
                    var currentLeaderEpochField = default(int);
                    var fetchOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var partitionMaxBytesField = Decoder.ReadInt32(buffer, ref index);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField
                    );
                }
                public static int WriteV07(byte[] buffer, int index, FetchPartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                    index = Encoder.WriteInt64(buffer, index, message.FetchOffsetField);
                    index = Encoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = Encoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                    return index;
                }
                public static FetchPartition ReadV08(byte[] buffer, ref int index)
                {
                    var partitionField = Decoder.ReadInt32(buffer, ref index);
                    var currentLeaderEpochField = default(int);
                    var fetchOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var partitionMaxBytesField = Decoder.ReadInt32(buffer, ref index);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField
                    );
                }
                public static int WriteV08(byte[] buffer, int index, FetchPartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                    index = Encoder.WriteInt64(buffer, index, message.FetchOffsetField);
                    index = Encoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = Encoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                    return index;
                }
                public static FetchPartition ReadV09(byte[] buffer, ref int index)
                {
                    var partitionField = Decoder.ReadInt32(buffer, ref index);
                    var currentLeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    var fetchOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var partitionMaxBytesField = Decoder.ReadInt32(buffer, ref index);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField
                    );
                }
                public static int WriteV09(byte[] buffer, int index, FetchPartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                    index = Encoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                    index = Encoder.WriteInt64(buffer, index, message.FetchOffsetField);
                    index = Encoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = Encoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                    return index;
                }
                public static FetchPartition ReadV10(byte[] buffer, ref int index)
                {
                    var partitionField = Decoder.ReadInt32(buffer, ref index);
                    var currentLeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    var fetchOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var partitionMaxBytesField = Decoder.ReadInt32(buffer, ref index);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField
                    );
                }
                public static int WriteV10(byte[] buffer, int index, FetchPartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                    index = Encoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                    index = Encoder.WriteInt64(buffer, index, message.FetchOffsetField);
                    index = Encoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = Encoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                    return index;
                }
                public static FetchPartition ReadV11(byte[] buffer, ref int index)
                {
                    var partitionField = Decoder.ReadInt32(buffer, ref index);
                    var currentLeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    var fetchOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var partitionMaxBytesField = Decoder.ReadInt32(buffer, ref index);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField
                    );
                }
                public static int WriteV11(byte[] buffer, int index, FetchPartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                    index = Encoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                    index = Encoder.WriteInt64(buffer, index, message.FetchOffsetField);
                    index = Encoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = Encoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                    return index;
                }
                public static FetchPartition ReadV12(byte[] buffer, ref int index)
                {
                    var partitionField = Decoder.ReadInt32(buffer, ref index);
                    var currentLeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    var fetchOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var lastFetchedEpochField = Decoder.ReadInt32(buffer, ref index);
                    var logStartOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var partitionMaxBytesField = Decoder.ReadInt32(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField
                    );
                }
                public static int WriteV12(byte[] buffer, int index, FetchPartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                    index = Encoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                    index = Encoder.WriteInt64(buffer, index, message.FetchOffsetField);
                    index = Encoder.WriteInt32(buffer, index, message.LastFetchedEpochField);
                    index = Encoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = Encoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
                public static FetchPartition ReadV13(byte[] buffer, ref int index)
                {
                    var partitionField = Decoder.ReadInt32(buffer, ref index);
                    var currentLeaderEpochField = Decoder.ReadInt32(buffer, ref index);
                    var fetchOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var lastFetchedEpochField = Decoder.ReadInt32(buffer, ref index);
                    var logStartOffsetField = Decoder.ReadInt64(buffer, ref index);
                    var partitionMaxBytesField = Decoder.ReadInt32(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField
                    );
                }
                public static int WriteV13(byte[] buffer, int index, FetchPartition message)
                {
                    index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                    index = Encoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                    index = Encoder.WriteInt64(buffer, index, message.FetchOffsetField);
                    index = Encoder.WriteInt32(buffer, index, message.LastFetchedEpochField);
                    index = Encoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = Encoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
            }
        }
        private static class ForgottenTopicSerde
        {
            public static ForgottenTopic ReadV07(byte[] buffer, ref int index)
            {
                var topicField = Decoder.ReadString(buffer, ref index);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static int WriteV07(byte[] buffer, int index, ForgottenTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicField);
                index = Encoder.WriteArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
                return index;
            }
            public static ForgottenTopic ReadV08(byte[] buffer, ref int index)
            {
                var topicField = Decoder.ReadString(buffer, ref index);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static int WriteV08(byte[] buffer, int index, ForgottenTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicField);
                index = Encoder.WriteArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
                return index;
            }
            public static ForgottenTopic ReadV09(byte[] buffer, ref int index)
            {
                var topicField = Decoder.ReadString(buffer, ref index);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static int WriteV09(byte[] buffer, int index, ForgottenTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicField);
                index = Encoder.WriteArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
                return index;
            }
            public static ForgottenTopic ReadV10(byte[] buffer, ref int index)
            {
                var topicField = Decoder.ReadString(buffer, ref index);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static int WriteV10(byte[] buffer, int index, ForgottenTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicField);
                index = Encoder.WriteArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
                return index;
            }
            public static ForgottenTopic ReadV11(byte[] buffer, ref int index)
            {
                var topicField = Decoder.ReadString(buffer, ref index);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static int WriteV11(byte[] buffer, int index, ForgottenTopic message)
            {
                index = Encoder.WriteString(buffer, index, message.TopicField);
                index = Encoder.WriteArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
                return index;
            }
            public static ForgottenTopic ReadV12(byte[] buffer, ref int index)
            {
                var topicField = Decoder.ReadCompactString(buffer, ref index);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static int WriteV12(byte[] buffer, int index, ForgottenTopic message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.TopicField);
                index = Encoder.WriteCompactArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static ForgottenTopic ReadV13(byte[] buffer, ref int index)
            {
                var topicField = "";
                var topicIdField = Decoder.ReadUuid(buffer, ref index);
                var partitionsField = Decoder.ReadCompactArray<int>(buffer, ref index, Decoder.ReadInt32) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static int WriteV13(byte[] buffer, int index, ForgottenTopic message)
            {
                index = Encoder.WriteUuid(buffer, index, message.TopicIdField);
                index = Encoder.WriteCompactArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
        }
    }
}