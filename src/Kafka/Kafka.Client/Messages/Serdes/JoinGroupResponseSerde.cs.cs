using JoinGroupResponseMember = Kafka.Client.Messages.JoinGroupResponse.JoinGroupResponseMember;
using Kafka.Common.Encoding;
using Kafka.Common.Exceptions;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using Version = Kafka.Common.Model.Version;

namespace Kafka.Client.Messages.Serdes
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class JoinGroupResponseSerde
    {
        private static readonly ApiKey API_KEY = new(11);
        private static readonly VersionRange API_VERSIONS = new(0, 9);
        private static readonly VersionRange FLEXBILE_VERSIONS = new (6, 32767);
        public static IEncoder<ResponseHeader, JoinGroupResponse> CreateEncoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 9 ? apiVersion : new Version(9);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerEncoder = ResponseHeaderSerde.CreateEncoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Encoder<ResponseHeader, JoinGroupResponse>(API_KEY, 0, flexible, headerEncoder, WriteV0);
                case 1:
                    return new Encoder<ResponseHeader, JoinGroupResponse>(API_KEY, 1, flexible, headerEncoder, WriteV1);
                case 2:
                    return new Encoder<ResponseHeader, JoinGroupResponse>(API_KEY, 2, flexible, headerEncoder, WriteV2);
                case 3:
                    return new Encoder<ResponseHeader, JoinGroupResponse>(API_KEY, 3, flexible, headerEncoder, WriteV3);
                case 4:
                    return new Encoder<ResponseHeader, JoinGroupResponse>(API_KEY, 4, flexible, headerEncoder, WriteV4);
                case 5:
                    return new Encoder<ResponseHeader, JoinGroupResponse>(API_KEY, 5, flexible, headerEncoder, WriteV5);
                case 6:
                    return new Encoder<ResponseHeader, JoinGroupResponse>(API_KEY, 6, flexible, headerEncoder, WriteV6);
                case 7:
                    return new Encoder<ResponseHeader, JoinGroupResponse>(API_KEY, 7, flexible, headerEncoder, WriteV7);
                case 8:
                    return new Encoder<ResponseHeader, JoinGroupResponse>(API_KEY, 8, flexible, headerEncoder, WriteV8);
                case 9:
                    return new Encoder<ResponseHeader, JoinGroupResponse>(API_KEY, 9, flexible, headerEncoder, WriteV9);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        public static IDecoder<ResponseHeader, JoinGroupResponse> CreateDecoder(Version apiVersion)
        {
            apiVersion = apiVersion <= 9 ? apiVersion : new Version(9);
            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);
            var headerDecoder = ResponseHeaderSerde.CreateDecoder(flexible);
            switch (apiVersion)
            {
                case 0:
                    return new Decoder<ResponseHeader, JoinGroupResponse>(API_KEY, 0, flexible, headerDecoder, ReadV0);
                case 1:
                    return new Decoder<ResponseHeader, JoinGroupResponse>(API_KEY, 1, flexible, headerDecoder, ReadV1);
                case 2:
                    return new Decoder<ResponseHeader, JoinGroupResponse>(API_KEY, 2, flexible, headerDecoder, ReadV2);
                case 3:
                    return new Decoder<ResponseHeader, JoinGroupResponse>(API_KEY, 3, flexible, headerDecoder, ReadV3);
                case 4:
                    return new Decoder<ResponseHeader, JoinGroupResponse>(API_KEY, 4, flexible, headerDecoder, ReadV4);
                case 5:
                    return new Decoder<ResponseHeader, JoinGroupResponse>(API_KEY, 5, flexible, headerDecoder, ReadV5);
                case 6:
                    return new Decoder<ResponseHeader, JoinGroupResponse>(API_KEY, 6, flexible, headerDecoder, ReadV6);
                case 7:
                    return new Decoder<ResponseHeader, JoinGroupResponse>(API_KEY, 7, flexible, headerDecoder, ReadV7);
                case 8:
                    return new Decoder<ResponseHeader, JoinGroupResponse>(API_KEY, 8, flexible, headerDecoder, ReadV8);
                case 9:
                    return new Decoder<ResponseHeader, JoinGroupResponse>(API_KEY, 9, flexible, headerDecoder, ReadV9);
                default:
                    throw new UnsupportedVersionException();
            }
        }
        private static int WriteV0(byte[] buffer, int index, JoinGroupResponse message)
        {
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.GenerationIdField);
            if (message.ProtocolNameField == null)
                throw new ArgumentNullException(nameof(message.ProtocolNameField));
            index = BinaryEncoder.WriteString(buffer, index, message.ProtocolNameField);
            index = BinaryEncoder.WriteString(buffer, index, message.LeaderField);
            index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteArray<JoinGroupResponseMember>(buffer, index, message.MembersField, JoinGroupResponseMemberSerde.WriteV0);
            return index;
        }
        private static (int Offset, JoinGroupResponse Value) ReadV0(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var generationIdField = default(int);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var leaderField = "";
            var skipAssignmentField = default(bool);
            var memberIdField = "";
            var membersField = ImmutableArray<JoinGroupResponseMember>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, generationIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, protocolNameField) = BinaryDecoder.ReadString(buffer, index);
            (index, leaderField) = BinaryDecoder.ReadString(buffer, index);
            (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, var _membersField_) = BinaryDecoder.ReadArray<JoinGroupResponseMember>(buffer, index, JoinGroupResponseMemberSerde.ReadV0);
            if (_membersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Members'");
            else
                membersField = _membersField_.Value;
            return (index, new(
                throttleTimeMsField,
                errorCodeField,
                generationIdField,
                protocolTypeField,
                protocolNameField,
                leaderField,
                skipAssignmentField,
                memberIdField,
                membersField,
                taggedFields
            ));
        }
        private static int WriteV1(byte[] buffer, int index, JoinGroupResponse message)
        {
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.GenerationIdField);
            if (message.ProtocolNameField == null)
                throw new ArgumentNullException(nameof(message.ProtocolNameField));
            index = BinaryEncoder.WriteString(buffer, index, message.ProtocolNameField);
            index = BinaryEncoder.WriteString(buffer, index, message.LeaderField);
            index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteArray<JoinGroupResponseMember>(buffer, index, message.MembersField, JoinGroupResponseMemberSerde.WriteV1);
            return index;
        }
        private static (int Offset, JoinGroupResponse Value) ReadV1(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var generationIdField = default(int);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var leaderField = "";
            var skipAssignmentField = default(bool);
            var memberIdField = "";
            var membersField = ImmutableArray<JoinGroupResponseMember>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, generationIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, protocolNameField) = BinaryDecoder.ReadString(buffer, index);
            (index, leaderField) = BinaryDecoder.ReadString(buffer, index);
            (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, var _membersField_) = BinaryDecoder.ReadArray<JoinGroupResponseMember>(buffer, index, JoinGroupResponseMemberSerde.ReadV1);
            if (_membersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Members'");
            else
                membersField = _membersField_.Value;
            return (index, new(
                throttleTimeMsField,
                errorCodeField,
                generationIdField,
                protocolTypeField,
                protocolNameField,
                leaderField,
                skipAssignmentField,
                memberIdField,
                membersField,
                taggedFields
            ));
        }
        private static int WriteV2(byte[] buffer, int index, JoinGroupResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.GenerationIdField);
            if (message.ProtocolNameField == null)
                throw new ArgumentNullException(nameof(message.ProtocolNameField));
            index = BinaryEncoder.WriteString(buffer, index, message.ProtocolNameField);
            index = BinaryEncoder.WriteString(buffer, index, message.LeaderField);
            index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteArray<JoinGroupResponseMember>(buffer, index, message.MembersField, JoinGroupResponseMemberSerde.WriteV2);
            return index;
        }
        private static (int Offset, JoinGroupResponse Value) ReadV2(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var generationIdField = default(int);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var leaderField = "";
            var skipAssignmentField = default(bool);
            var memberIdField = "";
            var membersField = ImmutableArray<JoinGroupResponseMember>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, generationIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, protocolNameField) = BinaryDecoder.ReadString(buffer, index);
            (index, leaderField) = BinaryDecoder.ReadString(buffer, index);
            (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, var _membersField_) = BinaryDecoder.ReadArray<JoinGroupResponseMember>(buffer, index, JoinGroupResponseMemberSerde.ReadV2);
            if (_membersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Members'");
            else
                membersField = _membersField_.Value;
            return (index, new(
                throttleTimeMsField,
                errorCodeField,
                generationIdField,
                protocolTypeField,
                protocolNameField,
                leaderField,
                skipAssignmentField,
                memberIdField,
                membersField,
                taggedFields
            ));
        }
        private static int WriteV3(byte[] buffer, int index, JoinGroupResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.GenerationIdField);
            if (message.ProtocolNameField == null)
                throw new ArgumentNullException(nameof(message.ProtocolNameField));
            index = BinaryEncoder.WriteString(buffer, index, message.ProtocolNameField);
            index = BinaryEncoder.WriteString(buffer, index, message.LeaderField);
            index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteArray<JoinGroupResponseMember>(buffer, index, message.MembersField, JoinGroupResponseMemberSerde.WriteV3);
            return index;
        }
        private static (int Offset, JoinGroupResponse Value) ReadV3(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var generationIdField = default(int);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var leaderField = "";
            var skipAssignmentField = default(bool);
            var memberIdField = "";
            var membersField = ImmutableArray<JoinGroupResponseMember>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, generationIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, protocolNameField) = BinaryDecoder.ReadString(buffer, index);
            (index, leaderField) = BinaryDecoder.ReadString(buffer, index);
            (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, var _membersField_) = BinaryDecoder.ReadArray<JoinGroupResponseMember>(buffer, index, JoinGroupResponseMemberSerde.ReadV3);
            if (_membersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Members'");
            else
                membersField = _membersField_.Value;
            return (index, new(
                throttleTimeMsField,
                errorCodeField,
                generationIdField,
                protocolTypeField,
                protocolNameField,
                leaderField,
                skipAssignmentField,
                memberIdField,
                membersField,
                taggedFields
            ));
        }
        private static int WriteV4(byte[] buffer, int index, JoinGroupResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.GenerationIdField);
            if (message.ProtocolNameField == null)
                throw new ArgumentNullException(nameof(message.ProtocolNameField));
            index = BinaryEncoder.WriteString(buffer, index, message.ProtocolNameField);
            index = BinaryEncoder.WriteString(buffer, index, message.LeaderField);
            index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteArray<JoinGroupResponseMember>(buffer, index, message.MembersField, JoinGroupResponseMemberSerde.WriteV4);
            return index;
        }
        private static (int Offset, JoinGroupResponse Value) ReadV4(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var generationIdField = default(int);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var leaderField = "";
            var skipAssignmentField = default(bool);
            var memberIdField = "";
            var membersField = ImmutableArray<JoinGroupResponseMember>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, generationIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, protocolNameField) = BinaryDecoder.ReadString(buffer, index);
            (index, leaderField) = BinaryDecoder.ReadString(buffer, index);
            (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, var _membersField_) = BinaryDecoder.ReadArray<JoinGroupResponseMember>(buffer, index, JoinGroupResponseMemberSerde.ReadV4);
            if (_membersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Members'");
            else
                membersField = _membersField_.Value;
            return (index, new(
                throttleTimeMsField,
                errorCodeField,
                generationIdField,
                protocolTypeField,
                protocolNameField,
                leaderField,
                skipAssignmentField,
                memberIdField,
                membersField,
                taggedFields
            ));
        }
        private static int WriteV5(byte[] buffer, int index, JoinGroupResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.GenerationIdField);
            if (message.ProtocolNameField == null)
                throw new ArgumentNullException(nameof(message.ProtocolNameField));
            index = BinaryEncoder.WriteString(buffer, index, message.ProtocolNameField);
            index = BinaryEncoder.WriteString(buffer, index, message.LeaderField);
            index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteArray<JoinGroupResponseMember>(buffer, index, message.MembersField, JoinGroupResponseMemberSerde.WriteV5);
            return index;
        }
        private static (int Offset, JoinGroupResponse Value) ReadV5(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var generationIdField = default(int);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var leaderField = "";
            var skipAssignmentField = default(bool);
            var memberIdField = "";
            var membersField = ImmutableArray<JoinGroupResponseMember>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, generationIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, protocolNameField) = BinaryDecoder.ReadString(buffer, index);
            (index, leaderField) = BinaryDecoder.ReadString(buffer, index);
            (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
            (index, var _membersField_) = BinaryDecoder.ReadArray<JoinGroupResponseMember>(buffer, index, JoinGroupResponseMemberSerde.ReadV5);
            if (_membersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Members'");
            else
                membersField = _membersField_.Value;
            return (index, new(
                throttleTimeMsField,
                errorCodeField,
                generationIdField,
                protocolTypeField,
                protocolNameField,
                leaderField,
                skipAssignmentField,
                memberIdField,
                membersField,
                taggedFields
            ));
        }
        private static int WriteV6(byte[] buffer, int index, JoinGroupResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.GenerationIdField);
            if (message.ProtocolNameField == null)
                throw new ArgumentNullException(nameof(message.ProtocolNameField));
            index = BinaryEncoder.WriteCompactString(buffer, index, message.ProtocolNameField);
            index = BinaryEncoder.WriteCompactString(buffer, index, message.LeaderField);
            index = BinaryEncoder.WriteCompactString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteCompactArray<JoinGroupResponseMember>(buffer, index, message.MembersField, JoinGroupResponseMemberSerde.WriteV6);
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
        private static (int Offset, JoinGroupResponse Value) ReadV6(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var generationIdField = default(int);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var leaderField = "";
            var skipAssignmentField = default(bool);
            var memberIdField = "";
            var membersField = ImmutableArray<JoinGroupResponseMember>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, generationIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, protocolNameField) = BinaryDecoder.ReadCompactString(buffer, index);
            (index, leaderField) = BinaryDecoder.ReadCompactString(buffer, index);
            (index, memberIdField) = BinaryDecoder.ReadCompactString(buffer, index);
            (index, var _membersField_) = BinaryDecoder.ReadCompactArray<JoinGroupResponseMember>(buffer, index, JoinGroupResponseMemberSerde.ReadV6);
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
                generationIdField,
                protocolTypeField,
                protocolNameField,
                leaderField,
                skipAssignmentField,
                memberIdField,
                membersField,
                taggedFields
            ));
        }
        private static int WriteV7(byte[] buffer, int index, JoinGroupResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.GenerationIdField);
            index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.ProtocolTypeField);
            index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.ProtocolNameField);
            index = BinaryEncoder.WriteCompactString(buffer, index, message.LeaderField);
            index = BinaryEncoder.WriteCompactString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteCompactArray<JoinGroupResponseMember>(buffer, index, message.MembersField, JoinGroupResponseMemberSerde.WriteV7);
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
        private static (int Offset, JoinGroupResponse Value) ReadV7(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var generationIdField = default(int);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var leaderField = "";
            var skipAssignmentField = default(bool);
            var memberIdField = "";
            var membersField = ImmutableArray<JoinGroupResponseMember>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, generationIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, protocolTypeField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
            (index, protocolNameField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
            (index, leaderField) = BinaryDecoder.ReadCompactString(buffer, index);
            (index, memberIdField) = BinaryDecoder.ReadCompactString(buffer, index);
            (index, var _membersField_) = BinaryDecoder.ReadCompactArray<JoinGroupResponseMember>(buffer, index, JoinGroupResponseMemberSerde.ReadV7);
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
                generationIdField,
                protocolTypeField,
                protocolNameField,
                leaderField,
                skipAssignmentField,
                memberIdField,
                membersField,
                taggedFields
            ));
        }
        private static int WriteV8(byte[] buffer, int index, JoinGroupResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.GenerationIdField);
            index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.ProtocolTypeField);
            index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.ProtocolNameField);
            index = BinaryEncoder.WriteCompactString(buffer, index, message.LeaderField);
            index = BinaryEncoder.WriteCompactString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteCompactArray<JoinGroupResponseMember>(buffer, index, message.MembersField, JoinGroupResponseMemberSerde.WriteV8);
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
        private static (int Offset, JoinGroupResponse Value) ReadV8(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var generationIdField = default(int);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var leaderField = "";
            var skipAssignmentField = default(bool);
            var memberIdField = "";
            var membersField = ImmutableArray<JoinGroupResponseMember>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, generationIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, protocolTypeField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
            (index, protocolNameField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
            (index, leaderField) = BinaryDecoder.ReadCompactString(buffer, index);
            (index, memberIdField) = BinaryDecoder.ReadCompactString(buffer, index);
            (index, var _membersField_) = BinaryDecoder.ReadCompactArray<JoinGroupResponseMember>(buffer, index, JoinGroupResponseMemberSerde.ReadV8);
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
                generationIdField,
                protocolTypeField,
                protocolNameField,
                leaderField,
                skipAssignmentField,
                memberIdField,
                membersField,
                taggedFields
            ));
        }
        private static int WriteV9(byte[] buffer, int index, JoinGroupResponse message)
        {
            index = BinaryEncoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = BinaryEncoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = BinaryEncoder.WriteInt32(buffer, index, message.GenerationIdField);
            index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.ProtocolTypeField);
            index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.ProtocolNameField);
            index = BinaryEncoder.WriteCompactString(buffer, index, message.LeaderField);
            index = BinaryEncoder.WriteBoolean(buffer, index, message.SkipAssignmentField);
            index = BinaryEncoder.WriteCompactString(buffer, index, message.MemberIdField);
            index = BinaryEncoder.WriteCompactArray<JoinGroupResponseMember>(buffer, index, message.MembersField, JoinGroupResponseMemberSerde.WriteV9);
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
        private static (int Offset, JoinGroupResponse Value) ReadV9(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var generationIdField = default(int);
            var protocolTypeField = default(string?);
            var protocolNameField = default(string?);
            var leaderField = "";
            var skipAssignmentField = default(bool);
            var memberIdField = "";
            var membersField = ImmutableArray<JoinGroupResponseMember>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, generationIdField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, protocolTypeField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
            (index, protocolNameField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
            (index, leaderField) = BinaryDecoder.ReadCompactString(buffer, index);
            (index, skipAssignmentField) = BinaryDecoder.ReadBoolean(buffer, index);
            (index, memberIdField) = BinaryDecoder.ReadCompactString(buffer, index);
            (index, var _membersField_) = BinaryDecoder.ReadCompactArray<JoinGroupResponseMember>(buffer, index, JoinGroupResponseMemberSerde.ReadV9);
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
                generationIdField,
                protocolTypeField,
                protocolNameField,
                leaderField,
                skipAssignmentField,
                memberIdField,
                membersField,
                taggedFields
            ));
        }
        [GeneratedCode("kgen", "1.0.0.0")]
        private static class JoinGroupResponseMemberSerde
        {
            public static int WriteV0(byte[] buffer, int index, JoinGroupResponseMember message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
                index = BinaryEncoder.WriteBytes(buffer, index, message.MetadataField);
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
            public static (int Offset, JoinGroupResponseMember Value) ReadV0(byte[] buffer, int index)
            {
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var metadataField = ReadOnlyMemory<byte>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
                (index, metadataField) = BinaryDecoder.ReadBytes(buffer, index);
                return (index, new(
                    memberIdField,
                    groupInstanceIdField,
                    metadataField,
                    taggedFields
                ));
            }
            public static int WriteV1(byte[] buffer, int index, JoinGroupResponseMember message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
                index = BinaryEncoder.WriteBytes(buffer, index, message.MetadataField);
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
            public static (int Offset, JoinGroupResponseMember Value) ReadV1(byte[] buffer, int index)
            {
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var metadataField = ReadOnlyMemory<byte>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
                (index, metadataField) = BinaryDecoder.ReadBytes(buffer, index);
                return (index, new(
                    memberIdField,
                    groupInstanceIdField,
                    metadataField,
                    taggedFields
                ));
            }
            public static int WriteV2(byte[] buffer, int index, JoinGroupResponseMember message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
                index = BinaryEncoder.WriteBytes(buffer, index, message.MetadataField);
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
            public static (int Offset, JoinGroupResponseMember Value) ReadV2(byte[] buffer, int index)
            {
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var metadataField = ReadOnlyMemory<byte>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
                (index, metadataField) = BinaryDecoder.ReadBytes(buffer, index);
                return (index, new(
                    memberIdField,
                    groupInstanceIdField,
                    metadataField,
                    taggedFields
                ));
            }
            public static int WriteV3(byte[] buffer, int index, JoinGroupResponseMember message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
                index = BinaryEncoder.WriteBytes(buffer, index, message.MetadataField);
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
            public static (int Offset, JoinGroupResponseMember Value) ReadV3(byte[] buffer, int index)
            {
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var metadataField = ReadOnlyMemory<byte>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
                (index, metadataField) = BinaryDecoder.ReadBytes(buffer, index);
                return (index, new(
                    memberIdField,
                    groupInstanceIdField,
                    metadataField,
                    taggedFields
                ));
            }
            public static int WriteV4(byte[] buffer, int index, JoinGroupResponseMember message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
                index = BinaryEncoder.WriteBytes(buffer, index, message.MetadataField);
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
            public static (int Offset, JoinGroupResponseMember Value) ReadV4(byte[] buffer, int index)
            {
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var metadataField = ReadOnlyMemory<byte>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
                (index, metadataField) = BinaryDecoder.ReadBytes(buffer, index);
                return (index, new(
                    memberIdField,
                    groupInstanceIdField,
                    metadataField,
                    taggedFields
                ));
            }
            public static int WriteV5(byte[] buffer, int index, JoinGroupResponseMember message)
            {
                index = BinaryEncoder.WriteString(buffer, index, message.MemberIdField);
                index = BinaryEncoder.WriteNullableString(buffer, index, message.GroupInstanceIdField);
                index = BinaryEncoder.WriteBytes(buffer, index, message.MetadataField);
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
            public static (int Offset, JoinGroupResponseMember Value) ReadV5(byte[] buffer, int index)
            {
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var metadataField = ReadOnlyMemory<byte>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
                (index, groupInstanceIdField) = BinaryDecoder.ReadNullableString(buffer, index);
                (index, metadataField) = BinaryDecoder.ReadBytes(buffer, index);
                return (index, new(
                    memberIdField,
                    groupInstanceIdField,
                    metadataField,
                    taggedFields
                ));
            }
            public static int WriteV6(byte[] buffer, int index, JoinGroupResponseMember message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.MemberIdField);
                index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
                index = BinaryEncoder.WriteCompactBytes(buffer, index, message.MetadataField);
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
            public static (int Offset, JoinGroupResponseMember Value) ReadV6(byte[] buffer, int index)
            {
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var metadataField = ReadOnlyMemory<byte>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, memberIdField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, groupInstanceIdField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
                (index, metadataField) = BinaryDecoder.ReadCompactBytes(buffer, index);
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
                    metadataField,
                    taggedFields
                ));
            }
            public static int WriteV7(byte[] buffer, int index, JoinGroupResponseMember message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.MemberIdField);
                index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
                index = BinaryEncoder.WriteCompactBytes(buffer, index, message.MetadataField);
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
            public static (int Offset, JoinGroupResponseMember Value) ReadV7(byte[] buffer, int index)
            {
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var metadataField = ReadOnlyMemory<byte>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, memberIdField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, groupInstanceIdField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
                (index, metadataField) = BinaryDecoder.ReadCompactBytes(buffer, index);
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
                    metadataField,
                    taggedFields
                ));
            }
            public static int WriteV8(byte[] buffer, int index, JoinGroupResponseMember message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.MemberIdField);
                index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
                index = BinaryEncoder.WriteCompactBytes(buffer, index, message.MetadataField);
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
            public static (int Offset, JoinGroupResponseMember Value) ReadV8(byte[] buffer, int index)
            {
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var metadataField = ReadOnlyMemory<byte>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, memberIdField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, groupInstanceIdField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
                (index, metadataField) = BinaryDecoder.ReadCompactBytes(buffer, index);
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
                    metadataField,
                    taggedFields
                ));
            }
            public static int WriteV9(byte[] buffer, int index, JoinGroupResponseMember message)
            {
                index = BinaryEncoder.WriteCompactString(buffer, index, message.MemberIdField);
                index = BinaryEncoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
                index = BinaryEncoder.WriteCompactBytes(buffer, index, message.MetadataField);
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
            public static (int Offset, JoinGroupResponseMember Value) ReadV9(byte[] buffer, int index)
            {
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var metadataField = ReadOnlyMemory<byte>.Empty;
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, memberIdField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, groupInstanceIdField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
                (index, metadataField) = BinaryDecoder.ReadCompactBytes(buffer, index);
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
                    metadataField,
                    taggedFields
                ));
            }
        }
    }
}