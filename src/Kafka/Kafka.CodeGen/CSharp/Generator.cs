using Kafka.CodeGen.Models;
using Kafka.CodeGen.Models.Extensions;
using System.Collections.Immutable;
using System.IO.Abstractions;
using Version = Kafka.CodeGen.Models.Version;

namespace Kafka.CodeGen.CSharp
{
    public static class Generator
    {
        public static async ValueTask Write(
            IFileSystem fileSystem,
            string directory,
            Message message
        )
        {
            TestValidVersion(message.ValidVersions);
            var typeLookup = CreateTypeLookup(message);
            await WriteMessage( 
                fileSystem,
                message,
                directory,
                typeLookup
            );
            await WriteMessageExtension(
                fileSystem,
                message,
                directory,
                typeLookup
            );
        }

        private static async ValueTask WriteMessage(
            IFileSystem fileSystem,
            Message message,
            string directory,
            IReadOnlyDictionary<string, QualifiedStruct> typeLookup
        )
        {
            var path = fileSystem.Path.Join(directory, $"{message.Name}.cs");
            using var writer = new StreamWriter(
                fileSystem.FileStream.Create(
                    fileSystem.Path.Combine(
                        path
                    ),
                    FileMode.Create,
                    FileAccess.Write,
                    FileShare.ReadWrite
                )
            );

            if(HasRecords(message, typeLookup))
                await writer.WriteLineAsync($"using Kafka.Common.Records;");
            await writer.WriteLineAsync($"using System.CodeDom.Compiler;");
            await writer.WriteLineAsync($"namespace Kafka.Client.Messages");
            await writer.WriteLineAsync($"{{");
            await writer.WriteLineAsync($"    [GeneratedCode(\"{typeof(Generator).Assembly.GetName().Name}\", \"{typeof(Generator).Assembly.GetName().Version}\")]");
            await writer.WriteLineAsync($"    public sealed record {message.Name} (");
            await writer.WriteAsync($"        {FieldToProperty(message.Fields.First(), typeLookup)}");
            foreach (var field in message.Fields.Skip(1))
            {
                await writer.WriteLineAsync($",");
                await writer.WriteAsync($"        {FieldToProperty(field, typeLookup)}");
            }
            await writer.WriteLineAsync();
            await writer.WriteAsync($"    )");
            if (message.Structs.Any())
            {
                await writer.WriteLineAsync();
                await writer.WriteLineAsync($"    {{");
                await WriteMessageStructs(message.Structs, typeLookup, writer, 0);
                await writer.WriteAsync($"    }}");
            }
            await writer.WriteLineAsync($";");
            await writer.WriteLineAsync($"}}");
            await writer.FlushAsync();
        }

        private static async ValueTask WriteMessageExtension(
            IFileSystem fileSystem,
            Message message,
            string directory,
            IReadOnlyDictionary<string, QualifiedStruct> typeLookup
        )
        {
            var path = fileSystem.Path.Join(directory, $"{message.Name}.Extensions.cs");
            using var writer = new StreamWriter(
                fileSystem.FileStream.Create(
                    fileSystem.Path.Combine(
                        path
                    ),
                    FileMode.Create,
                    FileAccess.Write,
                    FileShare.ReadWrite
                )
            );
            await writer.WriteLineAsync($"using Kafka.Common.Encoding;");
            await writer.WriteLineAsync($"using System.CodeDom.Compiler;");
            await writer.WriteLineAsync($"namespace Kafka.Client.Messages.Extensions");
            await writer.WriteLineAsync($"{{");
            await writer.WriteLineAsync($"    [GeneratedCode(\"{typeof(Generator).Assembly.GetName().Name}\", \"{typeof(Generator).Assembly.GetName().Version}\")]");
            await writer.WriteLineAsync($"    public static class {message.Name}Extensions");
            await writer.WriteLineAsync($"    {{");
            await writer.WriteLineAsync($"        public static void Write(this {message.Name} message, MemoryStream buffer)");
            await writer.WriteLineAsync($"        {{");
            foreach (var field in message.Fields)
                await FieldTypeToEncode(writer, field.Type, $"message.{field.Name}Field", typeLookup, 0);
            await writer.WriteLineAsync($"        }}");
            await writer.WriteLineAsync($"    }}");
            await writer.WriteLineAsync($"}}");
            await writer.FlushAsync();
        }

        private static async ValueTask WriteMessageStructs(
            IImmutableDictionary<string, Struct> types,
            IReadOnlyDictionary<string, QualifiedStruct> typeLookup,
            TextWriter writer,
            int depth
        )
        {
            var indent = "".PadRight(4 + (depth * 4));
            foreach (var type in types.Values)
            {
                await WriteMessageStruct(type, typeLookup, writer, depth);
                if (type.Structs.Any())
                {
                    await writer.WriteLineAsync();
                    await writer.WriteAsync(indent);
                    await writer.WriteLineAsync($"    {{");
                    await WriteMessageStructs(type.Structs, typeLookup, writer, depth + 1);
                    await writer.WriteAsync(indent);
                    await writer.WriteAsync($"    }}");
                }
                await writer.WriteLineAsync($";");
            }
        }

        private static async ValueTask WriteMessageStruct(
            Struct type,
            IReadOnlyDictionary<string, QualifiedStruct> typeLookup,
            TextWriter writer,
            int depth
        )
        {
            var indent = "".PadRight(8 + (depth * 4));
            await writer.WriteAsync(indent);
            await writer.WriteLineAsync($"public sealed record {type.Name} (");
            await writer.WriteAsync(indent);
            await writer.WriteAsync($"    {FieldToProperty(type.Fields.First(), typeLookup)}");
            foreach (var field in type.Fields.Skip(1))
            {
                await writer.WriteLineAsync($",");
                await writer.WriteAsync(indent);
                await writer.WriteAsync($"    {FieldToProperty(field, typeLookup)}");
            }
            await writer.WriteLineAsync();
            await writer.WriteAsync(indent);
            await writer.WriteAsync($")");
        }
        private static bool TestValidVersion(
            Version version
        ) =>
            TestValidVersion(
                version,
                Version.Any
            )
        ;
        private static bool TestValidVersion(
            Version version,
            Version limit
        ) =>
            version.Min >= limit.Min &&
            version.Max <= limit.Max
        ;

        private static string FieldToProperty(
            Field field,
            IReadOnlyDictionary<string, QualifiedStruct> typeLookup
        ) =>
            $"{QualifyType(field.Type, typeLookup)} {field.Name}Field"
        ;

        private static string QualifyType(
            FieldType fieldType,
            IReadOnlyDictionary<string, QualifiedStruct> typeLookup
        ) =>
            fieldType switch
            {
                StructFieldType f => typeLookup[f.Name].ParentName,
                ArrayFieldType f => $"{QualifyType(f.ItemType, typeLookup)}[]",
                RecordsFieldType => "IRecords",
                FieldType f => f.ToSystemType()
            }
        ;

        private static async ValueTask FieldTypeToEncode(
            TextWriter writer,
            FieldType fieldType,
            string dereference,
            IReadOnlyDictionary<string, QualifiedStruct> typeLookup,
            int depth
        )
        {
            var indent = "".PadRight(12 + (depth * 4));
            switch (fieldType)
            {
                case StructFieldType s:
                    await StructFieldToEncode(
                        writer,
                        s,
                        dereference,
                        typeLookup,
                        depth
                    );
                    break;
                case ArrayFieldType a:
                    await writer.WriteAsync(indent);
                    await writer.WriteLineAsync($"Encoder.WriteArray(buffer, {dereference}, (b, i) =>");
                    await writer.WriteAsync(indent);
                    await writer.WriteLineAsync($"{{");
                    await FieldTypeToEncode(writer, a.ItemType, "i", typeLookup, depth + 1);
                    await writer.WriteAsync(indent);
                    await writer.WriteLineAsync($"    return 0;");
                    await writer.WriteAsync(indent);
                    await writer.WriteLineAsync($"}});");
                    break;
                case RecordsFieldType _:
                    await writer.WriteAsync(indent);
                    await writer.WriteLineAsync($"Encoder.WriteRecords(buffer, {dereference});");
                    break;
                case ScalarFieldType f:
                    var scalarWrite = ScalarFieldToEncode(f);
                    await writer.WriteAsync(indent);
                    await writer.WriteLineAsync($"Encoder.{scalarWrite}(buffer, {dereference});");
                    break;
                default:
                    throw new InvalidOperationException($"Unsupported field type '{fieldType.GetType().Name}'");
            }
        }

        private static async ValueTask StructFieldToEncode(
            TextWriter writer,
            StructFieldType fieldType,
            string dereference,
            IReadOnlyDictionary<string, QualifiedStruct> typeLookup,
            int depth
        )
        {
            var qualifiedStruct = typeLookup[fieldType.Name];
            foreach (var field in qualifiedStruct.Struct.Fields)
                await FieldTypeToEncode(writer, field.Type, $"{dereference}.{field.Name}Field", typeLookup, depth);
        }

        private static string ScalarFieldToEncode(
            ScalarFieldType field
        ) =>
            field.Name switch
            {
                "bool" => $"WriteBoolean",
                "int8" => $"WriteInt8",
                "int16" => $"WriteInt16",
                "uint16" => $"WriteUInt16",
                "int32" => $"WriteInt32",
                "uint32" => $"WriteUInt32",
                "int64" => $"WriteInt64",
                "uint64" => $"WriteUInt64",
                "varint" => $"WriteVarInt32",
                "varlong" => $"WriteVarInt64",
                "uuid" => $"WriteUuid",
                "float64" => $"WriteFloat64",
                "string" => $"WriteString",
                "bytes" => $"WriteBytes",
                var t => throw new InvalidOperationException($"Unsupported scalar type '{t}'")
            }
        ;

        private static IReadOnlyDictionary<string, QualifiedStruct> CreateTypeLookup(
            Message message
        )
        {
            var names = new Dictionary<string, QualifiedStruct>();
            AddTypeLookup(names, message.Name, message.Structs);
            return names.ToImmutableDictionary();
        }

        private static void AddTypeLookup(
            Dictionary<string, QualifiedStruct> names,
            string fullName,
            IImmutableDictionary<string, Struct> structs
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
            Struct Struct
        );

        private static bool HasRecords(
            Message message,
            IReadOnlyDictionary<string, QualifiedStruct> structs
        ) =>
            HasRecords(
                message.Fields,
                structs
            )
        ;

        private static bool HasRecords(
            IEnumerable<Field> fields,
            IReadOnlyDictionary<string, QualifiedStruct> structs
        ) =>
            fields.Aggregate(
                false,
                (s, f) => s || IsRecords(
                    f.Type,
                    structs
                )
            )
        ;

        private static bool IsRecords(
            FieldType field,
            IReadOnlyDictionary<string, QualifiedStruct> structs
        ) =>
            field switch
            {
                RecordsFieldType _ => true,
                ArrayFieldType f => IsRecords(
                    f.ItemType,
                    structs
                ),
                StructFieldType f => HasRecords(
                    structs[f.Name].Struct.Fields,
                    structs
                ),
                _ => false
            }
        ;
    }
}
