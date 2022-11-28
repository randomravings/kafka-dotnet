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
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV04(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV05(ref b),
        };
        private static readonly EncodeDelegate<LeaveGroupResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
            (b, m) => WriteV05(b, m),
        };
        public static LeaveGroupResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, LeaveGroupResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static LeaveGroupResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var membersField = ImmutableArray<MemberResponse>.Empty;
            return new(
                throttleTimeMsField,
                errorCodeField,
                membersField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, LeaveGroupResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            return buffer;
        }
        private static LeaveGroupResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var membersField = ImmutableArray<MemberResponse>.Empty;
            return new(
                throttleTimeMsField,
                errorCodeField,
                membersField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, LeaveGroupResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            return buffer;
        }
        private static LeaveGroupResponse ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var membersField = ImmutableArray<MemberResponse>.Empty;
            return new(
                throttleTimeMsField,
                errorCodeField,
                membersField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, LeaveGroupResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            return buffer;
        }
        private static LeaveGroupResponse ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var membersField = Decoder.ReadArray<MemberResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => MemberResponseSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Members'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                membersField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, LeaveGroupResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteArray<MemberResponse>(buffer, message.MembersField, (b, i) => MemberResponseSerde.WriteV03(b, i));
            return buffer;
        }
        private static LeaveGroupResponse ReadV04(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var membersField = Decoder.ReadCompactArray<MemberResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => MemberResponseSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Members'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                membersField
            );
        }
        private static Memory<byte> WriteV04(Memory<byte> buffer, LeaveGroupResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteCompactArray<MemberResponse>(buffer, message.MembersField, (b, i) => MemberResponseSerde.WriteV04(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static LeaveGroupResponse ReadV05(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var membersField = Decoder.ReadCompactArray<MemberResponse>(ref buffer, (ref ReadOnlyMemory<byte> b) => MemberResponseSerde.ReadV05(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Members'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                membersField
            );
        }
        private static Memory<byte> WriteV05(Memory<byte> buffer, LeaveGroupResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteCompactArray<MemberResponse>(buffer, message.MembersField, (b, i) => MemberResponseSerde.WriteV05(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class MemberResponseSerde
        {
            public static MemberResponse ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var memberIdField = Decoder.ReadString(ref buffer);
                var groupInstanceIdField = Decoder.ReadNullableString(ref buffer);
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                return new(
                    memberIdField,
                    groupInstanceIdField,
                    errorCodeField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, MemberResponse message)
            {
                buffer = Encoder.WriteString(buffer, message.MemberIdField);
                buffer = Encoder.WriteNullableString(buffer, message.GroupInstanceIdField);
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                return buffer;
            }
            public static MemberResponse ReadV04(ref ReadOnlyMemory<byte> buffer)
            {
                var memberIdField = Decoder.ReadCompactString(ref buffer);
                var groupInstanceIdField = Decoder.ReadCompactNullableString(ref buffer);
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    memberIdField,
                    groupInstanceIdField,
                    errorCodeField
                );
            }
            public static Memory<byte> WriteV04(Memory<byte> buffer, MemberResponse message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.MemberIdField);
                buffer = Encoder.WriteCompactNullableString(buffer, message.GroupInstanceIdField);
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static MemberResponse ReadV05(ref ReadOnlyMemory<byte> buffer)
            {
                var memberIdField = Decoder.ReadCompactString(ref buffer);
                var groupInstanceIdField = Decoder.ReadCompactNullableString(ref buffer);
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    memberIdField,
                    groupInstanceIdField,
                    errorCodeField
                );
            }
            public static Memory<byte> WriteV05(Memory<byte> buffer, MemberResponse message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.MemberIdField);
                buffer = Encoder.WriteCompactNullableString(buffer, message.GroupInstanceIdField);
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
    }
}