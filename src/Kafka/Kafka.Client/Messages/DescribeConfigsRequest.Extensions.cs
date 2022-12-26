using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using DescribeConfigsResource = Kafka.Client.Messages.DescribeConfigsRequest.DescribeConfigsResource;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeConfigsRequestSerde
    {
        private static readonly DecodeDelegate<DescribeConfigsRequest>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
            ReadV04,
        };
        private static readonly EncodeDelegate<DescribeConfigsRequest>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
            WriteV04,
        };
        public static DescribeConfigsRequest Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, DescribeConfigsRequest message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static DescribeConfigsRequest ReadV00(byte[] buffer, ref int index)
        {
            var resourcesField = Decoder.ReadArray<DescribeConfigsResource>(buffer, ref index, DescribeConfigsResourceSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Resources'");
            var includeSynonymsField = default(bool);
            var includeDocumentationField = default(bool);
            return new(
                resourcesField,
                includeSynonymsField,
                includeDocumentationField
            );
        }
        private static int WriteV00(byte[] buffer, int index, DescribeConfigsRequest message)
        {
            index = Encoder.WriteArray<DescribeConfigsResource>(buffer, index, message.ResourcesField, DescribeConfigsResourceSerde.WriteV00);
            return index;
        }
        private static DescribeConfigsRequest ReadV01(byte[] buffer, ref int index)
        {
            var resourcesField = Decoder.ReadArray<DescribeConfigsResource>(buffer, ref index, DescribeConfigsResourceSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Resources'");
            var includeSynonymsField = Decoder.ReadBoolean(buffer, ref index);
            var includeDocumentationField = default(bool);
            return new(
                resourcesField,
                includeSynonymsField,
                includeDocumentationField
            );
        }
        private static int WriteV01(byte[] buffer, int index, DescribeConfigsRequest message)
        {
            index = Encoder.WriteArray<DescribeConfigsResource>(buffer, index, message.ResourcesField, DescribeConfigsResourceSerde.WriteV01);
            index = Encoder.WriteBoolean(buffer, index, message.IncludeSynonymsField);
            return index;
        }
        private static DescribeConfigsRequest ReadV02(byte[] buffer, ref int index)
        {
            var resourcesField = Decoder.ReadArray<DescribeConfigsResource>(buffer, ref index, DescribeConfigsResourceSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Resources'");
            var includeSynonymsField = Decoder.ReadBoolean(buffer, ref index);
            var includeDocumentationField = default(bool);
            return new(
                resourcesField,
                includeSynonymsField,
                includeDocumentationField
            );
        }
        private static int WriteV02(byte[] buffer, int index, DescribeConfigsRequest message)
        {
            index = Encoder.WriteArray<DescribeConfigsResource>(buffer, index, message.ResourcesField, DescribeConfigsResourceSerde.WriteV02);
            index = Encoder.WriteBoolean(buffer, index, message.IncludeSynonymsField);
            return index;
        }
        private static DescribeConfigsRequest ReadV03(byte[] buffer, ref int index)
        {
            var resourcesField = Decoder.ReadArray<DescribeConfigsResource>(buffer, ref index, DescribeConfigsResourceSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Resources'");
            var includeSynonymsField = Decoder.ReadBoolean(buffer, ref index);
            var includeDocumentationField = Decoder.ReadBoolean(buffer, ref index);
            return new(
                resourcesField,
                includeSynonymsField,
                includeDocumentationField
            );
        }
        private static int WriteV03(byte[] buffer, int index, DescribeConfigsRequest message)
        {
            index = Encoder.WriteArray<DescribeConfigsResource>(buffer, index, message.ResourcesField, DescribeConfigsResourceSerde.WriteV03);
            index = Encoder.WriteBoolean(buffer, index, message.IncludeSynonymsField);
            index = Encoder.WriteBoolean(buffer, index, message.IncludeDocumentationField);
            return index;
        }
        private static DescribeConfigsRequest ReadV04(byte[] buffer, ref int index)
        {
            var resourcesField = Decoder.ReadCompactArray<DescribeConfigsResource>(buffer, ref index, DescribeConfigsResourceSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'Resources'");
            var includeSynonymsField = Decoder.ReadBoolean(buffer, ref index);
            var includeDocumentationField = Decoder.ReadBoolean(buffer, ref index);
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                resourcesField,
                includeSynonymsField,
                includeDocumentationField
            );
        }
        private static int WriteV04(byte[] buffer, int index, DescribeConfigsRequest message)
        {
            index = Encoder.WriteCompactArray<DescribeConfigsResource>(buffer, index, message.ResourcesField, DescribeConfigsResourceSerde.WriteV04);
            index = Encoder.WriteBoolean(buffer, index, message.IncludeSynonymsField);
            index = Encoder.WriteBoolean(buffer, index, message.IncludeDocumentationField);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class DescribeConfigsResourceSerde
        {
            public static DescribeConfigsResource ReadV00(byte[] buffer, ref int index)
            {
                var ResourceTypeField = Decoder.ReadInt8(buffer, ref index);
                var ResourceNameField = Decoder.ReadString(buffer, ref index);
                var ConfigurationKeysField = Decoder.ReadArray<string>(buffer, ref index, Decoder.ReadCompactString);
                return new(
                    ResourceTypeField,
                    ResourceNameField,
                    ConfigurationKeysField
                );
            }
            public static int WriteV00(byte[] buffer, int index, DescribeConfigsResource message)
            {
                index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
                index = Encoder.WriteString(buffer, index, message.ResourceNameField);
                index = Encoder.WriteArray<string>(buffer, index, message.ConfigurationKeysField, Encoder.WriteCompactString);
                return index;
            }
            public static DescribeConfigsResource ReadV01(byte[] buffer, ref int index)
            {
                var ResourceTypeField = Decoder.ReadInt8(buffer, ref index);
                var ResourceNameField = Decoder.ReadString(buffer, ref index);
                var ConfigurationKeysField = Decoder.ReadArray<string>(buffer, ref index, Decoder.ReadCompactString);
                return new(
                    ResourceTypeField,
                    ResourceNameField,
                    ConfigurationKeysField
                );
            }
            public static int WriteV01(byte[] buffer, int index, DescribeConfigsResource message)
            {
                index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
                index = Encoder.WriteString(buffer, index, message.ResourceNameField);
                index = Encoder.WriteArray<string>(buffer, index, message.ConfigurationKeysField, Encoder.WriteCompactString);
                return index;
            }
            public static DescribeConfigsResource ReadV02(byte[] buffer, ref int index)
            {
                var ResourceTypeField = Decoder.ReadInt8(buffer, ref index);
                var ResourceNameField = Decoder.ReadString(buffer, ref index);
                var ConfigurationKeysField = Decoder.ReadArray<string>(buffer, ref index, Decoder.ReadCompactString);
                return new(
                    ResourceTypeField,
                    ResourceNameField,
                    ConfigurationKeysField
                );
            }
            public static int WriteV02(byte[] buffer, int index, DescribeConfigsResource message)
            {
                index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
                index = Encoder.WriteString(buffer, index, message.ResourceNameField);
                index = Encoder.WriteArray<string>(buffer, index, message.ConfigurationKeysField, Encoder.WriteCompactString);
                return index;
            }
            public static DescribeConfigsResource ReadV03(byte[] buffer, ref int index)
            {
                var ResourceTypeField = Decoder.ReadInt8(buffer, ref index);
                var ResourceNameField = Decoder.ReadString(buffer, ref index);
                var ConfigurationKeysField = Decoder.ReadArray<string>(buffer, ref index, Decoder.ReadCompactString);
                return new(
                    ResourceTypeField,
                    ResourceNameField,
                    ConfigurationKeysField
                );
            }
            public static int WriteV03(byte[] buffer, int index, DescribeConfigsResource message)
            {
                index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
                index = Encoder.WriteString(buffer, index, message.ResourceNameField);
                index = Encoder.WriteArray<string>(buffer, index, message.ConfigurationKeysField, Encoder.WriteCompactString);
                return index;
            }
            public static DescribeConfigsResource ReadV04(byte[] buffer, ref int index)
            {
                var ResourceTypeField = Decoder.ReadInt8(buffer, ref index);
                var ResourceNameField = Decoder.ReadCompactString(buffer, ref index);
                var ConfigurationKeysField = Decoder.ReadCompactArray<string>(buffer, ref index, Decoder.ReadCompactString);
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    ResourceTypeField,
                    ResourceNameField,
                    ConfigurationKeysField
                );
            }
            public static int WriteV04(byte[] buffer, int index, DescribeConfigsResource message)
            {
                index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
                index = Encoder.WriteCompactString(buffer, index, message.ResourceNameField);
                index = Encoder.WriteCompactArray<string>(buffer, index, message.ConfigurationKeysField, Encoder.WriteCompactString);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
        }
    }
}