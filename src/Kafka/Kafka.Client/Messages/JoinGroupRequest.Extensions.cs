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
       public static (int Offset, JoinGroupRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, JoinGroupRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, JoinGroupRequest Value) ReadV00(byte[] buffer, int index)
       {
           (index, var groupIdField) = Decoder.ReadString(buffer, index);
           (index, var sessionTimeoutMsField) = Decoder.ReadInt32(buffer, index);
           var rebalanceTimeoutMsField = default(int);
           (index, var memberIdField) = Decoder.ReadString(buffer, index);
           var groupInstanceIdField = default(string?);
           (index, var protocolTypeField) = Decoder.ReadString(buffer, index);
           (index, var protocolsField) = Decoder.ReadArray<JoinGroupRequestProtocol>(buffer, index, JoinGroupRequestProtocolSerde.ReadV00);
           if (protocolsField == null)
               throw new NullReferenceException("Null not allowed for 'Protocols'");
           var reasonField = default(string?);
           return (index, new(
               groupIdField,
               sessionTimeoutMsField,
               rebalanceTimeoutMsField,
               memberIdField,
               groupInstanceIdField,
               protocolTypeField,
               protocolsField.Value,
               reasonField
           ));
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
       private static (int Offset, JoinGroupRequest Value) ReadV01(byte[] buffer, int index)
       {
           (index, var groupIdField) = Decoder.ReadString(buffer, index);
           (index, var sessionTimeoutMsField) = Decoder.ReadInt32(buffer, index);
           (index, var rebalanceTimeoutMsField) = Decoder.ReadInt32(buffer, index);
           (index, var memberIdField) = Decoder.ReadString(buffer, index);
           var groupInstanceIdField = default(string?);
           (index, var protocolTypeField) = Decoder.ReadString(buffer, index);
           (index, var protocolsField) = Decoder.ReadArray<JoinGroupRequestProtocol>(buffer, index, JoinGroupRequestProtocolSerde.ReadV01);
           if (protocolsField == null)
               throw new NullReferenceException("Null not allowed for 'Protocols'");
           var reasonField = default(string?);
           return (index, new(
               groupIdField,
               sessionTimeoutMsField,
               rebalanceTimeoutMsField,
               memberIdField,
               groupInstanceIdField,
               protocolTypeField,
               protocolsField.Value,
               reasonField
           ));
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
       private static (int Offset, JoinGroupRequest Value) ReadV02(byte[] buffer, int index)
       {
           (index, var groupIdField) = Decoder.ReadString(buffer, index);
           (index, var sessionTimeoutMsField) = Decoder.ReadInt32(buffer, index);
           (index, var rebalanceTimeoutMsField) = Decoder.ReadInt32(buffer, index);
           (index, var memberIdField) = Decoder.ReadString(buffer, index);
           var groupInstanceIdField = default(string?);
           (index, var protocolTypeField) = Decoder.ReadString(buffer, index);
           (index, var protocolsField) = Decoder.ReadArray<JoinGroupRequestProtocol>(buffer, index, JoinGroupRequestProtocolSerde.ReadV02);
           if (protocolsField == null)
               throw new NullReferenceException("Null not allowed for 'Protocols'");
           var reasonField = default(string?);
           return (index, new(
               groupIdField,
               sessionTimeoutMsField,
               rebalanceTimeoutMsField,
               memberIdField,
               groupInstanceIdField,
               protocolTypeField,
               protocolsField.Value,
               reasonField
           ));
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
       private static (int Offset, JoinGroupRequest Value) ReadV03(byte[] buffer, int index)
       {
           (index, var groupIdField) = Decoder.ReadString(buffer, index);
           (index, var sessionTimeoutMsField) = Decoder.ReadInt32(buffer, index);
           (index, var rebalanceTimeoutMsField) = Decoder.ReadInt32(buffer, index);
           (index, var memberIdField) = Decoder.ReadString(buffer, index);
           var groupInstanceIdField = default(string?);
           (index, var protocolTypeField) = Decoder.ReadString(buffer, index);
           (index, var protocolsField) = Decoder.ReadArray<JoinGroupRequestProtocol>(buffer, index, JoinGroupRequestProtocolSerde.ReadV03);
           if (protocolsField == null)
               throw new NullReferenceException("Null not allowed for 'Protocols'");
           var reasonField = default(string?);
           return (index, new(
               groupIdField,
               sessionTimeoutMsField,
               rebalanceTimeoutMsField,
               memberIdField,
               groupInstanceIdField,
               protocolTypeField,
               protocolsField.Value,
               reasonField
           ));
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
       private static (int Offset, JoinGroupRequest Value) ReadV04(byte[] buffer, int index)
       {
           (index, var groupIdField) = Decoder.ReadString(buffer, index);
           (index, var sessionTimeoutMsField) = Decoder.ReadInt32(buffer, index);
           (index, var rebalanceTimeoutMsField) = Decoder.ReadInt32(buffer, index);
           (index, var memberIdField) = Decoder.ReadString(buffer, index);
           var groupInstanceIdField = default(string?);
           (index, var protocolTypeField) = Decoder.ReadString(buffer, index);
           (index, var protocolsField) = Decoder.ReadArray<JoinGroupRequestProtocol>(buffer, index, JoinGroupRequestProtocolSerde.ReadV04);
           if (protocolsField == null)
               throw new NullReferenceException("Null not allowed for 'Protocols'");
           var reasonField = default(string?);
           return (index, new(
               groupIdField,
               sessionTimeoutMsField,
               rebalanceTimeoutMsField,
               memberIdField,
               groupInstanceIdField,
               protocolTypeField,
               protocolsField.Value,
               reasonField
           ));
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
       private static (int Offset, JoinGroupRequest Value) ReadV05(byte[] buffer, int index)
       {
           (index, var groupIdField) = Decoder.ReadString(buffer, index);
           (index, var sessionTimeoutMsField) = Decoder.ReadInt32(buffer, index);
           (index, var rebalanceTimeoutMsField) = Decoder.ReadInt32(buffer, index);
           (index, var memberIdField) = Decoder.ReadString(buffer, index);
           (index, var groupInstanceIdField) = Decoder.ReadNullableString(buffer, index);
           (index, var protocolTypeField) = Decoder.ReadString(buffer, index);
           (index, var protocolsField) = Decoder.ReadArray<JoinGroupRequestProtocol>(buffer, index, JoinGroupRequestProtocolSerde.ReadV05);
           if (protocolsField == null)
               throw new NullReferenceException("Null not allowed for 'Protocols'");
           var reasonField = default(string?);
           return (index, new(
               groupIdField,
               sessionTimeoutMsField,
               rebalanceTimeoutMsField,
               memberIdField,
               groupInstanceIdField,
               protocolTypeField,
               protocolsField.Value,
               reasonField
           ));
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
       private static (int Offset, JoinGroupRequest Value) ReadV06(byte[] buffer, int index)
       {
           (index, var groupIdField) = Decoder.ReadCompactString(buffer, index);
           (index, var sessionTimeoutMsField) = Decoder.ReadInt32(buffer, index);
           (index, var rebalanceTimeoutMsField) = Decoder.ReadInt32(buffer, index);
           (index, var memberIdField) = Decoder.ReadCompactString(buffer, index);
           (index, var groupInstanceIdField) = Decoder.ReadCompactNullableString(buffer, index);
           (index, var protocolTypeField) = Decoder.ReadCompactString(buffer, index);
           (index, var protocolsField) = Decoder.ReadCompactArray<JoinGroupRequestProtocol>(buffer, index, JoinGroupRequestProtocolSerde.ReadV06);
           if (protocolsField == null)
               throw new NullReferenceException("Null not allowed for 'Protocols'");
           var reasonField = default(string?);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               groupIdField,
               sessionTimeoutMsField,
               rebalanceTimeoutMsField,
               memberIdField,
               groupInstanceIdField,
               protocolTypeField,
               protocolsField.Value,
               reasonField
           ));
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
       private static (int Offset, JoinGroupRequest Value) ReadV07(byte[] buffer, int index)
       {
           (index, var groupIdField) = Decoder.ReadCompactString(buffer, index);
           (index, var sessionTimeoutMsField) = Decoder.ReadInt32(buffer, index);
           (index, var rebalanceTimeoutMsField) = Decoder.ReadInt32(buffer, index);
           (index, var memberIdField) = Decoder.ReadCompactString(buffer, index);
           (index, var groupInstanceIdField) = Decoder.ReadCompactNullableString(buffer, index);
           (index, var protocolTypeField) = Decoder.ReadCompactString(buffer, index);
           (index, var protocolsField) = Decoder.ReadCompactArray<JoinGroupRequestProtocol>(buffer, index, JoinGroupRequestProtocolSerde.ReadV07);
           if (protocolsField == null)
               throw new NullReferenceException("Null not allowed for 'Protocols'");
           var reasonField = default(string?);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               groupIdField,
               sessionTimeoutMsField,
               rebalanceTimeoutMsField,
               memberIdField,
               groupInstanceIdField,
               protocolTypeField,
               protocolsField.Value,
               reasonField
           ));
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
       private static (int Offset, JoinGroupRequest Value) ReadV08(byte[] buffer, int index)
       {
           (index, var groupIdField) = Decoder.ReadCompactString(buffer, index);
           (index, var sessionTimeoutMsField) = Decoder.ReadInt32(buffer, index);
           (index, var rebalanceTimeoutMsField) = Decoder.ReadInt32(buffer, index);
           (index, var memberIdField) = Decoder.ReadCompactString(buffer, index);
           (index, var groupInstanceIdField) = Decoder.ReadCompactNullableString(buffer, index);
           (index, var protocolTypeField) = Decoder.ReadCompactString(buffer, index);
           (index, var protocolsField) = Decoder.ReadCompactArray<JoinGroupRequestProtocol>(buffer, index, JoinGroupRequestProtocolSerde.ReadV08);
           if (protocolsField == null)
               throw new NullReferenceException("Null not allowed for 'Protocols'");
           (index, var reasonField) = Decoder.ReadCompactNullableString(buffer, index);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               groupIdField,
               sessionTimeoutMsField,
               rebalanceTimeoutMsField,
               memberIdField,
               groupInstanceIdField,
               protocolTypeField,
               protocolsField.Value,
               reasonField
           ));
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
       private static (int Offset, JoinGroupRequest Value) ReadV09(byte[] buffer, int index)
       {
           (index, var groupIdField) = Decoder.ReadCompactString(buffer, index);
           (index, var sessionTimeoutMsField) = Decoder.ReadInt32(buffer, index);
           (index, var rebalanceTimeoutMsField) = Decoder.ReadInt32(buffer, index);
           (index, var memberIdField) = Decoder.ReadCompactString(buffer, index);
           (index, var groupInstanceIdField) = Decoder.ReadCompactNullableString(buffer, index);
           (index, var protocolTypeField) = Decoder.ReadCompactString(buffer, index);
           (index, var protocolsField) = Decoder.ReadCompactArray<JoinGroupRequestProtocol>(buffer, index, JoinGroupRequestProtocolSerde.ReadV09);
           if (protocolsField == null)
               throw new NullReferenceException("Null not allowed for 'Protocols'");
           (index, var reasonField) = Decoder.ReadCompactNullableString(buffer, index);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               groupIdField,
               sessionTimeoutMsField,
               rebalanceTimeoutMsField,
               memberIdField,
               groupInstanceIdField,
               protocolTypeField,
               protocolsField.Value,
               reasonField
           ));
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
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class JoinGroupRequestProtocolSerde
       {
           public static (int Offset, JoinGroupRequestProtocol Value) ReadV00(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var metadataField) = Decoder.ReadBytes(buffer, index);
               return (index, new(
                   nameField,
                   metadataField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, JoinGroupRequestProtocol message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteBytes(buffer, index, message.MetadataField);
               return index;
           }
           public static (int Offset, JoinGroupRequestProtocol Value) ReadV01(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var metadataField) = Decoder.ReadBytes(buffer, index);
               return (index, new(
                   nameField,
                   metadataField
               ));
           }
           public static int WriteV01(byte[] buffer, int index, JoinGroupRequestProtocol message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteBytes(buffer, index, message.MetadataField);
               return index;
           }
           public static (int Offset, JoinGroupRequestProtocol Value) ReadV02(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var metadataField) = Decoder.ReadBytes(buffer, index);
               return (index, new(
                   nameField,
                   metadataField
               ));
           }
           public static int WriteV02(byte[] buffer, int index, JoinGroupRequestProtocol message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteBytes(buffer, index, message.MetadataField);
               return index;
           }
           public static (int Offset, JoinGroupRequestProtocol Value) ReadV03(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var metadataField) = Decoder.ReadBytes(buffer, index);
               return (index, new(
                   nameField,
                   metadataField
               ));
           }
           public static int WriteV03(byte[] buffer, int index, JoinGroupRequestProtocol message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteBytes(buffer, index, message.MetadataField);
               return index;
           }
           public static (int Offset, JoinGroupRequestProtocol Value) ReadV04(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var metadataField) = Decoder.ReadBytes(buffer, index);
               return (index, new(
                   nameField,
                   metadataField
               ));
           }
           public static int WriteV04(byte[] buffer, int index, JoinGroupRequestProtocol message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteBytes(buffer, index, message.MetadataField);
               return index;
           }
           public static (int Offset, JoinGroupRequestProtocol Value) ReadV05(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var metadataField) = Decoder.ReadBytes(buffer, index);
               return (index, new(
                   nameField,
                   metadataField
               ));
           }
           public static int WriteV05(byte[] buffer, int index, JoinGroupRequestProtocol message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteBytes(buffer, index, message.MetadataField);
               return index;
           }
           public static (int Offset, JoinGroupRequestProtocol Value) ReadV06(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               (index, var metadataField) = Decoder.ReadCompactBytes(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   metadataField
               ));
           }
           public static int WriteV06(byte[] buffer, int index, JoinGroupRequestProtocol message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteCompactBytes(buffer, index, message.MetadataField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, JoinGroupRequestProtocol Value) ReadV07(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               (index, var metadataField) = Decoder.ReadCompactBytes(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   metadataField
               ));
           }
           public static int WriteV07(byte[] buffer, int index, JoinGroupRequestProtocol message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteCompactBytes(buffer, index, message.MetadataField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, JoinGroupRequestProtocol Value) ReadV08(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               (index, var metadataField) = Decoder.ReadCompactBytes(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   metadataField
               ));
           }
           public static int WriteV08(byte[] buffer, int index, JoinGroupRequestProtocol message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteCompactBytes(buffer, index, message.MetadataField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, JoinGroupRequestProtocol Value) ReadV09(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               (index, var metadataField) = Decoder.ReadCompactBytes(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   metadataField
               ));
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