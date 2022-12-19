using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using ListedGroup = Kafka.Client.Messages.ListGroupsResponse.ListedGroup;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ListGroupsResponseSerde
    {
        private static readonly DecodeDelegate<ListGroupsResponse>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
            ReadV04,
        };
        private static readonly EncodeDelegate<ListGroupsResponse>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
            WriteV04,
        };
        public static ListGroupsResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, ListGroupsResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static ListGroupsResponse ReadV00(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var groupsField = Decoder.ReadArray<ListedGroup>(buffer, ref index, ListedGroupSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                groupsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, ListGroupsResponse message)
        {
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteArray<ListedGroup>(buffer, index, message.GroupsField, ListedGroupSerde.WriteV00);
            return index;
        }
        private static ListGroupsResponse ReadV01(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var groupsField = Decoder.ReadArray<ListedGroup>(buffer, ref index, ListedGroupSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                groupsField
            );
        }
        private static int WriteV01(byte[] buffer, int index, ListGroupsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteArray<ListedGroup>(buffer, index, message.GroupsField, ListedGroupSerde.WriteV01);
            return index;
        }
        private static ListGroupsResponse ReadV02(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var groupsField = Decoder.ReadArray<ListedGroup>(buffer, ref index, ListedGroupSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                groupsField
            );
        }
        private static int WriteV02(byte[] buffer, int index, ListGroupsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteArray<ListedGroup>(buffer, index, message.GroupsField, ListedGroupSerde.WriteV02);
            return index;
        }
        private static ListGroupsResponse ReadV03(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var groupsField = Decoder.ReadCompactArray<ListedGroup>(buffer, ref index, ListedGroupSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                errorCodeField,
                groupsField
            );
        }
        private static int WriteV03(byte[] buffer, int index, ListGroupsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteCompactArray<ListedGroup>(buffer, index, message.GroupsField, ListedGroupSerde.WriteV03);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static ListGroupsResponse ReadV04(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var groupsField = Decoder.ReadCompactArray<ListedGroup>(buffer, ref index, ListedGroupSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                errorCodeField,
                groupsField
            );
        }
        private static int WriteV04(byte[] buffer, int index, ListGroupsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteCompactArray<ListedGroup>(buffer, index, message.GroupsField, ListedGroupSerde.WriteV04);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class ListedGroupSerde
        {
            public static ListedGroup ReadV00(byte[] buffer, ref int index)
            {
                var groupIdField = Decoder.ReadString(buffer, ref index);
                var protocolTypeField = Decoder.ReadString(buffer, ref index);
                var groupStateField = "";
                return new(
                    groupIdField,
                    protocolTypeField,
                    groupStateField
                );
            }
            public static int WriteV00(byte[] buffer, int index, ListedGroup message)
            {
                index = Encoder.WriteString(buffer, index, message.GroupIdField);
                index = Encoder.WriteString(buffer, index, message.ProtocolTypeField);
                return index;
            }
            public static ListedGroup ReadV01(byte[] buffer, ref int index)
            {
                var groupIdField = Decoder.ReadString(buffer, ref index);
                var protocolTypeField = Decoder.ReadString(buffer, ref index);
                var groupStateField = "";
                return new(
                    groupIdField,
                    protocolTypeField,
                    groupStateField
                );
            }
            public static int WriteV01(byte[] buffer, int index, ListedGroup message)
            {
                index = Encoder.WriteString(buffer, index, message.GroupIdField);
                index = Encoder.WriteString(buffer, index, message.ProtocolTypeField);
                return index;
            }
            public static ListedGroup ReadV02(byte[] buffer, ref int index)
            {
                var groupIdField = Decoder.ReadString(buffer, ref index);
                var protocolTypeField = Decoder.ReadString(buffer, ref index);
                var groupStateField = "";
                return new(
                    groupIdField,
                    protocolTypeField,
                    groupStateField
                );
            }
            public static int WriteV02(byte[] buffer, int index, ListedGroup message)
            {
                index = Encoder.WriteString(buffer, index, message.GroupIdField);
                index = Encoder.WriteString(buffer, index, message.ProtocolTypeField);
                return index;
            }
            public static ListedGroup ReadV03(byte[] buffer, ref int index)
            {
                var groupIdField = Decoder.ReadCompactString(buffer, ref index);
                var protocolTypeField = Decoder.ReadCompactString(buffer, ref index);
                var groupStateField = "";
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    groupIdField,
                    protocolTypeField,
                    groupStateField
                );
            }
            public static int WriteV03(byte[] buffer, int index, ListedGroup message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.GroupIdField);
                index = Encoder.WriteCompactString(buffer, index, message.ProtocolTypeField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static ListedGroup ReadV04(byte[] buffer, ref int index)
            {
                var groupIdField = Decoder.ReadCompactString(buffer, ref index);
                var protocolTypeField = Decoder.ReadCompactString(buffer, ref index);
                var groupStateField = Decoder.ReadCompactString(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    groupIdField,
                    protocolTypeField,
                    groupStateField
                );
            }
            public static int WriteV04(byte[] buffer, int index, ListedGroup message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.GroupIdField);
                index = Encoder.WriteCompactString(buffer, index, message.ProtocolTypeField);
                index = Encoder.WriteCompactString(buffer, index, message.GroupStateField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
        }
    }
}