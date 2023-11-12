using Kafka.CodeGen.Models;
using Kafka.CodeGen.Models.Extensions;
using Kafka.Common.Encoding;
using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;
using Kafka.Common.Protocol;
using Kafka.Common.Records;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.Data;
using System.IO.Abstractions;
using System.Text;

namespace Kafka.CodeGen.CSharp
{
    public static class Generator
    {
        private const string REQUEST_HEADER_TYPE = "RequestHeaderData";
        private const string RESPONSE_HEADER_TYPE = "ResponseHeaderData";
        private const string TAG_BUFFER = "TaggedFields";

        public static void WriteModel(
            IDirectoryInfo directoryInfo,
            MessageDefinition messageDefinition,
            string messageNamespace
        )
        {
            TestValidVersion(messageDefinition.ValidVersions);
            var typeLookup = CreateTypeLookup(messageDefinition);
            var typeFlags = GetUsings(messageDefinition, typeLookup);

            var usings = new List<string>();
            if (messageDefinition.FlexibleVersions.Some())
                usings.Add("Kafka.Common.Model");
            if (messageDefinition.FlexibleVersions.Some() || typeFlags.HasFlag(UsingsFlags.Array))
                usings.Add("System.Collections.Immutable");
            if (typeFlags.HasFlag(UsingsFlags.Record))
                usings.Add("Kafka.Common.Records");

            var messageName = GetMessageName(messageDefinition);
            var writer = CreateWriter(directoryInfo, messageName);
            WriteUsings(
                writer,
                messageNamespace,
                typeLookup,
                usings
            );
            writer.WriteLine($"namespace {messageNamespace} {{");
            WriteMessageRecord(
                writer,
                messageDefinition,
                "    "
            );
            writer.WriteLine("}");
            writer.Flush();
        }

        public static void WriteEncoder(
            IDirectoryInfo directoryInfo,
            MessageDefinition messageDefinition,
            string messageNamespace,
            string messageSerdeNamespace
        )
        {
            TestValidVersion(messageDefinition.ValidVersions);
            var typeLookup = CreateTypeLookup(messageDefinition);
            var typeFlags = GetUsings(messageDefinition, typeLookup);

            var usings = new List<string>
            {
                typeof(BinaryEncoder).Namespace ?? "",
                "Kafka.Common.Model",
                "Kafka.Common.Protocol",
                "System.Collections.Immutable",
                "Kafka.Common.Model.Extensions"
            };
            if (typeFlags.HasFlag(UsingsFlags.Record))
                usings.Add("Kafka.Common.Records");

            var writer = CreateWriter(
                directoryInfo,
                GetEncoderName(messageDefinition)
            );
            WriteUsings(
                writer,
                messageNamespace,
                typeLookup,
                usings
            );
            writer.Write("namespace ");
            writer.Write(messageSerdeNamespace);
            writer.WriteLine();
            writer.Write("{");
            writer.WriteLine();

            switch (messageDefinition.MessageType)
            {
                case MessageType.Header:
                    WriteHeaderEncoder(
                        writer,
                        messageDefinition,
                        "    "
                    );
                    break;
                case MessageType.Request:
                    WriteRequestEncoder(
                        writer,
                        messageDefinition,
                        "    "
                    );
                    break;
                case MessageType.Response:
                    WriteResponseEncoder(
                        writer,
                        messageDefinition,
                        "    "
                    );
                    break;
            }
            writer.Write("}");
            writer.WriteLine();

            writer.Flush();
        }

        public static void WriteDecoder(
            IDirectoryInfo directoryInfo,
            MessageDefinition messageDefinition,
            string messageNamespace,
            string messageSerdeNamespace
        )
        {
            TestValidVersion(messageDefinition.ValidVersions);
            var typeLookup = CreateTypeLookup(messageDefinition);
            var typeFlags = GetUsings(messageDefinition, typeLookup);

            var usings = new List<string>
            {
                typeof(BinaryEncoder).Namespace ?? "",
                "Kafka.Common.Model",
                "Kafka.Common.Protocol",
                "System.Collections.Immutable",
                "Kafka.Common.Model.Extensions"
            };
            if (typeFlags.HasFlag(UsingsFlags.Record))
                usings.Add("Kafka.Common.Records");

            var writer = CreateWriter(
                directoryInfo,
                GetDecoderName(messageDefinition)
            );
            WriteUsings(
                writer,
                messageNamespace,
                typeLookup,
                usings
            );
            writer.Write("namespace ");
            writer.Write(messageSerdeNamespace);
            writer.WriteLine();
            writer.Write("{");
            writer.WriteLine();
            switch (messageDefinition.MessageType)
            {
                case MessageType.Header:
                    WriteHeaderDecoder(
                        writer,
                        messageDefinition,
                        "    "
                    );
                    break;
                case MessageType.Request:
                    WriteRequestDecoder(
                        writer,
                        messageDefinition,
                        "    "
                    );
                    break;
                case MessageType.Response:
                    WriteResponseDecoder(
                        writer,
                        messageDefinition,
                        "    "
                    );
                    break;
                default:
                    throw new NotImplementedException($"Message type: '{messageDefinition.MessageType}'");
            }
            writer.WriteLine("}");
            writer.Flush();
        }

        private static void WriteHeaderEncoder(
            TextWriter writer,
            MessageDefinition messageDefinition,
            string indent
        )
        {
            var messageName = GetMessageName(messageDefinition);
            var className = GetEncoderName(messageDefinition);
            WriteCodeGenAttribute(
                writer,
                indent
            );
            writer.Write(indent);
            writer.Write("public static class ");
            writer.Write(className);
            writer.WriteLine();
            writer.Write(indent);
            writer.Write("{");
            writer.WriteLine();
            foreach (var version in messageDefinition.ValidVersions.Enumerate())
                WriteEncodeMethod(
                    writer,
                    messageDefinition.Fields,
                    messageName,
                    version,
                    messageDefinition.FlexibleVersions.Includes(version),
                    "public static",
                    $"{indent}    "
                );
            WriteStructEncoders(
                writer,
                messageDefinition.Structs,
                messageDefinition.ValidVersions,
                messageDefinition.FlexibleVersions,
                $"{indent}    "
            );
            writer.Write(indent);
            writer.Write("}");
            writer.WriteLine();
        }

        private static void WriteRequestEncoder(
            TextWriter writer,
            MessageDefinition messageDefinition,
            string indent
        )
        {
            var messageName = GetMessageName(messageDefinition);
            var className = GetEncoderName(messageDefinition);
            WriteCodeGenAttribute(
                writer,
                indent
            );
            writer.Write(indent);
            writer.Write("public class ");
            writer.Write(className);
            writer.Write(" : ");
            writer.WriteLine();
            writer.Write(indent);
            writer.Write("    ");
            writer.Write(ZipGenerics(typeof(RequestEncoder<,>), REQUEST_HEADER_TYPE, GetMessageName(messageDefinition)));
            writer.WriteLine();
            writer.Write(indent);
            writer.Write("{");
            writer.WriteLine();
            WriteConstructor(
                writer,
                messageDefinition,
                true,
                $"{indent}    "
            );
            WriteMethodOverrides(
                writer,
                messageDefinition,
                true,
                $"{indent}    "
            );
            foreach (var version in messageDefinition.ValidVersions.Enumerate())
                WriteEncodeMethod(
                    writer,
                    messageDefinition.Fields,
                    messageName,
                    version,
                    messageDefinition.FlexibleVersions.Includes(version),
                    "private static",
                    $"{indent}    "
                );
            WriteStructEncoders(
                writer,
                messageDefinition.Structs,
                messageDefinition.ValidVersions,
                messageDefinition.FlexibleVersions,
                $"{indent}    "
            );
            writer.Write(indent);
            writer.Write("}");
            writer.WriteLine();
        }

        private static void WriteConstructor(
            TextWriter writer,
            MessageDefinition messageDefinition,
            bool isEncoder,
            string indent
        )
        {
            var messageName = GetMessageName(messageDefinition);
            var className = isEncoder ? GetEncoderName(messageDefinition) : GetDecoderName(messageDefinition);
            var readWrite = isEncoder ? "Write" : "Read";
            var encodeDecode = isEncoder ? "Encoder" : "Decoder";
            writer.WriteLine($"{indent}public {className}() :");
            writer.WriteLine($"{indent}    base(");
            writer.WriteLine($"{indent}        {nameof(ApiKey)}.{messageDefinition.ApiKey},");
            writer.WriteLine($"{indent}        new({messageDefinition.ValidVersions.Min.Value}, {messageDefinition.ValidVersions.Max.Value}),");
            writer.WriteLine($"{indent}        new({messageDefinition.FlexibleVersions.Min.Value}, {messageDefinition.FlexibleVersions.Max.Value}),");
            writer.WriteLine($"{indent}        {messageDefinition.MessageType}Header{encodeDecode}.{readWrite}V0,");
            writer.WriteLine($"{indent}        {readWrite}V0");
            writer.WriteLine($"{indent}    )");
            writer.WriteLine($"{indent}{{ }}");
        }

        private static void WriteMethodOverrides(
            TextWriter writer,
            MessageDefinition messageDefinition,
            bool isEncoder,
            string indent
        )
        {
            var messageName = GetMessageName(messageDefinition);
            var className = GetDecoderName(messageDefinition);
            var readWrite = isEncoder ? "Write" : "Read";
            var encodeDecode = isEncoder ? "Encoder" : "Decoder";
            var headerType = messageDefinition.MessageType == MessageType.Request ? REQUEST_HEADER_TYPE : RESPONSE_HEADER_TYPE;
            var delegateType = isEncoder ? typeof(EncodeDelegate<>) : typeof(DecodeDelegate<>);
            switch (messageDefinition.ApiKey, messageDefinition.MessageType)
            {
                case (ApiKey.ApiVersions, MessageType.Response):
                    writer.WriteLine($"{indent}protected override {ZipGenerics(delegateType, headerType)} GetHeader{encodeDecode}(short apiVersion) =>");
                    writer.WriteLine($"{indent}    {messageDefinition.MessageType}Header{encodeDecode}.{readWrite}V0");
                    writer.WriteLine($"{indent};");
                    break;
                case (_, MessageType.Request):
                    writer.WriteLine($"{indent}protected override {ZipGenerics(delegateType, headerType)} GetHeader{encodeDecode}(short apiVersion)");
                    writer.WriteLine($"{indent}{{");
                    writer.WriteLine($"{indent}    if (_flexibleVersions.Includes(apiVersion))");
                    writer.WriteLine($"{indent}        return {messageDefinition.MessageType}Header{encodeDecode}.{readWrite}V2;");
                    writer.WriteLine($"{indent}    else");
                    writer.WriteLine($"{indent}        return {messageDefinition.MessageType}Header{encodeDecode}.{readWrite}V1;");
                    writer.WriteLine($"{indent}}}");
                    break;
                case (_, MessageType.Response):
                    writer.WriteLine($"{indent}protected override {ZipGenerics(delegateType, headerType)} GetHeader{encodeDecode}(short apiVersion)");
                    writer.WriteLine($"{indent}{{");
                    writer.WriteLine($"{indent}    if (_flexibleVersions.Includes(apiVersion))");
                    writer.WriteLine($"{indent}        return {messageDefinition.MessageType}Header{encodeDecode}.{readWrite}V1;");
                    writer.WriteLine($"{indent}    else");
                    writer.WriteLine($"{indent}        return {messageDefinition.MessageType}Header{encodeDecode}.{readWrite}V0;");
                    writer.WriteLine($"{indent}}}");
                    break;
            }
            writer.WriteLine($"{indent}protected override {ZipGenerics(delegateType, messageName)} GetMessage{encodeDecode}(short apiVersion) =>");
            writer.WriteLine($"{indent}    apiVersion switch");
            writer.WriteLine($"{indent}    {{");
            foreach (var verision in messageDefinition.ValidVersions.Enumerate())
                writer.WriteLine($"{indent}        {verision} => {readWrite}V{verision},");
            writer.WriteLine($"{indent}        _ => throw new {nameof(NotSupportedException)}()");
            writer.WriteLine($"{indent}    }}");
            writer.WriteLine($"{indent};");
        }

        private static void WriteResponseEncoder(
            TextWriter writer,
            MessageDefinition messageDefinition,
            string indent
        )
        {
            var messageName = GetMessageName(messageDefinition);
            var className = GetEncoderName(messageDefinition);
            WriteCodeGenAttribute(
                writer,
                indent
            );
            writer.Write(indent);
            writer.Write("public class ");
            writer.Write(className);
            writer.Write(" : ");
            writer.WriteLine();
            writer.Write(indent);
            writer.Write("    ");
            writer.Write(ZipGenerics(typeof(ResponseEncoder<,>), RESPONSE_HEADER_TYPE, GetMessageName(messageDefinition)));
            writer.WriteLine();
            writer.Write(indent);
            writer.Write("{");
            writer.WriteLine();
            foreach (var version in messageDefinition.ValidVersions.Enumerate())
                WriteDecodeMethod(
                    writer,
                    messageDefinition.Fields,
                    messageName,
                    version,
                    messageDefinition.FlexibleVersions.Includes(version),
                    "private static",
                    $"{indent}    "
                );
            WriteConstructor(
                writer,
                messageDefinition,
                true,
                $"{indent}    "
            );
            WriteMethodOverrides(
                writer,
                messageDefinition,
                true,
                $"{indent}    "
            );
            writer.Write(indent);
            writer.Write("}");
            writer.WriteLine();
        }

        private static void WriteHeaderDecoder(
            TextWriter writer,
            MessageDefinition messageDefinition,
            string indent
        )
        {
            var messageName = GetMessageName(messageDefinition);
            var className = GetDecoderName(messageDefinition);
            WriteCodeGenAttribute(
                writer,
                indent
            );
            writer.Write(indent);
            writer.Write("public static class ");
            writer.Write(className);
            writer.WriteLine();
            writer.Write(indent);
            writer.Write("{");
            writer.WriteLine();
            foreach (var version in messageDefinition.ValidVersions.Enumerate())
                WriteDecodeMethod(
                    writer,
                    messageDefinition.Fields,
                    messageName,
                    version,
                    messageDefinition.FlexibleVersions.Includes(version),
                    "public static",
                    $"{indent}    "
                );
            WriteStructDecoders(
                writer,
                messageDefinition.Structs,
                messageDefinition.ValidVersions,
                messageDefinition.FlexibleVersions,
                $"{indent}    "
            );
            writer.Write(indent);
            writer.Write("}");
            writer.WriteLine();
        }

        private static void WriteRequestDecoder(
            TextWriter writer,
            MessageDefinition messageDefinition,
            string indent
        )
        {
            var messageName = GetMessageName(messageDefinition);
            var className = GetDecoderName(messageDefinition);
            WriteCodeGenAttribute(
                writer,
                indent
            );
            writer.Write(indent);
            writer.Write("public class ");
            writer.Write(className);
            writer.Write(" : ");
            writer.WriteLine();
            writer.Write(indent);
            writer.Write("    ");
            writer.Write(ZipGenerics(typeof(RequestDecoder<,>), REQUEST_HEADER_TYPE, GetMessageName(messageDefinition)));
            writer.WriteLine();
            writer.Write(indent);
            writer.Write("{");
            writer.WriteLine();
            WriteConstructor(
                writer,
                messageDefinition,
                false,
                $"{indent}    "
            );
            WriteMethodOverrides(
                writer,
                messageDefinition,
                false,
                $"{indent}    "
            );
            foreach (var version in messageDefinition.ValidVersions.Enumerate())
                WriteEncodeMethod(
                    writer,
                    messageDefinition.Fields,
                    messageName,
                    version,
                    messageDefinition.FlexibleVersions.Includes(version),
                    "private static",
                    $"{indent}    "
                );
            WriteStructDecoders(
                writer,
                messageDefinition.Structs,
                messageDefinition.ValidVersions,
                messageDefinition.FlexibleVersions,
                $"{indent}    "
            );
            writer.Write(indent);
            writer.Write("}");
            writer.WriteLine();
        }

        private static void WriteResponseDecoder(
            TextWriter writer,
            MessageDefinition messageDefinition,
            string indent
        )
        {
            var messageName = GetMessageName(messageDefinition);
            var className = GetDecoderName(messageDefinition);
            WriteCodeGenAttribute(
                writer,
                indent
            );
            writer.Write(indent);
            writer.Write("public class ");
            writer.Write(className);
            writer.Write(" : ");
            writer.WriteLine();
            writer.Write(indent);
            writer.Write("    ");
            writer.Write(ZipGenerics(typeof(ResponseDecoder<,>), RESPONSE_HEADER_TYPE, GetMessageName(messageDefinition)));
            writer.WriteLine();
            writer.Write(indent);
            writer.Write("{");
            writer.WriteLine();
            WriteConstructor(
                writer,
                messageDefinition,
                false,
                $"{indent}    "
            );
            WriteMethodOverrides(
                writer,
                messageDefinition,
                false,
                $"{indent}    "
            );
            foreach (var version in messageDefinition.ValidVersions.Enumerate())
                WriteDecodeMethod(
                    writer,
                    messageDefinition.Fields,
                    messageName,
                    version,
                    messageDefinition.FlexibleVersions.Includes(version),
                    "private static",
                    $"{indent}    "
                );
            WriteStructDecoders(
                writer,
                messageDefinition.Structs,
                messageDefinition.ValidVersions,
                messageDefinition.FlexibleVersions,
                $"{indent}    "
            );
            writer.Write(indent);
            writer.Write("}");
            writer.WriteLine();
        }

        private static void WriteStructEncoders(
            TextWriter writer,
            ImmutableSortedDictionary<string, StructDefinition> structDefinitions,
            VersionRange versions,
            VersionRange flexibleVersions,
            string indent
        )
        {
            foreach (var structDefinition in structDefinitions)
                WriteStructEncoder(
                    writer,
                    structDefinition.Value,
                    versions,
                    flexibleVersions,
                    indent
                );
        }

        private static void WriteStructDecoders(
            TextWriter writer,
            ImmutableSortedDictionary<string, StructDefinition> structDefinitions,
            VersionRange versions,
            VersionRange flexibleVersions,
            string indent
        )
        {
            foreach (var structDefinition in structDefinitions)
                WriteStructDecoder(
                    writer,
                    structDefinition.Value,
                    versions,
                    flexibleVersions,
                    indent
                );
        }

        private static void WriteStructEncoder(
            TextWriter writer,
            StructDefinition structDefinition,
            VersionRange versions,
            VersionRange flexibleVersions,
            string indent
        )
        {
            var messageName = GetMessageName(structDefinition);
            var className = GetEncoderName(structDefinition);
            WriteCodeGenAttribute(
                writer,
                indent
            );
            writer.Write(indent);
            writer.Write("private static class ");
            writer.Write(className);
            writer.WriteLine();
            writer.Write(indent);
            writer.Write("{");
            writer.WriteLine();
            foreach (var version in versions.Enumerate())
                WriteEncodeMethod(
                    writer,
                    structDefinition.Fields,
                    messageName,
                    version,
                    flexibleVersions.Includes(version),
                    "public static",
                    $"{indent}    "
                );
            WriteStructEncoders(
                    writer,
                    structDefinition.Structs,
                    versions,
                    flexibleVersions,
                    $"{indent}    "
                );
            writer.Write(indent);
            writer.Write("}");
            writer.WriteLine();
        }

        private static void WriteStructDecoder(
            TextWriter writer,
            StructDefinition structDefinition,
            VersionRange versions,
            VersionRange flexibleVersions,
            string indent
        )
        {
            var messageName = GetMessageName(structDefinition);
            var className = GetDecoderName(structDefinition);
            WriteCodeGenAttribute(
                writer,
                indent
            );
            writer.Write(indent);
            writer.Write("private static class ");
            writer.Write(className);
            writer.WriteLine();
            writer.Write(indent);
            writer.Write("{");
            writer.WriteLine();
            foreach (var version in versions.Enumerate())
                WriteDecodeMethod(
                    writer,
                    structDefinition.Fields,
                    messageName,
                    version,
                    flexibleVersions.Includes(version),
                    "public static",
                    $"{indent}    "
                );
            foreach (var nestedStructDefintition in structDefinition.Structs)
                WriteStructDecoder(
                    writer,
                    nestedStructDefintition.Value,
                    versions,
                    flexibleVersions,
                    $"{indent}    "
                );
            writer.Write(indent);
            writer.Write("}");
            writer.WriteLine();
        }

        private static void WriteCodeGenAttribute(
            TextWriter writer,
            string indent
        )
        {
            var assemblyName = typeof(Generator).Assembly.GetName();
            writer.Write(indent);
            writer.Write("[");
            writer.Write(typeof(GeneratedCodeAttribute).Name);
            writer.Write("(\"");
            writer.Write(assemblyName.Name);
            writer.Write("\", \"");
            writer.Write(assemblyName.Version);
            writer.Write("\")]");
            writer.WriteLine();
        }

        public static void WriteEncodeMethod(
            TextWriter writer,
            ImmutableArray<Field> fields,
            string messageName,
            short version,
            bool flexible,
            string methodKeywords,
            string indent
        )
        {
            writer.Write(indent);
            writer.Write(methodKeywords);
            writer.Write(" int WriteV");
            writer.Write(version);
            writer.Write("(byte[] buffer, int index, ");
            writer.Write(messageName);
            writer.Write(" message)");
            writer.WriteLine();
            writer.Write(indent);
            writer.Write("{");
            writer.WriteLine();
            EncodeUntaggedFields(writer, indent, fields, flexible, version, "message");
            if (flexible)
                EncodeTaggedFields(writer, fields, version, flexible, "message", indent);
            writer.Write(indent);
            writer.Write("    return index;");
            writer.WriteLine();
            writer.Write(indent);
            writer.Write("}");
            writer.WriteLine();
        }

        public static void WriteDecodeMethod(
            TextWriter writer,
            ImmutableArray<Field> fields,
            string messageName,
            short version,
            bool flexible,
            string methodKeywords,
            string indent
        )
        {
            writer.Write(indent);
            writer.Write(methodKeywords);
            writer.Write(" ");
            writer.Write(ZipGenerics(typeof(DecodeResult<>), messageName));
            writer.Write(" ReadV");
            writer.Write(version);
            writer.Write("(byte[] buffer, int index)");
            writer.WriteLine();
            writer.Write(indent);
            writer.Write("{");
            writer.WriteLine();
            DecodeFieldDeclare(writer, fields, $"{indent}    ");
            DecodeFields(writer, fields, flexible, version, $"{indent}    ");
            if (flexible)
                DecodeTaggedFields(writer, fields, version, flexible, indent);
            DecodeReturnValue(writer, fields, $"{indent}    ");
            writer.Write(indent);
            writer.Write("}");
            writer.WriteLine();
        }

        private static void WriteUsings(
            TextWriter writer,
            string messageNamespace,
            IReadOnlyDictionary<string, QualifiedStruct> typeLookup,
            IEnumerable<string> namespaces
        )
        {
            foreach (var ns in namespaces.Append("System.CodeDom.Compiler").Order())
                writer.WriteLine($"using {ns};");
            foreach (var type in typeLookup)
                writer.WriteLine($"using {type.Value.Name} = {messageNamespace}.{type.Value.ParentName};");
            writer.WriteLine();
        }

        private static void WriteMessageRecord(
            TextWriter writer,
            MessageDefinition message,
            string indent
        )
        {
            var messageName = GetMessageName(message);
            var assemblyName = typeof(Generator).Assembly.GetName();
            WriteSummary(writer, indent, message);
            writer.WriteLine($"{indent}[GeneratedCode(\"{assemblyName.Name}\", \"{assemblyName.Version}\")]");
            writer.WriteLine($"{indent}public sealed record {GetMessageName(message)} (");
            WriteFields(
                writer,
                message.Fields,
                $"{indent}    "
            );
            writer.Write($"{indent})");
            if (message.Name.EndsWith($"Request"))
                writer.WriteLine($" : {nameof(RequestMessage)} (TaggedFields)");
            else if (message.Name.EndsWith("Response"))
                writer.WriteLine($" : {nameof(ResponseMessage)} (TaggedFields)");
            else if (message.Name == "RequestHeader")
                writer.WriteLine($" : {nameof(RequestHeader)} (CorrelationIdField, TaggedFields)");
            else if (message.Name.EndsWith("ResponseHeader"))
                writer.WriteLine($" : {nameof(ResponseHeader)} (CorrelationIdField, TaggedFields)");
            else
                writer.WriteLine();
            writer.WriteLine($"{indent}{{");
            WriteDefaultEmptyValue(
                writer,
                messageName,
                message.Fields,
                $"{indent}    "
            );
            foreach (var @struct in message.Structs)
                WriteStructRecord(
                    writer,
                    @struct.Value,
                    $"{indent}    "
                );
            writer.WriteLine($"{indent}}};");
        }

        private static void WriteStructRecord(
            TextWriter writer,
            StructDefinition structDefinition,
            string indent
        )
        {
            var messageName = GetMessageName(structDefinition);
            var assemblyName = typeof(Generator).Assembly.GetName();
            WriteSummary(writer, indent, structDefinition);
            writer.WriteLine($"{indent}[GeneratedCode(\"{assemblyName.Name}\", \"{assemblyName.Version}\")]");
            writer.WriteLine($"{indent}public sealed record {GetMessageName(structDefinition)} (");
            WriteFields(
                writer,
                structDefinition.Fields,
                $"{indent}    "
            );
            writer.Write($"{indent})");
            writer.WriteLine();
            writer.WriteLine($"{indent}{{");
            WriteDefaultEmptyValue(
                writer,
                messageName,
                structDefinition.Fields,
                $"{indent}    "
            );
            foreach (var @struct in structDefinition.Structs)
                WriteStructRecord(
                    writer,
                    @struct.Value,
                    $"{indent}    "
                );
            writer.WriteLine($"{indent}}};");
        }

        private static void WriteDefaultEmptyValue(
            TextWriter writer,
            string name,
            ImmutableArray<Field> fields,
            string indent
        )
        {
            writer.WriteLine($"{indent}public static {name} Empty {{ get; }} = new(");
            var value = DefaultValue(fields.First());
            writer.Write($"{indent}    {value}");
            foreach (var field in fields.Skip(1))
            {
                value = DefaultValue(field);
                writer.WriteLine(",");
                writer.Write($"{indent}    {value}");
            }
            writer.WriteLine($",");
            writer.WriteLine($"{indent}    ImmutableArray<{nameof(TaggedField)}>.Empty");
            writer.WriteLine($"{indent});");
        }

        private static void WriteFields(
            TextWriter writer,
            IEnumerable<Field> fields,
            string indent
        )
        {
            WriteFieldProperty(writer, indent, fields.First());
            foreach (var field in fields.Skip(1))
            {
                writer.WriteLine($",");
                WriteFieldProperty(writer, indent, field);
            }
            writer.WriteLine($",");
            writer.WriteLine($"{indent}ImmutableArray<{nameof(TaggedField)}> {TAG_BUFFER}");
        }

        private static void WriteItems<TItem>(
            TextWriter writer,
            IEnumerable<TItem> items,
            Func<TItem, string> stringify,
            string separator,
            bool newline
        )
        {
            var enumerator = items.GetEnumerator();
            if (!enumerator.MoveNext())
                return;
            var value = stringify(enumerator.Current);
            writer.Write(value);
            while (enumerator.MoveNext())
            {
                writer.Write(separator);
                if (newline)
                    writer.WriteLine();
                value = stringify(enumerator.Current);
                writer.Write(value);
            }
        }

        private static void WriteApiDetails(
            TextWriter writer,
            string messageName,
            ApiKey apiKey,
            VersionRange versions,
            VersionRange flexibleVersions,
            string indent
        )
        {
            writer.WriteLine($"{indent}private static readonly {nameof(ApiKey)} ApiKey = {nameof(ApiKey)}.{apiKey};");
            writer.WriteLine($"{indent}private static readonly {nameof(VersionRange)} ApiVersions = new ({versions.Min.Value}, {versions.Max.Value});");
            writer.WriteLine($"{indent}private static readonly {nameof(VersionRange)} FlexibleVersions = new ({flexibleVersions.Min.Value}, {flexibleVersions.Max.Value});");
        }

        //private static void WriteMessageSerde(
        //    TextWriter writer,
        //    MessageDefinition messageDefinition,
        //    VersionRange versions,
        //    VersionRange flexibleVersions,
        //    string indent
        //)
        //{
        //    var serdeModifier = "public";
        //    var messageName = GetMessageName(messageDefinition);
        //    if (messageDefinition is ApiRequestDefinition || messageDefinition is ApiResponseDefinition || messageDefinition is RequestHeaderDefinition)
        //    {
        //        var header = messageDefinition is ApiRequestDefinition ? "RequestHeader" : "ResponseHeader";
        //        var encoder = $"{(messageDefinition is ApiRequestDefinition ? typeof(EncodeDelegate<>) : typeof(EncodeDelegate<>)).Name.Split('`')[0]}<{messageDefinition.Name}Data>";
        //        var decoder = $"{(messageDefinition is ApiRequestDefinition ? typeof(DecodeDelegate<>) : typeof(EncodeDelegate<>)).Name.Split('`')[0]}<{messageDefinition.Name}Data>";
        //        serdeModifier = "private";
        //        writer.WriteLine($"        private static readonly {nameof(ApiKey)} ApiKey = {nameof(ApiKey)}.{messageDefinition.ApiKey};");
        //        writer.WriteLine($"        private static readonly {nameof(VersionRange)} ApiVersions = new ({messageDefinition.ValidVersions.Min.Value}, {messageDefinition.ValidVersions.Max.Value});");
        //        writer.WriteLine($"        private static readonly {nameof(VersionRange)} FlexibleVersions = new ({messageDefinition.FlexibleVersions.Min.Value}, {messageDefinition.FlexibleVersions.Max.Value});");
        //        writer.WriteLine($"        private static readonly {ZipGenerics(typeof(ImmutableArray<>), ZipGenerics(typeof(EncodeDelegate<>), messageName))} Encoders = ImmutableArray.Create<EncodeDelegate<{messageName}>>(");
        //        WriteItems(
        //            writer,
        //            messageDefinition.ValidVersions.Enumerate(),
        //            v => $"            WriteV{v}",
        //            ",",
        //            true
        //        );
        //        writer.WriteLine();
        //        writer.WriteLine($"        );");
        //        writer.WriteLine($"        private static readonly {ZipGenerics(typeof(ImmutableArray<>), ZipGenerics(typeof(DecodeDelegate<>), messageName))} Decoders = ImmutableArray.Create<DecodeDelegate<{messageName}>>(");
        //        WriteItems(
        //            writer,
        //            messageDefinition.ValidVersions.Enumerate(),
        //            v => $"            ReadV{v}",
        //            ",",
        //            true
        //        );
        //        writer.WriteLine();
        //        writer.WriteLine($"        );");
        //    }
        //    if (messageDefinition is RequestHeaderDefinition headerMessage)
        //    {
        //        serdeModifier = "private";
        //        writer.WriteLine($"        private static readonly {ZipGenerics(typeof(ImmutableArray<>), ZipGenerics(typeof(EncodeDelegate<>), messageName))} UntaggedEncoders = ImmutableArray.Create<EncodeDelegate<{messageName}>>(");
        //        WriteItems(
        //            writer,
        //            messageDefinition.ValidVersions.Enumerate(),
        //            v => $"            WriteUntaggedV{v}",
        //            ",",
        //            true
        //        );
        //        writer.WriteLine();
        //        writer.WriteLine($"        );");
        //        writer.WriteLine($"        public static readonly {ZipGenerics(typeof(ImmutableArray<>), ZipGenerics(typeof(DecodeDelegate<>), messageName))} UntaggedDecoders = ImmutableArray.Create<DecodeDelegate<{messageName}>>(");
        //        WriteItems(
        //            writer,
        //            messageDefinition.ValidVersions.Enumerate(),
        //            v => $"            ReadUntaggedV{v}",
        //            ",",
        //            true
        //        );
        //        writer.WriteLine();
        //        writer.WriteLine($"        );");
        //    }
        //    foreach (var version in versions.Enumerate())
        //    {
        //        var flexible = flexibleVersions.Includes(version);
        //        var variableList = new List<string>();
        //        writer.WriteLine($"{indent}{serdeModifier} static int WriteV{version}(byte[] buffer, int index, {messageName} message)");
        //        writer.WriteLine($"{indent}{{");
        //        EncodeUntaggedFields(writer, indent, messageDefinition.Fields, flexible, version, "message");
        //        EncodeTaggedFields(writer, indent, "message", messageDefinition, version);
        //        writer.WriteLine($"{indent}    return index;");
        //        writer.WriteLine($"{indent}}}");
        //        writer.WriteLine($"{indent}{serdeModifier} static  {ZipGenerics(typeof(DecodeResult<>), messageName)} ReadV{version}(byte[] buffer, int index)");
        //        writer.WriteLine($"{indent}{{");
        //        DecodeFieldDeclare(writer, $"{indent}    ", messageDefinition);
        //        DecodeFields(writer, $"{indent}    ", messageDefinition.Fields, flexible, version);
        //        DecodeTaggedFields(writer, indent, messageDefinition.Fields, flexible, version);
        //        DecodeReturnValue(writer, $"{indent}    ", messageDefinition);
        //        writer.WriteLine($"{indent}}}");


        //        if (messageDefinition is RequestHeaderDefinition)
        //        {
        //            writer.WriteLine($"{indent}{serdeModifier} static int WriteUntaggedV{version}(byte[] buffer, int index, {GetMessageName(messageDefinition)} message)");
        //            writer.WriteLine($"{indent}{{");
        //            foreach (var field in messageDefinition.Fields.Where(f => f.Properties.Versions.Includes(version)))
        //                EncodeField(writer, $"{indent}    ", flexible, field, version, $"message.{FieldPropertyNamify(field)}");
        //            writer.WriteLine($"{indent}    return index;");
        //            writer.WriteLine($"{indent}}}");
        //            variableList.Clear();
        //            writer.WriteLine($"{indent}{serdeModifier} static {ZipGenerics(typeof(DecodeResult<>), messageName)} ReadUntaggedV{version}(byte[] buffer, int index)");
        //            writer.WriteLine($"{indent}{{");
        //            DecodeFieldDeclare(writer, $"{indent}    ", messageDefinition);
        //            DecodeFields(writer, $"{indent}    ", messageDefinition.Fields, flexible, version);
        //            DecodeReturnValue(writer, $"{indent}    ", messageDefinition);
        //            writer.WriteLine($"{indent}}}");
        //        }
        //    }
        //    foreach (var @struct in messageDefinition.Structs.Values)
        //        WriteMessageRecordExtension(writer, @struct, versions, flexibleVersions, indent);
        //}

        private static void DecodeFieldDeclare(
            TextWriter writer,
            ImmutableArray<Field> fields,
            string indent
        )
        {
            foreach (var field in fields)
            {
                var variable = FieldVariableNamify(field);
                var defaultValue = DefaultValue(field);
                writer.Write(indent);
                writer.Write("var ");
                writer.Write(variable);
                writer.Write(" = ");
                writer.Write(defaultValue);
                writer.WriteLine(";");
            }
            writer.WriteLine($"{indent}var taggedFields = ImmutableArray<{nameof(TaggedField)}>.Empty;");
        }

        private static void DecodeFields(
            TextWriter writer,
            ImmutableArray<Field> fields,
            bool flexible,
            short version,
            string indent
        )
        {
            var untaggedFields = GetUntaggedFields(fields, version);
            foreach (var untaggedField in untaggedFields)
            {
                var variable = FieldVariableNamify(untaggedField);
                DecodeField(writer, indent, flexible, untaggedField, version, variable);
            }
        }

        private static void DecodeReturnValue(TextWriter writer, ImmutableArray<Field> fields, string indent)
        {
            writer.WriteLine($"{indent}return new(index, new(");
            foreach (var field in fields)
            {
                var variable = FieldVariableNamify(field);
                writer.WriteLine($"{indent}    {variable},");
            }
            writer.WriteLine($"{indent}    taggedFields");
            writer.WriteLine($"{indent}));");
        }

        private static void EncodeUntaggedFields(
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
                EncodeField(writer, $"{indent}    ", flexible, field, version, $"{referenceName}.{FieldPropertyNamify(field)}");
            }
        }

        private static void EncodeTaggedFields(
            TextWriter writer,
            IEnumerable<Field> fields,
            short version,
            bool flexible,
            string referenceName,
            string indent
        )
        {
            if (!flexible)
                return;
            var taggedFields = GetKnownTaggedFields(fields, version);
            var requiredTaggedFieldsCount = taggedFields.Where(r => !IsNullable(r, version)).Count();
            var optionalTaggedFields = taggedFields.Where(r => IsNullable(r, version)).ToImmutableArray();
            var startTag = -1;
            if (taggedFields.Any())
                startTag = taggedFields.Max(r => r.Properties.Tag);
            writer.WriteLine($"{indent}    var taggedFieldsCount = {requiredTaggedFieldsCount}u;");
            writer.WriteLine($"{indent}    var previousTagged = {startTag};");
            foreach (var optionalTaggedField in optionalTaggedFields)
            {
                var propertyName = FieldPropertyNamify(optionalTaggedField);
                writer.WriteLine($"{indent}    if({referenceName}.{propertyName} != null)");
                writer.WriteLine($"{indent}        taggedFieldsCount++;");
            }
            writer.WriteLine($"{indent}    taggedFieldsCount += (uint){referenceName}.{TAG_BUFFER}.Length;");
            writer.WriteLine($"{indent}    index = {nameof(BinaryEncoder)}.{nameof(BinaryEncoder.WriteVarUInt32)}(buffer, index, taggedFieldsCount);");
            foreach (var taggedField in taggedFields.OrderBy(r => r.Properties.Tag))
            {
                var propertyName = FieldPropertyNamify(taggedField);
                if (IsNullable(taggedField))
                    writer.WriteLine($"{indent}    if({referenceName}.{propertyName} != null)");
                writer.WriteLine($"{indent}    {{");
                writer.WriteLine($"{indent}        index = {nameof(BinaryEncoder)}.{nameof(BinaryEncoder.WriteVarInt32)}(buffer, index, {taggedField.Properties.Tag});");
                EncodeField(writer, $"{indent}        ", true, taggedField, version, $"{referenceName}.{propertyName}");
                writer.WriteLine($"{indent}    }}");
            }
            writer.WriteLine($"{indent}    foreach(var taggedField in {referenceName}.{TAG_BUFFER})");
            writer.WriteLine($"{indent}    {{");
            writer.WriteLine($"{indent}        if(taggedField.{nameof(TaggedField.Tag)} <= previousTagged)");
            writer.WriteLine($"{indent}            throw new {nameof(InvalidOperationException)}($\"Reserved or out of order tag: {{taggedField.{nameof(TaggedField.Tag)}}} - Reserved Range: {startTag}\");");
            writer.WriteLine($"{indent}        index = {nameof(BinaryEncoder)}.{nameof(BinaryEncoder.WriteVarInt32)}(buffer, index, taggedField.{nameof(TaggedField.Tag)});");
            writer.WriteLine($"{indent}        index = {nameof(BinaryEncoder)}.{nameof(BinaryEncoder.WriteCompactBytes)}(buffer, index, taggedField.{nameof(TaggedField.Value)});");
            writer.WriteLine($"{indent}    }}");
        }

        private static void DecodeTaggedFields(
            TextWriter writer,
            IEnumerable<Field> fields,
            short version,
            bool flexible,
            string indent
        )
        {
            if (!flexible)
                return;
            var taggedFields = GetKnownTaggedFields(fields, version);

            writer.WriteLine($"{indent}    (index, var taggedFieldsCount) = {nameof(BinaryDecoder)}.{nameof(BinaryDecoder.ReadVarUInt32)}(buffer, index);");
            writer.WriteLine($"{indent}    if (taggedFieldsCount > 0)");
            writer.WriteLine($"{indent}    {{");
            writer.WriteLine($"{indent}        var taggedFieldsBuilder = ImmutableArray.CreateBuilder<{nameof(TaggedField)}>();");
            writer.WriteLine($"{indent}        while (taggedFieldsCount > 0)");
            writer.WriteLine($"{indent}        {{");
            writer.WriteLine($"{indent}            (index, var tag) = {nameof(BinaryDecoder)}.{nameof(BinaryDecoder.ReadVarInt32)}(buffer, index);");
            if (taggedFields.Length > 0)
                DecodeTaggedKnown(writer, $"{indent}            ", taggedFields, version);
            else
                DecodeTaggedUnknown(writer, $"{indent}            ");
            writer.WriteLine($"{indent}            taggedFieldsCount--;");
            writer.WriteLine($"{indent}        }}");
            writer.WriteLine($"{indent}    }}");
        }

        private static void DecodeTaggedKnown(
            TextWriter writer,
            string indent,
            IEnumerable<Field> taggedFields,
            short version
        )
        {
            writer.WriteLine($"{indent}switch (tag)");
            writer.WriteLine($"{indent}{{");
            foreach (var taggedField in taggedFields.OrderBy(r => r.Properties.Tag))
            {
                var variable = FieldVariableNamify(taggedField);
                writer.WriteLine($"{indent}    case {taggedField.Properties.Tag}:");
                DecodeField(writer, $"{indent}        ", true, taggedField, version, variable);
                writer.WriteLine($"{indent}        break;");
            }
            writer.WriteLine($"{indent}    default:");
            DecodeTaggedUnknown(writer, $"{indent}        ");
            writer.WriteLine($"{indent}        break;");
            writer.WriteLine($"{indent}}}");
        }

        private static void DecodeTaggedUnknown(
            TextWriter writer,
            string indent
        )
        {
            writer.WriteLine($"{indent}(index, var bytes) = {nameof(BinaryDecoder)}.{nameof(BinaryDecoder.ReadCompactBytes)}(buffer, index);");
            writer.WriteLine($"{indent}taggedFieldsBuilder.Add(new(tag, bytes));");
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

        private static void WriteSummary(
            TextWriter writer,
            string indent,
            MessageDefinition message
        )
        {
            writer.WriteLine($"{indent}/// <summary>");
            WriteFieldDocumentations(writer, indent, message.Fields);
            writer.WriteLine($"{indent}/// </summary>");
        }

        private static void WriteSummary(
            TextWriter writer,
            string indent,
            StructDefinition @struct
        )
        {
            writer.WriteLine($"{indent}/// <summary>");
            WriteFieldDocumentations(writer, indent, @struct.Fields);
            writer.WriteLine($"{indent}/// </summary>");
        }

        private static void WriteFieldDocumentations(
            TextWriter writer,
            string indent,
            IEnumerable<Field> fields
        )
        {
            foreach (var field in fields)
            {
                writer.Write(indent);
                writer.Write(@"/// <param name=""");
                writer.Write(FieldPropertyNamify(field));
                writer.Write(@""">");
                writer.Write(field.Properties.About);
                writer.Write(@"</param>");
                writer.WriteLine();
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

        private static void WriteFieldProperty(
            TextWriter writer,
            string indent,
            Field field
        )
        {
            writer.Write(indent);
            writer.Write(FieldTypify(field));
            writer.Write(' ');
            writer.Write(FieldPropertyNamify(field));
        }

        private static string QualifyType(
            FieldType fieldType
        ) =>
            fieldType switch
            {
                StructFieldType f => $"{GetMessageName(f)}",
                ArrayFieldType f => $"ImmutableArray<{QualifyType(f.ItemType)}>",
                RecordsFieldType => "ImmutableArray<IRecords>",
                FieldType f => f.ToSystemType()
            }
        ;

        private static void EncodeField(
            TextWriter writer,
            string indent,
            bool flexible,
            Field field,
            short version,
            string dereference
        )
        {
            EncodeIfNullThrow(
                writer,
                indent,
                field,
                version,
                dereference
            );
            writer.Write(indent);
            writer.Write("index = ");
            var flexibleField = flexible && field.Properties.FlexibleVersions.Includes(version);
            switch (field.Type)
            {
                case ArrayFieldType a:
                    EncodeArrayField(writer, indent, flexibleField, field.Properties, a, version, dereference);
                    break;
                case StructFieldType s:
                    EncodeStructField(writer, s, version, dereference);
                    break;
                case RecordsFieldType r:
                    EncodeRecordsField(writer, indent, flexibleField, field.Properties, r, version, dereference);
                    break;
                case ScalarFieldType f:
                    EncodeScalarField(writer, indent, flexibleField, field.Properties, f, version, dereference);
                    break;
                default:
                    throw new InvalidOperationException($"Unsupported field type '{field.Type.GetType().Name}'");
            }
        }

        private static void EncodeIfNullThrow(
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
            writer.WriteLine($"{indent}if ({dereference} == null)");
            writer.WriteLine($"{indent}    throw new {nameof(ArgumentNullException)}(nameof({dereference}));");
        }

        private static void EncodeStructField(
            TextWriter writer,
            StructFieldType fieldType,
            short version,
            string dereference
        )
        {
            writer.WriteLine($"{GetEncoderName(fieldType)}.WriteV{version}(buffer, index, {dereference});");
        }

        private static void EncodeRecordsField(
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
                writer.WriteLine($"{nameof(BinaryEncoder)}.{nameof(BinaryEncoder.WriteCompactRecords)}(buffer, index, {dereference});");
            else
                writer.WriteLine($"{nameof(BinaryEncoder)}.{nameof(BinaryEncoder.WriteRecords)}(buffer, index, {dereference});");
        }

        private static void EncodeScalarField(
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
            writer.WriteLine($"{nameof(BinaryEncoder)}.{scalarWrite}(buffer, index, {dereference});");
        }

        private static void EncodeArrayField(
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
            writer.Write($"{nameof(BinaryEncoder)}.Write");
            if (flexible)
                writer.Write("Compact");
            writer.Write($"Array<{typeArg}>(buffer, index, {dereference}, ");
            switch (fieldType.ItemType)
            {
                case StructFieldType s:
                    writer.Write($"{GetEncoderName(s)}.WriteV{version}");
                    break;
                case RecordsFieldType r:
                    writer.WriteLine($"{nameof(BinaryEncoder)}{nameof(BinaryEncoder.WriteRecords)}");
                    break;
                case ScalarFieldType f:
                    writer.Write($"{nameof(BinaryEncoder)}.{ScalarFieldToEncode(f, false, fieldProperties.FlexibleVersions.Includes(version))}");
                    break;

                default:
                    throw new InvalidOperationException($"Unsupported array field item type '{fieldType.GetType().Name}'");
            }
            writer.WriteLine($");");
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

        private static void DecodeField(
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
            writer.Write(indent);
            writer.Write($"(index, ");
            if (field.Type is ArrayFieldType && !nullable)
                writer.Write($"var _{reference}_");
            else
                writer.Write(reference);
            writer.Write(") = ");
            DecodeFieldStatement(writer, indent, flexible, nullable, field, version, reference);
        }

        private static void DecodeFieldStatement(
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
                    DecodeArrayField(writer, indent, field.Name, flexible, field.Properties, a, version, dereference);
                    break;
                case StructFieldType s:
                    DecodeStructField(writer, s, version);
                    break;
                case RecordsFieldType r:
                    DecodeRecordsField(writer, indent, field.Name, flexible, nullable, r, version, dereference);
                    break;
                case ScalarFieldType f:
                    DecodeScalarField(writer, flexible, nullable, f, version);
                    break;
                default:
                    throw new InvalidOperationException($"Unsupported field type '{field.Type.GetType().Name}'");
            }
        }

        private static void DecodeArrayField(
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
            writer.Write($"{nameof(BinaryDecoder)}.Read");
            if (flexible)
                writer.Write("Compact");
            writer.Write($"Array");
            writer.Write($"<{typeArg}>(buffer, index, ");
            switch (fieldType.ItemType)
            {
                case StructFieldType s:
                    writer.Write($"{GetDecoderName(s)}.ReadV{version}");
                    break;
                case RecordsFieldType r:
                    writer.WriteLine($"{nameof(BinaryDecoder)}{nameof(BinaryDecoder.ReadRecords)}");
                    break;
                case ScalarFieldType f:
                    writer.Write($"{nameof(BinaryDecoder)}.{ScalarFieldToDecode(f, false, fieldProperties.FlexibleVersions.Includes(version))}");
                    break;
                default:
                    throw new InvalidOperationException($"Unsupported array field item type '{fieldType.GetType().Name}'");
            }
            writer.Write($")");
            if (!fieldProperties.NullableVersions.Includes(version))
            {
                writer.WriteLine($";");
                writer.WriteLine(@$"{indent}if (_{dereference}_ == null)");
                writer.WriteLine(@$"{indent}    throw new {nameof(NullReferenceException)}(""Null not allowed for '{fieldName}'"");");
                writer.WriteLine(@$"{indent}else");
                writer.Write(@$"{indent}    {dereference} = _{dereference}_.Value");
            }
            writer.WriteLine(";");
        }

        private static void DecodeStructField(
            TextWriter writer,
            StructFieldType fieldType,
            short version
        ) =>
            writer.WriteLine($"{GetDecoderName(fieldType)}.ReadV{version}(buffer, index);")
        ;

        private static void DecodeRecordsField(
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
            if (flexible)
                writer.Write($"{nameof(BinaryDecoder)}.{nameof(BinaryDecoder.ReadCompactRecords)}(buffer, index)");
            else
                writer.Write($"{nameof(BinaryDecoder)}.{nameof(BinaryDecoder.ReadRecords)}(buffer, index)");
            if (!nullable)
            {
                writer.WriteLine($";");
                writer.WriteLine(@$"{indent}if ({dereference} == null)");
                writer.Write(@$"{indent}    throw new {nameof(NullReferenceException)}(""Null not allowed for '{fieldName}'"")");
            }
            writer.WriteLine($";");
        }

        private static void DecodeScalarField(
            TextWriter writer,
            bool flexible,
            bool nullable,
            ScalarFieldType fieldType,
            short version
        )
        {
            var scalarRead = ScalarFieldToDecode(fieldType, nullable, flexible);
            writer.WriteLine($"{nameof(BinaryDecoder)}.{scalarRead}(buffer, index);");
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
                ("bytes", false) => @"Array.Empty<byte>()",
                _ => $"default({fieldType.ToSystemType()}{(nullable ? "?" : "")})"
            }
        ;

        private static string DefaultStruct(
            StructFieldType fieldType,
            bool nullable
        ) =>
            nullable switch
            {
                true => $"default{GetMessageName(fieldType)}",
                false => $"{GetMessageName(fieldType)}.Empty"
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
                (StructFieldType f, false) => $"ImmutableArray<{GetMessageName(f)}>.Empty",
                (ScalarFieldType f, true) => $"default(ImmutableArray<{f.ToSystemType()}>?)",
                (RecordsFieldType f, true) => $"default(ImmutableArray<{nameof(IRecords)}>?)",
                (StructFieldType f, true) => $"default(ImmutableArray<{GetMessageName(f)}>?)",
                _ => "default",
            }
        ;

        private static IReadOnlyDictionary<string, QualifiedStruct> CreateTypeLookup(
            MessageDefinition message
        )
        {
            var names = new Dictionary<string, QualifiedStruct>();
            AddTypeLookup(names, $"{GetMessageName(message)}", message.Structs);
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
                var name = GetMessageName(kv.Value);
                var newFullName = $"{fullName}.{name}";
                if (!names.ContainsKey(kv.Key))
                    names.Add(kv.Key, new(name, newFullName, kv.Value));
                AddTypeLookup(names, newFullName, kv.Value.Structs);
            }
        }

        private sealed record QualifiedStruct(
            string Name,
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

        private static string ZipGenerics(
            Type genericType,
            params string[] genericArguments
        )
        {
            var generingTypeName = GetGenericBaseName(genericType);
            return $"{generingTypeName}<{string.Join(", ", genericArguments)}>";
        }

        private static string GetGenericBaseName(
            Type genericType
        ) =>
            genericType.GetGenericTypeDefinition().Name.Split('`', StringSplitOptions.RemoveEmptyEntries)[0]
        ;

        private static TextWriter CreateWriter(
            IDirectoryInfo directoryInfo,
            string fileName
        )
        {
            var fileSystem = directoryInfo.FileSystem;
            var path = fileSystem.Path.Join(directoryInfo.FullName, $"{fileName}.cs");
            return new StreamWriter(
                fileSystem.FileStream.New(
                    fileSystem.Path.Combine(
                        path
                    ),
                    FileMode.Create,
                    FileAccess.Write,
                    FileShare.ReadWrite
                )
            );
        }

        private static string GetMessageName(StructFieldType structFieldType) =>
            $"{structFieldType.Name}"
        ;

        private static string GetMessageName(MessageDefinition messageDefinition) =>
            $"{messageDefinition.Name}Data"
        ;

        private static string GetMessageName(StructDefinition structDefinition) =>
            $"{structDefinition.Name}"
        ;

        private static string GetEncoderName(MessageDefinition messageDefinition) =>
            $"{messageDefinition.Name}Encoder"
        ;

        private static string GetEncoderName(StructDefinition structDefinition) =>
            $"{structDefinition.Name}Encoder"
        ;

        private static string GetEncoderName(StructFieldType structFieldType) =>
            $"{structFieldType.Name}Encoder"
        ;

        private static string GetDecoderName(MessageDefinition messageDefinition) =>
            $"{messageDefinition.Name}Decoder"
        ;

        private static string GetDecoderName(StructDefinition structDefinition) =>
            $"{structDefinition.Name}Decoder"
        ;

        private static string GetDecoderName(StructFieldType structFieldType) =>
            $"{structFieldType.Name}Decoder"
        ;
    }
}
