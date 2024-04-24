using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using ListedGroup = Kafka.Client.Messages.ListGroupsResponseData.ListedGroup;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    internal class ListGroupsResponseDecoder : 
        ResponseDecoder<ResponseHeaderData, ListGroupsResponseData>
    {
        internal ListGroupsResponseDecoder() :
            base(
                ApiKey.ListGroups,
                new(0, 5),
                new(3, 32767),
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
        protected override DecodeValue<ListGroupsResponseData> GetMessageDecoder(short apiVersion) =>
            apiVersion switch
            {
                0 => ReadV0,
                1 => ReadV1,
                2 => ReadV2,
                3 => ReadV3,
                4 => ReadV4,
                5 => ReadV5,
                _ => throw new NotSupportedException()
            }
        ;
        private static DecodeResult<ListGroupsResponseData> ReadV0([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<ListedGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, groupsField) = BinaryDecoder.ReadArray<ListedGroup>(buffer, i, ListedGroupDecoder.ReadV0);
            if (groupsField.IsDefault)
                throw new InvalidDataException("groupsField was null");
;
            return new(i, new(
                throttleTimeMsField,
                errorCodeField,
                groupsField,
                taggedFields
            ));
        }
        private static DecodeResult<ListGroupsResponseData> ReadV1([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<ListedGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, groupsField) = BinaryDecoder.ReadArray<ListedGroup>(buffer, i, ListedGroupDecoder.ReadV1);
            if (groupsField.IsDefault)
                throw new InvalidDataException("groupsField was null");
;
            return new(i, new(
                throttleTimeMsField,
                errorCodeField,
                groupsField,
                taggedFields
            ));
        }
        private static DecodeResult<ListGroupsResponseData> ReadV2([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<ListedGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, groupsField) = BinaryDecoder.ReadArray<ListedGroup>(buffer, i, ListedGroupDecoder.ReadV2);
            if (groupsField.IsDefault)
                throw new InvalidDataException("groupsField was null");
;
            return new(i, new(
                throttleTimeMsField,
                errorCodeField,
                groupsField,
                taggedFields
            ));
        }
        private static DecodeResult<ListGroupsResponseData> ReadV3([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<ListedGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, groupsField) = BinaryDecoder.ReadCompactArray<ListedGroup>(buffer, i, ListedGroupDecoder.ReadV3);
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
                errorCodeField,
                groupsField,
                taggedFields
            ));
        }
        private static DecodeResult<ListGroupsResponseData> ReadV4([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<ListedGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, groupsField) = BinaryDecoder.ReadCompactArray<ListedGroup>(buffer, i, ListedGroupDecoder.ReadV4);
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
                errorCodeField,
                groupsField,
                taggedFields
            ));
        }
        private static DecodeResult<ListGroupsResponseData> ReadV5([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<ListedGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, groupsField) = BinaryDecoder.ReadCompactArray<ListedGroup>(buffer, i, ListedGroupDecoder.ReadV5);
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
                errorCodeField,
                groupsField,
                taggedFields
            ));
        }
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class ListedGroupDecoder
        {
            public static DecodeResult<ListedGroup> ReadV0([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var groupIdField = "";
                var protocolTypeField = "";
                var groupStateField = "";
                var groupTypeField = "";
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, groupIdField) = BinaryDecoder.ReadString(buffer, i);
                (i, protocolTypeField) = BinaryDecoder.ReadString(buffer, i);
                return new(i, new(
                    groupIdField,
                    protocolTypeField,
                    groupStateField,
                    groupTypeField,
                    taggedFields
                ));
            }
            public static DecodeResult<ListedGroup> ReadV1([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var groupIdField = "";
                var protocolTypeField = "";
                var groupStateField = "";
                var groupTypeField = "";
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, groupIdField) = BinaryDecoder.ReadString(buffer, i);
                (i, protocolTypeField) = BinaryDecoder.ReadString(buffer, i);
                return new(i, new(
                    groupIdField,
                    protocolTypeField,
                    groupStateField,
                    groupTypeField,
                    taggedFields
                ));
            }
            public static DecodeResult<ListedGroup> ReadV2([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var groupIdField = "";
                var protocolTypeField = "";
                var groupStateField = "";
                var groupTypeField = "";
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, groupIdField) = BinaryDecoder.ReadString(buffer, i);
                (i, protocolTypeField) = BinaryDecoder.ReadString(buffer, i);
                return new(i, new(
                    groupIdField,
                    protocolTypeField,
                    groupStateField,
                    groupTypeField,
                    taggedFields
                ));
            }
            public static DecodeResult<ListedGroup> ReadV3([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var groupIdField = "";
                var protocolTypeField = "";
                var groupStateField = "";
                var groupTypeField = "";
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, groupIdField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, protocolTypeField) = BinaryDecoder.ReadCompactString(buffer, i);
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
                    protocolTypeField,
                    groupStateField,
                    groupTypeField,
                    taggedFields
                ));
            }
            public static DecodeResult<ListedGroup> ReadV4([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var groupIdField = "";
                var protocolTypeField = "";
                var groupStateField = "";
                var groupTypeField = "";
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, groupIdField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, protocolTypeField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, groupStateField) = BinaryDecoder.ReadCompactString(buffer, i);
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
                    protocolTypeField,
                    groupStateField,
                    groupTypeField,
                    taggedFields
                ));
            }
            public static DecodeResult<ListedGroup> ReadV5([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var groupIdField = "";
                var protocolTypeField = "";
                var groupStateField = "";
                var groupTypeField = "";
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, groupIdField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, protocolTypeField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, groupStateField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, groupTypeField) = BinaryDecoder.ReadCompactString(buffer, i);
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
                    protocolTypeField,
                    groupStateField,
                    groupTypeField,
                    taggedFields
                ));
            }
        }
    }
}
