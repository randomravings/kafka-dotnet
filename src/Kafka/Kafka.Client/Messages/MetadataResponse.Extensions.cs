using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using MetadataResponseTopic = Kafka.Client.Messages.MetadataResponse.MetadataResponseTopic;
using MetadataResponsePartition = Kafka.Client.Messages.MetadataResponse.MetadataResponseTopic.MetadataResponsePartition;
using MetadataResponseBroker = Kafka.Client.Messages.MetadataResponse.MetadataResponseBroker;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class MetadataResponseSerde
   {
       private static readonly DecodeDelegate<MetadataResponse>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
           ReadV04,
           ReadV05,
           ReadV06,
           ReadV07,
           ReadV08,
           ReadV09,
           ReadV10,
           ReadV11,
           ReadV12,
       };
       private static readonly EncodeDelegate<MetadataResponse>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
           WriteV04,
           WriteV05,
           WriteV06,
           WriteV07,
           WriteV08,
           WriteV09,
           WriteV10,
           WriteV11,
           WriteV12,
};
       public static (int Offset, MetadataResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, MetadataResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, MetadataResponse Value) ReadV00(byte[] buffer, int index)
       {
           var throttleTimeMsField = default(int);
           (index, var brokersField) = Decoder.ReadArray<MetadataResponseBroker>(buffer, index, MetadataResponseBrokerSerde.ReadV00);
           if (brokersField == null)
               throw new NullReferenceException("Null not allowed for 'Brokers'");
           var clusterIdField = default(string?);
           var controllerIdField = default(int);
           (index, var topicsField) = Decoder.ReadArray<MetadataResponseTopic>(buffer, index, MetadataResponseTopicSerde.ReadV00);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           var clusterAuthorizedOperationsField = default(int);
           return (index, new(
               throttleTimeMsField,
               brokersField.Value,
               clusterIdField,
               controllerIdField,
               topicsField.Value,
               clusterAuthorizedOperationsField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, MetadataResponse message)
       {
           index = Encoder.WriteArray<MetadataResponseBroker>(buffer, index, message.BrokersField, MetadataResponseBrokerSerde.WriteV00);
           index = Encoder.WriteArray<MetadataResponseTopic>(buffer, index, message.TopicsField, MetadataResponseTopicSerde.WriteV00);
           return index;
       }
       private static (int Offset, MetadataResponse Value) ReadV01(byte[] buffer, int index)
       {
           var throttleTimeMsField = default(int);
           (index, var brokersField) = Decoder.ReadArray<MetadataResponseBroker>(buffer, index, MetadataResponseBrokerSerde.ReadV01);
           if (brokersField == null)
               throw new NullReferenceException("Null not allowed for 'Brokers'");
           var clusterIdField = default(string?);
           (index, var controllerIdField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<MetadataResponseTopic>(buffer, index, MetadataResponseTopicSerde.ReadV01);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           var clusterAuthorizedOperationsField = default(int);
           return (index, new(
               throttleTimeMsField,
               brokersField.Value,
               clusterIdField,
               controllerIdField,
               topicsField.Value,
               clusterAuthorizedOperationsField
           ));
       }
       private static int WriteV01(byte[] buffer, int index, MetadataResponse message)
       {
           index = Encoder.WriteArray<MetadataResponseBroker>(buffer, index, message.BrokersField, MetadataResponseBrokerSerde.WriteV01);
           index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
           index = Encoder.WriteArray<MetadataResponseTopic>(buffer, index, message.TopicsField, MetadataResponseTopicSerde.WriteV01);
           return index;
       }
       private static (int Offset, MetadataResponse Value) ReadV02(byte[] buffer, int index)
       {
           var throttleTimeMsField = default(int);
           (index, var brokersField) = Decoder.ReadArray<MetadataResponseBroker>(buffer, index, MetadataResponseBrokerSerde.ReadV02);
           if (brokersField == null)
               throw new NullReferenceException("Null not allowed for 'Brokers'");
           (index, var clusterIdField) = Decoder.ReadNullableString(buffer, index);
           (index, var controllerIdField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<MetadataResponseTopic>(buffer, index, MetadataResponseTopicSerde.ReadV02);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           var clusterAuthorizedOperationsField = default(int);
           return (index, new(
               throttleTimeMsField,
               brokersField.Value,
               clusterIdField,
               controllerIdField,
               topicsField.Value,
               clusterAuthorizedOperationsField
           ));
       }
       private static int WriteV02(byte[] buffer, int index, MetadataResponse message)
       {
           index = Encoder.WriteArray<MetadataResponseBroker>(buffer, index, message.BrokersField, MetadataResponseBrokerSerde.WriteV02);
           index = Encoder.WriteNullableString(buffer, index, message.ClusterIdField);
           index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
           index = Encoder.WriteArray<MetadataResponseTopic>(buffer, index, message.TopicsField, MetadataResponseTopicSerde.WriteV02);
           return index;
       }
       private static (int Offset, MetadataResponse Value) ReadV03(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var brokersField) = Decoder.ReadArray<MetadataResponseBroker>(buffer, index, MetadataResponseBrokerSerde.ReadV03);
           if (brokersField == null)
               throw new NullReferenceException("Null not allowed for 'Brokers'");
           (index, var clusterIdField) = Decoder.ReadNullableString(buffer, index);
           (index, var controllerIdField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<MetadataResponseTopic>(buffer, index, MetadataResponseTopicSerde.ReadV03);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           var clusterAuthorizedOperationsField = default(int);
           return (index, new(
               throttleTimeMsField,
               brokersField.Value,
               clusterIdField,
               controllerIdField,
               topicsField.Value,
               clusterAuthorizedOperationsField
           ));
       }
       private static int WriteV03(byte[] buffer, int index, MetadataResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<MetadataResponseBroker>(buffer, index, message.BrokersField, MetadataResponseBrokerSerde.WriteV03);
           index = Encoder.WriteNullableString(buffer, index, message.ClusterIdField);
           index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
           index = Encoder.WriteArray<MetadataResponseTopic>(buffer, index, message.TopicsField, MetadataResponseTopicSerde.WriteV03);
           return index;
       }
       private static (int Offset, MetadataResponse Value) ReadV04(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var brokersField) = Decoder.ReadArray<MetadataResponseBroker>(buffer, index, MetadataResponseBrokerSerde.ReadV04);
           if (brokersField == null)
               throw new NullReferenceException("Null not allowed for 'Brokers'");
           (index, var clusterIdField) = Decoder.ReadNullableString(buffer, index);
           (index, var controllerIdField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<MetadataResponseTopic>(buffer, index, MetadataResponseTopicSerde.ReadV04);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           var clusterAuthorizedOperationsField = default(int);
           return (index, new(
               throttleTimeMsField,
               brokersField.Value,
               clusterIdField,
               controllerIdField,
               topicsField.Value,
               clusterAuthorizedOperationsField
           ));
       }
       private static int WriteV04(byte[] buffer, int index, MetadataResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<MetadataResponseBroker>(buffer, index, message.BrokersField, MetadataResponseBrokerSerde.WriteV04);
           index = Encoder.WriteNullableString(buffer, index, message.ClusterIdField);
           index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
           index = Encoder.WriteArray<MetadataResponseTopic>(buffer, index, message.TopicsField, MetadataResponseTopicSerde.WriteV04);
           return index;
       }
       private static (int Offset, MetadataResponse Value) ReadV05(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var brokersField) = Decoder.ReadArray<MetadataResponseBroker>(buffer, index, MetadataResponseBrokerSerde.ReadV05);
           if (brokersField == null)
               throw new NullReferenceException("Null not allowed for 'Brokers'");
           (index, var clusterIdField) = Decoder.ReadNullableString(buffer, index);
           (index, var controllerIdField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<MetadataResponseTopic>(buffer, index, MetadataResponseTopicSerde.ReadV05);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           var clusterAuthorizedOperationsField = default(int);
           return (index, new(
               throttleTimeMsField,
               brokersField.Value,
               clusterIdField,
               controllerIdField,
               topicsField.Value,
               clusterAuthorizedOperationsField
           ));
       }
       private static int WriteV05(byte[] buffer, int index, MetadataResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<MetadataResponseBroker>(buffer, index, message.BrokersField, MetadataResponseBrokerSerde.WriteV05);
           index = Encoder.WriteNullableString(buffer, index, message.ClusterIdField);
           index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
           index = Encoder.WriteArray<MetadataResponseTopic>(buffer, index, message.TopicsField, MetadataResponseTopicSerde.WriteV05);
           return index;
       }
       private static (int Offset, MetadataResponse Value) ReadV06(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var brokersField) = Decoder.ReadArray<MetadataResponseBroker>(buffer, index, MetadataResponseBrokerSerde.ReadV06);
           if (brokersField == null)
               throw new NullReferenceException("Null not allowed for 'Brokers'");
           (index, var clusterIdField) = Decoder.ReadNullableString(buffer, index);
           (index, var controllerIdField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<MetadataResponseTopic>(buffer, index, MetadataResponseTopicSerde.ReadV06);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           var clusterAuthorizedOperationsField = default(int);
           return (index, new(
               throttleTimeMsField,
               brokersField.Value,
               clusterIdField,
               controllerIdField,
               topicsField.Value,
               clusterAuthorizedOperationsField
           ));
       }
       private static int WriteV06(byte[] buffer, int index, MetadataResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<MetadataResponseBroker>(buffer, index, message.BrokersField, MetadataResponseBrokerSerde.WriteV06);
           index = Encoder.WriteNullableString(buffer, index, message.ClusterIdField);
           index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
           index = Encoder.WriteArray<MetadataResponseTopic>(buffer, index, message.TopicsField, MetadataResponseTopicSerde.WriteV06);
           return index;
       }
       private static (int Offset, MetadataResponse Value) ReadV07(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var brokersField) = Decoder.ReadArray<MetadataResponseBroker>(buffer, index, MetadataResponseBrokerSerde.ReadV07);
           if (brokersField == null)
               throw new NullReferenceException("Null not allowed for 'Brokers'");
           (index, var clusterIdField) = Decoder.ReadNullableString(buffer, index);
           (index, var controllerIdField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<MetadataResponseTopic>(buffer, index, MetadataResponseTopicSerde.ReadV07);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           var clusterAuthorizedOperationsField = default(int);
           return (index, new(
               throttleTimeMsField,
               brokersField.Value,
               clusterIdField,
               controllerIdField,
               topicsField.Value,
               clusterAuthorizedOperationsField
           ));
       }
       private static int WriteV07(byte[] buffer, int index, MetadataResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<MetadataResponseBroker>(buffer, index, message.BrokersField, MetadataResponseBrokerSerde.WriteV07);
           index = Encoder.WriteNullableString(buffer, index, message.ClusterIdField);
           index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
           index = Encoder.WriteArray<MetadataResponseTopic>(buffer, index, message.TopicsField, MetadataResponseTopicSerde.WriteV07);
           return index;
       }
       private static (int Offset, MetadataResponse Value) ReadV08(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var brokersField) = Decoder.ReadArray<MetadataResponseBroker>(buffer, index, MetadataResponseBrokerSerde.ReadV08);
           if (brokersField == null)
               throw new NullReferenceException("Null not allowed for 'Brokers'");
           (index, var clusterIdField) = Decoder.ReadNullableString(buffer, index);
           (index, var controllerIdField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<MetadataResponseTopic>(buffer, index, MetadataResponseTopicSerde.ReadV08);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, var clusterAuthorizedOperationsField) = Decoder.ReadInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               brokersField.Value,
               clusterIdField,
               controllerIdField,
               topicsField.Value,
               clusterAuthorizedOperationsField
           ));
       }
       private static int WriteV08(byte[] buffer, int index, MetadataResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<MetadataResponseBroker>(buffer, index, message.BrokersField, MetadataResponseBrokerSerde.WriteV08);
           index = Encoder.WriteNullableString(buffer, index, message.ClusterIdField);
           index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
           index = Encoder.WriteArray<MetadataResponseTopic>(buffer, index, message.TopicsField, MetadataResponseTopicSerde.WriteV08);
           index = Encoder.WriteInt32(buffer, index, message.ClusterAuthorizedOperationsField);
           return index;
       }
       private static (int Offset, MetadataResponse Value) ReadV09(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var brokersField) = Decoder.ReadCompactArray<MetadataResponseBroker>(buffer, index, MetadataResponseBrokerSerde.ReadV09);
           if (brokersField == null)
               throw new NullReferenceException("Null not allowed for 'Brokers'");
           (index, var clusterIdField) = Decoder.ReadCompactNullableString(buffer, index);
           (index, var controllerIdField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadCompactArray<MetadataResponseTopic>(buffer, index, MetadataResponseTopicSerde.ReadV09);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, var clusterAuthorizedOperationsField) = Decoder.ReadInt32(buffer, index);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               brokersField.Value,
               clusterIdField,
               controllerIdField,
               topicsField.Value,
               clusterAuthorizedOperationsField
           ));
       }
       private static int WriteV09(byte[] buffer, int index, MetadataResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteCompactArray<MetadataResponseBroker>(buffer, index, message.BrokersField, MetadataResponseBrokerSerde.WriteV09);
           index = Encoder.WriteCompactNullableString(buffer, index, message.ClusterIdField);
           index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
           index = Encoder.WriteCompactArray<MetadataResponseTopic>(buffer, index, message.TopicsField, MetadataResponseTopicSerde.WriteV09);
           index = Encoder.WriteInt32(buffer, index, message.ClusterAuthorizedOperationsField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, MetadataResponse Value) ReadV10(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var brokersField) = Decoder.ReadCompactArray<MetadataResponseBroker>(buffer, index, MetadataResponseBrokerSerde.ReadV10);
           if (brokersField == null)
               throw new NullReferenceException("Null not allowed for 'Brokers'");
           (index, var clusterIdField) = Decoder.ReadCompactNullableString(buffer, index);
           (index, var controllerIdField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadCompactArray<MetadataResponseTopic>(buffer, index, MetadataResponseTopicSerde.ReadV10);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, var clusterAuthorizedOperationsField) = Decoder.ReadInt32(buffer, index);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               brokersField.Value,
               clusterIdField,
               controllerIdField,
               topicsField.Value,
               clusterAuthorizedOperationsField
           ));
       }
       private static int WriteV10(byte[] buffer, int index, MetadataResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteCompactArray<MetadataResponseBroker>(buffer, index, message.BrokersField, MetadataResponseBrokerSerde.WriteV10);
           index = Encoder.WriteCompactNullableString(buffer, index, message.ClusterIdField);
           index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
           index = Encoder.WriteCompactArray<MetadataResponseTopic>(buffer, index, message.TopicsField, MetadataResponseTopicSerde.WriteV10);
           index = Encoder.WriteInt32(buffer, index, message.ClusterAuthorizedOperationsField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, MetadataResponse Value) ReadV11(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var brokersField) = Decoder.ReadCompactArray<MetadataResponseBroker>(buffer, index, MetadataResponseBrokerSerde.ReadV11);
           if (brokersField == null)
               throw new NullReferenceException("Null not allowed for 'Brokers'");
           (index, var clusterIdField) = Decoder.ReadCompactNullableString(buffer, index);
           (index, var controllerIdField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadCompactArray<MetadataResponseTopic>(buffer, index, MetadataResponseTopicSerde.ReadV11);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           var clusterAuthorizedOperationsField = default(int);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               brokersField.Value,
               clusterIdField,
               controllerIdField,
               topicsField.Value,
               clusterAuthorizedOperationsField
           ));
       }
       private static int WriteV11(byte[] buffer, int index, MetadataResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteCompactArray<MetadataResponseBroker>(buffer, index, message.BrokersField, MetadataResponseBrokerSerde.WriteV11);
           index = Encoder.WriteCompactNullableString(buffer, index, message.ClusterIdField);
           index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
           index = Encoder.WriteCompactArray<MetadataResponseTopic>(buffer, index, message.TopicsField, MetadataResponseTopicSerde.WriteV11);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, MetadataResponse Value) ReadV12(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var brokersField) = Decoder.ReadCompactArray<MetadataResponseBroker>(buffer, index, MetadataResponseBrokerSerde.ReadV12);
           if (brokersField == null)
               throw new NullReferenceException("Null not allowed for 'Brokers'");
           (index, var clusterIdField) = Decoder.ReadCompactNullableString(buffer, index);
           (index, var controllerIdField) = Decoder.ReadInt32(buffer, index);
           (index, var topicsField) = Decoder.ReadCompactArray<MetadataResponseTopic>(buffer, index, MetadataResponseTopicSerde.ReadV12);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           var clusterAuthorizedOperationsField = default(int);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               brokersField.Value,
               clusterIdField,
               controllerIdField,
               topicsField.Value,
               clusterAuthorizedOperationsField
           ));
       }
       private static int WriteV12(byte[] buffer, int index, MetadataResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteCompactArray<MetadataResponseBroker>(buffer, index, message.BrokersField, MetadataResponseBrokerSerde.WriteV12);
           index = Encoder.WriteCompactNullableString(buffer, index, message.ClusterIdField);
           index = Encoder.WriteInt32(buffer, index, message.ControllerIdField);
           index = Encoder.WriteCompactArray<MetadataResponseTopic>(buffer, index, message.TopicsField, MetadataResponseTopicSerde.WriteV12);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class MetadataResponseTopicSerde
       {
           public static (int Offset, MetadataResponseTopic Value) ReadV00(byte[] buffer, int index)
           {
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var nameField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               var isInternalField = default(bool);
               (index, var partitionsField) = Decoder.ReadArray<MetadataResponsePartition>(buffer, index, MetadataResponsePartitionSerde.ReadV00);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               var topicAuthorizedOperationsField = default(int);
               return (index, new(
                   errorCodeField,
                   nameField,
                   topicIdField,
                   isInternalField,
                   partitionsField.Value,
                   topicAuthorizedOperationsField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, MetadataResponseTopic message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               if (message.NameField == null)
                   throw new ArgumentNullException(nameof(message.NameField));
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<MetadataResponsePartition>(buffer, index, message.PartitionsField, MetadataResponsePartitionSerde.WriteV00);
               return index;
           }
           public static (int Offset, MetadataResponseTopic Value) ReadV01(byte[] buffer, int index)
           {
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var nameField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var isInternalField) = Decoder.ReadBoolean(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<MetadataResponsePartition>(buffer, index, MetadataResponsePartitionSerde.ReadV01);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               var topicAuthorizedOperationsField = default(int);
               return (index, new(
                   errorCodeField,
                   nameField,
                   topicIdField,
                   isInternalField,
                   partitionsField.Value,
                   topicAuthorizedOperationsField
               ));
           }
           public static int WriteV01(byte[] buffer, int index, MetadataResponseTopic message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               if (message.NameField == null)
                   throw new ArgumentNullException(nameof(message.NameField));
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteBoolean(buffer, index, message.IsInternalField);
               index = Encoder.WriteArray<MetadataResponsePartition>(buffer, index, message.PartitionsField, MetadataResponsePartitionSerde.WriteV01);
               return index;
           }
           public static (int Offset, MetadataResponseTopic Value) ReadV02(byte[] buffer, int index)
           {
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var nameField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var isInternalField) = Decoder.ReadBoolean(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<MetadataResponsePartition>(buffer, index, MetadataResponsePartitionSerde.ReadV02);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               var topicAuthorizedOperationsField = default(int);
               return (index, new(
                   errorCodeField,
                   nameField,
                   topicIdField,
                   isInternalField,
                   partitionsField.Value,
                   topicAuthorizedOperationsField
               ));
           }
           public static int WriteV02(byte[] buffer, int index, MetadataResponseTopic message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               if (message.NameField == null)
                   throw new ArgumentNullException(nameof(message.NameField));
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteBoolean(buffer, index, message.IsInternalField);
               index = Encoder.WriteArray<MetadataResponsePartition>(buffer, index, message.PartitionsField, MetadataResponsePartitionSerde.WriteV02);
               return index;
           }
           public static (int Offset, MetadataResponseTopic Value) ReadV03(byte[] buffer, int index)
           {
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var nameField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var isInternalField) = Decoder.ReadBoolean(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<MetadataResponsePartition>(buffer, index, MetadataResponsePartitionSerde.ReadV03);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               var topicAuthorizedOperationsField = default(int);
               return (index, new(
                   errorCodeField,
                   nameField,
                   topicIdField,
                   isInternalField,
                   partitionsField.Value,
                   topicAuthorizedOperationsField
               ));
           }
           public static int WriteV03(byte[] buffer, int index, MetadataResponseTopic message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               if (message.NameField == null)
                   throw new ArgumentNullException(nameof(message.NameField));
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteBoolean(buffer, index, message.IsInternalField);
               index = Encoder.WriteArray<MetadataResponsePartition>(buffer, index, message.PartitionsField, MetadataResponsePartitionSerde.WriteV03);
               return index;
           }
           public static (int Offset, MetadataResponseTopic Value) ReadV04(byte[] buffer, int index)
           {
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var nameField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var isInternalField) = Decoder.ReadBoolean(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<MetadataResponsePartition>(buffer, index, MetadataResponsePartitionSerde.ReadV04);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               var topicAuthorizedOperationsField = default(int);
               return (index, new(
                   errorCodeField,
                   nameField,
                   topicIdField,
                   isInternalField,
                   partitionsField.Value,
                   topicAuthorizedOperationsField
               ));
           }
           public static int WriteV04(byte[] buffer, int index, MetadataResponseTopic message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               if (message.NameField == null)
                   throw new ArgumentNullException(nameof(message.NameField));
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteBoolean(buffer, index, message.IsInternalField);
               index = Encoder.WriteArray<MetadataResponsePartition>(buffer, index, message.PartitionsField, MetadataResponsePartitionSerde.WriteV04);
               return index;
           }
           public static (int Offset, MetadataResponseTopic Value) ReadV05(byte[] buffer, int index)
           {
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var nameField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var isInternalField) = Decoder.ReadBoolean(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<MetadataResponsePartition>(buffer, index, MetadataResponsePartitionSerde.ReadV05);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               var topicAuthorizedOperationsField = default(int);
               return (index, new(
                   errorCodeField,
                   nameField,
                   topicIdField,
                   isInternalField,
                   partitionsField.Value,
                   topicAuthorizedOperationsField
               ));
           }
           public static int WriteV05(byte[] buffer, int index, MetadataResponseTopic message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               if (message.NameField == null)
                   throw new ArgumentNullException(nameof(message.NameField));
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteBoolean(buffer, index, message.IsInternalField);
               index = Encoder.WriteArray<MetadataResponsePartition>(buffer, index, message.PartitionsField, MetadataResponsePartitionSerde.WriteV05);
               return index;
           }
           public static (int Offset, MetadataResponseTopic Value) ReadV06(byte[] buffer, int index)
           {
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var nameField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var isInternalField) = Decoder.ReadBoolean(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<MetadataResponsePartition>(buffer, index, MetadataResponsePartitionSerde.ReadV06);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               var topicAuthorizedOperationsField = default(int);
               return (index, new(
                   errorCodeField,
                   nameField,
                   topicIdField,
                   isInternalField,
                   partitionsField.Value,
                   topicAuthorizedOperationsField
               ));
           }
           public static int WriteV06(byte[] buffer, int index, MetadataResponseTopic message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               if (message.NameField == null)
                   throw new ArgumentNullException(nameof(message.NameField));
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteBoolean(buffer, index, message.IsInternalField);
               index = Encoder.WriteArray<MetadataResponsePartition>(buffer, index, message.PartitionsField, MetadataResponsePartitionSerde.WriteV06);
               return index;
           }
           public static (int Offset, MetadataResponseTopic Value) ReadV07(byte[] buffer, int index)
           {
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var nameField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var isInternalField) = Decoder.ReadBoolean(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<MetadataResponsePartition>(buffer, index, MetadataResponsePartitionSerde.ReadV07);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               var topicAuthorizedOperationsField = default(int);
               return (index, new(
                   errorCodeField,
                   nameField,
                   topicIdField,
                   isInternalField,
                   partitionsField.Value,
                   topicAuthorizedOperationsField
               ));
           }
           public static int WriteV07(byte[] buffer, int index, MetadataResponseTopic message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               if (message.NameField == null)
                   throw new ArgumentNullException(nameof(message.NameField));
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteBoolean(buffer, index, message.IsInternalField);
               index = Encoder.WriteArray<MetadataResponsePartition>(buffer, index, message.PartitionsField, MetadataResponsePartitionSerde.WriteV07);
               return index;
           }
           public static (int Offset, MetadataResponseTopic Value) ReadV08(byte[] buffer, int index)
           {
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var nameField) = Decoder.ReadString(buffer, index);
               var topicIdField = default(Guid);
               (index, var isInternalField) = Decoder.ReadBoolean(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<MetadataResponsePartition>(buffer, index, MetadataResponsePartitionSerde.ReadV08);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               (index, var topicAuthorizedOperationsField) = Decoder.ReadInt32(buffer, index);
               return (index, new(
                   errorCodeField,
                   nameField,
                   topicIdField,
                   isInternalField,
                   partitionsField.Value,
                   topicAuthorizedOperationsField
               ));
           }
           public static int WriteV08(byte[] buffer, int index, MetadataResponseTopic message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               if (message.NameField == null)
                   throw new ArgumentNullException(nameof(message.NameField));
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteBoolean(buffer, index, message.IsInternalField);
               index = Encoder.WriteArray<MetadataResponsePartition>(buffer, index, message.PartitionsField, MetadataResponsePartitionSerde.WriteV08);
               index = Encoder.WriteInt32(buffer, index, message.TopicAuthorizedOperationsField);
               return index;
           }
           public static (int Offset, MetadataResponseTopic Value) ReadV09(byte[] buffer, int index)
           {
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               var topicIdField = default(Guid);
               (index, var isInternalField) = Decoder.ReadBoolean(buffer, index);
               (index, var partitionsField) = Decoder.ReadCompactArray<MetadataResponsePartition>(buffer, index, MetadataResponsePartitionSerde.ReadV09);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               (index, var topicAuthorizedOperationsField) = Decoder.ReadInt32(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   errorCodeField,
                   nameField,
                   topicIdField,
                   isInternalField,
                   partitionsField.Value,
                   topicAuthorizedOperationsField
               ));
           }
           public static int WriteV09(byte[] buffer, int index, MetadataResponseTopic message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               if (message.NameField == null)
                   throw new ArgumentNullException(nameof(message.NameField));
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteBoolean(buffer, index, message.IsInternalField);
               index = Encoder.WriteCompactArray<MetadataResponsePartition>(buffer, index, message.PartitionsField, MetadataResponsePartitionSerde.WriteV09);
               index = Encoder.WriteInt32(buffer, index, message.TopicAuthorizedOperationsField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, MetadataResponseTopic Value) ReadV10(byte[] buffer, int index)
           {
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               (index, var topicIdField) = Decoder.ReadUuid(buffer, index);
               (index, var isInternalField) = Decoder.ReadBoolean(buffer, index);
               (index, var partitionsField) = Decoder.ReadCompactArray<MetadataResponsePartition>(buffer, index, MetadataResponsePartitionSerde.ReadV10);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               (index, var topicAuthorizedOperationsField) = Decoder.ReadInt32(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   errorCodeField,
                   nameField,
                   topicIdField,
                   isInternalField,
                   partitionsField.Value,
                   topicAuthorizedOperationsField
               ));
           }
           public static int WriteV10(byte[] buffer, int index, MetadataResponseTopic message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               if (message.NameField == null)
                   throw new ArgumentNullException(nameof(message.NameField));
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteUuid(buffer, index, message.TopicIdField);
               index = Encoder.WriteBoolean(buffer, index, message.IsInternalField);
               index = Encoder.WriteCompactArray<MetadataResponsePartition>(buffer, index, message.PartitionsField, MetadataResponsePartitionSerde.WriteV10);
               index = Encoder.WriteInt32(buffer, index, message.TopicAuthorizedOperationsField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, MetadataResponseTopic Value) ReadV11(byte[] buffer, int index)
           {
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               (index, var topicIdField) = Decoder.ReadUuid(buffer, index);
               (index, var isInternalField) = Decoder.ReadBoolean(buffer, index);
               (index, var partitionsField) = Decoder.ReadCompactArray<MetadataResponsePartition>(buffer, index, MetadataResponsePartitionSerde.ReadV11);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               (index, var topicAuthorizedOperationsField) = Decoder.ReadInt32(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   errorCodeField,
                   nameField,
                   topicIdField,
                   isInternalField,
                   partitionsField.Value,
                   topicAuthorizedOperationsField
               ));
           }
           public static int WriteV11(byte[] buffer, int index, MetadataResponseTopic message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               if (message.NameField == null)
                   throw new ArgumentNullException(nameof(message.NameField));
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteUuid(buffer, index, message.TopicIdField);
               index = Encoder.WriteBoolean(buffer, index, message.IsInternalField);
               index = Encoder.WriteCompactArray<MetadataResponsePartition>(buffer, index, message.PartitionsField, MetadataResponsePartitionSerde.WriteV11);
               index = Encoder.WriteInt32(buffer, index, message.TopicAuthorizedOperationsField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, MetadataResponseTopic Value) ReadV12(byte[] buffer, int index)
           {
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var nameField) = Decoder.ReadCompactNullableString(buffer, index);
               (index, var topicIdField) = Decoder.ReadUuid(buffer, index);
               (index, var isInternalField) = Decoder.ReadBoolean(buffer, index);
               (index, var partitionsField) = Decoder.ReadCompactArray<MetadataResponsePartition>(buffer, index, MetadataResponsePartitionSerde.ReadV12);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               (index, var topicAuthorizedOperationsField) = Decoder.ReadInt32(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   errorCodeField,
                   nameField,
                   topicIdField,
                   isInternalField,
                   partitionsField.Value,
                   topicAuthorizedOperationsField
               ));
           }
           public static int WriteV12(byte[] buffer, int index, MetadataResponseTopic message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteCompactNullableString(buffer, index, message.NameField);
               index = Encoder.WriteUuid(buffer, index, message.TopicIdField);
               index = Encoder.WriteBoolean(buffer, index, message.IsInternalField);
               index = Encoder.WriteCompactArray<MetadataResponsePartition>(buffer, index, message.PartitionsField, MetadataResponsePartitionSerde.WriteV12);
               index = Encoder.WriteInt32(buffer, index, message.TopicAuthorizedOperationsField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class MetadataResponsePartitionSerde
           {
               public static (int Offset, MetadataResponsePartition Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var leaderIdField) = Decoder.ReadInt32(buffer, index);
                   var leaderEpochField = default(int);
                   (index, var replicaNodesField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
                   if (replicaNodesField == null)
                       throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                   (index, var isrNodesField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
                   if (isrNodesField == null)
                       throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                   var offlineReplicasField = ImmutableArray<int>.Empty;
                   return (index, new(
                       errorCodeField,
                       partitionIndexField,
                       leaderIdField,
                       leaderEpochField,
                       replicaNodesField.Value,
                       isrNodesField.Value,
                       offlineReplicasField
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, MetadataResponsePartition message)
               {
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt32(buffer, index, message.LeaderIdField);
                   index = Encoder.WriteArray<int>(buffer, index, message.ReplicaNodesField, Encoder.WriteInt32);
                   index = Encoder.WriteArray<int>(buffer, index, message.IsrNodesField, Encoder.WriteInt32);
                   return index;
               }
               public static (int Offset, MetadataResponsePartition Value) ReadV01(byte[] buffer, int index)
               {
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var leaderIdField) = Decoder.ReadInt32(buffer, index);
                   var leaderEpochField = default(int);
                   (index, var replicaNodesField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
                   if (replicaNodesField == null)
                       throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                   (index, var isrNodesField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
                   if (isrNodesField == null)
                       throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                   var offlineReplicasField = ImmutableArray<int>.Empty;
                   return (index, new(
                       errorCodeField,
                       partitionIndexField,
                       leaderIdField,
                       leaderEpochField,
                       replicaNodesField.Value,
                       isrNodesField.Value,
                       offlineReplicasField
                   ));
               }
               public static int WriteV01(byte[] buffer, int index, MetadataResponsePartition message)
               {
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt32(buffer, index, message.LeaderIdField);
                   index = Encoder.WriteArray<int>(buffer, index, message.ReplicaNodesField, Encoder.WriteInt32);
                   index = Encoder.WriteArray<int>(buffer, index, message.IsrNodesField, Encoder.WriteInt32);
                   return index;
               }
               public static (int Offset, MetadataResponsePartition Value) ReadV02(byte[] buffer, int index)
               {
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var leaderIdField) = Decoder.ReadInt32(buffer, index);
                   var leaderEpochField = default(int);
                   (index, var replicaNodesField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
                   if (replicaNodesField == null)
                       throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                   (index, var isrNodesField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
                   if (isrNodesField == null)
                       throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                   var offlineReplicasField = ImmutableArray<int>.Empty;
                   return (index, new(
                       errorCodeField,
                       partitionIndexField,
                       leaderIdField,
                       leaderEpochField,
                       replicaNodesField.Value,
                       isrNodesField.Value,
                       offlineReplicasField
                   ));
               }
               public static int WriteV02(byte[] buffer, int index, MetadataResponsePartition message)
               {
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt32(buffer, index, message.LeaderIdField);
                   index = Encoder.WriteArray<int>(buffer, index, message.ReplicaNodesField, Encoder.WriteInt32);
                   index = Encoder.WriteArray<int>(buffer, index, message.IsrNodesField, Encoder.WriteInt32);
                   return index;
               }
               public static (int Offset, MetadataResponsePartition Value) ReadV03(byte[] buffer, int index)
               {
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var leaderIdField) = Decoder.ReadInt32(buffer, index);
                   var leaderEpochField = default(int);
                   (index, var replicaNodesField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
                   if (replicaNodesField == null)
                       throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                   (index, var isrNodesField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
                   if (isrNodesField == null)
                       throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                   var offlineReplicasField = ImmutableArray<int>.Empty;
                   return (index, new(
                       errorCodeField,
                       partitionIndexField,
                       leaderIdField,
                       leaderEpochField,
                       replicaNodesField.Value,
                       isrNodesField.Value,
                       offlineReplicasField
                   ));
               }
               public static int WriteV03(byte[] buffer, int index, MetadataResponsePartition message)
               {
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt32(buffer, index, message.LeaderIdField);
                   index = Encoder.WriteArray<int>(buffer, index, message.ReplicaNodesField, Encoder.WriteInt32);
                   index = Encoder.WriteArray<int>(buffer, index, message.IsrNodesField, Encoder.WriteInt32);
                   return index;
               }
               public static (int Offset, MetadataResponsePartition Value) ReadV04(byte[] buffer, int index)
               {
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var leaderIdField) = Decoder.ReadInt32(buffer, index);
                   var leaderEpochField = default(int);
                   (index, var replicaNodesField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
                   if (replicaNodesField == null)
                       throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                   (index, var isrNodesField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
                   if (isrNodesField == null)
                       throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                   var offlineReplicasField = ImmutableArray<int>.Empty;
                   return (index, new(
                       errorCodeField,
                       partitionIndexField,
                       leaderIdField,
                       leaderEpochField,
                       replicaNodesField.Value,
                       isrNodesField.Value,
                       offlineReplicasField
                   ));
               }
               public static int WriteV04(byte[] buffer, int index, MetadataResponsePartition message)
               {
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt32(buffer, index, message.LeaderIdField);
                   index = Encoder.WriteArray<int>(buffer, index, message.ReplicaNodesField, Encoder.WriteInt32);
                   index = Encoder.WriteArray<int>(buffer, index, message.IsrNodesField, Encoder.WriteInt32);
                   return index;
               }
               public static (int Offset, MetadataResponsePartition Value) ReadV05(byte[] buffer, int index)
               {
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var leaderIdField) = Decoder.ReadInt32(buffer, index);
                   var leaderEpochField = default(int);
                   (index, var replicaNodesField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
                   if (replicaNodesField == null)
                       throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                   (index, var isrNodesField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
                   if (isrNodesField == null)
                       throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                   (index, var offlineReplicasField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
                   if (offlineReplicasField == null)
                       throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                   return (index, new(
                       errorCodeField,
                       partitionIndexField,
                       leaderIdField,
                       leaderEpochField,
                       replicaNodesField.Value,
                       isrNodesField.Value,
                       offlineReplicasField.Value
                   ));
               }
               public static int WriteV05(byte[] buffer, int index, MetadataResponsePartition message)
               {
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt32(buffer, index, message.LeaderIdField);
                   index = Encoder.WriteArray<int>(buffer, index, message.ReplicaNodesField, Encoder.WriteInt32);
                   index = Encoder.WriteArray<int>(buffer, index, message.IsrNodesField, Encoder.WriteInt32);
                   index = Encoder.WriteArray<int>(buffer, index, message.OfflineReplicasField, Encoder.WriteInt32);
                   return index;
               }
               public static (int Offset, MetadataResponsePartition Value) ReadV06(byte[] buffer, int index)
               {
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var leaderIdField) = Decoder.ReadInt32(buffer, index);
                   var leaderEpochField = default(int);
                   (index, var replicaNodesField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
                   if (replicaNodesField == null)
                       throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                   (index, var isrNodesField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
                   if (isrNodesField == null)
                       throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                   (index, var offlineReplicasField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
                   if (offlineReplicasField == null)
                       throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                   return (index, new(
                       errorCodeField,
                       partitionIndexField,
                       leaderIdField,
                       leaderEpochField,
                       replicaNodesField.Value,
                       isrNodesField.Value,
                       offlineReplicasField.Value
                   ));
               }
               public static int WriteV06(byte[] buffer, int index, MetadataResponsePartition message)
               {
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt32(buffer, index, message.LeaderIdField);
                   index = Encoder.WriteArray<int>(buffer, index, message.ReplicaNodesField, Encoder.WriteInt32);
                   index = Encoder.WriteArray<int>(buffer, index, message.IsrNodesField, Encoder.WriteInt32);
                   index = Encoder.WriteArray<int>(buffer, index, message.OfflineReplicasField, Encoder.WriteInt32);
                   return index;
               }
               public static (int Offset, MetadataResponsePartition Value) ReadV07(byte[] buffer, int index)
               {
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var leaderIdField) = Decoder.ReadInt32(buffer, index);
                   (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
                   (index, var replicaNodesField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
                   if (replicaNodesField == null)
                       throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                   (index, var isrNodesField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
                   if (isrNodesField == null)
                       throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                   (index, var offlineReplicasField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
                   if (offlineReplicasField == null)
                       throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                   return (index, new(
                       errorCodeField,
                       partitionIndexField,
                       leaderIdField,
                       leaderEpochField,
                       replicaNodesField.Value,
                       isrNodesField.Value,
                       offlineReplicasField.Value
                   ));
               }
               public static int WriteV07(byte[] buffer, int index, MetadataResponsePartition message)
               {
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt32(buffer, index, message.LeaderIdField);
                   index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                   index = Encoder.WriteArray<int>(buffer, index, message.ReplicaNodesField, Encoder.WriteInt32);
                   index = Encoder.WriteArray<int>(buffer, index, message.IsrNodesField, Encoder.WriteInt32);
                   index = Encoder.WriteArray<int>(buffer, index, message.OfflineReplicasField, Encoder.WriteInt32);
                   return index;
               }
               public static (int Offset, MetadataResponsePartition Value) ReadV08(byte[] buffer, int index)
               {
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var leaderIdField) = Decoder.ReadInt32(buffer, index);
                   (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
                   (index, var replicaNodesField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
                   if (replicaNodesField == null)
                       throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                   (index, var isrNodesField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
                   if (isrNodesField == null)
                       throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                   (index, var offlineReplicasField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
                   if (offlineReplicasField == null)
                       throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                   return (index, new(
                       errorCodeField,
                       partitionIndexField,
                       leaderIdField,
                       leaderEpochField,
                       replicaNodesField.Value,
                       isrNodesField.Value,
                       offlineReplicasField.Value
                   ));
               }
               public static int WriteV08(byte[] buffer, int index, MetadataResponsePartition message)
               {
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt32(buffer, index, message.LeaderIdField);
                   index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                   index = Encoder.WriteArray<int>(buffer, index, message.ReplicaNodesField, Encoder.WriteInt32);
                   index = Encoder.WriteArray<int>(buffer, index, message.IsrNodesField, Encoder.WriteInt32);
                   index = Encoder.WriteArray<int>(buffer, index, message.OfflineReplicasField, Encoder.WriteInt32);
                   return index;
               }
               public static (int Offset, MetadataResponsePartition Value) ReadV09(byte[] buffer, int index)
               {
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var leaderIdField) = Decoder.ReadInt32(buffer, index);
                   (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
                   (index, var replicaNodesField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
                   if (replicaNodesField == null)
                       throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                   (index, var isrNodesField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
                   if (isrNodesField == null)
                       throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                   (index, var offlineReplicasField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
                   if (offlineReplicasField == null)
                       throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       errorCodeField,
                       partitionIndexField,
                       leaderIdField,
                       leaderEpochField,
                       replicaNodesField.Value,
                       isrNodesField.Value,
                       offlineReplicasField.Value
                   ));
               }
               public static int WriteV09(byte[] buffer, int index, MetadataResponsePartition message)
               {
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt32(buffer, index, message.LeaderIdField);
                   index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                   index = Encoder.WriteCompactArray<int>(buffer, index, message.ReplicaNodesField, Encoder.WriteInt32);
                   index = Encoder.WriteCompactArray<int>(buffer, index, message.IsrNodesField, Encoder.WriteInt32);
                   index = Encoder.WriteCompactArray<int>(buffer, index, message.OfflineReplicasField, Encoder.WriteInt32);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
               public static (int Offset, MetadataResponsePartition Value) ReadV10(byte[] buffer, int index)
               {
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var leaderIdField) = Decoder.ReadInt32(buffer, index);
                   (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
                   (index, var replicaNodesField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
                   if (replicaNodesField == null)
                       throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                   (index, var isrNodesField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
                   if (isrNodesField == null)
                       throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                   (index, var offlineReplicasField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
                   if (offlineReplicasField == null)
                       throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       errorCodeField,
                       partitionIndexField,
                       leaderIdField,
                       leaderEpochField,
                       replicaNodesField.Value,
                       isrNodesField.Value,
                       offlineReplicasField.Value
                   ));
               }
               public static int WriteV10(byte[] buffer, int index, MetadataResponsePartition message)
               {
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt32(buffer, index, message.LeaderIdField);
                   index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                   index = Encoder.WriteCompactArray<int>(buffer, index, message.ReplicaNodesField, Encoder.WriteInt32);
                   index = Encoder.WriteCompactArray<int>(buffer, index, message.IsrNodesField, Encoder.WriteInt32);
                   index = Encoder.WriteCompactArray<int>(buffer, index, message.OfflineReplicasField, Encoder.WriteInt32);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
               public static (int Offset, MetadataResponsePartition Value) ReadV11(byte[] buffer, int index)
               {
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var leaderIdField) = Decoder.ReadInt32(buffer, index);
                   (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
                   (index, var replicaNodesField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
                   if (replicaNodesField == null)
                       throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                   (index, var isrNodesField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
                   if (isrNodesField == null)
                       throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                   (index, var offlineReplicasField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
                   if (offlineReplicasField == null)
                       throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       errorCodeField,
                       partitionIndexField,
                       leaderIdField,
                       leaderEpochField,
                       replicaNodesField.Value,
                       isrNodesField.Value,
                       offlineReplicasField.Value
                   ));
               }
               public static int WriteV11(byte[] buffer, int index, MetadataResponsePartition message)
               {
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt32(buffer, index, message.LeaderIdField);
                   index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                   index = Encoder.WriteCompactArray<int>(buffer, index, message.ReplicaNodesField, Encoder.WriteInt32);
                   index = Encoder.WriteCompactArray<int>(buffer, index, message.IsrNodesField, Encoder.WriteInt32);
                   index = Encoder.WriteCompactArray<int>(buffer, index, message.OfflineReplicasField, Encoder.WriteInt32);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
               public static (int Offset, MetadataResponsePartition Value) ReadV12(byte[] buffer, int index)
               {
                   (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
                   (index, var partitionIndexField) = Decoder.ReadInt32(buffer, index);
                   (index, var leaderIdField) = Decoder.ReadInt32(buffer, index);
                   (index, var leaderEpochField) = Decoder.ReadInt32(buffer, index);
                   (index, var replicaNodesField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
                   if (replicaNodesField == null)
                       throw new NullReferenceException("Null not allowed for 'ReplicaNodes'");
                   (index, var isrNodesField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
                   if (isrNodesField == null)
                       throw new NullReferenceException("Null not allowed for 'IsrNodes'");
                   (index, var offlineReplicasField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
                   if (offlineReplicasField == null)
                       throw new NullReferenceException("Null not allowed for 'OfflineReplicas'");
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       errorCodeField,
                       partitionIndexField,
                       leaderIdField,
                       leaderEpochField,
                       replicaNodesField.Value,
                       isrNodesField.Value,
                       offlineReplicasField.Value
                   ));
               }
               public static int WriteV12(byte[] buffer, int index, MetadataResponsePartition message)
               {
                   index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                   index = Encoder.WriteInt32(buffer, index, message.PartitionIndexField);
                   index = Encoder.WriteInt32(buffer, index, message.LeaderIdField);
                   index = Encoder.WriteInt32(buffer, index, message.LeaderEpochField);
                   index = Encoder.WriteCompactArray<int>(buffer, index, message.ReplicaNodesField, Encoder.WriteInt32);
                   index = Encoder.WriteCompactArray<int>(buffer, index, message.IsrNodesField, Encoder.WriteInt32);
                   index = Encoder.WriteCompactArray<int>(buffer, index, message.OfflineReplicasField, Encoder.WriteInt32);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
           }
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class MetadataResponseBrokerSerde
       {
           public static (int Offset, MetadataResponseBroker Value) ReadV00(byte[] buffer, int index)
           {
               (index, var nodeIdField) = Decoder.ReadInt32(buffer, index);
               (index, var hostField) = Decoder.ReadString(buffer, index);
               (index, var portField) = Decoder.ReadInt32(buffer, index);
               var rackField = default(string?);
               return (index, new(
                   nodeIdField,
                   hostField,
                   portField,
                   rackField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, MetadataResponseBroker message)
           {
               index = Encoder.WriteInt32(buffer, index, message.NodeIdField);
               index = Encoder.WriteString(buffer, index, message.HostField);
               index = Encoder.WriteInt32(buffer, index, message.PortField);
               return index;
           }
           public static (int Offset, MetadataResponseBroker Value) ReadV01(byte[] buffer, int index)
           {
               (index, var nodeIdField) = Decoder.ReadInt32(buffer, index);
               (index, var hostField) = Decoder.ReadString(buffer, index);
               (index, var portField) = Decoder.ReadInt32(buffer, index);
               (index, var rackField) = Decoder.ReadNullableString(buffer, index);
               return (index, new(
                   nodeIdField,
                   hostField,
                   portField,
                   rackField
               ));
           }
           public static int WriteV01(byte[] buffer, int index, MetadataResponseBroker message)
           {
               index = Encoder.WriteInt32(buffer, index, message.NodeIdField);
               index = Encoder.WriteString(buffer, index, message.HostField);
               index = Encoder.WriteInt32(buffer, index, message.PortField);
               index = Encoder.WriteNullableString(buffer, index, message.RackField);
               return index;
           }
           public static (int Offset, MetadataResponseBroker Value) ReadV02(byte[] buffer, int index)
           {
               (index, var nodeIdField) = Decoder.ReadInt32(buffer, index);
               (index, var hostField) = Decoder.ReadString(buffer, index);
               (index, var portField) = Decoder.ReadInt32(buffer, index);
               (index, var rackField) = Decoder.ReadNullableString(buffer, index);
               return (index, new(
                   nodeIdField,
                   hostField,
                   portField,
                   rackField
               ));
           }
           public static int WriteV02(byte[] buffer, int index, MetadataResponseBroker message)
           {
               index = Encoder.WriteInt32(buffer, index, message.NodeIdField);
               index = Encoder.WriteString(buffer, index, message.HostField);
               index = Encoder.WriteInt32(buffer, index, message.PortField);
               index = Encoder.WriteNullableString(buffer, index, message.RackField);
               return index;
           }
           public static (int Offset, MetadataResponseBroker Value) ReadV03(byte[] buffer, int index)
           {
               (index, var nodeIdField) = Decoder.ReadInt32(buffer, index);
               (index, var hostField) = Decoder.ReadString(buffer, index);
               (index, var portField) = Decoder.ReadInt32(buffer, index);
               (index, var rackField) = Decoder.ReadNullableString(buffer, index);
               return (index, new(
                   nodeIdField,
                   hostField,
                   portField,
                   rackField
               ));
           }
           public static int WriteV03(byte[] buffer, int index, MetadataResponseBroker message)
           {
               index = Encoder.WriteInt32(buffer, index, message.NodeIdField);
               index = Encoder.WriteString(buffer, index, message.HostField);
               index = Encoder.WriteInt32(buffer, index, message.PortField);
               index = Encoder.WriteNullableString(buffer, index, message.RackField);
               return index;
           }
           public static (int Offset, MetadataResponseBroker Value) ReadV04(byte[] buffer, int index)
           {
               (index, var nodeIdField) = Decoder.ReadInt32(buffer, index);
               (index, var hostField) = Decoder.ReadString(buffer, index);
               (index, var portField) = Decoder.ReadInt32(buffer, index);
               (index, var rackField) = Decoder.ReadNullableString(buffer, index);
               return (index, new(
                   nodeIdField,
                   hostField,
                   portField,
                   rackField
               ));
           }
           public static int WriteV04(byte[] buffer, int index, MetadataResponseBroker message)
           {
               index = Encoder.WriteInt32(buffer, index, message.NodeIdField);
               index = Encoder.WriteString(buffer, index, message.HostField);
               index = Encoder.WriteInt32(buffer, index, message.PortField);
               index = Encoder.WriteNullableString(buffer, index, message.RackField);
               return index;
           }
           public static (int Offset, MetadataResponseBroker Value) ReadV05(byte[] buffer, int index)
           {
               (index, var nodeIdField) = Decoder.ReadInt32(buffer, index);
               (index, var hostField) = Decoder.ReadString(buffer, index);
               (index, var portField) = Decoder.ReadInt32(buffer, index);
               (index, var rackField) = Decoder.ReadNullableString(buffer, index);
               return (index, new(
                   nodeIdField,
                   hostField,
                   portField,
                   rackField
               ));
           }
           public static int WriteV05(byte[] buffer, int index, MetadataResponseBroker message)
           {
               index = Encoder.WriteInt32(buffer, index, message.NodeIdField);
               index = Encoder.WriteString(buffer, index, message.HostField);
               index = Encoder.WriteInt32(buffer, index, message.PortField);
               index = Encoder.WriteNullableString(buffer, index, message.RackField);
               return index;
           }
           public static (int Offset, MetadataResponseBroker Value) ReadV06(byte[] buffer, int index)
           {
               (index, var nodeIdField) = Decoder.ReadInt32(buffer, index);
               (index, var hostField) = Decoder.ReadString(buffer, index);
               (index, var portField) = Decoder.ReadInt32(buffer, index);
               (index, var rackField) = Decoder.ReadNullableString(buffer, index);
               return (index, new(
                   nodeIdField,
                   hostField,
                   portField,
                   rackField
               ));
           }
           public static int WriteV06(byte[] buffer, int index, MetadataResponseBroker message)
           {
               index = Encoder.WriteInt32(buffer, index, message.NodeIdField);
               index = Encoder.WriteString(buffer, index, message.HostField);
               index = Encoder.WriteInt32(buffer, index, message.PortField);
               index = Encoder.WriteNullableString(buffer, index, message.RackField);
               return index;
           }
           public static (int Offset, MetadataResponseBroker Value) ReadV07(byte[] buffer, int index)
           {
               (index, var nodeIdField) = Decoder.ReadInt32(buffer, index);
               (index, var hostField) = Decoder.ReadString(buffer, index);
               (index, var portField) = Decoder.ReadInt32(buffer, index);
               (index, var rackField) = Decoder.ReadNullableString(buffer, index);
               return (index, new(
                   nodeIdField,
                   hostField,
                   portField,
                   rackField
               ));
           }
           public static int WriteV07(byte[] buffer, int index, MetadataResponseBroker message)
           {
               index = Encoder.WriteInt32(buffer, index, message.NodeIdField);
               index = Encoder.WriteString(buffer, index, message.HostField);
               index = Encoder.WriteInt32(buffer, index, message.PortField);
               index = Encoder.WriteNullableString(buffer, index, message.RackField);
               return index;
           }
           public static (int Offset, MetadataResponseBroker Value) ReadV08(byte[] buffer, int index)
           {
               (index, var nodeIdField) = Decoder.ReadInt32(buffer, index);
               (index, var hostField) = Decoder.ReadString(buffer, index);
               (index, var portField) = Decoder.ReadInt32(buffer, index);
               (index, var rackField) = Decoder.ReadNullableString(buffer, index);
               return (index, new(
                   nodeIdField,
                   hostField,
                   portField,
                   rackField
               ));
           }
           public static int WriteV08(byte[] buffer, int index, MetadataResponseBroker message)
           {
               index = Encoder.WriteInt32(buffer, index, message.NodeIdField);
               index = Encoder.WriteString(buffer, index, message.HostField);
               index = Encoder.WriteInt32(buffer, index, message.PortField);
               index = Encoder.WriteNullableString(buffer, index, message.RackField);
               return index;
           }
           public static (int Offset, MetadataResponseBroker Value) ReadV09(byte[] buffer, int index)
           {
               (index, var nodeIdField) = Decoder.ReadInt32(buffer, index);
               (index, var hostField) = Decoder.ReadCompactString(buffer, index);
               (index, var portField) = Decoder.ReadInt32(buffer, index);
               (index, var rackField) = Decoder.ReadCompactNullableString(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nodeIdField,
                   hostField,
                   portField,
                   rackField
               ));
           }
           public static int WriteV09(byte[] buffer, int index, MetadataResponseBroker message)
           {
               index = Encoder.WriteInt32(buffer, index, message.NodeIdField);
               index = Encoder.WriteCompactString(buffer, index, message.HostField);
               index = Encoder.WriteInt32(buffer, index, message.PortField);
               index = Encoder.WriteCompactNullableString(buffer, index, message.RackField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, MetadataResponseBroker Value) ReadV10(byte[] buffer, int index)
           {
               (index, var nodeIdField) = Decoder.ReadInt32(buffer, index);
               (index, var hostField) = Decoder.ReadCompactString(buffer, index);
               (index, var portField) = Decoder.ReadInt32(buffer, index);
               (index, var rackField) = Decoder.ReadCompactNullableString(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nodeIdField,
                   hostField,
                   portField,
                   rackField
               ));
           }
           public static int WriteV10(byte[] buffer, int index, MetadataResponseBroker message)
           {
               index = Encoder.WriteInt32(buffer, index, message.NodeIdField);
               index = Encoder.WriteCompactString(buffer, index, message.HostField);
               index = Encoder.WriteInt32(buffer, index, message.PortField);
               index = Encoder.WriteCompactNullableString(buffer, index, message.RackField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, MetadataResponseBroker Value) ReadV11(byte[] buffer, int index)
           {
               (index, var nodeIdField) = Decoder.ReadInt32(buffer, index);
               (index, var hostField) = Decoder.ReadCompactString(buffer, index);
               (index, var portField) = Decoder.ReadInt32(buffer, index);
               (index, var rackField) = Decoder.ReadCompactNullableString(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nodeIdField,
                   hostField,
                   portField,
                   rackField
               ));
           }
           public static int WriteV11(byte[] buffer, int index, MetadataResponseBroker message)
           {
               index = Encoder.WriteInt32(buffer, index, message.NodeIdField);
               index = Encoder.WriteCompactString(buffer, index, message.HostField);
               index = Encoder.WriteInt32(buffer, index, message.PortField);
               index = Encoder.WriteCompactNullableString(buffer, index, message.RackField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           public static (int Offset, MetadataResponseBroker Value) ReadV12(byte[] buffer, int index)
           {
               (index, var nodeIdField) = Decoder.ReadInt32(buffer, index);
               (index, var hostField) = Decoder.ReadCompactString(buffer, index);
               (index, var portField) = Decoder.ReadInt32(buffer, index);
               (index, var rackField) = Decoder.ReadCompactNullableString(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nodeIdField,
                   hostField,
                   portField,
                   rackField
               ));
           }
           public static int WriteV12(byte[] buffer, int index, MetadataResponseBroker message)
           {
               index = Encoder.WriteInt32(buffer, index, message.NodeIdField);
               index = Encoder.WriteCompactString(buffer, index, message.HostField);
               index = Encoder.WriteInt32(buffer, index, message.PortField);
               index = Encoder.WriteCompactNullableString(buffer, index, message.RackField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
   }
}