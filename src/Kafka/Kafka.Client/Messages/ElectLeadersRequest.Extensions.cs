using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using TopicPartitions = Kafka.Client.Messages.ElectLeadersRequest.TopicPartitions;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class ElectLeadersRequestSerde
   {
       private static readonly DecodeDelegate<ElectLeadersRequest>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
       };
       private static readonly EncodeDelegate<ElectLeadersRequest>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
};
       public static (int Offset, ElectLeadersRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, ElectLeadersRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, ElectLeadersRequest Value) ReadV00(byte[] buffer, int index)
       {
           var electionTypeField = default(sbyte);
           (index, var topicPartitionsField) = Decoder.ReadArray<TopicPartitions>(buffer, index, TopicPartitionsSerde.ReadV00);
           (index, var timeoutMsField) = Decoder.ReadInt32(buffer, index);
           return (index, new(
               electionTypeField,
               topicPartitionsField,
               timeoutMsField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, ElectLeadersRequest message)
       {
           index = Encoder.WriteArray<TopicPartitions>(buffer, index, message.TopicPartitionsField, TopicPartitionsSerde.WriteV00);
           index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
           return index;
       }
       private static (int Offset, ElectLeadersRequest Value) ReadV01(byte[] buffer, int index)
       {
           (index, var electionTypeField) = Decoder.ReadInt8(buffer, index);
           (index, var topicPartitionsField) = Decoder.ReadArray<TopicPartitions>(buffer, index, TopicPartitionsSerde.ReadV01);
           (index, var timeoutMsField) = Decoder.ReadInt32(buffer, index);
           return (index, new(
               electionTypeField,
               topicPartitionsField,
               timeoutMsField
           ));
       }
       private static int WriteV01(byte[] buffer, int index, ElectLeadersRequest message)
       {
           index = Encoder.WriteInt8(buffer, index, message.ElectionTypeField);
           index = Encoder.WriteArray<TopicPartitions>(buffer, index, message.TopicPartitionsField, TopicPartitionsSerde.WriteV01);
           index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
           return index;
       }
       private static (int Offset, ElectLeadersRequest Value) ReadV02(byte[] buffer, int index)
       {
           (index, var electionTypeField) = Decoder.ReadInt8(buffer, index);
           (index, var topicPartitionsField) = Decoder.ReadCompactArray<TopicPartitions>(buffer, index, TopicPartitionsSerde.ReadV02);
           (index, var timeoutMsField) = Decoder.ReadInt32(buffer, index);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               electionTypeField,
               topicPartitionsField,
               timeoutMsField
           ));
       }
       private static int WriteV02(byte[] buffer, int index, ElectLeadersRequest message)
       {
           index = Encoder.WriteInt8(buffer, index, message.ElectionTypeField);
           index = Encoder.WriteCompactArray<TopicPartitions>(buffer, index, message.TopicPartitionsField, TopicPartitionsSerde.WriteV02);
           index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class TopicPartitionsSerde
       {
           public static (int Offset, TopicPartitions Value) ReadV00(byte[] buffer, int index)
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
           public static int WriteV00(byte[] buffer, int index, TopicPartitions message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicField);
               index = Encoder.WriteArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
               return index;
           }
           public static (int Offset, TopicPartitions Value) ReadV01(byte[] buffer, int index)
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
           public static int WriteV01(byte[] buffer, int index, TopicPartitions message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicField);
               index = Encoder.WriteArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
               return index;
           }
           public static (int Offset, TopicPartitions Value) ReadV02(byte[] buffer, int index)
           {
               (index, var topicField) = Decoder.ReadCompactString(buffer, index);
               (index, var partitionsField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicField,
                   partitionsField.Value
               ));
           }
           public static int WriteV02(byte[] buffer, int index, TopicPartitions message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.TopicField);
               index = Encoder.WriteCompactArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
   }
}