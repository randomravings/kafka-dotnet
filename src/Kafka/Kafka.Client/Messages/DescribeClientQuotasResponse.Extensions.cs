using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using EntityData = Kafka.Client.Messages.DescribeClientQuotasResponse.EntryData.EntityData;
using ValueData = Kafka.Client.Messages.DescribeClientQuotasResponse.EntryData.ValueData;
using EntryData = Kafka.Client.Messages.DescribeClientQuotasResponse.EntryData;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class DescribeClientQuotasResponseSerde
   {
       private static readonly DecodeDelegate<DescribeClientQuotasResponse>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
       };
       private static readonly EncodeDelegate<DescribeClientQuotasResponse>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
};
       public static (int Offset, DescribeClientQuotasResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, DescribeClientQuotasResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, DescribeClientQuotasResponse Value) ReadV00(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var errorMessageField) = Decoder.ReadNullableString(buffer, index);
           (index, var entriesField) = Decoder.ReadArray<EntryData>(buffer, index, EntryDataSerde.ReadV00);
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               errorMessageField,
               entriesField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, DescribeClientQuotasResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
           index = Encoder.WriteArray<EntryData>(buffer, index, message.EntriesField, EntryDataSerde.WriteV00);
           return index;
       }
       private static (int Offset, DescribeClientQuotasResponse Value) ReadV01(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
           (index, var errorMessageField) = Decoder.ReadCompactNullableString(buffer, index);
           (index, var entriesField) = Decoder.ReadCompactArray<EntryData>(buffer, index, EntryDataSerde.ReadV01);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               errorCodeField,
               errorMessageField,
               entriesField
           ));
       }
       private static int WriteV01(byte[] buffer, int index, DescribeClientQuotasResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
           index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
           index = Encoder.WriteCompactArray<EntryData>(buffer, index, message.EntriesField, EntryDataSerde.WriteV01);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class EntryDataSerde
       {
           public static (int Offset, EntryData Value) ReadV00(byte[] buffer, int index)
           {
               (index, var entityField) = Decoder.ReadArray<EntityData>(buffer, index, EntityDataSerde.ReadV00);
               if (entityField == null)
                   throw new NullReferenceException("Null not allowed for 'Entity'");
               (index, var valuesField) = Decoder.ReadArray<ValueData>(buffer, index, ValueDataSerde.ReadV00);
               if (valuesField == null)
                   throw new NullReferenceException("Null not allowed for 'Values'");
               return (index, new(
                   entityField.Value,
                   valuesField.Value
               ));
           }
           public static int WriteV00(byte[] buffer, int index, EntryData message)
           {
               index = Encoder.WriteArray<EntityData>(buffer, index, message.EntityField, EntityDataSerde.WriteV00);
               index = Encoder.WriteArray<ValueData>(buffer, index, message.ValuesField, ValueDataSerde.WriteV00);
               return index;
           }
           public static (int Offset, EntryData Value) ReadV01(byte[] buffer, int index)
           {
               (index, var entityField) = Decoder.ReadCompactArray<EntityData>(buffer, index, EntityDataSerde.ReadV01);
               if (entityField == null)
                   throw new NullReferenceException("Null not allowed for 'Entity'");
               (index, var valuesField) = Decoder.ReadCompactArray<ValueData>(buffer, index, ValueDataSerde.ReadV01);
               if (valuesField == null)
                   throw new NullReferenceException("Null not allowed for 'Values'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   entityField.Value,
                   valuesField.Value
               ));
           }
           public static int WriteV01(byte[] buffer, int index, EntryData message)
           {
               index = Encoder.WriteCompactArray<EntityData>(buffer, index, message.EntityField, EntityDataSerde.WriteV01);
               index = Encoder.WriteCompactArray<ValueData>(buffer, index, message.ValuesField, ValueDataSerde.WriteV01);
               index = Encoder.WriteVarUInt32(buffer, index, 0);
               return index;
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class EntityDataSerde
           {
               public static (int Offset, EntityData Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var entityTypeField) = Decoder.ReadString(buffer, index);
                   (index, var entityNameField) = Decoder.ReadNullableString(buffer, index);
                   return (index, new(
                       entityTypeField,
                       entityNameField
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, EntityData message)
               {
                   index = Encoder.WriteString(buffer, index, message.EntityTypeField);
                   index = Encoder.WriteNullableString(buffer, index, message.EntityNameField);
                   return index;
               }
               public static (int Offset, EntityData Value) ReadV01(byte[] buffer, int index)
               {
                   (index, var entityTypeField) = Decoder.ReadCompactString(buffer, index);
                   (index, var entityNameField) = Decoder.ReadCompactNullableString(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       entityTypeField,
                       entityNameField
                   ));
               }
               public static int WriteV01(byte[] buffer, int index, EntityData message)
               {
                   index = Encoder.WriteCompactString(buffer, index, message.EntityTypeField);
                   index = Encoder.WriteCompactNullableString(buffer, index, message.EntityNameField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
           }
           [GeneratedCode("kgen", "1.0.0.0")]
           private static class ValueDataSerde
           {
               public static (int Offset, ValueData Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var keyField) = Decoder.ReadString(buffer, index);
                   (index, var valueField) = Decoder.ReadFloat64(buffer, index);
                   return (index, new(
                       keyField,
                       valueField
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, ValueData message)
               {
                   index = Encoder.WriteString(buffer, index, message.KeyField);
                   index = Encoder.WriteFloat64(buffer, index, message.ValueField);
                   return index;
               }
               public static (int Offset, ValueData Value) ReadV01(byte[] buffer, int index)
               {
                   (index, var keyField) = Decoder.ReadCompactString(buffer, index);
                   (index, var valueField) = Decoder.ReadFloat64(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       keyField,
                       valueField
                   ));
               }
               public static int WriteV01(byte[] buffer, int index, ValueData message)
               {
                   index = Encoder.WriteCompactString(buffer, index, message.KeyField);
                   index = Encoder.WriteFloat64(buffer, index, message.ValueField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
           }
       }
   }
}