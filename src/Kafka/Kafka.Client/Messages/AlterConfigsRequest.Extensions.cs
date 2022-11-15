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
        private static readonly Func<Stream, AlterConfigsRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
        };
        private static readonly Action<Stream, AlterConfigsRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
        };
        public static AlterConfigsRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, AlterConfigsRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static AlterConfigsRequest ReadV00(Stream buffer)
        {
            var resourcesField = Decoder.ReadArray<AlterConfigsResource>(buffer, b => AlterConfigsResourceSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Resources'");
            var validateOnlyField = Decoder.ReadBoolean(buffer);
            return new(
                resourcesField,
                validateOnlyField
            );
        }
        private static void WriteV00(Stream buffer, AlterConfigsRequest message)
        {
            Encoder.WriteArray<AlterConfigsResource>(buffer, message.ResourcesField, (b, i) => AlterConfigsResourceSerde.WriteV00(b, i));
            Encoder.WriteBoolean(buffer, message.ValidateOnlyField);
        }
        private static AlterConfigsRequest ReadV01(Stream buffer)
        {
            var resourcesField = Decoder.ReadArray<AlterConfigsResource>(buffer, b => AlterConfigsResourceSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Resources'");
            var validateOnlyField = Decoder.ReadBoolean(buffer);
            return new(
                resourcesField,
                validateOnlyField
            );
        }
        private static void WriteV01(Stream buffer, AlterConfigsRequest message)
        {
            Encoder.WriteArray<AlterConfigsResource>(buffer, message.ResourcesField, (b, i) => AlterConfigsResourceSerde.WriteV01(b, i));
            Encoder.WriteBoolean(buffer, message.ValidateOnlyField);
        }
        private static AlterConfigsRequest ReadV02(Stream buffer)
        {
            var resourcesField = Decoder.ReadCompactArray<AlterConfigsResource>(buffer, b => AlterConfigsResourceSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Resources'");
            var validateOnlyField = Decoder.ReadBoolean(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                resourcesField,
                validateOnlyField
            );
        }
        private static void WriteV02(Stream buffer, AlterConfigsRequest message)
        {
            Encoder.WriteCompactArray<AlterConfigsResource>(buffer, message.ResourcesField, (b, i) => AlterConfigsResourceSerde.WriteV02(b, i));
            Encoder.WriteBoolean(buffer, message.ValidateOnlyField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class AlterConfigsResourceSerde
        {
            public static AlterConfigsResource ReadV00(Stream buffer)
            {
                var resourceTypeField = Decoder.ReadInt8(buffer);
                var resourceNameField = Decoder.ReadString(buffer);
                var configsField = Decoder.ReadArray<AlterableConfig>(buffer, b => AlterableConfigSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                return new(
                    resourceTypeField,
                    resourceNameField,
                    configsField
                );
            }
            public static void WriteV00(Stream buffer, AlterConfigsResource message)
            {
                Encoder.WriteInt8(buffer, message.ResourceTypeField);
                Encoder.WriteString(buffer, message.ResourceNameField);
                Encoder.WriteArray<AlterableConfig>(buffer, message.ConfigsField, (b, i) => AlterableConfigSerde.WriteV00(b, i));
            }
            public static AlterConfigsResource ReadV01(Stream buffer)
            {
                var resourceTypeField = Decoder.ReadInt8(buffer);
                var resourceNameField = Decoder.ReadString(buffer);
                var configsField = Decoder.ReadArray<AlterableConfig>(buffer, b => AlterableConfigSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                return new(
                    resourceTypeField,
                    resourceNameField,
                    configsField
                );
            }
            public static void WriteV01(Stream buffer, AlterConfigsResource message)
            {
                Encoder.WriteInt8(buffer, message.ResourceTypeField);
                Encoder.WriteString(buffer, message.ResourceNameField);
                Encoder.WriteArray<AlterableConfig>(buffer, message.ConfigsField, (b, i) => AlterableConfigSerde.WriteV01(b, i));
            }
            public static AlterConfigsResource ReadV02(Stream buffer)
            {
                var resourceTypeField = Decoder.ReadInt8(buffer);
                var resourceNameField = Decoder.ReadCompactString(buffer);
                var configsField = Decoder.ReadCompactArray<AlterableConfig>(buffer, b => AlterableConfigSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    resourceTypeField,
                    resourceNameField,
                    configsField
                );
            }
            public static void WriteV02(Stream buffer, AlterConfigsResource message)
            {
                Encoder.WriteInt8(buffer, message.ResourceTypeField);
                Encoder.WriteCompactString(buffer, message.ResourceNameField);
                Encoder.WriteCompactArray<AlterableConfig>(buffer, message.ConfigsField, (b, i) => AlterableConfigSerde.WriteV02(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class AlterableConfigSerde
            {
                public static AlterableConfig ReadV00(Stream buffer)
                {
                    var nameField = Decoder.ReadString(buffer);
                    var valueField = Decoder.ReadNullableString(buffer);
                    return new(
                        nameField,
                        valueField
                    );
                }
                public static void WriteV00(Stream buffer, AlterableConfig message)
                {
                    Encoder.WriteString(buffer, message.NameField);
                    Encoder.WriteNullableString(buffer, message.ValueField);
                }
                public static AlterableConfig ReadV01(Stream buffer)
                {
                    var nameField = Decoder.ReadString(buffer);
                    var valueField = Decoder.ReadNullableString(buffer);
                    return new(
                        nameField,
                        valueField
                    );
                }
                public static void WriteV01(Stream buffer, AlterableConfig message)
                {
                    Encoder.WriteString(buffer, message.NameField);
                    Encoder.WriteNullableString(buffer, message.ValueField);
                }
                public static AlterableConfig ReadV02(Stream buffer)
                {
                    var nameField = Decoder.ReadCompactString(buffer);
                    var valueField = Decoder.ReadCompactNullableString(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
                    return new(
                        nameField,
                        valueField
                    );
                }
                public static void WriteV02(Stream buffer, AlterableConfig message)
                {
                    Encoder.WriteCompactString(buffer, message.NameField);
                    Encoder.WriteCompactNullableString(buffer, message.ValueField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
            }
        }
    }
}