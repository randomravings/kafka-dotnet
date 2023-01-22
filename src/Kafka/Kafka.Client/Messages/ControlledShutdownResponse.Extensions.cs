using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using RemainingPartition = Kafka.Client.Messages.ControlledShutdownResponse.RemainingPartition;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class ControlledShutdownResponseSerde
   {
       private static readonly DecodeDelegate<ControlledShutdownResponse>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
       };
       private static readonly EncodeDelegate<ControlledShutdownResponse>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
};
       public static (int Offset, ControlledShutdownResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, ControlledShutdownResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, ControlledShutdownResponse Value) ReadV00(byte[] buffer, int index)
       {
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var remainingPartitionsField) = Decoder.ReadArray<RemainingPartition>(buffer, index, RemainingPartitionSerde.ReadV00);
           if (remainingPartitionsField == null)
               throw new NullReferenceException("Null not allowed for 'RemainingPartitions'");
           return (index, new(
               errorCodeField,
               remainingPartitionsField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, ControlledShutdownResponse message)
       {
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteArray<RemainingPartition>(buffer, index, message.RemainingPartitionsField, RemainingPartitionSerde.WriteV00);
           return index;
       }
       private static (int Offset, ControlledShutdownResponse Value) ReadV01(byte[] buffer, int index)
       {
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var remainingPartitionsField) = Decoder.ReadArray<RemainingPartition>(buffer, index, RemainingPartitionSerde.ReadV01);
           if (remainingPartitionsField == null)
               throw new NullReferenceException("Null not allowed for 'RemainingPartitions'");
           return (index, new(
               errorCodeField,
               remainingPartitionsField.Value
           ));
       }
       private static int WriteV01(byte[] buffer, int index, ControlledShutdownResponse message)
       {
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteArray<RemainingPartition>(buffer, index, message.RemainingPartitionsField, RemainingPartitionSerde.WriteV01);
           return index;
       }
       private static (int Offset, ControlledShutdownResponse Value) ReadV02(byte[] buffer, int index)
       {
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var remainingPartitionsField) = Decoder.ReadArray<RemainingPartition>(buffer, index, RemainingPartitionSerde.ReadV02);
           if (remainingPartitionsField == null)
               throw new NullReferenceException("Null not allowed for 'RemainingPartitions'");
           return (index, new(
               errorCodeField,
               remainingPartitionsField.Value
           ));
       }
       private static int WriteV02(byte[] buffer, int index, ControlledShutdownResponse message)
       {
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteArray<RemainingPartition>(buffer, index, message.RemainingPartitionsField, RemainingPartitionSerde.WriteV02);
           return index;
       }
       private static (int Offset, ControlledShutdownResponse Value) ReadV03(byte[] buffer, int index)
       {
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var remainingPartitionsField) = Decoder.ReadCompactArray<RemainingPartition>(buffer, index, RemainingPartitionSerde.ReadV03);
           if (remainingPartitionsField == null)
               throw new NullReferenceException("Null not allowed for 'RemainingPartitions'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               errorCodeField,
               remainingPartitionsField.Value
           ));
       }
       private static int WriteV03(byte[] buffer, int index, ControlledShutdownResponse message)
       {
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteCompactArray<RemainingPartition>(buffer, index, message.RemainingPartitionsField, RemainingPartitionSerde.WriteV03);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class RemainingPartitionSerde
       {
           public static (int Offset, RemainingPartition Value) ReadV00(byte[] buffer, int index)
           {
               (index, var topicNameField) = Decoder.ReadString(buffer, index);
               (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
               return (index, new(
                   topicNameField,
                   partitionIndexField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, RemainingPartition message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicNameField);
               index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
               return index;
           }
           public static (int Offset, RemainingPartition Value) ReadV01(byte[] buffer, int index)
           {
               (index, var topicNameField) = Decoder.ReadString(buffer, index);
               (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
               return (index, new(
                   topicNameField,
                   partitionIndexField
               ));
           }
           public static int WriteV01(byte[] buffer, int index, RemainingPartition message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicNameField);
               index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
               return index;
           }
           public static (int Offset, RemainingPartition Value) ReadV02(byte[] buffer, int index)
           {
               (index, var topicNameField) = Decoder.ReadString(buffer, index);
               (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
               return (index, new(
                   topicNameField,
                   partitionIndexField
               ));
           }
           public static int WriteV02(byte[] buffer, int index, RemainingPartition message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicNameField);
               index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
               return index;
           }
           public static (int Offset, RemainingPartition Value) ReadV03(byte[] buffer, int index)
           {
               (index, var topicNameField) = Decoder.ReadCompactString(buffer, index);
               (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicNameField,
                   partitionIndexField
               ));
           }
           public static int WriteV03(byte[] buffer, int index, RemainingPartition message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.TopicNameField);
               index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
   }
}