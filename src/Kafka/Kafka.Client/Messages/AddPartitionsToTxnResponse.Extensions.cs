using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using AddPartitionsToTxnPartitionResult = Kafka.Client.Messages.AddPartitionsToTxnResponse.AddPartitionsToTxnTopicResult.AddPartitionsToTxnPartitionResult;
using AddPartitionsToTxnTopicResult = Kafka.Client.Messages.AddPartitionsToTxnResponse.AddPartitionsToTxnTopicResult;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class AddPartitionsToTxnResponseSerde
   {
       private static readonly DecodeDelegate<AddPartitionsToTxnResponse>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
       };
       private static readonly EncodeDelegate<AddPartitionsToTxnResponse>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
};
       public static (int Offset, AddPartitionsToTxnResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, AddPartitionsToTxnResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, AddPartitionsToTxnResponse Value) ReadV00(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var resultsField) = Decoder.ReadArray<AddPartitionsToTxnTopicResult>(buffer, index, AddPartitionsToTxnTopicResultSerde.ReadV00);
           if (resultsField == null)
               throw new NullReferenceException("Null not allowed for 'Results'");
           return (index, new(
               throttleTimeMsField,
               resultsField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, AddPartitionsToTxnResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<AddPartitionsToTxnTopicResult>(buffer, index, message.ResultsField, AddPartitionsToTxnTopicResultSerde.WriteV00);
           return index;
       }
       private static (int Offset, AddPartitionsToTxnResponse Value) ReadV01(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var resultsField) = Decoder.ReadArray<AddPartitionsToTxnTopicResult>(buffer, index, AddPartitionsToTxnTopicResultSerde.ReadV01);
           if (resultsField == null)
               throw new NullReferenceException("Null not allowed for 'Results'");
           return (index, new(
               throttleTimeMsField,
               resultsField.Value
           ));
       }
       private static int WriteV01(byte[] buffer, int index, AddPartitionsToTxnResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<AddPartitionsToTxnTopicResult>(buffer, index, message.ResultsField, AddPartitionsToTxnTopicResultSerde.WriteV01);
           return index;
       }
       private static (int Offset, AddPartitionsToTxnResponse Value) ReadV02(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var resultsField) = Decoder.ReadArray<AddPartitionsToTxnTopicResult>(buffer, index, AddPartitionsToTxnTopicResultSerde.ReadV02);
           if (resultsField == null)
               throw new NullReferenceException("Null not allowed for 'Results'");
           return (index, new(
               throttleTimeMsField,
               resultsField.Value
           ));
       }
       private static int WriteV02(byte[] buffer, int index, AddPartitionsToTxnResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<AddPartitionsToTxnTopicResult>(buffer, index, message.ResultsField, AddPartitionsToTxnTopicResultSerde.WriteV02);
           return index;
       }
       private static (int Offset, AddPartitionsToTxnResponse Value) ReadV03(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var resultsField) = Decoder.ReadCompactArray<AddPartitionsToTxnTopicResult>(buffer, index, AddPartitionsToTxnTopicResultSerde.ReadV03);
           if (resultsField == null)
               throw new NullReferenceException("Null not allowed for 'Results'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               resultsField.Value
           ));
       }
       private static int WriteV03(byte[] buffer, int index, AddPartitionsToTxnResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteCompactArray<AddPartitionsToTxnTopicResult>(buffer, index, message.ResultsField, AddPartitionsToTxnTopicResultSerde.WriteV03);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class AddPartitionsToTxnTopicResultSerde
       {
           public static (int Offset, AddPartitionsToTxnTopicResult Value) ReadV00(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var resultsField) = Decoder.ReadArray<AddPartitionsToTxnPartitionResult>(buffer, index, AddPartitionsToTxnPartitionResultSerde.ReadV00);
               if (resultsField == null)
                   throw new NullReferenceException("Null not allowed for 'Results'");
               return (index, new(
                   nameField,
                   resultsField.Value
               ));
           }
           public static int WriteV00(byte[] buffer, int index, AddPartitionsToTxnTopicResult message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<AddPartitionsToTxnPartitionResult>(buffer, index, message.ResultsField, AddPartitionsToTxnPartitionResultSerde.WriteV00);
               return index;
           }
           public static (int Offset, AddPartitionsToTxnTopicResult Value) ReadV01(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var resultsField) = Decoder.ReadArray<AddPartitionsToTxnPartitionResult>(buffer, index, AddPartitionsToTxnPartitionResultSerde.ReadV01);
               if (resultsField == null)
                   throw new NullReferenceException("Null not allowed for 'Results'");
               return (index, new(
                   nameField,
                   resultsField.Value
               ));
           }
           public static int WriteV01(byte[] buffer, int index, AddPartitionsToTxnTopicResult message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<AddPartitionsToTxnPartitionResult>(buffer, index, message.ResultsField, AddPartitionsToTxnPartitionResultSerde.WriteV01);
               return index;
           }
           public static (int Offset, AddPartitionsToTxnTopicResult Value) ReadV02(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var resultsField) = Decoder.ReadArray<AddPartitionsToTxnPartitionResult>(buffer, index, AddPartitionsToTxnPartitionResultSerde.ReadV02);
               if (resultsField == null)
                   throw new NullReferenceException("Null not allowed for 'Results'");
               return (index, new(
                   nameField,
                   resultsField.Value
               ));
           }
           public static int WriteV02(byte[] buffer, int index, AddPartitionsToTxnTopicResult message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<AddPartitionsToTxnPartitionResult>(buffer, index, message.ResultsField, AddPartitionsToTxnPartitionResultSerde.WriteV02);
               return index;
           }
           public static (int Offset, AddPartitionsToTxnTopicResult Value) ReadV03(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               (index, var resultsField) = Decoder.ReadCompactArray<AddPartitionsToTxnPartitionResult>(buffer, index, AddPartitionsToTxnPartitionResultSerde.ReadV03);
               if (resultsField == null)
                   throw new NullReferenceException("Null not allowed for 'Results'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   resultsField.Value
               ));
           }
           public static int WriteV03(byte[] buffer, int index, AddPartitionsToTxnTopicResult message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteCompactArray<AddPartitionsToTxnPartitionResult>(buffer, index, message.ResultsField, AddPartitionsToTxnPartitionResultSerde.WriteV03);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class AddPartitionsToTxnPartitionResultSerde
           {
               public static (int Offset, AddPartitionsToTxnPartitionResult Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, AddPartitionsToTxnPartitionResult message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   return index;
               }
               public static (int Offset, AddPartitionsToTxnPartitionResult Value) ReadV01(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField
                   ));
               }
               public static int WriteV01(byte[] buffer, int index, AddPartitionsToTxnPartitionResult message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   return index;
               }
               public static (int Offset, AddPartitionsToTxnPartitionResult Value) ReadV02(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField
                   ));
               }
               public static int WriteV02(byte[] buffer, int index, AddPartitionsToTxnPartitionResult message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   return index;
               }
               public static (int Offset, AddPartitionsToTxnPartitionResult Value) ReadV03(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField
                   ));
               }
               public static int WriteV03(byte[] buffer, int index, AddPartitionsToTxnPartitionResult message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
           }
       }
   }
}