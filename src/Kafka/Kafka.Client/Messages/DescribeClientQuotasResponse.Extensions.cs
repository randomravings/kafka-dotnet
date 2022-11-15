using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using ValueData = Kafka.Client.Messages.DescribeClientQuotasResponse.EntryData.ValueData;
using EntryData = Kafka.Client.Messages.DescribeClientQuotasResponse.EntryData;
using EntityData = Kafka.Client.Messages.DescribeClientQuotasResponse.EntryData.EntityData;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeClientQuotasResponseSerde
    {
        private static readonly Func<Stream, DescribeClientQuotasResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
        };
        private static readonly Action<Stream, DescribeClientQuotasResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
        };
        public static DescribeClientQuotasResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, DescribeClientQuotasResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static DescribeClientQuotasResponse ReadV00(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var errorMessageField = Decoder.ReadNullableString(buffer);
            var entriesField = Decoder.ReadArray<EntryData>(buffer, b => EntryDataSerde.ReadV00(b));
            return new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                entriesField
            );
        }
        private static void WriteV00(Stream buffer, DescribeClientQuotasResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteNullableString(buffer, message.ErrorMessageField);
            Encoder.WriteArray<EntryData>(buffer, message.EntriesField, (b, i) => EntryDataSerde.WriteV00(b, i));
        }
        private static DescribeClientQuotasResponse ReadV01(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var errorCodeField = Decoder.ReadInt16(buffer);
            var errorMessageField = Decoder.ReadCompactNullableString(buffer);
            var entriesField = Decoder.ReadCompactArray<EntryData>(buffer, b => EntryDataSerde.ReadV01(b));
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                entriesField
            );
        }
        private static void WriteV01(Stream buffer, DescribeClientQuotasResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteInt16(buffer, message.ErrorCodeField);
            Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
            Encoder.WriteCompactArray<EntryData>(buffer, message.EntriesField, (b, i) => EntryDataSerde.WriteV01(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class EntryDataSerde
        {
            public static EntryData ReadV00(Stream buffer)
            {
                var entityField = Decoder.ReadArray<EntityData>(buffer, b => EntityDataSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Entity'");
                var valuesField = Decoder.ReadArray<ValueData>(buffer, b => ValueDataSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Values'");
                return new(
                    entityField,
                    valuesField
                );
            }
            public static void WriteV00(Stream buffer, EntryData message)
            {
                Encoder.WriteArray<EntityData>(buffer, message.EntityField, (b, i) => EntityDataSerde.WriteV00(b, i));
                Encoder.WriteArray<ValueData>(buffer, message.ValuesField, (b, i) => ValueDataSerde.WriteV00(b, i));
            }
            public static EntryData ReadV01(Stream buffer)
            {
                var entityField = Decoder.ReadCompactArray<EntityData>(buffer, b => EntityDataSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Entity'");
                var valuesField = Decoder.ReadCompactArray<ValueData>(buffer, b => ValueDataSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Values'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    entityField,
                    valuesField
                );
            }
            public static void WriteV01(Stream buffer, EntryData message)
            {
                Encoder.WriteCompactArray<EntityData>(buffer, message.EntityField, (b, i) => EntityDataSerde.WriteV01(b, i));
                Encoder.WriteCompactArray<ValueData>(buffer, message.ValuesField, (b, i) => ValueDataSerde.WriteV01(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class ValueDataSerde
            {
                public static ValueData ReadV00(Stream buffer)
                {
                    var keyField = Decoder.ReadString(buffer);
                    var valueField = Decoder.ReadFloat64(buffer);
                    return new(
                        keyField,
                        valueField
                    );
                }
                public static void WriteV00(Stream buffer, ValueData message)
                {
                    Encoder.WriteString(buffer, message.KeyField);
                    Encoder.WriteFloat64(buffer, message.ValueField);
                }
                public static ValueData ReadV01(Stream buffer)
                {
                    var keyField = Decoder.ReadCompactString(buffer);
                    var valueField = Decoder.ReadFloat64(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        keyField,
                        valueField
                    );
                }
                public static void WriteV01(Stream buffer, ValueData message)
                {
                    Encoder.WriteCompactString(buffer, message.KeyField);
                    Encoder.WriteFloat64(buffer, message.ValueField);
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