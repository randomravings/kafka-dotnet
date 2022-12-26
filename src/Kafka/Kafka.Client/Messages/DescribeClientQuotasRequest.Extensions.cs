using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using ComponentData = Kafka.Client.Messages.DescribeClientQuotasRequest.ComponentData;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeClientQuotasRequestSerde
    {
        private static readonly DecodeDelegate<DescribeClientQuotasRequest>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
        };
        private static readonly EncodeDelegate<DescribeClientQuotasRequest>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
        };
        public static DescribeClientQuotasRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, DescribeClientQuotasRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static DescribeClientQuotasRequest ReadV00(byte[] buffer, ref int index)
        {
            var componentsField = Decoder.ReadArray<ComponentData>(buffer, ref index, ComponentDataSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Components'");
            var strictField = Decoder.ReadBoolean(buffer, ref index);
            return new(
                componentsField,
                strictField
            );
        }
        private static int WriteV00(byte[] buffer, int index, DescribeClientQuotasRequest message)
        {
            index = Encoder.WriteArray<ComponentData>(buffer, index, message.ComponentsField, ComponentDataSerde.WriteV00);
            index = Encoder.WriteBoolean(buffer, index, message.StrictField);
            return index;
        }
        private static DescribeClientQuotasRequest ReadV01(byte[] buffer, ref int index)
        {
            var componentsField = Decoder.ReadCompactArray<ComponentData>(buffer, ref index, ComponentDataSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Components'");
            var strictField = Decoder.ReadBoolean(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                componentsField,
                strictField
            );
        }
        private static int WriteV01(byte[] buffer, int index, DescribeClientQuotasRequest message)
        {
            index = Encoder.WriteCompactArray<ComponentData>(buffer, index, message.ComponentsField, ComponentDataSerde.WriteV01);
            index = Encoder.WriteBoolean(buffer, index, message.StrictField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class ComponentDataSerde
        {
            public static ComponentData ReadV00(byte[] buffer, ref int index)
            {
                var EntityTypeField = Decoder.ReadString(buffer, ref index);
                var MatchTypeField = Decoder.ReadInt8(buffer, ref index);
                var MatchField = Decoder.ReadNullableString(buffer, ref index);
                return new(
                    EntityTypeField,
                    MatchTypeField,
                    MatchField
                );
            }
            public static int WriteV00(byte[] buffer, int index, ComponentData message)
            {
                index = Encoder.WriteString(buffer, index, message.EntityTypeField);
                index = Encoder.WriteInt8(buffer, index, message.MatchTypeField);
                index = Encoder.WriteNullableString(buffer, index, message.MatchField);
                return index;
            }
            public static ComponentData ReadV01(byte[] buffer, ref int index)
            {
                var EntityTypeField = Decoder.ReadCompactString(buffer, ref index);
                var MatchTypeField = Decoder.ReadInt8(buffer, ref index);
                var MatchField = Decoder.ReadCompactNullableString(buffer, ref index);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    EntityTypeField,
                    MatchTypeField,
                    MatchField
                );
            }
            public static int WriteV01(byte[] buffer, int index, ComponentData message)
            {
                index = Encoder.WriteCompactString(buffer, index, message.EntityTypeField);
                index = Encoder.WriteInt8(buffer, index, message.MatchTypeField);
                index = Encoder.WriteCompactNullableString(buffer, index, message.MatchField);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
        }
    }
}