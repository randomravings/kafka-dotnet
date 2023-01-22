using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using TopicRequest = Kafka.Client.Messages.DescribeProducersRequest.TopicRequest;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class DescribeProducersRequestSerde
   {
       private static readonly DecodeDelegate<DescribeProducersRequest>[] READ_VERSIONS = {
           ReadV00,
       };
       private static readonly EncodeDelegate<DescribeProducersRequest>[] WRITE_VERSIONS = {
           WriteV00,
};
       public static (int Offset, DescribeProducersRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, DescribeProducersRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, DescribeProducersRequest Value) ReadV00(byte[] buffer, int index)
       {
           (index, var topicsField) = Decoder.ReadCompactArray<TopicRequest>(buffer, index, TopicRequestSerde.ReadV00);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               topicsField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, DescribeProducersRequest message)
       {
           index = Encoder.WriteCompactArray<TopicRequest>(buffer, index, message.TopicsField, TopicRequestSerde.WriteV00);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class TopicRequestSerde
       {
           public static (int Offset, TopicRequest Value) ReadV00(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               (index, var partitionIndexesField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
               if (partitionIndexesField == null)
                   throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   partitionIndexesField.Value
               ));
           }
           public static int WriteV00(byte[] buffer, int index, TopicRequest message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteCompactArray<int>(buffer, index, message.PartitionIndexesField, Encoder.WriteInt32);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
   }
}