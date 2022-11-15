using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using DescribeConfigsResourceResult = Kafka.Client.Messages.DescribeConfigsResponse.DescribeConfigsResult.DescribeConfigsResourceResult;
using DescribeConfigsSynonym = Kafka.Client.Messages.DescribeConfigsResponse.DescribeConfigsResult.DescribeConfigsResourceResult.DescribeConfigsSynonym;
using DescribeConfigsResult = Kafka.Client.Messages.DescribeConfigsResponse.DescribeConfigsResult;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeConfigsResponseSerde
    {
        private static readonly Func<Stream, DescribeConfigsResponse>[] READ_VERSIONS = {
            b => ReadV00(b),
            b => ReadV01(b),
            b => ReadV02(b),
            b => ReadV03(b),
            b => ReadV04(b),
        };
        private static readonly Action<Stream, DescribeConfigsResponse>[] WRITE_VERSIONS = {
            (b, m) => WriteV00(b, m),
            (b, m) => WriteV01(b, m),
            (b, m) => WriteV02(b, m),
            (b, m) => WriteV03(b, m),
            (b, m) => WriteV04(b, m),
        };
        public static DescribeConfigsResponse Read(Stream buffer, short version) =>
            READ_VERSIONS[version](buffer)
        ;
        public static void Write(Stream buffer, short version, DescribeConfigsResponse message) =>
            WRITE_VERSIONS[version](buffer, message)
        ;
        private static DescribeConfigsResponse ReadV00(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var resultsField = Decoder.ReadArray<DescribeConfigsResult>(buffer, b => DescribeConfigsResultSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static void WriteV00(Stream buffer, DescribeConfigsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<DescribeConfigsResult>(buffer, message.ResultsField, (b, i) => DescribeConfigsResultSerde.WriteV00(b, i));
        }
        private static DescribeConfigsResponse ReadV01(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var resultsField = Decoder.ReadArray<DescribeConfigsResult>(buffer, b => DescribeConfigsResultSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static void WriteV01(Stream buffer, DescribeConfigsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<DescribeConfigsResult>(buffer, message.ResultsField, (b, i) => DescribeConfigsResultSerde.WriteV01(b, i));
        }
        private static DescribeConfigsResponse ReadV02(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var resultsField = Decoder.ReadArray<DescribeConfigsResult>(buffer, b => DescribeConfigsResultSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static void WriteV02(Stream buffer, DescribeConfigsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<DescribeConfigsResult>(buffer, message.ResultsField, (b, i) => DescribeConfigsResultSerde.WriteV02(b, i));
        }
        private static DescribeConfigsResponse ReadV03(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var resultsField = Decoder.ReadArray<DescribeConfigsResult>(buffer, b => DescribeConfigsResultSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static void WriteV03(Stream buffer, DescribeConfigsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteArray<DescribeConfigsResult>(buffer, message.ResultsField, (b, i) => DescribeConfigsResultSerde.WriteV03(b, i));
        }
        private static DescribeConfigsResponse ReadV04(Stream buffer)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer);
            var resultsField = Decoder.ReadCompactArray<DescribeConfigsResult>(buffer, b => DescribeConfigsResultSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            _ = Decoder.ReadVarUInt32(buffer);
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static void WriteV04(Stream buffer, DescribeConfigsResponse message)
        {
            Encoder.WriteInt32(buffer, message.ThrottleTimeMsField);
            Encoder.WriteCompactArray<DescribeConfigsResult>(buffer, message.ResultsField, (b, i) => DescribeConfigsResultSerde.WriteV04(b, i));
            Encoder.WriteVarUInt32(buffer, 0);
        }
        private static class DescribeConfigsResultSerde
        {
            public static DescribeConfigsResult ReadV00(Stream buffer)
            {
                var errorCodeField = Decoder.ReadInt16(buffer);
                var errorMessageField = Decoder.ReadNullableString(buffer);
                var resourceTypeField = Decoder.ReadInt8(buffer);
                var resourceNameField = Decoder.ReadString(buffer);
                var configsField = Decoder.ReadArray<DescribeConfigsResourceResult>(buffer, b => DescribeConfigsResourceResultSerde.ReadV00(b)) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                return new(
                    errorCodeField,
                    errorMessageField,
                    resourceTypeField,
                    resourceNameField,
                    configsField
                );
            }
            public static void WriteV00(Stream buffer, DescribeConfigsResult message)
            {
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteNullableString(buffer, message.ErrorMessageField);
                Encoder.WriteInt8(buffer, message.ResourceTypeField);
                Encoder.WriteString(buffer, message.ResourceNameField);
                Encoder.WriteArray<DescribeConfigsResourceResult>(buffer, message.ConfigsField, (b, i) => DescribeConfigsResourceResultSerde.WriteV00(b, i));
            }
            public static DescribeConfigsResult ReadV01(Stream buffer)
            {
                var errorCodeField = Decoder.ReadInt16(buffer);
                var errorMessageField = Decoder.ReadNullableString(buffer);
                var resourceTypeField = Decoder.ReadInt8(buffer);
                var resourceNameField = Decoder.ReadString(buffer);
                var configsField = Decoder.ReadArray<DescribeConfigsResourceResult>(buffer, b => DescribeConfigsResourceResultSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                return new(
                    errorCodeField,
                    errorMessageField,
                    resourceTypeField,
                    resourceNameField,
                    configsField
                );
            }
            public static void WriteV01(Stream buffer, DescribeConfigsResult message)
            {
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteNullableString(buffer, message.ErrorMessageField);
                Encoder.WriteInt8(buffer, message.ResourceTypeField);
                Encoder.WriteString(buffer, message.ResourceNameField);
                Encoder.WriteArray<DescribeConfigsResourceResult>(buffer, message.ConfigsField, (b, i) => DescribeConfigsResourceResultSerde.WriteV01(b, i));
            }
            public static DescribeConfigsResult ReadV02(Stream buffer)
            {
                var errorCodeField = Decoder.ReadInt16(buffer);
                var errorMessageField = Decoder.ReadNullableString(buffer);
                var resourceTypeField = Decoder.ReadInt8(buffer);
                var resourceNameField = Decoder.ReadString(buffer);
                var configsField = Decoder.ReadArray<DescribeConfigsResourceResult>(buffer, b => DescribeConfigsResourceResultSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                return new(
                    errorCodeField,
                    errorMessageField,
                    resourceTypeField,
                    resourceNameField,
                    configsField
                );
            }
            public static void WriteV02(Stream buffer, DescribeConfigsResult message)
            {
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteNullableString(buffer, message.ErrorMessageField);
                Encoder.WriteInt8(buffer, message.ResourceTypeField);
                Encoder.WriteString(buffer, message.ResourceNameField);
                Encoder.WriteArray<DescribeConfigsResourceResult>(buffer, message.ConfigsField, (b, i) => DescribeConfigsResourceResultSerde.WriteV02(b, i));
            }
            public static DescribeConfigsResult ReadV03(Stream buffer)
            {
                var errorCodeField = Decoder.ReadInt16(buffer);
                var errorMessageField = Decoder.ReadNullableString(buffer);
                var resourceTypeField = Decoder.ReadInt8(buffer);
                var resourceNameField = Decoder.ReadString(buffer);
                var configsField = Decoder.ReadArray<DescribeConfigsResourceResult>(buffer, b => DescribeConfigsResourceResultSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                return new(
                    errorCodeField,
                    errorMessageField,
                    resourceTypeField,
                    resourceNameField,
                    configsField
                );
            }
            public static void WriteV03(Stream buffer, DescribeConfigsResult message)
            {
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteNullableString(buffer, message.ErrorMessageField);
                Encoder.WriteInt8(buffer, message.ResourceTypeField);
                Encoder.WriteString(buffer, message.ResourceNameField);
                Encoder.WriteArray<DescribeConfigsResourceResult>(buffer, message.ConfigsField, (b, i) => DescribeConfigsResourceResultSerde.WriteV03(b, i));
            }
            public static DescribeConfigsResult ReadV04(Stream buffer)
            {
                var errorCodeField = Decoder.ReadInt16(buffer);
                var errorMessageField = Decoder.ReadCompactNullableString(buffer);
                var resourceTypeField = Decoder.ReadInt8(buffer);
                var resourceNameField = Decoder.ReadCompactString(buffer);
                var configsField = Decoder.ReadCompactArray<DescribeConfigsResourceResult>(buffer, b => DescribeConfigsResourceResultSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                _ = Decoder.ReadVarUInt32(buffer);
                return new(
                    errorCodeField,
                    errorMessageField,
                    resourceTypeField,
                    resourceNameField,
                    configsField
                );
            }
            public static void WriteV04(Stream buffer, DescribeConfigsResult message)
            {
                Encoder.WriteInt16(buffer, message.ErrorCodeField);
                Encoder.WriteCompactNullableString(buffer, message.ErrorMessageField);
                Encoder.WriteInt8(buffer, message.ResourceTypeField);
                Encoder.WriteCompactString(buffer, message.ResourceNameField);
                Encoder.WriteCompactArray<DescribeConfigsResourceResult>(buffer, message.ConfigsField, (b, i) => DescribeConfigsResourceResultSerde.WriteV04(b, i));
                Encoder.WriteVarUInt32(buffer, 0);
            }
            private static class DescribeConfigsResourceResultSerde
            {
                public static DescribeConfigsResourceResult ReadV00(Stream buffer)
                {
                    var nameField = Decoder.ReadString(buffer);
                    var valueField = Decoder.ReadNullableString(buffer);
                    var readOnlyField = Decoder.ReadBoolean(buffer);
                    var isDefaultField = Decoder.ReadBoolean(buffer);
                    var configSourceField = default(sbyte);
                    var isSensitiveField = Decoder.ReadBoolean(buffer);
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
                public static void WriteV00(Stream buffer, DescribeConfigsResourceResult message)
                {
                    Encoder.WriteString(buffer, message.NameField);
                    Encoder.WriteNullableString(buffer, message.ValueField);
                    Encoder.WriteBoolean(buffer, message.ReadOnlyField);
                    Encoder.WriteBoolean(buffer, message.IsDefaultField);
                    Encoder.WriteBoolean(buffer, message.IsSensitiveField);
                }
                public static DescribeConfigsResourceResult ReadV01(Stream buffer)
                {
                    var nameField = Decoder.ReadString(buffer);
                    var valueField = Decoder.ReadNullableString(buffer);
                    var readOnlyField = Decoder.ReadBoolean(buffer);
                    var isDefaultField = default(bool);
                    var configSourceField = Decoder.ReadInt8(buffer);
                    var isSensitiveField = Decoder.ReadBoolean(buffer);
                    var synonymsField = Decoder.ReadArray<DescribeConfigsSynonym>(buffer, b => DescribeConfigsSynonymSerde.ReadV01(b)) ?? throw new NullReferenceException("Null not allowed for 'Synonyms'");
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
                public static void WriteV01(Stream buffer, DescribeConfigsResourceResult message)
                {
                    Encoder.WriteString(buffer, message.NameField);
                    Encoder.WriteNullableString(buffer, message.ValueField);
                    Encoder.WriteBoolean(buffer, message.ReadOnlyField);
                    Encoder.WriteInt8(buffer, message.ConfigSourceField);
                    Encoder.WriteBoolean(buffer, message.IsSensitiveField);
                    Encoder.WriteArray<DescribeConfigsSynonym>(buffer, message.SynonymsField, (b, i) => DescribeConfigsSynonymSerde.WriteV01(b, i));
                }
                public static DescribeConfigsResourceResult ReadV02(Stream buffer)
                {
                    var nameField = Decoder.ReadString(buffer);
                    var valueField = Decoder.ReadNullableString(buffer);
                    var readOnlyField = Decoder.ReadBoolean(buffer);
                    var isDefaultField = default(bool);
                    var configSourceField = Decoder.ReadInt8(buffer);
                    var isSensitiveField = Decoder.ReadBoolean(buffer);
                    var synonymsField = Decoder.ReadArray<DescribeConfigsSynonym>(buffer, b => DescribeConfigsSynonymSerde.ReadV02(b)) ?? throw new NullReferenceException("Null not allowed for 'Synonyms'");
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
                public static void WriteV02(Stream buffer, DescribeConfigsResourceResult message)
                {
                    Encoder.WriteString(buffer, message.NameField);
                    Encoder.WriteNullableString(buffer, message.ValueField);
                    Encoder.WriteBoolean(buffer, message.ReadOnlyField);
                    Encoder.WriteInt8(buffer, message.ConfigSourceField);
                    Encoder.WriteBoolean(buffer, message.IsSensitiveField);
                    Encoder.WriteArray<DescribeConfigsSynonym>(buffer, message.SynonymsField, (b, i) => DescribeConfigsSynonymSerde.WriteV02(b, i));
                }
                public static DescribeConfigsResourceResult ReadV03(Stream buffer)
                {
                    var nameField = Decoder.ReadString(buffer);
                    var valueField = Decoder.ReadNullableString(buffer);
                    var readOnlyField = Decoder.ReadBoolean(buffer);
                    var isDefaultField = default(bool);
                    var configSourceField = Decoder.ReadInt8(buffer);
                    var isSensitiveField = Decoder.ReadBoolean(buffer);
                    var synonymsField = Decoder.ReadArray<DescribeConfigsSynonym>(buffer, b => DescribeConfigsSynonymSerde.ReadV03(b)) ?? throw new NullReferenceException("Null not allowed for 'Synonyms'");
                    var configTypeField = Decoder.ReadInt8(buffer);
                    var documentationField = Decoder.ReadNullableString(buffer);
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
                public static void WriteV03(Stream buffer, DescribeConfigsResourceResult message)
                {
                    Encoder.WriteString(buffer, message.NameField);
                    Encoder.WriteNullableString(buffer, message.ValueField);
                    Encoder.WriteBoolean(buffer, message.ReadOnlyField);
                    Encoder.WriteInt8(buffer, message.ConfigSourceField);
                    Encoder.WriteBoolean(buffer, message.IsSensitiveField);
                    Encoder.WriteArray<DescribeConfigsSynonym>(buffer, message.SynonymsField, (b, i) => DescribeConfigsSynonymSerde.WriteV03(b, i));
                    Encoder.WriteInt8(buffer, message.ConfigTypeField);
                    Encoder.WriteNullableString(buffer, message.DocumentationField);
                }
                public static DescribeConfigsResourceResult ReadV04(Stream buffer)
                {
                    var nameField = Decoder.ReadCompactString(buffer);
                    var valueField = Decoder.ReadCompactNullableString(buffer);
                    var readOnlyField = Decoder.ReadBoolean(buffer);
                    var isDefaultField = default(bool);
                    var configSourceField = Decoder.ReadInt8(buffer);
                    var isSensitiveField = Decoder.ReadBoolean(buffer);
                    var synonymsField = Decoder.ReadCompactArray<DescribeConfigsSynonym>(buffer, b => DescribeConfigsSynonymSerde.ReadV04(b)) ?? throw new NullReferenceException("Null not allowed for 'Synonyms'");
                    var configTypeField = Decoder.ReadInt8(buffer);
                    var documentationField = Decoder.ReadCompactNullableString(buffer);
                    _ = Decoder.ReadVarUInt32(buffer);
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
                public static void WriteV04(Stream buffer, DescribeConfigsResourceResult message)
                {
                    Encoder.WriteCompactString(buffer, message.NameField);
                    Encoder.WriteCompactNullableString(buffer, message.ValueField);
                    Encoder.WriteBoolean(buffer, message.ReadOnlyField);
                    Encoder.WriteInt8(buffer, message.ConfigSourceField);
                    Encoder.WriteBoolean(buffer, message.IsSensitiveField);
                    Encoder.WriteCompactArray<DescribeConfigsSynonym>(buffer, message.SynonymsField, (b, i) => DescribeConfigsSynonymSerde.WriteV04(b, i));
                    Encoder.WriteInt8(buffer, message.ConfigTypeField);
                    Encoder.WriteCompactNullableString(buffer, message.DocumentationField);
                    Encoder.WriteVarUInt32(buffer, 0);
                }
                private static class DescribeConfigsSynonymSerde
                {
                    public static DescribeConfigsSynonym ReadV01(Stream buffer)
                    {
                        var nameField = Decoder.ReadString(buffer);
                        var valueField = Decoder.ReadNullableString(buffer);
                        var sourceField = Decoder.ReadInt8(buffer);
                        return new(
                            nameField,
                            valueField,
                            sourceField
                        );
                    }
                    public static void WriteV01(Stream buffer, DescribeConfigsSynonym message)
                    {
                        Encoder.WriteString(buffer, message.NameField);
                        Encoder.WriteNullableString(buffer, message.ValueField);
                        Encoder.WriteInt8(buffer, message.SourceField);
                    }
                    public static DescribeConfigsSynonym ReadV02(Stream buffer)
                    {
                        var nameField = Decoder.ReadString(buffer);
                        var valueField = Decoder.ReadNullableString(buffer);
                        var sourceField = Decoder.ReadInt8(buffer);
                        return new(
                            nameField,
                            valueField,
                            sourceField
                        );
                    }
                    public static void WriteV02(Stream buffer, DescribeConfigsSynonym message)
                    {
                        Encoder.WriteString(buffer, message.NameField);
                        Encoder.WriteNullableString(buffer, message.ValueField);
                        Encoder.WriteInt8(buffer, message.SourceField);
                    }
                    public static DescribeConfigsSynonym ReadV03(Stream buffer)
                    {
                        var nameField = Decoder.ReadString(buffer);
                        var valueField = Decoder.ReadNullableString(buffer);
                        var sourceField = Decoder.ReadInt8(buffer);
                        return new(
                            nameField,
                            valueField,
                            sourceField
                        );
                    }
                    public static void WriteV03(Stream buffer, DescribeConfigsSynonym message)
                    {
                        Encoder.WriteString(buffer, message.NameField);
                        Encoder.WriteNullableString(buffer, message.ValueField);
                        Encoder.WriteInt8(buffer, message.SourceField);
                    }
                    public static DescribeConfigsSynonym ReadV04(Stream buffer)
                    {
                        var nameField = Decoder.ReadCompactString(buffer);
                        var valueField = Decoder.ReadCompactNullableString(buffer);
                        var sourceField = Decoder.ReadInt8(buffer);
                        _ = Decoder.ReadVarUInt32(buffer);
                        return new(
                            nameField,
                            valueField,
                            sourceField
                        );
                    }
                    public static void WriteV04(Stream buffer, DescribeConfigsSynonym message)
                    {
                        Encoder.WriteCompactString(buffer, message.NameField);
                        Encoder.WriteCompactNullableString(buffer, message.ValueField);
                        Encoder.WriteInt8(buffer, message.SourceField);
                        Encoder.WriteVarUInt32(buffer, 0);
                    }
                }
            }
        }
    }
}