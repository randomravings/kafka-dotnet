using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using MemberResponse = Kafka.Client.Messages.LeaveGroupResponse.MemberResponse;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class LeaveGroupResponseSerde
    {
        private static readonly DecodeDelegate<LeaveGroupResponse>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
            ReadV04,
            ReadV05,
        };
        private static readonly EncodeDelegate<LeaveGroupResponse>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
            WriteV04,
            WriteV05,
        };
        public static LeaveGroupResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, LeaveGroupResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static LeaveGroupResponse ReadV00(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var membersField = ImmutableArray<MemberResponse>.Empty;
            return new(
                throttleTimeMsField,
                errorCodeField,
                membersField
            );
        }
        private static int WriteV00(byte[] buffer, int index, LeaveGroupResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            return index;
        }
        private static LeaveGroupResponse ReadV01(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var membersField = ImmutableArray<MemberResponse>.Empty;
            return new(
                throttleTimeMsField,
                errorCodeField,
                membersField
            );
        }
        private static int WriteV01(byte[] buffer, int index, LeaveGroupResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            return index;
        }
        private static LeaveGroupResponse ReadV02(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var membersField = ImmutableArray<MemberResponse>.Empty;
            return new(
                throttleTimeMsField,
                errorCodeField,
                membersField
            );
        }
        private static int WriteV02(byte[] buffer, int index, LeaveGroupResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            return index;
        }
        private static LeaveGroupResponse ReadV03(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var membersField = Decoder.ReadArray<MemberResponse>(buffer, ref index, MemberResponseSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Members'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                membersField
            );
        }
        private static int WriteV03(byte[] buffer, int index, LeaveGroupResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteArray<MemberResponse>(buffer, index, message.MembersField, MemberResponseSerde.WriteV03);
            return index;
        }
        private static LeaveGroupResponse ReadV04(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var membersField = Decoder.ReadCompactArray<MemberResponse>(buffer, ref index, MemberResponseSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'Members'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                errorCodeField,
                membersField
            );
        }
        private static int WriteV04(byte[] buffer, int index, LeaveGroupResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteCompactArray<MemberResponse>(buffer, index, message.MembersField, MemberResponseSerde.WriteV04);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static LeaveGroupResponse ReadV05(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var membersField = Decoder.ReadCompactArray<MemberResponse>(buffer, ref index, MemberResponseSerde.ReadV05) ?? throw new NullReferenceException("Null not allowed for 'Members'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                errorCodeField,
                membersField
            );
        }
        private static int WriteV05(byte[] buffer, int index, LeaveGroupResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteCompactArray<MemberResponse>(buffer, index, message.MembersField, MemberResponseSerde.WriteV05);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class MemberResponseSerde
        {
            public static MemberResponse ReadV03(byte[] buffer, ref int index)
            {
                var memberIdField = Decoder.ReadString(buffer, ref index);
                var groupInstanceIdField = Decoder.ReadNullableString(buffer, ref index);
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                return new(
                    memberIdField,
                    groupInstanceIdField,
                    errorCodeField
                );
            }
            public static int WriteV03(byte[] buffer, int index, MemberResponse message)
            {
                index = Encoder.WriteString(buffer, index, message.MemberIdField);
                index = Encoder.WriteNullableString(buffer, index, message.GroupInstanceIdField);
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                return index;
            }
            public static MemberResponse ReadV04(byte[] buffer, ref int index)
            {
                var memberIdField = Decoder.ReadCompactString(buffer, ref index);
                var groupInstanceIdField = Decoder.ReadCompactNullableString(buffer, ref index);
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    memberIdField,
                    groupInstanceIdField,
                    errorCodeField
                );
            }
            public static int WriteV04(byte[] buffer, int index, MemberResponse message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.MemberIdField);
                index = Encoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static MemberResponse ReadV05(byte[] buffer, ref int index)
            {
                var memberIdField = Decoder.ReadCompactString(buffer, ref index);
                var groupInstanceIdField = Decoder.ReadCompactNullableString(buffer, ref index);
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    memberIdField,
                    groupInstanceIdField,
                    errorCodeField
                );
            }
            public static int WriteV05(byte[] buffer, int index, MemberResponse message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.MemberIdField);
                index = Encoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
        }
    }
}