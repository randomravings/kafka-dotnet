using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using ListOffsetsPartitionResponse = Kafka.Client.Messages.ListOffsetsResponseData.ListOffsetsTopicResponse.ListOffsetsPartitionResponse;
using ListOffsetsTopicResponse = Kafka.Client.Messages.ListOffsetsResponseData.ListOffsetsTopicResponse;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    internal class ListOffsetsResponseDecoder : 
        ResponseDecoder<ResponseHeaderData, ListOffsetsResponseData>
    {
        internal ListOffsetsResponseDecoder() :
            base(
                ApiKey.ListOffsets,
                new(0, 8),
                new(6, 32767),
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
        protected override DecodeValue<ListOffsetsResponseData> GetMessageDecoder(short apiVersion) =>
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
                _ => throw new NotSupportedException()
            }
        ;
        private static DecodeResult<ListOffsetsResponseData> ReadV0([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<ListOffsetsTopicResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, var _topicsField_) = BinaryDecoder.ReadArray<ListOffsetsTopicResponse>(buffer, i, ListOffsetsTopicResponseDecoder.ReadV0);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return new(i, new(
                throttleTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static DecodeResult<ListOffsetsResponseData> ReadV1([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<ListOffsetsTopicResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, var _topicsField_) = BinaryDecoder.ReadArray<ListOffsetsTopicResponse>(buffer, i, ListOffsetsTopicResponseDecoder.ReadV1);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return new(i, new(
                throttleTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static DecodeResult<ListOffsetsResponseData> ReadV2([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<ListOffsetsTopicResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var _topicsField_) = BinaryDecoder.ReadArray<ListOffsetsTopicResponse>(buffer, i, ListOffsetsTopicResponseDecoder.ReadV2);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return new(i, new(
                throttleTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static DecodeResult<ListOffsetsResponseData> ReadV3([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<ListOffsetsTopicResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var _topicsField_) = BinaryDecoder.ReadArray<ListOffsetsTopicResponse>(buffer, i, ListOffsetsTopicResponseDecoder.ReadV3);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return new(i, new(
                throttleTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static DecodeResult<ListOffsetsResponseData> ReadV4([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<ListOffsetsTopicResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var _topicsField_) = BinaryDecoder.ReadArray<ListOffsetsTopicResponse>(buffer, i, ListOffsetsTopicResponseDecoder.ReadV4);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return new(i, new(
                throttleTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static DecodeResult<ListOffsetsResponseData> ReadV5([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<ListOffsetsTopicResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var _topicsField_) = BinaryDecoder.ReadArray<ListOffsetsTopicResponse>(buffer, i, ListOffsetsTopicResponseDecoder.ReadV5);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return new(i, new(
                throttleTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static DecodeResult<ListOffsetsResponseData> ReadV6([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<ListOffsetsTopicResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var _topicsField_) = BinaryDecoder.ReadCompactArray<ListOffsetsTopicResponse>(buffer, i, ListOffsetsTopicResponseDecoder.ReadV6);
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
                topicsField,
                taggedFields
            ));
        }
        private static DecodeResult<ListOffsetsResponseData> ReadV7([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<ListOffsetsTopicResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var _topicsField_) = BinaryDecoder.ReadCompactArray<ListOffsetsTopicResponse>(buffer, i, ListOffsetsTopicResponseDecoder.ReadV7);
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
                topicsField,
                taggedFields
            ));
        }
        private static DecodeResult<ListOffsetsResponseData> ReadV8([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<ListOffsetsTopicResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var _topicsField_) = BinaryDecoder.ReadCompactArray<ListOffsetsTopicResponse>(buffer, i, ListOffsetsTopicResponseDecoder.ReadV8);
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
                topicsField,
                taggedFields
            ));
        }
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class ListOffsetsTopicResponseDecoder
        {
            public static DecodeResult<ListOffsetsTopicResponse> ReadV0([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var partitionsField = ImmutableArray<ListOffsetsPartitionResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, var _partitionsField_) = BinaryDecoder.ReadArray<ListOffsetsPartitionResponse>(buffer, i, ListOffsetsPartitionResponseDecoder.ReadV0);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return new(i, new(
                    nameField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<ListOffsetsTopicResponse> ReadV1([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var partitionsField = ImmutableArray<ListOffsetsPartitionResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, var _partitionsField_) = BinaryDecoder.ReadArray<ListOffsetsPartitionResponse>(buffer, i, ListOffsetsPartitionResponseDecoder.ReadV1);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return new(i, new(
                    nameField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<ListOffsetsTopicResponse> ReadV2([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var partitionsField = ImmutableArray<ListOffsetsPartitionResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, var _partitionsField_) = BinaryDecoder.ReadArray<ListOffsetsPartitionResponse>(buffer, i, ListOffsetsPartitionResponseDecoder.ReadV2);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return new(i, new(
                    nameField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<ListOffsetsTopicResponse> ReadV3([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var partitionsField = ImmutableArray<ListOffsetsPartitionResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, var _partitionsField_) = BinaryDecoder.ReadArray<ListOffsetsPartitionResponse>(buffer, i, ListOffsetsPartitionResponseDecoder.ReadV3);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return new(i, new(
                    nameField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<ListOffsetsTopicResponse> ReadV4([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var partitionsField = ImmutableArray<ListOffsetsPartitionResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, var _partitionsField_) = BinaryDecoder.ReadArray<ListOffsetsPartitionResponse>(buffer, i, ListOffsetsPartitionResponseDecoder.ReadV4);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return new(i, new(
                    nameField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<ListOffsetsTopicResponse> ReadV5([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var partitionsField = ImmutableArray<ListOffsetsPartitionResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, var _partitionsField_) = BinaryDecoder.ReadArray<ListOffsetsPartitionResponse>(buffer, i, ListOffsetsPartitionResponseDecoder.ReadV5);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return new(i, new(
                    nameField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<ListOffsetsTopicResponse> ReadV6([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var partitionsField = ImmutableArray<ListOffsetsPartitionResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, var _partitionsField_) = BinaryDecoder.ReadCompactArray<ListOffsetsPartitionResponse>(buffer, i, ListOffsetsPartitionResponseDecoder.ReadV6);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
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
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<ListOffsetsTopicResponse> ReadV7([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var partitionsField = ImmutableArray<ListOffsetsPartitionResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, var _partitionsField_) = BinaryDecoder.ReadCompactArray<ListOffsetsPartitionResponse>(buffer, i, ListOffsetsPartitionResponseDecoder.ReadV7);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
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
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<ListOffsetsTopicResponse> ReadV8([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var partitionsField = ImmutableArray<ListOffsetsPartitionResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, var _partitionsField_) = BinaryDecoder.ReadCompactArray<ListOffsetsPartitionResponse>(buffer, i, ListOffsetsPartitionResponseDecoder.ReadV8);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
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
                    partitionsField,
                    taggedFields
                ));
            }
            [GeneratedCodeAttribute("kgen", "1.0.0.0")]
            private static class ListOffsetsPartitionResponseDecoder
            {
                public static DecodeResult<ListOffsetsPartitionResponse> ReadV0([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = default(long);
                    var offsetField = default(long);
                    var leaderEpochField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, var _oldStyleOffsetsField_) = BinaryDecoder.ReadArray<long>(buffer, i, BinaryDecoder.ReadInt64);
                    if (_oldStyleOffsetsField_ == null)
                        throw new NullReferenceException("Null not allowed for 'OldStyleOffsets'");
                    else
                        oldStyleOffsetsField = _oldStyleOffsetsField_.Value;
                    return new(i, new(
                        partitionIndexField,
                        errorCodeField,
                        oldStyleOffsetsField,
                        timestampField,
                        offsetField,
                        leaderEpochField,
                        taggedFields
                    ));
                }
                public static DecodeResult<ListOffsetsPartitionResponse> ReadV1([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = default(long);
                    var offsetField = default(long);
                    var leaderEpochField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, timestampField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, offsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    return new(i, new(
                        partitionIndexField,
                        errorCodeField,
                        oldStyleOffsetsField,
                        timestampField,
                        offsetField,
                        leaderEpochField,
                        taggedFields
                    ));
                }
                public static DecodeResult<ListOffsetsPartitionResponse> ReadV2([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = default(long);
                    var offsetField = default(long);
                    var leaderEpochField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, timestampField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, offsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    return new(i, new(
                        partitionIndexField,
                        errorCodeField,
                        oldStyleOffsetsField,
                        timestampField,
                        offsetField,
                        leaderEpochField,
                        taggedFields
                    ));
                }
                public static DecodeResult<ListOffsetsPartitionResponse> ReadV3([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = default(long);
                    var offsetField = default(long);
                    var leaderEpochField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, timestampField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, offsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    return new(i, new(
                        partitionIndexField,
                        errorCodeField,
                        oldStyleOffsetsField,
                        timestampField,
                        offsetField,
                        leaderEpochField,
                        taggedFields
                    ));
                }
                public static DecodeResult<ListOffsetsPartitionResponse> ReadV4([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = default(long);
                    var offsetField = default(long);
                    var leaderEpochField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, timestampField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, offsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, leaderEpochField) = BinaryDecoder.ReadInt32(buffer, i);
                    return new(i, new(
                        partitionIndexField,
                        errorCodeField,
                        oldStyleOffsetsField,
                        timestampField,
                        offsetField,
                        leaderEpochField,
                        taggedFields
                    ));
                }
                public static DecodeResult<ListOffsetsPartitionResponse> ReadV5([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = default(long);
                    var offsetField = default(long);
                    var leaderEpochField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, timestampField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, offsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, leaderEpochField) = BinaryDecoder.ReadInt32(buffer, i);
                    return new(i, new(
                        partitionIndexField,
                        errorCodeField,
                        oldStyleOffsetsField,
                        timestampField,
                        offsetField,
                        leaderEpochField,
                        taggedFields
                    ));
                }
                public static DecodeResult<ListOffsetsPartitionResponse> ReadV6([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = default(long);
                    var offsetField = default(long);
                    var leaderEpochField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, timestampField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, offsetField) = BinaryDecoder.ReadInt64(buffer, i);
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
                        partitionIndexField,
                        errorCodeField,
                        oldStyleOffsetsField,
                        timestampField,
                        offsetField,
                        leaderEpochField,
                        taggedFields
                    ));
                }
                public static DecodeResult<ListOffsetsPartitionResponse> ReadV7([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = default(long);
                    var offsetField = default(long);
                    var leaderEpochField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, timestampField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, offsetField) = BinaryDecoder.ReadInt64(buffer, i);
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
                        partitionIndexField,
                        errorCodeField,
                        oldStyleOffsetsField,
                        timestampField,
                        offsetField,
                        leaderEpochField,
                        taggedFields
                    ));
                }
                public static DecodeResult<ListOffsetsPartitionResponse> ReadV8([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = default(long);
                    var offsetField = default(long);
                    var leaderEpochField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    (i, timestampField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, offsetField) = BinaryDecoder.ReadInt64(buffer, i);
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
                        partitionIndexField,
                        errorCodeField,
                        oldStyleOffsetsField,
                        timestampField,
                        offsetField,
                        leaderEpochField,
                        taggedFields
                    ));
                }
            }
        }
    }
}
