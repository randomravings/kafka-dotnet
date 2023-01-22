using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using UpdateMetadataEndpoint = Kafka.Client.Messages.UpdateMetadataRequest.UpdateMetadataBroker.UpdateMetadataEndpoint;
using UpdateMetadataBroker = Kafka.Client.Messages.UpdateMetadataRequest.UpdateMetadataBroker;
using UpdateMetadataTopicState = Kafka.Client.Messages.UpdateMetadataRequest.UpdateMetadataTopicState;
using UpdateMetadataPartitionState = Kafka.Client.Messages.UpdateMetadataRequest.UpdateMetadataPartitionState;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class UpdateMetadataRequestSerde
   {
       private static readonly DecodeDelegate<UpdateMetadataRequest>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
           ReadV04,
           ReadV05,
           ReadV06,
           ReadV07,
           ReadV08,
       };
       private static readonly EncodeDelegate<UpdateMetadataRequest>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
           WriteV04,
           WriteV05,
           WriteV06,
           WriteV07,
           WriteV08,
};
       public static (int Offset, UpdateMetadataRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, UpdateMetadataRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, UpdateMetadataRequest Value) ReadV00(byte[] buffer, int index)
       {
           (index, var controllerIdField) = Decoder.ReadInt32(buffer, index);
           var kRaftControllerIdField = default(int);
           (index, var controllerEpochField) = Decoder.ReadInt32(buffer, index);
           var brokerEpochField = default(long);
           (index, var ungroupedPartitionStatesField) = Decoder.ReadArray<UpdateMetadataPartitionState>(buffer, index, UpdateMetadataPartitionStateSerde.ReadV00);
           if (ungroupedPartitionStatesField == null)
               throw new NullReferenceException("Null not allowed for 'UngroupedPartitionStates'");
           var topicStatesField = ImmutableArray<UpdateMetadataTopicState>.Empty;
           (index, var liveBrokersField) = Decoder.ReadArray<UpdateMetadataBroker>(buffer, index, UpdateMetadataBrokerSerde.ReadV00);
           if (liveBrokersField == null)
               throw new NullReferenceException("Null not allowed for 'LiveBrokers'");
           return (index, new(
               controllerIdField,
               kRaftControllerIdField,
               controllerEpochField,
               brokerEpochField,
               ungroupedPartitionStatesField.Value,
               topicStatesField,
               liveBrokersField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, UpdateMetadataRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
           index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
           index = Encoder.WriteArray<UpdateMetadataPartitionState>(buffer, index, message.UngroupedPartitionStatesField, UpdateMetadataPartitionStateSerde.WriteV00);
           index = Encoder.WriteArray<UpdateMetadataBroker>(buffer, index, message.LiveBrokersField, UpdateMetadataBrokerSerde.WriteV00);
           return index;
       }
       private static (int Offset, UpdateMetadataRequest Value) ReadV01(byte[] buffer, int index)
       {
           (index, var controllerIdField) = Decoder.ReadInt32(buffer, index);
           var kRaftControllerIdField = default(int);
           (index, var controllerEpochField) = Decoder.ReadInt32(buffer, index);
           var brokerEpochField = default(long);
           (index, var ungroupedPartitionStatesField) = Decoder.ReadArray<UpdateMetadataPartitionState>(buffer, index, UpdateMetadataPartitionStateSerde.ReadV01);
           if (ungroupedPartitionStatesField == null)
               throw new NullReferenceException("Null not allowed for 'UngroupedPartitionStates'");
           var topicStatesField = ImmutableArray<UpdateMetadataTopicState>.Empty;
           (index, var liveBrokersField) = Decoder.ReadArray<UpdateMetadataBroker>(buffer, index, UpdateMetadataBrokerSerde.ReadV01);
           if (liveBrokersField == null)
               throw new NullReferenceException("Null not allowed for 'LiveBrokers'");
           return (index, new(
               controllerIdField,
               kRaftControllerIdField,
               controllerEpochField,
               brokerEpochField,
               ungroupedPartitionStatesField.Value,
               topicStatesField,
               liveBrokersField.Value
           ));
       }
       private static int WriteV01(byte[] buffer, int index, UpdateMetadataRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
           index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
           index = Encoder.WriteArray<UpdateMetadataPartitionState>(buffer, index, message.UngroupedPartitionStatesField, UpdateMetadataPartitionStateSerde.WriteV01);
           index = Encoder.WriteArray<UpdateMetadataBroker>(buffer, index, message.LiveBrokersField, UpdateMetadataBrokerSerde.WriteV01);
           return index;
       }
       private static (int Offset, UpdateMetadataRequest Value) ReadV02(byte[] buffer, int index)
       {
           (index, var controllerIdField) = Decoder.ReadInt32(buffer, index);
           var kRaftControllerIdField = default(int);
           (index, var controllerEpochField) = Decoder.ReadInt32(buffer, index);
           var brokerEpochField = default(long);
           (index, var ungroupedPartitionStatesField) = Decoder.ReadArray<UpdateMetadataPartitionState>(buffer, index, UpdateMetadataPartitionStateSerde.ReadV02);
           if (ungroupedPartitionStatesField == null)
               throw new NullReferenceException("Null not allowed for 'UngroupedPartitionStates'");
           var topicStatesField = ImmutableArray<UpdateMetadataTopicState>.Empty;
           (index, var liveBrokersField) = Decoder.ReadArray<UpdateMetadataBroker>(buffer, index, UpdateMetadataBrokerSerde.ReadV02);
           if (liveBrokersField == null)
               throw new NullReferenceException("Null not allowed for 'LiveBrokers'");
           return (index, new(
               controllerIdField,
               kRaftControllerIdField,
               controllerEpochField,
               brokerEpochField,
               ungroupedPartitionStatesField.Value,
               topicStatesField,
               liveBrokersField.Value
           ));
       }
       private static int WriteV02(byte[] buffer, int index, UpdateMetadataRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
           index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
           index = Encoder.WriteArray<UpdateMetadataPartitionState>(buffer, index, message.UngroupedPartitionStatesField, UpdateMetadataPartitionStateSerde.WriteV02);
           index = Encoder.WriteArray<UpdateMetadataBroker>(buffer, index, message.LiveBrokersField, UpdateMetadataBrokerSerde.WriteV02);
           return index;
       }
       private static (int Offset, UpdateMetadataRequest Value) ReadV03(byte[] buffer, int index)
       {
           (index, var controllerIdField) = Decoder.ReadInt32(buffer, index);
           var kRaftControllerIdField = default(int);
           (index, var controllerEpochField) = Decoder.ReadInt32(buffer, index);
           var brokerEpochField = default(long);
           (index, var ungroupedPartitionStatesField) = Decoder.ReadArray<UpdateMetadataPartitionState>(buffer, index, UpdateMetadataPartitionStateSerde.ReadV03);
           if (ungroupedPartitionStatesField == null)
               throw new NullReferenceException("Null not allowed for 'UngroupedPartitionStates'");
           var topicStatesField = ImmutableArray<UpdateMetadataTopicState>.Empty;
           (index, var liveBrokersField) = Decoder.ReadArray<UpdateMetadataBroker>(buffer, index, UpdateMetadataBrokerSerde.ReadV03);
           if (liveBrokersField == null)
               throw new NullReferenceException("Null not allowed for 'LiveBrokers'");
           return (index, new(
               controllerIdField,
               kRaftControllerIdField,
               controllerEpochField,
               brokerEpochField,
               ungroupedPartitionStatesField.Value,
               topicStatesField,
               liveBrokersField.Value
           ));
       }
       private static int WriteV03(byte[] buffer, int index, UpdateMetadataRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
           index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
           index = Encoder.WriteArray<UpdateMetadataPartitionState>(buffer, index, message.UngroupedPartitionStatesField, UpdateMetadataPartitionStateSerde.WriteV03);
           index = Encoder.WriteArray<UpdateMetadataBroker>(buffer, index, message.LiveBrokersField, UpdateMetadataBrokerSerde.WriteV03);
           return index;
       }
       private static (int Offset, UpdateMetadataRequest Value) ReadV04(byte[] buffer, int index)
       {
           (index, var controllerIdField) = Decoder.ReadInt32(buffer, index);
           var kRaftControllerIdField = default(int);
           (index, var controllerEpochField) = Decoder.ReadInt32(buffer, index);
           var brokerEpochField = default(long);
           (index, var ungroupedPartitionStatesField) = Decoder.ReadArray<UpdateMetadataPartitionState>(buffer, index, UpdateMetadataPartitionStateSerde.ReadV04);
           if (ungroupedPartitionStatesField == null)
               throw new NullReferenceException("Null not allowed for 'UngroupedPartitionStates'");
           var topicStatesField = ImmutableArray<UpdateMetadataTopicState>.Empty;
           (index, var liveBrokersField) = Decoder.ReadArray<UpdateMetadataBroker>(buffer, index, UpdateMetadataBrokerSerde.ReadV04);
           if (liveBrokersField == null)
               throw new NullReferenceException("Null not allowed for 'LiveBrokers'");
           return (index, new(
               controllerIdField,
               kRaftControllerIdField,
               controllerEpochField,
               brokerEpochField,
               ungroupedPartitionStatesField.Value,
               topicStatesField,
               liveBrokersField.Value
           ));
       }
       private static int WriteV04(byte[] buffer, int index, UpdateMetadataRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
           index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
           index = Encoder.WriteArray<UpdateMetadataPartitionState>(buffer, index, message.UngroupedPartitionStatesField, UpdateMetadataPartitionStateSerde.WriteV04);
           index = Encoder.WriteArray<UpdateMetadataBroker>(buffer, index, message.LiveBrokersField, UpdateMetadataBrokerSerde.WriteV04);
           return index;
       }
       private static (int Offset, UpdateMetadataRequest Value) ReadV05(byte[] buffer, int index)
       {
           (index, var controllerIdField) = Decoder.ReadInt32(buffer, index);
           var kRaftControllerIdField = default(int);
           (index, var controllerEpochField) = Decoder.ReadInt32(buffer, index);
           (index, var brokerEpochField) = Decoder.ReadInt64(buffer, index);
           var ungroupedPartitionStatesField = ImmutableArray<UpdateMetadataPartitionState>.Empty;
           (index, var topicStatesField) = Decoder.ReadArray<UpdateMetadataTopicState>(buffer, index, UpdateMetadataTopicStateSerde.ReadV05);
           if (topicStatesField == null)
               throw new NullReferenceException("Null not allowed for 'TopicStates'");
           (index, var liveBrokersField) = Decoder.ReadArray<UpdateMetadataBroker>(buffer, index, UpdateMetadataBrokerSerde.ReadV05);
           if (liveBrokersField == null)
               throw new NullReferenceException("Null not allowed for 'LiveBrokers'");
           return (index, new(
               controllerIdField,
               kRaftControllerIdField,
               controllerEpochField,
               brokerEpochField,
               ungroupedPartitionStatesField,
               topicStatesField.Value,
               liveBrokersField.Value
           ));
       }
       private static int WriteV05(byte[] buffer, int index, UpdateMetadataRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
           index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
           index = Encoder.WriteInt64(buffer, index, message.BrokerEpochField);
           index = Encoder.WriteArray<UpdateMetadataTopicState>(buffer, index, message.TopicStatesField, UpdateMetadataTopicStateSerde.WriteV05);
           index = Encoder.WriteArray<UpdateMetadataBroker>(buffer, index, message.LiveBrokersField, UpdateMetadataBrokerSerde.WriteV05);
           return index;
       }
       private static (int Offset, UpdateMetadataRequest Value) ReadV06(byte[] buffer, int index)
       {
           (index, var controllerIdField) = Decoder.ReadInt32(buffer, index);
           var kRaftControllerIdField = default(int);
           (index, var controllerEpochField) = Decoder.ReadInt32(buffer, index);
           (index, var brokerEpochField) = Decoder.ReadInt64(buffer, index);
           var ungroupedPartitionStatesField = ImmutableArray<UpdateMetadataPartitionState>.Empty;
           (index, var topicStatesField) = Decoder.ReadCompactArray<UpdateMetadataTopicState>(buffer, index, UpdateMetadataTopicStateSerde.ReadV06);
           if (topicStatesField == null)
               throw new NullReferenceException("Null not allowed for 'TopicStates'");
           (index, var liveBrokersField) = Decoder.ReadCompactArray<UpdateMetadataBroker>(buffer, index, UpdateMetadataBrokerSerde.ReadV06);
           if (liveBrokersField == null)
               throw new NullReferenceException("Null not allowed for 'LiveBrokers'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               controllerIdField,
               kRaftControllerIdField,
               controllerEpochField,
               brokerEpochField,
               ungroupedPartitionStatesField,
               topicStatesField.Value,
               liveBrokersField.Value
           ));
       }
       private static int WriteV06(byte[] buffer, int index, UpdateMetadataRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
           index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
           index = Encoder.WriteInt64(buffer, index, message.BrokerEpochField);
           index = Encoder.WriteCompactArray<UpdateMetadataTopicState>(buffer, index, message.TopicStatesField, UpdateMetadataTopicStateSerde.WriteV06);
           index = Encoder.WriteCompactArray<UpdateMetadataBroker>(buffer, index, message.LiveBrokersField, UpdateMetadataBrokerSerde.WriteV06);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, UpdateMetadataRequest Value) ReadV07(byte[] buffer, int index)
       {
           (index, var controllerIdField) = Decoder.ReadInt32(buffer, index);
           var kRaftControllerIdField = default(int);
           (index, var controllerEpochField) = Decoder.ReadInt32(buffer, index);
           (index, var brokerEpochField) = Decoder.ReadInt64(buffer, index);
           var ungroupedPartitionStatesField = ImmutableArray<UpdateMetadataPartitionState>.Empty;
           (index, var topicStatesField) = Decoder.ReadCompactArray<UpdateMetadataTopicState>(buffer, index, UpdateMetadataTopicStateSerde.ReadV07);
           if (topicStatesField == null)
               throw new NullReferenceException("Null not allowed for 'TopicStates'");
           (index, var liveBrokersField) = Decoder.ReadCompactArray<UpdateMetadataBroker>(buffer, index, UpdateMetadataBrokerSerde.ReadV07);
           if (liveBrokersField == null)
               throw new NullReferenceException("Null not allowed for 'LiveBrokers'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               controllerIdField,
               kRaftControllerIdField,
               controllerEpochField,
               brokerEpochField,
               ungroupedPartitionStatesField,
               topicStatesField.Value,
               liveBrokersField.Value
           ));
       }
       private static int WriteV07(byte[] buffer, int index, UpdateMetadataRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
           index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
           index = Encoder.WriteInt64(buffer, index, message.BrokerEpochField);
           index = Encoder.WriteCompactArray<UpdateMetadataTopicState>(buffer, index, message.TopicStatesField, UpdateMetadataTopicStateSerde.WriteV07);
           index = Encoder.WriteCompactArray<UpdateMetadataBroker>(buffer, index, message.LiveBrokersField, UpdateMetadataBrokerSerde.WriteV07);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, UpdateMetadataRequest Value) ReadV08(byte[] buffer, int index)
       {
           (index, var controllerIdField) = Decoder.ReadInt32(buffer, index);
           (index, var kRaftControllerIdField) = Decoder.ReadInt32(buffer, index);
           (index, var controllerEpochField) = Decoder.ReadInt32(buffer, index);
           (index, var brokerEpochField) = Decoder.ReadInt64(buffer, index);
           var ungroupedPartitionStatesField = ImmutableArray<UpdateMetadataPartitionState>.Empty;
           (index, var topicStatesField) = Decoder.ReadCompactArray<UpdateMetadataTopicState>(buffer, index, UpdateMetadataTopicStateSerde.ReadV08);
           if (topicStatesField == null)
               throw new NullReferenceException("Null not allowed for 'TopicStates'");
           (index, var liveBrokersField) = Decoder.ReadCompactArray<UpdateMetadataBroker>(buffer, index, UpdateMetadataBrokerSerde.ReadV08);
           if (liveBrokersField == null)
               throw new NullReferenceException("Null not allowed for 'LiveBrokers'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               controllerIdField,
               kRaftControllerIdField,
               controllerEpochField,
               brokerEpochField,
               ungroupedPartitionStatesField,
               topicStatesField.Value,
               liveBrokersField.Value
           ));
       }
       private static int WriteV08(byte[] buffer, int index, UpdateMetadataRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
           index = Encoder.WriteInt32(buffer, index, message.KRaftControllerIdField);
           index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
           index = Encoder.WriteInt64(buffer, index, message.BrokerEpochField);
           index = Encoder.WriteCompactArray<UpdateMetadataTopicState>(buffer, index, message.TopicStatesField, UpdateMetadataTopicStateSerde.WriteV08);
           index = Encoder.WriteCompactArray<UpdateMetadataBroker>(buffer, index, message.LiveBrokersField, UpdateMetadataBrokerSerde.WriteV08);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class UpdateMetadataBrokerSerde
       {
           public static (int Offset, UpdateMetadataBroker Value) ReadV00(byte[] buffer, int index)
           {
               (index, var idField) = Decoder.ReadInt32(buffer, index);
               (index, var v0HostField) = Decoder.ReadString(buffer, index);
               (index, var v0PortField) = Decoder.ReadInt32(buffer, index);
               var endpointsField = ImmutableArray<UpdateMetadataEndpoint>.Empty;
               var rackField = default(string?);
               return (index, new(
                   idField,
                   v0HostField,
                   v0PortField,
                   endpointsField,
                   rackField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, UpdateMetadataBroker message)
           {
               index = Encoder.WriteInt32(buffer, index, message.IdField);
               index = Encoder.WriteString(buffer, index, message.V0HostField);
               index = Encoder.WriteInt32(buffer, index, message.V0PortField);
               return index;
           }
           public static (int Offset, UpdateMetadataBroker Value) ReadV01(byte[] buffer, int index)
           {
               (index, var idField) = Decoder.ReadInt32(buffer, index);
               var v0HostField = "";
               var v0PortField = default(int);
               (index, var endpointsField) = Decoder.ReadArray<UpdateMetadataEndpoint>(buffer, index, UpdateMetadataEndpointSerde.ReadV01);
               if (endpointsField == null)
                   throw new NullReferenceException("Null not allowed for 'Endpoints'");
               var rackField = default(string?);
               return (index, new(
                   idField,
                   v0HostField,
                   v0PortField,
                   endpointsField.Value,
                   rackField
               ));
           }
           public static int WriteV01(byte[] buffer, int index, UpdateMetadataBroker message)
           {
               index = Encoder.WriteInt32(buffer, index, message.IdField);
               index = Encoder.WriteArray<UpdateMetadataEndpoint>(buffer, index, message.EndpointsField, UpdateMetadataEndpointSerde.WriteV01);
               return index;
           }
           public static (int Offset, UpdateMetadataBroker Value) ReadV02(byte[] buffer, int index)
           {
               (index, var idField) = Decoder.ReadInt32(buffer, index);
               var v0HostField = "";
               var v0PortField = default(int);
               (index, var endpointsField) = Decoder.ReadArray<UpdateMetadataEndpoint>(buffer, index, UpdateMetadataEndpointSerde.ReadV02);
               if (endpointsField == null)
                   throw new NullReferenceException("Null not allowed for 'Endpoints'");
               (index, var rackField) = Decoder.ReadNullableString(buffer, index);
               return (index, new(
                   idField,
                   v0HostField,
                   v0PortField,
                   endpointsField.Value,
                   rackField
               ));
           }
           public static int WriteV02(byte[] buffer, int index, UpdateMetadataBroker message)
           {
               index = Encoder.WriteInt32(buffer, index, message.IdField);
               index = Encoder.WriteArray<UpdateMetadataEndpoint>(buffer, index, message.EndpointsField, UpdateMetadataEndpointSerde.WriteV02);
               index = Encoder.WriteNullableString(buffer, index, message.RackField);
               return index;
           }
           public static (int Offset, UpdateMetadataBroker Value) ReadV03(byte[] buffer, int index)
           {
               (index, var idField) = Decoder.ReadInt32(buffer, index);
               var v0HostField = "";
               var v0PortField = default(int);
               (index, var endpointsField) = Decoder.ReadArray<UpdateMetadataEndpoint>(buffer, index, UpdateMetadataEndpointSerde.ReadV03);
               if (endpointsField == null)
                   throw new NullReferenceException("Null not allowed for 'Endpoints'");
               (index, var rackField) = Decoder.ReadNullableString(buffer, index);
               return (index, new(
                   idField,
                   v0HostField,
                   v0PortField,
                   endpointsField.Value,
                   rackField
               ));
           }
           public static int WriteV03(byte[] buffer, int index, UpdateMetadataBroker message)
           {
               index = Encoder.WriteInt32(buffer, index, message.IdField);
               index = Encoder.WriteArray<UpdateMetadataEndpoint>(buffer, index, message.EndpointsField, UpdateMetadataEndpointSerde.WriteV03);
               index = Encoder.WriteNullableString(buffer, index, message.RackField);
               return index;
           }
           public static (int Offset, UpdateMetadataBroker Value) ReadV04(byte[] buffer, int index)
           {
               (index, var idField) = Decoder.ReadInt32(buffer, index);
               var v0HostField = "";
               var v0PortField = default(int);
               (index, var endpointsField) = Decoder.ReadArray<UpdateMetadataEndpoint>(buffer, index, UpdateMetadataEndpointSerde.ReadV04);
               if (endpointsField == null)
                   throw new NullReferenceException("Null not allowed for 'Endpoints'");
               (index, var rackField) = Decoder.ReadNullableString(buffer, index);
               return (index, new(
                   idField,
                   v0HostField,
                   v0PortField,
                   endpointsField.Value,
                   rackField
               ));
           }
           public static int WriteV04(byte[] buffer, int index, UpdateMetadataBroker message)
           {
               index = Encoder.WriteInt32(buffer, index, message.IdField);
               index = Encoder.WriteArray<UpdateMetadataEndpoint>(buffer, index, message.EndpointsField, UpdateMetadataEndpointSerde.WriteV04);
               index = Encoder.WriteNullableString(buffer, index, message.RackField);
               return index;
           }
           public static (int Offset, UpdateMetadataBroker Value) ReadV05(byte[] buffer, int index)
           {
               (index, var idField) = Decoder.ReadInt32(buffer, index);
               var v0HostField = "";
               var v0PortField = default(int);
               (index, var endpointsField) = Decoder.ReadArray<UpdateMetadataEndpoint>(buffer, index, UpdateMetadataEndpointSerde.ReadV05);
               if (endpointsField == null)
                   throw new NullReferenceException("Null not allowed for 'Endpoints'");
               (index, var rackField) = Decoder.ReadNullableString(buffer, index);
               return (index, new(
                   idField,
                   v0HostField,
                   v0PortField,
                   endpointsField.Value,
                   rackField
               ));
           }
           public static int WriteV05(byte[] buffer, int index, UpdateMetadataBroker message)
           {
               index = Encoder.WriteInt32(buffer, index, message.IdField);
               index = Encoder.WriteArray<UpdateMetadataEndpoint>(buffer, index, message.EndpointsField, UpdateMetadataEndpointSerde.WriteV05);
               index = Encoder.WriteNullableString(buffer, index, message.RackField);
               return index;
           }
           public static (int Offset, UpdateMetadataBroker Value) ReadV06(byte[] buffer, int index)
           {
               (index, var idField) = Decoder.ReadInt32(buffer, index);
               var v0HostField = "";
               var v0PortField = default(int);
               (index, var endpointsField) = Decoder.ReadCompactArray<UpdateMetadataEndpoint>(buffer, index, UpdateMetadataEndpointSerde.ReadV06);
               if (endpointsField == null)
                   throw new NullReferenceException("Null not allowed for 'Endpoints'");
               (index, var rackField) = Decoder.ReadCompactNullableString(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   idField,
                   v0HostField,
                   v0PortField,
                   endpointsField.Value,
                   rackField
               ));
           }
           public static int WriteV06(byte[] buffer, int index, UpdateMetadataBroker message)
           {
               index = Encoder.WriteInt32(buffer, index, message.IdField);
               index = Encoder.WriteCompactArray<UpdateMetadataEndpoint>(buffer, index, message.EndpointsField, UpdateMetadataEndpointSerde.WriteV06);
               index = Encoder.WriteCompactNullableString(buffer, index, message.RackField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, UpdateMetadataBroker Value) ReadV07(byte[] buffer, int index)
           {
               (index, var idField) = Decoder.ReadInt32(buffer, index);
               var v0HostField = "";
               var v0PortField = default(int);
               (index, var endpointsField) = Decoder.ReadCompactArray<UpdateMetadataEndpoint>(buffer, index, UpdateMetadataEndpointSerde.ReadV07);
               if (endpointsField == null)
                   throw new NullReferenceException("Null not allowed for 'Endpoints'");
               (index, var rackField) = Decoder.ReadCompactNullableString(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   idField,
                   v0HostField,
                   v0PortField,
                   endpointsField.Value,
                   rackField
               ));
           }
           public static int WriteV07(byte[] buffer, int index, UpdateMetadataBroker message)
           {
               index = Encoder.WriteInt32(buffer, index, message.IdField);
               index = Encoder.WriteCompactArray<UpdateMetadataEndpoint>(buffer, index, message.EndpointsField, UpdateMetadataEndpointSerde.WriteV07);
               index = Encoder.WriteCompactNullableString(buffer, index, message.RackField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, UpdateMetadataBroker Value) ReadV08(byte[] buffer, int index)
           {
               (index, var idField) = Decoder.ReadInt32(buffer, index);
               var v0HostField = "";
               var v0PortField = default(int);
               (index, var endpointsField) = Decoder.ReadCompactArray<UpdateMetadataEndpoint>(buffer, index, UpdateMetadataEndpointSerde.ReadV08);
               if (endpointsField == null)
                   throw new NullReferenceException("Null not allowed for 'Endpoints'");
               (index, var rackField) = Decoder.ReadCompactNullableString(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   idField,
                   v0HostField,
                   v0PortField,
                   endpointsField.Value,
                   rackField
               ));
           }
           public static int WriteV08(byte[] buffer, int index, UpdateMetadataBroker message)
           {
               index = Encoder.WriteInt32(buffer, index, message.IdField);
               index = Encoder.WriteCompactArray<UpdateMetadataEndpoint>(buffer, index, message.EndpointsField, UpdateMetadataEndpointSerde.WriteV08);
               index = Encoder.WriteCompactNullableString(buffer, index, message.RackField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class UpdateMetadataEndpointSerde
           {
               public static (int Offset, UpdateMetadataEndpoint Value) ReadV00(byte[] buffer, int index)
               {
                   var portField = default(int);
                   var hostField = "";
                   var listenerField = "";
                   var securityProtocolField = default(short);
                   return (index, new(
                       portField,
                       hostField,
                       listenerField,
                       securityProtocolField
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, UpdateMetadataEndpoint message)
               {
                   return index;
               }
               public static (int Offset, UpdateMetadataEndpoint Value) ReadV01(byte[] buffer, int index)
               {
                   (index, var portField) = Decoder.ReadInt32(buffer, index);
                   (index, var hostField) = Decoder.ReadString(buffer, index);
                   var listenerField = "";
                   (index, var securityProtocolField) = Decoder.ReadInt16(buffer, index);
                   return (index, new(
                       portField,
                       hostField,
                       listenerField,
                       securityProtocolField
                   ));
               }
               public static int WriteV01(byte[] buffer, int index, UpdateMetadataEndpoint message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PortField);
                   index = Encoder.WriteString(buffer, index, message.HostField);
                   index = Encoder.WriteInt16(buffer, index, message.SecurityProtocolField);
                   return index;
               }
               public static (int Offset, UpdateMetadataEndpoint Value) ReadV02(byte[] buffer, int index)
               {
                   (index, var portField) = Decoder.ReadInt32(buffer, index);
                   (index, var hostField) = Decoder.ReadString(buffer, index);
                   var listenerField = "";
                   (index, var securityProtocolField) = Decoder.ReadInt16(buffer, index);
                   return (index, new(
                       portField,
                       hostField,
                       listenerField,
                       securityProtocolField
                   ));
               }
               public static int WriteV02(byte[] buffer, int index, UpdateMetadataEndpoint message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PortField);
                   index = Encoder.WriteString(buffer, index, message.HostField);
                   index = Encoder.WriteInt16(buffer, index, message.SecurityProtocolField);
                   return index;
               }
               public static (int Offset, UpdateMetadataEndpoint Value) ReadV03(byte[] buffer, int index)
               {
                   (index, var portField) = Decoder.ReadInt32(buffer, index);
                   (index, var hostField) = Decoder.ReadString(buffer, index);
                   (index, var listenerField) = Decoder.ReadString(buffer, index);
                   (index, var securityProtocolField) = Decoder.ReadInt16(buffer, index);
                   return (index, new(
                       portField,
                       hostField,
                       listenerField,
                       securityProtocolField
                   ));
               }
               public static int WriteV03(byte[] buffer, int index, UpdateMetadataEndpoint message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PortField);
                   index = Encoder.WriteString(buffer, index, message.HostField);
                   index = Encoder.WriteString(buffer, index, message.ListenerField);
                   index = Encoder.WriteInt16(buffer, index, message.SecurityProtocolField);
                   return index;
               }
               public static (int Offset, UpdateMetadataEndpoint Value) ReadV04(byte[] buffer, int index)
               {
                   (index, var portField) = Decoder.ReadInt32(buffer, index);
                   (index, var hostField) = Decoder.ReadString(buffer, index);
                   (index, var listenerField) = Decoder.ReadString(buffer, index);
                   (index, var securityProtocolField) = Decoder.ReadInt16(buffer, index);
                   return (index, new(
                       portField,
                       hostField,
                       listenerField,
                       securityProtocolField
                   ));
               }
               public static int WriteV04(byte[] buffer, int index, UpdateMetadataEndpoint message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PortField);
                   index = Encoder.WriteString(buffer, index, message.HostField);
                   index = Encoder.WriteString(buffer, index, message.ListenerField);
                   index = Encoder.WriteInt16(buffer, index, message.SecurityProtocolField);
                   return index;
               }
               public static (int Offset, UpdateMetadataEndpoint Value) ReadV05(byte[] buffer, int index)
               {
                   (index, var portField) = Decoder.ReadInt32(buffer, index);
                   (index, var hostField) = Decoder.ReadString(buffer, index);
                   (index, var listenerField) = Decoder.ReadString(buffer, index);
                   (index, var securityProtocolField) = Decoder.ReadInt16(buffer, index);
                   return (index, new(
                       portField,
                       hostField,
                       listenerField,
                       securityProtocolField
                   ));
               }
               public static int WriteV05(byte[] buffer, int index, UpdateMetadataEndpoint message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PortField);
                   index = Encoder.WriteString(buffer, index, message.HostField);
                   index = Encoder.WriteString(buffer, index, message.ListenerField);
                   index = Encoder.WriteInt16(buffer, index, message.SecurityProtocolField);
                   return index;
               }
               public static (int Offset, UpdateMetadataEndpoint Value) ReadV06(byte[] buffer, int index)
               {
                   (index, var portField) = Decoder.ReadInt32(buffer, index);
                   (index, var hostField) = Decoder.ReadCompactString(buffer, index);
                   (index, var listenerField) = Decoder.ReadCompactString(buffer, index);
                   (index, var securityProtocolField) = Decoder.ReadInt16(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       portField,
                       hostField,
                       listenerField,
                       securityProtocolField
                   ));
               }
               public static int WriteV06(byte[] buffer, int index, UpdateMetadataEndpoint message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PortField);
                   index = Encoder.WriteCompactString(buffer, index, message.HostField);
                   index = Encoder.WriteCompactString(buffer, index, message.ListenerField);
                   index = Encoder.WriteInt16(buffer, index, message.SecurityProtocolField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
               public static (int Offset, UpdateMetadataEndpoint Value) ReadV07(byte[] buffer, int index)
               {
                   (index, var portField) = Decoder.ReadInt32(buffer, index);
                   (index, var hostField) = Decoder.ReadCompactString(buffer, index);
                   (index, var listenerField) = Decoder.ReadCompactString(buffer, index);
                   (index, var securityProtocolField) = Decoder.ReadInt16(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       portField,
                       hostField,
                       listenerField,
                       securityProtocolField
                   ));
               }
               public static int WriteV07(byte[] buffer, int index, UpdateMetadataEndpoint message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PortField);
                   index = Encoder.WriteCompactString(buffer, index, message.HostField);
                   index = Encoder.WriteCompactString(buffer, index, message.ListenerField);
                   index = Encoder.WriteInt16(buffer, index, message.SecurityProtocolField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
               public static (int Offset, UpdateMetadataEndpoint Value) ReadV08(byte[] buffer, int index)
               {
                   (index, var portField) = Decoder.ReadInt32(buffer, index);
                   (index, var hostField) = Decoder.ReadCompactString(buffer, index);
                   (index, var listenerField) = Decoder.ReadCompactString(buffer, index);
                   (index, var securityProtocolField) = Decoder.ReadInt16(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       portField,
                       hostField,
                       listenerField,
                       securityProtocolField
                   ));
               }
               public static int WriteV08(byte[] buffer, int index, UpdateMetadataEndpoint message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.PortField);
                   index = Encoder.WriteCompactString(buffer, index, message.HostField);
                   index = Encoder.WriteCompactString(buffer, index, message.ListenerField);
                   index = Encoder.WriteInt16(buffer, index, message.SecurityProtocolField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
           }
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class UpdateMetadataTopicStateSerde
       {
           public static (int Offset, UpdateMetadataTopicState Value) ReadV00(byte[] buffer, int index)
           {
               var topicNameField = "";
               var topicIdField = default(Guid);
               var partitionStatesField = ImmutableArray<UpdateMetadataPartitionState>.Empty;
               return (index, new(
                   topicNameField,
                   topicIdField,
                   partitionStatesField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, UpdateMetadataTopicState message)
           {
               return index;
           }
           public static (int Offset, UpdateMetadataTopicState Value) ReadV01(byte[] buffer, int index)
           {
               var topicNameField = "";
               var topicIdField = default(Guid);
               var partitionStatesField = ImmutableArray<UpdateMetadataPartitionState>.Empty;
               return (index, new(
                   topicNameField,
                   topicIdField,
                   partitionStatesField
               ));
           }
           public static int WriteV01(byte[] buffer, int index, UpdateMetadataTopicState message)
           {
               return index;
           }
           public static (int Offset, UpdateMetadataTopicState Value) ReadV02(byte[] buffer, int index)
           {
               var topicNameField = "";
               var topicIdField = default(Guid);
               var partitionStatesField = ImmutableArray<UpdateMetadataPartitionState>.Empty;
               return (index, new(
                   topicNameField,
                   topicIdField,
                   partitionStatesField
               ));
           }
           public static int WriteV02(byte[] buffer, int index, UpdateMetadataTopicState message)
           {
               return index;
           }
           public static (int Offset, UpdateMetadataTopicState Value) ReadV03(byte[] buffer, int index)
           {
               var topicNameField = "";
               var topicIdField = default(Guid);
               var partitionStatesField = ImmutableArray<UpdateMetadataPartitionState>.Empty;
               return (index, new(
                   topicNameField,
                   topicIdField,
                   partitionStatesField
               ));
           }
           public static int WriteV03(byte[] buffer, int index, UpdateMetadataTopicState message)
           {
               return index;
           }
           public static (int Offset, UpdateMetadataTopicState Value) ReadV04(byte[] buffer, int index)
           {
               var topicNameField = "";
               var topicIdField = default(Guid);
               var partitionStatesField = ImmutableArray<UpdateMetadataPartitionState>.Empty;
               return (index, new(
                   topicNameField,
                   topicIdField,
                   partitionStatesField
               ));
           }
           public static int WriteV04(byte[] buffer, int index, UpdateMetadataTopicState message)
           {
               return index;
           }
           public static (int Offset, UpdateMetadataTopicState Value) ReadV05(byte[] buffer, int index)
           {
               (index, var topicNameField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var partitionStatesField) = Decoder.ReadArray<UpdateMetadataPartitionState>(buffer, index, UpdateMetadataPartitionStateSerde.ReadV05);
               if (partitionStatesField == null)
                   throw new NullReferenceException("Null not allowed for 'PartitionStates'");
               return (index, new(
                   topicNameField,
                   topicIdField,
                   partitionStatesField.Value
               ));
           }
           public static int WriteV05(byte[] buffer, int index, UpdateMetadataTopicState message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicNameField);
               index = Encoder.WriteArray<UpdateMetadataPartitionState>(buffer, index, message.PartitionStatesField, UpdateMetadataPartitionStateSerde.WriteV05);
               return index;
           }
           public static (int Offset, UpdateMetadataTopicState Value) ReadV06(byte[] buffer, int index)
           {
               (index, var topicNameField) = Decoder.ReadCompactString(buffer, index);
               var topicIdField = default(Guid);
               (index, var partitionStatesField) = Decoder.ReadCompactArray<UpdateMetadataPartitionState>(buffer, index, UpdateMetadataPartitionStateSerde.ReadV06);
               if (partitionStatesField == null)
                   throw new NullReferenceException("Null not allowed for 'PartitionStates'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicNameField,
                   topicIdField,
                   partitionStatesField.Value
               ));
           }
           public static int WriteV06(byte[] buffer, int index, UpdateMetadataTopicState message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.TopicNameField);
               index = Encoder.WriteCompactArray<UpdateMetadataPartitionState>(buffer, index, message.PartitionStatesField, UpdateMetadataPartitionStateSerde.WriteV06);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, UpdateMetadataTopicState Value) ReadV07(byte[] buffer, int index)
           {
               (index, var topicNameField) = Decoder.ReadCompactString(buffer, index);
               (index, var topicIdField) = Decoder.ReadUuid(buffer, index);
               (index, var partitionStatesField) = Decoder.ReadCompactArray<UpdateMetadataPartitionState>(buffer, index, UpdateMetadataPartitionStateSerde.ReadV07);
               if (partitionStatesField == null)
                   throw new NullReferenceException("Null not allowed for 'PartitionStates'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicNameField,
                   topicIdField,
                   partitionStatesField.Value
               ));
           }
           public static int WriteV07(byte[] buffer, int index, UpdateMetadataTopicState message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.TopicNameField);
               index = Encoder.WriteUuid(buffer, index, message.TopicIdField);
               index = Encoder.WriteCompactArray<UpdateMetadataPartitionState>(buffer, index, message.PartitionStatesField, UpdateMetadataPartitionStateSerde.WriteV07);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, UpdateMetadataTopicState Value) ReadV08(byte[] buffer, int index)
           {
               (index, var topicNameField) = Decoder.ReadCompactString(buffer, index);
               (index, var topicIdField) = Decoder.ReadUuid(buffer, index);
               (index, var partitionStatesField) = Decoder.ReadCompactArray<UpdateMetadataPartitionState>(buffer, index, UpdateMetadataPartitionStateSerde.ReadV08);
               if (partitionStatesField == null)
                   throw new NullReferenceException("Null not allowed for 'PartitionStates'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicNameField,
                   topicIdField,
                   partitionStatesField.Value
               ));
           }
           public static int WriteV08(byte[] buffer, int index, UpdateMetadataTopicState message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.TopicNameField);
               index = Encoder.WriteUuid(buffer, index, message.TopicIdField);
               index = Encoder.WriteCompactArray<UpdateMetadataPartitionState>(buffer, index, message.PartitionStatesField, UpdateMetadataPartitionStateSerde.WriteV08);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class UpdateMetadataPartitionStateSerde
       {
           public static (int Offset, UpdateMetadataPartitionState Value) ReadV00(byte[] buffer, int index)
           {
               (index, var topicNameField) = Decoder.ReadString(buffer, index);
               (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
               (index, var controllerEpochField) = Decoder.ReadInt32(buffer, index);
               (index, var leaderField) = Decoder.ReadInt32(buffer, index);
               (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
               (index, var isrField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
               if (isrField == null)
                   throw new NullReferenceException("Null not allowed for 'Isr'");
               (index, var zkVersionField) = Decoder.ReadInt32(buffer, index);
               (index, var replicasField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
               if (replicasField == null)
                   throw new NullReferenceException("Null not allowed for 'Replicas'");
               var offlineReplicasField = ImmutableArray<int>.Empty;
               return (index, new(
                   topicNameField,
                   partitionIndexField,
                   controllerEpochField,
                   leaderField,
                   leaderEpochField,
                   isrField.Value,
                   zkVersionField,
                   replicasField.Value,
                   offlineReplicasField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, UpdateMetadataPartitionState message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicNameField);
               index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
               index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
               index = Encoder.WriteInt32(buffer, index, message.LeaderField);
               index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
               index = Encoder.WriteArray<int>(buffer, index, message.IsrField, Encoder.WriteInt32);
               index = Encoder.WriteInt32(buffer, index, message.ZkVersionField);
               index = Encoder.WriteArray<int>(buffer, index, message.ReplicasField, Encoder.WriteInt32);
               return index;
           }
           public static (int Offset, UpdateMetadataPartitionState Value) ReadV01(byte[] buffer, int index)
           {
               (index, var topicNameField) = Decoder.ReadString(buffer, index);
               (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
               (index, var controllerEpochField) = Decoder.ReadInt32(buffer, index);
               (index, var leaderField) = Decoder.ReadInt32(buffer, index);
               (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
               (index, var isrField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
               if (isrField == null)
                   throw new NullReferenceException("Null not allowed for 'Isr'");
               (index, var zkVersionField) = Decoder.ReadInt32(buffer, index);
               (index, var replicasField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
               if (replicasField == null)
                   throw new NullReferenceException("Null not allowed for 'Replicas'");
               var offlineReplicasField = ImmutableArray<int>.Empty;
               return (index, new(
                   topicNameField,
                   partitionIndexField,
                   controllerEpochField,
                   leaderField,
                   leaderEpochField,
                   isrField.Value,
                   zkVersionField,
                   replicasField.Value,
                   offlineReplicasField
               ));
           }
           public static int WriteV01(byte[] buffer, int index, UpdateMetadataPartitionState message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicNameField);
               index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
               index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
               index = Encoder.WriteInt32(buffer, index, message.LeaderField);
               index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
               index = Encoder.WriteArray<int>(buffer, index, message.IsrField, Encoder.WriteInt32);
               index = Encoder.WriteInt32(buffer, index, message.ZkVersionField);
               index = Encoder.WriteArray<int>(buffer, index, message.ReplicasField, Encoder.WriteInt32);
               return index;
           }
           public static (int Offset, UpdateMetadataPartitionState Value) ReadV02(byte[] buffer, int index)
           {
               (index, var topicNameField) = Decoder.ReadString(buffer, index);
               (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
               (index, var controllerEpochField) = Decoder.ReadInt32(buffer, index);
               (index, var leaderField) = Decoder.ReadInt32(buffer, index);
               (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
               (index, var isrField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
               if (isrField == null)
                   throw new NullReferenceException("Null not allowed for 'Isr'");
               (index, var zkVersionField) = Decoder.ReadInt32(buffer, index);
               (index, var replicasField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
               if (replicasField == null)
                   throw new NullReferenceException("Null not allowed for 'Replicas'");
               var offlineReplicasField = ImmutableArray<int>.Empty;
               return (index, new(
                   topicNameField,
                   partitionIndexField,
                   controllerEpochField,
                   leaderField,
                   leaderEpochField,
                   isrField.Value,
                   zkVersionField,
                   replicasField.Value,
                   offlineReplicasField
               ));
           }
           public static int WriteV02(byte[] buffer, int index, UpdateMetadataPartitionState message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicNameField);
               index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
               index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
               index = Encoder.WriteInt32(buffer, index, message.LeaderField);
               index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
               index = Encoder.WriteArray<int>(buffer, index, message.IsrField, Encoder.WriteInt32);
               index = Encoder.WriteInt32(buffer, index, message.ZkVersionField);
               index = Encoder.WriteArray<int>(buffer, index, message.ReplicasField, Encoder.WriteInt32);
               return index;
           }
           public static (int Offset, UpdateMetadataPartitionState Value) ReadV03(byte[] buffer, int index)
           {
               (index, var topicNameField) = Decoder.ReadString(buffer, index);
               (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
               (index, var controllerEpochField) = Decoder.ReadInt32(buffer, index);
               (index, var leaderField) = Decoder.ReadInt32(buffer, index);
               (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
               (index, var isrField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
               if (isrField == null)
                   throw new NullReferenceException("Null not allowed for 'Isr'");
               (index, var zkVersionField) = Decoder.ReadInt32(buffer, index);
               (index, var replicasField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
               if (replicasField == null)
                   throw new NullReferenceException("Null not allowed for 'Replicas'");
               var offlineReplicasField = ImmutableArray<int>.Empty;
               return (index, new(
                   topicNameField,
                   partitionIndexField,
                   controllerEpochField,
                   leaderField,
                   leaderEpochField,
                   isrField.Value,
                   zkVersionField,
                   replicasField.Value,
                   offlineReplicasField
               ));
           }
           public static int WriteV03(byte[] buffer, int index, UpdateMetadataPartitionState message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicNameField);
               index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
               index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
               index = Encoder.WriteInt32(buffer, index, message.LeaderField);
               index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
               index = Encoder.WriteArray<int>(buffer, index, message.IsrField, Encoder.WriteInt32);
               index = Encoder.WriteInt32(buffer, index, message.ZkVersionField);
               index = Encoder.WriteArray<int>(buffer, index, message.ReplicasField, Encoder.WriteInt32);
               return index;
           }
           public static (int Offset, UpdateMetadataPartitionState Value) ReadV04(byte[] buffer, int index)
           {
               (index, var topicNameField) = Decoder.ReadString(buffer, index);
               (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
               (index, var controllerEpochField) = Decoder.ReadInt32(buffer, index);
               (index, var leaderField) = Decoder.ReadInt32(buffer, index);
               (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
               (index, var isrField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
               if (isrField == null)
                   throw new NullReferenceException("Null not allowed for 'Isr'");
               (index, var zkVersionField) = Decoder.ReadInt32(buffer, index);
               (index, var replicasField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
               if (replicasField == null)
                   throw new NullReferenceException("Null not allowed for 'Replicas'");
               (index, var offlineReplicasField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
               if (offlineReplicasField == null)
                   throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
               return (index, new(
                   topicNameField,
                   partitionIndexField,
                   controllerEpochField,
                   leaderField,
                   leaderEpochField,
                   isrField.Value,
                   zkVersionField,
                   replicasField.Value,
                   offlineReplicasField.Value
               ));
           }
           public static int WriteV04(byte[] buffer, int index, UpdateMetadataPartitionState message)
           {
               index = Encoder.WriteString(buffer, index, message.TopicNameField);
               index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
               index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
               index = Encoder.WriteInt32(buffer, index, message.LeaderField);
               index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
               index = Encoder.WriteArray<int>(buffer, index, message.IsrField, Encoder.WriteInt32);
               index = Encoder.WriteInt32(buffer, index, message.ZkVersionField);
               index = Encoder.WriteArray<int>(buffer, index, message.ReplicasField, Encoder.WriteInt32);
               index = Encoder.WriteArray<int>(buffer, index, message.OfflineReplicasField, Encoder.WriteInt32);
               return index;
           }
           public static (int Offset, UpdateMetadataPartitionState Value) ReadV05(byte[] buffer, int index)
           {
               var topicNameField = "";
               (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
               (index, var controllerEpochField) = Decoder.ReadInt32(buffer, index);
               (index, var leaderField) = Decoder.ReadInt32(buffer, index);
               (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
               (index, var isrField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
               if (isrField == null)
                   throw new NullReferenceException("Null not allowed for 'Isr'");
               (index, var zkVersionField) = Decoder.ReadInt32(buffer, index);
               (index, var replicasField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
               if (replicasField == null)
                   throw new NullReferenceException("Null not allowed for 'Replicas'");
               (index, var offlineReplicasField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
               if (offlineReplicasField == null)
                   throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
               return (index, new(
                   topicNameField,
                   partitionIndexField,
                   controllerEpochField,
                   leaderField,
                   leaderEpochField,
                   isrField.Value,
                   zkVersionField,
                   replicasField.Value,
                   offlineReplicasField.Value
               ));
           }
           public static int WriteV05(byte[] buffer, int index, UpdateMetadataPartitionState message)
           {
               index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
               index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
               index = Encoder.WriteInt32(buffer, index, message.LeaderField);
               index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
               index = Encoder.WriteArray<int>(buffer, index, message.IsrField, Encoder.WriteInt32);
               index = Encoder.WriteInt32(buffer, index, message.ZkVersionField);
               index = Encoder.WriteArray<int>(buffer, index, message.ReplicasField, Encoder.WriteInt32);
               index = Encoder.WriteArray<int>(buffer, index, message.OfflineReplicasField, Encoder.WriteInt32);
               return index;
           }
           public static (int Offset, UpdateMetadataPartitionState Value) ReadV06(byte[] buffer, int index)
           {
               var topicNameField = "";
               (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
               (index, var controllerEpochField) = Decoder.ReadInt32(buffer, index);
               (index, var leaderField) = Decoder.ReadInt32(buffer, index);
               (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
               (index, var isrField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
               if (isrField == null)
                   throw new NullReferenceException("Null not allowed for 'Isr'");
               (index, var zkVersionField) = Decoder.ReadInt32(buffer, index);
               (index, var replicasField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
               if (replicasField == null)
                   throw new NullReferenceException("Null not allowed for 'Replicas'");
               (index, var offlineReplicasField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
               if (offlineReplicasField == null)
                   throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicNameField,
                   partitionIndexField,
                   controllerEpochField,
                   leaderField,
                   leaderEpochField,
                   isrField.Value,
                   zkVersionField,
                   replicasField.Value,
                   offlineReplicasField.Value
               ));
           }
           public static int WriteV06(byte[] buffer, int index, UpdateMetadataPartitionState message)
           {
               index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
               index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
               index = Encoder.WriteInt32(buffer, index, message.LeaderField);
               index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
               index = Encoder.WriteCompactArray<int>(buffer, index, message.IsrField, Encoder.WriteInt32);
               index = Encoder.WriteInt32(buffer, index, message.ZkVersionField);
               index = Encoder.WriteCompactArray<int>(buffer, index, message.ReplicasField, Encoder.WriteInt32);
               index = Encoder.WriteCompactArray<int>(buffer, index, message.OfflineReplicasField, Encoder.WriteInt32);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, UpdateMetadataPartitionState Value) ReadV07(byte[] buffer, int index)
           {
               var topicNameField = "";
               (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
               (index, var controllerEpochField) = Decoder.ReadInt32(buffer, index);
               (index, var leaderField) = Decoder.ReadInt32(buffer, index);
               (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
               (index, var isrField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
               if (isrField == null)
                   throw new NullReferenceException("Null not allowed for 'Isr'");
               (index, var zkVersionField) = Decoder.ReadInt32(buffer, index);
               (index, var replicasField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
               if (replicasField == null)
                   throw new NullReferenceException("Null not allowed for 'Replicas'");
               (index, var offlineReplicasField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
               if (offlineReplicasField == null)
                   throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicNameField,
                   partitionIndexField,
                   controllerEpochField,
                   leaderField,
                   leaderEpochField,
                   isrField.Value,
                   zkVersionField,
                   replicasField.Value,
                   offlineReplicasField.Value
               ));
           }
           public static int WriteV07(byte[] buffer, int index, UpdateMetadataPartitionState message)
           {
               index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
               index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
               index = Encoder.WriteInt32(buffer, index, message.LeaderField);
               index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
               index = Encoder.WriteCompactArray<int>(buffer, index, message.IsrField, Encoder.WriteInt32);
               index = Encoder.WriteInt32(buffer, index, message.ZkVersionField);
               index = Encoder.WriteCompactArray<int>(buffer, index, message.ReplicasField, Encoder.WriteInt32);
               index = Encoder.WriteCompactArray<int>(buffer, index, message.OfflineReplicasField, Encoder.WriteInt32);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, UpdateMetadataPartitionState Value) ReadV08(byte[] buffer, int index)
           {
               var topicNameField = "";
               (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
               (index, var controllerEpochField) = Decoder.ReadInt32(buffer, index);
               (index, var leaderField) = Decoder.ReadInt32(buffer, index);
               (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
               (index, var isrField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
               if (isrField == null)
                   throw new NullReferenceException("Null not allowed for 'Isr'");
               (index, var zkVersionField) = Decoder.ReadInt32(buffer, index);
               (index, var replicasField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
               if (replicasField == null)
                   throw new NullReferenceException("Null not allowed for 'Replicas'");
               (index, var offlineReplicasField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
               if (offlineReplicasField == null)
                   throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   topicNameField,
                   partitionIndexField,
                   controllerEpochField,
                   leaderField,
                   leaderEpochField,
                   isrField.Value,
                   zkVersionField,
                   replicasField.Value,
                   offlineReplicasField.Value
               ));
           }
           public static int WriteV08(byte[] buffer, int index, UpdateMetadataPartitionState message)
           {
               index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
               index = Encoder.WriteInt32(buffer, index, message.ControllerEpochField);
               index = Encoder.WriteInt32(buffer, index, message.LeaderField);
               index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
               index = Encoder.WriteCompactArray<int>(buffer, index, message.IsrField, Encoder.WriteInt32);
               index = Encoder.WriteInt32(buffer, index, message.ZkVersionField);
               index = Encoder.WriteCompactArray<int>(buffer, index, message.ReplicasField, Encoder.WriteInt32);
               index = Encoder.WriteCompactArray<int>(buffer, index, message.OfflineReplicasField, Encoder.WriteInt32);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
   }
}