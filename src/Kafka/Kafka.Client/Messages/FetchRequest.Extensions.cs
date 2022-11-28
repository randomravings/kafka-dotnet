using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using ForgottenTopic = Kafka.Client.Messages.FetchRequest.ForgottenTopic;
using FetchTopic = Kafka.Client.Messages.FetchRequest.FetchTopic;
using FetchPartition = Kafka.Client.Messages.FetchRequest.FetchTopic.FetchPartition;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class FetchRequestSerde
    {
        private static readonly DecodeDelegate<FetchRequest>[] READ_VERSIONS = {
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
        private static readonly EncodeDelegate<FetchRequest>[] WRITE_VERSIONS = {
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
        public static FetchRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, FetchRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static FetchRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var clusterIdField = default(string?);
            var replicaIdField = Decoder.ReadInt32(ref buffer);
            var maxWaitMsField = Decoder.ReadInt32(ref buffer);
            var minBytesField = Decoder.ReadInt32(ref buffer);
            var maxBytesField = default(int);
            var isolationLevelField = default(sbyte);
            var sessionIdField = default(int);
            var sessionEpochField = default(int);
            var topicsField = Decoder.ReadArray<FetchTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => FetchTopicSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
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
        private static Memory<byte> WriteV00(Memory<byte> buffer, FetchRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ReplicaIdField);
            buffer = Encoder.WriteInt32(buffer, message.MaxWaitMsField);
            buffer = Encoder.WriteInt32(buffer, message.MinBytesField);
            buffer = Encoder.WriteArray<FetchTopic>(buffer, message.TopicsField, (b, i) => FetchTopicSerde.WriteV00(b, i));
            return buffer;
        }
        private static FetchRequest ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var clusterIdField = default(string?);
            var replicaIdField = Decoder.ReadInt32(ref buffer);
            var maxWaitMsField = Decoder.ReadInt32(ref buffer);
            var minBytesField = Decoder.ReadInt32(ref buffer);
            var maxBytesField = default(int);
            var isolationLevelField = default(sbyte);
            var sessionIdField = default(int);
            var sessionEpochField = default(int);
            var topicsField = Decoder.ReadArray<FetchTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => FetchTopicSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
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
        private static Memory<byte> WriteV01(Memory<byte> buffer, FetchRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ReplicaIdField);
            buffer = Encoder.WriteInt32(buffer, message.MaxWaitMsField);
            buffer = Encoder.WriteInt32(buffer, message.MinBytesField);
            buffer = Encoder.WriteArray<FetchTopic>(buffer, message.TopicsField, (b, i) => FetchTopicSerde.WriteV01(b, i));
            return buffer;
        }
        private static FetchRequest ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var clusterIdField = default(string?);
            var replicaIdField = Decoder.ReadInt32(ref buffer);
            var maxWaitMsField = Decoder.ReadInt32(ref buffer);
            var minBytesField = Decoder.ReadInt32(ref buffer);
            var maxBytesField = default(int);
            var isolationLevelField = default(sbyte);
            var sessionIdField = default(int);
            var sessionEpochField = default(int);
            var topicsField = Decoder.ReadArray<FetchTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => FetchTopicSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
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
        private static Memory<byte> WriteV02(Memory<byte> buffer, FetchRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ReplicaIdField);
            buffer = Encoder.WriteInt32(buffer, message.MaxWaitMsField);
            buffer = Encoder.WriteInt32(buffer, message.MinBytesField);
            buffer = Encoder.WriteArray<FetchTopic>(buffer, message.TopicsField, (b, i) => FetchTopicSerde.WriteV02(b, i));
            return buffer;
        }
        private static FetchRequest ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var clusterIdField = default(string?);
            var replicaIdField = Decoder.ReadInt32(ref buffer);
            var maxWaitMsField = Decoder.ReadInt32(ref buffer);
            var minBytesField = Decoder.ReadInt32(ref buffer);
            var maxBytesField = Decoder.ReadInt32(ref buffer);
            var isolationLevelField = default(sbyte);
            var sessionIdField = default(int);
            var sessionEpochField = default(int);
            var topicsField = Decoder.ReadArray<FetchTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => FetchTopicSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
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
        private static Memory<byte> WriteV03(Memory<byte> buffer, FetchRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ReplicaIdField);
            buffer = Encoder.WriteInt32(buffer, message.MaxWaitMsField);
            buffer = Encoder.WriteInt32(buffer, message.MinBytesField);
            buffer = Encoder.WriteInt32(buffer, message.MaxBytesField);
            buffer = Encoder.WriteArray<FetchTopic>(buffer, message.TopicsField, (b, i) => FetchTopicSerde.WriteV03(b, i));
            return buffer;
        }
        private static FetchRequest ReadV04(ref ReadOnlyMemory<byte> buffer)
        {
            var clusterIdField = default(string?);
            var replicaIdField = Decoder.ReadInt32(ref buffer);
            var maxWaitMsField = Decoder.ReadInt32(ref buffer);
            var minBytesField = Decoder.ReadInt32(ref buffer);
            var maxBytesField = Decoder.ReadInt32(ref buffer);
            var isolationLevelField = Decoder.ReadInt8(ref buffer);
            var sessionIdField = default(int);
            var sessionEpochField = default(int);
            var topicsField = Decoder.ReadArray<FetchTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => FetchTopicSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
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
        private static Memory<byte> WriteV04(Memory<byte> buffer, FetchRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ReplicaIdField);
            buffer = Encoder.WriteInt32(buffer, message.MaxWaitMsField);
            buffer = Encoder.WriteInt32(buffer, message.MinBytesField);
            buffer = Encoder.WriteInt32(buffer, message.MaxBytesField);
            buffer = Encoder.WriteInt8(buffer, message.IsolationLevelField);
            buffer = Encoder.WriteArray<FetchTopic>(buffer, message.TopicsField, (b, i) => FetchTopicSerde.WriteV04(b, i));
            return buffer;
        }
        private static FetchRequest ReadV05(ref ReadOnlyMemory<byte> buffer)
        {
            var clusterIdField = default(string?);
            var replicaIdField = Decoder.ReadInt32(ref buffer);
            var maxWaitMsField = Decoder.ReadInt32(ref buffer);
            var minBytesField = Decoder.ReadInt32(ref buffer);
            var maxBytesField = Decoder.ReadInt32(ref buffer);
            var isolationLevelField = Decoder.ReadInt8(ref buffer);
            var sessionIdField = default(int);
            var sessionEpochField = default(int);
            var topicsField = Decoder.ReadArray<FetchTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => FetchTopicSerde.ReadV05(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
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
        private static Memory<byte> WriteV05(Memory<byte> buffer, FetchRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ReplicaIdField);
            buffer = Encoder.WriteInt32(buffer, message.MaxWaitMsField);
            buffer = Encoder.WriteInt32(buffer, message.MinBytesField);
            buffer = Encoder.WriteInt32(buffer, message.MaxBytesField);
            buffer = Encoder.WriteInt8(buffer, message.IsolationLevelField);
            buffer = Encoder.WriteArray<FetchTopic>(buffer, message.TopicsField, (b, i) => FetchTopicSerde.WriteV05(b, i));
            return buffer;
        }
        private static FetchRequest ReadV06(ref ReadOnlyMemory<byte> buffer)
        {
            var clusterIdField = default(string?);
            var replicaIdField = Decoder.ReadInt32(ref buffer);
            var maxWaitMsField = Decoder.ReadInt32(ref buffer);
            var minBytesField = Decoder.ReadInt32(ref buffer);
            var maxBytesField = Decoder.ReadInt32(ref buffer);
            var isolationLevelField = Decoder.ReadInt8(ref buffer);
            var sessionIdField = default(int);
            var sessionEpochField = default(int);
            var topicsField = Decoder.ReadArray<FetchTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => FetchTopicSerde.ReadV06(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
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
        private static Memory<byte> WriteV06(Memory<byte> buffer, FetchRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ReplicaIdField);
            buffer = Encoder.WriteInt32(buffer, message.MaxWaitMsField);
            buffer = Encoder.WriteInt32(buffer, message.MinBytesField);
            buffer = Encoder.WriteInt32(buffer, message.MaxBytesField);
            buffer = Encoder.WriteInt8(buffer, message.IsolationLevelField);
            buffer = Encoder.WriteArray<FetchTopic>(buffer, message.TopicsField, (b, i) => FetchTopicSerde.WriteV06(b, i));
            return buffer;
        }
        private static FetchRequest ReadV07(ref ReadOnlyMemory<byte> buffer)
        {
            var clusterIdField = default(string?);
            var replicaIdField = Decoder.ReadInt32(ref buffer);
            var maxWaitMsField = Decoder.ReadInt32(ref buffer);
            var minBytesField = Decoder.ReadInt32(ref buffer);
            var maxBytesField = Decoder.ReadInt32(ref buffer);
            var isolationLevelField = Decoder.ReadInt8(ref buffer);
            var sessionIdField = Decoder.ReadInt32(ref buffer);
            var sessionEpochField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadArray<FetchTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => FetchTopicSerde.ReadV07(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var forgottenTopicsDataField = Decoder.ReadArray<ForgottenTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => ForgottenTopicSerde.ReadV07(ref b)) ?? throw new NullReferenceException("Null not allowed for 'ForgottenTopicsData'");
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
        private static Memory<byte> WriteV07(Memory<byte> buffer, FetchRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ReplicaIdField);
            buffer = Encoder.WriteInt32(buffer, message.MaxWaitMsField);
            buffer = Encoder.WriteInt32(buffer, message.MinBytesField);
            buffer = Encoder.WriteInt32(buffer, message.MaxBytesField);
            buffer = Encoder.WriteInt8(buffer, message.IsolationLevelField);
            buffer = Encoder.WriteInt32(buffer, message.SessionIdField);
            buffer = Encoder.WriteInt32(buffer, message.SessionEpochField);
            buffer = Encoder.WriteArray<FetchTopic>(buffer, message.TopicsField, (b, i) => FetchTopicSerde.WriteV07(b, i));
            buffer = Encoder.WriteArray<ForgottenTopic>(buffer, message.ForgottenTopicsDataField, (b, i) => ForgottenTopicSerde.WriteV07(b, i));
            return buffer;
        }
        private static FetchRequest ReadV08(ref ReadOnlyMemory<byte> buffer)
        {
            var clusterIdField = default(string?);
            var replicaIdField = Decoder.ReadInt32(ref buffer);
            var maxWaitMsField = Decoder.ReadInt32(ref buffer);
            var minBytesField = Decoder.ReadInt32(ref buffer);
            var maxBytesField = Decoder.ReadInt32(ref buffer);
            var isolationLevelField = Decoder.ReadInt8(ref buffer);
            var sessionIdField = Decoder.ReadInt32(ref buffer);
            var sessionEpochField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadArray<FetchTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => FetchTopicSerde.ReadV08(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var forgottenTopicsDataField = Decoder.ReadArray<ForgottenTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => ForgottenTopicSerde.ReadV08(ref b)) ?? throw new NullReferenceException("Null not allowed for 'ForgottenTopicsData'");
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
        private static Memory<byte> WriteV08(Memory<byte> buffer, FetchRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ReplicaIdField);
            buffer = Encoder.WriteInt32(buffer, message.MaxWaitMsField);
            buffer = Encoder.WriteInt32(buffer, message.MinBytesField);
            buffer = Encoder.WriteInt32(buffer, message.MaxBytesField);
            buffer = Encoder.WriteInt8(buffer, message.IsolationLevelField);
            buffer = Encoder.WriteInt32(buffer, message.SessionIdField);
            buffer = Encoder.WriteInt32(buffer, message.SessionEpochField);
            buffer = Encoder.WriteArray<FetchTopic>(buffer, message.TopicsField, (b, i) => FetchTopicSerde.WriteV08(b, i));
            buffer = Encoder.WriteArray<ForgottenTopic>(buffer, message.ForgottenTopicsDataField, (b, i) => ForgottenTopicSerde.WriteV08(b, i));
            return buffer;
        }
        private static FetchRequest ReadV09(ref ReadOnlyMemory<byte> buffer)
        {
            var clusterIdField = default(string?);
            var replicaIdField = Decoder.ReadInt32(ref buffer);
            var maxWaitMsField = Decoder.ReadInt32(ref buffer);
            var minBytesField = Decoder.ReadInt32(ref buffer);
            var maxBytesField = Decoder.ReadInt32(ref buffer);
            var isolationLevelField = Decoder.ReadInt8(ref buffer);
            var sessionIdField = Decoder.ReadInt32(ref buffer);
            var sessionEpochField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadArray<FetchTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => FetchTopicSerde.ReadV09(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var forgottenTopicsDataField = Decoder.ReadArray<ForgottenTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => ForgottenTopicSerde.ReadV09(ref b)) ?? throw new NullReferenceException("Null not allowed for 'ForgottenTopicsData'");
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
        private static Memory<byte> WriteV09(Memory<byte> buffer, FetchRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ReplicaIdField);
            buffer = Encoder.WriteInt32(buffer, message.MaxWaitMsField);
            buffer = Encoder.WriteInt32(buffer, message.MinBytesField);
            buffer = Encoder.WriteInt32(buffer, message.MaxBytesField);
            buffer = Encoder.WriteInt8(buffer, message.IsolationLevelField);
            buffer = Encoder.WriteInt32(buffer, message.SessionIdField);
            buffer = Encoder.WriteInt32(buffer, message.SessionEpochField);
            buffer = Encoder.WriteArray<FetchTopic>(buffer, message.TopicsField, (b, i) => FetchTopicSerde.WriteV09(b, i));
            buffer = Encoder.WriteArray<ForgottenTopic>(buffer, message.ForgottenTopicsDataField, (b, i) => ForgottenTopicSerde.WriteV09(b, i));
            return buffer;
        }
        private static FetchRequest ReadV10(ref ReadOnlyMemory<byte> buffer)
        {
            var clusterIdField = default(string?);
            var replicaIdField = Decoder.ReadInt32(ref buffer);
            var maxWaitMsField = Decoder.ReadInt32(ref buffer);
            var minBytesField = Decoder.ReadInt32(ref buffer);
            var maxBytesField = Decoder.ReadInt32(ref buffer);
            var isolationLevelField = Decoder.ReadInt8(ref buffer);
            var sessionIdField = Decoder.ReadInt32(ref buffer);
            var sessionEpochField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadArray<FetchTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => FetchTopicSerde.ReadV10(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var forgottenTopicsDataField = Decoder.ReadArray<ForgottenTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => ForgottenTopicSerde.ReadV10(ref b)) ?? throw new NullReferenceException("Null not allowed for 'ForgottenTopicsData'");
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
        private static Memory<byte> WriteV10(Memory<byte> buffer, FetchRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ReplicaIdField);
            buffer = Encoder.WriteInt32(buffer, message.MaxWaitMsField);
            buffer = Encoder.WriteInt32(buffer, message.MinBytesField);
            buffer = Encoder.WriteInt32(buffer, message.MaxBytesField);
            buffer = Encoder.WriteInt8(buffer, message.IsolationLevelField);
            buffer = Encoder.WriteInt32(buffer, message.SessionIdField);
            buffer = Encoder.WriteInt32(buffer, message.SessionEpochField);
            buffer = Encoder.WriteArray<FetchTopic>(buffer, message.TopicsField, (b, i) => FetchTopicSerde.WriteV10(b, i));
            buffer = Encoder.WriteArray<ForgottenTopic>(buffer, message.ForgottenTopicsDataField, (b, i) => ForgottenTopicSerde.WriteV10(b, i));
            return buffer;
        }
        private static FetchRequest ReadV11(ref ReadOnlyMemory<byte> buffer)
        {
            var clusterIdField = default(string?);
            var replicaIdField = Decoder.ReadInt32(ref buffer);
            var maxWaitMsField = Decoder.ReadInt32(ref buffer);
            var minBytesField = Decoder.ReadInt32(ref buffer);
            var maxBytesField = Decoder.ReadInt32(ref buffer);
            var isolationLevelField = Decoder.ReadInt8(ref buffer);
            var sessionIdField = Decoder.ReadInt32(ref buffer);
            var sessionEpochField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadArray<FetchTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => FetchTopicSerde.ReadV11(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var forgottenTopicsDataField = Decoder.ReadArray<ForgottenTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => ForgottenTopicSerde.ReadV11(ref b)) ?? throw new NullReferenceException("Null not allowed for 'ForgottenTopicsData'");
            var rackIdField = Decoder.ReadString(ref buffer);
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
        private static Memory<byte> WriteV11(Memory<byte> buffer, FetchRequest message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ReplicaIdField);
            buffer = Encoder.WriteInt32(buffer, message.MaxWaitMsField);
            buffer = Encoder.WriteInt32(buffer, message.MinBytesField);
            buffer = Encoder.WriteInt32(buffer, message.MaxBytesField);
            buffer = Encoder.WriteInt8(buffer, message.IsolationLevelField);
            buffer = Encoder.WriteInt32(buffer, message.SessionIdField);
            buffer = Encoder.WriteInt32(buffer, message.SessionEpochField);
            buffer = Encoder.WriteArray<FetchTopic>(buffer, message.TopicsField, (b, i) => FetchTopicSerde.WriteV11(b, i));
            buffer = Encoder.WriteArray<ForgottenTopic>(buffer, message.ForgottenTopicsDataField, (b, i) => ForgottenTopicSerde.WriteV11(b, i));
            buffer = Encoder.WriteString(buffer, message.RackIdField);
            return buffer;
        }
        private static FetchRequest ReadV12(ref ReadOnlyMemory<byte> buffer)
        {
            var clusterIdField = default(string?);
            var replicaIdField = Decoder.ReadInt32(ref buffer);
            var maxWaitMsField = Decoder.ReadInt32(ref buffer);
            var minBytesField = Decoder.ReadInt32(ref buffer);
            var maxBytesField = Decoder.ReadInt32(ref buffer);
            var isolationLevelField = Decoder.ReadInt8(ref buffer);
            var sessionIdField = Decoder.ReadInt32(ref buffer);
            var sessionEpochField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadCompactArray<FetchTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => FetchTopicSerde.ReadV12(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var forgottenTopicsDataField = Decoder.ReadCompactArray<ForgottenTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => ForgottenTopicSerde.ReadV12(ref b)) ?? throw new NullReferenceException("Null not allowed for 'ForgottenTopicsData'");
            var rackIdField = Decoder.ReadCompactString(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
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
        private static Memory<byte> WriteV12(Memory<byte> buffer, FetchRequest message)
        {
            buffer = Encoder.WriteCompactNullableString(buffer, message.ClusterIdField);
            buffer = Encoder.WriteInt32(buffer, message.ReplicaIdField);
            buffer = Encoder.WriteInt32(buffer, message.MaxWaitMsField);
            buffer = Encoder.WriteInt32(buffer, message.MinBytesField);
            buffer = Encoder.WriteInt32(buffer, message.MaxBytesField);
            buffer = Encoder.WriteInt8(buffer, message.IsolationLevelField);
            buffer = Encoder.WriteInt32(buffer, message.SessionIdField);
            buffer = Encoder.WriteInt32(buffer, message.SessionEpochField);
            buffer = Encoder.WriteCompactArray<FetchTopic>(buffer, message.TopicsField, (b, i) => FetchTopicSerde.WriteV12(b, i));
            buffer = Encoder.WriteCompactArray<ForgottenTopic>(buffer, message.ForgottenTopicsDataField, (b, i) => ForgottenTopicSerde.WriteV12(b, i));
            buffer = Encoder.WriteCompactString(buffer, message.RackIdField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static FetchRequest ReadV13(ref ReadOnlyMemory<byte> buffer)
        {
            var clusterIdField = default(string?);
            var replicaIdField = Decoder.ReadInt32(ref buffer);
            var maxWaitMsField = Decoder.ReadInt32(ref buffer);
            var minBytesField = Decoder.ReadInt32(ref buffer);
            var maxBytesField = Decoder.ReadInt32(ref buffer);
            var isolationLevelField = Decoder.ReadInt8(ref buffer);
            var sessionIdField = Decoder.ReadInt32(ref buffer);
            var sessionEpochField = Decoder.ReadInt32(ref buffer);
            var topicsField = Decoder.ReadCompactArray<FetchTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => FetchTopicSerde.ReadV13(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Topics'");
            var forgottenTopicsDataField = Decoder.ReadCompactArray<ForgottenTopic>(ref buffer, (ref ReadOnlyMemory<byte> b) => ForgottenTopicSerde.ReadV13(ref b)) ?? throw new NullReferenceException("Null not allowed for 'ForgottenTopicsData'");
            var rackIdField = Decoder.ReadCompactString(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
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
        private static Memory<byte> WriteV13(Memory<byte> buffer, FetchRequest message)
        {
            buffer = Encoder.WriteCompactNullableString(buffer, message.ClusterIdField);
            buffer = Encoder.WriteInt32(buffer, message.ReplicaIdField);
            buffer = Encoder.WriteInt32(buffer, message.MaxWaitMsField);
            buffer = Encoder.WriteInt32(buffer, message.MinBytesField);
            buffer = Encoder.WriteInt32(buffer, message.MaxBytesField);
            buffer = Encoder.WriteInt8(buffer, message.IsolationLevelField);
            buffer = Encoder.WriteInt32(buffer, message.SessionIdField);
            buffer = Encoder.WriteInt32(buffer, message.SessionEpochField);
            buffer = Encoder.WriteCompactArray<FetchTopic>(buffer, message.TopicsField, (b, i) => FetchTopicSerde.WriteV13(b, i));
            buffer = Encoder.WriteCompactArray<ForgottenTopic>(buffer, message.ForgottenTopicsDataField, (b, i) => ForgottenTopicSerde.WriteV13(b, i));
            buffer = Encoder.WriteCompactString(buffer, message.RackIdField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class ForgottenTopicSerde
        {
            public static ForgottenTopic ReadV07(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV07(Memory<byte> buffer, ForgottenTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicField);
                buffer = Encoder.WriteArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
                return buffer;
            }
            public static ForgottenTopic ReadV08(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV08(Memory<byte> buffer, ForgottenTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicField);
                buffer = Encoder.WriteArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
                return buffer;
            }
            public static ForgottenTopic ReadV09(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV09(Memory<byte> buffer, ForgottenTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicField);
                buffer = Encoder.WriteArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
                return buffer;
            }
            public static ForgottenTopic ReadV10(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV10(Memory<byte> buffer, ForgottenTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicField);
                buffer = Encoder.WriteArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
                return buffer;
            }
            public static ForgottenTopic ReadV11(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV11(Memory<byte> buffer, ForgottenTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicField);
                buffer = Encoder.WriteArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
                return buffer;
            }
            public static ForgottenTopic ReadV12(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadCompactString(ref buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV12(Memory<byte> buffer, ForgottenTopic message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.TopicField);
                buffer = Encoder.WriteCompactArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static ForgottenTopic ReadV13(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = "";
                var topicIdField = Decoder.ReadUuid(ref buffer);
                var partitionsField = Decoder.ReadCompactArray<int>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadInt32(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV13(Memory<byte> buffer, ForgottenTopic message)
            {
                buffer = Encoder.WriteUuid(buffer, message.TopicIdField);
                buffer = Encoder.WriteCompactArray<int>(buffer, message.PartitionsField, (b, i) => Encoder.WriteInt32(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
        private static class FetchTopicSerde
        {
            public static FetchTopic ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<FetchPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => FetchPartitionSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, FetchTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicField);
                buffer = Encoder.WriteArray<FetchPartition>(buffer, message.PartitionsField, (b, i) => FetchPartitionSerde.WriteV00(b, i));
                return buffer;
            }
            public static FetchTopic ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<FetchPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => FetchPartitionSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, FetchTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicField);
                buffer = Encoder.WriteArray<FetchPartition>(buffer, message.PartitionsField, (b, i) => FetchPartitionSerde.WriteV01(b, i));
                return buffer;
            }
            public static FetchTopic ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<FetchPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => FetchPartitionSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, FetchTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicField);
                buffer = Encoder.WriteArray<FetchPartition>(buffer, message.PartitionsField, (b, i) => FetchPartitionSerde.WriteV02(b, i));
                return buffer;
            }
            public static FetchTopic ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<FetchPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => FetchPartitionSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, FetchTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicField);
                buffer = Encoder.WriteArray<FetchPartition>(buffer, message.PartitionsField, (b, i) => FetchPartitionSerde.WriteV03(b, i));
                return buffer;
            }
            public static FetchTopic ReadV04(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<FetchPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => FetchPartitionSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV04(Memory<byte> buffer, FetchTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicField);
                buffer = Encoder.WriteArray<FetchPartition>(buffer, message.PartitionsField, (b, i) => FetchPartitionSerde.WriteV04(b, i));
                return buffer;
            }
            public static FetchTopic ReadV05(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<FetchPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => FetchPartitionSerde.ReadV05(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV05(Memory<byte> buffer, FetchTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicField);
                buffer = Encoder.WriteArray<FetchPartition>(buffer, message.PartitionsField, (b, i) => FetchPartitionSerde.WriteV05(b, i));
                return buffer;
            }
            public static FetchTopic ReadV06(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<FetchPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => FetchPartitionSerde.ReadV06(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV06(Memory<byte> buffer, FetchTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicField);
                buffer = Encoder.WriteArray<FetchPartition>(buffer, message.PartitionsField, (b, i) => FetchPartitionSerde.WriteV06(b, i));
                return buffer;
            }
            public static FetchTopic ReadV07(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<FetchPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => FetchPartitionSerde.ReadV07(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV07(Memory<byte> buffer, FetchTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicField);
                buffer = Encoder.WriteArray<FetchPartition>(buffer, message.PartitionsField, (b, i) => FetchPartitionSerde.WriteV07(b, i));
                return buffer;
            }
            public static FetchTopic ReadV08(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<FetchPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => FetchPartitionSerde.ReadV08(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV08(Memory<byte> buffer, FetchTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicField);
                buffer = Encoder.WriteArray<FetchPartition>(buffer, message.PartitionsField, (b, i) => FetchPartitionSerde.WriteV08(b, i));
                return buffer;
            }
            public static FetchTopic ReadV09(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<FetchPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => FetchPartitionSerde.ReadV09(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV09(Memory<byte> buffer, FetchTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicField);
                buffer = Encoder.WriteArray<FetchPartition>(buffer, message.PartitionsField, (b, i) => FetchPartitionSerde.WriteV09(b, i));
                return buffer;
            }
            public static FetchTopic ReadV10(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<FetchPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => FetchPartitionSerde.ReadV10(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV10(Memory<byte> buffer, FetchTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicField);
                buffer = Encoder.WriteArray<FetchPartition>(buffer, message.PartitionsField, (b, i) => FetchPartitionSerde.WriteV10(b, i));
                return buffer;
            }
            public static FetchTopic ReadV11(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadString(ref buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadArray<FetchPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => FetchPartitionSerde.ReadV11(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV11(Memory<byte> buffer, FetchTopic message)
            {
                buffer = Encoder.WriteString(buffer, message.TopicField);
                buffer = Encoder.WriteArray<FetchPartition>(buffer, message.PartitionsField, (b, i) => FetchPartitionSerde.WriteV11(b, i));
                return buffer;
            }
            public static FetchTopic ReadV12(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = Decoder.ReadCompactString(ref buffer);
                var topicIdField = default(Guid);
                var partitionsField = Decoder.ReadCompactArray<FetchPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => FetchPartitionSerde.ReadV12(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV12(Memory<byte> buffer, FetchTopic message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.TopicField);
                buffer = Encoder.WriteCompactArray<FetchPartition>(buffer, message.PartitionsField, (b, i) => FetchPartitionSerde.WriteV12(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static FetchTopic ReadV13(ref ReadOnlyMemory<byte> buffer)
            {
                var topicField = "";
                var topicIdField = Decoder.ReadUuid(ref buffer);
                var partitionsField = Decoder.ReadCompactArray<FetchPartition>(ref buffer, (ref ReadOnlyMemory<byte> b) => FetchPartitionSerde.ReadV13(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Partitions'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    topicField,
                    topicIdField,
                    partitionsField
                );
            }
            public static Memory<byte> WriteV13(Memory<byte> buffer, FetchTopic message)
            {
                buffer = Encoder.WriteUuid(buffer, message.TopicIdField);
                buffer = Encoder.WriteCompactArray<FetchPartition>(buffer, message.PartitionsField, (b, i) => FetchPartitionSerde.WriteV13(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class FetchPartitionSerde
            {
                public static FetchPartition ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionField = Decoder.ReadInt32(ref buffer);
                    var currentLeaderEpochField = default(int);
                    var fetchOffsetField = Decoder.ReadInt64(ref buffer);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = default(long);
                    var partitionMaxBytesField = Decoder.ReadInt32(ref buffer);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField
                    );
                }
                public static Memory<byte> WriteV00(Memory<byte> buffer, FetchPartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionField);
                    buffer = Encoder.WriteInt64(buffer, message.FetchOffsetField);
                    buffer = Encoder.WriteInt32(buffer, message.PartitionMaxBytesField);
                    return buffer;
                }
                public static FetchPartition ReadV01(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionField = Decoder.ReadInt32(ref buffer);
                    var currentLeaderEpochField = default(int);
                    var fetchOffsetField = Decoder.ReadInt64(ref buffer);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = default(long);
                    var partitionMaxBytesField = Decoder.ReadInt32(ref buffer);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField
                    );
                }
                public static Memory<byte> WriteV01(Memory<byte> buffer, FetchPartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionField);
                    buffer = Encoder.WriteInt64(buffer, message.FetchOffsetField);
                    buffer = Encoder.WriteInt32(buffer, message.PartitionMaxBytesField);
                    return buffer;
                }
                public static FetchPartition ReadV02(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionField = Decoder.ReadInt32(ref buffer);
                    var currentLeaderEpochField = default(int);
                    var fetchOffsetField = Decoder.ReadInt64(ref buffer);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = default(long);
                    var partitionMaxBytesField = Decoder.ReadInt32(ref buffer);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField
                    );
                }
                public static Memory<byte> WriteV02(Memory<byte> buffer, FetchPartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionField);
                    buffer = Encoder.WriteInt64(buffer, message.FetchOffsetField);
                    buffer = Encoder.WriteInt32(buffer, message.PartitionMaxBytesField);
                    return buffer;
                }
                public static FetchPartition ReadV03(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionField = Decoder.ReadInt32(ref buffer);
                    var currentLeaderEpochField = default(int);
                    var fetchOffsetField = Decoder.ReadInt64(ref buffer);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = default(long);
                    var partitionMaxBytesField = Decoder.ReadInt32(ref buffer);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField
                    );
                }
                public static Memory<byte> WriteV03(Memory<byte> buffer, FetchPartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionField);
                    buffer = Encoder.WriteInt64(buffer, message.FetchOffsetField);
                    buffer = Encoder.WriteInt32(buffer, message.PartitionMaxBytesField);
                    return buffer;
                }
                public static FetchPartition ReadV04(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionField = Decoder.ReadInt32(ref buffer);
                    var currentLeaderEpochField = default(int);
                    var fetchOffsetField = Decoder.ReadInt64(ref buffer);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = default(long);
                    var partitionMaxBytesField = Decoder.ReadInt32(ref buffer);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField
                    );
                }
                public static Memory<byte> WriteV04(Memory<byte> buffer, FetchPartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionField);
                    buffer = Encoder.WriteInt64(buffer, message.FetchOffsetField);
                    buffer = Encoder.WriteInt32(buffer, message.PartitionMaxBytesField);
                    return buffer;
                }
                public static FetchPartition ReadV05(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionField = Decoder.ReadInt32(ref buffer);
                    var currentLeaderEpochField = default(int);
                    var fetchOffsetField = Decoder.ReadInt64(ref buffer);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = Decoder.ReadInt64(ref buffer);
                    var partitionMaxBytesField = Decoder.ReadInt32(ref buffer);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField
                    );
                }
                public static Memory<byte> WriteV05(Memory<byte> buffer, FetchPartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionField);
                    buffer = Encoder.WriteInt64(buffer, message.FetchOffsetField);
                    buffer = Encoder.WriteInt64(buffer, message.LogStartOffsetField);
                    buffer = Encoder.WriteInt32(buffer, message.PartitionMaxBytesField);
                    return buffer;
                }
                public static FetchPartition ReadV06(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionField = Decoder.ReadInt32(ref buffer);
                    var currentLeaderEpochField = default(int);
                    var fetchOffsetField = Decoder.ReadInt64(ref buffer);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = Decoder.ReadInt64(ref buffer);
                    var partitionMaxBytesField = Decoder.ReadInt32(ref buffer);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField
                    );
                }
                public static Memory<byte> WriteV06(Memory<byte> buffer, FetchPartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionField);
                    buffer = Encoder.WriteInt64(buffer, message.FetchOffsetField);
                    buffer = Encoder.WriteInt64(buffer, message.LogStartOffsetField);
                    buffer = Encoder.WriteInt32(buffer, message.PartitionMaxBytesField);
                    return buffer;
                }
                public static FetchPartition ReadV07(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionField = Decoder.ReadInt32(ref buffer);
                    var currentLeaderEpochField = default(int);
                    var fetchOffsetField = Decoder.ReadInt64(ref buffer);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = Decoder.ReadInt64(ref buffer);
                    var partitionMaxBytesField = Decoder.ReadInt32(ref buffer);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField
                    );
                }
                public static Memory<byte> WriteV07(Memory<byte> buffer, FetchPartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionField);
                    buffer = Encoder.WriteInt64(buffer, message.FetchOffsetField);
                    buffer = Encoder.WriteInt64(buffer, message.LogStartOffsetField);
                    buffer = Encoder.WriteInt32(buffer, message.PartitionMaxBytesField);
                    return buffer;
                }
                public static FetchPartition ReadV08(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionField = Decoder.ReadInt32(ref buffer);
                    var currentLeaderEpochField = default(int);
                    var fetchOffsetField = Decoder.ReadInt64(ref buffer);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = Decoder.ReadInt64(ref buffer);
                    var partitionMaxBytesField = Decoder.ReadInt32(ref buffer);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField
                    );
                }
                public static Memory<byte> WriteV08(Memory<byte> buffer, FetchPartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionField);
                    buffer = Encoder.WriteInt64(buffer, message.FetchOffsetField);
                    buffer = Encoder.WriteInt64(buffer, message.LogStartOffsetField);
                    buffer = Encoder.WriteInt32(buffer, message.PartitionMaxBytesField);
                    return buffer;
                }
                public static FetchPartition ReadV09(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionField = Decoder.ReadInt32(ref buffer);
                    var currentLeaderEpochField = Decoder.ReadInt32(ref buffer);
                    var fetchOffsetField = Decoder.ReadInt64(ref buffer);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = Decoder.ReadInt64(ref buffer);
                    var partitionMaxBytesField = Decoder.ReadInt32(ref buffer);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField
                    );
                }
                public static Memory<byte> WriteV09(Memory<byte> buffer, FetchPartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionField);
                    buffer = Encoder.WriteInt32(buffer, message.CurrentLeaderEpochField);
                    buffer = Encoder.WriteInt64(buffer, message.FetchOffsetField);
                    buffer = Encoder.WriteInt64(buffer, message.LogStartOffsetField);
                    buffer = Encoder.WriteInt32(buffer, message.PartitionMaxBytesField);
                    return buffer;
                }
                public static FetchPartition ReadV10(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionField = Decoder.ReadInt32(ref buffer);
                    var currentLeaderEpochField = Decoder.ReadInt32(ref buffer);
                    var fetchOffsetField = Decoder.ReadInt64(ref buffer);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = Decoder.ReadInt64(ref buffer);
                    var partitionMaxBytesField = Decoder.ReadInt32(ref buffer);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField
                    );
                }
                public static Memory<byte> WriteV10(Memory<byte> buffer, FetchPartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionField);
                    buffer = Encoder.WriteInt32(buffer, message.CurrentLeaderEpochField);
                    buffer = Encoder.WriteInt64(buffer, message.FetchOffsetField);
                    buffer = Encoder.WriteInt64(buffer, message.LogStartOffsetField);
                    buffer = Encoder.WriteInt32(buffer, message.PartitionMaxBytesField);
                    return buffer;
                }
                public static FetchPartition ReadV11(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionField = Decoder.ReadInt32(ref buffer);
                    var currentLeaderEpochField = Decoder.ReadInt32(ref buffer);
                    var fetchOffsetField = Decoder.ReadInt64(ref buffer);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = Decoder.ReadInt64(ref buffer);
                    var partitionMaxBytesField = Decoder.ReadInt32(ref buffer);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField
                    );
                }
                public static Memory<byte> WriteV11(Memory<byte> buffer, FetchPartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionField);
                    buffer = Encoder.WriteInt32(buffer, message.CurrentLeaderEpochField);
                    buffer = Encoder.WriteInt64(buffer, message.FetchOffsetField);
                    buffer = Encoder.WriteInt64(buffer, message.LogStartOffsetField);
                    buffer = Encoder.WriteInt32(buffer, message.PartitionMaxBytesField);
                    return buffer;
                }
                public static FetchPartition ReadV12(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionField = Decoder.ReadInt32(ref buffer);
                    var currentLeaderEpochField = Decoder.ReadInt32(ref buffer);
                    var fetchOffsetField = Decoder.ReadInt64(ref buffer);
                    var lastFetchedEpochField = Decoder.ReadInt32(ref buffer);
                    var logStartOffsetField = Decoder.ReadInt64(ref buffer);
                    var partitionMaxBytesField = Decoder.ReadInt32(ref buffer);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField
                    );
                }
                public static Memory<byte> WriteV12(Memory<byte> buffer, FetchPartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionField);
                    buffer = Encoder.WriteInt32(buffer, message.CurrentLeaderEpochField);
                    buffer = Encoder.WriteInt64(buffer, message.FetchOffsetField);
                    buffer = Encoder.WriteInt32(buffer, message.LastFetchedEpochField);
                    buffer = Encoder.WriteInt64(buffer, message.LogStartOffsetField);
                    buffer = Encoder.WriteInt32(buffer, message.PartitionMaxBytesField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
                public static FetchPartition ReadV13(ref ReadOnlyMemory<byte> buffer)
                {
                    var partitionField = Decoder.ReadInt32(ref buffer);
                    var currentLeaderEpochField = Decoder.ReadInt32(ref buffer);
                    var fetchOffsetField = Decoder.ReadInt64(ref buffer);
                    var lastFetchedEpochField = Decoder.ReadInt32(ref buffer);
                    var logStartOffsetField = Decoder.ReadInt64(ref buffer);
                    var partitionMaxBytesField = Decoder.ReadInt32(ref buffer);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField
                    );
                }
                public static Memory<byte> WriteV13(Memory<byte> buffer, FetchPartition message)
                {
                    buffer = Encoder.WriteInt32(buffer, message.PartitionField);
                    buffer = Encoder.WriteInt32(buffer, message.CurrentLeaderEpochField);
                    buffer = Encoder.WriteInt64(buffer, message.FetchOffsetField);
                    buffer = Encoder.WriteInt32(buffer, message.LastFetchedEpochField);
                    buffer = Encoder.WriteInt64(buffer, message.LogStartOffsetField);
                    buffer = Encoder.WriteInt32(buffer, message.PartitionMaxBytesField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
            }
        }
    }
}