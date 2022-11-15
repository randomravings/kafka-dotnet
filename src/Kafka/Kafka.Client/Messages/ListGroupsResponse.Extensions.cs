using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using ListedGroup = Kafka.Client.Messages.ListGroupsResponse.ListedGroup;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ListGroupsResponseSerde
    {
        private static readonly Func<Stream, ListGroupsResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
            b => ReadV04(b),
        };
        private static readonly Action<Stream, ListGroupsResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
        };
        public static ListGroupsResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, ListGroupsResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static ListGroupsResponse ReadV00(Stream buffer)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var groupsField = Decoder.ReadArray<ListedGroup>(buffer, b => ListedGroupSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                groupsField
            );
        }
        private static void WriteV00(Stream buffer, ListGroupsResponse message)
        {
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteArray<ListedGroup>(buffer, message.GroupsField, (b, i) => ListedGroupSerde.WriteV00(b, i));
        }
        private static ListGroupsResponse ReadV01(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var groupsField = Decoder.ReadArray<ListedGroup>(buffer, b => ListedGroupSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                groupsField
            );
        }
        private static void WriteV01(Stream buffer, ListGroupsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteArray<ListedGroup>(buffer, message.GroupsField, (b, i) => ListedGroupSerde.WriteV01(b, i));
        }
        private static ListGroupsResponse ReadV02(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var groupsField = Decoder.ReadArray<ListedGroup>(buffer, b => ListedGroupSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                groupsField
            );
        }
        private static void WriteV02(Stream buffer, ListGroupsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteArray<ListedGroup>(buffer, message.GroupsField, (b, i) => ListedGroupSerde.WriteV02(b, i));
        }
        private static ListGroupsResponse ReadV03(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var groupsField = Decoder.ReadCompactArray<ListedGroup>(buffer, b => ListedGroupSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                groupsField
            );
        }
        private static void WriteV03(Stream buffer, ListGroupsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteCompactArray<ListedGroup>(buffer, message.GroupsField, (b, i) => ListedGroupSerde.WriteV03(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static ListGroupsResponse ReadV04(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var groupsField = Decoder.ReadCompactArray<ListedGroup>(buffer, b => ListedGroupSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                groupsField
            );
        }
        private static void WriteV04(Stream buffer, ListGroupsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteCompactArray<ListedGroup>(buffer, message.GroupsField, (b, i) => ListedGroupSerde.WriteV04(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class ListedGroupSerde
        {
            public static ListedGroup ReadV00(Stream buffer)
            {
                var groupIdField = Decoder.ReadString(buffer);
                var protocolTypeField = Decoder.ReadString(buffer);
                var groupStateField = "";
                return new(
                    groupIdField,
                    protocolTypeField,
                    groupStateField
                );
            }
            public static void WriteV00(Stream buffer, ListedGroup message)
            {
                Encoder.WriteString(buffer, message.GroupIdField);
                Encoder.WriteString(buffer, message.ProtocolTypeField);
            }
            public static ListedGroup ReadV01(Stream buffer)
            {
                var groupIdField = Decoder.ReadString(buffer);
                var protocolTypeField = Decoder.ReadString(buffer);
                var groupStateField = "";
                return new(
                    groupIdField,
                    protocolTypeField,
                    groupStateField
                );
            }
            public static void WriteV01(Stream buffer, ListedGroup message)
            {
                Encoder.WriteString(buffer, message.GroupIdField);
                Encoder.WriteString(buffer, message.ProtocolTypeField);
            }
            public static ListedGroup ReadV02(Stream buffer)
            {
                var groupIdField = Decoder.ReadString(buffer);
                var protocolTypeField = Decoder.ReadString(buffer);
                var groupStateField = "";
                return new(
                    groupIdField,
                    protocolTypeField,
                    groupStateField
                );
            }
            public static void WriteV02(Stream buffer, ListedGroup message)
            {
                Encoder.WriteString(buffer, message.GroupIdField);
                Encoder.WriteString(buffer, message.ProtocolTypeField);
            }
            public static ListedGroup ReadV03(Stream buffer)
            {
                var groupIdField = Decoder.ReadCompactString(buffer);
                var protocolTypeField = Decoder.ReadCompactString(buffer);
                var groupStateField = "";
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    groupIdField,
                    protocolTypeField,
                    groupStateField
                );
            }
            public static void WriteV03(Stream buffer, ListedGroup message)
            {
                Encoder.WriteCompactString(buffer, message.GroupIdField);
                Encoder.WriteCompactString(buffer, message.ProtocolTypeField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static ListedGroup ReadV04(Stream buffer)
            {
                var groupIdField = Decoder.ReadCompactString(buffer);
                var protocolTypeField = Decoder.ReadCompactString(buffer);
                var groupStateField = Decoder.ReadCompactString(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    groupIdField,
                    protocolTypeField,
                    groupStateField
                );
            }
            public static void WriteV04(Stream buffer, ListedGroup message)
            {
                Encoder.WriteCompactString(buffer, message.GroupIdField);
                Encoder.WriteCompactString(buffer, message.ProtocolTypeField);
                Encoder.WriteCompactString(buffer, message.GroupStateField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
    }
}