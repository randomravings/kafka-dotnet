using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using Coordinator = Kafka.Client.Messages.FindCoordinatorResponse.Coordinator;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class FindCoordinatorResponseSerde
   {
       private static readonly DecodeDelegate<FindCoordinatorResponse>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
           ReadV04,
       };
       private static readonly EncodeDelegate<FindCoordinatorResponse>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
           WriteV04,
};
       public static (int Offset, FindCoordinatorResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, FindCoordinatorResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, FindCoordinatorResponse Value) ReadV00(byte[] buffer, int index)
       {
           var throttleTimeMsField = default(int);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           var errorMessageField = default(string?);
           (index, var nodeIdField) = Decoder.ReadInt32(buffer, index);
           (index, var hostField) = Decoder.ReadString(buffer, index);
           (index, var portField) = Decoder.ReadInt32(buffer, index);
           var coordinatorsField = ImmutableArray<Coordinator>.Empty;
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               errorMessageField,
               nodeIdField,
               hostField,
               portField,
               coordinatorsField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, FindCoordinatorResponse message)
       {
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteInt32(buffer, index, message.NodeIdField);
           index = Encoder.WriteString(buffer, index, message.HostField);
           index = Encoder.WriteInt32(buffer, index, message.PortField);
           return index;
       }
       private static (int Offset, FindCoordinatorResponse Value) ReadV01(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var errorMessageField) = Decoder.ReadNullableString(buffer, index);
           (index, var nodeIdField) = Decoder.ReadInt32(buffer, index);
           (index, var hostField) = Decoder.ReadString(buffer, index);
           (index, var portField) = Decoder.ReadInt32(buffer, index);
           var coordinatorsField = ImmutableArray<Coordinator>.Empty;
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               errorMessageField,
               nodeIdField,
               hostField,
               portField,
               coordinatorsField
           ));
       }
       private static int WriteV01(byte[] buffer, int index, FindCoordinatorResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
           index = Encoder.WriteInt32(buffer, index, message.NodeIdField);
           index = Encoder.WriteString(buffer, index, message.HostField);
           index = Encoder.WriteInt32(buffer, index, message.PortField);
           return index;
       }
       private static (int Offset, FindCoordinatorResponse Value) ReadV02(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var errorMessageField) = Decoder.ReadNullableString(buffer, index);
           (index, var nodeIdField) = Decoder.ReadInt32(buffer, index);
           (index, var hostField) = Decoder.ReadString(buffer, index);
           (index, var portField) = Decoder.ReadInt32(buffer, index);
           var coordinatorsField = ImmutableArray<Coordinator>.Empty;
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               errorMessageField,
               nodeIdField,
               hostField,
               portField,
               coordinatorsField
           ));
       }
       private static int WriteV02(byte[] buffer, int index, FindCoordinatorResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
           index = Encoder.WriteInt32(buffer, index, message.NodeIdField);
           index = Encoder.WriteString(buffer, index, message.HostField);
           index = Encoder.WriteInt32(buffer, index, message.PortField);
           return index;
       }
       private static (int Offset, FindCoordinatorResponse Value) ReadV03(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var errorMessageField) = Decoder.ReadCompactNullableString(buffer, index);
           (index, var nodeIdField) = Decoder.ReadInt32(buffer, index);
           (index, var hostField) = Decoder.ReadCompactString(buffer, index);
           (index, var portField) = Decoder.ReadInt32(buffer, index);
           var coordinatorsField = ImmutableArray<Coordinator>.Empty;
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               errorMessageField,
               nodeIdField,
               hostField,
               portField,
               coordinatorsField
           ));
       }
       private static int WriteV03(byte[] buffer, int index, FindCoordinatorResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
           index = Encoder.WriteInt32(buffer, index, message.NodeIdField);
           index = Encoder.WriteCompactString(buffer, index, message.HostField);
           index = Encoder.WriteInt32(buffer, index, message.PortField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, FindCoordinatorResponse Value) ReadV04(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           var errorCodeField = default(short);
           var errorMessageField = default(string?);
           var nodeIdField = default(int);
           var hostField = "";
           var portField = default(int);
           (index, var coordinatorsField) = Decoder.ReadCompactArray<Coordinator>(buffer, index, CoordinatorSerde.ReadV04);
           if (coordinatorsField == null)
               throw new NullReferenceException("Null not allowed for 'Coordinators'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               errorMessageField,
               nodeIdField,
               hostField,
               portField,
               coordinatorsField.Value
           ));
       }
       private static int WriteV04(byte[] buffer, int index, FindCoordinatorResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteCompactArray<Coordinator>(buffer, index, message.CoordinatorsField, CoordinatorSerde.WriteV04);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class CoordinatorSerde
       {
           public static (int Offset, Coordinator Value) ReadV00(byte[] buffer, int index)
           {
               var keyField = "";
               var nodeIdField = default(int);
               var hostField = "";
               var portField = default(int);
               var errorCodeField = default(short);
               var errorMessageField = default(string?);
               return (index, new(
                   keyField,
                   nodeIdField,
                   hostField,
                   portField,
                   errorCodeField,
                   errorMessageField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, Coordinator message)
           {
               return index;
           }
           public static (int Offset, Coordinator Value) ReadV01(byte[] buffer, int index)
           {
               var keyField = "";
               var nodeIdField = default(int);
               var hostField = "";
               var portField = default(int);
               var errorCodeField = default(short);
               var errorMessageField = default(string?);
               return (index, new(
                   keyField,
                   nodeIdField,
                   hostField,
                   portField,
                   errorCodeField,
                   errorMessageField
               ));
           }
           public static int WriteV01(byte[] buffer, int index, Coordinator message)
           {
               return index;
           }
           public static (int Offset, Coordinator Value) ReadV02(byte[] buffer, int index)
           {
               var keyField = "";
               var nodeIdField = default(int);
               var hostField = "";
               var portField = default(int);
               var errorCodeField = default(short);
               var errorMessageField = default(string?);
               return (index, new(
                   keyField,
                   nodeIdField,
                   hostField,
                   portField,
                   errorCodeField,
                   errorMessageField
               ));
           }
           public static int WriteV02(byte[] buffer, int index, Coordinator message)
           {
               return index;
           }
           public static (int Offset, Coordinator Value) ReadV03(byte[] buffer, int index)
           {
               var keyField = "";
               var nodeIdField = default(int);
               var hostField = "";
               var portField = default(int);
               var errorCodeField = default(short);
               var errorMessageField = default(string?);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   keyField,
                   nodeIdField,
                   hostField,
                   portField,
                   errorCodeField,
                   errorMessageField
               ));
           }
           public static int WriteV03(byte[] buffer, int index, Coordinator message)
           {
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, Coordinator Value) ReadV04(byte[] buffer, int index)
           {
               (index, var keyField) = Decoder.ReadCompactString(buffer, index);
               (index, var nodeIdField) = Decoder.ReadInt32(buffer, index);
               (index, var hostField) = Decoder.ReadCompactString(buffer, index);
               (index, var portField) = Decoder.ReadInt32(buffer, index);
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var errorMessageField) = Decoder.ReadCompactNullableString(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   keyField,
                   nodeIdField,
                   hostField,
                   portField,
                   errorCodeField,
                   errorMessageField
               ));
           }
           public static int WriteV04(byte[] buffer, int index, Coordinator message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.KeyField);
               index = Encoder.WriteInt32(buffer, index, message.NodeIdField);
               index = Encoder.WriteCompactString(buffer, index, message.HostField);
               index = Encoder.WriteInt32(buffer, index, message.PortField);
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
   }
}