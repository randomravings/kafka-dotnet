using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using Kafka.Common.Records;
using LeaderIdAndEpoch = Kafka.Client.Messages.FetchSnapshotResponse.TopicSnapshot.PartitionSnapshot.LeaderIdAndEpoch;
using SnapshotId = Kafka.Client.Messages.FetchSnapshotResponse.TopicSnapshot.PartitionSnapshot.SnapshotId;
using TopicSnapshot = Kafka.Client.Messages.FetchSnapshotResponse.TopicSnapshot;
using PartitionSnapshot = Kafka.Client.Messages.FetchSnapshotResponse.TopicSnapshot.PartitionSnapshot;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class FetchSnapshotResponseSerde
   {
       private static readonly DecodeDelegate<FetchSnapshotResponse>[] READ_VERSIONS = {
           ReadV00,
       };
       private static readonly EncodeDelegate<FetchSnapshotResponse>[] WRITE_VERSIONS = {
           WriteV00,
};
       public static (int Offset, FetchSnapshotResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, FetchSnapshotResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, FetchSnapshotResponse Value) ReadV00(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var topicsField) = Decoder.ReadCompactArray<TopicSnapshot>(buffer, index, TopicSnapshotSerde.ReadV00);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               topicsField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, FetchSnapshotResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
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
                   (index, var indexField) = Decoder.ReadInt32(buffer, index);
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var snapshotIdField) = SnapshotIdSerde.ReadV00(buffer, index);
                   var currentLeaderField = LeaderIdAndEpoch.Empty;
                   (index, var sizeField) = Decoder.ReadInt64(buffer, index);
                   (index, var positionField) = Decoder.ReadInt64(buffer, index);
                   (index, var unalignedRecordsField) = Decoder.ReadRecords(buffer, index);
                   if (unalignedRecordsField == null)
                       throw new NullReferenceException("Null not allowed for 'UnalignedRecords'");
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       indexField,
                       errorCodeField,
                       snapshotIdField,
                       currentLeaderField,
                       sizeField,
                       positionField,
                       unalignedRecordsField.Value
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, PartitionSnapshot message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.IndexField);
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = SnapshotIdSerde.WriteV00(buffer, index, message.SnapshotIdField);
                   index = LeaderIdAndEpochSerde.WriteV00(buffer, index, message.CurrentLeaderField);
                   index = Encoder.WriteInt64(buffer, index, message.SizeField);
                   index = Encoder.WriteInt64(buffer, index, message.PositionField);
                   index = Encoder.WriteCompactRecords(buffer, index, message.UnalignedRecordsField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
               [GeneratedCode("kgen", "1.0.0.0")]
               private static class LeaderIdAndEpochSerde
               {
                   public static (int Offset, LeaderIdAndEpoch Value) ReadV00(byte[] buffer, int index)
                   {
                       (index, var leaderIdField) = Decoder.ReadInt32(buffer, index);
                       (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
                       (index, _) = Decoder.ReadVarUInt32(buffer, index);
                       return (index, new(
                           leaderIdField,
                           leaderEpochField
                       ));
                   }
                   public static int WriteV00(byte[] buffer, int index, LeaderIdAndEpoch message)
                   {
                       index = Encoder.WriteInt32(buffer, index, message.LeaderIdField);
                       index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                       index = Encoder.WriteVarUInt32(buffer, index, 0);
                       return index;
                   }
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