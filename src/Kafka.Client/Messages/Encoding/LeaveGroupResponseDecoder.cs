using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using MemberResponse = Kafka.Client.Messages.LeaveGroupResponseData.MemberResponse;

namespace Kafka.Client.Messages.Encoding
{
    [GeneratedCodeAttribute("kgen", "1.0.0.0")]
    internal class LeaveGroupResponseDecoder : 
        ResponseDecoder<ResponseHeaderData, LeaveGroupResponseData>
    {
        internal LeaveGroupResponseDecoder() :
            base(
                ApiKey.LeaveGroup,
                new(0, 5),
                new(4, 32767),
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
        protected override DecodeValue<LeaveGroupResponseData> GetMessageDecoder(short apiVersion) =>
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
        private static DecodeResult<LeaveGroupResponseData> ReadV0([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var membersField = ImmutableArray<MemberResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            return new(i, new(
                throttleTimeMsField,
                errorCodeField,
                membersField,
                taggedFields
            ));
        }
        private static DecodeResult<LeaveGroupResponseData> ReadV1([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var membersField = ImmutableArray<MemberResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            return new(i, new(
                throttleTimeMsField,
                errorCodeField,
                membersField,
                taggedFields
            ));
        }
        private static DecodeResult<LeaveGroupResponseData> ReadV2([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var membersField = ImmutableArray<MemberResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            return new(i, new(
                throttleTimeMsField,
                errorCodeField,
                membersField,
                taggedFields
            ));
        }
        private static DecodeResult<LeaveGroupResponseData> ReadV3([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var membersField = ImmutableArray<MemberResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, var _membersField_) = BinaryDecoder.ReadArray<MemberResponse>(buffer, i, MemberResponseDecoder.ReadV3);
            if (_membersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Members'");
            else
                membersField = _membersField_.Value;
            return new(i, new(
                throttleTimeMsField,
                errorCodeField,
                membersField,
                taggedFields
            ));
        }
        private static DecodeResult<LeaveGroupResponseData> ReadV4([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var membersField = ImmutableArray<MemberResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, var _membersField_) = BinaryDecoder.ReadCompactArray<MemberResponse>(buffer, i, MemberResponseDecoder.ReadV4);
            if (_membersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Members'");
            else
                membersField = _membersField_.Value;
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
                membersField,
                taggedFields
            ));
        }
        private static DecodeResult<LeaveGroupResponseData> ReadV5([NotNull] in byte[] buffer, in int index)
        {
            var i = index;
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var membersField = ImmutableArray<MemberResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (i, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, i);
            (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
            (i, var _membersField_) = BinaryDecoder.ReadCompactArray<MemberResponse>(buffer, i, MemberResponseDecoder.ReadV5);
            if (_membersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Members'");
            else
                membersField = _membersField_.Value;
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
                membersField,
                taggedFields
            ));
        }
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class MemberResponseDecoder
        {
            public static DecodeResult<MemberResponse> ReadV0([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var errorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(i, new(
                    memberIdField,
                    groupInstanceIdField,
                    errorCodeField,
                    taggedFields
                ));
            }
            public static DecodeResult<MemberResponse> ReadV1([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var errorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(i, new(
                    memberIdField,
                    groupInstanceIdField,
                    errorCodeField,
                    taggedFields
                ));
            }
            public static DecodeResult<MemberResponse> ReadV2([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var errorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(i, new(
                    memberIdField,
                    groupInstanceIdField,
                    errorCodeField,
                    taggedFields
                ));
            }
            public static DecodeResult<MemberResponse> ReadV3([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var errorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, memberIdField) = BinaryDecoder.ReadString(buffer, i);
                (i, groupInstanceIdField) = BinaryDecoder.ReadNullableString(buffer, i);
                (i, errorCodeField) = BinaryDecoder.ReadInt16(buffer, i);
                return new(i, new(
                    memberIdField,
                    groupInstanceIdField,
                    errorCodeField,
                    taggedFields
                ));
            }
            public static DecodeResult<MemberResponse> ReadV4([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var errorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, memberIdField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, groupInstanceIdField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
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
                    memberIdField,
                    groupInstanceIdField,
                    errorCodeField,
                    taggedFields
                ));
            }
            public static DecodeResult<MemberResponse> ReadV5([NotNull] in byte[] buffer, in int index)
            {
                var i = index;
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var errorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (i, memberIdField) = BinaryDecoder.ReadCompactString(buffer, i);
                (i, groupInstanceIdField) = BinaryDecoder.ReadCompactNullableString(buffer, i);
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
                    memberIdField,
                    groupInstanceIdField,
                    errorCodeField,
                    taggedFields
                ));
            }
        }
    }
}
