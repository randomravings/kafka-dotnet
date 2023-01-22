using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using Kafka.Common.Records;
using TopicProduceData = Kafka.Client.Messages.ProduceRequest.TopicProduceData;
using PartitionProduceData = Kafka.Client.Messages.ProduceRequest.TopicProduceData.PartitionProduceData;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class ProduceRequestSerde
   {
       private static readonly DecodeDelegate<ProduceRequest>[] READ_VERSIONS = {
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
       };
       private static readonly EncodeDelegate<ProduceRequest>[] WRITE_VERSIONS = {
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
};
       public static (int Offset, ProduceRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, ProduceRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, ProduceRequest Value) ReadV00(byte[] buffer, int index)
       {
           var transactionalIdField = default(string?);
           (index, var acksField) = Decoder.ReadInt16(buffer, index);
           (index, var timeoutMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicDataField) = Decoder.ReadArray<TopicProduceData>(buffer, index, TopicProduceDataSerde.ReadV00);
           if (topicDataField == null)
               throw new NullReferenceException("Null not allowed for 'TopicData'");
           return (index, new(
               transactionalIdField,
               acksField,
               timeoutMsField,
               topicDataField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, ProduceRequest message)
       {
           index = Encoder.WriteInt16(buffer, index, message.AcksField);
           index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
           index = Encoder.WriteArray<TopicProduceData>(buffer, index, message.TopicDataField, TopicProduceDataSerde.WriteV00);
           return index;
       }
       private static (int Offset, ProduceRequest Value) ReadV01(byte[] buffer, int index)
       {
           var transactionalIdField = default(string?);
           (index, var acksField) = Decoder.ReadInt16(buffer, index);
           (index, var timeoutMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicDataField) = Decoder.ReadArray<TopicProduceData>(buffer, index, TopicProduceDataSerde.ReadV01);
           if (topicDataField == null)
               throw new NullReferenceException("Null not allowed for 'TopicData'");
           return (index, new(
               transactionalIdField,
               acksField,
               timeoutMsField,
               topicDataField.Value
           ));
       }
       private static int WriteV01(byte[] buffer, int index, ProduceRequest message)
       {
           index = Encoder.WriteInt16(buffer, index, message.AcksField);
           index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
           index = Encoder.WriteArray<TopicProduceData>(buffer, index, message.TopicDataField, TopicProduceDataSerde.WriteV01);
           return index;
       }
       private static (int Offset, ProduceRequest Value) ReadV02(byte[] buffer, int index)
       {
           var transactionalIdField = default(string?);
           (index, var acksField) = Decoder.ReadInt16(buffer, index);
           (index, var timeoutMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicDataField) = Decoder.ReadArray<TopicProduceData>(buffer, index, TopicProduceDataSerde.ReadV02);
           if (topicDataField == null)
               throw new NullReferenceException("Null not allowed for 'TopicData'");
           return (index, new(
               transactionalIdField,
               acksField,
               timeoutMsField,
               topicDataField.Value
           ));
       }
       private static int WriteV02(byte[] buffer, int index, ProduceRequest message)
       {
           index = Encoder.WriteInt16(buffer, index, message.AcksField);
           index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
           index = Encoder.WriteArray<TopicProduceData>(buffer, index, message.TopicDataField, TopicProduceDataSerde.WriteV02);
           return index;
       }
       private static (int Offset, ProduceRequest Value) ReadV03(byte[] buffer, int index)
       {
           (index, var transactionalIdField) = Decoder.ReadNullableString(buffer, index);
           (index, var acksField) = Decoder.ReadInt16(buffer, index);
           (index, var timeoutMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicDataField) = Decoder.ReadArray<TopicProduceData>(buffer, index, TopicProduceDataSerde.ReadV03);
           if (topicDataField == null)
               throw new NullReferenceException("Null not allowed for 'TopicData'");
           return (index, new(
               transactionalIdField,
               acksField,
               timeoutMsField,
               topicDataField.Value
           ));
       }
       private static int WriteV03(byte[] buffer, int index, ProduceRequest message)
       {
           index = Encoder.WriteNullableString(buffer, index, message.TransactionalIdField);
           index = Encoder.WriteInt16(buffer, index, message.AcksField);
           index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
           index = Encoder.WriteArray<TopicProduceData>(buffer, index, message.TopicDataField, TopicProduceDataSerde.WriteV03);
           return index;
       }
       private static (int Offset, ProduceRequest Value) ReadV04(byte[] buffer, int index)
       {
           (index, var transactionalIdField) = Decoder.ReadNullableString(buffer, index);
           (index, var acksField) = Decoder.ReadInt16(buffer, index);
           (index, var timeoutMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicDataField) = Decoder.ReadArray<TopicProduceData>(buffer, index, TopicProduceDataSerde.ReadV04);
           if (topicDataField == null)
               throw new NullReferenceException("Null not allowed for 'TopicData'");
           return (index, new(
               transactionalIdField,
               acksField,
               timeoutMsField,
               topicDataField.Value
           ));
       }
       private static int WriteV04(byte[] buffer, int index, ProduceRequest message)
       {
           index = Encoder.WriteNullableString(buffer, index, message.TransactionalIdField);
           index = Encoder.WriteInt16(buffer, index, message.AcksField);
           index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
           index = Encoder.WriteArray<TopicProduceData>(buffer, index, message.TopicDataField, TopicProduceDataSerde.WriteV04);
           return index;
       }
       private static (int Offset, ProduceRequest Value) ReadV05(byte[] buffer, int index)
       {
           (index, var transactionalIdField) = Decoder.ReadNullableString(buffer, index);
           (index, var acksField) = Decoder.ReadInt16(buffer, index);
           (index, var timeoutMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicDataField) = Decoder.ReadArray<TopicProduceData>(buffer, index, TopicProduceDataSerde.ReadV05);
           if (topicDataField == null)
               throw new NullReferenceException("Null not allowed for 'TopicData'");
           return (index, new(
               transactionalIdField,
               acksField,
               timeoutMsField,
               topicDataField.Value
           ));
       }
       private static int WriteV05(byte[] buffer, int index, ProduceRequest message)
       {
           index = Encoder.WriteNullableString(buffer, index, message.TransactionalIdField);
           index = Encoder.WriteInt16(buffer, index, message.AcksField);
           index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
           index = Encoder.WriteArray<TopicProduceData>(buffer, index, message.TopicDataField, TopicProduceDataSerde.WriteV05);
           return index;
       }
       private static (int Offset, ProduceRequest Value) ReadV06(byte[] buffer, int index)
       {
           (index, var transactionalIdField) = Decoder.ReadNullableString(buffer, index);
           (index, var acksField) = Decoder.ReadInt16(buffer, index);
           (index, var timeoutMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicDataField) = Decoder.ReadArray<TopicProduceData>(buffer, index, TopicProduceDataSerde.ReadV06);
           if (topicDataField == null)
               throw new NullReferenceException("Null not allowed for 'TopicData'");
           return (index, new(
               transactionalIdField,
               acksField,
               timeoutMsField,
               topicDataField.Value
           ));
       }
       private static int WriteV06(byte[] buffer, int index, ProduceRequest message)
       {
           index = Encoder.WriteNullableString(buffer, index, message.TransactionalIdField);
           index = Encoder.WriteInt16(buffer, index, message.AcksField);
           index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
           index = Encoder.WriteArray<TopicProduceData>(buffer, index, message.TopicDataField, TopicProduceDataSerde.WriteV06);
           return index;
       }
       private static (int Offset, ProduceRequest Value) ReadV07(byte[] buffer, int index)
       {
           (index, var transactionalIdField) = Decoder.ReadNullableString(buffer, index);
           (index, var acksField) = Decoder.ReadInt16(buffer, index);
           (index, var timeoutMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicDataField) = Decoder.ReadArray<TopicProduceData>(buffer, index, TopicProduceDataSerde.ReadV07);
           if (topicDataField == null)
               throw new NullReferenceException("Null not allowed for 'TopicData'");
           return (index, new(
               transactionalIdField,
               acksField,
               timeoutMsField,
               topicDataField.Value
           ));
       }
       private static int WriteV07(byte[] buffer, int index, ProduceRequest message)
       {
           index = Encoder.WriteNullableString(buffer, index, message.TransactionalIdField);
           index = Encoder.WriteInt16(buffer, index, message.AcksField);
           index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
           index = Encoder.WriteArray<TopicProduceData>(buffer, index, message.TopicDataField, TopicProduceDataSerde.WriteV07);
           return index;
       }
       private static (int Offset, ProduceRequest Value) ReadV08(byte[] buffer, int index)
       {
           (index, var transactionalIdField) = Decoder.ReadNullableString(buffer, index);
           (index, var acksField) = Decoder.ReadInt16(buffer, index);
           (index, var timeoutMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicDataField) = Decoder.ReadArray<TopicProduceData>(buffer, index, TopicProduceDataSerde.ReadV08);
           if (topicDataField == null)
               throw new NullReferenceException("Null not allowed for 'TopicData'");
           return (index, new(
               transactionalIdField,
               acksField,
               timeoutMsField,
               topicDataField.Value
           ));
       }
       private static int WriteV08(byte[] buffer, int index, ProduceRequest message)
       {
           index = Encoder.WriteNullableString(buffer, index, message.TransactionalIdField);
           index = Encoder.WriteInt16(buffer, index, message.AcksField);
           index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
           index = Encoder.WriteArray<TopicProduceData>(buffer, index, message.TopicDataField, TopicProduceDataSerde.WriteV08);
           return index;
       }
       private static (int Offset, ProduceRequest Value) ReadV09(byte[] buffer, int index)
       {
           (index, var transactionalIdField) = Decoder.ReadCompactNullableString(buffer, index);
           (index, var acksField) = Decoder.ReadInt16(buffer, index);
           (index, var timeoutMsField) = Decoder.ReadInt32(buffer, index);
           (index, var topicDataField) = Decoder.ReadCompactArray<TopicProduceData>(buffer, index, TopicProduceDataSerde.ReadV09);
           if (topicDataField == null)
               throw new NullReferenceException("Null not allowed for 'TopicData'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               transactionalIdField,
               acksField,
               timeoutMsField,
               topicDataField.Value
           ));
       }
       private static int WriteV09(byte[] buffer, int index, ProduceRequest message)
       {
           index = Encoder.WriteCompactNullableString(buffer, index, message.TransactionalIdField);
           index = Encoder.WriteInt16(buffer, index, message.AcksField);
           index = Encoder.WriteInt32(buffer, index, message.TimeoutMsField);
           index = Encoder.WriteCompactArray<TopicProduceData>(buffer, index, message.TopicDataField, TopicProduceDataSerde.WriteV09);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class TopicProduceDataSerde
       {
           public static (int Offset, TopicProduceData Value) ReadV00(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionDataField) = Decoder.ReadArray<PartitionProduceData>(buffer, index, PartitionProduceDataSerde.ReadV00);
               if (partitionDataField == null)
                   throw new NullReferenceException("Null not allowed for 'PartitionData'");
               return (index, new(
                   nameField,
                   partitionDataField.Value
               ));
           }
           public static int WriteV00(byte[] buffer, int index, TopicProduceData message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<PartitionProduceData>(buffer, index, message.PartitionDataField, PartitionProduceDataSerde.WriteV00);
               return index;
           }
           public static (int Offset, TopicProduceData Value) ReadV01(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionDataField) = Decoder.ReadArray<PartitionProduceData>(buffer, index, PartitionProduceDataSerde.ReadV01);
               if (partitionDataField == null)
                   throw new NullReferenceException("Null not allowed for 'PartitionData'");
               return (index, new(
                   nameField,
                   partitionDataField.Value
               ));
           }
           public static int WriteV01(byte[] buffer, int index, TopicProduceData message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<PartitionProduceData>(buffer, index, message.PartitionDataField, PartitionProduceDataSerde.WriteV01);
               return index;
           }
           public static (int Offset, TopicProduceData Value) ReadV02(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionDataField) = Decoder.ReadArray<PartitionProduceData>(buffer, index, PartitionProduceDataSerde.ReadV02);
               if (partitionDataField == null)
                   throw new NullReferenceException("Null not allowed for 'PartitionData'");
               return (index, new(
                   nameField,
                   partitionDataField.Value
               ));
           }
           public static int WriteV02(byte[] buffer, int index, TopicProduceData message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<PartitionProduceData>(buffer, index, message.PartitionDataField, PartitionProduceDataSerde.WriteV02);
               return index;
           }
           public static (int Offset, TopicProduceData Value) ReadV03(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionDataField) = Decoder.ReadArray<PartitionProduceData>(buffer, index, PartitionProduceDataSerde.ReadV03);
               if (partitionDataField == null)
                   throw new NullReferenceException("Null not allowed for 'PartitionData'");
               return (index, new(
                   nameField,
                   partitionDataField.Value
               ));
           }
           public static int WriteV03(byte[] buffer, int index, TopicProduceData message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<PartitionProduceData>(buffer, index, message.PartitionDataField, PartitionProduceDataSerde.WriteV03);
               return index;
           }
           public static (int Offset, TopicProduceData Value) ReadV04(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionDataField) = Decoder.ReadArray<PartitionProduceData>(buffer, index, PartitionProduceDataSerde.ReadV04);
               if (partitionDataField == null)
                   throw new NullReferenceException("Null not allowed for 'PartitionData'");
               return (index, new(
                   nameField,
                   partitionDataField.Value
               ));
           }
           public static int WriteV04(byte[] buffer, int index, TopicProduceData message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<PartitionProduceData>(buffer, index, message.PartitionDataField, PartitionProduceDataSerde.WriteV04);
               return index;
           }
           public static (int Offset, TopicProduceData Value) ReadV05(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionDataField) = Decoder.ReadArray<PartitionProduceData>(buffer, index, PartitionProduceDataSerde.ReadV05);
               if (partitionDataField == null)
                   throw new NullReferenceException("Null not allowed for 'PartitionData'");
               return (index, new(
                   nameField,
                   partitionDataField.Value
               ));
           }
           public static int WriteV05(byte[] buffer, int index, TopicProduceData message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<PartitionProduceData>(buffer, index, message.PartitionDataField, PartitionProduceDataSerde.WriteV05);
               return index;
           }
           public static (int Offset, TopicProduceData Value) ReadV06(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionDataField) = Decoder.ReadArray<PartitionProduceData>(buffer, index, PartitionProduceDataSerde.ReadV06);
               if (partitionDataField == null)
                   throw new NullReferenceException("Null not allowed for 'PartitionData'");
               return (index, new(
                   nameField,
                   partitionDataField.Value
               ));
           }
           public static int WriteV06(byte[] buffer, int index, TopicProduceData message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<PartitionProduceData>(buffer, index, message.PartitionDataField, PartitionProduceDataSerde.WriteV06);
               return index;
           }
           public static (int Offset, TopicProduceData Value) ReadV07(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionDataField) = Decoder.ReadArray<PartitionProduceData>(buffer, index, PartitionProduceDataSerde.ReadV07);
               if (partitionDataField == null)
                   throw new NullReferenceException("Null not allowed for 'PartitionData'");
               return (index, new(
                   nameField,
                   partitionDataField.Value
               ));
           }
           public static int WriteV07(byte[] buffer, int index, TopicProduceData message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<PartitionProduceData>(buffer, index, message.PartitionDataField, PartitionProduceDataSerde.WriteV07);
               return index;
           }
           public static (int Offset, TopicProduceData Value) ReadV08(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadString(buffer, index);
               (index, var partitionDataField) = Decoder.ReadArray<PartitionProduceData>(buffer, index, PartitionProduceDataSerde.ReadV08);
               if (partitionDataField == null)
                   throw new NullReferenceException("Null not allowed for 'PartitionData'");
               return (index, new(
                   nameField,
                   partitionDataField.Value
               ));
           }
           public static int WriteV08(byte[] buffer, int index, TopicProduceData message)
           {
               index = Encoder.WriteString(buffer, index, message.NameField);
               index = Encoder.WriteArray<PartitionProduceData>(buffer, index, message.PartitionDataField, PartitionProduceDataSerde.WriteV08);
               return index;
           }
           public static (int Offset, TopicProduceData Value) ReadV09(byte[] buffer, int index)
           {
               (index, var nameField) = Decoder.ReadCompactString(buffer, index);
               (index, var partitionDataField) = Decoder.ReadCompactArray<PartitionProduceData>(buffer, index, PartitionProduceDataSerde.ReadV09);
               if (partitionDataField == null)
                   throw new NullReferenceException("Null not allowed for 'PartitionData'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   nameField,
                   partitionDataField.Value
               ));
           }
           public static int WriteV09(byte[] buffer, int index, TopicProduceData message)
           {
               index = Encoder.WriteCompactString(buffer, index, message.NameField);
               index = Encoder.WriteCompactArray<PartitionProduceData>(buffer, index, message.PartitionDataField, PartitionProduceDataSerde.WriteV09);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class PartitionProduceDataSerde
           {
               public static (int Offset, PartitionProduceData Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var indexField) = Decoder.ReadInt32(buffer, index);
                   (index, var recordsField) = Decoder.ReadRecords(buffer, index);
                   return (index, new(
                       indexField,
                       recordsField
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, PartitionProduceData message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.IndexField);
                   index = Encoder.WriteRecords(buffer, index, message.RecordsField);
                   return index;
               }
               public static (int Offset, PartitionProduceData Value) ReadV01(byte[] buffer, int index)
               {
                   (index, var indexField) = Decoder.ReadInt32(buffer, index);
                   (index, var recordsField) = Decoder.ReadRecords(buffer, index);
                   return (index, new(
                       indexField,
                       recordsField
                   ));
               }
               public static int WriteV01(byte[] buffer, int index, PartitionProduceData message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.IndexField);
                   index = Encoder.WriteRecords(buffer, index, message.RecordsField);
                   return index;
               }
               public static (int Offset, PartitionProduceData Value) ReadV02(byte[] buffer, int index)
               {
                   (index, var indexField) = Decoder.ReadInt32(buffer, index);
                   (index, var recordsField) = Decoder.ReadRecords(buffer, index);
                   return (index, new(
                       indexField,
                       recordsField
                   ));
               }
               public static int WriteV02(byte[] buffer, int index, PartitionProduceData message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.IndexField);
                   index = Encoder.WriteRecords(buffer, index, message.RecordsField);
                   return index;
               }
               public static (int Offset, PartitionProduceData Value) ReadV03(byte[] buffer, int index)
               {
                   (index, var indexField) = Decoder.ReadInt32(buffer, index);
                   (index, var recordsField) = Decoder.ReadRecords(buffer, index);
                   return (index, new(
                       indexField,
                       recordsField
                   ));
               }
               public static int WriteV03(byte[] buffer, int index, PartitionProduceData message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.IndexField);
                   index = Encoder.WriteRecords(buffer, index, message.RecordsField);
                   return index;
               }
               public static (int Offset, PartitionProduceData Value) ReadV04(byte[] buffer, int index)
               {
                   (index, var indexField) = Decoder.ReadInt32(buffer, index);
                   (index, var recordsField) = Decoder.ReadRecords(buffer, index);
                   return (index, new(
                       indexField,
                       recordsField
                   ));
               }
               public static int WriteV04(byte[] buffer, int index, PartitionProduceData message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.IndexField);
                   index = Encoder.WriteRecords(buffer, index, message.RecordsField);
                   return index;
               }
               public static (int Offset, PartitionProduceData Value) ReadV05(byte[] buffer, int index)
               {
                   (index, var indexField) = Decoder.ReadInt32(buffer, index);
                   (index, var recordsField) = Decoder.ReadRecords(buffer, index);
                   return (index, new(
                       indexField,
                       recordsField
                   ));
               }
               public static int WriteV05(byte[] buffer, int index, PartitionProduceData message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.IndexField);
                   index = Encoder.WriteRecords(buffer, index, message.RecordsField);
                   return index;
               }
               public static (int Offset, PartitionProduceData Value) ReadV06(byte[] buffer, int index)
               {
                   (index, var indexField) = Decoder.ReadInt32(buffer, index);
                   (index, var recordsField) = Decoder.ReadRecords(buffer, index);
                   return (index, new(
                       indexField,
                       recordsField
                   ));
               }
               public static int WriteV06(byte[] buffer, int index, PartitionProduceData message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.IndexField);
                   index = Encoder.WriteRecords(buffer, index, message.RecordsField);
                   return index;
               }
               public static (int Offset, PartitionProduceData Value) ReadV07(byte[] buffer, int index)
               {
                   (index, var indexField) = Decoder.ReadInt32(buffer, index);
                   (index, var recordsField) = Decoder.ReadRecords(buffer, index);
                   return (index, new(
                       indexField,
                       recordsField
                   ));
               }
               public static int WriteV07(byte[] buffer, int index, PartitionProduceData message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.IndexField);
                   index = Encoder.WriteRecords(buffer, index, message.RecordsField);
                   return index;
               }
               public static (int Offset, PartitionProduceData Value) ReadV08(byte[] buffer, int index)
               {
                   (index, var indexField) = Decoder.ReadInt32(buffer, index);
                   (index, var recordsField) = Decoder.ReadRecords(buffer, index);
                   return (index, new(
                       indexField,
                       recordsField
                   ));
               }
               public static int WriteV08(byte[] buffer, int index, PartitionProduceData message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.IndexField);
                   index = Encoder.WriteRecords(buffer, index, message.RecordsField);
                   return index;
               }
               public static (int Offset, PartitionProduceData Value) ReadV09(byte[] buffer, int index)
               {
                   (index, var indexField) = Decoder.ReadInt32(buffer, index);
                   (index, var recordsField) = Decoder.ReadRecords(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       indexField,
                       recordsField
                   ));
               }
               public static int WriteV09(byte[] buffer, int index, PartitionProduceData message)
               {
                   index = Encoder.WriteInt32(buffer, index, message.IndexField);
                   index = Encoder.WriteCompactRecords(buffer, index, message.RecordsField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
           }
       }
   }
}