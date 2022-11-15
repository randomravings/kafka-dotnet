//using Kafka.CodeGen.Models;
//using Kafka.CodeGen.Models.Extensions;

//namespace Kafka.CodeGen.CSharp
//{
//    internal static class RecordWriter
//    {
//        private static async ValueTask Write(
//            TextWriter writer,
//            Message message,
//            IReadOnlyDictionary<string, QualifiedStruct> typeLookup
//        )
//        {
//            var maxVersion = message.ValidVersions.Max;
//            var fields = message.Fields.Where(r => r.Versions.Includes(maxVersion));
//            await writer.WriteLineAsync($"    [GeneratedCode(\"{typeof(Generator).Assembly.GetName().Name}\", \"{typeof(Generator).Assembly.GetName().Version}\")]");
//            await writer.WriteLineAsync($"    public sealed record {message.Name} (");
//            await WriteFields(writer, message.Fields);
//            await writer.WriteLineAsync();
//            await writer.WriteAsync($"    )");
//            if (message.Structs.Any())
//            {
//                await writer.WriteLineAsync();
//                await writer.WriteLineAsync($"    {{");
//                await WriteMessageStructs(message.Structs, typeLookup, writer, 0);
//                await writer.WriteAsync($"    }}");
//            }
//            await writer.WriteLineAsync($";");
//        }

//        private static async ValueTask WriteStructs(
//            TextWriter writer,
//            IEnumerable<Field> fields
//        )
//        {
//            await writer.WriteAsync($"        {FieldToProperty(maxVersion, fields.First(), typeLookup)}");
//            foreach (var field in fields.Skip(1))
//            {
//                await writer.WriteLineAsync($",");
//                await writer.WriteAsync($"        {FieldToProperty(maxVersion, field, typeLookup)}");
//            }
//        }

//        private static async ValueTask WriteFields(
//            TextWriter writer,
//            IEnumerable<Field> fields
//        )
//        {
//            await writer.WriteAsync($"        {FieldToProperty(maxVersion, fields.First(), typeLookup)}");
//            foreach (var field in fields.Skip(1))
//            {
//                await writer.WriteLineAsync($",");
//                await writer.WriteAsync($"        {FieldToProperty(maxVersion, field, typeLookup)}");
//            }
//        }
//    }
//}
