using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using AlterableConfig = Kafka.Client.Messages.AlterConfigsRequest.AlterConfigsResource.AlterableConfig;
using AlterConfigsResource = Kafka.Client.Messages.AlterConfigsRequest.AlterConfigsResource;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AlterConfigsRequestSerde
    {
        private static readonly DecodeDelegate<AlterConfigsRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
        };
        private static readonly EncodeDelegate<AlterConfigsRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
        };
        public static AlterConfigsRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, AlterConfigsRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static AlterConfigsRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var resourcesField = Decoder.ReadArray<AlterConfigsResource>(ref buffer, (ref ReadOnlyMemory<byte> b) => AlterConfigsResourceSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Resources'");
            var validateOnlyField = Decoder.ReadBoolean(ref buffer);
            return new(
                resourcesField,
                validateOnlyField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, AlterConfigsRequest message)
        {
            buffer = Encoder.WriteArray<AlterConfigsResource>(buffer, message.ResourcesField, (b, i) => AlterConfigsResourceSerde.WriteV00(b, i));
            buffer = Encoder.WriteBoolean(buffer, message.ValidateOnlyField);
            return buffer;
        }
        private static AlterConfigsRequest ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var resourcesField = Decoder.ReadArray<AlterConfigsResource>(ref buffer, (ref ReadOnlyMemory<byte> b) => AlterConfigsResourceSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Resources'");
            var validateOnlyField = Decoder.ReadBoolean(ref buffer);
            return new(
                resourcesField,
                validateOnlyField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, AlterConfigsRequest message)
        {
            buffer = Encoder.WriteArray<AlterConfigsResource>(buffer, message.ResourcesField, (b, i) => AlterConfigsResourceSerde.WriteV01(b, i));
            buffer = Encoder.WriteBoolean(buffer, message.ValidateOnlyField);
            return buffer;
        }
        private static AlterConfigsRequest ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var resourcesField = Decoder.ReadCompactArray<AlterConfigsResource>(ref buffer, (ref ReadOnlyMemory<byte> b) => AlterConfigsResourceSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Resources'");
            var validateOnlyField = Decoder.ReadBoolean(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                resourcesField,
                validateOnlyField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, AlterConfigsRequest message)
        {
            buffer = Encoder.WriteCompactArray<AlterConfigsResource>(buffer, message.ResourcesField, (b, i) => AlterConfigsResourceSerde.WriteV02(b, i));
            buffer = Encoder.WriteBoolean(buffer, message.ValidateOnlyField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class AlterConfigsResourceSerde
        {
            public static AlterConfigsResource ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var resourceTypeField = Decoder.ReadInt8(ref buffer);
                var resourceNameField = Decoder.ReadString(ref buffer);
                var configsField = Decoder.ReadArray<AlterableConfig>(ref buffer, (ref ReadOnlyMemory<byte> b) => AlterableConfigSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                return new(
                    resourceTypeField,
                    resourceNameField,
                    configsField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, AlterConfigsResource message)
            {
                buffer = Encoder.WriteInt8(buffer, message.ResourceTypeField);
                buffer = Encoder.WriteString(buffer, message.ResourceNameField);
                buffer = Encoder.WriteArray<AlterableConfig>(buffer, message.ConfigsField, (b, i) => AlterableConfigSerde.WriteV00(b, i));
                return buffer;
            }
            public static AlterConfigsResource ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var resourceTypeField = Decoder.ReadInt8(ref buffer);
                var resourceNameField = Decoder.ReadString(ref buffer);
                var configsField = Decoder.ReadArray<AlterableConfig>(ref buffer, (ref ReadOnlyMemory<byte> b) => AlterableConfigSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                return new(
                    resourceTypeField,
                    resourceNameField,
                    configsField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, AlterConfigsResource message)
            {
                buffer = Encoder.WriteInt8(buffer, message.ResourceTypeField);
                buffer = Encoder.WriteString(buffer, message.ResourceNameField);
                buffer = Encoder.WriteArray<AlterableConfig>(buffer, message.ConfigsField, (b, i) => AlterableConfigSerde.WriteV01(b, i));
                return buffer;
            }
            public static AlterConfigsResource ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var resourceTypeField = Decoder.ReadInt8(ref buffer);
                var resourceNameField = Decoder.ReadCompactString(ref buffer);
                var configsField = Decoder.ReadCompactArray<AlterableConfig>(ref buffer, (ref ReadOnlyMemory<byte> b) => AlterableConfigSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    resourceTypeField,
                    resourceNameField,
                    configsField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, AlterConfigsResource message)
            {
                buffer = Encoder.WriteInt8(buffer, message.ResourceTypeField);
                buffer = Encoder.WriteCompactString(buffer, message.ResourceNameField);
                buffer = Encoder.WriteCompactArray<AlterableConfig>(buffer, message.ConfigsField, (b, i) => AlterableConfigSerde.WriteV02(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class AlterableConfigSerde
            {
                public static AlterableConfig ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var nameField = Decoder.ReadString(ref buffer);
                    var valueField = Decoder.ReadNullableString(ref buffer);
                    return new(
                        nameField,
                        valueField
                    );
                }
                public static Memory<byte> WriteV00(Memory<byte> buffer, AlterableConfig message)
                {
                    buffer = Encoder.WriteString(buffer, message.NameField);
                    buffer = Encoder.WriteNullableString(buffer, message.ValueField);
                    return buffer;
                }
                public static AlterableConfig ReadV01(ref ReadOnlyMemory<byte> buffer)
                {
                    var nameField = Decoder.ReadString(ref buffer);
                    var valueField = Decoder.ReadNullableString(ref buffer);
                    return new(
                        nameField,
                        valueField
                    );
                }
                public static Memory<byte> WriteV01(Memory<byte> buffer, AlterableConfig message)
                {
                    buffer = Encoder.WriteString(buffer, message.NameField);
                    buffer = Encoder.WriteNullableString(buffer, message.ValueField);
                    return buffer;
                }
                public static AlterableConfig ReadV02(ref ReadOnlyMemory<byte> buffer)
                {
                    var nameField = Decoder.ReadCompactString(ref buffer);
                    var valueField = Decoder.ReadCompactNullableString(ref buffer);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        nameField,
                        valueField
                    );
                }
                public static Memory<byte> WriteV02(Memory<byte> buffer, AlterableConfig message)
                {
                    buffer = Encoder.WriteCompactString(buffer, message.NameField);
                    buffer = Encoder.WriteCompactNullableString(buffer, message.ValueField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
            }
        }
    }
}