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
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
            ReadV04,
            ReadV05,
        };
        private static readonly EncodeDelegate<LeaveGroupRequest>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
            WriteV04,
            WriteV05,
        };
        public static LeaveGroupRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, LeaveGroupRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static LeaveGroupRequest ReadV00(byte[] buffer, ref int index)
        {
            var groupIdField = Decoder.ReadString(buffer, ref index);
            var memberIdField = Decoder.ReadString(buffer, ref index);
            var membersField = ImmutableArray<MemberIdentity>.Empty;
            return new(
                groupIdField,
                memberIdField,
                membersField
            );
        }
        private static int WriteV00(byte[] buffer, int index, LeaveGroupRequest message)
        {
            index = Encoder.WriteString(buffer, index, message.GroupIdField);
            index = Encoder.WriteString(buffer, index, message.MemberIdField);
            return index;
        }
        private static LeaveGroupRequest ReadV01(byte[] buffer, ref int index)
        {
            var groupIdField = Decoder.ReadString(buffer, ref index);
            var memberIdField = Decoder.ReadString(buffer, ref index);
            var membersField = ImmutableArray<MemberIdentity>.Empty;
            return new(
                groupIdField,
                memberIdField,
                membersField
            );
        }
        private static int WriteV01(byte[] buffer, int index, LeaveGroupRequest message)
        {
            index = Encoder.WriteString(buffer, index, message.GroupIdField);
            index = Encoder.WriteString(buffer, index, message.MemberIdField);
            return index;
        }
        private static LeaveGroupRequest ReadV02(byte[] buffer, ref int index)
        {
            var groupIdField = Decoder.ReadString(buffer, ref index);
            var memberIdField = Decoder.ReadString(buffer, ref index);
            var membersField = ImmutableArray<MemberIdentity>.Empty;
            return new(
                groupIdField,
                memberIdField,
                membersField
            );
        }
        private static int WriteV02(byte[] buffer, int index, LeaveGroupRequest message)
        {
            index = Encoder.WriteString(buffer, index, message.GroupIdField);
            index = Encoder.WriteString(buffer, index, message.MemberIdField);
            return index;
        }
        private static LeaveGroupRequest ReadV03(byte[] buffer, ref int index)
        {
            var groupIdField = Decoder.ReadString(buffer, ref index);
            var memberIdField = "";
            var membersField = Decoder.ReadArray<MemberIdentity>(buffer, ref index, MemberIdentitySerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Members'");
            return new(
                groupIdField,
                memberIdField,
                membersField
            );
        }
        private static int WriteV03(byte[] buffer, int index, LeaveGroupRequest message)
        {
            index = Encoder.WriteString(buffer, index, message.GroupIdField);
            index = Encoder.WriteArray<MemberIdentity>(buffer, index, message.MembersField, MemberIdentitySerde.WriteV03);
            return index;
        }
        private static LeaveGroupRequest ReadV04(byte[] buffer, ref int index)
        {
            var groupIdField = Decoder.ReadCompactString(buffer, ref index);
            var memberIdField = "";
            var membersField = Decoder.ReadCompactArray<MemberIdentity>(buffer, ref index, MemberIdentitySerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'Members'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                groupIdField,
                memberIdField,
                membersField
            );
        }
        private static int WriteV04(byte[] buffer, int index, LeaveGroupRequest message)
        {
            index = Encoder.WriteCompactString(buffer, index, message.GroupIdField);
            index = Encoder.WriteCompactArray<MemberIdentity>(buffer, index, message.MembersField, MemberIdentitySerde.WriteV04);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static LeaveGroupRequest ReadV05(byte[] buffer, ref int index)
        {
            var groupIdField = Decoder.ReadCompactString(buffer, ref index);
            var memberIdField = "";
            var membersField = Decoder.ReadCompactArray<MemberIdentity>(buffer, ref index, MemberIdentitySerde.ReadV05) ?? throw new NullReferenceException("Null not allowed for 'Members'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                groupIdField,
                memberIdField,
                membersField
            );
        }
        private static int WriteV05(byte[] buffer, int index, LeaveGroupRequest message)
        {
            index = Encoder.WriteCompactString(buffer, index, message.GroupIdField);
            index = Encoder.WriteCompactArray<MemberIdentity>(buffer, index, message.MembersField, MemberIdentitySerde.WriteV05);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class MemberIdentitySerde
        {
            public static MemberIdentity ReadV03(byte[] buffer, ref int index)
            {
                var memberIdField = Decoder.ReadString(buffer, ref index);
                var groupInstanceIdField = Decoder.ReadNullableString(buffer, ref index);
                var reasonField = default(string?);
                return new(
                    memberIdField,
                    groupInstanceIdField,
                    reasonField
                );
            }
            public static int WriteV03(byte[] buffer, int index, MemberIdentity message)
            {
                index = Encoder.WriteString(buffer, index, message.MemberIdField);
                index = Encoder.WriteNullableString(buffer, index, message.GroupInstanceIdField);
                return index;
            }
            public static MemberIdentity ReadV04(byte[] buffer, ref int index)
            {
                var memberIdField = Decoder.ReadCompactString(buffer, ref index);
                var groupInstanceIdField = Decoder.ReadCompactNullableString(buffer, ref index);
                var reasonField = default(string?);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    memberIdField,
                    groupInstanceIdField,
                    reasonField
                );
            }
            public static int WriteV04(byte[] buffer, int index, MemberIdentity message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.MemberIdField);
                index = Encoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static MemberIdentity ReadV05(byte[] buffer, ref int index)
            {
                var memberIdField = Decoder.ReadCompactString(buffer, ref index);
                var groupInstanceIdField = Decoder.ReadCompactNullableString(buffer, ref index);
                var reasonField = Decoder.ReadCompactNullableString(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    memberIdField,
                    groupInstanceIdField,
                    reasonField
                );
            }
            public static int WriteV05(byte[] buffer, int index, MemberIdentity message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.MemberIdField);
                index = Encoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
                index = Encoder.WriteCompactNullableString(buffer, index, message.ReasonField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
        }
    }
}