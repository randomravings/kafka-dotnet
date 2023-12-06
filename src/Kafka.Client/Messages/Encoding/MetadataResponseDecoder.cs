using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using MetadataResponseBroker = Kafka.Client.Messages.MetadataResponseData.MetadataResponseBroker;
using MetadataResponseTopic = Kafka.Client.Messages.MetadataResponseData.MetadataResponseTopic;
using MetadataResponsePartition = Kafka.Client.Messages.MetadataResponseData.MetadataResponseTopic.MetadataResponsePartition;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    internal class MetadataResponseDecoder : 
        ResponseDecoder<ResponseHeaderData, MetadataResponseData>
    {
        internal MetadataResponseDecoder() :
            base(
                ApiKey.Metadata,
                new(0, 12),
                new(9, 32767),
                ResponseHeaderDecoder.ReadV0,
                ReadV0
            )
        { }
        protected override DecodeValue<ResponseHeaderData> GetHeaderDecoder(short apiVersion)
        {
            if (FlexibleVersions.Includes(apiVersion))
                return ResponseHeaderDecoder.ReadV1;
            else
                return ResponseHeaderDecoder.ReadV0;
        }
        protected override DecodeValue<MetadataResponseData> GetMessageDecoder(short apiVersion) =>
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
        private static DecodeResult<MetadataResponseData> ReadV0([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var brokersField = ImmutableArray<MetadataResponseBroker>.Empty;
            var clusterIdField = default(string?);
            var controllerIdField = default(int);
            var topicsField = ImmutableArray<MetadataResponseTopic>.Empty;
            var clusterAuthorizedOperationsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, var _brokersField_) = BinaryDecoder.ReadArray<MetadataResponseBroker>(buffer, i, MetadataResponseBrokerDecoder.ReadV0);
            if (_brokersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Brokers'");
            else
                brokersField = _brokersField_.Value;
            (i, var _topicsField_) = BinaryDecoder.ReadArray<MetadataResponseTopic>(buffer, i, MetadataResponseTopicDecoder.ReadV0);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return new(i, new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static DecodeResult<MetadataResponseData> ReadV1([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var brokersField = ImmutableArray<MetadataResponseBroker>.Empty;
            var clusterIdField = default(string?);
            var controllerIdField = default(int);
            var topicsField = ImmutableArray<MetadataResponseTopic>.Empty;
            var clusterAuthorizedOperationsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, var _brokersField_) = BinaryDecoder.ReadArray<MetadataResponseBroker>(buffer, i, MetadataResponseBrokerDecoder.ReadV1);
            if (_brokersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Brokers'");
            else
                brokersField = _brokersField_.Value;
            (i, controllerIdField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var _topicsField_) = BinaryDecoder.ReadArray<MetadataResponseTopic>(buffer, i, MetadataResponseTopicDecoder.ReadV1);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return new(i, new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static DecodeResult<MetadataResponseData> ReadV2([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var brokersField = ImmutableArray<MetadataResponseBroker>.Empty;
            var clusterIdField = default(string?);
            var controllerIdField = default(int);
            var topicsField = ImmutableArray<MetadataResponseTopic>.Empty;
            var clusterAuthorizedOperationsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, var _brokersField_) = BinaryDecoder.ReadArray<MetadataResponseBroker>(buffer, i, MetadataResponseBrokerDecoder.ReadV2);
            if (_brokersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Brokers'");
            else
                brokersField = _brokersField_.Value;
            (i, clusterIdField) = BinaryDecoder.ReadNullableString(buffer, i);
            (i, controllerIdField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var _topicsField_) = BinaryDecoder.ReadArray<MetadataResponseTopic>(buffer, i, MetadataResponseTopicDecoder.ReadV2);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return new(i, new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static DecodeResult<MetadataResponseData> ReadV3([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var brokersField = ImmutableArray<MetadataResponseBroker>.Empty;
            var clusterIdField = default(string?);
            var controllerIdField = default(int);
            var topicsField = ImmutableArray<MetadataResponseTopic>.Empty;
            var clusterAuthorizedOperationsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var _brokersField_) = BinaryDecoder.ReadArray<MetadataResponseBroker>(buffer, i, MetadataResponseBrokerDecoder.ReadV3);
            if (_brokersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Brokers'");
            else
                brokersField = _brokersField_.Value;
            (i, clusterIdField) = BinaryDecoder.ReadNullableString(buffer, i);
            (i, controllerIdField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var _topicsField_) = BinaryDecoder.ReadArray<MetadataResponseTopic>(buffer, i, MetadataResponseTopicDecoder.ReadV3);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return new(i, new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static DecodeResult<MetadataResponseData> ReadV4([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var brokersField = ImmutableArray<MetadataResponseBroker>.Empty;
            var clusterIdField = default(string?);
            var controllerIdField = default(int);
            var topicsField = ImmutableArray<MetadataResponseTopic>.Empty;
            var clusterAuthorizedOperationsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var _brokersField_) = BinaryDecoder.ReadArray<MetadataResponseBroker>(buffer, i, MetadataResponseBrokerDecoder.ReadV4);
            if (_brokersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Brokers'");
            else
                brokersField = _brokersField_.Value;
            (i, clusterIdField) = BinaryDecoder.ReadNullableString(buffer, i);
            (i, controllerIdField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var _topicsField_) = BinaryDecoder.ReadArray<MetadataResponseTopic>(buffer, i, MetadataResponseTopicDecoder.ReadV4);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return new(i, new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static DecodeResult<MetadataResponseData> ReadV5([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var brokersField = ImmutableArray<MetadataResponseBroker>.Empty;
            var clusterIdField = default(string?);
            var controllerIdField = default(int);
            var topicsField = ImmutableArray<MetadataResponseTopic>.Empty;
            var clusterAuthorizedOperationsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var _brokersField_) = BinaryDecoder.ReadArray<MetadataResponseBroker>(buffer, i, MetadataResponseBrokerDecoder.ReadV5);
            if (_brokersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Brokers'");
            else
                brokersField = _brokersField_.Value;
            (i, clusterIdField) = BinaryDecoder.ReadNullableString(buffer, i);
            (i, controllerIdField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var _topicsField_) = BinaryDecoder.ReadArray<MetadataResponseTopic>(buffer, i, MetadataResponseTopicDecoder.ReadV5);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return new(i, new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static DecodeResult<MetadataResponseData> ReadV6([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var brokersField = ImmutableArray<MetadataResponseBroker>.Empty;
            var clusterIdField = default(string?);
            var controllerIdField = default(int);
            var topicsField = ImmutableArray<MetadataResponseTopic>.Empty;
            var clusterAuthorizedOperationsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var _brokersField_) = BinaryDecoder.ReadArray<MetadataResponseBroker>(buffer, i, MetadataResponseBrokerDecoder.ReadV6);
            if (_brokersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Brokers'");
            else
                brokersField = _brokersField_.Value;
            (i, clusterIdField) = BinaryDecoder.ReadNullableString(buffer, i);
            (i, controllerIdField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var _topicsField_) = BinaryDecoder.ReadArray<MetadataResponseTopic>(buffer, i, MetadataResponseTopicDecoder.ReadV6);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return new(i, new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static DecodeResult<MetadataResponseData> ReadV7([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var brokersField = ImmutableArray<MetadataResponseBroker>.Empty;
            var clusterIdField = default(string?);
            var controllerIdField = default(int);
            var topicsField = ImmutableArray<MetadataResponseTopic>.Empty;
            var clusterAuthorizedOperationsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var _brokersField_) = BinaryDecoder.ReadArray<MetadataResponseBroker>(buffer, i, MetadataResponseBrokerDecoder.ReadV7);
            if (_brokersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Brokers'");
            else
                brokersField = _brokersField_.Value;
            (i, clusterIdField) = BinaryDecoder.ReadNullableString(buffer, i);
            (i, controllerIdField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var _topicsField_) = BinaryDecoder.ReadArray<MetadataResponseTopic>(buffer, i, MetadataResponseTopicDecoder.ReadV7);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return new(i, new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static DecodeResult<MetadataResponseData> ReadV8([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var brokersField = ImmutableArray<MetadataResponseBroker>.Empty;
            var clusterIdField = default(string?);
            var controllerIdField = default(int);
            var topicsField = ImmutableArray<MetadataResponseTopic>.Empty;
            var clusterAuthorizedOperationsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var _brokersField_) = BinaryDecoder.ReadArray<MetadataResponseBroker>(buffer, i, MetadataResponseBrokerDecoder.ReadV8);
            if (_brokersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Brokers'");
            else
                brokersField = _brokersField_.Value;
            (i, clusterIdField) = BinaryDecoder.ReadNullableString(buffer, i);
            (i, controllerIdField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var _topicsField_) = BinaryDecoder.ReadArray<MetadataResponseTopic>(buffer, i, MetadataResponseTopicDecoder.ReadV8);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (i, clusterAuthorizedOperationsField) = BinaryDecoder.ReadInt32(buffer, i);
            return new(i, new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static DecodeResult<MetadataResponseData> ReadV9([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var brokersField = ImmutableArray<MetadataResponseBroker>.Empty;
            var clusterIdField = default(string?);
            var controllerIdField = default(int);
            var topicsField = ImmutableArray<MetadataResponseTopic>.Empty;
            var clusterAuthorizedOperationsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var _brokersField_) = BinaryDecoder.ReadCompactArray<MetadataResponseBroker>(buffer, i, MetadataResponseBrokerDecoder.ReadV9);
            if (_brokersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Brokers'");
            else
                brokersField = _brokersField_.Value;
            (i, clusterIdField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
            (i, controllerIdField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var _topicsField_) = BinaryDecoder.ReadCompactArray<MetadataResponseTopic>(buffer, i, MetadataResponseTopicDecoder.ReadV9);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (i, clusterAuthorizedOperationsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, i);
            if (taggedFieldsCount > 0)
            {
                var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                while (taggedFieldsCount > 0)
                {
                    (i, var tag) = BinaryDecoder.ReadVarInt32(buffer, i);
                    (i, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, i);
                    taggedFieldsBuilder.Add(new(tag, bytes));
                    taggedFieldsCount--;
                }
            }
            return new(i, new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static DecodeResult<MetadataResponseData> ReadV10([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var brokersField = ImmutableArray<MetadataResponseBroker>.Empty;
            var clusterIdField = default(string?);
            var controllerIdField = default(int);
            var topicsField = ImmutableArray<MetadataResponseTopic>.Empty;
            var clusterAuthorizedOperationsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var _brokersField_) = BinaryDecoder.ReadCompactArray<MetadataResponseBroker>(buffer, i, MetadataResponseBrokerDecoder.ReadV10);
            if (_brokersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Brokers'");
            else
                brokersField = _brokersField_.Value;
            (i, clusterIdField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
            (i, controllerIdField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var _topicsField_) = BinaryDecoder.ReadCompactArray<MetadataResponseTopic>(buffer, i, MetadataResponseTopicDecoder.ReadV10);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (i, clusterAuthorizedOperationsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, i);
            if (taggedFieldsCount > 0)
            {
                var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                while (taggedFieldsCount > 0)
                {
                    (i, var tag) = BinaryDecoder.ReadVarInt32(buffer, i);
                    (i, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, i);
                    taggedFieldsBuilder.Add(new(tag, bytes));
                    taggedFieldsCount--;
                }
            }
            return new(i, new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static DecodeResult<MetadataResponseData> ReadV11([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var brokersField = ImmutableArray<MetadataResponseBroker>.Empty;
            var clusterIdField = default(string?);
            var controllerIdField = default(int);
            var topicsField = ImmutableArray<MetadataResponseTopic>.Empty;
            var clusterAuthorizedOperationsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var _brokersField_) = BinaryDecoder.ReadCompactArray<MetadataResponseBroker>(buffer, i, MetadataResponseBrokerDecoder.ReadV11);
            if (_brokersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Brokers'");
            else
                brokersField = _brokersField_.Value;
            (i, clusterIdField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
            (i, controllerIdField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var _topicsField_) = BinaryDecoder.ReadCompactArray<MetadataResponseTopic>(buffer, i, MetadataResponseTopicDecoder.ReadV11);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (i, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, i);
            if (taggedFieldsCount > 0)
            {
                var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                while (taggedFieldsCount > 0)
                {
                    (i, var tag) = BinaryDecoder.ReadVarInt32(buffer, i);
                    (i, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, i);
                    taggedFieldsBuilder.Add(new(tag, bytes));
                    taggedFieldsCount--;
                }
            }
            return new(i, new(
                throttleTimeMsField,
                brokersField,
                clusterIdField,
                controllerIdField,
                topicsField,
                clusterAuthorizedOperationsField,
                taggedFields
            ));
        }
        private static DecodeResult<MetadataResponseData> ReadV12([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var brokersField = ImmutableArray<MetadataResponseBroker>.Empty;
            var clusterIdField = default(string?);
            var controllerIdField = default(int);
            var topicsField = ImmutableArray<MetadataResponseTopic>.Empty;
            var clusterAuthorizedOperationsField = default(int);
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var _brokersField_) = BinaryDecoder.ReadCompactArray<MetadataResponseBroker>(buffer, i, MetadataResponseBrokerDecoder.ReadV12);
            if (_brokersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Brokers'");
            else
                brokersField = _brokersField_.Value;
            (i, clusterIdField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
            (i, controllerIdField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var _topicsField_) = BinaryDecoder.ReadCompactArray<MetadataResponseTopic>(buffer, i, MetadataResponseTopicDecoder.ReadV12);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (i, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, i);
            if (taggedFieldsCount > 0)
            {
                var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                while (taggedFieldsCount > 0)
                {
                    (i, var tag) = BinaryDecoder.ReadVarInt32(buffer, i);
                    (i, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, i);
                    taggedFieldsBuilder.Add(new(tag, bytes));
                    taggedFieldsCount--;
                }
            }
            return new(i, new(
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
            public static DecodeResult<MetadataResponseBroker> ReadV0([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nodeIdField) = BinaryDecoder.ReadInt32(buffer, i);
                (i, hostField) = BinaryDecoder.ReadString(buffer, i);
                (i, portField) = BinaryDecoder.ReadInt32(buffer, i);
                return new(i, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseBroker> ReadV1([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nodeIdField) = BinaryDecoder.ReadInt32(buffer, i);
                (i, hostField) = BinaryDecoder.ReadString(buffer, i);
                (i, portField) = BinaryDecoder.ReadInt32(buffer, i);
                (i, rackField) = BinaryDecoder.ReadNullableString(buffer, i);
                return new(i, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseBroker> ReadV2([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nodeIdField) = BinaryDecoder.ReadInt32(buffer, i);
                (i, hostField) = BinaryDecoder.ReadString(buffer, i);
                (i, portField) = BinaryDecoder.ReadInt32(buffer, i);
                (i, rackField) = BinaryDecoder.ReadNullableString(buffer, i);
                return new(i, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseBroker> ReadV3([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nodeIdField) = BinaryDecoder.ReadInt32(buffer, i);
                (i, hostField) = BinaryDecoder.ReadString(buffer, i);
                (i, portField) = BinaryDecoder.ReadInt32(buffer, i);
                (i, rackField) = BinaryDecoder.ReadNullableString(buffer, i);
                return new(i, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseBroker> ReadV4([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nodeIdField) = BinaryDecoder.ReadInt32(buffer, i);
                (i, hostField) = BinaryDecoder.ReadString(buffer, i);
                (i, portField) = BinaryDecoder.ReadInt32(buffer, i);
                (i, rackField) = BinaryDecoder.ReadNullableString(buffer, i);
                return new(i, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseBroker> ReadV5([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nodeIdField) = BinaryDecoder.ReadInt32(buffer, i);
                (i, hostField) = BinaryDecoder.ReadString(buffer, i);
                (i, portField) = BinaryDecoder.ReadInt32(buffer, i);
                (i, rackField) = BinaryDecoder.ReadNullableString(buffer, i);
                return new(i, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseBroker> ReadV6([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nodeIdField) = BinaryDecoder.ReadInt32(buffer, i);
                (i, hostField) = BinaryDecoder.ReadString(buffer, i);
                (i, portField) = BinaryDecoder.ReadInt32(buffer, i);
                (i, rackField) = BinaryDecoder.ReadNullableString(buffer, i);
                return new(i, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseBroker> ReadV7([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nodeIdField) = BinaryDecoder.ReadInt32(buffer, i);
                (i, hostField) = BinaryDecoder.ReadString(buffer, i);
                (i, portField) = BinaryDecoder.ReadInt32(buffer, i);
                (i, rackField) = BinaryDecoder.ReadNullableString(buffer, i);
                return new(i, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseBroker> ReadV8([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nodeIdField) = BinaryDecoder.ReadInt32(buffer, i);
                (i, hostField) = BinaryDecoder.ReadString(buffer, i);
                (i, portField) = BinaryDecoder.ReadInt32(buffer, i);
                (i, rackField) = BinaryDecoder.ReadNullableString(buffer, i);
                return new(i, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseBroker> ReadV9([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nodeIdField) = BinaryDecoder.ReadInt32(buffer, i);
                (i, hostField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, portField) = BinaryDecoder.ReadInt32(buffer, i);
                (i, rackField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
                (i, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, i);
                if (taggedFieldsCount > 0)
                {
                    var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                    while (taggedFieldsCount > 0)
                    {
                        (i, var tag) = BinaryDecoder.ReadVarInt32(buffer, i);
                        (i, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, i);
                        taggedFieldsBuilder.Add(new(tag, bytes));
                        taggedFieldsCount--;
                    }
                }
                return new(i, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseBroker> ReadV10([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nodeIdField) = BinaryDecoder.ReadInt32(buffer, i);
                (i, hostField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, portField) = BinaryDecoder.ReadInt32(buffer, i);
                (i, rackField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
                (i, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, i);
                if (taggedFieldsCount > 0)
                {
                    var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                    while (taggedFieldsCount > 0)
                    {
                        (i, var tag) = BinaryDecoder.ReadVarInt32(buffer, i);
                        (i, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, i);
                        taggedFieldsBuilder.Add(new(tag, bytes));
                        taggedFieldsCount--;
                    }
                }
                return new(i, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseBroker> ReadV11([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nodeIdField) = BinaryDecoder.ReadInt32(buffer, i);
                (i, hostField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, portField) = BinaryDecoder.ReadInt32(buffer, i);
                (i, rackField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
                (i, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, i);
                if (taggedFieldsCount > 0)
                {
                    var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                    while (taggedFieldsCount > 0)
                    {
                        (i, var tag) = BinaryDecoder.ReadVarInt32(buffer, i);
                        (i, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, i);
                        taggedFieldsBuilder.Add(new(tag, bytes));
                        taggedFieldsCount--;
                    }
                }
                return new(i, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseBroker> ReadV12([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nodeIdField) = BinaryDecoder.ReadInt32(buffer, i);
                (i, hostField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, portField) = BinaryDecoder.ReadInt32(buffer, i);
                (i, rackField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
                (i, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, i);
                if (taggedFieldsCount > 0)
                {
                    var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                    while (taggedFieldsCount > 0)
                    {
                        (i, var tag) = BinaryDecoder.ReadVarInt32(buffer, i);
                        (i, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, i);
                        taggedFieldsBuilder.Add(new(tag, bytes));
                        taggedFieldsCount--;
                    }
                }
                return new(i, new(
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
            public static DecodeResult<MetadataResponseTopic> ReadV0([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var errorCodeField = default(short);
                var nameField = default(string?);
                var topicIdField = default(Guid);
                var isInternalField = default(bool);
                var partitionsField = ImmutableArray<MetadataResponsePartition>.Empty;
                var topicAuthorizedOperationsField = default(int);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, var _partitionsField_) = BinaryDecoder.ReadArray<MetadataResponsePartition>(buffer, i, MetadataResponsePartitionDecoder.ReadV0);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return new(i, new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseTopic> ReadV1([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var errorCodeField = default(short);
                var nameField = default(string?);
                var topicIdField = default(Guid);
                var isInternalField = default(bool);
                var partitionsField = ImmutableArray<MetadataResponsePartition>.Empty;
                var topicAuthorizedOperationsField = default(int);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, isInternalField) = BinaryDecoder.ReadBoolean(buffer, i);
                (i, var _partitionsField_) = BinaryDecoder.ReadArray<MetadataResponsePartition>(buffer, i, MetadataResponsePartitionDecoder.ReadV1);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return new(i, new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseTopic> ReadV2([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var errorCodeField = default(short);
                var nameField = default(string?);
                var topicIdField = default(Guid);
                var isInternalField = default(bool);
                var partitionsField = ImmutableArray<MetadataResponsePartition>.Empty;
                var topicAuthorizedOperationsField = default(int);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, isInternalField) = BinaryDecoder.ReadBoolean(buffer, i);
                (i, var _partitionsField_) = BinaryDecoder.ReadArray<MetadataResponsePartition>(buffer, i, MetadataResponsePartitionDecoder.ReadV2);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return new(i, new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseTopic> ReadV3([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var errorCodeField = default(short);
                var nameField = default(string?);
                var topicIdField = default(Guid);
                var isInternalField = default(bool);
                var partitionsField = ImmutableArray<MetadataResponsePartition>.Empty;
                var topicAuthorizedOperationsField = default(int);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, isInternalField) = BinaryDecoder.ReadBoolean(buffer, i);
                (i, var _partitionsField_) = BinaryDecoder.ReadArray<MetadataResponsePartition>(buffer, i, MetadataResponsePartitionDecoder.ReadV3);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return new(i, new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseTopic> ReadV4([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var errorCodeField = default(short);
                var nameField = default(string?);
                var topicIdField = default(Guid);
                var isInternalField = default(bool);
                var partitionsField = ImmutableArray<MetadataResponsePartition>.Empty;
                var topicAuthorizedOperationsField = default(int);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, isInternalField) = BinaryDecoder.ReadBoolean(buffer, i);
                (i, var _partitionsField_) = BinaryDecoder.ReadArray<MetadataResponsePartition>(buffer, i, MetadataResponsePartitionDecoder.ReadV4);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return new(i, new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseTopic> ReadV5([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var errorCodeField = default(short);
                var nameField = default(string?);
                var topicIdField = default(Guid);
                var isInternalField = default(bool);
                var partitionsField = ImmutableArray<MetadataResponsePartition>.Empty;
                var topicAuthorizedOperationsField = default(int);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, isInternalField) = BinaryDecoder.ReadBoolean(buffer, i);
                (i, var _partitionsField_) = BinaryDecoder.ReadArray<MetadataResponsePartition>(buffer, i, MetadataResponsePartitionDecoder.ReadV5);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return new(i, new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseTopic> ReadV6([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var errorCodeField = default(short);
                var nameField = default(string?);
                var topicIdField = default(Guid);
                var isInternalField = default(bool);
                var partitionsField = ImmutableArray<MetadataResponsePartition>.Empty;
                var topicAuthorizedOperationsField = default(int);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, isInternalField) = BinaryDecoder.ReadBoolean(buffer, i);
                (i, var _partitionsField_) = BinaryDecoder.ReadArray<MetadataResponsePartition>(buffer, i, MetadataResponsePartitionDecoder.ReadV6);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return new(i, new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseTopic> ReadV7([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var errorCodeField = default(short);
                var nameField = default(string?);
                var topicIdField = default(Guid);
                var isInternalField = default(bool);
                var partitionsField = ImmutableArray<MetadataResponsePartition>.Empty;
                var topicAuthorizedOperationsField = default(int);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, isInternalField) = BinaryDecoder.ReadBoolean(buffer, i);
                (i, var _partitionsField_) = BinaryDecoder.ReadArray<MetadataResponsePartition>(buffer, i, MetadataResponsePartitionDecoder.ReadV7);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return new(i, new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseTopic> ReadV8([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var errorCodeField = default(short);
                var nameField = default(string?);
                var topicIdField = default(Guid);
                var isInternalField = default(bool);
                var partitionsField = ImmutableArray<MetadataResponsePartition>.Empty;
                var topicAuthorizedOperationsField = default(int);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, isInternalField) = BinaryDecoder.ReadBoolean(buffer, i);
                (i, var _partitionsField_) = BinaryDecoder.ReadArray<MetadataResponsePartition>(buffer, i, MetadataResponsePartitionDecoder.ReadV8);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                (i, topicAuthorizedOperationsField) = BinaryDecoder.ReadInt32(buffer, i);
                return new(i, new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseTopic> ReadV9([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var errorCodeField = default(short);
                var nameField = default(string?);
                var topicIdField = default(Guid);
                var isInternalField = default(bool);
                var partitionsField = ImmutableArray<MetadataResponsePartition>.Empty;
                var topicAuthorizedOperationsField = default(int);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, nameField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, isInternalField) = BinaryDecoder.ReadBoolean(buffer, i);
                (i, var _partitionsField_) = BinaryDecoder.ReadCompactArray<MetadataResponsePartition>(buffer, i, MetadataResponsePartitionDecoder.ReadV9);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                (i, topicAuthorizedOperationsField) = BinaryDecoder.ReadInt32(buffer, i);
                (i, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, i);
                if (taggedFieldsCount > 0)
                {
                    var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                    while (taggedFieldsCount > 0)
                    {
                        (i, var tag) = BinaryDecoder.ReadVarInt32(buffer, i);
                        (i, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, i);
                        taggedFieldsBuilder.Add(new(tag, bytes));
                        taggedFieldsCount--;
                    }
                }
                return new(i, new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseTopic> ReadV10([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var errorCodeField = default(short);
                var nameField = default(string?);
                var topicIdField = default(Guid);
                var isInternalField = default(bool);
                var partitionsField = ImmutableArray<MetadataResponsePartition>.Empty;
                var topicAuthorizedOperationsField = default(int);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, nameField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, topicIdField) = BinaryDecoder.ReadUuid(buffer, i);
                (i, isInternalField) = BinaryDecoder.ReadBoolean(buffer, i);
                (i, var _partitionsField_) = BinaryDecoder.ReadCompactArray<MetadataResponsePartition>(buffer, i, MetadataResponsePartitionDecoder.ReadV10);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                (i, topicAuthorizedOperationsField) = BinaryDecoder.ReadInt32(buffer, i);
                (i, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, i);
                if (taggedFieldsCount > 0)
                {
                    var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                    while (taggedFieldsCount > 0)
                    {
                        (i, var tag) = BinaryDecoder.ReadVarInt32(buffer, i);
                        (i, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, i);
                        taggedFieldsBuilder.Add(new(tag, bytes));
                        taggedFieldsCount--;
                    }
                }
                return new(i, new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseTopic> ReadV11([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var errorCodeField = default(short);
                var nameField = default(string?);
                var topicIdField = default(Guid);
                var isInternalField = default(bool);
                var partitionsField = ImmutableArray<MetadataResponsePartition>.Empty;
                var topicAuthorizedOperationsField = default(int);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, nameField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, topicIdField) = BinaryDecoder.ReadUuid(buffer, i);
                (i, isInternalField) = BinaryDecoder.ReadBoolean(buffer, i);
                (i, var _partitionsField_) = BinaryDecoder.ReadCompactArray<MetadataResponsePartition>(buffer, i, MetadataResponsePartitionDecoder.ReadV11);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                (i, topicAuthorizedOperationsField) = BinaryDecoder.ReadInt32(buffer, i);
                (i, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, i);
                if (taggedFieldsCount > 0)
                {
                    var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                    while (taggedFieldsCount > 0)
                    {
                        (i, var tag) = BinaryDecoder.ReadVarInt32(buffer, i);
                        (i, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, i);
                        taggedFieldsBuilder.Add(new(tag, bytes));
                        taggedFieldsCount--;
                    }
                }
                return new(i, new(
                    errorCodeField,
                    nameField,
                    topicIdField,
                    isInternalField,
                    partitionsField,
                    topicAuthorizedOperationsField,
                    taggedFields
                ));
            }
            public static DecodeResult<MetadataResponseTopic> ReadV12([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var errorCodeField = default(short);
                var nameField = default(string?);
                var topicIdField = default(Guid);
                var isInternalField = default(bool);
                var partitionsField = ImmutableArray<MetadataResponsePartition>.Empty;
                var topicAuthorizedOperationsField = default(int);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                (i, nameField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
                (i, topicIdField) = BinaryDecoder.ReadUuid(buffer, i);
                (i, isInternalField) = BinaryDecoder.ReadBoolean(buffer, i);
                (i, var _partitionsField_) = BinaryDecoder.ReadCompactArray<MetadataResponsePartition>(buffer, i, MetadataResponsePartitionDecoder.ReadV12);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                (i, topicAuthorizedOperationsField) = BinaryDecoder.ReadInt32(buffer, i);
                (i, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, i);
                if (taggedFieldsCount > 0)
                {
                    var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                    while (taggedFieldsCount > 0)
                    {
                        (i, var tag) = BinaryDecoder.ReadVarInt32(buffer, i);
                        (i, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, i);
                        taggedFieldsBuilder.Add(new(tag, bytes));
                        taggedFieldsCount--;
                    }
                }
                return new(i, new(
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
                public static DecodeResult<MetadataResponsePartition> ReadV0([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var errorCodeField = default(short);
                    var partitionIndexField = default(int);
                    var leaderIdField = default(int);
                    var leaderEpochField = default(int);
                    var replicaNodesField = ImmutableArray<int>.Empty;
                    var isrNodesField = ImmutableArray<int>.Empty;
                    var offlineReplicasField = ImmutableArray<int>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, leaderIdField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, var _replicaNodesField_) = BinaryDecoder.ReadArray<int>(buffer, i, BinaryDecoder.ReadInt32);
                    if (_replicaNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    else
                        replicaNodesField = _replicaNodesField_.Value;
                    (i, var _isrNodesField_) = BinaryDecoder.ReadArray<int>(buffer, i, BinaryDecoder.ReadInt32);
                    if (_isrNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    else
                        isrNodesField = _isrNodesField_.Value;
                    return new(i, new(
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
                public static DecodeResult<MetadataResponsePartition> ReadV1([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var errorCodeField = default(short);
                    var partitionIndexField = default(int);
                    var leaderIdField = default(int);
                    var leaderEpochField = default(int);
                    var replicaNodesField = ImmutableArray<int>.Empty;
                    var isrNodesField = ImmutableArray<int>.Empty;
                    var offlineReplicasField = ImmutableArray<int>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, leaderIdField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, var _replicaNodesField_) = BinaryDecoder.ReadArray<int>(buffer, i, BinaryDecoder.ReadInt32);
                    if (_replicaNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    else
                        replicaNodesField = _replicaNodesField_.Value;
                    (i, var _isrNodesField_) = BinaryDecoder.ReadArray<int>(buffer, i, BinaryDecoder.ReadInt32);
                    if (_isrNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    else
                        isrNodesField = _isrNodesField_.Value;
                    return new(i, new(
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
                public static DecodeResult<MetadataResponsePartition> ReadV2([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var errorCodeField = default(short);
                    var partitionIndexField = default(int);
                    var leaderIdField = default(int);
                    var leaderEpochField = default(int);
                    var replicaNodesField = ImmutableArray<int>.Empty;
                    var isrNodesField = ImmutableArray<int>.Empty;
                    var offlineReplicasField = ImmutableArray<int>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, leaderIdField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, var _replicaNodesField_) = BinaryDecoder.ReadArray<int>(buffer, i, BinaryDecoder.ReadInt32);
                    if (_replicaNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    else
                        replicaNodesField = _replicaNodesField_.Value;
                    (i, var _isrNodesField_) = BinaryDecoder.ReadArray<int>(buffer, i, BinaryDecoder.ReadInt32);
                    if (_isrNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    else
                        isrNodesField = _isrNodesField_.Value;
                    return new(i, new(
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
                public static DecodeResult<MetadataResponsePartition> ReadV3([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var errorCodeField = default(short);
                    var partitionIndexField = default(int);
                    var leaderIdField = default(int);
                    var leaderEpochField = default(int);
                    var replicaNodesField = ImmutableArray<int>.Empty;
                    var isrNodesField = ImmutableArray<int>.Empty;
                    var offlineReplicasField = ImmutableArray<int>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, leaderIdField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, var _replicaNodesField_) = BinaryDecoder.ReadArray<int>(buffer, i, BinaryDecoder.ReadInt32);
                    if (_replicaNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    else
                        replicaNodesField = _replicaNodesField_.Value;
                    (i, var _isrNodesField_) = BinaryDecoder.ReadArray<int>(buffer, i, BinaryDecoder.ReadInt32);
                    if (_isrNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    else
                        isrNodesField = _isrNodesField_.Value;
                    return new(i, new(
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
                public static DecodeResult<MetadataResponsePartition> ReadV4([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var errorCodeField = default(short);
                    var partitionIndexField = default(int);
                    var leaderIdField = default(int);
                    var leaderEpochField = default(int);
                    var replicaNodesField = ImmutableArray<int>.Empty;
                    var isrNodesField = ImmutableArray<int>.Empty;
                    var offlineReplicasField = ImmutableArray<int>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, leaderIdField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, var _replicaNodesField_) = BinaryDecoder.ReadArray<int>(buffer, i, BinaryDecoder.ReadInt32);
                    if (_replicaNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    else
                        replicaNodesField = _replicaNodesField_.Value;
                    (i, var _isrNodesField_) = BinaryDecoder.ReadArray<int>(buffer, i, BinaryDecoder.ReadInt32);
                    if (_isrNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    else
                        isrNodesField = _isrNodesField_.Value;
                    return new(i, new(
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
                public static DecodeResult<MetadataResponsePartition> ReadV5([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var errorCodeField = default(short);
                    var partitionIndexField = default(int);
                    var leaderIdField = default(int);
                    var leaderEpochField = default(int);
                    var replicaNodesField = ImmutableArray<int>.Empty;
                    var isrNodesField = ImmutableArray<int>.Empty;
                    var offlineReplicasField = ImmutableArray<int>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, leaderIdField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, var _replicaNodesField_) = BinaryDecoder.ReadArray<int>(buffer, i, BinaryDecoder.ReadInt32);
                    if (_replicaNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    else
                        replicaNodesField = _replicaNodesField_.Value;
                    (i, var _isrNodesField_) = BinaryDecoder.ReadArray<int>(buffer, i, BinaryDecoder.ReadInt32);
                    if (_isrNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    else
                        isrNodesField = _isrNodesField_.Value;
                    (i, var _offlineReplicasField_) = BinaryDecoder.ReadArray<int>(buffer, i, BinaryDecoder.ReadInt32);
                    if (_offlineReplicasField_ == null)
                        throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                    else
                        offlineReplicasField = _offlineReplicasField_.Value;
                    return new(i, new(
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
                public static DecodeResult<MetadataResponsePartition> ReadV6([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var errorCodeField = default(short);
                    var partitionIndexField = default(int);
                    var leaderIdField = default(int);
                    var leaderEpochField = default(int);
                    var replicaNodesField = ImmutableArray<int>.Empty;
                    var isrNodesField = ImmutableArray<int>.Empty;
                    var offlineReplicasField = ImmutableArray<int>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, leaderIdField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, var _replicaNodesField_) = BinaryDecoder.ReadArray<int>(buffer, i, BinaryDecoder.ReadInt32);
                    if (_replicaNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    else
                        replicaNodesField = _replicaNodesField_.Value;
                    (i, var _isrNodesField_) = BinaryDecoder.ReadArray<int>(buffer, i, BinaryDecoder.ReadInt32);
                    if (_isrNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    else
                        isrNodesField = _isrNodesField_.Value;
                    (i, var _offlineReplicasField_) = BinaryDecoder.ReadArray<int>(buffer, i, BinaryDecoder.ReadInt32);
                    if (_offlineReplicasField_ == null)
                        throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                    else
                        offlineReplicasField = _offlineReplicasField_.Value;
                    return new(i, new(
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
                public static DecodeResult<MetadataResponsePartition> ReadV7([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var errorCodeField = default(short);
                    var partitionIndexField = default(int);
                    var leaderIdField = default(int);
                    var leaderEpochField = default(int);
                    var replicaNodesField = ImmutableArray<int>.Empty;
                    var isrNodesField = ImmutableArray<int>.Empty;
                    var offlineReplicasField = ImmutableArray<int>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, leaderIdField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, leaderEpochField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, var _replicaNodesField_) = BinaryDecoder.ReadArray<int>(buffer, i, BinaryDecoder.ReadInt32);
                    if (_replicaNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    else
                        replicaNodesField = _replicaNodesField_.Value;
                    (i, var _isrNodesField_) = BinaryDecoder.ReadArray<int>(buffer, i, BinaryDecoder.ReadInt32);
                    if (_isrNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    else
                        isrNodesField = _isrNodesField_.Value;
                    (i, var _offlineReplicasField_) = BinaryDecoder.ReadArray<int>(buffer, i, BinaryDecoder.ReadInt32);
                    if (_offlineReplicasField_ == null)
                        throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                    else
                        offlineReplicasField = _offlineReplicasField_.Value;
                    return new(i, new(
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
                public static DecodeResult<MetadataResponsePartition> ReadV8([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var errorCodeField = default(short);
                    var partitionIndexField = default(int);
                    var leaderIdField = default(int);
                    var leaderEpochField = default(int);
                    var replicaNodesField = ImmutableArray<int>.Empty;
                    var isrNodesField = ImmutableArray<int>.Empty;
                    var offlineReplicasField = ImmutableArray<int>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, leaderIdField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, leaderEpochField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, var _replicaNodesField_) = BinaryDecoder.ReadArray<int>(buffer, i, BinaryDecoder.ReadInt32);
                    if (_replicaNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    else
                        replicaNodesField = _replicaNodesField_.Value;
                    (i, var _isrNodesField_) = BinaryDecoder.ReadArray<int>(buffer, i, BinaryDecoder.ReadInt32);
                    if (_isrNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    else
                        isrNodesField = _isrNodesField_.Value;
                    (i, var _offlineReplicasField_) = BinaryDecoder.ReadArray<int>(buffer, i, BinaryDecoder.ReadInt32);
                    if (_offlineReplicasField_ == null)
                        throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                    else
                        offlineReplicasField = _offlineReplicasField_.Value;
                    return new(i, new(
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
                public static DecodeResult<MetadataResponsePartition> ReadV9([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var errorCodeField = default(short);
                    var partitionIndexField = default(int);
                    var leaderIdField = default(int);
                    var leaderEpochField = default(int);
                    var replicaNodesField = ImmutableArray<int>.Empty;
                    var isrNodesField = ImmutableArray<int>.Empty;
                    var offlineReplicasField = ImmutableArray<int>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, leaderIdField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, leaderEpochField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, var _replicaNodesField_) = BinaryDecoder.ReadCompactArray<int>(buffer, i, BinaryDecoder.ReadInt32);
                    if (_replicaNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    else
                        replicaNodesField = _replicaNodesField_.Value;
                    (i, var _isrNodesField_) = BinaryDecoder.ReadCompactArray<int>(buffer, i, BinaryDecoder.ReadInt32);
                    if (_isrNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    else
                        isrNodesField = _isrNodesField_.Value;
                    (i, var _offlineReplicasField_) = BinaryDecoder.ReadCompactArray<int>(buffer, i, BinaryDecoder.ReadInt32);
                    if (_offlineReplicasField_ == null)
                        throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                    else
                        offlineReplicasField = _offlineReplicasField_.Value;
                    (i, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, i);
                    if (taggedFieldsCount > 0)
                    {
                        var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                        while (taggedFieldsCount > 0)
                        {
                            (i, var tag) = BinaryDecoder.ReadVarInt32(buffer, i);
                            (i, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, i);
                            taggedFieldsBuilder.Add(new(tag, bytes));
                            taggedFieldsCount--;
                        }
                    }
                    return new(i, new(
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
                public static DecodeResult<MetadataResponsePartition> ReadV10([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var errorCodeField = default(short);
                    var partitionIndexField = default(int);
                    var leaderIdField = default(int);
                    var leaderEpochField = default(int);
                    var replicaNodesField = ImmutableArray<int>.Empty;
                    var isrNodesField = ImmutableArray<int>.Empty;
                    var offlineReplicasField = ImmutableArray<int>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, leaderIdField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, leaderEpochField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, var _replicaNodesField_) = BinaryDecoder.ReadCompactArray<int>(buffer, i, BinaryDecoder.ReadInt32);
                    if (_replicaNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    else
                        replicaNodesField = _replicaNodesField_.Value;
                    (i, var _isrNodesField_) = BinaryDecoder.ReadCompactArray<int>(buffer, i, BinaryDecoder.ReadInt32);
                    if (_isrNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    else
                        isrNodesField = _isrNodesField_.Value;
                    (i, var _offlineReplicasField_) = BinaryDecoder.ReadCompactArray<int>(buffer, i, BinaryDecoder.ReadInt32);
                    if (_offlineReplicasField_ == null)
                        throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                    else
                        offlineReplicasField = _offlineReplicasField_.Value;
                    (i, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, i);
                    if (taggedFieldsCount > 0)
                    {
                        var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                        while (taggedFieldsCount > 0)
                        {
                            (i, var tag) = BinaryDecoder.ReadVarInt32(buffer, i);
                            (i, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, i);
                            taggedFieldsBuilder.Add(new(tag, bytes));
                            taggedFieldsCount--;
                        }
                    }
                    return new(i, new(
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
                public static DecodeResult<MetadataResponsePartition> ReadV11([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var errorCodeField = default(short);
                    var partitionIndexField = default(int);
                    var leaderIdField = default(int);
                    var leaderEpochField = default(int);
                    var replicaNodesField = ImmutableArray<int>.Empty;
                    var isrNodesField = ImmutableArray<int>.Empty;
                    var offlineReplicasField = ImmutableArray<int>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, leaderIdField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, leaderEpochField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, var _replicaNodesField_) = BinaryDecoder.ReadCompactArray<int>(buffer, i, BinaryDecoder.ReadInt32);
                    if (_replicaNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    else
                        replicaNodesField = _replicaNodesField_.Value;
                    (i, var _isrNodesField_) = BinaryDecoder.ReadCompactArray<int>(buffer, i, BinaryDecoder.ReadInt32);
                    if (_isrNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    else
                        isrNodesField = _isrNodesField_.Value;
                    (i, var _offlineReplicasField_) = BinaryDecoder.ReadCompactArray<int>(buffer, i, BinaryDecoder.ReadInt32);
                    if (_offlineReplicasField_ == null)
                        throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                    else
                        offlineReplicasField = _offlineReplicasField_.Value;
                    (i, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, i);
                    if (taggedFieldsCount > 0)
                    {
                        var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                        while (taggedFieldsCount > 0)
                        {
                            (i, var tag) = BinaryDecoder.ReadVarInt32(buffer, i);
                            (i, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, i);
                            taggedFieldsBuilder.Add(new(tag, bytes));
                            taggedFieldsCount--;
                        }
                    }
                    return new(i, new(
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
                public static DecodeResult<MetadataResponsePartition> ReadV12([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var errorCodeField = default(short);
                    var partitionIndexField = default(int);
                    var leaderIdField = default(int);
                    var leaderEpochField = default(int);
                    var replicaNodesField = ImmutableArray<int>.Empty;
                    var isrNodesField = ImmutableArray<int>.Empty;
                    var offlineReplicasField = ImmutableArray<int>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, leaderIdField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, leaderEpochField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, var _replicaNodesField_) = BinaryDecoder.ReadCompactArray<int>(buffer, i, BinaryDecoder.ReadInt32);
                    if (_replicaNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                    else
                        replicaNodesField = _replicaNodesField_.Value;
                    (i, var _isrNodesField_) = BinaryDecoder.ReadCompactArray<int>(buffer, i, BinaryDecoder.ReadInt32);
                    if (_isrNodesField_ == null)
                        throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                    else
                        isrNodesField = _isrNodesField_.Value;
                    (i, var _offlineReplicasField_) = BinaryDecoder.ReadCompactArray<int>(buffer, i, BinaryDecoder.ReadInt32);
                    if (_offlineReplicasField_ == null)
                        throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                    else
                        offlineReplicasField = _offlineReplicasField_.Value;
                    (i, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, i);
                    if (taggedFieldsCount > 0)
                    {
                        var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                        while (taggedFieldsCount > 0)
                        {
                            (i, var tag) = BinaryDecoder.ReadVarInt32(buffer, i);
                            (i, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, i);
                            taggedFieldsBuilder.Add(new(tag, bytes));
                            taggedFieldsCount--;
                        }
                    }
                    return new(i, new(
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
