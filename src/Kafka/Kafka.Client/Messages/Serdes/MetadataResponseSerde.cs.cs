using Kafka.Common.Encoding;
using Kafka.Common.Exceptions;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using MetadataResponseBroker = Kafka.Client.Messages.MetadataResponse.MetadataResponseBroker;
using MetadataResponsePartition = Kafka.Client.Messages.MetadataResponse.MetadataResponseTopic.MetadataResponsePartition;
using MetadataResponseTopic = Kafka.Client.Messages.MetadataResponse.MetadataResponseTopic;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Version = Kafka.Common.Model.Version;

namespace Kafka.Client.Messages.Serdes
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class MetadataResponseSerde
    {
        private static readonly ApiKey API_KEY = new(3);
        private static readonly VersionRange API_VERSIONS = new(0, 12);
        private static readonly VersionRange FLEXBILE_VERSIONS = new (9, 32767);
        public static IEncoder<ResponseHeader, MetadataResponse> CreateEncoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 12 ? apiVersion : new Version(12);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerEncoder = ResponseHeaderSerde.CreateEncoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Encoder<ResponseHeader, MetadataResponse>(API_KEY, 0, flexible, headerEncoder, WriteV0);
                case 1:
                    return new Encoder<ResponseHeader, MetadataResponse>(API_KEY, 1, flexible, headerEncoder, WriteV1);
                case 2:
                    return new Encoder<ResponseHeader, MetadataResponse>(API_KEY, 2, flexible, headerEncoder, WriteV2);
                case 3:
                    return new Encoder<ResponseHeader, MetadataResponse>(API_KEY, 3, flexible, headerEncoder, WriteV3);
                case 4:
                    return new Encoder<ResponseHeader, MetadataResponse>(API_KEY, 4, flexible, headerEncoder, WriteV4);
                case 5:
                    return new Encoder<ResponseHeader, MetadataResponse>(API_KEY, 5, flexible, headerEncoder, WriteV5);
                case 6:
                    return new Encoder<ResponseHeader, MetadataResponse>(API_KEY, 6, flexible, headerEncoder, WriteV6);
                case 7:
                    return new Encoder<ResponseHeader, MetadataResponse>(API_KEY, 7, flexible, headerEncoder, WriteV7);
                case 8:
                    return new Encoder<ResponseHeader, MetadataResponse>(API_KEY, 8, flexible, headerEncoder, WriteV8);
                case 9:
                    return new Encoder<ResponseHeader, MetadataResponse>(API_KEY, 9, flexible, headerEncoder, WriteV9);
                case 10:
                    return new Encoder<ResponseHeader, MetadataResponse>(API_KEY, 10, flexible, headerEncoder, WriteV10);
                case 11:
                    return new Encoder<ResponseHeader, MetadataResponse>(API_KEY, 11, flexible, headerEncoder, WriteV11);
                case 12:
                    return new Encoder<ResponseHeader, MetadataResponse>(API_KEY, 12, flexible, headerEncoder, WriteV12);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        public static IDecoder<ResponseHeader, MetadataResponse> CreateDecoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 12 ? apiVersion : new Version(12);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerDecoder = ResponseHeaderSerde.CreateDecoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Decoder<ResponseHeader, MetadataResponse>(API_KEY, 0, flexible, headerDecoder, ReadV0);
                case 1:
                    return new Decoder<ResponseHeader, MetadataResponse>(API_KEY, 1, flexible, headerDecoder, ReadV1);
                case 2:
                    return new Decoder<ResponseHeader, MetadataResponse>(API_KEY, 2, flexible, headerDecoder, ReadV2);
                case 3:
                    return new Decoder<ResponseHeader, MetadataResponse>(API_KEY, 3, flexible, headerDecoder, ReadV3);
                case 4:
                    return new Decoder<ResponseHeader, MetadataResponse>(API_KEY, 4, flexible, headerDecoder, ReadV4);
                case 5:
                    return new Decoder<ResponseHeader, MetadataResponse>(API_KEY, 5, flexible, headerDecoder, ReadV5);
                case 6:
                    return new Decoder<ResponseHeader, MetadataResponse>(API_KEY, 6, flexible, headerDecoder, ReadV6);
                case 7:
                    return new Decoder<ResponseHeader, MetadataResponse>(API_KEY, 7, flexible, headerDecoder, ReadV7);
                case 8:
                    return new Decoder<ResponseHeader, MetadataResponse>(API_KEY, 8, flexible, headerDecoder, ReadV8);
                case 9:
                    return new Decoder<ResponseHeader, MetadataResponse>(API_KEY, 9, flexible, headerDecoder, ReadV9);
                case 10:
                    return new Decoder<ResponseHeader, MetadataResponse>(API_KEY, 10, flexible, headerDecoder, ReadV10);
                case 11:
                    return new Decoder<ResponseHeader, MetadataResponse>(API_KEY, 11, flexible, headerDecoder, ReadV11);
                case 12:
                    return new Decoder<ResponseHeader, MetadataResponse>(API_KEY, 12, flexible, headerDecoder, ReadV12);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        private static int WriteV0(byte[] buffer, int index, MetadataResponse message)
        {
            index = BinaryEncoder.WriteArray<MetadataResponseBroker>(buffer, index, message.BrokersField, MetadataResponseBrokerSerde.WriteV0);
            index = BinaryEncoder.WriteArray<MetadataResponseTopic>(buffer, index, message.TopicsField, MetadataResponseTopicSerde.WriteV0);
            return index;
        }
        private static (int Offset, MetadataResponse Value) ReadV0(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var brokersField = ImmutableArray<MetadataResponseBroker>.Empty;
            var clusterIdField = default(string?);
            var controllerIdField = default(int);
            var topicsField = ImmutableArray<MetadataResponseTopic>.Empty;
            var clusterAuthorizedOperationsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _brokersField_) = BinaryDecoder.ReadArray<MetadataResponseBroker>(buffer, index, MetadataResponseBrokerSerde.ReadV0);
            if (_brokersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Brokers'");
            else
                brokersField = _brokersField_.Value;
            (index, var _topicsField_) = BinaryDecoder.ReadArray<MetadataResponseTopic>(buffer, index, MetadataResponseTopicSerde.ReadV0);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return (index, new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static int WriteV1(byte[] buffer, int index, MetadataResponse message)
        {
            index = BinaryEncoder.WriteArray<MetadataResponseBroker>(buffer, index, message.BrokersField, MetadataResponseBrokerSerde.WriteV1);
            index = BinaryEncoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = BinaryEncoder.WriteArray<MetadataResponseTopic>(buffer, index, message.TopicsField, MetadataResponseTopicSerde.WriteV1);
            return index;
        }
        private static (int Offset, MetadataResponse Value) ReadV1(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var brokersField = ImmutableArray<MetadataResponseBroker>.Empty;
            var clusterIdField = default(string?);
            var controllerIdField = default(int);
            var topicsField = ImmutableArray<MetadataResponseTopic>.Empty;
            var clusterAuthorizedOperationsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _brokersField_) = BinaryDecoder.ReadArray<MetadataResponseBroker>(buffer, index, MetadataResponseBrokerSerde.ReadV1);
            if (_brokersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Brokers'");
            else
                brokersField = _brokersField_.Value;
            (index, controllerIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<MetadataResponseTopic>(buffer, index, MetadataResponseTopicSerde.ReadV1);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return (index, new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static int WriteV2(byte[] buffer, int index, MetadataResponse message)
        {
            index = BinaryEncoder.WriteArray<MetadataResponseBroker>(buffer, index, message.BrokersField, MetadataResponseBrokerSerde.WriteV2);
            index = BinaryEncoder.WriteNullableString(buffer, index, message.ClusterIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = BinaryEncoder.WriteArray<MetadataResponseTopic>(buffer, index, message.TopicsField, MetadataResponseTopicSerde.WriteV2);
            return index;
        }
        private static (int Offset, MetadataResponse Value) ReadV2(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var brokersField = ImmutableArray<MetadataResponseBroker>.Empty;
            var clusterIdField = default(string?);
            var controllerIdField = default(int);
            var topicsField = ImmutableArray<MetadataResponseTopic>.Empty;
            var clusterAuthorizedOperationsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _brokersField_) = BinaryDecoder.ReadArray<MetadataResponseBroker>(buffer, index, MetadataResponseBrokerSerde.ReadV2);
            if (_brokersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Brokers'");
            else
                brokersField = _brokersField_.Value;
            (index, clusterIdField) = BinaryDecoder.ReadNullableString(buffer, index);
            (index, controllerIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<MetadataResponseTopic>(buffer, index, MetadataResponseTopicSerde.ReadV2);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return (index, new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static int WriteV3(byte[] buffer, int index, MetadataResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteArray<MetadataResponseBroker>(buffer, index, message.BrokersField, MetadataResponseBrokerSerde.WriteV3);
            index = BinaryEncoder.WriteNullableString(buffer, index, message.ClusterIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = BinaryEncoder.WriteArray<MetadataResponseTopic>(buffer, index, message.TopicsField, MetadataResponseTopicSerde.WriteV3);
            return index;
        }
        private static (int Offset, MetadataResponse Value) ReadV3(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var brokersField = ImmutableArray<MetadataResponseBroker>.Empty;
            var clusterIdField = default(string?);
            var controllerIdField = default(int);
            var topicsField = ImmutableArray<MetadataResponseTopic>.Empty;
            var clusterAuthorizedOperationsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _brokersField_) = BinaryDecoder.ReadArray<MetadataResponseBroker>(buffer, index, MetadataResponseBrokerSerde.ReadV3);
            if (_brokersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Brokers'");
            else
                brokersField = _brokersField_.Value;
            (index, clusterIdField) = BinaryDecoder.ReadNullableString(buffer, index);
            (index, controllerIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<MetadataResponseTopic>(buffer, index, MetadataResponseTopicSerde.ReadV3);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return (index, new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static int WriteV4(byte[] buffer, int index, MetadataResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteArray<MetadataResponseBroker>(buffer, index, message.BrokersField, MetadataResponseBrokerSerde.WriteV4);
            index = BinaryEncoder.WriteNullableString(buffer, index, message.ClusterIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = BinaryEncoder.WriteArray<MetadataResponseTopic>(buffer, index, message.TopicsField, MetadataResponseTopicSerde.WriteV4);
            return index;
        }
        private static (int Offset, MetadataResponse Value) ReadV4(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var brokersField = ImmutableArray<MetadataResponseBroker>.Empty;
            var clusterIdField = default(string?);
            var controllerIdField = default(int);
            var topicsField = ImmutableArray<MetadataResponseTopic>.Empty;
            var clusterAuthorizedOperationsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _brokersField_) = BinaryDecoder.ReadArray<MetadataResponseBroker>(buffer, index, MetadataResponseBrokerSerde.ReadV4);
            if (_brokersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Brokers'");
            else
                brokersField = _brokersField_.Value;
            (index, clusterIdField) = BinaryDecoder.ReadNullableString(buffer, index);
            (index, controllerIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<MetadataResponseTopic>(buffer, index, MetadataResponseTopicSerde.ReadV4);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return (index, new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static int WriteV5(byte[] buffer, int index, MetadataResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteArray<MetadataResponseBroker>(buffer, index, message.BrokersField, MetadataResponseBrokerSerde.WriteV5);
            index = BinaryEncoder.WriteNullableString(buffer, index, message.ClusterIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = BinaryEncoder.WriteArray<MetadataResponseTopic>(buffer, index, message.TopicsField, MetadataResponseTopicSerde.WriteV5);
            return index;
        }
        private static (int Offset, MetadataResponse Value) ReadV5(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var brokersField = ImmutableArray<MetadataResponseBroker>.Empty;
            var clusterIdField = default(string?);
            var controllerIdField = default(int);
            var topicsField = ImmutableArray<MetadataResponseTopic>.Empty;
            var clusterAuthorizedOperationsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _brokersField_) = BinaryDecoder.ReadArray<MetadataResponseBroker>(buffer, index, MetadataResponseBrokerSerde.ReadV5);
            if (_brokersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Brokers'");
            else
                brokersField = _brokersField_.Value;
            (index, clusterIdField) = BinaryDecoder.ReadNullableString(buffer, index);
            (index, controllerIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<MetadataResponseTopic>(buffer, index, MetadataResponseTopicSerde.ReadV5);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return (index, new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static int WriteV6(byte[] buffer, int index, MetadataResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteArray<MetadataResponseBroker>(buffer, index, message.BrokersField, MetadataResponseBrokerSerde.WriteV6);
            index = BinaryEncoder.WriteNullableString(buffer, index, message.ClusterIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = BinaryEncoder.WriteArray<MetadataResponseTopic>(buffer, index, message.TopicsField, MetadataResponseTopicSerde.WriteV6);
            return index;
        }
        private static (int Offset, MetadataResponse Value) ReadV6(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var brokersField = ImmutableArray<MetadataResponseBroker>.Empty;
            var clusterIdField = default(string?);
            var controllerIdField = default(int);
            var topicsField = ImmutableArray<MetadataResponseTopic>.Empty;
            var clusterAuthorizedOperationsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _brokersField_) = BinaryDecoder.ReadArray<MetadataResponseBroker>(buffer, index, MetadataResponseBrokerSerde.ReadV6);
            if (_brokersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Brokers'");
            else
                brokersField = _brokersField_.Value;
            (index, clusterIdField) = BinaryDecoder.ReadNullableString(buffer, index);
            (index, controllerIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<MetadataResponseTopic>(buffer, index, MetadataResponseTopicSerde.ReadV6);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return (index, new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static int WriteV7(byte[] buffer, int index, MetadataResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteArray<MetadataResponseBroker>(buffer, index, message.BrokersField, MetadataResponseBrokerSerde.WriteV7);
            index = BinaryEncoder.WriteNullableString(buffer, index, message.ClusterIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = BinaryEncoder.WriteArray<MetadataResponseTopic>(buffer, index, message.TopicsField, MetadataResponseTopicSerde.WriteV7);
            return index;
        }
        private static (int Offset, MetadataResponse Value) ReadV7(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var brokersField = ImmutableArray<MetadataResponseBroker>.Empty;
            var clusterIdField = default(string?);
            var controllerIdField = default(int);
            var topicsField = ImmutableArray<MetadataResponseTopic>.Empty;
            var clusterAuthorizedOperationsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _brokersField_) = BinaryDecoder.ReadArray<MetadataResponseBroker>(buffer, index, MetadataResponseBrokerSerde.ReadV7);
            if (_brokersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Brokers'");
            else
                brokersField = _brokersField_.Value;
            (index, clusterIdField) = BinaryDecoder.ReadNullableString(buffer, index);
            (index, controllerIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<MetadataResponseTopic>(buffer, index, MetadataResponseTopicSerde.ReadV7);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return (index, new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static int WriteV8(byte[] buffer, int index, MetadataResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteArray<MetadataResponseBroker>(buffer, index, message.BrokersField, MetadataResponseBrokerSerde.WriteV8);
            index = BinaryEncoder.WriteNullableString(buffer, index, message.ClusterIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = BinaryEncoder.WriteArray<MetadataResponseTopic>(buffer, index, message.TopicsField, MetadataResponseTopicSerde.WriteV8);
            index = BinaryEncoder.WriteInt32(buffer, index, message.ClusterAuthorizedOperationsField);
            return index;
        }
        private static (int Offset, MetadataResponse Value) ReadV8(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var brokersField = ImmutableArray<MetadataResponseBroker>.Empty;
            var clusterIdField = default(string?);
            var controllerIdField = default(int);
            var topicsField = ImmutableArray<MetadataResponseTopic>.Empty;
            var clusterAuthorizedOperationsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _brokersField_) = BinaryDecoder.ReadArray<MetadataResponseBroker>(buffer, index, MetadataResponseBrokerSerde.ReadV8);
            if (_brokersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Brokers'");
            else
                brokersField = _brokersField_.Value;
            (index, clusterIdField) = BinaryDecoder.ReadNullableString(buffer, index);
            (index, controllerIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<MetadataResponseTopic>(buffer, index, MetadataResponseTopicSerde.ReadV8);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (index, clusterAuthorizedOperationsField) = BinaryDecoder.ReadInt32(buffer, index);
            return (index, new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static int WriteV9(byte[] buffer, int index, MetadataResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteCompactArray<MetadataResponseBroker>(buffer, index, message.BrokersField, MetadataResponseBrokerSerde.WriteV9);
            index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.ClusterIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = BinaryEncoder.WriteCompactArray<MetadataResponseTopic>(buffer, index, message.TopicsField, MetadataResponseTopicSerde.WriteV9);
            index = BinaryEncoder.WriteInt32(buffer, index, message.ClusterAuthorizedOperationsField);
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
        private static (int Offset, MetadataResponse Value) ReadV9(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var brokersField = ImmutableArray<MetadataResponseBroker>.Empty;
            var clusterIdField = default(string?);
            var controllerIdField = default(int);
            var topicsField = ImmutableArray<MetadataResponseTopic>.Empty;
            var clusterAuthorizedOperationsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _brokersField_) = BinaryDecoder.ReadCompactArray<MetadataResponseBroker>(buffer, index, MetadataResponseBrokerSerde.ReadV9);
            if (_brokersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Brokers'");
            else
                brokersField = _brokersField_.Value;
            (index, clusterIdField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
            (index, controllerIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadCompactArray<MetadataResponseTopic>(buffer, index, MetadataResponseTopicSerde.ReadV9);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (index, clusterAuthorizedOperationsField) = BinaryDecoder.ReadInt32(buffer, index);
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
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static int WriteV10(byte[] buffer, int index, MetadataResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteCompactArray<MetadataResponseBroker>(buffer, index, message.BrokersField, MetadataResponseBrokerSerde.WriteV10);
            index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.ClusterIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = BinaryEncoder.WriteCompactArray<MetadataResponseTopic>(buffer, index, message.TopicsField, MetadataResponseTopicSerde.WriteV10);
            index = BinaryEncoder.WriteInt32(buffer, index, message.ClusterAuthorizedOperationsField);
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
        private static (int Offset, MetadataResponse Value) ReadV10(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var brokersField = ImmutableArray<MetadataResponseBroker>.Empty;
            var clusterIdField = default(string?);
            var controllerIdField = default(int);
            var topicsField = ImmutableArray<MetadataResponseTopic>.Empty;
            var clusterAuthorizedOperationsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _brokersField_) = BinaryDecoder.ReadCompactArray<MetadataResponseBroker>(buffer, index, MetadataResponseBrokerSerde.ReadV10);
            if (_brokersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Brokers'");
            else
                brokersField = _brokersField_.Value;
            (index, clusterIdField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
            (index, controllerIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadCompactArray<MetadataResponseTopic>(buffer, index, MetadataResponseTopicSerde.ReadV10);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (index, clusterAuthorizedOperationsField) = BinaryDecoder.ReadInt32(buffer, index);
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
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static int WriteV11(byte[] buffer, int index, MetadataResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteCompactArray<MetadataResponseBroker>(buffer, index, message.BrokersField, MetadataResponseBrokerSerde.WriteV11);
            index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.ClusterIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = BinaryEncoder.WriteCompactArray<MetadataResponseTopic>(buffer, index, message.TopicsField, MetadataResponseTopicSerde.WriteV11);
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
        private static (int Offset, MetadataResponse Value) ReadV11(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var brokersField = ImmutableArray<MetadataResponseBroker>.Empty;
            var clusterIdField = default(string?);
            var controllerIdField = default(int);
            var topicsField = ImmutableArray<MetadataResponseTopic>.Empty;
            var clusterAuthorizedOperationsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _brokersField_) = BinaryDecoder.ReadCompactArray<MetadataResponseBroker>(buffer, index, MetadataResponseBrokerSerde.ReadV11);
            if (_brokersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Brokers'");
            else
                brokersField = _brokersField_.Value;
            (index, clusterIdField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
            (index, controllerIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadCompactArray<MetadataResponseTopic>(buffer, index, MetadataResponseTopicSerde.ReadV11);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
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
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static int WriteV12(byte[] buffer, int index, MetadataResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteCompactArray<MetadataResponseBroker>(buffer, index, message.BrokersField, MetadataResponseBrokerSerde.WriteV12);
            index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.ClusterIdField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.ControllerIdField);
            index = BinaryEncoder.WriteCompactArray<MetadataResponseTopic>(buffer, index, message.TopicsField, MetadataResponseTopicSerde.WriteV12);
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
        private static (int Offset, MetadataResponse Value) ReadV12(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var brokersField = ImmutableArray<MetadataResponseBroker>.Empty;
            var clusterIdField = default(string?);
            var controllerIdField = default(int);
            var topicsField = ImmutableArray<MetadataResponseTopic>.Empty;
            var clusterAuthorizedOperationsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _brokersField_) = BinaryDecoder.ReadCompactArray<MetadataResponseBroker>(buffer, index, MetadataResponseBrokerSerde.ReadV12);
            if (_brokersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Brokers'");
            else
                brokersField = _brokersField_.Value;
            (index, clusterIdField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
            (index, controllerIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadCompactArray<MetadataResponseTopic>(buffer, index, MetadataResponseTopicSerde.ReadV12);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
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
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField,
                taggedFields
            ));
        }
        [GeneratedCode("kgen", "1.0.0.0")]
        private static class MetadataResponseBrokerSerde
        {
            public static int WriteV0(byte[] buffer, int index, MetadataResponseBroker message)
            {
                index = BinaryEncoder.WriteInt32(buffer, index, message.NodeIdField);
                index = BinaryEncoder.WriteString(buffer, index, message.HostField);
                index = BinaryEncoder.WriteInt32(buffer, index, message.PortField);
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
            public static (int Offset, MetadataResponseBroker Value) ReadV0(byte[] buffer, int index)
            {
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nodeIdField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, hostField) = BinaryDecoder.ReadString(buffer, index);
                (index, portField) = BinaryDecoder.ReadInt32(buffer, index);
                return (index, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static int WriteV1(byte[] buffer, int index, MetadataResponseBroker message)
            {
                index = BinaryEncoder.WriteInt32(buffer, index, message.NodeIdField);
                index = BinaryEncoder.WriteString(buffer, index, message.HostField);
                index = BinaryEncoder.WriteInt32(buffer, index, message.PortField);
                index = BinaryEncoder.WriteNullableString(buffer, index, message.RackField);
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
            public static (int Offset, MetadataResponseBroker Value) ReadV1(byte[] buffer, int index)
            {
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nodeIdField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, hostField) = BinaryDecoder.ReadString(buffer, index);
                (index, portField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, rackField) = BinaryDecoder.ReadNullableString(buffer, index);
                return (index, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static int WriteV2(byte[] buffer, int index, MetadataResponseBroker message)
            {
                index = BinaryEncoder.WriteInt32(buffer, index, message.NodeIdField);
                index = BinaryEncoder.WriteString(buffer, index, message.HostField);
                index = BinaryEncoder.WriteInt32(buffer, index, message.PortField);
                index = BinaryEncoder.WriteNullableString(buffer, index, message.RackField);
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
            public static (int Offset, MetadataResponseBroker Value) ReadV2(byte[] buffer, int index)
            {
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nodeIdField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, hostField) = BinaryDecoder.ReadString(buffer, index);
                (index, portField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, rackField) = BinaryDecoder.ReadNullableString(buffer, index);
                return (index, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static int WriteV3(byte[] buffer, int index, MetadataResponseBroker message)
            {
                index = BinaryEncoder.WriteInt32(buffer, index, message.NodeIdField);
                index = BinaryEncoder.WriteString(buffer, index, message.HostField);
                index = BinaryEncoder.WriteInt32(buffer, index, message.PortField);
                index = BinaryEncoder.WriteNullableString(buffer, index, message.RackField);
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
            public static (int Offset, MetadataResponseBroker Value) ReadV3(byte[] buffer, int index)
            {
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nodeIdField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, hostField) = BinaryDecoder.ReadString(buffer, index);
                (index, portField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, rackField) = BinaryDecoder.ReadNullableString(buffer, index);
                return (index, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static int WriteV4(byte[] buffer, int index, MetadataResponseBroker message)
            {
                index = BinaryEncoder.WriteInt32(buffer, index, message.NodeIdField);
                index = BinaryEncoder.WriteString(buffer, index, message.HostField);
                index = BinaryEncoder.WriteInt32(buffer, index, message.PortField);
                index = BinaryEncoder.WriteNullableString(buffer, index, message.RackField);
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
            public static (int Offset, MetadataResponseBroker Value) ReadV4(byte[] buffer, int index)
            {
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nodeIdField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, hostField) = BinaryDecoder.ReadString(buffer, index);
                (index, portField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, rackField) = BinaryDecoder.ReadNullableString(buffer, index);
                return (index, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static int WriteV5(byte[] buffer, int index, MetadataResponseBroker message)
            {
                index = BinaryEncoder.WriteInt32(buffer, index, message.NodeIdField);
                index = BinaryEncoder.WriteString(buffer, index, message.HostField);
                index = BinaryEncoder.WriteInt32(buffer, index, message.PortField);
                index = BinaryEncoder.WriteNullableString(buffer, index, message.RackField);
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
            public static (int Offset, MetadataResponseBroker Value) ReadV5(byte[] buffer, int index)
            {
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nodeIdField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, hostField) = BinaryDecoder.ReadString(buffer, index);
                (index, portField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, rackField) = BinaryDecoder.ReadNullableString(buffer, index);
                return (index, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static int WriteV6(byte[] buffer, int index, MetadataResponseBroker message)
            {
                index = BinaryEncoder.WriteInt32(buffer, index, message.NodeIdField);
                index = BinaryEncoder.WriteString(buffer, index, message.HostField);
                index = BinaryEncoder.WriteInt32(buffer, index, message.PortField);
                index = BinaryEncoder.WriteNullableString(buffer, index, message.RackField);
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
            public static (int Offset, MetadataResponseBroker Value) ReadV6(byte[] buffer, int index)
            {
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nodeIdField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, hostField) = BinaryDecoder.ReadString(buffer, index);
                (index, portField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, rackField) = BinaryDecoder.ReadNullableString(buffer, index);
                return (index, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static int WriteV7(byte[] buffer, int index, MetadataResponseBroker message)
            {
                index = BinaryEncoder.WriteInt32(buffer, index, message.NodeIdField);
                index = BinaryEncoder.WriteString(buffer, index, message.HostField);
                index = BinaryEncoder.WriteInt32(buffer, index, message.PortField);
                index = BinaryEncoder.WriteNullableString(buffer, index, message.RackField);
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
            public static (int Offset, MetadataResponseBroker Value) ReadV7(byte[] buffer, int index)
            {
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nodeIdField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, hostField) = BinaryDecoder.ReadString(buffer, index);
                (index, portField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, rackField) = BinaryDecoder.ReadNullableString(buffer, index);
                return (index, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static int WriteV8(byte[] buffer, int index, MetadataResponseBroker message)
            {
                index = BinaryEncoder.WriteInt32(buffer, index, message.NodeIdField);
                index = BinaryEncoder.WriteString(buffer, index, message.HostField);
                index = BinaryEncoder.WriteInt32(buffer, index, message.PortField);
                index = BinaryEncoder.WriteNullableString(buffer, index, message.RackField);
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
            public static (int Offset, MetadataResponseBroker Value) ReadV8(byte[] buffer, int index)
            {
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nodeIdField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, hostField) = BinaryDecoder.ReadString(buffer, index);
                (index, portField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, rackField) = BinaryDecoder.ReadNullableString(buffer, index);
                return (index, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static int WriteV9(byte[] buffer, int index, MetadataResponseBroker message)
            {
                index = BinaryEncoder.WriteInt32(buffer, index, message.NodeIdField);
                index = BinaryEncoder.WriteCompactString(buffer, index, message.HostField);
                index = BinaryEncoder.WriteInt32(buffer, index, message.PortField);
                index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.RackField);
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
            public static (int Offset, MetadataResponseBroker Value) ReadV9(byte[] buffer, int index)
            {
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nodeIdField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, hostField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, portField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, rackField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
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
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static int WriteV10(byte[] buffer, int index, MetadataResponseBroker message)
            {
                index = BinaryEncoder.WriteInt32(buffer, index, message.NodeIdField);
                index = BinaryEncoder.WriteCompactString(buffer, index, message.HostField);
                index = BinaryEncoder.WriteInt32(buffer, index, message.PortField);
                index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.RackField);
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
            public static (int Offset, MetadataResponseBroker Value) ReadV10(byte[] buffer, int index)
            {
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nodeIdField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, hostField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, portField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, rackField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
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
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static int WriteV11(byte[] buffer, int index, MetadataResponseBroker message)
            {
                index = BinaryEncoder.WriteInt32(buffer, index, message.NodeIdField);
                index = BinaryEncoder.WriteCompactString(buffer, index, message.HostField);
                index = BinaryEncoder.WriteInt32(buffer, index, message.PortField);
                index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.RackField);
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
            public static (int Offset, MetadataResponseBroker Value) ReadV11(byte[] buffer, int index)
            {
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nodeIdField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, hostField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, portField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, rackField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
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
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static int WriteV12(byte[] buffer, int index, MetadataResponseBroker message)
            {
                index = BinaryEncoder.WriteInt32(buffer, index, message.NodeIdField);
                index = BinaryEncoder.WriteCompactString(buffer, index, message.HostField);
                index = BinaryEncoder.WriteInt32(buffer, index, message.PortField);
                index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.RackField);
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
            public static (int Offset, MetadataResponseBroker Value) ReadV12(byte[] buffer, int index)
            {
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nodeIdField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, hostField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, portField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, rackField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
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
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
        }
        [GeneratedCode("kgen", "1.0.0.0")]
        private static class MetadataResponseTopicSerde
        {
            public static int WriteV0(byte[] buffer, int index, MetadataResponseTopic message)
            {
                index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteArray<MetadataResponsePartition>(buffer, index, message.PartitionsField, MetadataResponsePartitionSerde.WriteV0);
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
            public static (int Offset, MetadataResponseTopic Value) ReadV0(byte[] buffer, int index)
            {
                var errorCodeField = default(short);
                var nameField = default(string?);
                var topicIdField = default(Guid);
                var isInternalField = default(bool);
                var partitionsField = ImmutableArray<MetadataResponsePartition>.Empty;
                var topicAuthorizedOperationsField = default(int);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<MetadataResponsePartition>(buffer, index, MetadataResponsePartitionSerde.ReadV0);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return (index, new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField,
                    taggedFields
                ));
            }
            public static int WriteV1(byte[] buffer, int index, MetadataResponseTopic message)
            {
                index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteBoolean(buffer, index, message.IsInternalField);
                index = BinaryEncoder.WriteArray<MetadataResponsePartition>(buffer, index, message.PartitionsField, MetadataResponsePartitionSerde.WriteV1);
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
            public static (int Offset, MetadataResponseTopic Value) ReadV1(byte[] buffer, int index)
            {
                var errorCodeField = default(short);
                var nameField = default(string?);
                var topicIdField = default(Guid);
                var isInternalField = default(bool);
                var partitionsField = ImmutableArray<MetadataResponsePartition>.Empty;
                var topicAuthorizedOperationsField = default(int);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, isInternalField) = BinaryDecoder.ReadBoolean(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<MetadataResponsePartition>(buffer, index, MetadataResponsePartitionSerde.ReadV1);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return (index, new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField,
                    taggedFields
                ));
            }
            public static int WriteV2(byte[] buffer, int index, MetadataResponseTopic message)
            {
                index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteBoolean(buffer, index, message.IsInternalField);
                index = BinaryEncoder.WriteArray<MetadataResponsePartition>(buffer, index, message.PartitionsField, MetadataResponsePartitionSerde.WriteV2);
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
            public static (int Offset, MetadataResponseTopic Value) ReadV2(byte[] buffer, int index)
            {
                var errorCodeField = default(short);
                var nameField = default(string?);
                var topicIdField = default(Guid);
                var isInternalField = default(bool);
                var partitionsField = ImmutableArray<MetadataResponsePartition>.Empty;
                var topicAuthorizedOperationsField = default(int);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, isInternalField) = BinaryDecoder.ReadBoolean(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<MetadataResponsePartition>(buffer, index, MetadataResponsePartitionSerde.ReadV2);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return (index, new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField,
                    taggedFields
                ));
            }
            public static int WriteV3(byte[] buffer, int index, MetadataResponseTopic message)
            {
                index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteBoolean(buffer, index, message.IsInternalField);
                index = BinaryEncoder.WriteArray<MetadataResponsePartition>(buffer, index, message.PartitionsField, MetadataResponsePartitionSerde.WriteV3);
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
            public static (int Offset, MetadataResponseTopic Value) ReadV3(byte[] buffer, int index)
            {
                var errorCodeField = default(short);
                var nameField = default(string?);
                var topicIdField = default(Guid);
                var isInternalField = default(bool);
                var partitionsField = ImmutableArray<MetadataResponsePartition>.Empty;
                var topicAuthorizedOperationsField = default(int);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, isInternalField) = BinaryDecoder.ReadBoolean(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<MetadataResponsePartition>(buffer, index, MetadataResponsePartitionSerde.ReadV3);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return (index, new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField,
                    taggedFields
                ));
            }
            public static int WriteV4(byte[] buffer, int index, MetadataResponseTopic message)
            {
                index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteBoolean(buffer, index, message.IsInternalField);
                index = BinaryEncoder.WriteArray<MetadataResponsePartition>(buffer, index, message.PartitionsField, MetadataResponsePartitionSerde.WriteV4);
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
            public static (int Offset, MetadataResponseTopic Value) ReadV4(byte[] buffer, int index)
            {
                var errorCodeField = default(short);
                var nameField = default(string?);
                var topicIdField = default(Guid);
                var isInternalField = default(bool);
                var partitionsField = ImmutableArray<MetadataResponsePartition>.Empty;
                var topicAuthorizedOperationsField = default(int);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, isInternalField) = BinaryDecoder.ReadBoolean(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<MetadataResponsePartition>(buffer, index, MetadataResponsePartitionSerde.ReadV4);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return (index, new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField,
                    taggedFields
                ));
            }
            public static int WriteV5(byte[] buffer, int index, MetadataResponseTopic message)
            {
                index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteBoolean(buffer, index, message.IsInternalField);
                index = BinaryEncoder.WriteArray<MetadataResponsePartition>(buffer, index, message.PartitionsField, MetadataResponsePartitionSerde.WriteV5);
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
            public static (int Offset, MetadataResponseTopic Value) ReadV5(byte[] buffer, int index)
            {
                var errorCodeField = default(short);
                var nameField = default(string?);
                var topicIdField = default(Guid);
                var isInternalField = default(bool);
                var partitionsField = ImmutableArray<MetadataResponsePartition>.Empty;
                var topicAuthorizedOperationsField = default(int);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, isInternalField) = BinaryDecoder.ReadBoolean(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<MetadataResponsePartition>(buffer, index, MetadataResponsePartitionSerde.ReadV5);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return (index, new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField,
                    taggedFields
                ));
            }
            public static int WriteV6(byte[] buffer, int index, MetadataResponseTopic message)
            {
                index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteBoolean(buffer, index, message.IsInternalField);
                index = BinaryEncoder.WriteArray<MetadataResponsePartition>(buffer, index, message.PartitionsField, MetadataResponsePartitionSerde.WriteV6);
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
            public static (int Offset, MetadataResponseTopic Value) ReadV6(byte[] buffer, int index)
            {
                var errorCodeField = default(short);
                var nameField = default(string?);
                var topicIdField = default(Guid);
                var isInternalField = default(bool);
                var partitionsField = ImmutableArray<MetadataResponsePartition>.Empty;
                var topicAuthorizedOperationsField = default(int);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, isInternalField) = BinaryDecoder.ReadBoolean(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<MetadataResponsePartition>(buffer, index, MetadataResponsePartitionSerde.ReadV6);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return (index, new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField,
                    taggedFields
                ));
            }
            public static int WriteV7(byte[] buffer, int index, MetadataResponseTopic message)
            {
                index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteBoolean(buffer, index, message.IsInternalField);
                index = BinaryEncoder.WriteArray<MetadataResponsePartition>(buffer, index, message.PartitionsField, MetadataResponsePartitionSerde.WriteV7);
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
            public static (int Offset, MetadataResponseTopic Value) ReadV7(byte[] buffer, int index)
            {
                var errorCodeField = default(short);
                var nameField = default(string?);
                var topicIdField = default(Guid);
                var isInternalField = default(bool);
                var partitionsField = ImmutableArray<MetadataResponsePartition>.Empty;
                var topicAuthorizedOperationsField = default(int);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, isInternalField) = BinaryDecoder.ReadBoolean(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<MetadataResponsePartition>(buffer, index, MetadataResponsePartitionSerde.ReadV7);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return (index, new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField,
                    taggedFields
                ));
            }
            public static int WriteV8(byte[] buffer, int index, MetadataResponseTopic message)
            {
                index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = BinaryEncoder.WriteString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteBoolean(buffer, index, message.IsInternalField);
                index = BinaryEncoder.WriteArray<MetadataResponsePartition>(buffer, index, message.PartitionsField, MetadataResponsePartitionSerde.WriteV8);
                index = BinaryEncoder.WriteInt32(buffer, index, message.TopicAuthorizedOperationsField);
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
            public static (int Offset, MetadataResponseTopic Value) ReadV8(byte[] buffer, int index)
            {
                var errorCodeField = default(short);
                var nameField = default(string?);
                var topicIdField = default(Guid);
                var isInternalField = default(bool);
                var partitionsField = ImmutableArray<MetadataResponsePartition>.Empty;
                var topicAuthorizedOperationsField = default(int);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, isInternalField) = BinaryDecoder.ReadBoolean(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<MetadataResponsePartition>(buffer, index, MetadataResponsePartitionSerde.ReadV8);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                (index, topicAuthorizedOperationsField) = BinaryDecoder.ReadInt32(buffer, index);
                return (index, new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField,
                    taggedFields
                ));
            }
            public static int WriteV9(byte[] buffer, int index, MetadataResponseTopic message)
            {
                index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteBoolean(buffer, index, message.IsInternalField);
                index = BinaryEncoder.WriteCompactArray<MetadataResponsePartition>(buffer, index, message.PartitionsField, MetadataResponsePartitionSerde.WriteV9);
                index = BinaryEncoder.WriteInt32(buffer, index, message.TopicAuthorizedOperationsField);
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
            public static (int Offset, MetadataResponseTopic Value) ReadV9(byte[] buffer, int index)
            {
                var errorCodeField = default(short);
                var nameField = default(string?);
                var topicIdField = default(Guid);
                var isInternalField = default(bool);
                var partitionsField = ImmutableArray<MetadataResponsePartition>.Empty;
                var topicAuthorizedOperationsField = default(int);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, isInternalField) = BinaryDecoder.ReadBoolean(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadCompactArray<MetadataResponsePartition>(buffer, index, MetadataResponsePartitionSerde.ReadV9);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                (index, topicAuthorizedOperationsField) = BinaryDecoder.ReadInt32(buffer, index);
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
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField,
                    taggedFields
                ));
            }
            public static int WriteV10(byte[] buffer, int index, MetadataResponseTopic message)
            {
                index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteUuid(buffer, index, message.TopicIdField);
                index = BinaryEncoder.WriteBoolean(buffer, index, message.IsInternalField);
                index = BinaryEncoder.WriteCompactArray<MetadataResponsePartition>(buffer, index, message.PartitionsField, MetadataResponsePartitionSerde.WriteV10);
                index = BinaryEncoder.WriteInt32(buffer, index, message.TopicAuthorizedOperationsField);
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
            public static (int Offset, MetadataResponseTopic Value) ReadV10(byte[] buffer, int index)
            {
                var errorCodeField = default(short);
                var nameField = default(string?);
                var topicIdField = default(Guid);
                var isInternalField = default(bool);
                var partitionsField = ImmutableArray<MetadataResponsePartition>.Empty;
                var topicAuthorizedOperationsField = default(int);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, topicIdField) = BinaryDecoder.ReadUuid(buffer, index);
                (index, isInternalField) = BinaryDecoder.ReadBoolean(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadCompactArray<MetadataResponsePartition>(buffer, index, MetadataResponsePartitionSerde.ReadV10);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                (index, topicAuthorizedOperationsField) = BinaryDecoder.ReadInt32(buffer, index);
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
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField,
                    taggedFields
                ));
            }
            public static int WriteV11(byte[] buffer, int index, MetadataResponseTopic message)
            {
                index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                if (message.NameField == null)
                    throw new ArgumentNullException(nameof(message.NameField));
                index = BinaryEncoder.WriteCompactString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteUuid(buffer, index, message.TopicIdField);
                index = BinaryEncoder.WriteBoolean(buffer, index, message.IsInternalField);
                index = BinaryEncoder.WriteCompactArray<MetadataResponsePartition>(buffer, index, message.PartitionsField, MetadataResponsePartitionSerde.WriteV11);
                index = BinaryEncoder.WriteInt32(buffer, index, message.TopicAuthorizedOperationsField);
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
            public static (int Offset, MetadataResponseTopic Value) ReadV11(byte[] buffer, int index)
            {
                var errorCodeField = default(short);
                var nameField = default(string?);
                var topicIdField = default(Guid);
                var isInternalField = default(bool);
                var partitionsField = ImmutableArray<MetadataResponsePartition>.Empty;
                var topicAuthorizedOperationsField = default(int);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, topicIdField) = BinaryDecoder.ReadUuid(buffer, index);
                (index, isInternalField) = BinaryDecoder.ReadBoolean(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadCompactArray<MetadataResponsePartition>(buffer, index, MetadataResponsePartitionSerde.ReadV11);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                (index, topicAuthorizedOperationsField) = BinaryDecoder.ReadInt32(buffer, index);
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
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField,
                    taggedFields
                ));
            }
            public static int WriteV12(byte[] buffer, int index, MetadataResponseTopic message)
            {
                index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.NameField);
                index = BinaryEncoder.WriteUuid(buffer, index, message.TopicIdField);
                index = BinaryEncoder.WriteBoolean(buffer, index, message.IsInternalField);
                index = BinaryEncoder.WriteCompactArray<MetadataResponsePartition>(buffer, index, message.PartitionsField, MetadataResponsePartitionSerde.WriteV12);
                index = BinaryEncoder.WriteInt32(buffer, index, message.TopicAuthorizedOperationsField);
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
            public static (int Offset, MetadataResponseTopic Value) ReadV12(byte[] buffer, int index)
            {
                var errorCodeField = default(short);
                var nameField = default(string?);
                var topicIdField = default(Guid);
                var isInternalField = default(bool);
                var partitionsField = ImmutableArray<MetadataResponsePartition>.Empty;
                var topicAuthorizedOperationsField = default(int);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                (index, nameField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
                (index, topicIdField) = BinaryDecoder.ReadUuid(buffer, index);
                (index, isInternalField) = BinaryDecoder.ReadBoolean(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadCompactArray<MetadataResponsePartition>(buffer, index, MetadataResponsePartitionSerde.ReadV12);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                (index, topicAuthorizedOperationsField) = BinaryDecoder.ReadInt32(buffer, index);
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
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField,
                    taggedFields
                ));
            }
            [GeneratedCode("kgen", "1.0.0.0")]
            private static class MetadataResponsePartitionSerde
            {
                public static int WriteV0(byte[] buffer, int index, MetadataResponsePartition message)
                {
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.LeaderIdField);
                    index = BinaryEncoder.WriteArray<int>(buffer, index, message.ReplicaNodesField, BinaryEncoder.WriteInt32);
                    index = BinaryEncoder.WriteArray<int>(buffer, index, message.IsrNodesField, BinaryEncoder.WriteInt32);
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
                public static (int Offset, MetadataResponsePartition Value) ReadV0(byte[] buffer, int index)
                {
                    var errorCodeField = default(short);
                    var partitionIndexField = default(int);
                    var leaderIdField = default(int);
                    var leaderEpochField = default(int);
                    var replicaNodesField = ImmutableArray<int>.Empty;
                    var isrNodesField = ImmutableArray<int>.Empty;
                    var offlineReplicasField = ImmutableArray<int>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, leaderIdField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, var _replicaNodesField_) = BinaryDecoder.ReadArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                    if (_replicaNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    else
                        replicaNodesField = _replicaNodesField_.Value;
                    (index, var _isrNodesField_) = BinaryDecoder.ReadArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                    if (_isrNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    else
                        isrNodesField = _isrNodesField_.Value;
                    return (index, new(
                        errorCodeField,
                        partitionIndexField,
                        leaderIdField,
                        leaderEpochField,
                        replicaNodesField,
                        isrNodesField,
                        offlineReplicasField,
                        taggedFields
                    ));
                }
                public static int WriteV1(byte[] buffer, int index, MetadataResponsePartition message)
                {
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.LeaderIdField);
                    index = BinaryEncoder.WriteArray<int>(buffer, index, message.ReplicaNodesField, BinaryEncoder.WriteInt32);
                    index = BinaryEncoder.WriteArray<int>(buffer, index, message.IsrNodesField, BinaryEncoder.WriteInt32);
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
                public static (int Offset, MetadataResponsePartition Value) ReadV1(byte[] buffer, int index)
                {
                    var errorCodeField = default(short);
                    var partitionIndexField = default(int);
                    var leaderIdField = default(int);
                    var leaderEpochField = default(int);
                    var replicaNodesField = ImmutableArray<int>.Empty;
                    var isrNodesField = ImmutableArray<int>.Empty;
                    var offlineReplicasField = ImmutableArray<int>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, leaderIdField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, var _replicaNodesField_) = BinaryDecoder.ReadArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                    if (_replicaNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    else
                        replicaNodesField = _replicaNodesField_.Value;
                    (index, var _isrNodesField_) = BinaryDecoder.ReadArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                    if (_isrNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    else
                        isrNodesField = _isrNodesField_.Value;
                    return (index, new(
                        errorCodeField,
                        partitionIndexField,
                        leaderIdField,
                        leaderEpochField,
                        replicaNodesField,
                        isrNodesField,
                        offlineReplicasField,
                        taggedFields
                    ));
                }
                public static int WriteV2(byte[] buffer, int index, MetadataResponsePartition message)
                {
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.LeaderIdField);
                    index = BinaryEncoder.WriteArray<int>(buffer, index, message.ReplicaNodesField, BinaryEncoder.WriteInt32);
                    index = BinaryEncoder.WriteArray<int>(buffer, index, message.IsrNodesField, BinaryEncoder.WriteInt32);
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
                public static (int Offset, MetadataResponsePartition Value) ReadV2(byte[] buffer, int index)
                {
                    var errorCodeField = default(short);
                    var partitionIndexField = default(int);
                    var leaderIdField = default(int);
                    var leaderEpochField = default(int);
                    var replicaNodesField = ImmutableArray<int>.Empty;
                    var isrNodesField = ImmutableArray<int>.Empty;
                    var offlineReplicasField = ImmutableArray<int>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, leaderIdField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, var _replicaNodesField_) = BinaryDecoder.ReadArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                    if (_replicaNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    else
                        replicaNodesField = _replicaNodesField_.Value;
                    (index, var _isrNodesField_) = BinaryDecoder.ReadArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                    if (_isrNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    else
                        isrNodesField = _isrNodesField_.Value;
                    return (index, new(
                        errorCodeField,
                        partitionIndexField,
                        leaderIdField,
                        leaderEpochField,
                        replicaNodesField,
                        isrNodesField,
                        offlineReplicasField,
                        taggedFields
                    ));
                }
                public static int WriteV3(byte[] buffer, int index, MetadataResponsePartition message)
                {
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.LeaderIdField);
                    index = BinaryEncoder.WriteArray<int>(buffer, index, message.ReplicaNodesField, BinaryEncoder.WriteInt32);
                    index = BinaryEncoder.WriteArray<int>(buffer, index, message.IsrNodesField, BinaryEncoder.WriteInt32);
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
                public static (int Offset, MetadataResponsePartition Value) ReadV3(byte[] buffer, int index)
                {
                    var errorCodeField = default(short);
                    var partitionIndexField = default(int);
                    var leaderIdField = default(int);
                    var leaderEpochField = default(int);
                    var replicaNodesField = ImmutableArray<int>.Empty;
                    var isrNodesField = ImmutableArray<int>.Empty;
                    var offlineReplicasField = ImmutableArray<int>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, leaderIdField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, var _replicaNodesField_) = BinaryDecoder.ReadArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                    if (_replicaNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    else
                        replicaNodesField = _replicaNodesField_.Value;
                    (index, var _isrNodesField_) = BinaryDecoder.ReadArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                    if (_isrNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    else
                        isrNodesField = _isrNodesField_.Value;
                    return (index, new(
                        errorCodeField,
                        partitionIndexField,
                        leaderIdField,
                        leaderEpochField,
                        replicaNodesField,
                        isrNodesField,
                        offlineReplicasField,
                        taggedFields
                    ));
                }
                public static int WriteV4(byte[] buffer, int index, MetadataResponsePartition message)
                {
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.LeaderIdField);
                    index = BinaryEncoder.WriteArray<int>(buffer, index, message.ReplicaNodesField, BinaryEncoder.WriteInt32);
                    index = BinaryEncoder.WriteArray<int>(buffer, index, message.IsrNodesField, BinaryEncoder.WriteInt32);
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
                public static (int Offset, MetadataResponsePartition Value) ReadV4(byte[] buffer, int index)
                {
                    var errorCodeField = default(short);
                    var partitionIndexField = default(int);
                    var leaderIdField = default(int);
                    var leaderEpochField = default(int);
                    var replicaNodesField = ImmutableArray<int>.Empty;
                    var isrNodesField = ImmutableArray<int>.Empty;
                    var offlineReplicasField = ImmutableArray<int>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, leaderIdField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, var _replicaNodesField_) = BinaryDecoder.ReadArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                    if (_replicaNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    else
                        replicaNodesField = _replicaNodesField_.Value;
                    (index, var _isrNodesField_) = BinaryDecoder.ReadArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                    if (_isrNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    else
                        isrNodesField = _isrNodesField_.Value;
                    return (index, new(
                        errorCodeField,
                        partitionIndexField,
                        leaderIdField,
                        leaderEpochField,
                        replicaNodesField,
                        isrNodesField,
                        offlineReplicasField,
                        taggedFields
                    ));
                }
                public static int WriteV5(byte[] buffer, int index, MetadataResponsePartition message)
                {
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.LeaderIdField);
                    index = BinaryEncoder.WriteArray<int>(buffer, index, message.ReplicaNodesField, BinaryEncoder.WriteInt32);
                    index = BinaryEncoder.WriteArray<int>(buffer, index, message.IsrNodesField, BinaryEncoder.WriteInt32);
                    index = BinaryEncoder.WriteArray<int>(buffer, index, message.OfflineReplicasField, BinaryEncoder.WriteInt32);
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
                public static (int Offset, MetadataResponsePartition Value) ReadV5(byte[] buffer, int index)
                {
                    var errorCodeField = default(short);
                    var partitionIndexField = default(int);
                    var leaderIdField = default(int);
                    var leaderEpochField = default(int);
                    var replicaNodesField = ImmutableArray<int>.Empty;
                    var isrNodesField = ImmutableArray<int>.Empty;
                    var offlineReplicasField = ImmutableArray<int>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, leaderIdField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, var _replicaNodesField_) = BinaryDecoder.ReadArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                    if (_replicaNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    else
                        replicaNodesField = _replicaNodesField_.Value;
                    (index, var _isrNodesField_) = BinaryDecoder.ReadArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                    if (_isrNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    else
                        isrNodesField = _isrNodesField_.Value;
                    (index, var _offlineReplicasField_) = BinaryDecoder.ReadArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                    if (_offlineReplicasField_ == null)
                        throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                    else
                        offlineReplicasField = _offlineReplicasField_.Value;
                    return (index, new(
                        errorCodeField,
                        partitionIndexField,
                        leaderIdField,
                        leaderEpochField,
                        replicaNodesField,
                        isrNodesField,
                        offlineReplicasField,
                        taggedFields
                    ));
                }
                public static int WriteV6(byte[] buffer, int index, MetadataResponsePartition message)
                {
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.LeaderIdField);
                    index = BinaryEncoder.WriteArray<int>(buffer, index, message.ReplicaNodesField, BinaryEncoder.WriteInt32);
                    index = BinaryEncoder.WriteArray<int>(buffer, index, message.IsrNodesField, BinaryEncoder.WriteInt32);
                    index = BinaryEncoder.WriteArray<int>(buffer, index, message.OfflineReplicasField, BinaryEncoder.WriteInt32);
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
                public static (int Offset, MetadataResponsePartition Value) ReadV6(byte[] buffer, int index)
                {
                    var errorCodeField = default(short);
                    var partitionIndexField = default(int);
                    var leaderIdField = default(int);
                    var leaderEpochField = default(int);
                    var replicaNodesField = ImmutableArray<int>.Empty;
                    var isrNodesField = ImmutableArray<int>.Empty;
                    var offlineReplicasField = ImmutableArray<int>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, leaderIdField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, var _replicaNodesField_) = BinaryDecoder.ReadArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                    if (_replicaNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    else
                        replicaNodesField = _replicaNodesField_.Value;
                    (index, var _isrNodesField_) = BinaryDecoder.ReadArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                    if (_isrNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    else
                        isrNodesField = _isrNodesField_.Value;
                    (index, var _offlineReplicasField_) = BinaryDecoder.ReadArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                    if (_offlineReplicasField_ == null)
                        throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                    else
                        offlineReplicasField = _offlineReplicasField_.Value;
                    return (index, new(
                        errorCodeField,
                        partitionIndexField,
                        leaderIdField,
                        leaderEpochField,
                        replicaNodesField,
                        isrNodesField,
                        offlineReplicasField,
                        taggedFields
                    ));
                }
                public static int WriteV7(byte[] buffer, int index, MetadataResponsePartition message)
                {
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.LeaderIdField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.LeaderEpochField);
                    index = BinaryEncoder.WriteArray<int>(buffer, index, message.ReplicaNodesField, BinaryEncoder.WriteInt32);
                    index = BinaryEncoder.WriteArray<int>(buffer, index, message.IsrNodesField, BinaryEncoder.WriteInt32);
                    index = BinaryEncoder.WriteArray<int>(buffer, index, message.OfflineReplicasField, BinaryEncoder.WriteInt32);
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
                public static (int Offset, MetadataResponsePartition Value) ReadV7(byte[] buffer, int index)
                {
                    var errorCodeField = default(short);
                    var partitionIndexField = default(int);
                    var leaderIdField = default(int);
                    var leaderEpochField = default(int);
                    var replicaNodesField = ImmutableArray<int>.Empty;
                    var isrNodesField = ImmutableArray<int>.Empty;
                    var offlineReplicasField = ImmutableArray<int>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, leaderIdField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, leaderEpochField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, var _replicaNodesField_) = BinaryDecoder.ReadArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                    if (_replicaNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    else
                        replicaNodesField = _replicaNodesField_.Value;
                    (index, var _isrNodesField_) = BinaryDecoder.ReadArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                    if (_isrNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    else
                        isrNodesField = _isrNodesField_.Value;
                    (index, var _offlineReplicasField_) = BinaryDecoder.ReadArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                    if (_offlineReplicasField_ == null)
                        throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                    else
                        offlineReplicasField = _offlineReplicasField_.Value;
                    return (index, new(
                        errorCodeField,
                        partitionIndexField,
                        leaderIdField,
                        leaderEpochField,
                        replicaNodesField,
                        isrNodesField,
                        offlineReplicasField,
                        taggedFields
                    ));
                }
                public static int WriteV8(byte[] buffer, int index, MetadataResponsePartition message)
                {
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.LeaderIdField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.LeaderEpochField);
                    index = BinaryEncoder.WriteArray<int>(buffer, index, message.ReplicaNodesField, BinaryEncoder.WriteInt32);
                    index = BinaryEncoder.WriteArray<int>(buffer, index, message.IsrNodesField, BinaryEncoder.WriteInt32);
                    index = BinaryEncoder.WriteArray<int>(buffer, index, message.OfflineReplicasField, BinaryEncoder.WriteInt32);
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
                public static (int Offset, MetadataResponsePartition Value) ReadV8(byte[] buffer, int index)
                {
                    var errorCodeField = default(short);
                    var partitionIndexField = default(int);
                    var leaderIdField = default(int);
                    var leaderEpochField = default(int);
                    var replicaNodesField = ImmutableArray<int>.Empty;
                    var isrNodesField = ImmutableArray<int>.Empty;
                    var offlineReplicasField = ImmutableArray<int>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, leaderIdField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, leaderEpochField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, var _replicaNodesField_) = BinaryDecoder.ReadArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                    if (_replicaNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    else
                        replicaNodesField = _replicaNodesField_.Value;
                    (index, var _isrNodesField_) = BinaryDecoder.ReadArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                    if (_isrNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    else
                        isrNodesField = _isrNodesField_.Value;
                    (index, var _offlineReplicasField_) = BinaryDecoder.ReadArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                    if (_offlineReplicasField_ == null)
                        throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                    else
                        offlineReplicasField = _offlineReplicasField_.Value;
                    return (index, new(
                        errorCodeField,
                        partitionIndexField,
                        leaderIdField,
                        leaderEpochField,
                        replicaNodesField,
                        isrNodesField,
                        offlineReplicasField,
                        taggedFields
                    ));
                }
                public static int WriteV9(byte[] buffer, int index, MetadataResponsePartition message)
                {
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.LeaderIdField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.LeaderEpochField);
                    index = BinaryEncoder.WriteCompactArray<int>(buffer, index, message.ReplicaNodesField, BinaryEncoder.WriteInt32);
                    index = BinaryEncoder.WriteCompactArray<int>(buffer, index, message.IsrNodesField, BinaryEncoder.WriteInt32);
                    index = BinaryEncoder.WriteCompactArray<int>(buffer, index, message.OfflineReplicasField, BinaryEncoder.WriteInt32);
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
                public static (int Offset, MetadataResponsePartition Value) ReadV9(byte[] buffer, int index)
                {
                    var errorCodeField = default(short);
                    var partitionIndexField = default(int);
                    var leaderIdField = default(int);
                    var leaderEpochField = default(int);
                    var replicaNodesField = ImmutableArray<int>.Empty;
                    var isrNodesField = ImmutableArray<int>.Empty;
                    var offlineReplicasField = ImmutableArray<int>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, leaderIdField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, leaderEpochField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, var _replicaNodesField_) = BinaryDecoder.ReadCompactArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                    if (_replicaNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    else
                        replicaNodesField = _replicaNodesField_.Value;
                    (index, var _isrNodesField_) = BinaryDecoder.ReadCompactArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                    if (_isrNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    else
                        isrNodesField = _isrNodesField_.Value;
                    (index, var _offlineReplicasField_) = BinaryDecoder.ReadCompactArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                    if (_offlineReplicasField_ == null)
                        throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                    else
                        offlineReplicasField = _offlineReplicasField_.Value;
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
                        errorCodeField,
                        partitionIndexField,
                        leaderIdField,
                        leaderEpochField,
                        replicaNodesField,
                        isrNodesField,
                        offlineReplicasField,
                        taggedFields
                    ));
                }
                public static int WriteV10(byte[] buffer, int index, MetadataResponsePartition message)
                {
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.LeaderIdField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.LeaderEpochField);
                    index = BinaryEncoder.WriteCompactArray<int>(buffer, index, message.ReplicaNodesField, BinaryEncoder.WriteInt32);
                    index = BinaryEncoder.WriteCompactArray<int>(buffer, index, message.IsrNodesField, BinaryEncoder.WriteInt32);
                    index = BinaryEncoder.WriteCompactArray<int>(buffer, index, message.OfflineReplicasField, BinaryEncoder.WriteInt32);
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
                public static (int Offset, MetadataResponsePartition Value) ReadV10(byte[] buffer, int index)
                {
                    var errorCodeField = default(short);
                    var partitionIndexField = default(int);
                    var leaderIdField = default(int);
                    var leaderEpochField = default(int);
                    var replicaNodesField = ImmutableArray<int>.Empty;
                    var isrNodesField = ImmutableArray<int>.Empty;
                    var offlineReplicasField = ImmutableArray<int>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, leaderIdField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, leaderEpochField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, var _replicaNodesField_) = BinaryDecoder.ReadCompactArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                    if (_replicaNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    else
                        replicaNodesField = _replicaNodesField_.Value;
                    (index, var _isrNodesField_) = BinaryDecoder.ReadCompactArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                    if (_isrNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    else
                        isrNodesField = _isrNodesField_.Value;
                    (index, var _offlineReplicasField_) = BinaryDecoder.ReadCompactArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                    if (_offlineReplicasField_ == null)
                        throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                    else
                        offlineReplicasField = _offlineReplicasField_.Value;
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
                        errorCodeField,
                        partitionIndexField,
                        leaderIdField,
                        leaderEpochField,
                        replicaNodesField,
                        isrNodesField,
                        offlineReplicasField,
                        taggedFields
                    ));
                }
                public static int WriteV11(byte[] buffer, int index, MetadataResponsePartition message)
                {
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.LeaderIdField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.LeaderEpochField);
                    index = BinaryEncoder.WriteCompactArray<int>(buffer, index, message.ReplicaNodesField, BinaryEncoder.WriteInt32);
                    index = BinaryEncoder.WriteCompactArray<int>(buffer, index, message.IsrNodesField, BinaryEncoder.WriteInt32);
                    index = BinaryEncoder.WriteCompactArray<int>(buffer, index, message.OfflineReplicasField, BinaryEncoder.WriteInt32);
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
                public static (int Offset, MetadataResponsePartition Value) ReadV11(byte[] buffer, int index)
                {
                    var errorCodeField = default(short);
                    var partitionIndexField = default(int);
                    var leaderIdField = default(int);
                    var leaderEpochField = default(int);
                    var replicaNodesField = ImmutableArray<int>.Empty;
                    var isrNodesField = ImmutableArray<int>.Empty;
                    var offlineReplicasField = ImmutableArray<int>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, leaderIdField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, leaderEpochField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, var _replicaNodesField_) = BinaryDecoder.ReadCompactArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                    if (_replicaNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    else
                        replicaNodesField = _replicaNodesField_.Value;
                    (index, var _isrNodesField_) = BinaryDecoder.ReadCompactArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                    if (_isrNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    else
                        isrNodesField = _isrNodesField_.Value;
                    (index, var _offlineReplicasField_) = BinaryDecoder.ReadCompactArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                    if (_offlineReplicasField_ == null)
                        throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                    else
                        offlineReplicasField = _offlineReplicasField_.Value;
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
                        errorCodeField,
                        partitionIndexField,
                        leaderIdField,
                        leaderEpochField,
                        replicaNodesField,
                        isrNodesField,
                        offlineReplicasField,
                        taggedFields
                    ));
                }
                public static int WriteV12(byte[] buffer, int index, MetadataResponsePartition message)
                {
                    index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.PartitionIndexField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.LeaderIdField);
                    index = BinaryEncoder.WriteInt32(buffer, index, message.LeaderEpochField);
                    index = BinaryEncoder.WriteCompactArray<int>(buffer, index, message.ReplicaNodesField, BinaryEncoder.WriteInt32);
                    index = BinaryEncoder.WriteCompactArray<int>(buffer, index, message.IsrNodesField, BinaryEncoder.WriteInt32);
                    index = BinaryEncoder.WriteCompactArray<int>(buffer, index, message.OfflineReplicasField, BinaryEncoder.WriteInt32);
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
                public static (int Offset, MetadataResponsePartition Value) ReadV12(byte[] buffer, int index)
                {
                    var errorCodeField = default(short);
                    var partitionIndexField = default(int);
                    var leaderIdField = default(int);
                    var leaderEpochField = default(int);
                    var replicaNodesField = ImmutableArray<int>.Empty;
                    var isrNodesField = ImmutableArray<int>.Empty;
                    var offlineReplicasField = ImmutableArray<int>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, leaderIdField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, leaderEpochField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, var _replicaNodesField_) = BinaryDecoder.ReadCompactArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                    if (_replicaNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    else
                        replicaNodesField = _replicaNodesField_.Value;
                    (index, var _isrNodesField_) = BinaryDecoder.ReadCompactArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                    if (_isrNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    else
                        isrNodesField = _isrNodesField_.Value;
                    (index, var _offlineReplicasField_) = BinaryDecoder.ReadCompactArray<int>(buffer, index, BinaryDecoder.ReadInt32);
                    if (_offlineReplicasField_ == null)
                        throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                    else
                        offlineReplicasField = _offlineReplicasField_.Value;
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
                        errorCodeField,
                        partitionIndexField,
                        leaderIdField,
                        leaderEpochField,
                        replicaNodesField,
                        isrNodesField,
                        offlineReplicasField,
                        taggedFields
                    ));
                }
            }
        }
    }
}