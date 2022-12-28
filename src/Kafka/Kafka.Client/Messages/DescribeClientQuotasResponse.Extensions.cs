using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using ValueData = Kafka.Client.Messages.DescribeClientQuotasResponse.EntryData.ValueData;
using EntityData = Kafka.Client.Messages.DescribeClientQuotasResponse.EntryData.EntityData;
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
        public static DescribeClientQuotasResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, DescribeClientQuotasResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static DescribeClientQuotasResponse ReadV00(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var errorMessageField = Decoder.ReadNullableString(buffer, ref index);
            var entriesField = Decoder.ReadArray<EntryData>(buffer, ref index, EntryDataSerde.ReadV00);
            return new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                entriesField
            );
        }
        private static int WriteV00(byte[] buffer, int index, DescribeClientQuotasResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
            index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
            index = Encoder.WriteArray<EntryData>(buffer, index, message.EntriesField, EntryDataSerde.WriteV00);
            return index;
        }
        private static DescribeClientQuotasResponse ReadV01(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var errorCodeField = Decoder.ReadInt16(buffer, ref index);
            var errorMessageField = Decoder.ReadCompactNullableString(buffer, ref index);
            var entriesField = Decoder.ReadCompactArray<EntryData>(buffer, ref index, EntryDataSerde.ReadV01);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                errorCodeField,
                errorMessageField,
                entriesField
            );
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
        private static class EntryDataSerde
        {
            public static EntryData ReadV00(byte[] buffer, ref int index)
            {
                var EntityField = Decoder.ReadArray<EntityData>(buffer, ref index, EntityDataSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Entity'");
                var ValuesField = Decoder.ReadArray<ValueData>(buffer, ref index, ValueDataSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Values'");
                return new(
                    EntityField,
                    ValuesField
                );
            }
            public static int WriteV00(byte[] buffer, int index, EntryData message)
            {
                index = Encoder.WriteArray<EntityData>(buffer, index, message.EntityField, EntityDataSerde.WriteV00);
                index = Encoder.WriteArray<ValueData>(buffer, index, message.ValuesField, ValueDataSerde.WriteV00);
                return index;
            }
            public static EntryData ReadV01(byte[] buffer, ref int index)
            {
                var EntityField = Decoder.ReadCompactArray<EntityData>(buffer, ref index, EntityDataSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Entity'");
                var ValuesField = Decoder.ReadCompactArray<ValueData>(buffer, ref index, ValueDataSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Values'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    EntityField,
                    ValuesField
                );
            }
            public static int WriteV01(byte[] buffer, int index, EntryData message)
            {
                index = Encoder.WriteCompactArray<EntityData>(buffer, index, message.EntityField, EntityDataSerde.WriteV01);
                index = Encoder.WriteCompactArray<ValueData>(buffer, index, message.ValuesField, ValueDataSerde.WriteV01);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class ValueDataSerde
            {
                public static ValueData ReadV00(byte[] buffer, ref int index)
                {
                    var KeyField = Decoder.ReadString(buffer, ref index);
                    var ValueField = Decoder.ReadFloat64(buffer, ref index);
                    return new(
                        KeyField,
                        ValueField
                    );
                }
                public static int WriteV00(byte[] buffer, int index, ValueData message)
                {
                    index = Encoder.WriteString(buffer, index, message.KeyField);
                    index = Encoder.WriteFloat64(buffer, index, message.ValueField);
                    return index;
                }
                public static ValueData ReadV01(byte[] buffer, ref int index)
                {
                    var KeyField = Decoder.ReadCompactString(buffer, ref index);
                    var ValueField = Decoder.ReadFloat64(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        KeyField,
                        ValueField
                    );
                }
                public static int WriteV01(byte[] buffer, int index, ValueData message)
                {
                    index = Encoder.WriteCompactString(buffer, index, message.KeyField);
                    index = Encoder.WriteFloat64(buffer, index, message.ValueField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
            }
            private static class EntityDataSerde
            {
                public static EntityData ReadV00(byte[] buffer, ref int index)
                {
                    var EntityTypeField = Decoder.ReadString(buffer, ref index);
                    var EntityNameField = Decoder.ReadNullableString(buffer, ref index);
                    return new(
                        EntityTypeField,
                        EntityNameField
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
                    var EntityTypeField = Decoder.ReadCompactString(buffer, ref index);
                    var EntityNameField = Decoder.ReadCompactNullableString(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        EntityTypeField,
                        EntityNameField
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
        }
    }
}