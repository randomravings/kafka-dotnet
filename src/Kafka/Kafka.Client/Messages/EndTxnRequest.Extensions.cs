using System.CodeDom.Compiler;
using Kafka.Common.Encoding;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class EndTxnRequestSerde
   {
       private static readonly DecodeDelegate<EndTxnRequest>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
       };
       private static readonly EncodeDelegate<EndTxnRequest>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
};
       public static (int Offset, EndTxnRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, EndTxnRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, EndTxnRequest Value) ReadV00(byte[] buffer, int index)
       {
           (index, var transactionalIdField) = Decoder.ReadString(buffer, index);
           (index, var producerIdField) = Decoder.ReadInt64(buffer, index);
           (index, var producerEpochField) = Decoder.ReadInt16(buffer, index);
           (index, var committedField) = Decoder.ReadBoolean(buffer, index);
           return (index, new(
               transactionalIdField,
               producerIdField,
               producerEpochField,
               committedField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, EndTxnRequest message)
       {
           index = Encoder.WriteString(buffer, index, message.TransactionalIdField);
           index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
           index = Encoder.WriteInt16(buffer, index, message.ProducerEpochField);
           index = Encoder.WriteBoolean(buffer, index, message.CommittedField);
           return index;
       }
       private static (int Offset, EndTxnRequest Value) ReadV01(byte[] buffer, int index)
       {
           (index, var transactionalIdField) = Decoder.ReadString(buffer, index);
           (index, var producerIdField) = Decoder.ReadInt64(buffer, index);
           (index, var producerEpochField) = Decoder.ReadInt16(buffer, index);
           (index, var committedField) = Decoder.ReadBoolean(buffer, index);
           return (index, new(
               transactionalIdField,
               producerIdField,
               producerEpochField,
               committedField
           ));
       }
       private static int WriteV01(byte[] buffer, int index, EndTxnRequest message)
       {
           index = Encoder.WriteString(buffer, index, message.TransactionalIdField);
           index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
           index = Encoder.WriteInt16(buffer, index, message.ProducerEpochField);
           index = Encoder.WriteBoolean(buffer, index, message.CommittedField);
           return index;
       }
       private static (int Offset, EndTxnRequest Value) ReadV02(byte[] buffer, int index)
       {
           (index, var transactionalIdField) = Decoder.ReadString(buffer, index);
           (index, var producerIdField) = Decoder.ReadInt64(buffer, index);
           (index, var producerEpochField) = Decoder.ReadInt16(buffer, index);
           (index, var committedField) = Decoder.ReadBoolean(buffer, index);
           return (index, new(
               transactionalIdField,
               producerIdField,
               producerEpochField,
               committedField
           ));
       }
       private static int WriteV02(byte[] buffer, int index, EndTxnRequest message)
       {
           index = Encoder.WriteString(buffer, index, message.TransactionalIdField);
           index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
           index = Encoder.WriteInt16(buffer, index, message.ProducerEpochField);
           index = Encoder.WriteBoolean(buffer, index, message.CommittedField);
           return index;
       }
       private static (int Offset, EndTxnRequest Value) ReadV03(byte[] buffer, int index)
       {
           (index, var transactionalIdField) = Decoder.ReadCompactString(buffer, index);
           (index, var producerIdField) = Decoder.ReadInt64(buffer, index);
           (index, var producerEpochField) = Decoder.ReadInt16(buffer, index);
           (index, var committedField) = Decoder.ReadBoolean(buffer, index);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               transactionalIdField,
               producerIdField,
               producerEpochField,
               committedField
           ));
       }
       private static int WriteV03(byte[] buffer, int index, EndTxnRequest message)
       {
           index = Encoder.WriteCompactString(buffer, index, message.TransactionalIdField);
           index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
           index = Encoder.WriteInt16(buffer, index, message.ProducerEpochField);
           index = Encoder.WriteBoolean(buffer, index, message.CommittedField);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
   }
}