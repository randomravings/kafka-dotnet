using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using MemberResponse = Kafka.Client.Messages.LeaveGroupResponse.MemberResponse;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class LeaveGroupResponseSerde
    {
        private static readonly Func<Stream, LeaveGroupResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
            b => ReadV04(b),
            b => ReadV05(b),
        };
        private static readonly Action<Stream, LeaveGroupResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
            (b, m) => WriteV05(b, m),
        };
        public static LeaveGroupResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, LeaveGroupResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static LeaveGroupResponse ReadV00(Stream buffer)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var membersField = ImmutableArray<MemberResponse>.Empty;
            return new(
                throttleTimeMsField,
                errorCodeField,
                membersField
            );
        }
        private static void WriteV00(Stream buffer, LeaveGroupResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
        }
        private static LeaveGroupResponse ReadV01(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var membersField = ImmutableArray<MemberResponse>.Empty;
            return new(
                throttleTimeMsField,
                errorCodeField,
                membersField
            );
        }
        private static void WriteV01(Stream buffer, LeaveGroupResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
        }
        private static LeaveGroupResponse ReadV02(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var membersField = ImmutableArray<MemberResponse>.Empty;
            return new(
                throttleTimeMsField,
                errorCodeField,
                membersField
            );
        }
        private static void WriteV02(Stream buffer, LeaveGroupResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
        }
        private static LeaveGroupResponse ReadV03(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var membersField = Decoder.ReadArray<MemberResponse>(buffer, b => MemberResponseSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Members'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                membersField
            );
        }
        private static void WriteV03(Stream buffer, LeaveGroupResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteArray<MemberResponse>(buffer, message.MembersField, (b, i) => MemberResponseSerde.WriteV03(b, i));
        }
        private static LeaveGroupResponse ReadV04(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var membersField = Decoder.ReadCompactArray<MemberResponse>(buffer, b => MemberResponseSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'Members'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                membersField
            );
        }
        private static void WriteV04(Stream buffer, LeaveGroupResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteCompactArray<MemberResponse>(buffer, message.MembersField, (b, i) => MemberResponseSerde.WriteV04(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static LeaveGroupResponse ReadV05(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var membersField = Decoder.ReadCompactArray<MemberResponse>(buffer, b => MemberResponseSerde.ReadV05(b)) ?? throw new NullReferenceException("Null not allowed for 'Members'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                membersField
            );
        }
        private static void WriteV05(Stream buffer, LeaveGroupResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteCompactArray<MemberResponse>(buffer, message.MembersField, (b, i) => MemberResponseSerde.WriteV05(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class MemberResponseSerde
        {
            public static MemberResponse ReadV03(Stream buffer)
            {
                var memberIdField = Decoder.ReadString(buffer);
                var groupInstanceIdField = Decoder.ReadNullableString(buffer);
                var errorCodeField = Decoder.ReadInt16(buffer);
                return new(
                    memberIdField,
                    groupInstanceIdField,
                    errorCodeField
                );
            }
            public static void WriteV03(Stream buffer, MemberResponse message)
            {
                Encoder.WriteString(buffer, message.MemberIdField);
                Encoder.WriteNullableString(buffer, message.GroupInstanceIdField);
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
            }
            public static MemberResponse ReadV04(Stream buffer)
            {
                var memberIdField = Decoder.ReadCompactString(buffer);
                var groupInstanceIdField = Decoder.ReadCompactNullableString(buffer);
                var errorCodeField = Decoder.ReadInt16(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    memberIdField,
                    groupInstanceIdField,
                    errorCodeField
                );
            }
            public static void WriteV04(Stream buffer, MemberResponse message)
            {
                Encoder.WriteCompactString(buffer, message.MemberIdField);
                Encoder.WriteCompactNullableString(buffer, message.GroupInstanceIdField);
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static MemberResponse ReadV05(Stream buffer)
            {
                var memberIdField = Decoder.ReadCompactString(buffer);
                var groupInstanceIdField = Decoder.ReadCompactNullableString(buffer);
                var errorCodeField = Decoder.ReadInt16(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    memberIdField,
                    groupInstanceIdField,
                    errorCodeField
                );
            }
            public static void WriteV05(Stream buffer, MemberResponse message)
            {
                Encoder.WriteCompactString(buffer, message.MemberIdField);
                Encoder.WriteCompactNullableString(buffer, message.GroupInstanceIdField);
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
    }
}