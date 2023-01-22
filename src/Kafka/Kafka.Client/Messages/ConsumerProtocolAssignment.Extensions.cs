using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using TopicPartition = Kafka.Client.Messages.ConsumerProtocolAssignment.TopicPartition;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class ConsumerProtocolAssignmentSerde
   {
       private static readonly DecodeDelegate<ConsumerProtocolAssignment>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
       };
       private static readonly EncodeDelegate<ConsumerProtocolAssignment>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
};
       public static (int Offset, ConsumerProtocolAssignment Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, ConsumerProtocolAssignment message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, ConsumerProtocolAssignment Value) ReadV00(byte[] buffer, int index)
       {
           (index, var assignedPartitionsField) = Decoder.ReadArray<TopicPartition>(buffer, index, TopicPartitionSerde.ReadV00);
           if (assignedPartitionsField == null)
               throw new NullReferenceException("Null not allowed for 'AssignedPartitions'");
           (index, var userDataField) = Decoder.ReadNullableBytes(buffer, index);
           return (index, new(
               assignedPartitionsField.Value,
               userDataField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, ConsumerProtocolAssignment message)
       {
           index = Encoder.WriteArray<TopicPartition>(buffer, index, message.AssignedPartitionsField, TopicPartitionSerde.WriteV00);
           index = Encoder.WriteNullableBytes(buffer, index, message.UserDataField);
           return index;
       }
       private static (int Offset, ConsumerProtocolAssignment Value) ReadV01(byte[] buffer, int index)
       {
           (index, var assignedPartitionsField) = Decoder.ReadArray<TopicPartition>(buffer, index, TopicPartitionSerde.ReadV01);
           if (assignedPartitionsField == null)
               throw new NullReferenceException("Null not allowed for 'AssignedPartitions'");
           (index, var userDataField) = Decoder.ReadNullableBytes(buffer, index);
           return (index, new(
               assignedPartitionsField.Value,
               userDataField
           ));
       }
       private static int WriteV01(byte[] buffer, int index, ConsumerProtocolAssignment message)
       {
           index = Encoder.WriteArray<TopicPartition>(buffer, index, message.AssignedPartitionsField, TopicPartitionSerde.WriteV01);
           index = Encoder.WriteNullableBytes(buffer, index, message.UserDataField);
           return index;
       }
       private static (int Offset, ConsumerProtocolAssignment Value) ReadV02(byte[] buffer, int index)
       {
           (index, var assignedPartitionsField) = Decoder.ReadArray<TopicPartition>(buffer, index, TopicPartitionSerde.ReadV02);
           if (assignedPartitionsField == null)
               throw new NullReferenceException("Null not allowed for 'AssignedPartitions'");
           (index, var userDataField) = Decoder.ReadNullableBytes(buffer, index);
           return (index, new(
               assignedPartitionsField.Value,
               userDataField
           ));
       }
       private static int WriteV02(byte[] buffer, int index, ConsumerProtocolAssignment message)
       {
           index = Encoder.WriteArray<TopicPartition>(buffer, index, message.AssignedPartitionsField, TopicPartitionSerde.WriteV02);
           index = Encoder.WriteNullableBytes(buffer, index, message.UserDataField);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class TopicPartitionSerde
       {
           public static (int Offset, TopicPartition Value) ReadV00(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   topicField,
                   partitionsField.Value
               ));
           }
           public static int WriteV00(byte[] buffer, int index, TopicPartition message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicField);
               index = Encoder.WriteArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
               return index;
           }
           public static (int Offset, TopicPartition Value) ReadV01(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   topicField,
                   partitionsField.Value
               ));
           }
           public static int WriteV01(byte[] buffer, int index, TopicPartition message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicField);
               index = Encoder.WriteArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
               return index;
           }
           public static (int Offset, TopicPartition Value) ReadV02(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   topicField,
                   partitionsField.Value
               ));
           }
           public static int WriteV02(byte[] buffer, int index, TopicPartition message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicField);
               index = Encoder.WriteArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
               return index;
           }
       }
   }
}