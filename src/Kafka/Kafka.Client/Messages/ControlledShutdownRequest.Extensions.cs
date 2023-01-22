using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class ControlledShutdownRequestSerde
   {
       private static readonly DecodeDelegate<ControlledShutdownRequest>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
       };
       private static readonly EncodeDelegate<ControlledShutdownRequest>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
};
       public static (int Offset, ControlledShutdownRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, ControlledShutdownRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, ControlledShutdownRequest Value) ReadV00(byte[] buffer, int index)
       {
           (index, var brokerIdField) = Decoder.ReadInt32(buffer, index);
           var brokerEpochField = default(long);
           return (index, new(
               brokerIdField,
               brokerEpochField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, ControlledShutdownRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.BrokerIdField);
           return index;
       }
       private static (int Offset, ControlledShutdownRequest Value) ReadV01(byte[] buffer, int index)
       {
           (index, var brokerIdField) = Decoder.ReadInt32(buffer, index);
           var brokerEpochField = default(long);
           return (index, new(
               brokerIdField,
               brokerEpochField
           ));
       }
       private static int WriteV01(byte[] buffer, int index, ControlledShutdownRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.BrokerIdField);
           return index;
       }
       private static (int Offset, ControlledShutdownRequest Value) ReadV02(byte[] buffer, int index)
       {
           (index, var brokerIdField) = Decoder.ReadInt32(buffer, index);
           (index, var brokerEpochField) = Decoder.ReadInt64(buffer, index);
           return (index, new(
               brokerIdField,
               brokerEpochField
           ));
       }
       private static int WriteV02(byte[] buffer, int index, ControlledShutdownRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.BrokerIdField);
           index = Encoder.WriteInt64(buffer, index, message.BrokerEpochField);
           return index;
       }
       private static (int Offset, ControlledShutdownRequest Value) ReadV03(byte[] buffer, int index)
       {
           (index, var brokerIdField) = Decoder.ReadInt32(buffer, index);
           (index, var brokerEpochField) = Decoder.ReadInt64(buffer, index);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               brokerIdField,
               brokerEpochField
           ));
       }
       private static int WriteV03(byte[] buffer, int index, ControlledShutdownRequest message)
       {
           index = Encoder.WriteInt32(buffer, index, message.BrokerIdField);
           index = Encoder.WriteInt64(buffer, index, message.BrokerEpochField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
   }
}