using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using EntryData = Kafka.Client.Messages.DescribeClientQuotasResponse.EntryData;
using ValueData = Kafka.Client.Messages.DescribeClientQuotasResponse.EntryData.ValueData;
using EntityData = Kafka.Client.Messages.DescribeClientQuotasResponse.EntryData.EntityData;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeClientQuotasResponseSerde
    {
        private static readonly DecodeDelegate<DescribeClientQuotasResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
        };
        private static readonly EncodeDelegate<DescribeClientQuotasResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
        };
        public static DescribeClientQuotasResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, DescribeClientQuotasResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static DescribeClientQuotasResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var errorMessageField = Decoder.ReadNullableString(ref buffer);
            var entriesField = Decoder.ReadArray<EntryData>(ref buffer, (ref ReadOnlyMemory<byte> b) => EntryDataSerde.ReadV00(ref b));
            return new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                entriesField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, DescribeClientQuotasResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteNullableString(buffer, message.ErrorMessageField);
            buffer = Encoder.WriteArray<EntryData>(buffer, message.EntriesField, (b, i) => EntryDataSerde.WriteV00(b, i));
            return buffer;
        }
        private static DescribeClientQuotasResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var errorCodeField = Decoder.ReadInt16(ref buffer);
            var errorMessageField = Decoder.ReadCompactNullableString(ref buffer);
            var entriesField = Decoder.ReadCompactArray<EntryData>(ref buffer, (ref ReadOnlyMemory<byte> b) => EntryDataSerde.ReadV01(ref b));
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                entriesField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, DescribeClientQuotasResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
            buffer = Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
            buffer = Encoder.WriteCompactArray<EntryData>(buffer, message.EntriesField, (b, i) => EntryDataSerde.WriteV01(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class EntryDataSerde
        {
            public static EntryData ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var entityField = Decoder.ReadArray<EntityData>(ref buffer, (ref ReadOnlyMemory<byte> b) => EntityDataSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Entity'");
                var valuesField = Decoder.ReadArray<ValueData>(ref buffer, (ref ReadOnlyMemory<byte> b) => ValueDataSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Values'");
                return new(
                    entityField,
                    valuesField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, EntryData message)
            {
                buffer = Encoder.WriteArray<EntityData>(buffer, message.EntityField, (b, i) => EntityDataSerde.WriteV00(b, i));
                buffer = Encoder.WriteArray<ValueData>(buffer, message.ValuesField, (b, i) => ValueDataSerde.WriteV00(b, i));
                return buffer;
            }
            public static EntryData ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var entityField = Decoder.ReadCompactArray<EntityData>(ref buffer, (ref ReadOnlyMemory<byte> b) => EntityDataSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Entity'");
                var valuesField = Decoder.ReadCompactArray<ValueData>(ref buffer, (ref ReadOnlyMemory<byte> b) => ValueDataSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Values'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    entityField,
                    valuesField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, EntryData message)
            {
                buffer = Encoder.WriteCompactArray<EntityData>(buffer, message.EntityField, (b, i) => EntityDataSerde.WriteV01(b, i));
                buffer = Encoder.WriteCompactArray<ValueData>(buffer, message.ValuesField, (b, i) => ValueDataSerde.WriteV01(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class ValueDataSerde
            {
                public static ValueData ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var keyField = Decoder.ReadString(ref buffer);
                    var valueField = Decoder.ReadFloat64(ref buffer);
                    return new(
                        keyField,
                        valueField
                    );
                }
                public static Memory<byte> WriteV00(Memory<byte> buffer, ValueData message)
                {
                    buffer = Encoder.WriteString(buffer, message.KeyField);
                    buffer = Encoder.WriteFloat64(buffer, message.ValueField);
                    return buffer;
                }
                public static ValueData ReadV01(ref ReadOnlyMemory<byte> buffer)
                {
                    var keyField = Decoder.ReadCompactString(ref buffer);
                    var valueField = Decoder.ReadFloat64(ref buffer);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        keyField,
                        valueField
                    );
                }
                public static Memory<byte> WriteV01(Memory<byte> buffer, ValueData message)
                {
                    buffer = Encoder.WriteCompactString(buffer, message.KeyField);
                    buffer = Encoder.WriteFloat64(buffer, message.ValueField);
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