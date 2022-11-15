using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using JoinGroupRequestProtocol = Kafka.Client.Messages.JoinGroupRequest.JoinGroupRequestProtocol;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class JoinGroupRequestSerde
    {
        private static readonly Func<Stream, JoinGroupRequest>[] READ_VERSIONS = {
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
        private static readonly Action<Stream, JoinGroupRequest>[] WRITE_VERSIONS = {
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
        public static JoinGroupRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, JoinGroupRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static JoinGroupRequest ReadV00(Stream buffer)
        {
            var groupIdField = Decoder.ReadString(buffer);
            var sessionTimeoutMsField = Decoder.ReadInt32(buffer);
            var rebalanceTimeoutMsField = default(int);
            var memberIdField = Decoder.ReadString(buffer);
            var groupInstanceIdField = default(string?);
            var protocolTypeField = Decoder.ReadString(buffer);
            var protocolsField = Decoder.ReadArray<JoinGroupRequestProtocol>(buffer, b => JoinGroupRequestProtocolSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Protocols'");
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
        private static void WriteV00(Stream buffer, JoinGroupRequest message)
        {
            Encoder.WriteString(buffer, message.GroupIdField);
            Encoder.WriteInt32(buffer, message.SessionTimeoutMsField);
            Encoder.WriteString(buffer, message.MemberIdField);
            Encoder.WriteString(buffer, message.ProtocolTypeField);
            Encoder.WriteArray<JoinGroupRequestProtocol>(buffer, message.ProtocolsField, (b, i) => JoinGroupRequestProtocolSerde.WriteV00(b, i));
        }
        private static JoinGroupRequest ReadV01(Stream buffer)
        {
            var groupIdField = Decoder.ReadString(buffer);
            var sessionTimeoutMsField = Decoder.ReadInt32(buffer);
            var rebalanceTimeoutMsField = Decoder.ReadInt32(buffer);
            var memberIdField = Decoder.ReadString(buffer);
            var groupInstanceIdField = default(string?);
            var protocolTypeField = Decoder.ReadString(buffer);
            var protocolsField = Decoder.ReadArray<JoinGroupRequestProtocol>(buffer, b => JoinGroupRequestProtocolSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Protocols'");
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
        private static void WriteV01(Stream buffer, JoinGroupRequest message)
        {
            Encoder.WriteString(buffer, message.GroupIdField);
            Encoder.WriteInt32(buffer, message.SessionTimeoutMsField);
            Encoder.WriteInt32(buffer, message.RebalanceTimeoutMsField);
            Encoder.WriteString(buffer, message.MemberIdField);
            Encoder.WriteString(buffer, message.ProtocolTypeField);
            Encoder.WriteArray<JoinGroupRequestProtocol>(buffer, message.ProtocolsField, (b, i) => JoinGroupRequestProtocolSerde.WriteV01(b, i));
        }
        private static JoinGroupRequest ReadV02(Stream buffer)
        {
            var groupIdField = Decoder.ReadString(buffer);
            var sessionTimeoutMsField = Decoder.ReadInt32(buffer);
            var rebalanceTimeoutMsField = Decoder.ReadInt32(buffer);
            var memberIdField = Decoder.ReadString(buffer);
            var groupInstanceIdField = default(string?);
            var protocolTypeField = Decoder.ReadString(buffer);
            var protocolsField = Decoder.ReadArray<JoinGroupRequestProtocol>(buffer, b => JoinGroupRequestProtocolSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Protocols'");
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
        private static void WriteV02(Stream buffer, JoinGroupRequest message)
        {
            Encoder.WriteString(buffer, message.GroupIdField);
            Encoder.WriteInt32(buffer, message.SessionTimeoutMsField);
            Encoder.WriteInt32(buffer, message.RebalanceTimeoutMsField);
            Encoder.WriteString(buffer, message.MemberIdField);
            Encoder.WriteString(buffer, message.ProtocolTypeField);
            Encoder.WriteArray<JoinGroupRequestProtocol>(buffer, message.ProtocolsField, (b, i) => JoinGroupRequestProtocolSerde.WriteV02(b, i));
        }
        private static JoinGroupRequest ReadV03(Stream buffer)
        {
            var groupIdField = Decoder.ReadString(buffer);
            var sessionTimeoutMsField = Decoder.ReadInt32(buffer);
            var rebalanceTimeoutMsField = Decoder.ReadInt32(buffer);
            var memberIdField = Decoder.ReadString(buffer);
            var groupInstanceIdField = default(string?);
            var protocolTypeField = Decoder.ReadString(buffer);
            var protocolsField = Decoder.ReadArray<JoinGroupRequestProtocol>(buffer, b => JoinGroupRequestProtocolSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Protocols'");
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
        private static void WriteV03(Stream buffer, JoinGroupRequest message)
        {
            Encoder.WriteString(buffer, message.GroupIdField);
            Encoder.WriteInt32(buffer, message.SessionTimeoutMsField);
            Encoder.WriteInt32(buffer, message.RebalanceTimeoutMsField);
            Encoder.WriteString(buffer, message.MemberIdField);
            Encoder.WriteString(buffer, message.ProtocolTypeField);
            Encoder.WriteArray<JoinGroupRequestProtocol>(buffer, message.ProtocolsField, (b, i) => JoinGroupRequestProtocolSerde.WriteV03(b, i));
        }
        private static JoinGroupRequest ReadV04(Stream buffer)
        {
            var groupIdField = Decoder.ReadString(buffer);
            var sessionTimeoutMsField = Decoder.ReadInt32(buffer);
            var rebalanceTimeoutMsField = Decoder.ReadInt32(buffer);
            var memberIdField = Decoder.ReadString(buffer);
            var groupInstanceIdField = default(string?);
            var protocolTypeField = Decoder.ReadString(buffer);
            var protocolsField = Decoder.ReadArray<JoinGroupRequestProtocol>(buffer, b => JoinGroupRequestProtocolSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'Protocols'");
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
        private static void WriteV04(Stream buffer, JoinGroupRequest message)
        {
            Encoder.WriteString(buffer, message.GroupIdField);
            Encoder.WriteInt32(buffer, message.SessionTimeoutMsField);
            Encoder.WriteInt32(buffer, message.RebalanceTimeoutMsField);
            Encoder.WriteString(buffer, message.MemberIdField);
            Encoder.WriteString(buffer, message.ProtocolTypeField);
            Encoder.WriteArray<JoinGroupRequestProtocol>(buffer, message.ProtocolsField, (b, i) => JoinGroupRequestProtocolSerde.WriteV04(b, i));
        }
        private static JoinGroupRequest ReadV05(Stream buffer)
        {
            var groupIdField = Decoder.ReadString(buffer);
            var sessionTimeoutMsField = Decoder.ReadInt32(buffer);
            var rebalanceTimeoutMsField = Decoder.ReadInt32(buffer);
            var memberIdField = Decoder.ReadString(buffer);
            var groupInstanceIdField = Decoder.ReadNullableString(buffer);
            var protocolTypeField = Decoder.ReadString(buffer);
            var protocolsField = Decoder.ReadArray<JoinGroupRequestProtocol>(buffer, b => JoinGroupRequestProtocolSerde.ReadV05(b)) ?? throw new NullReferenceException("Null not allowed for 'Protocols'");
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
        private static void WriteV05(Stream buffer, JoinGroupRequest message)
        {
            Encoder.WriteString(buffer, message.GroupIdField);
            Encoder.WriteInt32(buffer, message.SessionTimeoutMsField);
            Encoder.WriteInt32(buffer, message.RebalanceTimeoutMsField);
            Encoder.WriteString(buffer, message.MemberIdField);
            Encoder.WriteNullableString(buffer, message.GroupInstanceIdField);
            Encoder.WriteString(buffer, message.ProtocolTypeField);
            Encoder.WriteArray<JoinGroupRequestProtocol>(buffer, message.ProtocolsField, (b, i) => JoinGroupRequestProtocolSerde.WriteV05(b, i));
        }
        private static JoinGroupRequest ReadV06(Stream buffer)
        {
            var groupIdField = Decoder.ReadCompactString(buffer);
            var sessionTimeoutMsField = Decoder.ReadInt32(buffer);
            var rebalanceTimeoutMsField = Decoder.ReadInt32(buffer);
            var memberIdField = Decoder.ReadCompactString(buffer);
            var groupInstanceIdField = Decoder.ReadCompactNullableString(buffer);
            var protocolTypeField = Decoder.ReadCompactString(buffer);
            var protocolsField = Decoder.ReadCompactArray<JoinGroupRequestProtocol>(buffer, b => JoinGroupRequestProtocolSerde.ReadV06(b)) ?? throw new NullReferenceException("Null not allowed for 'Protocols'");
            var reasonField = default(string?);
            _ = Decoder.ReadVarUInt32(buffer);
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
        private static void WriteV06(Stream buffer, JoinGroupRequest message)
        {
            Encoder.WriteCompactString(buffer, message.GroupIdField);
            Encoder.WriteInt32(buffer, message.SessionTimeoutMsField);
            Encoder.WriteInt32(buffer, message.RebalanceTimeoutMsField);
            Encoder.WriteCompactString(buffer, message.MemberIdField);
            Encoder.WriteCompactNullableString(buffer, message.GroupInstanceIdField);
            Encoder.WriteCompactString(buffer, message.ProtocolTypeField);
            Encoder.WriteCompactArray<JoinGroupRequestProtocol>(buffer, message.ProtocolsField, (b, i) => JoinGroupRequestProtocolSerde.WriteV06(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static JoinGroupRequest ReadV07(Stream buffer)
        {
            var groupIdField = Decoder.ReadCompactString(buffer);
            var sessionTimeoutMsField = Decoder.ReadInt32(buffer);
            var rebalanceTimeoutMsField = Decoder.ReadInt32(buffer);
            var memberIdField = Decoder.ReadCompactString(buffer);
            var groupInstanceIdField = Decoder.ReadCompactNullableString(buffer);
            var protocolTypeField = Decoder.ReadCompactString(buffer);
            var protocolsField = Decoder.ReadCompactArray<JoinGroupRequestProtocol>(buffer, b => JoinGroupRequestProtocolSerde.ReadV07(b)) ?? throw new NullReferenceException("Null not allowed for 'Protocols'");
            var reasonField = default(string?);
            _ = Decoder.ReadVarUInt32(buffer);
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
        private static void WriteV07(Stream buffer, JoinGroupRequest message)
        {
            Encoder.WriteCompactString(buffer, message.GroupIdField);
            Encoder.WriteInt32(buffer, message.SessionTimeoutMsField);
            Encoder.WriteInt32(buffer, message.RebalanceTimeoutMsField);
            Encoder.WriteCompactString(buffer, message.MemberIdField);
            Encoder.WriteCompactNullableString(buffer, message.GroupInstanceIdField);
            Encoder.WriteCompactString(buffer, message.ProtocolTypeField);
            Encoder.WriteCompactArray<JoinGroupRequestProtocol>(buffer, message.ProtocolsField, (b, i) => JoinGroupRequestProtocolSerde.WriteV07(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static JoinGroupRequest ReadV08(Stream buffer)
        {
            var groupIdField = Decoder.ReadCompactString(buffer);
            var sessionTimeoutMsField = Decoder.ReadInt32(buffer);
            var rebalanceTimeoutMsField = Decoder.ReadInt32(buffer);
            var memberIdField = Decoder.ReadCompactString(buffer);
            var groupInstanceIdField = Decoder.ReadCompactNullableString(buffer);
            var protocolTypeField = Decoder.ReadCompactString(buffer);
            var protocolsField = Decoder.ReadCompactArray<JoinGroupRequestProtocol>(buffer, b => JoinGroupRequestProtocolSerde.ReadV08(b)) ?? throw new NullReferenceException("Null not allowed for 'Protocols'");
            var reasonField = Decoder.ReadCompactNullableString(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
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
        private static void WriteV08(Stream buffer, JoinGroupRequest message)
        {
            Encoder.WriteCompactString(buffer, message.GroupIdField);
            Encoder.WriteInt32(buffer, message.SessionTimeoutMsField);
            Encoder.WriteInt32(buffer, message.RebalanceTimeoutMsField);
            Encoder.WriteCompactString(buffer, message.MemberIdField);
            Encoder.WriteCompactNullableString(buffer, message.GroupInstanceIdField);
            Encoder.WriteCompactString(buffer, message.ProtocolTypeField);
            Encoder.WriteCompactArray<JoinGroupRequestProtocol>(buffer, message.ProtocolsField, (b, i) => JoinGroupRequestProtocolSerde.WriteV08(b, i));
            Encoder.WriteCompactNullableString(buffer, message.ReasonField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static JoinGroupRequest ReadV09(Stream buffer)
        {
            var groupIdField = Decoder.ReadCompactString(buffer);
            var sessionTimeoutMsField = Decoder.ReadInt32(buffer);
            var rebalanceTimeoutMsField = Decoder.ReadInt32(buffer);
            var memberIdField = Decoder.ReadCompactString(buffer);
            var groupInstanceIdField = Decoder.ReadCompactNullableString(buffer);
            var protocolTypeField = Decoder.ReadCompactString(buffer);
            var protocolsField = Decoder.ReadCompactArray<JoinGroupRequestProtocol>(buffer, b => JoinGroupRequestProtocolSerde.ReadV09(b)) ?? throw new NullReferenceException("Null not allowed for 'Protocols'");
            var reasonField = Decoder.ReadCompactNullableString(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
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
        private static void WriteV09(Stream buffer, JoinGroupRequest message)
        {
            Encoder.WriteCompactString(buffer, message.GroupIdField);
            Encoder.WriteInt32(buffer, message.SessionTimeoutMsField);
            Encoder.WriteInt32(buffer, message.RebalanceTimeoutMsField);
            Encoder.WriteCompactString(buffer, message.MemberIdField);
            Encoder.WriteCompactNullableString(buffer, message.GroupInstanceIdField);
            Encoder.WriteCompactString(buffer, message.ProtocolTypeField);
            Encoder.WriteCompactArray<JoinGroupRequestProtocol>(buffer, message.ProtocolsField, (b, i) => JoinGroupRequestProtocolSerde.WriteV09(b, i));
            Encoder.WriteCompactNullableString(buffer, message.ReasonField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class JoinGroupRequestProtocolSerde
        {
            public static JoinGroupRequestProtocol ReadV00(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var metadataField = Decoder.ReadBytes(buffer);
                return new(
                    nameField,
                    metadataField
                );
            }
            public static void WriteV00(Stream buffer, JoinGroupRequestProtocol message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteBytes(buffer, message.MetadataField);
            }
            public static JoinGroupRequestProtocol ReadV01(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var metadataField = Decoder.ReadBytes(buffer);
                return new(
                    nameField,
                    metadataField
                );
            }
            public static void WriteV01(Stream buffer, JoinGroupRequestProtocol message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteBytes(buffer, message.MetadataField);
            }
            public static JoinGroupRequestProtocol ReadV02(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var metadataField = Decoder.ReadBytes(buffer);
                return new(
                    nameField,
                    metadataField
                );
            }
            public static void WriteV02(Stream buffer, JoinGroupRequestProtocol message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteBytes(buffer, message.MetadataField);
            }
            public static JoinGroupRequestProtocol ReadV03(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var metadataField = Decoder.ReadBytes(buffer);
                return new(
                    nameField,
                    metadataField
                );
            }
            public static void WriteV03(Stream buffer, JoinGroupRequestProtocol message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteBytes(buffer, message.MetadataField);
            }
            public static JoinGroupRequestProtocol ReadV04(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var metadataField = Decoder.ReadBytes(buffer);
                return new(
                    nameField,
                    metadataField
                );
            }
            public static void WriteV04(Stream buffer, JoinGroupRequestProtocol message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteBytes(buffer, message.MetadataField);
            }
            public static JoinGroupRequestProtocol ReadV05(Stream buffer)
            {
                var nameField = Decoder.ReadString(buffer);
                var metadataField = Decoder.ReadBytes(buffer);
                return new(
                    nameField,
                    metadataField
                );
            }
            public static void WriteV05(Stream buffer, JoinGroupRequestProtocol message)
            {
                Encoder.WriteString(buffer, message.NameField);
                Encoder.WriteBytes(buffer, message.MetadataField);
            }
            public static JoinGroupRequestProtocol ReadV06(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var metadataField = Decoder.ReadCompactBytes(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    metadataField
                );
            }
            public static void WriteV06(Stream buffer, JoinGroupRequestProtocol message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteCompactBytes(buffer, message.MetadataField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static JoinGroupRequestProtocol ReadV07(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var metadataField = Decoder.ReadCompactBytes(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    metadataField
                );
            }
            public static void WriteV07(Stream buffer, JoinGroupRequestProtocol message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteCompactBytes(buffer, message.MetadataField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static JoinGroupRequestProtocol ReadV08(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var metadataField = Decoder.ReadCompactBytes(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    metadataField
                );
            }
            public static void WriteV08(Stream buffer, JoinGroupRequestProtocol message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteCompactBytes(buffer, message.MetadataField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
            public static JoinGroupRequestProtocol ReadV09(Stream buffer)
            {
                var nameField = Decoder.ReadCompactString(buffer);
                var metadataField = Decoder.ReadCompactBytes(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    nameField,
                    metadataField
                );
            }
            public static void WriteV09(Stream buffer, JoinGroupRequestProtocol message)
            {
                Encoder.WriteCompactString(buffer, message.NameField);
                Encoder.WriteCompactBytes(buffer, message.MetadataField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
    }
}