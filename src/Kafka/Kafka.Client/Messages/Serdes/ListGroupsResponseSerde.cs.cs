using Kafka.Common.Encoding;
using Kafka.Common.Exceptions;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using ListedGroup = Kafka.Client.Messages.ListGroupsResponse.ListedGroup;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Version = Kafka.Common.Model.Version;

namespace Kafka.Client.Messages.Serdes
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ListGroupsResponseSerde
    {
        private static readonly ApiKey API_KEY = new(16);
        private static readonly VersionRange API_VERSIONS = new(0, 4);
        private static readonly VersionRange FLEXBILE_VERSIONS = new (3, 32767);
        public static IEncoder<ResponseHeader, ListGroupsResponse> CreateEncoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 4 ? apiVersion : new Version(4);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerEncoder = ResponseHeaderSerde.CreateEncoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Encoder<ResponseHeader, ListGroupsResponse>(API_KEY, 0, flexible, headerEncoder, WriteV0);
                case 1:
                    return new Encoder<ResponseHeader, ListGroupsResponse>(API_KEY, 1, flexible, headerEncoder, WriteV1);
                case 2:
                    return new Encoder<ResponseHeader, ListGroupsResponse>(API_KEY, 2, flexible, headerEncoder, WriteV2);
                case 3:
                    return new Encoder<ResponseHeader, ListGroupsResponse>(API_KEY, 3, flexible, headerEncoder, WriteV3);
                case 4:
                    return new Encoder<ResponseHeader, ListGroupsResponse>(API_KEY, 4, flexible, headerEncoder, WriteV4);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        public static IDecoder<ResponseHeader, ListGroupsResponse> CreateDecoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 4 ? apiVersion : new Version(4);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerDecoder = ResponseHeaderSerde.CreateDecoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Decoder<ResponseHeader, ListGroupsResponse>(API_KEY, 0, flexible, headerDecoder, ReadV0);
                case 1:
                    return new Decoder<ResponseHeader, ListGroupsResponse>(API_KEY, 1, flexible, headerDecoder, ReadV1);
                case 2:
                    return new Decoder<ResponseHeader, ListGroupsResponse>(API_KEY, 2, flexible, headerDecoder, ReadV2);
                case 3:
                    return new Decoder<ResponseHeader, ListGroupsResponse>(API_KEY, 3, flexible, headerDecoder, ReadV3);
                case 4:
                    return new Decoder<ResponseHeader, ListGroupsResponse>(API_KEY, 4, flexible, headerDecoder, ReadV4);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        private static int WriteV0(byte[] buffer, int index, ListGroupsResponse message)
        {
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = BinaryEncoder.WriteArray<ListedGroup>(buffer, index, message.GroupsField, ListedGroupSerde.WriteV0);
            return index;
        }
        private static (int Offset, ListGroupsResponse Value) ReadV0(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<ListedGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, var _groupsField_) = BinaryDecoder.ReadArray<ListedGroup>(buffer, index, ListedGroupSerde.ReadV0);
            if (_groupsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Groups'");
            else
                groupsField = _groupsField_.Value;
            return (index, new(
                throttleTimeMsField,
                errorCodeField,
                groupsField,
                taggedFields
            ));
        }
        private static int WriteV1(byte[] buffer, int index, ListGroupsResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = BinaryEncoder.WriteArray<ListedGroup>(buffer, index, message.GroupsField, ListedGroupSerde.WriteV1);
            return index;
        }
        private static (int Offset, ListGroupsResponse Value) ReadV1(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<ListedGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, var _groupsField_) = BinaryDecoder.ReadArray<ListedGroup>(buffer, index, ListedGroupSerde.ReadV1);
            if (_groupsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Groups'");
            else
                groupsField = _groupsField_.Value;
            return (index, new(
                throttleTimeMsField,
                errorCodeField,
                groupsField,
                taggedFields
            ));
        }
        private static int WriteV2(byte[] buffer, int index, ListGroupsResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = BinaryEncoder.WriteArray<ListedGroup>(buffer, index, message.GroupsField, ListedGroupSerde.WriteV2);
            return index;
        }
        private static (int Offset, ListGroupsResponse Value) ReadV2(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<ListedGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, var _groupsField_) = BinaryDecoder.ReadArray<ListedGroup>(buffer, index, ListedGroupSerde.ReadV2);
            if (_groupsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Groups'");
            else
                groupsField = _groupsField_.Value;
            return (index, new(
                throttleTimeMsField,
                errorCodeField,
                groupsField,
                taggedFields
            ));
        }
        private static int WriteV3(byte[] buffer, int index, ListGroupsResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = BinaryEncoder.WriteCompactArray<ListedGroup>(buffer, index, message.GroupsField, ListedGroupSerde.WriteV3);
            var taggedFieldsCount = 0u;
            var previousTagged = -1;
            taggedFieldsCount += (uint)message.TaggedFields.Length;
            index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
            foreach(var taggedField in message.TaggedFields)
            {
                if(taggedField.Tag <= previousTagged)
                    throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
            }
            return index;
        }
        private static (int Offset, ListGroupsResponse Value) ReadV3(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<ListedGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, var _groupsField_) = BinaryDecoder.ReadCompactArray<ListedGroup>(buffer, index, ListedGroupSerde.ReadV3);
            if (_groupsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Groups'");
            else
                groupsField = _groupsField_.Value;
            (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
            if(taggedFieldsCount > 0)
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
            return (index, new(
                throttleTimeMsField,
                errorCodeField,
                groupsField,
                taggedFields
            ));
        }
        private static int WriteV4(byte[] buffer, int index, ListGroupsResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = BinaryEncoder.WriteCompactArray<ListedGroup>(buffer, index, message.GroupsField, ListedGroupSerde.WriteV4);
            var taggedFieldsCount = 0u;
            var previousTagged = -1;
            taggedFieldsCount += (uint)message.TaggedFields.Length;
            index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
            foreach(var taggedField in message.TaggedFields)
            {
                if(taggedField.Tag <= previousTagged)
                    throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
            }
            return index;
        }
        private static (int Offset, ListGroupsResponse Value) ReadV4(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var groupsField = ImmutableArray<ListedGroup>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, var _groupsField_) = BinaryDecoder.ReadCompactArray<ListedGroup>(buffer, index, ListedGroupSerde.ReadV4);
            if (_groupsField_ == null)
                throw new NullReferenceException("Null not allowed for 'Groups'");
            else
                groupsField = _groupsField_.Value;
            (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
            if(taggedFieldsCount > 0)
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
            return (index, new(
                throttleTimeMsField,
                errorCodeField,
                groupsField,
                taggedFields
            ));
        }
        [GeneratedCode("kgen", "1.0.0.0")]
        private static class ListedGroupSerde
        {
            public static int WriteV0(byte[] buffer, int index, ListedGroup message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
                index = BinaryEncoder.WriteString(buffer, index, message.ProtocolTypeField);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, ListedGroup Value) ReadV0(byte[] buffer, int index)
            {
                var groupIdField = "";
                var protocolTypeField = "";
                var groupStateField = "";
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, groupIdField) = BinaryDecoder.ReadString(buffer, index);
                (index, protocolTypeField) = BinaryDecoder.ReadString(buffer, index);
                return (index, new(
                    groupIdField,
                    protocolTypeField,
                    groupStateField,
                    taggedFields
                ));
            }
            public static int WriteV1(byte[] buffer, int index, ListedGroup message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
                index = BinaryEncoder.WriteString(buffer, index, message.ProtocolTypeField);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, ListedGroup Value) ReadV1(byte[] buffer, int index)
            {
                var groupIdField = "";
                var protocolTypeField = "";
                var groupStateField = "";
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, groupIdField) = BinaryDecoder.ReadString(buffer, index);
                (index, protocolTypeField) = BinaryDecoder.ReadString(buffer, index);
                return (index, new(
                    groupIdField,
                    protocolTypeField,
                    groupStateField,
                    taggedFields
                ));
            }
            public static int WriteV2(byte[] buffer, int index, ListedGroup message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
                index = BinaryEncoder.WriteString(buffer, index, message.ProtocolTypeField);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, ListedGroup Value) ReadV2(byte[] buffer, int index)
            {
                var groupIdField = "";
                var protocolTypeField = "";
                var groupStateField = "";
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, groupIdField) = BinaryDecoder.ReadString(buffer, index);
                (index, protocolTypeField) = BinaryDecoder.ReadString(buffer, index);
                return (index, new(
                    groupIdField,
                    protocolTypeField,
                    groupStateField,
                    taggedFields
                ));
            }
            public static int WriteV3(byte[] buffer, int index, ListedGroup message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.GroupIdField);
                index = BinaryEncoder.WriteCompactString(buffer, index, message.ProtocolTypeField);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, ListedGroup Value) ReadV3(byte[] buffer, int index)
            {
                var groupIdField = "";
                var protocolTypeField = "";
                var groupStateField = "";
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, groupIdField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, protocolTypeField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
                if(taggedFieldsCount > 0)
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
                return (index, new(
                    groupIdField,
                    protocolTypeField,
                    groupStateField,
                    taggedFields
                ));
            }
            public static int WriteV4(byte[] buffer, int index, ListedGroup message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.GroupIdField);
                index = BinaryEncoder.WriteCompactString(buffer, index, message.ProtocolTypeField);
                index = BinaryEncoder.WriteCompactString(buffer, index, message.GroupStateField);
                var taggedFieldsCount = 0u;
                var previousTagged = -1;
                taggedFieldsCount += (uint)message.TaggedFields.Length;
                index = BinaryEncoder.WriteVarUInt32(buffer, index, taggedFieldsCount);
                foreach(var taggedField in message.TaggedFields)
                {
                    if(taggedField.Tag <= previousTagged)
                        throw new InvalidOperationException($"Reserved or out of order tag: {taggedField.Tag} - Reserved Range: -1");
                    index = BinaryEncoder.WriteVarInt32(buffer, index, taggedField.Tag);
                    index = BinaryEncoder.WriteCompactBytes(buffer, index, taggedField.Value);
                }
                return index;
            }
            public static (int Offset, ListedGroup Value) ReadV4(byte[] buffer, int index)
            {
                var groupIdField = "";
                var protocolTypeField = "";
                var groupStateField = "";
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, groupIdField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, protocolTypeField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, groupStateField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, var taggedFieldsCount) = BinaryDecoder.ReadVarUInt32(buffer, index);
                if(taggedFieldsCount > 0)
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
                return (index, new(
                    groupIdField,
                    protocolTypeField,
                    groupStateField,
                    taggedFields
                ));
            }
        }
    }
}