using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using OffsetFetchResponseGroup = Kafka.Client.Messages.OffsetFetchResponseData.OffsetFetchResponseGroup;
using OffsetFetchResponsePartition = Kafka.Client.Messages.OffsetFetchResponseData.OffsetFetchResponseTopic.OffsetFetchResponsePartition;
using OffsetFetchResponsePartitions = Kafka.Client.Messages.OffsetFetchResponseData.OffsetFetchResponseGroup.OffsetFetchResponseTopics.OffsetFetchResponsePartitions;
using OffsetFetchResponseTopic = Kafka.Client.Messages.OffsetFetchResponseData.OffsetFetchResponseTopic;
using OffsetFetchResponseTopics = Kafka.Client.Messages.OffsetFetchResponseData.OffsetFetchResponseGroup.OffsetFetchResponseTopics;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    internal class OffsetFetchResponseDecoder : 
        ResponseDecoder<ResponseHeaderData, OffsetFetchResponseData>
    {
        internal OffsetFetchResponseDecoder() :
            base(
                ApiKey.OffsetFetch,
                new(0, 9),
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
        protected override DecodeValue<OffsetFetchResponseData> GetMessageDecoder(short apiVersion) =>
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
        private static DecodeResult<OffsetFetchResponseData> ReadV0([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<OffsetFetchResponseTopic>.Empty;
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, topicsField) = BinaryDecoder.ReadArray<OffsetFetchResponseTopic>(buffer, i, OffsetFetchResponseTopicDecoder.ReadV0);
            if (topicsField.IsDefault)
                throw new InvalidDataException("topicsField was null");
;
            return new(i, new(
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField,
                taggedFields
            ));
        }
        private static DecodeResult<OffsetFetchResponseData> ReadV1([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<OffsetFetchResponseTopic>.Empty;
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, topicsField) = BinaryDecoder.ReadArray<OffsetFetchResponseTopic>(buffer, i, OffsetFetchResponseTopicDecoder.ReadV1);
            if (topicsField.IsDefault)
                throw new InvalidDataException("topicsField was null");
;
            return new(i, new(
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField,
                taggedFields
            ));
        }
        private static DecodeResult<OffsetFetchResponseData> ReadV2([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<OffsetFetchResponseTopic>.Empty;
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, topicsField) = BinaryDecoder.ReadArray<OffsetFetchResponseTopic>(buffer, i, OffsetFetchResponseTopicDecoder.ReadV2);
            if (topicsField.IsDefault)
                throw new InvalidDataException("topicsField was null");
;
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            return new(i, new(
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField,
                taggedFields
            ));
        }
        private static DecodeResult<OffsetFetchResponseData> ReadV3([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<OffsetFetchResponseTopic>.Empty;
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, topicsField) = BinaryDecoder.ReadArray<OffsetFetchResponseTopic>(buffer, i, OffsetFetchResponseTopicDecoder.ReadV3);
            if (topicsField.IsDefault)
                throw new InvalidDataException("topicsField was null");
;
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            return new(i, new(
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField,
                taggedFields
            ));
        }
        private static DecodeResult<OffsetFetchResponseData> ReadV4([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<OffsetFetchResponseTopic>.Empty;
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, topicsField) = BinaryDecoder.ReadArray<OffsetFetchResponseTopic>(buffer, i, OffsetFetchResponseTopicDecoder.ReadV4);
            if (topicsField.IsDefault)
                throw new InvalidDataException("topicsField was null");
;
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            return new(i, new(
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField,
                taggedFields
            ));
        }
        private static DecodeResult<OffsetFetchResponseData> ReadV5([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<OffsetFetchResponseTopic>.Empty;
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, topicsField) = BinaryDecoder.ReadArray<OffsetFetchResponseTopic>(buffer, i, OffsetFetchResponseTopicDecoder.ReadV5);
            if (topicsField.IsDefault)
                throw new InvalidDataException("topicsField was null");
;
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            return new(i, new(
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField,
                taggedFields
            ));
        }
        private static DecodeResult<OffsetFetchResponseData> ReadV6([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<OffsetFetchResponseTopic>.Empty;
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, topicsField) = BinaryDecoder.ReadCompactArray<OffsetFetchResponseTopic>(buffer, i, OffsetFetchResponseTopicDecoder.ReadV6);
            if (topicsField.IsDefault)
                throw new InvalidDataException("topicsField was null");
;
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
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField,
                taggedFields
            ));
        }
        private static DecodeResult<OffsetFetchResponseData> ReadV7([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<OffsetFetchResponseTopic>.Empty;
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, topicsField) = BinaryDecoder.ReadCompactArray<OffsetFetchResponseTopic>(buffer, i, OffsetFetchResponseTopicDecoder.ReadV7);
            if (topicsField.IsDefault)
                throw new InvalidDataException("topicsField was null");
;
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
                throttleTimeMsField,
                topicsField,
                errorCodeField,
                groupsField,
                taggedFields
            ));
        }
        private static DecodeResult<OffsetFetchResponseData> ReadV8([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<OffsetFetchResponseTopic>.Empty;
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, groupsField) = BinaryDecoder.ReadCompactArray<OffsetFetchResponseGroup>(buffer, i, OffsetFetchResponseGroupDecoder.ReadV8);
            if (groupsField.IsDefault)
                throw new InvalidDataException("groupsField was null");
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
                topicsField,
                errorCodeField,
                groupsField,
                taggedFields
            ));
        }
        private static DecodeResult<OffsetFetchResponseData> ReadV9([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var topicsField = ImmutableArray<OffsetFetchResponseTopic>.Empty;
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<OffsetFetchResponseGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, groupsField) = BinaryDecoder.ReadCompactArray<OffsetFetchResponseGroup>(buffer, i, OffsetFetchResponseGroupDecoder.ReadV9);
            if (groupsField.IsDefault)
                throw new InvalidDataException("groupsField was null");
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
                topicsField,
                errorCodeField,
                groupsField,
                taggedFields
            ));
        }
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class OffsetFetchResponseGroupDecoder
        {
            public static DecodeResult<OffsetFetchResponseGroup> ReadV0([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var groupIdField = "";
                var topicsField = ImmutableArray<OffsetFetchResponseTopics>.Empty;
                var errorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(i, new(
                    groupIdField,
                    topicsField,
                    errorCodeField,
                    taggedFields
                ));
            }
            public static DecodeResult<OffsetFetchResponseGroup> ReadV1([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var groupIdField = "";
                var topicsField = ImmutableArray<OffsetFetchResponseTopics>.Empty;
                var errorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(i, new(
                    groupIdField,
                    topicsField,
                    errorCodeField,
                    taggedFields
                ));
            }
            public static DecodeResult<OffsetFetchResponseGroup> ReadV2([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var groupIdField = "";
                var topicsField = ImmutableArray<OffsetFetchResponseTopics>.Empty;
                var errorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(i, new(
                    groupIdField,
                    topicsField,
                    errorCodeField,
                    taggedFields
                ));
            }
            public static DecodeResult<OffsetFetchResponseGroup> ReadV3([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var groupIdField = "";
                var topicsField = ImmutableArray<OffsetFetchResponseTopics>.Empty;
                var errorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(i, new(
                    groupIdField,
                    topicsField,
                    errorCodeField,
                    taggedFields
                ));
            }
            public static DecodeResult<OffsetFetchResponseGroup> ReadV4([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var groupIdField = "";
                var topicsField = ImmutableArray<OffsetFetchResponseTopics>.Empty;
                var errorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(i, new(
                    groupIdField,
                    topicsField,
                    errorCodeField,
                    taggedFields
                ));
            }
            public static DecodeResult<OffsetFetchResponseGroup> ReadV5([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var groupIdField = "";
                var topicsField = ImmutableArray<OffsetFetchResponseTopics>.Empty;
                var errorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(i, new(
                    groupIdField,
                    topicsField,
                    errorCodeField,
                    taggedFields
                ));
            }
            public static DecodeResult<OffsetFetchResponseGroup> ReadV6([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var groupIdField = "";
                var topicsField = ImmutableArray<OffsetFetchResponseTopics>.Empty;
                var errorCodeField = default(short);
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
                    groupIdField,
                    topicsField,
                    errorCodeField,
                    taggedFields
                ));
            }
            public static DecodeResult<OffsetFetchResponseGroup> ReadV7([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var groupIdField = "";
                var topicsField = ImmutableArray<OffsetFetchResponseTopics>.Empty;
                var errorCodeField = default(short);
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
                    groupIdField,
                    topicsField,
                    errorCodeField,
                    taggedFields
                ));
            }
            public static DecodeResult<OffsetFetchResponseGroup> ReadV8([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var groupIdField = "";
                var topicsField = ImmutableArray<OffsetFetchResponseTopics>.Empty;
                var errorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, groupIdField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, topicsField) = BinaryDecoder.ReadCompactArray<OffsetFetchResponseTopics>(buffer, i, OffsetFetchResponseTopicsDecoder.ReadV8);
                if (topicsField.IsDefault)
                    throw new InvalidDataException("topicsField was null");
;
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
                    groupIdField,
                    topicsField,
                    errorCodeField,
                    taggedFields
                ));
            }
            public static DecodeResult<OffsetFetchResponseGroup> ReadV9([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var groupIdField = "";
                var topicsField = ImmutableArray<OffsetFetchResponseTopics>.Empty;
                var errorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, groupIdField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, topicsField) = BinaryDecoder.ReadCompactArray<OffsetFetchResponseTopics>(buffer, i, OffsetFetchResponseTopicsDecoder.ReadV9);
                if (topicsField.IsDefault)
                    throw new InvalidDataException("topicsField was null");
;
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
                    groupIdField,
                    topicsField,
                    errorCodeField,
                    taggedFields
                ));
            }
            [GeneratedCodeAttribute("kgen", "1.0.0.0")]
            private static class OffsetFetchResponseTopicsDecoder
            {
                public static DecodeResult<OffsetFetchResponseTopics> ReadV0([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var nameField = "";
                    var partitionsField = ImmutableArray<OffsetFetchResponsePartitions>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    return new(i, new(
                        nameField,
                        partitionsField,
                        taggedFields
                    ));
                }
                public static DecodeResult<OffsetFetchResponseTopics> ReadV1([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var nameField = "";
                    var partitionsField = ImmutableArray<OffsetFetchResponsePartitions>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    return new(i, new(
                        nameField,
                        partitionsField,
                        taggedFields
                    ));
                }
                public static DecodeResult<OffsetFetchResponseTopics> ReadV2([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var nameField = "";
                    var partitionsField = ImmutableArray<OffsetFetchResponsePartitions>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    return new(i, new(
                        nameField,
                        partitionsField,
                        taggedFields
                    ));
                }
                public static DecodeResult<OffsetFetchResponseTopics> ReadV3([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var nameField = "";
                    var partitionsField = ImmutableArray<OffsetFetchResponsePartitions>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    return new(i, new(
                        nameField,
                        partitionsField,
                        taggedFields
                    ));
                }
                public static DecodeResult<OffsetFetchResponseTopics> ReadV4([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var nameField = "";
                    var partitionsField = ImmutableArray<OffsetFetchResponsePartitions>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    return new(i, new(
                        nameField,
                        partitionsField,
                        taggedFields
                    ));
                }
                public static DecodeResult<OffsetFetchResponseTopics> ReadV5([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var nameField = "";
                    var partitionsField = ImmutableArray<OffsetFetchResponsePartitions>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    return new(i, new(
                        nameField,
                        partitionsField,
                        taggedFields
                    ));
                }
                public static DecodeResult<OffsetFetchResponseTopics> ReadV6([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var nameField = "";
                    var partitionsField = ImmutableArray<OffsetFetchResponsePartitions>.Empty;
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
                        nameField,
                        partitionsField,
                        taggedFields
                    ));
                }
                public static DecodeResult<OffsetFetchResponseTopics> ReadV7([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var nameField = "";
                    var partitionsField = ImmutableArray<OffsetFetchResponsePartitions>.Empty;
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
                        nameField,
                        partitionsField,
                        taggedFields
                    ));
                }
                public static DecodeResult<OffsetFetchResponseTopics> ReadV8([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var nameField = "";
                    var partitionsField = ImmutableArray<OffsetFetchResponsePartitions>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, nameField) = BinaryDecoder.ReadCompactString(buffer, i);
                    (i, partitionsField) = BinaryDecoder.ReadCompactArray<OffsetFetchResponsePartitions>(buffer, i, OffsetFetchResponsePartitionsDecoder.ReadV8);
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
                        nameField,
                        partitionsField,
                        taggedFields
                    ));
                }
                public static DecodeResult<OffsetFetchResponseTopics> ReadV9([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var nameField = "";
                    var partitionsField = ImmutableArray<OffsetFetchResponsePartitions>.Empty;
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, nameField) = BinaryDecoder.ReadCompactString(buffer, i);
                    (i, partitionsField) = BinaryDecoder.ReadCompactArray<OffsetFetchResponsePartitions>(buffer, i, OffsetFetchResponsePartitionsDecoder.ReadV9);
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
                        nameField,
                        partitionsField,
                        taggedFields
                    ));
                }
                [GeneratedCodeAttribute("kgen", "1.0.0.0")]
                private static class OffsetFetchResponsePartitionsDecoder
                {
                    public static DecodeResult<OffsetFetchResponsePartitions> ReadV0([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var partitionIndexField = default(int);
                        var committedOffsetField = default(long);
                        var committedLeaderEpochField = default(int);
                        var metadataField = default(string?);
                        var errorCodeField = default(short);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(i, new(
                            partitionIndexField,
                            committedOffsetField,
                            committedLeaderEpochField,
                            metadataField,
                            errorCodeField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<OffsetFetchResponsePartitions> ReadV1([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var partitionIndexField = default(int);
                        var committedOffsetField = default(long);
                        var committedLeaderEpochField = default(int);
                        var metadataField = default(string?);
                        var errorCodeField = default(short);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(i, new(
                            partitionIndexField,
                            committedOffsetField,
                            committedLeaderEpochField,
                            metadataField,
                            errorCodeField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<OffsetFetchResponsePartitions> ReadV2([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var partitionIndexField = default(int);
                        var committedOffsetField = default(long);
                        var committedLeaderEpochField = default(int);
                        var metadataField = default(string?);
                        var errorCodeField = default(short);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(i, new(
                            partitionIndexField,
                            committedOffsetField,
                            committedLeaderEpochField,
                            metadataField,
                            errorCodeField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<OffsetFetchResponsePartitions> ReadV3([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var partitionIndexField = default(int);
                        var committedOffsetField = default(long);
                        var committedLeaderEpochField = default(int);
                        var metadataField = default(string?);
                        var errorCodeField = default(short);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(i, new(
                            partitionIndexField,
                            committedOffsetField,
                            committedLeaderEpochField,
                            metadataField,
                            errorCodeField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<OffsetFetchResponsePartitions> ReadV4([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var partitionIndexField = default(int);
                        var committedOffsetField = default(long);
                        var committedLeaderEpochField = default(int);
                        var metadataField = default(string?);
                        var errorCodeField = default(short);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(i, new(
                            partitionIndexField,
                            committedOffsetField,
                            committedLeaderEpochField,
                            metadataField,
                            errorCodeField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<OffsetFetchResponsePartitions> ReadV5([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var partitionIndexField = default(int);
                        var committedOffsetField = default(long);
                        var committedLeaderEpochField = default(int);
                        var metadataField = default(string?);
                        var errorCodeField = default(short);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        return new(i, new(
                            partitionIndexField,
                            committedOffsetField,
                            committedLeaderEpochField,
                            metadataField,
                            errorCodeField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<OffsetFetchResponsePartitions> ReadV6([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var partitionIndexField = default(int);
                        var committedOffsetField = default(long);
                        var committedLeaderEpochField = default(int);
                        var metadataField = default(string?);
                        var errorCodeField = default(short);
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
                            partitionIndexField,
                            committedOffsetField,
                            committedLeaderEpochField,
                            metadataField,
                            errorCodeField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<OffsetFetchResponsePartitions> ReadV7([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var partitionIndexField = default(int);
                        var committedOffsetField = default(long);
                        var committedLeaderEpochField = default(int);
                        var metadataField = default(string?);
                        var errorCodeField = default(short);
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
                            partitionIndexField,
                            committedOffsetField,
                            committedLeaderEpochField,
                            metadataField,
                            errorCodeField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<OffsetFetchResponsePartitions> ReadV8([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var partitionIndexField = default(int);
                        var committedOffsetField = default(long);
                        var committedLeaderEpochField = default(int);
                        var metadataField = default(string?);
                        var errorCodeField = default(short);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                        (i, committedOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                        (i, committedLeaderEpochField) = BinaryDecoder.ReadInt32(buffer, i);
                        (i, metadataField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
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
                            committedOffsetField,
                            committedLeaderEpochField,
                            metadataField,
                            errorCodeField,
                            taggedFields
                        ));
                    }
                    public static DecodeResult<OffsetFetchResponsePartitions> ReadV9([NotNull] in byte[] buffer, in int index)
                    {
                        var i = index;
                        var partitionIndexField = default(int);
                        var committedOffsetField = default(long);
                        var committedLeaderEpochField = default(int);
                        var metadataField = default(string?);
                        var errorCodeField = default(short);
                        var taggedFields = ImmutableArray<TaggedField>.Empty;
                        (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                        (i, committedOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                        (i, committedLeaderEpochField) = BinaryDecoder.ReadInt32(buffer, i);
                        (i, metadataField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
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
            public static DecodeResult<OffsetFetchResponseTopic> ReadV0([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetFetchResponsePartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, partitionsField) = BinaryDecoder.ReadArray<OffsetFetchResponsePartition>(buffer, i, OffsetFetchResponsePartitionDecoder.ReadV0);
                if (partitionsField.IsDefault)
                    throw new InvalidDataException("partitionsField was null");
;
                return new(i, new(
                    nameField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<OffsetFetchResponseTopic> ReadV1([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetFetchResponsePartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, partitionsField) = BinaryDecoder.ReadArray<OffsetFetchResponsePartition>(buffer, i, OffsetFetchResponsePartitionDecoder.ReadV1);
                if (partitionsField.IsDefault)
                    throw new InvalidDataException("partitionsField was null");
;
                return new(i, new(
                    nameField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<OffsetFetchResponseTopic> ReadV2([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetFetchResponsePartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, partitionsField) = BinaryDecoder.ReadArray<OffsetFetchResponsePartition>(buffer, i, OffsetFetchResponsePartitionDecoder.ReadV2);
                if (partitionsField.IsDefault)
                    throw new InvalidDataException("partitionsField was null");
;
                return new(i, new(
                    nameField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<OffsetFetchResponseTopic> ReadV3([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetFetchResponsePartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, partitionsField) = BinaryDecoder.ReadArray<OffsetFetchResponsePartition>(buffer, i, OffsetFetchResponsePartitionDecoder.ReadV3);
                if (partitionsField.IsDefault)
                    throw new InvalidDataException("partitionsField was null");
;
                return new(i, new(
                    nameField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<OffsetFetchResponseTopic> ReadV4([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetFetchResponsePartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, partitionsField) = BinaryDecoder.ReadArray<OffsetFetchResponsePartition>(buffer, i, OffsetFetchResponsePartitionDecoder.ReadV4);
                if (partitionsField.IsDefault)
                    throw new InvalidDataException("partitionsField was null");
;
                return new(i, new(
                    nameField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<OffsetFetchResponseTopic> ReadV5([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetFetchResponsePartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadString(buffer, i);
                (i, partitionsField) = BinaryDecoder.ReadArray<OffsetFetchResponsePartition>(buffer, i, OffsetFetchResponsePartitionDecoder.ReadV5);
                if (partitionsField.IsDefault)
                    throw new InvalidDataException("partitionsField was null");
;
                return new(i, new(
                    nameField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<OffsetFetchResponseTopic> ReadV6([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetFetchResponsePartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, partitionsField) = BinaryDecoder.ReadCompactArray<OffsetFetchResponsePartition>(buffer, i, OffsetFetchResponsePartitionDecoder.ReadV6);
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
                    nameField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<OffsetFetchResponseTopic> ReadV7([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetFetchResponsePartition>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, nameField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, partitionsField) = BinaryDecoder.ReadCompactArray<OffsetFetchResponsePartition>(buffer, i, OffsetFetchResponsePartitionDecoder.ReadV7);
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
                    nameField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<OffsetFetchResponseTopic> ReadV8([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetFetchResponsePartition>.Empty;
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
                    nameField,
                    partitionsField,
                    taggedFields
                ));
            }
            public static DecodeResult<OffsetFetchResponseTopic> ReadV9([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var nameField = "";
                var partitionsField = ImmutableArray<OffsetFetchResponsePartition>.Empty;
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
                    nameField,
                    partitionsField,
                    taggedFields
                ));
            }
            [GeneratedCodeAttribute("kgen", "1.0.0.0")]
            private static class OffsetFetchResponsePartitionDecoder
            {
                public static DecodeResult<OffsetFetchResponsePartition> ReadV0([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var committedOffsetField = default(long);
                    var committedLeaderEpochField = default(int);
                    var metadataField = default(string?);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, committedOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, metadataField) = BinaryDecoder.ReadNullableString(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    return new(i, new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        metadataField,
                        errorCodeField,
                        taggedFields
                    ));
                }
                public static DecodeResult<OffsetFetchResponsePartition> ReadV1([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var committedOffsetField = default(long);
                    var committedLeaderEpochField = default(int);
                    var metadataField = default(string?);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, committedOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, metadataField) = BinaryDecoder.ReadNullableString(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    return new(i, new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        metadataField,
                        errorCodeField,
                        taggedFields
                    ));
                }
                public static DecodeResult<OffsetFetchResponsePartition> ReadV2([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var committedOffsetField = default(long);
                    var committedLeaderEpochField = default(int);
                    var metadataField = default(string?);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, committedOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, metadataField) = BinaryDecoder.ReadNullableString(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    return new(i, new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        metadataField,
                        errorCodeField,
                        taggedFields
                    ));
                }
                public static DecodeResult<OffsetFetchResponsePartition> ReadV3([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var committedOffsetField = default(long);
                    var committedLeaderEpochField = default(int);
                    var metadataField = default(string?);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, committedOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, metadataField) = BinaryDecoder.ReadNullableString(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    return new(i, new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        metadataField,
                        errorCodeField,
                        taggedFields
                    ));
                }
                public static DecodeResult<OffsetFetchResponsePartition> ReadV4([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var committedOffsetField = default(long);
                    var committedLeaderEpochField = default(int);
                    var metadataField = default(string?);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, committedOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, metadataField) = BinaryDecoder.ReadNullableString(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    return new(i, new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        metadataField,
                        errorCodeField,
                        taggedFields
                    ));
                }
                public static DecodeResult<OffsetFetchResponsePartition> ReadV5([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var committedOffsetField = default(long);
                    var committedLeaderEpochField = default(int);
                    var metadataField = default(string?);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, committedOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, committedLeaderEpochField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, metadataField) = BinaryDecoder.ReadNullableString(buffer, i);
                    (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                    return new(i, new(
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        metadataField,
                        errorCodeField,
                        taggedFields
                    ));
                }
                public static DecodeResult<OffsetFetchResponsePartition> ReadV6([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var committedOffsetField = default(long);
                    var committedLeaderEpochField = default(int);
                    var metadataField = default(string?);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, committedOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, committedLeaderEpochField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, metadataField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
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
                        committedOffsetField,
                        committedLeaderEpochField,
                        metadataField,
                        errorCodeField,
                        taggedFields
                    ));
                }
                public static DecodeResult<OffsetFetchResponsePartition> ReadV7([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var committedOffsetField = default(long);
                    var committedLeaderEpochField = default(int);
                    var metadataField = default(string?);
                    var errorCodeField = default(short);
                    var taggedFields = ImmutableArray<TaggedField>.Empty;
                    (i, partitionIndexField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, committedOffsetField) = BinaryDecoder.ReadInt64(buffer, i);
                    (i, committedLeaderEpochField) = BinaryDecoder.ReadInt32(buffer, i);
                    (i, metadataField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
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
                        committedOffsetField,
                        committedLeaderEpochField,
                        metadataField,
                        errorCodeField,
                        taggedFields
                    ));
                }
                public static DecodeResult<OffsetFetchResponsePartition> ReadV8([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var committedOffsetField = default(long);
                    var committedLeaderEpochField = default(int);
                    var metadataField = default(string?);
                    var errorCodeField = default(short);
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
                        partitionIndexField,
                        committedOffsetField,
                        committedLeaderEpochField,
                        metadataField,
                        errorCodeField,
                        taggedFields
                    ));
                }
                public static DecodeResult<OffsetFetchResponsePartition> ReadV9([NotNull] in byte[] buffer, in int index)
                {
                    var i = index;
                    var partitionIndexField = default(int);
                    var committedOffsetField = default(long);
                    var committedLeaderEpochField = default(int);
                    var metadataField = default(string?);
                    var errorCodeField = default(short);
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
