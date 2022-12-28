using Kafka.CodeGen.Models;
using Kafka.CodeGen.Models.Extensions;
using Kafka.Common.Encoding;
using Kafka.Common.Protocol;
using Kafka.Common.Records;
using Kafka.Common.Types.Extensions;
using System.Collections.Immutable;
using System.IO.Abstractions;
using Version = Kafka.Common.Types.Version;

namespace Kafka.CodeGen.CSharp
{
    public static class Generator
    {
        public static async ValueTask Write(
            IFileSystem fileSystem,
            string directory,
            MessageDefinition message
        )
        {
            TestValidVersion(message.ValidVersions);
            var typeLookup = CreateTypeLookup(message);
            var typeFlags = GetUsings(message, typeLookup);
            await WriteModel(
                fileSystem,
                message,
                directory,
                typeLookup,
                typeFlags
            );
            await WriteSerde(
                fileSystem,
                message,
                directory,
                typeLookup,
                typeFlags
            );
        }

        private static async ValueTask WriteModel(
            IFileSystem fileSystem,
            MessageDefinition message,
            string directory,
            IReadOnlyDictionary<string, QualifiedStruct> typeLookup,
            UsingsFlags typeFlags
        )
        {
            using var writer = CreateWriter(
                fileSystem,
                directory,
                message.Name
            );

            var usings = new List<string>();
            if (typeFlags.HasFlag(UsingsFlags.Array))
                usings.Add("System.Collections.Immutable");
            if (typeFlags.HasFlag(UsingsFlags.Record))
                usings.Add("Kafka.Common.Records");
            usings.Add("Kafka.Common.Protocol");
            foreach (var type in typeLookup)
                usings.Add($"{type.Key} = Kafka.Client.Messages.{type.Value.ParentName}");

            await WriteNamespace(
                writer,
                message,
                typeLookup,
                usings,
                (w, m, t) => WriteMessageRecord(w, m)
            );
            await writer.FlushAsync();
        }

        private static async ValueTask WriteSerde(
            IFileSystem fileSystem,
            MessageDefinition message,
            string directory,
            IReadOnlyDictionary<string, QualifiedStruct> typeLookup,
            UsingsFlags typeFlags
        )
        {
            using var writer = CreateWriter(
                fileSystem,
                directory,
                $"{message.Name}.Extensions"
            );

            var usings = new List<string>()
            {
                typeof(Encoder).Namespace ?? ""
            };
            if (typeFlags.HasFlag(UsingsFlags.OptionalArray))
                usings.Add("System.Collections.Immutable");
            if (typeFlags.HasFlag(UsingsFlags.Record))
                usings.Add("Kafka.Common.Records");
            foreach (var type in typeLookup)
                usings.Add($"{type.Key} = Kafka.Client.Messages.{type.Value.ParentName}");

            await WriteNamespace(
                writer,
                message,
                typeLookup,
                usings,
                (w, m, t) => WriteMessageRecordExtension(w, m)
            );
            await writer.FlushAsync();
        }

        private static async ValueTask WriteNamespace(
            TextWriter writer,
            MessageDefinition message,
            IReadOnlyDictionary<string, QualifiedStruct> typeLookup,
            IEnumerable<string> namespaces,
            Func<TextWriter, MessageDefinition, IReadOnlyDictionary<string, QualifiedStruct>, ValueTask> classWriter
        )
        {
            await writer.WriteLineAsync($"using System.CodeDom.Compiler;");
            foreach (var ns in namespaces)
                await writer.WriteLineAsync($"using {ns};");
            await writer.WriteLineAsync();
            await writer.WriteLineAsync($"namespace Kafka.Client.Messages");
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
            MessageDefinition message
        )
        {
            var assemblyName = typeof(Generator).Assembly.GetName();
            await WriteSummary(writer, "    ", message);
            await writer.WriteLineAsync($"    [GeneratedCode(\"{assemblyName.Name}\", \"{assemblyName.Version}\")]");
            await writer.WriteLineAsync($"    public sealed record {message.Name} (");
            await WriteFields(
                writer,
                message.Fields,
                "    "
            );
            switch (message)
            {
                case ApiRequestMessage a:
                    await writer.WriteLineAsync($"    ) : {nameof(Request)}({a.ApiKey.Value},{a.ValidVersions.Min},{a.ValidVersions.Max},{a.FlexibleVersions.Min})");
                    break;
                case ApiResponseMessage a:
                    await writer.WriteLineAsync($"    ) : {nameof(Response)}({a.ApiKey.Value})");
                    break;
                default:
                    await writer.WriteLineAsync($"    )");
                    break;
            }
            await writer.WriteLineAsync($"    {{");
            await WriteDefaultEmptyValue(
                writer,
                "        ",
                message.Name,
                message.Fields
            );
            await WriteMessageNestedRecords(
                message.Structs,
                writer,
                "        "
            );
            await writer.WriteLineAsync($"    }};");
        }

        private static async ValueTask WriteMessageNestedRecords(
            IImmutableDictionary<string, StructDefinition> types,
            TextWriter writer,
            string indent
        )
        {
            if (!types.Any())
                return;
            foreach (var type in types.Values)
                await WriteMessageNestedRecord(type, writer, indent);
        }

        private static async ValueTask WriteMessageNestedRecord(
            StructDefinition @struct,
            TextWriter writer,
            string indent
        )
        {
            await WriteSummary(writer, indent, @struct);
            await writer.WriteLineAsync($"{indent}public sealed record {@struct.Name} (");
            await WriteFields(
                writer,
                @struct.Fields,
                indent
            );
            await writer.WriteLineAsync($"{indent})");
            await writer.WriteLineAsync($"{indent}{{");
            await WriteDefaultEmptyValue(
                writer,
                $"{indent}    ",
                @struct.Name,
                @struct.Fields
            );
            await WriteMessageNestedRecords(@struct.Structs, writer, $"{indent}    ");
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
            await writer.WriteLineAsync();
            await writer.WriteLineAsync($"{indent});");
        }

        private static async ValueTask WriteFields(
            TextWriter writer,
            IEnumerable<Field> fields,
            string indent
        )
        {
            await WriteFieldProperty(writer, $"{indent}    ", fields.First());
            foreach (var field in fields.Skip(1))
            {
                await writer.WriteLineAsync($",");
                await WriteFieldProperty(writer, $"{indent}    ", field);
            }
            await writer.WriteLineAsync();
        }

        private static async ValueTask WriteHeaderRecordExtension(
            TextWriter writer,
            HeaderMessage message
        )
        {
            await writer.WriteLineAsync($"        private delegate {message.Name} DecodeDelegate(byte[] buffer, ref int index, bool flexible);");
            await writer.WriteLineAsync($"        private delegate int EncodeDelegate(byte[] buffer, int offset, {message.Name} item, bool flexible);");
            await writer.WriteLineAsync($"        private static readonly DecodeDelegate[] READ_VERSIONS = {{");
            foreach (var version in message.ValidVersions.Enumerate())
                await writer.WriteLineAsync($"            ReadV{version:0#},");
            await writer.WriteLineAsync($"        }};");
            await writer.WriteLineAsync($"        private static readonly EncodeDelegate[] WRITE_VERSIONS = {{");
            foreach (var version in message.ValidVersions.Enumerate())
                await writer.WriteLineAsync($"            WriteV{version:0#},");
            await writer.WriteLineAsync($"        }};");
            await writer.WriteLineAsync($"        public static {message.Name} Read(byte[] buffer, ref int index, short version, bool flexible) =>");
            await writer.WriteLineAsync($"            READ_VERSIONS[version](buffer, ref index, flexible)");
            await writer.WriteLineAsync($"        ;");
            await writer.WriteLineAsync($"        public static int Write(byte[] buffer, int index, {message.Name} message, short version, bool flexible) =>");
            await writer.WriteLineAsync($"            WRITE_VERSIONS[version](buffer, index, message,flexible)");
            await writer.WriteLineAsync($"        ;");
            foreach (var version in message.ValidVersions.Enumerate())
            {
                var flexible = message.FlexibleVersions.Includes(version);
                var variableList = new List<string>();
                await writer.WriteLineAsync($"        private static {message.Name} ReadV{version:0#}(byte[] buffer, ref int index, bool flexible)");
                await writer.WriteLineAsync($"        {{");
                foreach (var field in message.Fields)
                {
                    var variable = FieldVariableNamify(field);
                    variableList.Add(variable);
                    await DecodeField(writer, "            ", flexible, field, version, variable);
                }
                if (flexible)
                {
                    await writer.WriteLineAsync("            if (flexible)");
                    await writer.WriteLineAsync("                _ = Decoder.ReadVarUInt32(buffer, ref index);");
                }
                await writer.WriteLineAsync($"            return new(");
                foreach (var variable in variableList.GetRange(0, variableList.Count - 1))
                    await writer.WriteLineAsync($"                {variable},");
                await writer.WriteLineAsync($"                {variableList.Last()}");
                await writer.WriteLineAsync($"            );");
                await writer.WriteLineAsync($"        }}");
                await writer.WriteLineAsync($"        private static int WriteV{version:0#}(byte[] buffer, int index, {message.Name} message, bool flexible)");
                await writer.WriteLineAsync($"        {{");
                foreach (var field in message.Fields.Where(f => f.Properties.Versions.Includes(version)))
                    await EncodeField(writer, "            ", flexible, field, version, $"message.{field.Name}Field");
                if (flexible)
                {
                    await writer.WriteLineAsync("            if (flexible)");
                    await writer.WriteLineAsync("                index = Encoder.WriteVarUInt32(buffer, index, 0);");
                }
                await writer.WriteLineAsync($"            return index;");
                await writer.WriteLineAsync($"        }}");
            }
        }

        private static async ValueTask WriteRequestResponseExtension(
            TextWriter writer,
            MessageDefinition message
        )
        {
            await writer.WriteLineAsync($"        private static readonly DecodeDelegate<{message.Name}>[] READ_VERSIONS = {{");
            foreach (var version in message.ValidVersions.Enumerate())
                await writer.WriteLineAsync($"            ReadV{version:0#},");
            await writer.WriteLineAsync($"        }};");
            await writer.WriteLineAsync($"        private static readonly EncodeDelegate<{message.Name}>[] WRITE_VERSIONS = {{");
            foreach (var version in message.ValidVersions.Enumerate())
                await writer.WriteLineAsync($"            WriteV{version:0#},");
            await writer.WriteLineAsync($"        }};");
            await writer.WriteLineAsync($"        public static {message.Name} Read(byte[] buffer, ref int index, short version) =>");
            await writer.WriteLineAsync($"            READ_VERSIONS[version](buffer, ref index)");
            await writer.WriteLineAsync($"        ;");
            await writer.WriteLineAsync($"        public static int Write(byte[] buffer, int index, {message.Name} message, short version) =>");
            await writer.WriteLineAsync($"            WRITE_VERSIONS[version](buffer, index, message)");
            await writer.WriteLineAsync($"        ;");
            foreach (var version in message.ValidVersions.Enumerate())
            {
                var flexible = message.FlexibleVersions.Includes(version);
                var variableList = new List<string>();
                await writer.WriteLineAsync($"        private static {message.Name} ReadV{version:0#}(byte[] buffer, ref int index)");
                await writer.WriteLineAsync($"        {{");
                foreach (var field in message.Fields)
                {
                    var variable = $"{char.ToLower(field.Name[0])}{field.Name[1..]}Field";
                    variableList.Add(variable);
                    await DecodeField(writer, "            ", flexible, field, version, variable);
                }
                if (flexible)
                    await writer.WriteLineAsync("            _ = Decoder.ReadVarUInt32(buffer, ref index);");
                await writer.WriteLineAsync($"            return new(");
                foreach (var variable in variableList.GetRange(0, variableList.Count - 1))
                    await writer.WriteLineAsync($"                {variable},");
                await writer.WriteLineAsync($"                {variableList.Last()}");
                await writer.WriteLineAsync($"            );");
                await writer.WriteLineAsync($"        }}");
                await writer.WriteLineAsync($"        private static int WriteV{version:0#}(byte[] buffer, int index, {message.Name} message)");
                await writer.WriteLineAsync($"        {{");
                foreach (var field in message.Fields.Where(f => f.Properties.Versions.Includes(version)))
                    await EncodeField(writer, "            ", flexible, field, version, $"message.{FieldPropertyNamify(field)}");
                if (flexible)
                    await writer.WriteLineAsync("            index = Encoder.WriteVarUInt32(buffer, index, 0);");
                await writer.WriteLineAsync($"            return index;");
                await writer.WriteLineAsync($"        }}");
            }
            foreach (var @struct in message.Structs.Values)
                await WriteMessageRecordExtension(writer, @struct, message.FlexibleVersions, @struct.Versions.Constrain(message.ValidVersions), 0);
        }

        private static async ValueTask WriteMessageRecordExtension(
            TextWriter writer,
            MessageDefinition message
        )
        {
            var assemblyName = typeof(Generator).Assembly.GetName();
            await writer.WriteLineAsync($"    [GeneratedCode(\"{assemblyName.Name}\", \"{assemblyName.Version}\")]");
            await writer.WriteLineAsync($"    public static class {message.Name}Serde");
            await writer.WriteLineAsync($"    {{");
            switch (message)
            {
                case HeaderMessage h:
                    await WriteHeaderRecordExtension(writer, h);
                    break;
                default:
                    await WriteRequestResponseExtension(writer, message);
                    break;
            }
            await writer.WriteLineAsync($"    }}");
        }

        private static async ValueTask WriteMessageRecordExtension(
            TextWriter writer,
            StructDefinition @struct,
            Version flexibleVersions,
            Version versions,
            int depth
        )
        {
            var indent = "".PadRight(8 + (depth * 4));
            await writer.WriteLineAsync($"{indent}private static class {@struct.Name}Serde");
            await writer.WriteLineAsync($"{indent}{{");
            foreach (var version in versions.Enumerate())
            {
                var flexible = flexibleVersions.Includes(version);
                var variableList = new List<string>();
                await writer.WriteLineAsync($"{indent}    public static {@struct.Name} ReadV{version:0#}(byte[] buffer, ref int index)");
                await writer.WriteLineAsync($"{indent}    {{");
                foreach (var field in @struct.Fields)
                {
                    var variable = FieldPropertyNamify(field);
                    variableList.Add(variable);
                    await DecodeField(writer, $"{indent}        ", flexible, field, version, variable);
                }
                if (flexible)
                    await writer.WriteLineAsync($"{indent}        _ = Decoder.ReadVarUInt32(buffer, ref index);");
                await writer.WriteLineAsync($"{indent}        return new(");
                foreach (var variable in variableList.GetRange(0, variableList.Count - 1))
                    await writer.WriteLineAsync($"{indent}            {variable},");
                await writer.WriteLineAsync($"{indent}            {variableList.Last()}");
                await writer.WriteLineAsync($"{indent}        );");
                await writer.WriteLineAsync($"{indent}    }}");
                await writer.WriteLineAsync($"{indent}    public static int WriteV{version:0#}(byte[] buffer, int index, {@struct.Name} message)");
                await writer.WriteLineAsync($"{indent}    {{");
                foreach (var field in @struct.Fields.Where(f => f.Properties.Versions.Includes(version)))
                    await EncodeField(writer, $"{indent}        ", flexible, field, version, $"message.{FieldPropertyNamify(field)}");
                if (flexible)
                    await writer.WriteLineAsync($"{indent}        index = Encoder.WriteVarUInt32(buffer, index, 0);");
                await writer.WriteLineAsync($"{indent}        return index;");
                await writer.WriteLineAsync($"{indent}    }}");
            }
            foreach (var nestedStruct in @struct.Structs.Values)
                await WriteMessageRecordExtension(writer, nestedStruct, flexibleVersions, nestedStruct.Versions.Constrain(versions), depth + 1);
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
            Version version
        ) =>
            TestValidVersion(
                version,
                Version.All
            )
        ;

        private static bool TestValidVersion(
            Version version,
            Version limit
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
                StructFieldType f => f.Name,
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
                    await EncodeStructField(writer, indent, s, version, dereference);
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
            string indent,
            StructFieldType fieldType,
            short version,
            string dereference
        )
        {
            await writer.WriteLineAsync($"{fieldType.Name}Serde.WriteV{version:0#}(buffer, index, {dereference});");
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
                await writer.WriteLineAsync($"{nameof(Encoder)}.{nameof(Encoder.WriteCompactRecords)}(buffer, index, {dereference});");
            else
                await writer.WriteLineAsync($"{nameof(Encoder)}.{nameof(Encoder.WriteRecords)}(buffer, index, {dereference});");
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
            await writer.WriteLineAsync($"{nameof(Encoder)}.{scalarWrite}(buffer, index, {dereference});");
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
            await writer.WriteAsync($"{nameof(Encoder)}.Write");
            if (flexible)
                await writer.WriteAsync("Compact");
            await writer.WriteAsync($"Array<{typeArg}>(buffer, index, {dereference}, ");
            switch (fieldType.ItemType)
            {
                case StructFieldType s:
                    await writer.WriteAsync($"{s.Name}Serde.WriteV{version:0#}");
                    break;
                case RecordsFieldType r:
                    await writer.WriteLineAsync($"{nameof(Encoder)}{nameof(Encoder.WriteRecords)}");
                    break;
                case ScalarFieldType f:
                    await writer.WriteAsync($"{nameof(Encoder)}.{ScalarFieldToEncode(f, false, fieldProperties.FlexibleVersions.Includes(version))}");
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
                ("bool", _, _) => nameof(Encoder.WriteBoolean),
                ("int8", _, _) => nameof(Encoder.WriteInt8),
                ("int16", _, _) => nameof(Encoder.WriteInt16),
                ("uint16", _, _) => nameof(Encoder.WriteUInt16),
                ("int32", _, _) => nameof(Encoder.WriteInt32),
                ("uint32", _, _) => nameof(Encoder.WriteUInt32),
                ("int64", _, _) => nameof(Encoder.WriteInt64),
                ("uint64", _, _) => nameof(Encoder.WriteUInt64),
                ("varint", _, _) => nameof(Encoder.WriteVarInt32),
                ("varlong", _, _) => nameof(Encoder.WriteVarInt64),
                ("uuid", _, _) => nameof(Encoder.WriteUuid),
                ("float64", _, _) => nameof(Encoder.WriteFloat64),
                ("string", true, true) => nameof(Encoder.WriteCompactNullableString),
                ("string", false, true) => nameof(Encoder.WriteCompactString),
                ("string", true, false) => nameof(Encoder.WriteNullableString),
                ("string", false, false) => nameof(Encoder.WriteString),
                ("bytes", true, true) => nameof(Encoder.WriteCompactNullableBytes),
                ("bytes", false, true) => nameof(Encoder.WriteCompactBytes),
                ("bytes", true, false) => nameof(Encoder.WriteNullableBytes),
                ("bytes", false, false) => nameof(Encoder.WriteBytes),
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
                ("bool", _, _) => nameof(Decoder.ReadBoolean),
                ("int8", _, _) => nameof(Decoder.ReadInt8),
                ("int16", _, _) => nameof(Decoder.ReadInt16),
                ("uint16", _, _) => nameof(Decoder.ReadUInt16),
                ("int32", _, _) => nameof(Decoder.ReadInt32),
                ("uint32", _, _) => nameof(Decoder.ReadUInt32),
                ("int64", _, _) => nameof(Decoder.ReadInt64),
                ("uint64", _, _) => nameof(Decoder.ReadUInt64),
                ("varint", _, _) => nameof(Decoder.ReadVarInt32),
                ("varlong", _, _) => nameof(Decoder.ReadVarInt64),
                ("uuid", _, _) => nameof(Decoder.ReadUuid),
                ("float64", _, _) _ => nameof(Decoder.ReadFloat64),
                ("string", true, true) => nameof(Decoder.ReadCompactNullableString),
                ("string", false, true) => nameof(Decoder.ReadCompactString),
                ("string", true, false) => nameof(Decoder.ReadNullableString),
                ("string", false, false) => nameof(Decoder.ReadString),
                ("bytes", true, true) => nameof(Decoder.ReadCompactNullableBytes),
                ("bytes", false, true) => nameof(Decoder.ReadCompactBytes),
                ("bytes", true, false) => nameof(Decoder.ReadNullableBytes),
                ("bytes", false, false) => nameof(Decoder.ReadBytes),
                (var t, _, _) => throw new InvalidOperationException($"Unsupported scalar type '{t}'")
            }
        ;

        private static async ValueTask DecodeField(
            TextWriter writer,
            string indent,
            bool flexible,
            Field field,
            short version,
            string dereference
        )
        {
            var flexibleField = flexible && field.Properties.FlexibleVersions.Includes(version);
            await writer.WriteAsync(indent);
            await writer.WriteAsync($"var {dereference} = ");
            switch (field.Type)
            {
                case ArrayFieldType a:
                    await DecodeArrayField(writer, field.Name, flexibleField, field.Properties, a, version);
                    break;
                case StructFieldType s:
                    await DecodeStructField(writer, field.Properties, s, version);
                    break;
                case RecordsFieldType r:
                    await DecodeRecordsField(writer, field.Name, flexibleField, field.Properties, r, version);
                    break;
                case ScalarFieldType f:
                    await DecodeScalarField(writer, flexibleField, field.Properties, f, version);
                    break;
                default:
                    throw new InvalidOperationException($"Unsupported field type '{field.Type.GetType().Name}'");
            }
        }

        private static async ValueTask DecodeArrayField(
            TextWriter writer,
            string fieldName,
            bool flexible,
            FieldProperties fieldProperties,
            ArrayFieldType fieldType,
            short version
        )
        {
            var typeArg = QualifyType(fieldType.ItemType);
            if (!fieldProperties.Versions.Includes(version) || fieldProperties.TaggedVersions.Includes(version))
            {
                if (fieldProperties.NullableVersions.Includes(version))
                    await writer.WriteLineAsync($"default;");
                else
                    await writer.WriteLineAsync($"{nameof(ImmutableArray)}<{typeArg}>.Empty;");
                return;
            }
            else
            {
                await writer.WriteAsync($"Decoder.Read");
                if (flexible)
                    await writer.WriteAsync("Compact");
                await writer.WriteAsync($"Array");
                await writer.WriteAsync($"<{typeArg}>(buffer, ref index, ");
            }
            switch (fieldType.ItemType)
            {
                case StructFieldType s:
                    await writer.WriteAsync($"{s.Name}Serde.ReadV{version:0#}");
                    break;
                case RecordsFieldType r:
                    await writer.WriteLineAsync($"{nameof(Decoder)}{nameof(Decoder.ReadRecords)}");
                    break;
                case ScalarFieldType f:
                    await writer.WriteAsync($"{nameof(Decoder)}.{ScalarFieldToDecode(f, false, fieldProperties.FlexibleVersions.Includes(version))}");
                    break;
                default:
                    throw new InvalidOperationException($"Unsupported array field item type '{fieldType.GetType().Name}'");
            }
            await writer.WriteAsync($")");
            if (!fieldProperties.NullableVersions.Includes(version))
                await writer.WriteAsync(@$" ?? throw new {nameof(NullReferenceException)}(""Null not allowed for '{fieldName}'"")");
            await writer.WriteLineAsync($";");
        }

        private static async ValueTask DecodeStructField(
            TextWriter writer,
            FieldProperties fieldProperties,
            StructFieldType fieldType,
            short version
        )
        {
            if (!fieldProperties.Versions.Includes(version) || fieldProperties.TaggedVersions.Includes(version))
                if (fieldProperties.NullableVersions.Includes(version))
                    await writer.WriteLineAsync($"default({fieldType.Name});");
                else
                    await writer.WriteLineAsync($"{fieldType.Name}.Empty;");
            else
                await writer.WriteLineAsync($"{fieldType.Name}Serde.ReadV{version:0#}(buffer, ref index);");
        }

        private static async ValueTask DecodeRecordsField(
            TextWriter writer,
            string fieldName,
            bool flexible,
            FieldProperties fieldProperties,
            RecordsFieldType fieldType,
            short version
        )
        {
            if (!fieldProperties.Versions.Includes(version) || fieldProperties.TaggedVersions.Includes(version))
            {
                if (fieldProperties.NullableVersions.Includes(version))
                    await writer.WriteLineAsync($"default(ImmutableArray<{nameof(IRecords)}>);");
                else
                    await writer.WriteLineAsync($"{nameof(RecordBatch)}.{nameof(RecordBatch.Empty)};");
            }
            else
            {
                if (fieldProperties.NullableVersions.Includes(version))
                    await writer.WriteLineAsync($"Decoder.ReadRecords(buffer, ref index);");
                else
                    await writer.WriteLineAsync($"Decoder.ReadRecords(buffer, ref index) ?? throw new {nameof(NullReferenceException)}(\"Null not allowed for '{fieldName}'\");");
            }
        }

        private static async ValueTask DecodeScalarField(
            TextWriter writer,
            bool flexible,
            FieldProperties fieldProperties,
            ScalarFieldType fieldType,
            short version
        )
        {
            if (!fieldProperties.Versions.Includes(version) || fieldProperties.TaggedVersions.Includes(version))
            {
                var expr = DefaultScalar(fieldType, fieldProperties.NullableVersions.Some());
                await writer.WriteLineAsync($"{expr};");
            }
            else
            {
                var scalarRead = ScalarFieldToDecode(fieldType, fieldProperties.NullableVersions.Includes(version), flexible);
                await writer.WriteLineAsync($"Decoder.{scalarRead}(buffer, ref index);");
            }
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
                true => $"default(ImmutableArray<{nameof(IRecords)}>)",
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
            AddTypeLookup(names, message.Name, message.Structs);
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
            Version versions,
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
            Version versions,
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

        private static TextWriter CreateWriter(
            IFileSystem fileSystem,
            string directory,
            string name
        )
        {
            var path = fileSystem.Path.Join(directory, $"{name}.cs");
            return new StreamWriter(
                fileSystem.FileStream.Create(
                    fileSystem.Path.Combine(
                        path
                    ),
                    FileMode.Create,
                    FileAccess.Write,
                    FileShare.ReadWrite
                )
            );
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
