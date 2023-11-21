using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using Kafka.Common.Records;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using SnapshotId = Kafka.Client.Messages.FetchResponseData.FetchableTopicResponse.PartitionData.SnapshotId;
using NodeEndpoint = Kafka.Client.Messages.FetchResponseData.NodeEndpoint;
using PartitionData = Kafka.Client.Messages.FetchResponseData.FetchableTopicResponse.PartitionData;
using LeaderIdAndEpoch = Kafka.Client.Messages.FetchResponseData.FetchableTopicResponse.PartitionData.LeaderIdAndEpoch;
using EpochEndOffset = Kafka.Client.Messages.FetchResponseData.FetchableTopicResponse.PartitionData.EpochEndOffset;
using FetchableTopicResponse = Kafka.Client.Messages.FetchResponseData.FetchableTopicResponse;
using AbortedTransaction = Kafka.Client.Messages.FetchResponseData.FetchableTopicResponse.PartitionData.AbortedTransaction;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    public class FetchResponseDecoder : 
        ResponseDecoder<ResponseHeaderData, FetchResponseData>
    {
        public FetchResponseDecoder() :
            base(
                ApiKey.Fetch,
                new(0, 16),
                new(12, 32767),
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
        protected override DecodeDelegate<FetchResponseData> GetMessageDecoder(short apiVersion) =>
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
                13 => ReadV13,
                14 => ReadV14,
                15 => ReadV15,
                16 => ReadV16,
                _ => throw new NotSupportedException()
            }
        ;
        private static DecodeResult<FetchResponseData> ReadV0(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var nodeEndpointsField = ImmutableArray<NodeEndpoint>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _responsesField_) = BinaryDecoder.ReadArray<FetchableTopicResponse>(buffer, index, FetchableTopicResponseDecoder.ReadV0);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            return new(index, new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField,
                nodeEndpointsField,
                taggedFields
            ));
        }
        private static DecodeResult<FetchResponseData> ReadV1(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var nodeEndpointsField = ImmutableArray<NodeEndpoint>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _responsesField_) = BinaryDecoder.ReadArray<FetchableTopicResponse>(buffer, index, FetchableTopicResponseDecoder.ReadV1);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            return new(index, new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField,
                nodeEndpointsField,
                taggedFields
            ));
        }
        private static DecodeResult<FetchResponseData> ReadV2(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var nodeEndpointsField = ImmutableArray<NodeEndpoint>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _responsesField_) = BinaryDecoder.ReadArray<FetchableTopicResponse>(buffer, index, FetchableTopicResponseDecoder.ReadV2);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            return new(index, new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField,
                nodeEndpointsField,
                taggedFields
            ));
        }
        private static DecodeResult<FetchResponseData> ReadV3(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var nodeEndpointsField = ImmutableArray<NodeEndpoint>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _responsesField_) = BinaryDecoder.ReadArray<FetchableTopicResponse>(buffer, index, FetchableTopicResponseDecoder.ReadV3);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            return new(index, new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField,
                nodeEndpointsField,
                taggedFields
            ));
        }
        private static DecodeResult<FetchResponseData> ReadV4(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var nodeEndpointsField = ImmutableArray<NodeEndpoint>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _responsesField_) = BinaryDecoder.ReadArray<FetchableTopicResponse>(buffer, index, FetchableTopicResponseDecoder.ReadV4);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            return new(index, new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField,
                nodeEndpointsField,
                taggedFields
            ));
        }
        private static DecodeResult<FetchResponseData> ReadV5(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var nodeEndpointsField = ImmutableArray<NodeEndpoint>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _responsesField_) = BinaryDecoder.ReadArray<FetchableTopicResponse>(buffer, index, FetchableTopicResponseDecoder.ReadV5);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            return new(index, new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField,
                nodeEndpointsField,
                taggedFields
            ));
        }
        private static DecodeResult<FetchResponseData> ReadV6(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var nodeEndpointsField = ImmutableArray<NodeEndpoint>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _responsesField_) = BinaryDecoder.ReadArray<FetchableTopicResponse>(buffer, index, FetchableTopicResponseDecoder.ReadV6);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            return new(index, new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField,
                nodeEndpointsField,
                taggedFields
            ));
        }
        private static DecodeResult<FetchResponseData> ReadV7(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var nodeEndpointsField = ImmutableArray<NodeEndpoint>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, sessionIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _responsesField_) = BinaryDecoder.ReadArray<FetchableTopicResponse>(buffer, index, FetchableTopicResponseDecoder.ReadV7);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            return new(index, new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField,
                nodeEndpointsField,
                taggedFields
            ));
        }
        private static DecodeResult<FetchResponseData> ReadV8(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var nodeEndpointsField = ImmutableArray<NodeEndpoint>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, sessionIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _responsesField_) = BinaryDecoder.ReadArray<FetchableTopicResponse>(buffer, index, FetchableTopicResponseDecoder.ReadV8);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            return new(index, new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField,
                nodeEndpointsField,
                taggedFields
            ));
        }
        private static DecodeResult<FetchResponseData> ReadV9(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var nodeEndpointsField = ImmutableArray<NodeEndpoint>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, sessionIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _responsesField_) = BinaryDecoder.ReadArray<FetchableTopicResponse>(buffer, index, FetchableTopicResponseDecoder.ReadV9);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            return new(index, new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField,
                nodeEndpointsField,
                taggedFields
            ));
        }
        private static DecodeResult<FetchResponseData> ReadV10(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var nodeEndpointsField = ImmutableArray<NodeEndpoint>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, sessionIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _responsesField_) = BinaryDecoder.ReadArray<FetchableTopicResponse>(buffer, index, FetchableTopicResponseDecoder.ReadV10);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            return new(index, new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField,
                nodeEndpointsField,
                taggedFields
            ));
        }
        private static DecodeResult<FetchResponseData> ReadV11(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var nodeEndpointsField = ImmutableArray<NodeEndpoint>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, sessionIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _responsesField_) = BinaryDecoder.ReadArray<FetchableTopicResponse>(buffer, index, FetchableTopicResponseDecoder.ReadV11);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            return new(index, new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField,
                nodeEndpointsField,
                taggedFields
            ));
        }
        private static DecodeResult<FetchResponseData> ReadV12(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var nodeEndpointsField = ImmutableArray<NodeEndpoint>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, sessionIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _responsesField_) = BinaryDecoder.ReadCompactArray<FetchableTopicResponse>(buffer, index, FetchableTopicResponseDecoder.ReadV12);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
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
                errorCodeField,
                sessionIdField,
                responsesField,
                nodeEndpointsField,
                taggedFields
            ));
        }
        private static DecodeResult<FetchResponseData> ReadV13(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var nodeEndpointsField = ImmutableArray<NodeEndpoint>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, sessionIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _responsesField_) = BinaryDecoder.ReadCompactArray<FetchableTopicResponse>(buffer, index, FetchableTopicResponseDecoder.ReadV13);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
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
                errorCodeField,
                sessionIdField,
                responsesField,
                nodeEndpointsField,
                taggedFields
            ));
        }
        private static DecodeResult<FetchResponseData> ReadV14(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var nodeEndpointsField = ImmutableArray<NodeEndpoint>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, sessionIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _responsesField_) = BinaryDecoder.ReadCompactArray<FetchableTopicResponse>(buffer, index, FetchableTopicResponseDecoder.ReadV14);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
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
                errorCodeField,
                sessionIdField,
                responsesField,
                nodeEndpointsField,
                taggedFields
            ));
        }
        private static DecodeResult<FetchResponseData> ReadV15(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var nodeEndpointsField = ImmutableArray<NodeEndpoint>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, sessionIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _responsesField_) = BinaryDecoder.ReadCompactArray<FetchableTopicResponse>(buffer, index, FetchableTopicResponseDecoder.ReadV15);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
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
                errorCodeField,
                sessionIdField,
                responsesField,
                nodeEndpointsField,
                taggedFields
            ));
        }
        private static DecodeResult<FetchResponseData> ReadV16(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var nodeEndpointsField = ImmutableArray<NodeEndpoint>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, sessionIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _responsesField_) = BinaryDecoder.ReadCompactArray<FetchableTopicResponse>(buffer, index, FetchableTopicResponseDecoder.ReadV16);
            if (_responsesField_ == null)
                throw new NullReferenceException("Null not allowed for 'Responses'");
            else
                responsesField = _responsesField_.Value;
            (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
            if (taggedFieldsCount > 0)
            {
                var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                while (taggedFieldsCount > 0)
                {
                    (index, var tag) = BinaryDecoder.ReadVarInt32(buffer, index);
                    switch (tag)
                    {
                        case 0:
                            (index, var _nodeEndpointsField_) = BinaryDecoder.ReadCompactArray<NodeEndpoint>(buffer, index, NodeEndpointDecoder.ReadV16);
                            if (_nodeEndpointsField_ == null)
                                throw new NullReferenceException("Null not allowed for 'NodeEndpoints'");
                            else
                                nodeEndpointsField = _nodeEndpointsField_.Value;
                            break;
                        default:
                            (index, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, index);
                            taggedFieldsBuilder.Add(new(tag, bytes));
                            break;
                    }
                    taggedFieldsCount--;
                }
            }
            return new(index, new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField,
                nodeEndpointsField,
                taggedFields
            ));
        }
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class FetchableTopicResponseDecoder
        {
            public static DecodeResult<FetchableTopicResponse> ReadV0(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<PartitionData>(buffer, index, PartitionDataDecoder.ReadV0);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return new(index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<FetchableTopicResponse> ReadV1(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<PartitionData>(buffer, index, PartitionDataDecoder.ReadV1);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return new(index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<FetchableTopicResponse> ReadV2(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<PartitionData>(buffer, index, PartitionDataDecoder.ReadV2);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return new(index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<FetchableTopicResponse> ReadV3(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<PartitionData>(buffer, index, PartitionDataDecoder.ReadV3);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return new(index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<FetchableTopicResponse> ReadV4(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<PartitionData>(buffer, index, PartitionDataDecoder.ReadV4);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return new(index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<FetchableTopicResponse> ReadV5(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<PartitionData>(buffer, index, PartitionDataDecoder.ReadV5);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return new(index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<FetchableTopicResponse> ReadV6(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<PartitionData>(buffer, index, PartitionDataDecoder.ReadV6);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return new(index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<FetchableTopicResponse> ReadV7(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<PartitionData>(buffer, index, PartitionDataDecoder.ReadV7);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return new(index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<FetchableTopicResponse> ReadV8(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<PartitionData>(buffer, index, PartitionDataDecoder.ReadV8);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return new(index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<FetchableTopicResponse> ReadV9(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<PartitionData>(buffer, index, PartitionDataDecoder.ReadV9);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return new(index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<FetchableTopicResponse> ReadV10(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<PartitionData>(buffer, index, PartitionDataDecoder.ReadV10);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return new(index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<FetchableTopicResponse> ReadV11(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<PartitionData>(buffer, index, PartitionDataDecoder.ReadV11);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return new(index, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<FetchableTopicResponse> ReadV12(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadCompactArray<PartitionData>(buffer, index, PartitionDataDecoder.ReadV12);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
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
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<FetchableTopicResponse> ReadV13(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicIdField) = BinaryDecoder.ReadUuid(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadCompactArray<PartitionData>(buffer, index, PartitionDataDecoder.ReadV13);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
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
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<FetchableTopicResponse> ReadV14(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicIdField) = BinaryDecoder.ReadUuid(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadCompactArray<PartitionData>(buffer, index, PartitionDataDecoder.ReadV14);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
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
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<FetchableTopicResponse> ReadV15(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicIdField) = BinaryDecoder.ReadUuid(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadCompactArray<PartitionData>(buffer, index, PartitionDataDecoder.ReadV15);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
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
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<FetchableTopicResponse> ReadV16(byte[] buffer, int index)
            {
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, topicIdField) = BinaryDecoder.ReadUuid(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadCompactArray<PartitionData>(buffer, index, PartitionDataDecoder.ReadV16);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
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
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            [GeneratedCodeAttribute("kgen", "1.0.0.0")]
            private static class PartitionDataDecoder
            {
                public static DecodeResult<PartitionData> ReadV0(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>?);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, recordsField) = BinaryDecoder.ReadRecords(buffer, index);
                    return new(index, new(
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
                        recordsField,
                        taggedFields
                    ));
                }
                public static DecodeResult<PartitionData> ReadV1(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>?);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, recordsField) = BinaryDecoder.ReadRecords(buffer, index);
                    return new(index, new(
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
                        recordsField,
                        taggedFields
                    ));
                }
                public static DecodeResult<PartitionData> ReadV2(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>?);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, recordsField) = BinaryDecoder.ReadRecords(buffer, index);
                    return new(index, new(
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
                        recordsField,
                        taggedFields
                    ));
                }
                public static DecodeResult<PartitionData> ReadV3(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>?);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, recordsField) = BinaryDecoder.ReadRecords(buffer, index);
                    return new(index, new(
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
                        recordsField,
                        taggedFields
                    ));
                }
                public static DecodeResult<PartitionData> ReadV4(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>?);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, lastStableOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, abortedTransactionsField) = BinaryDecoder.ReadArray<AbortedTransaction>(buffer, index, AbortedTransactionDecoder.ReadV4);
                    (index, recordsField) = BinaryDecoder.ReadRecords(buffer, index);
                    return new(index, new(
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
                        recordsField,
                        taggedFields
                    ));
                }
                public static DecodeResult<PartitionData> ReadV5(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>?);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, lastStableOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, abortedTransactionsField) = BinaryDecoder.ReadArray<AbortedTransaction>(buffer, index, AbortedTransactionDecoder.ReadV5);
                    (index, recordsField) = BinaryDecoder.ReadRecords(buffer, index);
                    return new(index, new(
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
                        recordsField,
                        taggedFields
                    ));
                }
                public static DecodeResult<PartitionData> ReadV6(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>?);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, lastStableOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, abortedTransactionsField) = BinaryDecoder.ReadArray<AbortedTransaction>(buffer, index, AbortedTransactionDecoder.ReadV6);
                    (index, recordsField) = BinaryDecoder.ReadRecords(buffer, index);
                    return new(index, new(
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
                        recordsField,
                        taggedFields
                    ));
                }
                public static DecodeResult<PartitionData> ReadV7(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>?);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, lastStableOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, abortedTransactionsField) = BinaryDecoder.ReadArray<AbortedTransaction>(buffer, index, AbortedTransactionDecoder.ReadV7);
                    (index, recordsField) = BinaryDecoder.ReadRecords(buffer, index);
                    return new(index, new(
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
                        recordsField,
                        taggedFields
                    ));
                }
                public static DecodeResult<PartitionData> ReadV8(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>?);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, lastStableOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, abortedTransactionsField) = BinaryDecoder.ReadArray<AbortedTransaction>(buffer, index, AbortedTransactionDecoder.ReadV8);
                    (index, recordsField) = BinaryDecoder.ReadRecords(buffer, index);
                    return new(index, new(
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
                        recordsField,
                        taggedFields
                    ));
                }
                public static DecodeResult<PartitionData> ReadV9(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>?);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, lastStableOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, abortedTransactionsField) = BinaryDecoder.ReadArray<AbortedTransaction>(buffer, index, AbortedTransactionDecoder.ReadV9);
                    (index, recordsField) = BinaryDecoder.ReadRecords(buffer, index);
                    return new(index, new(
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
                        recordsField,
                        taggedFields
                    ));
                }
                public static DecodeResult<PartitionData> ReadV10(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>?);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, lastStableOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, abortedTransactionsField) = BinaryDecoder.ReadArray<AbortedTransaction>(buffer, index, AbortedTransactionDecoder.ReadV10);
                    (index, recordsField) = BinaryDecoder.ReadRecords(buffer, index);
                    return new(index, new(
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
                        recordsField,
                        taggedFields
                    ));
                }
                public static DecodeResult<PartitionData> ReadV11(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>?);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, lastStableOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, abortedTransactionsField) = BinaryDecoder.ReadArray<AbortedTransaction>(buffer, index, AbortedTransactionDecoder.ReadV11);
                    (index, preferredReadReplicaField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, recordsField) = BinaryDecoder.ReadRecords(buffer, index);
                    return new(index, new(
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
                        recordsField,
                        taggedFields
                    ));
                }
                public static DecodeResult<PartitionData> ReadV12(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>?);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, lastStableOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, abortedTransactionsField) = BinaryDecoder.ReadCompactArray<AbortedTransaction>(buffer, index, AbortedTransactionDecoder.ReadV12);
                    (index, preferredReadReplicaField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, recordsField) = BinaryDecoder.ReadCompactRecords(buffer, index);
                    (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
                    if (taggedFieldsCount > 0)
                    {
                        var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                        while (taggedFieldsCount > 0)
                        {
                            (index, var tag) = BinaryDecoder.ReadVarInt32(buffer, index);
                            switch (tag)
                            {
                                case 0:
                                    (index, divergingEpochField) = EpochEndOffsetDecoder.ReadV12(buffer, index);
                                    break;
                                case 1:
                                    (index, currentLeaderField) = LeaderIdAndEpochDecoder.ReadV12(buffer, index);
                                    break;
                                case 2:
                                    (index, snapshotIdField) = SnapshotIdDecoder.ReadV12(buffer, index);
                                    break;
                                default:
                                    (index, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, index);
                                    taggedFieldsBuilder.Add(new(tag, bytes));
                                    break;
                            }
                            taggedFieldsCount--;
                        }
                    }
                    return new(index, new(
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
                        recordsField,
                        taggedFields
                    ));
                }
                public static DecodeResult<PartitionData> ReadV13(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>?);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, lastStableOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, abortedTransactionsField) = BinaryDecoder.ReadCompactArray<AbortedTransaction>(buffer, index, AbortedTransactionDecoder.ReadV13);
                    (index, preferredReadReplicaField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, recordsField) = BinaryDecoder.ReadCompactRecords(buffer, index);
                    (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
                    if (taggedFieldsCount > 0)
                    {
                        var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                        while (taggedFieldsCount > 0)
                        {
                            (index, var tag) = BinaryDecoder.ReadVarInt32(buffer, index);
                            switch (tag)
                            {
                                case 0:
                                    (index, divergingEpochField) = EpochEndOffsetDecoder.ReadV13(buffer, index);
                                    break;
                                case 1:
                                    (index, currentLeaderField) = LeaderIdAndEpochDecoder.ReadV13(buffer, index);
                                    break;
                                case 2:
                                    (index, snapshotIdField) = SnapshotIdDecoder.ReadV13(buffer, index);
                                    break;
                                default:
                                    (index, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, index);
                                    taggedFieldsBuilder.Add(new(tag, bytes));
                                    break;
                            }
                            taggedFieldsCount--;
                        }
                    }
                    return new(index, new(
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
                        recordsField,
                        taggedFields
                    ));
                }
                public static DecodeResult<PartitionData> ReadV14(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>?);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, lastStableOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, abortedTransactionsField) = BinaryDecoder.ReadCompactArray<AbortedTransaction>(buffer, index, AbortedTransactionDecoder.ReadV14);
                    (index, preferredReadReplicaField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, recordsField) = BinaryDecoder.ReadCompactRecords(buffer, index);
                    (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
                    if (taggedFieldsCount > 0)
                    {
                        var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                        while (taggedFieldsCount > 0)
                        {
                            (index, var tag) = BinaryDecoder.ReadVarInt32(buffer, index);
                            switch (tag)
                            {
                                case 0:
                                    (index, divergingEpochField) = EpochEndOffsetDecoder.ReadV14(buffer, index);
                                    break;
                                case 1:
                                    (index, currentLeaderField) = LeaderIdAndEpochDecoder.ReadV14(buffer, index);
                                    break;
                                case 2:
                                    (index, snapshotIdField) = SnapshotIdDecoder.ReadV14(buffer, index);
                                    break;
                                default:
                                    (index, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, index);
                                    taggedFieldsBuilder.Add(new(tag, bytes));
                                    break;
                            }
                            taggedFieldsCount--;
                        }
                    }
                    return new(index, new(
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
                        recordsField,
                        taggedFields
                    ));
                }
                public static DecodeResult<PartitionData> ReadV15(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>?);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, lastStableOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, abortedTransactionsField) = BinaryDecoder.ReadCompactArray<AbortedTransaction>(buffer, index, AbortedTransactionDecoder.ReadV15);
                    (index, preferredReadReplicaField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, recordsField) = BinaryDecoder.ReadCompactRecords(buffer, index);
                    (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
                    if (taggedFieldsCount > 0)
                    {
                        var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                        while (taggedFieldsCount > 0)
                        {
                            (index, var tag) = BinaryDecoder.ReadVarInt32(buffer, index);
                            switch (tag)
                            {
                                case 0:
                                    (index, divergingEpochField) = EpochEndOffsetDecoder.ReadV15(buffer, index);
                                    break;
                                case 1:
                                    (index, currentLeaderField) = LeaderIdAndEpochDecoder.ReadV15(buffer, index);
                                    break;
                                case 2:
                                    (index, snapshotIdField) = SnapshotIdDecoder.ReadV15(buffer, index);
                                    break;
                                default:
                                    (index, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, index);
                                    taggedFieldsBuilder.Add(new(tag, bytes));
                                    break;
                            }
                            taggedFieldsCount--;
                        }
                    }
                    return new(index, new(
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
                        recordsField,
                        taggedFields
                    ));
                }
                public static DecodeResult<PartitionData> ReadV16(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>?);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>?);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, lastStableOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, abortedTransactionsField) = BinaryDecoder.ReadCompactArray<AbortedTransaction>(buffer, index, AbortedTransactionDecoder.ReadV16);
                    (index, preferredReadReplicaField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, recordsField) = BinaryDecoder.ReadCompactRecords(buffer, index);
                    (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
                    if (taggedFieldsCount > 0)
                    {
                        var taggedFieldsBuilder = ImmutableArray.CreateBuilder<TaggedField>();
                        while (taggedFieldsCount > 0)
                        {
                            (index, var tag) = BinaryDecoder.ReadVarInt32(buffer, index);
                            switch (tag)
                            {
                                case 0:
                                    (index, divergingEpochField) = EpochEndOffsetDecoder.ReadV16(buffer, index);
                                    break;
                                case 1:
                                    (index, currentLeaderField) = LeaderIdAndEpochDecoder.ReadV16(buffer, index);
                                    break;
                                case 2:
                                    (index, snapshotIdField) = SnapshotIdDecoder.ReadV16(buffer, index);
                                    break;
                                default:
                                    (index, var bytes) = BinaryDecoder.ReadCompactBytes(buffer, index);
                                    taggedFieldsBuilder.Add(new(tag, bytes));
                                    break;
                            }
                            taggedFieldsCount--;
                        }
                    }
                    return new(index, new(
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
                        recordsField,
                        taggedFields
                    ));
                }
                [GeneratedCodeAttribute("kgen", "1.0.0.0")]
                private static class AbortedTransactionDecoder
                {
                    public static DecodeResult<AbortedTransaction> ReadV0(byte[] buffer, int index)
                    {
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(index, new(
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<AbortedTransaction> ReadV1(byte[] buffer, int index)
                    {
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(index, new(
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<AbortedTransaction> ReadV2(byte[] buffer, int index)
                    {
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(index, new(
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<AbortedTransaction> ReadV3(byte[] buffer, int index)
                    {
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(index, new(
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<AbortedTransaction> ReadV4(byte[] buffer, int index)
                    {
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, producerIdField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, firstOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        return new(index, new(
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<AbortedTransaction> ReadV5(byte[] buffer, int index)
                    {
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, producerIdField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, firstOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        return new(index, new(
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<AbortedTransaction> ReadV6(byte[] buffer, int index)
                    {
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, producerIdField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, firstOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        return new(index, new(
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<AbortedTransaction> ReadV7(byte[] buffer, int index)
                    {
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, producerIdField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, firstOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        return new(index, new(
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<AbortedTransaction> ReadV8(byte[] buffer, int index)
                    {
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, producerIdField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, firstOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        return new(index, new(
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<AbortedTransaction> ReadV9(byte[] buffer, int index)
                    {
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, producerIdField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, firstOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        return new(index, new(
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<AbortedTransaction> ReadV10(byte[] buffer, int index)
                    {
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, producerIdField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, firstOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        return new(index, new(
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<AbortedTransaction> ReadV11(byte[] buffer, int index)
                    {
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, producerIdField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, firstOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        return new(index, new(
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<AbortedTransaction> ReadV12(byte[] buffer, int index)
                    {
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, producerIdField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, firstOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
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
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<AbortedTransaction> ReadV13(byte[] buffer, int index)
                    {
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, producerIdField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, firstOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
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
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<AbortedTransaction> ReadV14(byte[] buffer, int index)
                    {
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, producerIdField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, firstOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
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
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<AbortedTransaction> ReadV15(byte[] buffer, int index)
                    {
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, producerIdField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, firstOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
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
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<AbortedTransaction> ReadV16(byte[] buffer, int index)
                    {
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, producerIdField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, firstOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
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
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                }
                [GeneratedCodeAttribute("kgen", "1.0.0.0")]
                private static class EpochEndOffsetDecoder
                {
                    public static DecodeResult<EpochEndOffset> ReadV0(byte[] buffer, int index)
                    {
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(index, new(
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<EpochEndOffset> ReadV1(byte[] buffer, int index)
                    {
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(index, new(
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<EpochEndOffset> ReadV2(byte[] buffer, int index)
                    {
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(index, new(
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<EpochEndOffset> ReadV3(byte[] buffer, int index)
                    {
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(index, new(
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<EpochEndOffset> ReadV4(byte[] buffer, int index)
                    {
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(index, new(
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<EpochEndOffset> ReadV5(byte[] buffer, int index)
                    {
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(index, new(
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<EpochEndOffset> ReadV6(byte[] buffer, int index)
                    {
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(index, new(
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<EpochEndOffset> ReadV7(byte[] buffer, int index)
                    {
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(index, new(
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<EpochEndOffset> ReadV8(byte[] buffer, int index)
                    {
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(index, new(
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<EpochEndOffset> ReadV9(byte[] buffer, int index)
                    {
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(index, new(
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<EpochEndOffset> ReadV10(byte[] buffer, int index)
                    {
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(index, new(
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<EpochEndOffset> ReadV11(byte[] buffer, int index)
                    {
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(index, new(
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<EpochEndOffset> ReadV12(byte[] buffer, int index)
                    {
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, epochField) = BinaryDecoder.ReadInt32(buffer, index);
                        (index, endOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
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
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<EpochEndOffset> ReadV13(byte[] buffer, int index)
                    {
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, epochField) = BinaryDecoder.ReadInt32(buffer, index);
                        (index, endOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
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
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<EpochEndOffset> ReadV14(byte[] buffer, int index)
                    {
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, epochField) = BinaryDecoder.ReadInt32(buffer, index);
                        (index, endOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
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
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<EpochEndOffset> ReadV15(byte[] buffer, int index)
                    {
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, epochField) = BinaryDecoder.ReadInt32(buffer, index);
                        (index, endOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
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
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<EpochEndOffset> ReadV16(byte[] buffer, int index)
                    {
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, epochField) = BinaryDecoder.ReadInt32(buffer, index);
                        (index, endOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
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
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                }
                [GeneratedCodeAttribute("kgen", "1.0.0.0")]
                private static class LeaderIdAndEpochDecoder
                {
                    public static DecodeResult<LeaderIdAndEpoch> ReadV0(byte[] buffer, int index)
                    {
                        var leaderIdField = default(int);
                        var leaderEpochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(index, new(
                            leaderIdField,
                            leaderEpochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<LeaderIdAndEpoch> ReadV1(byte[] buffer, int index)
                    {
                        var leaderIdField = default(int);
                        var leaderEpochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(index, new(
                            leaderIdField,
                            leaderEpochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<LeaderIdAndEpoch> ReadV2(byte[] buffer, int index)
                    {
                        var leaderIdField = default(int);
                        var leaderEpochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(index, new(
                            leaderIdField,
                            leaderEpochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<LeaderIdAndEpoch> ReadV3(byte[] buffer, int index)
                    {
                        var leaderIdField = default(int);
                        var leaderEpochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(index, new(
                            leaderIdField,
                            leaderEpochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<LeaderIdAndEpoch> ReadV4(byte[] buffer, int index)
                    {
                        var leaderIdField = default(int);
                        var leaderEpochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(index, new(
                            leaderIdField,
                            leaderEpochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<LeaderIdAndEpoch> ReadV5(byte[] buffer, int index)
                    {
                        var leaderIdField = default(int);
                        var leaderEpochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(index, new(
                            leaderIdField,
                            leaderEpochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<LeaderIdAndEpoch> ReadV6(byte[] buffer, int index)
                    {
                        var leaderIdField = default(int);
                        var leaderEpochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(index, new(
                            leaderIdField,
                            leaderEpochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<LeaderIdAndEpoch> ReadV7(byte[] buffer, int index)
                    {
                        var leaderIdField = default(int);
                        var leaderEpochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(index, new(
                            leaderIdField,
                            leaderEpochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<LeaderIdAndEpoch> ReadV8(byte[] buffer, int index)
                    {
                        var leaderIdField = default(int);
                        var leaderEpochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(index, new(
                            leaderIdField,
                            leaderEpochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<LeaderIdAndEpoch> ReadV9(byte[] buffer, int index)
                    {
                        var leaderIdField = default(int);
                        var leaderEpochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(index, new(
                            leaderIdField,
                            leaderEpochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<LeaderIdAndEpoch> ReadV10(byte[] buffer, int index)
                    {
                        var leaderIdField = default(int);
                        var leaderEpochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(index, new(
                            leaderIdField,
                            leaderEpochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<LeaderIdAndEpoch> ReadV11(byte[] buffer, int index)
                    {
                        var leaderIdField = default(int);
                        var leaderEpochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(index, new(
                            leaderIdField,
                            leaderEpochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<LeaderIdAndEpoch> ReadV12(byte[] buffer, int index)
                    {
                        var leaderIdField = default(int);
                        var leaderEpochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, leaderIdField) = BinaryDecoder.ReadInt32(buffer, index);
                        (index, leaderEpochField) = BinaryDecoder.ReadInt32(buffer, index);
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
                            leaderIdField,
                            leaderEpochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<LeaderIdAndEpoch> ReadV13(byte[] buffer, int index)
                    {
                        var leaderIdField = default(int);
                        var leaderEpochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, leaderIdField) = BinaryDecoder.ReadInt32(buffer, index);
                        (index, leaderEpochField) = BinaryDecoder.ReadInt32(buffer, index);
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
                            leaderIdField,
                            leaderEpochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<LeaderIdAndEpoch> ReadV14(byte[] buffer, int index)
                    {
                        var leaderIdField = default(int);
                        var leaderEpochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, leaderIdField) = BinaryDecoder.ReadInt32(buffer, index);
                        (index, leaderEpochField) = BinaryDecoder.ReadInt32(buffer, index);
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
                            leaderIdField,
                            leaderEpochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<LeaderIdAndEpoch> ReadV15(byte[] buffer, int index)
                    {
                        var leaderIdField = default(int);
                        var leaderEpochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, leaderIdField) = BinaryDecoder.ReadInt32(buffer, index);
                        (index, leaderEpochField) = BinaryDecoder.ReadInt32(buffer, index);
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
                            leaderIdField,
                            leaderEpochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<LeaderIdAndEpoch> ReadV16(byte[] buffer, int index)
                    {
                        var leaderIdField = default(int);
                        var leaderEpochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, leaderIdField) = BinaryDecoder.ReadInt32(buffer, index);
                        (index, leaderEpochField) = BinaryDecoder.ReadInt32(buffer, index);
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
                            leaderIdField,
                            leaderEpochField,
                            taggedFields
                        ));
                    }
                }
                [GeneratedCodeAttribute("kgen", "1.0.0.0")]
                private static class SnapshotIdDecoder
                {
                    public static DecodeResult<SnapshotId> ReadV0(byte[] buffer, int index)
                    {
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, endOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, epochField) = BinaryDecoder.ReadInt32(buffer, index);
                        return new(index, new(
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<SnapshotId> ReadV1(byte[] buffer, int index)
                    {
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, endOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, epochField) = BinaryDecoder.ReadInt32(buffer, index);
                        return new(index, new(
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<SnapshotId> ReadV2(byte[] buffer, int index)
                    {
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, endOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, epochField) = BinaryDecoder.ReadInt32(buffer, index);
                        return new(index, new(
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<SnapshotId> ReadV3(byte[] buffer, int index)
                    {
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, endOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, epochField) = BinaryDecoder.ReadInt32(buffer, index);
                        return new(index, new(
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<SnapshotId> ReadV4(byte[] buffer, int index)
                    {
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, endOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, epochField) = BinaryDecoder.ReadInt32(buffer, index);
                        return new(index, new(
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<SnapshotId> ReadV5(byte[] buffer, int index)
                    {
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, endOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, epochField) = BinaryDecoder.ReadInt32(buffer, index);
                        return new(index, new(
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<SnapshotId> ReadV6(byte[] buffer, int index)
                    {
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, endOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, epochField) = BinaryDecoder.ReadInt32(buffer, index);
                        return new(index, new(
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<SnapshotId> ReadV7(byte[] buffer, int index)
                    {
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, endOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, epochField) = BinaryDecoder.ReadInt32(buffer, index);
                        return new(index, new(
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<SnapshotId> ReadV8(byte[] buffer, int index)
                    {
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, endOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, epochField) = BinaryDecoder.ReadInt32(buffer, index);
                        return new(index, new(
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<SnapshotId> ReadV9(byte[] buffer, int index)
                    {
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, endOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, epochField) = BinaryDecoder.ReadInt32(buffer, index);
                        return new(index, new(
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<SnapshotId> ReadV10(byte[] buffer, int index)
                    {
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, endOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, epochField) = BinaryDecoder.ReadInt32(buffer, index);
                        return new(index, new(
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<SnapshotId> ReadV11(byte[] buffer, int index)
                    {
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, endOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, epochField) = BinaryDecoder.ReadInt32(buffer, index);
                        return new(index, new(
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<SnapshotId> ReadV12(byte[] buffer, int index)
                    {
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, endOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, epochField) = BinaryDecoder.ReadInt32(buffer, index);
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
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<SnapshotId> ReadV13(byte[] buffer, int index)
                    {
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, endOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, epochField) = BinaryDecoder.ReadInt32(buffer, index);
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
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<SnapshotId> ReadV14(byte[] buffer, int index)
                    {
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, endOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, epochField) = BinaryDecoder.ReadInt32(buffer, index);
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
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<SnapshotId> ReadV15(byte[] buffer, int index)
                    {
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, endOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, epochField) = BinaryDecoder.ReadInt32(buffer, index);
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
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<SnapshotId> ReadV16(byte[] buffer, int index)
                    {
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, endOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, epochField) = BinaryDecoder.ReadInt32(buffer, index);
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
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                }
            }
        }
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class NodeEndpointDecoder
        {
            public static DecodeResult<NodeEndpoint> ReadV0(byte[] buffer, int index)
            {
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(index, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static DecodeResult<NodeEndpoint> ReadV1(byte[] buffer, int index)
            {
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(index, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static DecodeResult<NodeEndpoint> ReadV2(byte[] buffer, int index)
            {
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(index, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static DecodeResult<NodeEndpoint> ReadV3(byte[] buffer, int index)
            {
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(index, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static DecodeResult<NodeEndpoint> ReadV4(byte[] buffer, int index)
            {
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(index, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static DecodeResult<NodeEndpoint> ReadV5(byte[] buffer, int index)
            {
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(index, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static DecodeResult<NodeEndpoint> ReadV6(byte[] buffer, int index)
            {
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(index, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static DecodeResult<NodeEndpoint> ReadV7(byte[] buffer, int index)
            {
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(index, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static DecodeResult<NodeEndpoint> ReadV8(byte[] buffer, int index)
            {
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(index, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static DecodeResult<NodeEndpoint> ReadV9(byte[] buffer, int index)
            {
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(index, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static DecodeResult<NodeEndpoint> ReadV10(byte[] buffer, int index)
            {
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(index, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static DecodeResult<NodeEndpoint> ReadV11(byte[] buffer, int index)
            {
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(index, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static DecodeResult<NodeEndpoint> ReadV12(byte[] buffer, int index)
            {
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
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
            public static DecodeResult<NodeEndpoint> ReadV13(byte[] buffer, int index)
            {
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
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
            public static DecodeResult<NodeEndpoint> ReadV14(byte[] buffer, int index)
            {
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
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
            public static DecodeResult<NodeEndpoint> ReadV15(byte[] buffer, int index)
            {
                var nodeIdField = default(int);
                var hostField = "";
                var portField = default(int);
                var rackField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
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
            public static DecodeResult<NodeEndpoint> ReadV16(byte[] buffer, int index)
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
    }
}
