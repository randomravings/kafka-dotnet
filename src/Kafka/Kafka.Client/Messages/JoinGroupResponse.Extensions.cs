using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using JoinGroupResponseMember = Kafka.Client.Messages.JoinGroupResponse.JoinGroupResponseMember;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class JoinGroupResponseSerde
    {
        private static readonly DecodeDelegate<JoinGroupResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV04(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV05(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV06(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV07(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV08(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV09(ref b),
        };
        private static readonly EncodeDelegate<JoinGroupResponse>[] WRITE_VERSIONS = {
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
        public static JoinGroupResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, JoinGroupResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static JoinGroupResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var generationIdField = Decoder.ReadInt32(ref buffer);
            var protocolTypeField = default(string?);
            var protocolNameField = Decoder.ReadString(ref buffer);
            var leaderField = Decoder.ReadString(ref buffer);
            var skipAssignmentField = default(bool);
            var memberIdField = Decoder.ReadString(ref buffer);
            var membersField = Decoder.ReadArray<JoinGroupResponseMember>(ref buffer, (ref ReadOnlyMemory<byte> b) => JoinGroupResponseMemberSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Members'");
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
        private static Memory<byte> WriteV00(Memory<byte> buffer, JoinGroupResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteInt32(buffer, message.GenerationIdField);
            if (message.ProtocolNameField == null)
                throw new ArgumentNullException(nameof(message.ProtocolNameField));
            buffer = Encoder.WriteString(buffer, message.ProtocolNameField);
            buffer = Encoder.WriteString(buffer, message.LeaderField);
            buffer = Encoder.WriteString(buffer, message.MemberIdField);
            buffer = Encoder.WriteArray<JoinGroupResponseMember>(buffer, message.MembersField, (b, i) => JoinGroupResponseMemberSerde.WriteV00(b, i));
            return buffer;
        }
        private static JoinGroupResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var generationIdField = Decoder.ReadInt32(ref buffer);
            var protocolTypeField = default(string?);
            var protocolNameField = Decoder.ReadString(ref buffer);
            var leaderField = Decoder.ReadString(ref buffer);
            var skipAssignmentField = default(bool);
            var memberIdField = Decoder.ReadString(ref buffer);
            var membersField = Decoder.ReadArray<JoinGroupResponseMember>(ref buffer, (ref ReadOnlyMemory<byte> b) => JoinGroupResponseMemberSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Members'");
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
        private static Memory<byte> WriteV01(Memory<byte> buffer, JoinGroupResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteInt32(buffer, message.GenerationIdField);
            if (message.ProtocolNameField == null)
                throw new ArgumentNullException(nameof(message.ProtocolNameField));
            buffer = Encoder.WriteString(buffer, message.ProtocolNameField);
            buffer = Encoder.WriteString(buffer, message.LeaderField);
            buffer = Encoder.WriteString(buffer, message.MemberIdField);
            buffer = Encoder.WriteArray<JoinGroupResponseMember>(buffer, message.MembersField, (b, i) => JoinGroupResponseMemberSerde.WriteV01(b, i));
            return buffer;
        }
        private static JoinGroupResponse ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var generationIdField = Decoder.ReadInt32(ref buffer);
            var protocolTypeField = default(string?);
            var protocolNameField = Decoder.ReadString(ref buffer);
            var leaderField = Decoder.ReadString(ref buffer);
            var skipAssignmentField = default(bool);
            var memberIdField = Decoder.ReadString(ref buffer);
            var membersField = Decoder.ReadArray<JoinGroupResponseMember>(ref buffer, (ref ReadOnlyMemory<byte> b) => JoinGroupResponseMemberSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Members'");
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
        private static Memory<byte> WriteV02(Memory<byte> buffer, JoinGroupResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteInt32(buffer, message.GenerationIdField);
            if (message.ProtocolNameField == null)
                throw new ArgumentNullException(nameof(message.ProtocolNameField));
            buffer = Encoder.WriteString(buffer, message.ProtocolNameField);
            buffer = Encoder.WriteString(buffer, message.LeaderField);
            buffer = Encoder.WriteString(buffer, message.MemberIdField);
            buffer = Encoder.WriteArray<JoinGroupResponseMember>(buffer, message.MembersField, (b, i) => JoinGroupResponseMemberSerde.WriteV02(b, i));
            return buffer;
        }
        private static JoinGroupResponse ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var generationIdField = Decoder.ReadInt32(ref buffer);
            var protocolTypeField = default(string?);
            var protocolNameField = Decoder.ReadString(ref buffer);
            var leaderField = Decoder.ReadString(ref buffer);
            var skipAssignmentField = default(bool);
            var memberIdField = Decoder.ReadString(ref buffer);
            var membersField = Decoder.ReadArray<JoinGroupResponseMember>(ref buffer, (ref ReadOnlyMemory<byte> b) => JoinGroupResponseMemberSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Members'");
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
        private static Memory<byte> WriteV03(Memory<byte> buffer, JoinGroupResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteInt32(buffer, message.GenerationIdField);
            if (message.ProtocolNameField == null)
                throw new ArgumentNullException(nameof(message.ProtocolNameField));
            buffer = Encoder.WriteString(buffer, message.ProtocolNameField);
            buffer = Encoder.WriteString(buffer, message.LeaderField);
            buffer = Encoder.WriteString(buffer, message.MemberIdField);
            buffer = Encoder.WriteArray<JoinGroupResponseMember>(buffer, message.MembersField, (b, i) => JoinGroupResponseMemberSerde.WriteV03(b, i));
            return buffer;
        }
        private static JoinGroupResponse ReadV04(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var generationIdField = Decoder.ReadInt32(ref buffer);
            var protocolTypeField = default(string?);
            var protocolNameField = Decoder.ReadString(ref buffer);
            var leaderField = Decoder.ReadString(ref buffer);
            var skipAssignmentField = default(bool);
            var memberIdField = Decoder.ReadString(ref buffer);
            var membersField = Decoder.ReadArray<JoinGroupResponseMember>(ref buffer, (ref ReadOnlyMemory<byte> b) => JoinGroupResponseMemberSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Members'");
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
        private static Memory<byte> WriteV04(Memory<byte> buffer, JoinGroupResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteInt32(buffer, message.GenerationIdField);
            if (message.ProtocolNameField == null)
                throw new ArgumentNullException(nameof(message.ProtocolNameField));
            buffer = Encoder.WriteString(buffer, message.ProtocolNameField);
            buffer = Encoder.WriteString(buffer, message.LeaderField);
            buffer = Encoder.WriteString(buffer, message.MemberIdField);
            buffer = Encoder.WriteArray<JoinGroupResponseMember>(buffer, message.MembersField, (b, i) => JoinGroupResponseMemberSerde.WriteV04(b, i));
            return buffer;
        }
        private static JoinGroupResponse ReadV05(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var generationIdField = Decoder.ReadInt32(ref buffer);
            var protocolTypeField = default(string?);
            var protocolNameField = Decoder.ReadString(ref buffer);
            var leaderField = Decoder.ReadString(ref buffer);
            var skipAssignmentField = default(bool);
            var memberIdField = Decoder.ReadString(ref buffer);
            var membersField = Decoder.ReadArray<JoinGroupResponseMember>(ref buffer, (ref ReadOnlyMemory<byte> b) => JoinGroupResponseMemberSerde.ReadV05(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Members'");
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
        private static Memory<byte> WriteV05(Memory<byte> buffer, JoinGroupResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteInt32(buffer, message.GenerationIdField);
            if (message.ProtocolNameField == null)
                throw new ArgumentNullException(nameof(message.ProtocolNameField));
            buffer = Encoder.WriteString(buffer, message.ProtocolNameField);
            buffer = Encoder.WriteString(buffer, message.LeaderField);
            buffer = Encoder.WriteString(buffer, message.MemberIdField);
            buffer = Encoder.WriteArray<JoinGroupResponseMember>(buffer, message.MembersField, (b, i) => JoinGroupResponseMemberSerde.WriteV05(b, i));
            return buffer;
        }
        private static JoinGroupResponse ReadV06(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var generationIdField = Decoder.ReadInt32(ref buffer);
            var protocolTypeField = default(string?);
            var protocolNameField = Decoder.ReadCompactString(ref buffer);
            var leaderField = Decoder.ReadCompactString(ref buffer);
            var skipAssignmentField = default(bool);
            var memberIdField = Decoder.ReadCompactString(ref buffer);
            var membersField = Decoder.ReadCompactArray<JoinGroupResponseMember>(ref buffer, (ref ReadOnlyMemory<byte> b) => JoinGroupResponseMemberSerde.ReadV06(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Members'");
            _ = Decoder.ReadVarUInt32(ref buffer);
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
        private static Memory<byte> WriteV06(Memory<byte> buffer, JoinGroupResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteInt32(buffer, message.GenerationIdField);
            if (message.ProtocolNameField == null)
                throw new ArgumentNullException(nameof(message.ProtocolNameField));
            buffer = Encoder.WriteCompactString(buffer, message.ProtocolNameField);
            buffer = Encoder.WriteCompactString(buffer, message.LeaderField);
            buffer = Encoder.WriteCompactString(buffer, message.MemberIdField);
            buffer = Encoder.WriteCompactArray<JoinGroupResponseMember>(buffer, message.MembersField, (b, i) => JoinGroupResponseMemberSerde.WriteV06(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static JoinGroupResponse ReadV07(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var generationIdField = Decoder.ReadInt32(ref buffer);
            var protocolTypeField = Decoder.ReadCompactNullableString(ref buffer);
            var protocolNameField = Decoder.ReadCompactNullableString(ref buffer);
            var leaderField = Decoder.ReadCompactString(ref buffer);
            var skipAssignmentField = default(bool);
            var memberIdField = Decoder.ReadCompactString(ref buffer);
            var membersField = Decoder.ReadCompactArray<JoinGroupResponseMember>(ref buffer, (ref ReadOnlyMemory<byte> b) => JoinGroupResponseMemberSerde.ReadV07(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Members'");
            _ = Decoder.ReadVarUInt32(ref buffer);
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
        private static Memory<byte> WriteV07(Memory<byte> buffer, JoinGroupResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteInt32(buffer, message.GenerationIdField);
            buffer = Encoder.WriteCompactNullableString(buffer, message.ProtocolTypeField);
            buffer = Encoder.WriteCompactNullableString(buffer, message.ProtocolNameField);
            buffer = Encoder.WriteCompactString(buffer, message.LeaderField);
            buffer = Encoder.WriteCompactString(buffer, message.MemberIdField);
            buffer = Encoder.WriteCompactArray<JoinGroupResponseMember>(buffer, message.MembersField, (b, i) => JoinGroupResponseMemberSerde.WriteV07(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static JoinGroupResponse ReadV08(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var generationIdField = Decoder.ReadInt32(ref buffer);
            var protocolTypeField = Decoder.ReadCompactNullableString(ref buffer);
            var protocolNameField = Decoder.ReadCompactNullableString(ref buffer);
            var leaderField = Decoder.ReadCompactString(ref buffer);
            var skipAssignmentField = default(bool);
            var memberIdField = Decoder.ReadCompactString(ref buffer);
            var membersField = Decoder.ReadCompactArray<JoinGroupResponseMember>(ref buffer, (ref ReadOnlyMemory<byte> b) => JoinGroupResponseMemberSerde.ReadV08(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Members'");
            _ = Decoder.ReadVarUInt32(ref buffer);
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
        private static Memory<byte> WriteV08(Memory<byte> buffer, JoinGroupResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteInt32(buffer, message.GenerationIdField);
            buffer = Encoder.WriteCompactNullableString(buffer, message.ProtocolTypeField);
            buffer = Encoder.WriteCompactNullableString(buffer, message.ProtocolNameField);
            buffer = Encoder.WriteCompactString(buffer, message.LeaderField);
            buffer = Encoder.WriteCompactString(buffer, message.MemberIdField);
            buffer = Encoder.WriteCompactArray<JoinGroupResponseMember>(buffer, message.MembersField, (b, i) => JoinGroupResponseMemberSerde.WriteV08(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static JoinGroupResponse ReadV09(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var generationIdField = Decoder.ReadInt32(ref buffer);
            var protocolTypeField = Decoder.ReadCompactNullableString(ref buffer);
            var protocolNameField = Decoder.ReadCompactNullableString(ref buffer);
            var leaderField = Decoder.ReadCompactString(ref buffer);
            var skipAssignmentField = Decoder.ReadBoolean(ref buffer);
            var memberIdField = Decoder.ReadCompactString(ref buffer);
            var membersField = Decoder.ReadCompactArray<JoinGroupResponseMember>(ref buffer, (ref ReadOnlyMemory<byte> b) => JoinGroupResponseMemberSerde.ReadV09(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Members'");
            _ = Decoder.ReadVarUInt32(ref buffer);
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
        private static Memory<byte> WriteV09(Memory<byte> buffer, JoinGroupResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteInt32(buffer, message.GenerationIdField);
            buffer = Encoder.WriteCompactNullableString(buffer, message.ProtocolTypeField);
            buffer = Encoder.WriteCompactNullableString(buffer, message.ProtocolNameField);
            buffer = Encoder.WriteCompactString(buffer, message.LeaderField);
            buffer = Encoder.WriteBoolean(buffer, message.SkipAssignmentField);
            buffer = Encoder.WriteCompactString(buffer, message.MemberIdField);
            buffer = Encoder.WriteCompactArray<JoinGroupResponseMember>(buffer, message.MembersField, (b, i) => JoinGroupResponseMemberSerde.WriteV09(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class JoinGroupResponseMemberSerde
        {
            public static JoinGroupResponseMember ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var memberIdField = Decoder.ReadString(ref buffer);
                var groupInstanceIdField = default(string?);
                var metadataField = Decoder.ReadBytes(ref buffer);
                return new(
                    memberIdField,
                    groupInstanceIdField,
                    metadataField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, JoinGroupResponseMember message)
            {
                buffer = Encoder.WriteString(buffer, message.MemberIdField);
                buffer = Encoder.WriteBytes(buffer, message.MetadataField);
                return buffer;
            }
            public static JoinGroupResponseMember ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var memberIdField = Decoder.ReadString(ref buffer);
                var groupInstanceIdField = default(string?);
                var metadataField = Decoder.ReadBytes(ref buffer);
                return new(
                    memberIdField,
                    groupInstanceIdField,
                    metadataField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, JoinGroupResponseMember message)
            {
                buffer = Encoder.WriteString(buffer, message.MemberIdField);
                buffer = Encoder.WriteBytes(buffer, message.MetadataField);
                return buffer;
            }
            public static JoinGroupResponseMember ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var memberIdField = Decoder.ReadString(ref buffer);
                var groupInstanceIdField = default(string?);
                var metadataField = Decoder.ReadBytes(ref buffer);
                return new(
                    memberIdField,
                    groupInstanceIdField,
                    metadataField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, JoinGroupResponseMember message)
            {
                buffer = Encoder.WriteString(buffer, message.MemberIdField);
                buffer = Encoder.WriteBytes(buffer, message.MetadataField);
                return buffer;
            }
            public static JoinGroupResponseMember ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var memberIdField = Decoder.ReadString(ref buffer);
                var groupInstanceIdField = default(string?);
                var metadataField = Decoder.ReadBytes(ref buffer);
                return new(
                    memberIdField,
                    groupInstanceIdField,
                    metadataField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, JoinGroupResponseMember message)
            {
                buffer = Encoder.WriteString(buffer, message.MemberIdField);
                buffer = Encoder.WriteBytes(buffer, message.MetadataField);
                return buffer;
            }
            public static JoinGroupResponseMember ReadV04(ref ReadOnlyMemory<byte> buffer)
            {
                var memberIdField = Decoder.ReadString(ref buffer);
                var groupInstanceIdField = default(string?);
                var metadataField = Decoder.ReadBytes(ref buffer);
                return new(
                    memberIdField,
                    groupInstanceIdField,
                    metadataField
                );
            }
            public static Memory<byte> WriteV04(Memory<byte> buffer, JoinGroupResponseMember message)
            {
                buffer = Encoder.WriteString(buffer, message.MemberIdField);
                buffer = Encoder.WriteBytes(buffer, message.MetadataField);
                return buffer;
            }
            public static JoinGroupResponseMember ReadV05(ref ReadOnlyMemory<byte> buffer)
            {
                var memberIdField = Decoder.ReadString(ref buffer);
                var groupInstanceIdField = Decoder.ReadNullableString(ref buffer);
                var metadataField = Decoder.ReadBytes(ref buffer);
                return new(
                    memberIdField,
                    groupInstanceIdField,
                    metadataField
                );
            }
            public static Memory<byte> WriteV05(Memory<byte> buffer, JoinGroupResponseMember message)
            {
                buffer = Encoder.WriteString(buffer, message.MemberIdField);
                buffer = Encoder.WriteNullableString(buffer, message.GroupInstanceIdField);
                buffer = Encoder.WriteBytes(buffer, message.MetadataField);
                return buffer;
            }
            public static JoinGroupResponseMember ReadV06(ref ReadOnlyMemory<byte> buffer)
            {
                var memberIdField = Decoder.ReadCompactString(ref buffer);
                var groupInstanceIdField = Decoder.ReadCompactNullableString(ref buffer);
                var metadataField = Decoder.ReadCompactBytes(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    memberIdField,
                    groupInstanceIdField,
                    metadataField
                );
            }
            public static Memory<byte> WriteV06(Memory<byte> buffer, JoinGroupResponseMember message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.MemberIdField);
                buffer = Encoder.WriteCompactNullableString(buffer, message.GroupInstanceIdField);
                buffer = Encoder.WriteCompactBytes(buffer, message.MetadataField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static JoinGroupResponseMember ReadV07(ref ReadOnlyMemory<byte> buffer)
            {
                var memberIdField = Decoder.ReadCompactString(ref buffer);
                var groupInstanceIdField = Decoder.ReadCompactNullableString(ref buffer);
                var metadataField = Decoder.ReadCompactBytes(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    memberIdField,
                    groupInstanceIdField,
                    metadataField
                );
            }
            public static Memory<byte> WriteV07(Memory<byte> buffer, JoinGroupResponseMember message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.MemberIdField);
                buffer = Encoder.WriteCompactNullableString(buffer, message.GroupInstanceIdField);
                buffer = Encoder.WriteCompactBytes(buffer, message.MetadataField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static JoinGroupResponseMember ReadV08(ref ReadOnlyMemory<byte> buffer)
            {
                var memberIdField = Decoder.ReadCompactString(ref buffer);
                var groupInstanceIdField = Decoder.ReadCompactNullableString(ref buffer);
                var metadataField = Decoder.ReadCompactBytes(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    memberIdField,
                    groupInstanceIdField,
                    metadataField
                );
            }
            public static Memory<byte> WriteV08(Memory<byte> buffer, JoinGroupResponseMember message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.MemberIdField);
                buffer = Encoder.WriteCompactNullableString(buffer, message.GroupInstanceIdField);
                buffer = Encoder.WriteCompactBytes(buffer, message.MetadataField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static JoinGroupResponseMember ReadV09(ref ReadOnlyMemory<byte> buffer)
            {
                var memberIdField = Decoder.ReadCompactString(ref buffer);
                var groupInstanceIdField = Decoder.ReadCompactNullableString(ref buffer);
                var metadataField = Decoder.ReadCompactBytes(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    memberIdField,
                    groupInstanceIdField,
                    metadataField
                );
            }
            public static Memory<byte> WriteV09(Memory<byte> buffer, JoinGroupResponseMember message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.MemberIdField);
                buffer = Encoder.WriteCompactNullableString(buffer, message.GroupInstanceIdField);
                buffer = Encoder.WriteCompactBytes(buffer, message.MetadataField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
    }
}