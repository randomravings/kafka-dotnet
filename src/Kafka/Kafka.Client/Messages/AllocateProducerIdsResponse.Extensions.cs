using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class AllocateProducerIdsResponseSerde
   {
       private static readonly DecodeDelegate<AllocateProducerIdsResponse>[] READ_VERSIONS = {
           ReadV00,
       };
       private static readonly EncodeDelegate<AllocateProducerIdsResponse>[] WRITE_VERSIONS = {
           WriteV00,
};
       public static (int Offset, AllocateProducerIdsResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, AllocateProducerIdsResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, AllocateProducerIdsResponse Value) ReadV00(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var producerIdStartField) = Decoder.ReadInt64(buffer, index);
           (index, var producerIdLenField) = Decoder.ReadInt32(buffer, index);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               producerIdStartField,
               producerIdLenField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, AllocateProducerIdsResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteInt64(buffer, index, message.ProducerIdStartField);
           index = Encoder.WriteInt32(buffer, index, message.ProducerIdLenField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
   }
}