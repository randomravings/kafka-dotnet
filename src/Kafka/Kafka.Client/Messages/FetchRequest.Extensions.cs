using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using FetchTopic = Kafka.Client.Messages.FetchRequest.FetchTopic;
using FetchPartition = Kafka.Client.Messages.FetchRequest.FetchTopic.FetchPartition;
using ForgottenTopic = Kafka.Client.Messages.FetchRequest.ForgottenTopic;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class FetchRequestSerde
    {
        private static readonly Func<Stream, FetchRequest>[] READ_VERSIONS = {
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
        private static readonly Action<Stream, FetchRequest>[] WRITE_VERSIONS = {
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
        public static FetchRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, FetchRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static FetchRequest ReadV00(Stream buffer)
        {
            var clusterIdField = default(string?);
            var replicaIdField = Decoder.ReadInt32(buffer);
            var maxWaitMsField = Decoder.ReadInt32(buffer);
            var minBytesField = Decoder.ReadInt32(buffer);
            var maxBytesField = default(int);
            var isolationLevelField = default(sbyte);
            var sessionIdField = default(int);
            var sessionEpochField = default(int);
            var topicsField = Decoder.ReadArray<FetchTopic>(buffer, b => FetchTopicSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
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
        private static void WriteV00(Stream buffer, FetchRequest message)
        {
            Encoder.WriteInt32(buffer, message.ReplicaIdField);
            Encoder.WriteInt32(buffer, message.MaxWaitMsField);
            Encoder.WriteInt32(buffer, message.MinBytesField);
            Encoder.WriteArray<FetchTopic>(buffer, message.TopicsField, (b, i) => FetchTopicSerde.WriteV00(b, i));
        }
        private static FetchRequest ReadV01(Stream buffer)
        {
            var clusterIdField = default(string?);
            var replicaIdField = Decoder.ReadInt32(buffer);
            var maxWaitMsField = Decoder.ReadInt32(buffer);
            var minBytesField = Decoder.ReadInt32(buffer);
            var maxBytesField = default(int);
            var isolationLevelField = default(sbyte);
            var sessionIdField = default(int);
            var sessionEpochField = default(int);
            var topicsField = Decoder.ReadArray<FetchTopic>(buffer, b => FetchTopicSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
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
        private static void WriteV01(Stream buffer, FetchRequest message)
        {
            Encoder.WriteInt32(buffer, message.ReplicaIdField);
            Encoder.WriteInt32(buffer, message.MaxWaitMsField);
            Encoder.WriteInt32(buffer, message.MinBytesField);
            Encoder.WriteArray<FetchTopic>(buffer, message.TopicsField, (b, i) => FetchTopicSerde.WriteV01(b, i));
        }
        private static FetchRequest ReadV02(Stream buffer)
        {
            var clusterIdField = default(string?);
            var replicaIdField = Decoder.ReadInt32(buffer);
            var maxWaitMsField = Decoder.ReadInt32(buffer);
            var minBytesField = Decoder.ReadInt32(buffer);
            var maxBytesField = default(int);
            var isolationLevelField = default(sbyte);
            var sessionIdField = default(int);
            var sessionEpochField = default(int);
            var topicsField = Decoder.ReadArray<FetchTopic>(buffer, b => FetchTopicSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
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
        private static void WriteV02(Stream buffer, FetchRequest message)
        {
            Encoder.WriteInt32(buffer, message.ReplicaIdField);
            Encoder.WriteInt32(buffer, message.MaxWaitMsField);
            Encoder.WriteInt32(buffer, message.MinBytesField);
            Encoder.WriteArray<FetchTopic>(buffer, message.TopicsField, (b, i) => FetchTopicSerde.WriteV02(b, i));
        }
        private static FetchRequest ReadV03(Stream buffer)
        {
            var clusterIdField = default(string?);
            var replicaIdField = Decoder.ReadInt32(buffer);
            var maxWaitMsField = Decoder.ReadInt32(buffer);
            var minBytesField = Decoder.ReadInt32(buffer);
            var maxBytesField = Decoder.ReadInt32(buffer);
            var isolationLevelField = default(sbyte);
            var sessionIdField = default(int);
            var sessionEpochField = default(int);
            var topicsField = Decoder.ReadArray<FetchTopic>(buffer, b => FetchTopicSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
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
        private static void WriteV03(Stream buffer, FetchRequest message)
        {
            Encoder.WriteInt32(buffer, message.ReplicaIdField);
            Encoder.WriteInt32(buffer, message.MaxWaitMsField);
            Encoder.WriteInt32(buffer, message.MinBytesField);
            Encoder.WriteInt32(buffer, message.MaxBytesField);
            Encoder.WriteArray<FetchTopic>(buffer, message.TopicsField, (b, i) => FetchTopicSerde.WriteV03(b, i));
        }
        private static FetchRequest ReadV04(Stream buffer)
        {
            var clusterIdField = default(string?);
            var replicaIdField = Decoder.ReadInt32(buffer);
            var maxWaitMsField = Decoder.ReadInt32(buffer);
            var minBytesField = Decoder.ReadInt32(buffer);
            var maxBytesField = Decoder.ReadInt32(buffer);
            var isolationLevelField = Decoder.ReadInt8(buffer);
            var sessionIdField = default(int);
            var sessionEpochField = default(int);
            var topicsField = Decoder.ReadArray<FetchTopic>(buffer, b => FetchTopicSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
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
        private static void WriteV04(Stream buffer, FetchRequest message)
        {
            Encoder.WriteInt32(buffer, message.ReplicaIdField);
            Encoder.WriteInt32(buffer, message.MaxWaitMsField);
            Encoder.WriteInt32(buffer, message.MinBytesField);
            Encoder.WriteInt32(buffer, message.MaxBytesField);
            Encoder.WriteInt8(buffer, message.IsolationLevelField);
            Encoder.WriteArray<FetchTopic>(buffer, message.TopicsField, (b, i) => FetchTopicSerde.WriteV04(b, i));
        }
        private static FetchRequest ReadV05(Stream buffer)
        {
            var clusterIdField = default(string?);
            var replicaIdField = Decoder.ReadInt32(buffer);
            var maxWaitMsField = Decoder.ReadInt32(buffer);
            var minBytesField = Decoder.ReadInt32(buffer);
            var maxBytesField = Decoder.ReadInt32(buffer);
            var isolationLevelField = Decoder.ReadInt8(buffer);
            var sessionIdField = default(int);
            var sessionEpochField = default(int);
            var topicsField = Decoder.ReadArray<FetchTopic>(buffer, b => FetchTopicSerde.ReadV05(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
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
        private static void WriteV05(Stream buffer, FetchRequest message)
        {
            Encoder.WriteInt32(buffer, message.ReplicaIdField);
            Encoder.WriteInt32(buffer, message.MaxWaitMsField);
            Encoder.WriteInt32(buffer, message.MinBytesField);
            Encoder.WriteInt32(buffer, message.MaxBytesField);
            Encoder.WriteInt8(buffer, message.IsolationLevelField);
            Encoder.WriteArray<FetchTopic>(buffer, message.TopicsField, (b, i) => FetchTopicSerde.WriteV05(b, i));
        }
        private static FetchRequest ReadV06(Stream buffer)
        {
            var clusterIdField = default(string?);
            var replicaIdField = Decoder.ReadInt32(buffer);
            var maxWaitMsField = Decoder.ReadInt32(buffer);
            var minBytesField = Decoder.ReadInt32(buffer);
            var maxBytesField = Decoder.ReadInt32(buffer);
            var isolationLevelField = Decoder.ReadInt8(buffer);
            var sessionIdField = default(int);
            var sessionEpochField = default(int);
            var topicsField = Decoder.ReadArray<FetchTopic>(buffer, b => FetchTopicSerde.ReadV06(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
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
        private static void WriteV06(Stream buffer, FetchRequest message)
        {
            Encoder.WriteInt32(buffer, message.ReplicaIdField);
            Encoder.WriteInt32(buffer, message.MaxWaitMsField);
            Encoder.WriteInt32(buffer, message.MinBytesField);
            Encoder.WriteInt32(buffer, message.MaxBytesField);
            Encoder.WriteInt8(buffer, message.IsolationLevelField);
            Encoder.WriteArray<FetchTopic>(buffer, message.TopicsField, (b, i) => FetchTopicSerde.WriteV06(b, i));
        }
        private static FetchRequest ReadV07(Stream buffer)
        {
            var clusterIdField = default(string?);
            var replicaIdField = Decoder.ReadInt32(buffer);
            var maxWaitMsField = Decoder.ReadInt32(buffer);
            var minBytesField = Decoder.ReadInt32(buffer);
            var maxBytesField = Decoder.ReadInt32(buffer);
            var isolationLevelField = Decoder.ReadInt8(buffer);
            var sessionIdField = Decoder.ReadInt32(buffer);
            var sessionEpochField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadArray<FetchTopic>(buffer, b => FetchTopicSerde.ReadV07(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var forgottenTopicsDataField = Decoder.ReadArray<ForgottenTopic>(buffer, b => ForgottenTopicSerde.ReadV07(b)) ?? throw new NullReferenceException("Null not allowed for 'ForgottenTopicsData'");
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
        private static void WriteV07(Stream buffer, FetchRequest message)
        {
            Encoder.WriteInt32(buffer, message.ReplicaIdField);
            Encoder.WriteInt32(buffer, message.MaxWaitMsField);
            Encoder.WriteInt32(buffer, message.MinBytesField);
            Encoder.WriteInt32(buffer, message.MaxBytesField);
            Encoder.WriteInt8(buffer, message.IsolationLevelField);
            Encoder.WriteInt32(buffer, message.SessionIdField);
            Encoder.WriteInt32(buffer, message.SessionEpochField);
            Encoder.WriteArray<FetchTopic>(buffer, message.TopicsField, (b, i) => FetchTopicSerde.WriteV07(b, i));
            Encoder.WriteArray<ForgottenTopic>(buffer, message.ForgottenTopicsDataField, (b, i) => ForgottenTopicSerde.WriteV07(b, i));
        }
        private static FetchRequest ReadV08(Stream buffer)
        {
            var clusterIdField = default(string?);
            var replicaIdField = Decoder.ReadInt32(buffer);
            var maxWaitMsField = Decoder.ReadInt32(buffer);
            var minBytesField = Decoder.ReadInt32(buffer);
            var maxBytesField = Decoder.ReadInt32(buffer);
            var isolationLevelField = Decoder.ReadInt8(buffer);
            var sessionIdField = Decoder.ReadInt32(buffer);
            var sessionEpochField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadArray<FetchTopic>(buffer, b => FetchTopicSerde.ReadV08(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var forgottenTopicsDataField = Decoder.ReadArray<ForgottenTopic>(buffer, b => ForgottenTopicSerde.ReadV08(b)) ?? throw new NullReferenceException("Null not allowed for 'ForgottenTopicsData'");
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
        private static void WriteV08(Stream buffer, FetchRequest message)
        {
            Encoder.WriteInt32(buffer, message.ReplicaIdField);
            Encoder.WriteInt32(buffer, message.MaxWaitMsField);
            Encoder.WriteInt32(buffer, message.MinBytesField);
            Encoder.WriteInt32(buffer, message.MaxBytesField);
            Encoder.WriteInt8(buffer, message.IsolationLevelField);
            Encoder.WriteInt32(buffer, message.SessionIdField);
            Encoder.WriteInt32(buffer, message.SessionEpochField);
            Encoder.WriteArray<FetchTopic>(buffer, message.TopicsField, (b, i) => FetchTopicSerde.WriteV08(b, i));
            Encoder.WriteArray<ForgottenTopic>(buffer, message.ForgottenTopicsDataField, (b, i) => ForgottenTopicSerde.WriteV08(b, i));
        }
        private static FetchRequest ReadV09(Stream buffer)
        {
            var clusterIdField = default(string?);
            var replicaIdField = Decoder.ReadInt32(buffer);
            var maxWaitMsField = Decoder.ReadInt32(buffer);
            var minBytesField = Decoder.ReadInt32(buffer);
            var maxBytesField = Decoder.ReadInt32(buffer);
            var isolationLevelField = Decoder.ReadInt8(buffer);
            var sessionIdField = Decoder.ReadInt32(buffer);
            var sessionEpochField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadArray<FetchTopic>(buffer, b => FetchTopicSerde.ReadV09(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var forgottenTopicsDataField = Decoder.ReadArray<ForgottenTopic>(buffer, b => ForgottenTopicSerde.ReadV09(b)) ?? throw new NullReferenceException("Null not allowed for 'ForgottenTopicsData'");
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
        private static void WriteV09(Stream buffer, FetchRequest message)
        {
            Encoder.WriteInt32(buffer, message.ReplicaIdField);
            Encoder.WriteInt32(buffer, message.MaxWaitMsField);
            Encoder.WriteInt32(buffer, message.MinBytesField);
            Encoder.WriteInt32(buffer, message.MaxBytesField);
            Encoder.WriteInt8(buffer, message.IsolationLevelField);
            Encoder.WriteInt32(buffer, message.SessionIdField);
            Encoder.WriteInt32(buffer, message.SessionEpochField);
            Encoder.WriteArray<FetchTopic>(buffer, message.TopicsField, (b, i) => FetchTopicSerde.WriteV09(b, i));
            Encoder.WriteArray<ForgottenTopic>(buffer, message.ForgottenTopicsDataField, (b, i) => ForgottenTopicSerde.WriteV09(b, i));
        }
        private static FetchRequest ReadV10(Stream buffer)
        {
            var clusterIdField = default(string?);
            var replicaIdField = Decoder.ReadInt32(buffer);
            var maxWaitMsField = Decoder.ReadInt32(buffer);
            var minBytesField = Decoder.ReadInt32(buffer);
            var maxBytesField = Decoder.ReadInt32(buffer);
            var isolationLevelField = Decoder.ReadInt8(buffer);
            var sessionIdField = Decoder.ReadInt32(buffer);
            var sessionEpochField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadArray<FetchTopic>(buffer, b => FetchTopicSerde.ReadV10(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var forgottenTopicsDataField = Decoder.ReadArray<ForgottenTopic>(buffer, b => ForgottenTopicSerde.ReadV10(b)) ?? throw new NullReferenceException("Null not allowed for 'ForgottenTopicsData'");
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
        private static void WriteV10(Stream buffer, FetchRequest message)
        {
            Encoder.WriteInt32(buffer, message.ReplicaIdField);
            Encoder.WriteInt32(buffer, message.MaxWaitMsField);
            Encoder.WriteInt32(buffer, message.MinBytesField);
            Encoder.WriteInt32(buffer, message.MaxBytesField);
            Encoder.WriteInt8(buffer, message.IsolationLevelField);
            Encoder.WriteInt32(buffer, message.SessionIdField);
            Encoder.WriteInt32(buffer, message.SessionEpochField);
            Encoder.WriteArray<FetchTopic>(buffer, message.TopicsField, (b, i) => FetchTopicSerde.WriteV10(b, i));
            Encoder.WriteArray<ForgottenTopic>(buffer, message.ForgottenTopicsDataField, (b, i) => ForgottenTopicSerde.WriteV10(b, i));
        }
        private static FetchRequest ReadV11(Stream buffer)
        {
            var clusterIdField = default(string?);
            var replicaIdField = Decoder.ReadInt32(buffer);
            var maxWaitMsField = Decoder.ReadInt32(buffer);
            var minBytesField = Decoder.ReadInt32(buffer);
            var maxBytesField = Decoder.ReadInt32(buffer);
            var isolationLevelField = Decoder.ReadInt8(buffer);
            var sessionIdField = Decoder.ReadInt32(buffer);
            var sessionEpochField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadArray<FetchTopic>(buffer, b => FetchTopicSerde.ReadV11(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var forgottenTopicsDataField = Decoder.ReadArray<ForgottenTopic>(buffer, b => ForgottenTopicSerde.ReadV11(b)) ?? throw new NullReferenceException("Null not allowed for 'ForgottenTopicsData'");
            var rackIdField = Decoder.ReadString(buffer);
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
        private static void WriteV11(Stream buffer, FetchRequest message)
        {
            Encoder.WriteInt32(buffer, message.ReplicaIdField);
            Encoder.WriteInt32(buffer, message.MaxWaitMsField);
            Encoder.WriteInt32(buffer, message.MinBytesField);
            Encoder.WriteInt32(buffer, message.MaxBytesField);
            Encoder.WriteInt8(buffer, message.IsolationLevelField);
            Encoder.WriteInt32(buffer, message.SessionIdField);
            Encoder.WriteInt32(buffer, message.SessionEpochField);
            Encoder.WriteArray<FetchTopic>(buffer, message.TopicsField, (b, i) => FetchTopicSerde.WriteV11(b, i));
            Encoder.WriteArray<ForgottenTopic>(buffer, message.ForgottenTopicsDataField, (b, i) => ForgottenTopicSerde.WriteV11(b, i));
            Encoder.WriteString(buffer, message.RackIdField);
        }
        private static FetchRequest ReadV12(Stream buffer)
        {
            var clusterIdField = default(string?);
            var replicaIdField = Decoder.ReadInt32(buffer);
            var maxWaitMsField = Decoder.ReadInt32(buffer);
            var minBytesField = Decoder.ReadInt32(buffer);
            var maxBytesField = Decoder.ReadInt32(buffer);
            var isolationLevelField = Decoder.ReadInt8(buffer);
            var sessionIdField = Decoder.ReadInt32(buffer);
            var sessionEpochField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadCompactArray<FetchTopic>(buffer, b => FetchTopicSerde.ReadV12(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var forgottenTopicsDataField = Decoder.ReadCompactArray<ForgottenTopic>(buffer, b => ForgottenTopicSerde.ReadV12(b)) ?? throw new NullReferenceException("Null not allowed for 'ForgottenTopicsData'");
            var rackIdField = Decoder.ReadCompactString(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
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
        private static void WriteV12(Stream buffer, FetchRequest message)
        {
            Encoder.WriteCompactNullableString(buffer, message.ClusterIdField);
            Encoder.WriteInt32(buffer, message.ReplicaIdField);
            Encoder.WriteInt32(buffer, message.MaxWaitMsField);
            Encoder.WriteInt32(buffer, message.MinBytesField);
            Encoder.WriteInt32(buffer, message.MaxBytesField);
            Encoder.WriteInt8(buffer, message.IsolationLevelField);
            Encoder.WriteInt32(buffer, message.SessionIdField);
            Encoder.WriteInt32(buffer, message.SessionEpochField);
            Encoder.WriteCompactArray<FetchTopic>(buffer, message.TopicsField, (b, i) => FetchTopicSerde.WriteV12(b, i));
            Encoder.WriteCompactArray<ForgottenTopic>(buffer, message.ForgottenTopicsDataField, (b, i) => ForgottenTopicSerde.WriteV12(b, i));
            Encoder.WriteCompactString(buffer, message.RackIdField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static FetchRequest ReadV13(Stream buffer)
        {
            var clusterIdField = default(string?);
            var replicaIdField = Decoder.ReadInt32(buffer);
            var maxWaitMsField = Decoder.ReadInt32(buffer);
            var minBytesField = Decoder.ReadInt32(buffer);
            var maxBytesField = Decoder.ReadInt32(buffer);
            var isolationLevelField = Decoder.ReadInt8(buffer);
            var sessionIdField = Decoder.ReadInt32(buffer);
            var sessionEpochField = Decoder.ReadInt32(buffer);
            var topicsField = Decoder.ReadCompactArray<FetchTopic>(buffer, b => FetchTopicSerde.ReadV13(b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var forgottenTopicsDataField = Decoder.ReadCompactArray<ForgottenTopic>(buffer, b => ForgottenTopicSerde.ReadV13(b)) ?? throw new NullReferenceException("Null not allowed for 'ForgottenTopicsData'");
            var rackIdField = Decoder.ReadCompactString(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
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
        private static void WriteV13(Stream buffer, FetchRequest message)
        {
            Encoder.WriteCompactNullableString(buffer, message.ClusterIdField);
            Encoder.WriteInt32(buffer, message.ReplicaIdField);
            Encoder.WriteInt32(buffer, message.MaxWaitMsField);
            Encoder.WriteInt32(buffer, message.MinBytesField);
            Encoder.WriteInt32(buffer, message.MaxBytesField);
            Encoder.WriteInt8(buffer, message.IsolationLevelField);
            Encoder.WriteInt32(buffer, message.SessionIdField);
            Encoder.WriteInt32(buffer, message.SessionEpochField);
            Encoder.WriteCompactArray<FetchTopic>(buffer, message.TopicsField, (b, i) => FetchTopicSerde.WriteV13(b, i));
            Encoder.WriteCompactArray<ForgottenTopic>(buffer, message.ForgottenTopicsDataField, (b, i) => ForgottenTopicSerde.WriteV13(b, i));
            Encoder.WriteCompactString(buffer, message.RackIdField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class FetchTopicSerde
        {
            public static FetchTopic ReadV00(Stream buffer)
            {
                var topicField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<FetchPartition>(buffer, b => FetchPartitionSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static void WriteV00(Stream buffer, FetchTopic message)
            {
                Encoder.WriteString(buffer, message.TopicField);
                Encoder.WriteArray<FetchPartition>(buffer, message.PartitionsField, (b, i) => FetchPartitionSerde.WriteV00(b, i));
            }
            public static FetchTopic ReadV01(Stream buffer)
            {
                var topicField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<FetchPartition>(buffer, b => FetchPartitionSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static void WriteV01(Stream buffer, FetchTopic message)
            {
                Encoder.WriteString(buffer, message.TopicField);
                Encoder.WriteArray<FetchPartition>(buffer, message.PartitionsField, (b, i) => FetchPartitionSerde.WriteV01(b, i));
            }
            public static FetchTopic ReadV02(Stream buffer)
            {
                var topicField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<FetchPartition>(buffer, b => FetchPartitionSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static void WriteV02(Stream buffer, FetchTopic message)
            {
                Encoder.WriteString(buffer, message.TopicField);
                Encoder.WriteArray<FetchPartition>(buffer, message.PartitionsField, (b, i) => FetchPartitionSerde.WriteV02(b, i));
            }
            public static FetchTopic ReadV03(Stream buffer)
            {
                var topicField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<FetchPartition>(buffer, b => FetchPartitionSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static void WriteV03(Stream buffer, FetchTopic message)
            {
                Encoder.WriteString(buffer, message.TopicField);
                Encoder.WriteArray<FetchPartition>(buffer, message.PartitionsField, (b, i) => FetchPartitionSerde.WriteV03(b, i));
            }
            public static FetchTopic ReadV04(Stream buffer)
            {
                var topicField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<FetchPartition>(buffer, b => FetchPartitionSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static void WriteV04(Stream buffer, FetchTopic message)
            {
                Encoder.WriteString(buffer, message.TopicField);
                Encoder.WriteArray<FetchPartition>(buffer, message.PartitionsField, (b, i) => FetchPartitionSerde.WriteV04(b, i));
            }
            public static FetchTopic ReadV05(Stream buffer)
            {
                var topicField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<FetchPartition>(buffer, b => FetchPartitionSerde.ReadV05(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static void WriteV05(Stream buffer, FetchTopic message)
            {
                Encoder.WriteString(buffer, message.TopicField);
                Encoder.WriteArray<FetchPartition>(buffer, message.PartitionsField, (b, i) => FetchPartitionSerde.WriteV05(b, i));
            }
            public static FetchTopic ReadV06(Stream buffer)
            {
                var topicField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<FetchPartition>(buffer, b => FetchPartitionSerde.ReadV06(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static void WriteV06(Stream buffer, FetchTopic message)
            {
                Encoder.WriteString(buffer, message.TopicField);
                Encoder.WriteArray<FetchPartition>(buffer, message.PartitionsField, (b, i) => FetchPartitionSerde.WriteV06(b, i));
            }
            public static FetchTopic ReadV07(Stream buffer)
            {
                var topicField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<FetchPartition>(buffer, b => FetchPartitionSerde.ReadV07(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static void WriteV07(Stream buffer, FetchTopic message)
            {
                Encoder.WriteString(buffer, message.TopicField);
                Encoder.WriteArray<FetchPartition>(buffer, message.PartitionsField, (b, i) => FetchPartitionSerde.WriteV07(b, i));
            }
            public static FetchTopic ReadV08(Stream buffer)
            {
                var topicField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<FetchPartition>(buffer, b => FetchPartitionSerde.ReadV08(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static void WriteV08(Stream buffer, FetchTopic message)
            {
                Encoder.WriteString(buffer, message.TopicField);
                Encoder.WriteArray<FetchPartition>(buffer, message.PartitionsField, (b, i) => FetchPartitionSerde.WriteV08(b, i));
            }
            public static FetchTopic ReadV09(Stream buffer)
            {
                var topicField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<FetchPartition>(buffer, b => FetchPartitionSerde.ReadV09(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static void WriteV09(Stream buffer, FetchTopic message)
            {
                Encoder.WriteString(buffer, message.TopicField);
                Encoder.WriteArray<FetchPartition>(buffer, message.PartitionsField, (b, i) => FetchPartitionSerde.WriteV09(b, i));
            }
            public static FetchTopic ReadV10(Stream buffer)
            {
                var topicField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<FetchPartition>(buffer, b => FetchPartitionSerde.ReadV10(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static void WriteV10(Stream buffer, FetchTopic message)
            {
                Encoder.WriteString(buffer, message.TopicField);
                Encoder.WriteArray<FetchPartition>(buffer, message.PartitionsField, (b, i) => FetchPartitionSerde.WriteV10(b, i));
            }
            public static FetchTopic ReadV11(Stream buffer)
            {
                var topicField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<FetchPartition>(buffer, b => FetchPartitionSerde.ReadV11(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static void WriteV11(Stream buffer, FetchTopic message)
            {
                Encoder.WriteString(buffer, message.TopicField);
                Encoder.WriteArray<FetchPartition>(buffer, message.PartitionsField, (b, i) => FetchPartitionSerde.WriteV11(b, i));
            }
            public static FetchTopic ReadV12(Stream buffer)
            {
                var topicField = Decoder.ReadCompactString(buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadCompactArray<FetchPartition>(buffer, b => FetchPartitionSerde.ReadV12(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static void WriteV12(Stream buffer, FetchTopic message)
            {
                Encoder.WriteCompactString(buffer, message.TopicField);
                Encoder.WriteCompactArray<FetchPartition>(buffer, message.PartitionsField, (b, i) => FetchPartitionSerde.WriteV12(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static FetchTopic ReadV13(Stream buffer)
            {
                var topicField = "";
                var topicIdField = Decoder.ReadUuid(buffer);
                var partitionsField = Decoder.ReadCompactArray<FetchPartition>(buffer, b => FetchPartitionSerde.ReadV13(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static void WriteV13(Stream buffer, FetchTopic message)
            {
                Encoder.WriteUuid(buffer, message.TopicIdField);
                Encoder.WriteCompactArray<FetchPartition>(buffer, message.PartitionsField, (b, i) => FetchPartitionSerde.WriteV13(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class FetchPartitionSerde
            {
                public static FetchPartition ReadV00(Stream buffer)
                {
                    var partitionField = Decoder.ReadInt32(buffer);
                    var currentLeaderEpochField = default(int);
                    var fetchOffsetField = Decoder.ReadInt64(buffer);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = default(long);
                    var partitionMaxBytesField = Decoder.ReadInt32(buffer);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField
                    );
                }
                public static void WriteV00(Stream buffer, FetchPartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionField);
                    Encoder.WriteInt64(buffer, message.FetchOffsetField);
                    Encoder.WriteInt32(buffer, message.PartitionMaxBytesField);
                }
                public static FetchPartition ReadV01(Stream buffer)
                {
                    var partitionField = Decoder.ReadInt32(buffer);
                    var currentLeaderEpochField = default(int);
                    var fetchOffsetField = Decoder.ReadInt64(buffer);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = default(long);
                    var partitionMaxBytesField = Decoder.ReadInt32(buffer);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField
                    );
                }
                public static void WriteV01(Stream buffer, FetchPartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionField);
                    Encoder.WriteInt64(buffer, message.FetchOffsetField);
                    Encoder.WriteInt32(buffer, message.PartitionMaxBytesField);
                }
                public static FetchPartition ReadV02(Stream buffer)
                {
                    var partitionField = Decoder.ReadInt32(buffer);
                    var currentLeaderEpochField = default(int);
                    var fetchOffsetField = Decoder.ReadInt64(buffer);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = default(long);
                    var partitionMaxBytesField = Decoder.ReadInt32(buffer);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField
                    );
                }
                public static void WriteV02(Stream buffer, FetchPartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionField);
                    Encoder.WriteInt64(buffer, message.FetchOffsetField);
                    Encoder.WriteInt32(buffer, message.PartitionMaxBytesField);
                }
                public static FetchPartition ReadV03(Stream buffer)
                {
                    var partitionField = Decoder.ReadInt32(buffer);
                    var currentLeaderEpochField = default(int);
                    var fetchOffsetField = Decoder.ReadInt64(buffer);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = default(long);
                    var partitionMaxBytesField = Decoder.ReadInt32(buffer);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField
                    );
                }
                public static void WriteV03(Stream buffer, FetchPartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionField);
                    Encoder.WriteInt64(buffer, message.FetchOffsetField);
                    Encoder.WriteInt32(buffer, message.PartitionMaxBytesField);
                }
                public static FetchPartition ReadV04(Stream buffer)
                {
                    var partitionField = Decoder.ReadInt32(buffer);
                    var currentLeaderEpochField = default(int);
                    var fetchOffsetField = Decoder.ReadInt64(buffer);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = default(long);
                    var partitionMaxBytesField = Decoder.ReadInt32(buffer);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField
                    );
                }
                public static void WriteV04(Stream buffer, FetchPartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionField);
                    Encoder.WriteInt64(buffer, message.FetchOffsetField);
                    Encoder.WriteInt32(buffer, message.PartitionMaxBytesField);
                }
                public static FetchPartition ReadV05(Stream buffer)
                {
                    var partitionField = Decoder.ReadInt32(buffer);
                    var currentLeaderEpochField = default(int);
                    var fetchOffsetField = Decoder.ReadInt64(buffer);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = Decoder.ReadInt64(buffer);
                    var partitionMaxBytesField = Decoder.ReadInt32(buffer);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField
                    );
                }
                public static void WriteV05(Stream buffer, FetchPartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionField);
                    Encoder.WriteInt64(buffer, message.FetchOffsetField);
                    Encoder.WriteInt64(buffer, message.LogStartOffsetField);
                    Encoder.WriteInt32(buffer, message.PartitionMaxBytesField);
                }
                public static FetchPartition ReadV06(Stream buffer)
                {
                    var partitionField = Decoder.ReadInt32(buffer);
                    var currentLeaderEpochField = default(int);
                    var fetchOffsetField = Decoder.ReadInt64(buffer);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = Decoder.ReadInt64(buffer);
                    var partitionMaxBytesField = Decoder.ReadInt32(buffer);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField
                    );
                }
                public static void WriteV06(Stream buffer, FetchPartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionField);
                    Encoder.WriteInt64(buffer, message.FetchOffsetField);
                    Encoder.WriteInt64(buffer, message.LogStartOffsetField);
                    Encoder.WriteInt32(buffer, message.PartitionMaxBytesField);
                }
                public static FetchPartition ReadV07(Stream buffer)
                {
                    var partitionField = Decoder.ReadInt32(buffer);
                    var currentLeaderEpochField = default(int);
                    var fetchOffsetField = Decoder.ReadInt64(buffer);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = Decoder.ReadInt64(buffer);
                    var partitionMaxBytesField = Decoder.ReadInt32(buffer);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField
                    );
                }
                public static void WriteV07(Stream buffer, FetchPartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionField);
                    Encoder.WriteInt64(buffer, message.FetchOffsetField);
                    Encoder.WriteInt64(buffer, message.LogStartOffsetField);
                    Encoder.WriteInt32(buffer, message.PartitionMaxBytesField);
                }
                public static FetchPartition ReadV08(Stream buffer)
                {
                    var partitionField = Decoder.ReadInt32(buffer);
                    var currentLeaderEpochField = default(int);
                    var fetchOffsetField = Decoder.ReadInt64(buffer);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = Decoder.ReadInt64(buffer);
                    var partitionMaxBytesField = Decoder.ReadInt32(buffer);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField
                    );
                }
                public static void WriteV08(Stream buffer, FetchPartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionField);
                    Encoder.WriteInt64(buffer, message.FetchOffsetField);
                    Encoder.WriteInt64(buffer, message.LogStartOffsetField);
                    Encoder.WriteInt32(buffer, message.PartitionMaxBytesField);
                }
                public static FetchPartition ReadV09(Stream buffer)
                {
                    var partitionField = Decoder.ReadInt32(buffer);
                    var currentLeaderEpochField = Decoder.ReadInt32(buffer);
                    var fetchOffsetField = Decoder.ReadInt64(buffer);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = Decoder.ReadInt64(buffer);
                    var partitionMaxBytesField = Decoder.ReadInt32(buffer);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField
                    );
                }
                public static void WriteV09(Stream buffer, FetchPartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionField);
                    Encoder.WriteInt32(buffer, message.CurrentLeaderEpochField);
                    Encoder.WriteInt64(buffer, message.FetchOffsetField);
                    Encoder.WriteInt64(buffer, message.LogStartOffsetField);
                    Encoder.WriteInt32(buffer, message.PartitionMaxBytesField);
                }
                public static FetchPartition ReadV10(Stream buffer)
                {
                    var partitionField = Decoder.ReadInt32(buffer);
                    var currentLeaderEpochField = Decoder.ReadInt32(buffer);
                    var fetchOffsetField = Decoder.ReadInt64(buffer);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = Decoder.ReadInt64(buffer);
                    var partitionMaxBytesField = Decoder.ReadInt32(buffer);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField
                    );
                }
                public static void WriteV10(Stream buffer, FetchPartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionField);
                    Encoder.WriteInt32(buffer, message.CurrentLeaderEpochField);
                    Encoder.WriteInt64(buffer, message.FetchOffsetField);
                    Encoder.WriteInt64(buffer, message.LogStartOffsetField);
                    Encoder.WriteInt32(buffer, message.PartitionMaxBytesField);
                }
                public static FetchPartition ReadV11(Stream buffer)
                {
                    var partitionField = Decoder.ReadInt32(buffer);
                    var currentLeaderEpochField = Decoder.ReadInt32(buffer);
                    var fetchOffsetField = Decoder.ReadInt64(buffer);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = Decoder.ReadInt64(buffer);
                    var partitionMaxBytesField = Decoder.ReadInt32(buffer);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField
                    );
                }
                public static void WriteV11(Stream buffer, FetchPartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionField);
                    Encoder.WriteInt32(buffer, message.CurrentLeaderEpochField);
                    Encoder.WriteInt64(buffer, message.FetchOffsetField);
                    Encoder.WriteInt64(buffer, message.LogStartOffsetField);
                    Encoder.WriteInt32(buffer, message.PartitionMaxBytesField);
                }
                public static FetchPartition ReadV12(Stream buffer)
                {
                    var partitionField = Decoder.ReadInt32(buffer);
                    var currentLeaderEpochField = Decoder.ReadInt32(buffer);
                    var fetchOffsetField = Decoder.ReadInt64(buffer);
                    var lastFetchedEpochField = Decoder.ReadInt32(buffer);
                    var logStartOffsetField = Decoder.ReadInt64(buffer);
                    var partitionMaxBytesField = Decoder.ReadInt32(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField
                    );
                }
                public static void WriteV12(Stream buffer, FetchPartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionField);
                    Encoder.WriteInt32(buffer, message.CurrentLeaderEpochField);
                    Encoder.WriteInt64(buffer, message.FetchOffsetField);
                    Encoder.WriteInt32(buffer, message.LastFetchedEpochField);
                    Encoder.WriteInt64(buffer, message.LogStartOffsetField);
                    Encoder.WriteInt32(buffer, message.PartitionMaxBytesField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
                public static FetchPartition ReadV13(Stream buffer)
                {
                    var partitionField = Decoder.ReadInt32(buffer);
                    var currentLeaderEpochField = Decoder.ReadInt32(buffer);
                    var fetchOffsetField = Decoder.ReadInt64(buffer);
                    var lastFetchedEpochField = Decoder.ReadInt32(buffer);
                    var logStartOffsetField = Decoder.ReadInt64(buffer);
                    var partitionMaxBytesField = Decoder.ReadInt32(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField
                    );
                }
                public static void WriteV13(Stream buffer, FetchPartition message)
                {
                    Encoder.WriteInt32(buffer, message.PartitionField);
                    Encoder.WriteInt32(buffer, message.CurrentLeaderEpochField);
                    Encoder.WriteInt64(buffer, message.FetchOffsetField);
                    Encoder.WriteInt32(buffer, message.LastFetchedEpochField);
                    Encoder.WriteInt64(buffer, message.LogStartOffsetField);
                    Encoder.WriteInt32(buffer, message.PartitionMaxBytesField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
            }
        }
        private static class ForgottenTopicSerde
        {
            public static ForgottenTopic ReadV07(Stream buffer)
            {
                var topicField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static void WriteV07(Stream buffer, ForgottenTopic message)
            {
                Encoder.WriteString(buffer, message.TopicField);
                Encoder.WriteArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
            }
            public static ForgottenTopic ReadV08(Stream buffer)
            {
                var topicField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static void WriteV08(Stream buffer, ForgottenTopic message)
            {
                Encoder.WriteString(buffer, message.TopicField);
                Encoder.WriteArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
            }
            public static ForgottenTopic ReadV09(Stream buffer)
            {
                var topicField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static void WriteV09(Stream buffer, ForgottenTopic message)
            {
                Encoder.WriteString(buffer, message.TopicField);
                Encoder.WriteArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
            }
            public static ForgottenTopic ReadV10(Stream buffer)
            {
                var topicField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static void WriteV10(Stream buffer, ForgottenTopic message)
            {
                Encoder.WriteString(buffer, message.TopicField);
                Encoder.WriteArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
            }
            public static ForgottenTopic ReadV11(Stream buffer)
            {
                var topicField = Decoder.ReadString(buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static void WriteV11(Stream buffer, ForgottenTopic message)
            {
                Encoder.WriteString(buffer, message.TopicField);
                Encoder.WriteArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
            }
            public static ForgottenTopic ReadV12(Stream buffer)
            {
                var topicField = Decoder.ReadCompactString(buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static void WriteV12(Stream buffer, ForgottenTopic message)
            {
                Encoder.WriteCompactString(buffer, message.TopicField);
                Encoder.WriteCompactArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static ForgottenTopic ReadV13(Stream buffer)
            {
                var topicField = "";
                var topicIdField = Decoder.ReadUuid(buffer);
                var partitionsField = Decoder.ReadCompactArray<int>(buffer, b => Decoder.ReadInt32(b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static void WriteV13(Stream buffer, ForgottenTopic message)
            {
                Encoder.WriteUuid(buffer, message.TopicIdField);
                Encoder.WriteCompactArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
    }
}