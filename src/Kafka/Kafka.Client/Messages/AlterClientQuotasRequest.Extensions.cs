using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using OpData = Kafka.Client.Messages.AlterClientQuotasRequest.EntryData.OpData;
using EntryData = Kafka.Client.Messages.AlterClientQuotasRequest.EntryData;
using EntityData = Kafka.Client.Messages.AlterClientQuotasRequest.EntryData.EntityData;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AlterClientQuotasRequestSerde
    {
        private static readonly Func<Stream, AlterClientQuotasRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
        };
        private static readonly Action<Stream, AlterClientQuotasRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
        };
        public static AlterClientQuotasRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, AlterClientQuotasRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static AlterClientQuotasRequest ReadV00(Stream buffer)
        {
            var entriesField = Decoder.ReadArray<EntryData>(buffer, b => EntryDataSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Entries'");
            var validateOnlyField = Decoder.ReadBoolean(buffer);
            return new(
                entriesField,
                validateOnlyField
            );
        }
        private static void WriteV00(Stream buffer, AlterClientQuotasRequest message)
        {
            Encoder.WriteArray<EntryData>(buffer, message.EntriesField, (b, i) => EntryDataSerde.WriteV00(b, i));
            Encoder.WriteBoolean(buffer, message.ValidateOnlyField);
        }
        private static AlterClientQuotasRequest ReadV01(Stream buffer)
        {
            var entriesField = Decoder.ReadCompactArray<EntryData>(buffer, b => EntryDataSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Entries'");
            var validateOnlyField = Decoder.ReadBoolean(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                entriesField,
                validateOnlyField
            );
        }
        private static void WriteV01(Stream buffer, AlterClientQuotasRequest message)
        {
            Encoder.WriteCompactArray<EntryData>(buffer, message.EntriesField, (b, i) => EntryDataSerde.WriteV01(b, i));
            Encoder.WriteBoolean(buffer, message.ValidateOnlyField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class EntryDataSerde
        {
            public static EntryData ReadV00(Stream buffer)
            {
                var entityField = Decoder.ReadArray<EntityData>(buffer, b => EntityDataSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Entity'");
                var opsField = Decoder.ReadArray<OpData>(buffer, b => OpDataSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Ops'");
                return new(
                    entityField,
                    opsField
                );
            }
            public static void WriteV00(Stream buffer, EntryData message)
            {
                Encoder.WriteArray<EntityData>(buffer, message.EntityField, (b, i) => EntityDataSerde.WriteV00(b, i));
                Encoder.WriteArray<OpData>(buffer, message.OpsField, (b, i) => OpDataSerde.WriteV00(b, i));
            }
            public static EntryData ReadV01(Stream buffer)
            {
                var entityField = Decoder.ReadCompactArray<EntityData>(buffer, b => EntityDataSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Entity'");
                var opsField = Decoder.ReadCompactArray<OpData>(buffer, b => OpDataSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Ops'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    entityField,
                    opsField
                );
            }
            public static void WriteV01(Stream buffer, EntryData message)
            {
                Encoder.WriteCompactArray<EntityData>(buffer, message.EntityField, (b, i) => EntityDataSerde.WriteV01(b, i));
                Encoder.WriteCompactArray<OpData>(buffer, message.OpsField, (b, i) => OpDataSerde.WriteV01(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class OpDataSerde
            {
                public static OpData ReadV00(Stream buffer)
                {
                    var keyField = Decoder.ReadString(buffer);
                    var valueField = Decoder.ReadFloat64(buffer);
                    var removeField = Decoder.ReadBoolean(buffer);
                    return new(
                        keyField,
                        valueField,
                        removeField
                    );
                }
                public static void WriteV00(Stream buffer, OpData message)
                {
                    Encoder.WriteString(buffer, message.KeyField);
                    Encoder.WriteFloat64(buffer, message.ValueField);
                    Encoder.WriteBoolean(buffer, message.RemoveField);
                }
                public static OpData ReadV01(Stream buffer)
                {
                    var keyField = Decoder.ReadCompactString(buffer);
                    var valueField = Decoder.ReadFloat64(buffer);
                    var removeField = Decoder.ReadBoolean(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        keyField,
                        valueField,
                        removeField
                    );
                }
                public static void WriteV01(Stream buffer, OpData message)
                {
                    Encoder.WriteCompactString(buffer, message.KeyField);
                    Encoder.WriteFloat64(buffer, message.ValueField);
                    Encoder.WriteBoolean(buffer, message.RemoveField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
            }
            private static class EntityDataSerde
            {
                public static EntityData ReadV00(Stream buffer)
                {
                    var entityTypeField = Decoder.ReadString(buffer);
                    var entityNameField = Decoder.ReadNullableString(buffer);
                    return new(
                        entityTypeField,
                        entityNameField
                    );
                }
                public static void WriteV00(Stream buffer, EntityData message)
                {
                    Encoder.WriteString(buffer, message.EntityTypeField);
                    Encoder.WriteNullableString(buffer, message.EntityNameField);
                }
                public static EntityData ReadV01(Stream buffer)
                {
                    var entityTypeField = Decoder.ReadCompactString(buffer);
                    var entityNameField = Decoder.ReadCompactNullableString(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        entityTypeField,
                        entityNameField
                    );
                }
                public static void WriteV01(Stream buffer, EntityData message)
                {
                    Encoder.WriteCompactString(buffer, message.EntityTypeField);
                    Encoder.WriteCompactNullableString(buffer, message.EntityNameField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
            }
        }
    }
}