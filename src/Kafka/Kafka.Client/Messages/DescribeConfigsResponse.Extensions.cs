using System.CodeDom.Compiler;
using Kafka.Common.Encoding;
using System.Collections.Immutable;
using DescribeConfigsSynonym = Kafka.Client.Messages.DescribeConfigsResponse.DescribeConfigsResult.DescribeConfigsResourceResult.DescribeConfigsSynonym;
using DescribeConfigsResult = Kafka.Client.Messages.DescribeConfigsResponse.DescribeConfigsResult;
using DescribeConfigsResourceResult = Kafka.Client.Messages.DescribeConfigsResponse.DescribeConfigsResult.DescribeConfigsResourceResult;

namespace Kafka.Client.Messages
{
    [GeneratedCode("kgen", "1.0.0.0")]
    public static class DescribeConfigsResponseSerde
    {
        private static readonly DecodeDelegate<DescribeConfigsResponse>[] READ_VERSIONS = {
            ReadV00,
            ReadV01,
            ReadV02,
            ReadV03,
            ReadV04,
        };
        private static readonly EncodeDelegate<DescribeConfigsResponse>[] WRITE_VERSIONS = {
            WriteV00,
            WriteV01,
            WriteV02,
            WriteV03,
            WriteV04,
        };
        public static DescribeConfigsResponse Read(byte[] buffer, ref int index, short version) =>
            READ_VERSIONS[version](buffer, ref index)
        ;
        public static int Write(byte[] buffer, int index, DescribeConfigsResponse message, short version) =>
            WRITE_VERSIONS[version](buffer, index, message)
        ;
        private static DescribeConfigsResponse ReadV00(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var resultsField = Decoder.ReadArray<DescribeConfigsResult>(buffer, ref index, DescribeConfigsResultSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static int WriteV00(byte[] buffer, int index, DescribeConfigsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<DescribeConfigsResult>(buffer, index, message.ResultsField, DescribeConfigsResultSerde.WriteV00);
            return index;
        }
        private static DescribeConfigsResponse ReadV01(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var resultsField = Decoder.ReadArray<DescribeConfigsResult>(buffer, ref index, DescribeConfigsResultSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static int WriteV01(byte[] buffer, int index, DescribeConfigsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<DescribeConfigsResult>(buffer, index, message.ResultsField, DescribeConfigsResultSerde.WriteV01);
            return index;
        }
        private static DescribeConfigsResponse ReadV02(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var resultsField = Decoder.ReadArray<DescribeConfigsResult>(buffer, ref index, DescribeConfigsResultSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static int WriteV02(byte[] buffer, int index, DescribeConfigsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<DescribeConfigsResult>(buffer, index, message.ResultsField, DescribeConfigsResultSerde.WriteV02);
            return index;
        }
        private static DescribeConfigsResponse ReadV03(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var resultsField = Decoder.ReadArray<DescribeConfigsResult>(buffer, ref index, DescribeConfigsResultSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static int WriteV03(byte[] buffer, int index, DescribeConfigsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteArray<DescribeConfigsResult>(buffer, index, message.ResultsField, DescribeConfigsResultSerde.WriteV03);
            return index;
        }
        private static DescribeConfigsResponse ReadV04(byte[] buffer, ref int index)
        {
            var throttleTimeMsField = Decoder.ReadInt32(buffer, ref index);
            var resultsField = Decoder.ReadCompactArray<DescribeConfigsResult>(buffer, ref index, DescribeConfigsResultSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'Results'");
            _ = Decoder.ReadVarUInt32(buffer, ref index);
            return new(
                throttleTimeMsField,
                resultsField
            );
        }
        private static int WriteV04(byte[] buffer, int index, DescribeConfigsResponse message)
        {
            index = Encoder.WriteInt32(buffer, index, message.ThrottleTimeMsField);
            index = Encoder.WriteCompactArray<DescribeConfigsResult>(buffer, index, message.ResultsField, DescribeConfigsResultSerde.WriteV04);
            index = Encoder.WriteVarUInt32(buffer, index, 0);
            return index;
        }
        private static class DescribeConfigsResultSerde
        {
            public static DescribeConfigsResult ReadV00(byte[] buffer, ref int index)
            {
                var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                var ErrorMessageField = Decoder.ReadNullableString(buffer, ref index);
                var ResourceTypeField = Decoder.ReadInt8(buffer, ref index);
                var ResourceNameField = Decoder.ReadString(buffer, ref index);
                var ConfigsField = Decoder.ReadArray<DescribeConfigsResourceResult>(buffer, ref index, DescribeConfigsResourceResultSerde.ReadV00) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                return new(
                    ErrorCodeField,
                    ErrorMessageField,
                    ResourceTypeField,
                    ResourceNameField,
                    ConfigsField
                );
            }
            public static int WriteV00(byte[] buffer, int index, DescribeConfigsResult message)
            {
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
                index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
                index = Encoder.WriteString(buffer, index, message.ResourceNameField);
                index = Encoder.WriteArray<DescribeConfigsResourceResult>(buffer, index, message.ConfigsField, DescribeConfigsResourceResultSerde.WriteV00);
                return index;
            }
            public static DescribeConfigsResult ReadV01(byte[] buffer, ref int index)
            {
                var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                var ErrorMessageField = Decoder.ReadNullableString(buffer, ref index);
                var ResourceTypeField = Decoder.ReadInt8(buffer, ref index);
                var ResourceNameField = Decoder.ReadString(buffer, ref index);
                var ConfigsField = Decoder.ReadArray<DescribeConfigsResourceResult>(buffer, ref index, DescribeConfigsResourceResultSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                return new(
                    ErrorCodeField,
                    ErrorMessageField,
                    ResourceTypeField,
                    ResourceNameField,
                    ConfigsField
                );
            }
            public static int WriteV01(byte[] buffer, int index, DescribeConfigsResult message)
            {
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
                index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
                index = Encoder.WriteString(buffer, index, message.ResourceNameField);
                index = Encoder.WriteArray<DescribeConfigsResourceResult>(buffer, index, message.ConfigsField, DescribeConfigsResourceResultSerde.WriteV01);
                return index;
            }
            public static DescribeConfigsResult ReadV02(byte[] buffer, ref int index)
            {
                var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                var ErrorMessageField = Decoder.ReadNullableString(buffer, ref index);
                var ResourceTypeField = Decoder.ReadInt8(buffer, ref index);
                var ResourceNameField = Decoder.ReadString(buffer, ref index);
                var ConfigsField = Decoder.ReadArray<DescribeConfigsResourceResult>(buffer, ref index, DescribeConfigsResourceResultSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                return new(
                    ErrorCodeField,
                    ErrorMessageField,
                    ResourceTypeField,
                    ResourceNameField,
                    ConfigsField
                );
            }
            public static int WriteV02(byte[] buffer, int index, DescribeConfigsResult message)
            {
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
                index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
                index = Encoder.WriteString(buffer, index, message.ResourceNameField);
                index = Encoder.WriteArray<DescribeConfigsResourceResult>(buffer, index, message.ConfigsField, DescribeConfigsResourceResultSerde.WriteV02);
                return index;
            }
            public static DescribeConfigsResult ReadV03(byte[] buffer, ref int index)
            {
                var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                var ErrorMessageField = Decoder.ReadNullableString(buffer, ref index);
                var ResourceTypeField = Decoder.ReadInt8(buffer, ref index);
                var ResourceNameField = Decoder.ReadString(buffer, ref index);
                var ConfigsField = Decoder.ReadArray<DescribeConfigsResourceResult>(buffer, ref index, DescribeConfigsResourceResultSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                return new(
                    ErrorCodeField,
                    ErrorMessageField,
                    ResourceTypeField,
                    ResourceNameField,
                    ConfigsField
                );
            }
            public static int WriteV03(byte[] buffer, int index, DescribeConfigsResult message)
            {
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteNullableString(buffer, index, message.ErrorMessageField);
                index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
                index = Encoder.WriteString(buffer, index, message.ResourceNameField);
                index = Encoder.WriteArray<DescribeConfigsResourceResult>(buffer, index, message.ConfigsField, DescribeConfigsResourceResultSerde.WriteV03);
                return index;
            }
            public static DescribeConfigsResult ReadV04(byte[] buffer, ref int index)
            {
                var ErrorCodeField = Decoder.ReadInt16(buffer, ref index);
                var ErrorMessageField = Decoder.ReadCompactNullableString(buffer, ref index);
                var ResourceTypeField = Decoder.ReadInt8(buffer, ref index);
                var ResourceNameField = Decoder.ReadCompactString(buffer, ref index);
                var ConfigsField = Decoder.ReadCompactArray<DescribeConfigsResourceResult>(buffer, ref index, DescribeConfigsResourceResultSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'Configs'");
                _ = Decoder.ReadVarUInt32(buffer, ref index);
                return new(
                    ErrorCodeField,
                    ErrorMessageField,
                    ResourceTypeField,
                    ResourceNameField,
                    ConfigsField
                );
            }
            public static int WriteV04(byte[] buffer, int index, DescribeConfigsResult message)
            {
                index = Encoder.WriteInt16(buffer, index, message.ErrorCodeField);
                index = Encoder.WriteCompactNullableString(buffer, index, message.ErrorMessageField);
                index = Encoder.WriteInt8(buffer, index, message.ResourceTypeField);
                index = Encoder.WriteCompactString(buffer, index, message.ResourceNameField);
                index = Encoder.WriteCompactArray<DescribeConfigsResourceResult>(buffer, index, message.ConfigsField, DescribeConfigsResourceResultSerde.WriteV04);
                index = Encoder.WriteVarUInt32(buffer, index, 0);
                return index;
            }
            private static class DescribeConfigsResourceResultSerde
            {
                public static DescribeConfigsResourceResult ReadV00(byte[] buffer, ref int index)
                {
                    var NameField = Decoder.ReadString(buffer, ref index);
                    var ValueField = Decoder.ReadNullableString(buffer, ref index);
                    var ReadOnlyField = Decoder.ReadBoolean(buffer, ref index);
                    var IsDefaultField = Decoder.ReadBoolean(buffer, ref index);
                    var ConfigSourceField = default(sbyte);
                    var IsSensitiveField = Decoder.ReadBoolean(buffer, ref index);
                    var SynonymsField = ImmutableArray<DescribeConfigsSynonym>.Empty;
                    var ConfigTypeField = default(sbyte);
                    var DocumentationField = default(string?);
                    return new(
                        NameField,
                        ValueField,
                        ReadOnlyField,
                        IsDefaultField,
                        ConfigSourceField,
                        IsSensitiveField,
                        SynonymsField,
                        ConfigTypeField,
                        DocumentationField
                    );
                }
                public static int WriteV00(byte[] buffer, int index, DescribeConfigsResourceResult message)
                {
                    index = Encoder.WriteString(buffer, index, message.NameField);
                    index = Encoder.WriteNullableString(buffer, index, message.ValueField);
                    index = Encoder.WriteBoolean(buffer, index, message.ReadOnlyField);
                    index = Encoder.WriteBoolean(buffer, index, message.IsDefaultField);
                    index = Encoder.WriteBoolean(buffer, index, message.IsSensitiveField);
                    return index;
                }
                public static DescribeConfigsResourceResult ReadV01(byte[] buffer, ref int index)
                {
                    var NameField = Decoder.ReadString(buffer, ref index);
                    var ValueField = Decoder.ReadNullableString(buffer, ref index);
                    var ReadOnlyField = Decoder.ReadBoolean(buffer, ref index);
                    var IsDefaultField = default(bool);
                    var ConfigSourceField = Decoder.ReadInt8(buffer, ref index);
                    var IsSensitiveField = Decoder.ReadBoolean(buffer, ref index);
                    var SynonymsField = Decoder.ReadArray<DescribeConfigsSynonym>(buffer, ref index, DescribeConfigsSynonymSerde.ReadV01) ?? throw new NullReferenceException("Null not allowed for 'Synonyms'");
                    var ConfigTypeField = default(sbyte);
                    var DocumentationField = default(string?);
                    return new(
                        NameField,
                        ValueField,
                        ReadOnlyField,
                        IsDefaultField,
                        ConfigSourceField,
                        IsSensitiveField,
                        SynonymsField,
                        ConfigTypeField,
                        DocumentationField
                    );
                }
                public static int WriteV01(byte[] buffer, int index, DescribeConfigsResourceResult message)
                {
                    index = Encoder.WriteString(buffer, index, message.NameField);
                    index = Encoder.WriteNullableString(buffer, index, message.ValueField);
                    index = Encoder.WriteBoolean(buffer, index, message.ReadOnlyField);
                    index = Encoder.WriteInt8(buffer, index, message.ConfigSourceField);
                    index = Encoder.WriteBoolean(buffer, index, message.IsSensitiveField);
                    index = Encoder.WriteArray<DescribeConfigsSynonym>(buffer, index, message.SynonymsField, DescribeConfigsSynonymSerde.WriteV01);
                    return index;
                }
                public static DescribeConfigsResourceResult ReadV02(byte[] buffer, ref int index)
                {
                    var NameField = Decoder.ReadString(buffer, ref index);
                    var ValueField = Decoder.ReadNullableString(buffer, ref index);
                    var ReadOnlyField = Decoder.ReadBoolean(buffer, ref index);
                    var IsDefaultField = default(bool);
                    var ConfigSourceField = Decoder.ReadInt8(buffer, ref index);
                    var IsSensitiveField = Decoder.ReadBoolean(buffer, ref index);
                    var SynonymsField = Decoder.ReadArray<DescribeConfigsSynonym>(buffer, ref index, DescribeConfigsSynonymSerde.ReadV02) ?? throw new NullReferenceException("Null not allowed for 'Synonyms'");
                    var ConfigTypeField = default(sbyte);
                    var DocumentationField = default(string?);
                    return new(
                        NameField,
                        ValueField,
                        ReadOnlyField,
                        IsDefaultField,
                        ConfigSourceField,
                        IsSensitiveField,
                        SynonymsField,
                        ConfigTypeField,
                        DocumentationField
                    );
                }
                public static int WriteV02(byte[] buffer, int index, DescribeConfigsResourceResult message)
                {
                    index = Encoder.WriteString(buffer, index, message.NameField);
                    index = Encoder.WriteNullableString(buffer, index, message.ValueField);
                    index = Encoder.WriteBoolean(buffer, index, message.ReadOnlyField);
                    index = Encoder.WriteInt8(buffer, index, message.ConfigSourceField);
                    index = Encoder.WriteBoolean(buffer, index, message.IsSensitiveField);
                    index = Encoder.WriteArray<DescribeConfigsSynonym>(buffer, index, message.SynonymsField, DescribeConfigsSynonymSerde.WriteV02);
                    return index;
                }
                public static DescribeConfigsResourceResult ReadV03(byte[] buffer, ref int index)
                {
                    var NameField = Decoder.ReadString(buffer, ref index);
                    var ValueField = Decoder.ReadNullableString(buffer, ref index);
                    var ReadOnlyField = Decoder.ReadBoolean(buffer, ref index);
                    var IsDefaultField = default(bool);
                    var ConfigSourceField = Decoder.ReadInt8(buffer, ref index);
                    var IsSensitiveField = Decoder.ReadBoolean(buffer, ref index);
                    var SynonymsField = Decoder.ReadArray<DescribeConfigsSynonym>(buffer, ref index, DescribeConfigsSynonymSerde.ReadV03) ?? throw new NullReferenceException("Null not allowed for 'Synonyms'");
                    var ConfigTypeField = Decoder.ReadInt8(buffer, ref index);
                    var DocumentationField = Decoder.ReadNullableString(buffer, ref index);
                    return new(
                        NameField,
                        ValueField,
                        ReadOnlyField,
                        IsDefaultField,
                        ConfigSourceField,
                        IsSensitiveField,
                        SynonymsField,
                        ConfigTypeField,
                        DocumentationField
                    );
                }
                public static int WriteV03(byte[] buffer, int index, DescribeConfigsResourceResult message)
                {
                    index = Encoder.WriteString(buffer, index, message.NameField);
                    index = Encoder.WriteNullableString(buffer, index, message.ValueField);
                    index = Encoder.WriteBoolean(buffer, index, message.ReadOnlyField);
                    index = Encoder.WriteInt8(buffer, index, message.ConfigSourceField);
                    index = Encoder.WriteBoolean(buffer, index, message.IsSensitiveField);
                    index = Encoder.WriteArray<DescribeConfigsSynonym>(buffer, index, message.SynonymsField, DescribeConfigsSynonymSerde.WriteV03);
                    index = Encoder.WriteInt8(buffer, index, message.ConfigTypeField);
                    index = Encoder.WriteNullableString(buffer, index, message.DocumentationField);
                    return index;
                }
                public static DescribeConfigsResourceResult ReadV04(byte[] buffer, ref int index)
                {
                    var NameField = Decoder.ReadCompactString(buffer, ref index);
                    var ValueField = Decoder.ReadCompactNullableString(buffer, ref index);
                    var ReadOnlyField = Decoder.ReadBoolean(buffer, ref index);
                    var IsDefaultField = default(bool);
                    var ConfigSourceField = Decoder.ReadInt8(buffer, ref index);
                    var IsSensitiveField = Decoder.ReadBoolean(buffer, ref index);
                    var SynonymsField = Decoder.ReadCompactArray<DescribeConfigsSynonym>(buffer, ref index, DescribeConfigsSynonymSerde.ReadV04) ?? throw new NullReferenceException("Null not allowed for 'Synonyms'");
                    var ConfigTypeField = Decoder.ReadInt8(buffer, ref index);
                    var DocumentationField = Decoder.ReadCompactNullableString(buffer, ref index);
                    _ = Decoder.ReadVarUInt32(buffer, ref index);
                    return new(
                        NameField,
                        ValueField,
                        ReadOnlyField,
                        IsDefaultField,
                        ConfigSourceField,
                        IsSensitiveField,
                        SynonymsField,
                        ConfigTypeField,
                        DocumentationField
                    );
                }
                public static int WriteV04(byte[] buffer, int index, DescribeConfigsResourceResult message)
                {
                    index = Encoder.WriteCompactString(buffer, index, message.NameField);
                    index = Encoder.WriteCompactNullableString(buffer, index, message.ValueField);
                    index = Encoder.WriteBoolean(buffer, index, message.ReadOnlyField);
                    index = Encoder.WriteInt8(buffer, index, message.ConfigSourceField);
                    index = Encoder.WriteBoolean(buffer, index, message.IsSensitiveField);
                    index = Encoder.WriteCompactArray<DescribeConfigsSynonym>(buffer, index, message.SynonymsField, DescribeConfigsSynonymSerde.WriteV04);
                    index = Encoder.WriteInt8(buffer, index, message.ConfigTypeField);
                    index = Encoder.WriteCompactNullableString(buffer, index, message.DocumentationField);
                    index = Encoder.WriteVarUInt32(buffer, index, 0);
                    return index;
                }
                private static class DescribeConfigsSynonymSerde
                {
                    public static DescribeConfigsSynonym ReadV01(byte[] buffer, ref int index)
                    {
                        var NameField = Decoder.ReadString(buffer, ref index);
                        var ValueField = Decoder.ReadNullableString(buffer, ref index);
                        var SourceField = Decoder.ReadInt8(buffer, ref index);
                        return new(
                            NameField,
                            ValueField,
                            SourceField
                        );
                    }
                    public static int WriteV01(byte[] buffer, int index, DescribeConfigsSynonym message)
                    {
                        index = Encoder.WriteString(buffer, index, message.NameField);
                        index = Encoder.WriteNullableString(buffer, index, message.ValueField);
                        index = Encoder.WriteInt8(buffer, index, message.SourceField);
                        return index;
                    }
                    public static DescribeConfigsSynonym ReadV02(byte[] buffer, ref int index)
                    {
                        var NameField = Decoder.ReadString(buffer, ref index);
                        var ValueField = Decoder.ReadNullableString(buffer, ref index);
                        var SourceField = Decoder.ReadInt8(buffer, ref index);
                        return new(
                            NameField,
                            ValueField,
                            SourceField
                        );
                    }
                    public static int WriteV02(byte[] buffer, int index, DescribeConfigsSynonym message)
                    {
                        index = Encoder.WriteString(buffer, index, message.NameField);
                        index = Encoder.WriteNullableString(buffer, index, message.ValueField);
                        index = Encoder.WriteInt8(buffer, index, message.SourceField);
                        return index;
                    }
                    public static DescribeConfigsSynonym ReadV03(byte[] buffer, ref int index)
                    {
                        var NameField = Decoder.ReadString(buffer, ref index);
                        var ValueField = Decoder.ReadNullableString(buffer, ref index);
                        var SourceField = Decoder.ReadInt8(buffer, ref index);
                        return new(
                            NameField,
                            ValueField,
                            SourceField
                        );
                    }
                    public static int WriteV03(byte[] buffer, int index, DescribeConfigsSynonym message)
                    {
                        index = Encoder.WriteString(buffer, index, message.NameField);
                        index = Encoder.WriteNullableString(buffer, index, message.ValueField);
                        index = Encoder.WriteInt8(buffer, index, message.SourceField);
                        return index;
                    }
                    public static DescribeConfigsSynonym ReadV04(byte[] buffer, ref int index)
                    {
                        var NameField = Decoder.ReadCompactString(buffer, ref index);
                        var ValueField = Decoder.ReadCompactNullableString(buffer, ref index);
                        var SourceField = Decoder.ReadInt8(buffer, ref index);
                        _ = Decoder.ReadVarUInt32(buffer, ref index);
                        return new(
                            NameField,
                            ValueField,
                            SourceField
                        );
                    }
                    public static int WriteV04(byte[] buffer, int index, DescribeConfigsSynonym message)
                    {
                        index = Encoder.WriteCompactString(buffer, index, message.NameField);
                        index = Encoder.WriteCompactNullableString(buffer, index, message.ValueField);
                        index = Encoder.WriteInt8(buffer, index, message.SourceField);
                        index = Encoder.WriteVarUInt32(buffer, index, 0);
                        return index;
                    }
                }
            }
        }
    }
}