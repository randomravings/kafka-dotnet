using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using OffsetFetchResponseTopic = Kafka.Client.Messages.OffsetFetchResponseData.OffsetFetchResponseTopic;
using OffsetFetchResponsePartitions = Kafka.Client.Messages.OffsetFetchResponseData.OffsetFetchResponseGroup.OffsetFetchResponseTopics.OffsetFetchResponsePartitions;
using OffsetFetchResponseTopics = Kafka.Client.Messages.OffsetFetchResponseData.OffsetFetchResponseGroup.OffsetFetchResponseTopics;
using OffsetFetchResponsePartition = Kafka.Client.Messages.OffsetFetchResponseData.OffsetFetchResponseTopic.OffsetFetchResponsePartition;
using OffsetFetchResponseGroup = Kafka.Client.Messages.OffsetFetchResponseData.OffsetFetchResponseGroup;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    public class OffsetFetchResponseDecoder : 
        ResponseDecoder<ResponseHeaderData, OffsetFetchResponseData>
    {
        public OffsetFetchResponseDecoder() :
            base(
                ApiKey.OffsetFetch,
                new(0, 9),
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
        protected override DecodeDelegate<OffsetFetchResponseData> GetMessageDecoder(short apiVersion) =>
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
        private static DecodeResult<OffsetFetchResponseData> ReadV0(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<OffsetFetchResponseTopic>.Empty;
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _topicsField_) = BinaryDecoder.ReadArray<OffsetFetchResponseTopic>(buffer, index, OffsetFetchResponseTopicDecoder.ReadV0);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return new(index, new(
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField,
                taggedFields
            ));
        }
        private static DecodeResult<OffsetFetchResponseData> ReadV1(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<OffsetFetchResponseTopic>.Empty;
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _topicsField_) = BinaryDecoder.ReadArray<OffsetFetchResponseTopic>(buffer, index, OffsetFetchResponseTopicDecoder.ReadV1);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            return new(index, new(
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField,
                taggedFields
            ));
        }
        private static DecodeResult<OffsetFetchResponseData> ReadV2(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<OffsetFetchResponseTopic>.Empty;
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, var _topicsField_) = BinaryDecoder.ReadArray<OffsetFetchResponseTopic>(buffer, index, OffsetFetchResponseTopicDecoder.ReadV2);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            return new(index, new(
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField,
                taggedFields
            ));
        }
        private static DecodeResult<OffsetFetchResponseData> ReadV3(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<OffsetFetchResponseTopic>.Empty;
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<OffsetFetchResponseTopic>(buffer, index, OffsetFetchResponseTopicDecoder.ReadV3);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            return new(index, new(
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField,
                taggedFields
            ));
        }
        private static DecodeResult<OffsetFetchResponseData> ReadV4(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<OffsetFetchResponseTopic>.Empty;
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<OffsetFetchResponseTopic>(buffer, index, OffsetFetchResponseTopicDecoder.ReadV4);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            return new(index, new(
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField,
                taggedFields
            ));
        }
        private static DecodeResult<OffsetFetchResponseData> ReadV5(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<OffsetFetchResponseTopic>.Empty;
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadArray<OffsetFetchResponseTopic>(buffer, index, OffsetFetchResponseTopicDecoder.ReadV5);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            return new(index, new(
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField,
                taggedFields
            ));
        }
        private static DecodeResult<OffsetFetchResponseData> ReadV6(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<OffsetFetchResponseTopic>.Empty;
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadCompactArray<OffsetFetchResponseTopic>(buffer, index, OffsetFetchResponseTopicDecoder.ReadV6);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
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
                errorCodeField,
                groupsField,
                taggedFields
            ));
        }
        private static DecodeResult<OffsetFetchResponseData> ReadV7(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<OffsetFetchResponseTopic>.Empty;
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _topicsField_) = BinaryDecoder.ReadCompactArray<OffsetFetchResponseTopic>(buffer, index, OffsetFetchResponseTopicDecoder.ReadV7);
            if (_topicsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Topics'");
            else
                topicsField = _topicsField_.Value;
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
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
                errorCodeField,
                groupsField,
                taggedFields
            ));
        }
        private static DecodeResult<OffsetFetchResponseData> ReadV8(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<OffsetFetchResponseTopic>.Empty;
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _groupsField_) = BinaryDecoder.ReadCompactArray<OffsetFetchResponseGroup>(buffer, index, OffsetFetchResponseGroupDecoder.ReadV8);
            if (_groupsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Groups'");
            else
                groupsField = _groupsField_.Value;
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
                errorCodeField,
                groupsField,
                taggedFields
            ));
        }
        private static DecodeResult<OffsetFetchResponseData> ReadV9(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<OffsetFetchResponseTopic>.Empty;
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, var _groupsField_) = BinaryDecoder.ReadCompactArray<OffsetFetchResponseGroup>(buffer, index, OffsetFetchResponseGroupDecoder.ReadV9);
            if (_groupsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Groups'");
            else
                groupsField = _groupsField_.Value;
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
                errorCodeField,
                groupsField,
                taggedFields
            ));
        }
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class OffsetFetchResponseGroupDecoder
        {
            public static DecodeResult<OffsetFetchResponseGroup> ReadV0(byte[] buffer, int index)
            {
                var groupIdField = "";
                var topicsField = ImmutableArray<OffsetFetchResponseTopics>.Empty;
                var errorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(index, new(
                    groupIdField,
                    topicsField,
                    errorCodeField,
                    taggedFields
                ));
            }
            public static DecodeResult<OffsetFetchResponseGroup> ReadV1(byte[] buffer, int index)
            {
                var groupIdField = "";
                var topicsField = ImmutableArray<OffsetFetchResponseTopics>.Empty;
                var errorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(index, new(
                    groupIdField,
                    topicsField,
                    errorCodeField,
                    taggedFields
                ));
            }
            public static DecodeResult<OffsetFetchResponseGroup> ReadV2(byte[] buffer, int index)
            {
                var groupIdField = "";
                var topicsField = ImmutableArray<OffsetFetchResponseTopics>.Empty;
                var errorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(index, new(
                    groupIdField,
                    topicsField,
                    errorCodeField,
                    taggedFields
                ));
            }
            public static DecodeResult<OffsetFetchResponseGroup> ReadV3(byte[] buffer, int index)
            {
                var groupIdField = "";
                var topicsField = ImmutableArray<OffsetFetchResponseTopics>.Empty;
                var errorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(index, new(
                    groupIdField,
                    topicsField,
                    errorCodeField,
                    taggedFields
                ));
            }
            public static DecodeResult<OffsetFetchResponseGroup> ReadV4(byte[] buffer, int index)
            {
                var groupIdField = "";
                var topicsField = ImmutableArray<OffsetFetchResponseTopics>.Empty;
                var errorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(index, new(
                    groupIdField,
                    topicsField,
                    errorCodeField,
                    taggedFields
                ));
            }
            public static DecodeResult<OffsetFetchResponseGroup> ReadV5(byte[] buffer, int index)
            {
                var groupIdField = "";
                var topicsField = ImmutableArray<OffsetFetchResponseTopics>.Empty;
                var errorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(index, new(
                    groupIdField,
                    topicsField,
                    errorCodeField,
                    taggedFields
                ));
            }
            public static DecodeResult<OffsetFetchResponseGroup> ReadV6(byte[] buffer, int index)
            {
                var groupIdField = "";
                var topicsField = ImmutableArray<OffsetFetchResponseTopics>.Empty;
                var errorCodeField = default(short);
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
                    groupIdField,
                    topicsField,
                    errorCodeField,
                    taggedFields
                ));
            }
            public static DecodeResult<OffsetFetchResponseGroup> ReadV7(byte[] buffer, int index)
            {
                var groupIdField = "";
                var topicsField = ImmutableArray<OffsetFetchResponseTopics>.Empty;
                var errorCodeField = default(short);
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
                    groupIdField,
                    topicsField,
                    errorCodeField,
                    taggedFields
                ));
            }
            public static DecodeResult<OffsetFetchResponseGroup> ReadV8(byte[] buffer, int index)
            {
                var groupIdField = "";
                var topicsField = ImmutableArray<OffsetFetchResponseTopics>.Empty;
                var errorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, groupIdField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, var _topicsField_) = BinaryDecoder.ReadCompactArray<OffsetFetchResponseTopics>(buffer, index, OffsetFetchResponseTopicsDecoder.ReadV8);
                if (_topicsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Topics'");
                else
                    topicsField = _topicsField_.Value;
                (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
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
                    groupIdField,
                    topicsField,
                    errorCodeField,
                    taggedFields
                ));
            }
            public static DecodeResult<OffsetFetchResponseGroup> ReadV9(byte[] buffer, int index)
            {
                var groupIdField = "";
                var topicsField = ImmutableArray<OffsetFetchResponseTopics>.Empty;
                var errorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, groupIdField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, var _topicsField_) = BinaryDecoder.ReadCompactArray<OffsetFetchResponseTopics>(buffer, index, OffsetFetchResponseTopicsDecoder.ReadV9);
                if (_topicsField_ == null)
                    throw new NullReferenceException("Null not allowed for 'Topics'");
                else
                    topicsField = _topicsField_.Value;
                (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
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
                    groupIdField,
                    topicsField,
                    errorCodeField,
                    taggedFields
                ));
            }
            [GeneratedCodeAttribute("kgen", "1.0.0.0")]
            private static class OffsetFetchResponseTopicsDecoder
            {
                public static DecodeResult<OffsetFetchResponseTopics> ReadV0(byte[] buffer, int index)
                {
                    var nameField = "";
                    var partitionsField = ImmutableArray<OffsetFetchResponsePartitions>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    return new(index, new(
                        nameField,
                        partitionsField,
                        taggedFields
                    ));
                }
                public static DecodeResult<OffsetFetchResponseTopics> ReadV1(byte[] buffer, int index)
                {
                    var nameField = "";
                    var partitionsField = ImmutableArray<OffsetFetchResponsePartitions>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    return new(index, new(
                        nameField,
                        partitionsField,
                        taggedFields
                    ));
                }
                public static DecodeResult<OffsetFetchResponseTopics> ReadV2(byte[] buffer, int index)
                {
                    var nameField = "";
                    var partitionsField = ImmutableArray<OffsetFetchResponsePartitions>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    return new(index, new(
                        nameField,
                        partitionsField,
                        taggedFields
                    ));
                }
                public static DecodeResult<OffsetFetchResponseTopics> ReadV3(byte[] buffer, int index)
                {
                    var nameField = "";
                    var partitionsField = ImmutableArray<OffsetFetchResponsePartitions>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    return new(index, new(
                        nameField,
                        partitionsField,
                        taggedFields
                    ));
                }
                public static DecodeResult<OffsetFetchResponseTopics> ReadV4(byte[] buffer, int index)
                {
                    var nameField = "";
                    var partitionsField = ImmutableArray<OffsetFetchResponsePartitions>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    return new(index, new(
                        nameField,
                        partitionsField,
                        taggedFields
                    ));
                }
                public static DecodeResult<OffsetFetchResponseTopics> ReadV5(byte[] buffer, int index)
                {
                    var nameField = "";
                    var partitionsField = ImmutableArray<OffsetFetchResponsePartitions>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    return new(index, new(
                        nameField,
                        partitionsField,
                        taggedFields
                    ));
                }
                public static DecodeResult<OffsetFetchResponseTopics> ReadV6(byte[] buffer, int index)
                {
                    var nameField = "";
                    var partitionsField = ImmutableArray<OffsetFetchResponsePartitions>.Empty;
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
                        nameField,
                        partitionsField,
                        taggedFields
                    ));
                }
                public static DecodeResult<OffsetFetchResponseTopics> ReadV7(byte[] buffer, int index)
                {
                    var nameField = "";
                    var partitionsField = ImmutableArray<OffsetFetchResponsePartitions>.Empty;
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
                        nameField,
                        partitionsField,
                        taggedFields
                    ));
                }
                public static DecodeResult<OffsetFetchResponseTopics> ReadV8(byte[] buffer, int index)
                {
                    var nameField = "";
                    var partitionsField = ImmutableArray<OffsetFetchResponsePartitions>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                    (index, var _partitionsField_) = BinaryDecoder.ReadCompactArray<OffsetFetchResponsePartitions>(buffer, index, OffsetFetchResponsePartitionsDecoder.ReadV8);
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
                public static DecodeResult<OffsetFetchResponseTopics> ReadV9(byte[] buffer, int index)
                {
                    var nameField = "";
                    var partitionsField = ImmutableArray<OffsetFetchResponsePartitions>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                    (index, var _partitionsField_) = BinaryDecoder.ReadCompactArray<OffsetFetchResponsePartitions>(buffer, index, OffsetFetchResponsePartitionsDecoder.ReadV9);
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
                private static class OffsetFetchResponsePartitionsDecoder
                {
                    public static DecodeResult<OffsetFetchResponsePartitions> ReadV0(byte[] buffer, int index)
                    {
                        var partitionIndexField = default(int);
                        var committedOffsetField = default(long);
                        var committedLeaderEpochField = default(int);
                        var metadataField = default(string?);
                        var errorCodeField = default(short);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(index, new(
                            partitionIndexField,
                            committedOffsetField,
                            committedLeaderEpochField,
                            metadataField,
                            errorCodeField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<OffsetFetchResponsePartitions> ReadV1(byte[] buffer, int index)
                    {
                        var partitionIndexField = default(int);
                        var committedOffsetField = default(long);
                        var committedLeaderEpochField = default(int);
                        var metadataField = default(string?);
                        var errorCodeField = default(short);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(index, new(
                            partitionIndexField,
                            committedOffsetField,
                            committedLeaderEpochField,
                            metadataField,
                            errorCodeField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<OffsetFetchResponsePartitions> ReadV2(byte[] buffer, int index)
                    {
                        var partitionIndexField = default(int);
                        var committedOffsetField = default(long);
                        var committedLeaderEpochField = default(int);
                        var metadataField = default(string?);
                        var errorCodeField = default(short);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(index, new(
                            partitionIndexField,
                            committedOffsetField,
                            committedLeaderEpochField,
                            metadataField,
                            errorCodeField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<OffsetFetchResponsePartitions> ReadV3(byte[] buffer, int index)
                    {
                        var partitionIndexField = default(int);
                        var committedOffsetField = default(long);
                        var committedLeaderEpochField = default(int);
                        var metadataField = default(string?);
                        var errorCodeField = default(short);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(index, new(
                            partitionIndexField,
                            committedOffsetField,
                            committedLeaderEpochField,
                            metadataField,
                            errorCodeField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<OffsetFetchResponsePartitions> ReadV4(byte[] buffer, int index)
                    {
                        var partitionIndexField = default(int);
                        var committedOffsetField = default(long);
                        var committedLeaderEpochField = default(int);
                        var metadataField = default(string?);
                        var errorCodeField = default(short);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(index, new(
                            partitionIndexField,
                            committedOffsetField,
                            committedLeaderEpochField,
                            metadataField,
                            errorCodeField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<OffsetFetchResponsePartitions> ReadV5(byte[] buffer, int index)
                    {
                        var partitionIndexField = default(int);
                        var committedOffsetField = default(long);
                        var committedLeaderEpochField = default(int);
                        var metadataField = default(string?);
                        var errorCodeField = default(short);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(index, new(
                            partitionIndexField,
                            committedOffsetField,
                            committedLeaderEpochField,
                            metadataField,
                            errorCodeField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<OffsetFetchResponsePartitions> ReadV6(byte[] buffer, int index)
                    {
                        var partitionIndexField = default(int);
                        var committedOffsetField = default(long);
                        var committedLeaderEpochField = default(int);
                        var metadataField = default(string?);
                        var errorCodeField = default(short);
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
                            partitionIndexField,
                            committedOffsetField,
                            committedLeaderEpochField,
                            metadataField,
                            errorCodeField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<OffsetFetchResponsePartitions> ReadV7(byte[] buffer, int index)
                    {
                        var partitionIndexField = default(int);
                        var committedOffsetField = default(long);
                        var committedLeaderEpochField = default(int);
                        var metadataField = default(string?);
                        var errorCodeField = default(short);
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
                            partitionIndexField,
                            committedOffsetField,
                            committedLeaderEpochField,
                            metadataField,
                            errorCodeField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<OffsetFetchResponsePartitions> ReadV8(byte[] buffer, int index)
                    {
                        var partitionIndexField = default(int);
                        var committedOffsetField = default(long);
                        var committedLeaderEpochField = default(int);
                        var metadataField = default(string?);
                        var errorCodeField = default(short);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                        (index, committedOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, committedLeaderEpochField) = BinaryDecoder.ReadInt32(buffer, index);
                        (index, metadataField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
                        (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
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
                            committedOffsetField,
                            committedLeaderEpochField,
                            metadataField,
                            errorCodeField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<OffsetFetchResponsePartitions> ReadV9(byte[] buffer, int index)
                    {
                        var partitionIndexField = default(int);
                        var committedOffsetField = default(long);
                        var committedLeaderEpochField = default(int);
                        var metadataField = default(string?);
                        var errorCodeField = default(short);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                        (index, committedOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                        (index, committedLeaderEpochField) = BinaryDecoder.ReadInt32(buffer, index);
                        (index, metadataField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
                        (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
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
                            committedOffsetField,
                            committedLeaderEpochField,
                            metadataField,
                            errorCodeField,
                            taggedFields
                        ));
                    }
                }
            }
        }
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class OffsetFetchResponseTopicDecoder
        {
            public static DecodeResult<OffsetFetchResponseTopic> ReadV0(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetFetchResponsePartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<OffsetFetchResponsePartition>(buffer, index, OffsetFetchResponsePartitionDecoder.ReadV0);
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
            public static DecodeResult<OffsetFetchResponseTopic> ReadV1(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetFetchResponsePartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<OffsetFetchResponsePartition>(buffer, index, OffsetFetchResponsePartitionDecoder.ReadV1);
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
            public static DecodeResult<OffsetFetchResponseTopic> ReadV2(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetFetchResponsePartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<OffsetFetchResponsePartition>(buffer, index, OffsetFetchResponsePartitionDecoder.ReadV2);
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
            public static DecodeResult<OffsetFetchResponseTopic> ReadV3(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetFetchResponsePartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<OffsetFetchResponsePartition>(buffer, index, OffsetFetchResponsePartitionDecoder.ReadV3);
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
            public static DecodeResult<OffsetFetchResponseTopic> ReadV4(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetFetchResponsePartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<OffsetFetchResponsePartition>(buffer, index, OffsetFetchResponsePartitionDecoder.ReadV4);
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
            public static DecodeResult<OffsetFetchResponseTopic> ReadV5(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetFetchResponsePartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadArray<OffsetFetchResponsePartition>(buffer, index, OffsetFetchResponsePartitionDecoder.ReadV5);
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
            public static DecodeResult<OffsetFetchResponseTopic> ReadV6(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetFetchResponsePartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadCompactArray<OffsetFetchResponsePartition>(buffer, index, OffsetFetchResponsePartitionDecoder.ReadV6);
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
            public static DecodeResult<OffsetFetchResponseTopic> ReadV7(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetFetchResponsePartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, nameField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, var _partitionsField_) = BinaryDecoder.ReadCompactArray<OffsetFetchResponsePartition>(buffer, index, OffsetFetchResponsePartitionDecoder.ReadV7);
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
            public static DecodeResult<OffsetFetchResponseTopic> ReadV8(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetFetchResponsePartition>.Empty;
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
                    nameField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<OffsetFetchResponseTopic> ReadV9(byte[] buffer, int index)
            {
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetFetchResponsePartition>.Empty;
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
                    nameField,
                    partitionsField,
                    taggedFields
                ));
            }
            [GeneratedCodeAttribute("kgen", "1.0.0.0")]
            private static class OffsetFetchResponsePartitionDecoder
            {
                public static DecodeResult<OffsetFetchResponsePartition> ReadV0(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var committedOffsetField = default(long);
                    var committedLeaderEpochField = default(int);
                    var metadataField = default(string?);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, committedOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, metadataField) = BinaryDecoder.ReadNullableString(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    return new(index, new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        metadataField,
                        errorCodeField,
                        taggedFields
                    ));
                }
                public static DecodeResult<OffsetFetchResponsePartition> ReadV1(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var committedOffsetField = default(long);
                    var committedLeaderEpochField = default(int);
                    var metadataField = default(string?);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, committedOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, metadataField) = BinaryDecoder.ReadNullableString(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    return new(index, new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        metadataField,
                        errorCodeField,
                        taggedFields
                    ));
                }
                public static DecodeResult<OffsetFetchResponsePartition> ReadV2(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var committedOffsetField = default(long);
                    var committedLeaderEpochField = default(int);
                    var metadataField = default(string?);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, committedOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, metadataField) = BinaryDecoder.ReadNullableString(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    return new(index, new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        metadataField,
                        errorCodeField,
                        taggedFields
                    ));
                }
                public static DecodeResult<OffsetFetchResponsePartition> ReadV3(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var committedOffsetField = default(long);
                    var committedLeaderEpochField = default(int);
                    var metadataField = default(string?);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, committedOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, metadataField) = BinaryDecoder.ReadNullableString(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    return new(index, new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        metadataField,
                        errorCodeField,
                        taggedFields
                    ));
                }
                public static DecodeResult<OffsetFetchResponsePartition> ReadV4(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var committedOffsetField = default(long);
                    var committedLeaderEpochField = default(int);
                    var metadataField = default(string?);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, committedOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, metadataField) = BinaryDecoder.ReadNullableString(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    return new(index, new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        metadataField,
                        errorCodeField,
                        taggedFields
                    ));
                }
                public static DecodeResult<OffsetFetchResponsePartition> ReadV5(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var committedOffsetField = default(long);
                    var committedLeaderEpochField = default(int);
                    var metadataField = default(string?);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, committedOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, committedLeaderEpochField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, metadataField) = BinaryDecoder.ReadNullableString(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                    return new(index, new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        metadataField,
                        errorCodeField,
                        taggedFields
                    ));
                }
                public static DecodeResult<OffsetFetchResponsePartition> ReadV6(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var committedOffsetField = default(long);
                    var committedLeaderEpochField = default(int);
                    var metadataField = default(string?);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, committedOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, committedLeaderEpochField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, metadataField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
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
                        committedOffsetField,
                        committedLeaderEpochField,
                        metadataField,
                        errorCodeField,
                        taggedFields
                    ));
                }
                public static DecodeResult<OffsetFetchResponsePartition> ReadV7(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var committedOffsetField = default(long);
                    var committedLeaderEpochField = default(int);
                    var metadataField = default(string?);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (index, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, committedOffsetField) = BinaryDecoder.ReadInt64(buffer, index);
                    (index, committedLeaderEpochField) = BinaryDecoder.ReadInt32(buffer, index);
                    (index, metadataField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
                    (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
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
                        committedOffsetField,
                        committedLeaderEpochField,
                        metadataField,
                        errorCodeField,
                        taggedFields
                    ));
                }
                public static DecodeResult<OffsetFetchResponsePartition> ReadV8(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var committedOffsetField = default(long);
                    var committedLeaderEpochField = default(int);
                    var metadataField = default(string?);
                    var errorCodeField = default(short);
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
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        metadataField,
                        errorCodeField,
                        taggedFields
                    ));
                }
                public static DecodeResult<OffsetFetchResponsePartition> ReadV9(byte[] buffer, int index)
                {
                    var partitionIndexField = default(int);
                    var committedOffsetField = default(long);
                    var committedLeaderEpochField = default(int);
                    var metadataField = default(string?);
                    var errorCodeField = default(short);
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
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        metadataField,
                        errorCodeField,
                        taggedFields
                    ));
                }
            }
        }
    }
}
