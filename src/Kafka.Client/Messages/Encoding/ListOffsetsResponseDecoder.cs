using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using ListOffsetsPartitionResponse = Kafka.Client.Messages.ListOffsetsResponseData.ListOffsetsTopicResponse.ListOffsetsPartitionResponse;
using ListOffsetsTopicResponse = Kafka.Client.Messages.ListOffsetsResponseData.ListOffsetsTopicResponse;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    public class ListOffsetsResponseDecoder : 
        ResponseDecoder<ResponseHeaderData, ListOffsetsResponseData>
    {
        public ListOffsetsResponseDecoder() :
            base(
                ApiKey.ListOffsets,
                new(0, 8),
                new(6, 32767),
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
        protected override DecodeDelegate<ListOffsetsResponseData> GetMessageDecoder(short apiVersion) =>
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
        private static DecodeResult<ListOffsetsResponseData> ReadV0(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<ListOffsetsTopicResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _topicsField_) = BinaryDecoder.ReadArray<ListOffsetsTopicResponse>(buffer, index, ListOffsetsTopicResponseDecoder.ReadV0);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return new(index, new(
                throttleTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static DecodeResult<ListOffsetsResponseData> ReadV1(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<ListOffsetsTopicResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _topicsField_) = BinaryDecoder.ReadArray<ListOffsetsTopicResponse>(buffer, index, ListOffsetsTopicResponseDecoder.ReadV1);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return new(index, new(
                throttleTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static DecodeResult<ListOffsetsResponseData> ReadV2(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<ListOffsetsTopicResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<ListOffsetsTopicResponse>(buffer, index, ListOffsetsTopicResponseDecoder.ReadV2);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return new(index, new(
                throttleTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static DecodeResult<ListOffsetsResponseData> ReadV3(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<ListOffsetsTopicResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<ListOffsetsTopicResponse>(buffer, index, ListOffsetsTopicResponseDecoder.ReadV3);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return new(index, new(
                throttleTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static DecodeResult<ListOffsetsResponseData> ReadV4(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<ListOffsetsTopicResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<ListOffsetsTopicResponse>(buffer, index, ListOffsetsTopicResponseDecoder.ReadV4);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return new(index, new(
                throttleTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static DecodeResult<ListOffsetsResponseData> ReadV5(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<ListOffsetsTopicResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<ListOffsetsTopicResponse>(buffer, index, ListOffsetsTopicResponseDecoder.ReadV5);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return new(index, new(
                throttleTimeMsField,
                topicsField,
                taggedFields
            ));
        }
        private static DecodeResult<ListOffsetsResponseData> ReadV6(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<ListOffsetsTopicResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadCompactArray<ListOffsetsTopicResponse>(buffer, index, ListOffsetsTopicResponseDecoder.ReadV6);
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
                topicsField,
                taggedFields
            ));
        }
        private static DecodeResult<ListOffsetsResponseData> ReadV7(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<ListOffsetsTopicResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadCompactArray<ListOffsetsTopicResponse>(buffer, index, ListOffsetsTopicResponseDecoder.ReadV7);
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
                topicsField,
                taggedFields
            ));
        }
        private static DecodeResult<ListOffsetsResponseData> ReadV8(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<ListOffsetsTopicResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadCompactArray<ListOffsetsTopicResponse>(buffer, index, ListOffsetsTopicResponseDecoder.ReadV8);
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
                topicsField,
                taggedFields
            ));
        }
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class ListOffsetsTopicResponseDecoder
        {
            public static DecodeResult<ListOffsetsTopicResponse> ReadV0(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<ListOffsetsPartitionResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<ListOffsetsPartitionResponse>(buffer, index, ListOffsetsPartitionResponseDecoder.ReadV0);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return new(index, new(
                    nameField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<ListOffsetsTopicResponse> ReadV1(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<ListOffsetsPartitionResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<ListOffsetsPartitionResponse>(buffer, index, ListOffsetsPartitionResponseDecoder.ReadV1);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return new(index, new(
                    nameField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<ListOffsetsTopicResponse> ReadV2(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<ListOffsetsPartitionResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<ListOffsetsPartitionResponse>(buffer, index, ListOffsetsPartitionResponseDecoder.ReadV2);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return new(index, new(
                    nameField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<ListOffsetsTopicResponse> ReadV3(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<ListOffsetsPartitionResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<ListOffsetsPartitionResponse>(buffer, index, ListOffsetsPartitionResponseDecoder.ReadV3);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return new(index, new(
                    nameField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<ListOffsetsTopicResponse> ReadV4(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<ListOffsetsPartitionResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<ListOffsetsPartitionResponse>(buffer, index, ListOffsetsPartitionResponseDecoder.ReadV4);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return new(index, new(
                    nameField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<ListOffsetsTopicResponse> ReadV5(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<ListOffsetsPartitionResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<ListOffsetsPartitionResponse>(buffer, index, ListOffsetsPartitionResponseDecoder.ReadV5);
                if (_partitionsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Partitions'");
                else
                    partitionsField = _partitionsField_.Value;
                return new(index, new(
                    nameField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<ListOffsetsTopicResponse> ReadV6(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<ListOffsetsPartitionResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadCompactArray<ListOffsetsPartitionResponse>(buffer, index, ListOffsetsPartitionResponseDecoder.ReadV6);
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
                    nameField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<ListOffsetsTopicResponse> ReadV7(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<ListOffsetsPartitionResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadCompactArray<ListOffsetsPartitionResponse>(buffer, index, ListOffsetsPartitionResponseDecoder.ReadV7);
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
                    nameField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<ListOffsetsTopicResponse> ReadV8(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<ListOffsetsPartitionResponse>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadCompactArray<ListOffsetsPartitionResponse>(buffer, index, ListOffsetsPartitionResponseDecoder.ReadV8);
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
                    nameField,
                    partitionsField,
                    taggedFields
                ));
            }
            [GeneratedCodeAttribute("kgen", "1.0.0.0")]
            private static class ListOffsetsPartitionResponseDecoder
            {
                public static DecodeResult<ListOffsetsPartitionResponse> ReadV0(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = default(long);
                    var offsetField = default(long);
                    var leaderEpochField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, var _oldStyleOffsetsField_) = BinaryDecoder.ReadArray<long>(buffer, index, BinaryDecoder.ReadInt64);
                    if (_oldStyleOffsetsField_ == null)
                        throw new NullReferenceException("Null not allowed for 'OldStyleOffsets'");
                    else
                        oldStyleOffsetsField = _oldStyleOffsetsField_.Value;
                    return new(index, new(
                        partitionIndexField,
                        errorCodeField,
                        oldStyleOffsetsField,
                        timestampField,
                        offsetField,
                        leaderEpochField,
                        taggedFields
                    ));
                }
                public static DecodeResult<ListOffsetsPartitionResponse> ReadV1(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = default(long);
                    var offsetField = default(long);
                    var leaderEpochField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, timestampField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, offsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    return new(index, new(
                        partitionIndexField,
                        errorCodeField,
                        oldStyleOffsetsField,
                        timestampField,
                        offsetField,
                        leaderEpochField,
                        taggedFields
                    ));
                }
                public static DecodeResult<ListOffsetsPartitionResponse> ReadV2(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = default(long);
                    var offsetField = default(long);
                    var leaderEpochField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, timestampField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, offsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    return new(index, new(
                        partitionIndexField,
                        errorCodeField,
                        oldStyleOffsetsField,
                        timestampField,
                        offsetField,
                        leaderEpochField,
                        taggedFields
                    ));
                }
                public static DecodeResult<ListOffsetsPartitionResponse> ReadV3(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = default(long);
                    var offsetField = default(long);
                    var leaderEpochField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, timestampField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, offsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    return new(index, new(
                        partitionIndexField,
                        errorCodeField,
                        oldStyleOffsetsField,
                        timestampField,
                        offsetField,
                        leaderEpochField,
                        taggedFields
                    ));
                }
                public static DecodeResult<ListOffsetsPartitionResponse> ReadV4(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = default(long);
                    var offsetField = default(long);
                    var leaderEpochField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, timestampField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, offsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, leaderEpochField) = BinaryDecoder.ReadInt32(buffer, index);
                    return new(index, new(
                        partitionIndexField,
                        errorCodeField,
                        oldStyleOffsetsField,
                        timestampField,
                        offsetField,
                        leaderEpochField,
                        taggedFields
                    ));
                }
                public static DecodeResult<ListOffsetsPartitionResponse> ReadV5(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = default(long);
                    var offsetField = default(long);
                    var leaderEpochField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, timestampField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, offsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, leaderEpochField) = BinaryDecoder.ReadInt32(buffer, index);
                    return new(index, new(
                        partitionIndexField,
                        errorCodeField,
                        oldStyleOffsetsField,
                        timestampField,
                        offsetField,
                        leaderEpochField,
                        taggedFields
                    ));
                }
                public static DecodeResult<ListOffsetsPartitionResponse> ReadV6(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = default(long);
                    var offsetField = default(long);
                    var leaderEpochField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, timestampField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, offsetField) = BinaryDecoder.ReadInt64(buffer, index);
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
                        partitionIndexField,
                        errorCodeField,
                        oldStyleOffsetsField,
                        timestampField,
                        offsetField,
                        leaderEpochField,
                        taggedFields
                    ));
                }
                public static DecodeResult<ListOffsetsPartitionResponse> ReadV7(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = default(long);
                    var offsetField = default(long);
                    var leaderEpochField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, timestampField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, offsetField) = BinaryDecoder.ReadInt64(buffer, index);
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
                        partitionIndexField,
                        errorCodeField,
                        oldStyleOffsetsField,
                        timestampField,
                        offsetField,
                        leaderEpochField,
                        taggedFields
                    ));
                }
                public static DecodeResult<ListOffsetsPartitionResponse> ReadV8(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var oldStyleOffsetsField = ImmutableArray<long>.Empty;
                    var timestampField = default(long);
                    var offsetField = default(long);
                    var leaderEpochField = default(int);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    (index, timestampField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, offsetField) = BinaryDecoder.ReadInt64(buffer, index);
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
