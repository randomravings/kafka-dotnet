using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using EntityData = Kafka.Client.Messages.AlterClientQuotasRequest.EntryData.EntityData;
using OpData = Kafka.Client.Messages.AlterClientQuotasRequest.EntryData.OpData;
using EntryData = Kafka.Client.Messages.AlterClientQuotasRequest.EntryData;

namespace Kafka.Client.Messages
{
   [GeneratedCode("kgen", "1.0.0.0")]
   public static class AlterClientQuotasRequestSerde
   {
       private static readonly DecodeDelegate<AlterClientQuotasRequest>[] READ_VERSIONS = {
           ReadV00,
           ReadV01,
       };
       private static readonly EncodeDelegate<AlterClientQuotasRequest>[] WRITE_VERSIONS = {
           WriteV00,
           WriteV01,
};
       public static (int Offset, AlterClientQuotasRequest Value) Read(byte[] buffer, int index, short version) =>
           READ_VERSIONS[version](buffer, index)
       ;
       public static int Write(byte[] buffer, int index, AlterClientQuotasRequest message, short version) =>
           WRITE_VERSIONS[version](buffer, index, message)
       ;
       private static (int Offset, AlterClientQuotasRequest Value) ReadV00(byte[] buffer, int index)
       {
           (index, var entriesField) = Decoder.ReadArray<EntryData>(buffer, index, EntryDataSerde.ReadV00);
           if (entriesField == null)
               throw new NullReferenceException("Null not allowed for 'Entries'");
           (index, var validateOnlyField) = Decoder.ReadBoolean(buffer, index);
           return (index, new(
               entriesField.Value,
               validateOnlyField
           ));
       }
       private static int WriteV00(byte[] buffer, int index, AlterClientQuotasRequest message)
       {
           index = Encoder.WriteArray<EntryData>(buffer, index, message.EntriesField, EntryDataSerde.WriteV00);
           index = Encoder.WriteBoolean(buffer, index, message.ValidateOnlyField);
           return index;
       }
       private static (int Offset, AlterClientQuotasRequest Value) ReadV01(byte[] buffer, int index)
       {
           (index, var entriesField) = Decoder.ReadCompactArray<EntryData>(buffer, index, EntryDataSerde.ReadV01);
           if (entriesField == null)
               throw new NullReferenceException("Null not allowed for 'Entries'");
           (index, var validateOnlyField) = Decoder.ReadBoolean(buffer, index);
           (index, _) = Decoder.ReadVarUInt32(buffer, index);
           return (index, new(
               entriesField.Value,
               validateOnlyField
           ));
       }
       private static int WriteV01(byte[] buffer, int index, AlterClientQuotasRequest message)
       {
           index = Encoder.WriteCompactArray<EntryData>(buffer, index, message.EntriesField, EntryDataSerde.WriteV01);
           index = Encoder.WriteBoolean(buffer, index, message.ValidateOnlyField);
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
               (index, var opsField) = Decoder.ReadArray<OpData>(buffer, index, OpDataSerde.ReadV00);
               if (opsField == null)
                   throw new NullReferenceException("Null not allowed for 'Ops'");
               return (index, new(
                   entityField.Value,
                   opsField.Value
               ));
           }
           public static int WriteV00(byte[] buffer, int index, EntryData message)
           {
               index = Encoder.WriteArray<EntityData>(buffer, index, message.EntityField, EntityDataSerde.WriteV00);
               index = Encoder.WriteArray<OpData>(buffer, index, message.OpsField, OpDataSerde.WriteV00);
               return index;
           }
           public static (int Offset, EntryData Value) ReadV01(byte[] buffer, int index)
           {
               (index, var entityField) = Decoder.ReadCompactArray<EntityData>(buffer, index, EntityDataSerde.ReadV01);
               if (entityField == null)
                   throw new NullReferenceException("Null not allowed for 'Entity'");
               (index, var opsField) = Decoder.ReadCompactArray<OpData>(buffer, index, OpDataSerde.ReadV01);
               if (opsField == null)
                   throw new NullReferenceException("Null not allowed for 'Ops'");
               (index, _) = Decoder.ReadVarUInt32(buffer, index);
               return (index, new(
                   entityField.Value,
                   opsField.Value
               ));
           }
           public static int WriteV01(byte[] buffer, int index, EntryData message)
           {
               index = Encoder.WriteCompactArray<EntityData>(buffer, index, message.EntityField, EntityDataSerde.WriteV01);
               index = Encoder.WriteCompactArray<OpData>(buffer, index, message.OpsField, OpDataSerde.WriteV01);
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
           private static class OpDataSerde
           {
               public static (int Offset, OpData Value) ReadV00(byte[] buffer, int index)
               {
                   (index, var keyField) = Decoder.ReadString(buffer, index);
                   (index, var valueField) = Decoder.ReadFloat64(buffer, index);
                   (index, var removeField) = Decoder.ReadBoolean(buffer, index);
                   return (index, new(
                       keyField,
                       valueField,
                       removeField
                   ));
               }
               public static int WriteV00(byte[] buffer, int index, OpData message)
               {
                   index = Encoder.WriteString(buffer, index, message.KeyField);
                   index = Encoder.WriteFloat64(buffer, index, message.ValueField);
                   index = Encoder.WriteBoolean(buffer, index, message.RemoveField);
                   return index;
               }
               public static (int Offset, OpData Value) ReadV01(byte[] buffer, int index)
               {
                   (index, var keyField) = Decoder.ReadCompactString(buffer, index);
                   (index, var valueField) = Decoder.ReadFloat64(buffer, index);
                   (index, var removeField) = Decoder.ReadBoolean(buffer, index);
                   (index, _) = Decoder.ReadVarUInt32(buffer, index);
                   return (index, new(
                       keyField,
                       valueField,
                       removeField
                   ));
               }
               public static int WriteV01(byte[] buffer, int index, OpData message)
               {
                   index = Encoder.WriteCompactString(buffer, index, message.KeyField);
                   index = Encoder.WriteFloat64(buffer, index, message.ValueField);
                   index = Encoder.WriteBoolean(buffer, index, message.RemoveField);
                   index = Encoder.WriteVarUInt32(buffer, index, 0);
                   return index;
               }
           }
       }
   }
}