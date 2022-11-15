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
        private static readonly Func<Stream, DescribeGroupsResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
            b => ReadV04(b),
            b => ReadV05(b),
        };
        private static readonly Action<Stream, DescribeGroupsResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
            (b, m) => WriteV05(b, m),
        };
        public static DescribeGroupsResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, DescribeGroupsResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static DescribeGroupsResponse ReadV00(Stream buffer)
        {
            var throttleTimeMsField = default(int);
            var groupsField = Decoder.ReadArray<DescribedGroup>(buffer, b => DescribedGroupSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            return new(
                throttleTimeMsField,
                groupsField
            );
        }
        private static void WriteV00(Stream buffer, DescribeGroupsResponse message)
        {
            Encoder.WriteArray<DescribedGroup>(buffer, message.GroupsField, (b, i) => DescribedGroupSerde.WriteV00(b, i));
        }
        private static DescribeGroupsResponse ReadV01(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var groupsField = Decoder.ReadArray<DescribedGroup>(buffer, b => DescribedGroupSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            return new(
                throttleTimeMsField,
                groupsField
            );
        }
        private static void WriteV01(Stream buffer, DescribeGroupsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<DescribedGroup>(buffer, message.GroupsField, (b, i) => DescribedGroupSerde.WriteV01(b, i));
        }
        private static DescribeGroupsResponse ReadV02(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var groupsField = Decoder.ReadArray<DescribedGroup>(buffer, b => DescribedGroupSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            return new(
                throttleTimeMsField,
                groupsField
            );
        }
        private static void WriteV02(Stream buffer, DescribeGroupsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<DescribedGroup>(buffer, message.GroupsField, (b, i) => DescribedGroupSerde.WriteV02(b, i));
        }
        private static DescribeGroupsResponse ReadV03(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var groupsField = Decoder.ReadArray<DescribedGroup>(buffer, b => DescribedGroupSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            return new(
                throttleTimeMsField,
                groupsField
            );
        }
        private static void WriteV03(Stream buffer, DescribeGroupsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<DescribedGroup>(buffer, message.GroupsField, (b, i) => DescribedGroupSerde.WriteV03(b, i));
        }
        private static DescribeGroupsResponse ReadV04(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var groupsField = Decoder.ReadArray<DescribedGroup>(buffer, b => DescribedGroupSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            return new(
                throttleTimeMsField,
                groupsField
            );
        }
        private static void WriteV04(Stream buffer, DescribeGroupsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<DescribedGroup>(buffer, message.GroupsField, (b, i) => DescribedGroupSerde.WriteV04(b, i));
        }
        private static DescribeGroupsResponse ReadV05(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var groupsField = Decoder.ReadCompactArray<DescribedGroup>(buffer, b => DescribedGroupSerde.ReadV05(b)) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                groupsField
            );
        }
        private static void WriteV05(Stream buffer, DescribeGroupsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteCompactArray<DescribedGroup>(buffer, message.GroupsField, (b, i) => DescribedGroupSerde.WriteV05(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class DescribedGroupSerde
        {
            public static DescribedGroup ReadV00(Stream buffer)
            {
                var errorCodeField = Decoder.ReadInt16(buffer);
                var groupIdField = Decoder.ReadString(buffer);
                var groupStateField = Decoder.ReadString(buffer);
                var protocolTypeField = Decoder.ReadString(buffer);
                var protocolDataField = Decoder.ReadString(buffer);
                var membersField = Decoder.ReadArray<DescribedGroupMember>(buffer, b => DescribedGroupMemberSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Members'");
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
            public static void WriteV00(Stream buffer, DescribedGroup message)
            {
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteString(buffer, message.GroupIdField);
                Encoder.WriteString(buffer, message.GroupStateField);
                Encoder.WriteString(buffer, message.ProtocolTypeField);
                Encoder.WriteString(buffer, message.ProtocolDataField);
                Encoder.WriteArray<DescribedGroupMember>(buffer, message.MembersField, (b, i) => DescribedGroupMemberSerde.WriteV00(b, i));
            }
            public static DescribedGroup ReadV01(Stream buffer)
            {
                var errorCodeField = Decoder.ReadInt16(buffer);
                var groupIdField = Decoder.ReadString(buffer);
                var groupStateField = Decoder.ReadString(buffer);
                var protocolTypeField = Decoder.ReadString(buffer);
                var protocolDataField = Decoder.ReadString(buffer);
                var membersField = Decoder.ReadArray<DescribedGroupMember>(buffer, b => DescribedGroupMemberSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Members'");
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
            public static void WriteV01(Stream buffer, DescribedGroup message)
            {
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteString(buffer, message.GroupIdField);
                Encoder.WriteString(buffer, message.GroupStateField);
                Encoder.WriteString(buffer, message.ProtocolTypeField);
                Encoder.WriteString(buffer, message.ProtocolDataField);
                Encoder.WriteArray<DescribedGroupMember>(buffer, message.MembersField, (b, i) => DescribedGroupMemberSerde.WriteV01(b, i));
            }
            public static DescribedGroup ReadV02(Stream buffer)
            {
                var errorCodeField = Decoder.ReadInt16(buffer);
                var groupIdField = Decoder.ReadString(buffer);
                var groupStateField = Decoder.ReadString(buffer);
                var protocolTypeField = Decoder.ReadString(buffer);
                var protocolDataField = Decoder.ReadString(buffer);
                var membersField = Decoder.ReadArray<DescribedGroupMember>(buffer, b => DescribedGroupMemberSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Members'");
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
            public static void WriteV02(Stream buffer, DescribedGroup message)
            {
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteString(buffer, message.GroupIdField);
                Encoder.WriteString(buffer, message.GroupStateField);
                Encoder.WriteString(buffer, message.ProtocolTypeField);
                Encoder.WriteString(buffer, message.ProtocolDataField);
                Encoder.WriteArray<DescribedGroupMember>(buffer, message.MembersField, (b, i) => DescribedGroupMemberSerde.WriteV02(b, i));
            }
            public static DescribedGroup ReadV03(Stream buffer)
            {
                var errorCodeField = Decoder.ReadInt16(buffer);
                var groupIdField = Decoder.ReadString(buffer);
                var groupStateField = Decoder.ReadString(buffer);
                var protocolTypeField = Decoder.ReadString(buffer);
                var protocolDataField = Decoder.ReadString(buffer);
                var membersField = Decoder.ReadArray<DescribedGroupMember>(buffer, b => DescribedGroupMemberSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Members'");
                var authorizedOperationsField = Decoder.ReadInt32(buffer);
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
            public static void WriteV03(Stream buffer, DescribedGroup message)
            {
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteString(buffer, message.GroupIdField);
                Encoder.WriteString(buffer, message.GroupStateField);
                Encoder.WriteString(buffer, message.ProtocolTypeField);
                Encoder.WriteString(buffer, message.ProtocolDataField);
                Encoder.WriteArray<DescribedGroupMember>(buffer, message.MembersField, (b, i) => DescribedGroupMemberSerde.WriteV03(b, i));
                Encoder.WriteInt32(buffer, message.AuthorizedOperationsField);
            }
            public static DescribedGroup ReadV04(Stream buffer)
            {
                var errorCodeField = Decoder.ReadInt16(buffer);
                var groupIdField = Decoder.ReadString(buffer);
                var groupStateField = Decoder.ReadString(buffer);
                var protocolTypeField = Decoder.ReadString(buffer);
                var protocolDataField = Decoder.ReadString(buffer);
                var membersField = Decoder.ReadArray<DescribedGroupMember>(buffer, b => DescribedGroupMemberSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'Members'");
                var authorizedOperationsField = Decoder.ReadInt32(buffer);
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
            public static void WriteV04(Stream buffer, DescribedGroup message)
            {
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteString(buffer, message.GroupIdField);
                Encoder.WriteString(buffer, message.GroupStateField);
                Encoder.WriteString(buffer, message.ProtocolTypeField);
                Encoder.WriteString(buffer, message.ProtocolDataField);
                Encoder.WriteArray<DescribedGroupMember>(buffer, message.MembersField, (b, i) => DescribedGroupMemberSerde.WriteV04(b, i));
                Encoder.WriteInt32(buffer, message.AuthorizedOperationsField);
            }
            public static DescribedGroup ReadV05(Stream buffer)
            {
                var errorCodeField = Decoder.ReadInt16(buffer);
                var groupIdField = Decoder.ReadCompactString(buffer);
                var groupStateField = Decoder.ReadCompactString(buffer);
                var protocolTypeField = Decoder.ReadCompactString(buffer);
                var protocolDataField = Decoder.ReadCompactString(buffer);
                var membersField = Decoder.ReadCompactArray<DescribedGroupMember>(buffer, b => DescribedGroupMemberSerde.ReadV05(b)) ?? throw new NullReferenceException("Null not allowed for 'Members'");
                var authorizedOperationsField = Decoder.ReadInt32(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
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
            public static void WriteV05(Stream buffer, DescribedGroup message)
            {
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteCompactString(buffer, message.GroupIdField);
                Encoder.WriteCompactString(buffer, message.GroupStateField);
                Encoder.WriteCompactString(buffer, message.ProtocolTypeField);
                Encoder.WriteCompactString(buffer, message.ProtocolDataField);
                Encoder.WriteCompactArray<DescribedGroupMember>(buffer, message.MembersField, (b, i) => DescribedGroupMemberSerde.WriteV05(b, i));
                Encoder.WriteInt32(buffer, message.AuthorizedOperationsField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class DescribedGroupMemberSerde
            {
                public static DescribedGroupMember ReadV00(Stream buffer)
                {
                    var memberIdField = Decoder.ReadString(buffer);
                    var groupInstanceIdField = default(string?);
                    var clientIdField = Decoder.ReadString(buffer);
                    var clientHostField = Decoder.ReadString(buffer);
                    var memberMetadataField = Decoder.ReadBytes(buffer);
                    var memberAssignmentField = Decoder.ReadBytes(buffer);
                    return new(
                        memberIdField,
                        groupInstanceIdField,
                        clientIdField,
                        clientHostField,
                        memberMetadataField,
                        memberAssignmentField
                    );
                }
                public static void WriteV00(Stream buffer, DescribedGroupMember message)
                {
                    Encoder.WriteString(buffer, message.MemberIdField);
                    Encoder.WriteString(buffer, message.ClientIdField);
                    Encoder.WriteString(buffer, message.ClientHostField);
                    Encoder.WriteBytes(buffer, message.MemberMetadataField);
                    Encoder.WriteBytes(buffer, message.MemberAssignmentField);
                }
                public static DescribedGroupMember ReadV01(Stream buffer)
                {
                    var memberIdField = Decoder.ReadString(buffer);
                    var groupInstanceIdField = default(string?);
                    var clientIdField = Decoder.ReadString(buffer);
                    var clientHostField = Decoder.ReadString(buffer);
                    var memberMetadataField = Decoder.ReadBytes(buffer);
                    var memberAssignmentField = Decoder.ReadBytes(buffer);
                    return new(
                        memberIdField,
                        groupInstanceIdField,
                        clientIdField,
                        clientHostField,
                        memberMetadataField,
                        memberAssignmentField
                    );
                }
                public static void WriteV01(Stream buffer, DescribedGroupMember message)
                {
                    Encoder.WriteString(buffer, message.MemberIdField);
                    Encoder.WriteString(buffer, message.ClientIdField);
                    Encoder.WriteString(buffer, message.ClientHostField);
                    Encoder.WriteBytes(buffer, message.MemberMetadataField);
                    Encoder.WriteBytes(buffer, message.MemberAssignmentField);
                }
                public static DescribedGroupMember ReadV02(Stream buffer)
                {
                    var memberIdField = Decoder.ReadString(buffer);
                    var groupInstanceIdField = default(string?);
                    var clientIdField = Decoder.ReadString(buffer);
                    var clientHostField = Decoder.ReadString(buffer);
                    var memberMetadataField = Decoder.ReadBytes(buffer);
                    var memberAssignmentField = Decoder.ReadBytes(buffer);
                    return new(
                        memberIdField,
                        groupInstanceIdField,
                        clientIdField,
                        clientHostField,
                        memberMetadataField,
                        memberAssignmentField
                    );
                }
                public static void WriteV02(Stream buffer, DescribedGroupMember message)
                {
                    Encoder.WriteString(buffer, message.MemberIdField);
                    Encoder.WriteString(buffer, message.ClientIdField);
                    Encoder.WriteString(buffer, message.ClientHostField);
                    Encoder.WriteBytes(buffer, message.MemberMetadataField);
                    Encoder.WriteBytes(buffer, message.MemberAssignmentField);
                }
                public static DescribedGroupMember ReadV03(Stream buffer)
                {
                    var memberIdField = Decoder.ReadString(buffer);
                    var groupInstanceIdField = default(string?);
                    var clientIdField = Decoder.ReadString(buffer);
                    var clientHostField = Decoder.ReadString(buffer);
                    var memberMetadataField = Decoder.ReadBytes(buffer);
                    var memberAssignmentField = Decoder.ReadBytes(buffer);
                    return new(
                        memberIdField,
                        groupInstanceIdField,
                        clientIdField,
                        clientHostField,
                        memberMetadataField,
                        memberAssignmentField
                    );
                }
                public static void WriteV03(Stream buffer, DescribedGroupMember message)
                {
                    Encoder.WriteString(buffer, message.MemberIdField);
                    Encoder.WriteString(buffer, message.ClientIdField);
                    Encoder.WriteString(buffer, message.ClientHostField);
                    Encoder.WriteBytes(buffer, message.MemberMetadataField);
                    Encoder.WriteBytes(buffer, message.MemberAssignmentField);
                }
                public static DescribedGroupMember ReadV04(Stream buffer)
                {
                    var memberIdField = Decoder.ReadString(buffer);
                    var groupInstanceIdField = Decoder.ReadNullableString(buffer);
                    var clientIdField = Decoder.ReadString(buffer);
                    var clientHostField = Decoder.ReadString(buffer);
                    var memberMetadataField = Decoder.ReadBytes(buffer);
                    var memberAssignmentField = Decoder.ReadBytes(buffer);
                    return new(
                        memberIdField,
                        groupInstanceIdField,
                        clientIdField,
                        clientHostField,
                        memberMetadataField,
                        memberAssignmentField
                    );
                }
                public static void WriteV04(Stream buffer, DescribedGroupMember message)
                {
                    Encoder.WriteString(buffer, message.MemberIdField);
                    Encoder.WriteNullableString(buffer, message.GroupInstanceIdField);
                    Encoder.WriteString(buffer, message.ClientIdField);
                    Encoder.WriteString(buffer, message.ClientHostField);
                    Encoder.WriteBytes(buffer, message.MemberMetadataField);
                    Encoder.WriteBytes(buffer, message.MemberAssignmentField);
                }
                public static DescribedGroupMember ReadV05(Stream buffer)
                {
                    var memberIdField = Decoder.ReadCompactString(buffer);
                    var groupInstanceIdField = Decoder.ReadCompactNullableString(buffer);
                    var clientIdField = Decoder.ReadCompactString(buffer);
                    var clientHostField = Decoder.ReadCompactString(buffer);
                    var memberMetadataField = Decoder.ReadCompactBytes(buffer);
                    var memberAssignmentField = Decoder.ReadCompactBytes(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        memberIdField,
                        groupInstanceIdField,
                        clientIdField,
                        clientHostField,
                        memberMetadataField,
                        memberAssignmentField
                    );
                }
                public static void WriteV05(Stream buffer, DescribedGroupMember message)
                {
                    Encoder.WriteCompactString(buffer, message.MemberIdField);
                    Encoder.WriteCompactNullableString(buffer, message.GroupInstanceIdField);
                    Encoder.WriteCompactString(buffer, message.ClientIdField);
                    Encoder.WriteCompactString(buffer, message.ClientHostField);
                    Encoder.WriteCompactBytes(buffer, message.MemberMetadataField);
                    Encoder.WriteCompactBytes(buffer, message.MemberAssignmentField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
            }
        }
    }
}