using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using JoinGroupRequestProtocol = Kafka.Client.Messages.JoinGroupRequest.JoinGroupRequestProtocol;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class JoinGroupRequestSerde
    {
        private static readonly DecodeDelegate<JoinGroupRequest>[] READ_VERSIONS = {
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
        private static readonly EncodeDelegate<JoinGroupRequest>[] WRITE_VERSIONS = {
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
        public static JoinGroupRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, JoinGroupRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static JoinGroupRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var groupIdField = Decoder.ReadString(ref buffer);
            var sessionTimeoutMsField = Decoder.ReadInt32(ref buffer);
            var rebalanceTimeoutMsField = default(int);
            var memberIdField = Decoder.ReadString(ref buffer);
            var groupInstanceIdField = default(string?);
            var protocolTypeField = Decoder.ReadString(ref buffer);
            var protocolsField = Decoder.ReadArray<JoinGroupRequestProtocol>(ref buffer, (ref ReadOnlyMemory<byte> b) => JoinGroupRequestProtocolSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Protocols'");
            var reasonField = default(string?);
            return new(
                groupIdField,
                sessionTimeoutMsField,
                rebalanceTimeoutMsField,
                memberIdField,
                groupInstanceIdField,
                protocolTypeField,
                protocolsField,
                reasonField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, JoinGroupRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.GroupIdField);
            buffer = Encoder.WriteInt32(buffer, message.SessionTimeoutMsField);
            buffer = Encoder.WriteString(buffer, message.MemberIdField);
            buffer = Encoder.WriteString(buffer, message.ProtocolTypeField);
            buffer = Encoder.WriteArray<JoinGroupRequestProtocol>(buffer, message.ProtocolsField, (b, i) => JoinGroupRequestProtocolSerde.WriteV00(b, i));
            return buffer;
        }
        private static JoinGroupRequest ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var groupIdField = Decoder.ReadString(ref buffer);
            var sessionTimeoutMsField = Decoder.ReadInt32(ref buffer);
            var rebalanceTimeoutMsField = Decoder.ReadInt32(ref buffer);
            var memberIdField = Decoder.ReadString(ref buffer);
            var groupInstanceIdField = default(string?);
            var protocolTypeField = Decoder.ReadString(ref buffer);
            var protocolsField = Decoder.ReadArray<JoinGroupRequestProtocol>(ref buffer, (ref ReadOnlyMemory<byte> b) => JoinGroupRequestProtocolSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Protocols'");
            var reasonField = default(string?);
            return new(
                groupIdField,
                sessionTimeoutMsField,
                rebalanceTimeoutMsField,
                memberIdField,
                groupInstanceIdField,
                protocolTypeField,
                protocolsField,
                reasonField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, JoinGroupRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.GroupIdField);
            buffer = Encoder.WriteInt32(buffer, message.SessionTimeoutMsField);
            buffer = Encoder.WriteInt32(buffer, message.RebalanceTimeoutMsField);
            buffer = Encoder.WriteString(buffer, message.MemberIdField);
            buffer = Encoder.WriteString(buffer, message.ProtocolTypeField);
            buffer = Encoder.WriteArray<JoinGroupRequestProtocol>(buffer, message.ProtocolsField, (b, i) => JoinGroupRequestProtocolSerde.WriteV01(b, i));
            return buffer;
        }
        private static JoinGroupRequest ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var groupIdField = Decoder.ReadString(ref buffer);
            var sessionTimeoutMsField = Decoder.ReadInt32(ref buffer);
            var rebalanceTimeoutMsField = Decoder.ReadInt32(ref buffer);
            var memberIdField = Decoder.ReadString(ref buffer);
            var groupInstanceIdField = default(string?);
            var protocolTypeField = Decoder.ReadString(ref buffer);
            var protocolsField = Decoder.ReadArray<JoinGroupRequestProtocol>(ref buffer, (ref ReadOnlyMemory<byte> b) => JoinGroupRequestProtocolSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Protocols'");
            var reasonField = default(string?);
            return new(
                groupIdField,
                sessionTimeoutMsField,
                rebalanceTimeoutMsField,
                memberIdField,
                groupInstanceIdField,
                protocolTypeField,
                protocolsField,
                reasonField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, JoinGroupRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.GroupIdField);
            buffer = Encoder.WriteInt32(buffer, message.SessionTimeoutMsField);
            buffer = Encoder.WriteInt32(buffer, message.RebalanceTimeoutMsField);
            buffer = Encoder.WriteString(buffer, message.MemberIdField);
            buffer = Encoder.WriteString(buffer, message.ProtocolTypeField);
            buffer = Encoder.WriteArray<JoinGroupRequestProtocol>(buffer, message.ProtocolsField, (b, i) => JoinGroupRequestProtocolSerde.WriteV02(b, i));
            return buffer;
        }
        private static JoinGroupRequest ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var groupIdField = Decoder.ReadString(ref buffer);
            var sessionTimeoutMsField = Decoder.ReadInt32(ref buffer);
            var rebalanceTimeoutMsField = Decoder.ReadInt32(ref buffer);
            var memberIdField = Decoder.ReadString(ref buffer);
            var groupInstanceIdField = default(string?);
            var protocolTypeField = Decoder.ReadString(ref buffer);
            var protocolsField = Decoder.ReadArray<JoinGroupRequestProtocol>(ref buffer, (ref ReadOnlyMemory<byte> b) => JoinGroupRequestProtocolSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Protocols'");
            var reasonField = default(string?);
            return new(
                groupIdField,
                sessionTimeoutMsField,
                rebalanceTimeoutMsField,
                memberIdField,
                groupInstanceIdField,
                protocolTypeField,
                protocolsField,
                reasonField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, JoinGroupRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.GroupIdField);
            buffer = Encoder.WriteInt32(buffer, message.SessionTimeoutMsField);
            buffer = Encoder.WriteInt32(buffer, message.RebalanceTimeoutMsField);
            buffer = Encoder.WriteString(buffer, message.MemberIdField);
            buffer = Encoder.WriteString(buffer, message.ProtocolTypeField);
            buffer = Encoder.WriteArray<JoinGroupRequestProtocol>(buffer, message.ProtocolsField, (b, i) => JoinGroupRequestProtocolSerde.WriteV03(b, i));
            return buffer;
        }
        private static JoinGroupRequest ReadV04(ref ReadOnlyMemory<byte> buffer)
        {
            var groupIdField = Decoder.ReadString(ref buffer);
            var sessionTimeoutMsField = Decoder.ReadInt32(ref buffer);
            var rebalanceTimeoutMsField = Decoder.ReadInt32(ref buffer);
            var memberIdField = Decoder.ReadString(ref buffer);
            var groupInstanceIdField = default(string?);
            var protocolTypeField = Decoder.ReadString(ref buffer);
            var protocolsField = Decoder.ReadArray<JoinGroupRequestProtocol>(ref buffer, (ref ReadOnlyMemory<byte> b) => JoinGroupRequestProtocolSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Protocols'");
            var reasonField = default(string?);
            return new(
                groupIdField,
                sessionTimeoutMsField,
                rebalanceTimeoutMsField,
                memberIdField,
                groupInstanceIdField,
                protocolTypeField,
                protocolsField,
                reasonField
            );
        }
        private static Memory<byte> WriteV04(Memory<byte> buffer, JoinGroupRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.GroupIdField);
            buffer = Encoder.WriteInt32(buffer, message.SessionTimeoutMsField);
            buffer = Encoder.WriteInt32(buffer, message.RebalanceTimeoutMsField);
            buffer = Encoder.WriteString(buffer, message.MemberIdField);
            buffer = Encoder.WriteString(buffer, message.ProtocolTypeField);
            buffer = Encoder.WriteArray<JoinGroupRequestProtocol>(buffer, message.ProtocolsField, (b, i) => JoinGroupRequestProtocolSerde.WriteV04(b, i));
            return buffer;
        }
        private static JoinGroupRequest ReadV05(ref ReadOnlyMemory<byte> buffer)
        {
            var groupIdField = Decoder.ReadString(ref buffer);
            var sessionTimeoutMsField = Decoder.ReadInt32(ref buffer);
            var rebalanceTimeoutMsField = Decoder.ReadInt32(ref buffer);
            var memberIdField = Decoder.ReadString(ref buffer);
            var groupInstanceIdField = Decoder.ReadNullableString(ref buffer);
            var protocolTypeField = Decoder.ReadString(ref buffer);
            var protocolsField = Decoder.ReadArray<JoinGroupRequestProtocol>(ref buffer, (ref ReadOnlyMemory<byte> b) => JoinGroupRequestProtocolSerde.ReadV05(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Protocols'");
            var reasonField = default(string?);
            return new(
                groupIdField,
                sessionTimeoutMsField,
                rebalanceTimeoutMsField,
                memberIdField,
                groupInstanceIdField,
                protocolTypeField,
                protocolsField,
                reasonField
            );
        }
        private static Memory<byte> WriteV05(Memory<byte> buffer, JoinGroupRequest message)
        {
            buffer = Encoder.WriteString(buffer, message.GroupIdField);
            buffer = Encoder.WriteInt32(buffer, message.SessionTimeoutMsField);
            buffer = Encoder.WriteInt32(buffer, message.RebalanceTimeoutMsField);
            buffer = Encoder.WriteString(buffer, message.MemberIdField);
            buffer = Encoder.WriteNullableString(buffer, message.GroupInstanceIdField);
            buffer = Encoder.WriteString(buffer, message.ProtocolTypeField);
            buffer = Encoder.WriteArray<JoinGroupRequestProtocol>(buffer, message.ProtocolsField, (b, i) => JoinGroupRequestProtocolSerde.WriteV05(b, i));
            return buffer;
        }
        private static JoinGroupRequest ReadV06(ref ReadOnlyMemory<byte> buffer)
        {
            var groupIdField = Decoder.ReadCompactString(ref buffer);
            var sessionTimeoutMsField = Decoder.ReadInt32(ref buffer);
            var rebalanceTimeoutMsField = Decoder.ReadInt32(ref buffer);
            var memberIdField = Decoder.ReadCompactString(ref buffer);
            var groupInstanceIdField = Decoder.ReadCompactNullableString(ref buffer);
            var protocolTypeField = Decoder.ReadCompactString(ref buffer);
            var protocolsField = Decoder.ReadCompactArray<JoinGroupRequestProtocol>(ref buffer, (ref ReadOnlyMemory<byte> b) => JoinGroupRequestProtocolSerde.ReadV06(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Protocols'");
            var reasonField = default(string?);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                groupIdField,
                sessionTimeoutMsField,
                rebalanceTimeoutMsField,
                memberIdField,
                groupInstanceIdField,
                protocolTypeField,
                protocolsField,
                reasonField
            );
        }
        private static Memory<byte> WriteV06(Memory<byte> buffer, JoinGroupRequest message)
        {
            buffer = Encoder.WriteCompactString(buffer, message.GroupIdField);
            buffer = Encoder.WriteInt32(buffer, message.SessionTimeoutMsField);
            buffer = Encoder.WriteInt32(buffer, message.RebalanceTimeoutMsField);
            buffer = Encoder.WriteCompactString(buffer, message.MemberIdField);
            buffer = Encoder.WriteCompactNullableString(buffer, message.GroupInstanceIdField);
            buffer = Encoder.WriteCompactString(buffer, message.ProtocolTypeField);
            buffer = Encoder.WriteCompactArray<JoinGroupRequestProtocol>(buffer, message.ProtocolsField, (b, i) => JoinGroupRequestProtocolSerde.WriteV06(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static JoinGroupRequest ReadV07(ref ReadOnlyMemory<byte> buffer)
        {
            var groupIdField = Decoder.ReadCompactString(ref buffer);
            var sessionTimeoutMsField = Decoder.ReadInt32(ref buffer);
            var rebalanceTimeoutMsField = Decoder.ReadInt32(ref buffer);
            var memberIdField = Decoder.ReadCompactString(ref buffer);
            var groupInstanceIdField = Decoder.ReadCompactNullableString(ref buffer);
            var protocolTypeField = Decoder.ReadCompactString(ref buffer);
            var protocolsField = Decoder.ReadCompactArray<JoinGroupRequestProtocol>(ref buffer, (ref ReadOnlyMemory<byte> b) => JoinGroupRequestProtocolSerde.ReadV07(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Protocols'");
            var reasonField = default(string?);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                groupIdField,
                sessionTimeoutMsField,
                rebalanceTimeoutMsField,
                memberIdField,
                groupInstanceIdField,
                protocolTypeField,
                protocolsField,
                reasonField
            );
        }
        private static Memory<byte> WriteV07(Memory<byte> buffer, JoinGroupRequest message)
        {
            buffer = Encoder.WriteCompactString(buffer, message.GroupIdField);
            buffer = Encoder.WriteInt32(buffer, message.SessionTimeoutMsField);
            buffer = Encoder.WriteInt32(buffer, message.RebalanceTimeoutMsField);
            buffer = Encoder.WriteCompactString(buffer, message.MemberIdField);
            buffer = Encoder.WriteCompactNullableString(buffer, message.GroupInstanceIdField);
            buffer = Encoder.WriteCompactString(buffer, message.ProtocolTypeField);
            buffer = Encoder.WriteCompactArray<JoinGroupRequestProtocol>(buffer, message.ProtocolsField, (b, i) => JoinGroupRequestProtocolSerde.WriteV07(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static JoinGroupRequest ReadV08(ref ReadOnlyMemory<byte> buffer)
        {
            var groupIdField = Decoder.ReadCompactString(ref buffer);
            var sessionTimeoutMsField = Decoder.ReadInt32(ref buffer);
            var rebalanceTimeoutMsField = Decoder.ReadInt32(ref buffer);
            var memberIdField = Decoder.ReadCompactString(ref buffer);
            var groupInstanceIdField = Decoder.ReadCompactNullableString(ref buffer);
            var protocolTypeField = Decoder.ReadCompactString(ref buffer);
            var protocolsField = Decoder.ReadCompactArray<JoinGroupRequestProtocol>(ref buffer, (ref ReadOnlyMemory<byte> b) => JoinGroupRequestProtocolSerde.ReadV08(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Protocols'");
            var reasonField = Decoder.ReadCompactNullableString(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                groupIdField,
                sessionTimeoutMsField,
                rebalanceTimeoutMsField,
                memberIdField,
                groupInstanceIdField,
                protocolTypeField,
                protocolsField,
                reasonField
            );
        }
        private static Memory<byte> WriteV08(Memory<byte> buffer, JoinGroupRequest message)
        {
            buffer = Encoder.WriteCompactString(buffer, message.GroupIdField);
            buffer = Encoder.WriteInt32(buffer, message.SessionTimeoutMsField);
            buffer = Encoder.WriteInt32(buffer, message.RebalanceTimeoutMsField);
            buffer = Encoder.WriteCompactString(buffer, message.MemberIdField);
            buffer = Encoder.WriteCompactNullableString(buffer, message.GroupInstanceIdField);
            buffer = Encoder.WriteCompactString(buffer, message.ProtocolTypeField);
            buffer = Encoder.WriteCompactArray<JoinGroupRequestProtocol>(buffer, message.ProtocolsField, (b, i) => JoinGroupRequestProtocolSerde.WriteV08(b, i));
            buffer = Encoder.WriteCompactNullableString(buffer, message.ReasonField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static JoinGroupRequest ReadV09(ref ReadOnlyMemory<byte> buffer)
        {
            var groupIdField = Decoder.ReadCompactString(ref buffer);
            var sessionTimeoutMsField = Decoder.ReadInt32(ref buffer);
            var rebalanceTimeoutMsField = Decoder.ReadInt32(ref buffer);
            var memberIdField = Decoder.ReadCompactString(ref buffer);
            var groupInstanceIdField = Decoder.ReadCompactNullableString(ref buffer);
            var protocolTypeField = Decoder.ReadCompactString(ref buffer);
            var protocolsField = Decoder.ReadCompactArray<JoinGroupRequestProtocol>(ref buffer, (ref ReadOnlyMemory<byte> b) => JoinGroupRequestProtocolSerde.ReadV09(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Protocols'");
            var reasonField = Decoder.ReadCompactNullableString(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                groupIdField,
                sessionTimeoutMsField,
                rebalanceTimeoutMsField,
                memberIdField,
                groupInstanceIdField,
                protocolTypeField,
                protocolsField,
                reasonField
            );
        }
        private static Memory<byte> WriteV09(Memory<byte> buffer, JoinGroupRequest message)
        {
            buffer = Encoder.WriteCompactString(buffer, message.GroupIdField);
            buffer = Encoder.WriteInt32(buffer, message.SessionTimeoutMsField);
            buffer = Encoder.WriteInt32(buffer, message.RebalanceTimeoutMsField);
            buffer = Encoder.WriteCompactString(buffer, message.MemberIdField);
            buffer = Encoder.WriteCompactNullableString(buffer, message.GroupInstanceIdField);
            buffer = Encoder.WriteCompactString(buffer, message.ProtocolTypeField);
            buffer = Encoder.WriteCompactArray<JoinGroupRequestProtocol>(buffer, message.ProtocolsField, (b, i) => JoinGroupRequestProtocolSerde.WriteV09(b, i));
            buffer = Encoder.WriteCompactNullableString(buffer, message.ReasonField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class JoinGroupRequestProtocolSerde
        {
            public static JoinGroupRequestProtocol ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var metadataField = Decoder.ReadBytes(ref buffer);
                return new(
                    nameField,
                    metadataField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, JoinGroupRequestProtocol message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteBytes(buffer, message.MetadataField);
                return buffer;
            }
            public static JoinGroupRequestProtocol ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var metadataField = Decoder.ReadBytes(ref buffer);
                return new(
                    nameField,
                    metadataField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, JoinGroupRequestProtocol message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteBytes(buffer, message.MetadataField);
                return buffer;
            }
            public static JoinGroupRequestProtocol ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var metadataField = Decoder.ReadBytes(ref buffer);
                return new(
                    nameField,
                    metadataField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, JoinGroupRequestProtocol message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteBytes(buffer, message.MetadataField);
                return buffer;
            }
            public static JoinGroupRequestProtocol ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var metadataField = Decoder.ReadBytes(ref buffer);
                return new(
                    nameField,
                    metadataField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, JoinGroupRequestProtocol message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteBytes(buffer, message.MetadataField);
                return buffer;
            }
            public static JoinGroupRequestProtocol ReadV04(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var metadataField = Decoder.ReadBytes(ref buffer);
                return new(
                    nameField,
                    metadataField
                );
            }
            public static Memory<byte> WriteV04(Memory<byte> buffer, JoinGroupRequestProtocol message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteBytes(buffer, message.MetadataField);
                return buffer;
            }
            public static JoinGroupRequestProtocol ReadV05(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadString(ref buffer);
                var metadataField = Decoder.ReadBytes(ref buffer);
                return new(
                    nameField,
                    metadataField
                );
            }
            public static Memory<byte> WriteV05(Memory<byte> buffer, JoinGroupRequestProtocol message)
            {
                buffer = Encoder.WriteString(buffer, message.NameField);
                buffer = Encoder.WriteBytes(buffer, message.MetadataField);
                return buffer;
            }
            public static JoinGroupRequestProtocol ReadV06(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactString(ref buffer);
                var metadataField = Decoder.ReadCompactBytes(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nameField,
                    metadataField
                );
            }
            public static Memory<byte> WriteV06(Memory<byte> buffer, JoinGroupRequestProtocol message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteCompactBytes(buffer, message.MetadataField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static JoinGroupRequestProtocol ReadV07(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactString(ref buffer);
                var metadataField = Decoder.ReadCompactBytes(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nameField,
                    metadataField
                );
            }
            public static Memory<byte> WriteV07(Memory<byte> buffer, JoinGroupRequestProtocol message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteCompactBytes(buffer, message.MetadataField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static JoinGroupRequestProtocol ReadV08(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactString(ref buffer);
                var metadataField = Decoder.ReadCompactBytes(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nameField,
                    metadataField
                );
            }
            public static Memory<byte> WriteV08(Memory<byte> buffer, JoinGroupRequestProtocol message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteCompactBytes(buffer, message.MetadataField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            public static JoinGroupRequestProtocol ReadV09(ref ReadOnlyMemory<byte> buffer)
            {
                var nameField = Decoder.ReadCompactString(ref buffer);
                var metadataField = Decoder.ReadCompactBytes(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    nameField,
                    metadataField
                );
            }
            public static Memory<byte> WriteV09(Memory<byte> buffer, JoinGroupRequestProtocol message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.NameField);
                buffer = Encoder.WriteCompactBytes(buffer, message.MetadataField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
    }
}