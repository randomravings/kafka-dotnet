using Kafka.Common.Encoding;
using Kafka.Common.Exceptions;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using MemberIdentity = Kafka.Client.Messages.LeaveGroupRequest.MemberIdentity;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Version = Kafka.Common.Model.Version;

namespace Kafka.Client.Messages.Serdes
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class LeaveGroupRequestSerde
    {
        private static readonly ApiKey API_KEY = new(13);
        private static readonly VersionRange API_VERSIONS = new(0, 5);
        private static readonly VersionRange FLEXBILE_VERSIONS = new (4, 32767);
        public static IEncoder<RequestHeader, LeaveGroupRequest> CreateEncoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 5 ? apiVersion : new Version(5);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerEncoder = RequestHeaderSerde.CreateEncoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Encoder<RequestHeader, LeaveGroupRequest>(API_KEY, 0, flexible, headerEncoder, WriteV0);
                case 1:
                    return new Encoder<RequestHeader, LeaveGroupRequest>(API_KEY, 1, flexible, headerEncoder, WriteV1);
                case 2:
                    return new Encoder<RequestHeader, LeaveGroupRequest>(API_KEY, 2, flexible, headerEncoder, WriteV2);
                case 3:
                    return new Encoder<RequestHeader, LeaveGroupRequest>(API_KEY, 3, flexible, headerEncoder, WriteV3);
                case 4:
                    return new Encoder<RequestHeader, LeaveGroupRequest>(API_KEY, 4, flexible, headerEncoder, WriteV4);
                case 5:
                    return new Encoder<RequestHeader, LeaveGroupRequest>(API_KEY, 5, flexible, headerEncoder, WriteV5);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        public static IDecoder<RequestHeader, LeaveGroupRequest> CreateDecoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 5 ? apiVersion : new Version(5);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerDecoder = RequestHeaderSerde.CreateDecoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Decoder<RequestHeader, LeaveGroupRequest>(API_KEY, 0, flexible, headerDecoder, ReadV0);
                case 1:
                    return new Decoder<RequestHeader, LeaveGroupRequest>(API_KEY, 1, flexible, headerDecoder, ReadV1);
                case 2:
                    return new Decoder<RequestHeader, LeaveGroupRequest>(API_KEY, 2, flexible, headerDecoder, ReadV2);
                case 3:
                    return new Decoder<RequestHeader, LeaveGroupRequest>(API_KEY, 3, flexible, headerDecoder, ReadV3);
                case 4:
                    return new Decoder<RequestHeader, LeaveGroupRequest>(API_KEY, 4, flexible, headerDecoder, ReadV4);
                case 5:
                    return new Decoder<RequestHeader, LeaveGroupRequest>(API_KEY, 5, flexible, headerDecoder, ReadV5);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        private static int WriteV0(byte[] buffer, int index, LeaveGroupRequest message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
            return index;
        }
        private static (int Offset, LeaveGroupRequest Value) ReadV0(byte[] buffer, int index)
        {
            var groupIdField = "";
            var memberIdField = "";
            var membersField = ImmutableArray<MemberIdentity>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, groupIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
            return (index, new(
                groupIdField,
                memberIdField,
                membersField,
                taggedFields
            ));
        }
        private static int WriteV1(byte[] buffer, int index, LeaveGroupRequest message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
            return index;
        }
        private static (int Offset, LeaveGroupRequest Value) ReadV1(byte[] buffer, int index)
        {
            var groupIdField = "";
            var memberIdField = "";
            var membersField = ImmutableArray<MemberIdentity>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, groupIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
            return (index, new(
                groupIdField,
                memberIdField,
                membersField,
                taggedFields
            ));
        }
        private static int WriteV2(byte[] buffer, int index, LeaveGroupRequest message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
            return index;
        }
        private static (int Offset, LeaveGroupRequest Value) ReadV2(byte[] buffer, int index)
        {
            var groupIdField = "";
            var memberIdField = "";
            var membersField = ImmutableArray<MemberIdentity>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, groupIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
            return (index, new(
                groupIdField,
                memberIdField,
                membersField,
                taggedFields
            ));
        }
        private static int WriteV3(byte[] buffer, int index, LeaveGroupRequest message)
        {
            index = BinaryEncoder.WriteString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteArray<MemberIdentity>(buffer, index, message.MembersField, MemberIdentitySerde.WriteV3);
            return index;
        }
        private static (int Offset, LeaveGroupRequest Value) ReadV3(byte[] buffer, int index)
        {
            var groupIdField = "";
            var memberIdField = "";
            var membersField = ImmutableArray<MemberIdentity>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, groupIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, var _membersField_) = BinaryDecoder.ReadArray<MemberIdentity>(buffer, index, MemberIdentitySerde.ReadV3);
            if (_membersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Members'");
            else
                membersField = _membersField_.Value;
            return (index, new(
                groupIdField,
                memberIdField,
                membersField,
                taggedFields
            ));
        }
        private static int WriteV4(byte[] buffer, int index, LeaveGroupRequest message)
        {
            index = BinaryEncoder.WriteCompactString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteCompactArray<MemberIdentity>(buffer, index, message.MembersField, MemberIdentitySerde.WriteV4);
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
        private static (int Offset, LeaveGroupRequest Value) ReadV4(byte[] buffer, int index)
        {
            var groupIdField = "";
            var memberIdField = "";
            var membersField = ImmutableArray<MemberIdentity>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, groupIdField) = BinaryDecoder.ReadCompactString(buffer, index);
            (index, var _membersField_) = BinaryDecoder.ReadCompactArray<MemberIdentity>(buffer, index, MemberIdentitySerde.ReadV4);
            if (_membersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Members'");
            else
                membersField = _membersField_.Value;
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
                memberIdField,
                membersField,
                taggedFields
            ));
        }
        private static int WriteV5(byte[] buffer, int index, LeaveGroupRequest message)
        {
            index = BinaryEncoder.WriteCompactString(buffer, index, message.GroupIdField);
            index = BinaryEncoder.WriteCompactArray<MemberIdentity>(buffer, index, message.MembersField, MemberIdentitySerde.WriteV5);
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
        private static (int Offset, LeaveGroupRequest Value) ReadV5(byte[] buffer, int index)
        {
            var groupIdField = "";
            var memberIdField = "";
            var membersField = ImmutableArray<MemberIdentity>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, groupIdField) = BinaryDecoder.ReadCompactString(buffer, index);
            (index, var _membersField_) = BinaryDecoder.ReadCompactArray<MemberIdentity>(buffer, index, MemberIdentitySerde.ReadV5);
            if (_membersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Members'");
            else
                membersField = _membersField_.Value;
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
                memberIdField,
                membersField,
                taggedFields
            ));
        }
        [GeneratedCode("kgen", "1.0.0.0")]
        private static class MemberIdentitySerde
        {
            public static int WriteV0(byte[] buffer, int index, MemberIdentity message)
            {
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
            public static (int Offset, MemberIdentity Value) ReadV0(byte[] buffer, int index)
            {
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var reasonField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return (index, new(
                    memberIdField,
                    groupInstanceIdField,
                    reasonField,
                    taggedFields
                ));
            }
            public static int WriteV1(byte[] buffer, int index, MemberIdentity message)
            {
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
            public static (int Offset, MemberIdentity Value) ReadV1(byte[] buffer, int index)
            {
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var reasonField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return (index, new(
                    memberIdField,
                    groupInstanceIdField,
                    reasonField,
                    taggedFields
                ));
            }
            public static int WriteV2(byte[] buffer, int index, MemberIdentity message)
            {
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
            public static (int Offset, MemberIdentity Value) ReadV2(byte[] buffer, int index)
            {
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var reasonField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return (index, new(
                    memberIdField,
                    groupInstanceIdField,
                    reasonField,
                    taggedFields
                ));
            }
            public static int WriteV3(byte[] buffer, int index, MemberIdentity message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
                index = BinaryEncoder.WriteNullableString(buffer, index, message.GroupInstanceIdField);
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
            public static (int Offset, MemberIdentity Value) ReadV3(byte[] buffer, int index)
            {
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var reasonField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
                (index, groupInstanceIdField) = BinaryDecoder.ReadNullableString(buffer, index);
                return (index, new(
                    memberIdField,
                    groupInstanceIdField,
                    reasonField,
                    taggedFields
                ));
            }
            public static int WriteV4(byte[] buffer, int index, MemberIdentity message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.MemberIdField);
                index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
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
            public static (int Offset, MemberIdentity Value) ReadV4(byte[] buffer, int index)
            {
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var reasonField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, memberIdField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, groupInstanceIdField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
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
                    memberIdField,
                    groupInstanceIdField,
                    reasonField,
                    taggedFields
                ));
            }
            public static int WriteV5(byte[] buffer, int index, MemberIdentity message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.MemberIdField);
                index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
                index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.ReasonField);
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
            public static (int Offset, MemberIdentity Value) ReadV5(byte[] buffer, int index)
            {
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var reasonField = default(string?);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, memberIdField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, groupInstanceIdField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
                (index, reasonField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
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
                    memberIdField,
                    groupInstanceIdField,
                    reasonField,
                    taggedFields
                ));
            }
        }
    }
}