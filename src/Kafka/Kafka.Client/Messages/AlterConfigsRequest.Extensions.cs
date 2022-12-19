using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using AlterableConfig = Kafka.Client.Messages.AlterConfigsRequest.AlterConfigsResource.AlterableConfig;
using AlterConfigsResource = Kafka.Client.Messages.AlterConfigsRequest.AlterConfigsResource;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class AlterConfigsRequestSerde
    {
        private static readonly DecodeDelegate<AlterConfigsRequest>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
        };
        private static readonly EncodeDelegate<AlterConfigsRequest>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
        };
        public static AlterConfigsRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, AlterConfigsRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static AlterConfigsRequest ReadV00(byte[] buffer, ref int index)
        {
            var resourcesField = Decoder.ReadArray<AlterConfigsResource>(buffer, ref index, AlterConfigsResourceSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Resources'");
            var validateOnlyField = Decoder.ReadBoolean(buffer, ref index);
            return new(
                resourcesField,
                validateOnlyField
            );
        }
        private static int WriteV00(byte[] buffer, int index, AlterConfigsRequest message)
        {
            index = Encoder.WriteArray<AlterConfigsResource>(buffer, index, message.ResourcesField, AlterConfigsResourceSerde.WriteV00);
            index = Encoder.WriteBoolean(buffer, index, message.ValidateOnlyField);
            return index;
        }
        private static AlterConfigsRequest ReadV01(byte[] buffer, ref int index)
        {
            var resourcesField = Decoder.ReadArray<AlterConfigsResource>(buffer, ref index, AlterConfigsResourceSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Resources'");
            var validateOnlyField = Decoder.ReadBoolean(buffer, ref index);
            return new(
                resourcesField,
                validateOnlyField
            );
        }
        private static int WriteV01(byte[] buffer, int index, AlterConfigsRequest message)
        {
            index = Encoder.WriteArray<AlterConfigsResource>(buffer, index, message.ResourcesField, AlterConfigsResourceSerde.WriteV01);
            index = Encoder.WriteBoolean(buffer, index, message.ValidateOnlyField);
            return index;
        }
        private static AlterConfigsRequest ReadV02(byte[] buffer, ref int index)
        {
            var resourcesField = Decoder.ReadCompactArray<AlterConfigsResource>(buffer, ref index, AlterConfigsResourceSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Resources'");
            var validateOnlyField = Decoder.ReadBoolean(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                resourcesField,
                validateOnlyField
            );
        }
        private static int WriteV02(byte[] buffer, int index, AlterConfigsRequest message)
        {
            index = Encoder.WriteCompactArray<AlterConfigsResource>(buffer, index, message.ResourcesField, AlterConfigsResourceSerde.WriteV02);
            index = Encoder.WriteBoolean(buffer, index, message.ValidateOnlyField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class AlterConfigsResourceSerde
        {
            public static AlterConfigsResource ReadV00(byte[] buffer, ref int index)
            {
                var resourceTypeField = Decoder.ReadInt8(buffer, ref index);
                var resourceNameField = Decoder.ReadString(buffer, ref index);
                var configsField = Decoder.ReadArray<AlterableConfig>(buffer, ref index, AlterableConfigSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                return new(
                    resourceTypeField,
                    resourceNameField,
                    configsField
                );
            }
            public static int WriteV00(byte[] buffer, int index, AlterConfigsResource message)
            {
                index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
                index = Encoder.WriteString(buffer, index, message.ResourceNameField);
                index = Encoder.WriteArray<AlterableConfig>(buffer, index, message.ConfigsField, AlterableConfigSerde.WriteV00);
                return index;
            }
            public static AlterConfigsResource ReadV01(byte[] buffer, ref int index)
            {
                var resourceTypeField = Decoder.ReadInt8(buffer, ref index);
                var resourceNameField = Decoder.ReadString(buffer, ref index);
                var configsField = Decoder.ReadArray<AlterableConfig>(buffer, ref index, AlterableConfigSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                return new(
                    resourceTypeField,
                    resourceNameField,
                    configsField
                );
            }
            public static int WriteV01(byte[] buffer, int index, AlterConfigsResource message)
            {
                index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
                index = Encoder.WriteString(buffer, index, message.ResourceNameField);
                index = Encoder.WriteArray<AlterableConfig>(buffer, index, message.ConfigsField, AlterableConfigSerde.WriteV01);
                return index;
            }
            public static AlterConfigsResource ReadV02(byte[] buffer, ref int index)
            {
                var resourceTypeField = Decoder.ReadInt8(buffer, ref index);
                var resourceNameField = Decoder.ReadCompactString(buffer, ref index);
                var configsField = Decoder.ReadCompactArray<AlterableConfig>(buffer, ref index, AlterableConfigSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    resourceTypeField,
                    resourceNameField,
                    configsField
                );
            }
            public static int WriteV02(byte[] buffer, int index, AlterConfigsResource message)
            {
                index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
                index = Encoder.WriteCompactString(buffer, index, message.ResourceNameField);
                index = Encoder.WriteCompactArray<AlterableConfig>(buffer, index, message.ConfigsField, AlterableConfigSerde.WriteV02);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class AlterableConfigSerde
            {
                public static AlterableConfig ReadV00(byte[] buffer, ref int index)
                {
                    var nameField = Decoder.ReadString(buffer, ref index);
                    var valueField = Decoder.ReadNullableString(buffer, ref index);
                    return new(
                        nameField,
                        valueField
                    );
                }
                public static int WriteV00(byte[] buffer, int index, AlterableConfig message)
                {
                    index = Encoder.WriteString(buffer, index, message.NameField);
                    index = Encoder.WriteNullableString(buffer, index, message.ValueField);
                    return index;
                }
                public static AlterableConfig ReadV01(byte[] buffer, ref int index)
                {
                    var nameField = Decoder.ReadString(buffer, ref index);
                    var valueField = Decoder.ReadNullableString(buffer, ref index);
                    return new(
                        nameField,
                        valueField
                    );
                }
                public static int WriteV01(byte[] buffer, int index, AlterableConfig message)
                {
                    index = Encoder.WriteString(buffer, index, message.NameField);
                    index = Encoder.WriteNullableString(buffer, index, message.ValueField);
                    return index;
                }
                public static AlterableConfig ReadV02(byte[] buffer, ref int index)
                {
                    var nameField = Decoder.ReadCompactString(buffer, ref index);
                    var valueField = Decoder.ReadCompactNullableString(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        nameField,
                        valueField
                    );
                }
                public static int WriteV02(byte[] buffer, int index, AlterableConfig message)
                {
                    index = Encoder.WriteCompactString(buffer, index, message.NameField);
                    index = Encoder.WriteCompactNullableString(buffer, index, message.ValueField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
            }
        }
    }
}