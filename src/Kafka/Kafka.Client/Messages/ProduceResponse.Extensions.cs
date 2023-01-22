using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using BatchIndexAndErrorMessage = Kafka.Client.Messages.ProduceResponse.TopicProduceResponse.PartitionProduceResponse.BatchIndexAndErrorMessage;
using TopicProduceResponse = Kafka.Client.Messages.ProduceResponse.TopicProduceResponse;
using PartitionProduceResponse = Kafka.Client.Messages.ProduceResponse.TopicProduceResponse.PartitionProduceResponse;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class ProduceResponseSerde
   {
       private static readonly DecodeDelegate<ProduceResponse>[] READ_VERSIONS = {
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
       private static readonly EncodeDelegate<ProduceResponse>[] WRITE_VERSIONS = {
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
       public static (int Offset, ProduceResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, ProduceResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, ProduceResponse Value) ReadV00(byte[] buffer, int index)
       {
           (index, var responsesField) = Decoder.ReadArray<TopicProduceResponse>(buffer, index, TopicProduceResponseSerde.ReadV00);
           if (responsesField == null)
               throw new NullReferenceException("Null not allowed for 'Responses'");
           var throttleTimeMsField = default(int);
           return (index, new(
               responsesField.Value,
               throttleTimeMsField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, ProduceResponse message)
       {
           index = Encoder.WriteArray<TopicProduceResponse>(buffer, index, message.ResponsesField, TopicProduceResponseSerde.WriteV00);
           return index;
       }
       private static (int Offset, ProduceResponse Value) ReadV01(byte[] buffer, int index)
       {
           (index, var responsesField) = Decoder.ReadArray<TopicProduceResponse>(buffer, index, TopicProduceResponseSerde.ReadV01);
           if (responsesField == null)
               throw new NullReferenceException("Null not allowed for 'Responses'");
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           return (index, new(
               responsesField.Value,
               throttleTimeMsField
           ));
       }
       private static int WriteV01(byte[] buffer, int index, ProduceResponse message)
       {
           index = Encoder.WriteArray<TopicProduceResponse>(buffer, index, message.ResponsesField, TopicProduceResponseSerde.WriteV01);
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           return index;
       }
       private static (int Offset, ProduceResponse Value) ReadV02(byte[] buffer, int index)
       {
           (index, var responsesField) = Decoder.ReadArray<TopicProduceResponse>(buffer, index, TopicProduceResponseSerde.ReadV02);
           if (responsesField == null)
               throw new NullReferenceException("Null not allowed for 'Responses'");
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           return (index, new(
               responsesField.Value,
               throttleTimeMsField
           ));
       }
       private static int WriteV02(byte[] buffer, int index, ProduceResponse message)
       {
           index = Encoder.WriteArray<TopicProduceResponse>(buffer, index, message.ResponsesField, TopicProduceResponseSerde.WriteV02);
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           return index;
       }
       private static (int Offset, ProduceResponse Value) ReadV03(byte[] buffer, int index)
       {
           (index, var responsesField) = Decoder.ReadArray<TopicProduceResponse>(buffer, index, TopicProduceResponseSerde.ReadV03);
           if (responsesField == null)
               throw new NullReferenceException("Null not allowed for 'Responses'");
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           return (index, new(
               responsesField.Value,
               throttleTimeMsField
           ));
       }
       private static int WriteV03(byte[] buffer, int index, ProduceResponse message)
       {
           index = Encoder.WriteArray<TopicProduceResponse>(buffer, index, message.ResponsesField, TopicProduceResponseSerde.WriteV03);
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           return index;
       }
       private static (int Offset, ProduceResponse Value) ReadV04(byte[] buffer, int index)
       {
           (index, var responsesField) = Decoder.ReadArray<TopicProduceResponse>(buffer, index, TopicProduceResponseSerde.ReadV04);
           if (responsesField == null)
               throw new NullReferenceException("Null not allowed for 'Responses'");
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           return (index, new(
               responsesField.Value,
               throttleTimeMsField
           ));
       }
       private static int WriteV04(byte[] buffer, int index, ProduceResponse message)
       {
           index = Encoder.WriteArray<TopicProduceResponse>(buffer, index, message.ResponsesField, TopicProduceResponseSerde.WriteV04);
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           return index;
       }
       private static (int Offset, ProduceResponse Value) ReadV05(byte[] buffer, int index)
       {
           (index, var responsesField) = Decoder.ReadArray<TopicProduceResponse>(buffer, index, TopicProduceResponseSerde.ReadV05);
           if (responsesField == null)
               throw new NullReferenceException("Null not allowed for 'Responses'");
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           return (index, new(
               responsesField.Value,
               throttleTimeMsField
           ));
       }
       private static int WriteV05(byte[] buffer, int index, ProduceResponse message)
       {
           index = Encoder.WriteArray<TopicProduceResponse>(buffer, index, message.ResponsesField, TopicProduceResponseSerde.WriteV05);
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           return index;
       }
       private static (int Offset, ProduceResponse Value) ReadV06(byte[] buffer, int index)
       {
           (index, var responsesField) = Decoder.ReadArray<TopicProduceResponse>(buffer, index, TopicProduceResponseSerde.ReadV06);
           if (responsesField == null)
               throw new NullReferenceException("Null not allowed for 'Responses'");
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           return (index, new(
               responsesField.Value,
               throttleTimeMsField
           ));
       }
       private static int WriteV06(byte[] buffer, int index, ProduceResponse message)
       {
           index = Encoder.WriteArray<TopicProduceResponse>(buffer, index, message.ResponsesField, TopicProduceResponseSerde.WriteV06);
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           return index;
       }
       private static (int Offset, ProduceResponse Value) ReadV07(byte[] buffer, int index)
       {
           (index, var responsesField) = Decoder.ReadArray<TopicProduceResponse>(buffer, index, TopicProduceResponseSerde.ReadV07);
           if (responsesField == null)
               throw new NullReferenceException("Null not allowed for 'Responses'");
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           return (index, new(
               responsesField.Value,
               throttleTimeMsField
           ));
       }
       private static int WriteV07(byte[] buffer, int index, ProduceResponse message)
       {
           index = Encoder.WriteArray<TopicProduceResponse>(buffer, index, message.ResponsesField, TopicProduceResponseSerde.WriteV07);
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           return index;
       }
       private static (int Offset, ProduceResponse Value) ReadV08(byte[] buffer, int index)
       {
           (index, var responsesField) = Decoder.ReadArray<TopicProduceResponse>(buffer, index, TopicProduceResponseSerde.ReadV08);
           if (responsesField == null)
               throw new NullReferenceException("Null not allowed for 'Responses'");
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           return (index, new(
               responsesField.Value,
               throttleTimeMsField
           ));
       }
       private static int WriteV08(byte[] buffer, int index, ProduceResponse message)
       {
           index = Encoder.WriteArray<TopicProduceResponse>(buffer, index, message.ResponsesField, TopicProduceResponseSerde.WriteV08);
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           return index;
       }
       private static (int Offset, ProduceResponse Value) ReadV09(byte[] buffer, int index)
       {
           (index, var responsesField) = Decoder.ReadCompactArray<TopicProduceResponse>(buffer, index, TopicProduceResponseSerde.ReadV09);
           if (responsesField == null)
               throw new NullReferenceException("Null not allowed for 'Responses'");
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               responsesField.Value,
               throttleTimeMsField
           ));
       }
       private static int WriteV09(byte[] buffer, int index, ProduceResponse message)
       {
           index = Encoder.WriteCompactArray<TopicProduceResponse>(buffer, index, message.ResponsesField, TopicProduceResponseSerde.WriteV09);
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class TopicProduceResponseSerde
       {
           public static (int Offset, TopicProduceResponse Value) ReadV00(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionResponsesField) = Decoder.ReadArray<PartitionProduceResponse>(buffer, index, PartitionProduceResponseSerde.ReadV00);
               if (partitionResponsesField == null)
                   throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
               return (index, new(
                   nameField,
                   partitionResponsesField.Value
               ));
           }
           public static int WriteV00(byte[] buffer, int index, TopicProduceResponse message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<PartitionProduceResponse>(buffer, index, message.PartitionResponsesField, PartitionProduceResponseSerde.WriteV00);
               return index;
           }
           public static (int Offset, TopicProduceResponse Value) ReadV01(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionResponsesField) = Decoder.ReadArray<PartitionProduceResponse>(buffer, index, PartitionProduceResponseSerde.ReadV01);
               if (partitionResponsesField == null)
                   throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
               return (index, new(
                   nameField,
                   partitionResponsesField.Value
               ));
           }
           public static int WriteV01(byte[] buffer, int index, TopicProduceResponse message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<PartitionProduceResponse>(buffer, index, message.PartitionResponsesField, PartitionProduceResponseSerde.WriteV01);
               return index;
           }
           public static (int Offset, TopicProduceResponse Value) ReadV02(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionResponsesField) = Decoder.ReadArray<PartitionProduceResponse>(buffer, index, PartitionProduceResponseSerde.ReadV02);
               if (partitionResponsesField == null)
                   throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
               return (index, new(
                   nameField,
                   partitionResponsesField.Value
               ));
           }
           public static int WriteV02(byte[] buffer, int index, TopicProduceResponse message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<PartitionProduceResponse>(buffer, index, message.PartitionResponsesField, PartitionProduceResponseSerde.WriteV02);
               return index;
           }
           public static (int Offset, TopicProduceResponse Value) ReadV03(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionResponsesField) = Decoder.ReadArray<PartitionProduceResponse>(buffer, index, PartitionProduceResponseSerde.ReadV03);
               if (partitionResponsesField == null)
                   throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
               return (index, new(
                   nameField,
                   partitionResponsesField.Value
               ));
           }
           public static int WriteV03(byte[] buffer, int index, TopicProduceResponse message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<PartitionProduceResponse>(buffer, index, message.PartitionResponsesField, PartitionProduceResponseSerde.WriteV03);
               return index;
           }
           public static (int Offset, TopicProduceResponse Value) ReadV04(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionResponsesField) = Decoder.ReadArray<PartitionProduceResponse>(buffer, index, PartitionProduceResponseSerde.ReadV04);
               if (partitionResponsesField == null)
                   throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
               return (index, new(
                   nameField,
                   partitionResponsesField.Value
               ));
           }
           public static int WriteV04(byte[] buffer, int index, TopicProduceResponse message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<PartitionProduceResponse>(buffer, index, message.PartitionResponsesField, PartitionProduceResponseSerde.WriteV04);
               return index;
           }
           public static (int Offset, TopicProduceResponse Value) ReadV05(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionResponsesField) = Decoder.ReadArray<PartitionProduceResponse>(buffer, index, PartitionProduceResponseSerde.ReadV05);
               if (partitionResponsesField == null)
                   throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
               return (index, new(
                   nameField,
                   partitionResponsesField.Value
               ));
           }
           public static int WriteV05(byte[] buffer, int index, TopicProduceResponse message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<PartitionProduceResponse>(buffer, index, message.PartitionResponsesField, PartitionProduceResponseSerde.WriteV05);
               return index;
           }
           public static (int Offset, TopicProduceResponse Value) ReadV06(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionResponsesField) = Decoder.ReadArray<PartitionProduceResponse>(buffer, index, PartitionProduceResponseSerde.ReadV06);
               if (partitionResponsesField == null)
                   throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
               return (index, new(
                   nameField,
                   partitionResponsesField.Value
               ));
           }
           public static int WriteV06(byte[] buffer, int index, TopicProduceResponse message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<PartitionProduceResponse>(buffer, index, message.PartitionResponsesField, PartitionProduceResponseSerde.WriteV06);
               return index;
           }
           public static (int Offset, TopicProduceResponse Value) ReadV07(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionResponsesField) = Decoder.ReadArray<PartitionProduceResponse>(buffer, index, PartitionProduceResponseSerde.ReadV07);
               if (partitionResponsesField == null)
                   throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
               return (index, new(
                   nameField,
                   partitionResponsesField.Value
               ));
           }
           public static int WriteV07(byte[] buffer, int index, TopicProduceResponse message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<PartitionProduceResponse>(buffer, index, message.PartitionResponsesField, PartitionProduceResponseSerde.WriteV07);
               return index;
           }
           public static (int Offset, TopicProduceResponse Value) ReadV08(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionResponsesField) = Decoder.ReadArray<PartitionProduceResponse>(buffer, index, PartitionProduceResponseSerde.ReadV08);
               if (partitionResponsesField == null)
                   throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
               return (index, new(
                   nameField,
                   partitionResponsesField.Value
               ));
           }
           public static int WriteV08(byte[] buffer, int index, TopicProduceResponse message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<PartitionProduceResponse>(buffer, index, message.PartitionResponsesField, PartitionProduceResponseSerde.WriteV08);
               return index;
           }
           public static (int Offset, TopicProduceResponse Value) ReadV09(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               (index, var partitionResponsesField) = Decoder.ReadCompactArray<PartitionProduceResponse>(buffer, index, PartitionProduceResponseSerde.ReadV09);
               if (partitionResponsesField == null)
                   throw new NullReferenceException("Null not allowed for 'PartitionResponses'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   partitionResponsesField.Value
               ));
           }
           public static int WriteV09(byte[] buffer, int index, TopicProduceResponse message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteCompactArray<PartitionProduceResponse>(buffer, index, message.PartitionResponsesField, PartitionProduceResponseSerde.WriteV09);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class PartitionProduceResponseSerde
           {
               public static (int Offset, PartitionProduceResponse Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var indexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var baseOffsetField) = Decoder.ReadInt64(buffer, index);
                   var logAppendTimeMsField = default(long);
                   var logStartOffsetField = default(long);
                   var recordErrorsField = ImmutableArray<BatchIndexAndErrorMessage>.Empty;
                   var errorMessageField = default(string?);
                   return (index, new(
                       indexField,
                       errorCodeField,
                       baseOffsetField,
                       logAppendTimeMsField,
                       logStartOffsetField,
                       recordErrorsField,
                       errorMessageField
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, PartitionProduceResponse message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.IndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt64(buffer, index, message.BaseOffsetField);
                   return index;
               }
               public static (int Offset, PartitionProduceResponse Value) ReadV01(byte[] buffer, int index)
               {
                   (index, var indexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var baseOffsetField) = Decoder.ReadInt64(buffer, index);
                   var logAppendTimeMsField = default(long);
                   var logStartOffsetField = default(long);
                   var recordErrorsField = ImmutableArray<BatchIndexAndErrorMessage>.Empty;
                   var errorMessageField = default(string?);
                   return (index, new(
                       indexField,
                       errorCodeField,
                       baseOffsetField,
                       logAppendTimeMsField,
                       logStartOffsetField,
                       recordErrorsField,
                       errorMessageField
                   ));
               }
               public static int WriteV01(byte[] buffer, int index, PartitionProduceResponse message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.IndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt64(buffer, index, message.BaseOffsetField);
                   return index;
               }
               public static (int Offset, PartitionProduceResponse Value) ReadV02(byte[] buffer, int index)
               {
                   (index, var indexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var baseOffsetField) = Decoder.ReadInt64(buffer, index);
                   (index, var logAppendTimeMsField) = Decoder.ReadInt64(buffer, index);
                   var logStartOffsetField = default(long);
                   var recordErrorsField = ImmutableArray<BatchIndexAndErrorMessage>.Empty;
                   var errorMessageField = default(string?);
                   return (index, new(
                       indexField,
                       errorCodeField,
                       baseOffsetField,
                       logAppendTimeMsField,
                       logStartOffsetField,
                       recordErrorsField,
                       errorMessageField
                   ));
               }
               public static int WriteV02(byte[] buffer, int index, PartitionProduceResponse message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.IndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt64(buffer, index, message.BaseOffsetField);
                   index = Encoder.WriteInt64(buffer, index, message.LogAppendTimeMsField);
                   return index;
               }
               public static (int Offset, PartitionProduceResponse Value) ReadV03(byte[] buffer, int index)
               {
                   (index, var indexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var baseOffsetField) = Decoder.ReadInt64(buffer, index);
                   (index, var logAppendTimeMsField) = Decoder.ReadInt64(buffer, index);
                   var logStartOffsetField = default(long);
                   var recordErrorsField = ImmutableArray<BatchIndexAndErrorMessage>.Empty;
                   var errorMessageField = default(string?);
                   return (index, new(
                       indexField,
                       errorCodeField,
                       baseOffsetField,
                       logAppendTimeMsField,
                       logStartOffsetField,
                       recordErrorsField,
                       errorMessageField
                   ));
               }
               public static int WriteV03(byte[] buffer, int index, PartitionProduceResponse message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.IndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt64(buffer, index, message.BaseOffsetField);
                   index = Encoder.WriteInt64(buffer, index, message.LogAppendTimeMsField);
                   return index;
               }
               public static (int Offset, PartitionProduceResponse Value) ReadV04(byte[] buffer, int index)
               {
                   (index, var indexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var baseOffsetField) = Decoder.ReadInt64(buffer, index);
                   (index, var logAppendTimeMsField) = Decoder.ReadInt64(buffer, index);
                   var logStartOffsetField = default(long);
                   var recordErrorsField = ImmutableArray<BatchIndexAndErrorMessage>.Empty;
                   var errorMessageField = default(string?);
                   return (index, new(
                       indexField,
                       errorCodeField,
                       baseOffsetField,
                       logAppendTimeMsField,
                       logStartOffsetField,
                       recordErrorsField,
                       errorMessageField
                   ));
               }
               public static int WriteV04(byte[] buffer, int index, PartitionProduceResponse message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.IndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt64(buffer, index, message.BaseOffsetField);
                   index = Encoder.WriteInt64(buffer, index, message.LogAppendTimeMsField);
                   return index;
               }
               public static (int Offset, PartitionProduceResponse Value) ReadV05(byte[] buffer, int index)
               {
                   (index, var indexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var baseOffsetField) = Decoder.ReadInt64(buffer, index);
                   (index, var logAppendTimeMsField) = Decoder.ReadInt64(buffer, index);
                   (index, var logStartOffsetField) = Decoder.ReadInt64(buffer, index);
                   var recordErrorsField = ImmutableArray<BatchIndexAndErrorMessage>.Empty;
                   var errorMessageField = default(string?);
                   return (index, new(
                       indexField,
                       errorCodeField,
                       baseOffsetField,
                       logAppendTimeMsField,
                       logStartOffsetField,
                       recordErrorsField,
                       errorMessageField
                   ));
               }
               public static int WriteV05(byte[] buffer, int index, PartitionProduceResponse message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.IndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt64(buffer, index, message.BaseOffsetField);
                   index = Encoder.WriteInt64(buffer, index, message.LogAppendTimeMsField);
                   index = Encoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                   return index;
               }
               public static (int Offset, PartitionProduceResponse Value) ReadV06(byte[] buffer, int index)
               {
                   (index, var indexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var baseOffsetField) = Decoder.ReadInt64(buffer, index);
                   (index, var logAppendTimeMsField) = Decoder.ReadInt64(buffer, index);
                   (index, var logStartOffsetField) = Decoder.ReadInt64(buffer, index);
                   var recordErrorsField = ImmutableArray<BatchIndexAndErrorMessage>.Empty;
                   var errorMessageField = default(string?);
                   return (index, new(
                       indexField,
                       errorCodeField,
                       baseOffsetField,
                       logAppendTimeMsField,
                       logStartOffsetField,
                       recordErrorsField,
                       errorMessageField
                   ));
               }
               public static int WriteV06(byte[] buffer, int index, PartitionProduceResponse message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.IndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt64(buffer, index, message.BaseOffsetField);
                   index = Encoder.WriteInt64(buffer, index, message.LogAppendTimeMsField);
                   index = Encoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                   return index;
               }
               public static (int Offset, PartitionProduceResponse Value) ReadV07(byte[] buffer, int index)
               {
                   (index, var indexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var baseOffsetField) = Decoder.ReadInt64(buffer, index);
                   (index, var logAppendTimeMsField) = Decoder.ReadInt64(buffer, index);
                   (index, var logStartOffsetField) = Decoder.ReadInt64(buffer, index);
                   var recordErrorsField = ImmutableArray<BatchIndexAndErrorMessage>.Empty;
                   var errorMessageField = default(string?);
                   return (index, new(
                       indexField,
                       errorCodeField,
                       baseOffsetField,
                       logAppendTimeMsField,
                       logStartOffsetField,
                       recordErrorsField,
                       errorMessageField
                   ));
               }
               public static int WriteV07(byte[] buffer, int index, PartitionProduceResponse message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.IndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt64(buffer, index, message.BaseOffsetField);
                   index = Encoder.WriteInt64(buffer, index, message.LogAppendTimeMsField);
                   index = Encoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                   return index;
               }
               public static (int Offset, PartitionProduceResponse Value) ReadV08(byte[] buffer, int index)
               {
                   (index, var indexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var baseOffsetField) = Decoder.ReadInt64(buffer, index);
                   (index, var logAppendTimeMsField) = Decoder.ReadInt64(buffer, index);
                   (index, var logStartOffsetField) = Decoder.ReadInt64(buffer, index);
                   (index, var recordErrorsField) = Decoder.ReadArray<BatchIndexAndErrorMessage>(buffer, index, BatchIndexAndErrorMessageSerde.ReadV08);
                   if (recordErrorsField == null)
                       throw new NullReferenceException("Null not allowed for 'RecordErrors'");
                   (index, var errorMessageField) = Decoder.ReadNullableString(buffer, index);
                   return (index, new(
                       indexField,
                       errorCodeField,
                       baseOffsetField,
                       logAppendTimeMsField,
                       logStartOffsetField,
                       recordErrorsField.Value,
                       errorMessageField
                   ));
               }
               public static int WriteV08(byte[] buffer, int index, PartitionProduceResponse message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.IndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt64(buffer, index, message.BaseOffsetField);
                   index = Encoder.WriteInt64(buffer, index, message.LogAppendTimeMsField);
                   index = Encoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                   index = Encoder.WriteArray<BatchIndexAndErrorMessage>(buffer, index, message.RecordErrorsField, BatchIndexAndErrorMessageSerde.WriteV08);
                   index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
                   return index;
               }
               public static (int Offset, PartitionProduceResponse Value) ReadV09(byte[] buffer, int index)
               {
                   (index, var indexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var baseOffsetField) = Decoder.ReadInt64(buffer, index);
                   (index, var logAppendTimeMsField) = Decoder.ReadInt64(buffer, index);
                   (index, var logStartOffsetField) = Decoder.ReadInt64(buffer, index);
                   (index, var recordErrorsField) = Decoder.ReadCompactArray<BatchIndexAndErrorMessage>(buffer, index, BatchIndexAndErrorMessageSerde.ReadV09);
                   if (recordErrorsField == null)
                       throw new NullReferenceException("Null not allowed for 'RecordErrors'");
                   (index, var errorMessageField) = Decoder.ReadCompactNullableString(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       indexField,
                       errorCodeField,
                       baseOffsetField,
                       logAppendTimeMsField,
                       logStartOffsetField,
                       recordErrorsField.Value,
                       errorMessageField
                   ));
               }
               public static int WriteV09(byte[] buffer, int index, PartitionProduceResponse message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.IndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt64(buffer, index, message.BaseOffsetField);
                   index = Encoder.WriteInt64(buffer, index, message.LogAppendTimeMsField);
                   index = Encoder.WriteInt64(buffer, index, message.LogStartOffsetField);
                   index = Encoder.WriteCompactArray<BatchIndexAndErrorMessage>(buffer, index, message.RecordErrorsField, BatchIndexAndErrorMessageSerde.WriteV09);
                   index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
               [GeneratedCode("kgen", "1.0.0.0")]
               private static class BatchIndexAndErrorMessageSerde
               {
                   public static (int Offset, BatchIndexAndErrorMessage Value) ReadV00(byte[] buffer, int index)
                   {
                       var batchIndexField = default(int);
                       var batchIndexErrorMessageField = default(string?);
                       return (index, new(
                           batchIndexField,
                           batchIndexErrorMessageField
                       ));
                   }
                   public static int WriteV00(byte[] buffer, int index, BatchIndexAndErrorMessage message)
                   {
                       return index;
                   }
                   public static (int Offset, BatchIndexAndErrorMessage Value) ReadV01(byte[] buffer, int index)
                   {
                       var batchIndexField = default(int);
                       var batchIndexErrorMessageField = default(string?);
                       return (index, new(
                           batchIndexField,
                           batchIndexErrorMessageField
                       ));
                   }
                   public static int WriteV01(byte[] buffer, int index, BatchIndexAndErrorMessage message)
                   {
                       return index;
                   }
                   public static (int Offset, BatchIndexAndErrorMessage Value) ReadV02(byte[] buffer, int index)
                   {
                       var batchIndexField = default(int);
                       var batchIndexErrorMessageField = default(string?);
                       return (index, new(
                           batchIndexField,
                           batchIndexErrorMessageField
                       ));
                   }
                   public static int WriteV02(byte[] buffer, int index, BatchIndexAndErrorMessage message)
                   {
                       return index;
                   }
                   public static (int Offset, BatchIndexAndErrorMessage Value) ReadV03(byte[] buffer, int index)
                   {
                       var batchIndexField = default(int);
                       var batchIndexErrorMessageField = default(string?);
                       return (index, new(
                           batchIndexField,
                           batchIndexErrorMessageField
                       ));
                   }
                   public static int WriteV03(byte[] buffer, int index, BatchIndexAndErrorMessage message)
                   {
                       return index;
                   }
                   public static (int Offset, BatchIndexAndErrorMessage Value) ReadV04(byte[] buffer, int index)
                   {
                       var batchIndexField = default(int);
                       var batchIndexErrorMessageField = default(string?);
                       return (index, new(
                           batchIndexField,
                           batchIndexErrorMessageField
                       ));
                   }
                   public static int WriteV04(byte[] buffer, int index, BatchIndexAndErrorMessage message)
                   {
                       return index;
                   }
                   public static (int Offset, BatchIndexAndErrorMessage Value) ReadV05(byte[] buffer, int index)
                   {
                       var batchIndexField = default(int);
                       var batchIndexErrorMessageField = default(string?);
                       return (index, new(
                           batchIndexField,
                           batchIndexErrorMessageField
                       ));
                   }
                   public static int WriteV05(byte[] buffer, int index, BatchIndexAndErrorMessage message)
                   {
                       return index;
                   }
                   public static (int Offset, BatchIndexAndErrorMessage Value) ReadV06(byte[] buffer, int index)
                   {
                       var batchIndexField = default(int);
                       var batchIndexErrorMessageField = default(string?);
                       return (index, new(
                           batchIndexField,
                           batchIndexErrorMessageField
                       ));
                   }
                   public static int WriteV06(byte[] buffer, int index, BatchIndexAndErrorMessage message)
                   {
                       return index;
                   }
                   public static (int Offset, BatchIndexAndErrorMessage Value) ReadV07(byte[] buffer, int index)
                   {
                       var batchIndexField = default(int);
                       var batchIndexErrorMessageField = default(string?);
                       return (index, new(
                           batchIndexField,
                           batchIndexErrorMessageField
                       ));
                   }
                   public static int WriteV07(byte[] buffer, int index, BatchIndexAndErrorMessage message)
                   {
                       return index;
                   }
                   public static (int Offset, BatchIndexAndErrorMessage Value) ReadV08(byte[] buffer, int index)
                   {
                       (index, var batchIndexField) = Decoder.ReadInt32(buffer, index);
                       (index, var batchIndexErrorMessageField) = Decoder.ReadNullableString(buffer, index);
                       return (index, new(
                           batchIndexField,
                           batchIndexErrorMessageField
                       ));
                   }
                   public static int WriteV08(byte[] buffer, int index, BatchIndexAndErrorMessage message)
                   {
                       index = Encoder.WriteInt32(buffer, index, message.BatchIndexField);
                       index = Encoder.WriteNullableString(buffer, index, message.BatchIndexErrorMessageField);
                       return index;
                   }
                   public static (int Offset, BatchIndexAndErrorMessage Value) ReadV09(byte[] buffer, int index)
                   {
                       (index, var batchIndexField) = Decoder.ReadInt32(buffer, index);
                       (index, var batchIndexErrorMessageField) = Decoder.ReadCompactNullableString(buffer, index);
                       (index, _) = Decoder.ReadVarUInt32(buffer, index);
                       return (index, new(
                           batchIndexField,
                           batchIndexErrorMessageField
                       ));
                   }
                   public static int WriteV09(byte[] buffer, int index, BatchIndexAndErrorMessage message)
                   {
                       index = Encoder.WriteInt32(buffer, index, message.BatchIndexField);
                       index = Encoder.WriteCompactNullableString(buffer, index, message.BatchIndexErrorMessageField);
                       index = Encoder.WriteVarUInt32(buffer, index, 0);
                       return index;
                   }
               }
           }
       }
   }
}