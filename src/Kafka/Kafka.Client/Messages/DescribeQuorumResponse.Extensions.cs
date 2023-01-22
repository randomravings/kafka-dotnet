using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using PartitionData = Kafka.Client.Messages.DescribeQuorumResponse.TopicData.PartitionData;
using ReplicaState = Kafka.Client.Messages.DescribeQuorumResponse.ReplicaState;
using TopicData = Kafka.Client.Messages.DescribeQuorumResponse.TopicData;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class DescribeQuorumResponseSerde
   {
       private static readonly DecodeDelegate<DescribeQuorumResponse>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
       };
       private static readonly EncodeDelegate<DescribeQuorumResponse>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
};
       public static (int Offset, DescribeQuorumResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, DescribeQuorumResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, DescribeQuorumResponse Value) ReadV00(byte[] buffer, int index)
       {
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var topicsField) = Decoder.ReadCompactArray<TopicData>(buffer, index, TopicDataSerde.ReadV00);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               errorCodeField,
               topicsField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, DescribeQuorumResponse message)
       {
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteCompactArray<TopicData>(buffer, index, message.TopicsField, TopicDataSerde.WriteV00);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, DescribeQuorumResponse Value) ReadV01(byte[] buffer, int index)
       {
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var topicsField) = Decoder.ReadCompactArray<TopicData>(buffer, index, TopicDataSerde.ReadV01);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               errorCodeField,
               topicsField.Value
           ));
       }
       private static int WriteV01(byte[] buffer, int index, DescribeQuorumResponse message)
       {
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteCompactArray<TopicData>(buffer, index, message.TopicsField, TopicDataSerde.WriteV01);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class ReplicaStateSerde
       {
           public static (int Offset, ReplicaState Value) ReadV00(byte[] buffer, int index)
           {
               (index, var replicaIdField) = Decoder.ReadInt32(buffer, index);
               (index, var logEndOffsetField) = Decoder.ReadInt64(buffer, index);
               var lastFetchTimestampField = default(long);
               var lastCaughtUpTimestampField = default(long);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   replicaIdField,
                   logEndOffsetField,
                   lastFetchTimestampField,
                   lastCaughtUpTimestampField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, ReplicaState message)
           {
               index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
               index = Encoder.WriteInt64(buffer, index, message.LogEndOffsetField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, ReplicaState Value) ReadV01(byte[] buffer, int index)
           {
               (index, var replicaIdField) = Decoder.ReadInt32(buffer, index);
               (index, var logEndOffsetField) = Decoder.ReadInt64(buffer, index);
               (index, var lastFetchTimestampField) = Decoder.ReadInt64(buffer, index);
               (index, var lastCaughtUpTimestampField) = Decoder.ReadInt64(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   replicaIdField,
                   logEndOffsetField,
                   lastFetchTimestampField,
                   lastCaughtUpTimestampField
               ));
           }
           public static int WriteV01(byte[] buffer, int index, ReplicaState message)
           {
               index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
               index = Encoder.WriteInt64(buffer, index, message.LogEndOffsetField);
               index = Encoder.WriteInt64(buffer, index, message.LastFetchTimestampField);
               index = Encoder.WriteInt64(buffer, index, message.LastCaughtUpTimestampField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class TopicDataSerde
       {
           public static (int Offset, TopicData Value) ReadV00(byte[] buffer, int index)
           {
               (index, var topicNameField) = Decoder.ReadCompactString(buffer, index);
               (index, var partitionsField) = Decoder.ReadCompactArray<PartitionData>(buffer, index, PartitionDataSerde.ReadV00);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicNameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV00(byte[] buffer, int index, TopicData message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.TopicNameField);
               index = Encoder.WriteCompactArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV00);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, TopicData Value) ReadV01(byte[] buffer, int index)
           {
               (index, var topicNameField) = Decoder.ReadCompactString(buffer, index);
               (index, var partitionsField) = Decoder.ReadCompactArray<PartitionData>(buffer, index, PartitionDataSerde.ReadV01);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicNameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV01(byte[] buffer, int index, TopicData message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.TopicNameField);
               index = Encoder.WriteCompactArray<PartitionData>(buffer, index, message.PartitionsField, PartitionDataSerde.WriteV01);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class PartitionDataSerde
           {
               public static (int Offset, PartitionData Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var leaderIdField) = Decoder.ReadInt32(buffer, index);
                   (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
                   (index, var highWatermarkField) = Decoder.ReadInt64(buffer, index);
                   (index, var currentVotersField) = Decoder.ReadCompactArray<ReplicaState>(buffer, index, ReplicaStateSerde.ReadV00);
                   if (currentVotersField == null)
                       throw new NullReferenceException("Null not allowed for 'CurrentVoters'");
                   (index, var observersField) = Decoder.ReadCompactArray<ReplicaState>(buffer, index, ReplicaStateSerde.ReadV00);
                   if (observersField == null)
                       throw new NullReferenceException("Null not allowed for 'Observers'");
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField,
                       leaderIdField,
                       leaderEpochField,
                       highWatermarkField,
                       currentVotersField.Value,
                       observersField.Value
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, PartitionData message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt32(buffer, index, message.LeaderIdField);
                   index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                   index = Encoder.WriteInt64(buffer, index, message.HighWatermarkField);
                   index = Encoder.WriteCompactArray<ReplicaState>(buffer, index, message.CurrentVotersField, ReplicaStateSerde.WriteV00);
                   index = Encoder.WriteCompactArray<ReplicaState>(buffer, index, message.ObserversField, ReplicaStateSerde.WriteV00);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
               public static (int Offset, PartitionData Value) ReadV01(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var leaderIdField) = Decoder.ReadInt32(buffer, index);
                   (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
                   (index, var highWatermarkField) = Decoder.ReadInt64(buffer, index);
                   (index, var currentVotersField) = Decoder.ReadCompactArray<ReplicaState>(buffer, index, ReplicaStateSerde.ReadV01);
                   if (currentVotersField == null)
                       throw new NullReferenceException("Null not allowed for 'CurrentVoters'");
                   (index, var observersField) = Decoder.ReadCompactArray<ReplicaState>(buffer, index, ReplicaStateSerde.ReadV01);
                   if (observersField == null)
                       throw new NullReferenceException("Null not allowed for 'Observers'");
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       errorCodeField,
                       leaderIdField,
                       leaderEpochField,
                       highWatermarkField,
                       currentVotersField.Value,
                       observersField.Value
                   ));
               }
               public static int WriteV01(byte[] buffer, int index, PartitionData message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt32(buffer, index, message.LeaderIdField);
                   index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                   index = Encoder.WriteInt64(buffer, index, message.HighWatermarkField);
                   index = Encoder.WriteCompactArray<ReplicaState>(buffer, index, message.CurrentVotersField, ReplicaStateSerde.WriteV01);
                   index = Encoder.WriteCompactArray<ReplicaState>(buffer, index, message.ObserversField, ReplicaStateSerde.WriteV01);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
           }
       }
   }
}