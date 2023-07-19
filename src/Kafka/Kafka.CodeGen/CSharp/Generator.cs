using Kafka.CodeGen.Models;
using Kafka.CodeGen.Models.Extensions;
using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using Kafka.Common.Records;
using System;
using System.Collections.Immutable;

namespace Kafka.CodeGen.CSharp
{
    public static class Generator
    {
        private const string TAG_BUFFER = "TaggedFields";

        public static async ValueTask WriteModel(
            TextWriter writer,
            MessageDefinition message,
            string messageNamespace
        )
        {
            TestValidVersion(message.ValidVersions);
            var typeLookup = CreateTypeLookup(message);
            var typeFlags = GetUsings(message, typeLookup);

            var usings = new List<string>();
            if (message.FlexibleVersions.Some())
                usings.Add("Kafka.Common.Model");
            if (message.FlexibleVersions.Some() || typeFlags.HasFlag(UsingsFlags.Array))
                usings.Add("System.Collections.Immutable");
            if (typeFlags.HasFlag(UsingsFlags.Record))
                usings.Add("Kafka.Common.Records");
            foreach (var type in typeLookup)
                usings.Add($"{type.Key} = {messageNamespace}.{type.Value.ParentName}");

            await WriteNamespace(
                messageNamespace,
                writer,
                message,
                typeLookup,
                usings,
                (w, m, t) => WriteMessageRecord(w, m, "    ")
            );
            await writer.FlushAsync();
        }

        public static async ValueTask WriteSerde(
            TextWriter writer,
            MessageDefinition message,
            string messageNamespace,
            string messageSerdeNamespace
        )
        {
            TestValidVersion(message.ValidVersions);
            var typeLookup = CreateTypeLookup(message);
            var typeFlags = GetUsings(message, typeLookup);

            var usings = new List<string>
            {
                typeof(BinaryEncoder).Namespace ?? "",
                "Kafka.Common.Model",
                "Kafka.Common.Model.Extensions",
                "Kafka.Common.Protocol",
                "Kafka.Common.Exceptions",
                "Version = Kafka.Common.Model.Version"
            };
            if (typeFlags.HasFlag(UsingsFlags.Record))
                usings.Add("Kafka.Common.Records");
            if (message.FlexibleVersions.Some() || typeFlags.HasFlag(UsingsFlags.Array))
                usings.Add("System.Collections.Immutable");
            foreach (var type in typeLookup)
                usings.Add($"{type.Key} = {messageNamespace}.{type.Value.ParentName}");

            await WriteNamespace(
                messageSerdeNamespace,
                writer,
                message,
                typeLookup,
                usings,
                (w, m, t) => WriteMessageRecordExtension(w, m, VersionRange.All, VersionRange.All, "    ")
            );
            await writer.FlushAsync();
        }

        private static async ValueTask WriteNamespace(
            string targetNamespace,
            TextWriter writer,
            MessageDefinition message,
            IReadOnlyDictionary<string, QualifiedStruct> typeLookup,
            IEnumerable<string> namespaces,
            Func<TextWriter, MessageDefinition, IReadOnlyDictionary<string, QualifiedStruct>, ValueTask> classWriter
        )
        {
            foreach (var ns in namespaces.Append("System.CodeDom.Compiler").Order())
                await writer.WriteLineAsync($"using {ns};");
            await writer.WriteLineAsync();
            await writer.WriteLineAsync($"namespace {targetNamespace}");
            await writer.WriteLineAsync($"{{");
            await classWriter(
                writer,
                message,
                typeLookup
            );
            await writer.WriteAsync($"}}");
            await writer.FlushAsync();
        }

        private static async ValueTask WriteMessageRecord(
            TextWriter writer,
            MessageDefinition message,
            string indent
        )
        {
            var assemblyName = typeof(Generator).Assembly.GetName();
            await WriteSummary(writer, indent, message);
            await writer.WriteLineAsync($"{indent}[GeneratedCode(\"{assemblyName.Name}\", \"{assemblyName.Version}\")]");
            await writer.WriteLineAsync($"{indent}public sealed record {message.Name} (");
            await WriteFields(
                writer,
                message.Fields,
                $"{indent}    "
            );
            await writer.WriteAsync($"{indent})");
            if (message.Name.EndsWith($"Request"))
                await writer.WriteLineAsync($" : {nameof(IRequest)}");
            else if (message.Name.EndsWith("Response"))
                await writer.WriteLineAsync($" : {nameof(IResponse)}");
            else if (message.Name == "RequestHeader")
                await writer.WriteLineAsync($" : {nameof(IRequestHeader)}");
            else if (message.Name.EndsWith("ResponseHeader"))
                await writer.WriteLineAsync($" : {nameof(IResponseHeader)}");
            else
                await writer.WriteLineAsync();
            await writer.WriteLineAsync($"{indent}{{");
            await WriteDefaultEmptyValue(
                writer,
                $"{indent}    ",
                message.Name,
                message.Fields
            );
            foreach (var @struct in message.Structs)
                await WriteMessageRecord(
                    writer,
                    @struct.Value,
                    $"{indent}    "
                );
            await writer.WriteLineAsync($"{indent}}};");
        }

        private static async ValueTask WriteDefaultEmptyValue(
            TextWriter writer,
            string indent,
            string name,
            IEnumerable<Field> fields
        )
        {
            await writer.WriteLineAsync($"{indent}public static {name} Empty {{ get; }} = new(");
            var value = DefaultValue(fields.First());
            await writer.WriteAsync($"{indent}    {value}");
            foreach (var field in fields.Skip(1))
            {
                value = DefaultValue(field);
                await writer.WriteLineAsync(",");
                await writer.WriteAsync($"{indent}    {value}");
            }
            await writer.WriteLineAsync($",");
            await writer.WriteLineAsync($"{indent}    ImmutableArray<{nameof(TaggedField)}>.Empty");
            await writer.WriteLineAsync();
            await writer.WriteLineAsync($"{indent});");
        }

        private static async ValueTask WriteFields(
            TextWriter writer,
            IEnumerable<Field> fields,
            string indent
        )
        {
            await WriteFieldProperty(writer, indent, fields.First());
            foreach (var field in fields.Skip(1))
            {
                await writer.WriteLineAsync($",");
                await WriteFieldProperty(writer, indent, field);
            }
            await writer.WriteLineAsync($",");
            await writer.WriteLineAsync($"{indent}ImmutableArray<{nameof(TaggedField)}> {TAG_BUFFER}");
        }

        private static async ValueTask WriteRequestSerde(
            TextWriter writer,
            MessageDefinition messageDefinition,
            VersionRange versions,
            VersionRange flexibleVersions,
            string indent
        )
        {
            var serdeModifier = "public";
            if (messageDefinition is ApiRequestMessage || messageDefinition is ApiResponseMessage)
            {
                var header = messageDefinition is ApiRequestMessage ? "RequestHeader" : "ResponseHeader";
                serdeModifier = "private";
                await writer.WriteLineAsync($"        private static readonly {nameof(ApiKey)} API_KEY = new({messageDefinition.ApiKey.Value});");
                await writer.WriteLineAsync($"        private static readonly {nameof(VersionRange)} API_VERSIONS = new({messageDefinition.ValidVersions.Min.Value}, {messageDefinition.ValidVersions.Max.Value});");
                await writer.WriteLineAsync($"        private static readonly {nameof(VersionRange)} FLEXBILE_VERSIONS = new ({messageDefinition.FlexibleVersions.Min.Value}, {messageDefinition.FlexibleVersions.Max.Value});");
                await writer.WriteLineAsync($"        public static IEncoder<{header}, {messageDefinition.Name}> CreateEncoder(Version apiVersion)");
                await writer.WriteLineAsync($"        {{");
                await writer.WriteLineAsync($"            apiVersion = apiVersion <= {messageDefinition.ValidVersions.Max.Value} ? apiVersion : new Version({messageDefinition.ValidVersions.Max.Value});");
                await writer.WriteLineAsync($"            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);");
                await writer.WriteLineAsync($"            var headerEncoder = {header}Serde.CreateEncoder(flexible);");
                await writer.WriteLineAsync($"            switch (apiVersion)");
                await writer.WriteLineAsync($"            {{");
                foreach (var version in messageDefinition.ValidVersions.Enumerate())
                {
                    await writer.WriteLineAsync($"                case {version}:");
                    await writer.WriteLineAsync($"                    return new {nameof(Encoder)}<{header}, {messageDefinition.Name}>(API_KEY, {version}, flexible, headerEncoder, WriteV{version});");
                }
                await writer.WriteLineAsync($"                default:");
                await writer.WriteLineAsync($"                    throw new UnsupportedVersionException();");
                await writer.WriteLineAsync($"            }}");
                await writer.WriteLineAsync($"        }}");
                await writer.WriteLineAsync($"        public static IDecoder<{header}, {messageDefinition.Name}> CreateDecoder(Version apiVersion)");
                await writer.WriteLineAsync($"        {{");
                await writer.WriteLineAsync($"            apiVersion = apiVersion <= {messageDefinition.ValidVersions.Max.Value} ? apiVersion : new Version({messageDefinition.ValidVersions.Max.Value});");
                await writer.WriteLineAsync($"            var flexible = FLEXBILE_VERSIONS.Includes(apiVersion);");
                await writer.WriteLineAsync($"            var headerDecoder = {header}Serde.CreateDecoder(flexible);");
                await writer.WriteLineAsync($"            switch (apiVersion)");
                await writer.WriteLineAsync($"            {{");
                foreach (var version in messageDefinition.ValidVersions.Enumerate())
                {
                    await writer.WriteLineAsync($"                case {version}:");
                    await writer.WriteLineAsync($"                    return new {nameof(Decoder)}<{header}, {messageDefinition.Name}>(API_KEY, {version}, flexible, headerDecoder, ReadV{version});");
                }
                await writer.WriteLineAsync($"                default:");
                await writer.WriteLineAsync($"                    throw new UnsupportedVersionException();");
                await writer.WriteLineAsync($"            }}");
                await writer.WriteLineAsync($"        }}");
            }
            if (messageDefinition is HeaderMessage headerMessage)
            {
                serdeModifier = "private";
                if (headerMessage.Name.Contains("Request"))
                {
                    await writer.WriteLineAsync($"        public static EncodeDelegate<{headerMessage.Name}> CreateEncoder(bool flexible) =>");
                    await writer.WriteLineAsync($"            flexible ? WriteV2 : WriteV1");
                    await writer.WriteLineAsync($"        ;");
                    await writer.WriteLineAsync($"        public static DecodeDelegate<{headerMessage.Name}> CreateDecoder(bool flexible) =>");
                    await writer.WriteLineAsync($"            flexible ? ReadV2 : ReadV1");
                    await writer.WriteLineAsync($"        ;");
                }
                else
                {
                    await writer.WriteLineAsync($"        public static EncodeDelegate<{headerMessage.Name}> CreateEncoder(bool flexible) =>");
                    await writer.WriteLineAsync($"            flexible ? WriteV1 : WriteV0");
                    await writer.WriteLineAsync($"        ;");
                    await writer.WriteLineAsync($"        public static DecodeDelegate<{headerMessage.Name}> CreateDecoder(bool flexible) =>");
                    await writer.WriteLineAsync($"            flexible ? ReadV1 : ReadV0");
                    await writer.WriteLineAsync($"        ;");
                }
            }
            foreach (var version in versions.Enumerate())
            {
                var flexible = flexibleVersions.Includes(version);
                var variableList = new List<string>();
                await writer.WriteLineAsync($"{indent}{serdeModifier} static int WriteV{version}(byte[] buffer, int index, {messageDefinition.Name} message)");
                await writer.WriteLineAsync($"{indent}{{");
                await EncodeUntaggedFields(writer, indent, messageDefinition.Fields, flexible, version, "message");
                await EncodeTaggedFields(writer, indent, "message", messageDefinition, version);
                await writer.WriteLineAsync($"{indent}    return index;");
                await writer.WriteLineAsync($"{indent}}}");
                await writer.WriteLineAsync($"{indent}{serdeModifier} static (int Offset, {messageDefinition.Name} Value) ReadV{version}(byte[] buffer, int index)");
                await writer.WriteLineAsync($"{indent}{{");
                await DecodeFieldDeclare(writer, $"{indent}    ", messageDefinition);
                await DecodeFields(writer, $"{indent}    ", messageDefinition.Fields, flexible, version);
                await DecodeTaggedFields(writer, indent, messageDefinition.Fields, flexible, version);
                await DecodeReturnValue(writer, $"{indent}    ", messageDefinition);
                await writer.WriteLineAsync($"{indent}}}");


                if (messageDefinition is HeaderMessage)
                {
                    await writer.WriteLineAsync($"{indent}{serdeModifier} static int WriteUntaggedV{version}(byte[] buffer, int index, {messageDefinition.Name} message)");
                    await writer.WriteLineAsync($"{indent}{{");
                    foreach (var field in messageDefinition.Fields.Where(f => f.Properties.Versions.Includes(version)))
                        await EncodeField(writer, $"{indent}    ", flexible, field, version, $"message.{FieldPropertyNamify(field)}");
                    await writer.WriteLineAsync($"{indent}    return index;");
                    await writer.WriteLineAsync($"{indent}}}");
                    variableList.Clear();
                    await writer.WriteLineAsync($"{indent}{serdeModifier} static (int Offset, {messageDefinition.Name} Value) ReadUntaggedV{version}(byte[] buffer, int index)");
                    await writer.WriteLineAsync($"{indent}{{");
                    await DecodeFieldDeclare(writer, $"{indent}    ", messageDefinition);
                    await DecodeFields(writer, $"{indent}    ", messageDefinition.Fields, flexible, version);
                    await DecodeReturnValue(writer, $"{indent}    ", messageDefinition);
                    await writer.WriteLineAsync($"{indent}}}");
                }
            }
            foreach (var @struct in messageDefinition.Structs.Values)
                await WriteMessageRecordExtension(writer, @struct, versions, flexibleVersions, indent);
        }

        private static async Task DecodeFieldDeclare(TextWriter writer, string indent, MessageDefinition messageDefinition)
        {
            foreach (var field in messageDefinition.Fields)
            {
                var variable = FieldVariableNamify(field);
                var defaultValue = DefaultValue(field);
                await writer.WriteAsync(indent);
                await writer.WriteAsync("var ");
                await writer.WriteAsync(variable);
                await writer.WriteAsync(" = ");
                await writer.WriteAsync(defaultValue);
                await writer.WriteLineAsync(";");
            }
            await writer.WriteLineAsync($"{indent}var taggedFields = ImmutableArray<{nameof(TaggedField)}>.Empty;");
        }

        private static async Task DecodeFields(
            TextWriter writer,
            string indent,
            IEnumerable<Field> fields,
            bool flexible,
            short version
        )
        {
            var untaggedFields = GetUntaggedFields(fields, version);
            foreach (var untaggedField in untaggedFields)
            {
                var variable = FieldVariableNamify(untaggedField);
                await DecodeField(writer, indent, flexible, untaggedField, version, variable);
            }
        }

        private static async Task DecodeReturnValue(TextWriter writer, string indent, MessageDefinition messageDefinition)
        {
            await writer.WriteLineAsync($"{indent}return (index, new(");
            foreach (var field in messageDefinition.Fields)
            {
                var variable = FieldVariableNamify(field);
                await writer.WriteLineAsync($"{indent}    {variable},");
            }
            await writer.WriteLineAsync($"{indent}    taggedFields");
            await writer.WriteLineAsync($"{indent}));");
        }

        private static async Task EncodeUntaggedFields(
            TextWriter writer,
            string indent,
            IEnumerable<Field> fields,
            bool flexible,
            short version,
            string referenceName
        )
        {
            var untaggedFields = GetUntaggedFields(fields, version);
            foreach (var field in untaggedFields)
            {
                await EncodeField(writer, $"{indent}    ", flexible, field, version, $"{referenceName}.{FieldPropertyNamify(field)}");
            }
        }

        private static async Task EncodeTaggedFields(
            TextWriter writer,
            string indent,
            string referenceName,
            MessageDefinition messageDefinition,
            short version
        )
        {
            if (!IsFlexible(messageDefinition, version))
                return;
            var taggedFields = GetKnownTaggedFields(messageDefinition.Fields, version);
            var requiredTaggedFieldsCount = taggedFields.Where(r => !IsNullable(r, version)).Count();
            var optionalTaggedFields = taggedFields.Where(r => IsNullable(r, version)).ToImmutableArray();
            var startTag = -1;
            if (taggedFields.Any())
                startTag = taggedFields.Max(r => r.Properties.Tag);
            await writer.WriteLineAsync($"{indent}    var taggedFieldsCount = {requiredTaggedFieldsCount}u;");
            await writer.WriteLineAsync($"{indent}    var previousTagged = {startTag};");
            foreach (var optionalTaggedField in optionalTaggedFields)
            {
                var propertyName = FieldPropertyNamify(optionalTaggedField);
                await writer.WriteLineAsync($"{indent}    if({referenceName}.{propertyName} != null)");
                await writer.WriteLineAsync($"{indent}        taggedFieldsCount++;");
            }
            await writer.WriteLineAsync($"{indent}    taggedFieldsCount += (uint){referenceName}.{TAG_BUFFER}.Length;");
            await writer.WriteLineAsync($"{indent}    index = {nameof(BinaryEncoder)}.{nameof(BinaryEncoder.WriteVarUInt32)}(buffer, index, taggedFieldsCount);");
            foreach (var taggedField in taggedFields.OrderBy(r => r.Properties.Tag))
            {
                var propertyName = FieldPropertyNamify(taggedField);
                if (IsNullable(taggedField))
                    await writer.WriteLineAsync($"{indent}    if({referenceName}.{propertyName} != null)");
                await writer.WriteLineAsync($"{indent}    {{");
                await writer.WriteLineAsync($"{indent}        index = {nameof(BinaryEncoder)}.{nameof(BinaryEncoder.WriteVarInt32)}(buffer, index, {taggedField.Properties.Tag});");
                await EncodeField(writer, $"{indent}        ", true, taggedField, version, $"{referenceName}.{propertyName}");
                await writer.WriteLineAsync($"{indent}    }}");
            }
            await writer.WriteLineAsync($"{indent}    foreach(var taggedField in {referenceName}.{TAG_BUFFER})");
            await writer.WriteLineAsync($"{indent}    {{");
            await writer.WriteLineAsync($"{indent}        if(taggedField.{nameof(TaggedField.Tag)} <= previousTagged)");
            await writer.WriteLineAsync($"{indent}            throw new {nameof(InvalidOperationException)}($\"Reserved or out of order tag: {{taggedField.{nameof(TaggedField.Tag)}}} - Reserved Range: {startTag}\");");
            await writer.WriteLineAsync($"{indent}        index = {nameof(BinaryEncoder)}.{nameof(BinaryEncoder.WriteVarInt32)}(buffer, index, taggedField.{nameof(TaggedField.Tag)});");
            await writer.WriteLineAsync($"{indent}        index = {nameof(BinaryEncoder)}.{nameof(BinaryEncoder.WriteCompactBytes)}(buffer, index, taggedField.{nameof(TaggedField.Value)});");
            await writer.WriteLineAsync($"{indent}    }}");
        }

        private static async Task DecodeTaggedFields(
            TextWriter writer,
            string indent,
            IEnumerable<Field> fields,
            bool flexible,
            short version
        )
        {
            if (!flexible)
                return;
            var taggedFields = GetKnownTaggedFields(fields, version);

            await writer.WriteLineAsync($"{indent}    (index, var taggedFieldsCount) = {nameof(BinaryDecoder)}.{nameof(BinaryDecoder.ReadVarUInt32)}(buffer, index);");
            await writer.WriteLineAsync($"{indent}    if(taggedFieldsCount > 0)");
            await writer.WriteLineAsync($"{indent}    {{");
            await writer.WriteLineAsync($"{indent}        var taggedFieldsBuilder = ImmutableArray.CreateBuilder<{nameof(TaggedField)}>();");
            await writer.WriteLineAsync($"{indent}        while (taggedFieldsCount > 0)");
            await writer.WriteLineAsync($"{indent}        {{");
            await writer.WriteLineAsync($"{indent}            (index, var tag) = {nameof(BinaryDecoder)}.{nameof(BinaryDecoder.ReadVarInt32)}(buffer, index);");
            if (taggedFields.Length > 0)
                await DecodeTaggedKnown(writer, $"{indent}            ", taggedFields, version);
            else
                await DecodeTaggedUnknown(writer, $"{indent}            ");
            await writer.WriteLineAsync($"{indent}            taggedFieldsCount--;");
            await writer.WriteLineAsync($"{indent}        }}");
            await writer.WriteLineAsync($"{indent}    }}");
        }

        private static async Task DecodeTaggedKnown(
            TextWriter writer,
            string indent,
            IEnumerable<Field> taggedFields,
            short version
        )
        {
            await writer.WriteLineAsync($"{indent}switch (tag)");
            await writer.WriteLineAsync($"{indent}{{");
            foreach (var taggedField in taggedFields.OrderBy(r => r.Properties.Tag))
            {
                var variable = FieldVariableNamify(taggedField);
                await writer.WriteLineAsync($"{indent}    case {taggedField.Properties.Tag}:");
                await DecodeField(writer, $"{indent}        ", true, taggedField, version, variable);
                await writer.WriteLineAsync($"{indent}        break;");
            }
            await writer.WriteLineAsync($"{indent}    default:");
            await DecodeTaggedUnknown(writer, $"{indent}        ");
            await writer.WriteLineAsync($"{indent}    break;");
            await writer.WriteLineAsync($"{indent}}}");
        }

        private static async Task DecodeTaggedUnknown(
            TextWriter writer,
            string indent
        )
        {
            await writer.WriteLineAsync($"{indent}(index, var bytes) = {nameof(BinaryDecoder)}.{nameof(BinaryDecoder.ReadCompactBytes)}(buffer, index);");
            await writer.WriteLineAsync($"{indent}taggedFieldsBuilder.Add(new(tag, bytes));");
        }

        private static ImmutableArray<Field> GetKnownTaggedFields(
            IEnumerable<Field> fields,
            short version
        ) =>
            fields
                .Where(f => f.Properties.Versions.Includes(version) &&
                            f.Properties.TaggedVersions.Includes(version))
                .ToImmutableArray()
            ;

        private static ImmutableArray<Field> GetUntaggedFields(
            IEnumerable<Field> fields,
            short version
        ) =>
            fields
                .Where(f => f.Properties.Versions.Includes(version) &&
                            !f.Properties.TaggedVersions.Includes(version))
                .ToImmutableArray()
            ;

        private static bool IsFlexible(
            MessageDefinition messageDefinition,
            short version
        ) =>
            messageDefinition.FlexibleVersions.Includes(version)
        ;

        private static bool IsNullable(Field field) =>
            field.Properties.Ignorable && field.Properties.NullableVersions.Some()
        ;

        private static bool IsNullable(Field field, short version) =>
            field.Properties.Ignorable && field.Properties.NullableVersions.Includes(version)
        ;


        private static async ValueTask WriteMessageRecordExtension(
            TextWriter writer,
            MessageDefinition message,
            VersionRange versions,
            VersionRange flexibleVersions,
            string indent
        )
        {
            versions = versions.Intersect(message.ValidVersions);
            flexibleVersions = flexibleVersions.Intersect(message.FlexibleVersions);
            var classModifier = "public";
            if (message is StructDefinition)
                classModifier = "private";
            var assemblyName = typeof(Generator).Assembly.GetName();
            await writer.WriteLineAsync($"{indent}[GeneratedCode(\"{assemblyName.Name}\", \"{assemblyName.Version}\")]");
            await writer.WriteLineAsync($"{indent}{classModifier} static class {message.Name}Serde");
            await writer.WriteLineAsync($"{indent}{{");
            await WriteRequestSerde(writer, message, versions, flexibleVersions, $"{indent}    ");
            await writer.WriteLineAsync($"{indent}}}");
        }

        private static async ValueTask WriteSummary(
            TextWriter writer,
            string indent,
            MessageDefinition message
        )
        {
            await writer.WriteLineAsync($"{indent}/// <summary>");
            await WriteFieldDocumentations(writer, indent, message.Fields);
            await writer.WriteLineAsync($"{indent}/// </summary>");
        }

        private static async ValueTask WriteSummary(
            TextWriter writer,
            string indent,
            StructDefinition @struct
        )
        {
            await writer.WriteLineAsync($"{indent}/// <summary>");
            await WriteFieldDocumentations(writer, indent, @struct.Fields);
            await writer.WriteLineAsync($"{indent}/// </summary>");
        }

        private static async ValueTask WriteFieldDocumentations(
            TextWriter writer,
            string indent,
            IEnumerable<Field> fields
        )
        {
            foreach (var field in fields)
            {
                await writer.WriteAsync(indent);
                await writer.WriteAsync(@"/// <param name=""");
                await writer.WriteAsync(FieldPropertyNamify(field));
                await writer.WriteAsync(@""">");
                await writer.WriteAsync(field.Properties.About);
                await writer.WriteAsync(@"</param>");
                await writer.WriteLineAsync();
            }
        }

        private static bool TestValidVersion(
            VersionRange version
        ) =>
            TestValidVersion(
                version,
                VersionRange.All
            )
        ;

        private static bool TestValidVersion(
            VersionRange version,
            VersionRange limit
        ) =>
            version.Min >= limit.Min &&
            version.Max <= limit.Max
        ;

        private static async ValueTask WriteFieldProperty(
            TextWriter writer,
            string indent,
            Field field
        )
        {
            await writer.WriteAsync(indent);
            await writer.WriteAsync(FieldTypify(field));
            await writer.WriteAsync(' ');
            await writer.WriteAsync(FieldPropertyNamify(field));
        }

        private static string QualifyType(
            FieldType fieldType
        ) =>
            fieldType switch
            {
                StructFieldType f => $"{f.Name}",
                ArrayFieldType f => $"ImmutableArray<{QualifyType(f.ItemType)}>",
                RecordsFieldType => "ImmutableArray<IRecords>",
                FieldType f => f.ToSystemType()
            }
        ;

        private static async ValueTask EncodeField(
            TextWriter writer,
            string indent,
            bool flexible,
            Field field,
            short version,
            string dereference
        )
        {
            await EncodeIfNullThrow(
                writer,
                indent,
                field,
                version,
                dereference
            );
            await writer.WriteAsync(indent);
            await writer.WriteAsync("index = ");
            var flexibleField = flexible && field.Properties.FlexibleVersions.Includes(version);
            switch (field.Type)
            {
                case ArrayFieldType a:
                    await EncodeArrayField(writer, indent, flexibleField, field.Properties, a, version, dereference);
                    break;
                case StructFieldType s:
                    await EncodeStructField(writer, s, version, dereference);
                    break;
                case RecordsFieldType r:
                    await EncodeRecordsField(writer, indent, flexibleField, field.Properties, r, version, dereference);
                    break;
                case ScalarFieldType f:
                    await EncodeScalarField(writer, indent, flexibleField, field.Properties, f, version, dereference);
                    break;
                default:
                    throw new InvalidOperationException($"Unsupported field type '{field.Type.GetType().Name}'");
            }
        }

        private static async ValueTask EncodeIfNullThrow(
            TextWriter writer,
            string indent,
            Field field,
            short version,
            string dereference
        )
        {
            // If no field version is nullable -> defer to developer to pay attention to compiler warnings.
            if (field.Properties.NullableVersions.None())
                return;
            // If the current version is nullable -> generated code should allow null values.
            if (field.Properties.NullableVersions.Includes(version))
                return;
            await writer.WriteLineAsync($"{indent}if ({dereference} == null)");
            await writer.WriteLineAsync($"{indent}    throw new {nameof(ArgumentNullException)}(nameof({dereference}));");
        }

        private static async ValueTask EncodeStructField(
            TextWriter writer,
            StructFieldType fieldType,
            short version,
            string dereference
        )
        {
            await writer.WriteLineAsync($"{fieldType.Name}Serde.WriteV{version}(buffer, index, {dereference});");
        }

        private static async ValueTask EncodeRecordsField(
            TextWriter writer,
            string indent,
            bool flexible,
            FieldProperties fieldProperties,
            RecordsFieldType fieldType,
            short version,
            string dereference
        )
        {
            if (flexible)
                await writer.WriteLineAsync($"{nameof(BinaryEncoder)}.{nameof(BinaryEncoder.WriteCompactRecords)}(buffer, index, {dereference});");
            else
                await writer.WriteLineAsync($"{nameof(BinaryEncoder)}.{nameof(BinaryEncoder.WriteRecords)}(buffer, index, {dereference});");
        }

        private static async ValueTask EncodeScalarField(
            TextWriter writer,
            string indent,
            bool flexible,
            FieldProperties fieldProperties,
            ScalarFieldType fieldType,
            short version,
            string dereference
        )
        {
            var scalarWrite = ScalarFieldToEncode(fieldType, fieldProperties.NullableVersions.Includes(version), flexible);
            await writer.WriteLineAsync($"{nameof(BinaryEncoder)}.{scalarWrite}(buffer, index, {dereference});");
        }

        private static async ValueTask EncodeArrayField(
            TextWriter writer,
            string indent,
            bool flexible,
            FieldProperties fieldProperties,
            ArrayFieldType fieldType,
            short version,
            string dereference
        )
        {
            var typeArg = QualifyType(fieldType.ItemType);
            await writer.WriteAsync($"{nameof(BinaryEncoder)}.Write");
            if (flexible)
                await writer.WriteAsync("Compact");
            await writer.WriteAsync($"Array<{typeArg}>(buffer, index, {dereference}, ");
            switch (fieldType.ItemType)
            {
                case StructFieldType s:
                    await writer.WriteAsync($"{s.Name}Serde.WriteV{version}");
                    break;
                case RecordsFieldType r:
                    await writer.WriteLineAsync($"{nameof(BinaryEncoder)}{nameof(BinaryEncoder.WriteRecords)}");
                    break;
                case ScalarFieldType f:
                    await writer.WriteAsync($"{nameof(BinaryEncoder)}.{ScalarFieldToEncode(f, false, fieldProperties.FlexibleVersions.Includes(version))}");
                    break;

                default:
                    throw new InvalidOperationException($"Unsupported array field item type '{fieldType.GetType().Name}'");
            }
            await writer.WriteLineAsync($");");
        }

        private static string ScalarFieldToEncode(
            ScalarFieldType field,
            bool nullable,
            bool flexible
        ) =>
            (field.Name, nullable, flexible) switch
            {
                ("bool", _, _) => nameof(BinaryEncoder.WriteBoolean),
                ("int8", _, _) => nameof(BinaryEncoder.WriteInt8),
                ("int16", _, _) => nameof(BinaryEncoder.WriteInt16),
                ("uint16", _, _) => nameof(BinaryEncoder.WriteUInt16),
                ("int32", _, _) => nameof(BinaryEncoder.WriteInt32),
                ("uint32", _, _) => nameof(BinaryEncoder.WriteUInt32),
                ("int64", _, _) => nameof(BinaryEncoder.WriteInt64),
                ("uint64", _, _) => nameof(BinaryEncoder.WriteUInt64),
                ("varint", _, _) => nameof(BinaryEncoder.WriteVarInt32),
                ("varlong", _, _) => nameof(BinaryEncoder.WriteVarInt64),
                ("uuid", _, _) => nameof(BinaryEncoder.WriteUuid),
                ("float64", _, _) => nameof(BinaryEncoder.WriteFloat64),
                ("string", true, true) => nameof(BinaryEncoder.WriteCompactNullableString),
                ("string", false, true) => nameof(BinaryEncoder.WriteCompactString),
                ("string", true, false) => nameof(BinaryEncoder.WriteNullableString),
                ("string", false, false) => nameof(BinaryEncoder.WriteString),
                ("bytes", true, true) => nameof(BinaryEncoder.WriteCompactNullableBytes),
                ("bytes", false, true) => nameof(BinaryEncoder.WriteCompactBytes),
                ("bytes", true, false) => nameof(BinaryEncoder.WriteNullableBytes),
                ("bytes", false, false) => nameof(BinaryEncoder.WriteBytes),
                (var t, _, _) => throw new InvalidOperationException($"Unsupported scalar type '{t}'")
            }
        ;

        private static string ScalarFieldToDecode(
            ScalarFieldType field,
            bool nullable,
            bool flexible
        ) =>
            (field.Name, nullable, flexible) switch
            {
                ("bool", _, _) => nameof(BinaryDecoder.ReadBoolean),
                ("int8", _, _) => nameof(BinaryDecoder.ReadInt8),
                ("int16", _, _) => nameof(BinaryDecoder.ReadInt16),
                ("uint16", _, _) => nameof(BinaryDecoder.ReadUInt16),
                ("int32", _, _) => nameof(BinaryDecoder.ReadInt32),
                ("uint32", _, _) => nameof(BinaryDecoder.ReadUInt32),
                ("int64", _, _) => nameof(BinaryDecoder.ReadInt64),
                ("uint64", _, _) => nameof(BinaryDecoder.ReadUInt64),
                ("varint", _, _) => nameof(BinaryDecoder.ReadVarInt32),
                ("varlong", _, _) => nameof(BinaryDecoder.ReadVarInt64),
                ("uuid", _, _) => nameof(BinaryDecoder.ReadUuid),
                ("float64", _, _) _ => nameof(BinaryDecoder.ReadFloat64),
                ("string", true, true) => nameof(BinaryDecoder.ReadCompactNullableString),
                ("string", false, true) => nameof(BinaryDecoder.ReadCompactString),
                ("string", true, false) => nameof(BinaryDecoder.ReadNullableString),
                ("string", false, false) => nameof(BinaryDecoder.ReadString),
                ("bytes", true, true) => nameof(BinaryDecoder.ReadCompactNullableBytes),
                ("bytes", false, true) => nameof(BinaryDecoder.ReadCompactBytes),
                ("bytes", true, false) => nameof(BinaryDecoder.ReadNullableBytes),
                ("bytes", false, false) => nameof(BinaryDecoder.ReadBytes),
                (var t, _, _) => throw new InvalidOperationException($"Unsupported scalar type '{t}'")
            }
        ;

        private static async ValueTask DecodeField(
            TextWriter writer,
            string indent,
            bool flexible,
            Field field,
            short version,
            string reference
        )
        {
            //var flexible = flexibleMessage && field.Properties.FlexibleVersions.Includes(version);
            var nullable = field.Properties.NullableVersions.Includes(version);
            await writer.WriteAsync(indent);
            await writer.WriteAsync($"(index, ");
            if(field.Type is ArrayFieldType && !nullable)
                await writer.WriteAsync($"var _{reference}_");
            else
                await writer.WriteAsync(reference);
            await writer.WriteAsync(") = ");
            await DecodeFieldStatement(writer, indent, flexible, nullable, field, version, reference);
        }

        private static async ValueTask DecodeFieldStatement(
            TextWriter writer,
            string indent,
            bool flexible,
            bool nullable,
            Field field,
            short version,
            string dereference
        )
        {
            switch (field.Type)
            {
                case ArrayFieldType a:
                    await DecodeArrayField(writer, indent, field.Name, flexible, field.Properties, a, version, dereference);
                    break;
                case StructFieldType s:
                    await DecodeStructField(writer, s, version);
                    break;
                case RecordsFieldType r:
                    await DecodeRecordsField(writer, indent, field.Name, flexible, nullable, r, version, dereference);
                    break;
                case ScalarFieldType f:
                    await DecodeScalarField(writer, flexible, nullable, f, version);
                    break;
                default:
                    throw new InvalidOperationException($"Unsupported field type '{field.Type.GetType().Name}'");
            }
        }

        private static async ValueTask DecodeArrayField(
            TextWriter writer,
            string indent,
            string fieldName,
            bool flexible,
            FieldProperties fieldProperties,
            ArrayFieldType fieldType,
            short version,
            string dereference
        )
        {
            var typeArg = QualifyType(fieldType.ItemType);
            await writer.WriteAsync($"{nameof(BinaryDecoder)}.Read");
            if (flexible)
                await writer.WriteAsync("Compact");
            await writer.WriteAsync($"Array");
            await writer.WriteAsync($"<{typeArg}>(buffer, index, ");
            switch (fieldType.ItemType)
            {
                case StructFieldType s:
                    await writer.WriteAsync($"{s.Name}Serde.ReadV{version}");
                    break;
                case RecordsFieldType r:
                    await writer.WriteLineAsync($"{nameof(BinaryDecoder)}{nameof(BinaryDecoder.ReadRecords)}");
                    break;
                case ScalarFieldType f:
                    await writer.WriteAsync($"{nameof(BinaryDecoder)}.{ScalarFieldToDecode(f, false, fieldProperties.FlexibleVersions.Includes(version))}");
                    break;
                default:
                    throw new InvalidOperationException($"Unsupported array field item type '{fieldType.GetType().Name}'");
            }
            await writer.WriteAsync($")");
            if (!fieldProperties.NullableVersions.Includes(version))
            {
                await writer.WriteLineAsync($";");
                await writer.WriteLineAsync(@$"{indent}if (_{dereference}_ == null)");
                await writer.WriteLineAsync(@$"{indent}    throw new {nameof(NullReferenceException)}(""Null not allowed for '{fieldName}'"");");
                await writer.WriteLineAsync(@$"{indent}else");
                await writer.WriteAsync(@$"{indent}    {dereference} = _{dereference}_.Value");
            }
            await writer.WriteLineAsync(";");
        }

        private static async ValueTask DecodeStructField(
            TextWriter writer,
            StructFieldType fieldType,
            short version
        ) =>
            await writer.WriteLineAsync($"{fieldType.Name}Serde.ReadV{version}(buffer, index);")
        ;

        private static async ValueTask DecodeRecordsField(
            TextWriter writer,
            string indent,
            string fieldName,
            bool flexible,
            bool nullable,
            RecordsFieldType fieldType,
            short version,
            string dereference
        )
        {
            if(flexible)
                await writer.WriteAsync($"{nameof(BinaryDecoder)}.ReadCompactRecords(buffer, index)");
            else
                await writer.WriteAsync($"{nameof(BinaryDecoder)}.ReadRecords(buffer, index)");
            if (!nullable)
            {
                await writer.WriteLineAsync($";");
                await writer.WriteLineAsync(@$"{indent}if ({dereference} == null)");
                await writer.WriteAsync(@$"{indent}    throw new {nameof(NullReferenceException)}(""Null not allowed for '{fieldName}'"")");
            }
            await writer.WriteLineAsync($";");
        }

        private static async ValueTask DecodeScalarField(
            TextWriter writer,
            bool flexible,
            bool nullable,
            ScalarFieldType fieldType,
            short version
        )
        {
            var scalarRead = ScalarFieldToDecode(fieldType, nullable, flexible);
            await writer.WriteLineAsync($"{nameof(BinaryDecoder)}.{scalarRead}(buffer, index);");
        }

        private static string DefaultValue(
            Field field
        ) =>
            (field.Type, field.Properties.NullableVersions.Some()) switch
            {
                (ScalarFieldType f, bool n) => DefaultScalar(f, n),
                (ArrayFieldType f, bool n) => DefaultArray(f, n),
                (StructFieldType f, bool n) => DefaultStruct(f, n),
                (RecordsFieldType _, bool n) => DefaultRecords(n),
                _ => "default"
            }
        ;

        private static string DefaultRecords(
            bool nullable
        ) =>
            nullable switch
            {
                true => $"default(ImmutableArray<{nameof(IRecords)}>?)",
                false => $"ImmutableArray<{nameof(IRecords)}>.Empty"
            }
        ;

        private static string DefaultScalar(
            ScalarFieldType fieldType,
            bool nullable
        ) =>
            (fieldType.Name, nullable) switch
            {
                ("string", false) => @"""""",
                ("bytes", false) => @"ReadOnlyMemory<byte>.Empty",
                _ => $"default({fieldType.ToSystemType()}{(nullable ? "?" : "")})"
            }
        ;

        private static string DefaultStruct(
            StructFieldType fieldType,
            bool nullable
        ) =>
            nullable switch
            {
                true => $"default{fieldType.Name}",
                false => $"{fieldType.Name}.Empty"
            }
        ;

        private static string DefaultArray(
            ArrayFieldType fieldType,
            bool nullable
        ) =>
            (fieldType.ItemType, nullable) switch
            {
                (ScalarFieldType f, false) => $"ImmutableArray<{f.ToSystemType()}>.Empty",
                (RecordsFieldType f, false) => $"ImmutableArray<{nameof(IRecords)}>.Empty",
                (StructFieldType f, false) => $"ImmutableArray<{f.Name}>.Empty",
                (ScalarFieldType f, true) => $"default(ImmutableArray<{f.ToSystemType()}>?)",
                (RecordsFieldType f, true) => $"default(ImmutableArray<{nameof(IRecords)}>?)",
                (StructFieldType f, true) => $"default(ImmutableArray<{f.Name}>?)",
                _ => "default",
            }
        ;

        private static IReadOnlyDictionary<string, QualifiedStruct> CreateTypeLookup(
            MessageDefinition message
        )
        {
            var names = new Dictionary<string, QualifiedStruct>();
            AddTypeLookup(names, $"{message.Name}", message.Structs);
            return names.ToImmutableDictionary();
        }

        private static void AddTypeLookup(
            Dictionary<string, QualifiedStruct> names,
            string fullName,
            IImmutableDictionary<string, StructDefinition> structs
        )
        {
            foreach (var kv in structs)
            {
                var newFullName = $"{fullName}.{kv.Key}";
                if (!names.ContainsKey(kv.Key))
                    names.Add(kv.Key, new(newFullName, kv.Value));
                AddTypeLookup(names, newFullName, kv.Value.Structs);
            }
        }

        private sealed record QualifiedStruct(
            string ParentName,
            StructDefinition Struct
        );

        private static UsingsFlags GetUsings(
            MessageDefinition message,
            IReadOnlyDictionary<string, QualifiedStruct> structs
        ) =>
            AggregateUsings(
                message.ValidVersions,
                message.Fields,
                structs
            )
        ;

        private static UsingsFlags AggregateUsings(
            VersionRange versions,
            IEnumerable<Field> fields,
            IReadOnlyDictionary<string, QualifiedStruct> structs
        ) =>
            fields.Aggregate(
                UsingsFlags.None,
                (s, f) => s | OrUsing(
                    versions,
                    f.Type,
                    versions.Intersect(f.Properties.Versions) != versions,
                    structs
                )
            )
        ;

        private static UsingsFlags OrUsing(
            VersionRange versions,
            FieldType field,
            bool nullabeOrDefault,
            IReadOnlyDictionary<string, QualifiedStruct> structs
        ) =>
            (field, nullabeOrDefault) switch
            {
                (ArrayFieldType f, true) => UsingsFlags.OptionalArray | OrUsing(
                    versions,
                    f,
                    false,
                    structs
                ),
                (ArrayFieldType f, false) => UsingsFlags.Array | OrUsing(
                    versions,
                    f.ItemType,
                    false,
                    structs
                ),
                (StructFieldType f, _) => AggregateUsings(
                    versions,
                    structs[f.Name].Struct.Fields,
                    structs
                ),
                (RecordsFieldType _, _) => UsingsFlags.Record,
                _ => UsingsFlags.None
            }
        ;

        private static UsingsFlags DetectByteArray(
            ScalarFieldType field
        ) =>
            field switch
            {
                { Name: "bytes" } => UsingsFlags.Array,
                _ => UsingsFlags.None
            }
        ;

        [Flags]
        private enum UsingsFlags
        {
            None = 0,
            Array = 1,
            Record = 2,
            OptionalArray = 4
        }

        private static string FieldTypify(
            Field field
        )
        {
            var type = QualifyType(field.Type);
            if (field.Properties.NullableVersions.Some())
                type += "?";
            return type;
        }

        private static string FieldPropertyNamify(
            Field field
        ) =>
            $"{char.ToUpper(field.Name[0])}{field.Name[1..]}Field"
        ;

        private static string FieldVariableNamify(
            Field field
        ) =>
            $"{char.ToLower(field.Name[0])}{field.Name[1..]}Field"
        ;
    }
}
