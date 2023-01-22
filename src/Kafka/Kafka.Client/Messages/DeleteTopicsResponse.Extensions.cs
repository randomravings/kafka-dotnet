using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using DeletableTopicResult = Kafka.Client.Messages.DeleteTopicsResponse.DeletableTopicResult;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class DeleteTopicsResponseSerde
   {
       private static readonly DecodeDelegate<DeleteTopicsResponse>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
           ReadV04,
           ReadV05,
           ReadV06,
       };
       private static readonly EncodeDelegate<DeleteTopicsResponse>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
           WriteV04,
           WriteV05,
           WriteV06,
};
       public static (int Offset, DeleteTopicsResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, DeleteTopicsResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, DeleteTopicsResponse Value) ReadV00(byte[] buffer, int index)
       {
           var throttleTimeMsField = default(int);
           (index, var responsesField) = Decoder.ReadArray<DeletableTopicResult>(buffer, index, DeletableTopicResultSerde.ReadV00);
           if (responsesField == null)
               throw new NullReferenceException("Null not allowed for 'Responses'");
           return (index, new(
               throttleTimeMsField,
               responsesField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, DeleteTopicsResponse message)
       {
           index = Encoder.WriteArray<DeletableTopicResult>(buffer, index, message.ResponsesField, DeletableTopicResultSerde.WriteV00);
           return index;
       }
       private static (int Offset, DeleteTopicsResponse Value) ReadV01(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var responsesField) = Decoder.ReadArray<DeletableTopicResult>(buffer, index, DeletableTopicResultSerde.ReadV01);
           if (responsesField == null)
               throw new NullReferenceException("Null not allowed for 'Responses'");
           return (index, new(
               throttleTimeMsField,
               responsesField.Value
           ));
       }
       private static int WriteV01(byte[] buffer, int index, DeleteTopicsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<DeletableTopicResult>(buffer, index, message.ResponsesField, DeletableTopicResultSerde.WriteV01);
           return index;
       }
       private static (int Offset, DeleteTopicsResponse Value) ReadV02(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var responsesField) = Decoder.ReadArray<DeletableTopicResult>(buffer, index, DeletableTopicResultSerde.ReadV02);
           if (responsesField == null)
               throw new NullReferenceException("Null not allowed for 'Responses'");
           return (index, new(
               throttleTimeMsField,
               responsesField.Value
           ));
       }
       private static int WriteV02(byte[] buffer, int index, DeleteTopicsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<DeletableTopicResult>(buffer, index, message.ResponsesField, DeletableTopicResultSerde.WriteV02);
           return index;
       }
       private static (int Offset, DeleteTopicsResponse Value) ReadV03(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var responsesField) = Decoder.ReadArray<DeletableTopicResult>(buffer, index, DeletableTopicResultSerde.ReadV03);
           if (responsesField == null)
               throw new NullReferenceException("Null not allowed for 'Responses'");
           return (index, new(
               throttleTimeMsField,
               responsesField.Value
           ));
       }
       private static int WriteV03(byte[] buffer, int index, DeleteTopicsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<DeletableTopicResult>(buffer, index, message.ResponsesField, DeletableTopicResultSerde.WriteV03);
           return index;
       }
       private static (int Offset, DeleteTopicsResponse Value) ReadV04(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var responsesField) = Decoder.ReadCompactArray<DeletableTopicResult>(buffer, index, DeletableTopicResultSerde.ReadV04);
           if (responsesField == null)
               throw new NullReferenceException("Null not allowed for 'Responses'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               responsesField.Value
           ));
       }
       private static int WriteV04(byte[] buffer, int index, DeleteTopicsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteCompactArray<DeletableTopicResult>(buffer, index, message.ResponsesField, DeletableTopicResultSerde.WriteV04);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, DeleteTopicsResponse Value) ReadV05(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var responsesField) = Decoder.ReadCompactArray<DeletableTopicResult>(buffer, index, DeletableTopicResultSerde.ReadV05);
           if (responsesField == null)
               throw new NullReferenceException("Null not allowed for 'Responses'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               responsesField.Value
           ));
       }
       private static int WriteV05(byte[] buffer, int index, DeleteTopicsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteCompactArray<DeletableTopicResult>(buffer, index, message.ResponsesField, DeletableTopicResultSerde.WriteV05);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, DeleteTopicsResponse Value) ReadV06(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var responsesField) = Decoder.ReadCompactArray<DeletableTopicResult>(buffer, index, DeletableTopicResultSerde.ReadV06);
           if (responsesField == null)
               throw new NullReferenceException("Null not allowed for 'Responses'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               responsesField.Value
           ));
       }
       private static int WriteV06(byte[] buffer, int index, DeleteTopicsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteCompactArray<DeletableTopicResult>(buffer, index, message.ResponsesField, DeletableTopicResultSerde.WriteV06);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class DeletableTopicResultSerde
       {
           public static (int Offset, DeletableTopicResult Value) ReadV00(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               var errorMessageField = default(string?);
               return (index, new(
                   nameField,
                   topicIdField,
                   errorCodeField,
                   errorMessageField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, DeletableTopicResult message)
           {
               if (message.NameField == null)
                   throw new ArgumentNullException(nameof(message.NameField));
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               return index;
           }
           public static (int Offset, DeletableTopicResult Value) ReadV01(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               var errorMessageField = default(string?);
               return (index, new(
                   nameField,
                   topicIdField,
                   errorCodeField,
                   errorMessageField
               ));
           }
           public static int WriteV01(byte[] buffer, int index, DeletableTopicResult message)
           {
               if (message.NameField == null)
                   throw new ArgumentNullException(nameof(message.NameField));
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               return index;
           }
           public static (int Offset, DeletableTopicResult Value) ReadV02(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               var errorMessageField = default(string?);
               return (index, new(
                   nameField,
                   topicIdField,
                   errorCodeField,
                   errorMessageField
               ));
           }
           public static int WriteV02(byte[] buffer, int index, DeletableTopicResult message)
           {
               if (message.NameField == null)
                   throw new ArgumentNullException(nameof(message.NameField));
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               return index;
           }
           public static (int Offset, DeletableTopicResult Value) ReadV03(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               var errorMessageField = default(string?);
               return (index, new(
                   nameField,
                   topicIdField,
                   errorCodeField,
                   errorMessageField
               ));
           }
           public static int WriteV03(byte[] buffer, int index, DeletableTopicResult message)
           {
               if (message.NameField == null)
                   throw new ArgumentNullException(nameof(message.NameField));
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               return index;
           }
           public static (int Offset, DeletableTopicResult Value) ReadV04(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               var topicIdField = default(Guid);
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               var errorMessageField = default(string?);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   topicIdField,
                   errorCodeField,
                   errorMessageField
               ));
           }
           public static int WriteV04(byte[] buffer, int index, DeletableTopicResult message)
           {
               if (message.NameField == null)
                   throw new ArgumentNullException(nameof(message.NameField));
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, DeletableTopicResult Value) ReadV05(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               var topicIdField = default(Guid);
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var errorMessageField) = Decoder.ReadCompactNullableString(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   topicIdField,
                   errorCodeField,
                   errorMessageField
               ));
           }
           public static int WriteV05(byte[] buffer, int index, DeletableTopicResult message)
           {
               if (message.NameField == null)
                   throw new ArgumentNullException(nameof(message.NameField));
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, DeletableTopicResult Value) ReadV06(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactNullableString(buffer, index);
               (index, var topicIdField) = Decoder.ReadUuid(buffer, index);
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var errorMessageField) = Decoder.ReadCompactNullableString(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   topicIdField,
                   errorCodeField,
                   errorMessageField
               ));
           }
           public static int WriteV06(byte[] buffer, int index, DeletableTopicResult message)
           {
               index = Encoder.WriteCompactNullableString(buffer, index, message.NameField);
               index = Encoder.WriteUuid(buffer, index, message.TopicIdField);
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
   }
}