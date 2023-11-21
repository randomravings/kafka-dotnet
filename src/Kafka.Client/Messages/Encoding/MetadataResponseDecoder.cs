using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using MetadataResponseTopic = Kafka.Client.Messages.MetadataResponseData.MetadataResponseTopic;
using MetadataResponsePartition = Kafka.Client.Messages.MetadataResponseData.MetadataResponseTopic.MetadataResponsePartition;
using MetadataResponseBroker = Kafka.Client.Messages.MetadataResponseData.MetadataResponseBroker;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    public class MetadataResponseDecoder : 
        ResponseDecoder<ResponseHeaderData, MetadataResponseData>
    {
        public MetadataResponseDecoder() :
            base(
                ApiKey.Metadata,
                new(0, 12),
                new(9, 32767),
                ResponseHeaderDecoder.ReadV0,
                ReadV0
            )
        { }
        protected override DecodeDelegate<ResponseHeaderData> GetHeaderDecoder(short apiVersion)
        {
            if (_flexibleVersions.Includes(apiVersion))
                return ResponseHeaderDecoder.ReadV1;
            else
                return ResponseHeaderDecoder.ReadV0;
        }
        protected override DecodeDelegate<MetadataResponseData> GetMessageDecoder(short apiVersion) =>
            apiVersion switch
            {
                0 => ReadV0,
                1 => ReadV1,
                2 => ReadV2,
                3 => ReadV3,
                4 => ReadV4,
                5 => ReadV5,
                6 => ReadV6,
                7 => ReadV7,
                8 => ReadV8,
                9 => ReadV9,
                10 => ReadV10,
                11 => ReadV11,
                12 => ReadV12,
                _ => throw new NotSupportedException()
            }
        ;
        private static DecodeResult<MetadataResponseData> ReadV0(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var brokersField = ImmutableArray<MetadataResponseBroker>.Empty;
            var clusterIdField = default(string?);
            var controllerIdField = default(int);
            var topicsField = ImmutableArray<MetadataResponseTopic>.Empty;
            var clusterAuthorizedOperationsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _brokersField_) = BinaryDecoder.ReadArray<MetadataResponseBroker>(buffer, index, MetadataResponseBrokerDecoder.ReadV0);
            if (_brokersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Brokers'");
            else
                brokersField = _brokersField_.Value;
            (index, var _topicsField_) = BinaryDecoder.ReadArray<MetadataResponseTopic>(buffer, index, MetadataResponseTopicDecoder.ReadV0);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return new(index, new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static DecodeResult<MetadataResponseData> ReadV1(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var brokersField = ImmutableArray<MetadataResponseBroker>.Empty;
            var clusterIdField = default(string?);
            var controllerIdField = default(int);
            var topicsField = ImmutableArray<MetadataResponseTopic>.Empty;
            var clusterAuthorizedOperationsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _brokersField_) = BinaryDecoder.ReadArray<MetadataResponseBroker>(buffer, index, MetadataResponseBrokerDecoder.ReadV1);
            if (_brokersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Brokers'");
            else
                brokersField = _brokersField_.Value;
            (index, controllerIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<MetadataResponseTopic>(buffer, index, MetadataResponseTopicDecoder.ReadV1);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return new(index, new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static DecodeResult<MetadataResponseData> ReadV2(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var brokersField = ImmutableArray<MetadataResponseBroker>.Empty;
            var clusterIdField = default(string?);
            var controllerIdField = default(int);
            var topicsField = ImmutableArray<MetadataResponseTopic>.Empty;
            var clusterAuthorizedOperationsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _brokersField_) = BinaryDecoder.ReadArray<MetadataResponseBroker>(buffer, index, MetadataResponseBrokerDecoder.ReadV2);
            if (_brokersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Brokers'");
            else
                brokersField = _brokersField_.Value;
            (index, clusterIdField) = BinaryDecoder.ReadNullableString(buffer, index);
            (index, controllerIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<MetadataResponseTopic>(buffer, index, MetadataResponseTopicDecoder.ReadV2);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return new(index, new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static DecodeResult<MetadataResponseData> ReadV3(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var brokersField = ImmutableArray<MetadataResponseBroker>.Empty;
            var clusterIdField = default(string?);
            var controllerIdField = default(int);
            var topicsField = ImmutableArray<MetadataResponseTopic>.Empty;
            var clusterAuthorizedOperationsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _brokersField_) = BinaryDecoder.ReadArray<MetadataResponseBroker>(buffer, index, MetadataResponseBrokerDecoder.ReadV3);
            if (_brokersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Brokers'");
            else
                brokersField = _brokersField_.Value;
            (index, clusterIdField) = BinaryDecoder.ReadNullableString(buffer, index);
            (index, controllerIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<MetadataResponseTopic>(buffer, index, MetadataResponseTopicDecoder.ReadV3);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return new(index, new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static DecodeResult<MetadataResponseData> ReadV4(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var brokersField = ImmutableArray<MetadataResponseBroker>.Empty;
            var clusterIdField = default(string?);
            var controllerIdField = default(int);
            var topicsField = ImmutableArray<MetadataResponseTopic>.Empty;
            var clusterAuthorizedOperationsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _brokersField_) = BinaryDecoder.ReadArray<MetadataResponseBroker>(buffer, index, MetadataResponseBrokerDecoder.ReadV4);
            if (_brokersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Brokers'");
            else
                brokersField = _brokersField_.Value;
            (index, clusterIdField) = BinaryDecoder.ReadNullableString(buffer, index);
            (index, controllerIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<MetadataResponseTopic>(buffer, index, MetadataResponseTopicDecoder.ReadV4);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return new(index, new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static DecodeResult<MetadataResponseData> ReadV5(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var brokersField = ImmutableArray<MetadataResponseBroker>.Empty;
            var clusterIdField = default(string?);
            var controllerIdField = default(int);
            var topicsField = ImmutableArray<MetadataResponseTopic>.Empty;
            var clusterAuthorizedOperationsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _brokersField_) = BinaryDecoder.ReadArray<MetadataResponseBroker>(buffer, index, MetadataResponseBrokerDecoder.ReadV5);
            if (_brokersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Brokers'");
            else
                brokersField = _brokersField_.Value;
            (index, clusterIdField) = BinaryDecoder.ReadNullableString(buffer, index);
            (index, controllerIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<MetadataResponseTopic>(buffer, index, MetadataResponseTopicDecoder.ReadV5);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return new(index, new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static DecodeResult<MetadataResponseData> ReadV6(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var brokersField = ImmutableArray<MetadataResponseBroker>.Empty;
            var clusterIdField = default(string?);
            var controllerIdField = default(int);
            var topicsField = ImmutableArray<MetadataResponseTopic>.Empty;
            var clusterAuthorizedOperationsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _brokersField_) = BinaryDecoder.ReadArray<MetadataResponseBroker>(buffer, index, MetadataResponseBrokerDecoder.ReadV6);
            if (_brokersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Brokers'");
            else
                brokersField = _brokersField_.Value;
            (index, clusterIdField) = BinaryDecoder.ReadNullableString(buffer, index);
            (index, controllerIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<MetadataResponseTopic>(buffer, index, MetadataResponseTopicDecoder.ReadV6);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return new(index, new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static DecodeResult<MetadataResponseData> ReadV7(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var brokersField = ImmutableArray<MetadataResponseBroker>.Empty;
            var clusterIdField = default(string?);
            var controllerIdField = default(int);
            var topicsField = ImmutableArray<MetadataResponseTopic>.Empty;
            var clusterAuthorizedOperationsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _brokersField_) = BinaryDecoder.ReadArray<MetadataResponseBroker>(buffer, index, MetadataResponseBrokerDecoder.ReadV7);
            if (_brokersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Brokers'");
            else
                brokersField = _brokersField_.Value;
            (index, clusterIdField) = BinaryDecoder.ReadNullableString(buffer, index);
            (index, controllerIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<MetadataResponseTopic>(buffer, index, MetadataResponseTopicDecoder.ReadV7);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return new(index, new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static DecodeResult<MetadataResponseData> ReadV8(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var brokersField = ImmutableArray<MetadataResponseBroker>.Empty;
            var clusterIdField = default(string?);
            var controllerIdField = default(int);
            var topicsField = ImmutableArray<MetadataResponseTopic>.Empty;
            var clusterAuthorizedOperationsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _brokersField_) = BinaryDecoder.ReadArray<MetadataResponseBroker>(buffer, index, MetadataResponseBrokerDecoder.ReadV8);
            if (_brokersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Brokers'");
            else
                brokersField = _brokersField_.Value;
            (index, clusterIdField) = BinaryDecoder.ReadNullableString(buffer, index);
            (index, controllerIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<MetadataResponseTopic>(buffer, index, MetadataResponseTopicDecoder.ReadV8);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (index, clusterAuthorizedOperationsField) = BinaryDecoder.ReadInt32(buffer, index);
            return new(index, new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static DecodeResult<MetadataResponseData> ReadV9(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var brokersField = ImmutableArray<MetadataResponseBroker>.Empty;
            var clusterIdField = default(string?);
            var controllerIdField = default(int);
            var topicsField = ImmutableArray<MetadataResponseTopic>.Empty;
            var clusterAuthorizedOperationsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _brokersField_) = BinaryDecoder.ReadCompactArray<MetadataResponseBroker>(buffer, index, MetadataResponseBrokerDecoder.ReadV9);
            if (_brokersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Brokers'");
            else
                brokersField = _brokersField_.Value;
            (index, clusterIdField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
            (index, controllerIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadCompactArray<MetadataResponseTopic>(buffer, index, MetadataResponseTopicDecoder.ReadV9);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (index, clusterAuthorizedOperationsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
            if (taggedFieldsCount > 0)
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
            return new(index, new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static DecodeResult<MetadataResponseData> ReadV10(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var brokersField = ImmutableArray<MetadataResponseBroker>.Empty;
            var clusterIdField = default(string?);
            var controllerIdField = default(int);
            var topicsField = ImmutableArray<MetadataResponseTopic>.Empty;
            var clusterAuthorizedOperationsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _brokersField_) = BinaryDecoder.ReadCompactArray<MetadataResponseBroker>(buffer, index, MetadataResponseBrokerDecoder.ReadV10);
            if (_brokersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Brokers'");
            else
                brokersField = _brokersField_.Value;
            (index, clusterIdField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
            (index, controllerIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadCompactArray<MetadataResponseTopic>(buffer, index, MetadataResponseTopicDecoder.ReadV10);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (index, clusterAuthorizedOperationsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
            if (taggedFieldsCount > 0)
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
            return new(index, new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static DecodeResult<MetadataResponseData> ReadV11(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var brokersField = ImmutableArray<MetadataResponseBroker>.Empty;
            var clusterIdField = default(string?);
            var controllerIdField = default(int);
            var topicsField = ImmutableArray<MetadataResponseTopic>.Empty;
            var clusterAuthorizedOperationsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _brokersField_) = BinaryDecoder.ReadCompactArray<MetadataResponseBroker>(buffer, index, MetadataResponseBrokerDecoder.ReadV11);
            if (_brokersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Brokers'");
            else
                brokersField = _brokersField_.Value;
            (index, clusterIdField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
            (index, controllerIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadCompactArray<MetadataResponseTopic>(buffer, index, MetadataResponseTopicDecoder.ReadV11);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
            if (taggedFieldsCount > 0)
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
            return new(index, new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static DecodeResult<MetadataResponseData> ReadV12(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var brokersField = ImmutableArray<MetadataResponseBroker>.Empty;
            var clusterIdField = default(string?);
            var controllerIdField = default(int);
            var topicsField = ImmutableArray<MetadataResponseTopic>.Empty;
            var clusterAuthorizedOperationsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _brokersField_) = BinaryDecoder.ReadCompactArray<MetadataResponseBroker>(buffer, index, MetadataResponseBrokerDecoder.ReadV12);
            if (_brokersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Brokers'");
            else
                brokersField = _brokersField_.Value;
            (index, clusterIdField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
            (index, controllerIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadCompactArray<MetadataResponseTopic>(buffer, index, MetadataResponseTopicDecoder.ReadV12);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
            if (taggedFieldsCount > 0)
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
            return new(index, new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField,
                taggedFields
            ));
        }
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class MetadataResponseBrokerDecoder
        {
            public static DecodeResult<MetadataResponseBroker> ReadV0(byte[] buffer, int index)
            {
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nodeIdField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, hostField) = BinaryDecoder.ReadString(buffer, index);
                (index, portField) = BinaryDecoder.ReadInt32(buffer, index);
                return new(index, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseBroker> ReadV1(byte[] buffer, int index)
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
                return new(index, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseBroker> ReadV2(byte[] buffer, int index)
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
                return new(index, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseBroker> ReadV3(byte[] buffer, int index)
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
                return new(index, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseBroker> ReadV4(byte[] buffer, int index)
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
                return new(index, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseBroker> ReadV5(byte[] buffer, int index)
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
                return new(index, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseBroker> ReadV6(byte[] buffer, int index)
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
                return new(index, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseBroker> ReadV7(byte[] buffer, int index)
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
                return new(index, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseBroker> ReadV8(byte[] buffer, int index)
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
                return new(index, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseBroker> ReadV9(byte[] buffer, int index)
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
                if (taggedFieldsCount > 0)
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
                return new(index, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseBroker> ReadV10(byte[] buffer, int index)
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
                if (taggedFieldsCount > 0)
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
                return new(index, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseBroker> ReadV11(byte[] buffer, int index)
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
                if (taggedFieldsCount > 0)
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
                return new(index, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseBroker> ReadV12(byte[] buffer, int index)
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
                if (taggedFieldsCount > 0)
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
                return new(index, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
        }
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class MetadataResponseTopicDecoder
        {
            public static DecodeResult<MetadataResponseTopic> ReadV0(byte[] buffer, int index)
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
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<MetadataResponsePartition>(buffer, index, MetadataResponsePartitionDecoder.ReadV0);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return new(index, new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseTopic> ReadV1(byte[] buffer, int index)
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
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<MetadataResponsePartition>(buffer, index, MetadataResponsePartitionDecoder.ReadV1);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return new(index, new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseTopic> ReadV2(byte[] buffer, int index)
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
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<MetadataResponsePartition>(buffer, index, MetadataResponsePartitionDecoder.ReadV2);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return new(index, new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseTopic> ReadV3(byte[] buffer, int index)
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
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<MetadataResponsePartition>(buffer, index, MetadataResponsePartitionDecoder.ReadV3);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return new(index, new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseTopic> ReadV4(byte[] buffer, int index)
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
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<MetadataResponsePartition>(buffer, index, MetadataResponsePartitionDecoder.ReadV4);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return new(index, new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseTopic> ReadV5(byte[] buffer, int index)
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
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<MetadataResponsePartition>(buffer, index, MetadataResponsePartitionDecoder.ReadV5);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return new(index, new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseTopic> ReadV6(byte[] buffer, int index)
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
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<MetadataResponsePartition>(buffer, index, MetadataResponsePartitionDecoder.ReadV6);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return new(index, new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseTopic> ReadV7(byte[] buffer, int index)
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
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<MetadataResponsePartition>(buffer, index, MetadataResponsePartitionDecoder.ReadV7);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return new(index, new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseTopic> ReadV8(byte[] buffer, int index)
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
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<MetadataResponsePartition>(buffer, index, MetadataResponsePartitionDecoder.ReadV8);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                (index, topicAuthorizedOperationsField) = BinaryDecoder.ReadInt32(buffer, index);
                return new(index, new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseTopic> ReadV9(byte[] buffer, int index)
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
                (index, var _partitionsField_) = BinaryDecoder.ReadCompactArray<MetadataResponsePartition>(buffer, index, MetadataResponsePartitionDecoder.ReadV9);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                (index, topicAuthorizedOperationsField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
                if (taggedFieldsCount > 0)
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
                return new(index, new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseTopic> ReadV10(byte[] buffer, int index)
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
                (index, var _partitionsField_) = BinaryDecoder.ReadCompactArray<MetadataResponsePartition>(buffer, index, MetadataResponsePartitionDecoder.ReadV10);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                (index, topicAuthorizedOperationsField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
                if (taggedFieldsCount > 0)
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
                return new(index, new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseTopic> ReadV11(byte[] buffer, int index)
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
                (index, var _partitionsField_) = BinaryDecoder.ReadCompactArray<MetadataResponsePartition>(buffer, index, MetadataResponsePartitionDecoder.ReadV11);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                (index, topicAuthorizedOperationsField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
                if (taggedFieldsCount > 0)
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
                return new(index, new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseTopic> ReadV12(byte[] buffer, int index)
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
                (index, var _partitionsField_) = BinaryDecoder.ReadCompactArray<MetadataResponsePartition>(buffer, index, MetadataResponsePartitionDecoder.ReadV12);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                (index, topicAuthorizedOperationsField) = BinaryDecoder.ReadInt32(buffer, index);
                (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
                if (taggedFieldsCount > 0)
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
                return new(index, new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField,
                    taggedFields
                ));
            }
            [GeneratedCodeAttribute("kgen", "1.0.0.0")]
            private static class MetadataResponsePartitionDecoder
            {
                public static DecodeResult<MetadataResponsePartition> ReadV0(byte[] buffer, int index)
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
                    return new(index, new(
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
                public static DecodeResult<MetadataResponsePartition> ReadV1(byte[] buffer, int index)
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
                    return new(index, new(
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
                public static DecodeResult<MetadataResponsePartition> ReadV2(byte[] buffer, int index)
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
                    return new(index, new(
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
                public static DecodeResult<MetadataResponsePartition> ReadV3(byte[] buffer, int index)
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
                    return new(index, new(
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
                public static DecodeResult<MetadataResponsePartition> ReadV4(byte[] buffer, int index)
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
                    return new(index, new(
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
                public static DecodeResult<MetadataResponsePartition> ReadV5(byte[] buffer, int index)
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
                    return new(index, new(
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
                public static DecodeResult<MetadataResponsePartition> ReadV6(byte[] buffer, int index)
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
                    return new(index, new(
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
                public static DecodeResult<MetadataResponsePartition> ReadV7(byte[] buffer, int index)
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
                    return new(index, new(
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
                public static DecodeResult<MetadataResponsePartition> ReadV8(byte[] buffer, int index)
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
                    return new(index, new(
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
                public static DecodeResult<MetadataResponsePartition> ReadV9(byte[] buffer, int index)
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
                    if (taggedFieldsCount > 0)
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
                    return new(index, new(
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
                public static DecodeResult<MetadataResponsePartition> ReadV10(byte[] buffer, int index)
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
                    if (taggedFieldsCount > 0)
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
                    return new(index, new(
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
                public static DecodeResult<MetadataResponsePartition> ReadV11(byte[] buffer, int index)
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
                    if (taggedFieldsCount > 0)
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
                    return new(index, new(
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
                public static DecodeResult<MetadataResponsePartition> ReadV12(byte[] buffer, int index)
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
                    if (taggedFieldsCount > 0)
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
                    return new(index, new(
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
