using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using Listener = Kafka.Client.Messages.BrokerRegistrationRequest.Listener;
using Feature = Kafka.Client.Messages.BrokerRegistrationRequest.Feature;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class BrokerRegistrationRequestSerde
   {
       private static readonly DecodeDelegate<BrokerRegistrationRequest>[] READ_VERSIONS = {
           ReadV00,
       };
       private static readonly EncodeDelegate<BrokerRegistrationRequest>[] WRITE_VERSIONS = {
           WriteV00,
};
       public static (int Offset, BrokerRegistrationRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, BrokerRegistrationRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, BrokerRegistrationRequest Value) ReadV00(byte[] buffer, int index)
       {
           (index, var brokerIdField) = Decoder.ReadInt32(buffer, index);
           (index, var clusterIdField) = Decoder.ReadCompactString(buffer, index);
           (index, var incarnationIdField) = Decoder.ReadUuid(buffer, index);
           (index, var listenersField) = Decoder.ReadCompactArray<Listener>(buffer, index, ListenerSerde.ReadV00);
           if (listenersField == null)
               throw new NullReferenceException("Null not allowed for 'Listeners'");
           (index, var featuresField) = Decoder.ReadCompactArray<Feature>(buffer, index, FeatureSerde.ReadV00);
           if (featuresField == null)
               throw new NullReferenceException("Null not allowed for 'Features'");
           (index, var rackField) = Decoder.ReadCompactNullableString(buffer, index);
           var isMigratingZkBrokerField = default(sbyte);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               brokerIdField,
               clusterIdField,
               incarnationIdField,
               listenersField.Value,
               featuresField.Value,
               rackField,
               isMigratingZkBrokerField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, BrokerRegistrationRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.BrokerIdField);
           index = Encoder.WriteCompactString(buffer, index, message.ClusterIdField);
           index = Encoder.WriteUuid(buffer, index, message.IncarnationIdField);
           index = Encoder.WriteCompactArray<Listener>(buffer, index, message.ListenersField, ListenerSerde.WriteV00);
           index = Encoder.WriteCompactArray<Feature>(buffer, index, message.FeaturesField, FeatureSerde.WriteV00);
           index = Encoder.WriteCompactNullableString(buffer, index, message.RackField);
           index = Encoder.WriteInt8(buffer, index, message.IsMigratingZkBrokerField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class ListenerSerde
       {
           public static (int Offset, Listener Value) ReadV00(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               (index, var hostField) = Decoder.ReadCompactString(buffer, index);
               (index, var portField) = Decoder.ReadUInt16(buffer, index);
               (index, var securityProtocolField) = Decoder.ReadInt16(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   hostField,
                   portField,
                   securityProtocolField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, Listener message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteCompactString(buffer, index, message.HostField);
               index = Encoder.WriteUInt16(buffer, index, message.PortField);
               index = Encoder.WriteInt16(buffer, index, message.SecurityProtocolField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class FeatureSerde
       {
           public static (int Offset, Feature Value) ReadV00(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               (index, var minSupportedVersionField) = Decoder.ReadInt16(buffer, index);
               (index, var maxSupportedVersionField) = Decoder.ReadInt16(buffer, index);
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   minSupportedVersionField,
                   maxSupportedVersionField
               ));
           }
           public static int WriteV00(byte[] buffer, int index, Feature message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteInt16(buffer, index, message.MinSupportedVersionField);
               index = Encoder.WriteInt16(buffer, index, message.MaxSupportedVersionField);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
   }
}