using FetchPartition = Kafka.Client.Messages.FetchRequest.FetchTopic.FetchPartition;
using FetchTopic = Kafka.Client.Messages.FetchRequest.FetchTopic;
using ForgottenTopic = Kafka.Client.Messages.FetchRequest.ForgottenTopic;
using Kafka.Common.Encoding;
using Kafka.Common.Exceptions;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Version = Kafka.Common.Model.Version;

namespace Kafka.Client.Messages.Serdes
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class FetchRequestSerde
    {
        private static readonly ApiKey API_KEY = new(1);
        private static readonly VersionRange API_VERSIONS = new(0, 13);
        private static readonly VersionRange FLEXBILE_VERSIONS = new (12, 32767);
        public static IEncoder<RequestHeader, FetchRequest> CreateEncoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 13 ? apiVersion : new Version(13);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerEncoder = RequestHeaderSerde.CreateEncoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Encoder<RequestHeader, FetchRequest>(API_KEY, 0, flexible, headerEncoder, WriteV0);
                case 1:
                    return new Encoder<RequestHeader, FetchRequest>(API_KEY, 1, flexible, headerEncoder, WriteV1);
                case 2:
                    return new Encoder<RequestHeader, FetchRequest>(API_KEY, 2, flexible, headerEncoder, WriteV2);
                case 3:
                    return new Encoder<RequestHeader, FetchRequest>(API_KEY, 3, flexible, headerEncoder, WriteV3);
                case 4:
                    return new Encoder<RequestHeader, FetchRequest>(API_KEY, 4, flexible, headerEncoder, WriteV4);
                case 5:
                    return new Encoder<RequestHeader, FetchRequest>(API_KEY, 5, flexible, headerEncoder, WriteV5);
                case 6:
                    return new Encoder<RequestHeader, FetchRequest>(API_KEY, 6, flexible, headerEncoder, WriteV6);
                case 7:
                    return new Encoder<RequestHeader, FetchRequest>(API_KEY, 7, flexible, headerEncoder, WriteV7);
                case 8:
                    return new Encoder<RequestHeader, FetchRequest>(API_KEY, 8, flexible, headerEncoder, WriteV8);
                case 9:
                    return new Encoder<RequestHeader, FetchRequest>(API_KEY, 9, flexible, headerEncoder, WriteV9);
                case 10:
                    return new Encoder<RequestHeader, FetchRequest>(API_KEY, 10, flexible, headerEncoder, WriteV10);
                case 11:
                    return new Encoder<RequestHeader, FetchRequest>(API_KEY, 11, flexible, headerEncoder, WriteV11);
                case 12:
                    return new Encoder<RequestHeader, FetchRequest>(API_KEY, 12, flexible, headerEncoder, WriteV12);
                case 13:
                    return new Encoder<RequestHeader, FetchRequest>(API_KEY, 13, flexible, headerEncoder, WriteV13);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        public static IDecoder<RequestHeader, FetchRequest> CreateDecoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 13 ? apiVersion : new Version(13);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerDecoder = RequestHeaderSerde.CreateDecoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Decoder<RequestHeader, FetchRequest>(API_KEY, 0, flexible, headerDecoder, ReadV0);
                case 1:
                    return new Decoder<RequestHeader, FetchRequest>(API_KEY, 1, flexible, headerDecoder, ReadV1);
                case 2:
                    return new Decoder<RequestHeader, FetchRequest>(API_KEY, 2, flexible, headerDecoder, ReadV2);
                case 3:
                    return new Decoder<RequestHeader, FetchRequest>(API_KEY, 3, flexible, headerDecoder, ReadV3);
                case 4:
                    return new Decoder<RequestHeader, FetchRequest>(API_KEY, 4, flexible, headerDecoder, ReadV4);
                case 5:
                    return new Decoder<RequestHeader, FetchRequest>(API_KEY, 5, flexible, headerDecoder, ReadV5);
                case 6:
                    return new Decoder<RequestHeader, FetchRequest>(API_KEY, 6, flexible, headerDecoder, ReadV6);
                case 7:
                    return new Decoder<RequestHeader, FetchRequest>(API_KEY, 7, flexible, headerDecoder, ReadV7);
                case 8:
                    return new Decoder<RequestHeader, FetchRequest>(API_KEY, 8, flexible, headerDecoder, ReadV8);
                case 9:
                    return new Decoder<RequestHeader, FetchRequest>(API_KEY, 9, flexible, headerDecoder, ReadV9);
                case 10:
                    return new Decoder<RequestHeader, FetchRequest>(API_KEY, 10, flexible, headerDecoder, ReadV10);
                case 11:
                    return new Decoder<RequestHeader, FetchRequest>(API_KEY, 11, flexible, headerDecoder, ReadV11);
                case 12:
                    return new Decoder<RequestHeader, FetchRequest>(API_KEY, 12, flexible, headerDecoder, ReadV12);
                case 13:
                    return new Decoder<RequestHeader, FetchRequest>(API_KEY, 13, flexible, headerDecoder, ReadV13);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        private static int WriteV0(byte[] buffer, int index, FetchRequest message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxWaitMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MinBytesField);
            index = BinaryEncoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicSerde.WriteV0);
            return index;
        }
        private static (int Offset, FetchRequest Value) ReadV0(byte[] buffer, int index)
        {
            var clusterIdField = default(string?);
            var replicaIdField = default(int);
            var maxWaitMsField = default(int);
            var minBytesField = default(int);
            var maxBytesField = default(int);
            var isolationLevelField = default(sbyte);
            var sessionIdField = default(int);
            var sessionEpochField = default(int);
            var topicsField = ImmutableArray<FetchTopic>.Empty;
            var forgottenTopicsDataField = ImmutableArray<ForgottenTopic>.Empty;
            var rackIdField = "";
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, replicaIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, maxWaitMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, minBytesField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<FetchTopic>(buffer, index, FetchTopicSerde.ReadV0);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return (index, new(
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
                rackIdField,
                taggedFields
            ));
        }
        private static int WriteV1(byte[] buffer, int index, FetchRequest message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxWaitMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MinBytesField);
            index = BinaryEncoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicSerde.WriteV1);
            return index;
        }
        private static (int Offset, FetchRequest Value) ReadV1(byte[] buffer, int index)
        {
            var clusterIdField = default(string?);
            var replicaIdField = default(int);
            var maxWaitMsField = default(int);
            var minBytesField = default(int);
            var maxBytesField = default(int);
            var isolationLevelField = default(sbyte);
            var sessionIdField = default(int);
            var sessionEpochField = default(int);
            var topicsField = ImmutableArray<FetchTopic>.Empty;
            var forgottenTopicsDataField = ImmutableArray<ForgottenTopic>.Empty;
            var rackIdField = "";
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, replicaIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, maxWaitMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, minBytesField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<FetchTopic>(buffer, index, FetchTopicSerde.ReadV1);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return (index, new(
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
                rackIdField,
                taggedFields
            ));
        }
        private static int WriteV2(byte[] buffer, int index, FetchRequest message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxWaitMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MinBytesField);
            index = BinaryEncoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicSerde.WriteV2);
            return index;
        }
        private static (int Offset, FetchRequest Value) ReadV2(byte[] buffer, int index)
        {
            var clusterIdField = default(string?);
            var replicaIdField = default(int);
            var maxWaitMsField = default(int);
            var minBytesField = default(int);
            var maxBytesField = default(int);
            var isolationLevelField = default(sbyte);
            var sessionIdField = default(int);
            var sessionEpochField = default(int);
            var topicsField = ImmutableArray<FetchTopic>.Empty;
            var forgottenTopicsDataField = ImmutableArray<ForgottenTopic>.Empty;
            var rackIdField = "";
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, replicaIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, maxWaitMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, minBytesField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<FetchTopic>(buffer, index, FetchTopicSerde.ReadV2);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return (index, new(
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
                rackIdField,
                taggedFields
            ));
        }
        private static int WriteV3(byte[] buffer, int index, FetchRequest message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxWaitMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MinBytesField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxBytesField);
            index = BinaryEncoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicSerde.WriteV3);
            return index;
        }
        private static (int Offset, FetchRequest Value) ReadV3(byte[] buffer, int index)
        {
            var clusterIdField = default(string?);
            var replicaIdField = default(int);
            var maxWaitMsField = default(int);
            var minBytesField = default(int);
            var maxBytesField = default(int);
            var isolationLevelField = default(sbyte);
            var sessionIdField = default(int);
            var sessionEpochField = default(int);
            var topicsField = ImmutableArray<FetchTopic>.Empty;
            var forgottenTopicsDataField = ImmutableArray<ForgottenTopic>.Empty;
            var rackIdField = "";
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, replicaIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, maxWaitMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, minBytesField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, maxBytesField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<FetchTopic>(buffer, index, FetchTopicSerde.ReadV3);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return (index, new(
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
                rackIdField,
                taggedFields
            ));
        }
        private static int WriteV4(byte[] buffer, int index, FetchRequest message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxWaitMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MinBytesField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxBytesField);
            index = BinaryEncoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = BinaryEncoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicSerde.WriteV4);
            return index;
        }
        private static (int Offset, FetchRequest Value) ReadV4(byte[] buffer, int index)
        {
            var clusterIdField = default(string?);
            var replicaIdField = default(int);
            var maxWaitMsField = default(int);
            var minBytesField = default(int);
            var maxBytesField = default(int);
            var isolationLevelField = default(sbyte);
            var sessionIdField = default(int);
            var sessionEpochField = default(int);
            var topicsField = ImmutableArray<FetchTopic>.Empty;
            var forgottenTopicsDataField = ImmutableArray<ForgottenTopic>.Empty;
            var rackIdField = "";
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, replicaIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, maxWaitMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, minBytesField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, maxBytesField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, isolationLevelField) = BinaryDecoder.ReadInt8(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<FetchTopic>(buffer, index, FetchTopicSerde.ReadV4);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return (index, new(
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
                rackIdField,
                taggedFields
            ));
        }
        private static int WriteV5(byte[] buffer, int index, FetchRequest message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxWaitMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MinBytesField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxBytesField);
            index = BinaryEncoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = BinaryEncoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicSerde.WriteV5);
            return index;
        }
        private static (int Offset, FetchRequest Value) ReadV5(byte[] buffer, int index)
        {
            var clusterIdField = default(string?);
            var replicaIdField = default(int);
            var maxWaitMsField = default(int);
            var minBytesField = default(int);
            var maxBytesField = default(int);
            var isolationLevelField = default(sbyte);
            var sessionIdField = default(int);
            var sessionEpochField = default(int);
            var topicsField = ImmutableArray<FetchTopic>.Empty;
            var forgottenTopicsDataField = ImmutableArray<ForgottenTopic>.Empty;
            var rackIdField = "";
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, replicaIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, maxWaitMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, minBytesField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, maxBytesField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, isolationLevelField) = BinaryDecoder.ReadInt8(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<FetchTopic>(buffer, index, FetchTopicSerde.ReadV5);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return (index, new(
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
                rackIdField,
                taggedFields
            ));
        }
        private static int WriteV6(byte[] buffer, int index, FetchRequest message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxWaitMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MinBytesField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxBytesField);
            index = BinaryEncoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = BinaryEncoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicSerde.WriteV6);
            return index;
        }
        private static (int Offset, FetchRequest Value) ReadV6(byte[] buffer, int index)
        {
            var clusterIdField = default(string?);
            var replicaIdField = default(int);
            var maxWaitMsField = default(int);
            var minBytesField = default(int);
            var maxBytesField = default(int);
            var isolationLevelField = default(sbyte);
            var sessionIdField = default(int);
            var sessionEpochField = default(int);
            var topicsField = ImmutableArray<FetchTopic>.Empty;
            var forgottenTopicsDataField = ImmutableArray<ForgottenTopic>.Empty;
            var rackIdField = "";
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, replicaIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, maxWaitMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, minBytesField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, maxBytesField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, isolationLevelField) = BinaryDecoder.ReadInt8(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<FetchTopic>(buffer, index, FetchTopicSerde.ReadV6);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return (index, new(
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
                rackIdField,
                taggedFields
            ));
        }
        private static int WriteV7(byte[] buffer, int index, FetchRequest message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxWaitMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MinBytesField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxBytesField);
            index = BinaryEncoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionEpochField);
            index = BinaryEncoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicSerde.WriteV7);
            index = BinaryEncoder.WriteArray<ForgottenTopic>(buffer, index, message.ForgottenTopicsDataField, ForgottenTopicSerde.WriteV7);
            return index;
        }
        private static (int Offset, FetchRequest Value) ReadV7(byte[] buffer, int index)
        {
            var clusterIdField = default(string?);
            var replicaIdField = default(int);
            var maxWaitMsField = default(int);
            var minBytesField = default(int);
            var maxBytesField = default(int);
            var isolationLevelField = default(sbyte);
            var sessionIdField = default(int);
            var sessionEpochField = default(int);
            var topicsField = ImmutableArray<FetchTopic>.Empty;
            var forgottenTopicsDataField = ImmutableArray<ForgottenTopic>.Empty;
            var rackIdField = "";
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, replicaIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, maxWaitMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, minBytesField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, maxBytesField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, isolationLevelField) = BinaryDecoder.ReadInt8(buffer, index);
            (index, sessionIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, sessionEpochField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<FetchTopic>(buffer, index, FetchTopicSerde.ReadV7);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (index, var _forgottenTopicsDataField_) = BinaryDecoder.ReadArray<ForgottenTopic>(buffer, index, ForgottenTopicSerde.ReadV7);
            if (_forgottenTopicsDataField_ == null)
                throw new NullReferenceException("Null not allowed for 'ForgottenTopicsData'");
            else
                forgottenTopicsDataField = _forgottenTopicsDataField_.Value;
            return (index, new(
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
                rackIdField,
                taggedFields
            ));
        }
        private static int WriteV8(byte[] buffer, int index, FetchRequest message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxWaitMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MinBytesField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxBytesField);
            index = BinaryEncoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionEpochField);
            index = BinaryEncoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicSerde.WriteV8);
            index = BinaryEncoder.WriteArray<ForgottenTopic>(buffer, index, message.ForgottenTopicsDataField, ForgottenTopicSerde.WriteV8);
            return index;
        }
        private static (int Offset, FetchRequest Value) ReadV8(byte[] buffer, int index)
        {
            var clusterIdField = default(string?);
            var replicaIdField = default(int);
            var maxWaitMsField = default(int);
            var minBytesField = default(int);
            var maxBytesField = default(int);
            var isolationLevelField = default(sbyte);
            var sessionIdField = default(int);
            var sessionEpochField = default(int);
            var topicsField = ImmutableArray<FetchTopic>.Empty;
            var forgottenTopicsDataField = ImmutableArray<ForgottenTopic>.Empty;
            var rackIdField = "";
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, replicaIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, maxWaitMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, minBytesField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, maxBytesField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, isolationLevelField) = BinaryDecoder.ReadInt8(buffer, index);
            (index, sessionIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, sessionEpochField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<FetchTopic>(buffer, index, FetchTopicSerde.ReadV8);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (index, var _forgottenTopicsDataField_) = BinaryDecoder.ReadArray<ForgottenTopic>(buffer, index, ForgottenTopicSerde.ReadV8);
            if (_forgottenTopicsDataField_ == null)
                throw new NullReferenceException("Null not allowed for 'ForgottenTopicsData'");
            else
                forgottenTopicsDataField = _forgottenTopicsDataField_.Value;
            return (index, new(
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
                rackIdField,
                taggedFields
            ));
        }
        private static int WriteV9(byte[] buffer, int index, FetchRequest message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxWaitMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MinBytesField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxBytesField);
            index = BinaryEncoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionEpochField);
            index = BinaryEncoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicSerde.WriteV9);
            index = BinaryEncoder.WriteArray<ForgottenTopic>(buffer, index, message.ForgottenTopicsDataField, ForgottenTopicSerde.WriteV9);
            return index;
        }
        private static (int Offset, FetchRequest Value) ReadV9(byte[] buffer, int index)
        {
            var clusterIdField = default(string?);
            var replicaIdField = default(int);
            var maxWaitMsField = default(int);
            var minBytesField = default(int);
            var maxBytesField = default(int);
            var isolationLevelField = default(sbyte);
            var sessionIdField = default(int);
            var sessionEpochField = default(int);
            var topicsField = ImmutableArray<FetchTopic>.Empty;
            var forgottenTopicsDataField = ImmutableArray<ForgottenTopic>.Empty;
            var rackIdField = "";
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, replicaIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, maxWaitMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, minBytesField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, maxBytesField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, isolationLevelField) = BinaryDecoder.ReadInt8(buffer, index);
            (index, sessionIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, sessionEpochField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<FetchTopic>(buffer, index, FetchTopicSerde.ReadV9);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (index, var _forgottenTopicsDataField_) = BinaryDecoder.ReadArray<ForgottenTopic>(buffer, index, ForgottenTopicSerde.ReadV9);
            if (_forgottenTopicsDataField_ == null)
                throw new NullReferenceException("Null not allowed for 'ForgottenTopicsData'");
            else
                forgottenTopicsDataField = _forgottenTopicsDataField_.Value;
            return (index, new(
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
                rackIdField,
                taggedFields
            ));
        }
        private static int WriteV10(byte[] buffer, int index, FetchRequest message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxWaitMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MinBytesField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxBytesField);
            index = BinaryEncoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionEpochField);
            index = BinaryEncoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicSerde.WriteV10);
            index = BinaryEncoder.WriteArray<ForgottenTopic>(buffer, index, message.ForgottenTopicsDataField, ForgottenTopicSerde.WriteV10);
            return index;
        }
        private static (int Offset, FetchRequest Value) ReadV10(byte[] buffer, int index)
        {
            var clusterIdField = default(string?);
            var replicaIdField = default(int);
            var maxWaitMsField = default(int);
            var minBytesField = default(int);
            var maxBytesField = default(int);
            var isolationLevelField = default(sbyte);
            var sessionIdField = default(int);
            var sessionEpochField = default(int);
            var topicsField = ImmutableArray<FetchTopic>.Empty;
            var forgottenTopicsDataField = ImmutableArray<ForgottenTopic>.Empty;
            var rackIdField = "";
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, replicaIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, maxWaitMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, minBytesField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, maxBytesField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, isolationLevelField) = BinaryDecoder.ReadInt8(buffer, index);
            (index, sessionIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, sessionEpochField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<FetchTopic>(buffer, index, FetchTopicSerde.ReadV10);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (index, var _forgottenTopicsDataField_) = BinaryDecoder.ReadArray<ForgottenTopic>(buffer, index, ForgottenTopicSerde.ReadV10);
            if (_forgottenTopicsDataField_ == null)
                throw new NullReferenceException("Null not allowed for 'ForgottenTopicsData'");
            else
                forgottenTopicsDataField = _forgottenTopicsDataField_.Value;
            return (index, new(
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
                rackIdField,
                taggedFields
            ));
        }
        private static int WriteV11(byte[] buffer, int index, FetchRequest message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxWaitMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MinBytesField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxBytesField);
            index = BinaryEncoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionEpochField);
            index = BinaryEncoder.WriteArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicSerde.WriteV11);
            index = BinaryEncoder.WriteArray<ForgottenTopic>(buffer, index, message.ForgottenTopicsDataField, ForgottenTopicSerde.WriteV11);
            index = BinaryEncoder.WriteString(buffer, index, message.RackIdField);
            return index;
        }
        private static (int Offset, FetchRequest Value) ReadV11(byte[] buffer, int index)
        {
            var clusterIdField = default(string?);
            var replicaIdField = default(int);
            var maxWaitMsField = default(int);
            var minBytesField = default(int);
            var maxBytesField = default(int);
            var isolationLevelField = default(sbyte);
            var sessionIdField = default(int);
            var sessionEpochField = default(int);
            var topicsField = ImmutableArray<FetchTopic>.Empty;
            var forgottenTopicsDataField = ImmutableArray<ForgottenTopic>.Empty;
            var rackIdField = "";
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, replicaIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, maxWaitMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, minBytesField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, maxBytesField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, isolationLevelField) = BinaryDecoder.ReadInt8(buffer, index);
            (index, sessionIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, sessionEpochField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<FetchTopic>(buffer, index, FetchTopicSerde.ReadV11);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (index, var _forgottenTopicsDataField_) = BinaryDecoder.ReadArray<ForgottenTopic>(buffer, index, ForgottenTopicSerde.ReadV11);
            if (_forgottenTopicsDataField_ == null)
                throw new NullReferenceException("Null not allowed for 'ForgottenTopicsData'");
            else
                forgottenTopicsDataField = _forgottenTopicsDataField_.Value;
            (index, rackIdField) = BinaryDecoder.ReadString(buffer, index);
            return (index, new(
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
                rackIdField,
                taggedFields
            ));
        }
        private static int WriteV12(byte[] buffer, int index, FetchRequest message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxWaitMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MinBytesField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxBytesField);
            index = BinaryEncoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionEpochField);
            index = BinaryEncoder.WriteCompactArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicSerde.WriteV12);
            index = BinaryEncoder.WriteCompactArray<ForgottenTopic>(buffer, index, message.ForgottenTopicsDataField, ForgottenTopicSerde.WriteV12);
            index = BinaryEncoder.WriteCompactString(buffer, index, message.RackIdField);
            var taggedFieldsCount = 0u;
            var previousTagged = 0;
            if(message.ClusterIdField != null)
                taggedFieldsCount++;
            taggedFieldsCount += (uint)message.TaggedFields.Length;
            index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
            if(message.ClusterIdField != null)
            {
                index = BinaryEncoder.WriteVarInt32(buffer, index, 0);
                index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.ClusterIdField);
            }
            foreach(var taggedField in message.TaggedFields)
            {
                if(taggedField.Tag <= previousTagged)
                    throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: 0");
                index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
            }
            return index;
        }
        private static (int Offset, FetchRequest Value) ReadV12(byte[] buffer, int index)
        {
            var clusterIdField = default(string?);
            var replicaIdField = default(int);
            var maxWaitMsField = default(int);
            var minBytesField = default(int);
            var maxBytesField = default(int);
            var isolationLevelField = default(sbyte);
            var sessionIdField = default(int);
            var sessionEpochField = default(int);
            var topicsField = ImmutableArray<FetchTopic>.Empty;
            var forgottenTopicsDataField = ImmutableArray<ForgottenTopic>.Empty;
            var rackIdField = "";
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, replicaIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, maxWaitMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, minBytesField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, maxBytesField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, isolationLevelField) = BinaryDecoder.ReadInt8(buffer, index);
            (index, sessionIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, sessionEpochField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadCompactArray<FetchTopic>(buffer, index, FetchTopicSerde.ReadV12);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (index, var _forgottenTopicsDataField_) = BinaryDecoder.ReadCompactArray<ForgottenTopic>(buffer, index, ForgottenTopicSerde.ReadV12);
            if (_forgottenTopicsDataField_ == null)
                throw new NullReferenceException("Null not allowed for 'ForgottenTopicsData'");
            else
                forgottenTopicsDataField = _forgottenTopicsDataField_.Value;
            (index, rackIdField) = BinaryDecoder.ReadCompactString(buffer, index);
            (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
            if(taggedFieldsCount > 0)
            {
                var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                while (taggedFieldsCount > 0)
                {
                    (index, var tag) = BinaryDecoder.ReadVarInt32(buffer, index);
                    switch (tag)
                    {
                        case 0:
                            (index, clusterIdField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
                            break;
                        default:
                            (index, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, index);
                            taggedFieldsBuilder.Add(new(tag, bytes));
                        break;
                    }
                    taggedFieldsCount--;
                }
            }
            return (index, new(
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
                rackIdField,
                taggedFields
            ));
        }
        private static int WriteV13(byte[] buffer, int index, FetchRequest message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ReplicaIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxWaitMsField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MinBytesField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.MaxBytesField);
            index = BinaryEncoder.WriteInt8(buffer, index, message.IsolationLevelField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.SessionEpochField);
            index = BinaryEncoder.WriteCompactArray<FetchTopic>(buffer, index, message.TopicsField, FetchTopicSerde.WriteV13);
            index = BinaryEncoder.WriteCompactArray<ForgottenTopic>(buffer, index, message.ForgottenTopicsDataField, ForgottenTopicSerde.WriteV13);
            index = BinaryEncoder.WriteCompactString(buffer, index, message.RackIdField);
            var taggedFieldsCount = 0u;
            var previousTagged = 0;
            if(message.ClusterIdField != null)
                taggedFieldsCount++;
            taggedFieldsCount += (uint)message.TaggedFields.Length;
            index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
            if(message.ClusterIdField != null)
            {
                index = BinaryEncoder.WriteVarInt32(buffer, index, 0);
                index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.ClusterIdField);
            }
            foreach(var taggedField in message.TaggedFields)
            {
                if(taggedField.Tag <= previousTagged)
                    throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: 0");
                index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
            }
            return index;
        }
        private static (int Offset, FetchRequest Value) ReadV13(byte[] buffer, int index)
        {
            var clusterIdField = default(string?);
            var replicaIdField = default(int);
            var maxWaitMsField = default(int);
            var minBytesField = default(int);
            var maxBytesField = default(int);
            var isolationLevelField = default(sbyte);
            var sessionIdField = default(int);
            var sessionEpochField = default(int);
            var topicsField = ImmutableArray<FetchTopic>.Empty;
            var forgottenTopicsDataField = ImmutableArray<ForgottenTopic>.Empty;
            var rackIdField = "";
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, replicaIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, maxWaitMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, minBytesField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, maxBytesField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, isolationLevelField) = BinaryDecoder.ReadInt8(buffer, index);
            (index, sessionIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, sessionEpochField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadCompactArray<FetchTopic>(buffer, index, FetchTopicSerde.ReadV13);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (index, var _forgottenTopicsDataField_) = BinaryDecoder.ReadCompactArray<ForgottenTopic>(buffer, index, ForgottenTopicSerde.ReadV13);
            if (_forgottenTopicsDataField_ == null)
                throw new NullReferenceException("Null not allowed for 'ForgottenTopicsData'");
            else
                forgottenTopicsDataField = _forgottenTopicsDataField_.Value;
            (index, rackIdField) = BinaryDecoder.ReadCompactString(buffer, index);
            (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
            if(taggedFieldsCount > 0)
            {
                var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                while (taggedFieldsCount > 0)
                {
                    (index, var tag) = BinaryDecoder.ReadVarInt32(buffer, index);
                    switch (tag)
                    {
                        case 0:
                            (index, clusterIdField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
                            break;
                        default:
                            (index, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, index);
                            taggedFieldsBuilder.Add(new(tag, bytes));
                        break;
                    }
                    taggedFieldsCount--;
                }
            }
            return (index, new(
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
                rackIdField,
                taggedFields
            ));
        }
        [GeneratedCode("kgen", "1.0.0.0")]
        private static class ForgottenTopicSerde
        {
            public static int WriteV0(byte[] buffer, int index, ForgottenTopic message)
            {
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, ForgottenTopic Value) ReadV0(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<int>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return (index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static int WriteV1(byte[] buffer, int index, ForgottenTopic message)
            {
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, ForgottenTopic Value) ReadV1(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<int>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return (index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static int WriteV2(byte[] buffer, int index, ForgottenTopic message)
            {
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, ForgottenTopic Value) ReadV2(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<int>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return (index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static int WriteV3(byte[] buffer, int index, ForgottenTopic message)
            {
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, ForgottenTopic Value) ReadV3(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<int>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return (index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static int WriteV4(byte[] buffer, int index, ForgottenTopic message)
            {
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, ForgottenTopic Value) ReadV4(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<int>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return (index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static int WriteV5(byte[] buffer, int index, ForgottenTopic message)
            {
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, ForgottenTopic Value) ReadV5(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<int>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return (index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static int WriteV6(byte[] buffer, int index, ForgottenTopic message)
            {
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, ForgottenTopic Value) ReadV6(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<int>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return (index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static int WriteV7(byte[] buffer, int index, ForgottenTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteArray<int>(buffer, index, message.PartitionsField, BinaryEncoder.WriteInt32);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, ForgottenTopic Value) ReadV7(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<int>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return (index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static int WriteV8(byte[] buffer, int index, ForgottenTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteArray<int>(buffer, index, message.PartitionsField, BinaryEncoder.WriteInt32);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, ForgottenTopic Value) ReadV8(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<int>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return (index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static int WriteV9(byte[] buffer, int index, ForgottenTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteArray<int>(buffer, index, message.PartitionsField, BinaryEncoder.WriteInt32);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, ForgottenTopic Value) ReadV9(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<int>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return (index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static int WriteV10(byte[] buffer, int index, ForgottenTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteArray<int>(buffer, index, message.PartitionsField, BinaryEncoder.WriteInt32);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, ForgottenTopic Value) ReadV10(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<int>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return (index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static int WriteV11(byte[] buffer, int index, ForgottenTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteArray<int>(buffer, index, message.PartitionsField, BinaryEncoder.WriteInt32);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, ForgottenTopic Value) ReadV11(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<int>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return (index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static int WriteV12(byte[] buffer, int index, ForgottenTopic message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteCompactArray<int>(buffer, index, message.PartitionsField, BinaryEncoder.WriteInt32);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, ForgottenTopic Value) ReadV12(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<int>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadCompactArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
                if(taggedFieldsCount > 0)
                {
                    var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                    while (taggedFieldsCount > 0)
                    {
                        (index, var tag) = BinaryDecoder.ReadVarInt32(buffer, index);
                        (index, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, index);
                        taggedFieldsBuilder.Add(new(tag, bytes));
                        taggedFieldsCount--;
                    }
                }
                return (index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static int WriteV13(byte[] buffer, int index, ForgottenTopic message)
            {
                index = BinaryEncoder.WriteUuid(buffer, index, message.TopicIdField);
                index = BinaryEncoder.WriteCompactArray<int>(buffer, index, message.PartitionsField, BinaryEncoder.WriteInt32);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, ForgottenTopic Value) ReadV13(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<int>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicIdField) = BinaryDecoder.ReadUuid(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadCompactArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
                if(taggedFieldsCount > 0)
                {
                    var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                    while (taggedFieldsCount > 0)
                    {
                        (index, var tag) = BinaryDecoder.ReadVarInt32(buffer, index);
                        (index, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, index);
                        taggedFieldsBuilder.Add(new(tag, bytes));
                        taggedFieldsCount--;
                    }
                }
                return (index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
        }
        [GeneratedCode("kgen", "1.0.0.0")]
        private static class FetchTopicSerde
        {
            public static int WriteV0(byte[] buffer, int index, FetchTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionSerde.WriteV0);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, FetchTopic Value) ReadV0(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<FetchPartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<FetchPartition>(buffer, index, FetchPartitionSerde.ReadV0);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return (index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static int WriteV1(byte[] buffer, int index, FetchTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionSerde.WriteV1);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, FetchTopic Value) ReadV1(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<FetchPartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<FetchPartition>(buffer, index, FetchPartitionSerde.ReadV1);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return (index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static int WriteV2(byte[] buffer, int index, FetchTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionSerde.WriteV2);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, FetchTopic Value) ReadV2(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<FetchPartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<FetchPartition>(buffer, index, FetchPartitionSerde.ReadV2);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return (index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static int WriteV3(byte[] buffer, int index, FetchTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionSerde.WriteV3);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, FetchTopic Value) ReadV3(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<FetchPartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<FetchPartition>(buffer, index, FetchPartitionSerde.ReadV3);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return (index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static int WriteV4(byte[] buffer, int index, FetchTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionSerde.WriteV4);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, FetchTopic Value) ReadV4(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<FetchPartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<FetchPartition>(buffer, index, FetchPartitionSerde.ReadV4);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return (index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static int WriteV5(byte[] buffer, int index, FetchTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionSerde.WriteV5);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, FetchTopic Value) ReadV5(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<FetchPartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<FetchPartition>(buffer, index, FetchPartitionSerde.ReadV5);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return (index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static int WriteV6(byte[] buffer, int index, FetchTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionSerde.WriteV6);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, FetchTopic Value) ReadV6(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<FetchPartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<FetchPartition>(buffer, index, FetchPartitionSerde.ReadV6);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return (index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static int WriteV7(byte[] buffer, int index, FetchTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionSerde.WriteV7);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, FetchTopic Value) ReadV7(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<FetchPartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<FetchPartition>(buffer, index, FetchPartitionSerde.ReadV7);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return (index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static int WriteV8(byte[] buffer, int index, FetchTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionSerde.WriteV8);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, FetchTopic Value) ReadV8(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<FetchPartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<FetchPartition>(buffer, index, FetchPartitionSerde.ReadV8);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return (index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static int WriteV9(byte[] buffer, int index, FetchTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionSerde.WriteV9);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, FetchTopic Value) ReadV9(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<FetchPartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<FetchPartition>(buffer, index, FetchPartitionSerde.ReadV9);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return (index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static int WriteV10(byte[] buffer, int index, FetchTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionSerde.WriteV10);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, FetchTopic Value) ReadV10(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<FetchPartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<FetchPartition>(buffer, index, FetchPartitionSerde.ReadV10);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return (index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static int WriteV11(byte[] buffer, int index, FetchTopic message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionSerde.WriteV11);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, FetchTopic Value) ReadV11(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<FetchPartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<FetchPartition>(buffer, index, FetchPartitionSerde.ReadV11);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return (index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static int WriteV12(byte[] buffer, int index, FetchTopic message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.TopicField);
                index = BinaryEncoder.WriteCompactArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionSerde.WriteV12);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, FetchTopic Value) ReadV12(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<FetchPartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadCompactArray<FetchPartition>(buffer, index, FetchPartitionSerde.ReadV12);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
                if(taggedFieldsCount > 0)
                {
                    var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                    while (taggedFieldsCount > 0)
                    {
                        (index, var tag) = BinaryDecoder.ReadVarInt32(buffer, index);
                        (index, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, index);
                        taggedFieldsBuilder.Add(new(tag, bytes));
                        taggedFieldsCount--;
                    }
                }
                return (index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static int WriteV13(byte[] buffer, int index, FetchTopic message)
            {
                index = BinaryEncoder.WriteUuid(buffer, index, message.TopicIdField);
                index = BinaryEncoder.WriteCompactArray<FetchPartition>(buffer, index, message.PartitionsField, FetchPartitionSerde.WriteV13);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, FetchTopic Value) ReadV13(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<FetchPartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicIdField) = BinaryDecoder.ReadUuid(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadCompactArray<FetchPartition>(buffer, index, FetchPartitionSerde.ReadV13);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
                if(taggedFieldsCount > 0)
                {
                    var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                    while (taggedFieldsCount > 0)
                    {
                        (index, var tag) = BinaryDecoder.ReadVarInt32(buffer, index);
                        (index, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, index);
                        taggedFieldsBuilder.Add(new(tag, bytes));
                        taggedFieldsCount--;
                    }
                }
                return (index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            [GeneratedCode("kgen", "1.0.0.0")]
            private static class FetchPartitionSerde
            {
                public static int WriteV0(byte[] buffer, int index, FetchPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.FetchOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                    var taggedFieldsCount = 0u;
                    var previousTagged = -1;
                    taggedFieldsCount += (uint)message.TaggedFields.Length;
                    index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                    foreach(var taggedField in message.TaggedFields)
                    {
                        if(taggedField.Tag <= previousTagged)
                            throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                        index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                        index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                    }
                    return index;
                }
                public static (int Offset, FetchPartition Value) ReadV0(byte[] buffer, int index)
                {
                    var partitionField = default(int);
                    var currentLeaderEpochField = default(int);
                    var fetchOffsetField = default(long);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = default(long);
                    var partitionMaxBytesField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, fetchOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, partitionMaxBytesField) = BinaryDecoder.ReadInt32(buffer, index);
                    return (index, new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField,
                        taggedFields
                    ));
                }
                public static int WriteV1(byte[] buffer, int index, FetchPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.FetchOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                    var taggedFieldsCount = 0u;
                    var previousTagged = -1;
                    taggedFieldsCount += (uint)message.TaggedFields.Length;
                    index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                    foreach(var taggedField in message.TaggedFields)
                    {
                        if(taggedField.Tag <= previousTagged)
                            throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                        index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                        index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                    }
                    return index;
                }
                public static (int Offset, FetchPartition Value) ReadV1(byte[] buffer, int index)
                {
                    var partitionField = default(int);
                    var currentLeaderEpochField = default(int);
                    var fetchOffsetField = default(long);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = default(long);
                    var partitionMaxBytesField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, fetchOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, partitionMaxBytesField) = BinaryDecoder.ReadInt32(buffer, index);
                    return (index, new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField,
                        taggedFields
                    ));
                }
                public static int WriteV2(byte[] buffer, int index, FetchPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.FetchOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                    var taggedFieldsCount = 0u;
                    var previousTagged = -1;
                    taggedFieldsCount += (uint)message.TaggedFields.Length;
                    index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                    foreach(var taggedField in message.TaggedFields)
                    {
                        if(taggedField.Tag <= previousTagged)
                            throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                        index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                        index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                    }
                    return index;
                }
                public static (int Offset, FetchPartition Value) ReadV2(byte[] buffer, int index)
                {
                    var partitionField = default(int);
                    var currentLeaderEpochField = default(int);
                    var fetchOffsetField = default(long);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = default(long);
                    var partitionMaxBytesField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, fetchOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, partitionMaxBytesField) = BinaryDecoder.ReadInt32(buffer, index);
                    return (index, new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField,
                        taggedFields
                    ));
                }
                public static int WriteV3(byte[] buffer, int index, FetchPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.FetchOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                    var taggedFieldsCount = 0u;
                    var previousTagged = -1;
                    taggedFieldsCount += (uint)message.TaggedFields.Length;
                    index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                    foreach(var taggedField in message.TaggedFields)
                    {
                        if(taggedField.Tag <= previousTagged)
                            throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                        index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                        index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                    }
                    return index;
                }
                public static (int Offset, FetchPartition Value) ReadV3(byte[] buffer, int index)
                {
                    var partitionField = default(int);
                    var currentLeaderEpochField = default(int);
                    var fetchOffsetField = default(long);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = default(long);
                    var partitionMaxBytesField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, fetchOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, partitionMaxBytesField) = BinaryDecoder.ReadInt32(buffer, index);
                    return (index, new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField,
                        taggedFields
                    ));
                }
                public static int WriteV4(byte[] buffer, int index, FetchPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.FetchOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                    var taggedFieldsCount = 0u;
                    var previousTagged = -1;
                    taggedFieldsCount += (uint)message.TaggedFields.Length;
                    index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                    foreach(var taggedField in message.TaggedFields)
                    {
                        if(taggedField.Tag <= previousTagged)
                            throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                        index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                        index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                    }
                    return index;
                }
                public static (int Offset, FetchPartition Value) ReadV4(byte[] buffer, int index)
                {
                    var partitionField = default(int);
                    var currentLeaderEpochField = default(int);
                    var fetchOffsetField = default(long);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = default(long);
                    var partitionMaxBytesField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, fetchOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, partitionMaxBytesField) = BinaryDecoder.ReadInt32(buffer, index);
                    return (index, new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField,
                        taggedFields
                    ));
                }
                public static int WriteV5(byte[] buffer, int index, FetchPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.FetchOffsetField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                    var taggedFieldsCount = 0u;
                    var previousTagged = -1;
                    taggedFieldsCount += (uint)message.TaggedFields.Length;
                    index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                    foreach(var taggedField in message.TaggedFields)
                    {
                        if(taggedField.Tag <= previousTagged)
                            throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                        index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                        index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                    }
                    return index;
                }
                public static (int Offset, FetchPartition Value) ReadV5(byte[] buffer, int index)
                {
                    var partitionField = default(int);
                    var currentLeaderEpochField = default(int);
                    var fetchOffsetField = default(long);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = default(long);
                    var partitionMaxBytesField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, fetchOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, partitionMaxBytesField) = BinaryDecoder.ReadInt32(buffer, index);
                    return (index, new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField,
                        taggedFields
                    ));
                }
                public static int WriteV6(byte[] buffer, int index, FetchPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.FetchOffsetField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                    var taggedFieldsCount = 0u;
                    var previousTagged = -1;
                    taggedFieldsCount += (uint)message.TaggedFields.Length;
                    index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                    foreach(var taggedField in message.TaggedFields)
                    {
                        if(taggedField.Tag <= previousTagged)
                            throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                        index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                        index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                    }
                    return index;
                }
                public static (int Offset, FetchPartition Value) ReadV6(byte[] buffer, int index)
                {
                    var partitionField = default(int);
                    var currentLeaderEpochField = default(int);
                    var fetchOffsetField = default(long);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = default(long);
                    var partitionMaxBytesField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, fetchOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, partitionMaxBytesField) = BinaryDecoder.ReadInt32(buffer, index);
                    return (index, new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField,
                        taggedFields
                    ));
                }
                public static int WriteV7(byte[] buffer, int index, FetchPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.FetchOffsetField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                    var taggedFieldsCount = 0u;
                    var previousTagged = -1;
                    taggedFieldsCount += (uint)message.TaggedFields.Length;
                    index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                    foreach(var taggedField in message.TaggedFields)
                    {
                        if(taggedField.Tag <= previousTagged)
                            throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                        index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                        index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                    }
                    return index;
                }
                public static (int Offset, FetchPartition Value) ReadV7(byte[] buffer, int index)
                {
                    var partitionField = default(int);
                    var currentLeaderEpochField = default(int);
                    var fetchOffsetField = default(long);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = default(long);
                    var partitionMaxBytesField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, fetchOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, partitionMaxBytesField) = BinaryDecoder.ReadInt32(buffer, index);
                    return (index, new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField,
                        taggedFields
                    ));
                }
                public static int WriteV8(byte[] buffer, int index, FetchPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.FetchOffsetField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                    var taggedFieldsCount = 0u;
                    var previousTagged = -1;
                    taggedFieldsCount += (uint)message.TaggedFields.Length;
                    index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                    foreach(var taggedField in message.TaggedFields)
                    {
                        if(taggedField.Tag <= previousTagged)
                            throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                        index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                        index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                    }
                    return index;
                }
                public static (int Offset, FetchPartition Value) ReadV8(byte[] buffer, int index)
                {
                    var partitionField = default(int);
                    var currentLeaderEpochField = default(int);
                    var fetchOffsetField = default(long);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = default(long);
                    var partitionMaxBytesField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, fetchOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, partitionMaxBytesField) = BinaryDecoder.ReadInt32(buffer, index);
                    return (index, new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField,
                        taggedFields
                    ));
                }
                public static int WriteV9(byte[] buffer, int index, FetchPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.FetchOffsetField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                    var taggedFieldsCount = 0u;
                    var previousTagged = -1;
                    taggedFieldsCount += (uint)message.TaggedFields.Length;
                    index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                    foreach(var taggedField in message.TaggedFields)
                    {
                        if(taggedField.Tag <= previousTagged)
                            throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                        index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                        index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                    }
                    return index;
                }
                public static (int Offset, FetchPartition Value) ReadV9(byte[] buffer, int index)
                {
                    var partitionField = default(int);
                    var currentLeaderEpochField = default(int);
                    var fetchOffsetField = default(long);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = default(long);
                    var partitionMaxBytesField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, currentLeaderEpochField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, fetchOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, partitionMaxBytesField) = BinaryDecoder.ReadInt32(buffer, index);
                    return (index, new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField,
                        taggedFields
                    ));
                }
                public static int WriteV10(byte[] buffer, int index, FetchPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.FetchOffsetField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                    var taggedFieldsCount = 0u;
                    var previousTagged = -1;
                    taggedFieldsCount += (uint)message.TaggedFields.Length;
                    index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                    foreach(var taggedField in message.TaggedFields)
                    {
                        if(taggedField.Tag <= previousTagged)
                            throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                        index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                        index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                    }
                    return index;
                }
                public static (int Offset, FetchPartition Value) ReadV10(byte[] buffer, int index)
                {
                    var partitionField = default(int);
                    var currentLeaderEpochField = default(int);
                    var fetchOffsetField = default(long);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = default(long);
                    var partitionMaxBytesField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, currentLeaderEpochField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, fetchOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, partitionMaxBytesField) = BinaryDecoder.ReadInt32(buffer, index);
                    return (index, new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField,
                        taggedFields
                    ));
                }
                public static int WriteV11(byte[] buffer, int index, FetchPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.FetchOffsetField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                    var taggedFieldsCount = 0u;
                    var previousTagged = -1;
                    taggedFieldsCount += (uint)message.TaggedFields.Length;
                    index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                    foreach(var taggedField in message.TaggedFields)
                    {
                        if(taggedField.Tag <= previousTagged)
                            throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                        index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                        index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                    }
                    return index;
                }
                public static (int Offset, FetchPartition Value) ReadV11(byte[] buffer, int index)
                {
                    var partitionField = default(int);
                    var currentLeaderEpochField = default(int);
                    var fetchOffsetField = default(long);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = default(long);
                    var partitionMaxBytesField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, currentLeaderEpochField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, fetchOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, partitionMaxBytesField) = BinaryDecoder.ReadInt32(buffer, index);
                    return (index, new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField,
                        taggedFields
                    ));
                }
                public static int WriteV12(byte[] buffer, int index, FetchPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.FetchOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.LastFetchedEpochField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                    var taggedFieldsCount = 0u;
                    var previousTagged = -1;
                    taggedFieldsCount += (uint)message.TaggedFields.Length;
                    index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                    foreach(var taggedField in message.TaggedFields)
                    {
                        if(taggedField.Tag <= previousTagged)
                            throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                        index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                        index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                    }
                    return index;
                }
                public static (int Offset, FetchPartition Value) ReadV12(byte[] buffer, int index)
                {
                    var partitionField = default(int);
                    var currentLeaderEpochField = default(int);
                    var fetchOffsetField = default(long);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = default(long);
                    var partitionMaxBytesField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, currentLeaderEpochField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, fetchOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, lastFetchedEpochField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, partitionMaxBytesField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
                    if(taggedFieldsCount > 0)
                    {
                        var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                        while (taggedFieldsCount > 0)
                        {
                            (index, var tag) = BinaryDecoder.ReadVarInt32(buffer, index);
                            (index, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, index);
                            taggedFieldsBuilder.Add(new(tag, bytes));
                            taggedFieldsCount--;
                        }
                    }
                    return (index, new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField,
                        taggedFields
                    ));
                }
                public static int WriteV13(byte[] buffer, int index, FetchPartition message)
                {
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.FetchOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.LastFetchedEpochField);
                    index = BinaryEncoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionMaxBytesField);
                    var taggedFieldsCount = 0u;
                    var previousTagged = -1;
                    taggedFieldsCount += (uint)message.TaggedFields.Length;
                    index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                    foreach(var taggedField in message.TaggedFields)
                    {
                        if(taggedField.Tag <= previousTagged)
                            throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                        index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                        index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                    }
                    return index;
                }
                public static (int Offset, FetchPartition Value) ReadV13(byte[] buffer, int index)
                {
                    var partitionField = default(int);
                    var currentLeaderEpochField = default(int);
                    var fetchOffsetField = default(long);
                    var lastFetchedEpochField = default(int);
                    var logStartOffsetField = default(long);
                    var partitionMaxBytesField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, currentLeaderEpochField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, fetchOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, lastFetchedEpochField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, partitionMaxBytesField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
                    if(taggedFieldsCount > 0)
                    {
                        var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                        while (taggedFieldsCount > 0)
                        {
                            (index, var tag) = BinaryDecoder.ReadVarInt32(buffer, index);
                            (index, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, index);
                            taggedFieldsBuilder.Add(new(tag, bytes));
                            taggedFieldsCount--;
                        }
                    }
                    return (index, new(
                        partitionField,
                        currentLeaderEpochField,
                        fetchOffsetField,
                        lastFetchedEpochField,
                        logStartOffsetField,
                        partitionMaxBytesField,
                        taggedFields
                    ));
                }
            }
        }
    }
}