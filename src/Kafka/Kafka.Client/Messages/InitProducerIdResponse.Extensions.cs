using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class InitProducerIdResponseSerde
   {
       private static readonly DecodeDelegate<InitProducerIdResponse>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
           ReadV04,
       };
       private static readonly EncodeDelegate<InitProducerIdResponse>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
           WriteV04,
};
       public static (int Offset, InitProducerIdResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, InitProducerIdResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, InitProducerIdResponse Value) ReadV00(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var producerIdField) = Decoder.ReadInt64(buffer, index);
           (index, var producerEpochField) = Decoder.ReadInt16(buffer, index);
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               producerIdField,
               producerEpochField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, InitProducerIdResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
           index = Encoder.WriteInt16(buffer, index, message.ProducerEpochField);
           return index;
       }
       private static (int Offset, InitProducerIdResponse Value) ReadV01(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var producerIdField) = Decoder.ReadInt64(buffer, index);
           (index, var producerEpochField) = Decoder.ReadInt16(buffer, index);
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               producerIdField,
               producerEpochField
           ));
       }
       private static int WriteV01(byte[] buffer, int index, InitProducerIdResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
           index = Encoder.WriteInt16(buffer, index, message.ProducerEpochField);
           return index;
       }
       private static (int Offset, InitProducerIdResponse Value) ReadV02(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var producerIdField) = Decoder.ReadInt64(buffer, index);
           (index, var producerEpochField) = Decoder.ReadInt16(buffer, index);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               producerIdField,
               producerEpochField
           ));
       }
       private static int WriteV02(byte[] buffer, int index, InitProducerIdResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
           index = Encoder.WriteInt16(buffer, index, message.ProducerEpochField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, InitProducerIdResponse Value) ReadV03(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var producerIdField) = Decoder.ReadInt64(buffer, index);
           (index, var producerEpochField) = Decoder.ReadInt16(buffer, index);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               producerIdField,
               producerEpochField
           ));
       }
       private static int WriteV03(byte[] buffer, int index, InitProducerIdResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
           index = Encoder.WriteInt16(buffer, index, message.ProducerEpochField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       private static (int Offset, InitProducerIdResponse Value) ReadV04(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var producerIdField) = Decoder.ReadInt64(buffer, index);
           (index, var producerEpochField) = Decoder.ReadInt16(buffer, index);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               producerIdField,
               producerEpochField
           ));
       }
       private static int WriteV04(byte[] buffer, int index, InitProducerIdResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
           index = Encoder.WriteInt16(buffer, index, message.ProducerEpochField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
   }
}