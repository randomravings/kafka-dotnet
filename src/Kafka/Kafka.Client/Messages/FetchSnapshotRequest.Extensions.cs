using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using SnapshotId = Kafka.Client.Messages.FetchSnapshotRequest.TopicSnapshot.PartitionSnapshot.SnapshotId;
using TopicSnapshot = Kafka.Client.Messages.FetchSnapshotRequest.TopicSnapshot;
using PartitionSnapshot = Kafka.Client.Messages.FetchSnapshotRequest.TopicSnapshot.PartitionSnapshot;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class FetchSnapshotRequestSerde
   {
       private static readonly DecodeDelegate<FetchSnapshotRequest>[] READ_VERSIONS = {
           ReadV00,
       };
       private static readonly EncodeDelegate<FetchSnapshotRequest>[] WRITE_VERSIONS = {
           WriteV00,
};
       public static (int Offset, FetchSnapshotRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, FetchSnapshotRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, FetchSnapshotRequest Value) ReadV00(byte[] buffer, int index)
       {
           var clusterIdField = default(string?);
           (index, var replicaIdField) = Decoder.ReadInt32(buffer, index);
           (index, var maxBytesField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadCompactArray<TopicSnapshot>(buffer, index, TopicSnapshotSerde.ReadV00);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               clusterIdField,
               replicaIdField,
               maxBytesField,
               topicsField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, FetchSnapshotRequest message)
       {
           index = Encoder.WriteCompactNullableString(buffer, index, message.ClusterIdField);
           index = Encoder.WriteInt32(buffer, index, message.ReplicaIdField);
           index = Encoder.WriteInt32(buffer, index, message.MaxBytesField);
           index = Encoder.WriteCompactArray<TopicSnapshot>(buffer, index, message.TopicsField, TopicSnapshotSerde.WriteV00);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class TopicSnapshotSerde
       {
           public static (int Offset, TopicSnapshot Value) ReadV00(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               (index, var partitionsField) = Decoder.ReadCompactArray<PartitionSnapshot>(buffer, index, PartitionSnapshotSerde.ReadV00);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV00(byte[] buffer, int index, TopicSnapshot message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteCompactArray<PartitionSnapshot>(buffer, index, message.PartitionsField, PartitionSnapshotSerde.WriteV00);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class PartitionSnapshotSerde
           {
               public static (int Offset, PartitionSnapshot Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var partitionField) = Decoder.ReadInt32(buffer, index);
                   (index, var currentLeaderEpochField) = Decoder.ReadInt32(buffer, index);
                   (index, var snapshotIdField) = SnapshotIdSerde.ReadV00(buffer, index);
                   (index, var positionField) = Decoder.ReadInt64(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       partitionField,
                       currentLeaderEpochField,
                       snapshotIdField,
                       positionField
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, PartitionSnapshot message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionField);
                   index = Encoder.WriteInt32(buffer, index, message.CurrentLeaderEpochField);
                   index = SnapshotIdSerde.WriteV00(buffer, index, message.SnapshotIdField);
                   index = Encoder.WriteInt64(buffer, index, message.PositionField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
               [GeneratedCode("kgen", "1.0.0.0")]
               private static class SnapshotIdSerde
               {
                   public static (int Offset, SnapshotId Value) ReadV00(byte[] buffer, int index)
                   {
                       (index, var endOffsetField) = Decoder.ReadInt64(buffer, index);
                       (index, var epochField) = Decoder.ReadInt32(buffer, index);
                       (index, _) = Decoder.ReadVarUInt32(buffer, index);
                       return (index, new(
                           endOffsetField,
                           epochField
                       ));
                   }
                   public static int WriteV00(byte[] buffer, int index, SnapshotId message)
                   {
                       index = Encoder.WriteInt64(buffer, index, message.EndOffsetField);
                       index = Encoder.WriteInt32(buffer, index, message.EpochField);
                       index = Encoder.WriteVarUInt32(buffer, index, 0);
                       return index;
                   }
               }
           }
       }
   }
}