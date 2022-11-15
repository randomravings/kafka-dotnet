using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using MemberIdentity = Kafka.Client.Messages.LeaveGroupRequest.MemberIdentity;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class LeaveGroupRequestSerde
    {
        private static readonly Func<Stream, LeaveGroupRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
            b => ReadV04(b),
            b => ReadV05(b),
        };
        private static readonly Action<Stream, LeaveGroupRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
            (b, m) => WriteV05(b, m),
        };
        public static LeaveGroupRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, LeaveGroupRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static LeaveGroupRequest ReadV00(Stream buffer)
        {
            var groupIdField = Decoder.ReadString(buffer);
            var memberIdField = Decoder.ReadString(buffer);
            var membersField = ImmutableArray<MemberIdentity>.Empty;
            return new(
                groupIdField,
                memberIdField,
                membersField
            );
        }
        private static void WriteV00(Stream buffer, LeaveGroupRequest message)
        {
            Encoder.WriteString(buffer, message.GroupIdField);
            Encoder.WriteString(buffer, message.MemberIdField);
        }
        private static LeaveGroupRequest ReadV01(Stream buffer)
        {
            var groupIdField = Decoder.ReadString(buffer);
            var memberIdField = Decoder.ReadString(buffer);
            var membersField = ImmutableArray<MemberIdentity>.Empty;
            return new(
                groupIdField,
                memberIdField,
                membersField
            );
        }
        private static void WriteV01(Stream buffer, LeaveGroupRequest message)
        {
            Encoder.WriteString(buffer, message.GroupIdField);
            Encoder.WriteString(buffer, message.MemberIdField);
        }
        private static LeaveGroupRequest ReadV02(Stream buffer)
        {
            var groupIdField = Decoder.ReadString(buffer);
            var memberIdField = Decoder.ReadString(buffer);
            var membersField = ImmutableArray<MemberIdentity>.Empty;
            return new(
                groupIdField,
                memberIdField,
                membersField
            );
        }
        private static void WriteV02(Stream buffer, LeaveGroupRequest message)
        {
            Encoder.WriteString(buffer, message.GroupIdField);
            Encoder.WriteString(buffer, message.MemberIdField);
        }
        private static LeaveGroupRequest ReadV03(Stream buffer)
        {
            var groupIdField = Decoder.ReadString(buffer);
            var memberIdField = "";
            var membersField = Decoder.ReadArray<MemberIdentity>(buffer, b => MemberIdentitySerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Members'");
            return new(
                groupIdField,
                memberIdField,
                membersField
            );
        }
        private static void WriteV03(Stream buffer, LeaveGroupRequest message)
        {
            Encoder.WriteString(buffer, message.GroupIdField);
            Encoder.WriteArray<MemberIdentity>(buffer, message.MembersField, (b, i) => MemberIdentitySerde.WriteV03(b, i));
        }
        private static LeaveGroupRequest ReadV04(Stream buffer)
        {
            var groupIdField = Decoder.ReadCompactString(buffer);
            var memberIdField = "";
            var membersField = Decoder.ReadCompactArray<MemberIdentity>(buffer, b => MemberIdentitySerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'Members'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                groupIdField,
                memberIdField,
                membersField
            );
        }
        private static void WriteV04(Stream buffer, LeaveGroupRequest message)
        {
            Encoder.WriteCompactString(buffer, message.GroupIdField);
            Encoder.WriteCompactArray<MemberIdentity>(buffer, message.MembersField, (b, i) => MemberIdentitySerde.WriteV04(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static LeaveGroupRequest ReadV05(Stream buffer)
        {
            var groupIdField = Decoder.ReadCompactString(buffer);
            var memberIdField = "";
            var membersField = Decoder.ReadCompactArray<MemberIdentity>(buffer, b => MemberIdentitySerde.ReadV05(b)) ?? throw new NullReferenceException("Null not allowed for 'Members'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                groupIdField,
                memberIdField,
                membersField
            );
        }
        private static void WriteV05(Stream buffer, LeaveGroupRequest message)
        {
            Encoder.WriteCompactString(buffer, message.GroupIdField);
            Encoder.WriteCompactArray<MemberIdentity>(buffer, message.MembersField, (b, i) => MemberIdentitySerde.WriteV05(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class MemberIdentitySerde
        {
            public static MemberIdentity ReadV03(Stream buffer)
            {
                var memberIdField = Decoder.ReadString(buffer);
                var groupInstanceIdField = Decoder.ReadNullableString(buffer);
                var reasonField = default(string?);
                return new(
                    memberIdField,
                    groupInstanceIdField,
                    reasonField
                );
            }
            public static void WriteV03(Stream buffer, MemberIdentity message)
            {
                Encoder.WriteString(buffer, message.MemberIdField);
                Encoder.WriteNullableString(buffer, message.GroupInstanceIdField);
            }
            public static MemberIdentity ReadV04(Stream buffer)
            {
                var memberIdField = Decoder.ReadCompactString(buffer);
                var groupInstanceIdField = Decoder.ReadCompactNullableString(buffer);
                var reasonField = default(string?);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    memberIdField,
                    groupInstanceIdField,
                    reasonField
                );
            }
            public static void WriteV04(Stream buffer, MemberIdentity message)
            {
                Encoder.WriteCompactString(buffer, message.MemberIdField);
                Encoder.WriteCompactNullableString(buffer, message.GroupInstanceIdField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static MemberIdentity ReadV05(Stream buffer)
            {
                var memberIdField = Decoder.ReadCompactString(buffer);
                var groupInstanceIdField = Decoder.ReadCompactNullableString(buffer);
                var reasonField = Decoder.ReadCompactNullableString(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    memberIdField,
                    groupInstanceIdField,
                    reasonField
                );
            }
            public static void WriteV05(Stream buffer, MemberIdentity message)
            {
                Encoder.WriteCompactString(buffer, message.MemberIdField);
                Encoder.WriteCompactNullableString(buffer, message.GroupInstanceIdField);
                Encoder.WriteCompactNullableString(buffer, message.ReasonField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
    }
}