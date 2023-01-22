using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using DescribableLogDirTopic = Kafka.Client.Messages.DescribeLogDirsRequest.DescribableLogDirTopic;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class DescribeLogDirsRequestSerde
   {
       private static readonly DecodeDelegate<DescribeLogDirsRequest>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
           ReadV04,
       };
       private static readonly EncodeDelegate<DescribeLogDirsRequest>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
           WriteV04,
};
       public static (int Offset, DescribeLogDirsRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, DescribeLogDirsRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, DescribeLogDirsRequest Value) ReadV00(byte[] buffer, int index)
       {
           (index, var topicsField) = Decoder.ReadArray<DescribableLogDirTopic>(buffer, index, DescribableLogDirTopicSerde.ReadV00);
           return (index, new(
               topicsField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, DescribeLogDirsRequest message)
       {
           index = Encoder.WriteArray<DescribableLogDirTopic>(buffer, index, message.TopicsField, DescribableLogDirTopicSerde.WriteV00);
           return index;
       }
       private static (int Offset, DescribeLogDirsRequest Value) ReadV01(byte[] buffer, int index)
       {
           (index, var topicsField) = Decoder.ReadArray<DescribableLogDirTopic>(buffer, index, DescribableLogDirTopicSerde.ReadV01);
           return (index, new(
               topicsField
           ));
       }
       private static int WriteV01(byte[] buffer, int index, DescribeLogDirsRequest message)
       {
           index = Encoder.WriteArray<DescribableLogDirTopic>(buffer, index, message.TopicsField, DescribableLogDirTopicSerde.WriteV01);
           return index;
       }
       private static (int Offset, DescribeLogDirsRequest Value) ReadV02(byte[] buffer, int index)
       {
           (index, var topicsField) = Decoder.ReadCompactArray<DescribableLogDirTopic>(buffer, index, DescribableLogDirTopicSerde.ReadV02);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               topicsField
           ));
       }
       private static int WriteV02(byte[] buffer, int index, DescribeLogDirsRequest message)
       {
           index = Encoder.WriteCompactArray<DescribableLogDirTopic>(buffer, index, message.TopicsField, DescribableLogDirTopicSerde.WriteV02);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, DescribeLogDirsRequest Value) ReadV03(byte[] buffer, int index)
       {
           (index, var topicsField) = Decoder.ReadCompactArray<DescribableLogDirTopic>(buffer, index, DescribableLogDirTopicSerde.ReadV03);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               topicsField
           ));
       }
       private static int WriteV03(byte[] buffer, int index, DescribeLogDirsRequest message)
       {
           index = Encoder.WriteCompactArray<DescribableLogDirTopic>(buffer, index, message.TopicsField, DescribableLogDirTopicSerde.WriteV03);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, DescribeLogDirsRequest Value) ReadV04(byte[] buffer, int index)
       {
           (index, var topicsField) = Decoder.ReadCompactArray<DescribableLogDirTopic>(buffer, index, DescribableLogDirTopicSerde.ReadV04);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               topicsField
           ));
       }
       private static int WriteV04(byte[] buffer, int index, DescribeLogDirsRequest message)
       {
           index = Encoder.WriteCompactArray<DescribableLogDirTopic>(buffer, index, message.TopicsField, DescribableLogDirTopicSerde.WriteV04);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class DescribableLogDirTopicSerde
       {
           public static (int Offset, DescribableLogDirTopic Value) ReadV00(byte[] buffer, int index)
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
           public static int WriteV00(byte[] buffer, int index, DescribableLogDirTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicField);
               index = Encoder.WriteArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
               return index;
           }
           public static (int Offset, DescribableLogDirTopic Value) ReadV01(byte[] buffer, int index)
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
           public static int WriteV01(byte[] buffer, int index, DescribableLogDirTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicField);
               index = Encoder.WriteArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
               return index;
           }
           public static (int Offset, DescribableLogDirTopic Value) ReadV02(byte[] buffer, int index)
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
           public static int WriteV02(byte[] buffer, int index, DescribableLogDirTopic message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.TopicField);
               index = Encoder.WriteCompactArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, DescribableLogDirTopic Value) ReadV03(byte[] buffer, int index)
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
           public static int WriteV03(byte[] buffer, int index, DescribableLogDirTopic message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.TopicField);
               index = Encoder.WriteCompactArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, DescribableLogDirTopic Value) ReadV04(byte[] buffer, int index)
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
           public static int WriteV04(byte[] buffer, int index, DescribableLogDirTopic message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.TopicField);
               index = Encoder.WriteCompactArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
   }
}