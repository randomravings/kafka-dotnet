using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using EntryData = Kafka.Client.Messages.AlterClientQuotasResponse.EntryData;
using EntityData = Kafka.Client.Messages.AlterClientQuotasResponse.EntryData.EntityData;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AlterClientQuotasResponseSerde
    {
        private static readonly DecodeDelegate<AlterClientQuotasResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
        };
        private static readonly EncodeDelegate<AlterClientQuotasResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
        };
        public static AlterClientQuotasResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, AlterClientQuotasResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static AlterClientQuotasResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var entriesField = Decoder.ReadArray<EntryData>(ref buffer, (ref ReadOnlyMemory<byte> b) => EntryDataSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Entries'");
            return new(
                throttleTimeMsField,
                entriesField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, AlterClientQuotasResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<EntryData>(buffer, message.EntriesField, (b, i) => EntryDataSerde.WriteV00(b, i));
            return buffer;
        }
        private static AlterClientQuotasResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var entriesField = Decoder.ReadCompactArray<EntryData>(ref buffer, (ref ReadOnlyMemory<byte> b) => EntryDataSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Entries'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                entriesField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, AlterClientQuotasResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteCompactArray<EntryData>(buffer, message.EntriesField, (b, i) => EntryDataSerde.WriteV01(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class EntryDataSerde
        {
            public static EntryData ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var errorMessageField = Decoder.ReadNullableString(ref buffer);
                var entityField = Decoder.ReadArray<EntityData>(ref buffer, (ref ReadOnlyMemory<byte> b) => EntityDataSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Entity'");
                return new(
                    errorCodeField,
                    errorMessageField,
                    entityField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, EntryData message)
            {
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteNullableString(buffer, message.ErrorMessageField);
                buffer = Encoder.WriteArray<EntityData>(buffer, message.EntityField, (b, i) => EntityDataSerde.WriteV00(b, i));
                return buffer;
            }
            public static EntryData ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var errorMessageField = Decoder.ReadCompactNullableString(ref buffer);
                var entityField = Decoder.ReadCompactArray<EntityData>(ref buffer, (ref ReadOnlyMemory<byte> b) => EntityDataSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Entity'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    errorCodeField,
                    errorMessageField,
                    entityField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, EntryData message)
            {
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                buffer = Encoder.WriteCompactArray<EntityData>(buffer, message.EntityField, (b, i) => EntityDataSerde.WriteV01(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
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