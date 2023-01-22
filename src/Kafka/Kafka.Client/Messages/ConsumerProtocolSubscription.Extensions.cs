using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using TopicPartition = Kafka.Client.Messages.ConsumerProtocolSubscription.TopicPartition;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class ConsumerProtocolSubscriptionSerde
   {
       private static readonly DecodeDelegate<ConsumerProtocolSubscription>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
       };
       private static readonly EncodeDelegate<ConsumerProtocolSubscription>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
};
       public static (int Offset, ConsumerProtocolSubscription Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, ConsumerProtocolSubscription message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, ConsumerProtocolSubscription Value) ReadV00(byte[] buffer, int index)
       {
           (index, var topicsField) = Decoder.ReadArray<string>(buffer, index, Decoder.ReadCompactString);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, var userDataField) = Decoder.ReadNullableBytes(buffer, index);
           var ownedPartitionsField = ImmutableArray<TopicPartition>.Empty;
           var generationIdField = default(int);
           return (index, new(
               topicsField.Value,
               userDataField,
               ownedPartitionsField,
               generationIdField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, ConsumerProtocolSubscription message)
       {
           index = Encoder.WriteArray<string>(buffer, index, message.TopicsField, Encoder.WriteCompactString);
           index = Encoder.WriteNullableBytes(buffer, index, message.UserDataField);
           return index;
       }
       private static (int Offset, ConsumerProtocolSubscription Value) ReadV01(byte[] buffer, int index)
       {
           (index, var topicsField) = Decoder.ReadArray<string>(buffer, index, Decoder.ReadCompactString);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, var userDataField) = Decoder.ReadNullableBytes(buffer, index);
           (index, var ownedPartitionsField) = Decoder.ReadArray<TopicPartition>(buffer, index, TopicPartitionSerde.ReadV01);
           if (ownedPartitionsField == null)
               throw new NullReferenceException("Null not allowed for 'OwnedPartitions'");
           var generationIdField = default(int);
           return (index, new(
               topicsField.Value,
               userDataField,
               ownedPartitionsField.Value,
               generationIdField
           ));
       }
       private static int WriteV01(byte[] buffer, int index, ConsumerProtocolSubscription message)
       {
           index = Encoder.WriteArray<string>(buffer, index, message.TopicsField, Encoder.WriteCompactString);
           index = Encoder.WriteNullableBytes(buffer, index, message.UserDataField);
           index = Encoder.WriteArray<TopicPartition>(buffer, index, message.OwnedPartitionsField, TopicPartitionSerde.WriteV01);
           return index;
       }
       private static (int Offset, ConsumerProtocolSubscription Value) ReadV02(byte[] buffer, int index)
       {
           (index, var topicsField) = Decoder.ReadArray<string>(buffer, index, Decoder.ReadCompactString);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, var userDataField) = Decoder.ReadNullableBytes(buffer, index);
           (index, var ownedPartitionsField) = Decoder.ReadArray<TopicPartition>(buffer, index, TopicPartitionSerde.ReadV02);
           if (ownedPartitionsField == null)
               throw new NullReferenceException("Null not allowed for 'OwnedPartitions'");
           (index, var generationIdField) = Decoder.ReadInt32(buffer, index);
           return (index, new(
               topicsField.Value,
               userDataField,
               ownedPartitionsField.Value,
               generationIdField
           ));
       }
       private static int WriteV02(byte[] buffer, int index, ConsumerProtocolSubscription message)
       {
           index = Encoder.WriteArray<string>(buffer, index, message.TopicsField, Encoder.WriteCompactString);
           index = Encoder.WriteNullableBytes(buffer, index, message.UserDataField);
           index = Encoder.WriteArray<TopicPartition>(buffer, index, message.OwnedPartitionsField, TopicPartitionSerde.WriteV02);
           index = Encoder.WriteInt32(buffer, index, message.GenerationIdField);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class TopicPartitionSerde
       {
           public static (int Offset, TopicPartition Value) ReadV00(byte[] buffer, int index)
           {
               var topicField = "";
               var partitionsField = ImmutableArray<int>.Empty;
               return (index, new(
                   topicField,
                   partitionsField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, TopicPartition message)
           {
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