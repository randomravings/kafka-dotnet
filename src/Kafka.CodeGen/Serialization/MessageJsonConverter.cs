using Kafka.CodeGen.Model;
using Kafka.Common.Model;
using Newtonsoft.Json;
using System.Collections.Immutable;
using VersionRange = Kafka.Common.Model.VersionRange;

namespace Kafka.CodeGen.Serialization
{
    internal sealed class MessageJsonConverter :
        JsonConverter<MessageDefinition>
    {
        public override bool CanRead => true;
        public override bool CanWrite => false;
        public override void WriteJson(
            JsonWriter writer,
            MessageDefinition? value,
            JsonSerializer serializer
        ) =>
            throw new NotImplementedException()
        ;

        public override MessageDefinition ReadJson(
            JsonReader reader,
            Type objectType,
            MessageDefinition? existingValue,
            bool hasExistingValue,
            JsonSerializer serializer
        )
        {
            var apiKey = ApiKey.None;
            var messageType = MessageType.None;
            var listenerBuilder = ImmutableSortedSet.CreateBuilder<Listener>();
            var name = "";
            var latestVersionUnstable = false;
            var validVersions = VersionRange.Empty;
            var flexibleVersions = VersionRange.Empty;
            var deprecatedVersions = VersionRange.Empty;
            var fieldsBuilder = ImmutableArray.CreateBuilder<Field>();
            var structsBuilder = ImmutableSortedDictionary.CreateBuilder <string, StructDefinition>();
            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonToken.PropertyName:
                        switch (reader.Value)
                        {
                            case "apiKey":
                                apiKey = (ApiKey)(reader.ReadAsInt32() ?? -1);
                                break;
                            case "type":
                                messageType = ParseMessageType(reader.ReadAsString() ?? "");
                                break;
                            case "listeners":
                                reader.Read(); // Start array
                                reader.Read(); // String or end array.
                                while (reader.TokenType != JsonToken.EndArray)
                                {
                                    listenerBuilder.Add(ParseListener((string)reader.Value));
                                    reader.Read();
                                }
                                break;
                            case "name":
                                name = reader.ReadAsString() ?? "";
                                break;
                            case "latestVersionUnstable":
                                latestVersionUnstable = reader.ReadAsBoolean() ?? false;
                                break;
                            case "validVersions":
                                var validVersionsValue = reader.ReadAsString() ?? "";
                                validVersions = ParseVersion(validVersionsValue);
                                break;
                            case "flexibleVersions":
                                var flexibleVersionsValue = reader.ReadAsString() ?? "";
                                flexibleVersions = ParseVersion(flexibleVersionsValue);
                                break;
                            case "deprecatedVersions":
                                var deprecatedVersionsValue = reader.ReadAsString() ?? "";
                                deprecatedVersions = ParseVersion(deprecatedVersionsValue);
                                break;
                            case "fields":
                                reader.Read(); // Start array
                                reader.Read(); // Start object
                                ParseFields(reader, fieldsBuilder, structsBuilder);
                                break;
                            case "commonStructs":
                                reader.Read(); // Start array
                                reader.Read(); // Start object
                                ParseStructs(reader, structsBuilder);
                                break;
                            default:
                                throw new InvalidOperationException($"Unknown message key '{reader.Value}'");
                        }
                        break;
                }
            }

            return new MessageDefinition(
                name,
                apiKey,
                messageType,
                latestVersionUnstable,
                validVersions,
                flexibleVersions,
                deprecatedVersions,
                listenerBuilder.ToImmutable(),
                fieldsBuilder.ToImmutable(),
                structsBuilder.ToImmutable()
            );
        }

        private static void ParseFields(
            JsonReader reader,
            ImmutableArray<Field>.Builder fields,
            ImmutableSortedDictionary<string, StructDefinition>.Builder structs
        )
        {
            while (reader.TokenType != JsonToken.EndArray)
            {
                var field = ParseField(
                    reader,
                    structs
                );
                fields.Add(field);
                reader.Read();
            }
        }

        private static void ParseStructs(
            JsonReader reader,
            ImmutableSortedDictionary<string, StructDefinition>.Builder structs
        )
        {
            while (reader.TokenType != JsonToken.EndArray)
            {
                ParseStruct(
                    reader,
                    structs
                );
                reader.Read();
            }
        }

        private static Field ParseField(
            JsonReader reader,
            IDictionary<string, StructDefinition> structs
        )
        {
            var name = "";
            var type = (FieldType)EmptyFieldType.Instance;
            var versions = VersionRange.Empty;
            var entityType = "";
            var about = "";
            var tag = -1;
            var ignorable = false;
            var mapKey = false;
            var nullableVersions = VersionRange.Empty;
            var defaultValue = "";
            var flexibleVersions = VersionRange.All;
            var taggedVersions = VersionRange.Empty;
            var zeroCopy = false;
            var localFieldsBuilder = ImmutableArray.CreateBuilder<Field>();
            var localStructsBuilder = ImmutableSortedDictionary.CreateBuilder<string, StructDefinition>();
            while (reader.TokenType != JsonToken.EndObject && reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonToken.PropertyName:
                        switch (reader.Value)
                        {
                            case "name":
                                name = reader.ReadAsString() ?? "";
                                break;
                            case "type":
                                var typeValue = reader.ReadAsString() ?? "";
                                type = GetFieldType(typeValue);
                                break;
                            case "versions":
                                var versionsValue = reader.ReadAsString() ?? "";
                                versions = ParseVersion(versionsValue);
                                break;
                            case "nullableVersions":
                                var nullableVersionsValue = reader.ReadAsString() ?? "";
                                nullableVersions = ParseVersion(nullableVersionsValue);
                                break;
                            case "taggedVersions":
                                var taggedVersionsValue = reader.ReadAsString() ?? "";
                                taggedVersions = ParseVersion(taggedVersionsValue);
                                break;
                            case "flexibleVersions":
                                var flexibleVersionsValue = reader.ReadAsString() ?? "";
                                flexibleVersions = ParseVersion(flexibleVersionsValue);
                                break;
                            case "entityType":
                                entityType = reader.ReadAsString() ?? "";
                                break;
                            case "about":
                                about = reader.ReadAsString() ?? "";
                                break;
                            case "tag":
                                tag = reader.ReadAsInt32() ?? -1;
                                break;
                            case "ignorable":
                                ignorable = reader.ReadAsBoolean() ?? false;
                                break;
                            case "mapKey":
                                mapKey = reader.ReadAsBoolean() ?? false;
                                break;
                            case "default":
                                defaultValue = reader.ReadAsString() ?? "";
                                break;
                            case "zeroCopy":
                                zeroCopy = reader.ReadAsBoolean() ?? false;
                                break;
                            case "fields":
                                reader.Read(); // Start array
                                reader.Read(); // Start object
                                ParseFields(
                                    reader,
                                    localFieldsBuilder,
                                    localStructsBuilder
                                );
                                break;
                            default:
                                throw new InvalidOperationException($"Unknown field key '{reader.Value}'");
                        }
                        break;
                }
            }

            if (type is EmptyFieldType)
                throw new InvalidOperationException("Unable to determine field type");

            var structType = GetStructType(type);
            if (structType != null && localFieldsBuilder.Count > 0)
                structs.Add(
                    structType.Name,
                    new(
                        structType.Name,
                        localFieldsBuilder.ToImmutableArray(),
                        localStructsBuilder.ToImmutableSortedDictionary()
                    )
                );

            return new(
                    Name: name,
                    Type: type,
                    Properties: new(
                        Versions: versions,
                        NullableVersions: nullableVersions,
                        TaggedVersions: taggedVersions,
                        FlexibleVersions: flexibleVersions,
                        EntityType: entityType,
                        About: about,
                        Ignorable: ignorable,
                        MapKey: mapKey,
                        ZeroCopy: zeroCopy,
                        Tag: tag
                    ),
                    DefaultValue: defaultValue
            );
        }

        private static StructFieldType? GetStructType(
            FieldType type
        ) =>
            type switch
            {
                StructFieldType s => s,
                ArrayFieldType a => GetStructType(a.ItemType),
                _ => default
            }
        ;


        private static void ParseStruct(
            JsonReader reader,
            ImmutableSortedDictionary<string, StructDefinition>.Builder structs
        )
        {
            var name = "";
            var fields = ImmutableArray.CreateBuilder<Field>();
            var localStructs = ImmutableSortedDictionary.CreateBuilder<string, StructDefinition>();
            while (reader.TokenType != JsonToken.EndObject && reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonToken.PropertyName:
                        switch (reader.Value)
                        {
                            case "name":
                                name = reader.ReadAsString() ?? "";
                                break;
                            case "versions":
                                var versionsValue = reader.ReadAsString() ?? "";
                                _ = ParseVersion(versionsValue);
                                break;
                            case "fields":
                                reader.Read(); // Start array
                                reader.Read(); // Start object
                                ParseFields(
                                    reader,
                                    fields,
                                    localStructs
                                );
                                break;
                            default:
                                throw new InvalidOperationException($"Unknown field key '{reader.Value}'");
                        }
                        break;
                }
            }

            structs.Add(
                name,
                new(
                    name,
                    fields.ToImmutableArray(),
                    localStructs.ToImmutableSortedDictionary()
                )
            );
        }

        private static FieldType GetFieldType(string type) =>
            (type.StartsWith("[]"), type) switch
            {
                (true, var t) => new ArrayFieldType(GetFieldType(t[2..])),
                (_, "bool") => new ScalarFieldType("bool"),
                (_, "int8") => new ScalarFieldType("int8"),
                (_, "int16") => new ScalarFieldType("int16"),
                (_, "uint16") => new ScalarFieldType("uint16"),
                (_, "int32") => new ScalarFieldType("int32"),
                (_, "uint32") => new ScalarFieldType("uint32"),
                (_, "int64") => new ScalarFieldType("int64"),
                (_, "uint64") => new ScalarFieldType("uint64"),
                (_, "varint") => new ScalarFieldType("uint32"),
                (_, "varlong") => new ScalarFieldType("uint64"),
                (_, "uuid") => new ScalarFieldType("uuid"),
                (_, "float64") => new ScalarFieldType("float64"),
                (_, "string") => new ScalarFieldType("string"),
                (_, "bytes") => new ScalarFieldType("bytes"),
                (_, "records") => RecordsFieldType.Instance,
                (_, var t) => new StructFieldType(t)
            }
        ;

        private static VersionRange ParseVersion(
            string versionString
        )
        {
            return versionString switch
            {
                "none" => VersionRange.Empty,
                var v => (v.IndexOf('+'), v.IndexOf('-')) switch
                {
                    (var p, -1) when p >= 0 => new VersionRange(short.Parse(v[..p]), short.MaxValue),
                    (-1, var d) when d >= 0 => new VersionRange(short.Parse(v[..d]), short.Parse(v[(d + 1)..])),
                    _ => new VersionRange(short.Parse(v), short.Parse(v))
                }
            };
        }

        private static MessageType ParseMessageType(
            string messageType
        )
        {
            return messageType switch
            {
                "header" => MessageType.Header,
                "request" => MessageType.Request,
                "response" => MessageType.Response,
                "data" => MessageType.Data,
                _ => MessageType.None
            };
        }

        private static Listener ParseListener(
            string listener
        ) =>
            listener.ToLower() switch
            {
                "zkbroker" => Listener.ZkBroker,
                "broker" => Listener.Broker,
                "controller" => Listener.Controller,
                _ => Listener.None
            }
        ;
    }
}
