using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using DescribeConfigsResource = Kafka.Client.Messages.DescribeConfigsRequest.DescribeConfigsResource;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeConfigsRequestSerde
    {
        private static readonly DecodeDelegate<DescribeConfigsRequest>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV04(ref b),
        };
        private static readonly EncodeDelegate<DescribeConfigsRequest>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
        };
        public static DescribeConfigsRequest Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, DescribeConfigsRequest message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static DescribeConfigsRequest ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var resourcesField = Decoder.ReadArray<DescribeConfigsResource>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribeConfigsResourceSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Resources'");
            var includeSynonymsField = default(bool);
            var includeDocumentationField = default(bool);
            return new(
                resourcesField,
                includeSynonymsField,
                includeDocumentationField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, DescribeConfigsRequest message)
        {
            buffer = Encoder.WriteArray<DescribeConfigsResource>(buffer, message.ResourcesField, (b, i) => DescribeConfigsResourceSerde.WriteV00(b, i));
            return buffer;
        }
        private static DescribeConfigsRequest ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var resourcesField = Decoder.ReadArray<DescribeConfigsResource>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribeConfigsResourceSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Resources'");
            var includeSynonymsField = Decoder.ReadBoolean(ref buffer);
            var includeDocumentationField = default(bool);
            return new(
                resourcesField,
                includeSynonymsField,
                includeDocumentationField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, DescribeConfigsRequest message)
        {
            buffer = Encoder.WriteArray<DescribeConfigsResource>(buffer, message.ResourcesField, (b, i) => DescribeConfigsResourceSerde.WriteV01(b, i));
            buffer = Encoder.WriteBoolean(buffer, message.IncludeSynonymsField);
            return buffer;
        }
        private static DescribeConfigsRequest ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var resourcesField = Decoder.ReadArray<DescribeConfigsResource>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribeConfigsResourceSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Resources'");
            var includeSynonymsField = Decoder.ReadBoolean(ref buffer);
            var includeDocumentationField = default(bool);
            return new(
                resourcesField,
                includeSynonymsField,
                includeDocumentationField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, DescribeConfigsRequest message)
        {
            buffer = Encoder.WriteArray<DescribeConfigsResource>(buffer, message.ResourcesField, (b, i) => DescribeConfigsResourceSerde.WriteV02(b, i));
            buffer = Encoder.WriteBoolean(buffer, message.IncludeSynonymsField);
            return buffer;
        }
        private static DescribeConfigsRequest ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var resourcesField = Decoder.ReadArray<DescribeConfigsResource>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribeConfigsResourceSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Resources'");
            var includeSynonymsField = Decoder.ReadBoolean(ref buffer);
            var includeDocumentationField = Decoder.ReadBoolean(ref buffer);
            return new(
                resourcesField,
                includeSynonymsField,
                includeDocumentationField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, DescribeConfigsRequest message)
        {
            buffer = Encoder.WriteArray<DescribeConfigsResource>(buffer, message.ResourcesField, (b, i) => DescribeConfigsResourceSerde.WriteV03(b, i));
            buffer = Encoder.WriteBoolean(buffer, message.IncludeSynonymsField);
            buffer = Encoder.WriteBoolean(buffer, message.IncludeDocumentationField);
            return buffer;
        }
        private static DescribeConfigsRequest ReadV04(ref ReadOnlyMemory<byte> buffer)
        {
            var resourcesField = Decoder.ReadCompactArray<DescribeConfigsResource>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribeConfigsResourceSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Resources'");
            var includeSynonymsField = Decoder.ReadBoolean(ref buffer);
            var includeDocumentationField = Decoder.ReadBoolean(ref buffer);
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                resourcesField,
                includeSynonymsField,
                includeDocumentationField
            );
        }
        private static Memory<byte> WriteV04(Memory<byte> buffer, DescribeConfigsRequest message)
        {
            buffer = Encoder.WriteCompactArray<DescribeConfigsResource>(buffer, message.ResourcesField, (b, i) => DescribeConfigsResourceSerde.WriteV04(b, i));
            buffer = Encoder.WriteBoolean(buffer, message.IncludeSynonymsField);
            buffer = Encoder.WriteBoolean(buffer, message.IncludeDocumentationField);
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class DescribeConfigsResourceSerde
        {
            public static DescribeConfigsResource ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var resourceTypeField = Decoder.ReadInt8(ref buffer);
                var resourceNameField = Decoder.ReadString(ref buffer);
                var configurationKeysField = Decoder.ReadArray<string>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadCompactString(ref b));
                return new(
                    resourceTypeField,
                    resourceNameField,
                    configurationKeysField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, DescribeConfigsResource message)
            {
                buffer = Encoder.WriteInt8(buffer, message.ResourceTypeField);
                buffer = Encoder.WriteString(buffer, message.ResourceNameField);
                buffer = Encoder.WriteArray<string>(buffer, message.ConfigurationKeysField, (b, i) => Encoder.WriteCompactString(b, i));
                return buffer;
            }
            public static DescribeConfigsResource ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var resourceTypeField = Decoder.ReadInt8(ref buffer);
                var resourceNameField = Decoder.ReadString(ref buffer);
                var configurationKeysField = Decoder.ReadArray<string>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadCompactString(ref b));
                return new(
                    resourceTypeField,
                    resourceNameField,
                    configurationKeysField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, DescribeConfigsResource message)
            {
                buffer = Encoder.WriteInt8(buffer, message.ResourceTypeField);
                buffer = Encoder.WriteString(buffer, message.ResourceNameField);
                buffer = Encoder.WriteArray<string>(buffer, message.ConfigurationKeysField, (b, i) => Encoder.WriteCompactString(b, i));
                return buffer;
            }
            public static DescribeConfigsResource ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var resourceTypeField = Decoder.ReadInt8(ref buffer);
                var resourceNameField = Decoder.ReadString(ref buffer);
                var configurationKeysField = Decoder.ReadArray<string>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadCompactString(ref b));
                return new(
                    resourceTypeField,
                    resourceNameField,
                    configurationKeysField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, DescribeConfigsResource message)
            {
                buffer = Encoder.WriteInt8(buffer, message.ResourceTypeField);
                buffer = Encoder.WriteString(buffer, message.ResourceNameField);
                buffer = Encoder.WriteArray<string>(buffer, message.ConfigurationKeysField, (b, i) => Encoder.WriteCompactString(b, i));
                return buffer;
            }
            public static DescribeConfigsResource ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var resourceTypeField = Decoder.ReadInt8(ref buffer);
                var resourceNameField = Decoder.ReadString(ref buffer);
                var configurationKeysField = Decoder.ReadArray<string>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadCompactString(ref b));
                return new(
                    resourceTypeField,
                    resourceNameField,
                    configurationKeysField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, DescribeConfigsResource message)
            {
                buffer = Encoder.WriteInt8(buffer, message.ResourceTypeField);
                buffer = Encoder.WriteString(buffer, message.ResourceNameField);
                buffer = Encoder.WriteArray<string>(buffer, message.ConfigurationKeysField, (b, i) => Encoder.WriteCompactString(b, i));
                return buffer;
            }
            public static DescribeConfigsResource ReadV04(ref ReadOnlyMemory<byte> buffer)
            {
                var resourceTypeField = Decoder.ReadInt8(ref buffer);
                var resourceNameField = Decoder.ReadCompactString(ref buffer);
                var configurationKeysField = Decoder.ReadCompactArray<string>(ref buffer, (ref ReadOnlyMemory<byte> b) => Decoder.ReadCompactString(ref b));
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    resourceTypeField,
                    resourceNameField,
                    configurationKeysField
                );
            }
            public static Memory<byte> WriteV04(Memory<byte> buffer, DescribeConfigsResource message)
            {
                buffer = Encoder.WriteInt8(buffer, message.ResourceTypeField);
                buffer = Encoder.WriteCompactString(buffer, message.ResourceNameField);
                buffer = Encoder.WriteCompactArray<string>(buffer, message.ConfigurationKeysField, (b, i) => Encoder.WriteCompactString(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
        }
    }
}