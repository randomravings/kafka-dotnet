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
        public static AlterClientQuotasRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, AlterClientQuotasRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static AlterClientQuotasRequest ReadV00(byte[] buffer, ref int index)
        {
            var entriesField = Decoder.ReadArray<EntryData>(buffer, ref index, EntryDataSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Entries'");
            var validateOnlyField = Decoder.ReadBoolean(buffer, ref index);
            return new(
                entriesField,
                validateOnlyField
            );
        }
        private static int WriteV00(byte[] buffer, int index, AlterClientQuotasRequest message)
        {
            index = Encoder.WriteArray<EntryData>(buffer, index, message.EntriesField, EntryDataSerde.WriteV00);
            index = Encoder.WriteBoolean(buffer, index, message.ValidateOnlyField);
            return index;
        }
        private static AlterClientQuotasRequest ReadV01(byte[] buffer, ref int index)
        {
            var entriesField = Decoder.ReadCompactArray<EntryData>(buffer, ref index, EntryDataSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Entries'");
            var validateOnlyField = Decoder.ReadBoolean(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                entriesField,
                validateOnlyField
            );
        }
        private static int WriteV01(byte[] buffer, int index, AlterClientQuotasRequest message)
        {
            index = Encoder.WriteCompactArray<EntryData>(buffer, index, message.EntriesField, EntryDataSerde.WriteV01);
            index = Encoder.WriteBoolean(buffer, index, message.ValidateOnlyField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class EntryDataSerde
        {
            public static EntryData ReadV00(byte[] buffer, ref int index)
            {
                var entityField = Decoder.ReadArray<EntityData>(buffer, ref index, EntityDataSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Entity'");
                var opsField = Decoder.ReadArray<OpData>(buffer, ref index, OpDataSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Ops'");
                return new(
                    entityField,
                    opsField
                );
            }
            public static int WriteV00(byte[] buffer, int index, EntryData message)
            {
                index = Encoder.WriteArray<EntityData>(buffer, index, message.EntityField, EntityDataSerde.WriteV00);
                index = Encoder.WriteArray<OpData>(buffer, index, message.OpsField, OpDataSerde.WriteV00);
                return index;
            }
            public static EntryData ReadV01(byte[] buffer, ref int index)
            {
                var entityField = Decoder.ReadCompactArray<EntityData>(buffer, ref index, EntityDataSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Entity'");
                var opsField = Decoder.ReadCompactArray<OpData>(buffer, ref index, OpDataSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Ops'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    entityField,
                    opsField
                );
            }
            public static int WriteV01(byte[] buffer, int index, EntryData message)
            {
                index = Encoder.WriteCompactArray<EntityData>(buffer, index, message.EntityField, EntityDataSerde.WriteV01);
                index = Encoder.WriteCompactArray<OpData>(buffer, index, message.OpsField, OpDataSerde.WriteV01);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class EntityDataSerde
            {
                public static EntityData ReadV00(byte[] buffer, ref int index)
                {
                    var entityTypeField = Decoder.ReadString(buffer, ref index);
                    var entityNameField = Decoder.ReadNullableString(buffer, ref index);
                    return new(
                        entityTypeField,
                        entityNameField
                    );
                }
                public static int WriteV00(byte[] buffer, int index, EntityData message)
                {
                    index = Encoder.WriteString(buffer, index, message.EntityTypeField);
                    index = Encoder.WriteNullableString(buffer, index, message.EntityNameField);
                    return index;
                }
                public static EntityData ReadV01(byte[] buffer, ref int index)
                {
                    var entityTypeField = Decoder.ReadCompactString(buffer, ref index);
                    var entityNameField = Decoder.ReadCompactNullableString(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        entityTypeField,
                        entityNameField
                    );
                }
                public static int WriteV01(byte[] buffer, int index, EntityData message)
                {
                    index = Encoder.WriteCompactString(buffer, index, message.EntityTypeField);
                    index = Encoder.WriteCompactNullableString(buffer, index, message.EntityNameField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
            }
            private static class OpDataSerde
            {
                public static OpData ReadV00(byte[] buffer, ref int index)
                {
                    var keyField = Decoder.ReadString(buffer, ref index);
                    var valueField = Decoder.ReadFloat64(buffer, ref index);
                    var removeField = Decoder.ReadBoolean(buffer, ref index);
                    return new(
                        keyField,
                        valueField,
                        removeField
                    );
                }
                public static int WriteV00(byte[] buffer, int index, OpData message)
                {
                    index = Encoder.WriteString(buffer, index, message.KeyField);
                    index = Encoder.WriteFloat64(buffer, index, message.ValueField);
                    index = Encoder.WriteBoolean(buffer, index, message.RemoveField);
                    return index;
                }
                public static OpData ReadV01(byte[] buffer, ref int index)
                {
                    var keyField = Decoder.ReadCompactString(buffer, ref index);
                    var valueField = Decoder.ReadFloat64(buffer, ref index);
                    var removeField = Decoder.ReadBoolean(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        keyField,
                        valueField,
                        removeField
                    );
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