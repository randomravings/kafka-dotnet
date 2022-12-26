using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using JoinGroupResponseMember = Kafka.Client.Messages.JoinGroupResponse.JoinGroupResponseMember;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class JoinGroupResponseSerde
    {
        private static readonly DecodeDelegate<JoinGroupResponse>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
            ReadV04,
            ReadV05,
            ReadV06,
            ReadV07,
            ReadV08,
            ReadV09,
        };
        private static readonly EncodeDelegate<JoinGroupResponse>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
            WriteV04,
            WriteV05,
            WriteV06,
            WriteV07,
            WriteV08,
            WriteV09,
        };
        public static JoinGroupResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, JoinGroupResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static JoinGroupResponse ReadV00(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var generationIdField = Decoder.ReadInt32(buffer, ref index);
            var protocolTypeField = default(string?);
            var protocolNameField = Decoder.ReadString(buffer, ref index);
            var leaderField = Decoder.ReadString(buffer, ref index);
            var skipAssignmentField = default(bool);
            var memberIdField = Decoder.ReadString(buffer, ref index);
            var membersField = Decoder.ReadArray<JoinGroupResponseMember>(buffer, ref index, JoinGroupResponseMemberSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Members'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                generationIdField,
                protocolTypeField,
                protocolNameField,
                leaderField,
                skipAssignmentField,
                memberIdField,
                membersField
            );
        }
        private static int WriteV00(byte[] buffer, int index, JoinGroupResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
            if (message.ProtocolNameField == null)
                throw new ArgumentNullException(nameof(message.ProtocolNameField));
            index = Encoder.WriteString(buffer, index, message.ProtocolNameField);
            index = Encoder.WriteString(buffer, index, message.LeaderField);
            index = Encoder.WriteString(buffer, index, message.MemberIdField);
            index = Encoder.WriteArray<JoinGroupResponseMember>(buffer, index, message.MembersField, JoinGroupResponseMemberSerde.WriteV00);
            return index;
        }
        private static JoinGroupResponse ReadV01(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var generationIdField = Decoder.ReadInt32(buffer, ref index);
            var protocolTypeField = default(string?);
            var protocolNameField = Decoder.ReadString(buffer, ref index);
            var leaderField = Decoder.ReadString(buffer, ref index);
            var skipAssignmentField = default(bool);
            var memberIdField = Decoder.ReadString(buffer, ref index);
            var membersField = Decoder.ReadArray<JoinGroupResponseMember>(buffer, ref index, JoinGroupResponseMemberSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Members'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                generationIdField,
                protocolTypeField,
                protocolNameField,
                leaderField,
                skipAssignmentField,
                memberIdField,
                membersField
            );
        }
        private static int WriteV01(byte[] buffer, int index, JoinGroupResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
            if (message.ProtocolNameField == null)
                throw new ArgumentNullException(nameof(message.ProtocolNameField));
            index = Encoder.WriteString(buffer, index, message.ProtocolNameField);
            index = Encoder.WriteString(buffer, index, message.LeaderField);
            index = Encoder.WriteString(buffer, index, message.MemberIdField);
            index = Encoder.WriteArray<JoinGroupResponseMember>(buffer, index, message.MembersField, JoinGroupResponseMemberSerde.WriteV01);
            return index;
        }
        private static JoinGroupResponse ReadV02(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var generationIdField = Decoder.ReadInt32(buffer, ref index);
            var protocolTypeField = default(string?);
            var protocolNameField = Decoder.ReadString(buffer, ref index);
            var leaderField = Decoder.ReadString(buffer, ref index);
            var skipAssignmentField = default(bool);
            var memberIdField = Decoder.ReadString(buffer, ref index);
            var membersField = Decoder.ReadArray<JoinGroupResponseMember>(buffer, ref index, JoinGroupResponseMemberSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Members'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                generationIdField,
                protocolTypeField,
                protocolNameField,
                leaderField,
                skipAssignmentField,
                memberIdField,
                membersField
            );
        }
        private static int WriteV02(byte[] buffer, int index, JoinGroupResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
            if (message.ProtocolNameField == null)
                throw new ArgumentNullException(nameof(message.ProtocolNameField));
            index = Encoder.WriteString(buffer, index, message.ProtocolNameField);
            index = Encoder.WriteString(buffer, index, message.LeaderField);
            index = Encoder.WriteString(buffer, index, message.MemberIdField);
            index = Encoder.WriteArray<JoinGroupResponseMember>(buffer, index, message.MembersField, JoinGroupResponseMemberSerde.WriteV02);
            return index;
        }
        private static JoinGroupResponse ReadV03(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var generationIdField = Decoder.ReadInt32(buffer, ref index);
            var protocolTypeField = default(string?);
            var protocolNameField = Decoder.ReadString(buffer, ref index);
            var leaderField = Decoder.ReadString(buffer, ref index);
            var skipAssignmentField = default(bool);
            var memberIdField = Decoder.ReadString(buffer, ref index);
            var membersField = Decoder.ReadArray<JoinGroupResponseMember>(buffer, ref index, JoinGroupResponseMemberSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Members'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                generationIdField,
                protocolTypeField,
                protocolNameField,
                leaderField,
                skipAssignmentField,
                memberIdField,
                membersField
            );
        }
        private static int WriteV03(byte[] buffer, int index, JoinGroupResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
            if (message.ProtocolNameField == null)
                throw new ArgumentNullException(nameof(message.ProtocolNameField));
            index = Encoder.WriteString(buffer, index, message.ProtocolNameField);
            index = Encoder.WriteString(buffer, index, message.LeaderField);
            index = Encoder.WriteString(buffer, index, message.MemberIdField);
            index = Encoder.WriteArray<JoinGroupResponseMember>(buffer, index, message.MembersField, JoinGroupResponseMemberSerde.WriteV03);
            return index;
        }
        private static JoinGroupResponse ReadV04(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var generationIdField = Decoder.ReadInt32(buffer, ref index);
            var protocolTypeField = default(string?);
            var protocolNameField = Decoder.ReadString(buffer, ref index);
            var leaderField = Decoder.ReadString(buffer, ref index);
            var skipAssignmentField = default(bool);
            var memberIdField = Decoder.ReadString(buffer, ref index);
            var membersField = Decoder.ReadArray<JoinGroupResponseMember>(buffer, ref index, JoinGroupResponseMemberSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'Members'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                generationIdField,
                protocolTypeField,
                protocolNameField,
                leaderField,
                skipAssignmentField,
                memberIdField,
                membersField
            );
        }
        private static int WriteV04(byte[] buffer, int index, JoinGroupResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
            if (message.ProtocolNameField == null)
                throw new ArgumentNullException(nameof(message.ProtocolNameField));
            index = Encoder.WriteString(buffer, index, message.ProtocolNameField);
            index = Encoder.WriteString(buffer, index, message.LeaderField);
            index = Encoder.WriteString(buffer, index, message.MemberIdField);
            index = Encoder.WriteArray<JoinGroupResponseMember>(buffer, index, message.MembersField, JoinGroupResponseMemberSerde.WriteV04);
            return index;
        }
        private static JoinGroupResponse ReadV05(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var generationIdField = Decoder.ReadInt32(buffer, ref index);
            var protocolTypeField = default(string?);
            var protocolNameField = Decoder.ReadString(buffer, ref index);
            var leaderField = Decoder.ReadString(buffer, ref index);
            var skipAssignmentField = default(bool);
            var memberIdField = Decoder.ReadString(buffer, ref index);
            var membersField = Decoder.ReadArray<JoinGroupResponseMember>(buffer, ref index, JoinGroupResponseMemberSerde.ReadV05) ?? throw new NullReferenceException("Null not allowed for 'Members'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                generationIdField,
                protocolTypeField,
                protocolNameField,
                leaderField,
                skipAssignmentField,
                memberIdField,
                membersField
            );
        }
        private static int WriteV05(byte[] buffer, int index, JoinGroupResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
            if (message.ProtocolNameField == null)
                throw new ArgumentNullException(nameof(message.ProtocolNameField));
            index = Encoder.WriteString(buffer, index, message.ProtocolNameField);
            index = Encoder.WriteString(buffer, index, message.LeaderField);
            index = Encoder.WriteString(buffer, index, message.MemberIdField);
            index = Encoder.WriteArray<JoinGroupResponseMember>(buffer, index, message.MembersField, JoinGroupResponseMemberSerde.WriteV05);
            return index;
        }
        private static JoinGroupResponse ReadV06(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var generationIdField = Decoder.ReadInt32(buffer, ref index);
            var protocolTypeField = default(string?);
            var protocolNameField = Decoder.ReadCompactString(buffer, ref index);
            var leaderField = Decoder.ReadCompactString(buffer, ref index);
            var skipAssignmentField = default(bool);
            var memberIdField = Decoder.ReadCompactString(buffer, ref index);
            var membersField = Decoder.ReadCompactArray<JoinGroupResponseMember>(buffer, ref index, JoinGroupResponseMemberSerde.ReadV06) ?? throw new NullReferenceException("Null not allowed for 'Members'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                errorCodeField,
                generationIdField,
                protocolTypeField,
                protocolNameField,
                leaderField,
                skipAssignmentField,
                memberIdField,
                membersField
            );
        }
        private static int WriteV06(byte[] buffer, int index, JoinGroupResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
            if (message.ProtocolNameField == null)
                throw new ArgumentNullException(nameof(message.ProtocolNameField));
            index = Encoder.WriteCompactString(buffer, index, message.ProtocolNameField);
            index = Encoder.WriteCompactString(buffer, index, message.LeaderField);
            index = Encoder.WriteCompactString(buffer, index, message.MemberIdField);
            index = Encoder.WriteCompactArray<JoinGroupResponseMember>(buffer, index, message.MembersField, JoinGroupResponseMemberSerde.WriteV06);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static JoinGroupResponse ReadV07(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var generationIdField = Decoder.ReadInt32(buffer, ref index);
            var protocolTypeField = Decoder.ReadCompactNullableString(buffer, ref index);
            var protocolNameField = Decoder.ReadCompactNullableString(buffer, ref index);
            var leaderField = Decoder.ReadCompactString(buffer, ref index);
            var skipAssignmentField = default(bool);
            var memberIdField = Decoder.ReadCompactString(buffer, ref index);
            var membersField = Decoder.ReadCompactArray<JoinGroupResponseMember>(buffer, ref index, JoinGroupResponseMemberSerde.ReadV07) ?? throw new NullReferenceException("Null not allowed for 'Members'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                errorCodeField,
                generationIdField,
                protocolTypeField,
                protocolNameField,
                leaderField,
                skipAssignmentField,
                memberIdField,
                membersField
            );
        }
        private static int WriteV07(byte[] buffer, int index, JoinGroupResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
            index = Encoder.WriteCompactNullableString(buffer, index, message.ProtocolTypeField);
            index = Encoder.WriteCompactNullableString(buffer, index, message.ProtocolNameField);
            index = Encoder.WriteCompactString(buffer, index, message.LeaderField);
            index = Encoder.WriteCompactString(buffer, index, message.MemberIdField);
            index = Encoder.WriteCompactArray<JoinGroupResponseMember>(buffer, index, message.MembersField, JoinGroupResponseMemberSerde.WriteV07);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static JoinGroupResponse ReadV08(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var generationIdField = Decoder.ReadInt32(buffer, ref index);
            var protocolTypeField = Decoder.ReadCompactNullableString(buffer, ref index);
            var protocolNameField = Decoder.ReadCompactNullableString(buffer, ref index);
            var leaderField = Decoder.ReadCompactString(buffer, ref index);
            var skipAssignmentField = default(bool);
            var memberIdField = Decoder.ReadCompactString(buffer, ref index);
            var membersField = Decoder.ReadCompactArray<JoinGroupResponseMember>(buffer, ref index, JoinGroupResponseMemberSerde.ReadV08) ?? throw new NullReferenceException("Null not allowed for 'Members'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                errorCodeField,
                generationIdField,
                protocolTypeField,
                protocolNameField,
                leaderField,
                skipAssignmentField,
                memberIdField,
                membersField
            );
        }
        private static int WriteV08(byte[] buffer, int index, JoinGroupResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
            index = Encoder.WriteCompactNullableString(buffer, index, message.ProtocolTypeField);
            index = Encoder.WriteCompactNullableString(buffer, index, message.ProtocolNameField);
            index = Encoder.WriteCompactString(buffer, index, message.LeaderField);
            index = Encoder.WriteCompactString(buffer, index, message.MemberIdField);
            index = Encoder.WriteCompactArray<JoinGroupResponseMember>(buffer, index, message.MembersField, JoinGroupResponseMemberSerde.WriteV08);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static JoinGroupResponse ReadV09(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var generationIdField = Decoder.ReadInt32(buffer, ref index);
            var protocolTypeField = Decoder.ReadCompactNullableString(buffer, ref index);
            var protocolNameField = Decoder.ReadCompactNullableString(buffer, ref index);
            var leaderField = Decoder.ReadCompactString(buffer, ref index);
            var skipAssignmentField = Decoder.ReadBoolean(buffer, ref index);
            var memberIdField = Decoder.ReadCompactString(buffer, ref index);
            var membersField = Decoder.ReadCompactArray<JoinGroupResponseMember>(buffer, ref index, JoinGroupResponseMemberSerde.ReadV09) ?? throw new NullReferenceException("Null not allowed for 'Members'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                errorCodeField,
                generationIdField,
                protocolTypeField,
                protocolNameField,
                leaderField,
                skipAssignmentField,
                memberIdField,
                membersField
            );
        }
        private static int WriteV09(byte[] buffer, int index, JoinGroupResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
            index = Encoder.WriteCompactNullableString(buffer, index, message.ProtocolTypeField);
            index = Encoder.WriteCompactNullableString(buffer, index, message.ProtocolNameField);
            index = Encoder.WriteCompactString(buffer, index, message.LeaderField);
            index = Encoder.WriteBoolean(buffer, index, message.SkipAssignmentField);
            index = Encoder.WriteCompactString(buffer, index, message.MemberIdField);
            index = Encoder.WriteCompactArray<JoinGroupResponseMember>(buffer, index, message.MembersField, JoinGroupResponseMemberSerde.WriteV09);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class JoinGroupResponseMemberSerde
        {
            public static JoinGroupResponseMember ReadV00(byte[] buffer, ref int index)
            {
                var MemberIdField = Decoder.ReadString(buffer, ref index);
                var GroupInstanceIdField = default(string?);
                var MetadataField = Decoder.ReadBytes(buffer, ref index);
                return new(
                    MemberIdField,
                    GroupInstanceIdField,
                    MetadataField
                );
            }
            public static int WriteV00(byte[] buffer, int index, JoinGroupResponseMember message)
            {
                index = Encoder.WriteString(buffer, index, message.MemberIdField);
                index = Encoder.WriteBytes(buffer, index, message.MetadataField);
                return index;
            }
            public static JoinGroupResponseMember ReadV01(byte[] buffer, ref int index)
            {
                var MemberIdField = Decoder.ReadString(buffer, ref index);
                var GroupInstanceIdField = default(string?);
                var MetadataField = Decoder.ReadBytes(buffer, ref index);
                return new(
                    MemberIdField,
                    GroupInstanceIdField,
                    MetadataField
                );
            }
            public static int WriteV01(byte[] buffer, int index, JoinGroupResponseMember message)
            {
                index = Encoder.WriteString(buffer, index, message.MemberIdField);
                index = Encoder.WriteBytes(buffer, index, message.MetadataField);
                return index;
            }
            public static JoinGroupResponseMember ReadV02(byte[] buffer, ref int index)
            {
                var MemberIdField = Decoder.ReadString(buffer, ref index);
                var GroupInstanceIdField = default(string?);
                var MetadataField = Decoder.ReadBytes(buffer, ref index);
                return new(
                    MemberIdField,
                    GroupInstanceIdField,
                    MetadataField
                );
            }
            public static int WriteV02(byte[] buffer, int index, JoinGroupResponseMember message)
            {
                index = Encoder.WriteString(buffer, index, message.MemberIdField);
                index = Encoder.WriteBytes(buffer, index, message.MetadataField);
                return index;
            }
            public static JoinGroupResponseMember ReadV03(byte[] buffer, ref int index)
            {
                var MemberIdField = Decoder.ReadString(buffer, ref index);
                var GroupInstanceIdField = default(string?);
                var MetadataField = Decoder.ReadBytes(buffer, ref index);
                return new(
                    MemberIdField,
                    GroupInstanceIdField,
                    MetadataField
                );
            }
            public static int WriteV03(byte[] buffer, int index, JoinGroupResponseMember message)
            {
                index = Encoder.WriteString(buffer, index, message.MemberIdField);
                index = Encoder.WriteBytes(buffer, index, message.MetadataField);
                return index;
            }
            public static JoinGroupResponseMember ReadV04(byte[] buffer, ref int index)
            {
                var MemberIdField = Decoder.ReadString(buffer, ref index);
                var GroupInstanceIdField = default(string?);
                var MetadataField = Decoder.ReadBytes(buffer, ref index);
                return new(
                    MemberIdField,
                    GroupInstanceIdField,
                    MetadataField
                );
            }
            public static int WriteV04(byte[] buffer, int index, JoinGroupResponseMember message)
            {
                index = Encoder.WriteString(buffer, index, message.MemberIdField);
                index = Encoder.WriteBytes(buffer, index, message.MetadataField);
                return index;
            }
            public static JoinGroupResponseMember ReadV05(byte[] buffer, ref int index)
            {
                var MemberIdField = Decoder.ReadString(buffer, ref index);
                var GroupInstanceIdField = Decoder.ReadNullableString(buffer, ref index);
                var MetadataField = Decoder.ReadBytes(buffer, ref index);
                return new(
                    MemberIdField,
                    GroupInstanceIdField,
                    MetadataField
                );
            }
            public static int WriteV05(byte[] buffer, int index, JoinGroupResponseMember message)
            {
                index = Encoder.WriteString(buffer, index, message.MemberIdField);
                index = Encoder.WriteNullableString(buffer, index, message.GroupInstanceIdField);
                index = Encoder.WriteBytes(buffer, index, message.MetadataField);
                return index;
            }
            public static JoinGroupResponseMember ReadV06(byte[] buffer, ref int index)
            {
                var MemberIdField = Decoder.ReadCompactString(buffer, ref index);
                var GroupInstanceIdField = Decoder.ReadCompactNullableString(buffer, ref index);
                var MetadataField = Decoder.ReadCompactBytes(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    MemberIdField,
                    GroupInstanceIdField,
                    MetadataField
                );
            }
            public static int WriteV06(byte[] buffer, int index, JoinGroupResponseMember message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.MemberIdField);
                index = Encoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
                index = Encoder.WriteCompactBytes(buffer, index, message.MetadataField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static JoinGroupResponseMember ReadV07(byte[] buffer, ref int index)
            {
                var MemberIdField = Decoder.ReadCompactString(buffer, ref index);
                var GroupInstanceIdField = Decoder.ReadCompactNullableString(buffer, ref index);
                var MetadataField = Decoder.ReadCompactBytes(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    MemberIdField,
                    GroupInstanceIdField,
                    MetadataField
                );
            }
            public static int WriteV07(byte[] buffer, int index, JoinGroupResponseMember message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.MemberIdField);
                index = Encoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
                index = Encoder.WriteCompactBytes(buffer, index, message.MetadataField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static JoinGroupResponseMember ReadV08(byte[] buffer, ref int index)
            {
                var MemberIdField = Decoder.ReadCompactString(buffer, ref index);
                var GroupInstanceIdField = Decoder.ReadCompactNullableString(buffer, ref index);
                var MetadataField = Decoder.ReadCompactBytes(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    MemberIdField,
                    GroupInstanceIdField,
                    MetadataField
                );
            }
            public static int WriteV08(byte[] buffer, int index, JoinGroupResponseMember message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.MemberIdField);
                index = Encoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
                index = Encoder.WriteCompactBytes(buffer, index, message.MetadataField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static JoinGroupResponseMember ReadV09(byte[] buffer, ref int index)
            {
                var MemberIdField = Decoder.ReadCompactString(buffer, ref index);
                var GroupInstanceIdField = Decoder.ReadCompactNullableString(buffer, ref index);
                var MetadataField = Decoder.ReadCompactBytes(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    MemberIdField,
                    GroupInstanceIdField,
                    MetadataField
                );
            }
            public static int WriteV09(byte[] buffer, int index, JoinGroupResponseMember message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.MemberIdField);
                index = Encoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
                index = Encoder.WriteCompactBytes(buffer, index, message.MetadataField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
        }
    }
}