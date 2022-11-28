using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using DescribeConfigsResult = Kafka.Client.Messages.DescribeConfigsResponse.DescribeConfigsResult;
using DescribeConfigsSynonym = Kafka.Client.Messages.DescribeConfigsResponse.DescribeConfigsResult.DescribeConfigsResourceResult.DescribeConfigsSynonym;
using DescribeConfigsResourceResult = Kafka.Client.Messages.DescribeConfigsResponse.DescribeConfigsResult.DescribeConfigsResourceResult;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeConfigsResponseSerde
    {
        private static readonly DecodeDelegate<DescribeConfigsResponse>[] READ_VERSIONS = {
            (ref ReadOnlyMemory<byte> b) => ReadV00(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV01(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV02(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV03(ref b),
            (ref ReadOnlyMemory<byte> b) => ReadV04(ref b),
        };
        private static readonly EncodeDelegate<DescribeConfigsResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
        };
        public static DescribeConfigsResponse Read(ref ReadOnlyMemory<byte> buffer, short version) =>
            READ_VERSIONS[version](ref buffer)
        ;
        public static Memory<byte> Write(Memory<byte> buffer, short version, DescribeConfigsResponse message) =>
            WRITE_VERSIONS[version](buffer, message);
        private static DescribeConfigsResponse ReadV00(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var resultsField = Decoder.ReadArray<DescribeConfigsResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribeConfigsResultSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static Memory<byte> WriteV00(Memory<byte> buffer, DescribeConfigsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<DescribeConfigsResult>(buffer, message.ResultsField, (b, i) => DescribeConfigsResultSerde.WriteV00(b, i));
            return buffer;
        }
        private static DescribeConfigsResponse ReadV01(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var resultsField = Decoder.ReadArray<DescribeConfigsResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribeConfigsResultSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static Memory<byte> WriteV01(Memory<byte> buffer, DescribeConfigsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<DescribeConfigsResult>(buffer, message.ResultsField, (b, i) => DescribeConfigsResultSerde.WriteV01(b, i));
            return buffer;
        }
        private static DescribeConfigsResponse ReadV02(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var resultsField = Decoder.ReadArray<DescribeConfigsResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribeConfigsResultSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static Memory<byte> WriteV02(Memory<byte> buffer, DescribeConfigsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<DescribeConfigsResult>(buffer, message.ResultsField, (b, i) => DescribeConfigsResultSerde.WriteV02(b, i));
            return buffer;
        }
        private static DescribeConfigsResponse ReadV03(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var resultsField = Decoder.ReadArray<DescribeConfigsResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribeConfigsResultSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static Memory<byte> WriteV03(Memory<byte> buffer, DescribeConfigsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteArray<DescribeConfigsResult>(buffer, message.ResultsField, (b, i) => DescribeConfigsResultSerde.WriteV03(b, i));
            return buffer;
        }
        private static DescribeConfigsResponse ReadV04(ref ReadOnlyMemory<byte> buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(ref buffer);
            var resultsField = Decoder.ReadCompactArray<DescribeConfigsResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribeConfigsResultSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            _ = Decoder.ReadVarUInt32(ref buffer);
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static Memory<byte> WriteV04(Memory<byte> buffer, DescribeConfigsResponse message)
        {
            buffer = Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            buffer = Encoder.WriteCompactArray<DescribeConfigsResult>(buffer, message.ResultsField, (b, i) => DescribeConfigsResultSerde.WriteV04(b, i));
            buffer = Encoder.WriteVarUInt32(buffer, 0);
            return buffer;
        }
        private static class DescribeConfigsResultSerde
        {
            public static DescribeConfigsResult ReadV00(ref ReadOnlyMemory<byte> buffer)
            {
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var errorMessageField = Decoder.ReadNullableString(ref buffer);
                var resourceTypeField = Decoder.ReadInt8(ref buffer);
                var resourceNameField = Decoder.ReadString(ref buffer);
                var configsField = Decoder.ReadArray<DescribeConfigsResourceResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribeConfigsResourceResultSerde.ReadV00(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                return new(
                    errorCodeField,
                    errorMessageField,
                    resourceTypeField,
                    resourceNameField,
                    configsField
                );
            }
            public static Memory<byte> WriteV00(Memory<byte> buffer, DescribeConfigsResult message)
            {
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteNullableString(buffer, message.ErrorMessageField);
                buffer = Encoder.WriteInt8(buffer, message.ResourceTypeField);
                buffer = Encoder.WriteString(buffer, message.ResourceNameField);
                buffer = Encoder.WriteArray<DescribeConfigsResourceResult>(buffer, message.ConfigsField, (b, i) => DescribeConfigsResourceResultSerde.WriteV00(b, i));
                return buffer;
            }
            public static DescribeConfigsResult ReadV01(ref ReadOnlyMemory<byte> buffer)
            {
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var errorMessageField = Decoder.ReadNullableString(ref buffer);
                var resourceTypeField = Decoder.ReadInt8(ref buffer);
                var resourceNameField = Decoder.ReadString(ref buffer);
                var configsField = Decoder.ReadArray<DescribeConfigsResourceResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribeConfigsResourceResultSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                return new(
                    errorCodeField,
                    errorMessageField,
                    resourceTypeField,
                    resourceNameField,
                    configsField
                );
            }
            public static Memory<byte> WriteV01(Memory<byte> buffer, DescribeConfigsResult message)
            {
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteNullableString(buffer, message.ErrorMessageField);
                buffer = Encoder.WriteInt8(buffer, message.ResourceTypeField);
                buffer = Encoder.WriteString(buffer, message.ResourceNameField);
                buffer = Encoder.WriteArray<DescribeConfigsResourceResult>(buffer, message.ConfigsField, (b, i) => DescribeConfigsResourceResultSerde.WriteV01(b, i));
                return buffer;
            }
            public static DescribeConfigsResult ReadV02(ref ReadOnlyMemory<byte> buffer)
            {
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var errorMessageField = Decoder.ReadNullableString(ref buffer);
                var resourceTypeField = Decoder.ReadInt8(ref buffer);
                var resourceNameField = Decoder.ReadString(ref buffer);
                var configsField = Decoder.ReadArray<DescribeConfigsResourceResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribeConfigsResourceResultSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                return new(
                    errorCodeField,
                    errorMessageField,
                    resourceTypeField,
                    resourceNameField,
                    configsField
                );
            }
            public static Memory<byte> WriteV02(Memory<byte> buffer, DescribeConfigsResult message)
            {
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteNullableString(buffer, message.ErrorMessageField);
                buffer = Encoder.WriteInt8(buffer, message.ResourceTypeField);
                buffer = Encoder.WriteString(buffer, message.ResourceNameField);
                buffer = Encoder.WriteArray<DescribeConfigsResourceResult>(buffer, message.ConfigsField, (b, i) => DescribeConfigsResourceResultSerde.WriteV02(b, i));
                return buffer;
            }
            public static DescribeConfigsResult ReadV03(ref ReadOnlyMemory<byte> buffer)
            {
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var errorMessageField = Decoder.ReadNullableString(ref buffer);
                var resourceTypeField = Decoder.ReadInt8(ref buffer);
                var resourceNameField = Decoder.ReadString(ref buffer);
                var configsField = Decoder.ReadArray<DescribeConfigsResourceResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribeConfigsResourceResultSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                return new(
                    errorCodeField,
                    errorMessageField,
                    resourceTypeField,
                    resourceNameField,
                    configsField
                );
            }
            public static Memory<byte> WriteV03(Memory<byte> buffer, DescribeConfigsResult message)
            {
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteNullableString(buffer, message.ErrorMessageField);
                buffer = Encoder.WriteInt8(buffer, message.ResourceTypeField);
                buffer = Encoder.WriteString(buffer, message.ResourceNameField);
                buffer = Encoder.WriteArray<DescribeConfigsResourceResult>(buffer, message.ConfigsField, (b, i) => DescribeConfigsResourceResultSerde.WriteV03(b, i));
                return buffer;
            }
            public static DescribeConfigsResult ReadV04(ref ReadOnlyMemory<byte> buffer)
            {
                var errorCodeField = Decoder.ReadInt16(ref buffer);
                var errorMessageField = Decoder.ReadCompactNullableString(ref buffer);
                var resourceTypeField = Decoder.ReadInt8(ref buffer);
                var resourceNameField = Decoder.ReadCompactString(ref buffer);
                var configsField = Decoder.ReadCompactArray<DescribeConfigsResourceResult>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribeConfigsResourceResultSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                _ = Decoder.ReadVarUInt32(ref buffer);
                return new(
                    errorCodeField,
                    errorMessageField,
                    resourceTypeField,
                    resourceNameField,
                    configsField
                );
            }
            public static Memory<byte> WriteV04(Memory<byte> buffer, DescribeConfigsResult message)
            {
                buffer = Encoder.WriteInt16(buffer, message.ErrorCodeField);
                buffer = Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                buffer = Encoder.WriteInt8(buffer, message.ResourceTypeField);
                buffer = Encoder.WriteCompactString(buffer, message.ResourceNameField);
                buffer = Encoder.WriteCompactArray<DescribeConfigsResourceResult>(buffer, message.ConfigsField, (b, i) => DescribeConfigsResourceResultSerde.WriteV04(b, i));
                buffer = Encoder.WriteVarUInt32(buffer, 0);
                return buffer;
            }
            private static class DescribeConfigsResourceResultSerde
            {
                public static DescribeConfigsResourceResult ReadV00(ref ReadOnlyMemory<byte> buffer)
                {
                    var nameField = Decoder.ReadString(ref buffer);
                    var valueField = Decoder.ReadNullableString(ref buffer);
                    var readOnlyField = Decoder.ReadBoolean(ref buffer);
                    var isDefaultField = Decoder.ReadBoolean(ref buffer);
                    var configSourceField = default(sbyte);
                    var isSensitiveField = Decoder.ReadBoolean(ref buffer);
                    var synonymsField = ImmutableArray<DescribeConfigsSynonym>.Empty;
                    var configTypeField = default(sbyte);
                    var documentationField = default(string?);
                    return new(
                        nameField,
                        valueField,
                        readOnlyField,
                        isDefaultField,
                        configSourceField,
                        isSensitiveField,
                        synonymsField,
                        configTypeField,
                        documentationField
                    );
                }
                public static Memory<byte> WriteV00(Memory<byte> buffer, DescribeConfigsResourceResult message)
                {
                    buffer = Encoder.WriteString(buffer, message.NameField);
                    buffer = Encoder.WriteNullableString(buffer, message.ValueField);
                    buffer = Encoder.WriteBoolean(buffer, message.ReadOnlyField);
                    buffer = Encoder.WriteBoolean(buffer, message.IsDefaultField);
                    buffer = Encoder.WriteBoolean(buffer, message.IsSensitiveField);
                    return buffer;
                }
                public static DescribeConfigsResourceResult ReadV01(ref ReadOnlyMemory<byte> buffer)
                {
                    var nameField = Decoder.ReadString(ref buffer);
                    var valueField = Decoder.ReadNullableString(ref buffer);
                    var readOnlyField = Decoder.ReadBoolean(ref buffer);
                    var isDefaultField = default(bool);
                    var configSourceField = Decoder.ReadInt8(ref buffer);
                    var isSensitiveField = Decoder.ReadBoolean(ref buffer);
                    var synonymsField = Decoder.ReadArray<DescribeConfigsSynonym>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribeConfigsSynonymSerde.ReadV01(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Synonyms'");
                    var configTypeField = default(sbyte);
                    var documentationField = default(string?);
                    return new(
                        nameField,
                        valueField,
                        readOnlyField,
                        isDefaultField,
                        configSourceField,
                        isSensitiveField,
                        synonymsField,
                        configTypeField,
                        documentationField
                    );
                }
                public static Memory<byte> WriteV01(Memory<byte> buffer, DescribeConfigsResourceResult message)
                {
                    buffer = Encoder.WriteString(buffer, message.NameField);
                    buffer = Encoder.WriteNullableString(buffer, message.ValueField);
                    buffer = Encoder.WriteBoolean(buffer, message.ReadOnlyField);
                    buffer = Encoder.WriteInt8(buffer, message.ConfigSourceField);
                    buffer = Encoder.WriteBoolean(buffer, message.IsSensitiveField);
                    buffer = Encoder.WriteArray<DescribeConfigsSynonym>(buffer, message.SynonymsField, (b, i) => DescribeConfigsSynonymSerde.WriteV01(b, i));
                    return buffer;
                }
                public static DescribeConfigsResourceResult ReadV02(ref ReadOnlyMemory<byte> buffer)
                {
                    var nameField = Decoder.ReadString(ref buffer);
                    var valueField = Decoder.ReadNullableString(ref buffer);
                    var readOnlyField = Decoder.ReadBoolean(ref buffer);
                    var isDefaultField = default(bool);
                    var configSourceField = Decoder.ReadInt8(ref buffer);
                    var isSensitiveField = Decoder.ReadBoolean(ref buffer);
                    var synonymsField = Decoder.ReadArray<DescribeConfigsSynonym>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribeConfigsSynonymSerde.ReadV02(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Synonyms'");
                    var configTypeField = default(sbyte);
                    var documentationField = default(string?);
                    return new(
                        nameField,
                        valueField,
                        readOnlyField,
                        isDefaultField,
                        configSourceField,
                        isSensitiveField,
                        synonymsField,
                        configTypeField,
                        documentationField
                    );
                }
                public static Memory<byte> WriteV02(Memory<byte> buffer, DescribeConfigsResourceResult message)
                {
                    buffer = Encoder.WriteString(buffer, message.NameField);
                    buffer = Encoder.WriteNullableString(buffer, message.ValueField);
                    buffer = Encoder.WriteBoolean(buffer, message.ReadOnlyField);
                    buffer = Encoder.WriteInt8(buffer, message.ConfigSourceField);
                    buffer = Encoder.WriteBoolean(buffer, message.IsSensitiveField);
                    buffer = Encoder.WriteArray<DescribeConfigsSynonym>(buffer, message.SynonymsField, (b, i) => DescribeConfigsSynonymSerde.WriteV02(b, i));
                    return buffer;
                }
                public static DescribeConfigsResourceResult ReadV03(ref ReadOnlyMemory<byte> buffer)
                {
                    var nameField = Decoder.ReadString(ref buffer);
                    var valueField = Decoder.ReadNullableString(ref buffer);
                    var readOnlyField = Decoder.ReadBoolean(ref buffer);
                    var isDefaultField = default(bool);
                    var configSourceField = Decoder.ReadInt8(ref buffer);
                    var isSensitiveField = Decoder.ReadBoolean(ref buffer);
                    var synonymsField = Decoder.ReadArray<DescribeConfigsSynonym>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribeConfigsSynonymSerde.ReadV03(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Synonyms'");
                    var configTypeField = Decoder.ReadInt8(ref buffer);
                    var documentationField = Decoder.ReadNullableString(ref buffer);
                    return new(
                        nameField,
                        valueField,
                        readOnlyField,
                        isDefaultField,
                        configSourceField,
                        isSensitiveField,
                        synonymsField,
                        configTypeField,
                        documentationField
                    );
                }
                public static Memory<byte> WriteV03(Memory<byte> buffer, DescribeConfigsResourceResult message)
                {
                    buffer = Encoder.WriteString(buffer, message.NameField);
                    buffer = Encoder.WriteNullableString(buffer, message.ValueField);
                    buffer = Encoder.WriteBoolean(buffer, message.ReadOnlyField);
                    buffer = Encoder.WriteInt8(buffer, message.ConfigSourceField);
                    buffer = Encoder.WriteBoolean(buffer, message.IsSensitiveField);
                    buffer = Encoder.WriteArray<DescribeConfigsSynonym>(buffer, message.SynonymsField, (b, i) => DescribeConfigsSynonymSerde.WriteV03(b, i));
                    buffer = Encoder.WriteInt8(buffer, message.ConfigTypeField);
                    buffer = Encoder.WriteNullableString(buffer, message.DocumentationField);
                    return buffer;
                }
                public static DescribeConfigsResourceResult ReadV04(ref ReadOnlyMemory<byte> buffer)
                {
                    var nameField = Decoder.ReadCompactString(ref buffer);
                    var valueField = Decoder.ReadCompactNullableString(ref buffer);
                    var readOnlyField = Decoder.ReadBoolean(ref buffer);
                    var isDefaultField = default(bool);
                    var configSourceField = Decoder.ReadInt8(ref buffer);
                    var isSensitiveField = Decoder.ReadBoolean(ref buffer);
                    var synonymsField = Decoder.ReadCompactArray<DescribeConfigsSynonym>(ref buffer, (ref ReadOnlyMemory<byte> b) => DescribeConfigsSynonymSerde.ReadV04(ref b)) ?? throw new NullReferenceException("Null not allowed for 'Synonyms'");
                    var configTypeField = Decoder.ReadInt8(ref buffer);
                    var documentationField = Decoder.ReadCompactNullableString(ref buffer);
                    _ = Decoder.ReadVarUInt32(ref buffer);
                    return new(
                        nameField,
                        valueField,
                        readOnlyField,
                        isDefaultField,
                        configSourceField,
                        isSensitiveField,
                        synonymsField,
                        configTypeField,
                        documentationField
                    );
                }
                public static Memory<byte> WriteV04(Memory<byte> buffer, DescribeConfigsResourceResult message)
                {
                    buffer = Encoder.WriteCompactString(buffer, message.NameField);
                    buffer = Encoder.WriteCompactNullableString(buffer, message.ValueField);
                    buffer = Encoder.WriteBoolean(buffer, message.ReadOnlyField);
                    buffer = Encoder.WriteInt8(buffer, message.ConfigSourceField);
                    buffer = Encoder.WriteBoolean(buffer, message.IsSensitiveField);
                    buffer = Encoder.WriteCompactArray<DescribeConfigsSynonym>(buffer, message.SynonymsField, (b, i) => DescribeConfigsSynonymSerde.WriteV04(b, i));
                    buffer = Encoder.WriteInt8(buffer, message.ConfigTypeField);
                    buffer = Encoder.WriteCompactNullableString(buffer, message.DocumentationField);
                    buffer = Encoder.WriteVarUInt32(buffer, 0);
                    return buffer;
                }
                private static class DescribeConfigsSynonymSerde
                {
                    public static DescribeConfigsSynonym ReadV01(ref ReadOnlyMemory<byte> buffer)
                    {
                        var nameField = Decoder.ReadString(ref buffer);
                        var valueField = Decoder.ReadNullableString(ref buffer);
                        var sourceField = Decoder.ReadInt8(ref buffer);
                        return new(
                            nameField,
                            valueField,
                            sourceField
                        );
                    }
                    public static Memory<byte> WriteV01(Memory<byte> buffer, DescribeConfigsSynonym message)
                    {
                        buffer = Encoder.WriteString(buffer, message.NameField);
                        buffer = Encoder.WriteNullableString(buffer, message.ValueField);
                        buffer = Encoder.WriteInt8(buffer, message.SourceField);
                        return buffer;
                    }
                    public static DescribeConfigsSynonym ReadV02(ref ReadOnlyMemory<byte> buffer)
                    {
                        var nameField = Decoder.ReadString(ref buffer);
                        var valueField = Decoder.ReadNullableString(ref buffer);
                        var sourceField = Decoder.ReadInt8(ref buffer);
                        return new(
                            nameField,
                            valueField,
                            sourceField
                        );
                    }
                    public static Memory<byte> WriteV02(Memory<byte> buffer, DescribeConfigsSynonym message)
                    {
                        buffer = Encoder.WriteString(buffer, message.NameField);
                        buffer = Encoder.WriteNullableString(buffer, message.ValueField);
                        buffer = Encoder.WriteInt8(buffer, message.SourceField);
                        return buffer;
                    }
                    public static DescribeConfigsSynonym ReadV03(ref ReadOnlyMemory<byte> buffer)
                    {
                        var nameField = Decoder.ReadString(ref buffer);
                        var valueField = Decoder.ReadNullableString(ref buffer);
                        var sourceField = Decoder.ReadInt8(ref buffer);
                        return new(
                            nameField,
                            valueField,
                            sourceField
                        );
                    }
                    public static Memory<byte> WriteV03(Memory<byte> buffer, DescribeConfigsSynonym message)
                    {
                        buffer = Encoder.WriteString(buffer, message.NameField);
                        buffer = Encoder.WriteNullableString(buffer, message.ValueField);
                        buffer = Encoder.WriteInt8(buffer, message.SourceField);
                        return buffer;
                    }
                    public static DescribeConfigsSynonym ReadV04(ref ReadOnlyMemory<byte> buffer)
                    {
                        var nameField = Decoder.ReadCompactString(ref buffer);
                        var valueField = Decoder.ReadCompactNullableString(ref buffer);
                        var sourceField = Decoder.ReadInt8(ref buffer);
                        _ = Decoder.ReadVarUInt32(ref buffer);
                        return new(
                            nameField,
                            valueField,
                            sourceField
                        );
                    }
                    public static Memory<byte> WriteV04(Memory<byte> buffer, DescribeConfigsSynonym message)
                    {
                        buffer = Encoder.WriteCompactString(buffer, message.NameField);
                        buffer = Encoder.WriteCompactNullableString(buffer, message.ValueField);
                        buffer = Encoder.WriteInt8(buffer, message.SourceField);
                        buffer = Encoder.WriteVarUInt32(buffer, 0);
                        return buffer;
                    }
                }
            }
        }
    }
}