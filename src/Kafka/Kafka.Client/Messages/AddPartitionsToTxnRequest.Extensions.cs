using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using AddPartitionsToTxnTopic = Kafka.Client.Messages.AddPartitionsToTxnRequest.AddPartitionsToTxnTopic;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class AddPartitionsToTxnRequestSerde
   {
       private static readonly DecodeDelegate<AddPartitionsToTxnRequest>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
           ReadV02,
           ReadV03,
       };
       private static readonly EncodeDelegate<AddPartitionsToTxnRequest>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
           WriteV02,
           WriteV03,
};
       public static (int Offset, AddPartitionsToTxnRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, AddPartitionsToTxnRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, AddPartitionsToTxnRequest Value) ReadV00(byte[] buffer, int index)
       {
           (index, var transactionalIdField) = Decoder.ReadString(buffer, index);
           (index, var producerIdField) = Decoder.ReadInt64(buffer, index);
           (index, var producerEpochField) = Decoder.ReadInt16(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<AddPartitionsToTxnTopic>(buffer, index, AddPartitionsToTxnTopicSerde.ReadV00);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               transactionalIdField,
               producerIdField,
               producerEpochField,
               topicsField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, AddPartitionsToTxnRequest message)
       {
           index = Encoder.WriteString(buffer, index, message.TransactionalIdField);
           index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
           index = Encoder.WriteInt16(buffer, index, message.ProducerEpochField);
           index = Encoder.WriteArray<AddPartitionsToTxnTopic>(buffer, index, message.TopicsField, AddPartitionsToTxnTopicSerde.WriteV00);
           return index;
       }
       private static (int Offset, AddPartitionsToTxnRequest Value) ReadV01(byte[] buffer, int index)
       {
           (index, var transactionalIdField) = Decoder.ReadString(buffer, index);
           (index, var producerIdField) = Decoder.ReadInt64(buffer, index);
           (index, var producerEpochField) = Decoder.ReadInt16(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<AddPartitionsToTxnTopic>(buffer, index, AddPartitionsToTxnTopicSerde.ReadV01);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               transactionalIdField,
               producerIdField,
               producerEpochField,
               topicsField.Value
           ));
       }
       private static int WriteV01(byte[] buffer, int index, AddPartitionsToTxnRequest message)
       {
           index = Encoder.WriteString(buffer, index, message.TransactionalIdField);
           index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
           index = Encoder.WriteInt16(buffer, index, message.ProducerEpochField);
           index = Encoder.WriteArray<AddPartitionsToTxnTopic>(buffer, index, message.TopicsField, AddPartitionsToTxnTopicSerde.WriteV01);
           return index;
       }
       private static (int Offset, AddPartitionsToTxnRequest Value) ReadV02(byte[] buffer, int index)
       {
           (index, var transactionalIdField) = Decoder.ReadString(buffer, index);
           (index, var producerIdField) = Decoder.ReadInt64(buffer, index);
           (index, var producerEpochField) = Decoder.ReadInt16(buffer, index);
           (index, var topicsField) = Decoder.ReadArray<AddPartitionsToTxnTopic>(buffer, index, AddPartitionsToTxnTopicSerde.ReadV02);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           return (index, new(
               transactionalIdField,
               producerIdField,
               producerEpochField,
               topicsField.Value
           ));
       }
       private static int WriteV02(byte[] buffer, int index, AddPartitionsToTxnRequest message)
       {
           index = Encoder.WriteString(buffer, index, message.TransactionalIdField);
           index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
           index = Encoder.WriteInt16(buffer, index, message.ProducerEpochField);
           index = Encoder.WriteArray<AddPartitionsToTxnTopic>(buffer, index, message.TopicsField, AddPartitionsToTxnTopicSerde.WriteV02);
           return index;
       }
       private static (int Offset, AddPartitionsToTxnRequest Value) ReadV03(byte[] buffer, int index)
       {
           (index, var transactionalIdField) = Decoder.ReadCompactString(buffer, index);
           (index, var producerIdField) = Decoder.ReadInt64(buffer, index);
           (index, var producerEpochField) = Decoder.ReadInt16(buffer, index);
           (index, var topicsField) = Decoder.ReadCompactArray<AddPartitionsToTxnTopic>(buffer, index, AddPartitionsToTxnTopicSerde.ReadV03);
           if (topicsField == null)
               throw new NullReferenceException("Null not allowed for 'Topics'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               transactionalIdField,
               producerIdField,
               producerEpochField,
               topicsField.Value
           ));
       }
       private static int WriteV03(byte[] buffer, int index, AddPartitionsToTxnRequest message)
       {
           index = Encoder.WriteCompactString(buffer, index, message.TransactionalIdField);
           index = Encoder.WriteInt64(buffer, index, message.ProducerIdField);
           index = Encoder.WriteInt16(buffer, index, message.ProducerEpochField);
           index = Encoder.WriteCompactArray<AddPartitionsToTxnTopic>(buffer, index, message.TopicsField, AddPartitionsToTxnTopicSerde.WriteV03);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class AddPartitionsToTxnTopicSerde
       {
           public static (int Offset, AddPartitionsToTxnTopic Value) ReadV00(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV00(byte[] buffer, int index, AddPartitionsToTxnTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
               return index;
           }
           public static (int Offset, AddPartitionsToTxnTopic Value) ReadV01(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV01(byte[] buffer, int index, AddPartitionsToTxnTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
               return index;
           }
           public static (int Offset, AddPartitionsToTxnTopic Value) ReadV02(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionsField) = Decoder.ReadArray<int>(buffer, index, Decoder.ReadInt32);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV02(byte[] buffer, int index, AddPartitionsToTxnTopic message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
               return index;
           }
           public static (int Offset, AddPartitionsToTxnTopic Value) ReadV03(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               (index, var partitionsField) = Decoder.ReadCompactArray<int>(buffer, index, Decoder.ReadInt32);
               if (partitionsField == null)
                   throw new NullReferenceException("Null not allowed for 'Partitions'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   partitionsField.Value
               ));
           }
           public static int WriteV03(byte[] buffer, int index, AddPartitionsToTxnTopic message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteCompactArray<int>(buffer, index, message.PartitionsField, Encoder.WriteInt32);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
       }
   }
}