using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using CreatePartitionsTopicResult = Kafka.Client.Messages.CreatePartitionsResponse.CreatePartitionsTopicResult;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class CreatePartitionsResponseSerde
   {
       private static readonly DecodeDelegate<CreatePartitionsResponse>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
       };
       private static readonly EncodeDelegate<CreatePartitionsResponse>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
};
       public static (int Offset, CreatePartitionsResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, CreatePartitionsResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, CreatePartitionsResponse Value) ReadV00(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var resultsField) = Decoder.ReadArray<CreatePartitionsTopicResult>(buffer, index, CreatePartitionsTopicResultSerde.ReadV00);
           if (resultsField == null)
               throw new NullReferenceException("Null not allowed for 'Results'");
           return (index, new(
               throttleTimeMsField,
               resultsField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, CreatePartitionsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<CreatePartitionsTopicResult>(buffer, index, message.ResultsField, CreatePartitionsTopicResultSerde.WriteV00);
           return index;
       }
       private static (int Offset, CreatePartitionsResponse Value) ReadV01(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var resultsField) = Decoder.ReadArray<CreatePartitionsTopicResult>(buffer, index, CreatePartitionsTopicResultSerde.ReadV01);
           if (resultsField == null)
               throw new NullReferenceException("Null not allowed for 'Results'");
           return (index, new(
               throttleTimeMsField,
               resultsField.Value
           ));
       }
       private static int WriteV01(byte[] buffer, int index, CreatePartitionsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<CreatePartitionsTopicResult>(buffer, index, message.ResultsField, CreatePartitionsTopicResultSerde.WriteV01);
           return index;
       }
       private static (int Offset, CreatePartitionsResponse Value) ReadV02(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var resultsField) = Decoder.ReadCompactArray<CreatePartitionsTopicResult>(buffer, index, CreatePartitionsTopicResultSerde.ReadV02);
           if (resultsField == null)
               throw new NullReferenceException("Null not allowed for 'Results'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               resultsField.Value
           ));
       }
       private static int WriteV02(byte[] buffer, int index, CreatePartitionsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteCompactArray<CreatePartitionsTopicResult>(buffer, index, message.ResultsField, CreatePartitionsTopicResultSerde.WriteV02);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, CreatePartitionsResponse Value) ReadV03(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var resultsField) = Decoder.ReadCompactArray<CreatePartitionsTopicResult>(buffer, index, CreatePartitionsTopicResultSerde.ReadV03);
           if (resultsField == null)
               throw new NullReferenceException("Null not allowed for 'Results'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               resultsField.Value
           ));
       }
       private static int WriteV03(byte[] buffer, int index, CreatePartitionsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteCompactArray<CreatePartitionsTopicResult>(buffer, index, message.ResultsField, CreatePartitionsTopicResultSerde.WriteV03);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class CreatePartitionsTopicResultSerde
       {
           public static (int Offset, CreatePartitionsTopicResult Value) ReadV00(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var errorMessageField) = Decoder.ReadNullableString(buffer, index);
               return (index, new(
                   nameField,
                   errorCodeField,
                   errorMessageField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, CreatePartitionsTopicResult message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
               return index;
           }
           public static (int Offset, CreatePartitionsTopicResult Value) ReadV01(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var errorMessageField) = Decoder.ReadNullableString(buffer, index);
               return (index, new(
                   nameField,
                   errorCodeField,
                   errorMessageField
               ));
           }
           public static int WriteV01(byte[] buffer, int index, CreatePartitionsTopicResult message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
               return index;
           }
           public static (int Offset, CreatePartitionsTopicResult Value) ReadV02(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var errorMessageField) = Decoder.ReadCompactNullableString(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   errorCodeField,
                   errorMessageField
               ));
           }
           public static int WriteV02(byte[] buffer, int index, CreatePartitionsTopicResult message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, CreatePartitionsTopicResult Value) ReadV03(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var errorMessageField) = Decoder.ReadCompactNullableString(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   errorCodeField,
                   errorMessageField
               ));
           }
           public static int WriteV03(byte[] buffer, int index, CreatePartitionsTopicResult message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
   }
}