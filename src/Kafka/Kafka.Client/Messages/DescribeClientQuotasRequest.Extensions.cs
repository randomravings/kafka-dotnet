using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using ComponentData = Kafka.Client.Messages.DescribeClientQuotasRequest.ComponentData;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeClientQuotasRequestSerde
    {
        private static readonly Func<Stream, DescribeClientQuotasRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
        };
        private static readonly Action<Stream, DescribeClientQuotasRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
        };
        public static DescribeClientQuotasRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, DescribeClientQuotasRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static DescribeClientQuotasRequest ReadV00(Stream buffer)
        {
            var componentsField = Decoder.ReadArray<ComponentData>(buffer, b => ComponentDataSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Components'");
            var strictField = Decoder.ReadBoolean(buffer);
            return new(
                componentsField,
                strictField
            );
        }
        private static void WriteV00(Stream buffer, DescribeClientQuotasRequest message)
        {
            Encoder.WriteArray<ComponentData>(buffer, message.ComponentsField, (b, i) => ComponentDataSerde.WriteV00(b, i));
            Encoder.WriteBoolean(buffer, message.StrictField);
        }
        private static DescribeClientQuotasRequest ReadV01(Stream buffer)
        {
            var componentsField = Decoder.ReadCompactArray<ComponentData>(buffer, b => ComponentDataSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Components'");
            var strictField = Decoder.ReadBoolean(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                componentsField,
                strictField
            );
        }
        private static void WriteV01(Stream buffer, DescribeClientQuotasRequest message)
        {
            Encoder.WriteCompactArray<ComponentData>(buffer, message.ComponentsField, (b, i) => ComponentDataSerde.WriteV01(b, i));
            Encoder.WriteBoolean(buffer, message.StrictField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class ComponentDataSerde
        {
            public static ComponentData ReadV00(Stream buffer)
            {
                var entityTypeField = Decoder.ReadString(buffer);
                var matchTypeField = Decoder.ReadInt8(buffer);
                var matchField = Decoder.ReadNullableString(buffer);
                return new(
                    entityTypeField,
                    matchTypeField,
                    matchField
                );
            }
            public static void WriteV00(Stream buffer, ComponentData message)
            {
                Encoder.WriteString(buffer, message.EntityTypeField);
                Encoder.WriteInt8(buffer, message.MatchTypeField);
                Encoder.WriteNullableString(buffer, message.MatchField);
            }
            public static ComponentData ReadV01(Stream buffer)
            {
                var entityTypeField = Decoder.ReadCompactString(buffer);
                var matchTypeField = Decoder.ReadInt8(buffer);
                var matchField = Decoder.ReadCompactNullableString(buffer);
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    entityTypeField,
                    matchTypeField,
                    matchField
                );
            }
            public static void WriteV01(Stream buffer, ComponentData message)
            {
                Encoder.WriteCompactString(buffer, message.EntityTypeField);
                Encoder.WriteInt8(buffer, message.MatchTypeField);
                Encoder.WriteCompactNullableString(buffer, message.MatchField);
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
    }
}