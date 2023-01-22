using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using StopReplicaPartitionError = Kafka.Client.Messages.StopReplicaResponse.StopReplicaPartitionError;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class StopReplicaResponseSerde
   {
       private static readonly DecodeDelegate<StopReplicaResponse>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
           ReadV04,
       };
       private static readonly EncodeDelegate<StopReplicaResponse>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
           WriteV04,
};
       public static (int Offset, StopReplicaResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, StopReplicaResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, StopReplicaResponse Value) ReadV00(byte[] buffer, int index)
       {
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var partitionErrorsField) = Decoder.ReadArray<StopReplicaPartitionError>(buffer, index, StopReplicaPartitionErrorSerde.ReadV00);
           if (partitionErrorsField == null)
               throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
           return (index, new(
               errorCodeField,
               partitionErrorsField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, StopReplicaResponse message)
       {
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteArray<StopReplicaPartitionError>(buffer, index, message.PartitionErrorsField, StopReplicaPartitionErrorSerde.WriteV00);
           return index;
       }
       private static (int Offset, StopReplicaResponse Value) ReadV01(byte[] buffer, int index)
       {
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var partitionErrorsField) = Decoder.ReadArray<StopReplicaPartitionError>(buffer, index, StopReplicaPartitionErrorSerde.ReadV01);
           if (partitionErrorsField == null)
               throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
           return (index, new(
               errorCodeField,
               partitionErrorsField.Value
           ));
       }
       private static int WriteV01(byte[] buffer, int index, StopReplicaResponse message)
       {
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteArray<StopReplicaPartitionError>(buffer, index, message.PartitionErrorsField, StopReplicaPartitionErrorSerde.WriteV01);
           return index;
       }
       private static (int Offset, StopReplicaResponse Value) ReadV02(byte[] buffer, int index)
       {
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var partitionErrorsField) = Decoder.ReadCompactArray<StopReplicaPartitionError>(buffer, index, StopReplicaPartitionErrorSerde.ReadV02);
           if (partitionErrorsField == null)
               throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               errorCodeField,
               partitionErrorsField.Value
           ));
       }
       private static int WriteV02(byte[] buffer, int index, StopReplicaResponse message)
       {
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteCompactArray<StopReplicaPartitionError>(buffer, index, message.PartitionErrorsField, StopReplicaPartitionErrorSerde.WriteV02);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, StopReplicaResponse Value) ReadV03(byte[] buffer, int index)
       {
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var partitionErrorsField) = Decoder.ReadCompactArray<StopReplicaPartitionError>(buffer, index, StopReplicaPartitionErrorSerde.ReadV03);
           if (partitionErrorsField == null)
               throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               errorCodeField,
               partitionErrorsField.Value
           ));
       }
       private static int WriteV03(byte[] buffer, int index, StopReplicaResponse message)
       {
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteCompactArray<StopReplicaPartitionError>(buffer, index, message.PartitionErrorsField, StopReplicaPartitionErrorSerde.WriteV03);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, StopReplicaResponse Value) ReadV04(byte[] buffer, int index)
       {
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var partitionErrorsField) = Decoder.ReadCompactArray<StopReplicaPartitionError>(buffer, index, StopReplicaPartitionErrorSerde.ReadV04);
           if (partitionErrorsField == null)
               throw new NullReferenceException("Null not allowed for 'PartitionErrors'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               errorCodeField,
               partitionErrorsField.Value
           ));
       }
       private static int WriteV04(byte[] buffer, int index, StopReplicaResponse message)
       {
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteCompactArray<StopReplicaPartitionError>(buffer, index, message.PartitionErrorsField, StopReplicaPartitionErrorSerde.WriteV04);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class StopReplicaPartitionErrorSerde
       {
           public static (int Offset, StopReplicaPartitionError Value) ReadV00(byte[] buffer, int index)
           {
               (index, var topicNameField) = Decoder.ReadString(buffer, index);
               (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               return (index, new(
                   topicNameField,
                   partitionIndexField,
                   errorCodeField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, StopReplicaPartitionError message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicNameField);
               index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               return index;
           }
           public static (int Offset, StopReplicaPartitionError Value) ReadV01(byte[] buffer, int index)
           {
               (index, var topicNameField) = Decoder.ReadString(buffer, index);
               (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               return (index, new(
                   topicNameField,
                   partitionIndexField,
                   errorCodeField
               ));
           }
           public static int WriteV01(byte[] buffer, int index, StopReplicaPartitionError message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicNameField);
               index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               return index;
           }
           public static (int Offset, StopReplicaPartitionError Value) ReadV02(byte[] buffer, int index)
           {
               (index, var topicNameField) = Decoder.ReadCompactString(buffer, index);
               (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicNameField,
                   partitionIndexField,
                   errorCodeField
               ));
           }
           public static int WriteV02(byte[] buffer, int index, StopReplicaPartitionError message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.TopicNameField);
               index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, StopReplicaPartitionError Value) ReadV03(byte[] buffer, int index)
           {
               (index, var topicNameField) = Decoder.ReadCompactString(buffer, index);
               (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicNameField,
                   partitionIndexField,
                   errorCodeField
               ));
           }
           public static int WriteV03(byte[] buffer, int index, StopReplicaPartitionError message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.TopicNameField);
               index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, StopReplicaPartitionError Value) ReadV04(byte[] buffer, int index)
           {
               (index, var topicNameField) = Decoder.ReadCompactString(buffer, index);
               (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicNameField,
                   partitionIndexField,
                   errorCodeField
               ));
           }
           public static int WriteV04(byte[] buffer, int index, StopReplicaPartitionError message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.TopicNameField);
               index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
   }
}