using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using Kafka.Common.Records;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using AbortedTransaction = Kafka.Client.Messages.FetchResponseData.FetchableTopicResponse.PartitionData.AbortedTransaction;
using EpochEndOffset = Kafka.Client.Messages.FetchResponseData.FetchableTopicResponse.PartitionData.EpochEndOffset;
using FetchableTopicResponse = Kafka.Client.Messages.FetchResponseData.FetchableTopicResponse;
using LeaderIdAndEpoch = Kafka.Client.Messages.FetchResponseData.FetchableTopicResponse.PartitionData.LeaderIdAndEpoch;
using NodeEndpoint = Kafka.Client.Messages.FetchResponseData.NodeEndpoint;
using PartitionData = Kafka.Client.Messages.FetchResponseData.FetchableTopicResponse.PartitionData;
using SnapshotId = Kafka.Client.Messages.FetchResponseData.FetchableTopicResponse.PartitionData.SnapshotId;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    internal class FetchResponseDecoder : 
        ResponseDecoder<ResponseHeaderData, FetchResponseData>
    {
        internal FetchResponseDecoder() :
            base(
                ApiKey.Fetch,
                new(0, 16),
                new(12, 32767),
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
        protected override DecodeValue<FetchResponseData> GetMessageDecoder(short apiVersion) =>
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
        private static DecodeResult<FetchResponseData> ReadV0([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var nodeEndpointsField = ImmutableArray<NodeEndpoint>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, responsesField) = BinaryDecoder.ReadArray<FetchableTopicResponse>(buffer, i, FetchableTopicResponseDecoder.ReadV0);
            if (responsesField.IsDefault)
                throw new InvalidDataException("responsesField was null");
;
            return new(i, new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField,
                nodeEndpointsField,
                taggedFields
            ));
        }
        private static DecodeResult<FetchResponseData> ReadV1([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var nodeEndpointsField = ImmutableArray<NodeEndpoint>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, responsesField) = BinaryDecoder.ReadArray<FetchableTopicResponse>(buffer, i, FetchableTopicResponseDecoder.ReadV1);
            if (responsesField.IsDefault)
                throw new InvalidDataException("responsesField was null");
;
            return new(i, new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField,
                nodeEndpointsField,
                taggedFields
            ));
        }
        private static DecodeResult<FetchResponseData> ReadV2([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var nodeEndpointsField = ImmutableArray<NodeEndpoint>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, responsesField) = BinaryDecoder.ReadArray<FetchableTopicResponse>(buffer, i, FetchableTopicResponseDecoder.ReadV2);
            if (responsesField.IsDefault)
                throw new InvalidDataException("responsesField was null");
;
            return new(i, new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField,
                nodeEndpointsField,
                taggedFields
            ));
        }
        private static DecodeResult<FetchResponseData> ReadV3([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var nodeEndpointsField = ImmutableArray<NodeEndpoint>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, responsesField) = BinaryDecoder.ReadArray<FetchableTopicResponse>(buffer, i, FetchableTopicResponseDecoder.ReadV3);
            if (responsesField.IsDefault)
                throw new InvalidDataException("responsesField was null");
;
            return new(i, new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField,
                nodeEndpointsField,
                taggedFields
            ));
        }
        private static DecodeResult<FetchResponseData> ReadV4([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var nodeEndpointsField = ImmutableArray<NodeEndpoint>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, responsesField) = BinaryDecoder.ReadArray<FetchableTopicResponse>(buffer, i, FetchableTopicResponseDecoder.ReadV4);
            if (responsesField.IsDefault)
                throw new InvalidDataException("responsesField was null");
;
            return new(i, new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField,
                nodeEndpointsField,
                taggedFields
            ));
        }
        private static DecodeResult<FetchResponseData> ReadV5([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var nodeEndpointsField = ImmutableArray<NodeEndpoint>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, responsesField) = BinaryDecoder.ReadArray<FetchableTopicResponse>(buffer, i, FetchableTopicResponseDecoder.ReadV5);
            if (responsesField.IsDefault)
                throw new InvalidDataException("responsesField was null");
;
            return new(i, new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField,
                nodeEndpointsField,
                taggedFields
            ));
        }
        private static DecodeResult<FetchResponseData> ReadV6([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var nodeEndpointsField = ImmutableArray<NodeEndpoint>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, responsesField) = BinaryDecoder.ReadArray<FetchableTopicResponse>(buffer, i, FetchableTopicResponseDecoder.ReadV6);
            if (responsesField.IsDefault)
                throw new InvalidDataException("responsesField was null");
;
            return new(i, new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField,
                nodeEndpointsField,
                taggedFields
            ));
        }
        private static DecodeResult<FetchResponseData> ReadV7([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var nodeEndpointsField = ImmutableArray<NodeEndpoint>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, sessionIdField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, responsesField) = BinaryDecoder.ReadArray<FetchableTopicResponse>(buffer, i, FetchableTopicResponseDecoder.ReadV7);
            if (responsesField.IsDefault)
                throw new InvalidDataException("responsesField was null");
;
            return new(i, new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField,
                nodeEndpointsField,
                taggedFields
            ));
        }
        private static DecodeResult<FetchResponseData> ReadV8([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var nodeEndpointsField = ImmutableArray<NodeEndpoint>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, sessionIdField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, responsesField) = BinaryDecoder.ReadArray<FetchableTopicResponse>(buffer, i, FetchableTopicResponseDecoder.ReadV8);
            if (responsesField.IsDefault)
                throw new InvalidDataException("responsesField was null");
;
            return new(i, new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField,
                nodeEndpointsField,
                taggedFields
            ));
        }
        private static DecodeResult<FetchResponseData> ReadV9([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var nodeEndpointsField = ImmutableArray<NodeEndpoint>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, sessionIdField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, responsesField) = BinaryDecoder.ReadArray<FetchableTopicResponse>(buffer, i, FetchableTopicResponseDecoder.ReadV9);
            if (responsesField.IsDefault)
                throw new InvalidDataException("responsesField was null");
;
            return new(i, new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField,
                nodeEndpointsField,
                taggedFields
            ));
        }
        private static DecodeResult<FetchResponseData> ReadV10([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var nodeEndpointsField = ImmutableArray<NodeEndpoint>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, sessionIdField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, responsesField) = BinaryDecoder.ReadArray<FetchableTopicResponse>(buffer, i, FetchableTopicResponseDecoder.ReadV10);
            if (responsesField.IsDefault)
                throw new InvalidDataException("responsesField was null");
;
            return new(i, new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField,
                nodeEndpointsField,
                taggedFields
            ));
        }
        private static DecodeResult<FetchResponseData> ReadV11([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var nodeEndpointsField = ImmutableArray<NodeEndpoint>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, sessionIdField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, responsesField) = BinaryDecoder.ReadArray<FetchableTopicResponse>(buffer, i, FetchableTopicResponseDecoder.ReadV11);
            if (responsesField.IsDefault)
                throw new InvalidDataException("responsesField was null");
;
            return new(i, new(
                throttleTimeMsField,
                errorCodeField,
                sessionIdField,
                responsesField,
                nodeEndpointsField,
                taggedFields
            ));
        }
        private static DecodeResult<FetchResponseData> ReadV12([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var nodeEndpointsField = ImmutableArray<NodeEndpoint>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, sessionIdField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, responsesField) = BinaryDecoder.ReadCompactArray<FetchableTopicResponse>(buffer, i, FetchableTopicResponseDecoder.ReadV12);
            if (responsesField.IsDefault)
                throw new InvalidDataException("responsesField was null");
;
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
                errorCodeField,
                sessionIdField,
                responsesField,
                nodeEndpointsField,
                taggedFields
            ));
        }
        private static DecodeResult<FetchResponseData> ReadV13([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var nodeEndpointsField = ImmutableArray<NodeEndpoint>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, sessionIdField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, responsesField) = BinaryDecoder.ReadCompactArray<FetchableTopicResponse>(buffer, i, FetchableTopicResponseDecoder.ReadV13);
            if (responsesField.IsDefault)
                throw new InvalidDataException("responsesField was null");
;
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
                errorCodeField,
                sessionIdField,
                responsesField,
                nodeEndpointsField,
                taggedFields
            ));
        }
        private static DecodeResult<FetchResponseData> ReadV14([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var nodeEndpointsField = ImmutableArray<NodeEndpoint>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, sessionIdField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, responsesField) = BinaryDecoder.ReadCompactArray<FetchableTopicResponse>(buffer, i, FetchableTopicResponseDecoder.ReadV14);
            if (responsesField.IsDefault)
                throw new InvalidDataException("responsesField was null");
;
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
                errorCodeField,
                sessionIdField,
                responsesField,
                nodeEndpointsField,
                taggedFields
            ));
        }
        private static DecodeResult<FetchResponseData> ReadV15([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var nodeEndpointsField = ImmutableArray<NodeEndpoint>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, sessionIdField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, responsesField) = BinaryDecoder.ReadCompactArray<FetchableTopicResponse>(buffer, i, FetchableTopicResponseDecoder.ReadV15);
            if (responsesField.IsDefault)
                throw new InvalidDataException("responsesField was null");
;
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
                errorCodeField,
                sessionIdField,
                responsesField,
                nodeEndpointsField,
                taggedFields
            ));
        }
        private static DecodeResult<FetchResponseData> ReadV16([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var sessionIdField = default(int);
            var responsesField = ImmutableArray<FetchableTopicResponse>.Empty;
            var nodeEndpointsField = ImmutableArray<NodeEndpoint>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, sessionIdField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, responsesField) = BinaryDecoder.ReadCompactArray<FetchableTopicResponse>(buffer, i, FetchableTopicResponseDecoder.ReadV16);
            if (responsesField.IsDefault)
                throw new InvalidDataException("responsesField was null");
;
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
                            (i, nodeEndpointsField) = BinaryDecoder.ReadCompactArray<NodeEndpoint>(buffer, i, NodeEndpointDecoder.ReadV16);
                            if (nodeEndpointsField.IsDefault)
                                throw new InvalidDataException("nodeEndpointsField was null");
;
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
            public static DecodeResult<FetchableTopicResponse> ReadV0([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, topicField) = BinaryDecoder.ReadString(buffer, i);
                (i, partitionsField) = BinaryDecoder.ReadArray<PartitionData>(buffer, i, PartitionDataDecoder.ReadV0);
                if (partitionsField.IsDefault)
                    throw new InvalidDataException("partitionsField was null");
;
                return new(i, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<FetchableTopicResponse> ReadV1([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, topicField) = BinaryDecoder.ReadString(buffer, i);
                (i, partitionsField) = BinaryDecoder.ReadArray<PartitionData>(buffer, i, PartitionDataDecoder.ReadV1);
                if (partitionsField.IsDefault)
                    throw new InvalidDataException("partitionsField was null");
;
                return new(i, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<FetchableTopicResponse> ReadV2([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, topicField) = BinaryDecoder.ReadString(buffer, i);
                (i, partitionsField) = BinaryDecoder.ReadArray<PartitionData>(buffer, i, PartitionDataDecoder.ReadV2);
                if (partitionsField.IsDefault)
                    throw new InvalidDataException("partitionsField was null");
;
                return new(i, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<FetchableTopicResponse> ReadV3([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, topicField) = BinaryDecoder.ReadString(buffer, i);
                (i, partitionsField) = BinaryDecoder.ReadArray<PartitionData>(buffer, i, PartitionDataDecoder.ReadV3);
                if (partitionsField.IsDefault)
                    throw new InvalidDataException("partitionsField was null");
;
                return new(i, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<FetchableTopicResponse> ReadV4([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, topicField) = BinaryDecoder.ReadString(buffer, i);
                (i, partitionsField) = BinaryDecoder.ReadArray<PartitionData>(buffer, i, PartitionDataDecoder.ReadV4);
                if (partitionsField.IsDefault)
                    throw new InvalidDataException("partitionsField was null");
;
                return new(i, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<FetchableTopicResponse> ReadV5([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, topicField) = BinaryDecoder.ReadString(buffer, i);
                (i, partitionsField) = BinaryDecoder.ReadArray<PartitionData>(buffer, i, PartitionDataDecoder.ReadV5);
                if (partitionsField.IsDefault)
                    throw new InvalidDataException("partitionsField was null");
;
                return new(i, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<FetchableTopicResponse> ReadV6([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, topicField) = BinaryDecoder.ReadString(buffer, i);
                (i, partitionsField) = BinaryDecoder.ReadArray<PartitionData>(buffer, i, PartitionDataDecoder.ReadV6);
                if (partitionsField.IsDefault)
                    throw new InvalidDataException("partitionsField was null");
;
                return new(i, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<FetchableTopicResponse> ReadV7([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, topicField) = BinaryDecoder.ReadString(buffer, i);
                (i, partitionsField) = BinaryDecoder.ReadArray<PartitionData>(buffer, i, PartitionDataDecoder.ReadV7);
                if (partitionsField.IsDefault)
                    throw new InvalidDataException("partitionsField was null");
;
                return new(i, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<FetchableTopicResponse> ReadV8([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, topicField) = BinaryDecoder.ReadString(buffer, i);
                (i, partitionsField) = BinaryDecoder.ReadArray<PartitionData>(buffer, i, PartitionDataDecoder.ReadV8);
                if (partitionsField.IsDefault)
                    throw new InvalidDataException("partitionsField was null");
;
                return new(i, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<FetchableTopicResponse> ReadV9([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, topicField) = BinaryDecoder.ReadString(buffer, i);
                (i, partitionsField) = BinaryDecoder.ReadArray<PartitionData>(buffer, i, PartitionDataDecoder.ReadV9);
                if (partitionsField.IsDefault)
                    throw new InvalidDataException("partitionsField was null");
;
                return new(i, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<FetchableTopicResponse> ReadV10([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, topicField) = BinaryDecoder.ReadString(buffer, i);
                (i, partitionsField) = BinaryDecoder.ReadArray<PartitionData>(buffer, i, PartitionDataDecoder.ReadV10);
                if (partitionsField.IsDefault)
                    throw new InvalidDataException("partitionsField was null");
;
                return new(i, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<FetchableTopicResponse> ReadV11([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, topicField) = BinaryDecoder.ReadString(buffer, i);
                (i, partitionsField) = BinaryDecoder.ReadArray<PartitionData>(buffer, i, PartitionDataDecoder.ReadV11);
                if (partitionsField.IsDefault)
                    throw new InvalidDataException("partitionsField was null");
;
                return new(i, new(
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<FetchableTopicResponse> ReadV12([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, topicField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, partitionsField) = BinaryDecoder.ReadCompactArray<PartitionData>(buffer, i, PartitionDataDecoder.ReadV12);
                if (partitionsField.IsDefault)
                    throw new InvalidDataException("partitionsField was null");
;
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
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<FetchableTopicResponse> ReadV13([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, topicIdField) = BinaryDecoder.ReadUuid(buffer, i);
                (i, partitionsField) = BinaryDecoder.ReadCompactArray<PartitionData>(buffer, i, PartitionDataDecoder.ReadV13);
                if (partitionsField.IsDefault)
                    throw new InvalidDataException("partitionsField was null");
;
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
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<FetchableTopicResponse> ReadV14([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, topicIdField) = BinaryDecoder.ReadUuid(buffer, i);
                (i, partitionsField) = BinaryDecoder.ReadCompactArray<PartitionData>(buffer, i, PartitionDataDecoder.ReadV14);
                if (partitionsField.IsDefault)
                    throw new InvalidDataException("partitionsField was null");
;
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
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<FetchableTopicResponse> ReadV15([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, topicIdField) = BinaryDecoder.ReadUuid(buffer, i);
                (i, partitionsField) = BinaryDecoder.ReadCompactArray<PartitionData>(buffer, i, PartitionDataDecoder.ReadV15);
                if (partitionsField.IsDefault)
                    throw new InvalidDataException("partitionsField was null");
;
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
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<FetchableTopicResponse> ReadV16([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var topicField = "";
                var topicIdField = default(Guid);
                var partitionsField = ImmutableArray<PartitionData>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, topicIdField) = BinaryDecoder.ReadUuid(buffer, i);
                (i, partitionsField) = BinaryDecoder.ReadCompactArray<PartitionData>(buffer, i, PartitionDataDecoder.ReadV16);
                if (partitionsField.IsDefault)
                    throw new InvalidDataException("partitionsField was null");
;
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
                    topicField,
                    topicIdField,
                    partitionsField,
                    taggedFields
                ));
            }
            [GeneratedCodeAttribute("kgen", "1.0.0.0")]
            private static class PartitionDataDecoder
            {
                public static DecodeResult<PartitionData> ReadV0([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, recordsField) = BinaryDecoder.ReadRecords(buffer, i);
                    return new(i, new(
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
                public static DecodeResult<PartitionData> ReadV1([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, recordsField) = BinaryDecoder.ReadRecords(buffer, i);
                    return new(i, new(
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
                public static DecodeResult<PartitionData> ReadV2([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, recordsField) = BinaryDecoder.ReadRecords(buffer, i);
                    return new(i, new(
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
                public static DecodeResult<PartitionData> ReadV3([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, recordsField) = BinaryDecoder.ReadRecords(buffer, i);
                    return new(i, new(
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
                public static DecodeResult<PartitionData> ReadV4([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, lastStableOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, abortedTransactionsField) = BinaryDecoder.ReadArray<AbortedTransaction>(buffer, i, AbortedTransactionDecoder.ReadV4);
                    (i, recordsField) = BinaryDecoder.ReadRecords(buffer, i);
                    return new(i, new(
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
                public static DecodeResult<PartitionData> ReadV5([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, lastStableOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, abortedTransactionsField) = BinaryDecoder.ReadArray<AbortedTransaction>(buffer, i, AbortedTransactionDecoder.ReadV5);
                    (i, recordsField) = BinaryDecoder.ReadRecords(buffer, i);
                    return new(i, new(
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
                public static DecodeResult<PartitionData> ReadV6([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, lastStableOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, abortedTransactionsField) = BinaryDecoder.ReadArray<AbortedTransaction>(buffer, i, AbortedTransactionDecoder.ReadV6);
                    (i, recordsField) = BinaryDecoder.ReadRecords(buffer, i);
                    return new(i, new(
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
                public static DecodeResult<PartitionData> ReadV7([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, lastStableOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, abortedTransactionsField) = BinaryDecoder.ReadArray<AbortedTransaction>(buffer, i, AbortedTransactionDecoder.ReadV7);
                    (i, recordsField) = BinaryDecoder.ReadRecords(buffer, i);
                    return new(i, new(
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
                public static DecodeResult<PartitionData> ReadV8([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, lastStableOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, abortedTransactionsField) = BinaryDecoder.ReadArray<AbortedTransaction>(buffer, i, AbortedTransactionDecoder.ReadV8);
                    (i, recordsField) = BinaryDecoder.ReadRecords(buffer, i);
                    return new(i, new(
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
                public static DecodeResult<PartitionData> ReadV9([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, lastStableOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, abortedTransactionsField) = BinaryDecoder.ReadArray<AbortedTransaction>(buffer, i, AbortedTransactionDecoder.ReadV9);
                    (i, recordsField) = BinaryDecoder.ReadRecords(buffer, i);
                    return new(i, new(
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
                public static DecodeResult<PartitionData> ReadV10([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, lastStableOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, abortedTransactionsField) = BinaryDecoder.ReadArray<AbortedTransaction>(buffer, i, AbortedTransactionDecoder.ReadV10);
                    (i, recordsField) = BinaryDecoder.ReadRecords(buffer, i);
                    return new(i, new(
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
                public static DecodeResult<PartitionData> ReadV11([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, lastStableOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, abortedTransactionsField) = BinaryDecoder.ReadArray<AbortedTransaction>(buffer, i, AbortedTransactionDecoder.ReadV11);
                    (i, preferredReadReplicaField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, recordsField) = BinaryDecoder.ReadRecords(buffer, i);
                    return new(i, new(
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
                public static DecodeResult<PartitionData> ReadV12([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, lastStableOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, abortedTransactionsField) = BinaryDecoder.ReadCompactArray<AbortedTransaction>(buffer, i, AbortedTransactionDecoder.ReadV12);
                    (i, preferredReadReplicaField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, recordsField) = BinaryDecoder.ReadCompactRecords(buffer, i);
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
                                    (i, divergingEpochField) = EpochEndOffsetDecoder.ReadV12(buffer, i);
                                    break;
                                case 1:
                                    (i, currentLeaderField) = LeaderIdAndEpochDecoder.ReadV12(buffer, i);
                                    break;
                                case 2:
                                    (i, snapshotIdField) = SnapshotIdDecoder.ReadV12(buffer, i);
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
                public static DecodeResult<PartitionData> ReadV13([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, lastStableOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, abortedTransactionsField) = BinaryDecoder.ReadCompactArray<AbortedTransaction>(buffer, i, AbortedTransactionDecoder.ReadV13);
                    (i, preferredReadReplicaField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, recordsField) = BinaryDecoder.ReadCompactRecords(buffer, i);
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
                                    (i, divergingEpochField) = EpochEndOffsetDecoder.ReadV13(buffer, i);
                                    break;
                                case 1:
                                    (i, currentLeaderField) = LeaderIdAndEpochDecoder.ReadV13(buffer, i);
                                    break;
                                case 2:
                                    (i, snapshotIdField) = SnapshotIdDecoder.ReadV13(buffer, i);
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
                public static DecodeResult<PartitionData> ReadV14([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, lastStableOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, abortedTransactionsField) = BinaryDecoder.ReadCompactArray<AbortedTransaction>(buffer, i, AbortedTransactionDecoder.ReadV14);
                    (i, preferredReadReplicaField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, recordsField) = BinaryDecoder.ReadCompactRecords(buffer, i);
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
                                    (i, divergingEpochField) = EpochEndOffsetDecoder.ReadV14(buffer, i);
                                    break;
                                case 1:
                                    (i, currentLeaderField) = LeaderIdAndEpochDecoder.ReadV14(buffer, i);
                                    break;
                                case 2:
                                    (i, snapshotIdField) = SnapshotIdDecoder.ReadV14(buffer, i);
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
                public static DecodeResult<PartitionData> ReadV15([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, lastStableOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, abortedTransactionsField) = BinaryDecoder.ReadCompactArray<AbortedTransaction>(buffer, i, AbortedTransactionDecoder.ReadV15);
                    (i, preferredReadReplicaField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, recordsField) = BinaryDecoder.ReadCompactRecords(buffer, i);
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
                                    (i, divergingEpochField) = EpochEndOffsetDecoder.ReadV15(buffer, i);
                                    break;
                                case 1:
                                    (i, currentLeaderField) = LeaderIdAndEpochDecoder.ReadV15(buffer, i);
                                    break;
                                case 2:
                                    (i, snapshotIdField) = SnapshotIdDecoder.ReadV15(buffer, i);
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
                public static DecodeResult<PartitionData> ReadV16([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var highWatermarkField = default(long);
                    var lastStableOffsetField = default(long);
                    var logStartOffsetField = default(long);
                    var divergingEpochField = EpochEndOffset.Empty;
                    var currentLeaderField = LeaderIdAndEpoch.Empty;
                    var snapshotIdField = SnapshotId.Empty;
                    var abortedTransactionsField = default(ImmutableArray<AbortedTransaction>);
                    var preferredReadReplicaField = default(int);
                    var recordsField = default(ImmutableArray<IRecords>);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, highWatermarkField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, lastStableOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, logStartOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, abortedTransactionsField) = BinaryDecoder.ReadCompactArray<AbortedTransaction>(buffer, i, AbortedTransactionDecoder.ReadV16);
                    (i, preferredReadReplicaField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, recordsField) = BinaryDecoder.ReadCompactRecords(buffer, i);
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
                                    (i, divergingEpochField) = EpochEndOffsetDecoder.ReadV16(buffer, i);
                                    break;
                                case 1:
                                    (i, currentLeaderField) = LeaderIdAndEpochDecoder.ReadV16(buffer, i);
                                    break;
                                case 2:
                                    (i, snapshotIdField) = SnapshotIdDecoder.ReadV16(buffer, i);
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
                    public static DecodeResult<AbortedTransaction> ReadV0([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(i, new(
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<AbortedTransaction> ReadV1([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(i, new(
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<AbortedTransaction> ReadV2([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(i, new(
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<AbortedTransaction> ReadV3([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(i, new(
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<AbortedTransaction> ReadV4([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (i, producerIdField) = BinaryDecoder.ReadInt64(buffer, i);
                        (i, firstOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                        return new(i, new(
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<AbortedTransaction> ReadV5([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (i, producerIdField) = BinaryDecoder.ReadInt64(buffer, i);
                        (i, firstOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                        return new(i, new(
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<AbortedTransaction> ReadV6([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (i, producerIdField) = BinaryDecoder.ReadInt64(buffer, i);
                        (i, firstOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                        return new(i, new(
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<AbortedTransaction> ReadV7([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (i, producerIdField) = BinaryDecoder.ReadInt64(buffer, i);
                        (i, firstOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                        return new(i, new(
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<AbortedTransaction> ReadV8([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (i, producerIdField) = BinaryDecoder.ReadInt64(buffer, i);
                        (i, firstOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                        return new(i, new(
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<AbortedTransaction> ReadV9([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (i, producerIdField) = BinaryDecoder.ReadInt64(buffer, i);
                        (i, firstOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                        return new(i, new(
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<AbortedTransaction> ReadV10([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (i, producerIdField) = BinaryDecoder.ReadInt64(buffer, i);
                        (i, firstOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                        return new(i, new(
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<AbortedTransaction> ReadV11([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (i, producerIdField) = BinaryDecoder.ReadInt64(buffer, i);
                        (i, firstOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                        return new(i, new(
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<AbortedTransaction> ReadV12([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (i, producerIdField) = BinaryDecoder.ReadInt64(buffer, i);
                        (i, firstOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
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
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<AbortedTransaction> ReadV13([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (i, producerIdField) = BinaryDecoder.ReadInt64(buffer, i);
                        (i, firstOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
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
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<AbortedTransaction> ReadV14([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (i, producerIdField) = BinaryDecoder.ReadInt64(buffer, i);
                        (i, firstOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
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
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<AbortedTransaction> ReadV15([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (i, producerIdField) = BinaryDecoder.ReadInt64(buffer, i);
                        (i, firstOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
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
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<AbortedTransaction> ReadV16([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var producerIdField = default(long);
                        var firstOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (i, producerIdField) = BinaryDecoder.ReadInt64(buffer, i);
                        (i, firstOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
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
                            producerIdField,
                            firstOffsetField,
                            taggedFields
                        ));
                    }
                }
                [GeneratedCodeAttribute("kgen", "1.0.0.0")]
                private static class EpochEndOffsetDecoder
                {
                    public static DecodeResult<EpochEndOffset> ReadV0([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(i, new(
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<EpochEndOffset> ReadV1([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(i, new(
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<EpochEndOffset> ReadV2([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(i, new(
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<EpochEndOffset> ReadV3([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(i, new(
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<EpochEndOffset> ReadV4([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(i, new(
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<EpochEndOffset> ReadV5([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(i, new(
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<EpochEndOffset> ReadV6([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(i, new(
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<EpochEndOffset> ReadV7([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(i, new(
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<EpochEndOffset> ReadV8([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(i, new(
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<EpochEndOffset> ReadV9([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(i, new(
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<EpochEndOffset> ReadV10([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(i, new(
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<EpochEndOffset> ReadV11([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(i, new(
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<EpochEndOffset> ReadV12([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (i, epochField) = BinaryDecoder.ReadInt32(buffer, i);
                        (i, endOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
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
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<EpochEndOffset> ReadV13([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (i, epochField) = BinaryDecoder.ReadInt32(buffer, i);
                        (i, endOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
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
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<EpochEndOffset> ReadV14([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (i, epochField) = BinaryDecoder.ReadInt32(buffer, i);
                        (i, endOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
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
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<EpochEndOffset> ReadV15([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (i, epochField) = BinaryDecoder.ReadInt32(buffer, i);
                        (i, endOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
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
                            epochField,
                            endOffsetField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<EpochEndOffset> ReadV16([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var epochField = default(int);
                        var endOffsetField = default(long);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (i, epochField) = BinaryDecoder.ReadInt32(buffer, i);
                        (i, endOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
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
                            epochField,
                            endOffsetField,
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
                        return new(i, new(
                            leaderIdField,
                            leaderEpochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<LeaderIdAndEpoch> ReadV11([NotNull] in byte[] buffer, in int index)
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
                    public static DecodeResult<LeaderIdAndEpoch> ReadV12([NotNull] in byte[] buffer, in int index)
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
                    public static DecodeResult<LeaderIdAndEpoch> ReadV13([NotNull] in byte[] buffer, in int index)
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
                    public static DecodeResult<LeaderIdAndEpoch> ReadV14([NotNull] in byte[] buffer, in int index)
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
                    public static DecodeResult<LeaderIdAndEpoch> ReadV15([NotNull] in byte[] buffer, in int index)
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
                    public static DecodeResult<LeaderIdAndEpoch> ReadV16([NotNull] in byte[] buffer, in int index)
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
                [GeneratedCodeAttribute("kgen", "1.0.0.0")]
                private static class SnapshotIdDecoder
                {
                    public static DecodeResult<SnapshotId> ReadV0([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (i, endOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                        (i, epochField) = BinaryDecoder.ReadInt32(buffer, i);
                        return new(i, new(
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<SnapshotId> ReadV1([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (i, endOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                        (i, epochField) = BinaryDecoder.ReadInt32(buffer, i);
                        return new(i, new(
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<SnapshotId> ReadV2([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (i, endOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                        (i, epochField) = BinaryDecoder.ReadInt32(buffer, i);
                        return new(i, new(
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<SnapshotId> ReadV3([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (i, endOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                        (i, epochField) = BinaryDecoder.ReadInt32(buffer, i);
                        return new(i, new(
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<SnapshotId> ReadV4([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (i, endOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                        (i, epochField) = BinaryDecoder.ReadInt32(buffer, i);
                        return new(i, new(
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<SnapshotId> ReadV5([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (i, endOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                        (i, epochField) = BinaryDecoder.ReadInt32(buffer, i);
                        return new(i, new(
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<SnapshotId> ReadV6([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (i, endOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                        (i, epochField) = BinaryDecoder.ReadInt32(buffer, i);
                        return new(i, new(
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<SnapshotId> ReadV7([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (i, endOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                        (i, epochField) = BinaryDecoder.ReadInt32(buffer, i);
                        return new(i, new(
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<SnapshotId> ReadV8([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (i, endOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                        (i, epochField) = BinaryDecoder.ReadInt32(buffer, i);
                        return new(i, new(
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<SnapshotId> ReadV9([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (i, endOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                        (i, epochField) = BinaryDecoder.ReadInt32(buffer, i);
                        return new(i, new(
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<SnapshotId> ReadV10([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (i, endOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                        (i, epochField) = BinaryDecoder.ReadInt32(buffer, i);
                        return new(i, new(
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<SnapshotId> ReadV11([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (i, endOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                        (i, epochField) = BinaryDecoder.ReadInt32(buffer, i);
                        return new(i, new(
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<SnapshotId> ReadV12([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (i, endOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                        (i, epochField) = BinaryDecoder.ReadInt32(buffer, i);
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
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<SnapshotId> ReadV13([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (i, endOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                        (i, epochField) = BinaryDecoder.ReadInt32(buffer, i);
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
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<SnapshotId> ReadV14([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (i, endOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                        (i, epochField) = BinaryDecoder.ReadInt32(buffer, i);
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
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<SnapshotId> ReadV15([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (i, endOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                        (i, epochField) = BinaryDecoder.ReadInt32(buffer, i);
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
                            endOffsetField,
                            epochField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<SnapshotId> ReadV16([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var endOffsetField = default(long);
                        var epochField = default(int);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (i, endOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                        (i, epochField) = BinaryDecoder.ReadInt32(buffer, i);
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
                return new(i, new(
                    nodeIdField,
                    hostField,
                    portField,
                    rackField,
                    taggedFields
                ));
            }
            public static DecodeResult<NodeEndpoint> ReadV11([NotNull] in byte[] buffer, in int index)
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
            public static DecodeResult<NodeEndpoint> ReadV12([NotNull] in byte[] buffer, in int index)
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
            public static DecodeResult<NodeEndpoint> ReadV13([NotNull] in byte[] buffer, in int index)
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
            public static DecodeResult<NodeEndpoint> ReadV14([NotNull] in byte[] buffer, in int index)
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
            public static DecodeResult<NodeEndpoint> ReadV15([NotNull] in byte[] buffer, in int index)
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
            public static DecodeResult<NodeEndpoint> ReadV16([NotNull] in byte[] buffer, in int index)
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
    }
}
