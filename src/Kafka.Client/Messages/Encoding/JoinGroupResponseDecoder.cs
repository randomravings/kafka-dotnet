using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using JoinGroupResponseMember = Kafka.Client.Messages.JoinGroupResponseData.JoinGroupResponseMember;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    internal class JoinGroupResponseDecoder : 
        ResponseDecoder<ResponseHeaderData, JoinGroupResponseData>
    {
        internal JoinGroupResponseDecoder() :
            base(
                ApiKey.JoinGroup,
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
        protected override DecodeDelegate<JoinGroupResponseData> GetMessageDecoder(short apiVersion) =>
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
        private static DecodeResult<JoinGroupResponseData> ReadV0(byte[] buffer, int index)
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
            (index, var _membersField_) = BinaryDecoder.ReadArray<JoinGroupResponseMember>(buffer, index, JoinGroupResponseMemberDecoder.ReadV0);
            if (_membersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Members'");
            else
                membersField = _membersField_.Value;
            return new(index, new(
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
        private static DecodeResult<JoinGroupResponseData> ReadV1(byte[] buffer, int index)
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
            (index, var _membersField_) = BinaryDecoder.ReadArray<JoinGroupResponseMember>(buffer, index, JoinGroupResponseMemberDecoder.ReadV1);
            if (_membersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Members'");
            else
                membersField = _membersField_.Value;
            return new(index, new(
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
        private static DecodeResult<JoinGroupResponseData> ReadV2(byte[] buffer, int index)
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
            (index, var _membersField_) = BinaryDecoder.ReadArray<JoinGroupResponseMember>(buffer, index, JoinGroupResponseMemberDecoder.ReadV2);
            if (_membersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Members'");
            else
                membersField = _membersField_.Value;
            return new(index, new(
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
        private static DecodeResult<JoinGroupResponseData> ReadV3(byte[] buffer, int index)
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
            (index, var _membersField_) = BinaryDecoder.ReadArray<JoinGroupResponseMember>(buffer, index, JoinGroupResponseMemberDecoder.ReadV3);
            if (_membersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Members'");
            else
                membersField = _membersField_.Value;
            return new(index, new(
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
        private static DecodeResult<JoinGroupResponseData> ReadV4(byte[] buffer, int index)
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
            (index, var _membersField_) = BinaryDecoder.ReadArray<JoinGroupResponseMember>(buffer, index, JoinGroupResponseMemberDecoder.ReadV4);
            if (_membersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Members'");
            else
                membersField = _membersField_.Value;
            return new(index, new(
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
        private static DecodeResult<JoinGroupResponseData> ReadV5(byte[] buffer, int index)
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
            (index, var _membersField_) = BinaryDecoder.ReadArray<JoinGroupResponseMember>(buffer, index, JoinGroupResponseMemberDecoder.ReadV5);
            if (_membersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Members'");
            else
                membersField = _membersField_.Value;
            return new(index, new(
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
        private static DecodeResult<JoinGroupResponseData> ReadV6(byte[] buffer, int index)
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
            (index, var _membersField_) = BinaryDecoder.ReadCompactArray<JoinGroupResponseMember>(buffer, index, JoinGroupResponseMemberDecoder.ReadV6);
            if (_membersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Members'");
            else
                membersField = _membersField_.Value;
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
        private static DecodeResult<JoinGroupResponseData> ReadV7(byte[] buffer, int index)
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
            (index, var _membersField_) = BinaryDecoder.ReadCompactArray<JoinGroupResponseMember>(buffer, index, JoinGroupResponseMemberDecoder.ReadV7);
            if (_membersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Members'");
            else
                membersField = _membersField_.Value;
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
        private static DecodeResult<JoinGroupResponseData> ReadV8(byte[] buffer, int index)
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
            (index, var _membersField_) = BinaryDecoder.ReadCompactArray<JoinGroupResponseMember>(buffer, index, JoinGroupResponseMemberDecoder.ReadV8);
            if (_membersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Members'");
            else
                membersField = _membersField_.Value;
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
        private static DecodeResult<JoinGroupResponseData> ReadV9(byte[] buffer, int index)
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
            (index, var _membersField_) = BinaryDecoder.ReadCompactArray<JoinGroupResponseMember>(buffer, index, JoinGroupResponseMemberDecoder.ReadV9);
            if (_membersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Members'");
            else
                membersField = _membersField_.Value;
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
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class JoinGroupResponseMemberDecoder
        {
            public static DecodeResult<JoinGroupResponseMember> ReadV0(byte[] buffer, int index)
            {
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var metadataField = Array.Empty<byte>();
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
                (index, metadataField) = BinaryDecoder.ReadBytes(buffer, index);
                return new(index, new(
                    memberIdField,
                    groupInstanceIdField,
                    metadataField,
                    taggedFields
                ));
            }
            public static DecodeResult<JoinGroupResponseMember> ReadV1(byte[] buffer, int index)
            {
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var metadataField = Array.Empty<byte>();
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
                (index, metadataField) = BinaryDecoder.ReadBytes(buffer, index);
                return new(index, new(
                    memberIdField,
                    groupInstanceIdField,
                    metadataField,
                    taggedFields
                ));
            }
            public static DecodeResult<JoinGroupResponseMember> ReadV2(byte[] buffer, int index)
            {
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var metadataField = Array.Empty<byte>();
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
                (index, metadataField) = BinaryDecoder.ReadBytes(buffer, index);
                return new(index, new(
                    memberIdField,
                    groupInstanceIdField,
                    metadataField,
                    taggedFields
                ));
            }
            public static DecodeResult<JoinGroupResponseMember> ReadV3(byte[] buffer, int index)
            {
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var metadataField = Array.Empty<byte>();
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
                (index, metadataField) = BinaryDecoder.ReadBytes(buffer, index);
                return new(index, new(
                    memberIdField,
                    groupInstanceIdField,
                    metadataField,
                    taggedFields
                ));
            }
            public static DecodeResult<JoinGroupResponseMember> ReadV4(byte[] buffer, int index)
            {
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var metadataField = Array.Empty<byte>();
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
                (index, metadataField) = BinaryDecoder.ReadBytes(buffer, index);
                return new(index, new(
                    memberIdField,
                    groupInstanceIdField,
                    metadataField,
                    taggedFields
                ));
            }
            public static DecodeResult<JoinGroupResponseMember> ReadV5(byte[] buffer, int index)
            {
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var metadataField = Array.Empty<byte>();
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
                (index, groupInstanceIdField) = BinaryDecoder.ReadNullableString(buffer, index);
                (index, metadataField) = BinaryDecoder.ReadBytes(buffer, index);
                return new(index, new(
                    memberIdField,
                    groupInstanceIdField,
                    metadataField,
                    taggedFields
                ));
            }
            public static DecodeResult<JoinGroupResponseMember> ReadV6(byte[] buffer, int index)
            {
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var metadataField = Array.Empty<byte>();
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, memberIdField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, groupInstanceIdField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
                (index, metadataField) = BinaryDecoder.ReadCompactBytes(buffer, index);
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
                    memberIdField,
                    groupInstanceIdField,
                    metadataField,
                    taggedFields
                ));
            }
            public static DecodeResult<JoinGroupResponseMember> ReadV7(byte[] buffer, int index)
            {
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var metadataField = Array.Empty<byte>();
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, memberIdField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, groupInstanceIdField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
                (index, metadataField) = BinaryDecoder.ReadCompactBytes(buffer, index);
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
                    memberIdField,
                    groupInstanceIdField,
                    metadataField,
                    taggedFields
                ));
            }
            public static DecodeResult<JoinGroupResponseMember> ReadV8(byte[] buffer, int index)
            {
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var metadataField = Array.Empty<byte>();
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, memberIdField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, groupInstanceIdField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
                (index, metadataField) = BinaryDecoder.ReadCompactBytes(buffer, index);
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
                    memberIdField,
                    groupInstanceIdField,
                    metadataField,
                    taggedFields
                ));
            }
            public static DecodeResult<JoinGroupResponseMember> ReadV9(byte[] buffer, int index)
            {
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var metadataField = Array.Empty<byte>();
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, memberIdField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, groupInstanceIdField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
                (index, metadataField) = BinaryDecoder.ReadCompactBytes(buffer, index);
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
                    memberIdField,
                    groupInstanceIdField,
                    metadataField,
                    taggedFields
                ));
            }
        }
    }
}
