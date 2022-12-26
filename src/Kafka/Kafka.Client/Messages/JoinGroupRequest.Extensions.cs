using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using JoinGroupRequestProtocol = Kafka.Client.Messages.JoinGroupRequest.JoinGroupRequestProtocol;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class JoinGroupRequestSerde
    {
        private static readonly DecodeDelegate<JoinGroupRequest>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
            ReadV04,
            ReadV05,
            ReadV06,
            ReadV07,
            ReadV08,
            ReadV09,
        };
        private static readonly EncodeDelegate<JoinGroupRequest>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
            WriteV04,
            WriteV05,
            WriteV06,
            WriteV07,
            WriteV08,
            WriteV09,
        };
        public static JoinGroupRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, JoinGroupRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static JoinGroupRequest ReadV00(byte[] buffer, ref int index)
        {
            var groupIdField = Decoder.ReadString(buffer, ref index);
            var sessionTimeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var rebalanceTimeoutMsField = default(int);
            var memberIdField = Decoder.ReadString(buffer, ref index);
            var groupInstanceIdField = default(string?);
            var protocolTypeField = Decoder.ReadString(buffer, ref index);
            var protocolsField = Decoder.ReadArray<JoinGroupRequestProtocol>(buffer, ref index, JoinGroupRequestProtocolSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Protocols'");
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
        private static int WriteV00(byte[] buffer, int index, JoinGroupRequest message)
        {
            index = Encoder.WriteString(buffer, index, message.GroupIdField);
            index = Encoder.WriteInt32(buffer, index, message.SessionTimeoutMsField);
            index = Encoder.WriteString(buffer, index, message.MemberIdField);
            index = Encoder.WriteString(buffer, index, message.ProtocolTypeField);
            index = Encoder.WriteArray<JoinGroupRequestProtocol>(buffer, index, message.ProtocolsField, JoinGroupRequestProtocolSerde.WriteV00);
            return index;
        }
        private static JoinGroupRequest ReadV01(byte[] buffer, ref int index)
        {
            var groupIdField = Decoder.ReadString(buffer, ref index);
            var sessionTimeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var rebalanceTimeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var memberIdField = Decoder.ReadString(buffer, ref index);
            var groupInstanceIdField = default(string?);
            var protocolTypeField = Decoder.ReadString(buffer, ref index);
            var protocolsField = Decoder.ReadArray<JoinGroupRequestProtocol>(buffer, ref index, JoinGroupRequestProtocolSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Protocols'");
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
        private static int WriteV01(byte[] buffer, int index, JoinGroupRequest message)
        {
            index = Encoder.WriteString(buffer, index, message.GroupIdField);
            index = Encoder.WriteInt32(buffer, index, message.SessionTimeoutMsField);
            index = Encoder.WriteInt32(buffer, index, message.RebalanceTimeoutMsField);
            index = Encoder.WriteString(buffer, index, message.MemberIdField);
            index = Encoder.WriteString(buffer, index, message.ProtocolTypeField);
            index = Encoder.WriteArray<JoinGroupRequestProtocol>(buffer, index, message.ProtocolsField, JoinGroupRequestProtocolSerde.WriteV01);
            return index;
        }
        private static JoinGroupRequest ReadV02(byte[] buffer, ref int index)
        {
            var groupIdField = Decoder.ReadString(buffer, ref index);
            var sessionTimeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var rebalanceTimeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var memberIdField = Decoder.ReadString(buffer, ref index);
            var groupInstanceIdField = default(string?);
            var protocolTypeField = Decoder.ReadString(buffer, ref index);
            var protocolsField = Decoder.ReadArray<JoinGroupRequestProtocol>(buffer, ref index, JoinGroupRequestProtocolSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Protocols'");
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
        private static int WriteV02(byte[] buffer, int index, JoinGroupRequest message)
        {
            index = Encoder.WriteString(buffer, index, message.GroupIdField);
            index = Encoder.WriteInt32(buffer, index, message.SessionTimeoutMsField);
            index = Encoder.WriteInt32(buffer, index, message.RebalanceTimeoutMsField);
            index = Encoder.WriteString(buffer, index, message.MemberIdField);
            index = Encoder.WriteString(buffer, index, message.ProtocolTypeField);
            index = Encoder.WriteArray<JoinGroupRequestProtocol>(buffer, index, message.ProtocolsField, JoinGroupRequestProtocolSerde.WriteV02);
            return index;
        }
        private static JoinGroupRequest ReadV03(byte[] buffer, ref int index)
        {
            var groupIdField = Decoder.ReadString(buffer, ref index);
            var sessionTimeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var rebalanceTimeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var memberIdField = Decoder.ReadString(buffer, ref index);
            var groupInstanceIdField = default(string?);
            var protocolTypeField = Decoder.ReadString(buffer, ref index);
            var protocolsField = Decoder.ReadArray<JoinGroupRequestProtocol>(buffer, ref index, JoinGroupRequestProtocolSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Protocols'");
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
        private static int WriteV03(byte[] buffer, int index, JoinGroupRequest message)
        {
            index = Encoder.WriteString(buffer, index, message.GroupIdField);
            index = Encoder.WriteInt32(buffer, index, message.SessionTimeoutMsField);
            index = Encoder.WriteInt32(buffer, index, message.RebalanceTimeoutMsField);
            index = Encoder.WriteString(buffer, index, message.MemberIdField);
            index = Encoder.WriteString(buffer, index, message.ProtocolTypeField);
            index = Encoder.WriteArray<JoinGroupRequestProtocol>(buffer, index, message.ProtocolsField, JoinGroupRequestProtocolSerde.WriteV03);
            return index;
        }
        private static JoinGroupRequest ReadV04(byte[] buffer, ref int index)
        {
            var groupIdField = Decoder.ReadString(buffer, ref index);
            var sessionTimeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var rebalanceTimeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var memberIdField = Decoder.ReadString(buffer, ref index);
            var groupInstanceIdField = default(string?);
            var protocolTypeField = Decoder.ReadString(buffer, ref index);
            var protocolsField = Decoder.ReadArray<JoinGroupRequestProtocol>(buffer, ref index, JoinGroupRequestProtocolSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'Protocols'");
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
        private static int WriteV04(byte[] buffer, int index, JoinGroupRequest message)
        {
            index = Encoder.WriteString(buffer, index, message.GroupIdField);
            index = Encoder.WriteInt32(buffer, index, message.SessionTimeoutMsField);
            index = Encoder.WriteInt32(buffer, index, message.RebalanceTimeoutMsField);
            index = Encoder.WriteString(buffer, index, message.MemberIdField);
            index = Encoder.WriteString(buffer, index, message.ProtocolTypeField);
            index = Encoder.WriteArray<JoinGroupRequestProtocol>(buffer, index, message.ProtocolsField, JoinGroupRequestProtocolSerde.WriteV04);
            return index;
        }
        private static JoinGroupRequest ReadV05(byte[] buffer, ref int index)
        {
            var groupIdField = Decoder.ReadString(buffer, ref index);
            var sessionTimeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var rebalanceTimeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var memberIdField = Decoder.ReadString(buffer, ref index);
            var groupInstanceIdField = Decoder.ReadNullableString(buffer, ref index);
            var protocolTypeField = Decoder.ReadString(buffer, ref index);
            var protocolsField = Decoder.ReadArray<JoinGroupRequestProtocol>(buffer, ref index, JoinGroupRequestProtocolSerde.ReadV05) ?? throw new NullReferenceException("Null not allowed for 'Protocols'");
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
        private static int WriteV05(byte[] buffer, int index, JoinGroupRequest message)
        {
            index = Encoder.WriteString(buffer, index, message.GroupIdField);
            index = Encoder.WriteInt32(buffer, index, message.SessionTimeoutMsField);
            index = Encoder.WriteInt32(buffer, index, message.RebalanceTimeoutMsField);
            index = Encoder.WriteString(buffer, index, message.MemberIdField);
            index = Encoder.WriteNullableString(buffer, index, message.GroupInstanceIdField);
            index = Encoder.WriteString(buffer, index, message.ProtocolTypeField);
            index = Encoder.WriteArray<JoinGroupRequestProtocol>(buffer, index, message.ProtocolsField, JoinGroupRequestProtocolSerde.WriteV05);
            return index;
        }
        private static JoinGroupRequest ReadV06(byte[] buffer, ref int index)
        {
            var groupIdField = Decoder.ReadCompactString(buffer, ref index);
            var sessionTimeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var rebalanceTimeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var memberIdField = Decoder.ReadCompactString(buffer, ref index);
            var groupInstanceIdField = Decoder.ReadCompactNullableString(buffer, ref index);
            var protocolTypeField = Decoder.ReadCompactString(buffer, ref index);
            var protocolsField = Decoder.ReadCompactArray<JoinGroupRequestProtocol>(buffer, ref index, JoinGroupRequestProtocolSerde.ReadV06) ?? throw new NullReferenceException("Null not allowed for 'Protocols'");
            var reasonField = default(string?);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
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
        private static int WriteV06(byte[] buffer, int index, JoinGroupRequest message)
        {
            index = Encoder.WriteCompactString(buffer, index, message.GroupIdField);
            index = Encoder.WriteInt32(buffer, index, message.SessionTimeoutMsField);
            index = Encoder.WriteInt32(buffer, index, message.RebalanceTimeoutMsField);
            index = Encoder.WriteCompactString(buffer, index, message.MemberIdField);
            index = Encoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
            index = Encoder.WriteCompactString(buffer, index, message.ProtocolTypeField);
            index = Encoder.WriteCompactArray<JoinGroupRequestProtocol>(buffer, index, message.ProtocolsField, JoinGroupRequestProtocolSerde.WriteV06);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static JoinGroupRequest ReadV07(byte[] buffer, ref int index)
        {
            var groupIdField = Decoder.ReadCompactString(buffer, ref index);
            var sessionTimeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var rebalanceTimeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var memberIdField = Decoder.ReadCompactString(buffer, ref index);
            var groupInstanceIdField = Decoder.ReadCompactNullableString(buffer, ref index);
            var protocolTypeField = Decoder.ReadCompactString(buffer, ref index);
            var protocolsField = Decoder.ReadCompactArray<JoinGroupRequestProtocol>(buffer, ref index, JoinGroupRequestProtocolSerde.ReadV07) ?? throw new NullReferenceException("Null not allowed for 'Protocols'");
            var reasonField = default(string?);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
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
        private static int WriteV07(byte[] buffer, int index, JoinGroupRequest message)
        {
            index = Encoder.WriteCompactString(buffer, index, message.GroupIdField);
            index = Encoder.WriteInt32(buffer, index, message.SessionTimeoutMsField);
            index = Encoder.WriteInt32(buffer, index, message.RebalanceTimeoutMsField);
            index = Encoder.WriteCompactString(buffer, index, message.MemberIdField);
            index = Encoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
            index = Encoder.WriteCompactString(buffer, index, message.ProtocolTypeField);
            index = Encoder.WriteCompactArray<JoinGroupRequestProtocol>(buffer, index, message.ProtocolsField, JoinGroupRequestProtocolSerde.WriteV07);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static JoinGroupRequest ReadV08(byte[] buffer, ref int index)
        {
            var groupIdField = Decoder.ReadCompactString(buffer, ref index);
            var sessionTimeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var rebalanceTimeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var memberIdField = Decoder.ReadCompactString(buffer, ref index);
            var groupInstanceIdField = Decoder.ReadCompactNullableString(buffer, ref index);
            var protocolTypeField = Decoder.ReadCompactString(buffer, ref index);
            var protocolsField = Decoder.ReadCompactArray<JoinGroupRequestProtocol>(buffer, ref index, JoinGroupRequestProtocolSerde.ReadV08) ?? throw new NullReferenceException("Null not allowed for 'Protocols'");
            var reasonField = Decoder.ReadCompactNullableString(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
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
        private static int WriteV08(byte[] buffer, int index, JoinGroupRequest message)
        {
            index = Encoder.WriteCompactString(buffer, index, message.GroupIdField);
            index = Encoder.WriteInt32(buffer, index, message.SessionTimeoutMsField);
            index = Encoder.WriteInt32(buffer, index, message.RebalanceTimeoutMsField);
            index = Encoder.WriteCompactString(buffer, index, message.MemberIdField);
            index = Encoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
            index = Encoder.WriteCompactString(buffer, index, message.ProtocolTypeField);
            index = Encoder.WriteCompactArray<JoinGroupRequestProtocol>(buffer, index, message.ProtocolsField, JoinGroupRequestProtocolSerde.WriteV08);
            index = Encoder.WriteCompactNullableString(buffer, index, message.ReasonField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static JoinGroupRequest ReadV09(byte[] buffer, ref int index)
        {
            var groupIdField = Decoder.ReadCompactString(buffer, ref index);
            var sessionTimeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var rebalanceTimeoutMsField = Decoder.ReadInt32(buffer, ref index);
            var memberIdField = Decoder.ReadCompactString(buffer, ref index);
            var groupInstanceIdField = Decoder.ReadCompactNullableString(buffer, ref index);
            var protocolTypeField = Decoder.ReadCompactString(buffer, ref index);
            var protocolsField = Decoder.ReadCompactArray<JoinGroupRequestProtocol>(buffer, ref index, JoinGroupRequestProtocolSerde.ReadV09) ?? throw new NullReferenceException("Null not allowed for 'Protocols'");
            var reasonField = Decoder.ReadCompactNullableString(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
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
        private static int WriteV09(byte[] buffer, int index, JoinGroupRequest message)
        {
            index = Encoder.WriteCompactString(buffer, index, message.GroupIdField);
            index = Encoder.WriteInt32(buffer, index, message.SessionTimeoutMsField);
            index = Encoder.WriteInt32(buffer, index, message.RebalanceTimeoutMsField);
            index = Encoder.WriteCompactString(buffer, index, message.MemberIdField);
            index = Encoder.WriteCompactNullableString(buffer, index, message.GroupInstanceIdField);
            index = Encoder.WriteCompactString(buffer, index, message.ProtocolTypeField);
            index = Encoder.WriteCompactArray<JoinGroupRequestProtocol>(buffer, index, message.ProtocolsField, JoinGroupRequestProtocolSerde.WriteV09);
            index = Encoder.WriteCompactNullableString(buffer, index, message.ReasonField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class JoinGroupRequestProtocolSerde
        {
            public static JoinGroupRequestProtocol ReadV00(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var MetadataField = Decoder.ReadBytes(buffer, ref index);
                return new(
                    NameField,
                    MetadataField
                );
            }
            public static int WriteV00(byte[] buffer, int index, JoinGroupRequestProtocol message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteBytes(buffer, index, message.MetadataField);
                return index;
            }
            public static JoinGroupRequestProtocol ReadV01(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var MetadataField = Decoder.ReadBytes(buffer, ref index);
                return new(
                    NameField,
                    MetadataField
                );
            }
            public static int WriteV01(byte[] buffer, int index, JoinGroupRequestProtocol message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteBytes(buffer, index, message.MetadataField);
                return index;
            }
            public static JoinGroupRequestProtocol ReadV02(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var MetadataField = Decoder.ReadBytes(buffer, ref index);
                return new(
                    NameField,
                    MetadataField
                );
            }
            public static int WriteV02(byte[] buffer, int index, JoinGroupRequestProtocol message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteBytes(buffer, index, message.MetadataField);
                return index;
            }
            public static JoinGroupRequestProtocol ReadV03(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var MetadataField = Decoder.ReadBytes(buffer, ref index);
                return new(
                    NameField,
                    MetadataField
                );
            }
            public static int WriteV03(byte[] buffer, int index, JoinGroupRequestProtocol message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteBytes(buffer, index, message.MetadataField);
                return index;
            }
            public static JoinGroupRequestProtocol ReadV04(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var MetadataField = Decoder.ReadBytes(buffer, ref index);
                return new(
                    NameField,
                    MetadataField
                );
            }
            public static int WriteV04(byte[] buffer, int index, JoinGroupRequestProtocol message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteBytes(buffer, index, message.MetadataField);
                return index;
            }
            public static JoinGroupRequestProtocol ReadV05(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadString(buffer, ref index);
                var MetadataField = Decoder.ReadBytes(buffer, ref index);
                return new(
                    NameField,
                    MetadataField
                );
            }
            public static int WriteV05(byte[] buffer, int index, JoinGroupRequestProtocol message)
            {
                index = Encoder.WriteString(buffer, index, message.NameField);
                index = Encoder.WriteBytes(buffer, index, message.MetadataField);
                return index;
            }
            public static JoinGroupRequestProtocol ReadV06(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadCompactString(buffer, ref index);
                var MetadataField = Decoder.ReadCompactBytes(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    NameField,
                    MetadataField
                );
            }
            public static int WriteV06(byte[] buffer, int index, JoinGroupRequestProtocol message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteCompactBytes(buffer, index, message.MetadataField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static JoinGroupRequestProtocol ReadV07(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadCompactString(buffer, ref index);
                var MetadataField = Decoder.ReadCompactBytes(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    NameField,
                    MetadataField
                );
            }
            public static int WriteV07(byte[] buffer, int index, JoinGroupRequestProtocol message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteCompactBytes(buffer, index, message.MetadataField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static JoinGroupRequestProtocol ReadV08(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadCompactString(buffer, ref index);
                var MetadataField = Decoder.ReadCompactBytes(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    NameField,
                    MetadataField
                );
            }
            public static int WriteV08(byte[] buffer, int index, JoinGroupRequestProtocol message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteCompactBytes(buffer, index, message.MetadataField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            public static JoinGroupRequestProtocol ReadV09(byte[] buffer, ref int index)
            {
                var NameField = Decoder.ReadCompactString(buffer, ref index);
                var MetadataField = Decoder.ReadCompactBytes(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    NameField,
                    MetadataField
                );
            }
            public static int WriteV09(byte[] buffer, int index, JoinGroupRequestProtocol message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.NameField);
                index = Encoder.WriteCompactBytes(buffer, index, message.MetadataField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
        }
    }
}