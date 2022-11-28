using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using DescribedGroup = Kafka.Client.Messages.DescribeGroupsResponse.DescribedGroup;
using DescribedGroupMember = Kafka.Client.Messages.DescribeGroupsResponse.DescribedGroup.DescribedGroupMember;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeGroupsResponseSerde
    {
        private static readonly DecodeDelegate<DescribeGroupsResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV04(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV05(ref b),
        };
        private static readonly EncodeDelegate<DescribeGroupsResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
            (b, m) => WriteV05(b, m),
        };
        public static DescribeGroupsResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, DescribeGroupsResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static DescribeGroupsResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = default(int);
            var groupsField = Decoder.ReadArray<DescribedGroup>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribedGroupSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            return new(
                throttleTimeMsField,
                groupsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, DescribeGroupsResponse message)
        {
            buffer = Encoder.WriteArray<DescribedGroup>(buffer, message.GroupsField, (b, i) => DescribedGroupSerde.WriteV00(b, i));
            return buffer;
        }
        private static DescribeGroupsResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var groupsField = Decoder.ReadArray<DescribedGroup>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribedGroupSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            return new(
                throttleTimeMsField,
                groupsField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, DescribeGroupsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<DescribedGroup>(buffer, message.GroupsField, (b, i) => DescribedGroupSerde.WriteV01(b, i));
            return buffer;
        }
        private static DescribeGroupsResponse ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var groupsField = Decoder.ReadArray<DescribedGroup>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribedGroupSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            return new(
                throttleTimeMsField,
                groupsField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, DescribeGroupsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<DescribedGroup>(buffer, message.GroupsField, (b, i) => DescribedGroupSerde.WriteV02(b, i));
            return buffer;
        }
        private static DescribeGroupsResponse ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var groupsField = Decoder.ReadArray<DescribedGroup>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribedGroupSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            return new(
                throttleTimeMsField,
                groupsField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, DescribeGroupsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<DescribedGroup>(buffer, message.GroupsField, (b, i) => DescribedGroupSerde.WriteV03(b, i));
            return buffer;
        }
        private static DescribeGroupsResponse ReadV04(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var groupsField = Decoder.ReadArray<DescribedGroup>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribedGroupSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            return new(
                throttleTimeMsField,
                groupsField
            );
        }
        private static Memory<byte> WriteV04(Memory<byte> buffer, DescribeGroupsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<DescribedGroup>(buffer, message.GroupsField, (b, i) => DescribedGroupSerde.WriteV04(b, i));
            return buffer;
        }
        private static DescribeGroupsResponse ReadV05(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var groupsField = Decoder.ReadCompactArray<DescribedGroup>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribedGroupSerde.ReadV05(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                groupsField
            );
        }
        private static Memory<byte> WriteV05(Memory<byte> buffer, DescribeGroupsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteCompactArray<DescribedGroup>(buffer, message.GroupsField, (b, i) => DescribedGroupSerde.WriteV05(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class DescribedGroupSerde
        {
            public static DescribedGroup ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var groupIdField = Decoder.ReadString(ref buffer);
                var groupStateField = Decoder.ReadString(ref buffer);
                var protocolTypeField = Decoder.ReadString(ref buffer);
                var protocolDataField = Decoder.ReadString(ref buffer);
                var membersField = Decoder.ReadArray<DescribedGroupMember>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribedGroupMemberSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Members'");
                var authorizedOperationsField = default(int);
                return new(
                    errorCodeField,
                    groupIdField,
                    groupStateField,
                    protocolTypeField,
                    protocolDataField,
                    membersField,
                    authorizedOperationsField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, DescribedGroup message)
            {
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteString(buffer, message.GroupIdField);
                buffer = Encoder.WriteString(buffer, message.GroupStateField);
                buffer = Encoder.WriteString(buffer, message.ProtocolTypeField);
                buffer = Encoder.WriteString(buffer, message.ProtocolDataField);
                buffer = Encoder.WriteArray<DescribedGroupMember>(buffer, message.MembersField, (b, i) => DescribedGroupMemberSerde.WriteV00(b, i));
                return buffer;
            }
            public static DescribedGroup ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var groupIdField = Decoder.ReadString(ref buffer);
                var groupStateField = Decoder.ReadString(ref buffer);
                var protocolTypeField = Decoder.ReadString(ref buffer);
                var protocolDataField = Decoder.ReadString(ref buffer);
                var membersField = Decoder.ReadArray<DescribedGroupMember>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribedGroupMemberSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Members'");
                var authorizedOperationsField = default(int);
                return new(
                    errorCodeField,
                    groupIdField,
                    groupStateField,
                    protocolTypeField,
                    protocolDataField,
                    membersField,
                    authorizedOperationsField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, DescribedGroup message)
            {
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteString(buffer, message.GroupIdField);
                buffer = Encoder.WriteString(buffer, message.GroupStateField);
                buffer = Encoder.WriteString(buffer, message.ProtocolTypeField);
                buffer = Encoder.WriteString(buffer, message.ProtocolDataField);
                buffer = Encoder.WriteArray<DescribedGroupMember>(buffer, message.MembersField, (b, i) => DescribedGroupMemberSerde.WriteV01(b, i));
                return buffer;
            }
            public static DescribedGroup ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var groupIdField = Decoder.ReadString(ref buffer);
                var groupStateField = Decoder.ReadString(ref buffer);
                var protocolTypeField = Decoder.ReadString(ref buffer);
                var protocolDataField = Decoder.ReadString(ref buffer);
                var membersField = Decoder.ReadArray<DescribedGroupMember>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribedGroupMemberSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Members'");
                var authorizedOperationsField = default(int);
                return new(
                    errorCodeField,
                    groupIdField,
                    groupStateField,
                    protocolTypeField,
                    protocolDataField,
                    membersField,
                    authorizedOperationsField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, DescribedGroup message)
            {
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteString(buffer, message.GroupIdField);
                buffer = Encoder.WriteString(buffer, message.GroupStateField);
                buffer = Encoder.WriteString(buffer, message.ProtocolTypeField);
                buffer = Encoder.WriteString(buffer, message.ProtocolDataField);
                buffer = Encoder.WriteArray<DescribedGroupMember>(buffer, message.MembersField, (b, i) => DescribedGroupMemberSerde.WriteV02(b, i));
                return buffer;
            }
            public static DescribedGroup ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var groupIdField = Decoder.ReadString(ref buffer);
                var groupStateField = Decoder.ReadString(ref buffer);
                var protocolTypeField = Decoder.ReadString(ref buffer);
                var protocolDataField = Decoder.ReadString(ref buffer);
                var membersField = Decoder.ReadArray<DescribedGroupMember>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribedGroupMemberSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Members'");
                var authorizedOperationsField = Decoder.ReadInt32(ref buffer);
                return new(
                    errorCodeField,
                    groupIdField,
                    groupStateField,
                    protocolTypeField,
                    protocolDataField,
                    membersField,
                    authorizedOperationsField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, DescribedGroup message)
            {
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteString(buffer, message.GroupIdField);
                buffer = Encoder.WriteString(buffer, message.GroupStateField);
                buffer = Encoder.WriteString(buffer, message.ProtocolTypeField);
                buffer = Encoder.WriteString(buffer, message.ProtocolDataField);
                buffer = Encoder.WriteArray<DescribedGroupMember>(buffer, message.MembersField, (b, i) => DescribedGroupMemberSerde.WriteV03(b, i));
                buffer = Encoder.WriteInt32(buffer, message.AuthorizedOperationsField);
                return buffer;
            }
            public static DescribedGroup ReadV04(ref ReadOnlyMemory<byte> buffer)
            {
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var groupIdField = Decoder.ReadString(ref buffer);
                var groupStateField = Decoder.ReadString(ref buffer);
                var protocolTypeField = Decoder.ReadString(ref buffer);
                var protocolDataField = Decoder.ReadString(ref buffer);
                var membersField = Decoder.ReadArray<DescribedGroupMember>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribedGroupMemberSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Members'");
                var authorizedOperationsField = Decoder.ReadInt32(ref buffer);
                return new(
                    errorCodeField,
                    groupIdField,
                    groupStateField,
                    protocolTypeField,
                    protocolDataField,
                    membersField,
                    authorizedOperationsField
                );
            }
            public static Memory<byte> WriteV04(Memory<byte> buffer, DescribedGroup message)
            {
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteString(buffer, message.GroupIdField);
                buffer = Encoder.WriteString(buffer, message.GroupStateField);
                buffer = Encoder.WriteString(buffer, message.ProtocolTypeField);
                buffer = Encoder.WriteString(buffer, message.ProtocolDataField);
                buffer = Encoder.WriteArray<DescribedGroupMember>(buffer, message.MembersField, (b, i) => DescribedGroupMemberSerde.WriteV04(b, i));
                buffer = Encoder.WriteInt32(buffer, message.AuthorizedOperationsField);
                return buffer;
            }
            public static DescribedGroup ReadV05(ref ReadOnlyMemory<byte> buffer)
            {
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var groupIdField = Decoder.ReadCompactString(ref buffer);
                var groupStateField = Decoder.ReadCompactString(ref buffer);
                var protocolTypeField = Decoder.ReadCompactString(ref buffer);
                var protocolDataField = Decoder.ReadCompactString(ref buffer);
                var membersField = Decoder.ReadCompactArray<DescribedGroupMember>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribedGroupMemberSerde.ReadV05(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Members'");
                var authorizedOperationsField = Decoder.ReadInt32(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    errorCodeField,
                    groupIdField,
                    groupStateField,
                    protocolTypeField,
                    protocolDataField,
                    membersField,
                    authorizedOperationsField
                );
            }
            public static Memory<byte> WriteV05(Memory<byte> buffer, DescribedGroup message)
            {
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteCompactString(buffer, message.GroupIdField);
                buffer = Encoder.WriteCompactString(buffer, message.GroupStateField);
                buffer = Encoder.WriteCompactString(buffer, message.ProtocolTypeField);
                buffer = Encoder.WriteCompactString(buffer, message.ProtocolDataField);
                buffer = Encoder.WriteCompactArray<DescribedGroupMember>(buffer, message.MembersField, (b, i) => DescribedGroupMemberSerde.WriteV05(b, i));
                buffer = Encoder.WriteInt32(buffer, message.AuthorizedOperationsField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class DescribedGroupMemberSerde
            {
                public static DescribedGroupMember ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var memberIdField = Decoder.ReadString(ref buffer);
                    var groupInstanceIdField = default(string?);
                    var clientIdField = Decoder.ReadString(ref buffer);
                    var clientHostField = Decoder.ReadString(ref buffer);
                    var memberMetadataField = Decoder.ReadBytes(ref buffer);
                    var memberAssignmentField = Decoder.ReadBytes(ref buffer);
                    return new(
                        memberIdField,
                        groupInstanceIdField,
                        clientIdField,
                        clientHostField,
                        memberMetadataField,
                        memberAssignmentField
                    );
                }
                public static Memory<byte> WriteV00(Memory<byte> buffer, DescribedGroupMember message)
                {
                    buffer = Encoder.WriteString(buffer, message.MemberIdField);
                    buffer = Encoder.WriteString(buffer, message.ClientIdField);
                    buffer = Encoder.WriteString(buffer, message.ClientHostField);
                    buffer = Encoder.WriteBytes(buffer, message.MemberMetadataField);
                    buffer = Encoder.WriteBytes(buffer, message.MemberAssignmentField);
                    return buffer;
                }
                public static DescribedGroupMember ReadV01(ref ReadOnlyMemory<byte> buffer)
                {
                    var memberIdField = Decoder.ReadString(ref buffer);
                    var groupInstanceIdField = default(string?);
                    var clientIdField = Decoder.ReadString(ref buffer);
                    var clientHostField = Decoder.ReadString(ref buffer);
                    var memberMetadataField = Decoder.ReadBytes(ref buffer);
                    var memberAssignmentField = Decoder.ReadBytes(ref buffer);
                    return new(
                        memberIdField,
                        groupInstanceIdField,
                        clientIdField,
                        clientHostField,
                        memberMetadataField,
                        memberAssignmentField
                    );
                }
                public static Memory<byte> WriteV01(Memory<byte> buffer, DescribedGroupMember message)
                {
                    buffer = Encoder.WriteString(buffer, message.MemberIdField);
                    buffer = Encoder.WriteString(buffer, message.ClientIdField);
                    buffer = Encoder.WriteString(buffer, message.ClientHostField);
                    buffer = Encoder.WriteBytes(buffer, message.MemberMetadataField);
                    buffer = Encoder.WriteBytes(buffer, message.MemberAssignmentField);
                    return buffer;
                }
                public static DescribedGroupMember ReadV02(ref ReadOnlyMemory<byte> buffer)
                {
                    var memberIdField = Decoder.ReadString(ref buffer);
                    var groupInstanceIdField = default(string?);
                    var clientIdField = Decoder.ReadString(ref buffer);
                    var clientHostField = Decoder.ReadString(ref buffer);
                    var memberMetadataField = Decoder.ReadBytes(ref buffer);
                    var memberAssignmentField = Decoder.ReadBytes(ref buffer);
                    return new(
                        memberIdField,
                        groupInstanceIdField,
                        clientIdField,
                        clientHostField,
                        memberMetadataField,
                        memberAssignmentField
                    );
                }
                public static Memory<byte> WriteV02(Memory<byte> buffer, DescribedGroupMember message)
                {
                    buffer = Encoder.WriteString(buffer, message.MemberIdField);
                    buffer = Encoder.WriteString(buffer, message.ClientIdField);
                    buffer = Encoder.WriteString(buffer, message.ClientHostField);
                    buffer = Encoder.WriteBytes(buffer, message.MemberMetadataField);
                    buffer = Encoder.WriteBytes(buffer, message.MemberAssignmentField);
                    return buffer;
                }
                public static DescribedGroupMember ReadV03(ref ReadOnlyMemory<byte> buffer)
                {
                    var memberIdField = Decoder.ReadString(ref buffer);
                    var groupInstanceIdField = default(string?);
                    var clientIdField = Decoder.ReadString(ref buffer);
                    var clientHostField = Decoder.ReadString(ref buffer);
                    var memberMetadataField = Decoder.ReadBytes(ref buffer);
                    var memberAssignmentField = Decoder.ReadBytes(ref buffer);
                    return new(
                        memberIdField,
                        groupInstanceIdField,
                        clientIdField,
                        clientHostField,
                        memberMetadataField,
                        memberAssignmentField
                    );
                }
                public static Memory<byte> WriteV03(Memory<byte> buffer, DescribedGroupMember message)
                {
                    buffer = Encoder.WriteString(buffer, message.MemberIdField);
                    buffer = Encoder.WriteString(buffer, message.ClientIdField);
                    buffer = Encoder.WriteString(buffer, message.ClientHostField);
                    buffer = Encoder.WriteBytes(buffer, message.MemberMetadataField);
                    buffer = Encoder.WriteBytes(buffer, message.MemberAssignmentField);
                    return buffer;
                }
                public static DescribedGroupMember ReadV04(ref ReadOnlyMemory<byte> buffer)
                {
                    var memberIdField = Decoder.ReadString(ref buffer);
                    var groupInstanceIdField = Decoder.ReadNullableString(ref buffer);
                    var clientIdField = Decoder.ReadString(ref buffer);
                    var clientHostField = Decoder.ReadString(ref buffer);
                    var memberMetadataField = Decoder.ReadBytes(ref buffer);
                    var memberAssignmentField = Decoder.ReadBytes(ref buffer);
                    return new(
                        memberIdField,
                        groupInstanceIdField,
                        clientIdField,
                        clientHostField,
                        memberMetadataField,
                        memberAssignmentField
                    );
                }
                public static Memory<byte> WriteV04(Memory<byte> buffer, DescribedGroupMember message)
                {
                    buffer = Encoder.WriteString(buffer, message.MemberIdField);
                    buffer = Encoder.WriteNullableString(buffer, message.GroupInstanceIdField);
                    buffer = Encoder.WriteString(buffer, message.ClientIdField);
                    buffer = Encoder.WriteString(buffer, message.ClientHostField);
                    buffer = Encoder.WriteBytes(buffer, message.MemberMetadataField);
                    buffer = Encoder.WriteBytes(buffer, message.MemberAssignmentField);
                    return buffer;
                }
                public static DescribedGroupMember ReadV05(ref ReadOnlyMemory<byte> buffer)
                {
                    var memberIdField = Decoder.ReadCompactString(ref buffer);
                    var groupInstanceIdField = Decoder.ReadCompactNullableString(ref buffer);
                    var clientIdField = Decoder.ReadCompactString(ref buffer);
                    var clientHostField = Decoder.ReadCompactString(ref buffer);
                    var memberMetadataField = Decoder.ReadCompactBytes(ref buffer);
                    var memberAssignmentField = Decoder.ReadCompactBytes(ref buffer);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        memberIdField,
                        groupInstanceIdField,
                        clientIdField,
                        clientHostField,
                        memberMetadataField,
                        memberAssignmentField
                    );
                }
                public static Memory<byte> WriteV05(Memory<byte> buffer, DescribedGroupMember message)
                {
                    buffer = Encoder.WriteCompactString(buffer, message.MemberIdField);
                    buffer = Encoder.WriteCompactNullableString(buffer, message.GroupInstanceIdField);
                    buffer = Encoder.WriteCompactString(buffer, message.ClientIdField);
                    buffer = Encoder.WriteCompactString(buffer, message.ClientHostField);
                    buffer = Encoder.WriteCompactBytes(buffer, message.MemberMetadataField);
                    buffer = Encoder.WriteCompactBytes(buffer, message.MemberAssignmentField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
            }
        }
    }
}