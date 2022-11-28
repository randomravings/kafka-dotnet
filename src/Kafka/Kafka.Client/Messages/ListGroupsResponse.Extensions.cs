using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using ListedGroup = Kafka.Client.Messages.ListGroupsResponse.ListedGroup;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class ListGroupsResponseSerde
    {
        private static readonly DecodeDelegate<ListGroupsResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV04(ref b),
        };
        private static readonly EncodeDelegate<ListGroupsResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
        };
        public static ListGroupsResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, ListGroupsResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static ListGroupsResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = default(int);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var groupsField = Decoder.ReadArray<ListedGroup>(ref buffer, (ref ReadOnlyMemory<byte> b) => ListedGroupSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                groupsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, ListGroupsResponse message)
        {
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteArray<ListedGroup>(buffer, message.GroupsField, (b, i) => ListedGroupSerde.WriteV00(b, i));
            return buffer;
        }
        private static ListGroupsResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var groupsField = Decoder.ReadArray<ListedGroup>(ref buffer, (ref ReadOnlyMemory<byte> b) => ListedGroupSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                groupsField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, ListGroupsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteArray<ListedGroup>(buffer, message.GroupsField, (b, i) => ListedGroupSerde.WriteV01(b, i));
            return buffer;
        }
        private static ListGroupsResponse ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var groupsField = Decoder.ReadArray<ListedGroup>(ref buffer, (ref ReadOnlyMemory<byte> b) => ListedGroupSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            return new(
                throttleTimeMsField,
                errorCodeField,
                groupsField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, ListGroupsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteArray<ListedGroup>(buffer, message.GroupsField, (b, i) => ListedGroupSerde.WriteV02(b, i));
            return buffer;
        }
        private static ListGroupsResponse ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var groupsField = Decoder.ReadCompactArray<ListedGroup>(ref buffer, (ref ReadOnlyMemory<byte> b) => ListedGroupSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                groupsField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, ListGroupsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteCompactArray<ListedGroup>(buffer, message.GroupsField, (b, i) => ListedGroupSerde.WriteV03(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static ListGroupsResponse ReadV04(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var groupsField = Decoder.ReadCompactArray<ListedGroup>(ref buffer, (ref ReadOnlyMemory<byte> b) => ListedGroupSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Groups'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                groupsField
            );
        }
        private static Memory<byte> WriteV04(Memory<byte> buffer, ListGroupsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteCompactArray<ListedGroup>(buffer, message.GroupsField, (b, i) => ListedGroupSerde.WriteV04(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class ListedGroupSerde
        {
            public static ListedGroup ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var groupIdField = Decoder.ReadString(ref buffer);
                var protocolTypeField = Decoder.ReadString(ref buffer);
                var groupStateField = "";
                return new(
                    groupIdField,
                    protocolTypeField,
                    groupStateField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, ListedGroup message)
            {
                buffer = Encoder.WriteString(buffer, message.GroupIdField);
                buffer = Encoder.WriteString(buffer, message.ProtocolTypeField);
                return buffer;
            }
            public static ListedGroup ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var groupIdField = Decoder.ReadString(ref buffer);
                var protocolTypeField = Decoder.ReadString(ref buffer);
                var groupStateField = "";
                return new(
                    groupIdField,
                    protocolTypeField,
                    groupStateField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, ListedGroup message)
            {
                buffer = Encoder.WriteString(buffer, message.GroupIdField);
                buffer = Encoder.WriteString(buffer, message.ProtocolTypeField);
                return buffer;
            }
            public static ListedGroup ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var groupIdField = Decoder.ReadString(ref buffer);
                var protocolTypeField = Decoder.ReadString(ref buffer);
                var groupStateField = "";
                return new(
                    groupIdField,
                    protocolTypeField,
                    groupStateField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, ListedGroup message)
            {
                buffer = Encoder.WriteString(buffer, message.GroupIdField);
                buffer = Encoder.WriteString(buffer, message.ProtocolTypeField);
                return buffer;
            }
            public static ListedGroup ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var groupIdField = Decoder.ReadCompactString(ref buffer);
                var protocolTypeField = Decoder.ReadCompactString(ref buffer);
                var groupStateField = "";
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    groupIdField,
                    protocolTypeField,
                    groupStateField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, ListedGroup message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.GroupIdField);
                buffer = Encoder.WriteCompactString(buffer, message.ProtocolTypeField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static ListedGroup ReadV04(ref ReadOnlyMemory<byte> buffer)
            {
                var groupIdField = Decoder.ReadCompactString(ref buffer);
                var protocolTypeField = Decoder.ReadCompactString(ref buffer);
                var groupStateField = Decoder.ReadCompactString(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    groupIdField,
                    protocolTypeField,
                    groupStateField
                );
            }
            public static Memory<byte> WriteV04(Memory<byte> buffer, ListedGroup message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.GroupIdField);
                buffer = Encoder.WriteCompactString(buffer, message.ProtocolTypeField);
                buffer = Encoder.WriteCompactString(buffer, message.GroupStateField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
    }
}