using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
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
        protected override DecodeDelegate<ResponseHeaderData> GetHeaderDecoder(short apiVersion)
        {
            if (_flexibleVersions.Includes(apiVersion))
                return ResponseHeaderDecoder.ReadV1;
            else
                return ResponseHeaderDecoder.ReadV0;
        }
        protected override DecodeDelegate<LeaveGroupResponseData> GetMessageDecoder(short apiVersion) =>
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
        private static DecodeResult<LeaveGroupResponseData> ReadV0(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var membersField = ImmutableArray<MemberResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            return new(index, new(
                throttleTimeMsField,
                errorCodeField,
                membersField,
                taggedFields
            ));
        }
        private static DecodeResult<LeaveGroupResponseData> ReadV1(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var membersField = ImmutableArray<MemberResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            return new(index, new(
                throttleTimeMsField,
                errorCodeField,
                membersField,
                taggedFields
            ));
        }
        private static DecodeResult<LeaveGroupResponseData> ReadV2(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var membersField = ImmutableArray<MemberResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            return new(index, new(
                throttleTimeMsField,
                errorCodeField,
                membersField,
                taggedFields
            ));
        }
        private static DecodeResult<LeaveGroupResponseData> ReadV3(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var membersField = ImmutableArray<MemberResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, var _membersField_) = BinaryDecoder.ReadArray<MemberResponse>(buffer, index, MemberResponseDecoder.ReadV3);
            if (_membersField_ == null)
                throw new NullReferenceException("Null not allowed for 'Members'");
            else
                membersField = _membersField_.Value;
            return new(index, new(
                throttleTimeMsField,
                errorCodeField,
                membersField,
                taggedFields
            ));
        }
        private static DecodeResult<LeaveGroupResponseData> ReadV4(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var membersField = ImmutableArray<MemberResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, var _membersField_) = BinaryDecoder.ReadCompactArray<MemberResponse>(buffer, index, MemberResponseDecoder.ReadV4);
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
                membersField,
                taggedFields
            ));
        }
        private static DecodeResult<LeaveGroupResponseData> ReadV5(byte[] buffer, int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = default(short);
            var membersField = ImmutableArray<MemberResponse>.Empty;
            var taggedFields = ImmutableArray<TaggedField>.Empty;
            (index, throttleTimeMsField) = BinaryDecoder.ReadInt32(buffer, index);
            (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
            (index, var _membersField_) = BinaryDecoder.ReadCompactArray<MemberResponse>(buffer, index, MemberResponseDecoder.ReadV5);
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
                membersField,
                taggedFields
            ));
        }
        [GeneratedCodeAttribute("kgen", "1.0.0.0")]
        private static class MemberResponseDecoder
        {
            public static DecodeResult<MemberResponse> ReadV0(byte[] buffer, int index)
            {
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var errorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(index, new(
                    memberIdField,
                    groupInstanceIdField,
                    errorCodeField,
                    taggedFields
                ));
            }
            public static DecodeResult<MemberResponse> ReadV1(byte[] buffer, int index)
            {
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var errorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(index, new(
                    memberIdField,
                    groupInstanceIdField,
                    errorCodeField,
                    taggedFields
                ));
            }
            public static DecodeResult<MemberResponse> ReadV2(byte[] buffer, int index)
            {
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var errorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                return new(index, new(
                    memberIdField,
                    groupInstanceIdField,
                    errorCodeField,
                    taggedFields
                ));
            }
            public static DecodeResult<MemberResponse> ReadV3(byte[] buffer, int index)
            {
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var errorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, memberIdField) = BinaryDecoder.ReadString(buffer, index);
                (index, groupInstanceIdField) = BinaryDecoder.ReadNullableString(buffer, index);
                (index, errorCodeField) = BinaryDecoder.ReadInt16(buffer, index);
                return new(index, new(
                    memberIdField,
                    groupInstanceIdField,
                    errorCodeField,
                    taggedFields
                ));
            }
            public static DecodeResult<MemberResponse> ReadV4(byte[] buffer, int index)
            {
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var errorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, memberIdField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, groupInstanceIdField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
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
                    memberIdField,
                    groupInstanceIdField,
                    errorCodeField,
                    taggedFields
                ));
            }
            public static DecodeResult<MemberResponse> ReadV5(byte[] buffer, int index)
            {
                var memberIdField = "";
                var groupInstanceIdField = default(string?);
                var errorCodeField = default(short);
                var taggedFields = ImmutableArray<TaggedField>.Empty;
                (index, memberIdField) = BinaryDecoder.ReadCompactString(buffer, index);
                (index, groupInstanceIdField) = BinaryDecoder.ReadCompactNullableString(buffer, index);
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
                    memberIdField,
                    groupInstanceIdField,
                    errorCodeField,
                    taggedFields
                ));
            }
        }
    }
}
