using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using DescribeConfigsResource = Kafka.Client.Messages.DescribeConfigsRequest.DescribeConfigsResource;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeConfigsRequestSerde
    {
        private static readonly Func<Stream, DescribeConfigsRequest>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
            b => ReadV04(b),
        };
        private static readonly Action<Stream, DescribeConfigsRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
        };
        public static DescribeConfigsRequest Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, DescribeConfigsRequest message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static DescribeConfigsRequest ReadV00(Stream buffer)
        {
            var resourcesField = Decoder.ReadArray<DescribeConfigsResource>(buffer, b => DescribeConfigsResourceSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Resources'");
            var includeSynonymsField = default(bool);
            var includeDocumentationField = default(bool);
            return new(
                resourcesField,
                includeSynonymsField,
                includeDocumentationField
            );
        }
        private static void WriteV00(Stream buffer, DescribeConfigsRequest message)
        {
            Encoder.WriteArray<DescribeConfigsResource>(buffer, message.ResourcesField, (b, i) => DescribeConfigsResourceSerde.WriteV00(b, i));
        }
        private static DescribeConfigsRequest ReadV01(Stream buffer)
        {
            var resourcesField = Decoder.ReadArray<DescribeConfigsResource>(buffer, b => DescribeConfigsResourceSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Resources'");
            var includeSynonymsField = Decoder.ReadBoolean(buffer);
            var includeDocumentationField = default(bool);
            return new(
                resourcesField,
                includeSynonymsField,
                includeDocumentationField
            );
        }
        private static void WriteV01(Stream buffer, DescribeConfigsRequest message)
        {
            Encoder.WriteArray<DescribeConfigsResource>(buffer, message.ResourcesField, (b, i) => DescribeConfigsResourceSerde.WriteV01(b, i));
            Encoder.WriteBoolean(buffer, message.IncludeSynonymsField);
        }
        private static DescribeConfigsRequest ReadV02(Stream buffer)
        {
            var resourcesField = Decoder.ReadArray<DescribeConfigsResource>(buffer, b => DescribeConfigsResourceSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Resources'");
            var includeSynonymsField = Decoder.ReadBoolean(buffer);
            var includeDocumentationField = default(bool);
            return new(
                resourcesField,
                includeSynonymsField,
                includeDocumentationField
            );
        }
        private static void WriteV02(Stream buffer, DescribeConfigsRequest message)
        {
            Encoder.WriteArray<DescribeConfigsResource>(buffer, message.ResourcesField, (b, i) => DescribeConfigsResourceSerde.WriteV02(b, i));
            Encoder.WriteBoolean(buffer, message.IncludeSynonymsField);
        }
        private static DescribeConfigsRequest ReadV03(Stream buffer)
        {
            var resourcesField = Decoder.ReadArray<DescribeConfigsResource>(buffer, b => DescribeConfigsResourceSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Resources'");
            var includeSynonymsField = Decoder.ReadBoolean(buffer);
            var includeDocumentationField = Decoder.ReadBoolean(buffer);
            return new(
                resourcesField,
                includeSynonymsField,
                includeDocumentationField
            );
        }
        private static void WriteV03(Stream buffer, DescribeConfigsRequest message)
        {
            Encoder.WriteArray<DescribeConfigsResource>(buffer, message.ResourcesField, (b, i) => DescribeConfigsResourceSerde.WriteV03(b, i));
            Encoder.WriteBoolean(buffer, message.IncludeSynonymsField);
            Encoder.WriteBoolean(buffer, message.IncludeDocumentationField);
        }
        private static DescribeConfigsRequest ReadV04(Stream buffer)
        {
            var resourcesField = Decoder.ReadCompactArray<DescribeConfigsResource>(buffer, b => DescribeConfigsResourceSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'Resources'");
            var includeSynonymsField = Decoder.ReadBoolean(buffer);
            var includeDocumentationField = Decoder.ReadBoolean(buffer);
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                resourcesField,
                includeSynonymsField,
                includeDocumentationField
            );
        }
        private static void WriteV04(Stream buffer, DescribeConfigsRequest message)
        {
            Encoder.WriteCompactArray<DescribeConfigsResource>(buffer, message.ResourcesField, (b, i) => DescribeConfigsResourceSerde.WriteV04(b, i));
            Encoder.WriteBoolean(buffer, message.IncludeSynonymsField);
            Encoder.WriteBoolean(buffer, message.IncludeDocumentationField);
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class DescribeConfigsResourceSerde
        {
            public static DescribeConfigsResource ReadV00(Stream buffer)
            {
                var resourceTypeField = Decoder.ReadInt8(buffer);
                var resourceNameField = Decoder.ReadString(buffer);
                var configurationKeysField = Decoder.ReadArray<string>(buffer, b => Decoder.ReadCompactString(b));
                return new(
                    resourceTypeField,
                    resourceNameField,
                    configurationKeysField
                );
            }
            public static void WriteV00(Stream buffer, DescribeConfigsResource message)
            {
                Encoder.WriteInt8(buffer, message.ResourceTypeField);
                Encoder.WriteString(buffer, message.ResourceNameField);
                Encoder.WriteArray<string>(buffer, message.ConfigurationKeysField, (b, i) => Encoder.WriteCompactString(b, i));
            }
            public static DescribeConfigsResource ReadV01(Stream buffer)
            {
                var resourceTypeField = Decoder.ReadInt8(buffer);
                var resourceNameField = Decoder.ReadString(buffer);
                var configurationKeysField = Decoder.ReadArray<string>(buffer, b => Decoder.ReadCompactString(b));
                return new(
                    resourceTypeField,
                    resourceNameField,
                    configurationKeysField
                );
            }
            public static void WriteV01(Stream buffer, DescribeConfigsResource message)
            {
                Encoder.WriteInt8(buffer, message.ResourceTypeField);
                Encoder.WriteString(buffer, message.ResourceNameField);
                Encoder.WriteArray<string>(buffer, message.ConfigurationKeysField, (b, i) => Encoder.WriteCompactString(b, i));
            }
            public static DescribeConfigsResource ReadV02(Stream buffer)
            {
                var resourceTypeField = Decoder.ReadInt8(buffer);
                var resourceNameField = Decoder.ReadString(buffer);
                var configurationKeysField = Decoder.ReadArray<string>(buffer, b => Decoder.ReadCompactString(b));
                return new(
                    resourceTypeField,
                    resourceNameField,
                    configurationKeysField
                );
            }
            public static void WriteV02(Stream buffer, DescribeConfigsResource message)
            {
                Encoder.WriteInt8(buffer, message.ResourceTypeField);
                Encoder.WriteString(buffer, message.ResourceNameField);
                Encoder.WriteArray<string>(buffer, message.ConfigurationKeysField, (b, i) => Encoder.WriteCompactString(b, i));
            }
            public static DescribeConfigsResource ReadV03(Stream buffer)
            {
                var resourceTypeField = Decoder.ReadInt8(buffer);
                var resourceNameField = Decoder.ReadString(buffer);
                var configurationKeysField = Decoder.ReadArray<string>(buffer, b => Decoder.ReadCompactString(b));
                return new(
                    resourceTypeField,
                    resourceNameField,
                    configurationKeysField
                );
            }
            public static void WriteV03(Stream buffer, DescribeConfigsResource message)
            {
                Encoder.WriteInt8(buffer, message.ResourceTypeField);
                Encoder.WriteString(buffer, message.ResourceNameField);
                Encoder.WriteArray<string>(buffer, message.ConfigurationKeysField, (b, i) => Encoder.WriteCompactString(b, i));
            }
            public static DescribeConfigsResource ReadV04(Stream buffer)
            {
                var resourceTypeField = Decoder.ReadInt8(buffer);
                var resourceNameField = Decoder.ReadCompactString(buffer);
                var configurationKeysField = Decoder.ReadCompactArray<string>(buffer, b => Decoder.ReadCompactString(b));
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    resourceTypeField,
                    resourceNameField,
                    configurationKeysField
                );
            }
            public static void WriteV04(Stream buffer, DescribeConfigsResource message)
            {
                Encoder.WriteInt8(buffer, message.ResourceTypeField);
                Encoder.WriteCompactString(buffer, message.ResourceNameField);
                Encoder.WriteCompactArray<string>(buffer, message.ConfigurationKeysField, (b, i) => Encoder.WriteCompactString(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
        }
    }
}