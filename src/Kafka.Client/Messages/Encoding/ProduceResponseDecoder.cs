using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using PartitionProduceResponse = Kafka.Client.Messages.ProduceResponseData.TopicProduceResponse.PartitionProduceResponse;
using TopicProduceResponse = Kafka.Client.Messages.ProduceResponseData.TopicProduceResponse;
using LeaderIdAndEpoch = Kafka.Client.Messages.ProduceResponseData.TopicProduceResponse.PartitionProduceResponse.LeaderIdAndEpoch;
using BatchIndexAndErrorMessage = Kafka.Client.Messages.ProduceResponseData.TopicProduceResponse.PartitionProduceResponse.BatchIndexAndErrorMessage;
using NodeEndpoint = Kafka.Client.Messages.ProduceResponseData.NodeEndpoint;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    internal class ProduceResponseDecoder : 
        ResponseDecoder<ResponseHeaderData, ProduceResponseData>
    {
        internal ProduceResponseDecoder() :
            base(
                ApiKey.Produce,
                new(0, 10),
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
        protected override DecodeValue<ProduceResponseData> GetMessageDecoder(short apiVersion) =>
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
                _ => throw new NotSupportedException()
            }
        ;
        private static DecodeResult<ProduceResponseData> ReadV0([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var responsesField = ImmutableArray<TopicProduceResponse>.Empty;
            var throttleTimeMsField = default(int);
            var nodeEndpointsField = ImmutableArray<NodeEndpoint>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, var _responsesField_) = BinaryDecoder.ReadArray<TopicProduceResponse>(buffer, i, TopicProduceResponseDecoder.ReadV0);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            return new(i, new(
                responsesField,
                throttleTimeMsField,
                nodeEndpointsField,
                taggedFields
            ));
        }
        private static DecodeResult<ProduceResponseData> ReadV1([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var responsesField = ImmutableArray<TopicProduceResponse>.Empty;
            var throttleTimeMsField = default(int);
            var nodeEndpointsField = ImmutableArray<NodeEndpoint>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, var _responsesField_) = BinaryDecoder.ReadArray<TopicProduceResponse>(buffer, i, TopicProduceResponseDecoder.ReadV1);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            return new(i, new(
                responsesField,
                throttleTimeMsField,
                nodeEndpointsField,
                taggedFields
            ));
        }
        private static DecodeResult<ProduceResponseData> ReadV2([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var responsesField = ImmutableArray<TopicProduceResponse>.Empty;
            var throttleTimeMsField = default(int);
            var nodeEndpointsField = ImmutableArray<NodeEndpoint>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, var _responsesField_) = BinaryDecoder.ReadArray<TopicProduceResponse>(buffer, i, TopicProduceResponseDecoder.ReadV2);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            return new(i, new(
                responsesField,
                throttleTimeMsField,
                nodeEndpointsField,
                taggedFields
            ));
        }
        private static DecodeResult<ProduceResponseData> ReadV3([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var responsesField = ImmutableArray<TopicProduceResponse>.Empty;
            var throttleTimeMsField = default(int);
            var nodeEndpointsField = ImmutableArray<NodeEndpoint>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, var _responsesField_) = BinaryDecoder.ReadArray<TopicProduceResponse>(buffer, i, TopicProduceResponseDecoder.ReadV3);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            return new(i, new(
                responsesField,
                throttleTimeMsField,
                nodeEndpointsField,
                taggedFields
            ));
        }
        private static DecodeResult<ProduceResponseData> ReadV4([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var responsesField = ImmutableArray<TopicProduceResponse>.Empty;
            var throttleTimeMsField = default(int);
            var nodeEndpointsField = ImmutableArray<NodeEndpoint>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, var _responsesField_) = BinaryDecoder.ReadArray<TopicProduceResponse>(buffer, i, TopicProduceResponseDecoder.ReadV4);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            return new(i, new(
                responsesField,
                throttleTimeMsField,
                nodeEndpointsField,
                taggedFields
            ));
        }
        private static DecodeResult<ProduceResponseData> ReadV5([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var responsesField = ImmutableArray<TopicProduceResponse>.Empty;
            var throttleTimeMsField = default(int);
            var nodeEndpointsField = ImmutableArray<NodeEndpoint>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, var _responsesField_) = BinaryDecoder.ReadArray<TopicProduceResponse>(buffer, i, TopicProduceResponseDecoder.ReadV5);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            return new(i, new(
                responsesField,
                throttleTimeMsField,
                nodeEndpointsField,
                taggedFields
            ));
        }
        private static DecodeResult<ProduceResponseData> ReadV6([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var responsesField = ImmutableArray<TopicProduceResponse>.Empty;
            var throttleTimeMsField = default(int);
            var nodeEndpointsField = ImmutableArray<NodeEndpoint>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, var _responsesField_) = BinaryDecoder.ReadArray<TopicProduceResponse>(buffer, i, TopicProduceResponseDecoder.ReadV6);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            return new(i, new(
                responsesField,
                throttleTimeMsField,
                nodeEndpointsField,
                taggedFields
            ));
        }
        private static DecodeResult<ProduceResponseData> ReadV7([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var responsesField = ImmutableArray<TopicProduceResponse>.Empty;
            var throttleTimeMsField = default(int);
            var nodeEndpointsField = ImmutableArray<NodeEndpoint>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, var _responsesField_) = BinaryDecoder.ReadArray<TopicProduceResponse>(buffer, i, TopicProduceResponseDecoder.ReadV7);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            return new(i, new(
                responsesField,
                throttleTimeMsField,
                nodeEndpointsField,
                taggedFields
            ));
        }
        private static DecodeResult<ProduceResponseData> ReadV8([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var responsesField = ImmutableArray<TopicProduceResponse>.Empty;
            var throttleTimeMsField = default(int);
            var nodeEndpointsField = ImmutableArray<NodeEndpoint>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, var _responsesField_) = BinaryDecoder.ReadArray<TopicProduceResponse>(buffer, i, TopicProduceResponseDecoder.ReadV8);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            return new(i, new(
                responsesField,
                throttleTimeMsField,
                nodeEndpointsField,
                taggedFields
            ));
        }
        private static DecodeResult<ProduceResponseData> ReadV9([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var responsesField = ImmutableArray<TopicProduceResponse>.Empty;
            var throttleTimeMsField = default(int);
            var nodeEndpointsField = ImmutableArray<NodeEndpoint>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, var _responsesField_) = BinaryDecoder.ReadCompactArray<TopicProduceResponse>(buffer, i, TopicProduceResponseDecoder.ReadV9);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
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
                responsesField,
                throttleTimeMsField,
                nodeEndpointsField,
                taggedFields
            ));
        }
        private static DecodeResult<ProduceResponseData> ReadV10([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var responsesField = ImmutableArray<TopicProduceResponse>.Empty;
            var throttleTimeMsField = default(int);
            var nodeEndpointsField = ImmutableArray<NodeEndpoint>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, var _responsesField_) = BinaryDecoder.ReadCompactArray<TopicProduceResponse>(buffer, i, TopicProduceResponseDecoder.ReadV10);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, i);
            if (taggedFieldsCount > 0)
            {
                var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                while (taggedFieldsCount > 0)
                {
                    (i, var tag) = BinaryDecoder.ReadVarInt32(buffer, i);
                    switch (tag)
                    {
                        case 0:
                            (i, var _nodeEndpointsField_) = BinaryDecoder.ReadCompactArray<NodeEndpoint>(buffer, i, NodeEndpointDecoder.ReadV10);
                            if (_nodeEndpointsField_ == null)
                                throw new NullReferenceException("Null not allowed for 'NodeEndpoints'");
                            else
                                nodeEndpointsField = _nodeEndpointsField_.Value;
                            break;
                        default:
                            (i, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, i);
                            taggedFieldsBuilder.Add(new(tag, bytes));
                            break;
                    }
                    taggedFieldsCount--;
                }
            }
            return new(i, new(
                responsesField,
                throttleTimeMsField,
                nodeEndpointsField,
                taggedFields
            ));
        }
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class NodeEndpointDecoder
        {
            public static DecodeResult<NodeEndpoint> ReadV0([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(i, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static DecodeResult<NodeEndpoint> ReadV1([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(i, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static DecodeResult<NodeEndpoint> ReadV2([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(i, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static DecodeResult<NodeEndpoint> ReadV3([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(i, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static DecodeResult<NodeEndpoint> ReadV4([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(i, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static DecodeResult<NodeEndpoint> ReadV5([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(i, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static DecodeResult<NodeEndpoint> ReadV6([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(i, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static DecodeResult<NodeEndpoint> ReadV7([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(i, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static DecodeResult<NodeEndpoint> ReadV8([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(i, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static DecodeResult<NodeEndpoint> ReadV9([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
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
            public static DecodeResult<NodeEndpoint> ReadV10([NotNull] in byte[] buffer, in int index)
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
        private static class TopicProduceResponseDecoder
        {
            public static DecodeResult<TopicProduceResponse> ReadV0([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var partitionResponsesField = ImmutableArray<PartitionProduceResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, var _partitionResponsesField_) = BinaryDecoder.ReadArray<PartitionProduceResponse>(buffer, i, PartitionProduceResponseDecoder.ReadV0);
                if (_partitionResponsesField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                else
                    partitionResponsesField = _partitionResponsesField_.Value;
                return new(i, new(
                    nameField,
                    partitionResponsesField,
                    taggedFields
                ));
            }
            public static DecodeResult<TopicProduceResponse> ReadV1([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var partitionResponsesField = ImmutableArray<PartitionProduceResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, var _partitionResponsesField_) = BinaryDecoder.ReadArray<PartitionProduceResponse>(buffer, i, PartitionProduceResponseDecoder.ReadV1);
                if (_partitionResponsesField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                else
                    partitionResponsesField = _partitionResponsesField_.Value;
                return new(i, new(
                    nameField,
                    partitionResponsesField,
                    taggedFields
                ));
            }
            public static DecodeResult<TopicProduceResponse> ReadV2([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var partitionResponsesField = ImmutableArray<PartitionProduceResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, var _partitionResponsesField_) = BinaryDecoder.ReadArray<PartitionProduceResponse>(buffer, i, PartitionProduceResponseDecoder.ReadV2);
                if (_partitionResponsesField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                else
                    partitionResponsesField = _partitionResponsesField_.Value;
                return new(i, new(
                    nameField,
                    partitionResponsesField,
                    taggedFields
                ));
            }
            public static DecodeResult<TopicProduceResponse> ReadV3([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var partitionResponsesField = ImmutableArray<PartitionProduceResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, var _partitionResponsesField_) = BinaryDecoder.ReadArray<PartitionProduceResponse>(buffer, i, PartitionProduceResponseDecoder.ReadV3);
                if (_partitionResponsesField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                else
                    partitionResponsesField = _partitionResponsesField_.Value;
                return new(i, new(
                    nameField,
                    partitionResponsesField,
                    taggedFields
                ));
            }
            public static DecodeResult<TopicProduceResponse> ReadV4([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var partitionResponsesField = ImmutableArray<PartitionProduceResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, var _partitionResponsesField_) = BinaryDecoder.ReadArray<PartitionProduceResponse>(buffer, i, PartitionProduceResponseDecoder.ReadV4);
                if (_partitionResponsesField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                else
                    partitionResponsesField = _partitionResponsesField_.Value;
                return new(i, new(
                    nameField,
                    partitionResponsesField,
                    taggedFields
                ));
            }
            public static DecodeResult<TopicProduceResponse> ReadV5([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var partitionResponsesField = ImmutableArray<PartitionProduceResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, var _partitionResponsesField_) = BinaryDecoder.ReadArray<PartitionProduceResponse>(buffer, i, PartitionProduceResponseDecoder.ReadV5);
                if (_partitionResponsesField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                else
                    partitionResponsesField = _partitionResponsesField_.Value;
                return new(i, new(
                    nameField,
                    partitionResponsesField,
                    taggedFields
                ));
            }
            public static DecodeResult<TopicProduceResponse> ReadV6([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var partitionResponsesField = ImmutableArray<PartitionProduceResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, var _partitionResponsesField_) = BinaryDecoder.ReadArray<PartitionProduceResponse>(buffer, i, PartitionProduceResponseDecoder.ReadV6);
                if (_partitionResponsesField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                else
                    partitionResponsesField = _partitionResponsesField_.Value;
                return new(i, new(
                    nameField,
                    partitionResponsesField,
                    taggedFields
                ));
            }
            public static DecodeResult<TopicProduceResponse> ReadV7([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var partitionResponsesField = ImmutableArray<PartitionProduceResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, var _partitionResponsesField_) = BinaryDecoder.ReadArray<PartitionProduceResponse>(buffer, i, PartitionProduceResponseDecoder.ReadV7);
                if (_partitionResponsesField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                else
                    partitionResponsesField = _partitionResponsesField_.Value;
                return new(i, new(
                    nameField,
                    partitionResponsesField,
                    taggedFields
                ));
            }
            public static DecodeResult<TopicProduceResponse> ReadV8([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var partitionResponsesField = ImmutableArray<PartitionProduceResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, var _partitionResponsesField_) = BinaryDecoder.ReadArray<PartitionProduceResponse>(buffer, i, PartitionProduceResponseDecoder.ReadV8);
                if (_partitionResponsesField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                else
                    partitionResponsesField = _partitionResponsesField_.Value;
                return new(i, new(
                    nameField,
                    partitionResponsesField,
                    taggedFields
                ));
            }
            public static DecodeResult<TopicProduceResponse> ReadV9([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var partitionResponsesField = ImmutableArray<PartitionProduceResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, var _partitionResponsesField_) = BinaryDecoder.ReadCompactArray<PartitionProduceResponse>(buffer, i, PartitionProduceResponseDecoder.ReadV9);
                if (_partitionResponsesField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                else
                    partitionResponsesField = _partitionResponsesField_.Value;
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
                    nameField,
                    partitionResponsesField,
                    taggedFields
                ));
            }
            public static DecodeResult<TopicProduceResponse> ReadV10([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var partitionResponsesField = ImmutableArray<PartitionProduceResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, var _partitionResponsesField_) = BinaryDecoder.ReadCompactArray<PartitionProduceResponse>(buffer, i, PartitionProduceResponseDecoder.ReadV10);
                if (_partitionResponsesField_ == null)
                    throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
                else
                    partitionResponsesField = _partitionResponsesField_.Value;
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
                    nameField,
                    partitionResponsesField,
                    taggedFields
                ));
            }
            [GeneratedCodeAttribute("kgen", "1.0.0.0")]
            private static class PartitionProduceResponseDecoder
            {
                public static DecodeResult<PartitionProduceResponse> ReadV0([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var indexField = default(int);
                    var errorCodeField = default(short);
                    var baseOffsetField = default(long);
                    var logAppendTimeMsField = default(long);
                    var logStartOffsetField = default(long);
                    var recordErrorsField = ImmutableArray<BatchIndexAndErrorMessage>.Empty;
                    var errorMessageField = default(string?);
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, indexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, baseOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    return new(i, new(
                        indexField,
                        errorCodeField,
                        baseOffsetField,
                        logAppendTimeMsField,
                        logStartOffsetField,
                        recordErrorsField,
                        errorMessageField,
                        currentLeaderField,
                        taggedFields
                    ));
                }
                public static DecodeResult<PartitionProduceResponse> ReadV1([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var indexField = default(int);
                    var errorCodeField = default(short);
                    var baseOffsetField = default(long);
                    var logAppendTimeMsField = default(long);
                    var logStartOffsetField = default(long);
                    var recordErrorsField = ImmutableArray<BatchIndexAndErrorMessage>.Empty;
                    var errorMessageField = default(string?);
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, indexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, baseOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    return new(i, new(
                        indexField,
                        errorCodeField,
                        baseOffsetField,
                        logAppendTimeMsField,
                        logStartOffsetField,
                        recordErrorsField,
                        errorMessageField,
                        currentLeaderField,
                        taggedFields
                    ));
                }
                public static DecodeResult<PartitionProduceResponse> ReadV2([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var indexField = default(int);
                    var errorCodeField = default(short);
                    var baseOffsetField = default(long);
                    var logAppendTimeMsField = default(long);
                    var logStartOffsetField = default(long);
                    var recordErrorsField = ImmutableArray<BatchIndexAndErrorMessage>.Empty;
                    var errorMessageField = default(string?);
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, indexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, baseOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, logAppendTimeMsField) = BinaryDecoder.ReadInt64(buffer, i);
                    return new(i, new(
                        indexField,
                        errorCodeField,
                        baseOffsetField,
                        logAppendTimeMsField,
                        logStartOffsetField,
                        recordErrorsField,
                        errorMessageField,
                        currentLeaderField,
                        taggedFields
                    ));
                }
                public static DecodeResult<PartitionProduceResponse> ReadV3([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var indexField = default(int);
                    var errorCodeField = default(short);
                    var baseOffsetField = default(long);
                    var logAppendTimeMsField = default(long);
                    var logStartOffsetField = default(long);
                    var recordErrorsField = ImmutableArray<BatchIndexAndErrorMessage>.Empty;
                    var errorMessageField = default(string?);
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, indexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, baseOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, logAppendTimeMsField) = BinaryDecoder.ReadInt64(buffer, i);
                    return new(i, new(
                        indexField,
                        errorCodeField,
                        baseOffsetField,
                        logAppendTimeMsField,
                        logStartOffsetField,
                        recordErrorsField,
                        errorMessageField,
                        currentLeaderField,
                        taggedFields
                    ));
                }
                public static DecodeResult<PartitionProduceResponse> ReadV4([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var indexField = default(int);
                    var errorCodeField = default(short);
                    var baseOffsetField = default(long);
                    var logAppendTimeMsField = default(long);
                    var logStartOffsetField = default(long);
                    var recordErrorsField = ImmutableArray<BatchIndexAndErrorMessage>.Empty;
                    var errorMessageField = default(string?);
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, indexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, baseOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, logAppendTimeMsField) = BinaryDecoder.ReadInt64(buffer, i);
                    return new(i, new(
                        indexField,
                        errorCodeField,
                        baseOffsetField,
                        logAppendTimeMsField,
                        logStartOffsetField,
                        recordErrorsField,
                        errorMessageField,
                        currentLeaderField,
                        taggedFields
                    ));
                }
                public static DecodeResult<PartitionProduceResponse> ReadV5([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var indexField = default(int);
                    var errorCodeField = default(short);
                    var baseOffsetField = default(long);
                    var logAppendTimeMsField = default(long);
                    var logStartOffsetField = default(long);
                    var recordErrorsField = ImmutableArray<BatchIndexAndErrorMessage>.Empty;
                    var errorMessageField = default(string?);
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, indexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, baseOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, logAppendTimeMsField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    return new(i, new(
                        indexField,
                        errorCodeField,
                        baseOffsetField,
                        logAppendTimeMsField,
                        logStartOffsetField,
                        recordErrorsField,
                        errorMessageField,
                        currentLeaderField,
                        taggedFields
                    ));
                }
                public static DecodeResult<PartitionProduceResponse> ReadV6([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var indexField = default(int);
                    var errorCodeField = default(short);
                    var baseOffsetField = default(long);
                    var logAppendTimeMsField = default(long);
                    var logStartOffsetField = default(long);
                    var recordErrorsField = ImmutableArray<BatchIndexAndErrorMessage>.Empty;
                    var errorMessageField = default(string?);
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, indexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, baseOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, logAppendTimeMsField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    return new(i, new(
                        indexField,
                        errorCodeField,
                        baseOffsetField,
                        logAppendTimeMsField,
                        logStartOffsetField,
                        recordErrorsField,
                        errorMessageField,
                        currentLeaderField,
                        taggedFields
                    ));
                }
                public static DecodeResult<PartitionProduceResponse> ReadV7([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var indexField = default(int);
                    var errorCodeField = default(short);
                    var baseOffsetField = default(long);
                    var logAppendTimeMsField = default(long);
                    var logStartOffsetField = default(long);
                    var recordErrorsField = ImmutableArray<BatchIndexAndErrorMessage>.Empty;
                    var errorMessageField = default(string?);
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, indexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, baseOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, logAppendTimeMsField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    return new(i, new(
                        indexField,
                        errorCodeField,
                        baseOffsetField,
                        logAppendTimeMsField,
                        logStartOffsetField,
                        recordErrorsField,
                        errorMessageField,
                        currentLeaderField,
                        taggedFields
                    ));
                }
                public static DecodeResult<PartitionProduceResponse> ReadV8([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var indexField = default(int);
                    var errorCodeField = default(short);
                    var baseOffsetField = default(long);
                    var logAppendTimeMsField = default(long);
                    var logStartOffsetField = default(long);
                    var recordErrorsField = ImmutableArray<BatchIndexAndErrorMessage>.Empty;
                    var errorMessageField = default(string?);
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, indexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, baseOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, logAppendTimeMsField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, var _recordErrorsField_) = BinaryDecoder.ReadArray<BatchIndexAndErrorMessage>(buffer, i, BatchIndexAndErrorMessageDecoder.ReadV8);
                    if (_recordErrorsField_ == null)
                        throw new NullReferenceException("Null not allowed for 'RecordErrors'");
                    else
                        recordErrorsField = _recordErrorsField_.Value;
                    (i, errorMessageField) = BinaryDecoder.ReadNullableString(buffer, i);
                    return new(i, new(
                        indexField,
                        errorCodeField,
                        baseOffsetField,
                        logAppendTimeMsField,
                        logStartOffsetField,
                        recordErrorsField,
                        errorMessageField,
                        currentLeaderField,
                        taggedFields
                    ));
                }
                public static DecodeResult<PartitionProduceResponse> ReadV9([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var indexField = default(int);
                    var errorCodeField = default(short);
                    var baseOffsetField = default(long);
                    var logAppendTimeMsField = default(long);
                    var logStartOffsetField = default(long);
                    var recordErrorsField = ImmutableArray<BatchIndexAndErrorMessage>.Empty;
                    var errorMessageField = default(string?);
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, indexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, baseOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, logAppendTimeMsField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, var _recordErrorsField_) = BinaryDecoder.ReadCompactArray<BatchIndexAndErrorMessage>(buffer, i, BatchIndexAndErrorMessageDecoder.ReadV9);
                    if (_recordErrorsField_ == null)
                        throw new NullReferenceException("Null not allowed for 'RecordErrors'");
                    else
                        recordErrorsField = _recordErrorsField_.Value;
                    (i, errorMessageField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
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
                        indexField,
                        errorCodeField,
                        baseOffsetField,
                        logAppendTimeMsField,
                        logStartOffsetField,
                        recordErrorsField,
                        errorMessageField,
                        currentLeaderField,
                        taggedFields
                    ));
                }
                public static DecodeResult<PartitionProduceResponse> ReadV10([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var indexField = default(int);
                    var errorCodeField = default(short);
                    var baseOffsetField = default(long);
                    var logAppendTimeMsField = default(long);
                    var logStartOffsetField = default(long);
                    var recordErrorsField = ImmutableArray<BatchIndexAndErrorMessage>.Empty;
                    var errorMessageField = default(string?);
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, indexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, baseOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, logAppendTimeMsField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, var _recordErrorsField_) = BinaryDecoder.ReadCompactArray<BatchIndexAndErrorMessage>(buffer, i, BatchIndexAndErrorMessageDecoder.ReadV10);
                    if (_recordErrorsField_ == null)
                        throw new NullReferenceException("Null not allowed for 'RecordErrors'");
                    else
                        recordErrorsField = _recordErrorsField_.Value;
                    (i, errorMessageField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
                    (i, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, i);
                    if (taggedFieldsCount > 0)
                    {
                        var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                        while (taggedFieldsCount > 0)
                        {
                            (i, var tag) = BinaryDecoder.ReadVarInt32(buffer, i);
                            switch (tag)
                            {
                                case 0:
                                    (i, currentLeaderField) = LeaderIdAndEpochDecoder.ReadV10(buffer, i);
                                    break;
                                default:
                                    (i, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, i);
                                    taggedFieldsBuilder.Add(new(tag, bytes));
                                    break;
                            }
                            taggedFieldsCount--;
                        }
                    }
                    return new(i, new(
                        indexField,
                        errorCodeField,
                        baseOffsetField,
                        logAppendTimeMsField,
                        logStartOffsetField,
                        recordErrorsField,
                        errorMessageField,
                        currentLeaderField,
                        taggedFields
                    ));
                }
                [GeneratedCodeAttribute("kgen", "1.0.0.0")]
                private static class BatchIndexAndErrorMessageDecoder
                {
                    public static DecodeResult<BatchIndexAndErrorMessage> ReadV0([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var batchIndexField = default(int);
                        var batchIndexErrorMessageField = default(string?);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(i, new(
                            batchIndexField,
                            batchIndexErrorMessageField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<BatchIndexAndErrorMessage> ReadV1([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var batchIndexField = default(int);
                        var batchIndexErrorMessageField = default(string?);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(i, new(
                            batchIndexField,
                            batchIndexErrorMessageField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<BatchIndexAndErrorMessage> ReadV2([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var batchIndexField = default(int);
                        var batchIndexErrorMessageField = default(string?);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(i, new(
                            batchIndexField,
                            batchIndexErrorMessageField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<BatchIndexAndErrorMessage> ReadV3([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var batchIndexField = default(int);
                        var batchIndexErrorMessageField = default(string?);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(i, new(
                            batchIndexField,
                            batchIndexErrorMessageField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<BatchIndexAndErrorMessage> ReadV4([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var batchIndexField = default(int);
                        var batchIndexErrorMessageField = default(string?);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(i, new(
                            batchIndexField,
                            batchIndexErrorMessageField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<BatchIndexAndErrorMessage> ReadV5([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var batchIndexField = default(int);
                        var batchIndexErrorMessageField = default(string?);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(i, new(
                            batchIndexField,
                            batchIndexErrorMessageField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<BatchIndexAndErrorMessage> ReadV6([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var batchIndexField = default(int);
                        var batchIndexErrorMessageField = default(string?);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(i, new(
                            batchIndexField,
                            batchIndexErrorMessageField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<BatchIndexAndErrorMessage> ReadV7([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var batchIndexField = default(int);
                        var batchIndexErrorMessageField = default(string?);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(i, new(
                            batchIndexField,
                            batchIndexErrorMessageField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<BatchIndexAndErrorMessage> ReadV8([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var batchIndexField = default(int);
                        var batchIndexErrorMessageField = default(string?);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (i, batchIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                        (i, batchIndexErrorMessageField) = BinaryDecoder.ReadNullableString(buffer, i);
                        return new(i, new(
                            batchIndexField,
                            batchIndexErrorMessageField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<BatchIndexAndErrorMessage> ReadV9([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var batchIndexField = default(int);
                        var batchIndexErrorMessageField = default(string?);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (i, batchIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                        (i, batchIndexErrorMessageField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
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
                            batchIndexField,
                            batchIndexErrorMessageField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<BatchIndexAndErrorMessage> ReadV10([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var batchIndexField = default(int);
                        var batchIndexErrorMessageField = default(string?);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (i, batchIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                        (i, batchIndexErrorMessageField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
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
                            batchIndexField,
                            batchIndexErrorMessageField,
                            taggedFields
                        ));
                    }
                }
                [GeneratedCodeAttribute("kgen", "1.0.0.0")]
                private static class LeaderIdAndEpochDecoder
                {
                    public static DecodeResult<LeaderIdAndEpoch> ReadV0([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var leaderIdField = default(int);
                        var leaderEpochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(i, new(
                            leaderIdField,
                            leaderEpochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<LeaderIdAndEpoch> ReadV1([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var leaderIdField = default(int);
                        var leaderEpochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(i, new(
                            leaderIdField,
                            leaderEpochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<LeaderIdAndEpoch> ReadV2([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var leaderIdField = default(int);
                        var leaderEpochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(i, new(
                            leaderIdField,
                            leaderEpochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<LeaderIdAndEpoch> ReadV3([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var leaderIdField = default(int);
                        var leaderEpochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(i, new(
                            leaderIdField,
                            leaderEpochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<LeaderIdAndEpoch> ReadV4([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var leaderIdField = default(int);
                        var leaderEpochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(i, new(
                            leaderIdField,
                            leaderEpochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<LeaderIdAndEpoch> ReadV5([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var leaderIdField = default(int);
                        var leaderEpochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(i, new(
                            leaderIdField,
                            leaderEpochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<LeaderIdAndEpoch> ReadV6([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var leaderIdField = default(int);
                        var leaderEpochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(i, new(
                            leaderIdField,
                            leaderEpochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<LeaderIdAndEpoch> ReadV7([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var leaderIdField = default(int);
                        var leaderEpochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(i, new(
                            leaderIdField,
                            leaderEpochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<LeaderIdAndEpoch> ReadV8([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var leaderIdField = default(int);
                        var leaderEpochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(i, new(
                            leaderIdField,
                            leaderEpochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<LeaderIdAndEpoch> ReadV9([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var leaderIdField = default(int);
                        var leaderEpochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
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
                            leaderIdField,
                            leaderEpochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<LeaderIdAndEpoch> ReadV10([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var leaderIdField = default(int);
                        var leaderEpochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (i, leaderIdField) = BinaryDecoder.ReadInt32(buffer, i);
                        (i, leaderEpochField) = BinaryDecoder.ReadInt32(buffer, i);
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
                            leaderIdField,
                            leaderEpochField,
                            taggedFields
                        ));
                    }
                }
            }
        }
    }
}
