using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using LeaderAndIsrPartitionState = Kafka.Client.Messages.LeaderAndIsrRequest.LeaderAndIsrPartitionState;
using LeaderAndIsrLiveLeader = Kafka.Client.Messages.LeaderAndIsrRequest.LeaderAndIsrLiveLeader;
using LeaderAndIsrTopicState = Kafka.Client.Messages.LeaderAndIsrRequest.LeaderAndIsrTopicState;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class LeaderAndIsrRequestSerde
   {
       private static readonly DecodeDelegate<LeaderAndIsrRequest>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
           ReadV04,
           ReadV05,
           ReadV06,
           ReadV07,
       };
       private static readonly EncodeDelegate<LeaderAndIsrRequest>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
           WriteV04,
           WriteV05,
           WriteV06,
           WriteV07,
};
       public static (int Offset, LeaderAndIsrRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, LeaderAndIsrRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, LeaderAndIsrRequest Value) ReadV00(byte[] buffer, int index)
       {
           (index, var controllerIdField) = Decoder.ReadInt32(buffer, index);
           var kRaftControllerIdField = default(int);
           (index, var controllerEpochField) = Decoder.ReadInt32(buffer, index);
           var brokerEpochField = default(long);
           var typeField = default(sbyte);
           (index, var ungroupedPartitionStatesField) = Decoder.ReadArray<LeaderAndIsrPartitionState>(buffer, index, LeaderAndIsrPartitionStateSerde.ReadV00);
           if (ungroupedPartitionStatesField == null)
               throw new NullReferenceException("Null not allowed for 'UngroupedPartitionStates'");
           var topicStatesField = ImmutableArray<LeaderAndIsrTopicState>.Empty;
           (index, var liveLeadersField) = Decoder.ReadArray<LeaderAndIsrLiveLeader>(buffer, index, LeaderAndIsrLiveLeaderSerde.ReadV00);
           if (liveLeadersField == null)
               throw new NullReferenceException("Null not allowed for 'LiveLeaders'");
           return (index, new(
               controllerIdField,
               kRaftControllerIdField,
               controllerEpochField,
               brokerEpochField,
               typeField,
               ungroupedPartitionStatesField.Value,
               topicStatesField,
               liveLeadersField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, LeaderAndIsrRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
           index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
           index = Encoder.WriteArray<LeaderAndIsrPartitionState>(buffer, index, message.UngroupedPartitionStatesField, LeaderAndIsrPartitionStateSerde.WriteV00);
           index = Encoder.WriteArray<LeaderAndIsrLiveLeader>(buffer, index, message.LiveLeadersField, LeaderAndIsrLiveLeaderSerde.WriteV00);
           return index;
       }
       private static (int Offset, LeaderAndIsrRequest Value) ReadV01(byte[] buffer, int index)
       {
           (index, var controllerIdField) = Decoder.ReadInt32(buffer, index);
           var kRaftControllerIdField = default(int);
           (index, var controllerEpochField) = Decoder.ReadInt32(buffer, index);
           var brokerEpochField = default(long);
           var typeField = default(sbyte);
           (index, var ungroupedPartitionStatesField) = Decoder.ReadArray<LeaderAndIsrPartitionState>(buffer, index, LeaderAndIsrPartitionStateSerde.ReadV01);
           if (ungroupedPartitionStatesField == null)
               throw new NullReferenceException("Null not allowed for 'UngroupedPartitionStates'");
           var topicStatesField = ImmutableArray<LeaderAndIsrTopicState>.Empty;
           (index, var liveLeadersField) = Decoder.ReadArray<LeaderAndIsrLiveLeader>(buffer, index, LeaderAndIsrLiveLeaderSerde.ReadV01);
           if (liveLeadersField == null)
               throw new NullReferenceException("Null not allowed for 'LiveLeaders'");
           return (index, new(
               controllerIdField,
               kRaftControllerIdField,
               controllerEpochField,
               brokerEpochField,
               typeField,
               ungroupedPartitionStatesField.Value,
               topicStatesField,
               liveLeadersField.Value
           ));
       }
       private static int WriteV01(byte[] buffer, int index, LeaderAndIsrRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
           index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
           index = Encoder.WriteArray<LeaderAndIsrPartitionState>(buffer, index, message.UngroupedPartitionStatesField, LeaderAndIsrPartitionStateSerde.WriteV01);
           index = Encoder.WriteArray<LeaderAndIsrLiveLeader>(buffer, index, message.LiveLeadersField, LeaderAndIsrLiveLeaderSerde.WriteV01);
           return index;
       }
       private static (int Offset, LeaderAndIsrRequest Value) ReadV02(byte[] buffer, int index)
       {
           (index, var controllerIdField) = Decoder.ReadInt32(buffer, index);
           var kRaftControllerIdField = default(int);
           (index, var controllerEpochField) = Decoder.ReadInt32(buffer, index);
           (index, var brokerEpochField) = Decoder.ReadInt64(buffer, index);
           var typeField = default(sbyte);
           var ungroupedPartitionStatesField = ImmutableArray<LeaderAndIsrPartitionState>.Empty;
           (index, var topicStatesField) = Decoder.ReadArray<LeaderAndIsrTopicState>(buffer, index, LeaderAndIsrTopicStateSerde.ReadV02);
           if (topicStatesField == null)
               throw new NullReferenceException("Null not allowed for 'TopicStates'");
           (index, var liveLeadersField) = Decoder.ReadArray<LeaderAndIsrLiveLeader>(buffer, index, LeaderAndIsrLiveLeaderSerde.ReadV02);
           if (liveLeadersField == null)
               throw new NullReferenceException("Null not allowed for 'LiveLeaders'");
           return (index, new(
               controllerIdField,
               kRaftControllerIdField,
               controllerEpochField,
               brokerEpochField,
               typeField,
               ungroupedPartitionStatesField,
               topicStatesField.Value,
               liveLeadersField.Value
           ));
       }
       private static int WriteV02(byte[] buffer, int index, LeaderAndIsrRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
           index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
           index = Encoder.WriteInt64(buffer, index, message.BrokerEpochField);
           index = Encoder.WriteArray<LeaderAndIsrTopicState>(buffer, index, message.TopicStatesField, LeaderAndIsrTopicStateSerde.WriteV02);
           index = Encoder.WriteArray<LeaderAndIsrLiveLeader>(buffer, index, message.LiveLeadersField, LeaderAndIsrLiveLeaderSerde.WriteV02);
           return index;
       }
       private static (int Offset, LeaderAndIsrRequest Value) ReadV03(byte[] buffer, int index)
       {
           (index, var controllerIdField) = Decoder.ReadInt32(buffer, index);
           var kRaftControllerIdField = default(int);
           (index, var controllerEpochField) = Decoder.ReadInt32(buffer, index);
           (index, var brokerEpochField) = Decoder.ReadInt64(buffer, index);
           var typeField = default(sbyte);
           var ungroupedPartitionStatesField = ImmutableArray<LeaderAndIsrPartitionState>.Empty;
           (index, var topicStatesField) = Decoder.ReadArray<LeaderAndIsrTopicState>(buffer, index, LeaderAndIsrTopicStateSerde.ReadV03);
           if (topicStatesField == null)
               throw new NullReferenceException("Null not allowed for 'TopicStates'");
           (index, var liveLeadersField) = Decoder.ReadArray<LeaderAndIsrLiveLeader>(buffer, index, LeaderAndIsrLiveLeaderSerde.ReadV03);
           if (liveLeadersField == null)
               throw new NullReferenceException("Null not allowed for 'LiveLeaders'");
           return (index, new(
               controllerIdField,
               kRaftControllerIdField,
               controllerEpochField,
               brokerEpochField,
               typeField,
               ungroupedPartitionStatesField,
               topicStatesField.Value,
               liveLeadersField.Value
           ));
       }
       private static int WriteV03(byte[] buffer, int index, LeaderAndIsrRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
           index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
           index = Encoder.WriteInt64(buffer, index, message.BrokerEpochField);
           index = Encoder.WriteArray<LeaderAndIsrTopicState>(buffer, index, message.TopicStatesField, LeaderAndIsrTopicStateSerde.WriteV03);
           index = Encoder.WriteArray<LeaderAndIsrLiveLeader>(buffer, index, message.LiveLeadersField, LeaderAndIsrLiveLeaderSerde.WriteV03);
           return index;
       }
       private static (int Offset, LeaderAndIsrRequest Value) ReadV04(byte[] buffer, int index)
       {
           (index, var controllerIdField) = Decoder.ReadInt32(buffer, index);
           var kRaftControllerIdField = default(int);
           (index, var controllerEpochField) = Decoder.ReadInt32(buffer, index);
           (index, var brokerEpochField) = Decoder.ReadInt64(buffer, index);
           var typeField = default(sbyte);
           var ungroupedPartitionStatesField = ImmutableArray<LeaderAndIsrPartitionState>.Empty;
           (index, var topicStatesField) = Decoder.ReadCompactArray<LeaderAndIsrTopicState>(buffer, index, LeaderAndIsrTopicStateSerde.ReadV04);
           if (topicStatesField == null)
               throw new NullReferenceException("Null not allowed for 'TopicStates'");
           (index, var liveLeadersField) = Decoder.ReadCompactArray<LeaderAndIsrLiveLeader>(buffer, index, LeaderAndIsrLiveLeaderSerde.ReadV04);
           if (liveLeadersField == null)
               throw new NullReferenceException("Null not allowed for 'LiveLeaders'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               controllerIdField,
               kRaftControllerIdField,
               controllerEpochField,
               brokerEpochField,
               typeField,
               ungroupedPartitionStatesField,
               topicStatesField.Value,
               liveLeadersField.Value
           ));
       }
       private static int WriteV04(byte[] buffer, int index, LeaderAndIsrRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
           index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
           index = Encoder.WriteInt64(buffer, index, message.BrokerEpochField);
           index = Encoder.WriteCompactArray<LeaderAndIsrTopicState>(buffer, index, message.TopicStatesField, LeaderAndIsrTopicStateSerde.WriteV04);
           index = Encoder.WriteCompactArray<LeaderAndIsrLiveLeader>(buffer, index, message.LiveLeadersField, LeaderAndIsrLiveLeaderSerde.WriteV04);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, LeaderAndIsrRequest Value) ReadV05(byte[] buffer, int index)
       {
           (index, var controllerIdField) = Decoder.ReadInt32(buffer, index);
           var kRaftControllerIdField = default(int);
           (index, var controllerEpochField) = Decoder.ReadInt32(buffer, index);
           (index, var brokerEpochField) = Decoder.ReadInt64(buffer, index);
           (index, var typeField) = Decoder.ReadInt8(buffer, index);
           var ungroupedPartitionStatesField = ImmutableArray<LeaderAndIsrPartitionState>.Empty;
           (index, var topicStatesField) = Decoder.ReadCompactArray<LeaderAndIsrTopicState>(buffer, index, LeaderAndIsrTopicStateSerde.ReadV05);
           if (topicStatesField == null)
               throw new NullReferenceException("Null not allowed for 'TopicStates'");
           (index, var liveLeadersField) = Decoder.ReadCompactArray<LeaderAndIsrLiveLeader>(buffer, index, LeaderAndIsrLiveLeaderSerde.ReadV05);
           if (liveLeadersField == null)
               throw new NullReferenceException("Null not allowed for 'LiveLeaders'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               controllerIdField,
               kRaftControllerIdField,
               controllerEpochField,
               brokerEpochField,
               typeField,
               ungroupedPartitionStatesField,
               topicStatesField.Value,
               liveLeadersField.Value
           ));
       }
       private static int WriteV05(byte[] buffer, int index, LeaderAndIsrRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
           index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
           index = Encoder.WriteInt64(buffer, index, message.BrokerEpochField);
           index = Encoder.WriteInt8(buffer, index, message.TypeField);
           index = Encoder.WriteCompactArray<LeaderAndIsrTopicState>(buffer, index, message.TopicStatesField, LeaderAndIsrTopicStateSerde.WriteV05);
           index = Encoder.WriteCompactArray<LeaderAndIsrLiveLeader>(buffer, index, message.LiveLeadersField, LeaderAndIsrLiveLeaderSerde.WriteV05);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, LeaderAndIsrRequest Value) ReadV06(byte[] buffer, int index)
       {
           (index, var controllerIdField) = Decoder.ReadInt32(buffer, index);
           var kRaftControllerIdField = default(int);
           (index, var controllerEpochField) = Decoder.ReadInt32(buffer, index);
           (index, var brokerEpochField) = Decoder.ReadInt64(buffer, index);
           (index, var typeField) = Decoder.ReadInt8(buffer, index);
           var ungroupedPartitionStatesField = ImmutableArray<LeaderAndIsrPartitionState>.Empty;
           (index, var topicStatesField) = Decoder.ReadCompactArray<LeaderAndIsrTopicState>(buffer, index, LeaderAndIsrTopicStateSerde.ReadV06);
           if (topicStatesField == null)
               throw new NullReferenceException("Null not allowed for 'TopicStates'");
           (index, var liveLeadersField) = Decoder.ReadCompactArray<LeaderAndIsrLiveLeader>(buffer, index, LeaderAndIsrLiveLeaderSerde.ReadV06);
           if (liveLeadersField == null)
               throw new NullReferenceException("Null not allowed for 'LiveLeaders'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               controllerIdField,
               kRaftControllerIdField,
               controllerEpochField,
               brokerEpochField,
               typeField,
               ungroupedPartitionStatesField,
               topicStatesField.Value,
               liveLeadersField.Value
           ));
       }
       private static int WriteV06(byte[] buffer, int index, LeaderAndIsrRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
           index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
           index = Encoder.WriteInt64(buffer, index, message.BrokerEpochField);
           index = Encoder.WriteInt8(buffer, index, message.TypeField);
           index = Encoder.WriteCompactArray<LeaderAndIsrTopicState>(buffer, index, message.TopicStatesField, LeaderAndIsrTopicStateSerde.WriteV06);
           index = Encoder.WriteCompactArray<LeaderAndIsrLiveLeader>(buffer, index, message.LiveLeadersField, LeaderAndIsrLiveLeaderSerde.WriteV06);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, LeaderAndIsrRequest Value) ReadV07(byte[] buffer, int index)
       {
           (index, var controllerIdField) = Decoder.ReadInt32(buffer, index);
           (index, var kRaftControllerIdField) = Decoder.ReadInt32(buffer, index);
           (index, var controllerEpochField) = Decoder.ReadInt32(buffer, index);
           (index, var brokerEpochField) = Decoder.ReadInt64(buffer, index);
           (index, var typeField) = Decoder.ReadInt8(buffer, index);
           var ungroupedPartitionStatesField = ImmutableArray<LeaderAndIsrPartitionState>.Empty;
           (index, var topicStatesField) = Decoder.ReadCompactArray<LeaderAndIsrTopicState>(buffer, index, LeaderAndIsrTopicStateSerde.ReadV07);
           if (topicStatesField == null)
               throw new NullReferenceException("Null not allowed for 'TopicStates'");
           (index, var liveLeadersField) = Decoder.ReadCompactArray<LeaderAndIsrLiveLeader>(buffer, index, LeaderAndIsrLiveLeaderSerde.ReadV07);
           if (liveLeadersField == null)
               throw new NullReferenceException("Null not allowed for 'LiveLeaders'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               controllerIdField,
               kRaftControllerIdField,
               controllerEpochField,
               brokerEpochField,
               typeField,
               ungroupedPartitionStatesField,
               topicStatesField.Value,
               liveLeadersField.Value
           ));
       }
       private static int WriteV07(byte[] buffer, int index, LeaderAndIsrRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
           index = Encoder.WriteInt32(buffer, index, message.KRaftControllerIdField);
           index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
           index = Encoder.WriteInt64(buffer, index, message.BrokerEpochField);
           index = Encoder.WriteInt8(buffer, index, message.TypeField);
           index = Encoder.WriteCompactArray<LeaderAndIsrTopicState>(buffer, index, message.TopicStatesField, LeaderAndIsrTopicStateSerde.WriteV07);
           index = Encoder.WriteCompactArray<LeaderAndIsrLiveLeader>(buffer, index, message.LiveLeadersField, LeaderAndIsrLiveLeaderSerde.WriteV07);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class LeaderAndIsrPartitionStateSerde
       {
           public static (int Offset, LeaderAndIsrPartitionState Value) ReadV00(byte[] buffer, int index)
           {
               (index, var topicNameField) = Decoder.ReadString(buffer, index);
               (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
               (index, var controllerEpochField) = Decoder.ReadInt32(buffer, index);
               (index, var leaderField) = Decoder.ReadInt32(buffer, index);
               (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
               (index, var isrField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
               if (isrField == null)
                   throw new NullReferenceException("Null not allowed for 'Isr'");
               (index, var partitionEpochField) = Decoder.ReadInt32(buffer, index);
               (index, var replicasField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
               if (replicasField == null)
                   throw new NullReferenceException("Null not allowed for 'Replicas'");
               var addingReplicasField = ImmutableArray<int>.Empty;
               var removingReplicasField = ImmutableArray<int>.Empty;
               var isNewField = default(bool);
               var leaderRecoveryStateField = default(sbyte);
               return (index, new(
                   topicNameField,
                   partitionIndexField,
                   controllerEpochField,
                   leaderField,
                   leaderEpochField,
                   isrField.Value,
                   partitionEpochField,
                   replicasField.Value,
                   addingReplicasField,
                   removingReplicasField,
                   isNewField,
                   leaderRecoveryStateField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, LeaderAndIsrPartitionState message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicNameField);
               index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
               index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
               index = Encoder.WriteInt32(buffer, index, message.LeaderField);
               index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
               index = Encoder.WriteArray<int>(buffer, index, message.IsrField, Encoder.WriteInt32);
               index = Encoder.WriteInt32(buffer, index, message.PartitionEpochField);
               index = Encoder.WriteArray<int>(buffer, index, message.ReplicasField, Encoder.WriteInt32);
               return index;
           }
           public static (int Offset, LeaderAndIsrPartitionState Value) ReadV01(byte[] buffer, int index)
           {
               (index, var topicNameField) = Decoder.ReadString(buffer, index);
               (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
               (index, var controllerEpochField) = Decoder.ReadInt32(buffer, index);
               (index, var leaderField) = Decoder.ReadInt32(buffer, index);
               (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
               (index, var isrField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
               if (isrField == null)
                   throw new NullReferenceException("Null not allowed for 'Isr'");
               (index, var partitionEpochField) = Decoder.ReadInt32(buffer, index);
               (index, var replicasField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
               if (replicasField == null)
                   throw new NullReferenceException("Null not allowed for 'Replicas'");
               var addingReplicasField = ImmutableArray<int>.Empty;
               var removingReplicasField = ImmutableArray<int>.Empty;
               (index, var isNewField) = Decoder.ReadBoolean(buffer, index);
               var leaderRecoveryStateField = default(sbyte);
               return (index, new(
                   topicNameField,
                   partitionIndexField,
                   controllerEpochField,
                   leaderField,
                   leaderEpochField,
                   isrField.Value,
                   partitionEpochField,
                   replicasField.Value,
                   addingReplicasField,
                   removingReplicasField,
                   isNewField,
                   leaderRecoveryStateField
               ));
           }
           public static int WriteV01(byte[] buffer, int index, LeaderAndIsrPartitionState message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicNameField);
               index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
               index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
               index = Encoder.WriteInt32(buffer, index, message.LeaderField);
               index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
               index = Encoder.WriteArray<int>(buffer, index, message.IsrField, Encoder.WriteInt32);
               index = Encoder.WriteInt32(buffer, index, message.PartitionEpochField);
               index = Encoder.WriteArray<int>(buffer, index, message.ReplicasField, Encoder.WriteInt32);
               index = Encoder.WriteBoolean(buffer, index, message.IsNewField);
               return index;
           }
           public static (int Offset, LeaderAndIsrPartitionState Value) ReadV02(byte[] buffer, int index)
           {
               var topicNameField = "";
               (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
               (index, var controllerEpochField) = Decoder.ReadInt32(buffer, index);
               (index, var leaderField) = Decoder.ReadInt32(buffer, index);
               (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
               (index, var isrField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
               if (isrField == null)
                   throw new NullReferenceException("Null not allowed for 'Isr'");
               (index, var partitionEpochField) = Decoder.ReadInt32(buffer, index);
               (index, var replicasField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
               if (replicasField == null)
                   throw new NullReferenceException("Null not allowed for 'Replicas'");
               var addingReplicasField = ImmutableArray<int>.Empty;
               var removingReplicasField = ImmutableArray<int>.Empty;
               (index, var isNewField) = Decoder.ReadBoolean(buffer, index);
               var leaderRecoveryStateField = default(sbyte);
               return (index, new(
                   topicNameField,
                   partitionIndexField,
                   controllerEpochField,
                   leaderField,
                   leaderEpochField,
                   isrField.Value,
                   partitionEpochField,
                   replicasField.Value,
                   addingReplicasField,
                   removingReplicasField,
                   isNewField,
                   leaderRecoveryStateField
               ));
           }
           public static int WriteV02(byte[] buffer, int index, LeaderAndIsrPartitionState message)
           {
               index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
               index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
               index = Encoder.WriteInt32(buffer, index, message.LeaderField);
               index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
               index = Encoder.WriteArray<int>(buffer, index, message.IsrField, Encoder.WriteInt32);
               index = Encoder.WriteInt32(buffer, index, message.PartitionEpochField);
               index = Encoder.WriteArray<int>(buffer, index, message.ReplicasField, Encoder.WriteInt32);
               index = Encoder.WriteBoolean(buffer, index, message.IsNewField);
               return index;
           }
           public static (int Offset, LeaderAndIsrPartitionState Value) ReadV03(byte[] buffer, int index)
           {
               var topicNameField = "";
               (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
               (index, var controllerEpochField) = Decoder.ReadInt32(buffer, index);
               (index, var leaderField) = Decoder.ReadInt32(buffer, index);
               (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
               (index, var isrField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
               if (isrField == null)
                   throw new NullReferenceException("Null not allowed for 'Isr'");
               (index, var partitionEpochField) = Decoder.ReadInt32(buffer, index);
               (index, var replicasField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
               if (replicasField == null)
                   throw new NullReferenceException("Null not allowed for 'Replicas'");
               (index, var addingReplicasField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
               if (addingReplicasField == null)
                   throw new NullReferenceException("Null not allowed for 'AddingReplicas'");
               (index, var removingReplicasField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
               if (removingReplicasField == null)
                   throw new NullReferenceException("Null not allowed for 'RemovingReplicas'");
               (index, var isNewField) = Decoder.ReadBoolean(buffer, index);
               var leaderRecoveryStateField = default(sbyte);
               return (index, new(
                   topicNameField,
                   partitionIndexField,
                   controllerEpochField,
                   leaderField,
                   leaderEpochField,
                   isrField.Value,
                   partitionEpochField,
                   replicasField.Value,
                   addingReplicasField.Value,
                   removingReplicasField.Value,
                   isNewField,
                   leaderRecoveryStateField
               ));
           }
           public static int WriteV03(byte[] buffer, int index, LeaderAndIsrPartitionState message)
           {
               index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
               index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
               index = Encoder.WriteInt32(buffer, index, message.LeaderField);
               index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
               index = Encoder.WriteArray<int>(buffer, index, message.IsrField, Encoder.WriteInt32);
               index = Encoder.WriteInt32(buffer, index, message.PartitionEpochField);
               index = Encoder.WriteArray<int>(buffer, index, message.ReplicasField, Encoder.WriteInt32);
               index = Encoder.WriteArray<int>(buffer, index, message.AddingReplicasField, Encoder.WriteInt32);
               index = Encoder.WriteArray<int>(buffer, index, message.RemovingReplicasField, Encoder.WriteInt32);
               index = Encoder.WriteBoolean(buffer, index, message.IsNewField);
               return index;
           }
           public static (int Offset, LeaderAndIsrPartitionState Value) ReadV04(byte[] buffer, int index)
           {
               var topicNameField = "";
               (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
               (index, var controllerEpochField) = Decoder.ReadInt32(buffer, index);
               (index, var leaderField) = Decoder.ReadInt32(buffer, index);
               (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
               (index, var isrField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
               if (isrField == null)
                   throw new NullReferenceException("Null not allowed for 'Isr'");
               (index, var partitionEpochField) = Decoder.ReadInt32(buffer, index);
               (index, var replicasField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
               if (replicasField == null)
                   throw new NullReferenceException("Null not allowed for 'Replicas'");
               (index, var addingReplicasField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
               if (addingReplicasField == null)
                   throw new NullReferenceException("Null not allowed for 'AddingReplicas'");
               (index, var removingReplicasField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
               if (removingReplicasField == null)
                   throw new NullReferenceException("Null not allowed for 'RemovingReplicas'");
               (index, var isNewField) = Decoder.ReadBoolean(buffer, index);
               var leaderRecoveryStateField = default(sbyte);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicNameField,
                   partitionIndexField,
                   controllerEpochField,
                   leaderField,
                   leaderEpochField,
                   isrField.Value,
                   partitionEpochField,
                   replicasField.Value,
                   addingReplicasField.Value,
                   removingReplicasField.Value,
                   isNewField,
                   leaderRecoveryStateField
               ));
           }
           public static int WriteV04(byte[] buffer, int index, LeaderAndIsrPartitionState message)
           {
               index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
               index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
               index = Encoder.WriteInt32(buffer, index, message.LeaderField);
               index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
               index = Encoder.WriteCompactArray<int>(buffer, index, message.IsrField, Encoder.WriteInt32);
               index = Encoder.WriteInt32(buffer, index, message.PartitionEpochField);
               index = Encoder.WriteCompactArray<int>(buffer, index, message.ReplicasField, Encoder.WriteInt32);
               index = Encoder.WriteCompactArray<int>(buffer, index, message.AddingReplicasField, Encoder.WriteInt32);
               index = Encoder.WriteCompactArray<int>(buffer, index, message.RemovingReplicasField, Encoder.WriteInt32);
               index = Encoder.WriteBoolean(buffer, index, message.IsNewField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, LeaderAndIsrPartitionState Value) ReadV05(byte[] buffer, int index)
           {
               var topicNameField = "";
               (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
               (index, var controllerEpochField) = Decoder.ReadInt32(buffer, index);
               (index, var leaderField) = Decoder.ReadInt32(buffer, index);
               (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
               (index, var isrField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
               if (isrField == null)
                   throw new NullReferenceException("Null not allowed for 'Isr'");
               (index, var partitionEpochField) = Decoder.ReadInt32(buffer, index);
               (index, var replicasField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
               if (replicasField == null)
                   throw new NullReferenceException("Null not allowed for 'Replicas'");
               (index, var addingReplicasField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
               if (addingReplicasField == null)
                   throw new NullReferenceException("Null not allowed for 'AddingReplicas'");
               (index, var removingReplicasField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
               if (removingReplicasField == null)
                   throw new NullReferenceException("Null not allowed for 'RemovingReplicas'");
               (index, var isNewField) = Decoder.ReadBoolean(buffer, index);
               var leaderRecoveryStateField = default(sbyte);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicNameField,
                   partitionIndexField,
                   controllerEpochField,
                   leaderField,
                   leaderEpochField,
                   isrField.Value,
                   partitionEpochField,
                   replicasField.Value,
                   addingReplicasField.Value,
                   removingReplicasField.Value,
                   isNewField,
                   leaderRecoveryStateField
               ));
           }
           public static int WriteV05(byte[] buffer, int index, LeaderAndIsrPartitionState message)
           {
               index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
               index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
               index = Encoder.WriteInt32(buffer, index, message.LeaderField);
               index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
               index = Encoder.WriteCompactArray<int>(buffer, index, message.IsrField, Encoder.WriteInt32);
               index = Encoder.WriteInt32(buffer, index, message.PartitionEpochField);
               index = Encoder.WriteCompactArray<int>(buffer, index, message.ReplicasField, Encoder.WriteInt32);
               index = Encoder.WriteCompactArray<int>(buffer, index, message.AddingReplicasField, Encoder.WriteInt32);
               index = Encoder.WriteCompactArray<int>(buffer, index, message.RemovingReplicasField, Encoder.WriteInt32);
               index = Encoder.WriteBoolean(buffer, index, message.IsNewField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, LeaderAndIsrPartitionState Value) ReadV06(byte[] buffer, int index)
           {
               var topicNameField = "";
               (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
               (index, var controllerEpochField) = Decoder.ReadInt32(buffer, index);
               (index, var leaderField) = Decoder.ReadInt32(buffer, index);
               (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
               (index, var isrField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
               if (isrField == null)
                   throw new NullReferenceException("Null not allowed for 'Isr'");
               (index, var partitionEpochField) = Decoder.ReadInt32(buffer, index);
               (index, var replicasField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
               if (replicasField == null)
                   throw new NullReferenceException("Null not allowed for 'Replicas'");
               (index, var addingReplicasField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
               if (addingReplicasField == null)
                   throw new NullReferenceException("Null not allowed for 'AddingReplicas'");
               (index, var removingReplicasField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
               if (removingReplicasField == null)
                   throw new NullReferenceException("Null not allowed for 'RemovingReplicas'");
               (index, var isNewField) = Decoder.ReadBoolean(buffer, index);
               (index, var leaderRecoveryStateField) = Decoder.ReadInt8(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicNameField,
                   partitionIndexField,
                   controllerEpochField,
                   leaderField,
                   leaderEpochField,
                   isrField.Value,
                   partitionEpochField,
                   replicasField.Value,
                   addingReplicasField.Value,
                   removingReplicasField.Value,
                   isNewField,
                   leaderRecoveryStateField
               ));
           }
           public static int WriteV06(byte[] buffer, int index, LeaderAndIsrPartitionState message)
           {
               index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
               index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
               index = Encoder.WriteInt32(buffer, index, message.LeaderField);
               index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
               index = Encoder.WriteCompactArray<int>(buffer, index, message.IsrField, Encoder.WriteInt32);
               index = Encoder.WriteInt32(buffer, index, message.PartitionEpochField);
               index = Encoder.WriteCompactArray<int>(buffer, index, message.ReplicasField, Encoder.WriteInt32);
               index = Encoder.WriteCompactArray<int>(buffer, index, message.AddingReplicasField, Encoder.WriteInt32);
               index = Encoder.WriteCompactArray<int>(buffer, index, message.RemovingReplicasField, Encoder.WriteInt32);
               index = Encoder.WriteBoolean(buffer, index, message.IsNewField);
               index = Encoder.WriteInt8(buffer, index, message.LeaderRecoveryStateField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, LeaderAndIsrPartitionState Value) ReadV07(byte[] buffer, int index)
           {
               var topicNameField = "";
               (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
               (index, var controllerEpochField) = Decoder.ReadInt32(buffer, index);
               (index, var leaderField) = Decoder.ReadInt32(buffer, index);
               (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
               (index, var isrField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
               if (isrField == null)
                   throw new NullReferenceException("Null not allowed for 'Isr'");
               (index, var partitionEpochField) = Decoder.ReadInt32(buffer, index);
               (index, var replicasField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
               if (replicasField == null)
                   throw new NullReferenceException("Null not allowed for 'Replicas'");
               (index, var addingReplicasField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
               if (addingReplicasField == null)
                   throw new NullReferenceException("Null not allowed for 'AddingReplicas'");
               (index, var removingReplicasField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
               if (removingReplicasField == null)
                   throw new NullReferenceException("Null not allowed for 'RemovingReplicas'");
               (index, var isNewField) = Decoder.ReadBoolean(buffer, index);
               (index, var leaderRecoveryStateField) = Decoder.ReadInt8(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicNameField,
                   partitionIndexField,
                   controllerEpochField,
                   leaderField,
                   leaderEpochField,
                   isrField.Value,
                   partitionEpochField,
                   replicasField.Value,
                   addingReplicasField.Value,
                   removingReplicasField.Value,
                   isNewField,
                   leaderRecoveryStateField
               ));
           }
           public static int WriteV07(byte[] buffer, int index, LeaderAndIsrPartitionState message)
           {
               index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
               index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
               index = Encoder.WriteInt32(buffer, index, message.LeaderField);
               index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
               index = Encoder.WriteCompactArray<int>(buffer, index, message.IsrField, Encoder.WriteInt32);
               index = Encoder.WriteInt32(buffer, index, message.PartitionEpochField);
               index = Encoder.WriteCompactArray<int>(buffer, index, message.ReplicasField, Encoder.WriteInt32);
               index = Encoder.WriteCompactArray<int>(buffer, index, message.AddingReplicasField, Encoder.WriteInt32);
               index = Encoder.WriteCompactArray<int>(buffer, index, message.RemovingReplicasField, Encoder.WriteInt32);
               index = Encoder.WriteBoolean(buffer, index, message.IsNewField);
               index = Encoder.WriteInt8(buffer, index, message.LeaderRecoveryStateField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class LeaderAndIsrLiveLeaderSerde
       {
           public static (int Offset, LeaderAndIsrLiveLeader Value) ReadV00(byte[] buffer, int index)
           {
               (index, var brokerIdField) = Decoder.ReadInt32(buffer, index);
               (index, var hostNameField) = Decoder.ReadString(buffer, index);
               (index, var portField) = Decoder.ReadInt32(buffer, index);
               return (index, new(
                   brokerIdField,
                   hostNameField,
                   portField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, LeaderAndIsrLiveLeader message)
           {
               index = Encoder.WriteInt32(buffer, index, message.BrokerIdField);
               index = Encoder.WriteString(buffer, index, message.HostNameField);
               index = Encoder.WriteInt32(buffer, index, message.PortField);
               return index;
           }
           public static (int Offset, LeaderAndIsrLiveLeader Value) ReadV01(byte[] buffer, int index)
           {
               (index, var brokerIdField) = Decoder.ReadInt32(buffer, index);
               (index, var hostNameField) = Decoder.ReadString(buffer, index);
               (index, var portField) = Decoder.ReadInt32(buffer, index);
               return (index, new(
                   brokerIdField,
                   hostNameField,
                   portField
               ));
           }
           public static int WriteV01(byte[] buffer, int index, LeaderAndIsrLiveLeader message)
           {
               index = Encoder.WriteInt32(buffer, index, message.BrokerIdField);
               index = Encoder.WriteString(buffer, index, message.HostNameField);
               index = Encoder.WriteInt32(buffer, index, message.PortField);
               return index;
           }
           public static (int Offset, LeaderAndIsrLiveLeader Value) ReadV02(byte[] buffer, int index)
           {
               (index, var brokerIdField) = Decoder.ReadInt32(buffer, index);
               (index, var hostNameField) = Decoder.ReadString(buffer, index);
               (index, var portField) = Decoder.ReadInt32(buffer, index);
               return (index, new(
                   brokerIdField,
                   hostNameField,
                   portField
               ));
           }
           public static int WriteV02(byte[] buffer, int index, LeaderAndIsrLiveLeader message)
           {
               index = Encoder.WriteInt32(buffer, index, message.BrokerIdField);
               index = Encoder.WriteString(buffer, index, message.HostNameField);
               index = Encoder.WriteInt32(buffer, index, message.PortField);
               return index;
           }
           public static (int Offset, LeaderAndIsrLiveLeader Value) ReadV03(byte[] buffer, int index)
           {
               (index, var brokerIdField) = Decoder.ReadInt32(buffer, index);
               (index, var hostNameField) = Decoder.ReadString(buffer, index);
               (index, var portField) = Decoder.ReadInt32(buffer, index);
               return (index, new(
                   brokerIdField,
                   hostNameField,
                   portField
               ));
           }
           public static int WriteV03(byte[] buffer, int index, LeaderAndIsrLiveLeader message)
           {
               index = Encoder.WriteInt32(buffer, index, message.BrokerIdField);
               index = Encoder.WriteString(buffer, index, message.HostNameField);
               index = Encoder.WriteInt32(buffer, index, message.PortField);
               return index;
           }
           public static (int Offset, LeaderAndIsrLiveLeader Value) ReadV04(byte[] buffer, int index)
           {
               (index, var brokerIdField) = Decoder.ReadInt32(buffer, index);
               (index, var hostNameField) = Decoder.ReadCompactString(buffer, index);
               (index, var portField) = Decoder.ReadInt32(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   brokerIdField,
                   hostNameField,
                   portField
               ));
           }
           public static int WriteV04(byte[] buffer, int index, LeaderAndIsrLiveLeader message)
           {
               index = Encoder.WriteInt32(buffer, index, message.BrokerIdField);
               index = Encoder.WriteCompactString(buffer, index, message.HostNameField);
               index = Encoder.WriteInt32(buffer, index, message.PortField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, LeaderAndIsrLiveLeader Value) ReadV05(byte[] buffer, int index)
           {
               (index, var brokerIdField) = Decoder.ReadInt32(buffer, index);
               (index, var hostNameField) = Decoder.ReadCompactString(buffer, index);
               (index, var portField) = Decoder.ReadInt32(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   brokerIdField,
                   hostNameField,
                   portField
               ));
           }
           public static int WriteV05(byte[] buffer, int index, LeaderAndIsrLiveLeader message)
           {
               index = Encoder.WriteInt32(buffer, index, message.BrokerIdField);
               index = Encoder.WriteCompactString(buffer, index, message.HostNameField);
               index = Encoder.WriteInt32(buffer, index, message.PortField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, LeaderAndIsrLiveLeader Value) ReadV06(byte[] buffer, int index)
           {
               (index, var brokerIdField) = Decoder.ReadInt32(buffer, index);
               (index, var hostNameField) = Decoder.ReadCompactString(buffer, index);
               (index, var portField) = Decoder.ReadInt32(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   brokerIdField,
                   hostNameField,
                   portField
               ));
           }
           public static int WriteV06(byte[] buffer, int index, LeaderAndIsrLiveLeader message)
           {
               index = Encoder.WriteInt32(buffer, index, message.BrokerIdField);
               index = Encoder.WriteCompactString(buffer, index, message.HostNameField);
               index = Encoder.WriteInt32(buffer, index, message.PortField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, LeaderAndIsrLiveLeader Value) ReadV07(byte[] buffer, int index)
           {
               (index, var brokerIdField) = Decoder.ReadInt32(buffer, index);
               (index, var hostNameField) = Decoder.ReadCompactString(buffer, index);
               (index, var portField) = Decoder.ReadInt32(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   brokerIdField,
                   hostNameField,
                   portField
               ));
           }
           public static int WriteV07(byte[] buffer, int index, LeaderAndIsrLiveLeader message)
           {
               index = Encoder.WriteInt32(buffer, index, message.BrokerIdField);
               index = Encoder.WriteCompactString(buffer, index, message.HostNameField);
               index = Encoder.WriteInt32(buffer, index, message.PortField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class LeaderAndIsrTopicStateSerde
       {
           public static (int Offset, LeaderAndIsrTopicState Value) ReadV00(byte[] buffer, int index)
           {
               var topicNameField = "";
               var topicIdField = default(Guid);
               var partitionStatesField = ImmutableArray<LeaderAndIsrPartitionState>.Empty;
               return (index, new(
                   topicNameField,
                   topicIdField,
                   partitionStatesField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, LeaderAndIsrTopicState message)
           {
               return index;
           }
           public static (int Offset, LeaderAndIsrTopicState Value) ReadV01(byte[] buffer, int index)
           {
               var topicNameField = "";
               var topicIdField = default(Guid);
               var partitionStatesField = ImmutableArray<LeaderAndIsrPartitionState>.Empty;
               return (index, new(
                   topicNameField,
                   topicIdField,
                   partitionStatesField
               ));
           }
           public static int WriteV01(byte[] buffer, int index, LeaderAndIsrTopicState message)
           {
               return index;
           }
           public static (int Offset, LeaderAndIsrTopicState Value) ReadV02(byte[] buffer, int index)
           {
               (index, var topicNameField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var partitionStatesField) = Decoder.ReadArray<LeaderAndIsrPartitionState>(buffer, index, LeaderAndIsrPartitionStateSerde.ReadV02);
               if (partitionStatesField == null)
                   throw new NullReferenceException("Null not allowed for 'PartitionStates'");
               return (index, new(
                   topicNameField,
                   topicIdField,
                   partitionStatesField.Value
               ));
           }
           public static int WriteV02(byte[] buffer, int index, LeaderAndIsrTopicState message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicNameField);
               index = Encoder.WriteArray<LeaderAndIsrPartitionState>(buffer, index, message.PartitionStatesField, LeaderAndIsrPartitionStateSerde.WriteV02);
               return index;
           }
           public static (int Offset, LeaderAndIsrTopicState Value) ReadV03(byte[] buffer, int index)
           {
               (index, var topicNameField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var partitionStatesField) = Decoder.ReadArray<LeaderAndIsrPartitionState>(buffer, index, LeaderAndIsrPartitionStateSerde.ReadV03);
               if (partitionStatesField == null)
                   throw new NullReferenceException("Null not allowed for 'PartitionStates'");
               return (index, new(
                   topicNameField,
                   topicIdField,
                   partitionStatesField.Value
               ));
           }
           public static int WriteV03(byte[] buffer, int index, LeaderAndIsrTopicState message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicNameField);
               index = Encoder.WriteArray<LeaderAndIsrPartitionState>(buffer, index, message.PartitionStatesField, LeaderAndIsrPartitionStateSerde.WriteV03);
               return index;
           }
           public static (int Offset, LeaderAndIsrTopicState Value) ReadV04(byte[] buffer, int index)
           {
               (index, var topicNameField) = Decoder.ReadCompactString(buffer, index);
               var topicIdField = default(Guid);
               (index, var partitionStatesField) = Decoder.ReadCompactArray<LeaderAndIsrPartitionState>(buffer, index, LeaderAndIsrPartitionStateSerde.ReadV04);
               if (partitionStatesField == null)
                   throw new NullReferenceException("Null not allowed for 'PartitionStates'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicNameField,
                   topicIdField,
                   partitionStatesField.Value
               ));
           }
           public static int WriteV04(byte[] buffer, int index, LeaderAndIsrTopicState message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.TopicNameField);
               index = Encoder.WriteCompactArray<LeaderAndIsrPartitionState>(buffer, index, message.PartitionStatesField, LeaderAndIsrPartitionStateSerde.WriteV04);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, LeaderAndIsrTopicState Value) ReadV05(byte[] buffer, int index)
           {
               (index, var topicNameField) = Decoder.ReadCompactString(buffer, index);
               (index, var topicIdField) = Decoder.ReadUuid(buffer, index);
               (index, var partitionStatesField) = Decoder.ReadCompactArray<LeaderAndIsrPartitionState>(buffer, index, LeaderAndIsrPartitionStateSerde.ReadV05);
               if (partitionStatesField == null)
                   throw new NullReferenceException("Null not allowed for 'PartitionStates'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicNameField,
                   topicIdField,
                   partitionStatesField.Value
               ));
           }
           public static int WriteV05(byte[] buffer, int index, LeaderAndIsrTopicState message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.TopicNameField);
               index = Encoder.WriteUuid(buffer, index, message.TopicIdField);
               index = Encoder.WriteCompactArray<LeaderAndIsrPartitionState>(buffer, index, message.PartitionStatesField, LeaderAndIsrPartitionStateSerde.WriteV05);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, LeaderAndIsrTopicState Value) ReadV06(byte[] buffer, int index)
           {
               (index, var topicNameField) = Decoder.ReadCompactString(buffer, index);
               (index, var topicIdField) = Decoder.ReadUuid(buffer, index);
               (index, var partitionStatesField) = Decoder.ReadCompactArray<LeaderAndIsrPartitionState>(buffer, index, LeaderAndIsrPartitionStateSerde.ReadV06);
               if (partitionStatesField == null)
                   throw new NullReferenceException("Null not allowed for 'PartitionStates'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicNameField,
                   topicIdField,
                   partitionStatesField.Value
               ));
           }
           public static int WriteV06(byte[] buffer, int index, LeaderAndIsrTopicState message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.TopicNameField);
               index = Encoder.WriteUuid(buffer, index, message.TopicIdField);
               index = Encoder.WriteCompactArray<LeaderAndIsrPartitionState>(buffer, index, message.PartitionStatesField, LeaderAndIsrPartitionStateSerde.WriteV06);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, LeaderAndIsrTopicState Value) ReadV07(byte[] buffer, int index)
           {
               (index, var topicNameField) = Decoder.ReadCompactString(buffer, index);
               (index, var topicIdField) = Decoder.ReadUuid(buffer, index);
               (index, var partitionStatesField) = Decoder.ReadCompactArray<LeaderAndIsrPartitionState>(buffer, index, LeaderAndIsrPartitionStateSerde.ReadV07);
               if (partitionStatesField == null)
                   throw new NullReferenceException("Null not allowed for 'PartitionStates'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicNameField,
                   topicIdField,
                   partitionStatesField.Value
               ));
           }
           public static int WriteV07(byte[] buffer, int index, LeaderAndIsrTopicState message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.TopicNameField);
               index = Encoder.WriteUuid(buffer, index, message.TopicIdField);
               index = Encoder.WriteCompactArray<LeaderAndIsrPartitionState>(buffer, index, message.PartitionStatesField, LeaderAndIsrPartitionStateSerde.WriteV07);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
   }
}