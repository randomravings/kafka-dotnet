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
        private static readonly DecodeDelegate<AlterClientQuotasRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
        };
        private static readonly EncodeDelegate<AlterClientQuotasRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
        };
        public static AlterClientQuotasRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, AlterClientQuotasRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static AlterClientQuotasRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var entriesField = Decoder.ReadArray<EntryData>(ref buffer, (ref ReadOnlyMemory<byte> b) => EntryDataSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Entries'");
            var validateOnlyField = Decoder.ReadBoolean(ref buffer);
            return new(
                entriesField,
                validateOnlyField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, AlterClientQuotasRequest message)
        {
            buffer = Encoder.WriteArray<EntryData>(buffer, message.EntriesField, (b, i) => EntryDataSerde.WriteV00(b, i));
            buffer = Encoder.WriteBoolean(buffer, message.ValidateOnlyField);
            return buffer;
        }
        private static AlterClientQuotasRequest ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var entriesField = Decoder.ReadCompactArray<EntryData>(ref buffer, (ref ReadOnlyMemory<byte> b) => EntryDataSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Entries'");
            var validateOnlyField = Decoder.ReadBoolean(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                entriesField,
                validateOnlyField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, AlterClientQuotasRequest message)
        {
            buffer = Encoder.WriteCompactArray<EntryData>(buffer, message.EntriesField, (b, i) => EntryDataSerde.WriteV01(b, i));
            buffer = Encoder.WriteBoolean(buffer, message.ValidateOnlyField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class EntryDataSerde
        {
            public static EntryData ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var entityField = Decoder.ReadArray<EntityData>(ref buffer, (ref ReadOnlyMemory<byte> b) => EntityDataSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Entity'");
                var opsField = Decoder.ReadArray<OpData>(ref buffer, (ref ReadOnlyMemory<byte> b) => OpDataSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Ops'");
                return new(
                    entityField,
                    opsField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, EntryData message)
            {
                buffer = Encoder.WriteArray<EntityData>(buffer, message.EntityField, (b, i) => EntityDataSerde.WriteV00(b, i));
                buffer = Encoder.WriteArray<OpData>(buffer, message.OpsField, (b, i) => OpDataSerde.WriteV00(b, i));
                return buffer;
            }
            public static EntryData ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var entityField = Decoder.ReadCompactArray<EntityData>(ref buffer, (ref ReadOnlyMemory<byte> b) => EntityDataSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Entity'");
                var opsField = Decoder.ReadCompactArray<OpData>(ref buffer, (ref ReadOnlyMemory<byte> b) => OpDataSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Ops'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    entityField,
                    opsField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, EntryData message)
            {
                buffer = Encoder.WriteCompactArray<EntityData>(buffer, message.EntityField, (b, i) => EntityDataSerde.WriteV01(b, i));
                buffer = Encoder.WriteCompactArray<OpData>(buffer, message.OpsField, (b, i) => OpDataSerde.WriteV01(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class OpDataSerde
            {
                public static OpData ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var keyField = Decoder.ReadString(ref buffer);
                    var valueField = Decoder.ReadFloat64(ref buffer);
                    var removeField = Decoder.ReadBoolean(ref buffer);
                    return new(
                        keyField,
                        valueField,
                        removeField
                    );
                }
                public static Memory<byte> WriteV00(Memory<byte> buffer, OpData message)
                {
                    buffer = Encoder.WriteString(buffer, message.KeyField);
                    buffer = Encoder.WriteFloat64(buffer, message.ValueField);
                    buffer = Encoder.WriteBoolean(buffer, message.RemoveField);
                    return buffer;
                }
                public static OpData ReadV01(ref ReadOnlyMemory<byte> buffer)
                {
                    var keyField = Decoder.ReadCompactString(ref buffer);
                    var valueField = Decoder.ReadFloat64(ref buffer);
                    var removeField = Decoder.ReadBoolean(ref buffer);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        keyField,
                        valueField,
                        removeField
                    );
                }
                public static Memory<byte> WriteV01(Memory<byte> buffer, OpData message)
                {
                    buffer = Encoder.WriteCompactString(buffer, message.KeyField);
                    buffer = Encoder.WriteFloat64(buffer, message.ValueField);
                    buffer = Encoder.WriteBoolean(buffer, message.RemoveField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
            }
            private static class EntityDataSerde
            {
                public static EntityData ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var entityTypeField = Decoder.ReadString(ref buffer);
                    var entityNameField = Decoder.ReadNullableString(ref buffer);
                    return new(
                        entityTypeField,
                        entityNameField
                    );
                }
                public static Memory<byte> WriteV00(Memory<byte> buffer, EntityData message)
                {
                    buffer = Encoder.WriteString(buffer, message.EntityTypeField);
                    buffer = Encoder.WriteNullableString(buffer, message.EntityNameField);
                    return buffer;
                }
                public static EntityData ReadV01(ref ReadOnlyMemory<byte> buffer)
                {
                    var entityTypeField = Decoder.ReadCompactString(ref buffer);
                    var entityNameField = Decoder.ReadCompactNullableString(ref buffer);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        entityTypeField,
                        entityNameField
                    );
                }
                public static Memory<byte> WriteV01(Memory<byte> buffer, EntityData message)
                {
                    buffer = Encoder.WriteCompactString(buffer, message.EntityTypeField);
                    buffer = Encoder.WriteCompactNullableString(buffer, message.EntityNameField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
            }
        }
    }
}