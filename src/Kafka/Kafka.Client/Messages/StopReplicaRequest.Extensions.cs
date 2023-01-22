using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using StopReplicaPartitionV0 = Kafka.Client.Messages.StopReplicaRequest.StopReplicaPartitionV0;
using StopReplicaTopicState = Kafka.Client.Messages.StopReplicaRequest.StopReplicaTopicState;
using StopReplicaPartitionState = Kafka.Client.Messages.StopReplicaRequest.StopReplicaTopicState.StopReplicaPartitionState;
using StopReplicaTopicV1 = Kafka.Client.Messages.StopReplicaRequest.StopReplicaTopicV1;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class StopReplicaRequestSerde
   {
       private static readonly DecodeDelegate<StopReplicaRequest>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
           ReadV04,
       };
       private static readonly EncodeDelegate<StopReplicaRequest>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
           WriteV04,
};
       public static (int Offset, StopReplicaRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, StopReplicaRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, StopReplicaRequest Value) ReadV00(byte[] buffer, int index)
       {
           (index, var controllerIdField) = Decoder.ReadInt32(buffer, index);
           var kRaftControllerIdField = default(int);
           (index, var controllerEpochField) = Decoder.ReadInt32(buffer, index);
           var brokerEpochField = default(long);
           (index, var deletePartitionsField) = Decoder.ReadBoolean(buffer, index);
           (index, var ungroupedPartitionsField) = Decoder.ReadArray<StopReplicaPartitionV0>(buffer, index, StopReplicaPartitionV0Serde.ReadV00);
           if (ungroupedPartitionsField == null)
               throw new NullReferenceException("Null not allowed for 'UngroupedPartitions'");
           var topicsField = ImmutableArray<StopReplicaTopicV1>.Empty;
           var topicStatesField = ImmutableArray<StopReplicaTopicState>.Empty;
           return (index, new(
               controllerIdField,
               kRaftControllerIdField,
               controllerEpochField,
               brokerEpochField,
               deletePartitionsField,
               ungroupedPartitionsField.Value,
               topicsField,
               topicStatesField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, StopReplicaRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
           index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
           index = Encoder.WriteBoolean(buffer, index, message.DeletePartitionsField);
           index = Encoder.WriteArray<StopReplicaPartitionV0>(buffer, index, message.UngroupedPartitionsField, StopReplicaPartitionV0Serde.WriteV00);
           return index;
       }
       private static (int Offset, StopReplicaRequest Value) ReadV01(byte[] buffer, int index)
       {
           (index, var controllerIdField) = Decoder.ReadInt32(buffer, index);
           var kRaftControllerIdField = default(int);
           (index, var controllerEpochField) = Decoder.ReadInt32(buffer, index);
           (index, var brokerEpochField) = Decoder.ReadInt64(buffer, index);
           (index, var deletePartitionsField) = Decoder.ReadBoolean(buffer, index);
           var ungroupedPartitionsField = ImmutableArray<StopReplicaPartitionV0>.Empty;
           (index, var topicsField) = Decoder.ReadArray<StopReplicaTopicV1>(buffer, index, StopReplicaTopicV1Serde.ReadV01);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           var topicStatesField = ImmutableArray<StopReplicaTopicState>.Empty;
           return (index, new(
               controllerIdField,
               kRaftControllerIdField,
               controllerEpochField,
               brokerEpochField,
               deletePartitionsField,
               ungroupedPartitionsField,
               topicsField.Value,
               topicStatesField
           ));
       }
       private static int WriteV01(byte[] buffer, int index, StopReplicaRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
           index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
           index = Encoder.WriteInt64(buffer, index, message.BrokerEpochField);
           index = Encoder.WriteBoolean(buffer, index, message.DeletePartitionsField);
           index = Encoder.WriteArray<StopReplicaTopicV1>(buffer, index, message.TopicsField, StopReplicaTopicV1Serde.WriteV01);
           return index;
       }
       private static (int Offset, StopReplicaRequest Value) ReadV02(byte[] buffer, int index)
       {
           (index, var controllerIdField) = Decoder.ReadInt32(buffer, index);
           var kRaftControllerIdField = default(int);
           (index, var controllerEpochField) = Decoder.ReadInt32(buffer, index);
           (index, var brokerEpochField) = Decoder.ReadInt64(buffer, index);
           (index, var deletePartitionsField) = Decoder.ReadBoolean(buffer, index);
           var ungroupedPartitionsField = ImmutableArray<StopReplicaPartitionV0>.Empty;
           (index, var topicsField) = Decoder.ReadCompactArray<StopReplicaTopicV1>(buffer, index, StopReplicaTopicV1Serde.ReadV02);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           var topicStatesField = ImmutableArray<StopReplicaTopicState>.Empty;
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               controllerIdField,
               kRaftControllerIdField,
               controllerEpochField,
               brokerEpochField,
               deletePartitionsField,
               ungroupedPartitionsField,
               topicsField.Value,
               topicStatesField
           ));
       }
       private static int WriteV02(byte[] buffer, int index, StopReplicaRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
           index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
           index = Encoder.WriteInt64(buffer, index, message.BrokerEpochField);
           index = Encoder.WriteBoolean(buffer, index, message.DeletePartitionsField);
           index = Encoder.WriteCompactArray<StopReplicaTopicV1>(buffer, index, message.TopicsField, StopReplicaTopicV1Serde.WriteV02);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, StopReplicaRequest Value) ReadV03(byte[] buffer, int index)
       {
           (index, var controllerIdField) = Decoder.ReadInt32(buffer, index);
           var kRaftControllerIdField = default(int);
           (index, var controllerEpochField) = Decoder.ReadInt32(buffer, index);
           (index, var brokerEpochField) = Decoder.ReadInt64(buffer, index);
           var deletePartitionsField = default(bool);
           var ungroupedPartitionsField = ImmutableArray<StopReplicaPartitionV0>.Empty;
           var topicsField = ImmutableArray<StopReplicaTopicV1>.Empty;
           (index, var topicStatesField) = Decoder.ReadCompactArray<StopReplicaTopicState>(buffer, index, StopReplicaTopicStateSerde.ReadV03);
           if (topicStatesField == null)
               throw new NullReferenceException("Null not allowed for 'TopicStates'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               controllerIdField,
               kRaftControllerIdField,
               controllerEpochField,
               brokerEpochField,
               deletePartitionsField,
               ungroupedPartitionsField,
               topicsField,
               topicStatesField.Value
           ));
       }
       private static int WriteV03(byte[] buffer, int index, StopReplicaRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
           index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
           index = Encoder.WriteInt64(buffer, index, message.BrokerEpochField);
           index = Encoder.WriteCompactArray<StopReplicaTopicState>(buffer, index, message.TopicStatesField, StopReplicaTopicStateSerde.WriteV03);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, StopReplicaRequest Value) ReadV04(byte[] buffer, int index)
       {
           (index, var controllerIdField) = Decoder.ReadInt32(buffer, index);
           (index, var kRaftControllerIdField) = Decoder.ReadInt32(buffer, index);
           (index, var controllerEpochField) = Decoder.ReadInt32(buffer, index);
           (index, var brokerEpochField) = Decoder.ReadInt64(buffer, index);
           var deletePartitionsField = default(bool);
           var ungroupedPartitionsField = ImmutableArray<StopReplicaPartitionV0>.Empty;
           var topicsField = ImmutableArray<StopReplicaTopicV1>.Empty;
           (index, var topicStatesField) = Decoder.ReadCompactArray<StopReplicaTopicState>(buffer, index, StopReplicaTopicStateSerde.ReadV04);
           if (topicStatesField == null)
               throw new NullReferenceException("Null not allowed for 'TopicStates'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               controllerIdField,
               kRaftControllerIdField,
               controllerEpochField,
               brokerEpochField,
               deletePartitionsField,
               ungroupedPartitionsField,
               topicsField,
               topicStatesField.Value
           ));
       }
       private static int WriteV04(byte[] buffer, int index, StopReplicaRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
           index = Encoder.WriteInt32(buffer, index, message.KRaftControllerIdField);
           index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
           index = Encoder.WriteInt64(buffer, index, message.BrokerEpochField);
           index = Encoder.WriteCompactArray<StopReplicaTopicState>(buffer, index, message.TopicStatesField, StopReplicaTopicStateSerde.WriteV04);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class StopReplicaPartitionV0Serde
       {
           public static (int Offset, StopReplicaPartitionV0 Value) ReadV00(byte[] buffer, int index)
           {
               (index, var topicNameField) = Decoder.ReadString(buffer, index);
               (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
               return (index, new(
                   topicNameField,
                   partitionIndexField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, StopReplicaPartitionV0 message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicNameField);
               index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
               return index;
           }
           public static (int Offset, StopReplicaPartitionV0 Value) ReadV01(byte[] buffer, int index)
           {
               var topicNameField = "";
               var partitionIndexField = default(int);
               return (index, new(
                   topicNameField,
                   partitionIndexField
               ));
           }
           public static int WriteV01(byte[] buffer, int index, StopReplicaPartitionV0 message)
           {
               return index;
           }
           public static (int Offset, StopReplicaPartitionV0 Value) ReadV02(byte[] buffer, int index)
           {
               var topicNameField = "";
               var partitionIndexField = default(int);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicNameField,
                   partitionIndexField
               ));
           }
           public static int WriteV02(byte[] buffer, int index, StopReplicaPartitionV0 message)
           {
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, StopReplicaPartitionV0 Value) ReadV03(byte[] buffer, int index)
           {
               var topicNameField = "";
               var partitionIndexField = default(int);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicNameField,
                   partitionIndexField
               ));
           }
           public static int WriteV03(byte[] buffer, int index, StopReplicaPartitionV0 message)
           {
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, StopReplicaPartitionV0 Value) ReadV04(byte[] buffer, int index)
           {
               var topicNameField = "";
               var partitionIndexField = default(int);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicNameField,
                   partitionIndexField
               ));
           }
           public static int WriteV04(byte[] buffer, int index, StopReplicaPartitionV0 message)
           {
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class StopReplicaTopicStateSerde
       {
           public static (int Offset, StopReplicaTopicState Value) ReadV00(byte[] buffer, int index)
           {
               var topicNameField = "";
               var partitionStatesField = ImmutableArray<StopReplicaPartitionState>.Empty;
               return (index, new(
                   topicNameField,
                   partitionStatesField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, StopReplicaTopicState message)
           {
               return index;
           }
           public static (int Offset, StopReplicaTopicState Value) ReadV01(byte[] buffer, int index)
           {
               var topicNameField = "";
               var partitionStatesField = ImmutableArray<StopReplicaPartitionState>.Empty;
               return (index, new(
                   topicNameField,
                   partitionStatesField
               ));
           }
           public static int WriteV01(byte[] buffer, int index, StopReplicaTopicState message)
           {
               return index;
           }
           public static (int Offset, StopReplicaTopicState Value) ReadV02(byte[] buffer, int index)
           {
               var topicNameField = "";
               var partitionStatesField = ImmutableArray<StopReplicaPartitionState>.Empty;
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicNameField,
                   partitionStatesField
               ));
           }
           public static int WriteV02(byte[] buffer, int index, StopReplicaTopicState message)
           {
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, StopReplicaTopicState Value) ReadV03(byte[] buffer, int index)
           {
               (index, var topicNameField) = Decoder.ReadCompactString(buffer, index);
               (index, var partitionStatesField) = Decoder.ReadCompactArray<StopReplicaPartitionState>(buffer, index, StopReplicaPartitionStateSerde.ReadV03);
               if (partitionStatesField == null)
                   throw new NullReferenceException("Null not allowed for 'PartitionStates'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicNameField,
                   partitionStatesField.Value
               ));
           }
           public static int WriteV03(byte[] buffer, int index, StopReplicaTopicState message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.TopicNameField);
               index = Encoder.WriteCompactArray<StopReplicaPartitionState>(buffer, index, message.PartitionStatesField, StopReplicaPartitionStateSerde.WriteV03);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, StopReplicaTopicState Value) ReadV04(byte[] buffer, int index)
           {
               (index, var topicNameField) = Decoder.ReadCompactString(buffer, index);
               (index, var partitionStatesField) = Decoder.ReadCompactArray<StopReplicaPartitionState>(buffer, index, StopReplicaPartitionStateSerde.ReadV04);
               if (partitionStatesField == null)
                   throw new NullReferenceException("Null not allowed for 'PartitionStates'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicNameField,
                   partitionStatesField.Value
               ));
           }
           public static int WriteV04(byte[] buffer, int index, StopReplicaTopicState message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.TopicNameField);
               index = Encoder.WriteCompactArray<StopReplicaPartitionState>(buffer, index, message.PartitionStatesField, StopReplicaPartitionStateSerde.WriteV04);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class StopReplicaPartitionStateSerde
           {
               public static (int Offset, StopReplicaPartitionState Value) ReadV00(byte[] buffer, int index)
               {
                   var partitionIndexField = default(int);
                   var leaderEpochField = default(int);
                   var deletePartitionField = default(bool);
                   return (index, new(
                       partitionIndexField,
                       leaderEpochField,
                       deletePartitionField
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, StopReplicaPartitionState message)
               {
                   return index;
               }
               public static (int Offset, StopReplicaPartitionState Value) ReadV01(byte[] buffer, int index)
               {
                   var partitionIndexField = default(int);
                   var leaderEpochField = default(int);
                   var deletePartitionField = default(bool);
                   return (index, new(
                       partitionIndexField,
                       leaderEpochField,
                       deletePartitionField
                   ));
               }
               public static int WriteV01(byte[] buffer, int index, StopReplicaPartitionState message)
               {
                   return index;
               }
               public static (int Offset, StopReplicaPartitionState Value) ReadV02(byte[] buffer, int index)
               {
                   var partitionIndexField = default(int);
                   var leaderEpochField = default(int);
                   var deletePartitionField = default(bool);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       leaderEpochField,
                       deletePartitionField
                   ));
               }
               public static int WriteV02(byte[] buffer, int index, StopReplicaPartitionState message)
               {
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
               public static (int Offset, StopReplicaPartitionState Value) ReadV03(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
                   (index, var deletePartitionField) = Decoder.ReadBoolean(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       leaderEpochField,
                       deletePartitionField
                   ));
               }
               public static int WriteV03(byte[] buffer, int index, StopReplicaPartitionState message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                   index = Encoder.WriteBoolean(buffer, index, message.DeletePartitionField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
               public static (int Offset, StopReplicaPartitionState Value) ReadV04(byte[] buffer, int index)
               {
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
                   (index, var deletePartitionField) = Decoder.ReadBoolean(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       partitionIndexField,
                       leaderEpochField,
                       deletePartitionField
                   ));
               }
               public static int WriteV04(byte[] buffer, int index, StopReplicaPartitionState message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                   index = Encoder.WriteBoolean(buffer, index, message.DeletePartitionField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
           }
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class StopReplicaTopicV1Serde
       {
           public static (int Offset, StopReplicaTopicV1 Value) ReadV00(byte[] buffer, int index)
           {
               var nameField = "";
               var partitionIndexesField = ImmutableArray<int>.Empty;
               return (index, new(
                   nameField,
                   partitionIndexesField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, StopReplicaTopicV1 message)
           {
               return index;
           }
           public static (int Offset, StopReplicaTopicV1 Value) ReadV01(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionIndexesField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
               if (partitionIndexesField == null)
                   throw new NullReferenceException("Null not allowed for 'PartitionIndexes'");
               return (index, new(
                   nameField,
                   partitionIndexesField.Value
               ));
           }
           public static int WriteV01(byte[] buffer, int index, StopReplicaTopicV1 message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<int>(buffer, index, message.PartitionIndexesField, Encoder.WriteInt32);
               return index;
           }
           public static (int Offset, StopReplicaTopicV1 Value) ReadV02(byte[] buffer, int index)
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
           public static int WriteV02(byte[] buffer, int index, StopReplicaTopicV1 message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteCompactArray<int>(buffer, index, message.PartitionIndexesField, Encoder.WriteInt32);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, StopReplicaTopicV1 Value) ReadV03(byte[] buffer, int index)
           {
               var nameField = "";
               var partitionIndexesField = ImmutableArray<int>.Empty;
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   partitionIndexesField
               ));
           }
           public static int WriteV03(byte[] buffer, int index, StopReplicaTopicV1 message)
           {
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, StopReplicaTopicV1 Value) ReadV04(byte[] buffer, int index)
           {
               var nameField = "";
               var partitionIndexesField = ImmutableArray<int>.Empty;
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   partitionIndexesField
               ));
           }
           public static int WriteV04(byte[] buffer, int index, StopReplicaTopicV1 message)
           {
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
   }
}