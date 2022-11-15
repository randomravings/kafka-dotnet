using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using JoinGroupResponseMember = Kafka.Client.Messages.JoinGroupResponse.JoinGroupResponseMember;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class JoinGroupResponseSerde
    {
        private static readonly Func<Stream, JoinGroupResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
            b => ReadV04(b),
            b => ReadV05(b),
            b => ReadV06(b),
            b => ReadV07(b),
            b => ReadV08(b),
            b => ReadV09(b),
        };
        private static readonly Action<Stream, JoinGroupResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
            (b, m) => WriteV05(b, m),
            (b, m) => WriteV06(b, m),
            (b, m) => WriteV07(b, m),
            (b, m) => WriteV08(b, m),
            (b, m) => WriteV09(b, m),
        };
        public static JoinGroupResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, JoinGroupResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static JoinGroupResponse ReadV00(Stream buffer)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var generationIdField = Decoder.ReadInt32(buffer);
            var protocolTypeField = default(string?);
            var protocolNameField = Decoder.ReadString(buffer);
            var leaderField = Decoder.ReadString(buffer);
            var skipAssignmentField = default(bool);
            var memberIdField = Decoder.ReadString(buffer);
            var membersField = Decoder.ReadArray<JoinGroupResponseMember>(buffer, b => JoinGroupResponseMemberSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Members'");
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
        private static void WriteV00(Stream buffer, JoinGroupResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteInt32(buffer, message.GenerationIdField);
            if (message.ProtocolNameField == null)
                throw new ArgumentNullException(nameof(message.ProtocolNameField));
            Encoder.WriteString(buffer, message.ProtocolNameField);
            Encoder.WriteString(buffer, message.LeaderField);
            Encoder.WriteString(buffer, message.MemberIdField);
            Encoder.WriteArray<JoinGroupResponseMember>(buffer, message.MembersField, (b, i) => JoinGroupResponseMemberSerde.WriteV00(b, i));
        }
        private static JoinGroupResponse ReadV01(Stream buffer)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var generationIdField = Decoder.ReadInt32(buffer);
            var protocolTypeField = default(string?);
            var protocolNameField = Decoder.ReadString(buffer);
            var leaderField = Decoder.ReadString(buffer);
            var skipAssignmentField = default(bool);
            var memberIdField = Decoder.ReadString(buffer);
            var membersField = Decoder.ReadArray<JoinGroupResponseMember>(buffer, b => JoinGroupResponseMemberSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Members'");
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
        private static void WriteV01(Stream buffer, JoinGroupResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteInt32(buffer, message.GenerationIdField);
            if (message.ProtocolNameField == null)
                throw new ArgumentNullException(nameof(message.ProtocolNameField));
            Encoder.WriteString(buffer, message.ProtocolNameField);
            Encoder.WriteString(buffer, message.LeaderField);
            Encoder.WriteString(buffer, message.MemberIdField);
            Encoder.WriteArray<JoinGroupResponseMember>(buffer, message.MembersField, (b, i) => JoinGroupResponseMemberSerde.WriteV01(b, i));
        }
        private static JoinGroupResponse ReadV02(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var generationIdField = Decoder.ReadInt32(buffer);
            var protocolTypeField = default(string?);
            var protocolNameField = Decoder.ReadString(buffer);
            var leaderField = Decoder.ReadString(buffer);
            var skipAssignmentField = default(bool);
            var memberIdField = Decoder.ReadString(buffer);
            var membersField = Decoder.ReadArray<JoinGroupResponseMember>(buffer, b => JoinGroupResponseMemberSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Members'");
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
        private static void WriteV02(Stream buffer, JoinGroupResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteInt32(buffer, message.GenerationIdField);
            if (message.ProtocolNameField == null)
                throw new ArgumentNullException(nameof(message.ProtocolNameField));
            Encoder.WriteString(buffer, message.ProtocolNameField);
            Encoder.WriteString(buffer, message.LeaderField);
            Encoder.WriteString(buffer, message.MemberIdField);
            Encoder.WriteArray<JoinGroupResponseMember>(buffer, message.MembersField, (b, i) => JoinGroupResponseMemberSerde.WriteV02(b, i));
        }
        private static JoinGroupResponse ReadV03(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var generationIdField = Decoder.ReadInt32(buffer);
            var protocolTypeField = default(string?);
            var protocolNameField = Decoder.ReadString(buffer);
            var leaderField = Decoder.ReadString(buffer);
            var skipAssignmentField = default(bool);
            var memberIdField = Decoder.ReadString(buffer);
            var membersField = Decoder.ReadArray<JoinGroupResponseMember>(buffer, b => JoinGroupResponseMemberSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Members'");
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
        private static void WriteV03(Stream buffer, JoinGroupResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteInt32(buffer, message.GenerationIdField);
            if (message.ProtocolNameField == null)
                throw new ArgumentNullException(nameof(message.ProtocolNameField));
            Encoder.WriteString(buffer, message.ProtocolNameField);
            Encoder.WriteString(buffer, message.LeaderField);
            Encoder.WriteString(buffer, message.MemberIdField);
            Encoder.WriteArray<JoinGroupResponseMember>(buffer, message.MembersField, (b, i) => JoinGroupResponseMemberSerde.WriteV03(b, i));
        }
        private static JoinGroupResponse ReadV04(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var generationIdField = Decoder.ReadInt32(buffer);
            var protocolTypeField = default(string?);
            var protocolNameField = Decoder.ReadString(buffer);
            var leaderField = Decoder.ReadString(buffer);
            var skipAssignmentField = default(bool);
            var memberIdField = Decoder.ReadString(buffer);
            var membersField = Decoder.ReadArray<JoinGroupResponseMember>(buffer, b => JoinGroupResponseMemberSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'Members'");
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
        private static void WriteV04(Stream buffer, JoinGroupResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteInt32(buffer, message.GenerationIdField);
            if (message.ProtocolNameField == null)
                throw new ArgumentNullException(nameof(message.ProtocolNameField));
            Encoder.WriteString(buffer, message.ProtocolNameField);
            Encoder.WriteString(buffer, message.LeaderField);
            Encoder.WriteString(buffer, message.MemberIdField);
            Encoder.WriteArray<JoinGroupResponseMember>(buffer, message.MembersField, (b, i) => JoinGroupResponseMemberSerde.WriteV04(b, i));
        }
        private static JoinGroupResponse ReadV05(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var generationIdField = Decoder.ReadInt32(buffer);
            var protocolTypeField = default(string?);
            var protocolNameField = Decoder.ReadString(buffer);
            var leaderField = Decoder.ReadString(buffer);
            var skipAssignmentField = default(bool);
            var memberIdField = Decoder.ReadString(buffer);
            var membersField = Decoder.ReadArray<JoinGroupResponseMember>(buffer, b => JoinGroupResponseMemberSerde.ReadV05(b)) ?? throw new NullReferenceException("Null not allowed for 'Members'");
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
        private static void WriteV05(Stream buffer, JoinGroupResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteInt32(buffer, message.GenerationIdField);
            if (message.ProtocolNameField == null)
                throw new ArgumentNullException(nameof(message.ProtocolNameField));
            Encoder.WriteString(buffer, message.ProtocolNameField);
            Encoder.WriteString(buffer, message.LeaderField);
            Encoder.WriteString(buffer, message.MemberIdField);
            Encoder.WriteArray<JoinGroupResponseMember>(buffer, message.MembersField, (b, i) => JoinGroupResponseMemberSerde.WriteV05(b, i));
        }
        private static JoinGroupResponse ReadV06(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var generationIdField = Decoder.ReadInt32(buffer);
            var protocolTypeField = default(string?);
            var protocolNameField = Decoder.ReadCompactString(buffer);
            var leaderField = Decoder.ReadCompactString(buffer);
            var skipAssignmentField = default(bool);
            var memberIdField = Decoder.ReadCompactString(buffer);
            var membersField = Decoder.ReadCompactArray<JoinGroupResponseMember>(buffer, b => JoinGroupResponseMemberSerde.ReadV06(b)) ?? throw new NullReferenceException("Null not allowed for 'Members'");
            _ = Decoder.ReadVarUInt32(buffer);
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
        private static void WriteV06(Stream buffer, JoinGroupResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteInt32(buffer, message.GenerationIdField);
            if (message.ProtocolNameField == null)
                throw new ArgumentNullException(nameof(message.ProtocolNameField));
            Encoder.WriteCompactString(buffer, message.ProtocolNameField);
            Encoder.WriteCompactString(buffer, message.LeaderField);
            Encoder.WriteCompactString(buffer, message.MemberIdField);
            Encoder.WriteCompactArray<JoinGroupResponseMember>(buffer, message.MembersField, (b, i) => JoinGroupResponseMemberSerde.WriteV06(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static JoinGroupResponse ReadV07(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var generationIdField = Decoder.ReadInt32(buffer);
            var protocolTypeField = Decoder.ReadCompactNullableString(buffer);
            var protocolNameField = Decoder.ReadCompactNullableString(buffer);
            var leaderField = Decoder.ReadCompactString(buffer);
            var skipAssignmentField = default(bool);
            var memberIdField = Decoder.ReadCompactString(buffer);
            var membersField = Decoder.ReadCompactArray<JoinGroupResponseMember>(buffer, b => JoinGroupResponseMemberSerde.ReadV07(b)) ?? throw new NullReferenceException("Null not allowed for 'Members'");
            _ = Decoder.ReadVarUInt32(buffer);
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
        private static void WriteV07(Stream buffer, JoinGroupResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteInt32(buffer, message.GenerationIdField);
            Encoder.WriteCompactNullableString(buffer, message.ProtocolTypeField);
            Encoder.WriteCompactNullableString(buffer, message.ProtocolNameField);
            Encoder.WriteCompactString(buffer, message.LeaderField);
            Encoder.WriteCompactString(buffer, message.MemberIdField);
            Encoder.WriteCompactArray<JoinGroupResponseMember>(buffer, message.MembersField, (b, i) => JoinGroupResponseMemberSerde.WriteV07(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static JoinGroupResponse ReadV08(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var generationIdField = Decoder.ReadInt32(buffer);
            var protocolTypeField = Decoder.ReadCompactNullableString(buffer);
            var protocolNameField = Decoder.ReadCompactNullableString(buffer);
            var leaderField = Decoder.ReadCompactString(buffer);
            var skipAssignmentField = default(bool);
            var memberIdField = Decoder.ReadCompactString(buffer);
            var membersField = Decoder.ReadCompactArray<JoinGroupResponseMember>(buffer, b => JoinGroupResponseMemberSerde.ReadV08(b)) ?? throw new NullReferenceException("Null not allowed for 'Members'");
            _ = Decoder.ReadVarUInt32(buffer);
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
        private static void WriteV08(Stream buffer, JoinGroupResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteInt32(buffer, message.GenerationIdField);
            Encoder.WriteCompactNullableString(buffer, message.ProtocolTypeField);
            Encoder.WriteCompactNullableString(buffer, message.ProtocolNameField);
            Encoder.WriteCompactString(buffer, message.LeaderField);
            Encoder.WriteCompactString(buffer, message.MemberIdField);
            Encoder.WriteCompactArray<JoinGroupResponseMember>(buffer, message.MembersField, (b, i) => JoinGroupResponseMemberSerde.WriteV08(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static JoinGroupResponse ReadV09(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var generationIdField = Decoder.ReadInt32(buffer);
            var protocolTypeField = Decoder.ReadCompactNullableString(buffer);
            var protocolNameField = Decoder.ReadCompactNullableString(buffer);
            var leaderField = Decoder.ReadCompactString(buffer);
            var skipAssignmentField = Decoder.ReadBoolean(buffer);
            var memberIdField = Decoder.ReadCompactString(buffer);
            var membersField = Decoder.ReadCompactArray<JoinGroupResponseMember>(buffer, b => JoinGroupResponseMemberSerde.ReadV09(b)) ?? throw new NullReferenceException("Null not allowed for 'Members'");
            _ = Decoder.ReadVarUInt32(buffer);
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
        private static void WriteV09(Stream buffer, JoinGroupResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteInt32(buffer, message.GenerationIdField);
            Encoder.WriteCompactNullableString(buffer, message.ProtocolTypeField);
            Encoder.WriteCompactNullableString(buffer, message.ProtocolNameField);
            Encoder.WriteCompactString(buffer, message.LeaderField);
            Encoder.WriteBoolean(buffer, message.SkipAssignmentField);
            Encoder.WriteCompactString(buffer, message.MemberIdField);
            Encoder.WriteCompactArray<JoinGroupResponseMember>(buffer, message.MembersField, (b, i) => JoinGroupResponseMemberSerde.WriteV09(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class JoinGroupResponseMemberSerde
        {
            public static JoinGroupResponseMember ReadV00(Stream buffer)
            {
                var memberIdField = Decoder.ReadString(buffer);
                var groupInstanceIdField = default(string?);
                var metadataField = Decoder.ReadBytes(buffer);
                return new(
                    memberIdField,
                    groupInstanceIdField,
                    metadataField
                );
            }
            public static void WriteV00(Stream buffer, JoinGroupResponseMember message)
            {
                Encoder.WriteString(buffer, message.MemberIdField);
                Encoder.WriteBytes(buffer, message.MetadataField);
            }
            public static JoinGroupResponseMember ReadV01(Stream buffer)
            {
                var memberIdField = Decoder.ReadString(buffer);
                var groupInstanceIdField = default(string?);
                var metadataField = Decoder.ReadBytes(buffer);
                return new(
                    memberIdField,
                    groupInstanceIdField,
                    metadataField
                );
            }
            public static void WriteV01(Stream buffer, JoinGroupResponseMember message)
            {
                Encoder.WriteString(buffer, message.MemberIdField);
                Encoder.WriteBytes(buffer, message.MetadataField);
            }
            public static JoinGroupResponseMember ReadV02(Stream buffer)
            {
                var memberIdField = Decoder.ReadString(buffer);
                var groupInstanceIdField = default(string?);
                var metadataField = Decoder.ReadBytes(buffer);
                return new(
                    memberIdField,
                    groupInstanceIdField,
                    metadataField
                );
            }
            public static void WriteV02(Stream buffer, JoinGroupResponseMember message)
            {
                Encoder.WriteString(buffer, message.MemberIdField);
                Encoder.WriteBytes(buffer, message.MetadataField);
            }
            public static JoinGroupResponseMember ReadV03(Stream buffer)
            {
                var memberIdField = Decoder.ReadString(buffer);
                var groupInstanceIdField = default(string?);
                var metadataField = Decoder.ReadBytes(buffer);
                return new(
                    memberIdField,
                    groupInstanceIdField,
                    metadataField
                );
            }
            public static void WriteV03(Stream buffer, JoinGroupResponseMember message)
            {
                Encoder.WriteString(buffer, message.MemberIdField);
                Encoder.WriteBytes(buffer, message.MetadataField);
            }
            public static JoinGroupResponseMember ReadV04(Stream buffer)
            {
                var memberIdField = Decoder.ReadString(buffer);
                var groupInstanceIdField = default(string?);
                var metadataField = Decoder.ReadBytes(buffer);
                return new(
                    memberIdField,
                    groupInstanceIdField,
                    metadataField
                );
            }
            public static void WriteV04(Stream buffer, JoinGroupResponseMember message)
            {
                Encoder.WriteString(buffer, message.MemberIdField);
                Encoder.WriteBytes(buffer, message.MetadataField);
            }
            public static JoinGroupResponseMember ReadV05(Stream buffer)
            {
                var memberIdField = Decoder.ReadString(buffer);
                var groupInstanceIdField = Decoder.ReadNullableString(buffer);
                var metadataField = Decoder.ReadBytes(buffer);
                return new(
                    memberIdField,
                    groupInstanceIdField,
                    metadataField
                );
            }
            public static void WriteV05(Stream buffer, JoinGroupResponseMember message)
            {
                Encoder.WriteString(buffer, message.MemberIdField);
                Encoder.WriteNullableString(buffer, message.GroupInstanceIdField);
                Encoder.WriteBytes(buffer, message.MetadataField);
            }
            public static JoinGroupResponseMember ReadV06(Stream buffer)
            {
                var memberIdField = Decoder.ReadCompactString(buffer);
                var groupInstanceIdField = Decoder.ReadCompactNullableString(buffer);
                var metadataField = Decoder.ReadCompactBytes(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    memberIdField,
                    groupInstanceIdField,
                    metadataField
                );
            }
            public static void WriteV06(Stream buffer, JoinGroupResponseMember message)
            {
                Encoder.WriteCompactString(buffer, message.MemberIdField);
                Encoder.WriteCompactNullableString(buffer, message.GroupInstanceIdField);
                Encoder.WriteCompactBytes(buffer, message.MetadataField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static JoinGroupResponseMember ReadV07(Stream buffer)
            {
                var memberIdField = Decoder.ReadCompactString(buffer);
                var groupInstanceIdField = Decoder.ReadCompactNullableString(buffer);
                var metadataField = Decoder.ReadCompactBytes(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    memberIdField,
                    groupInstanceIdField,
                    metadataField
                );
            }
            public static void WriteV07(Stream buffer, JoinGroupResponseMember message)
            {
                Encoder.WriteCompactString(buffer, message.MemberIdField);
                Encoder.WriteCompactNullableString(buffer, message.GroupInstanceIdField);
                Encoder.WriteCompactBytes(buffer, message.MetadataField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static JoinGroupResponseMember ReadV08(Stream buffer)
            {
                var memberIdField = Decoder.ReadCompactString(buffer);
                var groupInstanceIdField = Decoder.ReadCompactNullableString(buffer);
                var metadataField = Decoder.ReadCompactBytes(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    memberIdField,
                    groupInstanceIdField,
                    metadataField
                );
            }
            public static void WriteV08(Stream buffer, JoinGroupResponseMember message)
            {
                Encoder.WriteCompactString(buffer, message.MemberIdField);
                Encoder.WriteCompactNullableString(buffer, message.GroupInstanceIdField);
                Encoder.WriteCompactBytes(buffer, message.MetadataField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static JoinGroupResponseMember ReadV09(Stream buffer)
            {
                var memberIdField = Decoder.ReadCompactString(buffer);
                var groupInstanceIdField = Decoder.ReadCompactNullableString(buffer);
                var metadataField = Decoder.ReadCompactBytes(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    memberIdField,
                    groupInstanceIdField,
                    metadataField
                );
            }
            public static void WriteV09(Stream buffer, JoinGroupResponseMember message)
            {
                Encoder.WriteCompactString(buffer, message.MemberIdField);
                Encoder.WriteCompactNullableString(buffer, message.GroupInstanceIdField);
                Encoder.WriteCompactBytes(buffer, message.MetadataField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
    }
}