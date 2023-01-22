using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using EntityData = Kafka.Client.Messages.AlterClientQuotasResponse.EntryData.EntityData;
using EntryData = Kafka.Client.Messages.AlterClientQuotasResponse.EntryData;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class AlterClientQuotasResponseSerde
   {
       private static readonly DecodeDelegate<AlterClientQuotasResponse>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
       };
       private static readonly EncodeDelegate<AlterClientQuotasResponse>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
};
       public static (int Offset, AlterClientQuotasResponse Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, AlterClientQuotasResponse message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, AlterClientQuotasResponse Value) ReadV00(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var entriesField) = Decoder.ReadArray<EntryData>(buffer, index, EntryDataSerde.ReadV00);
           if (entriesField == null)
               throw new NullReferenceException("Null not allowed for 'Entries'");
           return (index, new(
               throttleTimeMsField,
               entriesField.Value
           ));
       }
       private static int WriteV00(byte[] buffer, int index, AlterClientQuotasResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteArray<EntryData>(buffer, index, message.EntriesField, EntryDataSerde.WriteV00);
           return index;
       }
       private static (int Offset, AlterClientQuotasResponse Value) ReadV01(byte[] buffer, int index)
       {
           (index, var throttleTimeMsField) = Decoder.ReadInt32(buffer, index);
           (index, var entriesField) = Decoder.ReadCompactArray<EntryData>(buffer, index, EntryDataSerde.ReadV01);
           if (entriesField == null)
               throw new NullReferenceException("Null not allowed for 'Entries'");
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               throttleTimeMsField,
               entriesField.Value
           ));
       }
       private static int WriteV01(byte[] buffer, int index, AlterClientQuotasResponse message)
       {
           index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
           index = Encoder.WriteCompactArray<EntryData>(buffer, index, message.EntriesField, EntryDataSerde.WriteV01);
           index = Encoder.WriteVarUInt32(buffer, index, 0);
           return index;
       }
       [GeneratedCode("kgen", "1.0.0.0")]
       private static class EntryDataSerde
       {
           public static (int Offset, EntryData Value) ReadV00(byte[] buffer, int index)
           {
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var errorMessageField) = Decoder.ReadNullableString(buffer, index);
               (index, var entityField) = Decoder.ReadArray<EntityData>(buffer, index, EntityDataSerde.ReadV00);
               if (entityField == null)
                   throw new NullReferenceException("Null not allowed for 'Entity'");
               return (index, new(
                   errorCodeField,
                   errorMessageField,
                   entityField.Value
               ));
           }
           public static int WriteV00(byte[] buffer, int index, EntryData message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
               index = Encoder.WriteArray<EntityData>(buffer, index, message.EntityField, EntityDataSerde.WriteV00);
               return index;
           }
           public static (int Offset, EntryData Value) ReadV01(byte[] buffer, int index)
           {
               (index, var errorCodeField) = Decoder.ReadInt16(buffer, index);
               (index, var errorMessageField) = Decoder.ReadCompactNullableString(buffer, index);
               (index, var entityField) = Decoder.ReadCompactArray<EntityData>(buffer, index, EntityDataSerde.ReadV01);
               if (entityField == null)
                   throw new NullReferenceException("Null not allowed for 'Entity'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   errorCodeField,
                   errorMessageField,
                   entityField.Value
               ));
           }
           public static int WriteV01(byte[] buffer, int index, EntryData message)
           {
               index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
               index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
               index = Encoder.WriteCompactArray<EntityData>(buffer, index, message.EntityField, EntityDataSerde.WriteV01);
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
       }
   }
}