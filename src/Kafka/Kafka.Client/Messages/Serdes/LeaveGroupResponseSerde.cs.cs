using Kafka.Common.Encoding;
using Kafka.Common.Exceptions;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using MemberResponse = Kafka.Client.Messages.LeaveGroupResponse.MemberResponse;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Version = Kafka.Common.Model.Version;

namespace Kafka.Client.Messages.Serdes
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class LeaveGroupResponseSerde
    {
        private static readonly ApiKey API_KEY = new(13);
        private static readonly VersionRange API_VERSIONS = new(0, 5);
        private static readonly VersionRange FLEXBILE_VERSIONS = new (4, 32767);
        public static IEncoder<ResponseHeader, LeaveGroupResponse> CreateEncoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 5 ? apiVersion : new Version(5);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerEncoder = ResponseHeaderSerde.CreateEncoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Encoder<ResponseHeader, LeaveGroupResponse>(API_KEY, 0, flexible, headerEncoder, WriteV0);
                case 1:
                    return new Encoder<ResponseHeader, LeaveGroupResponse>(API_KEY, 1, flexible, headerEncoder, WriteV1);
                case 2:
                    return new Encoder<ResponseHeader, LeaveGroupResponse>(API_KEY, 2, flexible, headerEncoder, WriteV2);
                case 3:
                    return new Encoder<ResponseHeader, LeaveGroupResponse>(API_KEY, 3, flexible, headerEncoder, WriteV3);
                case 4:
                    return new Encoder<ResponseHeader, LeaveGroupResponse>(API_KEY, 4, flexible, headerEncoder, WriteV4);
                case 5:
                    return new Encoder<ResponseHeader, LeaveGroupResponse>(API_KEY, 5, flexible, headerEncoder, WriteV5);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        public static IDecoder<ResponseHeader, LeaveGroupResponse> CreateDecoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 5 ? apiVersion : new Version(5);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerDecoder = ResponseHeaderSerde.CreateDecoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Decoder<ResponseHeader, LeaveGroupResponse>(API_KEY, 0, flexible, headerDecoder, ReadV0);
                case 1:
                    return new Decoder<ResponseHeader, LeaveGroupResponse>(API_KEY, 1, flexible, headerDecoder, ReadV1);
                case 2:
                    return new Decoder<ResponseHeader, LeaveGroupResponse>(API_KEY, 2, flexible, headerDecoder, ReadV2);
                case 3:
                    return new Decoder<ResponseHeader, LeaveGroupResponse>(API_KEY, 3, flexible, headerDecoder, ReadV3);
                case 4:
                    return new Decoder<ResponseHeader, LeaveGroupResponse>(API_KEY, 4, flexible, headerDecoder, ReadV4);
                case 5:
                    return new Decoder<ResponseHeader, LeaveGroupResponse>(API_KEY, 5, flexible, headerDecoder, ReadV5);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        private static int WriteV0(byte[] buffer, int index, LeaveGroupResponse message)
        {
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
            return index;
        }
        private static (int Offset, LeaveGroupResponse Value) ReadV0(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var membersField = ImmutableArray<MemberResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            return (index, new(
                throttleTimeMsField,
                errorCodeField,
                membersField,
                taggedFields
            ));
        }
        private static int WriteV1(byte[] buffer, int index, LeaveGroupResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
            return index;
        }
        private static (int Offset, LeaveGroupResponse Value) ReadV1(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var membersField = ImmutableArray<MemberResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            return (index, new(
                throttleTimeMsField,
                errorCodeField,
                membersField,
                taggedFields
            ));
        }
        private static int WriteV2(byte[] buffer, int index, LeaveGroupResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
            return index;
        }
        private static (int Offset, LeaveGroupResponse Value) ReadV2(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var membersField = ImmutableArray<MemberResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            return (index, new(
                throttleTimeMsField,
                errorCodeField,
                membersField,
                taggedFields
            ));
        }
        private static int WriteV3(byte[] buffer, int index, LeaveGroupResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = BinaryEncoder.WriteArray<MemberResponse>(buffer, index, message.MembersField, MemberResponseSerde.WriteV3);
            return index;
        }
        private static (int Offset, LeaveGroupResponse Value) ReadV3(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var membersField = ImmutableArray<MemberResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, var _membersField_) = BinaryDecoder.ReadArray<MemberResponse>(buffer, index, MemberResponseSerde.ReadV3);
            if (_membersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Members'");
            else
                membersField = _membersField_.Value;
            return (index, new(
                throttleTimeMsField,
                errorCodeField,
                membersField,
                taggedFields
            ));
        }
        private static int WriteV4(byte[] buffer, int index, LeaveGroupResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = BinaryEncoder.WriteCompactArray<MemberResponse>(buffer, index, message.MembersField, MemberResponseSerde.WriteV4);
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
        private static (int Offset, LeaveGroupResponse Value) ReadV4(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var membersField = ImmutableArray<MemberResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, var _membersField_) = BinaryDecoder.ReadCompactArray<MemberResponse>(buffer, index, MemberResponseSerde.ReadV4);
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
                throttleTimeMsField,
                errorCodeField,
                membersField,
                taggedFields
            ));
        }
        private static int WriteV5(byte[] buffer, int index, LeaveGroupResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = BinaryEncoder.WriteCompactArray<MemberResponse>(buffer, index, message.MembersField, MemberResponseSerde.WriteV5);
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
        private static (int Offset, LeaveGroupResponse Value) ReadV5(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var membersField = ImmutableArray<MemberResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, var _membersField_) = BinaryDecoder.ReadCompactArray<MemberResponse>(buffer, index, MemberResponseSerde.ReadV5);
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
                throttleTimeMsField,
                errorCodeField,
                membersField,
                taggedFields
            ));
        }
        [GeneratedCode("kgen", "1.0.0.0")]
        private static class MemberResponseSerde
        {
            public static int WriteV0(byte[] buffer, int index, MemberResponse message)
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
            public static (int Offset, MemberResponse Value) ReadV0(byte[] buffer, int index)
            {
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var errorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return (index, new(
                    memberIdField,
                    groupInstanceIdField,
                    errorCodeField,
                    taggedFields
                ));
            }
            public static int WriteV1(byte[] buffer, int index, MemberResponse message)
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
            public static (int Offset, MemberResponse Value) ReadV1(byte[] buffer, int index)
            {
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var errorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return (index, new(
                    memberIdField,
                    groupInstanceIdField,
                    errorCodeField,
                    taggedFields
                ));
            }
            public static int WriteV2(byte[] buffer, int index, MemberResponse message)
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
            public static (int Offset, MemberResponse Value) ReadV2(byte[] buffer, int index)
            {
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var errorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return (index, new(
                    memberIdField,
                    groupInstanceIdField,
                    errorCodeField,
                    taggedFields
                ));
            }
            public static int WriteV3(byte[] buffer, int index, MemberResponse message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
                index = BinaryEncoder.WriteNullableString(buffer, index, message.GroupInstanceIdField);
                index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
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
            public static (int Offset, MemberResponse Value) ReadV3(byte[] buffer, int index)
            {
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var errorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
                (index, groupInstanceIdField) = BinaryDecoder.ReadNullableString(buffer, index);
                (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                return (index, new(
                    memberIdField,
                    groupInstanceIdField,
                    errorCodeField,
                    taggedFields
                ));
            }
            public static int WriteV4(byte[] buffer, int index, MemberResponse message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.MemberIdField);
                index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
                index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
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
            public static (int Offset, MemberResponse Value) ReadV4(byte[] buffer, int index)
            {
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var errorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, memberIdField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, groupInstanceIdField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
                (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
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
                    errorCodeField,
                    taggedFields
                ));
            }
            public static int WriteV5(byte[] buffer, int index, MemberResponse message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.MemberIdField);
                index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
                index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
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
            public static (int Offset, MemberResponse Value) ReadV5(byte[] buffer, int index)
            {
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var errorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, memberIdField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, groupInstanceIdField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
                (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
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
                    errorCodeField,
                    taggedFields
                ));
            }
        }
    }
}