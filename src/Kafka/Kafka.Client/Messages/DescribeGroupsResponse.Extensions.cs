using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using DescribedGroup = Kafka.Client.Messages.DescribeGroupsResponse.DescribedGroup;
using DescribedGroupMember = Kafka.Client.Messages.DescribeGroupsResponse.DescribedGroup.DescribedGroupMember;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeGroupsResponseSerde
    {
        private static readonly DecodeDelegate<DescribeGroupsResponse>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
            ReadV04,
            ReadV05,
        };
        private static readonly EncodeDelegate<DescribeGroupsResponse>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
            WriteV04,
            WriteV05,
        };
        public static DescribeGroupsResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, DescribeGroupsResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static DescribeGroupsResponse ReadV00(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = default(int);
            var groupsField = Decoder.ReadArray<DescribedGroup>(buffer, ref index, DescribedGroupSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            return new(
                throttleTimeMsField,
                groupsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, DescribeGroupsResponse message)
        {
            index = Encoder.WriteArray<DescribedGroup>(buffer, index, message.GroupsField, DescribedGroupSerde.WriteV00);
            return index;
        }
        private static DescribeGroupsResponse ReadV01(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var groupsField = Decoder.ReadArray<DescribedGroup>(buffer, ref index, DescribedGroupSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            return new(
                throttleTimeMsField,
                groupsField
            );
        }
        private static int WriteV01(byte[] buffer, int index, DescribeGroupsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<DescribedGroup>(buffer, index, message.GroupsField, DescribedGroupSerde.WriteV01);
            return index;
        }
        private static DescribeGroupsResponse ReadV02(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var groupsField = Decoder.ReadArray<DescribedGroup>(buffer, ref index, DescribedGroupSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            return new(
                throttleTimeMsField,
                groupsField
            );
        }
        private static int WriteV02(byte[] buffer, int index, DescribeGroupsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<DescribedGroup>(buffer, index, message.GroupsField, DescribedGroupSerde.WriteV02);
            return index;
        }
        private static DescribeGroupsResponse ReadV03(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var groupsField = Decoder.ReadArray<DescribedGroup>(buffer, ref index, DescribedGroupSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            return new(
                throttleTimeMsField,
                groupsField
            );
        }
        private static int WriteV03(byte[] buffer, int index, DescribeGroupsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<DescribedGroup>(buffer, index, message.GroupsField, DescribedGroupSerde.WriteV03);
            return index;
        }
        private static DescribeGroupsResponse ReadV04(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var groupsField = Decoder.ReadArray<DescribedGroup>(buffer, ref index, DescribedGroupSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            return new(
                throttleTimeMsField,
                groupsField
            );
        }
        private static int WriteV04(byte[] buffer, int index, DescribeGroupsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<DescribedGroup>(buffer, index, message.GroupsField, DescribedGroupSerde.WriteV04);
            return index;
        }
        private static DescribeGroupsResponse ReadV05(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var groupsField = Decoder.ReadCompactArray<DescribedGroup>(buffer, ref index, DescribedGroupSerde.ReadV05) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                groupsField
            );
        }
        private static int WriteV05(byte[] buffer, int index, DescribeGroupsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteCompactArray<DescribedGroup>(buffer, index, message.GroupsField, DescribedGroupSerde.WriteV05);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class DescribedGroupSerde
        {
            public static DescribedGroup ReadV00(byte[] buffer, ref int index)
            {
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                var groupIdField = Decoder.ReadString(buffer, ref index);
                var groupStateField = Decoder.ReadString(buffer, ref index);
                var protocolTypeField = Decoder.ReadString(buffer, ref index);
                var protocolDataField = Decoder.ReadString(buffer, ref index);
                var membersField = Decoder.ReadArray<DescribedGroupMember>(buffer, ref index, DescribedGroupMemberSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Members'");
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
            public static int WriteV00(byte[] buffer, int index, DescribedGroup message)
            {
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteString(buffer, index, message.GroupIdField);
                index = Encoder.WriteString(buffer, index, message.GroupStateField);
                index = Encoder.WriteString(buffer, index, message.ProtocolTypeField);
                index = Encoder.WriteString(buffer, index, message.ProtocolDataField);
                index = Encoder.WriteArray<DescribedGroupMember>(buffer, index, message.MembersField, DescribedGroupMemberSerde.WriteV00);
                return index;
            }
            public static DescribedGroup ReadV01(byte[] buffer, ref int index)
            {
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                var groupIdField = Decoder.ReadString(buffer, ref index);
                var groupStateField = Decoder.ReadString(buffer, ref index);
                var protocolTypeField = Decoder.ReadString(buffer, ref index);
                var protocolDataField = Decoder.ReadString(buffer, ref index);
                var membersField = Decoder.ReadArray<DescribedGroupMember>(buffer, ref index, DescribedGroupMemberSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Members'");
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
            public static int WriteV01(byte[] buffer, int index, DescribedGroup message)
            {
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteString(buffer, index, message.GroupIdField);
                index = Encoder.WriteString(buffer, index, message.GroupStateField);
                index = Encoder.WriteString(buffer, index, message.ProtocolTypeField);
                index = Encoder.WriteString(buffer, index, message.ProtocolDataField);
                index = Encoder.WriteArray<DescribedGroupMember>(buffer, index, message.MembersField, DescribedGroupMemberSerde.WriteV01);
                return index;
            }
            public static DescribedGroup ReadV02(byte[] buffer, ref int index)
            {
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                var groupIdField = Decoder.ReadString(buffer, ref index);
                var groupStateField = Decoder.ReadString(buffer, ref index);
                var protocolTypeField = Decoder.ReadString(buffer, ref index);
                var protocolDataField = Decoder.ReadString(buffer, ref index);
                var membersField = Decoder.ReadArray<DescribedGroupMember>(buffer, ref index, DescribedGroupMemberSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Members'");
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
            public static int WriteV02(byte[] buffer, int index, DescribedGroup message)
            {
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteString(buffer, index, message.GroupIdField);
                index = Encoder.WriteString(buffer, index, message.GroupStateField);
                index = Encoder.WriteString(buffer, index, message.ProtocolTypeField);
                index = Encoder.WriteString(buffer, index, message.ProtocolDataField);
                index = Encoder.WriteArray<DescribedGroupMember>(buffer, index, message.MembersField, DescribedGroupMemberSerde.WriteV02);
                return index;
            }
            public static DescribedGroup ReadV03(byte[] buffer, ref int index)
            {
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                var groupIdField = Decoder.ReadString(buffer, ref index);
                var groupStateField = Decoder.ReadString(buffer, ref index);
                var protocolTypeField = Decoder.ReadString(buffer, ref index);
                var protocolDataField = Decoder.ReadString(buffer, ref index);
                var membersField = Decoder.ReadArray<DescribedGroupMember>(buffer, ref index, DescribedGroupMemberSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Members'");
                var authorizedOperationsField = Decoder.ReadInt32(buffer, ref index);
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
            public static int WriteV03(byte[] buffer, int index, DescribedGroup message)
            {
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteString(buffer, index, message.GroupIdField);
                index = Encoder.WriteString(buffer, index, message.GroupStateField);
                index = Encoder.WriteString(buffer, index, message.ProtocolTypeField);
                index = Encoder.WriteString(buffer, index, message.ProtocolDataField);
                index = Encoder.WriteArray<DescribedGroupMember>(buffer, index, message.MembersField, DescribedGroupMemberSerde.WriteV03);
                index = Encoder.WriteInt32(buffer, index, message.AuthorizedOperationsField);
                return index;
            }
            public static DescribedGroup ReadV04(byte[] buffer, ref int index)
            {
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                var groupIdField = Decoder.ReadString(buffer, ref index);
                var groupStateField = Decoder.ReadString(buffer, ref index);
                var protocolTypeField = Decoder.ReadString(buffer, ref index);
                var protocolDataField = Decoder.ReadString(buffer, ref index);
                var membersField = Decoder.ReadArray<DescribedGroupMember>(buffer, ref index, DescribedGroupMemberSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'Members'");
                var authorizedOperationsField = Decoder.ReadInt32(buffer, ref index);
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
            public static int WriteV04(byte[] buffer, int index, DescribedGroup message)
            {
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteString(buffer, index, message.GroupIdField);
                index = Encoder.WriteString(buffer, index, message.GroupStateField);
                index = Encoder.WriteString(buffer, index, message.ProtocolTypeField);
                index = Encoder.WriteString(buffer, index, message.ProtocolDataField);
                index = Encoder.WriteArray<DescribedGroupMember>(buffer, index, message.MembersField, DescribedGroupMemberSerde.WriteV04);
                index = Encoder.WriteInt32(buffer, index, message.AuthorizedOperationsField);
                return index;
            }
            public static DescribedGroup ReadV05(byte[] buffer, ref int index)
            {
                var errorCodeField = Decoder.ReadInt16(buffer, ref index);
                var groupIdField = Decoder.ReadCompactString(buffer, ref index);
                var groupStateField = Decoder.ReadCompactString(buffer, ref index);
                var protocolTypeField = Decoder.ReadCompactString(buffer, ref index);
                var protocolDataField = Decoder.ReadCompactString(buffer, ref index);
                var membersField = Decoder.ReadCompactArray<DescribedGroupMember>(buffer, ref index, DescribedGroupMemberSerde.ReadV05) ?? throw new NullReferenceException("Null not allowed for 'Members'");
                var authorizedOperationsField = Decoder.ReadInt32(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
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
            public static int WriteV05(byte[] buffer, int index, DescribedGroup message)
            {
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteCompactString(buffer, index, message.GroupIdField);
                index = Encoder.WriteCompactString(buffer, index, message.GroupStateField);
                index = Encoder.WriteCompactString(buffer, index, message.ProtocolTypeField);
                index = Encoder.WriteCompactString(buffer, index, message.ProtocolDataField);
                index = Encoder.WriteCompactArray<DescribedGroupMember>(buffer, index, message.MembersField, DescribedGroupMemberSerde.WriteV05);
                index = Encoder.WriteInt32(buffer, index, message.AuthorizedOperationsField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class DescribedGroupMemberSerde
            {
                public static DescribedGroupMember ReadV00(byte[] buffer, ref int index)
                {
                    var memberIdField = Decoder.ReadString(buffer, ref index);
                    var groupInstanceIdField = default(string?);
                    var clientIdField = Decoder.ReadString(buffer, ref index);
                    var clientHostField = Decoder.ReadString(buffer, ref index);
                    var memberMetadataField = Decoder.ReadBytes(buffer, ref index);
                    var memberAssignmentField = Decoder.ReadBytes(buffer, ref index);
                    return new(
                        memberIdField,
                        groupInstanceIdField,
                        clientIdField,
                        clientHostField,
                        memberMetadataField,
                        memberAssignmentField
                    );
                }
                public static int WriteV00(byte[] buffer, int index, DescribedGroupMember message)
                {
                    index = Encoder.WriteString(buffer, index, message.MemberIdField);
                    index = Encoder.WriteString(buffer, index, message.ClientIdField);
                    index = Encoder.WriteString(buffer, index, message.ClientHostField);
                    index = Encoder.WriteBytes(buffer, index, message.MemberMetadataField);
                    index = Encoder.WriteBytes(buffer, index, message.MemberAssignmentField);
                    return index;
                }
                public static DescribedGroupMember ReadV01(byte[] buffer, ref int index)
                {
                    var memberIdField = Decoder.ReadString(buffer, ref index);
                    var groupInstanceIdField = default(string?);
                    var clientIdField = Decoder.ReadString(buffer, ref index);
                    var clientHostField = Decoder.ReadString(buffer, ref index);
                    var memberMetadataField = Decoder.ReadBytes(buffer, ref index);
                    var memberAssignmentField = Decoder.ReadBytes(buffer, ref index);
                    return new(
                        memberIdField,
                        groupInstanceIdField,
                        clientIdField,
                        clientHostField,
                        memberMetadataField,
                        memberAssignmentField
                    );
                }
                public static int WriteV01(byte[] buffer, int index, DescribedGroupMember message)
                {
                    index = Encoder.WriteString(buffer, index, message.MemberIdField);
                    index = Encoder.WriteString(buffer, index, message.ClientIdField);
                    index = Encoder.WriteString(buffer, index, message.ClientHostField);
                    index = Encoder.WriteBytes(buffer, index, message.MemberMetadataField);
                    index = Encoder.WriteBytes(buffer, index, message.MemberAssignmentField);
                    return index;
                }
                public static DescribedGroupMember ReadV02(byte[] buffer, ref int index)
                {
                    var memberIdField = Decoder.ReadString(buffer, ref index);
                    var groupInstanceIdField = default(string?);
                    var clientIdField = Decoder.ReadString(buffer, ref index);
                    var clientHostField = Decoder.ReadString(buffer, ref index);
                    var memberMetadataField = Decoder.ReadBytes(buffer, ref index);
                    var memberAssignmentField = Decoder.ReadBytes(buffer, ref index);
                    return new(
                        memberIdField,
                        groupInstanceIdField,
                        clientIdField,
                        clientHostField,
                        memberMetadataField,
                        memberAssignmentField
                    );
                }
                public static int WriteV02(byte[] buffer, int index, DescribedGroupMember message)
                {
                    index = Encoder.WriteString(buffer, index, message.MemberIdField);
                    index = Encoder.WriteString(buffer, index, message.ClientIdField);
                    index = Encoder.WriteString(buffer, index, message.ClientHostField);
                    index = Encoder.WriteBytes(buffer, index, message.MemberMetadataField);
                    index = Encoder.WriteBytes(buffer, index, message.MemberAssignmentField);
                    return index;
                }
                public static DescribedGroupMember ReadV03(byte[] buffer, ref int index)
                {
                    var memberIdField = Decoder.ReadString(buffer, ref index);
                    var groupInstanceIdField = default(string?);
                    var clientIdField = Decoder.ReadString(buffer, ref index);
                    var clientHostField = Decoder.ReadString(buffer, ref index);
                    var memberMetadataField = Decoder.ReadBytes(buffer, ref index);
                    var memberAssignmentField = Decoder.ReadBytes(buffer, ref index);
                    return new(
                        memberIdField,
                        groupInstanceIdField,
                        clientIdField,
                        clientHostField,
                        memberMetadataField,
                        memberAssignmentField
                    );
                }
                public static int WriteV03(byte[] buffer, int index, DescribedGroupMember message)
                {
                    index = Encoder.WriteString(buffer, index, message.MemberIdField);
                    index = Encoder.WriteString(buffer, index, message.ClientIdField);
                    index = Encoder.WriteString(buffer, index, message.ClientHostField);
                    index = Encoder.WriteBytes(buffer, index, message.MemberMetadataField);
                    index = Encoder.WriteBytes(buffer, index, message.MemberAssignmentField);
                    return index;
                }
                public static DescribedGroupMember ReadV04(byte[] buffer, ref int index)
                {
                    var memberIdField = Decoder.ReadString(buffer, ref index);
                    var groupInstanceIdField = Decoder.ReadNullableString(buffer, ref index);
                    var clientIdField = Decoder.ReadString(buffer, ref index);
                    var clientHostField = Decoder.ReadString(buffer, ref index);
                    var memberMetadataField = Decoder.ReadBytes(buffer, ref index);
                    var memberAssignmentField = Decoder.ReadBytes(buffer, ref index);
                    return new(
                        memberIdField,
                        groupInstanceIdField,
                        clientIdField,
                        clientHostField,
                        memberMetadataField,
                        memberAssignmentField
                    );
                }
                public static int WriteV04(byte[] buffer, int index, DescribedGroupMember message)
                {
                    index = Encoder.WriteString(buffer, index, message.MemberIdField);
                    index = Encoder.WriteNullableString(buffer, index, message.GroupInstanceIdField);
                    index = Encoder.WriteString(buffer, index, message.ClientIdField);
                    index = Encoder.WriteString(buffer, index, message.ClientHostField);
                    index = Encoder.WriteBytes(buffer, index, message.MemberMetadataField);
                    index = Encoder.WriteBytes(buffer, index, message.MemberAssignmentField);
                    return index;
                }
                public static DescribedGroupMember ReadV05(byte[] buffer, ref int index)
                {
                    var memberIdField = Decoder.ReadCompactString(buffer, ref index);
                    var groupInstanceIdField = Decoder.ReadCompactNullableString(buffer, ref index);
                    var clientIdField = Decoder.ReadCompactString(buffer, ref index);
                    var clientHostField = Decoder.ReadCompactString(buffer, ref index);
                    var memberMetadataField = Decoder.ReadCompactBytes(buffer, ref index);
                    var memberAssignmentField = Decoder.ReadCompactBytes(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        memberIdField,
                        groupInstanceIdField,
                        clientIdField,
                        clientHostField,
                        memberMetadataField,
                        memberAssignmentField
                    );
                }
                public static int WriteV05(byte[] buffer, int index, DescribedGroupMember message)
                {
                    index = Encoder.WriteCompactString(buffer, index, message.MemberIdField);
                    index = Encoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
                    index = Encoder.WriteCompactString(buffer, index, message.ClientIdField);
                    index = Encoder.WriteCompactString(buffer, index, message.ClientHostField);
                    index = Encoder.WriteCompactBytes(buffer, index, message.MemberMetadataField);
                    index = Encoder.WriteCompactBytes(buffer, index, message.MemberAssignmentField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
            }
        }
    }
}