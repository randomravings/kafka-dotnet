using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using AlterConfigsResourceResponse = Kafka.Client.Messages.AlterConfigsResponse.AlterConfigsResourceResponse;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class AlterConfigsResponseSerde
   {
       private static readonly DecodeDelegate<AlterConfigsResponse>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
       };
       private static readonly EncodeDelegate<AlterConfigsResponse>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
};
       public static (int Offset, AlterConfigsResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, AlterConfigsResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, AlterConfigsResponse Value) ReadV00(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var responsesField) = Decoder.ReadArray<AlterConfigsResourceResponse>(buffer, index, AlterConfigsResourceResponseSerde.ReadV00);
           if (responsesField == null)
               throw new NullReferenceException("Null not allowed for 'Responses'");
           return (index, new(
               throttleTimeMsField,
               responsesField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, AlterConfigsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<AlterConfigsResourceResponse>(buffer, index, message.ResponsesField, AlterConfigsResourceResponseSerde.WriteV00);
           return index;
       }
       private static (int Offset, AlterConfigsResponse Value) ReadV01(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var responsesField) = Decoder.ReadArray<AlterConfigsResourceResponse>(buffer, index, AlterConfigsResourceResponseSerde.ReadV01);
           if (responsesField == null)
               throw new NullReferenceException("Null not allowed for 'Responses'");
           return (index, new(
               throttleTimeMsField,
               responsesField.Value
           ));
       }
       private static int WriteV01(byte[] buffer, int index, AlterConfigsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<AlterConfigsResourceResponse>(buffer, index, message.ResponsesField, AlterConfigsResourceResponseSerde.WriteV01);
           return index;
       }
       private static (int Offset, AlterConfigsResponse Value) ReadV02(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var responsesField) = Decoder.ReadCompactArray<AlterConfigsResourceResponse>(buffer, index, AlterConfigsResourceResponseSerde.ReadV02);
           if (responsesField == null)
               throw new NullReferenceException("Null not allowed for 'Responses'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               responsesField.Value
           ));
       }
       private static int WriteV02(byte[] buffer, int index, AlterConfigsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteCompactArray<AlterConfigsResourceResponse>(buffer, index, message.ResponsesField, AlterConfigsResourceResponseSerde.WriteV02);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class AlterConfigsResourceResponseSerde
       {
           public static (int Offset, AlterConfigsResourceResponse Value) ReadV00(byte[] buffer, int index)
           {
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var errorMessageField) = Decoder.ReadNullableString(buffer, index);
               (index, var resourceTypeField) = Decoder.ReadInt8(buffer, index);
               (index, var resourceNameField) = Decoder.ReadString(buffer, index);
               return (index, new(
                   errorCodeField,
                   errorMessageField,
                   resourceTypeField,
                   resourceNameField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, AlterConfigsResourceResponse message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
               index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
               index = Encoder.WriteString(buffer, index, message.ResourceNameField);
               return index;
           }
           public static (int Offset, AlterConfigsResourceResponse Value) ReadV01(byte[] buffer, int index)
           {
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var errorMessageField) = Decoder.ReadNullableString(buffer, index);
               (index, var resourceTypeField) = Decoder.ReadInt8(buffer, index);
               (index, var resourceNameField) = Decoder.ReadString(buffer, index);
               return (index, new(
                   errorCodeField,
                   errorMessageField,
                   resourceTypeField,
                   resourceNameField
               ));
           }
           public static int WriteV01(byte[] buffer, int index, AlterConfigsResourceResponse message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
               index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
               index = Encoder.WriteString(buffer, index, message.ResourceNameField);
               return index;
           }
           public static (int Offset, AlterConfigsResourceResponse Value) ReadV02(byte[] buffer, int index)
           {
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var errorMessageField) = Decoder.ReadCompactNullableString(buffer, index);
               (index, var resourceTypeField) = Decoder.ReadInt8(buffer, index);
               (index, var resourceNameField) = Decoder.ReadCompactString(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   errorCodeField,
                   errorMessageField,
                   resourceTypeField,
                   resourceNameField
               ));
           }
           public static int WriteV02(byte[] buffer, int index, AlterConfigsResourceResponse message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
               index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
               index = Encoder.WriteCompactString(buffer, index, message.ResourceNameField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
   }
}