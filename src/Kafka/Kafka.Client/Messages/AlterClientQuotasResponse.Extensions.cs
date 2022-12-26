using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using EntryData = Kafka.Client.Messages.AlterClientQuotasResponse.EntryData;
using EntityData = Kafka.Client.Messages.AlterClientQuotasResponse.EntryData.EntityData;

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
        public static AlterClientQuotasResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, AlterClientQuotasResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static AlterClientQuotasResponse ReadV00(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var entriesField = Decoder.ReadArray<EntryData>(buffer, ref index, EntryDataSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Entries'");
            return new(
                throttleTimeMsField,
                entriesField
            );
        }
        private static int WriteV00(byte[] buffer, int index, AlterClientQuotasResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<EntryData>(buffer, index, message.EntriesField, EntryDataSerde.WriteV00);
            return index;
        }
        private static AlterClientQuotasResponse ReadV01(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var entriesField = Decoder.ReadCompactArray<EntryData>(buffer, ref index, EntryDataSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Entries'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                entriesField
            );
        }
        private static int WriteV01(byte[] buffer, int index, AlterClientQuotasResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteCompactArray<EntryData>(buffer, index, message.EntriesField, EntryDataSerde.WriteV01);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class EntryDataSerde
        {
            public static EntryData ReadV00(byte[] buffer, ref int index)
            {
                var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                var ErrorMessageField = Decoder.ReadNullableString(buffer, ref index);
                var EntityField = Decoder.ReadArray<EntityData>(buffer, ref index, EntityDataSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Entity'");
                return new(
                    ErrorCodeField,
                    ErrorMessageField,
                    EntityField
                );
            }
            public static int WriteV00(byte[] buffer, int index, EntryData message)
            {
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
                index = Encoder.WriteArray<EntityData>(buffer, index, message.EntityField, EntityDataSerde.WriteV00);
                return index;
            }
            public static EntryData ReadV01(byte[] buffer, ref int index)
            {
                var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                var ErrorMessageField = Decoder.ReadCompactNullableString(buffer, ref index);
                var EntityField = Decoder.ReadCompactArray<EntityData>(buffer, ref index, EntityDataSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Entity'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    ErrorCodeField,
                    ErrorMessageField,
                    EntityField
                );
            }
            public static int WriteV01(byte[] buffer, int index, EntryData message)
            {
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
                index = Encoder.WriteCompactArray<EntityData>(buffer, index, message.EntityField, EntityDataSerde.WriteV01);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
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