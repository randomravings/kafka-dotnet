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
        private static readonly Func<Stream, AlterClientQuotasResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
        };
        private static readonly Action<Stream, AlterClientQuotasResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
        };
        public static AlterClientQuotasResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, AlterClientQuotasResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static AlterClientQuotasResponse ReadV00(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var entriesField = Decoder.ReadArray<EntryData>(buffer, b => EntryDataSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Entries'");
            return new(
                throttleTimeMsField,
                entriesField
            );
        }
        private static void WriteV00(Stream buffer, AlterClientQuotasResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<EntryData>(buffer, message.EntriesField, (b, i) => EntryDataSerde.WriteV00(b, i));
        }
        private static AlterClientQuotasResponse ReadV01(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var entriesField = Decoder.ReadCompactArray<EntryData>(buffer, b => EntryDataSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Entries'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                entriesField
            );
        }
        private static void WriteV01(Stream buffer, AlterClientQuotasResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteCompactArray<EntryData>(buffer, message.EntriesField, (b, i) => EntryDataSerde.WriteV01(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class EntryDataSerde
        {
            public static EntryData ReadV00(Stream buffer)
            {
                var errorCodeField = Decoder.ReadInt16(buffer);
                var errorMessageField = Decoder.ReadNullableString(buffer);
                var entityField = Decoder.ReadArray<EntityData>(buffer, b => EntityDataSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Entity'");
                return new(
                    errorCodeField,
                    errorMessageField,
                    entityField
                );
            }
            public static void WriteV00(Stream buffer, EntryData message)
            {
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteNullableString(buffer, message.ErrorMessageField);
                Encoder.WriteArray<EntityData>(buffer, message.EntityField, (b, i) => EntityDataSerde.WriteV00(b, i));
            }
            public static EntryData ReadV01(Stream buffer)
            {
                var errorCodeField = Decoder.ReadInt16(buffer);
                var errorMessageField = Decoder.ReadCompactNullableString(buffer);
                var entityField = Decoder.ReadCompactArray<EntityData>(buffer, b => EntityDataSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Entity'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    errorCodeField,
                    errorMessageField,
                    entityField
                );
            }
            public static void WriteV01(Stream buffer, EntryData message)
            {
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                Encoder.WriteCompactArray<EntityData>(buffer, message.EntityField, (b, i) => EntityDataSerde.WriteV01(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
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