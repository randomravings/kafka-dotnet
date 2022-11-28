using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using ComponentData = Kafka.Client.Messages.DescribeClientQuotasRequest.ComponentData;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeClientQuotasRequestSerde
    {
        private static readonly DecodeDelegate<DescribeClientQuotasRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
        };
        private static readonly EncodeDelegate<DescribeClientQuotasRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
        };
        public static DescribeClientQuotasRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, DescribeClientQuotasRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static DescribeClientQuotasRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var componentsField = Decoder.ReadArray<ComponentData>(ref buffer, (ref ReadOnlyMemory<byte> b) => ComponentDataSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Components'");
            var strictField = Decoder.ReadBoolean(ref buffer);
            return new(
                componentsField,
                strictField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, DescribeClientQuotasRequest message)
        {
            buffer = Encoder.WriteArray<ComponentData>(buffer, message.ComponentsField, (b, i) => ComponentDataSerde.WriteV00(b, i));
            buffer = Encoder.WriteBoolean(buffer, message.StrictField);
            return buffer;
        }
        private static DescribeClientQuotasRequest ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var componentsField = Decoder.ReadCompactArray<ComponentData>(ref buffer, (ref ReadOnlyMemory<byte> b) => ComponentDataSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Components'");
            var strictField = Decoder.ReadBoolean(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                componentsField,
                strictField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, DescribeClientQuotasRequest message)
        {
            buffer = Encoder.WriteCompactArray<ComponentData>(buffer, message.ComponentsField, (b, i) => ComponentDataSerde.WriteV01(b, i));
            buffer = Encoder.WriteBoolean(buffer, message.StrictField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class ComponentDataSerde
        {
            public static ComponentData ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var entityTypeField = Decoder.ReadString(ref buffer);
                var matchTypeField = Decoder.ReadInt8(ref buffer);
                var matchField = Decoder.ReadNullableString(ref buffer);
                return new(
                    entityTypeField,
                    matchTypeField,
                    matchField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, ComponentData message)
            {
                buffer = Encoder.WriteString(buffer, message.EntityTypeField);
                buffer = Encoder.WriteInt8(buffer, message.MatchTypeField);
                buffer = Encoder.WriteNullableString(buffer, message.MatchField);
                return buffer;
            }
            public static ComponentData ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var entityTypeField = Decoder.ReadCompactString(ref buffer);
                var matchTypeField = Decoder.ReadInt8(ref buffer);
                var matchField = Decoder.ReadCompactNullableString(ref buffer);
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    entityTypeField,
                    matchTypeField,
                    matchField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, ComponentData message)
            {
                buffer = Encoder.WriteCompactString(buffer, message.EntityTypeField);
                buffer = Encoder.WriteInt8(buffer, message.MatchTypeField);
                buffer = Encoder.WriteCompactNullableString(buffer, message.MatchField);
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
    }
}