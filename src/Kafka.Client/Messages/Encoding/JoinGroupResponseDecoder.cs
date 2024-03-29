using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
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
        protected override DecodeValue<ResponseHeaderData> GetHeaderDecoder(short apiVersion)
        {
            if (FlexibleVersions.Includes(apiVersion))
                return ResponseHeaderDecoder.ReadV1;
            else
                return ResponseHeaderDecoder.ReadV0;
        }
        protected override DecodeValue<JoinGroupResponseData> GetMessageDecoder(short apiVersion) =>
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
        private static DecodeResult<JoinGroupResponseData> ReadV0([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
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
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, generationIdField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, protocolNameField) = BinaryDecoder.ReadString(buffer, i);
            (i, leaderField) = BinaryDecoder.ReadString(buffer, i);
            (i, memberIdField) = BinaryDecoder.ReadString(buffer, i);
            (i, membersField) = BinaryDecoder.ReadArray<JoinGroupResponseMember>(buffer, i, JoinGroupResponseMemberDecoder.ReadV0);
            if (membersField.IsDefault)
                throw new InvalidDataException("membersField was null");
;
            return new(i, new(
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
        private static DecodeResult<JoinGroupResponseData> ReadV1([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
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
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, generationIdField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, protocolNameField) = BinaryDecoder.ReadString(buffer, i);
            (i, leaderField) = BinaryDecoder.ReadString(buffer, i);
            (i, memberIdField) = BinaryDecoder.ReadString(buffer, i);
            (i, membersField) = BinaryDecoder.ReadArray<JoinGroupResponseMember>(buffer, i, JoinGroupResponseMemberDecoder.ReadV1);
            if (membersField.IsDefault)
                throw new InvalidDataException("membersField was null");
;
            return new(i, new(
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
        private static DecodeResult<JoinGroupResponseData> ReadV2([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
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
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, generationIdField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, protocolNameField) = BinaryDecoder.ReadString(buffer, i);
            (i, leaderField) = BinaryDecoder.ReadString(buffer, i);
            (i, memberIdField) = BinaryDecoder.ReadString(buffer, i);
            (i, membersField) = BinaryDecoder.ReadArray<JoinGroupResponseMember>(buffer, i, JoinGroupResponseMemberDecoder.ReadV2);
            if (membersField.IsDefault)
                throw new InvalidDataException("membersField was null");
;
            return new(i, new(
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
        private static DecodeResult<JoinGroupResponseData> ReadV3([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
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
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, generationIdField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, protocolNameField) = BinaryDecoder.ReadString(buffer, i);
            (i, leaderField) = BinaryDecoder.ReadString(buffer, i);
            (i, memberIdField) = BinaryDecoder.ReadString(buffer, i);
            (i, membersField) = BinaryDecoder.ReadArray<JoinGroupResponseMember>(buffer, i, JoinGroupResponseMemberDecoder.ReadV3);
            if (membersField.IsDefault)
                throw new InvalidDataException("membersField was null");
;
            return new(i, new(
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
        private static DecodeResult<JoinGroupResponseData> ReadV4([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
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
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, generationIdField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, protocolNameField) = BinaryDecoder.ReadString(buffer, i);
            (i, leaderField) = BinaryDecoder.ReadString(buffer, i);
            (i, memberIdField) = BinaryDecoder.ReadString(buffer, i);
            (i, membersField) = BinaryDecoder.ReadArray<JoinGroupResponseMember>(buffer, i, JoinGroupResponseMemberDecoder.ReadV4);
            if (membersField.IsDefault)
                throw new InvalidDataException("membersField was null");
;
            return new(i, new(
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
        private static DecodeResult<JoinGroupResponseData> ReadV5([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
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
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, generationIdField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, protocolNameField) = BinaryDecoder.ReadString(buffer, i);
            (i, leaderField) = BinaryDecoder.ReadString(buffer, i);
            (i, memberIdField) = BinaryDecoder.ReadString(buffer, i);
            (i, membersField) = BinaryDecoder.ReadArray<JoinGroupResponseMember>(buffer, i, JoinGroupResponseMemberDecoder.ReadV5);
            if (membersField.IsDefault)
                throw new InvalidDataException("membersField was null");
;
            return new(i, new(
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
        private static DecodeResult<JoinGroupResponseData> ReadV6([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
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
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, generationIdField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, protocolNameField) = BinaryDecoder.ReadCompactString(buffer, i);
            (i, leaderField) = BinaryDecoder.ReadCompactString(buffer, i);
            (i, memberIdField) = BinaryDecoder.ReadCompactString(buffer, i);
            (i, membersField) = BinaryDecoder.ReadCompactArray<JoinGroupResponseMember>(buffer, i, JoinGroupResponseMemberDecoder.ReadV6);
            if (membersField.IsDefault)
                throw new InvalidDataException("membersField was null");
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
        private static DecodeResult<JoinGroupResponseData> ReadV7([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
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
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, generationIdField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, protocolTypeField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
            (i, protocolNameField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
            (i, leaderField) = BinaryDecoder.ReadCompactString(buffer, i);
            (i, memberIdField) = BinaryDecoder.ReadCompactString(buffer, i);
            (i, membersField) = BinaryDecoder.ReadCompactArray<JoinGroupResponseMember>(buffer, i, JoinGroupResponseMemberDecoder.ReadV7);
            if (membersField.IsDefault)
                throw new InvalidDataException("membersField was null");
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
        private static DecodeResult<JoinGroupResponseData> ReadV8([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
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
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, generationIdField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, protocolTypeField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
            (i, protocolNameField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
            (i, leaderField) = BinaryDecoder.ReadCompactString(buffer, i);
            (i, memberIdField) = BinaryDecoder.ReadCompactString(buffer, i);
            (i, membersField) = BinaryDecoder.ReadCompactArray<JoinGroupResponseMember>(buffer, i, JoinGroupResponseMemberDecoder.ReadV8);
            if (membersField.IsDefault)
                throw new InvalidDataException("membersField was null");
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
        private static DecodeResult<JoinGroupResponseData> ReadV9([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
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
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, generationIdField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, protocolTypeField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
            (i, protocolNameField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
            (i, leaderField) = BinaryDecoder.ReadCompactString(buffer, i);
            (i, skipAssignmentField) = BinaryDecoder.ReadBoolean(buffer, i);
            (i, memberIdField) = BinaryDecoder.ReadCompactString(buffer, i);
            (i, membersField) = BinaryDecoder.ReadCompactArray<JoinGroupResponseMember>(buffer, i, JoinGroupResponseMemberDecoder.ReadV9);
            if (membersField.IsDefault)
                throw new InvalidDataException("membersField was null");
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
            public static DecodeResult<JoinGroupResponseMember> ReadV0([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var metadataField = Array.Empty<byte>();
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, memberIdField) = BinaryDecoder.ReadString(buffer, i);
                (i, metadataField) = BinaryDecoder.ReadBytes(buffer, i);
                return new(i, new(
                    memberIdField,
                    groupInstanceIdField,
                    metadataField,
                    taggedFields
                ));
            }
            public static DecodeResult<JoinGroupResponseMember> ReadV1([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var metadataField = Array.Empty<byte>();
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, memberIdField) = BinaryDecoder.ReadString(buffer, i);
                (i, metadataField) = BinaryDecoder.ReadBytes(buffer, i);
                return new(i, new(
                    memberIdField,
                    groupInstanceIdField,
                    metadataField,
                    taggedFields
                ));
            }
            public static DecodeResult<JoinGroupResponseMember> ReadV2([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var metadataField = Array.Empty<byte>();
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, memberIdField) = BinaryDecoder.ReadString(buffer, i);
                (i, metadataField) = BinaryDecoder.ReadBytes(buffer, i);
                return new(i, new(
                    memberIdField,
                    groupInstanceIdField,
                    metadataField,
                    taggedFields
                ));
            }
            public static DecodeResult<JoinGroupResponseMember> ReadV3([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var metadataField = Array.Empty<byte>();
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, memberIdField) = BinaryDecoder.ReadString(buffer, i);
                (i, metadataField) = BinaryDecoder.ReadBytes(buffer, i);
                return new(i, new(
                    memberIdField,
                    groupInstanceIdField,
                    metadataField,
                    taggedFields
                ));
            }
            public static DecodeResult<JoinGroupResponseMember> ReadV4([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var metadataField = Array.Empty<byte>();
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, memberIdField) = BinaryDecoder.ReadString(buffer, i);
                (i, metadataField) = BinaryDecoder.ReadBytes(buffer, i);
                return new(i, new(
                    memberIdField,
                    groupInstanceIdField,
                    metadataField,
                    taggedFields
                ));
            }
            public static DecodeResult<JoinGroupResponseMember> ReadV5([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var metadataField = Array.Empty<byte>();
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, memberIdField) = BinaryDecoder.ReadString(buffer, i);
                (i, groupInstanceIdField) = BinaryDecoder.ReadNullableString(buffer, i);
                (i, metadataField) = BinaryDecoder.ReadBytes(buffer, i);
                return new(i, new(
                    memberIdField,
                    groupInstanceIdField,
                    metadataField,
                    taggedFields
                ));
            }
            public static DecodeResult<JoinGroupResponseMember> ReadV6([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var metadataField = Array.Empty<byte>();
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, memberIdField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, groupInstanceIdField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
                (i, metadataField) = BinaryDecoder.ReadCompactBytes(buffer, i);
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
                    memberIdField,
                    groupInstanceIdField,
                    metadataField,
                    taggedFields
                ));
            }
            public static DecodeResult<JoinGroupResponseMember> ReadV7([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var metadataField = Array.Empty<byte>();
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, memberIdField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, groupInstanceIdField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
                (i, metadataField) = BinaryDecoder.ReadCompactBytes(buffer, i);
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
                    memberIdField,
                    groupInstanceIdField,
                    metadataField,
                    taggedFields
                ));
            }
            public static DecodeResult<JoinGroupResponseMember> ReadV8([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var metadataField = Array.Empty<byte>();
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, memberIdField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, groupInstanceIdField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
                (i, metadataField) = BinaryDecoder.ReadCompactBytes(buffer, i);
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
                    memberIdField,
                    groupInstanceIdField,
                    metadataField,
                    taggedFields
                ));
            }
            public static DecodeResult<JoinGroupResponseMember> ReadV9([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var metadataField = Array.Empty<byte>();
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, memberIdField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, groupInstanceIdField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
                (i, metadataField) = BinaryDecoder.ReadCompactBytes(buffer, i);
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
                    memberIdField,
                    groupInstanceIdField,
                    metadataField,
                    taggedFields
                ));
            }
        }
    }
}
