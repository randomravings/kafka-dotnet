using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using OffsetCommitResponsePartition = Kafka.Client.Messages.OffsetCommitResponseData.OffsetCommitResponseTopic.OffsetCommitResponsePartition;
using OffsetCommitResponseTopic = Kafka.Client.Messages.OffsetCommitResponseData.OffsetCommitResponseTopic;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    internal class OffsetCommitResponseDecoder : 
        ResponseDecoder<ResponseHeaderData, OffsetCommitResponseData>
    {
        internal OffsetCommitResponseDecoder() :
            base(
                ApiKey.OffsetCommit,
                new(0, 9),
                new(8, 32767),
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
        protected override DecodeValue<OffsetCommitResponseData> GetMessageDecoder(short apiVersion) =>
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
                _ => throw new NotSupportedException()
            }
        ;
        private static DecodeResult<OffsetCommitResponseData> ReadV0([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<OffsetCommitResponseTopic>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, var _topicsField_) = BinaryDecoder.ReadArray<OffsetCommitResponseTopic>(buffer, i, OffsetCommitResponseTopicDecoder.ReadV0);
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
        private static DecodeResult<OffsetCommitResponseData> ReadV1([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<OffsetCommitResponseTopic>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, var _topicsField_) = BinaryDecoder.ReadArray<OffsetCommitResponseTopic>(buffer, i, OffsetCommitResponseTopicDecoder.ReadV1);
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
        private static DecodeResult<OffsetCommitResponseData> ReadV2([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<OffsetCommitResponseTopic>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, var _topicsField_) = BinaryDecoder.ReadArray<OffsetCommitResponseTopic>(buffer, i, OffsetCommitResponseTopicDecoder.ReadV2);
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
        private static DecodeResult<OffsetCommitResponseData> ReadV3([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<OffsetCommitResponseTopic>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var _topicsField_) = BinaryDecoder.ReadArray<OffsetCommitResponseTopic>(buffer, i, OffsetCommitResponseTopicDecoder.ReadV3);
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
        private static DecodeResult<OffsetCommitResponseData> ReadV4([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<OffsetCommitResponseTopic>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var _topicsField_) = BinaryDecoder.ReadArray<OffsetCommitResponseTopic>(buffer, i, OffsetCommitResponseTopicDecoder.ReadV4);
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
        private static DecodeResult<OffsetCommitResponseData> ReadV5([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<OffsetCommitResponseTopic>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var _topicsField_) = BinaryDecoder.ReadArray<OffsetCommitResponseTopic>(buffer, i, OffsetCommitResponseTopicDecoder.ReadV5);
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
        private static DecodeResult<OffsetCommitResponseData> ReadV6([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<OffsetCommitResponseTopic>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var _topicsField_) = BinaryDecoder.ReadArray<OffsetCommitResponseTopic>(buffer, i, OffsetCommitResponseTopicDecoder.ReadV6);
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
        private static DecodeResult<OffsetCommitResponseData> ReadV7([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<OffsetCommitResponseTopic>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var _topicsField_) = BinaryDecoder.ReadArray<OffsetCommitResponseTopic>(buffer, i, OffsetCommitResponseTopicDecoder.ReadV7);
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
        private static DecodeResult<OffsetCommitResponseData> ReadV8([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<OffsetCommitResponseTopic>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var _topicsField_) = BinaryDecoder.ReadCompactArray<OffsetCommitResponseTopic>(buffer, i, OffsetCommitResponseTopicDecoder.ReadV8);
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
        private static DecodeResult<OffsetCommitResponseData> ReadV9([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<OffsetCommitResponseTopic>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, var _topicsField_) = BinaryDecoder.ReadCompactArray<OffsetCommitResponseTopic>(buffer, i, OffsetCommitResponseTopicDecoder.ReadV9);
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
        private static class OffsetCommitResponseTopicDecoder
        {
            public static DecodeResult<OffsetCommitResponseTopic> ReadV0([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetCommitResponsePartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, var _partitionsField_) = BinaryDecoder.ReadArray<OffsetCommitResponsePartition>(buffer, i, OffsetCommitResponsePartitionDecoder.ReadV0);
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
            public static DecodeResult<OffsetCommitResponseTopic> ReadV1([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetCommitResponsePartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, var _partitionsField_) = BinaryDecoder.ReadArray<OffsetCommitResponsePartition>(buffer, i, OffsetCommitResponsePartitionDecoder.ReadV1);
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
            public static DecodeResult<OffsetCommitResponseTopic> ReadV2([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetCommitResponsePartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, var _partitionsField_) = BinaryDecoder.ReadArray<OffsetCommitResponsePartition>(buffer, i, OffsetCommitResponsePartitionDecoder.ReadV2);
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
            public static DecodeResult<OffsetCommitResponseTopic> ReadV3([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetCommitResponsePartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, var _partitionsField_) = BinaryDecoder.ReadArray<OffsetCommitResponsePartition>(buffer, i, OffsetCommitResponsePartitionDecoder.ReadV3);
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
            public static DecodeResult<OffsetCommitResponseTopic> ReadV4([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetCommitResponsePartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, var _partitionsField_) = BinaryDecoder.ReadArray<OffsetCommitResponsePartition>(buffer, i, OffsetCommitResponsePartitionDecoder.ReadV4);
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
            public static DecodeResult<OffsetCommitResponseTopic> ReadV5([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetCommitResponsePartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, var _partitionsField_) = BinaryDecoder.ReadArray<OffsetCommitResponsePartition>(buffer, i, OffsetCommitResponsePartitionDecoder.ReadV5);
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
            public static DecodeResult<OffsetCommitResponseTopic> ReadV6([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetCommitResponsePartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, var _partitionsField_) = BinaryDecoder.ReadArray<OffsetCommitResponsePartition>(buffer, i, OffsetCommitResponsePartitionDecoder.ReadV6);
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
            public static DecodeResult<OffsetCommitResponseTopic> ReadV7([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetCommitResponsePartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, var _partitionsField_) = BinaryDecoder.ReadArray<OffsetCommitResponsePartition>(buffer, i, OffsetCommitResponsePartitionDecoder.ReadV7);
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
            public static DecodeResult<OffsetCommitResponseTopic> ReadV8([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetCommitResponsePartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, var _partitionsField_) = BinaryDecoder.ReadCompactArray<OffsetCommitResponsePartition>(buffer, i, OffsetCommitResponsePartitionDecoder.ReadV8);
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
            public static DecodeResult<OffsetCommitResponseTopic> ReadV9([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetCommitResponsePartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, var _partitionsField_) = BinaryDecoder.ReadCompactArray<OffsetCommitResponsePartition>(buffer, i, OffsetCommitResponsePartitionDecoder.ReadV9);
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
            private static class OffsetCommitResponsePartitionDecoder
            {
                public static DecodeResult<OffsetCommitResponsePartition> ReadV0([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    return new(i, new(
                        partitionIndexField,
                        errorCodeField,
                        taggedFields
                    ));
                }
                public static DecodeResult<OffsetCommitResponsePartition> ReadV1([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    return new(i, new(
                        partitionIndexField,
                        errorCodeField,
                        taggedFields
                    ));
                }
                public static DecodeResult<OffsetCommitResponsePartition> ReadV2([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    return new(i, new(
                        partitionIndexField,
                        errorCodeField,
                        taggedFields
                    ));
                }
                public static DecodeResult<OffsetCommitResponsePartition> ReadV3([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    return new(i, new(
                        partitionIndexField,
                        errorCodeField,
                        taggedFields
                    ));
                }
                public static DecodeResult<OffsetCommitResponsePartition> ReadV4([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    return new(i, new(
                        partitionIndexField,
                        errorCodeField,
                        taggedFields
                    ));
                }
                public static DecodeResult<OffsetCommitResponsePartition> ReadV5([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    return new(i, new(
                        partitionIndexField,
                        errorCodeField,
                        taggedFields
                    ));
                }
                public static DecodeResult<OffsetCommitResponsePartition> ReadV6([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    return new(i, new(
                        partitionIndexField,
                        errorCodeField,
                        taggedFields
                    ));
                }
                public static DecodeResult<OffsetCommitResponsePartition> ReadV7([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    return new(i, new(
                        partitionIndexField,
                        errorCodeField,
                        taggedFields
                    ));
                }
                public static DecodeResult<OffsetCommitResponsePartition> ReadV8([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
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
                        taggedFields
                    ));
                }
                public static DecodeResult<OffsetCommitResponsePartition> ReadV9([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
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
                        taggedFields
                    ));
                }
            }
        }
    }
}
