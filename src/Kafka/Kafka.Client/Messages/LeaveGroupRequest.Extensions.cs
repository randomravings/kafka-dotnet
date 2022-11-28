using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using MemberIdentity = Kafka.Client.Messages.LeaveGroupRequest.MemberIdentity;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class LeaveGroupRequestSerde
    {
        private static readonly DecodeDelegate<LeaveGroupRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV04(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV05(ref b),
        };
        private static readonly EncodeDelegate<LeaveGroupRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
            (b, m) => WriteV05(b, m),
        };
        public static LeaveGroupRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, LeaveGroupRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static LeaveGroupRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var groupIdField = Decoder.ReadString(ref buffer);
            var memberIdField = Decoder.ReadString(ref buffer);
            var membersField = ImmutableArray<MemberIdentity>.Empty;
            return new(
                groupIdField,
                memberIdField,
                membersField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, LeaveGroupRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.GroupIdField);
            buffer = Encoder.WriteString(buffer, message.MemberIdField);
            return buffer;
        }
        private static LeaveGroupRequest ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var groupIdField = Decoder.ReadString(ref buffer);
            var memberIdField = Decoder.ReadString(ref buffer);
            var membersField = ImmutableArray<MemberIdentity>.Empty;
            return new(
                groupIdField,
                memberIdField,
                membersField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, LeaveGroupRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.GroupIdField);
            buffer = Encoder.WriteString(buffer, message.MemberIdField);
            return buffer;
        }
        private static LeaveGroupRequest ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var groupIdField = Decoder.ReadString(ref buffer);
            var memberIdField = Decoder.ReadString(ref buffer);
            var membersField = ImmutableArray<MemberIdentity>.Empty;
            return new(
                groupIdField,
                memberIdField,
                membersField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, LeaveGroupRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.GroupIdField);
            buffer = Encoder.WriteString(buffer, message.MemberIdField);
            return buffer;
        }
        private static LeaveGroupRequest ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var groupIdField = Decoder.ReadString(ref buffer);
            var memberIdField = "";
            var membersField = Decoder.ReadArray<MemberIdentity>(ref buffer, (ref ReadOnlyMemory<byte> b) => MemberIdentitySerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Members'");
            return new(
                groupIdField,
                memberIdField,
                membersField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, LeaveGroupRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.GroupIdField);
            buffer = Encoder.WriteArray<MemberIdentity>(buffer, message.MembersField, (b, i) => MemberIdentitySerde.WriteV03(b, i));
            return buffer;
        }
        private static LeaveGroupRequest ReadV04(ref ReadOnlyMemory<byte> buffer)
        {
            var groupIdField = Decoder.ReadCompactString(ref buffer);
            var memberIdField = "";
            var membersField = Decoder.ReadCompactArray<MemberIdentity>(ref buffer, (ref ReadOnlyMemory<byte> b) => MemberIdentitySerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Members'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                groupIdField,
                memberIdField,
                membersField
            );
        }
        private static Memory<byte> WriteV04(Memory<byte> buffer, LeaveGroupRequest message)
        {
            buffer = Encoder.WriteCompactString(buffer, message.GroupIdField);
            buffer = Encoder.WriteCompactArray<MemberIdentity>(buffer, message.MembersField, (b, i) => MemberIdentitySerde.WriteV04(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static LeaveGroupRequest ReadV05(ref ReadOnlyMemory<byte> buffer)
        {
            var groupIdField = Decoder.ReadCompactString(ref buffer);
            var memberIdField = "";
            var membersField = Decoder.ReadCompactArray<MemberIdentity>(ref buffer, (ref ReadOnlyMemory<byte> b) => MemberIdentitySerde.ReadV05(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Members'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                groupIdField,
                memberIdField,
                membersField
            );
        }
        private static Memory<byte> WriteV05(Memory<byte> buffer, LeaveGroupRequest message)
        {
            buffer = Encoder.WriteCompactString(buffer, message.GroupIdField);
            buffer = Encoder.WriteCompactArray<MemberIdentity>(buffer, message.MembersField, (b, i) => MemberIdentitySerde.WriteV05(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class MemberIdentitySerde
        {
            public static MemberIdentity ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var memberIdField = Decoder.ReadString(ref buffer);
                var groupInstanceIdField = Decoder.ReadNullableString(ref buffer);
                var reasonField = default(string?);
                return new(
                    memberIdField,
                    groupInstanceIdField,
                    reasonField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, MemberIdentity message)
            {
                buffer = Encoder.WriteString(buffer, message.MemberIdField);
                buffer = Encoder.WriteNullableString(buffer, message.GroupInstanceIdField);
                return buffer;
            }
            public static MemberIdentity ReadV04(ref ReadOnlyMemory<byte> buffer)
            {
                var memberIdField = Decoder.ReadCompactString(ref buffer);
                var groupInstanceIdField = Decoder.ReadCompactNullableString(ref buffer);
                var reasonField = default(string?);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    memberIdField,
                    groupInstanceIdField,
                    reasonField
                );
            }
            public static Memory<byte> WriteV04(Memory<byte> buffer, MemberIdentity message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.MemberIdField);
                buffer = Encoder.WriteCompactNullableString(buffer, message.GroupInstanceIdField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static MemberIdentity ReadV05(ref ReadOnlyMemory<byte> buffer)
            {
                var memberIdField = Decoder.ReadCompactString(ref buffer);
                var groupInstanceIdField = Decoder.ReadCompactNullableString(ref buffer);
                var reasonField = Decoder.ReadCompactNullableString(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    memberIdField,
                    groupInstanceIdField,
                    reasonField
                );
            }
            public static Memory<byte> WriteV05(Memory<byte> buffer, MemberIdentity message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.MemberIdField);
                buffer = Encoder.WriteCompactNullableString(buffer, message.GroupInstanceIdField);
                buffer = Encoder.WriteCompactNullableString(buffer, message.ReasonField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
    }
}