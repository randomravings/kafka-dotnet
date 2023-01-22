using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class BrokerHeartbeatRequestSerde
   {
       private static readonly DecodeDelegate<BrokerHeartbeatRequest>[] READ_VERSIONS = {
           ReadV00,
       };
       private static readonly EncodeDelegate<BrokerHeartbeatRequest>[] WRITE_VERSIONS = {
           WriteV00,
};
       public static (int Offset, BrokerHeartbeatRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, BrokerHeartbeatRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, BrokerHeartbeatRequest Value) ReadV00(byte[] buffer, int index)
       {
           (index, var brokerIdField) = Decoder.ReadInt32(buffer, index);
           (index, var brokerEpochField) = Decoder.ReadInt64(buffer, index);
           (index, var currentMetadataOffsetField) = Decoder.ReadInt64(buffer, index);
           (index, var wantFenceField) = Decoder.ReadBoolean(buffer, index);
           (index, var wantShutDownField) = Decoder.ReadBoolean(buffer, index);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               brokerIdField,
               brokerEpochField,
               currentMetadataOffsetField,
               wantFenceField,
               wantShutDownField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, BrokerHeartbeatRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.BrokerIdField);
           index = Encoder.WriteInt64(buffer, index, message.BrokerEpochField);
           index = Encoder.WriteInt64(buffer, index, message.CurrentMetadataOffsetField);
           index = Encoder.WriteBoolean(buffer, index, message.WantFenceField);
           index = Encoder.WriteBoolean(buffer, index, message.WantShutDownField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
   }
}